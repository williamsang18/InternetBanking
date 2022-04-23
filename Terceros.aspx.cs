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
    public partial class Terceros : System.Web.UI.Page
    {
        //Log4Net
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string sesToken;
        int clId;
        protected void Page_Load(object sender, EventArgs e)
        {
            sesToken = Convert.ToString(Session["SessionToken"]);
            clId = (int)(Session["ClientId"]);

            if (IsPostBack == false)
            {

                ddlCuentasOrigen.Items.Insert(0, new ListItem("None", ""));
                ddlBeneficiarios.Items.Insert(0, new ListItem("None", ""));

                List<BankAccount> accounts = (List<BankAccount>)Session["Accounts"];

                for (var i = 0; i < accounts.Count; i++)
                {
                    ddlCuentasOrigen.Items.Insert(i + 1, new ListItem(Convert.ToString(accounts[i].AccountNumber), Convert.ToString(accounts[i].AccountNumber)));
                }
            }

            List<BankBeneficiary> benefs;

            try
            {
                BeneficiaryByClientRequest beneficiaries = new BeneficiaryByClientRequest(sesToken, clId);
                string resultado = Utils.makeRequest("/v1/getBeneficiarioByClient", JsonSerializer.Serialize(beneficiaries));
                benefs = JsonSerializer.Deserialize<List<BankBeneficiary>>(resultado);
            }
            catch (Exception pp)
            {
                benefs = new List<BankBeneficiary>();
            }

            for (var i = 0; i < benefs.Count; i++)
            {
                ddlBeneficiarios.Items.Insert(i + 1, new ListItem(Convert.ToString(benefs[i].Alias), Convert.ToString(benefs[i].AccountNumber)));
            }
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            btnProcesar.Enabled = false;
            btnConfirmar.Visible = true;
        }

        protected void ddlCuentasOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetButton();
        }

        protected void ddlBeneficiarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCuentasOrigen.SelectedItem.Text == "None")
            {
                btnConfirmar.Visible = false;
                //btnSeleccionar.Enabled = false;
            }
            else
            {
                btnSeleccionar.Enabled = true;
            }

        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            tBoxCuentaDestino.Text = ddlBeneficiarios.SelectedItem.Value;
        }

        protected void tBoxCuentaDestino_TextChanged(object sender, EventArgs e)
        {
            btnConfirmar.Visible = false;
        }

        protected void tBoxMonto_TextChanged(object sender, EventArgs e)
        {
            btnConfirmar.Visible = false;
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            Transaction transaction = new Transaction(0, int.Parse(ddlCuentasOrigen.SelectedItem.Value), int.Parse(tBoxCuentaDestino.Text), float.Parse(tBoxMonto.Text), DateTime.Now);
            TransactionRequest transactionRequest = new TransactionRequest(sesToken, transaction);
            string tran = Utils.makeRequest("/v1/insertTransaction", JsonSerializer.Serialize(transactionRequest));
            Transaction logg = JsonSerializer.Deserialize<Transaction>(tran);
            log.Info("Se ha generado transacción con ID: " + logg.TransactionId);

            ddlCuentasOrigen.SelectedIndex = 0;
            ddlBeneficiarios.SelectedIndex = 0;
            tBoxCuentaDestino.Text = "";
            tBoxMonto.Text = "";
            btnProcesar.Enabled = false;
            btnConfirmar.Visible = false;
        }

        private void SetButton()
        {
            btnConfirmar.Enabled = (tBoxCuentaDestino.Text != "") && (tBoxMonto.Text != "") && (ddlCuentasOrigen.SelectedItem.Text != "None");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
            log.Info("Cliente con ID: " + Session["ClientId"] + " ha cerrado sesión.");
        }
    }
}