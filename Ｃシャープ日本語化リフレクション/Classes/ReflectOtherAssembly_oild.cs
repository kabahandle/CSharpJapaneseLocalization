using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ｃシャープ日本語化リフレクション
{
    public class ReflectOtherAssembly_old
    {
        /*
        public const string SystemNameSpace = "mscorlib"; 
        public const string SystemWindowsFormsNameSpace = "System.Windows.Forms";
        public const string System = "System" + ".";
        public const string SystemWindowsForms = ReflectOtherAssembly.SystemWindowsFormsNameSpace + ".";

        // .NET 4.0 PublicToken:
        // http://stackoverflow.com/questions/13048171/c-net-type-gettypesystem-windows-forms-form-returns-null
        private static readonly string DotNet4PublicToken = ", Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
        //private static readonly string FullyAssemblyPublicTokenVer4Forms = ", System.Windows.Forms" + ReflectOtherAssembly.DotNet4PublicToken;

        //private static readonly string dataAssembly = "System.Data" + ReflectOtherAssembly.DotNet4PublicToken;

        // .NET 2.0 PublicToken:
        // http://forums.ni.com/t5/Measurement-Studio-for-NET/File-or-assembly-name-System-Windows-Forms-Version-2-0-0-0/td-p/2150190
        private static readonly string DotNet2PublicToken = ", Version=2.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089";
        */

        private ReflectOtherAssembly reflecDotNet4 = new ReflectOtherAssemblyVersionDotNet4();
        private ReflectOtherAssembly reflecDotNet2 = new ReflectOtherAssemblyVersionDotNet2();

        /*
        public enum NameSpaceEnum
        {
            None,
            WindowsForms,
            System
        }
        */

        public ReflectOtherAssembly_old() { }
/*
        private static string NameSpaceEnumToNameSpaceString(NameSpaceEnum ns)
        {
            switch (ns)
            {
                case NameSpaceEnum.WindowsForms:
                    return ReflectOtherAssembly.SystemWindowsFormsNameSpace;
                    break;
                case NameSpaceEnum.System:
                    return ReflectOtherAssembly.SystemNameSpace;
                    break;
            }
            return string.Empty;
        }
        private static string NameSpaceEnumToObjectTreeString(NameSpaceEnum ns)
        {
            switch (ns)
            {
                case NameSpaceEnum.WindowsForms:
                    return ReflectOtherAssembly.SystemWindowsForms;
                    break;
                case NameSpaceEnum.System:
                    return ReflectOtherAssembly.System;
                    break;
            }
            return string.Empty;
        }

 */

         /* 
        public Type GetTypeOfDotNet4WindowsObject(string objectName, NameSpaceEnum ns = NameSpaceEnum.WindowsForms)
        {
            return this.reflecDotNet4.GetTypeOfWindowsObject(objectName, ns);
            Type type = null;
            //Type tForm = null;
            //Type tTextBox = null;

            if (objectName == null) return null;

            try
            {
                //type = Type.GetType(objectFullName + ReflectOtherAssembly.FullyAssemblyPublicTokenVer4Forms);
                type = Type.GetType(
                    ReflectOtherAssembly.NameSpaceEnumToObjectTreeString(ns)
                    + objectName + ", " 
                    + ReflectOtherAssembly.NameSpaceEnumToNameSpaceString(ns) 
                    + ReflectOtherAssembly.DotNet4PublicToken);

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
          */

            /*
        public Type GetTypeOfDotNet2WindowsObject(string objectName, NameSpaceEnum ns = NameSpaceEnum.WindowsForms)
        {
            return this.reflecDotNet2.GetTypeOfWindowsObject(objectName, ns);

            Type type = null;

            if (objectName == null) return null;

            try
            {
                //type = Type.GetType(objectFullName + ReflectOtherAssembly.FullyAssemblyPublicTokenvVer2Forms);
                type = Type.GetType(
                    ReflectOtherAssembly.NameSpaceEnumToObjectTreeString(ns)
                    + objectName + ", "
                    + ReflectOtherAssembly.NameSpaceEnumToNameSpaceString(ns)
                    + ReflectOtherAssembly.DotNet2PublicToken);
            }
            catch (Exception excp)
            {
                return null;
            }
            return type;
        }
             */

    }
}
