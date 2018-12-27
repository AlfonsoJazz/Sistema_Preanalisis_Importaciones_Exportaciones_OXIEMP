<%@ Page Title="OXIMEXP | Generación de Reportes " Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="Reportes.aspx.vb" Inherits="Reportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
        text-align: right;
        width: 270px;
    }
    .style2
    {
        text-align: right;
        width: 270px;
        height: 29px;
    }
    .style3
    {
        height: 29px;
    }
    .style4
    {
        text-align: right;
        width: 10px;
    }
    .style5
    {
        text-align: right;
        width: 10px;
        height: 29px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <h2>Consulta de datos y generación de reportes</h2>
<p>Selecciona una opción para consultar o generar un reporte</p>
<div id="TablaReportes">
    <table style="width: 100%;">
        <tr>
            <td class="style1">
                &nbsp;
                Selecciona un origen de datos:</td>
            <td class="style4">
                &nbsp;</td>
            <td rowspan="3">
                <asp:RadioButtonList ID="RadioButtonListOrigenDatos" runat="server" 
                    RepeatLayout="Flow" AutoPostBack="True">
                    <asp:ListItem Value="OXEXP002_FraccionModificado">Exportaciones Modificado</asp:ListItem>
                    <asp:ListItem Value="OXIMP002_FraccionModificado">Importaciones Modificado</asp:ListItem>
                    <asp:ListItem Value="OXEXP004_FraccionPreAnalisis">Exportaciones PreAnálisis</asp:ListItem>
                    <asp:ListItem Value="OXIMP004_FraccionPreAnalisis">Importaciones PreAnálisis</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;
                Selecciona el año a consultar:</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style3">
                &nbsp;
                <asp:DropDownList ID="DropDownListAño" runat="server" AutoPostBack="True" 
                    Width="150px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
                Selecciona el mes as consultar:</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;
                <asp:DropDownList ID="DropDownListMes" runat="server" AutoPostBack="True" 
                    Width="150px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp; Selecciona la fracción:</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;
                <asp:DropDownList ID="DropDownListFraccion" runat="server" AutoPostBack="True" 
                    Width="150px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td style="color: #FF0000">
                <asp:Literal ID="ErrorL" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td style="color: #FF0000">
                <asp:ImageButton ID="ButtonReporte" runat="server" Height="50px" 
                    ImageUrl="~/uiResources/reporteexcel.png" Visible="False" Width="120px" 
                    ToolTip="Haz clic para descargar reporte con formato de excel " />
            </td>
        </tr>
    </table>
</div>

</asp:Content>

