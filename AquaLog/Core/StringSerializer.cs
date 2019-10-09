﻿/*
 *  This file is part of the "AquaLog".
 *  Copyright (C) 2019 by Sergey V. Zhdanovskih.
 *  This program is licensed under the GNU General Public License.
 */

using System;
using System.Globalization;
using System.Text;

namespace AquaLog.Core
{
    /// <summary>
    /// Extremely simple linear serializer of objects into strings.
    /// </summary>
    public static class StringSerializer
    {
        private static bool IsDecimal(object obj)
        {
            return (obj != null) && IsDecimal(obj.GetType());
        }

        private static bool IsDecimal(Type type)
        {
            if (type == null)
                return false;

            switch (Type.GetTypeCode(type)) {
                case TypeCode.Single:
                case TypeCode.Double:
                case TypeCode.Decimal:
                    return true;
            }

            return false;
        }

        private static readonly NumberFormatInfo STD_NFI = new NumberFormatInfo {
            NumberDecimalSeparator = ".",
            NumberGroupSeparator = ""
        };

        public static string Serialize(object obj)
        {
            var str = new StringBuilder();
            //str.Append("{");

            var objType = obj.GetType();

            var typeProps = objType.GetProperties();
            foreach (var prop in typeProps) {
                var propValue = prop.GetValue(obj, null);

                if (str.Length > 1)
                    str.Append(";");

                IFormatProvider fmt = IsDecimal(propValue) ? STD_NFI : null;
                string strVal = Convert.ToString(propValue, fmt);
                str.Append(prop.Name + "=" + strVal);
            }

            //str.Append("}");
            return str.ToString();
        }

        public static T Deserialize<T>(string str) where T : class, new()
        {
            var objType = typeof(T);
            return Deserialize<T>(objType, str);
        }

        public static T Deserialize<T>(Type objType, string str) where T : class, new()
        {
            T result = new T();

            if (!string.IsNullOrEmpty(str)) {
                string[] props = str.Split(new char[] { ';', '=' }, Int32.MaxValue, StringSplitOptions.None);

                int i = 0;
                while (i < props.Length) {
                    string propName = props[i];
                    string propValue = (++i < props.Length) ? props[i] : string.Empty;

                    var propInfo = objType.GetProperty(propName);
                    IFormatProvider fmt = IsDecimal(propInfo.PropertyType) ? STD_NFI : null;
                    propInfo.SetValue(result, Convert.ChangeType(propValue, propInfo.PropertyType, fmt), null);

                    i += 1;
                }
            }

            return result;
        }
    }
}
