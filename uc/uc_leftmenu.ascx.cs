using System;
using System.Web;
using System.Web.UI;
using HuaYimo.Controls;

namespace HuaYimo.uc
{

	public partial class uc_leftmenu : BaseTCwebUserControl
    {
		protected int _ptype = 1;
        protected int _ctype;
        protected string _url = "";
        public string title = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getdata();
                if (!string.IsNullOrEmpty(Request["type"]))
                {
                    _ctype = Convert.ToInt32(Request["type"]);
                }
            }

        }
        public void getdata()
        {
            string type = "";
            if (Request["type"] != null)
            {
                type = Request["type"];
            }
            else if (Request["id"] != null)
            {
                type = NewsService.GetTypeId(int.Parse(Request["id"])).ToString();
            }
            if (type != "")
            {
                int ptype = int.Parse(type);
                int pid = NewsTypeService.GetPid(int.Parse(type));
                if (pid == 0)
                {
                    title = NewsTypeService.GetTypeName(int.Parse(type));
                    _ptype = int.Parse(type);
                }
                else
                {
					title = NewsTypeService.GetTypeName(pid);
                    ptype = pid;
                    _ptype = pid;

                }
				this.rpMenu.DataSource = NewsTypeService.GetChildTypeByParentId(ptype);
                this.rpMenu.DataBind();
                _ctype = Convert.ToInt32(type);
            }
            else
            {
				title = NewsTypeService.GetTypeName(1);
				this.rpMenu.DataSource = NewsTypeService.GetChildTypeByParentId(1);
                this.rpMenu.DataBind();

            }

        }

        public string geturl(string type)
        {
			

			string t = NewsTypeService.GetNewsTypeById(int.Parse(type)).issimple.ToString();
            switch (t)
            {
                case "0":
                case "1": return "news_list.aspx?type=" + type;
                case "2": return "news_pic.aspx?type=" + type;

                default: return "news_list.aspx?type=" + type;

            }
        }


        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        public int Ptype
        {
            get { return _ptype; }
            set { _ptype = value; }
        }

        public int Ctype
        {
            get { return _ctype; }
            set { _ctype = value; }
        }
    }
}
