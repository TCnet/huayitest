using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TCSolutions.TCweb.BusinessLogic.Content.Admin;
using HuaYimo.Controls;
using TCSolutions.TCweb.Common.Utils;

namespace HuaYimo.admin
{

	public partial class admin_add : BaseTCwebAdministrationPage
    {
		protected void Page_Load(object sender, EventArgs e)
        {
            //if (!LJH.Rank.IsModuleRank(1501))
            //{
             //   Response.Write("<div style='width:100%;margin-top:200px;text-align:center;color:red;'>您没有本模块的操作权限！ 请与管理员联系！</div>");
            //    Response.End();
            //}
            if (Request["edit"] != null)
            {
                btEdit.Visible = true;
                Submit1.Visible = false;
                panEdit.Visible = false;
                panReset.Visible = true;
            }
            else
            {
                btEdit.Visible = false;
                Submit1.Visible = true;
                panReset.Visible = false;
            }

            if (!IsPostBack)
            {

               
				this.ddlrole.DataSource = RoleService.GetChild(0);
                this.ddlrole.DataTextField = "roleName";
                this.ddlrole.DataValueField = "id";
                this.ddlrole.DataBind();
                if (Request["edit"] != null)
                {
                    getdata();
                }

            }
        }

        public void getdata()
        {
			Admin ob = AdminService.GetAdminById(int.Parse(Request["edit"]));

           
			if (ob!=null)
            {
				tbName.Text = ob.username;
                tbName.Enabled = false;
				tbTruename.Text = ob.truename;
				rbFlag.SelectedValue = ob.flag==true?"1":"0";
				this.ddlrole.SelectedValue = ob.roleid.ToString();

            }
            

        }

        protected void Submit1_ServerClick(object sender, EventArgs e)
        {
            if (tbName.Text.Trim() != "" && tbPass.Text != "" && tbPass2.Text != "" && tbPass2.Text == tbPass.Text)
            {
                
				Admin ob = AdminService.GetAdminByUserName(tbName.Text.Trim());


				if (ob==null)
                {
					ob = new Admin();
					ob.username = tbName.Text.Trim();
                    ob.truename = tbTruename.Text;
                    ob.password = AdminService.encry(tbPass.Text.Trim());
                    ob.p_id = AdminService.Adminid;
                    ob.roleid = Convert.ToInt32(this.ddlrole.SelectedValue);
                    ob.flag = rbFlag.SelectedValue == "1" ? true : false;
                    ob.logincount = 0;
                    ob.addtime = DateTime.Now;
                    ob.lasttime = DateTime.Now;
                    ob.modi_date = DateTime.Now;
                    AdminService.InsertAdmin(ob);
                    ShowJs.ShowAndRedirect("添加成功！", "admin_manage.aspx", this.Page);
                }
                else
                {
                  
                    ShowJs.ShowAndBack("此用户名已经存在！", this.Page);
                }
            }
            else
            {
                ShowJs.ShowAndBack("您的输入有误！", this.Page);
            }
        }

        protected void btEdit_Click(object sender, EventArgs e)
        {
            if (Request["edit"] != null)
            {
				Admin ob = AdminService.GetAdminById(int.Parse(Request["edit"]));
				if (ob!=null)
                {
					ob.truename = tbTruename.Text;
					ob.flag= rbFlag.SelectedValue=="1"?true:false;
					ob.roleid = int.Parse(this.ddlrole.SelectedValue);
                    if (this.tbRestPass.Text.Trim() != "")
                    {
						ob.password = AdminService.encry(this.tbRestPass.Text.Trim());
                    }
					AdminService.UpdateAdmin(ob);
                }
                
                ShowJs.ShowAndRedirect("修改成功！", "admin_manage.aspx", this.Page);

            }


        }

    }
}
