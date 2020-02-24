using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ｃシャープ日本語化リフレクション;

namespace Ｃシャープ日本語化リフレクションFixture.Classes
{
    [TestFixture]
    public class ReflectOtherAssemblyFixture
    {
        /*
        private static readonly string SystemWindowsForms = "System.Windows.Forms.";
        // .NET 4.0 PublicToken:
        // http://stackoverflow.com/questions/13048171/c-net-type-gettypesystem-windows-forms-form-returns-null
        private static readonly string FullyAssemblyPublicTokenVer4Forms = ", System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";

        // .NET 2.0 PublicToken:
        // http://forums.ni.com/t5/Measurement-Studio-for-NET/File-or-assembly-name-System-Windows-Forms-Version-2-0-0-0/td-p/2150190
        private static readonly string FullyAssemblyPublicTokenvVer2Forms = ", System.Windows.Forms, Version=2.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089";
        */

        public ReflectOtherAssembly reflectDotNet4 = new ReflectOtherAssemblyVersionDotNet4();
        public ReflectOtherAssembly reflectDotNet2 = new ReflectOtherAssemblyVersionDotNet2();

        #region // setup, teardown


        #endregion  // setup, teardown

        #region // dotNet4.0 Forms

        [Test]
        public void EmptyNameDotNet4Forms()
        {
            string name = string.Empty;

            Type type = this.reflectDotNet4.GetTypeOfWindowsObject(name);

            Assert.IsNull(type);
        }

        [Test]
        //[ExpectedException(typeof(ArgumentNullException))]
        public void NullNameDotNet4Forms()
        {
            string name = null;

            Type type = this.reflectDotNet4.GetTypeOfWindowsObject(name);

            Assert.IsNull(type);
        }

        [Test]
        [TestCase("tTextBox")]
        [TestCase("textbox")]
        [TestCase("combobox")]
        [TestCase("Combobox")]
        [TestCase("listBox")]
        public void MissTypeNameDotNet4Forms(string typename)
        {
            //string fulltypename = this.reflect.SystemWindowsForms + typename;
            Type type = this.reflectDotNet4.GetTypeOfWindowsObject(typename);

            Assert.IsNull(type);
        }

        [Test]
        [TestCase("TextBox")]
        [TestCase("ComboBox")]
        [TestCase("ListBox")]
        public void SuccessForGettingTypeDotNet4Forms(string typename)
        {
            //string fulltypename = this.reflect.SystemWindowsForms + typename;
            Type type = this.reflectDotNet4.GetTypeOfWindowsObject(typename);

            Assert.AreEqual(typename, type.Name);
        }

        [Test]
        [TestCase("TextBox")]
        public void FailByTypeDotNet4NoneNameSpace(string typename)
        {
            //string fulltypename = this.reflect.System + typename;
            Type type = this.reflectDotNet4.GetTypeOfWindowsObject(typename, Ｃシャープ日本語化リフレクション.ReflectOtherAssembly.NameSpaceEnum.None);

            Assert.IsNull(type);
        }
        #endregion // dotNet4.0

        #region // dotNet4 System

        [Test]
        [TestCase("String")]
        [TestCase("Int32")]
        [TestCase("Int64")]
        [TestCase("Decimal")]
        public void SuccessForGettingTypeDotNet4String(string typename)
        {
            //string fulltypename = this.reflect.System + typename;
            Type type = this.reflectDotNet4.GetTypeOfWindowsObject(typename, Ｃシャープ日本語化リフレクション.ReflectOtherAssembly.NameSpaceEnum.System);

            Assert.AreEqual(typename, type.Name);
        }

        [Test]
        [TestCase("string")]
        [TestCase("int")]
        [TestCase("long")]
        [TestCase("decimal")]
        public void FailByTypeDotNet4string(string typename)
        {
            //string fulltypename = this.reflect.System + typename;
            Type type = this.reflectDotNet4.GetTypeOfWindowsObject(typename, Ｃシャープ日本語化リフレクション.ReflectOtherAssembly.NameSpaceEnum.System);

            Assert.IsNull(type);
        }
        #endregion  // dotNet4 System


        #region // dotNet4.0 Generic
        [Test]
        [TestCase("List<>", "List`1")]
        [TestCase("Dictionary<,>", "Dictionary`2")]
        [TestCase("IList<>", "IList`1")]
        [TestCase("Stack<>", "Stack`1")]
        [TestCase("Queue<>", "Queue`1")]
        public void SeccessByGenricTypeDotNet4(string typename, string resultTypeName)
        {
            Type type = this.reflectDotNet4.GetTypeOfWindowsObject(typename, Ｃシャープ日本語化リフレクション.ReflectOtherAssembly.NameSpaceEnum.Generic);

            Assert.IsNotNull(type);
            Assert.AreEqual(resultTypeName, type.Name);
        }

        [Test]
        [TestCase("List<T>", "List`1")]
        [TestCase("List<object>", "List`1")]
        [TestCase("List<System.String>", "List`1")]
        [TestCase("Dictionary<T,T>", "Dictionary`2")]
        [TestCase("Dictionary<object,object>", "Dictionary`2")]
        [TestCase("Dictionary<System.String,System.String>", "Dictionary`2")]
        public void FailByWrongGenricTypeDotNet4(string typename, string resultTypeName)
        {
            Type type = this.reflectDotNet4.GetTypeOfWindowsObject(typename, Ｃシャープ日本語化リフレクション.ReflectOtherAssembly.NameSpaceEnum.Generic);

            Assert.IsNull(type);
            //Assert.AreNotEqual(resultTypeName, type.Name);
        }
        #endregion  // dotNew4.0 Generic



        #region // dotNet2.0 Forms
        [Test]
        public void EmptyNameDotNet2Forms()
        {
            string name = string.Empty;

            Type type = this.reflectDotNet2.GetTypeOfWindowsObject(name);

            Assert.IsNull(type);
        }

        [Test]
        //[ExpectedException(typeof(ArgumentNullException))]
        public void NullNameDotNet2Forms()
        {
            string name = null;

            Type type = this.reflectDotNet2.GetTypeOfWindowsObject(name);

            Assert.IsNull(type);
        }

        [Test]
        [TestCase("tTextBox")]
        [TestCase("textbox")]
        [TestCase("combobox")]
        [TestCase("Combobox")]
        [TestCase("listBox")]
        public void MissTypeNameDotNet2Forms(string typename)
        {
            //string fulltypename = this.reflect.SystemWindowsForms + typename;
            Type type = this.reflectDotNet2.GetTypeOfWindowsObject(typename);

            Assert.IsNull(type);
        }

        [Test]
        [TestCase("TextBox")]
        [TestCase("ComboBox")]
        [TestCase("ListBox")]
        public void SuccessForGettingTypeDotNet2Forms(string typename)
        {
            //string fulltypename = this.reflect.SystemWindowsForms + typename;
            Type type = this.reflectDotNet2.GetTypeOfWindowsObject(typename);

            Assert.AreEqual(typename, type.Name);
        }

        [Test]
        [TestCase("TextBox")]
        public void FailByTypeDotNet2NoneNameSpace(string typename)
        {
            //string fulltypename = this.reflect.System + typename;
            Type type = this.reflectDotNet2.GetTypeOfWindowsObject(typename, Ｃシャープ日本語化リフレクション.ReflectOtherAssembly.NameSpaceEnum.None);

            Assert.IsNull(type);
        }

        #endregion  // dotNet2.0

        #region // dotNet2.0 Sytstem

        [Test]
        [TestCase("String")]
        [TestCase("Int32")]
        [TestCase("Int64")]
        [TestCase("Decimal")]
        public void SuccessForGettingTypeDotNet2String(string typename)
        {
            //string fulltypename = this.reflect.System + typename;
            Type type = this.reflectDotNet2.GetTypeOfWindowsObject(typename, Ｃシャープ日本語化リフレクション.ReflectOtherAssembly.NameSpaceEnum.System);

            Assert.AreEqual(typename, type.Name);
        }

        [Test]
        [TestCase("string")]
        [TestCase("int")]
        [TestCase("long")]
        [TestCase("decimal")]
        public void FailByTypeDotNet2string(string typename)
        {
            //string fulltypename = this.reflect.System + typename;
            Type type = this.reflectDotNet2.GetTypeOfWindowsObject(typename, Ｃシャープ日本語化リフレクション.ReflectOtherAssembly.NameSpaceEnum.System);

            Assert.IsNull(type);
        }
        #endregion  // dotNet2.0 Sytstem


        #region // dotNet2.0 Generic
        [Test]
        [TestCase("List<>", "List`1")]
        [TestCase("Dictionary<,>", "Dictionary`2")]
        public void SeccessByGenricTypeDotNet2(string typename, string resultTypeName)
        {
            Type type = this.reflectDotNet2.GetTypeOfWindowsObject(typename, Ｃシャープ日本語化リフレクション.ReflectOtherAssembly.NameSpaceEnum.Generic);

            Assert.IsNotNull(type);
            Assert.AreEqual(resultTypeName, type.Name);
        }

        [Test]
        [TestCase("List<T>", "List`1")]
        [TestCase("List<object>", "List`1")]
        [TestCase("List<System.String>", "List`1")]
        [TestCase("Dictionary<T,T>", "Dictionary`2")]
        [TestCase("Dictionary<object,object>", "Dictionary`2")]
        [TestCase("Dictionary<System.String,System.String>", "Dictionary`2")]
        public void FailByWrongGenricTypeDotNet2(string typename, string resultTypeName)
        {
            Type type = this.reflectDotNet2.GetTypeOfWindowsObject(typename, Ｃシャープ日本語化リフレクション.ReflectOtherAssembly.NameSpaceEnum.Generic);

            Assert.IsNull(type);
            //Assert.AreNotEqual(resultTypeName, type.Name);
        }

        #endregion  // dotNew2.0 Generic

    }
}
