using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InternetBanking
{
    public partial class OtroBanco : System.Web.UI.Page
    {
        //Log4Net
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
            log.Info("Cliente con ID: " + Session["ClientId"] + " ha cerrado sesión.");
        }
    }
}