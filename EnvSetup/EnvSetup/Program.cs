using System;
using System.IO;
using System.Security.Principal;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace EnvSetup
{
    class CheckAdmin
    {
        public static bool IsAdministrator()
        {
            WindowsIdentity Current = WindowsIdentity.GetCurrent();
            WindowsPrincipal WPrincipal = new WindowsPrincipal(Current);
            return WPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
    class SysEnvironment
    {
        private static RegistryKey OpenSysEnvironment()
        {
            RegistryKey regLocalMachine = Registry.LocalMachine;
            RegistryKey regSYSTEM = regLocalMachine.OpenSubKey("SYSTEM", true);
            RegistryKey regControlSet001 = regSYSTEM.OpenSubKey("ControlSet001", true);
            RegistryKey regControl = regControlSet001.OpenSubKey("Control", true);
            RegistryKey regManager = regControl.OpenSubKey("Session Manager", true);
            RegistryKey regEnvironment = regManager.OpenSubKey("Environment", true);
            return regEnvironment;
        }

        public static string GetSysEnvironmentByName(string name)
        {
            string result = string.Empty;
            try
            {
                result = OpenSysEnvironment().GetValue(name).ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
            return result;
        }
        public static void SetSysEnvironment(string name, string strValue)
        {
            OpenSysEnvironment().SetValue(name, strValue);
        }

        public static void SetPathAfter(string strValue, string strHome)
        {
            string pathlist;
            pathlist = GetSysEnvironmentByName(strValue);
            if (pathlist.Substring(pathlist.Length - 1, 1) != ";")
            {
                SetSysEnvironment(strValue, pathlist + ";");
                pathlist = GetSysEnvironmentByName(strValue);
            }
            string[] list = pathlist.Split(';');
            bool isPathExist = false;

            foreach (string item in list)
            {
                if (item == strHome)
                    isPathExist = true;
            }
            if (!isPathExist)
            {
                SetSysEnvironment(strValue, pathlist + strHome + ";");
                Console.WriteLine(strValue + ":" + strHome + "  添加完成");
            }

        }

        public static void AddNewPath(string strValue, string strHome)
        {
            OpenSysEnvironment().SetValue(strValue, strHome);
            Console.WriteLine(strValue + ":" + strHome + "  添加完成");
        }

        public static bool CheckPathisExist(string strPachValue)
        {
            try
            {
                if (Directory.Exists(strPachValue))
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            if (CheckAdmin.IsAdministrator())
            {
                if (SysEnvironment.CheckPathisExist("C:\\Program Files (x86)\\Tesseract-OCR"))
                {
                    SysEnvironment.SetPathAfter("PATH", "C:\\Program Files (x86)\\Tesseract-OCR");
                    SysEnvironment.SetPathAfter("PATH", "C:\\Program Files (x86)\\Tesseract-OCR\\tessdata");
                    SysEnvironment.AddNewPath("TESSDATA_PREFIX", "C:\\Program Files (x86)\\Tesseract-OCR\\");
                    Console.WriteLine("操作完成 重启电脑后生效");
                }
                else if (SysEnvironment.CheckPathisExist("C:\\Program Files\\Tesseract-OCR"))
                {
                    SysEnvironment.SetPathAfter("PATH", "C:\\Program Files\\Tesseract-OCR");
                    SysEnvironment.SetPathAfter("PATH", "C:\\Program Files\\Tesseract-OCR\\tessdata");
                    SysEnvironment.AddNewPath("TESSDATA_PREFIX", "C:\\Program Files\\Tesseract-OCR\\");
                    Console.WriteLine("操作完成 重启电脑后生效");
                }
                else if (SysEnvironment.CheckPathisExist("D:\\Program Files (x86)\\Tesseract-OCR"))
                {
                    SysEnvironment.SetPathAfter("PATH", "D:\\Program Files (x86)\\Tesseract-OCR");
                    SysEnvironment.SetPathAfter("PATH", "D:\\Program Files (x86)\\Tesseract-OCR\\tessdata");
                    SysEnvironment.AddNewPath("TESSDATA_PREFIX", "D:\\Program Files (x86)\\Tesseract-OCR\\");
                    Console.WriteLine("操作完成 重启电脑后生效");
                }
                else if (SysEnvironment.CheckPathisExist("D:\\Program Files\\Tesseract-OCR"))
                {
                    SysEnvironment.SetPathAfter("PATH", "D:\\Program Files\\Tesseract-OCR");
                    SysEnvironment.SetPathAfter("PATH", "D:\\Program Files\\Tesseract-OCR\\tessdata");
                    SysEnvironment.AddNewPath("TESSDATA_PREFIX", "D:\\Program Files\\Tesseract-OCR\\");
                    Console.WriteLine("操作完成 重启电脑后生效");
                }
                else
                {
                    Console.WriteLine("请检查Tesseract-OCR安装目录");
                }
            }
            else
            {
                Console.WriteLine("请使用管理员权限运行");
            }
            

            //SysEnvironment.GetSysEnvironmentByName("PATH");

            Console.WriteLine("按任意键退出...");
            Console.ReadKey();
        }
    }
}
