using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AnantMatrimony.UD_CLASS
{
    class EventLogging
    {
        public bool AppErrlog(string error)
        {
            StreamWriter writer = null;
            string str = Convert.ToString(DateTime.Now.ToString("ddMMyyyy"));
            bool flag = File.Exists("C:/ApplicationLog/AanantErrLog/AppLog_" + str + ".txt");
            if (Directory.Exists("C:/ApplicationLog/AanantErrLog"))
            {
                if (flag)
                {
                    writer = new StreamWriter("C:/ApplicationLog/AanantErrLog/AppLog_" + str + ".txt", true);
                    writer.WriteLine(this.WriteInFile(error));
                    writer.Close();
                    return true;
                }
                File.Create("C:/ApplicationLog/AanantErrLog/AppLog_" + str + ".txt").Close();
                writer = new StreamWriter("C:/ApplicationLog/AanantErrLog/AppLog_" + str + ".txt", true);
                writer.WriteLine(this.WriteInFile(error));
                writer.Close();
                return true;
            }
            Directory.CreateDirectory("C:/ApplicationLog/AanantErrLog");
            File.Create("C:/ApplicationLog/AanantErrLog/AppLog_" + str + ".txt").Close();
            writer = new StreamWriter("C:/ApplicationLog/AanantErrLog/AppLog_" + str + ".txt", true);
            writer.WriteLine(this.WriteInFile(error));
            writer.Close();
            return true;
        }
        public bool AppClickLog(string Event, string ClickName, string ProfileId, string MemberCode, string Remark)
        {
            StreamWriter writer = null;
            string str = Convert.ToString(DateTime.Now.ToString("ddMMyyyy"));
            bool flag = File.Exists("C:/ApplicationLog/AanantClickLog/AppClickLog_" + str + ".txt");
            if (Directory.Exists("C:/ApplicationLog/AanantClickLog"))
            {
                if (flag)
                {
                    writer = new StreamWriter("C:/ApplicationLog/AanantClickLog/AppClickLog_" + str + ".txt", true);
                    writer.WriteLine(this.WriteInFileLog(Event, ClickName, ProfileId, MemberCode, Remark));
                    writer.Close();
                    return true;
                }
                File.Create("C:/ApplicationLog/AanantClickLog/AppClickLog_" + str + ".txt").Close();
                writer = new StreamWriter("C:/ApplicationLog/AanantClickLog/AppClickLog_" + str + ".txt", true);
                writer.WriteLine(this.WriteInFileLog(Event, ClickName, ProfileId, MemberCode, Remark));
                writer.Close();
                return true;
            }
            Directory.CreateDirectory("C:/ApplicationLog/AanantClickLog");
            File.Create("C:/ApplicationLog/AanantClickLog/AppClickLog_" + str + ".txt").Close();
            writer = new StreamWriter("C:/ApplicationLog/AanantClickLog/AppClickLog_" + str + ".txt", true);
            writer.WriteLine(this.WriteInFileLog(Event, ClickName, ProfileId, MemberCode, Remark));
            writer.Close();
            return true;
        }
        public string WriteInFile(string error)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("============================================\r\n");
            builder.Append(" \r\n");
            builder.Append("Error Occured At " + DateTime.Now.TimeOfDay.ToString() + "\r\n");
            builder.Append("-----------------------------------------------------\r\n");
            builder.Append(error + "\r\n");
            builder.Append(" \r\n");
            return Convert.ToString(builder);
        }
        public string WriteInFileLog(string Event, string ClickName, string ProfileId, string MemberCode, string Remark)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("============================================\r\n");
            builder.Append(" \r\n");
            builder.Append("Click Occured At " + DateTime.Now.TimeOfDay.ToString() + "\r\n");
            builder.Append("-----------------------------------------------------\r\n");
            builder.Append("Event : " + Event + ",ClickName : " + ClickName + ",ProfileId : " + ProfileId + ",MemberCode : " + MemberCode + "\r\n");
            builder.Append(Remark + "\r\n");
            return Convert.ToString(builder);
        }
        //Writes a Database Error to Log file 
        public bool DataBaseErrlog(string error)
        {
            StreamWriter writer = null;
            string str = Convert.ToString(DateTime.Now.ToString("ddMMyyyy"));
            bool flag = File.Exists("C:/ApplicationLog/AanantErrLog/DBLog_" + str + ".txt");
            if (Directory.Exists("C:/ApplicationLog/AanantErrLog"))
            {
                if (flag)
                {
                    writer = new StreamWriter("C:/ApplicationLog/AanantErrLog/DBLog_" + str + ".txt", true);
                    writer.WriteLine(this.WriteInFile(error));
                    writer.Close();
                    return true;
                }
                File.Create("C:/ApplicationLog/AanantErrLog/AppLog_" + str + ".txt").Close();
                writer = new StreamWriter("C:/ApplicationLog/AanantErrLog/DBLog_" + str + ".txt", true);
                writer.WriteLine(this.WriteInFile(error));
                writer.Close();
                return true;
            }
            Directory.CreateDirectory("C:/ApplicationLog/AanantErrLog");
            File.Create("C:/ApplicationLog/AanantErrLog/AppLog_" + str + ".txt").Close();
            writer = new StreamWriter("C:/ApplicationLog/AanantErrLog/DBLog_" + str + ".txt", true);
            writer.WriteLine(this.WriteInFile(error));
            writer.Close();
            return true;
        }


    }
}
