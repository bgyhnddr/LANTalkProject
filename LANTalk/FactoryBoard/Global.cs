using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.IO;
using System.Data;
using LANTalk.Core;
using System.Net.Sockets;
using System.Media;

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
        public bool Online;
        public DataTable OrderList;
        public Socket Socketor;

        public Department(string ip, string name, bool online, DataTable table)
        {
            IP = ip;
            Name = name;
            Online = online;
            OrderList = table;
        }
    }

    public class Global
    {

        public const string ASS = "ASS";
        public const string IJ = "IJ";
        public const string WH = "W/H";
        public const string eWH = "e-W/H";
        public const string SMT = "SMT";
        public const string SSP = "SSP";
        public const string Normal = "Normal";
        public const string UnNormal = "Unnormal";
        public const string UnKnown = "Unknown";
        public const string Receive = "Receive";
        public const string Wait = "Wait";
        public const string Undo = "Undo";
        public const string Sending = "Sending";

        public static string ErrorMessage;

        public const string WAVFile = "sound.wav";

        public const string DEPARTMENT_STRING = "department";
        public const string ASS_STRING = "ASS";
        public const string WH_STRING = "WH";
        public const string eWH_STRING = "eWH";
        public const string IJ_STRING = "IJ";
        public const string SMT_STRING = "SMT";
        public const string SSP_STRING = "SSP";
        public const string PORT_STRING = "Port";

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

        public static void SaveConfig(DataTable table)
        {
            var path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += "\\LANTalk";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path += "\\LANTalk.config";



            File.WriteAllText(path, CSVHelper.MakeCSV(table), Encoding.GetEncoding("GB2312"));
        }

        public static void SaveFile(DataTable table, string currentDept)
        {
            var path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += "\\LANTalk\\SaveFile\\" + currentDept;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var current = path + "\\current.csv";
            path += "\\" + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".csv";
            File.WriteAllText(path, CSVHelper.MakeCSV(table), Encoding.GetEncoding("GB2312"));
            File.WriteAllText(current, CSVHelper.MakeCSV(table), Encoding.GetEncoding("GB2312"));
        }

        public static void PlaySound()
        {
            var path = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path += "\\LANTalk\\" + Global.WAVFile;

            if (File.Exists(path))
            {
                SoundPlayer player = new System.Media.SoundPlayer();
                player.SoundLocation = path;
                player.Play();
            }
        }
    }
}
