<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inventario.aspx.cs" Inherits="WebSisInventario.Vistas.Inventario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <section id="contenedor">
        <section id="listaMenu">
            <nav id="menu">
               <ul>
                   <li><a href="Inventario.aspx" id="enlace">Inventario.</a></li>
                   <li><a href="CAtegoriaProductos.aspx" id="enlace">Categoria Productos.</a></li>
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
            <center>
             <asp:image imageurl="~/Images/banner-inventario1.png"  id="img" runat="server" AlternateText="Imagen no Disponible." ImagenAling="TextTop"  />

            </center>
        </section>
    </section>
</asp:Content>
