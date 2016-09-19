<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebSisInventario.Vistas.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contenido" runat="server">
    <div class="content">
        <asp:Image ImageUrl="~/Images/banner-inventario2.png" ID="img" AlternateText="Imagen no disponible." ImageAlign="TextTop" runat="server" />
        <form id="form1" runat="server">
            <div id="form">
                <h3>Iniciar Sesion.</h3>
                <p>
                    <asp:Label Text="Usuario" ID="label1" runat="server" />

                </p>
                <asp:TextBox runat="server" id="txtUser" CssClass="campoTexto"/>
                <p>
                    <asp:Label Text="Contraseña" ID="lael2"  runat="server" />

                </p>
                <asp:TextBox runat="server" ID="txtContraseña" CssClass="campoTexto" TextMode="Password" />
                <br />
                <br />
                <asp:Button Text="Entrar." CssClass="btn btn-primary button" ID="btnEntrar" BorderStyle="None"  runat="server" OnClick="btnEntrar_Click" />
                <p>
                <asp:Label Text="" ID="lblMensaje" Font-Bold="true" ForeColor="#000" runat="server" />
                </p>
            </div>
        </form>
    </div>
</asp:Content>
