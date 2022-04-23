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
    public partial class CuentaPropia : System.Web.UI.Page
    {
        //Log4Net
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string sesToken;
        protected void Page_Load(object sender, EventArgs e) { 
            sesToken = Convert.ToString(Session["SessionToken"]);
            if (IsPostBack == false)
            {
                sesToken = Convert.ToString(Session["SessionToken"]);

                ddlCuentaOrigen.Items.Insert(0, new ListItem("None", ""));
                ddlCuentaDestino.Items.Insert(0, new ListItem("None", ""));

                List<BankAccount> accounts = (List<BankAccount>)Session["Accounts"];

                for (var i = 0; i < accounts.Count; i++)
                {
                    ddlCuentaOrigen.Items.Insert(i + 1, new ListItem(Convert.ToString(accounts[i].AccountNumber), Convert.ToString(accounts[i].AccountNumber)));
                    ddlCuentaDestino.Items.Insert(i + 1, new ListItem(Convert.ToString(accounts[i].AccountNumber), Convert.ToString(accounts[i].AccountNumber)));
                }
            }
        }

        protected void ddlCuentaOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCuentaOrigen.SelectedItem.Text == "None")
            {
                btnConfirmar.Visible = false;
            }
        }

        protected void ddlCuentaDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCuentaDestino.SelectedItem.Text == "None")
            {
                btnConfirmar.Visible = false;
            }
        }

        protected void tBoxMonto_TextChanged(object sender, EventArgs e)
        {
            btnConfirmar.Visible = false;
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        {
            btnConfirmar.Visible = true;
            SetButton();
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            Transaction transaction = new Transaction(0, int.Parse(ddlCuentaOrigen.SelectedItem.Value), int.Parse(ddlCuentaDestino.SelectedItem.Value), float.Parse(tBoxMonto.Text), DateTime.Now);
            TransactionRequest transactionRequest = new TransactionRequest(sesToken, transaction);
            string tran = Utils.makeRequest("/v1/insertTransaction", JsonSerializer.Serialize(transactionRequest));
            Transaction logg = JsonSerializer.Deserialize<Transaction>(tran);
            log.Info("Se ha generado transacción con ID: " + logg.TransactionId);
            
            ddlCuentaOrigen.SelectedIndex = 0;
            ddlCuentaDestino.SelectedIndex = 0;
            tBoxMonto.Text = "";
            btnConfirmar.Visible = false;
        }

        private void SetButton()
        {
            btnConfirmar.Enabled = (tBoxMonto.Text != "") && (ddlCuentaOrigen.SelectedItem.Text != "None") && (ddlCuentaDestino.SelectedItem.Text != "None");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
            log.Info("Cliente con ID: " + Session["ClientId"] + " ha cerrado sesión.");
        }
    }
}