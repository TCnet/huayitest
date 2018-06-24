using System;
using System.Web;
using System.Web.UI;
using HuaYimo.Controls;
using TCSolutions.TCweb.BusinessLogic;
using System.Collections.Generic;
using TCSolutions.TCweb.BusinessLogic.Content.News;

namespace HuaYimo.uc
{

	public partial class uc_menu : BaseTCwebUserControl
    {
		protected string _cssType = "0";
        protected string _subCssType = "0";
		protected List<NewsType> dptype;
		protected List<NewsType> dctype;

        protected void Page_Load(object sender, EventArgs e)
        {
			dptype = NewsTypeService.GetChildTypeByParentIdDefault(0);

            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["type"]))
                {
                    int ptype = int.Parse(Request["type"]);
					int pid =NewsTypeService.GetPid(int.Parse(Request["type"]));
                    if (pid == 0)
                    {
                        ptype = int.Parse(Request["type"]);
                    }
                    else
                    {

                        ptype = pid;

                    }
                    _cssType = ptype.ToString();

                }

            }

        }



        public string CssType
        {
            get { return _cssType; }
            set { _cssType = value; }
        }

        public string SubCssType
        {
            get { return _subCssType; }
            set { _subCssType = value; }
        }
    }
}
