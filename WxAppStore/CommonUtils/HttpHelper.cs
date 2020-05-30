using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
 

namespace CommonUtils
{
    public class HttpHelper
    {
        
        /// <summary>
        /// get方式提交数据
        /// </summary>
        /// <param name="content">数据</param>
        /// <param name="url">url</param>
        /// <returns>响应内容</returns>
        public static string RequestUrl(string url, string content)//get方式提交数据
        {
            //向指定页面发送请求
            string send = url +"?"+ content;
            string resultStream = "";
            try
            {
                HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(send);
                req.Method = "GET";
                //req.Timeout = 6000;
                req.ContentType = "application/json";
                using (WebResponse wr = req.GetResponse())
                {
                    Stream stream = wr.GetResponseStream();
                    StreamReader sr = new StreamReader(stream, Encoding.GetEncoding("utf-8"));
                    resultStream = @sr.ReadToEnd();

                }
            }
            catch (Exception ex)
            {
                LogService.WriteErrorLog(ex.Message);
            }
            return resultStream;
        }
        /// <summary>
        /// post方式向页面提交
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="content">数据</param>
        /// <returns>响应内容</returns>
        public static string RequestPostUrl(string url, string content)//post方式向页面提交
        {
            string result = "";
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
            req.Method = "POST";
            req.ContentType = "application/json";

            #region 添加Post 参数
            byte[] data = Encoding.UTF8.GetBytes(content);
            req.ContentLength = data.Length;
            try
            {
                using (Stream reqStream = req.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);
                    reqStream.Close();
                }
                #endregion

                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                Stream stream = resp.GetResponseStream();
                //获取响应内容
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }


       
    }
}
