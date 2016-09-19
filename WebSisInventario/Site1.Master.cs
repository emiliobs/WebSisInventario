using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSisInventario
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["usuario"].ToString()))
            {
                Cerrar.Visible = false;

            }
            else
            {
                Iniciar.Visible = false;


            }
        }
    }
}