using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Ｃシャープ日本語化リフレクション
{
    public partial class Form1 : Form
    {
        private readonly string SystemWindowsForms = "System.Windows.Forms.";
        // PublicToken:
        // http://stackoverflow.com/questions/13048171/c-net-type-gettypesystem-windows-forms-form-returns-null
        private readonly string FullyAssenblyPublicToken = ", System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGetReflection_Click(object sender, EventArgs e)
        {
            // GetType
            Type type = ReflectOtherAssembly.GetTypeOfDotNet4WindowsFormsControl(cmbReflectTarget.Text);
            if (type == null)
            {
                MessageBox.Show("型情報が存在しません。");
                return;
            }

            // get reflection
            BindingFlags flag = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            foreach (var item in this.GetMethodsInfoByBindingFlags(type, flag))
            {
                this.richReflectionInfo.AppendText(item.ToString() + ControlChars.CrLf);
            }
        }

        private IEnumerable<MethodInfo> GetMethodsInfoByBindingFlags(Type type, BindingFlags flag)
        {
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
    }
}
