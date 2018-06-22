using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using TCSolutions.TCweb.BusinessLogic;



namespace HuaYimo.Controls
{
    public partial class BaseTCwebAdministrationUserControl : BaseTCwebUserControl
    {

        protected void ProcessException(Exception exc)
        {
            ProcessException(exc, true);
        }

        protected void ProcessException(Exception exc, bool showError)
        {
           
        }

        protected void ShowMessage(string message)
        {
            if (this.Page == null)
                return;

            MasterPage masterPage = this.Page.Master;
            if (masterPage == null)
                return;

            BaseTCwebAdministrationMasterPage nopAdministrationMasterPage = masterPage as BaseTCwebAdministrationMasterPage;
            if (nopAdministrationMasterPage != null)
                nopAdministrationMasterPage.ShowMessage(message);
        }

        protected void ShowError(string message)
        {
            ShowError(message, string.Empty);
        }

        protected void ShowError(string message, string completeMessage)
        {
            if (this.Page == null)
                return;

            MasterPage masterPage = this.Page.Master;
            if (masterPage == null)
                return;

            BaseTCwebAdministrationMasterPage nopAdministrationMasterPage = masterPage as BaseTCwebAdministrationMasterPage;
            if (nopAdministrationMasterPage != null)
                nopAdministrationMasterPage.ShowError(message, completeMessage);
        }



    }
}