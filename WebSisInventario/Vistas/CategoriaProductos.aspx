<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="CategoriaProductos.aspx.cs" Inherits="WebSisInventario.Vistas.CategoriaProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <section id="contenedor">
        <section id="listaMenu">

            <nav id="menu">
               <ul>
                   <li><a href="Inventario.aspx" id="enlace">Inventario.</a></li>
                   <li><a href="CategoriaProductos.aspx" id="enlace">Categoria Productos.</a></li>
                   <li><a href="CompraProductos.aspx"id="enlace">Compra Productos.</a></li>
                   <li><a href="VentaProducto.aspx"id="enlace">Venta Producto.</a></li>
                   <li><a href="ComprasRealizadas.aspx" id="enlace">Compras Realizadas.</a></li>
                   <li><a href="VentaRealizada.aspx" id="enlace">Ventas Realizada.</a></li>
                   <li><a href="Bodega.aspx" id="enlace">Bodega.</a></li>
                   <li><a href="ClienteProveedor.aspx" id="enlace">Cliente Proveedor.</a></li>
               </ul>
            </nav>

        </section>
        <section id="contenido">
            <form runat="server" id="form1">
                <div class="formularios">
                    <asp:PlaceHolder runat="server" ID="placeHolderProducto">
                        <asp:TextBox runat="server"  ID="txtProductos" Visible="false"/>
                        <asp:Label Text="Ingrese Productos." ID="lblIngreseProducto" Font-Bold="true" runat="server" />
                        <br />
                        <br />

                        <asp:Label ID="lblCodigo" Text="Código:" runat="server" />
                        <br />
                        <asp:TextBox runat="server" ID="txtCodigo" CssClass="campoTexto" onkeypress="return soloNumeros(event);"/>
                        <br />
                        <asp:Label ID="lblProducto" Text="Producto:" runat="server" />
                          <br />
                         <asp:TextBox runat="server" ID="txtProducto" CssClass="campoTexto" onkeypress="return soloLetras(event);" />
                        <br />
                        <asp:Label ID="lblPrecio" Text="Precio:" runat="server" />
                           <br />
                        <asp:TextBox runat="server" ID="txtPrecio" CssClass="campoTexto"  onkeypress="return  soloNumerosDecimal(event);" />
                        <br />
                        <asp:Label ID="lblCategorias" Text="Categoria:" runat="server" />
                           <br />
                        <br />
                        <asp:DropDownList runat="server" ID="DropDownList" CssClass="campoTexto" Height="27px">

                       </asp:DropDownList>
                        <br />

                    </asp:PlaceHolder>
                    <asp:PlaceHolder runat="server" ID="placeHolderCategoria">
                        <asp:TextBox runat="server"  ID="txtIdCAtegoria" Visible="false"/>
                        <asp:Label Text="Ingrese Categoria." ID="lblVenta" Font-Bold="true" runat="server" />
                        <br />
                        <br />
                        <asp:Label Text="Categoria:" runat="server" ID="lblCategoria" />
                        <br />
                        <asp:TextBox runat="server"  id="txtCategoria" CssClass="campoTexto"  onkeypress="return soloLetras(event);"/>
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                    </asp:PlaceHolder>
                    <asp:Button Text="Guardar." ID="btnGuardar" BorderStyle="None" CssClass="button" runat="server" OnClick="btnGuardar_Click" />
                     <asp:Button Text="Actualizar." ID="btnActualizar" BorderStyle="None" CssClass="button" runat="server" />
                     <asp:Button Text="Cancelar." ID="btnCancelar" BorderStyle="None" CssClass="button" runat="server" OnClick="btnCancelar_Click" />
                    <br />
                    <br />
                </div>

                <div class="formularios">
                    <br />
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" BorderStyle="Solid" BorderWidth="0px" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="5">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:CommandField ButtonType="Image" EditImageUrl="~/Images/Sign_up_Icon_256.png" HeaderText="Editar" ShowEditButton="True" />
                            <asp:CommandField ButtonType="Image" DeleteImageUrl="~/Images/Eliminar_Icon.png" HeaderText="Eliminar" ShowDeleteButton="True" />
                        </Columns>
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerSettings Mode="NumericFirstLast" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#E9E7E2" />
                        <SortedAscendingHeaderStyle BackColor="#506C8C" />
                        <SortedDescendingCellStyle BackColor="#FFFDF8" />
                        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                    </asp:GridView>
                    <br />
                    <asp:Image ImageUrl="~/Images/Vista_Elements_Icons.png" ID="image1" Width="39px"   height="34px" runat="server"/>
                    <asp:TextBox ID="txtBuscar" runat="server" AutoCompleteType="Search" AutoPostBack="True" CssClass="campoTexto" Width="101px"></asp:TextBox>
                    <asp:RadioButton ID="RadioButtonProducto" runat="server" Checked="True" GroupName="Tipo" Text="Producto" />
                    <asp:RadioButton ID="RadioButtonCategoria" runat="server" GroupName="Tipo" Text="Categoría" />
                    <asp:Button ID="ButtonTipo" runat="server" BorderStyle="None" CssClass="button" Text="Tipo." OnClick="ButtonTipo_Click" />
                    <asp:Label ID="LabelMensaje" runat="server" ForeColor="#FF3300"></asp:Label>
                </div>
            </form>
        </section>
    </section>
</asp:Content>
