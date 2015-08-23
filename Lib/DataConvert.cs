using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace System.Collections
{
    static class DataConvert
    {
        public static string GetString(object Val, string Def)
        {
            if ((Val == null) || (Val is DBNull))
                return Def;
            return Val.ToString();
        }

        public static DateTime GetDateTime(object Val, DateTime Def)
        {
            if (Val is DateTime)
                return (DateTime)Val;

            if ((Val == null) || (Val is DBNull))
                return Def;

            DateTime Res = Def;
            DateTime.TryParse(Val.ToString(), out Res);
            return Res;
        }

        public static bool GetBoolean(object Val, bool Def)
        {
            if ((Val == null) || (Val is DBNull))
                return Def;
            if (Val is bool)
                return (bool)Val;
            if ((Val is int) || (Val is uint) || (Val is ulong) || (Val is long))
                return ((int)Val > 0);
            if ((Val is float) || (Val is double) || (Val is decimal))
                return (Convert.ToSingle(Val) > 0);

            string ResStr = Val.ToString().Trim().ToUpper();

            if (((ResStr.IndexOf("TRUE") >= 0) ||
                (ResStr.IndexOf("YES") >= 0) ||
                (ResStr.IndexOf("ON") >= 0) ||
                (ResStr == "T") ||
                (ResStr == "Y") ||
                (ResStr == "1")))
            {
                return true;
            }
            else if (((ResStr.IndexOf("FALSE") >= 0) ||
                (ResStr.IndexOf("NO") >= 0) ||
                (ResStr.IndexOf("OFF") >= 0) ||
                (ResStr == "F") ||
                (ResStr == "N") ||
                (ResStr == "0")))
            {
                return false;
            }

            return Def;
        }

        public static int GetInteger(object Val, int Def)
        {
            if (Val == null)
                return Def;
            if ((Val is bool))
                return ((bool)Val ? 1 : 0);
            if ((Val is int) || (Val is uint) || (Val is ulong) || (Val is long))
                unchecked
                {
                    return (int)Val;
                }
            if ((Val is float) || (Val is double) || (Val is decimal))
                return Convert.ToInt32(Val);
            int Res;
            if (int.TryParse(Val.ToString(), out Res))
                return Res;
            return Def;
        }

        public static long GetLong(object Val, long Def)
        {
            if (Val == null)
                return Def;
            if ((Val is bool))
                return ((bool)Val ? 1 : 0);
            if ((Val is int) || (Val is uint) || (Val is ulong) || (Val is long))
                unchecked
                {
                    return (long)Val;
                }
            if ((Val is float) || (Val is double) || (Val is decimal))
                return Convert.ToInt64(Val);

            long Res;
            if (long.TryParse(Val.ToString(), out Res))
                return Res;
            return Def;
        }
    }
}
