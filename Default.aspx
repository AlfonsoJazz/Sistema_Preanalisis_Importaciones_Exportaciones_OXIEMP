<%@ Page Title="OXIMEXP | Sistema para el pre análisis de importaciones y exportaciones" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="false"
    CodeFile="Default.aspx.vb" Inherits="_Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 180px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Sistema para el pre análisis de importaciones y exportaciones
    </h2>
    <p>
        Favor de reportar cualquier error con el   <a href="mailto:vcisneros@oxiteno.com" title="Valentin Cisneros">administrador del sitio</a>.
    </p>
    <p>
        Ejecución de procesos 
    </p>
    <div>
        <table style="width: 100%;">
            <tr>
                <td class="style1">
                    &nbsp;
                    <asp:ImageButton ID="BtnProceso1" runat="server" 
                        ImageUrl="~/uiResources/Procedimiento.png" ToolTip="Ejecutar proceso :" 
                        Width="120px" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;
                    <asp:ImageButton ID="BtnProceso2" runat="server" 
                        ImageUrl="~/uiResources/Procedimiento.png" ToolTip="Ejecutar proceso :" 
                        Width="120px" />
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style1">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>