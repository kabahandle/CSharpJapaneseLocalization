using Microsoft.VisualBasic;
using MyDummySQL.DAOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Ｃシャープ日本語化リフレクション
{
    public partial class frmMain : Form
    {
        /*
        private readonly string SystemWindowsForms = "System.Windows.Forms.";
        // PublicToken:
        // http://stackoverflow.com/questions/13048171/c-net-type-gettypesystem-windows-forms-form-returns-null
        private readonly string FullyAssenblyPublicToken = ", System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
        */
        private Type prevType = null;

        private bool dirtyFlag = false;

        public class NameSpaceItem
        {
            public Ｃシャープ日本語化リフレクション.ReflectOtherAssembly.NameSpaceEnum nameSpace = ReflectOtherAssembly.NameSpaceEnum.None;
            public string nameSpaceString = string.Empty;
            public NameSpaceItem(Ｃシャープ日本語化リフレクション.ReflectOtherAssembly.NameSpaceEnum e, string nameSpaceString_)
            {
                this.nameSpace = e;
                this.nameSpaceString = nameSpaceString_;
            }
            public override string ToString()
            {
                return this.nameSpaceString;
            }
        }


        private FunctionSelector funcSelector = new FunctionSelector();

        public frmMain()
        {
            InitializeComponent();
        }

        public class ReflectDataListItem
        {
            public string item = string.Empty;
            public ReflectDataListItem(string item_)
            {
                this.item = item_;
            }
            public override string ToString()
            {
                return this.item;
            }
        }

        private void btnGetReflection_Click(object sender, EventArgs e)
        {
            // NameSpace
            if (this.cmbNameSpace.SelectedItem == null) return;
            NameSpaceItem sel = this.cmbNameSpace.SelectedItem as NameSpaceItem;
            if (sel == null) return;
            Ｃシャープ日本語化リフレクション.ReflectOtherAssembly.NameSpaceEnum ns = sel.nameSpace;

            // GetType
            ReflectOtherAssembly reflect = new ReflectOtherAssemblyVersionDotNet4();
            Type type = reflect.GetTypeOfWindowsObject(cmbReflectTarget.Text, ns);
            if (type == null)
            {
                MessageBox.Show("型情報が存在しません。");
                return;
            }

            // get reflection
            this.SetFullSignatureIntoReflectionList(type);
            /*
            this.listReflectionList.Items.Clear();
            BindingFlags flag =  BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.NonPublic;
            BindingList<string> dataSource = new BindingList<string>();
            foreach (var item in ReflectionHelper.GetMethodsInfoByBindingFlags(type, flag))
            {
                string publicprotected = ReflectionHelper.GetPublicProtected(item);
                string isVirtual = ReflectionHelper.GetVirtualIfOverrided(item);
                string fullsignature = publicprotected + isVirtual + item.ToString();

                //this.listReflectionList.Items.Add(publicprotected + isVirtual + item.ToString());
                dataSource.Add(fullsignature);
            }
             */
            /*
            this.bindingSource4ReflectionList.DataSource = dataSource;
            //this.bindingSource4ReflectionList.DataMember = "item";
            this.listReflectionList.DataSource = this.bindingSource4ReflectionList;
            this.listReflectionList.DisplayMember = "item";
            var a = this.listReflectionList.DataBindings;
            this.bindingSource4ReflectionList.Filter = " like 'O'";
             */
        }

        private void SetFullSignatureIntoReflectionList(Type type, string filter = "", string publicOrElse = "", bool isProperty = false, bool isEvent = false, bool methodOnly = false)
        {
            BindingFlags flag = BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.NonPublic;

            this.listReflectionList.BeginUpdate();
            this.listReflectionList.Items.Clear();
            List<string> signatures = this.GetFullSignatures(type, flag, filter, publicOrElse, isProperty, isEvent, methodOnly);
            this.listReflectionList.Items.AddRange(signatures.ToArray());
            this.listReflectionList.EndUpdate();
        }
        private bool JudgeIfOrNotAddSelectedFunc(string fullsignature, string filter = "", string publicOrElse = "", bool isProperty = false, bool isEvent = false, bool methodOnly = false)
        {
            string set_prop = "set_";
            string get_prop = "get_";
            string add_event = "add_";
            string remove_event = "remove_";
            if (!isProperty)
            {
                set_prop = string.Empty;
                get_prop = string.Empty;
            }
            if (!isEvent)
            {
                add_event = string.Empty;
                remove_event = string.Empty;
            }
            string methodonly_set_prop = "set_";
            string methodonly_get_prop = "get_";
            string methodonly_add_event = "add_";
            string methodonly_remove_event = "remove_";
            //this.listReflectionList.Items.Add(publicprotected + isVirtual + item.ToString());
            if (!methodOnly)
            {
                if (string.IsNullOrEmpty(filter)
                    && string.IsNullOrEmpty(publicOrElse)
                    && string.IsNullOrEmpty(set_prop)
                    && string.IsNullOrEmpty(get_prop)
                    && string.IsNullOrEmpty(add_event)
                    && string.IsNullOrEmpty(remove_event)
                )
                {
                    //this.listReflectionList.Items.Add(fullsignature);
                    return true;
                }
                else
                {
                    if (fullsignature != null)
                    {
                        if (this.IsStringContains(fullsignature, filter)
                            && this.IsStringStartsWith(fullsignature, publicOrElse)
                            && (this.IsStringContains(fullsignature, set_prop) || this.IsStringContains(fullsignature, get_prop))
                            && (this.IsStringContains(fullsignature, add_event) || this.IsStringContains(fullsignature, remove_event))
                            )
                        {
                            //this.listReflectionList.Items.Add(fullsignature);
                            return true;
                        }
                    }
                }
            }
            else
            {
                if (fullsignature != null)
                {
                    if (this.IsStringContains(fullsignature, filter)
                        && this.IsStringStartsWith(fullsignature, publicOrElse)
                        && (!this.IsStringContains(fullsignature, methodonly_set_prop) && !this.IsStringContains(fullsignature, methodonly_get_prop))
                        && (!this.IsStringContains(fullsignature, methodonly_add_event) && !this.IsStringContains(fullsignature, methodonly_remove_event))
                        )
                    {
                        //this.listReflectionList.Items.Add(fullsignature);
                        return true;
                    }
                }
            }
            return false;
  
        }
        private List<string> GetFullSignatures(Type type, BindingFlags flag, string filter = "", string publicOrElse = "", bool isProperty = false, bool isEvent = false, bool methodOnly = false)
        {
            List<string> sigunatures = new List<string>();
            if (filter == null) filter = string.Empty;
            if (publicOrElse == null) publicOrElse = string.Empty;

            /*
            string set_prop = "set_";
            string get_prop = "get_";
            string add_event = "add_";
            string remove_event = "remove_";
            if (!isProperty)
            {
                set_prop = string.Empty;
                get_prop = string.Empty;
            }
            if (!isEvent)
            {
                add_event = string.Empty;
                remove_event = string.Empty;
            }
            string methodonly_set_prop = "set_";
            string methodonly_get_prop = "get_";
            string methodonly_add_event = "add_";
            string methodonly_remove_event = "remove_";
            */

            this.prevType = type;

            //BindingFlags flag = BindingFlags.GetProperty | BindingFlags.Public | BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.NonPublic;
            foreach (var item in ReflectionHelper.GetMethodsInfoByBindingFlags(type, flag))
            {
                string publicprotected = ReflectionHelper.GetPublicProtected(item);
                string isVirtual = ReflectionHelper.GetVirtualIfOverrided(item);
                string fullsignature = publicprotected + isVirtual + item.ToString();

                if( this.JudgeIfOrNotAddSelectedFunc(fullsignature, filter, publicOrElse, isProperty, isEvent, methodOnly ) )
                {
                        sigunatures.Add(fullsignature);
                }


                /*
                //this.listReflectionList.Items.Add(publicprotected + isVirtual + item.ToString());
                if (!methodOnly)
                {
                    if (string.IsNullOrEmpty(filter)
                        && string.IsNullOrEmpty(publicOrElse)
                        && string.IsNullOrEmpty(set_prop)
                        && string.IsNullOrEmpty(get_prop)
                        && string.IsNullOrEmpty(add_event)
                        && string.IsNullOrEmpty(remove_event)
                    )
                    {
                        //this.listReflectionList.Items.Add(fullsignature);
                        sigunatures.Add(fullsignature);
                    }
                    else
                    {
                        if (fullsignature != null)
                        {
                            if (this.IsStringContains(fullsignature, filter)
                                && this.IsStringStartsWith(fullsignature, publicOrElse)
                                && (this.IsStringContains(fullsignature, set_prop) || this.IsStringContains(fullsignature, get_prop))
                                && (this.IsStringContains(fullsignature, add_event) || this.IsStringContains(fullsignature, remove_event))
                                )
                            {
                                //this.listReflectionList.Items.Add(fullsignature);
                                sigunatures.Add(fullsignature);
                            }
                        }
                    }
                }
                else
                {
                    if (fullsignature != null)
                    {
                        if (this.IsStringContains(fullsignature, filter)
                            && this.IsStringStartsWith(fullsignature, publicOrElse)
                            && (!this.IsStringContains(fullsignature, methodonly_set_prop) && !this.IsStringContains(fullsignature, methodonly_get_prop))
                            && (!this.IsStringContains(fullsignature, methodonly_add_event) && !this.IsStringContains(fullsignature, methodonly_remove_event))
                            )
                        {
                            //this.listReflectionList.Items.Add(fullsignature);
                            sigunatures.Add(fullsignature);
                        }
                    }
                }
                 */
            }
            //this.listReflectionList.EndUpdate();
            return sigunatures;
        }

        private bool IsStringContains(string src, string filterOr)
        {
            if( string.IsNullOrEmpty(src)) return false;
            if (string.IsNullOrEmpty(filterOr)) return true;
            return src.Contains(filterOr);
        }
        private bool IsStringStartsWith(string src, string publicOr)
        {
            if( string.IsNullOrEmpty(src)) return false;
            if (string.IsNullOrEmpty(publicOr)) return true;
            return src.StartsWith(publicOr);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.cmbReflectTarget.Load();
            this.cmbPrefix.SaveFilename = "prefix.txt";
            this.cmbPrefix.Load();

            this.cmbPublicElse.SelectedIndex = 0;

            object selected = new NameSpaceItem(ReflectOtherAssembly.NameSpaceEnum.WindowsForms, "System.Windows.Forms");
            this.cmbNameSpace.Items.Add(new NameSpaceItem(ReflectOtherAssembly.NameSpaceEnum.System, "System"));
            this.cmbNameSpace.Items.Add(new NameSpaceItem(ReflectOtherAssembly.NameSpaceEnum.Generic, "System.Collections.Generic"));
            this.cmbNameSpace.Items.Add(selected);
            this.cmbNameSpace.SelectedItem = selected;

            this.tbxJpLineOfListBox.ParentListView = this.listJpArgsInfo;

            this.cmbExportMethod.Text = "TSV";
            
            

            // Menu
            /*
            //Copy
            MenuItem mNdoc = new MenuItem();
            mNdoc.Text = "NDocコメント";
            mNdoc.Click += this.ShowNDocCommentDialog;
            //this.cMenu.Items.Add(mNdoc);
            this.tbxJpMethodName.ContextMenu = new ContextMenu();
            this.tbxJpMethodName.ContextMenu.MenuItems.Add(mNdoc);
             */
            this.AddMenusToControl(this.tbxJpMethodName);
            this.AddMenusToControl(this.tbxJpReturnType);
            this.AddMenusToControl(this.listJpArgsInfo);


            // SIZE
            using (DAOContext con = new DAOContext(AccessConstring.SettingConString))
            {
                con.OpenConnection();

                int ret = 0;

                SettingsSingleton.getValue(SettingsSingleton.KeyMainFormTop, out ret);
                if (ret > 0)
                {
                    this.Top = ret;
                }

                SettingsSingleton.getValue(SettingsSingleton.KeyMainFormLeft, out ret);
                if (ret > 0)
                {
                    this.Left = ret;
                }

                SettingsSingleton.getValue(SettingsSingleton.KeyMainFormWidth, out ret);
                if (ret > 0)
                {
                    this.Width = ret;
                }

                SettingsSingleton.getValue(SettingsSingleton.KeyMainFormHeight, out ret);
                if (ret > 0)
                {
                    this.Height = ret;
                }

                con.CloseConnection();
            }
        }

        private void AddMenusToControl(Control tbox)
        {
            ContextMenu menu = new System.Windows.Forms.ContextMenu();

            MenuItem mNdoc = new MenuItem();
            mNdoc.Text = "NDocコメント";
            mNdoc.Click += this.ShowNDocCommentDialog;
            //this.cMenu.Items.Add(mNdoc);
            mNdoc.Tag = (object)tbox;

            MenuItem mCopy = new MenuItem();
            mCopy.Text = "コピー";
            mCopy.Click += this.Copy;
            //this.cMenu.Items.Add(mNdoc);
            mCopy.Tag = (object)tbox;

            MenuItem mPaste = new MenuItem();
            mPaste.Text = "貼り付け";
            mPaste.Click += this.Paste;
            //this.cMenu.Items.Add(mNdoc);
            mPaste.Tag = (object)tbox;

            menu.MenuItems.Add(mNdoc);
            menu.MenuItems.Add(mCopy);
            menu.MenuItems.Add(mPaste);

            //this.tbxJpMethodName.ContextMenu = new ContextMenu();
            tbox.ContextMenu = menu;
        }

        private void ShowNDocCommentDialog(object sender, EventArgs e)
        {
            MenuItem m = sender as MenuItem;

            ListView l = m.Tag as ListView;
            if (l != null)
            {
                if( l.SelectedItems.Count > 0 )
                {
                    string text = l.SelectedItems[0].Text;

                    frmNDoc frm = new frmNDoc(text);
                    frm.ShowDialog();
                }
            }
            else
            {
                Control ctl = m.Tag as Control;
                if (ctl == null) return;
                if (string.IsNullOrEmpty(ctl.Text)) return;

                frmNDoc frm = new frmNDoc(ctl.Text);
                frm.ShowDialog();
            }
        }


        private void Paste(object sender, EventArgs e)
        {
            string text = Clipboard.GetText();
            if (!string.IsNullOrEmpty(text))
            {
                MenuItem m = sender as MenuItem;
                Control ctl = m.Tag as Control;
                if (ctl != null)
                {
                    ctl.Text = text;
                }
            }
        }
        private void Copy(object sender, EventArgs e)
        {
            MenuItem m = sender as MenuItem;
            Control ctl = m.Tag as Control;
            if (ctl != null)
            {
                Clipboard.SetText(ctl.Text);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.cmbReflectTarget.Save();
            this.cmbPrefix.Save();

            using (DAOContext con = new DAOContext(AccessConstring.SettingConString))
            {
                con.OpenConnection();

                SettingsSingleton.setValue(SettingsSingleton.KeyMainFormTop, this.Top);
                SettingsSingleton.setValue(SettingsSingleton.KeyMainFormLeft, this.Left);
                SettingsSingleton.setValue(SettingsSingleton.KeyMainFormWidth, this.Width);
                SettingsSingleton.setValue(SettingsSingleton.KeyMainFormHeight, this.Height);

                con.CloseConnection();
            }
        }

        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            object sel = this.cmbReflectTarget.SelectedItem;
            if (sel == null) return;
            this.cmbReflectTarget.Items.Remove(sel);
            this.cmbReflectTarget.Save();
        }

        private void listReflectionList_Click(object sender, EventArgs e)
        {
            if (this.dirtyFlag == true)
            {
                DialogResult ret = MessageBox.Show("編集を破棄しても宜しいですか？", "確認", MessageBoxButtons.OKCancel);
                if (ret == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }
            }

            string selectedFuncString = listReflectionList.SelectedItem as string;
            if (selectedFuncString == null) return;

            this.DoDispScreen(selectedFuncString, new ScreenDispCommand(this));

            this.dirtyFlag = false;
            this.lblJpStatus.Text = "日本語は編集されていません。";

            /*
            string returnType = string.Empty;
            string publicprotected = string.Empty;
            string virtualString = string.Empty;
            List<string> args = new List<string>();
            List<string> funcs = this.funcSelector.SelectFunctions(selectedFuncString, 1, out returnType,out args, out publicprotected, out virtualString);
            if (funcs.Count > 0)
            {
                // english
                this.tbxReturnType.Text = returnType;
                this.tbxMethodName.Text = funcs[0];
                this.tbxPublicOr.Text = publicprotected;
                this.tbxVirtual.Text = virtualString;

                this.listArgsInfo.Items.Clear();
                foreach (string arg in args)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = arg;
                    this.listArgsInfo.Items.Add(item);
                }

                // Japanese
                this.tbxJpReturnType.Text = returnType;
                this.tbxJpMethodName.Text = funcs[0];
                this.tbxJpPublicOr.Text = publicprotected;
                this.tbxJpVirtual.Text = virtualString;

                this.listJpArgsInfo.Items.Clear();
                foreach (string arg in args)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = arg;
                    this.listJpArgsInfo.Items.Add(item);
                }
            }
        */

        }

        private void DoDispScreen(string selectedFuncString, ICSJPCommand command)
        {
            string returnType = string.Empty;
            string publicprotected = string.Empty;
            string virtualString = string.Empty;
            List<string> args = new List<string>();
            List<string> funcs = this.funcSelector.SelectFunctions(selectedFuncString, 1, out returnType, out args, out publicprotected, out virtualString);
            if (funcs.Count > 0)
            {
                command.Execute(selectedFuncString, funcs[0], returnType, publicprotected, virtualString, args);

            }
        }

        #region // english props
        /*
        public string ReturnType
        {
            set
            {
                this.tbxReturnType.Text = value;
            }
        }
        public string MethodName
        {
            set
            {
                this.tbxMethodName.Text = value;
            }
        }
        public string PublicOr
        {
            set
            {
                this.tbxPublicOr.Text = value;
            }
        }
        public string VirtualString
        {
            set
            {
                this.tbxVirtual.Text = value;
            }
        }
        public ListView.ListViewItemCollection ListArgsInfoItems
        {
            get
            {
                return this.listArgsInfo.Items;
            }

        }
         */
        #endregion  // english props


        #region // japanese props
        /*
        public string JpReturnType
        {
            set
            {
                this.tbxJpReturnType.Text = value;
            }
        }
        public string JpMethodName
        {
            set
            {
                this.tbxJpMethodName.Text = value;
            }
        }
        public string JpPublicOr
        {
            set
            {
                this.tbxJpPublicOr.Text = value;
            }
        }
        public string JpVirtualString
        {
            set
            {
                this.tbxJpVirtual.Text = value;
            }
        }
        public ListView.ListViewItemCollection ListJpArgsInfoItems
        {
            get
            {
                return this.listJpArgsInfo.Items;
            }
        }
         */
        #endregion  // japanese props

        private interface ICSJPCommand
        {
            void Execute(string fullsigunature, string funcname, string returnType, string publicOr, string virtualString, List<string> args);
        }
        private class ScreenDispCommand : ICSJPCommand
        {
            public frmMain ParentForm { get; set; }
            public ScreenDispCommand(frmMain parentFrm)
            {
                this.ParentForm = parentFrm;
            }
            public void Execute(string fullsigunature, string funcname, string returnType, string publicOr, string virtualString, List<string> args)
            {
                // prefix
                string prefix = this.ParentForm.cmbPrefix.Text.Trim();
                if (string.IsNullOrEmpty(prefix))
                {
                    prefix = string.Empty;
                }

                using( DAOContext con = new DAOContext(AccessConstring.jpDBConString ))
                {
                    con.OpenConnection();

                    // english
                    this.ParentForm.tbxReturnType.Text = returnType;
                    this.ParentForm.tbxMethodName.Text = funcname;
                    this.ParentForm.tbxPublicOr.Text = publicOr;
                    this.ParentForm.tbxVirtual.Text = virtualString;

                    this.ParentForm.listArgsInfo.Items.Clear();
                    foreach (string arg in args)
                    {
                        ListViewItem item = new ListViewItem();
                        item.Text = arg;
                        this.ParentForm.listArgsInfo.Items.Add(item);
                    }

                    // Japanese
                    string ret = string.Empty;

                    SettingsSingleton.getValue(con, prefix + returnType, out ret);
                    if (!string.IsNullOrEmpty(ret))
                    {
                        this.ParentForm.tbxJpReturnType.Text = ret;
                    }
                    else
                    {
                        this.ParentForm.tbxJpReturnType.Text = returnType;
                    }

                    SettingsSingleton.getValue(con, prefix+ funcname, out ret);
                    if (!string.IsNullOrEmpty(ret))
                    {
                        this.ParentForm.tbxJpMethodName.Text = ret;
                    }
                    else
                    {
                        this.ParentForm.tbxJpMethodName.Text = funcname;
                    }

                    this.ParentForm.tbxJpPublicOr.Text = publicOr;
                    this.ParentForm.tbxJpVirtual.Text = virtualString;

                    this.ParentForm.listJpArgsInfo.Items.Clear();
                    foreach (string arg in args)
                    {
                        ListViewItem item = new ListViewItem();

                        SettingsSingleton.getValue(con, prefix + arg, out ret);
                        if (!string.IsNullOrEmpty(ret))
                        {
                            item.Text = ret;
                        }
                        else
                        {
                            item.Text = arg;
                        }

                        this.ParentForm.listJpArgsInfo.Items.Add(item);
                    }

                    con.CloseConnection();
                }
            }
        }

        public void SaveJpNameToDB()
        {
            //prefix
            string prefix = this.cmbPrefix.Text.Trim();
            if (string.IsNullOrEmpty(prefix))
            {
                prefix = string.Empty;
            }

            // english
            string returnTypeEn = this.tbxReturnType.Text;
            string funcnameEn = this.tbxMethodName.Text;
            string publicOrEn = this.tbxPublicOr.Text;
            string virtualStringEn = this.tbxVirtual.Text;

            List<string> ArgsListEn = new List<string>();//this.ParentForm.listArgsInfo.Items
            foreach ( var item in this.listArgsInfo.Items)
            {
                string arg = item.ToString();
                ArgsListEn.Add(arg);
                /*
                ListViewItem item = new ListViewItem();
                item.Text = arg;
                this.ParentForm.listArgsInfo.Items.Add(item);
                 */
            }

            // Japanese
            string returnTypeJp = this.tbxJpReturnType.Text;
            string funcnameJp = this.tbxJpMethodName.Text;
            string publicOrJp = this.tbxJpPublicOr.Text;
            string virtualStringJp = this.tbxJpVirtual.Text;

            //this.ParentForm.listJpArgsInfo.Items;
            List<string> ArgsListJp = new List<string>();
            foreach ( var item in this.listJpArgsInfo.Items)
            {
                string arg = item.ToString();
                ArgsListJp.Add(arg);
            }

            // convert and save
            using (DAOContext con = new DAOContext(AccessConstring.jpDBConString))
            {
                con.OpenConnection();

                if (!string.IsNullOrEmpty(returnTypeEn.Trim()) && !string.IsNullOrEmpty(returnTypeJp.Trim()))
                {
                    SettingsSingleton.setValue(con, prefix + returnTypeEn.Trim(), returnTypeJp.Trim());
                }
                if (!string.IsNullOrEmpty(funcnameEn.Trim()) && !string.IsNullOrEmpty(funcnameJp.Trim()))
                {
                    SettingsSingleton.setValue(con, prefix + funcnameEn.Trim(), funcnameJp.Trim());
                }

                int maxArgEn = ArgsListEn.Count;
                int maxArgJp = ArgsListJp.Count;
                int max = (maxArgEn < maxArgJp) ? maxArgEn : maxArgJp;

                try
                {
                    for (int i = 0; i < max; i++)
                    {
                        if (!string.IsNullOrEmpty(ArgsListEn[i].Trim()) && !string.IsNullOrEmpty(ArgsListJp[i].Trim()))
                        {
                            SettingsSingleton.setValue(con, prefix + ArgsListEn[i].Trim(), ArgsListJp[i].Trim());
                        }
                    }
                }
                catch (Exception excp)
                {
                }

                con.CloseConnection();
            }
        }

        private void tbxFilter_TextChanged(object sender, EventArgs e)
        {
            this.SearchReflectionList();
            /*
            if (string.IsNullOrEmpty(this.tbxFilter.Text)) return;
            if (this.prevType == null) return;

            this.SetFullSignatureIntoReflectionList(this.prevType, this.tbxFilter.Text);
            */
        }

        private void cmbPublicElse_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SearchReflectionList();
        }

        private void SearchReflectionList()
        {
            string filter = this.tbxFilter.Text;
            if (string.IsNullOrEmpty(filter))
            {
                filter = string.Empty;
            }

            string publicOrElse = this.cmbPublicElse.Items[this.cmbPublicElse.SelectedIndex] as string;
            if (string.IsNullOrEmpty(publicOrElse))
            {
                publicOrElse = string.Empty;
            };

            this.SetFullSignatureIntoReflectionList(this.prevType, filter, publicOrElse, this.chkIsProperty.Checked, this.chkIsEvent.Checked, this.chkMethodOnly.Checked);
        }

        private void chkIsProperty_CheckedChanged(object sender, EventArgs e)
        {
            this.SearchReflectionList();

        }

        private void chkIsEvent_CheckedChanged(object sender, EventArgs e)
        {
            this.SearchReflectionList();
        }

        private void chkMethodOnly_CheckedChanged(object sender, EventArgs e)
        {
            this.SearchReflectionList();

        }

        private void listReflectionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.listReflectionList_Click(sender, e);
        }

        private void listJpArgsInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void listJpArgsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            if (this.listJpArgsInfo.SelectedItems.Count < 1) return;
            ListViewItem item = this.listJpArgsInfo.SelectedItems[0] as ListViewItem;
            if (item == null) return;

            this.tbxJpLineOfListBox.Focus();
            this.tbxJpLineOfListBox.Top = this.listJpArgsInfo.Top + item.Bounds.Top;
            this.tbxJpLineOfListBox.Left = this.listJpArgsInfo.Left + item.Bounds.Left;
            this.tbxJpLineOfListBox.Width = item.Bounds.Width;
            this.tbxJpLineOfListBox.Height = item.Bounds.Height;
            this.tbxJpLineOfListBox.Visible = true;
            this.tbxJpLineOfListBox.BringToFront();
            this.tbxJpLineOfListBox.Text = item.Text;
             */
        }

        private void listJpArgsInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.EditJpArgList();
                e.Handled = true;
                return;
            }
        }

        private void EditJpArgList()
        {
            if (this.listJpArgsInfo.SelectedItems.Count < 1) return;
            ListViewItem item = this.listJpArgsInfo.SelectedItems[0] as ListViewItem;
            if (item == null) return;
            if (string.IsNullOrEmpty(item.Text)) return;

            this.tbxJpLineOfListBox.Top = this.listJpArgsInfo.Top + item.Bounds.Top;
            this.tbxJpLineOfListBox.Left = this.listJpArgsInfo.Left + item.Bounds.Left;
            this.tbxJpLineOfListBox.Width = item.Bounds.Width;
            this.tbxJpLineOfListBox.Height = item.Bounds.Height;
            this.tbxJpLineOfListBox.Visible = true;
            this.tbxJpLineOfListBox.BringToFront();
            this.tbxJpLineOfListBox.Text = item.Text;
            this.tbxJpLineOfListBox.Focus();
            this.dirtyFlag = true;
            this.lblJpStatus.Text = "日本語を編集中です。";
        }

        private void listJpArgsInfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.EditJpArgList();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.listReflectionList.Items.Count < 1) return;

            bool isCSV = false;

            if (this.cmbExportMethod.Text == "CSV")
            {
                isCSV = true;
            }

            //SaveFileDialogクラスのインスタンスを作成
            SaveFileDialog sfd = new SaveFileDialog();

            //はじめのファイル名を指定する
            sfd.FileName = "abc.txt";
            //はじめに表示されるフォルダを指定する
            sfd.InitialDirectory = Application.StartupPath;
            //[ファイルの種類]に表示される選択肢を指定する
            sfd.Filter = "CSVファイル(*.csv)|*.csv|テキストファイル(*.txt)|*.txt";
            //[ファイルの種類]ではじめに
            //「すべてのファイル」が選択されているようにする
            sfd.FilterIndex = 2;
            //タイトルを設定する
            sfd.Title = "保存先のファイルを選択してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            sfd.RestoreDirectory = true;
            //既に存在するファイル名を指定したとき警告する
            //デフォルトでTrueなので指定する必要はない
            sfd.OverwritePrompt = true;
            //存在しないパスが指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            sfd.CheckPathExists = true;

            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき
                //選択されたファイル名を表示する
                //Console.WriteLine(sfd.FileName);

                string filename = Path.GetFileName(sfd.FileName);
                string ext = Path.GetExtension(sfd.FileName);
                string path = Path.GetDirectoryName(sfd.FileName);
                string filetitle = filename.Substring(0, filename.Length - ext.Length);
                string ClassFileName = path + @"\" + filetitle + ext;
                string MethodFileName = path + @"\" + filetitle + "_method" + ext;
                string ArgsFileName = path + @"\" + filetitle + "_args" + ext;

                //FileStream ClassFs = null;
                FileStream MethodFs = null;
                FileStream ArgsFs = null;
                //StreamWriter ClassWriter = null;
                StreamWriter MethodWriter = null;
                StreamWriter ArgsWriter = null;
                try
                {
                    /*
                    try
                    {
                        ClassFs = File.Open(ClassFileName, FileMode.OpenOrCreate | FileMode.Truncate);
                    }
                    catch (Exception excp)
                    {
                        ClassFs = File.Open(ClassFileName, FileMode.OpenOrCreate);
                    }
                     */
                    try
                    {
                        MethodFs = File.Open(MethodFileName, FileMode.OpenOrCreate | FileMode.Truncate);
                    }
                    catch (Exception excp)
                    {
                        MethodFs = File.Open(MethodFileName, FileMode.OpenOrCreate);
                    }
                    try
                    {
                        ArgsFs = File.Open(ArgsFileName, FileMode.OpenOrCreate | FileMode.Truncate);
                    }
                    catch (Exception excp)
                    {
                        ArgsFs = File.Open(ArgsFileName, FileMode.OpenOrCreate);
                    }

                    //ClassWriter = new StreamWriter(ClassFs, Encoding.Default);
                    MethodWriter = new StreamWriter(MethodFs, Encoding.Default);
                    ArgsWriter = new StreamWriter(ArgsFs, Encoding.Default);


                    if (isCSV)
                    {   // CSV
                        MethodWriter.WriteLine(
                            "\"signature\"," +
                            "\"pubilc\"," +
                            "\"virtual\"," +
                            "\"return type\"," +
                            "\"method name\","
                            );
                        MethodWriter.Flush();

                        ArgsWriter.WriteLine(
                            "\"signature\"," +
                            "\"arg\","
                                );
                        ArgsWriter.Flush();
                    }
                    else
                    {   // TSV
                        MethodWriter.WriteLine(
                            "signature" + ControlChars.Tab +
                            "public" + ControlChars.Tab +
                            "virtual" + ControlChars.Tab +
                            "return type" + ControlChars.Tab +
                            "method name" + ControlChars.Tab
                            );
                        MethodWriter.Flush();

                        ArgsWriter.WriteLine(
                            "signature" + ControlChars.Tab +
                            "arg" + ControlChars.Tab
                                );
                        ArgsWriter.Flush();
                    }


                    foreach (object obj in this.listReflectionList.Items)
                    {
                        string fullsignature = obj as string;
                        if (fullsignature == null) continue;

                        string returnType = string.Empty;
                        string publicprotected = string.Empty;
                        string virtualString = string.Empty;
                        List<string> args = new List<string>();
                        List<string> funcs = this.funcSelector.SelectFunctions(fullsignature, 1, out returnType, out args, out publicprotected, out virtualString);

                        if (this.JudgeIfOrNotAddSelectedFunc(fullsignature, this.tbxFilter.Text, this.cmbPublicElse.Text, this.chkIsProperty.Checked, this.chkIsEvent.Checked, this.chkMethodOnly.Checked))
                        {

                            if (funcs.Count > 0)
                            {
                                if (isCSV)
                                {   // CSV
                                    MethodWriter.WriteLine(
                                        "\"" + fullsignature + "\"," +
                                        "\"" + publicprotected + "\"," +
                                        "\"" + virtualString + "\"," +
                                        "\"" + returnType + "\"," +
                                        "\"" + funcs[0] + "\","
                                        );
                                    MethodWriter.Flush();

                                    foreach (string arg in args)
                                    {
                                        ArgsWriter.WriteLine(
                                        "\"" + fullsignature + "\"," +
                                        "\"" + arg + "\","
                                            );
                                        ArgsWriter.Flush();
                                    }
                                }
                                else
                                {   // TSV
                                    MethodWriter.WriteLine(
                                        fullsignature + ControlChars.Tab +
                                        publicprotected + ControlChars.Tab +
                                        virtualString + ControlChars.Tab +
                                        returnType + ControlChars.Tab +
                                        funcs[0] + ControlChars.Tab
                                        );
                                    MethodWriter.Flush();

                                    foreach (string arg in args)
                                    {
                                        ArgsWriter.WriteLine(
                                        fullsignature + ControlChars.Tab +
                                        arg + ControlChars.Tab
                                            );
                                        ArgsWriter.Flush();
                                    }

                                }
                            }
                        }
                    }

                }
                catch (Exception excp)
                {
                }
                finally
                {
                    if (MethodWriter != null)
                    {
                        MethodWriter.Close();
                    }
                    if (ArgsWriter != null)
                    {
                        ArgsWriter.Close();
                    }
                    if (MethodFs != null)
                    {
                        MethodFs.Close();
                    }
                    if (ArgsFs != null)
                    {
                        ArgsFs.Close();
                    }
                }
            }
        }

        private void btnJPSave_Click(object sender, EventArgs e)
        {
            this.SaveJpNameToDB();
            this.dirtyFlag = false;
            this.lblJpStatus.Text = "日本語を保存しました。";
        }

        private void tbxJpReturnType_TextChanged(object sender, EventArgs e)
        {
            this.dirtyFlag = true;
            this.lblJpStatus.Text = "日本語を編集中です。";
        }

        private void tbxJpMethodName_TextChanged(object sender, EventArgs e)
        {
            this.dirtyFlag = true;
            this.lblJpStatus.Text = "日本語を編集中です。";
        }

        private void tbxJpLineOfListBox_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
