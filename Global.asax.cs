using System.Web;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using TCSolutions.TCweb.BusinessLogic.Infrastructure;
using TCSolutions.TCweb.BusinessLogic.Configuration;
using TCSolutions.TCweb.BusinessLogic.Installation;
using TCSolutions.TCweb.BusinessLogic.Tasks;


namespace HuaYimo
{
    public class Global : HttpApplication
    {
		void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码

            TCwebConfig.Init();
            if (InstallerHelper.ConnectionStringIsSet())
            {
                IoC.InitializeWith();

                //initialize task manager
                //  TaskManager.Instance.Initialize(TCwebConfig.ScheduleTasks);
                //  TaskManager.Instance.Start();
            }
        }

        void Application_BeginRequest(object sender, EventArgs e)
        {
            TCwebConfig.Init();
            if (!InstallerHelper.ConnectionStringIsSet())
            {
                // InstallerHelper.RedirectToInstallationPage();
            }
        }

        void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            HttpContext ctx = app.Context; //获取本次Http请求的HttpContext对象  
            if (ctx.User != null)
            {
                if (ctx.Request.IsAuthenticated == true) //验证过的一般用户才能进行角色验证  
                {
                    System.Web.Security.FormsIdentity fi = (System.Web.Security.FormsIdentity)ctx.User.Identity;
                    System.Web.Security.FormsAuthenticationTicket ticket = fi.Ticket; //取得身份验证票  
                    string userData = ticket.UserData;//从UserData中恢复role信息
                    string[] roles = userData.Split(','); //将角色数据转成字符串数组,得到相关的角色信息  
                    ctx.User = new System.Security.Principal.GenericPrincipal(fi, roles); //这样当前用户就拥有角色信息了
                }
            }

        }

        void Application_End(object sender, EventArgs e)
        {
            //  在应用程序关闭时运行的代码
            //  在应用程序关闭时运行的代码
            IoC.Dispose();
            if (InstallerHelper.ConnectionStringIsSet())
            {
                TaskManager.Instance.Stop();
            }
        }

        void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码

        }

        void Session_Start(object sender, EventArgs e)
        {
            // 在新会话启动时运行的代码

        }

        void Session_End(object sender, EventArgs e)
        {
            // 在会话结束时运行的代码。 
            // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
            // 或 SQLServer，则不会引发该事件。

        }
    }
}
