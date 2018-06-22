

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
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


using TCSolutions.TCweb.BusinessLogic.Configuration.Settings;

using TCSolutions.TCweb.Common.Utils;
using TCSolutions.TCweb.BusinessLogic.Infrastructure;

namespace HuaYimo.Controls
{
    public class BaseTCwebFrontendUserControl : BaseTCwebUserControl
    {
        protected void DisplayAlertMessage(string message)
        {
            if (String.IsNullOrEmpty(message))
                return;

            
            StringBuilder alertJsStart = new StringBuilder();
            alertJsStart.AppendLine("<script type=\"text/javascript\">");
            alertJsStart.AppendLine("$(document).ready(function() {");
            alertJsStart.AppendLine(string.Format("alert('{0}');", message.Trim()));
            alertJsStart.AppendLine("});");
            alertJsStart.AppendLine("</script>");
            string js = alertJsStart.ToString();
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "alertScriptKey", js);
        }
    }
}