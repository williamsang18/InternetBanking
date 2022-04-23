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
    public partial class Home : System.Web.UI.Page
    {
        //Log4Net
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        string sesToken;
        int clId;
        protected void Page_Load(object sender, EventArgs e)
        {
            sesToken = Convert.ToString(Session["SessionToken"]);
            clId = (int)(Session["ClientId"]);

            gvCuentas.DataSource = null;
            gvCuentas.DataBind();

            gvMovimientos.DataSource = null;
            gvMovimientos.DataBind();

            //GetClient
            ClientInfoRequest cliente = new ClientInfoRequest(sesToken, clId);
            string resultado = Utils.makeRequest("/v1/getClient", JsonSerializer.Serialize(cliente));
            BankClient data = JsonSerializer.Deserialize<BankClient>(resultado);

            //Mostrar informacion general del cliente
            lblNombre.Text = data.Name;
            lblCedula.Text = data.Cedula;
            lblSexo.Text = Convert.ToString(data.Sex);
            lblFechaRegistro.Text = Convert.ToString(data.RegisterDate);

            //Obtener cuentas
            List<BankAccount> bankAccounts;
            try
            {
                AccountsByClientRequest cuentas = new AccountsByClientRequest(sesToken, clId);
                string accounts = Utils.makeRequest("/v1/getAccounts", JsonSerializer.Serialize(cuentas));
                bankAccounts = JsonSerializer.Deserialize<List<BankAccount>>(accounts);
                log.Info("Lista de cuentas generadas para el cliente con ID: " + clId);
                lblCedula.Text = Convert.ToString(bankAccounts.Count);
            }
            catch (Exception pp) 
            {
                bankAccounts = new List<BankAccount>();
            }
            

            Session["Accounts"] = bankAccounts;

            //Tabla de cuentas
            if (bankAccounts.Count > 0)
            {
                gvCuentas.DataSource = Session["Accounts"];
                gvCuentas.DataBind();
                //gvCuentas.Columns[2].Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Selecciona la cuenta del gridview
            int id = int.Parse(gvCuentas.SelectedRow.Cells[1].Text);
            TransactionsByAccountRequest movimientos = new TransactionsByAccountRequest(sesToken, id);
            string movements = Utils.makeRequest("/v1/getAccountTransactions", JsonSerializer.Serialize(movimientos));
            List<Transaction> movs = JsonSerializer.Deserialize<List<Transaction>>(movements);
            gvMovimientos.DataSource = movs;
            gvMovimientos.DataBind();
            log.Info("Se han generado los movimientos de la cuenta con ID: " + id);
        }

        protected void gvCuentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Mostrar botón luego de que se seleccione una cuenta
            btnMovimientos.Visible = true;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            //Logout
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
            log.Info("Cliente con ID: " + Session["ClientId"] + " ha cerrado sesión.");
        }
    }
}