﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.IO;
using System.Data;
using LANTalk.Core;

namespace FactoryBoard
{
    enum Mode
    {
        OnlineList,
        SendOrder,
        Request
    }

    public class Department
    {
        public string IP;
        public string Name;
        public List<DataTable> SendList;
    }

    public class Global
    {

        public const string ASS = "ASS";
        public const string IJ = "IJ";
        public const string WH = "W/H";
        public const string eWH = "e-W/H";
        public const string SMT = "SMT";
        public const string SSP = "SSP";
        public const string Normal = "正常";
        public const string UnNormal = "异常";

        Global()
        {
        }



        public static string[] GetLoaclIPList()
        {
            var IPList = new List<string>();

            ManagementObjectSearcher query = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'");

            ManagementObjectCollection queryCollection = query.Get();

            foreach (ManagementObject mo in queryCollection)
            {
                var IP = string.Empty;

                string[] addresses = (string[])mo["IPAddress"];
                if (addresses == null || addresses.Length == 0)
                {
                    continue;
                }

                var ipcount = IPList.Where(o => o == addresses[0]).Count();

                if (ipcount == 0)
                {
                    IPList.Add(addresses[0]);
                }
            }
            return IPList.ToArray();
        }

        public static bool ConfigExists()
        {
            var path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += "\\LANTalk\\LANTalk.config";
            return File.Exists(path);
        }

        public static DataTable LoadConfig()
        {
            try
            {
                var path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                path += "\\LANTalk\\LANTalk.config";
                return CSVHelper.ReadCSVToTable(path);
            }
            catch
            {
                return null;
            }
        }

        public static bool FileExists(string fileName)
        {
            var path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += "\\LANTalk\\SaveFile";
            path += "\\" + fileName;
            return File.Exists(path);
        }

        public static void SaveFile(DataTable table)
        {
            var path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += "\\LANTalk\\SaveFile";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var current = path + "\\current.csv";
            path += "\\" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".csv";
            File.WriteAllText(path, CSVHelper.MakeCSV(table), Encoding.GetEncoding("GB2312"));
            File.WriteAllText(current, CSVHelper.MakeCSV(table), Encoding.GetEncoding("GB2312"));
        }
    }

    
}