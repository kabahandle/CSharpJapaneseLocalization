namespace テストフォーム
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
            this.リストボックス1 = new Ｃシャープ日本語化.リストボックス();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // リストボックス1
            // 
            this.リストボックス1.FormattingEnabled = true;
            this.リストボックス1.ItemHeight = 12;
            this.リストボックス1.Location = new System.Drawing.Point(108, 109);
            this.リストボックス1.Name = "リストボックス1";
            this.リストボックス1.Size = new System.Drawing.Size(120, 88);
            this.リストボックス1.TabIndex = 0;
            this.リストボックス1.ドロップ許可 = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(27, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.リストボックス1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Ｃシャープ日本語化.リストボックス リストボックス1;
        private System.Windows.Forms.Button button1;

    }
}

