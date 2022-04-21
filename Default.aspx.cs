using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InternetBanking
{
    public partial class Home : System.Web.UI.Page
    {
        //Cuentas
        Cuenta c1 = new Cuenta();
        Cuenta c2 = new Cuenta();
        Cuenta c3 = new Cuenta();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Prueba de cuentas
            c1.Numero = "123456";
            c1.Balance = 60000;

            c2.Numero = "159753";
            c2.Balance = 805000;

            c3.Numero = "754158";
            c3.Balance = 704000;

            List<Cuenta> cuentas = new List<Cuenta>() {c1, c2, c3};
            //

            gvCuentas.DataSource = cuentas;
            gvCuentas.DataBind();

            Usuario user1 = (Usuario)Session["user"];
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