using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Ｃシャープ日本語化リフレクション
{
    public class MyCombo :ComboBox
    {
        private readonly string fileName = "classes.txt";

        public string SaveFilename { get; set; }

        public MyCombo()
            : base()
        {
            this.SaveFilename = this.fileName;
        }

        public void Save()
        {
            FileStream fs = null;
            StreamWriter w = null;

            try
            {
                fs = File.Open(Application.StartupPath + @"\" + this.SaveFilename, FileMode.OpenOrCreate | FileMode.Truncate);
            }
            catch (Exception excp)
            {
                fs = File.Open(Application.StartupPath + @"\" + this.SaveFilename, FileMode.OpenOrCreate);
            }

            try
            {
                w = new StreamWriter(fs, Encoding.Default);
                foreach (string file in this.Items)
                {
                    w.WriteLine(file);
                    w.Flush();
                }

                //fs.Close();
            }
            catch (Exception excp)
            {
            }
            finally
            {
                if (w != null)
                {
                    w.Close();
                }
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        public void Load()
        {
            FileStream fs  = null;
            StreamReader r  = null;

            this.Items.Clear();
            try
            {
                fs = File.Open(Application.StartupPath + @"\" + this.SaveFilename, FileMode.OpenOrCreate);
                r = new StreamReader(fs, Encoding.Default);

                string line = "";
                while ((line = r.ReadLine()) != null)
                {
                    this.Items.Add(line);
                }

                //fs.Close();
            }
            catch (Exception excp)
            {
            }
            finally
            {
                if (r != null)
                {
                    r.Close();
                }
                if (fs != null)
                {
                    fs.Close();
                }
            }
        }

        /*
        protected override void OnKeyDown(KeyEventArgs e)
        {  
            if (e.KeyCode == Keys.Enter)
            {
                this.Items.Add(this.Text);
                e.Handled = true;
                return;
            }
            base.OnKeyDown(e);
        }
         */

        protected override void OnLostFocus(EventArgs e)
        {
            if (!this.Items.Contains(this.Text) && !string.IsNullOrEmpty(this.Text.Trim()))
            {
                this.Items.Add(this.Text);
            }
            base.OnLostFocus(e);
        }

    }
}
