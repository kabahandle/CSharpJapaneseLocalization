namespace Ｃシャープ日本語化リフレクション
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbReflectTarget = new Ｃシャープ日本語化リフレクション.MyCombo();
            this.btnGetReflection = new System.Windows.Forms.Button();
            this.richReflectionInfo = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Windows.Forms.";
            // 
            // cmbReflectTarget
            // 
            this.cmbReflectTarget.FormattingEnabled = true;
            this.cmbReflectTarget.Location = new System.Drawing.Point(104, 11);
            this.cmbReflectTarget.Name = "cmbReflectTarget";
            this.cmbReflectTarget.Size = new System.Drawing.Size(383, 20);
            this.cmbReflectTarget.TabIndex = 1;
            // 
            // btnGetReflection
            // 
            this.btnGetReflection.Location = new System.Drawing.Point(24, 47);
            this.btnGetReflection.Name = "btnGetReflection";
            this.btnGetReflection.Size = new System.Drawing.Size(116, 23);
            this.btnGetReflection.TabIndex = 2;
            this.btnGetReflection.Text = "リフレクションを取得";
            this.btnGetReflection.UseVisualStyleBackColor = true;
            this.btnGetReflection.Click += new System.EventHandler(this.btnGetReflection_Click);
            // 
            // richReflectionInfo
            // 
            this.richReflectionInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richReflectionInfo.Location = new System.Drawing.Point(0, 0);
            this.richReflectionInfo.Name = "richReflectionInfo";
            this.richReflectionInfo.Size = new System.Drawing.Size(638, 244);
            this.richReflectionInfo.TabIndex = 3;
            this.richReflectionInfo.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbReflectTarget);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnGetReflection);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(638, 83);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.richReflectionInfo);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 83);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(638, 244);
            this.panel2.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 327);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private MyCombo cmbReflectTarget;
        private System.Windows.Forms.Button btnGetReflection;
        private System.Windows.Forms.RichTextBox richReflectionInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}

