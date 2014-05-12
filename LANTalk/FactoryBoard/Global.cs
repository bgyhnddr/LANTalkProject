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
        public const string WH = "WH";
        public const string eWH = "e-WH";
        public const string SMT = "SMT";
        public const string SSP = "SSP";
        public const string Normal = "Normal";
        public const string UnNormal = "Unnormal";
        public const string UnKnown = "0-Unknown";
        public const string Receive = "4-Receive";
        public const string Wait = "1-Wait";
        public const string Undo = "2-Undo";
        public const string Sending = "3-Sending";

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

        public const int WAITTIME = 15;

        public static DateTime LastMoveTime;

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
            path += "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv";
            File.WriteAllText(path, CSVHelper.MakeCSV(table), Encoding.GetEncoding("GB2312"));
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


    public enum SortOrder
    {
        Ascending,
        Descending
    }
    public class RowComparer : IComparer<DataRow>
    {
        public Dictionary<int, SortOrder> SortColumns { get; set; }
        public int Compare(System.Data.DataRow x, System.Data.DataRow y)
        {
            int returnValue = 0;
            foreach (int key in SortColumns.Keys)
            {
                int compareResult;
                // Check for nulls
                if (x.ItemArray[key] == DBNull.Value
                           && y.ItemArray[key] == DBNull.Value)
                    compareResult = 0;
                else if (x.ItemArray[key] == DBNull.Value)
                    compareResult = -1;
                else if (y.ItemArray[key] == DBNull.Value)
                    compareResult = 1;
                else
                {
                    if (key == 0)
                    {
                        compareResult = ExCompare(x.ItemArray[key], y.ItemArray[key]);
                    }
                    else
                        // Compare anything else as a string
                        compareResult =
                             String.Compare(x.ItemArray[key].ToString(),
                                            y.ItemArray[key].ToString());
                }
                if (compareResult != 0)
                {
                    returnValue =
                       SortColumns[key] == SortOrder.Ascending ?
                                      compareResult : -compareResult;
                    break;
                }
            }
            return returnValue;
        }

        int ExCompare(Object x, Object y)
        {
            if (x == null || y == null)
                throw new ArgumentException("Parameters can't be null");
            string fileA = x as string;
            string fileB = y as string;
            char[] arr1 = fileA.ToCharArray();
            char[] arr2 = fileB.ToCharArray();
            int i = 0, j = 0;
            while (i < arr1.Length && j < arr2.Length)
            {
                if (char.IsDigit(arr1[i]) && char.IsDigit(arr2[j]))
                {
                    string s1 = "", s2 = "";
                    while (i < arr1.Length && char.IsDigit(arr1[i]))
                    {
                        s1 += arr1[i];
                        i++;
                    }
                    while (j < arr2.Length && char.IsDigit(arr2[j]))
                    {
                        s2 += arr2[j];
                        j++;
                    }
                    if (int.Parse(s1) > int.Parse(s2))
                    {
                        return 1;
                    }
                    if (int.Parse(s1) < int.Parse(s2))
                    {
                        return -1;
                    }
                }
                else
                {
                    if (arr1[i] > arr2[j])
                    {
                        return 1;
                    }
                    if (arr1[i] < arr2[j])
                    {
                        return -1;
                    }
                    i++;
                    j++;
                }
            }
            if (arr1.Length == arr2.Length)
            {
                return 0;
            }
            else
            {
                return arr1.Length > arr2.Length ? 1 : -1;
            }
        }
    }
}
