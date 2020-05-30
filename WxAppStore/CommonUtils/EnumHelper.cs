namespace CommonUtils
{
    using System;
    using System.Collections;

    /// <summary>
    /// 枚举操作公共类
    /// </summary>
    public class EnumHelper
    {
        /// <summary>
        /// 通过字符串获取枚举成员实例
        /// </summary>
        /// <typeparam name="T">枚举名,比如Enum1</typeparam>
        /// <param name="member">The member<see cref="string"/></param>
        /// <returns>The  T </returns>
        public static T GetInstance<T>(string member)
        {
            return (T)Enum.Parse(typeof(T), member, true);
        }

        /// <summary>
        /// 通过字符串获取枚举成员实例
        /// </summary>
        /// <typeparam name="T">枚举名,比如Enum1</typeparam>
        /// <param name="member">The member<see cref="object"/></param>
        /// <returns>The  T </returns>
        public static T GetInstance<T>(object member)
        {
            return GetInstance<T>(member.ToString());
        }

        /// <summary>
        /// 获取枚举成员名称和成员值的键值对集合
        /// </summary>
        /// <typeparam name="T">枚举名,比如Enum1</typeparam>
        /// <returns>The <see cref="Hashtable"/></returns>
        public static Hashtable GetMemberKeyValue<T>()
        {
            //创建哈希表
            var ht = new Hashtable();

            //获取枚举所有成员名称
            string[] memberNames = GetMemberNames<T>();

            //遍历枚举成员
            foreach (string memberName in memberNames)
            {
                ht.Add(memberName, GetMemberValue<T>(memberName));
            }

            //返回哈希表
            return ht;
        }

        /// <summary>
        /// 获取枚举所有成员名称
        /// </summary>
        /// <typeparam name="T">枚举名,比如Enum1</typeparam>
        /// <returns>The string[] </returns>
        public static string[] GetMemberNames<T>()
        {
            return Enum.GetNames(typeof(T));
        }

        /// <summary>
        /// 获取枚举成员的名称
        /// </summary>
        /// <typeparam name="T">枚举名,比如Enum1</typeparam>
        /// <param name="member">The member<see cref="object"/></param>
        /// <returns>The <see cref="string"/></returns>
        public static string GetMemberName<T>(object member)
        {
            //转成基础类型的成员值
            Type underlyingType = GetUnderlyingType(typeof(T));
            object memberValue = ConvertHelper.ConvertTo(member, underlyingType);
            //获取枚举成员的名称
            return Enum.GetName(typeof(T), memberValue);
        }

        /// <summary>
        /// 获取枚举所有成员值
        /// </summary>
        /// <typeparam name="T">枚举名,比如Enum1</typeparam>
        /// <returns>The <see cref="Array"/></returns>
        public static Array GetMemberValues<T>()
        {
            return Enum.GetValues(typeof(T));
        }

        /// <summary>
        /// 获取枚举成员的值
        /// </summary>
        /// <typeparam name="T">枚举名,比如Enum1</typeparam>
        /// <param name="memberName">The memberName<see cref="string"/></param>
        /// <returns>The <see cref="object"/></returns>
        public static object GetMemberValue<T>(string memberName)
        {
            //获取基础类型
            Type underlyingType = GetUnderlyingType(typeof(T));

            //获取枚举实例
            var instance = GetInstance<T>(memberName);

            //获取枚举成员的值
            return ConvertHelper.ConvertTo(instance, underlyingType);
        }

        /// <summary>
        /// 获取枚举的基础类型
        /// </summary>
        /// <param name="enumType">枚举类型</param>
        /// <returns>The <see cref="Type"/></returns>
        public static Type GetUnderlyingType(Type enumType)
        {
            //获取基础类型
            return Enum.GetUnderlyingType(enumType);
        }

        /// <summary>
        /// 检测枚举是否包含指定成员
        /// </summary>
        /// <typeparam name="T">枚举名,比如Enum1</typeparam>
        /// <param name="member">枚举成员名或成员值</param>
        /// <returns>The <see cref="bool"/></returns>
        public static bool IsDefined<T>(string member)
        {
            return Enum.IsDefined(typeof(T), member);
        }
    }
}
