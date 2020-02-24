using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ｃシャープ日本語化リフレクション;
using System.Reflection;
using NUnit.Framework;

namespace Ｃシャープ日本語化リフレクションFixture.Classes
{
    [TestFixture]
    public class ReflectionHelperFixture
    {
        public ReflectOtherAssembly reflectDotNet4 = new ReflectOtherAssemblyVersionDotNet4();
        public ReflectOtherAssembly reflectDotNet2 = new ReflectOtherAssemblyVersionDotNet2();

        [Test]
        [TestCase("TextBox")]
        [TestCase("ComboBox")]
        [TestCase("ListBox")]
        [TestCase("Panel")]
        [TestCase("Timer")]
        [TestCase("MenuStrip")]
        public void SeccessfullyGotReflectionControl(string controlName)
        {
            // GetType
            //controlName = ReflectOtherAssembly.SystemWindowsForms + controlName;
            Type type = this.reflectDotNet4.GetTypeOfWindowsObject(controlName);
            Assert.IsNotNull(type);

            // get reflection
            BindingFlags flag = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            var items = ReflectionHelper.GetMethodsInfoByBindingFlags(type, flag);
            Assert.IsNotNull(items);
            Assert.Less(0, items.Count());
        }

        [Test]
        [TestCase("String")]
        public void SeccessfullyGotReflectionString(string controlName)
        {
            // GetType
            //controlName = ReflectOtherAssembly.SystemWindowsForms + controlName;
            Type type = this.reflectDotNet4.GetTypeOfWindowsObject(controlName, ReflectOtherAssembly.NameSpaceEnum.System);
            Assert.IsNotNull(type);

            // get reflection
            BindingFlags flag = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            var items = ReflectionHelper.GetMethodsInfoByBindingFlags(type, flag);
            Assert.IsNotNull(items);
            Assert.Less(0, items.Count());
        }

        [Test]
        [TestCase("textBox")]
        [TestCase("ComboBoxx")]
        [TestCase("Listbox")]
        [TestCase("panel")]
        [TestCase("ttimer")]
        [TestCase("menuStrip")]
        public void GotFailedReflectionByPassMissTypeControl(string controlName)
        {
            // GetType
            //controlName = ReflectOtherAssembly.SystemWindowsForms + controlName;
            Type type = this.reflectDotNet4.GetTypeOfWindowsObject(controlName);
            Assert.IsNull(type);

            // get reflection
            BindingFlags flag = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            var items = ReflectionHelper.GetMethodsInfoByBindingFlags(type, flag);
            Assert.IsEmpty(items);
            //Assert.AreEqual(0, items.Count());
        }

        [Test]
        [TestCase("string")]
        public void GotFailedReflectionByPassMissTypeString(string controlName)
        {
            // GetType
            //controlName = ReflectOtherAssembly.SystemWindowsForms + controlName;
            Type type = this.reflectDotNet4.GetTypeOfWindowsObject(controlName, ReflectOtherAssembly.NameSpaceEnum.System);
            Assert.IsNull(type);

            // get reflection
            BindingFlags flag = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            var items = ReflectionHelper.GetMethodsInfoByBindingFlags(type, flag);
            Assert.IsEmpty(items);
            //Assert.AreEqual(0, items.Count());
        }

    }
}
