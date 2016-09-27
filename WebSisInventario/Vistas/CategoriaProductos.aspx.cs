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
        ConnSisInventario db4 = new ConnSisInventario();

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

                var campos = "Codigo, Producto, Precio, Categoria";
                this.GridView1.DataSource = db3.Consultar2(campos, "Productos");
                this.GridView1.DataBind();

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

                var campos = "Id,Categoria";
                this.GridView1.DataSource = db4.Consultar2(campos, "Categorias");
                this.GridView1.DataBind();

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
                var codigo = txtCodigo.Text.TrimStart();

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


            if (this.RadioButtonCategoria.Checked)
            {
                var categoria = txtCategoria.Text.Trim();
                //verifica si esxiste la categoria en la bd;
                var resultado = db1.Consultar3("Categoria","Categorias","Categoria", categoria);

                if (resultado)
                {
                    txtCategoria.Focus();
                    var campos = "Id, Categoria";

                    this.GridView1.DataSource = db4.Consultar2(campos, "Categorias");
                    this.GridView1.DataBind();
                    LabelMensaje.Text = "La Categoría " + categoria + "  Ya Existe..... ";
                }
                else
                {


                    //Query para insertar los datos a la tabla que esta en la BD:
                    var sql = "Insert Into Categorias(Categoria) Values ('"+categoria+"')";

                    //Evalua la funcio Insertar:
                    if (db3.Insertar(sql))
                    {
                        txtCategoria.Text = string.Empty;
                        btnActualizar.Visible = false;
                        btnGuardar.Visible = true;

                        this.GridView1.DataSource = db1.Consultar2("*","Categorias");
                        this.GridView1.DataBind();

                        LabelMensaje.Text = "";
                    }
                }


            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            if (this.RadioButtonProducto.Checked)
            {
                //this.placeHolderProducto.Visible = true;
                //this.placeHolderCategoria.Visible = false;


                //Evalúa los txtBox si estan vacíos;
                if (string.IsNullOrEmpty(txtCodigo.Text))
                {
                    txtCodigo.Focus();
                    LabelMensaje.Text = "Debe ingresar un Código.....";
                    return;
                }

                if (string.IsNullOrEmpty(txtProducto.Text))
                {
                    txtProducto.Focus();
                    LabelMensaje.Text = "Debe ingresar un Producto.....";
                    return;
                }

                if (string.IsNullOrEmpty(txtPrecio.Text))
                {
                    txtPrecio.Focus();
                    LabelMensaje.Text = "Debe ingresar un Precio.....";
                    return;
                }

                if (string.IsNullOrEmpty(DropDownList.Text))
                {
                    DropDownList.Focus();
                    return;
                }

                this.GuardarDatos();

            }

            if (this.RadioButtonCategoria.Checked)
            {

                this.placeHolderProducto.Visible = false;
                this.placeHolderCategoria.Visible = true;


                if (string.IsNullOrWhiteSpace(txtCategoria.Text))
                {
                    txtCategoria.Focus();
                    this.GridView1.DataSource = db1.Consultar2("*", "Categorias");
                    this.GridView1.DataBind();
                    LabelMensaje.Text = "Debe ingresar una Categoría.....";
                    return;
                }

                    this.GuardarDatos();
                //LabelMensaje.Text = string.Empty;



            }


        }
    }
}