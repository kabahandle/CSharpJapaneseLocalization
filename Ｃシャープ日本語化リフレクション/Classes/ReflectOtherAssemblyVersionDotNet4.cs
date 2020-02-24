using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ｃシャープ日本語化リフレクション
{
    public class ReflectOtherAssemblyVersionDotNet4 : ReflectOtherAssembly
    {
        // .NET 4.0 PublicToken:
        // http://stackoverflow.com/questions/13048171/c-net-type-gettypesystem-windows-forms-form-returns-null
        protected readonly string DotNet4PublicToken = ", Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
        //private static readonly string FullyAssemblyPublicTokenVer4Forms = ", System.Windows.Forms" + ReflectOtherAssembly.DotNet4PublicToken;

        public ReflectOtherAssemblyVersionDotNet4() : base() { }

        public override string GetPublicToken()
        {
            return this.DotNet4PublicToken;
        }

        /*
        public override Type GetTypeOfWindowsObject(string objectName, Ｃシャープ日本語化リフレクション.ReflectOtherAssembly.NameSpaceEnum ns = Ｃシャープ日本語化リフレクション.ReflectOtherAssembly.NameSpaceEnum.WindowsForms)
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

            string fullTypeString = base.NameSpaceEnumToObjectTreeString(ns)
                    + objectName + ", "
                    + base.NameSpaceEnumToNameSpaceString(ns)
                    + this.DotNet4PublicToken;

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
        */

    }
}
