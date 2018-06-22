using System;
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

using TCSolutions.TCweb.Common.Utils;
using System.Collections.Generic;

namespace HuaYimo.Controls
{
    public partial class BaseTCwebAdministrationPage : BaseTCwebPage
    {

        #region Methods



       

        /// <summary>
        /// Validates page security for current user
        /// </summary>
        /// <returns>true if action is allow; otherwise false</returns>
        protected virtual bool ValidatePageSecurity()
        {
            return true;
        }

       

        protected override void OnLoad(EventArgs e)
        {
            CommonHelper.EnsureSsl();
            base.OnLoad(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            //java-script
            //string adminJs = CommonHelper.GetStoreLocation() + "Scripts/admin.js";
            //Page.ClientScript.RegisterClientScriptInclude(adminJs, adminJs);

            //base.OnPreRender(e);
        }

        protected void ProcessException(Exception exc)
        {
            ProcessException(exc, true);
        }

        protected void ProcessException(Exception exc, bool showError)
        {
            
        }

        protected void ShowMessage(string message)
        {
            MasterPage masterPage = this.Master;
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
            MasterPage masterPage = this.Master;
            if (masterPage == null)
                return;

            BaseTCwebAdministrationMasterPage nopAdministrationMasterPage = masterPage as BaseTCwebAdministrationMasterPage;
            if (nopAdministrationMasterPage != null)
                nopAdministrationMasterPage.ShowError(message, completeMessage);
        }

        #endregion


        #region Properties

        protected virtual bool AdministratorSecurityValidationEnabled
        {
            get
            {
                return true;
            }
        }

        protected virtual bool IPAddressValidationEnabled
        {
            get
            {
                return true;
            }
        }

        #endregion
    }
}