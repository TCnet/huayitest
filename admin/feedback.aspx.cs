using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuaYimo.Controls;
using TCSolutions.TCweb.BusinessLogic.Content.FeedBack;
using TCSolutions.TCweb.Common.Utils;

namespace HuaYimo.admin
{

	public partial class feedback : BaseTCwebAdministrationPage
    {
		protected void Page_Load(object sender, EventArgs e)
        {
			
            if (Request["type"] != null)
            {
                if (Request["type"] == "1")
                {
					if (!RankService.IsModuleRank(1001))
                    {
                        Response.Write("<div style='width:100%;margin-top:200px;text-align:center;color:red;'>您没有本模块的操作权限！ 请与管理员联系！</div>");
                        Response.End();
                    }
                }
                if (Request["type"] == "2")
                {
					if (!RankService.IsModuleRank(1002))
                    {
                        Response.Write("<div style='width:100%;margin-top:200px;text-align:center;color:red;'>您没有本模块的操作权限！ 请与管理员联系！</div>");
                        Response.End();
                    }
                }

            }
            else
            {
				if (!RankService.IsModuleRank(1001))
                {
                    Response.Write("<div style='width:100%;margin-top:200px;text-align:center;color:red;'>您没有本模块的操作权限！ 请与管理员联系！</div>");
                    Response.End();
                }

            }
            if (!IsPostBack)
            {
				this.ddltype.DataSource = FeedBackTypeService.GetAllFeedBackType();
                this.ddltype.DataTextField = "typename";
                this.ddltype.DataValueField = "id";
                this.ddltype.DataBind();
                this.ddltype.Items.Insert(0, new ListItem("全部", "all"));

                this.rtNews.DataSource = pds();
                this.rtNews.DataBind();
                if (Request["flag"] != null)
                {
                    

					FeedBackService.SetFlag(Request["flag"].ToString()=="1"?true:false,int.Parse(Request["id"]));

                  
                    Response.Redirect("feedback.aspx?page=" + Request["page"] + getcanshu());
                }
                else if (Request["del"] != null)
                {

                    string[] page = Request["page"].Split(',');
					FeedBackService.DeleteFeedBack(int.Parse(Request["del"]));
                   
                    Response.Redirect(Request["reUrl"].Replace("|", "&"));
                }
            }
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {

            Response.Redirect("feedback.aspx?key=" + tbKey.Text.Trim() + "&username=" + tbusername.Text.Trim() + "&time1=" + tbTime1.Text.Trim() + "&time2=" + tbTime2.Text + "&type=" + this.ddltype.SelectedValue + getcanshu2());
        }

        protected void btDel_Click(object sender, EventArgs e)
        {
            if (Request["sel"] != null)
            {
                string[] a = Request["sel"].Split(',');
                for (int i = 0; i < a.Length; i++)
                {
					FeedBackService.DeleteFeedBack(int.Parse(a[i]));
                  
                }
            }
            Response.Redirect(Request.UrlReferrer.ToString());
        }

		protected string CommNews(string id, bool a)
        {
            if (!a)
                return "<a href=feedback.aspx?flag=1&id=" + id + "&page=" + (Request["page"] == null ? "0" : Request["page"]) + getcanshu() + ">审核</a>";
            else
                return "<a href=feedback.aspx?flag=0&id=" + id + "&page=" + (Request["page"] == null ? "0" : Request["page"]) + getcanshu() + "><font color=red>撤消审核</font></a>";
        }



        protected PagedDataSource pds()
        {
            string sql = "";

            if (Request["key"] != null)
            {
                sql = " and title like '%" + Request["key"] + "%' ";

                tbKey.Text = Request["key"];
            }
            if (Request["username"] != null && Request["username"] != "")
            {
                sql += " and username='" + Request["username"] + "'";
                tbusername.Text = Request["username"];
            }

            if (Request["time1"] != null && Request["time1"] != "")
            {
                sql += " and addtime>='" + Request["time1"] + "'";
                tbTime1.Text = Request["time1"];
            }
            if (Request["time2"] != null && Request["time2"] != "")
            {
                sql += " and addtime<='" + Request["time2"] + "'";
                tbTime2.Text = Request["time2"];
            }
            if (Request["type"] != null && Request["type"] != "all")
            {
                sql += " and type=" + Request["type"] + "";
                this.ddltype.SelectedValue = Request["type"];
            }
            string sql3 = " order by addtime desc";
            if (Request["paixu"] != null)
            {
                sql3 = " order by " + Request["paixu"] + " " + Request["paixu2"];
                this.drPaixu.SelectedValue = Request["paixu"];
                this.drPaixu2.SelectedValue = Request["paixu2"];
            }
           // string sql2 = "select * from tFeedBack where 1=1 " + sql + sql3;
			string sql2 = string.Format("where 1=1 {0} {1}",sql, sql3);
            //Response.Write(sql);
            //Response.End();
            PagedDataSource pds = new PagedDataSource();
			pds.DataSource = FeedBackService.GetTable(sql2);
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
                GetPage(pds(), lbpagetotal, lbpagenow, lbnumber, lbnumbertotal, lbGid, lpfirst, lpprev, lpnext, lplast, getcanshu(), "feedback.aspx", "black_link");
            }
        }

        protected void btsetflag1_Click(object sender, EventArgs e)
        {
            if (Request["sel"] != null)
            {
                string[] a = Request["sel"].Split(',');
                for (int i = 0; i < a.Length; i++)
                {
					FeedBackService.SetFlag(true,int.Parse(a[i]));
                    
                }
            }
            Response.Redirect("feedback.aspx?page=" + (Request["page"] == null ? "0" : Request["page"]) + getcanshu());
        }

        protected void btsetflag2_Click(object sender, EventArgs e)
        {
            if (Request["sel"] != null)
            {
                string[] a = Request["sel"].Split(',');
                for (int i = 0; i < a.Length; i++)
                {
					FeedBackService.SetFlag(false, int.Parse(a[i]));
                   
                }
            }
            Response.Redirect("feedback.aspx?page=" + (Request["page"] == null ? "0" : Request["page"]) + getcanshu());
        }

        protected void btPaiXu_Click(object sender, EventArgs e)
        {
            Response.Redirect("feedback.aspx?paixu=" + drPaixu.SelectedValue + "&paixu2=" + drPaixu2.SelectedValue + getcanshu1());
        }

        public string getcanshu1()
        {
            string v = "";
            if (Request["key"] != null)
            {
                v += "&key=" + Request["key"];
            }
            if (Request["username"] != null)
            {
                v += "&username=" + Request["username"];
            }
            if (Request["time1"] != null)
            {
                v += "&time1=" + Request["time1"];
            }
            if (Request["time2"] != null)
            {
                v += "&time2=" + Request["time2"];
            }
            if (Request["type"] != null)
            {
                v += "&type=" + Request["type"];
            }
            return v;
        }

        public string getcanshu2()
        {
            string v = "";
            if (Request["paixu"] != null)
            {
                v += "&paixu=" + Request["paixu"];
            }
            if (Request["paixu2"] != null)
            {
                v += "&paixu2=" + Request["paixu2"];
            }

            return v;
        }

        public string getcanshu()
        {
            return getcanshu1() + getcanshu2();
        }

    }
}
