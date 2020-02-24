using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ｃシャープ日本語化リフレクション
{
    public class ReflectOtherAssemblyVersionDotNet2 : ReflectOtherAssembly
    {
        // .NET 2.0 PublicToken:
        // http://forums.ni.com/t5/Measurement-Studio-for-NET/File-or-assembly-name-System-Windows-Forms-Version-2-0-0-0/td-p/2150190
        protected readonly string DotNet2PublicToken = ", Version=2.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089";

        public ReflectOtherAssemblyVersionDotNet2() : base() { }

        public override string GetPublicToken()
        {
            return this.DotNet2PublicToken;
        }

        /*
        public override Type GetTypeOfWindowsObject(string objectName, Ｃシャープ日本語化リフレクション.ReflectOtherAssembly.NameSpaceEnum ns = Ｃシャープ日本語化リフレクション.ReflectOtherAssembly.NameSpaceEnum.WindowsForms)
        {
            Type type = null;

            if (objectName == null) return null;

            try
            {
                //type = Type.GetType(objectFullName + ReflectOtherAssembly.FullyAssemblyPublicTokenvVer2Forms);
                type = Type.GetType(
                    base.NameSpaceEnumToObjectTreeString(ns)
                    + objectName + ", "
                    + base.NameSpaceEnumToNameSpaceString(ns)
                    + this.DotNet2PublicToken);
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
