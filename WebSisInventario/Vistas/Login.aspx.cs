using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSisInventario.Vistas
{
    public partial class Login : System.Web.UI.Page
    {
        ConnSisInventario Connect = new ConnSisInventario();
        bool usuario;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text))
            {
                txtUser.Focus();
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtContraseña.Text))
                {
                    txtContraseña.Focus();
                }
                else
                {
                    usuario = Connect.Consultar1("Login","UserName",txtUser.Text,"Password",txtContraseña.Text);

                    if (usuario)
                    {

                        Session["usuario"] = usuario;
                        Response.Redirect("Inventario.aspx");
                    }
                    else
                    {
                        lblMensaje.Text = "Usuario o Contraseña Incorrectos.!!!";
                    }

                }
            }
        }
    }
}