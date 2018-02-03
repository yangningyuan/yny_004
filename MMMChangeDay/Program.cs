using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace MMMChangeDay
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient MyWebClient = new WebClient();
            MyWebClient.Credentials = CredentialCache.DefaultCredentials;
            MyWebClient.DownloadData(System.Configuration.ConfigurationManager.AppSettings["url"]);
            return;
        }
        private static void Log(string text)
        {
            string path = System.Configuration.ConfigurationManager.AppSettings["logPath"];
            if (!File.Exists(path))
            {
                FileInfo file = new FileInfo(path);
                //创建文件   
                FileStream fs = file.Create();
                //关闭文件流   
                fs.Close();
            }
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(path, true))
            {
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss ") + "~" + text);
            }
        }
    }
}
