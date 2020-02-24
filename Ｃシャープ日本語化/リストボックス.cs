using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ｃシャープ日本語化
{
    public class リストボックス : ListBox
    {
        public リストボックス()
            : base()
        {
        }

        public void sub()
        {
            this.FindString("AA");
            //this.
        }

        // ↓この属性は、DLLの外側（使用側）からは見えなくなる。自分自身のフォームからはまだ見える
        //    参考URL：http://devlights.hatenablog.com/entry/20080418/p1
        //　　　　　　http://acha-ya.cocolog-nifty.com/blog/2010/09/post-de60.html
        // 　これを使えば、sealed→サブクラス　の手順を踏むまでもない。
        // [Browsable(false)]                              // プロパティウィンドウ非表示
        // [EditorBrowsable(EditorBrowsableState.Never)]   // インテリセンス非表示
        [Browsable(false)] 
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool AllowDrop
        {
            get
            {
                return base.AllowDrop;
            }
            set
            {
                base.AllowDrop = value;
            }
        }

        /// <summary>
        /// aaa
        /// </summary>
        /// <remarks>
        /// bbb
        /// </remarks>
        /// <example>
        /// <code>
        /// ccc
        /// </code>
        /// </example>
        public virtual bool ドロップ許可 { set; get; }
    }
}
