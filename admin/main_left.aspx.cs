using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using HuaYimo.Controls;


namespace HuaYimo.admin
{

	public partial class main_left : BaseTCwebAdministrationPage
    {
		protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
				this.ltName.Text = AdminService.Adminname;
                getdata();
            }
        }

       
        public string getAu(int id)
        {
			return NewsService.GetAuNews(id, false).Count.ToString();
        }

        public void getdata()
        {
            //this.rpIntro.DataSource = LJH.Intro.GetTable("select * from tIntro");
            //this.rpIntro.DataBind();

            //this.ltNewsType1.Text =LJH.News.GetCount(1,0).ToString();

            //this.ltNewsType2.Text =LJH.News.GetCount(2, 0).ToString();
            //this.ltNewsType3.Text = LJH.Product.GetCount(0).ToString();

			this.rpMenu.DataSource =NewsTypeService.GetChildTypeByParentId(0);
            this.rpMenu.DataBind();

            //this.ltNewsType4.Text =LJH.News.GetCount(4, 0).ToString();
            //this.ltNewsType5.Text =LJH.News.GetCount(5, 0).ToString();
            //this.ltNewsType6.Text =LJH.News.GetCount(6, 0).ToString();
            //this.ltNewsType7.Text =LJH.News.GetCount(7, 0).ToString();

            //this.ltNewsType8.Text =LJH.News.GetCount(8, 0).ToString();


        }
        
    }
}
