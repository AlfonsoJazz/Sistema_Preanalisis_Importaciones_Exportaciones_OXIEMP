<%@ Page Title="OXIMEXP | Actualización de registros: Importaciones" Language="VB" MasterPageFile="~/Site.master" AutoEventWireup="false" CodeFile="preanalisis_imp.aspx.vb" Inherits="preanalisis_imp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <%--<style type="text/css">
        .style1
        {
            width: 270px;
        }
        .style2
        {
            width: 10px;
        }
    </style>--%>
    <style type="text/css">
        .style1
        {
            text-align: right;
            width: 270px;
        }
        .style2
        {
            width: 10px;
        }
        .style3
        {
            width: 360px;
        }
        .style10
        {
            text-align: center;
        }
        .style11
        {
            width: 160px;
        }
        .style13
        {
            width: 90%;
        }
        .style14
        {
            width: 90%;
            text-align: center;

        }
        .style16
        {
            width: 400px;
            text-align: center;
            margin-left: 40px;
        }
        .style19
        {
            width: 290px;
            text-align: center;
        }
        .style20
        {
            width: 155px;
            height: 26px;
        }
        .style21
        {
            width: 400px;
            text-align: center;
            height: 26px;
        }
        .style22
        {
            width: 160px;
            height: 26px;
        }
        .style23
        {
            width: 290px;
            text-align: center;
            height: 26px;
        }
        .style24
        {
            text-align: center;
            height: 26px;
        }
        .style25
        {
            width: 155px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

<div>
    <h2>Actualización de registros pre análisis: Importaciones</h2>
     <p>Selecciona una opción para editar el contenido de cada registro, según su estatus en el sistema estarán disponibles para su edición.</p>
        <asp:Label ID="LabelMsg" runat="server" Visible="False" Width="100%" style="color: #00CC00"></asp:Label>
        <asp:Label ID="LabelError" runat="server" Visible="False" Width="100%" style="color: #FF0000"></asp:Label>
    <asp:Panel ID="Panel_Seleccion" runat="server">
        <table style="width: 100%;">
        <tr>
            <td class="style1">
                <asp:ImageButton ID="Actualizar_Registros" runat="server" 
                    ImageUrl="~/uiResources/update_registros.png" 
                    ToolTip="Haz clic para obtener registros actualizados" Width="100px" />
            </td>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
                Selecciona el año a consultar:</td>
            <td class="style2">
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
            <td class="style2">
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
            <td class="style2">
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
            <td class="style2">
                &nbsp;</td>
            <td style="color: #FF0000">
                <asp:ImageButton ID="ButtonConsulta" runat="server" 
                    ImageUrl="~/uiResources/vizualizardatos.png" Width="120px" 
                    ToolTip="Haz clic para recuperar los datos" Visible="False" />
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
            <td style="color: #FF0000">
                <asp:Literal ID="ErrorL" runat="server"></asp:Literal>
            </td>
        </tr>
    </table>
    </asp:Panel>

    <asp:Panel ID="PanelMain" runat="server" Visible="false" style="text-align: right">
        <div>
        <table style="width: 100%;">
            <tr>
                <td class="style25">
                    &nbsp; ID</td>
                <td class="style16">
                    <asp:TextBox ID="ID" runat="server" CssClass="style14" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="style11">
                    &nbsp;
                </td>
                <td style="color: #FF0000" class="style19">
                    &nbsp;</td>
                <td class="style10" style="color: #FF0000">

                </td>
            </tr>
            <tr>
                <td class="style25">
                    &nbsp; País</td>
                <td class="style16">
                    <asp:TextBox ID="Pais_txt" runat="server" CssClass="style14" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="style11">
                    &nbsp; País Homologado
                </td>
                <td class="style19">
                    <asp:DropDownList ID="ddPais_Homologado" runat="server" CssClass="style13">
                    </asp:DropDownList>
                </td>
                <td class="style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style25">
                    &nbsp; Importador</td>
                <td class="style16">
                    <asp:TextBox ID="Importadir_txt" runat="server" CssClass="style14" 
                        Enabled="False"></asp:TextBox>
                </td>
                <td class="style11">
                    Importador Homologado</td>
                <td class="style19">
                    <asp:DropDownList ID="ddImportador_Homologado" runat="server" 
                        CssClass="style13">
                    </asp:DropDownList>
                </td>
                <td class="style10">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="Importadir_txt" ErrorMessage="Error: Campo vacío" 
                        ForeColor="Red"> 
                     </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style25">
                    &nbsp; Familia</td>
                <td class="style16">
                    <asp:TextBox ID="Familia_txt" runat="server" CssClass="style14" Enabled="False"></asp:TextBox>
                </td>
                <td class="style11">
                    <asp:RadioButtonList ID="Decision_Familia" runat="server" RepeatDirection="Horizontal" 
                        ToolTip="Ingresar datos o seleccionar del catálogo de opciones" 
                        AutoPostBack="True">
                        <asp:ListItem>Escribir</asp:ListItem>
                        <asp:ListItem>Seleccionar</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="style19">
                    <asp:DropDownList ID="ddFamilias" runat="server" CssClass="style13" 
                        Enabled="False" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td class="style10">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="Familia_txt" ErrorMessage="Error: Campo vacío" 
                        ForeColor="Red"> 
                     </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style25">
                    &nbsp; Productos Identificados</td>
                <td class="style16">
                    <asp:TextBox ID="Prod_Identi_txt" runat="server" CssClass="style14" 
                        Enabled="False"></asp:TextBox>
                </td>
                <td class="style11">
                    <asp:RadioButtonList ID="Decision_PI" runat="server" 
                        RepeatDirection="Horizontal"  
                        ToolTip="Ingresar datos o seleccionar del catálogo de opciones" 
                        AutoPostBack="True" Enabled="False">
                        <asp:ListItem>Escribir</asp:ListItem>
                        <asp:ListItem>Seleccionar</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="style19">
                    <asp:DropDownList ID="ddProd_Identificados" runat="server" CssClass="style13" 
                        Enabled="False" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td class="style10">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="Prod_Identi_txt" ErrorMessage="Error: Campo vacío" 
                        ForeColor="Red"> 
                     </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style25">
                    &nbsp; Clasificación</td>
                <td class="style16">
                    <asp:TextBox ID="Clasificacion_txt" runat="server" CssClass="style14" 
                        Enabled="False"></asp:TextBox>
                </td>
                <td class="style11">
                    <asp:RadioButtonList ID="Decision_Clasificacion" runat="server" RepeatDirection="Horizontal" 
                        ToolTip="Ingresar datos o seleccionar del catálogo de opciones" 
                        AutoPostBack="True" Enabled="False">
                        <asp:ListItem>Escribir</asp:ListItem>
                        <asp:ListItem>Seleccionar</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="style19">
                    <asp:DropDownList ID="ddClasificacion" runat="server" CssClass="style13" 
                        Enabled="False" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td class="style10">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                        ControlToValidate="Clasificacion_txt" ErrorMessage="Error: Campo vacío" 
                        ForeColor="Red"> 
                     </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style20">
                    &nbsp; Descripción Química</td>
                <td class="style21">
                    <asp:TextBox ID="Desc_Quim_txt" runat="server" CssClass="style14" 
                        Enabled="False"></asp:TextBox>
                </td>
                <td class="style22">
                    <asp:RadioButtonList ID="Decision_DescQuim" runat="server" 
                        AutoPostBack="True" RepeatDirection="Horizontal" 
                        ToolTip="Ingresar datos o seleccionar del catálogo de opciones">
                        <asp:ListItem>Escribir</asp:ListItem>
                        <asp:ListItem>Seleccionar</asp:ListItem>
                    </asp:RadioButtonList>
                    </td>
                <td class="style23">
                    <asp:DropDownList ID="ddDesc_Quim" runat="server" CssClass="style13" 
                        Enabled="False" AutoPostBack="True">
                    </asp:DropDownList>
                    </td>
                <td class="style24">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                        ControlToValidate="Desc_Quim_txt" ErrorMessage="Error: Campo vacío" 
                        ForeColor="Red"> 
                     </asp:RequiredFieldValidator>
                    </td>
            </tr>
            <tr>
                <td class="style25">
                    &nbsp; Contratipo</td>
                <td class="style16">
                    <asp:TextBox ID="Contratipo_txt" runat="server" CssClass="style14" 
                        Enabled="False"></asp:TextBox>
                </td>
                <td class="style11">
                    <asp:RadioButtonList ID="Decision_Contratipo" runat="server" 
                        AutoPostBack="True" RepeatDirection="Horizontal" 
                        ToolTip="Ingresar datos o seleccionar del catálogo de opciones">
                        <asp:ListItem>Escribir</asp:ListItem>
                        <asp:ListItem>Seleccionar</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td class="style19">
                    <asp:DropDownList ID="ddContratipo" runat="server" CssClass="style13" 
                        Enabled="False" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td class="style10">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="Contratipo_txt" ErrorMessage="Error: Campo vacío" 
                        ForeColor="Red"> 
                     </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style25">
                    &nbsp; Proveedor</td>
                <td class="style16">
                    <asp:TextBox ID="Proveedor_txt" runat="server" CssClass="style14"></asp:TextBox>
                </td>
                <td class="style11">
                    Proveedor Homologado</td>
                <td class="style19">
                    <asp:DropDownList ID="ddProveedror_h" runat="server" CssClass="style13">
                    </asp:DropDownList>
                </td>
                <td class="style10">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                        ControlToValidate="Proveedor_txt" ErrorMessage="Error: Campo vacío" 
                        ForeColor="Red"> 
                     </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style25">
                    &nbsp;</td>
                <td class="style16">
                    &nbsp;</td>
                <td class="style11">
                    <br />
                    <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" 
                        Text="Los datos son correctos" 
                        ToolTip="Haz clic si estas seguro de realizar los cambios en el registro actual" />
                </td>
                <td class="style19">
                    <asp:ImageButton ID="Firmar_ConSangre" runat="server" 
                        ImageUrl="~/uiResources/guardar_base_1.png" 
                        ToolTip="Haz clic para guardar los cambios en la base de datos" 
                        Width="120px" Visible="False" />
                </td>
                <td class="style10">
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </asp:Panel>
    <asp:Panel ID="PanelPreview" runat="server">
        <asp:GridView ID="Previsualiza" runat="server" Width="100%" BackColor="#CCCCCC" 
            BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
            CellSpacing="2" ForeColor="Black" style="font-size: x-small">
            <Columns>
                <asp:CommandField ButtonType="Image" ShowSelectButton="True"  SelectImageUrl="~/uiResources/edit_Multiple.png" ControlStyle-Width="30px" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>

    </asp:Panel>
    <%--   <table style="width: 100%;">
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style3">
                <asp:Button ID="ButtonRegistros" runat="server" Text="Obtener registros" 
                    style="height: 26px" />
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;
                Seleccione el año:&nbsp;&nbsp; </td>
            <td class="style3">
                &nbsp;
                <asp:DropDownList ID="DD2" runat="server"  Width="300px" Enabled="False">
                </asp:DropDownList>
                <asp:Label ID="lblYear" runat="server" Visible="False" CssClass="style4"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;
                Seleccione el mes:&nbsp;&nbsp; </td>
            <td class="style3">
                &nbsp;
                <asp:DropDownList ID="DD3" runat="server"  Width="300px" Enabled="False">
                </asp:DropDownList>
                <asp:Label ID="lblmes" runat="server" Visible="False" CssClass="style4"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">
                &nbsp;
                Seleccione fracción:&nbsp;&nbsp; </td>
            <td>
                &nbsp;
                <asp:DropDownList ID="DD4" runat="server"  Width="300px" Enabled="False">
                </asp:DropDownList>
                <asp:Label ID="lblfrac" runat="server" Visible="False" CssClass="style4"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="lblConsulta" runat="server" style="font-size: smaller" 
                    Visible="False"></asp:Label>
            </td>
            <td>
                <asp:Button ID="ButtonConsulta" runat="server" Text="Realizar consulta" 
                    Width="150px" Enabled="False" CausesValidation="False" />
                &nbsp;<asp:Label ID="LblOrigen" runat="server" style="font-size: smaller" 
                    Visible="False"></asp:Label>
            </td>
        </tr>
    </table>--%>


    <%--  <div style="overflow-x: auto;">
        <p id="Instrucciones">Haz clic en &nbsp;registro" ImageUrl="~/uiResources/Edit.png" Width="18px" runat="server" />&nbsp;para editar el contenido de un registro en la base de datos</p>
        <asp:GridView ID="GridView1" runat="server" BackColor="#CCCCCC" 
            BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
            DataSourceID="SqlDataSource1" ForeColor="Black" 
            AutoGenerateColumns="False" DataKeyNames="OXIMP004_ID_IN" CellSpacing="2">
            <Columns>
                <asp:CommandField AccessibleHeaderText="Editar" 
                    SelectImageUrl="~/uiResources/Edit.png"  ControlStyle-Width="20px" ShowSelectButton="True" 
                    ButtonType="Image" SelectText="Editar" >
<ControlStyle Width="20px"></ControlStyle>
                </asp:CommandField>
                <asp:BoundField DataField="OXIMP004_ID_IN" HeaderText="ID" 
                    ReadOnly="True" SortExpression="OXIMP004_ID_IN" />
                <asp:BoundField DataField="OXIMP004_Año_IN" HeaderText="Año" 
                    SortExpression="OXIMP004_Año_IN" Visible="false" />
                <asp:BoundField DataField="OXIMP004_Mes_IN" HeaderText="Mes" 
                    SortExpression="OXIMP004_Mes_IN" Visible="false" />
                <asp:BoundField DataField="OXIMP004_PaisProcede_ST" 
                    HeaderText="País procedencia" SortExpression="OXIMP004_PaisProcede_ST" />
                <asp:BoundField DataField="OXIMP004_PaisHomologado_ST" 
                    HeaderText="País H." 
                    SortExpression="OXIMP004_PaisHomologado_ST" />
                <asp:BoundField DataField="OXIMP004_ContenidoCargamento" 
                    HeaderText="OXIMP004_ContenidoCargamento" 
                    SortExpression="OXIMP004_ContenidoCargamento" Visible="false" />
                <asp:BoundField DataField="OXIMP004_Importador_ST" 
                    HeaderText="Importador" SortExpression="OXIMP004_Importador_ST"  />
                <asp:BoundField DataField="OXIMP004_ImportadorHomologado_ST" 
                    HeaderText="Importador H." 
                    SortExpression="OXIMP004_ImportadorHomologado_ST" />
                <asp:BoundField DataField="OXIMP004_Familia_ST" 
                    HeaderText="Familia" SortExpression="OXIMP004_Familia_ST" />
                <asp:BoundField DataField="OXIMP004_Fraccion_ST" 
                    HeaderText="Fracción" SortExpression="OXIMP004_Fraccion_ST" Visible="false" />
                <asp:BoundField DataField="OXIMP004_ProductoIdentificados_ST" 
                    HeaderText="Productos Identificados" 
                    SortExpression="OXIMP004_ProductoIdentificados_ST" />
                <asp:BoundField DataField="OXIMP004_Clasificacion_ST" 
                    HeaderText="Clasificación" 
                    SortExpression="OXIMP004_Clasificacion_ST" />
                <asp:BoundField DataField="OXIMP004_DescripcionQuimica_ST" 
                    HeaderText="Descripción Química" 
                    SortExpression="OXIMP004_DescripcionQuimica_ST" />
                <asp:BoundField DataField="OXIMP004_Contratipo_ST" 
                    HeaderText="Contratipo" SortExpression="OXIMP004_Contratipo_ST" />
                <asp:BoundField DataField="OXIMP004_Proveedor_ST" 
                    HeaderText="Proveedor" SortExpression="OXIMP004_Proveedor_ST"/>
                <asp:BoundField DataField="OXIMP004_ProveedorHomologado_ST" 
                    HeaderText="Proveedor H." 
                    SortExpression="OXIMP004_ProveedorHomologado_ST" />
                <asp:BoundField DataField="OXIMP004_QtaToneladas_DC" 
                    HeaderText="OXIMP004_QtaToneladas_DC" 
                    SortExpression="OXIMP004_QtaToneladas_DC" Visible="false"/>
                <asp:BoundField DataField="OXIMP004_MontoUSD_DC" 
                    HeaderText="OXIMP004_MontoUSD_DC" SortExpression="OXIMP004_MontoUSD_DC" Visible="false"/>
                <asp:BoundField DataField="OXIMP004_PrecioAduanaUSD_DC" 
                    HeaderText="OXIMP004_PrecioAduanaUSD_DC" 
                    SortExpression="OXIMP004_PrecioAduanaUSD_DC" Visible="false" />
                <asp:BoundField DataField="OXIMP004_Incoterm_ST" 
                    HeaderText="OXIMP004_Incoterm_ST" SortExpression="OXIMP004_Incoterm_ST" Visible="false" />
                <asp:CheckBoxField DataField="OXIMP004_PaisH_BT" HeaderText="OXIMP004_PaisH_BT" 
                    SortExpression="OXIMP004_PaisH_BT" Visible="false"/>
                <asp:CheckBoxField DataField="OXIMP004_ImportadorH_BT" 
                    HeaderText="OXIMP004_ImportadorH_BT" SortExpression="OXIMP004_ImportadorH_BT" Visible="false"/>
                <asp:CheckBoxField DataField="OXIMP004_Familia_BT" 
                    HeaderText="OXIMP004_Familia_BT" SortExpression="OXIMP004_Familia_BT" Visible="false" />
                <asp:CheckBoxField DataField="OXIMP004_ProductoIdentificados_BT" 
                    HeaderText="OXIMP004_ProductoIdentificados_BT" 
                    SortExpression="OXIMP004_ProductoIdentificados_BT" Visible="false"/>
                <asp:CheckBoxField DataField="OXIMP004_Clasificacion_BT" 
                    HeaderText="OXIMP004_Clasificacion_BT" 
                    SortExpression="OXIMP004_Clasificacion_BT" Visible="false" />
                <asp:CheckBoxField DataField="OXIMP004_DescripcionQuimica_BT" 
                    HeaderText="OXIMP004_DescripcionQuimica_BT" 
                    SortExpression="OXIMP004_DescripcionQuimica_BT" Visible="false"/>
                <asp:CheckBoxField DataField="OXIMP004_Contratipo_BT" 
                    HeaderText="OXIMP004_Contratipo_BT" SortExpression="OXIMP004_Contratipo_BT" Visible="false" />
                <asp:CheckBoxField DataField="OXIMP004_ProveedorH_BT" 
                    HeaderText="OXIMP004_ProveedorH_BT" SortExpression="OXIMP004_ProveedorH_BT" Visible="false"/>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ZOXIMPEXPConnectionString %>" 
            SelectCommand="usp_OXIEMP_Consulta_Preanalisis" 
            SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:ControlParameter ControlID="lblConsulta" Name="STR_IMP_EXP" 
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="lblYear" Name="INT_AÑO" PropertyName="Text" 
                    Type="Int32" />
                <asp:ControlParameter ControlID="lblmes" Name="INT_MES" PropertyName="Text" 
                    Type="Int32" />
                <asp:ControlParameter ControlID="lblfrac" Name="INT_FRAC" PropertyName="Text" 
                    Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>--%>
</div>

</asp:Content>

