using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSisInventario.Vistas
{
    public partial class CategoriaProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["usuario"].ToString()))
            {
                Response.Redirect("Login.aspx");
            }

            btnActualizar.Visible = false;
            btnGuardar.Visible = true;

            placeHolderProducto.Visible = true;
            placeHolderCategoria.Visible = false;

        }

        protected void ButtonTipo_Click(object sender, EventArgs e)
        {
            //Condición que evalua si el RadioButton esta selelcionado:
            if (RadioButtonProducto.Checked)
            {
                btnActualizar.Visible = false;
                btnGuardar.Visible = true;

                placeHolderProducto.Visible = true;
                placeHolderCategoria.Visible = false;

                txtBuscar.Text = string.Empty;
                txtCodigo.Text = string.Empty;
                txtPrecio.Text = string.Empty;
                txtProducto.Text = string.Empty;
                LabelMensaje.Text = string.Empty;

            }

            if (RadioButtonCategoria.Checked)
            {
                btnActualizar.Visible = false;
                btnGuardar.Visible = true;

                placeHolderProducto.Visible = false;
                placeHolderCategoria.Visible = true;

                txtBuscar.Text = string.Empty;


                txtCategoria.Text = string.Empty;
                LabelMensaje.Text = string.Empty;

            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("CategoriaProductos.aspx");
        }
    }
}