using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InternetBanking
{
    public partial class Login : System.Web.UI.Page
    {
        //Log4Net
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {
            log.Info("Pagina cargada...");
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            /*string user, password;
            user = Login1.UserName;
            password = Login1.Password;
            
            if (user == user1.username & password == user1.password)
            {
                Session["user"] = user1;
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, true);
            }
            */
            LoginRequest user = new LoginRequest(Login1.UserName, Login1.Password);

            //UserId, SessionToken
            string resultado = Utils.makeRequest("/v1/login", JsonSerializer.Serialize(user));
            ClientSession data = JsonSerializer.Deserialize<ClientSession>(resultado);
            if(data.UserId != 0) 
            {

                Session["UserID"] = data.UserId;
                Session["SessionToken"] = data.SessionToken;
                Session["ClientID"] = data.ClientId;
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, true);
            }
        }
    }
}