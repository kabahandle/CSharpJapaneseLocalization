using MyDummySQL.DAOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ｃシャープ日本語化リフレクション
{
    public partial class frmNDoc : Form
    {
        private string keyText = string.Empty;
        private readonly string NDocHeader = "NDoc_";

        public frmNDoc(string keytext)
        {
            InitializeComponent();

            this.keyText = keytext;
            this.lblTargetName.Text = this.keyText;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.tbxNDocComnment.Text))
            {
                MessageBox.Show("テキストボックスが空です。");
                return;
            }
            if (string.IsNullOrEmpty(lblTargetName.Text))
            {
                MessageBox.Show("ターゲットが空です。");
                return;
            }
            using( DAOContext con = new DAOContext(AccessConstring.jpDBConString) )
            {
                con.OpenConnection();
                SettingsSingleton.setValue(con, this.NDocHeader + this.lblTargetName.Text, this.tbxNDocComnment.Text);
                con.CloseConnection();
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNDoc_Load(object sender, EventArgs e)
        {
            using (DAOContext con = new DAOContext(AccessConstring.SettingConString))
            {
                con.OpenConnection();

                int ret = 0;

                SettingsSingleton.getValue(SettingsSingleton.KeyNDocTop, out ret);
                if (ret > 0)
                {
                    this.Top = ret;
                }

                SettingsSingleton.getValue(SettingsSingleton.KeyNDocLeft, out ret);
                if (ret > 0)
                {
                    this.Left = ret;
                }

                SettingsSingleton.getValue(SettingsSingleton.KeyNDocWidth, out ret);
                if (ret > 0)
                {
                    this.Width = ret;
                }

                SettingsSingleton.getValue(SettingsSingleton.KeyNDocHeight, out ret);
                if (ret > 0)
                {
                    this.Height = ret;
                }

                con.CloseConnection();
            }
        }

        private void frmNDoc_FormClosing(object sender, FormClosingEventArgs e)
        {
            using (DAOContext con = new DAOContext(AccessConstring.SettingConString))
            {
                con.OpenConnection();

                SettingsSingleton.setValue(SettingsSingleton.KeyNDocTop, this.Top);
                SettingsSingleton.setValue(SettingsSingleton.KeyNDocLeft, this.Left);
                SettingsSingleton.setValue(SettingsSingleton.KeyNDocWidth, this.Width);
                SettingsSingleton.setValue(SettingsSingleton.KeyNDocHeight, this.Height);

                con.CloseConnection();
            }
        }
    }
}
