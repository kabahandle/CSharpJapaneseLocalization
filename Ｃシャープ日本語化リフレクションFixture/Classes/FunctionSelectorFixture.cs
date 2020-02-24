using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ｃシャープ日本語化リフレクション;
using System.Reflection;

namespace Ｃシャープ日本語化リフレクションFixture.Classes
{
    [TestFixture]
    public class FunctionSelectorFixture
    {
        public FunctionSelector funcSelect = new FunctionSelector();
        public string returnType = string.Empty;
        public string publicprotected = string.Empty;
        public string virtualString = string.Empty;
        public List<string> args = new List<string>();

        [SetUp]
        public void SetUp()
        {
            this.returnType = string.Empty;
            this.publicprotected = string.Empty;
            this.virtualString = string.Empty;
            this.args = new List<string>();
        }


        [Test]
        public void PublicFunc01()
        {
            string line = "public void func01(string str1, int intVal2, long lngVal3)";

            List<string> funcs = this.funcSelect.SelectFunctions(line, 1, out this.returnType, out this.args, out this.publicprotected, out this.virtualString);

            Assert.AreEqual("public", this.publicprotected);
            Assert.AreEqual(string.Empty, this.virtualString);
            Assert.AreEqual(1, funcs.Count);
            Assert.AreEqual("func01", funcs[0]);
            Assert.AreEqual(3, this.args.Count);
            Assert.AreEqual("string str1", this.args[0]);
            Assert.AreEqual("int intVal2", this.args[1]);
            Assert.AreEqual("long lngVal3",this.args[2]);
        }

        [Test]
        public void PrivateFunc02()
        {
            string line = "private virtual void func02( decimal dec1, int intVal2,  float fltVal3,  byte byt4 );";

            List<string> funcs = this.funcSelect.SelectFunctions(line, 1, out this.returnType, out this.args, out this.publicprotected, out this.virtualString);

            Assert.AreEqual("private", this.publicprotected);
            Assert.AreEqual("virtual", this.virtualString);
            Assert.AreEqual(1, funcs.Count);
            Assert.AreEqual("func02", funcs[0]);
            Assert.AreEqual(4, this.args.Count);
            Assert.AreEqual("decimal dec1", this.args[0]);
            Assert.AreEqual("int intVal2", this.args[1]);
            Assert.AreEqual("float fltVal3", this.args[2]);
            Assert.AreEqual("byte byt4", this.args[3]);
        }

        [Test]
        public void ProtectedFunc03()
        {
            string line = "protected   virtual  void   func02(  decimal    dec1 , int intVal2, float fltVal3, byte byt4) ; ";

            List<string> funcs = this.funcSelect.SelectFunctions(line, 1, out this.returnType, out this.args, out this.publicprotected, out this.virtualString);

            Assert.AreEqual("protected", this.publicprotected);
            Assert.AreEqual("virtual", this.virtualString);
            Assert.AreEqual(1, funcs.Count);
            Assert.AreEqual("func02", funcs[0]);
            Assert.AreEqual(4, this.args.Count);
            Assert.AreNotEqual("decimal dec1", this.args[0]);
            Assert.AreEqual("decimal    dec1",this.args[0]);
            Assert.AreEqual("int intVal2", this.args[1]);
            Assert.AreEqual("float fltVal3", this.args[2]);
            Assert.AreEqual("byte byt4", this.args[3]);
        }
    }
}
