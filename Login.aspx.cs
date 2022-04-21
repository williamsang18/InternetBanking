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
        protected void Page_Load(object sender, EventArgs e)
        {
            
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
            Usuario user = new Usuario(Login1.UserName, Login1.Password);

            //UserId, SessionToken
            string resultado = Utils.makeRequest("/v1/login", JsonSerializer.Serialize(user));
            dynamic data = JsonSerializer.Deserialize<dynamic>(resultado);
            if (data.StatusCode = 200) 
            {
                Session["UserId"] = data.UserId;
                Session["SessionToken"] = data.SessionToken;
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, true);
            }
        }
    }
}