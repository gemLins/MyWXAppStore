namespace CommonUtils
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Web;

    /// <summary>
    /// Web常用帮助类
    /// </summary>
    public class WebUtils
    {
        /// <summary>
        /// 返回 HTML 字符串的解码结果
        /// </summary>
        /// <param name="o">对象</param>
        /// <returns>解码结果</returns>
        public static string HtmlDecode(object o)
        {
            if (o == null)
            {
                return null;
            }
            return HtmlDecode(o.ToString());
        }
 

        /// <summary>
        /// 返回  字符串的HTML编码结果
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns>编码结果</returns>
        public static string HtmlEncode(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                str = str.Replace("<", "&lt;");
                str = str.Replace(">", "&gt;");
                str = str.Replace(" ", "&nbsp;");
                str = str.Replace("'", "&#39;");
                str = str.Replace("\"", "&quot;");
                str = str.Replace("\r\n", "<br>");
                str = str.Replace("\n", "<br>");
            }
            return str;
        }
         
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        public static void WriteCookie(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName] ?? new HttpCookie(strName);
            cookie.Value = DesEncryptHelper.Encrypt(strValue);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 写cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="strValue">值</param>
        /// <param name="expires">过期时间</param>
        public static void WriteCookie(string strName, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName] ?? new HttpCookie(strName);
            cookie.Value = DesEncryptHelper.Encrypt(strValue);
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// 读cookie值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>cookie值</returns>
        public static string GetCookie(string strName)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null)
            {
                return DesEncryptHelper.Decrypt(HttpContext.Current.Request.Cookies[strName].Value);
            }

            return "";
        }

        /// <summary>
        /// 清除cookie
        /// </summary>
        /// <param name="name">name of cookie</param>
        public static void RemoveCookie(string name)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];
            if (cookie != null)
            {
                HttpContext.Current.Request.Cookies.Remove(name);
            }
        }

        /// <summary>
        /// 读Session值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <returns>Session值</returns>
        public static object GetSession(string strName)
        {
            if (HttpContext.Current.Session != null && HttpContext.Current.Session[strName] != null)
            {
                return HttpContext.Current.Session[strName];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 写入Session值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="value">The value<see cref="string"/></param>
        public static void WriteSession(string strName, string value)
        {
            HttpContext.Current.Session[strName] = value;
        }

        /// <summary>
        /// 写入Session值
        /// </summary>
        /// <param name="strName">名称</param>
        /// <param name="value">The value<see cref="object"/></param>
        public static void WriteSession(string strName, object value)
        {
            HttpContext.Current.Session[strName] = value;
            HttpContext.Current.Session.Timeout = 2;
        }

        /// <summary>
        /// 返回标准日期格式string
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public static string GetDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 返回指定日期格式
        /// </summary>
        /// <param name="datetimestr">The datetimestr<see cref="string"/></param>
        /// <param name="replacestr">The replacestr<see cref="string"/></param>
        /// <returns>The <see cref="string"/></returns>
        public static string GetDate(string datetimestr, string replacestr)
        {
            if (datetimestr == null)
            {
                return replacestr;
            }

            if (datetimestr.Equals(""))
            {
                return replacestr;
            }

            try
            {
                datetimestr = Convert.ToDateTime(datetimestr).ToString("yyyy-MM-dd").Replace("1900-01-01", replacestr);
            }
            catch
            {
                return replacestr;
            }
            return datetimestr;
        }

        /// <summary>
        /// 返回标准时间格式string
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public static string GetTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }

        /// <summary>
        /// 返回标准时间格式string
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public static string GetDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 返回相对于当前时间的相对天数
        /// </summary>
        /// <param name="relativeday">The relativeday<see cref="int"/></param>
        /// <returns>The <see cref="string"/></returns>
        public static string GetDateTime(int relativeday)
        {
            return DateTime.Now.AddDays(relativeday).ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 返回标准时间格式string
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public static string GetDateTimeF()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffffff");
        }

        /// <summary>
        /// 返回标准时间
        /// </summary>
        /// <param name="fDateTime">时间</param>
        /// <param name="formatStr">标准</param>
        /// <returns>标准时间</returns>
        public static string GetStandardDateTime(string fDateTime, string formatStr)
        {
            if (fDateTime == "0000-0-0 0:00:00")
            {
                return fDateTime;
            }
            DateTime s = Convert.ToDateTime(fDateTime);
            return s.ToString(formatStr);
        }

        /// <summary>
        /// 返回标准时间 yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="fDateTime"> 时间</param>
        /// <returns>标准时间</returns>
        public static string GetStandardDateTime(string fDateTime)
        {
            return GetStandardDateTime(fDateTime, "yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 验证是否是时间格式
        /// </summary>
        /// <param name="timeval">时间</param>
        /// <returns>验证结果</returns>
        public static bool IsTime(string timeval)
        {
            return Regex.IsMatch(timeval, @"^((([0-1]?[0-9])|(2[0-3])):([0-5]?[0-9])(:[0-5]?[0-9])?)$");
        }

        /// <summary>
        /// 任意以数字,A-Z,_且3位数的字符
        /// </summary>
        /// <param name="str">The str </param>
        /// <returns>验证结果</returns>
        public static bool IsLetterOrNum(string str)
        {
            return Regex.IsMatch(str, @"^(\w{3,18})$");
        }
    }
}
