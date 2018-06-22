using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TCSolutions.TCweb.BusinessLogic.Content.Admin;
using HuaYimo.Controls;
using TCSolutions.TCweb.Common.Utils;

namespace HuaYimo.admin
{

	public partial class role_rank : BaseTCwebAdministrationPage
    {
		protected void Page_Load(object sender, EventArgs e)
        {
            //if (!LJH.Rank.IsModuleRank(1503))
           // {
            //    Response.Write("<div style='width:100%;margin-top:200px;text-align:center;color:red;'>您没有本模块的操作权限！ 请与管理员联系！</div>");
           //     Response.End();
           // }
            if (!IsPostBack)
            {
                getdata();
            }

        }

        public void getdata()
        {


			this.lbmodule1.Text = ModuleService.GetName(1);
			this.lbmodule2.Text = ModuleService.GetName(2);
			this.lbmodule3.Text = ModuleService.GetName(3);
			this.lbmodule4.Text = ModuleService.GetName(4);
			this.lbmodule5.Text = ModuleService.GetName(5);
			this.lbmodule6.Text = ModuleService.GetName(6);
			this.lbmodule7.Text = ModuleService.GetName(7);
			this.lbmodule8.Text = ModuleService.GetName(8);
			this.lbmodule9.Text = ModuleService.GetName(9);
			this.lbmodule10.Text = ModuleService.GetName(10);
			this.lbmodule11.Text = ModuleService.GetName(11);


            cbldata(cblmodule11, 11);
            cbldata(cblmodule10, 10);
            cbldata(cblmodule9, 9);


            cbldata(cblmodule8, 8);
            cbldata(cblmodule7, 7);
            cbldata(cblmodule6, 6);
            cbldata(cblmodule5, 5);
            cbldata(cblmodule4, 4);
            cbldata(cblmodule3, 3);
            cbldata(cblmodule2, 2);
            cbldata(cblmodule1, 1);

            if (Request["roleid"] != null)
            {
				this.lbrolename.Text = RoleService.GetRoleById(int.Parse(Request["roleid"])).rolename;
                this.hdback.Value = Request.UrlReferrer.ToString();
				var dt =RankService.GetRank(int.Parse(Request["roleid"]));
                for (int i = 0; i < dt.Count; i++)
                {
					string moduleId = dt[i].moduleid.ToString();

                    getcheck(cblmodule11, moduleId);
                    getcheck(cblmodule10, moduleId);
                    getcheck(cblmodule9, moduleId);

                    getcheck(cblmodule8, moduleId);
                    getcheck(cblmodule7, moduleId);
                    getcheck(cblmodule6, moduleId);
                    getcheck(cblmodule5, moduleId);
                    getcheck(cblmodule4, moduleId);
                    getcheck(cblmodule3, moduleId);
                    getcheck(cblmodule2, moduleId);
                    getcheck(cblmodule1, moduleId);


                }

            }

        }

        protected void btSub_Click(object sender, EventArgs e)
        {
            if (Request["roleid"] != null)
            {
                int roleid = int.Parse(Request["roleid"]);


                checkRank(cblmodule11, roleid);
                checkRank(cblmodule10, roleid);
                checkRank(cblmodule9, roleid);

                checkRank(cblmodule8, roleid);
                checkRank(cblmodule7, roleid);
                checkRank(cblmodule6, roleid);
                checkRank(cblmodule5, roleid);
                checkRank(cblmodule4, roleid);
                checkRank(cblmodule3, roleid);
                checkRank(cblmodule2, roleid);
                checkRank(cblmodule1, roleid);
                ShowJs.ShowAndRedirect("设置成功！", hdback.Value, this.Page);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cbl"></param>
        /// <param name="id"></param>
        public void cbldata(CheckBoxList cbl, int id)
        {
			cbl.DataSource = ModuleService.GetChild(id);
            cbl.DataTextField = "modulename";
            cbl.DataValueField = "id";
            cbl.DataBind();

        }


        /// <summary>
        /// 设置权限表
        /// </summary>
        /// <param name="cbl"></param>
        /// <param name="roleid"></param>
        public void checkRank(CheckBoxList cbl, int roleid)
        {
            for (int i = 0; i < cbl.Items.Count; i++)
            {
                int v = int.Parse(cbl.Items[i].Value);

                if (cbl.Items[i].Selected)
                {

					RankService.AddRank(v, int.Parse(Request["roleid"]));

                }
                else
                {

					RankService.DeleteRank(v, roleid);
                }
            }

        }

        /// <summary>
        /// 获取权限表
        /// </summary>
        /// <param name="cbl"></param>
        /// <param name="moduleId"></param>
        public void getcheck(CheckBoxList cbl, string moduleId)
        {
            for (int i8 = 0; i8 < cbl.Items.Count; i8++)
            {
                if (moduleId == cbl.Items[i8].Value)
                {
                    cbl.Items[i8].Selected = true;
                }
            }

        }

    }
}
