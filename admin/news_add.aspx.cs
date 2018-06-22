using System;
using System.Web;
using System.Web.UI;
using HuaYimo.Controls;
using System.Web.UI.WebControls;
using TCSolutions.TCweb.BusinessLogic.Content.News;
using System.IO;
using System.Configuration;
using TCSolutions.TCweb.Common.Utils;

namespace HuaYimo.admin
{

	public partial class news_add : BaseTCwebAdministrationPage
    {
		string path1 = "";
        string path2 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
			lbTitle.Text = NewsTypeService.GetTypeName(int.Parse(Request["type"]));
			path1 = MapPath(App_ImgPath);
			path2 = MapPath(App_FilePath);
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
            if (!IsPostBack)
            {
                //if(Request["type"]=="63")
                //{
                //    this.tbfile.Visible = true;
                //}

				this.ddlptype.DataSource = NewsTypeService.GetChildTypeByParentId(0);
                this.ddlptype.DataTextField = "typename";
                this.ddlptype.DataValueField = "id";
                this.ddlptype.DataBind();

               // this.ddlptype.Items.Remove(this.ddlptype.Items.FindByValue("10"));

                this.ddlptype.SelectedValue = Request["type"];





				ddlType.DataSource = NewsTypeService.GetChildTypeByParentId(int.Parse(this.ddlptype.SelectedValue));
                ddlType.DataTextField = "typename";
                ddlType.DataValueField = "id";
                ddlType.DataBind();


                //ddlType.Items.Insert(0, new ListItem("请选择分类", "0"));
                tbTime.Text = DateTime.Now.ToString();
                if (Request["edit"] != null)
                {
                    hdUrl.Value = Request.UrlReferrer.ToString();
					News ob = NewsService.GetNewsById(int.Parse(Request["edit"]));

					if (ob!=null)
                    {

						tbTitle.Text = ob.title;
						tbTitle2.Text = ob.title2;
						tbSource.Text = ob.source;
						ddlType.SelectedValue = ob.type.ToString();
                        
                        //ftbContent.Value = n["content"].ToString();
						txtFull.Text = ob.content;
						rbComm.SelectedValue = ob.flag==true?"1":"0";
						tbTime.Text = ob.addtime.ToString("yyyy-MM-dd");
						tbAuthor.Text =ob.author;
						tbfile.Text = ob.upfile;
						this.tburl.Text = ob.url;
						this.rbisdiredict.SelectedValue = ob.isdiredict==true?"1":"0";
						if (!string.IsNullOrEmpty(ob.img))
                        {
                            Image1.Visible = true;
                            //Image1.ImageUrl = n["img"].ToString();
							Image1.ImageUrl = "" + ob.img;
                            btDelImg.Visible = true;
                        }
						if (!string.IsNullOrEmpty(ob.upfile))
                        {
                            btDelFile.Visible = true;
                        }
                    }
                    
                }
            }
        }
        protected void Submit1_ServerClick(object sender, EventArgs e)
        {

            if (!System.IO.File.Exists(path1))
            {
                System.IO.Directory.CreateDirectory(path1);
            }
			if (!System.IO.File.Exists(path2))
            {
                System.IO.Directory.CreateDirectory(path2);
            }
            try
            {
				News ob = new News();
				ob.title = tbTitle.Text.Trim();
                
				ob.type = Convert.ToInt32(ddlType.SelectedValue) ;
				ob.content = txtFull.Text;
				ob.flag = rbComm.SelectedValue == "1" ? true : false;
               
				ob.author = tbAuthor.Text;
				ob.title2 = this.tbTitle2.Text;
				ob.isdiredict = this.rbisdiredict.SelectedValue == "1" ? true : false;
                
				ob.url = this.tburl.Text.Trim();
                if (this.upFile.HasFile)
                {

					ob.img =App_ImgPath+ UpFile(upFile, path1);
                }
                if (this.upFile1.HasFile)
                {
					ob.upfile =App_FilePath+ UpFile(upFile1, path2);
                }

                if (this.tbfile.Text.Trim() != "" && this.tbfile.Visible == true)
                {
					ob.upfile = this.tbfile.Text.Trim();
                }

				ob.addtime = Convert.ToDateTime(this.tbTime.Text);
				ob.adduser = AdminService.Adminid;
				ob.source = tbSource.Text;
				ob.istop = false;
				ob.isdelete = false;
				ob.hits = 0;
				ob.comm = false;
				ob.publish_new = true;
				NewsService.InsertNews(ob);
                

                string script = "<script>if(confirm('是否继续添加?')){location='" + Request.Url.ToString() + "';}else{location='news_manage.aspx?type=" + Request["type"] + "';}</script>";
                Response.Write(script);
                Response.End();
            }
            catch (Exception)
            {
                ShowJs.ShowAndBack("添加失败！", this.Page);

            }

        }
        protected void sbEdit_ServerClick(object sender, EventArgs e)
        {

            if (!System.IO.File.Exists(path1))
            {
                System.IO.Directory.CreateDirectory(path1);
            }
            try
            {
               
				News ob = NewsService.GetNewsById(int.Parse(Request["edit"]));
				if (ob!=null)
                {
					ob.title = tbTitle.Text.Trim();

                    ob.type = Convert.ToInt32(ddlType.SelectedValue);
                    ob.content = txtFull.Text;
                    ob.flag = rbComm.SelectedValue == "1" ? true : false;

                    ob.author = tbAuthor.Text;
                    ob.title2 = this.tbTitle2.Text;
                    ob.isdiredict = this.rbisdiredict.SelectedValue == "1" ? true : false;

                    ob.url = this.tburl.Text.Trim();
                    if (upFile.HasFile)
                    {
						if (!string.IsNullOrEmpty(ob.img))
                        {
							if (File.Exists(path1 + ob.img))
								File.Delete(path1 + ob.img);
                        }
						ob.img =App_ImgPath+ UpFile(upFile, path1);
                    }
                    if (upFile1.HasFile)
                    {
						if (!string.IsNullOrEmpty(ob.upfile))
							File.Delete(path2 + ob.upfile);
						ob.upfile =App_FilePath+ UpFile(upFile1, path2);
                    }
                    if (this.tbfile.Text.Trim() != "" && this.tbfile.Visible == true)
                    {
						ob.upfile = this.tbfile.Text.Trim();
                    }
					ob.source = tbSource.Text;
					ob.adduser = AdminService.Adminid;
					NewsService.UpdateNews(ob);
                }
              
               ShowJs.ShowAndRedirect("修改成功！", hdUrl.Value, this.Page);

            }
            catch (Exception)
            {
               ShowJs.ShowAndBack("修改失败！", this.Page);

            }

        }

        protected void btDelImg_Click(object sender, EventArgs e)
        {
			News ob = NewsService.GetNewsById(int.Parse(Request["edit"]));
			if (ob!=null)
            {
				if (File.Exists(path1 + ob.img))
					File.Delete(path1 + ob.img);
				ob.img = "";
				NewsService.UpdateNews(ob);
            }
          
            Response.Redirect(Request.Url.ToString());
        }

        protected void btDelFile_Click(object sender, EventArgs e)
        {
			News ob = NewsService.GetNewsById(int.Parse(Request["edit"]));
			if (ob != null)
            {
				if (File.Exists(path2 + ob.upfile))
					File.Delete(path2 +ob.upfile);
				ob.upfile= "";
				NewsService.UpdateNews(ob);
            }
          
            Response.Redirect(Request.Url.ToString());
        }

        protected void ddlptype_SelectedIndexChanged(object sender, EventArgs e)
        {
			ddlType.DataSource = NewsTypeService.GetChildTypeByParentId(int.Parse(this.ddlptype.SelectedValue));
            ddlType.DataTextField = "typename";
            ddlType.DataValueField = "id";
            ddlType.DataBind();
        }

    }
}
