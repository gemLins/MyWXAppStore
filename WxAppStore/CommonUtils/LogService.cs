using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CommonUtils
{
    /// <summary>
    /// LogService
    /// </summary>
    internal class LogService
    {
        /// <summary>
        /// 如果没有则创建Log文件夹
        /// </summary>
        public static void MakeDir()
        {
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\Log\\"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\Log\\");
            }
            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\XML\\"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "\\XML\\");
            }
        }
        /// <summary>
        /// 日志存储路径
        /// </summary>
        public static string dir = System.AppDomain.CurrentDomain.BaseDirectory + "\\Log\\";

        /// <summary>
        /// 写错误日志
        /// </summary>
        /// <param name="er">错误日志</param>
        public static void WriteErrorLog(string er)
        {
            MakeDir();
            try
            {
                string time = DateTime.Now.Date.ToString("yyyy-MM-dd");
                using (StreamWriter sw = new StreamWriter(dir + time + ".err.txt", true, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine("运行时错误出现时间：" + DateTime.Now.ToString());
                    sw.WriteLine("错误原因：" + er);
                    sw.WriteLine("\n");
                    sw.Close();
                }
            }
            catch
            {
                //
            }
        }
        /// <summary>
        /// 写运行日志
        /// </summary>
        /// <param name="log">运行日志</param>
        public static void WriteLog(string log)
        {
            MakeDir();
            try
            {
                string time = DateTime.Now.Date.ToString("yyyy-MM-dd");
                using (StreamWriter sw = new StreamWriter(dir + time + ".txt", true, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine(System.DateTime.Now.ToString() + "：" + log);
                    sw.WriteLine("\n");
                    sw.Close();
                }
            }
            catch
            {
                //
            }
        }

        /// <summary>
        /// 写请求数据日志
        /// </summary>
        /// <param name="message">日志内容</param>
        public static void WriteRequestLog(string message)
        {
            MakeDir();
            try
            {
                string time = DateTime.Now.Date.ToString("yyyy-MM-dd");
                using (StreamWriter sw = new StreamWriter(dir + time + ".request.txt", true, System.Text.Encoding.UTF8))
                {
                    sw.WriteLine(System.DateTime.Now.ToString() + "：" + message);
                    sw.WriteLine("\n");
                    sw.Close();
                }
            }
            catch
            {
                //
            }
        }


    }
}
