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
    public partial class Prestamo : System.Web.UI.Page
    {
        //Log4Net
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string sesToken;
        int clId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                ddlPrestamo.Items.Insert(0, new ListItem("None", ""));
                ddlCuentaOrigen.Items.Insert(0, new ListItem("None", ""));

                sesToken = Convert.ToString(Session["SessionToken"]);
                clId = (int)(Session["ClientId"]);

                List<BankAccount> accounts = (List<BankAccount>)Session["Accounts"];

                for (var i = 0; i < accounts.Count; i++)
                {
                    ddlCuentaOrigen.Items.Insert(i + 1, new ListItem(Convert.ToString(accounts[i].AccountNumber), Convert.ToString(accounts[i].AccountNumber)));
                }

                List<BankLoan> prestamos;
                try
                {
                    LoansByClientRequest loansByClient = new LoansByClientRequest(sesToken, clId);
                    string resultado = Utils.makeRequest("/v1/getLoansByClient", JsonSerializer.Serialize(loansByClient));
                    prestamos = JsonSerializer.Deserialize<List<BankLoan>>(resultado);
                }
                catch (Exception pp)
                {
                    prestamos = new List<BankLoan>();
                }

                for (var i = 0; i < prestamos.Count; i++)
                {
                    ddlPrestamo.Items.Insert(i + 1, new ListItem(Convert.ToString(prestamos[i].TotalLoanAmount - prestamos[i].TotalPaidAmount), Convert.ToString(prestamos[i].LoanId)));
                }
            }
        }

        protected void ddlPrestamo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCuentaOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void tBoxMonto_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            PayLoanRequest payLoan = new PayLoanRequest(sesToken, int.Parse(ddlPrestamo.SelectedItem.Value), int.Parse(ddlCuentaOrigen.SelectedItem.Value), float.Parse(tBoxMonto.Text));
            string pago = Utils.makeRequest("/v1/payLoan", JsonSerializer.Serialize(payLoan));
            BankLoan logg = JsonSerializer.Deserialize<BankLoan>(pago);
            log.Info("Se ha generado un pago al préstamo con ID: " + logg.LoanId);

            ddlCuentaOrigen.SelectedIndex = 0;
            ddlPrestamo.SelectedIndex = 0;
            tBoxMonto.Text = "";
            btnProcesar.Enabled = false;
            btnConfirmar.Visible = false;

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
            log.Info("Cliente con ID: " + Session["ClientId"] + " ha cerrado sesión.");

        }

        private void SetButton()
        {
            btnConfirmar.Enabled = (tBoxMonto.Text != "") && (tBoxMonto.Text != "") && (ddlPrestamo.SelectedItem.Text != "None") && (ddlCuentaOrigen.SelectedItem.Text != "None");
        }

        protected void btnProcesar_Click(object sender, EventArgs e)
        { 
            SetButton();
            btnConfirmar.Visible = true;
            
        }
    }
}