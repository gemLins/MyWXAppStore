namespace CommonUtils
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// ������������ת��������ת��������ת����ص���
    /// </summary>
    public class ConvertHelper
    {
        /// <summary>
        /// Convert a List{T} to a DataTable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items<see cref="List{T}"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public static DataTable ToDataTable<T>(List<T> items)
        {
            var tb = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo prop in props)
            {
                Type t = GetCoreType(prop.PropertyType);
                tb.Columns.Add(prop.Name, t);
            }

            foreach (T item in items)
            {
                var values = new object[props.Length];

                for (int i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                tb.Rows.Add(values);
            }

            return tb;
        }

        /// <summary>
        /// Determine of specified type is nullable
        /// </summary>
        /// <param name="t">The t<see cref="Type"/></param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool IsNullable(Type t)
        {
            return !t.IsValueType || (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Nullable<>));
        }

        /// <summary>
        /// Return underlying type if type is Nullable otherwise return the type
        /// </summary>
        /// <param name="t">The t<see cref="Type"/></param>
        /// <returns>The <see cref="Type"/></returns>
        public static Type GetCoreType(Type t)
        {
            if (t != null && IsNullable(t))
            {
                if (!t.IsValueType)
                {
                    return t;
                }
                else
                {
                    return Nullable.GetUnderlyingType(t);
                }
            }
            else
            {
                return t;
            }
        }

        /// <summary>
        /// ָ���ַ����Ĺ̶����ȣ�����ַ���С�ڹ̶����ȣ�
        /// �����ַ�����ǰ�油���㣬�����õĹ̶��������Ϊ9λ
        /// </summary>
        /// <param name="text">ԭʼ�ַ���</param>
        /// <param name="limitedLength">�ַ����Ĺ̶�����</param>
        /// <returns>The <see cref="string"/></returns>
        public static string RepairZero(string text, int limitedLength)
        {
            //����0���ַ���
            string temp = "";

            //����0
            for (int i = 0; i < limitedLength - text.Length; i++)
            {
                temp += "0";
            }

            //����text
            temp += text;

            //���ز���0���ַ���
            return temp;
        }

        /// <summary>
        /// ʵ�ָ����������ת����ConvertBase("15",10,16)��ʾ��ʮ������15ת��Ϊ16���Ƶ�����
        /// </summary>
        /// <param name="value">Ҫת����ֵ,��ԭֵ</param>
        /// <param name="from">ԭֵ�Ľ���,ֻ����2,8,10,16�ĸ�ֵ��</param>
        /// <param name="to">Ҫת������Ŀ����ƣ�ֻ����2,8,10,16�ĸ�ֵ��</param>
        /// <returns>The <see cref="string"/></returns>
        public static string ConvertBase(string value, int from, int to)
        {
            try
            {
                int intValue = Convert.ToInt32(value, from); //��ת��10����
                string result = Convert.ToString(intValue, to); //��ת��Ŀ�����
                if (to == 2)
                {
                    int resultLength = result.Length; //��ȡ�����Ƶĳ���
                    switch (resultLength)
                    {
                        case 7:
                            result = "0" + result;
                            break;
                        case 6:
                            result = "00" + result;
                            break;
                        case 5:
                            result = "000" + result;
                            break;
                        case 4:
                            result = "0000" + result;
                            break;
                        case 3:
                            result = "00000" + result;
                            break;
                    }
                }
                return result;
            }
            catch
            {
                return "0";
            }
        }

        /// <summary>
        /// ��stringת����byte[]
        /// </summary>
        /// <param name="text">Ҫת�����ַ���</param>
        /// <returns>The  byte[] </returns>
        public static byte[] StringToBytes(string text)
        {
            return Encoding.UTF8.GetBytes(text);
        }

        /// <summary>
        /// ʹ��ָ���ַ�����stringת����byte[]
        /// </summary>
        /// <param name="text">Ҫת�����ַ���</param>
        /// <param name="encoding">�ַ�����</param>
        /// <returns>The  byte[] </returns>
        public static byte[] StringToBytes(string text, Encoding encoding)
        {
            return encoding.GetBytes(text);
        }

        /// <summary>
        /// ��byte[]ת����string
        /// </summary>
        /// <param name="bytes">Ҫת�����ֽ�����</param>
        /// <returns>The <see cref="string"/></returns>
        public static string BytesToString(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        /// ʹ��ָ���ַ�����byte[]ת����string
        /// </summary>
        /// <param name="bytes">Ҫת�����ֽ�����</param>
        /// <param name="encoding">�ַ�����</param>
        /// <returns>The <see cref="string"/></returns>
        public static string BytesToString(byte[] bytes, Encoding encoding)
        {
            return encoding.GetString(bytes);
        }

        /// <summary>
        /// ����ת�����ַ���,ͬʱ�رո���
        /// </summary>
        /// <param name="stream">��</param>
        /// <param name="encoding">�ַ�����</param>
        /// <returns>The <see cref="string"/></returns>
        public static string StreamToString(Stream stream, Encoding encoding)
        {
            //��ȡ���ı�
            string streamText;

            //��ȡ��
            try
            {
                using (var reader = new StreamReader(stream, encoding))
                {
                    streamText = reader.ReadToEnd();
                }
            }
            catch
            {
                return string.Empty;
            }
            finally
            {
                stream.Close();
            }

            //�����ı�
            return streamText;
        }

        /// <summary>
        /// ����ת�����ַ���,ͬʱ�رո���
        /// </summary>
        /// <param name="stream">��</param>
        /// <returns>The <see cref="string"/></returns>
        public static string StreamToString(Stream stream)
        {
            return StreamToString(stream, Encoding.Default);
        }

        /// <summary>
        /// ��byte[]ת����int
        /// </summary>
        /// <param name="data">��Ҫת����������byte����</param>
        /// <returns>The <see cref="int"/></returns>
        public static int BytesToInt32(byte[] data)
        {
            //���������ֽ����鳤��С��4,�򷵻�0
            if (data.Length < 4)
            {
                return 0;
            }

            //����Ҫ���ص�����
            int num = 0;

            //���������ֽ����鳤�ȴ���4,��Ҫ���д���
            if (data.Length >= 4)
            {
                //����һ����ʱ������
                var tempBuffer = new byte[4];

                //��������ֽ������ǰ4���ֽڸ��Ƶ���ʱ������
                Buffer.BlockCopy(data, 0, tempBuffer, 0, 4);

                //����ʱ��������ֵת����������������num
                num = BitConverter.ToInt32(tempBuffer, 0);
            }

            //��������
            return num;
        }

        /// <summary>
        /// ������ת��Ϊ����,���������Ч�򷵻�"1900-1-1"
        /// </summary>
        /// <param name="date">����</param>
        /// <returns>The <see cref="DateTime"/></returns>
        public static DateTime ToDateTime(object date)
        {
            try
            {
                if (ValidationHelper.IsNullOrEmpty(date))
                {
                    return Convert.ToDateTime("1900-1-1");
                }
                else
                {
                    return Convert.ToDateTime(date);
                }
            }
            catch
            {
                return Convert.ToDateTime("1900-1-1");
            }
        }

        /// <summary>
        /// ������ת��ΪGUID
        /// </summary>
        /// <param name="data">data</param>
        /// <returns>Guid <see cref="Guid"/></returns>
        public static Guid ToGuid(object data)
        {
            //��Ч����֤
            if (ValidationHelper.IsNullOrEmpty(data))
            {
                return Guid.Empty;
            }

            try
            {
                return new Guid(data.ToString());
            }
            catch
            {
                return Guid.Empty;
            }
        }

        /// <summary>
        /// ������ת��Ϊ����
        /// </summary>
        /// <typeparam name="T">���ݵ�����</typeparam>
        /// <param name="data">Ҫת��������</param>
        /// <returns>The <see cref="int"/></returns>
        public static int ToInt32<T>(T data)
        {
            try
            {
                //���Ϊ���򷵻�0
                if (ValidationHelper.IsNullOrEmpty(data))
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(data);
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// ������ת��Ϊ����
        /// </summary>
        /// <param name="data">Ҫת��������</param>
        /// <returns>The <see cref="int"/></returns>
        public static int ToInt32(object data)
        {
            try
            {
                //���Ϊ���򷵻�0
                if (ValidationHelper.IsNullOrEmpty(data))
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(data);
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// ������ת��Ϊ�ַ���
        /// </summary>
        /// <param name="data">����</param>
        /// <returns>The <see cref="string"/></returns>
        public static string ToString(object data)
        {
            //��Ч����֤
            if (data == null)
            {
                return string.Empty;
            }

            return data.ToString();
        }

        /// <summary>
        /// ������ת��Ϊ������
        /// </summary>
        /// <typeparam name="T">���ݵ�����</typeparam>
        /// <param name="data">Ҫת��������</param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool ToBoolean<T>(T data)
        {
            try
            {
                //���Ϊ���򷵻�false
                if (ValidationHelper.IsNullOrEmpty(data))
                {
                    return false;
                }
                else
                {
                    return Convert.ToBoolean(data);
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// ������ת��Ϊ������
        /// </summary>
        /// <param name="data">Ҫת��������</param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool ToBoolean(object data)
        {
            try
            {
                //���Ϊ���򷵻�false
                if (ValidationHelper.IsNullOrEmpty(data))
                {
                    return false;
                }
                else
                {
                    return Convert.ToBoolean(data);
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// ������ת��Ϊ�����ȸ�����
        /// </summary>
        /// <typeparam name="T">���ݵ�����</typeparam>
        /// <param name="data">Ҫת��������</param>
        /// <returns>The <see cref="float"/></returns>
        public static float ToFloat<T>(T data)
        {
            try
            {
                //���Ϊ���򷵻�0
                if (ValidationHelper.IsNullOrEmpty(data))
                {
                    return 0;
                }
                else
                {
                    return Convert.ToSingle(data);
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// ������ת��Ϊ�����ȸ�����
        /// </summary>
        /// <param name="data">Ҫת��������</param>
        /// <returns>The <see cref="float"/></returns>
        public static float ToFloat(object data)
        {
            try
            {
                //���Ϊ���򷵻�0
                if (ValidationHelper.IsNullOrEmpty<object>(data))
                {
                    return 0;
                }
                else
                {
                    return Convert.ToSingle(data);
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// ������ת��Ϊ˫���ȸ�����
        /// </summary>
        /// <typeparam name="T">���ݵ�����</typeparam>
        /// <param name="data">Ҫת��������</param>
        /// <returns>The <see cref="double"/></returns>
        public static double ToDouble<T>(T data)
        {
            try
            {
                //���Ϊ���򷵻�0
                if (ValidationHelper.IsNullOrEmpty(data))
                {
                    return 0;
                }
                else
                {
                    return Convert.ToDouble(data);
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// ������ת��Ϊ˫���ȸ�����,������С��λ
        /// </summary>
        /// <typeparam name="T">���ݵ�����</typeparam>
        /// <param name="data">Ҫת��������</param>
        /// <param name="decimals">С����λ��</param>
        /// <returns>The <see cref="double"/></returns>
        public static double ToDouble<T>(T data, int decimals)
        {
            try
            {
                //���Ϊ���򷵻�0
                if (ValidationHelper.IsNullOrEmpty(data))
                {
                    return 0;
                }
                else
                {
                    double temp = Convert.ToDouble(data);
                    return Math.Round(temp, decimals);
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// ������ת��Ϊ˫���ȸ�����
        /// </summary>
        /// <param name="data">Ҫת��������</param>
        /// <returns>The <see cref="double"/></returns>
        public static double ToDouble(object data)
        {
            try
            {
                //���Ϊ���򷵻�0
                if (ValidationHelper.IsNullOrEmpty(data))
                {
                    return 0;
                }
                else
                {
                    return Convert.ToDouble(data);
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// ������ת��Ϊ˫���ȸ�����,������С��λ
        /// </summary>
        /// <param name="data">Ҫת��������</param>
        /// <param name="decimals">С����λ��</param>
        /// <returns>The <see cref="double"/></returns>
        public static double ToDouble(object data, int decimals)
        {
            try
            {
                //���Ϊ���򷵻�0
                if (ValidationHelper.IsNullOrEmpty<object>(data))
                {
                    return 0;
                }
                else
                {
                    double temp = Convert.ToDouble(data);
                    return Math.Round(temp, decimals);
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// ������ת��ΪDecimal����
        /// </summary>
        /// <typeparam name="T">���ݵ�����</typeparam>
        /// <param name="data">Ҫת��������</param>
        /// <returns>The <see cref="decimal"/></returns>
        public static decimal ToDecimal<T>(T data)
        {
            try
            {
                //���Ϊ���򷵻�0
                if (ValidationHelper.IsNullOrEmpty(data))
                {
                    return 0;
                }
                else
                {
                    return Convert.ToDecimal(data);
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// ������ת��ΪDecimal����
        /// </summary>
        /// <typeparam name="T">���ݵ�����</typeparam>
        /// <param name="data">Ҫת��������</param>
        /// <param name="decimals">С����λ��</param>
        /// <returns>The <see cref="decimal"/></returns>
        public static decimal ToDecimal<T>(T data, int decimals)
        {
            try
            {
                //���Ϊ���򷵻�0
                if (ValidationHelper.IsNullOrEmpty(data))
                {
                    return 0;
                }
                else
                {
                    decimal temp = Convert.ToDecimal(data);
                    return Math.Round(temp, decimals);
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// ������ת��ΪDecimal����
        /// </summary>
        /// <param name="data">Ҫת��������</param>
        /// <returns>The <see cref="decimal"/></returns>
        public static decimal ToDecimal(object data)
        {
            try
            {
                //���Ϊ���򷵻�0
                if (ValidationHelper.IsNullOrEmpty(data))
                {
                    return 0;
                }
                else
                {
                    return Convert.ToDecimal(data);
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// ������ת��ΪDecimal����
        /// </summary>
        /// <param name="data">Ҫת��������</param>
        /// <param name="decimals">С����λ��</param>
        /// <returns>The <see cref="decimal"/></returns>
        public static decimal ToDecimal(object data, int decimals)
        {
            try
            {
                //���Ϊ���򷵻�0
                if (ValidationHelper.IsNullOrEmpty<object>(data))
                {
                    return 0;
                }
                else
                {
                    decimal temp = Convert.ToDecimal(data);
                    return Math.Round(temp, decimals);
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// ������ת��Ϊָ������
        /// </summary>
        /// <param name="data">ת��������</param>
        /// <param name="targetType">ת����Ŀ������</param>
        /// <returns>The <see cref="object"/></returns>
        public static object ConvertTo(object data, Type targetType)
        {
            //�������Ϊ�գ��򷵻�
            if (ValidationHelper.IsNullOrEmpty(data))
            {
                return null;
            }

            try
            {
                //�������ʵ����IConvertible�ӿڣ���ת������
                if (data is IConvertible)
                {
                    return Convert.ChangeType(data, targetType);
                }
                else
                {
                    return data;
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// ������ת��Ϊָ������
        /// </summary>
        /// <typeparam name="T">ת����Ŀ������</typeparam>
        /// <param name="data">ת��������</param>
        /// <returns>The T </returns>
        public static T ConvertTo<T>(object data)
        {
            //�������Ϊ�գ��򷵻�
            if (ValidationHelper.IsNullOrEmpty(data))
            {
                return default(T);
            }

            try
            {
                //���������T���ͣ���ֱ��ת��
                if (data is T)
                {
                    return (T)data;
                }

                //���Ŀ��������ö��
                if (typeof(T).BaseType == typeof(Enum))
                {
                    return EnumHelper.GetInstance<T>(data);
                }

                //�������ʵ����IConvertible�ӿڣ���ת������
                if (data is IConvertible)
                {
                    return (T)Convert.ChangeType(data, typeof(T));
                }
                else
                {
                    return default(T);
                }
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// string��ת��Ϊbool��
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <returns>ת�����bool���ͽ��</returns>
        public static bool StrToBool(string strValue)
        {
            if (!string.IsNullOrEmpty(strValue))
            {
                strValue = strValue.Trim();
                return (((string.Compare(strValue, "true", true) == 0) || (string.Compare(strValue, "yes", true) == 0)) ||
                        (string.Compare(strValue, "1", true) == 0));
            }
            return false;
        }

        /// <summary>
        /// string��ת��Ϊʱ����
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����ʱ�����ͽ��</returns>
        public static DateTime StrToDateTime(object strValue, DateTime defValue)
        {
            if ((strValue == null) || (strValue.ToString().Length > 20))
            {
                return defValue;
            }

            DateTime intValue;

            if (!DateTime.TryParse(strValue.ToString(), out intValue))
            {
                intValue = defValue;
            }
            return intValue;
        }

        /// <summary>
        /// �������long��ת��ΪDateTime��
        /// </summary>
        /// <param name="inputLong">long��ֵ</param>
        /// <returns>ʱ��</returns>
        public static DateTime BigIntToDateTime(long inputLong)
        {
            DateTime beginTime = DateTime.Now.Date;
            DateTime.TryParse("1970-01-01", out beginTime);
            double addDays = inputLong / (double)(24 * 3600);

            return beginTime.AddDays(addDays);
        }

        /// <summary>
        /// object��ת��Ϊdecimal��
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <returns>ת�����decimal���ͽ��</returns>
        public static decimal StrToDecimal(object strValue)
        {
            if (!Convert.IsDBNull(strValue) && !Equals(strValue, null))
            {
                return StrToDecimal(strValue.ToString());
            }
            return 0M;
        }

        /// <summary>
        /// string��ת��Ϊdecimal��
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <returns>ת�����decimal���ͽ��</returns>
        public static decimal StrToDecimal(string strValue)
        {
            decimal num;
            decimal.TryParse(strValue, out num);
            return num;
        }

        /// <summary>
        /// string��ת��Ϊdecimal��
        /// </summary>
        /// <param name="input">Ҫת�����ַ���</param>
        /// <param name="defaultValue">ȱʡֵ</param>
        /// <returns>ת�����decimal���ͽ��</returns>
        public static decimal StrToDecimal(string input, decimal defaultValue)
        {
            decimal num;
            if (decimal.TryParse(input, out num))
            {
                return num;
            }
            return defaultValue;
        }

        /// <summary>
        /// string��ת��Ϊdouble��
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <returns>ת�����double���ͽ��</returns>
        public static double StrToDouble(object strValue)
        {
            if (!Convert.IsDBNull(strValue) && !Equals(strValue, null))
            {
                return StrToDouble(strValue.ToString());
            }
            return 0.0;
        }

        /// <summary>
        /// string��ת��Ϊdouble��
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <returns>ת�����double���ͽ��</returns>
        public static double StrToDouble(string strValue)
        {
            double num;
            double.TryParse(strValue, out num);
            return num;
        }

        /// <summary>
        /// string��ת��Ϊfloat��
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����float���ͽ��</returns>
        public static float StrToFloat(object strValue, float defValue)
        {
            if ((strValue == null) || (strValue.ToString().Length > 10))
            {
                return defValue;
            }

            float intValue = defValue;
            if (strValue != null)
            {
                bool IsFloat = new Regex(@"^([-]|[0-9])[0-9]*(\.\w*)?$").IsMatch(strValue.ToString());
                if (IsFloat)
                {
                    intValue = Convert.ToSingle(strValue);
                }
            }
            return intValue;
        }

        /// <summary>
        /// string��ת��Ϊint��
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <returns>ת�����int���ͽ��.���Ҫת�����ַ����Ƿ�����,�򷵻�-1.</returns>
        public static int StrToInt(object strValue)
        {
            int defValue = -1;
            if ((strValue == null) || (strValue.ToString() == string.Empty) || (strValue.ToString().Length > 10))
            {
                return defValue;
            }

            string val = strValue.ToString();
            string firstletter = val[0].ToString();

            if (val.Length == 10 && ValidationHelper.IsNumber(firstletter) && int.Parse(firstletter) > 1)
            {
                return defValue;
            }
            else if (val.Length == 10 && !ValidationHelper.IsNumber(firstletter))
            {
                return defValue;
            }


            int intValue = defValue;
            if (strValue != null)
            {
                bool IsInt = new Regex(@"^([-]|[0-9])[0-9]*$").IsMatch(strValue.ToString());
                if (IsInt)
                {
                    intValue = Convert.ToInt32(strValue);
                }
            }

            return intValue;
        }

        /// <summary>
        /// string��ת��Ϊint��
        /// </summary>
        /// <param name="strValue">Ҫת�����ַ���</param>
        /// <param name="defValue">ȱʡֵ</param>
        /// <returns>ת�����int���ͽ��</returns>
        public static int StrToInt(object strValue, int defValue)
        {
            if ((strValue == null) || (strValue.ToString() == string.Empty) || (strValue.ToString().Length > 10))
            {
                return defValue;
            }

            string val = strValue.ToString();
            string firstletter = val[0].ToString();

            if (val.Length == 10 && ValidationHelper.IsNumber(firstletter) && int.Parse(firstletter) > 1)
            {
                return defValue;
            }
            else if (val.Length == 10 && !ValidationHelper.IsNumber(firstletter))
            {
                return defValue;
            }


            int intValue = defValue;
            if (strValue != null)
            {
                bool IsInt = new Regex(@"^([-]|[0-9])[0-9]*$").IsMatch(strValue.ToString());
                if (IsInt)
                {
                    intValue = Convert.ToInt32(strValue);
                }
            }

            return intValue;
        }

        /// <summary>
        /// ��long����ֵת��ΪInt32����
        /// </summary>
        /// <param name="objNum">long����ֵ</param>
        /// <returns>int</returns>
        public static int SafeInt32(object objNum)
        {
            if (objNum == null)
            {
                return 0;
            }
            string strNum = objNum.ToString();
            if (ValidationHelper.IsNumber(strNum))
            {
                if (strNum.Length > 9)
                {
                    return int.MaxValue;
                }
                return Int32.Parse(strNum);
            }
            else
            {
                return 0;
            }
        }
    }
}
