namespace CommonUtils
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Web;

    /// <summary>
    /// Web���ð�����
    /// </summary>
    public class WebUtils
    {
        /// <summary>
        /// ���� HTML �ַ����Ľ�����
        /// </summary>
        /// <param name="o">����</param>
        /// <returns>������</returns>
        public static string HtmlDecode(object o)
        {
            if (o == null)
            {
                return null;
            }
            return HtmlDecode(o.ToString());
        }
 

        /// <summary>
        /// ����  �ַ�����HTML������
        /// </summary>
        /// <param name="str">�ַ���</param>
        /// <returns>������</returns>
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
         
        /// дcookieֵ
        /// </summary>
        /// <param name="strName">����</param>
        /// <param name="strValue">ֵ</param>
        public static void WriteCookie(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName] ?? new HttpCookie(strName);
            cookie.Value = DesEncryptHelper.Encrypt(strValue);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// дcookieֵ
        /// </summary>
        /// <param name="strName">����</param>
        /// <param name="strValue">ֵ</param>
        /// <param name="expires">����ʱ��</param>
        public static void WriteCookie(string strName, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName] ?? new HttpCookie(strName);
            cookie.Value = DesEncryptHelper.Encrypt(strValue);
            cookie.Expires = DateTime.Now.AddMinutes(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        /// <summary>
        /// ��cookieֵ
        /// </summary>
        /// <param name="strName">����</param>
        /// <returns>cookieֵ</returns>
        public static string GetCookie(string strName)
        {
            if (HttpContext.Current.Request.Cookies != null && HttpContext.Current.Request.Cookies[strName] != null)
            {
                return DesEncryptHelper.Decrypt(HttpContext.Current.Request.Cookies[strName].Value);
            }

            return "";
        }

        /// <summary>
        /// ���cookie
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
        /// ��Sessionֵ
        /// </summary>
        /// <param name="strName">����</param>
        /// <returns>Sessionֵ</returns>
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
        /// д��Sessionֵ
        /// </summary>
        /// <param name="strName">����</param>
        /// <param name="value">The value<see cref="string"/></param>
        public static void WriteSession(string strName, string value)
        {
            HttpContext.Current.Session[strName] = value;
        }

        /// <summary>
        /// д��Sessionֵ
        /// </summary>
        /// <param name="strName">����</param>
        /// <param name="value">The value<see cref="object"/></param>
        public static void WriteSession(string strName, object value)
        {
            HttpContext.Current.Session[strName] = value;
            HttpContext.Current.Session.Timeout = 2;
        }

        /// <summary>
        /// ���ر�׼���ڸ�ʽstring
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public static string GetDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// ����ָ�����ڸ�ʽ
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
        /// ���ر�׼ʱ���ʽstring
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public static string GetTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }

        /// <summary>
        /// ���ر�׼ʱ���ʽstring
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public static string GetDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// ��������ڵ�ǰʱ����������
        /// </summary>
        /// <param name="relativeday">The relativeday<see cref="int"/></param>
        /// <returns>The <see cref="string"/></returns>
        public static string GetDateTime(int relativeday)
        {
            return DateTime.Now.AddDays(relativeday).ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// ���ر�׼ʱ���ʽstring
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public static string GetDateTimeF()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffffff");
        }

        /// <summary>
        /// ���ر�׼ʱ��
        /// </summary>
        /// <param name="fDateTime">ʱ��</param>
        /// <param name="formatStr">��׼</param>
        /// <returns>��׼ʱ��</returns>
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
        /// ���ر�׼ʱ�� yyyy-MM-dd HH:mm:ss
        /// </summary>
        /// <param name="fDateTime"> ʱ��</param>
        /// <returns>��׼ʱ��</returns>
        public static string GetStandardDateTime(string fDateTime)
        {
            return GetStandardDateTime(fDateTime, "yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// ��֤�Ƿ���ʱ���ʽ
        /// </summary>
        /// <param name="timeval">ʱ��</param>
        /// <returns>��֤���</returns>
        public static bool IsTime(string timeval)
        {
            return Regex.IsMatch(timeval, @"^((([0-1]?[0-9])|(2[0-3])):([0-5]?[0-9])(:[0-5]?[0-9])?)$");
        }

        /// <summary>
        /// ����������,A-Z,_��3λ�����ַ�
        /// </summary>
        /// <param name="str">The str </param>
        /// <returns>��֤���</returns>
        public static bool IsLetterOrNum(string str)
        {
            return Regex.IsMatch(str, @"^(\w{3,18})$");
        }
    }
}
