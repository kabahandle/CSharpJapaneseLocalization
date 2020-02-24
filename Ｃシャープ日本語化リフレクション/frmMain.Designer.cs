namespace Ｃシャープ日本語化リフレクション
{
    partial class frmMain
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnGetReflection = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblJpStatus = new System.Windows.Forms.Label();
            this.btnJPSave = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbExportMethod = new System.Windows.Forms.ComboBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.chkMethodOnly = new System.Windows.Forms.CheckBox();
            this.chkIsEvent = new System.Windows.Forms.CheckBox();
            this.chkIsProperty = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbPublicElse = new System.Windows.Forms.ComboBox();
            this.tbxFilter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNameSpace = new System.Windows.Forms.ComboBox();
            this.btnClearHistory = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageEnglish = new System.Windows.Forms.TabPage();
            this.listReflectionList = new System.Windows.Forms.ListBox();
            this.tabPageJapanese = new System.Windows.Forms.TabPage();
            this.listJpReflectionList = new System.Windows.Forms.ListBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.listArgsInfo = new System.Windows.Forms.ListView();
            this.enArgs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbxVirtual = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxPublicOr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxMethodName = new System.Windows.Forms.TextBox();
            this.tbxReturnType = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listJpArgsInfo = new System.Windows.Forms.ListView();
            this.args = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.bindingSource4ReflectionList = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tbxJpLineOfListBox = new Ｃシャープ日本語化リフレクション.MyFloatingTextBox();
            this.tbxJpVirtual = new Ｃシャープ日本語化リフレクション.MySelectAllTextBoxIfFocused();
            this.tbxJpPublicOr = new Ｃシャープ日本語化リフレクション.MySelectAllTextBoxIfFocused();
            this.tbxJpMethodName = new Ｃシャープ日本語化リフレクション.MySelectAllTextBoxIfFocused();
            this.tbxJpReturnType = new Ｃシャープ日本語化リフレクション.MySelectAllTextBoxIfFocused();
            this.cmbReflectTarget = new Ｃシャープ日本語化リフレクション.MyCombo();
            this.cmbPrefix = new Ｃシャープ日本語化リフレクション.MyCombo();
            this.lblPrefix = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageEnglish.SuspendLayout();
            this.tabPageJapanese.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource4ReflectionList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetReflection
            // 
            this.btnGetReflection.Location = new System.Drawing.Point(24, 47);
            this.btnGetReflection.Name = "btnGetReflection";
            this.btnGetReflection.Size = new System.Drawing.Size(116, 23);
            this.btnGetReflection.TabIndex = 1;
            this.btnGetReflection.Text = "リフレクションを取得";
            this.btnGetReflection.UseVisualStyleBackColor = true;
            this.btnGetReflection.Click += new System.EventHandler(this.btnGetReflection_Click);
            // 
            // pnlHeader
            // 
            this.pnlHeader.Controls.Add(this.lblPrefix);
            this.pnlHeader.Controls.Add(this.cmbPrefix);
            this.pnlHeader.Controls.Add(this.lblJpStatus);
            this.pnlHeader.Controls.Add(this.btnJPSave);
            this.pnlHeader.Controls.Add(this.label13);
            this.pnlHeader.Controls.Add(this.cmbExportMethod);
            this.pnlHeader.Controls.Add(this.btnExport);
            this.pnlHeader.Controls.Add(this.chkMethodOnly);
            this.pnlHeader.Controls.Add(this.chkIsEvent);
            this.pnlHeader.Controls.Add(this.chkIsProperty);
            this.pnlHeader.Controls.Add(this.label5);
            this.pnlHeader.Controls.Add(this.cmbPublicElse);
            this.pnlHeader.Controls.Add(this.tbxFilter);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.cmbNameSpace);
            this.pnlHeader.Controls.Add(this.btnClearHistory);
            this.pnlHeader.Controls.Add(this.cmbReflectTarget);
            this.pnlHeader.Controls.Add(this.btnGetReflection);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(973, 115);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblJpStatus
            // 
            this.lblJpStatus.AutoSize = true;
            this.lblJpStatus.Location = new System.Drawing.Point(754, 82);
            this.lblJpStatus.Name = "lblJpStatus";
            this.lblJpStatus.Size = new System.Drawing.Size(50, 12);
            this.lblJpStatus.TabIndex = 15;
            this.lblJpStatus.Text = "ステータス";
            // 
            // btnJPSave
            // 
            this.btnJPSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnJPSave.Location = new System.Drawing.Point(756, 50);
            this.btnJPSave.Name = "btnJPSave";
            this.btnJPSave.Size = new System.Drawing.Size(75, 20);
            this.btnJPSave.TabIndex = 14;
            this.btnJPSave.Text = "日本語保存";
            this.btnJPSave.UseVisualStyleBackColor = true;
            this.btnJPSave.Click += new System.EventHandler(this.btnJPSave_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(683, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 13;
            this.label13.Text = "エクスポート：";
            // 
            // cmbExportMethod
            // 
            this.cmbExportMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbExportMethod.FormattingEnabled = true;
            this.cmbExportMethod.Items.AddRange(new object[] {
            "TSV",
            "CSV"});
            this.cmbExportMethod.Location = new System.Drawing.Point(754, 13);
            this.cmbExportMethod.Name = "cmbExportMethod";
            this.cmbExportMethod.Size = new System.Drawing.Size(77, 20);
            this.cmbExportMethod.TabIndex = 12;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(847, 11);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 11;
            this.btnExport.Text = "エクスポート";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // chkMethodOnly
            // 
            this.chkMethodOnly.AutoSize = true;
            this.chkMethodOnly.Location = new System.Drawing.Point(606, 66);
            this.chkMethodOnly.Name = "chkMethodOnly";
            this.chkMethodOnly.Size = new System.Drawing.Size(78, 16);
            this.chkMethodOnly.TabIndex = 10;
            this.chkMethodOnly.Text = "メソッドのみ";
            this.chkMethodOnly.UseVisualStyleBackColor = true;
            this.chkMethodOnly.CheckedChanged += new System.EventHandler(this.chkMethodOnly_CheckedChanged);
            // 
            // chkIsEvent
            // 
            this.chkIsEvent.AutoSize = true;
            this.chkIsEvent.Location = new System.Drawing.Point(536, 66);
            this.chkIsEvent.Name = "chkIsEvent";
            this.chkIsEvent.Size = new System.Drawing.Size(60, 16);
            this.chkIsEvent.TabIndex = 9;
            this.chkIsEvent.Text = "イベント";
            this.chkIsEvent.UseVisualStyleBackColor = true;
            this.chkIsEvent.CheckedChanged += new System.EventHandler(this.chkIsEvent_CheckedChanged);
            // 
            // chkIsProperty
            // 
            this.chkIsProperty.AutoSize = true;
            this.chkIsProperty.Location = new System.Drawing.Point(453, 66);
            this.chkIsProperty.Name = "chkIsProperty";
            this.chkIsProperty.Size = new System.Drawing.Size(68, 16);
            this.chkIsProperty.TabIndex = 8;
            this.chkIsProperty.Text = "プロパティ";
            this.chkIsProperty.UseVisualStyleBackColor = true;
            this.chkIsProperty.CheckedChanged += new System.EventHandler(this.chkIsProperty_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(393, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "PublicElse:";
            // 
            // cmbPublicElse
            // 
            this.cmbPublicElse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPublicElse.FormattingEnabled = true;
            this.cmbPublicElse.Items.AddRange(new object[] {
            "",
            "public",
            "protected",
            "privatate"});
            this.cmbPublicElse.Location = new System.Drawing.Point(453, 39);
            this.cmbPublicElse.Name = "cmbPublicElse";
            this.cmbPublicElse.Size = new System.Drawing.Size(104, 20);
            this.cmbPublicElse.TabIndex = 7;
            this.cmbPublicElse.SelectedIndexChanged += new System.EventHandler(this.cmbPublicElse_SelectedIndexChanged);
            // 
            // tbxFilter
            // 
            this.tbxFilter.Location = new System.Drawing.Point(453, 14);
            this.tbxFilter.Name = "tbxFilter";
            this.tbxFilter.Size = new System.Drawing.Size(221, 19);
            this.tbxFilter.TabIndex = 6;
            this.tbxFilter.TextChanged += new System.EventHandler(this.tbxFilter_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(393, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "フィルター：";
            // 
            // cmbNameSpace
            // 
            this.cmbNameSpace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNameSpace.FormattingEnabled = true;
            this.cmbNameSpace.Location = new System.Drawing.Point(24, 13);
            this.cmbNameSpace.Name = "cmbNameSpace";
            this.cmbNameSpace.Size = new System.Drawing.Size(168, 20);
            this.cmbNameSpace.TabIndex = 0;
            // 
            // btnClearHistory
            // 
            this.btnClearHistory.Location = new System.Drawing.Point(303, 47);
            this.btnClearHistory.Name = "btnClearHistory";
            this.btnClearHistory.Size = new System.Drawing.Size(75, 23);
            this.btnClearHistory.TabIndex = 3;
            this.btnClearHistory.Text = "履歴をクリア";
            this.btnClearHistory.UseVisualStyleBackColor = true;
            this.btnClearHistory.Click += new System.EventHandler(this.btnClearHistory_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 115);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(973, 341);
            this.splitContainer1.SplitterDistance = 323;
            this.splitContainer1.TabIndex = 5;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageEnglish);
            this.tabControl1.Controls.Add(this.tabPageJapanese);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(323, 341);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageEnglish
            // 
            this.tabPageEnglish.Controls.Add(this.listReflectionList);
            this.tabPageEnglish.Location = new System.Drawing.Point(4, 22);
            this.tabPageEnglish.Name = "tabPageEnglish";
            this.tabPageEnglish.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEnglish.Size = new System.Drawing.Size(315, 315);
            this.tabPageEnglish.TabIndex = 0;
            this.tabPageEnglish.Text = "英語";
            this.tabPageEnglish.UseVisualStyleBackColor = true;
            // 
            // listReflectionList
            // 
            this.listReflectionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listReflectionList.FormattingEnabled = true;
            this.listReflectionList.ItemHeight = 12;
            this.listReflectionList.Location = new System.Drawing.Point(3, 3);
            this.listReflectionList.Name = "listReflectionList";
            this.listReflectionList.Size = new System.Drawing.Size(309, 309);
            this.listReflectionList.TabIndex = 0;
            this.listReflectionList.Click += new System.EventHandler(this.listReflectionList_Click);
            this.listReflectionList.SelectedIndexChanged += new System.EventHandler(this.listReflectionList_SelectedIndexChanged);
            // 
            // tabPageJapanese
            // 
            this.tabPageJapanese.Controls.Add(this.listJpReflectionList);
            this.tabPageJapanese.Location = new System.Drawing.Point(4, 22);
            this.tabPageJapanese.Name = "tabPageJapanese";
            this.tabPageJapanese.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageJapanese.Size = new System.Drawing.Size(315, 315);
            this.tabPageJapanese.TabIndex = 1;
            this.tabPageJapanese.Text = "日本語";
            this.tabPageJapanese.UseVisualStyleBackColor = true;
            // 
            // listJpReflectionList
            // 
            this.listJpReflectionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listJpReflectionList.FormattingEnabled = true;
            this.listJpReflectionList.ItemHeight = 12;
            this.listJpReflectionList.Location = new System.Drawing.Point(3, 3);
            this.listJpReflectionList.Name = "listJpReflectionList";
            this.listJpReflectionList.Size = new System.Drawing.Size(309, 309);
            this.listJpReflectionList.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.listArgsInfo);
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tbxJpLineOfListBox);
            this.splitContainer2.Panel2.Controls.Add(this.listJpArgsInfo);
            this.splitContainer2.Panel2.Controls.Add(this.panel2);
            this.splitContainer2.Size = new System.Drawing.Size(646, 341);
            this.splitContainer2.SplitterDistance = 335;
            this.splitContainer2.TabIndex = 0;
            // 
            // listArgsInfo
            // 
            this.listArgsInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.enArgs});
            this.listArgsInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listArgsInfo.Location = new System.Drawing.Point(0, 125);
            this.listArgsInfo.Name = "listArgsInfo";
            this.listArgsInfo.Size = new System.Drawing.Size(335, 216);
            this.listArgsInfo.TabIndex = 1;
            this.listArgsInfo.UseCompatibleStateImageBehavior = false;
            this.listArgsInfo.View = System.Windows.Forms.View.Details;
            // 
            // enArgs
            // 
            this.enArgs.Text = "Args";
            this.enArgs.Width = 400;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbxVirtual);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.tbxPublicOr);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tbxMethodName);
            this.panel1.Controls.Add(this.tbxReturnType);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(335, 125);
            this.panel1.TabIndex = 0;
            // 
            // tbxVirtual
            // 
            this.tbxVirtual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxVirtual.Location = new System.Drawing.Point(74, 31);
            this.tbxVirtual.Name = "tbxVirtual";
            this.tbxVirtual.Size = new System.Drawing.Size(249, 19);
            this.tbxVirtual.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "Virtual";
            // 
            // tbxPublicOr
            // 
            this.tbxPublicOr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxPublicOr.Location = new System.Drawing.Point(74, 6);
            this.tbxPublicOr.Name = "tbxPublicOr";
            this.tbxPublicOr.Size = new System.Drawing.Size(249, 19);
            this.tbxPublicOr.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "PubilcOr：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "引数型：";
            // 
            // tbxMethodName
            // 
            this.tbxMethodName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxMethodName.Location = new System.Drawing.Point(74, 81);
            this.tbxMethodName.Name = "tbxMethodName";
            this.tbxMethodName.Size = new System.Drawing.Size(249, 19);
            this.tbxMethodName.TabIndex = 7;
            // 
            // tbxReturnType
            // 
            this.tbxReturnType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxReturnType.Location = new System.Drawing.Point(74, 56);
            this.tbxReturnType.Name = "tbxReturnType";
            this.tbxReturnType.Size = new System.Drawing.Size(249, 19);
            this.tbxReturnType.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "メソッド名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "戻り値型：";
            // 
            // listJpArgsInfo
            // 
            this.listJpArgsInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.args});
            this.listJpArgsInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listJpArgsInfo.Location = new System.Drawing.Point(0, 125);
            this.listJpArgsInfo.Name = "listJpArgsInfo";
            this.listJpArgsInfo.Size = new System.Drawing.Size(307, 216);
            this.listJpArgsInfo.TabIndex = 2;
            this.listJpArgsInfo.UseCompatibleStateImageBehavior = false;
            this.listJpArgsInfo.View = System.Windows.Forms.View.Details;
            this.listJpArgsInfo.SelectedIndexChanged += new System.EventHandler(this.listJpArgsList_SelectedIndexChanged);
            this.listJpArgsInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listJpArgsInfo_KeyDown);
            this.listJpArgsInfo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listJpArgsInfo_MouseDoubleClick);
            // 
            // args
            // 
            this.args.Text = "Args";
            this.args.Width = 400;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbxJpVirtual);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.tbxJpPublicOr);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.tbxJpMethodName);
            this.panel2.Controls.Add(this.tbxJpReturnType);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(307, 125);
            this.panel2.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 12);
            this.label8.TabIndex = 2;
            this.label8.Text = "Virtual";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "PubilcOr：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 107);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 8;
            this.label10.Text = "引数型：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(2, 84);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 12);
            this.label11.TabIndex = 6;
            this.label11.Text = "メソッド名：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(2, 59);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 12);
            this.label12.TabIndex = 4;
            this.label12.Text = "戻り値型：";
            // 
            // tbxJpLineOfListBox
            // 
            this.tbxJpLineOfListBox.ImeMode = System.Windows.Forms.ImeMode.On;
            this.tbxJpLineOfListBox.Location = new System.Drawing.Point(111, 263);
            this.tbxJpLineOfListBox.Name = "tbxJpLineOfListBox";
            this.tbxJpLineOfListBox.ParentListView = null;
            this.tbxJpLineOfListBox.Size = new System.Drawing.Size(100, 19);
            this.tbxJpLineOfListBox.TabIndex = 9;
            this.tbxJpLineOfListBox.Visible = false;
            this.tbxJpLineOfListBox.TextChanged += new System.EventHandler(this.tbxJpLineOfListBox_TextChanged);
            // 
            // tbxJpVirtual
            // 
            this.tbxJpVirtual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxJpVirtual.Location = new System.Drawing.Point(74, 31);
            this.tbxJpVirtual.Name = "tbxJpVirtual";
            this.tbxJpVirtual.Size = new System.Drawing.Size(221, 19);
            this.tbxJpVirtual.TabIndex = 3;
            // 
            // tbxJpPublicOr
            // 
            this.tbxJpPublicOr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxJpPublicOr.Location = new System.Drawing.Point(74, 6);
            this.tbxJpPublicOr.Name = "tbxJpPublicOr";
            this.tbxJpPublicOr.Size = new System.Drawing.Size(221, 19);
            this.tbxJpPublicOr.TabIndex = 1;
            // 
            // tbxJpMethodName
            // 
            this.tbxJpMethodName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxJpMethodName.Location = new System.Drawing.Point(74, 81);
            this.tbxJpMethodName.Name = "tbxJpMethodName";
            this.tbxJpMethodName.Size = new System.Drawing.Size(221, 19);
            this.tbxJpMethodName.TabIndex = 7;
            this.tbxJpMethodName.TextChanged += new System.EventHandler(this.tbxJpMethodName_TextChanged);
            // 
            // tbxJpReturnType
            // 
            this.tbxJpReturnType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxJpReturnType.Location = new System.Drawing.Point(74, 56);
            this.tbxJpReturnType.Name = "tbxJpReturnType";
            this.tbxJpReturnType.Size = new System.Drawing.Size(221, 19);
            this.tbxJpReturnType.TabIndex = 5;
            this.tbxJpReturnType.TextChanged += new System.EventHandler(this.tbxJpReturnType_TextChanged);
            // 
            // cmbReflectTarget
            // 
            this.cmbReflectTarget.FormattingEnabled = true;
            this.cmbReflectTarget.Location = new System.Drawing.Point(198, 13);
            this.cmbReflectTarget.Name = "cmbReflectTarget";
            this.cmbReflectTarget.Size = new System.Drawing.Size(180, 20);
            this.cmbReflectTarget.TabIndex = 2;
            // 
            // cmbPrefix
            // 
            this.cmbPrefix.FormattingEnabled = true;
            this.cmbPrefix.Location = new System.Drawing.Point(88, 82);
            this.cmbPrefix.Name = "cmbPrefix";
            this.cmbPrefix.Size = new System.Drawing.Size(121, 20);
            this.cmbPrefix.TabIndex = 16;
            // 
            // lblPrefix
            // 
            this.lblPrefix.AutoSize = true;
            this.lblPrefix.Location = new System.Drawing.Point(22, 85);
            this.lblPrefix.Name = "lblPrefix";
            this.lblPrefix.Size = new System.Drawing.Size(47, 12);
            this.lblPrefix.TabIndex = 17;
            this.lblPrefix.Text = "接頭辞：";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 456);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlHeader);
            this.Name = "frmMain";
            this.Text = "Main Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageEnglish.ResumeLayout(false);
            this.tabPageJapanese.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource4ReflectionList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MyCombo cmbReflectTarget;
        private System.Windows.Forms.Button btnGetReflection;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Button btnClearHistory;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.ListBox listReflectionList;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox tbxMethodName;
        public System.Windows.Forms.TextBox tbxReturnType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbNameSpace;
        private System.Windows.Forms.BindingSource bindingSource4ReflectionList;
        public System.Windows.Forms.TextBox tbxFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbPublicElse;
        private System.Windows.Forms.CheckBox chkIsEvent;
        private System.Windows.Forms.CheckBox chkIsProperty;
        private System.Windows.Forms.CheckBox chkMethodOnly;
        public System.Windows.Forms.TextBox tbxVirtual;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox tbxPublicOr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        public MySelectAllTextBoxIfFocused tbxJpVirtual;
        private System.Windows.Forms.Label label8;
        public MySelectAllTextBoxIfFocused tbxJpPublicOr;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        public MySelectAllTextBoxIfFocused tbxJpMethodName;
        public MySelectAllTextBoxIfFocused tbxJpReturnType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.ListView listJpArgsInfo;
        private System.Windows.Forms.ColumnHeader args;
        public MyFloatingTextBox tbxJpLineOfListBox;
        public System.Windows.Forms.ListView listArgsInfo;
        private System.Windows.Forms.ColumnHeader enArgs;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageEnglish;
        private System.Windows.Forms.TabPage tabPageJapanese;
        public System.Windows.Forms.ListBox listJpReflectionList;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbExportMethod;
        private System.Windows.Forms.Button btnJPSave;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Label lblJpStatus;
        private System.Windows.Forms.Label lblPrefix;
        private MyCombo cmbPrefix;
    }
}

