using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InternetBanking
{
    public partial class Detalle : System.Web.UI.Page
    {
        //Prueba cuenta
        Cuenta c1 = new Cuenta();
        Cuenta c2 = new Cuenta();
        Cuenta c3 = new Cuenta();
        List<Cuenta> cuentas = new List<Cuenta>();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Prueba de cuentas
            c1.Numero = "123456";
            c1.Balance = 60000;

            c2.Numero = "159753";
            c2.Balance = 805000;

            c3.Numero = "754158";
            c3.Balance = 704000;

            cuentas.Add(c1);
            cuentas.Add(c2);
            cuentas.Add(c3);
            //
        }

        protected void btnMovimientos_Click(object sender, EventArgs e)
        {
            //Cargar Movimientos
            gvMovimientos.DataSource = cuentas;
            gvMovimientos.DataBind();

        }
    }
}