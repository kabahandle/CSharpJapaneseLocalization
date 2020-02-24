using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Ｃシャープ日本語化リフレクション
{
    public static class ReflectionHelper
    {
        public static IEnumerable<MethodInfo> GetMethodsInfoByBindingFlags(Type type, BindingFlags flag)
        {
            // guard
            if (type == null)
            {
                yield break;
            }

            // get reflection
            // http://qiita.com/Kokudori/items/7c4b2ca35592e21af1d5
            //var names = type.GetProperties(BindingFlags.Static | BindingFlags.Public)
            //                .Where(x => x.PropertyType == typeof(string))
            //                .Select(x => x.GetValue(type, null) as string).ToList();
            var names = type.GetMethods(flag).ToList();
            foreach (var item in names)
            {
                //this.richReflectionInfo.AppendText(item.ToString() + ControlChars.CrLf);
                yield return item;
            }
        }

        public static string GetPublicProtected( MethodInfo method )
        {
            if( method == null )
            {
                return string.Empty;
            }
            if (method.IsPrivate)
            {
                return "private ";
            }
            if (method.IsFamily)
            {
                return "protected ";
            }
            if (method.IsPublic)
            {
                return "public ";
            }
            return string.Empty;
        }

        public static string GetVirtualIfOverrided(MethodInfo method)
        {
            if (method == null) return string.Empty;

            if (method.IsVirtual)
            {
                return "virtual ";
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
