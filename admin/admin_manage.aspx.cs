using System;
using System.Web;
using System.Web.UI;
using HuaYimo.Controls;
using TCSolutions.TCweb.BusinessLogic.Content.Admin;
using TCSolutions.TCweb.Common.Utils;

                 

namespace HuaYimo.admin
{

	public partial class admin_manage : BaseTCwebAdministrationPage
    {
		protected void Page_Load(object sender, EventArgs e)
        {
           // if (!LJH.Rank.IsModuleRank(1501))
           // {
           //     Response.Write("<div style='width:100%;margin-top:200px;text-align:center;color:red;'>您没有本模块的操作权限！ 请与管理员联系！</div>");
           //     Response.End();
          //  }

            if (!IsPostBack)
            {
                if (Request["del"] != null)
                {
					int id = AdminService.GetAdminPid(int.Parse(Request["del"]));
                    if (id != 0)
                    {
						AdminService.DeleteByPid(int.Parse(Request["del"]));
						AdminService.DeleteAdmin(int.Parse(Request["del"]));
                       // LJH.Admin.ExecuteNonQuery("delete tAdmin where p_id=" + Request["del"]);
                       // LJH.Admin.ExecuteNonQuery("delete tAdmin where id=" + Request["del"]);
                       // LJH.Admin.ExecuteNonQuery("delete tLogin_log where admin_id=" + Request["del"]);
                        Response.Redirect("admin_manage.aspx");
                    }
                    else
                    {
                        ShowJs.ShowAndBack("超级管理员不能删除！", this.Page);
                    }
                }
                else if (Request["flag"] != null && Request["id"] != null)
                {
					AdminService.SetFlag(Request["flag"].ToString()=="1"?true:false,int.Parse(Request["id"]));
                    
                    Response.Redirect("admin_manage.aspx");
                }
                else
                {
                    
					rtAdmin.DataSource = AdminService.GetAdminByPid(AdminService.Adminid);
                    rtAdmin.DataBind();
                }
            }
        }

		protected string GetFlag(bool a, string b)
		{
            if (a)
            {
                return "<a href=admin_manage.aspx?flag=0&id=" + b + ">冻结</a>";
            }
            else
            {
                return "<a href=admin_manage.aspx?flag=1&id=" + b + "><font color=red>激活</font></a>";
            }
        }

        protected void btDel_Click(object sender, EventArgs e)
        {
            if (Request["sel"] != null)
            {
                string[] a = Request["sel"].Split(',');
                for (int i = 0; i < a.Length; i++)
                {
					int id = AdminService.GetAdminPid(int.Parse(a[i]));
					if (id != 0)
						AdminService.DeleteAdmin(int.Parse(a[i]));
                }
            }
            Response.Redirect("admin_manage.aspx");

        }

		public string GetRoleName(int id)
		{
			string s = "";
			try{
				s=RoleService.GetRoleById(id).rolename;
            
			}catch{}
			return s;
    

		}


    }
}
