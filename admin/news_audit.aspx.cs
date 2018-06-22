using System;
using System.Web;
using System.Web.UI;
using TCSolutions.TCweb.BusinessLogic.Content.News;
using TCSolutions.TCweb.Common.Utils;
using HuaYimo.Controls;
using System.Web.UI.WebControls;

namespace HuaYimo.admin
{

	public partial class news_audit : BaseTCwebAdministrationPage
    {
		public string title = "";
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                if (Request["del"] != null)
                {
					NewsService.SetDelete(int.Parse(Request["del"]), true);
                    string backurl = BackPage(pds(), Request["reUrl"].Replace("|", "&"), "news_audit.aspx?page=" + (pds().CurrentPageIndex - 1).ToString() + getcanshu());
                    Response.Redirect(backurl);

                }
                else if (Request["id"] != null && Request["flag"] != null)
                {
					NewsService.SetFlag(int.Parse(Request["id"]), Request["flag"].ToString()=="1"?true:false);
                    Response.Redirect(Request.UrlReferrer.ToString());
                }

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
					NewsService.SetDelete(int.Parse(a[i]), true);
				}
                
            }
            string backurl = BackPage(pds(), Request.Url.ToString(), "news_audit.aspx?page=" + (pds().CurrentPageIndex - 1).ToString() + getcanshu());
            Response.Redirect(backurl);

        }
		protected string CommNews(string id, bool a)
        {
			if (a == false)
                return "<a href=news_audit.aspx?flag=1&id=" + id + "&page=" + (Request["page"] == null ? "0" : Request["page"]) + "><font color=green>审核通过</font></a>";
            else
                return "<a href=news_audit.aspx?flag=0&id=" + id + "&page=" + (Request["page"] == null ? "0" : Request["page"]) + "><font color=red>撤销审核</font></a>";
        }

        protected void btAudit_Click(object sender, EventArgs e)
        {
            if (Request["sel"] != null)
            {
                string[] a = Request["sel"].Split(',');

                for (int i = 0; i < a.Length; i++)
                {
					NewsService.SetFlag(int.Parse(a[i]), true);
                }

            }
            Response.Redirect(Request.Url.ToString());
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
                GetPage(pds(), lbpagetotal, lbpagenow, lbnumber, lbnumbertotal, lbGid, lpfirst, lpprev, lpnext, lplast, getcanshu(), "news_audit.aspx", "black_link");
            }
        }

        protected PagedDataSource pds()
        {
           
            string sqlpar = " b.p_id=" + Request["type"];
			string sql2 = string.Format("select a.* from \"tNews\" as a left join \"tNewsType\" as b on a.type=b.id where a.flag=false and a.isdelete=false and {0} order by a.addtime desc",sqlpar);
            //string sql2 = "select * from vNews where " + sql + " and " + sqlpar + " order by addtime desc";

            //Response.Write(sql2);
            //Response.End();
            PagedDataSource pds = new PagedDataSource();
			pds.DataSource = NewsService.GetTable(sql2);

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


    }
}
