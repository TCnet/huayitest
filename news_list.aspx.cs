


using HuaYimo.Controls;
using TCSolutions.TCweb.Common.Utils;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TCSolutions.TCweb.BusinessLogic.SEO;

namespace HuaYimo
{
	public partial class news_list : BaseTCwebFrontendPage
    {

		public string title = "";
        public bool issimple;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Request["type"] == "9")
                //{
                //    Response.Redirect("message.aspx?type=91");
                //}
                getdata();
				BindTitle();


            }

        }

		public void BindTitle()
        {
            //title, meta
            //string mtitle = string.Empty;
            //if (!string.IsNullOrEmpty(info.MetaTitle))
           //     title = info.MetaTitle;
           // else
			//	mtitle = info.Title;
            SEOHelper.RenderTitle(this, title, true);
          //  SEOHelper.RenderMetaTag(this, "description", info.MetaDescription, true);
          //  SEOHelper.RenderMetaTag(this, "keywords", info.MetaKeywords, true);

        }

        public void getdata()
        {
            int type = gettype();
			title = NewsTypeService.GetTypeName(type);
            this.uc_breadcrumb.Title = title;
			string s =NewsTypeService.GetNewsTypeById(type).issimple.ToString();

            if (s == "0")
            {
                issimple = false;



                this.rpNewslist.DataSource = pds();
                this.rpNewslist.DataBind();
            }
            else if (s == "1")
            {
                issimple = true;

				this.rpsimple.DataSource = NewsService.GetSimpleNews(type);
                this.rpsimple.DataBind();

            }
            else
            {
                Response.Redirect("news_pic.aspx?type=" + type);
            }

        }



        protected void rpNewslist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Footer)
            {
                Label lbpagetotal = (Label)e.Item.FindControl("lbpagetotal");

                Label lbpagenow = (Label)e.Item.FindControl("lbpagenow");

                Label lbnumber = (Label)e.Item.FindControl("lbnumber");
                Label lbnumbertotal = (Label)e.Item.FindControl("lbnumbertotal");
                Label lbGid = (Label)e.Item.FindControl("lbGid");
                HyperLink lpfirst = (HyperLink)e.Item.FindControl("lpfirst");
                HyperLink lpprev = (HyperLink)e.Item.FindControl("lpprev");
                HyperLink lpnext = (HyperLink)e.Item.FindControl("lpnext");
                HyperLink lplast = (HyperLink)e.Item.FindControl("lplast");

                Label lbGid2 = (Label)e.Item.FindControl("lbGid2");
                HyperLink lpfirst2 = (HyperLink)e.Item.FindControl("lpfirst2");
                HyperLink lpprev2 = (HyperLink)e.Item.FindControl("lpprev2");
                HyperLink lpnext2 = (HyperLink)e.Item.FindControl("lpnext2");
                HyperLink lplast2 = (HyperLink)e.Item.FindControl("lplast2");
                GetPage(pds(), lbpagetotal, lbpagenow, lbnumber, lbnumbertotal, lbGid, lpfirst, lpprev, lpnext, lplast, getcanshu(), "news_list.aspx", "black_link");

                lbGid2.Text = lbGid.Text;
                lpfirst2.NavigateUrl = lpfirst.NavigateUrl;
                lpnext2.NavigateUrl = lpnext.NavigateUrl;
                lplast2.NavigateUrl = lplast.NavigateUrl;
                lpprev2.NavigateUrl = lpprev.NavigateUrl;
            }
        }
        protected PagedDataSource pds()
        {
            int type = gettype();
            string sql2 = "select * from \"tNews\"  where IsDelete=false and flag=true and type=" + type + " order by istop desc, addtime desc";
           // string sql = string.Format("select * from vNews where type={0} and flag=1 order by addtime desc", type);
            //Response.Write(sql);
            //Response.End();
            PagedDataSource pds = new PagedDataSource();
			pds.DataSource =NewsService.GetTable(sql2);
            pds.AllowPaging = true;//允许分页
            pds.PageSize = 20;//分页数
            pds.CurrentPageIndex = Convert.ToInt32(Request.QueryString["page"]);//当前页CurrentPageIndex,通过获得传来的参数page来设置
            return pds;

        }

        public string getcanshu()
        {
            string v = "";
            if (Request["type"] != null)
            {
                v += "&type=" + Request["type"];
            }
            return v;
        }

		public int gettype()
        {
            int type = 11;
            try
            {

                if (Request["type"] != null)
                {
                    int pid = NewsTypeService.GetPid(int.Parse(Request["type"]));
                    if (pid == 0)//是父类
                    {

                        type = NewsTypeService.GetTypeidByPid(int.Parse(Request["type"]));

                    }
                    else
                    {
                        type = int.Parse(Request["type"]);
                    }
                }

            }
            catch (Exception e)
            {
                Response.Redirect("page404.aspx?e=" + "error type");
            }

            return type;

        }


        public string geturl(string id, string title)
        {
			string s = "<a href='news_view.aspx?id=" + id + "' class=\"black_link\"   >" +CommonHelper.GetSubString(title,30,"...") + "</a>";

            return s;



        }
    }
}
