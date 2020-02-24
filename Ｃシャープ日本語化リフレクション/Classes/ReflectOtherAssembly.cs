using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ｃシャープ日本語化リフレクション
{
    public abstract class ReflectOtherAssembly
    {
        protected readonly string SystemNameSpace = "mscorlib"; /*"System";*/
        protected readonly string SystemWindowsFormsNameSpace = "System.Windows.Forms";
        protected readonly string GenericNameSpace = "System.Collections.Generic";
        protected readonly string System = string.Empty;//"System" /*ReflectOtherAssemblyVersionBase.SystemNameSpace*/ + ".";
        protected readonly string SystemWindowsForms = string.Empty;//this.SystemWindowsFormsNameSpace + ".";
        protected readonly string Generic = string.Empty;

        // Geceric用ディクショナリ
        protected readonly Dictionary<string, Type> GenericTypeDict = new Dictionary<string, Type>();

        //private static readonly string dataAssembly = "System.Data" + ReflectOtherAssembly.DotNet4PublicToken;

        // .NET 2.0 PublicToken:
        // http://forums.ni.com/t5/Measurement-Studio-for-NET/File-or-assembly-name-System-Windows-Forms-Version-2-0-0-0/td-p/2150190
        protected static readonly string DotNet2PublicToken = ", Version=2.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089";

        public enum NameSpaceEnum
        {
            None,
            WindowsForms,
            System,
            Generic
        }

        // Generic用クラス
        public class T : Object { }
        public class TKey : Object { }
        public class TValue : Object { }

        // コンストラクタ
        public ReflectOtherAssembly()
        {
            this.System = "System" + ".";
            this.SystemWindowsForms = this.SystemWindowsFormsNameSpace + ".";
            this.Generic = this.GenericNameSpace + ".";


            // GecericDictionary
            this.GenericTypeDict.Add("List<>", typeof(List<T>));
            this.GenericTypeDict.Add("Dictionary<,>", typeof(Dictionary<TKey, TValue>));
            this.GenericTypeDict.Add("Stack<>", typeof(Stack<T>));
            this.GenericTypeDict.Add("Queue<>", typeof(Queue<T>));
            this.GenericTypeDict.Add("IList<>", typeof(IList<T>));
        }

        protected string NameSpaceEnumToNameSpaceString(Ｃシャープ日本語化リフレクション.ReflectOtherAssembly.NameSpaceEnum ns)
        {
            switch (ns)
            {
                case Ｃシャープ日本語化リフレクション.ReflectOtherAssembly.NameSpaceEnum.WindowsForms:
                    return this.SystemWindowsFormsNameSpace;
                    break;
                case Ｃシャープ日本語化リフレクション.ReflectOtherAssembly.NameSpaceEnum.System:
                    return this.SystemNameSpace;
                    break;
                case NameSpaceEnum.Generic:
                    return this.GenericNameSpace;
                    break;
            }
            return string.Empty;
        }
        protected string NameSpaceEnumToObjectTreeString(Ｃシャープ日本語化リフレクション.ReflectOtherAssembly.NameSpaceEnum ns)
        {
            switch (ns)
            {
                case Ｃシャープ日本語化リフレクション.ReflectOtherAssembly.NameSpaceEnum.WindowsForms:
                    return this.SystemWindowsForms;
                    break;
                case Ｃシャープ日本語化リフレクション.ReflectOtherAssembly.NameSpaceEnum.System:
                    return this.System;
                    break;
                case NameSpaceEnum.Generic:
                    return this.Generic;
                    break;
            }
            return string.Empty;
        }

        //public abstract Type GetTypeOfWindowsObject(string objectName, Ｃシャープ日本語化リフレクション.ReflectOtherAssembly.NameSpaceEnum ns = Ｃシャープ日本語化リフレクション.ReflectOtherAssembly.NameSpaceEnum.WindowsForms);

        protected Type GetGenericTyupe(string objectName)
        {
            if (this.GenericTypeDict.Keys.Contains(objectName))
            {
                return this.GenericTypeDict[objectName];
            }
            else
            {
                return null;
            }
            /*
            switch (objectName)
            {
                case "List<>":
                    return typeof(List<object>);
                case "Dictionary<,>":
                    return typeof(Dictionary<object, object>);
            }
            return null;
             */
        }

        public abstract string GetPublicToken();

        public virtual Type GetTypeOfWindowsObject(string objectName, Ｃシャープ日本語化リフレクション.ReflectOtherAssembly.NameSpaceEnum ns = Ｃシャープ日本語化リフレクション.ReflectOtherAssembly.NameSpaceEnum.WindowsForms)
        {
            Type type = null;
            //Type tForm = null;
            //Type tTextBox = null;

            if (objectName == null) return null;

            if (ns == NameSpaceEnum.Generic)
            {
                Type genericType = this.GetGenericTyupe(objectName);
                return genericType;
            }

            string fullTypeString = this.NameSpaceEnumToObjectTreeString(ns)
                    + objectName + ", "
                    + this.NameSpaceEnumToNameSpaceString(ns)
                    + this.GetPublicToken();

            try
            {
                //type = Type.GetType(objectFullName + ReflectOtherAssembly.FullyAssemblyPublicTokenVer4Forms);
                type = Type.GetType(fullTypeString);

                // http://stackoverflow.com/questions/13048171/c-net-type-gettypesystem-windows-forms-form-returns-null
                //tTextBox = Type.GetType("System.Windows.Forms.Form, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
                //tTextBox = Type.GetType("System.Windows.Forms.TextBox, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
            }
            catch (Exception excp)
            {
                return null;
            }
            return type;
        }



    }
}
