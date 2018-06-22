using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuaYimo.Controls;
using TCSolutions.TCweb.BusinessLogic.Content.AdvInfo;
using TCSolutions.TCweb.Common.Utils;

namespace HuaYimo.admin
{

	public partial class advInfo_manage : BaseTCwebAdministrationPage
    {
		protected void Page_Load(object sender, EventArgs e)
        {
            //if (!LJH.Rank.IsModuleRank(1407))
           // {
            //    Response.Write("<div style='width:100%;margin-top:200px;text-align:center;color:red;'>您没有本模块的操作权限！ 请与管理员联系！</div>");
           //    Response.End();
           // }

            if (!IsPostBack)
            {
                if (Request["del"] != null)
                {
					AdvInfoService.DeleteAdvInfo(int.Parse(Request["del"]));
                    string backurl = BackPage(pds(), Request["reUrl"].Replace("|", "&"), "advInfo_manage.aspx?page=" + (pds().CurrentPageIndex - 1).ToString() + getcanshu());
                    Response.Redirect(backurl);
                    //Response.Redirect(Request["reUrl"].Replace("|", "&"));
                }
                else if (Request["id"] != null && Request["flag"] != null)
                {
					AdvInfoService.SetFlag(Request["flag"].ToString()=="1"?true:false,int.Parse(Request["id"]));
                   
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
					AdvInfoService.DeleteAdvInfo(int.Parse(a[i]));

                }

            }
            string backurl = BackPage(pds(), Request.Url.ToString(), "advInfo_manage.aspx?page=" + (pds().CurrentPageIndex - 1).ToString() + getcanshu());
            Response.Redirect(backurl);

        }


        protected string FlagNews(string id, bool a)
        {
            if (!a)
				return "<a href=advInfo_manage.aspx?flag=1&id=" + id + "&page=" + (Request["page"] == null ? "0" : Request["page"]) + "><font color=red>取消审核</font></a>";
            else
				return "<a href=advInfo_manage.aspx?flag=0&id=" + id + "&page=" + (Request["page"] == null ? "0" : Request["page"]) + ">审核通过</a>";
        }

        protected void btSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("advInfo_manage.aspx?key=" + tbKey.Text.Trim());
        }




        protected PagedDataSource pds()
        {
            string sql = "";

            if (Request["key"] != null)
            {

                sql = " and title like '%" + Request["key"] + "%' ";
                
                tbKey.Text = Request["key"];
            }
			string sql2=string.Format("where 1=1 {0} order by addtime desc",sql);

          
            //Response.Write(sql);
            //Response.End();
            PagedDataSource pds = new PagedDataSource();
			pds.DataSource = AdvInfoService.GetTable(sql2);
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
                GetPage(pds(), lbpagetotal, lbpagenow, lbnumber, lbnumbertotal, lbGid, lpfirst, lpprev, lpnext, lplast, getcanshu(), "advInfo_manage.aspx", "black_link");
            }
        }

        public string getcanshu()
        {
            string v = "";

            if (Request["key"] != null)
            {
                v += "&key=" + Request["key"];
            }

            return v;

        }

    }
}
