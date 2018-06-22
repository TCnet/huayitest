using System;
using System.Web;
using System.Web.UI;
using HuaYimo.Controls;
namespace HuaYimo
{
	public partial class news_view : BaseTCwebFrontendPage
    {
		//public string title = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getdata();
            }

        }



        public void getdata()
        {
            if (Request["id"] != null)
            {
				int type = NewsService.GetTypeId(int.Parse(Request["id"]));

				int pid = NewsTypeService.GetPid(type);
                if (pid == 0)
                {
                    //title = LJH.NewsType.GetTypeName(type);
                    this.uc_menu.CssType = type.ToString();

                }
                else
                {

                    this.uc_menu.CssType = pid.ToString();

                }
				//string title = NewsTypeService.GetTypeName(type);
				 this.uc_breadcrumb.Title = NewsTypeService.GetTypeName(type);
                // title =LJH.NewsType.GetTypeName(type);
				this.rpNews.DataSource = NewsService.GetNews(int.Parse(Request["id"]));
                this.rpNews.DataBind();

                

            }


        }
    }
}
