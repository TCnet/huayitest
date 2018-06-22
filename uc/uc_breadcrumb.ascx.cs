using System;
using System.Web;
using System.Web.UI;

namespace HuaYimo.uc
{

    public partial class uc_breadcrumb : System.Web.UI.UserControl
    {

		protected string _title = "";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

    }
}
