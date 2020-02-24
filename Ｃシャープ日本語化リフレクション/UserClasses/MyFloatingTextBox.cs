using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ｃシャープ日本語化リフレクション
{
    public class MyFloatingTextBox : TextBox
    {
        public MyFloatingTextBox()
            : base()
        {
        }


        public ListView ParentListView { get; set; }

        protected override void OnLostFocus(EventArgs e)
        {
            this.Cancel();
            base.OnLostFocus(e);
        }

        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            this.WriteAndHide();
            base.OnMouseDoubleClick(e);
        }

        private void WriteAndHide()
        {
            if (this.ParentListView != null)
            {
                if (this.ParentListView.SelectedItems.Count > 0)
                {
                    ListViewItem item = this.ParentListView.SelectedItems[0];
                    item.Text = this.Text;
                    this.Visible = false;
                    this.Text = string.Empty;
                    this.ParentListView.Focus();
                }
            }
        }

        private void Cancel()
        {
            this.Text = string.Empty;
            this.Visible = false;
            this.ParentListView.Focus();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.WriteAndHide();
                e.Handled = true;
                return;
            }
            else if( e.KeyCode == Keys.Escape )
            {
                this.Cancel();
            }
            base.OnKeyDown(e);
        }
    }
}
