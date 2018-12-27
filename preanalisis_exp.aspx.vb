Imports System.Configuration.ConfigurationManager
Imports System.Configuration
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Web.Util.Transactions
Imports System.Data
Imports System.Web
Imports System.IO
Imports System.Activities
Imports System.Transactions

Partial Class preanalisis_exp
    Inherits System.Web.UI.Page
    Private cadenaconexion As String = ConfigurationManager.ConnectionStrings("ZOXIMPEXPConnectionString").ConnectionString
    Private parametro As String = "OXEXP004_FraccionPreAnalisis"
    ' Private Familia_Seleccionada As String
    Private InfoInsuficiente As String = "INFORMACIÓN INSUFICIENTE"
    REM Metodo para borrar todos los textbox al guardar en gridview
    Public Sub ClearTextBox(parent As Control)
        For Each child As Control In parent.Controls
            ClearTextBox(child)
        Next
        If TryCast(parent, TextBox) IsNot Nothing Then
            TryCast(parent, TextBox).Text = [String].Empty
            TryCast(parent, TextBox).BorderColor = Nothing
        ElseIf TryCast(parent, DropDownList) IsNot Nothing Then
            TryCast(parent, DropDownList).BorderColor = Nothing
            TryCast(parent, DropDownList).Items.Clear()
        ElseIf TryCast(parent, RadioButtonList) IsNot Nothing Then
            TryCast(parent, RadioButtonList).ClearSelection()
        End If
    End Sub

    REM Para renderizar dropdownlist según sea el caso 
    Protected Sub Renderiza_DropDownList(ByRef comando As String, ByRef ddList As DropDownList, Optional ByRef nombreParametroSQL As String = Nothing, Optional ByRef parametroSQL As String = Nothing)
        Try
            Using cn As New SqlConnection(cadenaconexion)
                Dim r As SqlDataReader
                Dim i As Integer
                Dim cmd As SqlCommand = cn.CreateCommand
                cmd.CommandType = CommandType.StoredProcedure
                If Not IsNothing(nombreParametroSQL) And Not IsNothing(parametroSQL) Then
                    cmd.Parameters.Add(nombreParametroSQL, SqlDbType.VarChar).Value = parametroSQL
                End If
                cmd.CommandText = comando
                cn.Open()
                i = cmd.ExecuteNonQuery
                If i <> 0 Then
                    r = cmd.ExecuteReader
                    ddList.Items.Clear()
                    ddList.Items.Add("Selecciona una opción")
                    While r.Read
                        ddList.Items.Add(r.GetString(0))
                    End While
                End If
                cn.Close() : cn.Dispose() : cmd.Dispose()
            End Using
        Catch ex As Exception
            LabelError.Text = ex.Message.ToString : LabelError.Visible = True
            Elog.save(Me, ex.Message.ToString)
        Finally
            Session(comando) = comando
        End Try
    End Sub

    Protected Sub Actualizar_Registros_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles Actualizar_Registros.Click
        ErrorL.Text = String.Empty
        DropDownListAño.Items.Clear()
        DropDownListMes.Items.Clear()
        DropDownListFraccion.Items.Clear()
        ButtonConsulta.Visible = False
        Try
            Using con As New SqlConnection(cadenaconexion)
                Dim cmd_año As SqlCommand = con.CreateCommand
                Dim rAño As SqlDataReader = Nothing
                cmd_año.CommandType = CommandType.StoredProcedure
                cmd_año.Parameters.Add("@STR_IMPORT_EXPORT", SqlDbType.VarChar).Value = parametro.ToString
                cmd_año.CommandText = "usp_OXIEMP_Selecciona_Año_Reporte"
                con.Open()
                cmd_año.ExecuteNonQuery()
                rAño = cmd_año.ExecuteReader
                DropDownListAño.Items.Add("Selecciona una opción")
                While rAño.Read
                    DropDownListAño.Items.Add(rAño.GetInt32(0))
                End While
                rAño.Close()
                con.Close() : con.Dispose()
                cmd_año.Dispose()
            End Using
        Catch ex As Exception
            ErrorL.Text = ex.Message.ToString
            Elog.save(Me, ex.Message.ToString)
        End Try
    End Sub

    Protected Sub DropDownListAño_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles DropDownListAño.SelectedIndexChanged
        ErrorL.Text = String.Empty
        DropDownListMes.Items.Clear()
        DropDownListFraccion.Items.Clear()
        ButtonConsulta.Visible = False
        Try
            If DropDownListAño.SelectedValue <> "Selecciona una opción" Then
                Using con_mes As New SqlConnection(cadenaconexion)
                    Dim cmd_mes As SqlCommand = con_mes.CreateCommand
                    Dim rMes As SqlDataReader = Nothing
                    cmd_mes.CommandType = CommandType.StoredProcedure
                    cmd_mes.Parameters.Add("@STR_IMPORT_EXPORT", SqlDbType.VarChar).Value = parametro
                    cmd_mes.Parameters.Add("@AÑO", SqlDbType.Int).Value = DropDownListAño.SelectedValue
                    cmd_mes.CommandText = "usp_OXIEMP_Selecciona_Mes_Fraccion_Reporte"
                    con_mes.Open()
                    cmd_mes.ExecuteNonQuery()
                    rMes = cmd_mes.ExecuteReader
                    DropDownListMes.Items.Clear()
                    DropDownListMes.Items.Add("Selecciona una opción")
                    While rMes.Read
                        DropDownListMes.Items.Add(rMes.GetInt32(0))
                    End While
                    rMes.Close()
                    con_mes.Close() : con_mes.Dispose()
                    cmd_mes.Dispose()
                End Using
            Else
                DropDownListMes.Items.Clear()
                DropDownListFraccion.Items.Clear()
                DropDownListAño.Focus()
            End If
        Catch ex As Exception
            ErrorL.Text = ex.Message.ToString
            Elog.save(Me, ex.Message.ToString)
        End Try
    End Sub

    Protected Sub DropDownListMes_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles DropDownListMes.SelectedIndexChanged
        ErrorL.Text = String.Empty
        DropDownListFraccion.Items.Clear()
        ButtonConsulta.Visible = False
        Try
            If DropDownListAño.SelectedValue <> "Selecciona una opción" Then
                If DropDownListMes.SelectedValue <> "Selecciona una opción" Then
                    Using conn As New SqlConnection(cadenaconexion)
                        Dim cmd_frac As SqlCommand = conn.CreateCommand
                        Dim rFrac As SqlDataReader = Nothing
                        cmd_frac.CommandType = CommandType.StoredProcedure
                        cmd_frac.Parameters.Add("@STR_IMPORT_EXPORT", SqlDbType.VarChar).Value = parametro
                        cmd_frac.Parameters.Add("@AÑO", SqlDbType.Int).Value = DropDownListAño.SelectedValue
                        cmd_frac.Parameters.Add("@MES", SqlDbType.Int).Value = DropDownListMes.SelectedValue
                        cmd_frac.CommandText = "usp_OXIEMP_Selecciona_Fraccion_Reporte"
                        conn.Open()
                        cmd_frac.ExecuteNonQuery()
                        rFrac = cmd_frac.ExecuteReader
                        DropDownListFraccion.Items.Clear()
                        DropDownListFraccion.Items.Add("Selecciona una opción")
                        While rFrac.Read
                            DropDownListFraccion.Items.Add(rFrac.GetInt32(0))
                        End While
                        rFrac.Close()
                        conn.Close() : conn.Dispose()
                        cmd_frac.Dispose()
                    End Using
                Else
                    DropDownListFraccion.Items.Clear()
                    DropDownListFraccion.Items.Clear()
                    DropDownListMes.Focus()
                End If
            Else
                DropDownListFraccion.Items.Clear()
                DropDownListMes.Items.Clear()
                DropDownListAño.Focus()
            End If
        Catch ex As Exception
            ErrorL.Text = ex.Message.ToString
            Elog.save(Me, ex.Message.ToString)
        End Try
    End Sub

    Protected Sub DropDownListFraccion_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles DropDownListFraccion.SelectedIndexChanged
        If DropDownListFraccion.SelectedValue <> "Selecciona una opción" Then
            ButtonConsulta.Visible = True
        Else
            ButtonConsulta.Visible = False
        End If
    End Sub

    Protected Sub ButtonConsulta_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ButtonConsulta.Click
        Try
            Using con As New SqlConnection(cadenaconexion)
                Dim gvDT As New DataTable
                Dim gvAdapter As SqlDataAdapter
                Dim cmd_Consulta As SqlCommand = con.CreateCommand
                cmd_Consulta.CommandType = CommandType.StoredProcedure
                cmd_Consulta.Parameters.Add("@STR_IMP_EXP", SqlDbType.VarChar).Value = parametro
                cmd_Consulta.Parameters.Add("@INT_AÑO", SqlDbType.Int).Value = DropDownListAño.SelectedValue
                cmd_Consulta.Parameters.Add("@INT_MES", SqlDbType.Int).Value = DropDownListMes.SelectedValue
                cmd_Consulta.Parameters.Add("@INT_FRAC", SqlDbType.Int).Value = DropDownListFraccion.SelectedValue
                cmd_Consulta.CommandText = "usp_OXIEMP_Consulta_Preanalisis"
                con.Open()
                cmd_Consulta.ExecuteNonQuery()
                gvAdapter = New SqlDataAdapter(cmd_Consulta)
                gvAdapter.Fill(gvDT)
                gvAdapter.Dispose() : cmd_Consulta.Dispose() : con.Close() : con.Dispose()
                If gvDT.Rows.Count > 0 Then
                    Dim col() As String = {"OXEXP004_Año_IN", _
                                            "OXEXP004_Mes_IN", _
                                            "OXEXP004_ContenidoCargamento_ST", _
                                            "OXEXP004_Fraccion_ST", _
                                            "OXEXP004_QtaToneladas_DC", _
                                            "OXEXP004_MontoUSD_DC", _
                                            "OXEXP004_PrecioAduanaUSD_DC", _
                                            "OXEXP004_PaisH_BT", _
                                            "OXEXP004_ExportadorH_BT", _
                                            "OXEXP004_ProductoIdentificados_BT", _
                                            "OXEXP004_Familia_BT", _
                                            "OXEXP004_Clasificacion_BT", _
                                            "OXEXP004_DescripcionQuimica_BT", _
                                            "OXEXP004_CompradorH_BT"}

                    For i As Integer = 0 To 13
                        gvDT.Columns.Remove(col(i))
                    Next
                    Dim colRestantes() As String = {"OXEXP004_ID_IN", _
                                                    "OXEXP004_PaisDestino_ST", _
                                                    "OXEXP004_PaisH_ST", _
                                                    "OXEXP004_ExportadorH_ST", _
                                                    "OXEXP004_ProductoIdentificados_ST", _
                                                    "OXEXP004_Familia_ST", _
                                                    "OXEXP004_Clasificacion_ST", _
                                                    "OXEXP004_DescripcionQuimica_ST", _
                                                    "OXEXP004_CompradorH_ST"}

                    Dim colNuevas() As String = {"ID" _
                                                , "País Destino" _
                                                , "País H." _
                                                , "Exportador H." _
                                                , "Productos Identificados" _
                                                , "Familia" _
                                                , "Clasificación" _
                                                , "Desc Quím" _
                                                , "Comprador H."}

                    For n As Integer = 0 To 8
                        gvDT.Columns(colRestantes(n)).ColumnName = colNuevas(n)
                    Next
                    Previsualiza.DataSource = gvDT
                    Previsualiza.DataBind()
                End If
            End Using
        Catch ex As Exception
            ErrorL.Text = ex.Message.ToString
            Elog.save(Me, ex.Message.ToString)
        End Try
    End Sub

    Protected Sub Previsualiza_SelectedIndexChanging(sender As Object, e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles Previsualiza.SelectedIndexChanging
        Try
            ''''''''''''''''''''''''''''''''
            Dim parent As Object = PanelMain
            Me.ClearTextBox(parent)
            ''''''''''''''''''''''''''''''''
            Dim gID As Integer
            Dim i As Integer = e.NewSelectedIndex
            gID = Convert.ToInt32(Previsualiza.Rows(i).Cells(1).Text)
            Dim nDT As New DataTable
            Dim bPais, bExportador, bFamilia, _
                bProductos, bClasificacion, bDescQuim, bComprador As Boolean
            Dim pa, exp, fam, pi, cls, dq, cpdr As String

            Using con As New SqlConnection(cadenaconexion)
                Dim cmd_recupera_registros As SqlCommand = con.CreateCommand

                Dim a As SqlDataAdapter
                cmd_recupera_registros.CommandType = CommandType.StoredProcedure
                cmd_recupera_registros.Parameters.Add("@STR_IMP_EXP", SqlDbType.VarChar).Value = parametro
                cmd_recupera_registros.Parameters.Add("@INT_ID_ITEM", SqlDbType.Int).Value = gID
                cmd_recupera_registros.CommandText = "usp_OXIEMP_Solicita_Registro"
                con.Open()
                cmd_recupera_registros.ExecuteNonQuery()
                a = New SqlDataAdapter(cmd_recupera_registros)
                a.Fill(nDT)
                a.Dispose()
                cmd_recupera_registros.Dispose() : con.Close() : con.Dispose()
            End Using
            REM iniciamos la recuperacion de datos
            Try
                If nDT.Rows.Count > 0 Then
                    Dim r As DataRow = nDT.Rows(0)
                    REM Extraemos los datos y los vamos ordenando en el formulario
                    ID.Text = r("OXEXP004_ID_IN")
                    REM pais
                    Pais_txt.Text = r("OXEXP004_PaisDestino_ST")
                    pa = r("OXEXP004_PaisDestino_ST")
                    bPais = CBool(r("OXEXP004_PaisH_BT"))
                    REM importador
                    Exportador_txt.Text = r("OXEXP004_ExportadorH_ST")
                    exp = r("OXEXP004_ExportadorH_ST")
                    bExportador = CBool(r("OXEXP004_ExportadorH_BT"))
                    REM Familia
                    Familia_txt.Text = r("OXEXP004_Familia_ST")
                    fam = r("OXEXP004_Familia_ST")
                    bFamilia = CBool(r("OXEXP004_Familia_BT"))
                    REM Productos Identificados
                    Prod_Identi_txt.Text = r("OXEXP004_ProductoIdentificados_ST")
                    pi = r("OXEXP004_ProductoIdentificados_ST")
                    bProductos = CBool(r("OXEXP004_ProductoIdentificados_BT"))
                    REM Clasificacion 
                    Clasificacion_txt.Text = r("OXEXP004_Clasificacion_ST")
                    cls = r("OXEXP004_Clasificacion_ST")
                    bClasificacion = CBool(r("OXEXP004_Clasificacion_BT"))
                    REM Descripcion Quimica
                    Desc_Quim_txt.Text = r("OXEXP004_DescripcionQuimica_ST")
                    dq = r("OXEXP004_DescripcionQuimica_ST")
                    bDescQuim = CBool(r("OXEXP004_DescripcionQuimica_BT"))
                    REM Comprador 
                    Comprador_txt.Text = r("OXEXP004_CompradorH_ST")
                    cpdr = r("OXEXP004_CompradorH_ST")
                    bComprador = CBool(r("OXEXP004_CompradorH_BT"))
                    'prvh = r("OXIMP004_ProveedorHomologado_ST")
                    ''''''''''''''''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''
                    REM Validamos que pais se pueda modificar
                    If bPais = True And pa <> InfoInsuficiente Then
                        ddPais_Homologado.Enabled = False
                        ddPais_Homologado.BorderColor = Drawing.Color.Green
                        Pais_txt.BorderColor = Drawing.Color.Green
                        ddPais_Homologado.Items.Add(pa)
                    ElseIf pa = InfoInsuficiente Or bPais = False Then
                        ddPais_Homologado.Enabled = True
                        ddPais_Homologado.BorderColor = Drawing.Color.Red
                        Me.Renderiza_DropDownList("usp_OXIEMP_Genera_Lista_Paises", ddPais_Homologado)
                        'Me.Renderiza_ddPais_Homologado()
                    End If
                    REM el importador no se va a poder modificar, solo se podrá seleccionar su homologado
                    If bExportador = True And exp <> InfoInsuficiente Then
                        ddExportador_Homologado.Enabled = False
                        ddExportador_Homologado.BorderColor = Drawing.Color.Green
                        Exportador_txt.BorderColor = Drawing.Color.Green
                        ddExportador_Homologado.Items.Add(exp)
                    ElseIf exp = InfoInsuficiente Or bExportador = False Then
                        ddExportador_Homologado.Enabled = True
                        ddExportador_Homologado.BorderColor = Drawing.Color.Red
                        Me.Renderiza_DropDownList("usp_OXIEMP_Genera_Lista_Exportador", ddExportador_Homologado)
                        'Me.Renderiza_ddImportador_Homologado()
                    End If
                    REM Familia si puede agregar registros a mano o eligiendo desde el combo
                    REM si familia esta bien pero lo demas no entonces lo guardamos en una variable de sesion 
                    If bFamilia = True And fam <> InfoInsuficiente Then
                        Decision_Familia.Enabled = False
                        ddFamilias.BorderColor = Drawing.Color.Green
                        Familia_txt.BorderColor = Drawing.Color.Green
                        ddFamilias.Items.Add(fam)
                        If Not IsNothing(Session("Familia_")) Then
                            Session.Remove("Familia_")
                            Session.Add("Familia_", fam.ToString)
                            Decision_PI.Enabled = True
                            Decision_Clasificacion.Enabled = True
                        Else
                            Session.Add("Familia_", fam.ToString)
                            Decision_PI.Enabled = True
                            Decision_Clasificacion.Enabled = True
                        End If
                    ElseIf fam = InfoInsuficiente Or bFamilia = False Then
                        Decision_Familia.Enabled = True
                        ddFamilias.BorderColor = Drawing.Color.Red
                        Familia_txt.BorderColor = Drawing.Color.Red
                    End If
                    REM Productos Identificados
                    If bProductos = True And pi <> InfoInsuficiente Then
                        Decision_PI.Enabled = False
                        Prod_Identi_txt.BorderColor = Drawing.Color.Green
                        ddProd_Identificados.BorderColor = Drawing.Color.Green
                    ElseIf pi = InfoInsuficiente Or bProductos = False Then
                        REM La decision se mantiene como no elegible ya que depende de la familia
                        Decision_PI.Enabled = True
                        ddProd_Identificados.BorderColor = Drawing.Color.Red
                        Prod_Identi_txt.BorderColor = Drawing.Color.Red
                    End If
                    REM Clasificacion 
                    If bClasificacion = True And cls <> InfoInsuficiente Then
                        Decision_Clasificacion.Enabled = False
                        Clasificacion_txt.BorderColor = Drawing.Color.Green
                        ddClasificacion.BorderColor = Drawing.Color.Green
                    ElseIf cls = InfoInsuficiente Or bClasificacion = False Then
                        Decision_Clasificacion.Enabled = True
                        Clasificacion_txt.BorderColor = Drawing.Color.Red
                        ddClasificacion.BorderColor = Drawing.Color.Red
                    End If
                    REM Desc Quim 
                    If bDescQuim = True And dq <> InfoInsuficiente Then
                        Decision_DescQuim.Enabled = False
                        Desc_Quim_txt.BorderColor = Drawing.Color.Green
                        ddDesc_Quim.BorderColor = Drawing.Color.Green
                    ElseIf dq = InfoInsuficiente Or bDescQuim = False Then
                        Decision_DescQuim.Enabled = True
                        Desc_Quim_txt.BorderColor = Drawing.Color.Red
                        ddDesc_Quim.BorderColor = Drawing.Color.Red
                    End If
                    REM Comprador 
                    If bComprador = True And cpdr <> InfoInsuficiente Then
                        Comprador_txt.Enabled = False
                        Comprador_txt.BorderColor = Drawing.Color.Green
                        ddComprador_H.Enabled = False
                        ddComprador_H.BorderColor = Drawing.Color.Green
                        ddComprador_H.Items.Add(cpdr)
                    ElseIf cpdr = InfoInsuficiente Or bComprador = False Then
                        Comprador_txt.Enabled = True
                        Comprador_txt.BorderColor = Drawing.Color.Red
                        ddComprador_H.BorderColor = Drawing.Color.Red
                        ddComprador_H.Enabled = True
                        If ddComprador_H.Items.Count = 0 Then
                            Me.Renderiza_DropDownList("usp_OXIEMP_Genera_Lista_Comprador", ddComprador_H)
                        End If
                    End If
                End If
            Catch ex As Exception
                LabelError.Text = ex.Message.ToString : LabelError.Visible = True
                Elog.save(Me, ex.Message.ToString)
            Finally
                nDT.Dispose()
                Panel_Seleccion.Visible = False
                Panel_Seleccion.Dispose()
                PanelMain.Visible = True
            End Try
        Catch ex As Exception
            LabelError.Text = ex.Message.ToString : LabelError.Visible = True
            Elog.save(Me, ex.Message.ToString)
        End Try

    End Sub

    Protected Sub Decision_Familia_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles Decision_Familia.SelectedIndexChanged
        If Decision_Familia.SelectedValue = "Escribir" Then
            If Prod_Identi_txt.BorderColor <> Drawing.Color.Green And Clasificacion_txt.BorderColor <> Drawing.Color.Green Then
                ddProd_Identificados.Items.Clear() : ddProd_Identificados.Enabled = False : Decision_PI.ClearSelection()
                ddClasificacion.Items.Clear() : ddClasificacion.Enabled = False : Decision_Clasificacion.ClearSelection()
                Prod_Identi_txt.Text = String.Empty : Clasificacion_txt.Text = String.Empty
            End If
            ddFamilias.Enabled = False : ddFamilias.Items.Clear()
            Familia_txt.Enabled = True
            Familia_txt.Text = String.Empty
            Familia_txt.Focus()
            'ddFamilias.Items.Clear()
            If Prod_Identi_txt.BorderColor <> Drawing.Color.Green And Clasificacion_txt.BorderColor <> Drawing.Color.Green Then
                REM habilitamos la opcion de solo llenar por medio de texto Productos id y clase debido a dependencia
                Prod_Identi_txt.Enabled = True : Decision_PI.Visible = False
                Clasificacion_txt.Enabled = True : Decision_Clasificacion.Visible = False
            End If
        ElseIf Decision_Familia.SelectedValue = "Seleccionar" Then
            If Prod_Identi_txt.BorderColor <> Drawing.Color.Green And Clasificacion_txt.BorderColor <> Drawing.Color.Green Then
                Prod_Identi_txt.Enabled = False : Decision_PI.Visible = True
                Clasificacion_txt.Enabled = False : Decision_Clasificacion.Visible = True
            End If
            Familia_txt.Enabled = False
            ddFamilias.Enabled = True
            Me.Renderiza_DropDownList("usp_OXIEMP_Genera_Lista_Familia", ddFamilias)
        End If
    End Sub

    Protected Sub Decision_PI_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles Decision_PI.SelectedIndexChanged
        If Decision_PI.SelectedValue = "Escribir" Then
            Prod_Identi_txt.Enabled = True
            ddProd_Identificados.Enabled = False
            'ddProd_Identificados.Items.Clear()
        ElseIf Decision_PI.SelectedValue = "Seleccionar" Then
            Prod_Identi_txt.Enabled = False
            ddProd_Identificados.Enabled = True
            Me.Renderiza_DropDownList("usp_OXIEMP_Genera_Lista_ProductosIdentificados", ddProd_Identificados, "@FAMILIA", Session("Familia_").ToString)
        End If
    End Sub

    Protected Sub Decision_Clasificacion_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles Decision_Clasificacion.SelectedIndexChanged
        If Decision_Clasificacion.SelectedValue = "Escribir" Then
            Clasificacion_txt.Enabled = True
            ddClasificacion.Enabled = False
            'ddClasificacion.Items.Clear()
        ElseIf Decision_Clasificacion.SelectedValue = "Seleccionar" Then
            Clasificacion_txt.Enabled = False
            ddClasificacion.Enabled = True
            Me.Renderiza_DropDownList("usp_OXIEMP_Genera_Lista_Clasificacion", ddClasificacion, "@FAMILIA", Session("Familia_").ToString)
        End If
    End Sub

    Protected Sub Decision_DescQuim_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles Decision_DescQuim.SelectedIndexChanged
        If Decision_DescQuim.SelectedValue = "Escribir" Then
            Desc_Quim_txt.Enabled = True
            ddDesc_Quim.Enabled = False
            'ddDesc_Quim.Items.Clear()
        ElseIf Decision_DescQuim.SelectedValue = "Seleccionar" Then
            Desc_Quim_txt.Enabled = False
            ddDesc_Quim.Enabled = True
            Me.Renderiza_DropDownList("usp_OXIEMP_Genera_Lista_DescQuim", ddDesc_Quim, "@ORDEN", "EXP")
        End If
    End Sub

    Protected Sub ddFamilias_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddFamilias.SelectedIndexChanged
        ddProd_Identificados.Items.Clear() : ddProd_Identificados.Enabled = False : Decision_PI.ClearSelection()
        ddClasificacion.Items.Clear() : ddClasificacion.Enabled = False : Decision_Clasificacion.ClearSelection()
        Prod_Identi_txt.Enabled = False : Clasificacion_txt.Enabled = False
        Try
            If ddFamilias.SelectedValue <> "Selecciona una opción" Then
                If Prod_Identi_txt.BorderColor <> Drawing.Color.Green And Clasificacion_txt.BorderColor <> Drawing.Color.Green Then
                    If Not IsNothing(Session("Familia_")) Then
                        Session.Remove("Familia_")
                        Session.Add("Familia_", ddFamilias.SelectedValue.ToString)
                        Decision_PI.Enabled = True
                        Decision_Clasificacion.Enabled = True
                    Else
                        Session.Add("Familia_", ddFamilias.SelectedValue.ToString)
                        Decision_PI.Enabled = True
                        Decision_Clasificacion.Enabled = True
                    End If
                    REM Trasladar contenido del combo al texbox
                End If
            End If
            Familia_txt.Text = ddFamilias.SelectedValue.ToString
        Catch ex As Exception
            LabelError.Text = ex.Message.ToString : LabelError.Visible = True
            Elog.save(Me, ex.Message.ToString)
        End Try
    End Sub

    Protected Sub ddProd_Identificados_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddProd_Identificados.SelectedIndexChanged
        Prod_Identi_txt.Text = ddProd_Identificados.SelectedValue.ToString
    End Sub

    Protected Sub ddClasificacion_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddClasificacion.SelectedIndexChanged
        Clasificacion_txt.Text = ddClasificacion.SelectedValue.ToString
    End Sub

    Protected Sub ddDesc_Quim_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles ddDesc_Quim.SelectedIndexChanged
        Desc_Quim_txt.Text = ddDesc_Quim.SelectedValue.ToString
    End Sub

    Protected Sub CheckBox1_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Firmar_ConSangre.Visible = True
        Else
            Firmar_ConSangre.Visible = False
        End If
    End Sub

    Protected Sub Firmar_ConSangre_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles Firmar_ConSangre.Click
        Dim ResultTrans As Boolean = False
        'Dim ResultTrans As Integer = 0
        Using tUpdate As New TransactionScope
            Try
                Using con As New SqlConnection(cadenaconexion)
                    Dim cmd_update As SqlCommand = con.CreateCommand
                    cmd_update.CommandType = CommandType.StoredProcedure
                    cmd_update.Parameters.Add("@STR_IMP_EXP", SqlDbType.VarChar).Value = parametro
                    cmd_update.Parameters.Add("@INT_ID", SqlDbType.Int).Value = ID.Text
                    cmd_update.Parameters.Add("@PAIS_H", SqlDbType.VarChar).Value = ddPais_Homologado.SelectedValue
                    cmd_update.Parameters.Add("@PAIS_ST", SqlDbType.VarChar).Value = Pais_txt.Text
                    cmd_update.Parameters.Add("@EXPORTADORH", SqlDbType.VarChar).Value = ddExportador_Homologado.SelectedValue
                    cmd_update.Parameters.Add("@EXPORTADOR_R", SqlDbType.VarChar).Value = Exportador_txt.Text
                    cmd_update.Parameters.Add("@FAMILIA", SqlDbType.VarChar).Value = Familia_txt.Text
                    cmd_update.Parameters.Add("@PRODUCTOS", SqlDbType.VarChar).Value = Prod_Identi_txt.Text
                    cmd_update.Parameters.Add("@CLASIFICACION", SqlDbType.VarChar).Value = Clasificacion_txt.Text
                    cmd_update.Parameters.Add("@DESCRIP_QUIM", SqlDbType.VarChar).Value = Desc_Quim_txt.Text
                    cmd_update.Parameters.Add("@COMPRADOR_H", SqlDbType.VarChar).Value = ddComprador_H.SelectedValue
                    cmd_update.Parameters.Add("@COMPRADOR_ST", SqlDbType.VarChar).Value = Comprador_txt.Text
                    cmd_update.CommandText = "usp_OXIEMP_Exp_PreAnalisis_Actualiza_registro"
                    con.Open()
                    cmd_update.ExecuteNonQuery()
                    tUpdate.Complete()
                    Previsualiza.DataBind()
                    'Previsualiza.(SelectedRow -1).BackColor = Drawing.Color.Green
                    con.Close() : cmd_update.Dispose()
                End Using
            Catch ex As Exception
                tUpdate.Dispose()
                'Previsualiza.SelectedRow.BackColor = Drawing.Color.DarkOrange
                LabelError.Text = ex.Message.ToString : LabelError.Visible = True
                Elog.save(Me, ex.Message.ToString)
            Finally
                Dim parent As Object = PanelMain
                Me.ClearTextBox(parent)
                Panel_Seleccion.Visible = True
                PanelMain.Visible = False
                CheckBox1.Checked = False
                Firmar_ConSangre.Visible = False
            End Try
        End Using
    End Sub
End Class