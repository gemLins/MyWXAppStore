namespace CommonUtils
{
    using System;
    using System.Collections;

    /// <summary>
    /// ö�ٲ���������
    /// </summary>
    public class EnumHelper
    {
        /// <summary>
        /// ͨ���ַ�����ȡö�ٳ�Աʵ��
        /// </summary>
        /// <typeparam name="T">ö����,����Enum1</typeparam>
        /// <param name="member">The member<see cref="string"/></param>
        /// <returns>The  T </returns>
        public static T GetInstance<T>(string member)
        {
            return (T)Enum.Parse(typeof(T), member, true);
        }

        /// <summary>
        /// ͨ���ַ�����ȡö�ٳ�Աʵ��
        /// </summary>
        /// <typeparam name="T">ö����,����Enum1</typeparam>
        /// <param name="member">The member<see cref="object"/></param>
        /// <returns>The  T </returns>
        public static T GetInstance<T>(object member)
        {
            return GetInstance<T>(member.ToString());
        }

        /// <summary>
        /// ��ȡö�ٳ�Ա���ƺͳ�Աֵ�ļ�ֵ�Լ���
        /// </summary>
        /// <typeparam name="T">ö����,����Enum1</typeparam>
        /// <returns>The <see cref="Hashtable"/></returns>
        public static Hashtable GetMemberKeyValue<T>()
        {
            //������ϣ��
            var ht = new Hashtable();

            //��ȡö�����г�Ա����
            string[] memberNames = GetMemberNames<T>();

            //����ö�ٳ�Ա
            foreach (string memberName in memberNames)
            {
                ht.Add(memberName, GetMemberValue<T>(memberName));
            }

            //���ع�ϣ��
            return ht;
        }

        /// <summary>
        /// ��ȡö�����г�Ա����
        /// </summary>
        /// <typeparam name="T">ö����,����Enum1</typeparam>
        /// <returns>The string[] </returns>
        public static string[] GetMemberNames<T>()
        {
            return Enum.GetNames(typeof(T));
        }

        /// <summary>
        /// ��ȡö�ٳ�Ա������
        /// </summary>
        /// <typeparam name="T">ö����,����Enum1</typeparam>
        /// <param name="member">The member<see cref="object"/></param>
        /// <returns>The <see cref="string"/></returns>
        public static string GetMemberName<T>(object member)
        {
            //ת�ɻ������͵ĳ�Աֵ
            Type underlyingType = GetUnderlyingType(typeof(T));
            object memberValue = ConvertHelper.ConvertTo(member, underlyingType);
            //��ȡö�ٳ�Ա������
            return Enum.GetName(typeof(T), memberValue);
        }

        /// <summary>
        /// ��ȡö�����г�Աֵ
        /// </summary>
        /// <typeparam name="T">ö����,����Enum1</typeparam>
        /// <returns>The <see cref="Array"/></returns>
        public static Array GetMemberValues<T>()
        {
            return Enum.GetValues(typeof(T));
        }

        /// <summary>
        /// ��ȡö�ٳ�Ա��ֵ
        /// </summary>
        /// <typeparam name="T">ö����,����Enum1</typeparam>
        /// <param name="memberName">The memberName<see cref="string"/></param>
        /// <returns>The <see cref="object"/></returns>
        public static object GetMemberValue<T>(string memberName)
        {
            //��ȡ��������
            Type underlyingType = GetUnderlyingType(typeof(T));

            //��ȡö��ʵ��
            var instance = GetInstance<T>(memberName);

            //��ȡö�ٳ�Ա��ֵ
            return ConvertHelper.ConvertTo(instance, underlyingType);
        }

        /// <summary>
        /// ��ȡö�ٵĻ�������
        /// </summary>
        /// <param name="enumType">ö������</param>
        /// <returns>The <see cref="Type"/></returns>
        public static Type GetUnderlyingType(Type enumType)
        {
            //��ȡ��������
            return Enum.GetUnderlyingType(enumType);
        }

        /// <summary>
        /// ���ö���Ƿ����ָ����Ա
        /// </summary>
        /// <typeparam name="T">ö����,����Enum1</typeparam>
        /// <param name="member">ö�ٳ�Ա�����Աֵ</param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool IsDefined<T>(string member)
        {
            return Enum.IsDefined(typeof(T), member);
        }
    }
}
