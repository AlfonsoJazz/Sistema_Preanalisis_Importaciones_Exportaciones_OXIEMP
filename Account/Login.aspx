<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Account_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//ES" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>OXIMEXP | Sistema para el pre-análisis de Importaciones y Exportaciones </title>
    <meta name="generator" content="José Alfonso Mosco H. - Becario de Negocios de TI"/>
    <link rel="SHORTCUT ICON"  href="../uiResources/Favicon_Oxiteno.ico"/> 
</head>
<script language="javascript" type="text/javascript">
    function prevent_previous_page_return() {
        window.history.forward(1);
    }
    function imgEscritura_onclick() {

    }

</script>
<body onload="prevent_previous_page_return()">
    <form id="frmLogin" method="post" runat="server">
    <table width="100%" cellspacing="0" cellpadding="0" border="0" style="vertical-align: top;">
        <tr>
            <td align="center">
                <table width="999px" cellspacing="0" cellpadding="0" border="0">
                    <tr>                       
                        <td align="center">
                            <table width="999px" cellspacing="0" cellpadding="0" border="0">
                                <tr>
                                    <td align="center">
                                        <table width="999" cellspacing="0" cellpadding="0" border="0" style="height: 110px;">
                                            <tr>
                                                <td align="left" valign="middle" style="width: 30%;">
                                                    <%--<asp:Button ID="Button2" runat="server" Text="Button" CausesValidation="false" />--%>
                                                </td>
                                                <td align="center" valign="middle" style="width: 40%;">
                                                </td>
                                                <td align="right" style="width: 30%;">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table width="800" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top">
                            <table width="625" border="0" cellspacing="0" cellpadding="0" align="center">
                                <tr>
                                    <td>
                                        <div align="center">
                                            <font class="Titulo" style="font-family:Calibri">Sistema para el pre-análisis de Importaciones y Exportaciones</font><br />
                                            <font color="navy"style="font-family:verdana,tahoma,arial;font-size: 10pt;">
                                            </font></div>
                                    </td>
                                </tr>
                                </table>
                            <br />
                            <table width="625" border="0" cellspacing="0" cellpadding="1" align="center">
                                <tr>
                                    <td align="left">
                                        <table border="0" cellspacing="0" cellpadding="0" style="width:500px">
                                            <tr>
                                                <td align="justify" style="text-align: justify; font-family:Calibri; font-size:smaller;">                                                      
                                                     Ingresar Usuario y Password de red.                                                  
                                                </td>
                                                <td>
                                                    &nbsp;</td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" style="font-family:verdana,tahoma,arial;font-size: 10pt;width:80%;">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" align="center"  style="width:19">
                                                        <tr>
                                                            <td colspan="5" bgcolor="#000055">
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td bgcolor="#000055">
                                                               <%-- &nbsp;--%>
                                                            </td>
                                                            <td bgcolor="#000055">
                                                                <div align="center">
                                                                    <asp:TextBox ID="txtUser" TabIndex="1" runat="server" MaxLength="20" AutoCompleteType="Disabled" ></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="valEmailAlias" runat="server" Font-Names="Arial"
                                                                        ErrorMessage="Se requiere su usuario de Windows" ControlToValidate="txtUser">*</asp:RequiredFieldValidator>
                                                                </div>
                                                            </td>
                                                            <td bgcolor="#000055">
                                                               <%-- &nbsp;--%>
                                                            </td>
                                                            <td bgcolor="#000055">
                                                                <div align="center">
                                                                    <asp:TextBox ID="txtPassword" TabIndex="2" runat="server" MaxLength="20"
                                                                        TextMode="Password"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="Requiredfieldvalidator3" runat="server" Font-Names="Arial"
                                                                        ErrorMessage="Se requiere su password de Windows" ControlToValidate="txtPassword">*</asp:RequiredFieldValidator>
                                                                </div>
                                                            </td>
                                                            <td bgcolor="#000055">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr bgcolor="#000055">
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                <div align="center">
                                                                    <font color="#FFFFFF" size="1" face="Arial, Helvetica, sans-serif"><b><i>Usename</i></b></font></div>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td align="center">
                                                                <font color="#FFFFFF" size="1" face="Arial, Helvetica, sans-serif"><i><b>Password</b></i></font>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td height="40" valign="bottom">
                                                    <img  alt="" src="../uiResources/rayat.jpg" height="40"/>
                                                </td>
                                                <td height="40" valign="middle">
                                                    <asp:ImageButton runat="server" ID="btnEntrar" ImageUrl="~/uiResources/BTN_Entrar.gif"
                                                        Width="73px" Height="32px" OnClick="btnEntrar_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width:auto;">
                                        &nbsp;
                                    </td>
                                    <td align="right" style="text-align:right;">
                                        <img id="imgEscritura" alt="" src="../uiResources/OXI_BLANCO.jpg" style="text-align:right;" onclick="return imgEscritura_onclick()" />
                                    </td>
                                </tr>
                            </table>
                           
                        </td>
                    </tr>
                </table>
                
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top" align="center" colspan="2" style="height: 67px">
                            <asp:Label ID="lblResults" runat="server" Visible="False" ForeColor="Red">Windows Username/Password invalid.</asp:Label><asp:ValidationSummary
                                ID="ValidationSummary1" runat="server" ShowMessageBox="True"></asp:ValidationSummary>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        
    </table>
    </form>
</body>
</html>
