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
    public partial class RegistrarBeneficiario : System.Web.UI.Page
    {
        //Log4Net
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void tBoxNumeroCuenta_TextChanged(object sender, EventArgs e)
        {
            btnConfirmar.Visible = false;
            SetButton();
        }

        protected void tBoxAlias_TextChanged(object sender, EventArgs e)
        {
            btnConfirmar.Visible = false;
            SetButton();
        }

        private void SetButton()
        {
            btnRegistrar.Enabled = (tBoxNumeroCuenta.Text != "") && (tBoxAlias.Text != "");
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            btnRegistrar.Enabled = false;
            btnConfirmar.Visible = true;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            BankBeneficiary bene = new BankBeneficiary((int)Session["ClientID"], int.Parse(tBoxNumeroCuenta.Text), tBoxAlias.Text, DateTime.Now); ;
            BeneficiaryCreationRequest beneficiary = new BeneficiaryCreationRequest(Convert.ToString(Session["SessionToken"]), bene);
            string tran = Utils.makeRequest("/v1/addBeneficiario", JsonSerializer.Serialize(beneficiary));
            BankBeneficiary logg = JsonSerializer.Deserialize<BankBeneficiary>(tran);
            log.Info("Se ha registrado el beneficiario con ID: " + logg.Id);

            tBoxNumeroCuenta.Text = "";
            tBoxAlias.Text = "";
            btnConfirmar.Visible = false;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
            log.Info("Cliente con ID: " + Session["ClientId"] + " ha cerrado sesión.");
        }
    }
}