using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.IO;

namespace DBUtility
{
    public enum EffentNextType
    {
        /// <summary>
        /// 对其他语句无任何影响 
        /// </summary>
        None,
        /// <summary>
        /// 当前语句必须为"select count(1) from .."格式，如果存在则继续执行，不存在回滚事务
        /// </summary>
        WhenHaveContine,
        /// <summary>
        /// 当前语句必须为"select count(1) from .."格式，如果不存在则继续执行，存在回滚事务
        /// </summary>
        WhenNoHaveContine,
        /// <summary>
        /// 当前语句影响到的行数必须大于0，否则回滚事务
        /// </summary>
        ExcuteEffectRows,
        /// <summary>
        /// 引发事件-当前语句必须为"select count(1) from .."格式，如果不存在则继续执行，存在回滚事务
        /// </summary>
        SolicitationEvent
    }
    public class CommandInfo
    {
        public object ShareObject = null;
        public object OriginalData = null;
        event EventHandler _solicitationEvent;
        public event EventHandler SolicitationEvent
        {
            add
            {
                _solicitationEvent += value;
            }
            remove
            {
                _solicitationEvent -= value;
            }
        }
        public void OnSolicitationEvent()
        {
            if (_solicitationEvent != null)
            {
                _solicitationEvent(this, new EventArgs());
            }
        }
        public string CommandText;
        public System.Data.Common.DbParameter[] Parameters;
        public EffentNextType EffentNextType = EffentNextType.None;
        public CommandInfo()
        {

        }
        public CommandInfo(string sqlText, SqlParameter[] para)
        {
            this.CommandText = sqlText;
            this.Parameters = para;
        }
        public CommandInfo(string sqlText, SqlParameter[] para, EffentNextType type)
        {
            this.CommandText = sqlText;
            this.Parameters = para;
            this.EffentNextType = type;
        }
    }
    public class LogHelper
    {
        public static string GetAppBaseDirctory()
        {

            string path = string.Empty;
            if (System.Environment.CurrentDirectory == AppDomain.CurrentDomain.BaseDirectory)
            {
                //Windows应用程序则相等
                path = AppDomain.CurrentDomain.BaseDirectory;
            }
            else
            {

                // path = AppDomain.CurrentDomain.BaseDirectory + "Bin/";
                path = AppDomain.CurrentDomain.BaseDirectory;
            }
            return path;
        }

        //在网站根目录下创建日志目录
        public static string path = GetAppBaseDirctory() + "log/";

        //对象锁
        public static object objlock = new object();

        public static void Log(string type, string content, string filename = null)
        {
            StringBuilder strbuid = new StringBuilder();
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (string.IsNullOrEmpty(filename))
            {
                filename = string.Format("{0}/{1}.log", path, DateTime.Now.ToString("yyyyMMdd"));
            }
            else
            {
                try
                {
                    if (new FileInfo(path + filename).Length > 1024 * 1024 * 5)
                    {
                        int num = filename.LastIndexOf('_');
                        if (num < 0)
                        {
                            filename = string.Format("{0}_{1}.log", filename.Substring(0, filename.LastIndexOf('.')), 1);
                        }
                        else
                        {
                            filename = string.Format("{0}_{1}.log", filename.Substring(0, filename.LastIndexOf('.')), num++);
                        }
                    }
                    else
                    {
                        filename = string.Format("{0}/{1}.log", path, filename);
                    }
                }
                catch
                {
                    filename = string.Format("{0}/{1}.log", path, filename);
                }
            }

            strbuid.AppendFormat("\r\n================{0}========{1}========\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"), type);
            strbuid.AppendFormat(" {0}\r\n", content);
            lock (objlock)
            {
                StreamWriter sw = new StreamWriter(filename, true);
                sw.Write(strbuid.ToString());
                sw.Close();
            }
        }
    }
}
