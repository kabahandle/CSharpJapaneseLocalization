using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ｃシャープ日本語化リフレクション
{
    public class MySelectAllTextBoxIfFocused : TextBox
    {
        public MySelectAllTextBoxIfFocused() : base() { }

        private bool isClicked = false;

        protected override void OnLeave(EventArgs e)
        {
            this.isClicked = false;
            base.OnLeave(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            this.SelectAll();
 	        base.OnGotFocus(e);
        }

        protected override void OnClick(EventArgs e)
        {
            if (this.isClicked == false)
            {
                this.SelectAll();
                this.isClicked = true;
            }
            base.OnClick(e);
        }
    }
}
