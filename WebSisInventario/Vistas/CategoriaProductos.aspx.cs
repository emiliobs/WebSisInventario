using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using System.Data;

namespace WebSisInventario.Vistas
{
    public partial class CategoriaProductos : System.Web.UI.Page
    {

        ConnSisInventario db1 = new ConnSisInventario();
        ConnSisInventario db2 = new ConnSisInventario();
        ConnSisInventario db3 = new ConnSisInventario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["usuario"].ToString()))
            {
                Response.Redirect("Login.aspx");
            }

            var campos = "Codigo, Producto, Precio, Categoria";

            GridView1.DataSource = db1.Consultar2(campos, "Productos");
            GridView1.DataBind();

            this.DropDownList.DataSource = db2.Consultar2("*", "Categorias");
            this.DropDownList.DataTextField = "Categoria";
            this.DropDownList.DataBind();


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

        //Método para insertar:7
        private void GuardarDatos()
        {
            string sql1, sql2;

            //Consicion que evlua si el RadioButton esta seleccionado:
            if (this.RadioButtonProducto.Checked)
            {
                int codigo = Convert.ToInt32(txtCodigo.Text);

                ////Condicion que verifica que no exista el productos en la bd:
                var resultado = db3.Consultar3("Codigo", "Productos", "Codigo", codigo);

                if (resultado)
                {
                    this.txtCodigo.Focus();
                    LabelMensaje.Text = "La ID " + codigo + "del Producto ya Existe.....";
                }
                else
                {
                    //Script para insertar los daots a la tabla que esta en la bd:
                    sql1 = "Insert Into Productos(Productos.Codigo,Productos.Producto,Productos.Precio,Productos.Categoria)"
                           + "values ('" + txtCodigo.Text + "', '" + txtProducto.Text + "', '" + txtPrecio.Text + "', '" + DropDownList.Text + "')";

                    //Evalúa la funcion insertar:
                    if (db1.Insertar(sql1))
                    {

                        int productoId = 0;
                        //Recorre los datos que estan en la tabla productos:
                        foreach (DataRow row in db2.Consultar2("*", "Productos").Rows)
                        {
                            productoId = Convert.ToInt32(row[0]);

                        }
                        //script para insertar los datos a la tabla que esta en la  base de datos:
                        sql2 = "Insert Into Bodega(Bodega.Codigo, Bodega.Actual, Bodega.Importe, Bodega.IdProducto)" +
                               "Values ('" + txtCodigo.Text + "', '" + 0 + "', '" + 0 + "', '" + productoId + "')";

                        //Evalúa la funcion insertar:
                        if (db2.Insertar(sql2))
                        {
                            Response.Redirect("CategoriaProductos.aspx");
                        }
                    }

                }

            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            this.GuardarDatos();
        }
    }
}