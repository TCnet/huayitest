using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HuaYimo.Controls;
using TCSolutions.TCweb.BusinessLogic.Content.News;
using TCSolutions.TCweb.Common.Utils;

namespace HuaYimo.admin
{

	public partial class news_type : BaseTCwebAdministrationPage
    {
		protected void Page_Load(object sender, EventArgs e)
        {
            //if (!LJH.Rank.IsModuleRank(1401))
           // {
            //    Response.Write("<div style='width:100%;margin-top:200px;text-align:center;color:red;'>您没有本模块的操作权限！ 请与管理员联系！</div>");
           //     Response.End();
           // }
            if (Request["edit"] != null)
            {
                sbEdit.Visible = true;
                Submit1.Visible = false;
                btBack.Visible = true;
            }
            else
            {
                sbEdit.Visible = false;
                Submit1.Visible = true;
                btBack.Visible = false;
            }
            if (Request["del"] != null)
            {

                
				NewsTypeService.DeleteNewsType(int.Parse(Request["del"]));
                Response.Redirect(Request["reUrl"].Replace("|", "&"));
            }
            if (!IsPostBack)
            {

                if (Request["edit"] != null)
                {
                    hdUrl.Value = Request.UrlReferrer.ToString();
					NewsType n = NewsTypeService.GetNewsTypeById(int.Parse(Request["edit"]));
                    
					if (n!=null)
                    {
						tbTitle.Text = n.typename;
						rbIssimple.SelectedValue = n.issimple.ToString();
						tbSord.Text = n.sort.ToString();
						if (n.p_id== 0)
                        {
                            trIssimple.Visible = false;
                            hlBack.Text = "顶级分类";
                        }
                        else
                        {
                            trIssimple.Visible = true;
							hlBack.NavigateUrl = "news_type.aspx?id=" + n.p_id.ToString();
							hlBack.Text = NewsTypeService.GetTypeName(n.p_id);
                        }

                    }
                    
                }
                else if (Request["id"] != null)
                {
                    trIssimple.Visible = true;

					NewsType n = NewsTypeService.GetNewsTypeById(int.Parse(Request["id"]));
                    
                   
					if (n!=null)
                    {
						hlBack.Text = n.typename;
						if (n.p_id != 0)
                        {
							hlBack.NavigateUrl = "news_type.aspx?id=" + n.p_id.ToString();
                        }
                        else
                        {
                            hlBack.NavigateUrl = "news_type.aspx";
                        }
                    }
                }

                else
                {
                    trIssimple.Visible = false;
                    hlBack.Text = "顶级分类";
                }

                if (Request["isdefault"] != null && Request["eid"] != null)
                {
					bool isdefault = Request["isdefault"] == "0" ? false : true;
					NewsTypeService.SetIsDefault(isdefault,int.Parse(Request["isdefault"]));
                   
                    Response.Redirect(Request.UrlReferrer.ToString());
                }
            }
            Bind();

        }

        protected string FlagNews(string id, string a)
        {

            if (a == "1")
                return "<a href=news_type.aspx?isdefault=0&eid=" + id + getcanshu() + "><font color=red>取消显示</font></a> |";
            else
                return "<a href=news_type.aspx?isdefault=1&eid=" + id + getcanshu() + ">首页显示</a> |";

        }

        protected void Submit1_ServerClick(object sender, EventArgs e)
        {
			NewsType ob = new NewsType();
			ob.typename = tbTitle.Text.Trim();
			ob.p_id = Request["id"] != null ? int.Parse(Request["id"]) : 0;
			ob.issimple = int.Parse(rbIssimple.SelectedValue);
			ob.sort = int.Parse(tbSord.Text);

			NewsTypeService.InsertNewsType(ob);
            ShowJs.ShowAndRedirect("添加成功！", Request.Url.ToString(), this.Page);
        }
        protected void sbEdit_ServerClick(object sender, EventArgs e)
        {
			NewsType ob = NewsTypeService.GetNewsTypeById(int.Parse(Request["edit"]));

            
			if (ob!=null)
            {
				ob.typename = tbTitle.Text.Trim();
				ob.issimple = int.Parse(rbIssimple.SelectedValue);
                ob.sort = int.Parse(tbSord.Text);
				NewsTypeService.UpdateNewsType(ob);

            }
           ShowJs.ShowAndRedirect("修改成功！", hdUrl.Value, this.Page);
        }

        void Bind()
        {
			this.rpNewsDefault.DataSource = NewsTypeService.GetDefault(5);
            this.rpNewsDefault.DataBind();
            if (Request["edit"] == null)
            {
                int id = 0;
                if (Request["id"] != null)
                    id = int.Parse(Request["id"]);
				gvMain.DataSource = NewsTypeService.GetChildTypeByParentId(id);
                gvMain.DataBind();
            }
        }

        protected void btDel_Click(object sender, EventArgs e)
        {
            if (Request["sel"] != null)
            {
                string[] a = Request["sel"].Split(',');

                for (int i = 0; i < a.Length; i++)
                {
					
					NewsTypeService.DeleteNewsType(int.Parse(a[i]));
                    
                }

            }
            Response.Redirect(Request.Url.ToString());
        }

        protected void gvMain_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMain.PageIndex = e.NewPageIndex;
            Bind();
        }

        public string getcanshu()
        {
            string s = "";
            if (Request["id"] != null)
            {
                s += "&id=" + Request["id"];
            }
            return s;
        }

        public string getlisttype(int id)
        {
			string s =NewsTypeService.GetNewsTypeById(id).issimple.ToString();
            switch (s)
            {
                case "0": return "列表页";
                case "1": return "内容页";
                case "2": return "图片页";
                default: return "未知";
            }

        }
    }
}
