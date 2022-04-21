using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InternetBanking
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblId.Text = Convert.ToString((int)Session["UserId"]);

            ClientInfoRequest cliente = new ClientInfoRequest(Convert.ToString(Session["SessionToken"]), int.Parse(Convert.ToString(Session["ClientId"])));
            string resultado = Utils.makeRequest("/v1/getclient", JsonSerializer.Serialize(cliente));
            BankClient data = JsonSerializer.Deserialize<BankClient>(resultado);

            lblNombre.Text = data.Name;
            lblCedula.Text = data.Cedula;
            lblSexo.Text = Convert.ToString(data.Sex);
            lblFechaRegistro.Text = Convert.ToString(data.RegisterDate);

            //List<Cuenta> cuentas = new List<Cuenta>() {c1, c2, c3};

            //gvCuentas.DataSource = cuentas;
            //gvCuentas.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Selecciona la cuenta del gridview
            Cuenta seleccionada = new Cuenta
            {
                Numero = gvCuentas.SelectedRow.Cells[1].Text,
                Balance = float.Parse(gvCuentas.SelectedRow.Cells[2].Text)
            };
            Session["cuenta"] = seleccionada;

            Response.Redirect("DetalleCuenta.aspx");
        }

        protected void gvCuentas_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Mostrar botón luego de que se seleccione una cuenta
            btnCuenta.Visible = true;
        }
    }
}