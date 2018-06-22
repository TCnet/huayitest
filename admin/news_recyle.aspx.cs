using System;
using System.Web;
using System.Web.UI;
using TCSolutions.TCweb.BusinessLogic.Content.News;
using TCSolutions.TCweb.Common.Utils;
using HuaYimo.Controls;
using System.Web.UI.WebControls;
using System.IO;


namespace HuaYimo.admin
{

	public partial class news_recyle : BaseTCwebAdministrationPage
    {
		public string title = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                if (Request["del"] != null)
                {
					News ob = NewsService.GetNewsById(int.Parse(Request["del"]));
                  
					if (ob!=null)
                    {
						if (File.Exists(MapPath(ob.img)))
                        {
							File.Delete(MapPath(ob.img));
                        }
						if (File.Exists(MapPath(ob.upfile)))
                        {
							File.Delete(MapPath(ob.upfile));
                        }
						NewsService.DeleteNews(ob);
                    }
                  

                    string backurl = BackPage(pds(), Request["reUrl"].Replace("|", "&"), "news_recyle.aspx?page=" + (pds().CurrentPageIndex - 1).ToString() + getcanshu());
                    Response.Redirect(backurl);

                }
                else if (Request["back"] != null && Request["back"] != "")
                {
					NewsService.SetDelete(int.Parse(Request["back"]), false);
                    Response.Redirect(Request.UrlReferrer.ToString());
                }
                else
                {
					title = NewsTypeService.GetTypeName(int.Parse(Request["type"])) + "回收";
                }

				ddlType.DataSource = NewsTypeService.GetChildTypeByParentId(int.Parse(Request["type"]));
                ddlType.DataTextField = "typename";
                ddlType.DataValueField = "id";
                ddlType.DataBind();

				this.rpNewsType.DataSource = NewsTypeService.GetChildTypeByParentId(int.Parse(Request["type"]));
                this.rpNewsType.DataBind();
                //ddlType.Items.Insert(0, new ListItem("请选择分类", "0"));
                rtNews.DataSource = pds();
                rtNews.DataBind();
            }
        }
        protected void btDel_Click(object sender, EventArgs e)
        {
            if (Request["sel"] != null)
            {
                string[] a = Request["sel"].Split(',');

                for (int i = 0; i < a.Length; i++)
                {
                   
					News ob = NewsService.GetNewsById(int.Parse(a[i]));
					if (ob!=null)
                    {
						if (File.Exists(MapPath(ob.img)))
                        {
                            File.Delete(MapPath(ob.img));
                        }
                        if (File.Exists(MapPath(ob.upfile)))
                        {
                            File.Delete(MapPath(ob.upfile));
                        }
                        NewsService.DeleteNews(ob);
                        
                    }
                   
                }

            }
            string backurl = BackPage(pds(), Request.Url.ToString(), "news_recyle.aspx?page=" + (pds().CurrentPageIndex - 1).ToString() + getcanshu());
            Response.Redirect(backurl);

        }


        protected void btSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("news_recyle.aspx?type=" + Request["type"] + "&key=" + tbKey.Text.Trim() + "&t=" + this.ddlType.SelectedValue);
        }

		protected string GetImg(object img)
        {
            string t = "";
            if (img != null)
            { t = img.ToString(); }

            if (t.Trim() == "")
                return "<font color=red>无首页图</font>";

            else
                return "<img src='" + "" + "" + t + "' width=100 height=80 >";
        }


        protected PagedDataSource pds()
        {
            string sql = "";

            if (Request["key"] != null)
            {
                sql = " and a.title like '%" + Request["key"] + "%' ";
                ddlType.SelectedValue = Request["type"];
                tbKey.Text = Request["key"];
            }
            if (Request["t"] != null && Request["t"] != "")
            {
                this.ddlType.SelectedValue = Request["t"];
                sql += " and a.type=" + int.Parse(Request["t"]);
            }

            string sql2 = "select a.* from \"tNews\" as a left join \"tNewsType\" as b on a.type=b.id  where a.isdelete=true and b.p_id=" + int.Parse(Request["type"]) + sql + " order by a.addtime desc";
            //Response.Write(sql);
            //Response.End();
            PagedDataSource pds = new PagedDataSource();
			pds.DataSource = NewsService.GetTable(sql2);
            pds.AllowPaging = true;//允许分页
            pds.PageSize = 20;//分页数
            pds.CurrentPageIndex = Convert.ToInt32(Request.QueryString["page"]);//当前页CurrentPageIndex,通过获得传来的参数page来设置
            return pds;

        }

        protected void rtNews_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
                GetPage(pds(), lbpagetotal, lbpagenow, lbnumber, lbnumbertotal, lbGid, lpfirst, lpprev, lpnext, lplast, getcanshu(), "news_recyle.aspx", "black_link");
            }
        }

        public string getcanshu()
        {
            string v = "";
            if (Request["type"] != null)
            {
                v += "&type=" + int.Parse(Request["type"]);
            }
            if (Request["key"] != null)
            {
                v += "&key=" + Request["key"];
            }
            if (Request["t"] != null && Request["t"] != "")
            {
                v += "&t=" + Request["t"];
            }
            return v;

        }



        protected void bgFlag_Click(object sender, EventArgs e)
        {
            if (Request["sel"] != null)
            {
                string[] a = Request["sel"].Split(',');

                for (int i = 0; i < a.Length; i++)
                {
					NewsService.SetDelete(int.Parse(a[i]), false);
                }

            }
            Response.Redirect(Request.Url.ToString());


        }

		protected string GetUpFile(object upfile)
        {
            string t = "";
            if (upfile != null)
            { t = upfile.ToString(); }

            if (t.Trim() == "")
                return "<font color=red>无附件</font>";
            else
                return "<a href='" + "" + "" + Eval("upfile").ToString() + "' style='color:green'>下载</a>";

        }

		protected string GetTypeName(object type)
        {
            int t = 0;
            if (type != null)
            { t = Convert.ToInt32(type); }
            return NewsTypeService.GetTypeName(t);

        }

        protected string GetUser(object adduser)
        {
            int t = 0;
            if (adduser != null)
            { t = Convert.ToInt32(adduser); }
            return AdminService.GetAdminById(t).username;

        }
		

    }
}
