using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ｃシャープ日本語化リフレクション
{
    class ReflectOtherAssemblyVersionBase
    {
        protected readonly string SystemNameSpace = "mscorlib"; /*"System";*/
        protected readonly string SystemWindowsFormsNameSpace = "System.Windows.Forms";
        protected readonly string System = string.Empty;//"System" /*ReflectOtherAssemblyVersionBase.SystemNameSpace*/ + ".";
        protected readonly string SystemWindowsForms = string.Empty;//this.SystemWindowsFormsNameSpace + ".";

        //private static readonly string dataAssembly = "System.Data" + ReflectOtherAssembly.DotNet4PublicToken;

        // .NET 2.0 PublicToken:
        // http://forums.ni.com/t5/Measurement-Studio-for-NET/File-or-assembly-name-System-Windows-Forms-Version-2-0-0-0/td-p/2150190
        protected static readonly string DotNet2PublicToken = ", Version=2.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089";

        public ReflectOtherAssemblyVersionBase()
        {
            this.System = "System" + ".";
            this.SystemWindowsForms = this.SystemWindowsFormsNameSpace + ".";
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
            }
            return string.Empty;
        }

        public virtual Type GetTypeOfWindowsObject(string objectName, Ｃシャープ日本語化リフレクション.ReflectOtherAssembly.NameSpaceEnum ns = Ｃシャープ日本語化リフレクション.ReflectOtherAssembly.NameSpaceEnum.WindowsForms)
        {
            return null;
        }



    }
}
