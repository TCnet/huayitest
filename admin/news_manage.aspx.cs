﻿using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TCSolutions.TCweb.BusinessLogic.Content.News;
using TCSolutions.TCweb.Common.Utils;
using HuaYimo.Controls;


namespace HuaYimo.admin
{

	public partial class news_manage : BaseTCwebAdministrationPage
    {
		public string title = "";
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                if (Request["del"] != null)
                {
					NewsService.SetDelete(int.Parse(Request["del"]), true);
                    //Response.Write(Request["reUrl"].Replace("|", "&"));
                    //Response.End();
                    string backurl = BackPage(pds(), Request["reUrl"].Replace("|", "&"), "news_manage.aspx?page=" + (pds().CurrentPageIndex - 1).ToString() + getcanshu());

                    Response.Redirect(backurl);
                    //Response.Redirect(Request["reUrl"].Replace("|", "&"));
                }
                else if (Request["id"] != null && Request["comm"] != null)
                {
					NewsService.SetComm(int.Parse(Request["id"]), Request["comm"]=="1"?true:false);
                    Response.Redirect(Request.UrlReferrer.ToString());
                }
                else if (Request["id"] != null && Request["flag"] != null)
                {
					NewsService.SetFlag(int.Parse(Request["id"]), Request["flag"]=="1"?true:false);
                    Response.Redirect(Request.UrlReferrer.ToString());
                }
                else if (Request["id"] != null && Request["istop"] != null)
                {
					NewsService.SetTop(int.Parse(Request["id"]), Request["istop"]=="1"?true:false);
					Response.Redirect(Request.UrlReferrer.ToString());
                }
                else
                {
					title = NewsTypeService.GetTypeName(int.Parse(Request["type"]));
                }

				ddlType.DataSource = NewsTypeService.GetChildTypeByParentId(int.Parse(Request["type"]));
                ddlType.DataTextField = "typename";
                ddlType.DataValueField = "id";
                ddlType.DataBind();


                //int nid = 12;
                //for (int i = 0; i < nt.DefaultView.Count;i++ )
                //{
                //    if (nt.DefaultView[i]["id"].ToString() == "86")
                //    {
                //        nid = i;
                //    }
                //}
                //if(Request["type"]=="4")
                //{ nt.Rows.RemoveAt(nid); }
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
					NewsService.SetDelete(int.Parse(a[i]), true);

                }

            }
            string backurl = BackPage(pds(), Request.Url.ToString(), "news_manage.aspx?page=" + (pds().CurrentPageIndex - 1).ToString() + getcanshu());
            Response.Redirect(backurl);
            // Response.Redirect(Request.Url.ToString());
        }
		protected string CommNews(string id, bool a)
        {
			if (a == false)
                return "<a href=news_manage.aspx?comm=1&id=" + id + "&type=" + Request["type"] + "&page=" + (Request["page"] == null ? "0" : Request["page"]) + ">首页flash显示</a>";
            else
                return "<a href=news_manage.aspx?comm=0&id=" + id + "&type=" + Request["type"] + "&page=" + (Request["page"] == null ? "0" : Request["page"]) + "><font color=red>取消显示</font></a>";
        }

		protected string TopNews(string id, bool a)
        {
			if (a == false)
                return "<a href=news_manage.aspx?istop=1&id=" + id + "&type=" + Request["type"] + "&page=" + (Request["page"] == null ? "0" : Request["page"]) + ">置顶</a>";
            else
                return "<a href=news_manage.aspx?istop=0&id=" + id + "&type=" + Request["type"] + "&page=" + (Request["page"] == null ? "0" : Request["page"]) + "><font color=red>取消置顶</font></a>";
        }

		protected string FlagNews(string id, bool a)
        {
			if (a==false)
                return "<a href=news_manage.aspx?flag=1&id=" + id + "&type=" + Request["type"] + "&page=" + (Request["page"] == null ? "0" : Request["page"]) + ">审核通过</a>";
            else
                return "<a href=news_manage.aspx?flag=0&id=" + id + "&type=" + Request["type"] + "&page=" + (Request["page"] == null ? "0" : Request["page"]) + "><font color=red>取消审核</font></a>";
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("news_manage.aspx?type=" + Request["type"] + "&key=" + tbKey.Text.Trim() + "&t=" + this.ddlType.SelectedValue);
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

			string sql2 = "select a.* from \"tNews\" as a left join \"tNewsType\" as b on a.type=b.id  where a.isdelete=false and b.p_id=" + int.Parse(Request["type"]) + sql + " order by a.istop desc, a.addtime desc";
            //Response.Write(sql2);
            //Response.End();
            PagedDataSource pdsd = new PagedDataSource();
			pdsd.DataSource = NewsService.GetTable(sql2);
			pdsd.AllowPaging = true;//允许分页
			pdsd.PageSize = 20;//分页数
			pdsd.CurrentPageIndex = Convert.ToInt32(Request.QueryString["page"]);//当前页CurrentPageIndex,通过获得传来的参数page来设置
			return pdsd;

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
                GetPage(pds(), lbpagetotal, lbpagenow, lbnumber, lbnumbertotal, lbGid, lpfirst, lpprev, lpnext, lplast, getcanshu(), "news_manage.aspx", "black_link");
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

        protected void btFalg1_Click(object sender, EventArgs e)
        {
            if (Request["sel"] != null)
            {
                string[] a = Request["sel"].Split(',');

                for (int i = 0; i < a.Length; i++)
                {
					NewsService.SetFlag(int.Parse(a[i]),true);
                }

            }

            Response.Redirect(Request.Url.ToString());
        }

        protected void bgFlag0_Click(object sender, EventArgs e)
        {
            if (Request["sel"] != null)
            {
                string[] a = Request["sel"].Split(',');

                for (int i = 0; i < a.Length; i++)
                {
					NewsService.SetFlag(int.Parse(a[i]), false);
                }

            }
            Response.Redirect(Request.Url.ToString());
        }
    }
}
