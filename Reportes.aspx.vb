Imports System.Configuration.ConfigurationManager
Imports System.Data
Imports System.Data.SqlClient
Imports SpreadsheetLight
Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Spreadsheet
Imports System.IO

Partial Class Reportes
    Inherits System.Web.UI.Page
    Private cadenaconexion As String = ConfigurationManager.ConnectionStrings("ZOXIMPEXPConnectionString").ConnectionString
    Private statusReporte As Boolean

    Protected Sub RadioButtonListOrigenDatos_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles RadioButtonListOrigenDatos.SelectedIndexChanged
        Dim Tabla_consulta As String = String.Empty
        DropDownListAño.Items.Clear()
        DropDownListMes.Items.Clear()
        DropDownListFraccion.Items.Clear()
        ErrorL.Text = String.Empty
        Try
            Select Case RadioButtonListOrigenDatos.SelectedValue
                Case "OXEXP002_FraccionModificado"
                    Tabla_consulta = "OXEXP002_FraccionModificado"
                    Me.GeneraListaAño(Tabla_consulta)
                    Tabla_consulta = String.Empty
                Case "OXIMP002_FraccionModificado"
                    Tabla_consulta = "OXIMP002_FraccionModificado"
                    Me.GeneraListaAño(Tabla_consulta)
                    Tabla_consulta = String.Empty
                Case "OXEXP004_FraccionPreAnalisis"
                    Tabla_consulta = "OXEXP004_FraccionPreAnalisis"
                    Me.GeneraListaAño(Tabla_consulta)
                    Tabla_consulta = String.Empty
                Case "OXIMP004_FraccionPreAnalisis"
                    Tabla_consulta = "OXIMP004_FraccionPreAnalisis"
                    Me.GeneraListaAño(Tabla_consulta)
                    Tabla_consulta = String.Empty
            End Select
        Catch ex As Exception
            ErrorL.Text = ex.Message.ToString
            Elog.save(Me, ex.Message.ToString)
        End Try
    End Sub

    Private Sub GeneraListaAño(ByRef Parametro As String)
        ErrorL.Text = String.Empty
        Try
            Using con As New SqlConnection(cadenaconexion)
                Dim cmd_año As SqlCommand = con.CreateCommand
                Dim rAño As SqlDataReader = Nothing
                cmd_año.CommandType = CommandType.StoredProcedure
                cmd_año.Parameters.Add("@STR_IMPORT_EXPORT", SqlDbType.VarChar).Value = Parametro.ToString
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
        ButtonReporte.Visible = False
        Try
            If DropDownListAño.SelectedValue <> "Selecciona una opción" Then
                Using con_mes As New SqlConnection(cadenaconexion)
                    Dim cmd_mes As SqlCommand = con_mes.CreateCommand
                    Dim rMes As SqlDataReader = Nothing
                    cmd_mes.CommandType = CommandType.StoredProcedure
                    cmd_mes.Parameters.Add("@STR_IMPORT_EXPORT", SqlDbType.VarChar).Value = RadioButtonListOrigenDatos.SelectedValue
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
        ButtonReporte.Visible = False
        Try
            If DropDownListAño.SelectedValue <> "Selecciona una opción" Then
                If DropDownListMes.SelectedValue <> "Selecciona una opción" Then
                    Using conn As New SqlConnection(cadenaconexion)
                        Dim cmd_frac As SqlCommand = conn.CreateCommand
                        Dim rFrac As SqlDataReader = Nothing
                        cmd_frac.CommandType = CommandType.StoredProcedure
                        cmd_frac.Parameters.Add("@STR_IMPORT_EXPORT", SqlDbType.VarChar).Value = RadioButtonListOrigenDatos.SelectedValue
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
            ButtonReporte.Visible = True
        Else
            ButtonReporte.Visible = False
        End If
    End Sub

    Protected Sub ButtonReporte_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles ButtonReporte.Click
        ErrorL.Text = String.Empty
        Dim rTabla As String = RadioButtonListOrigenDatos.SelectedValue.ToString
        Dim rFracion As String = DropDownListFraccion.SelectedValue.ToString
        Try
            Using con_reporte As New SqlConnection(cadenaconexion)
                Dim cmd_reporte As SqlCommand = con_reporte.CreateCommand
                Dim rDir As String = Server.MapPath("~/Reportes/").ToString & rTabla & rFracion & ".xlsx"
                Dim rDT As New DataTable
                Dim rAdaptador As SqlDataAdapter
                Dim xlsReporte As SLDocument = New SLDocument()
                Dim fInfo As FileInfo
                Dim dirInfo As DirectoryInfo
                cmd_reporte.CommandType = CommandType.StoredProcedure
                cmd_reporte.Parameters.Add("@STR_ORIGEN", SqlDbType.VarChar).Value = rTabla
                cmd_reporte.Parameters.Add("@INT_AÑO", SqlDbType.Int).Value = Convert.ToInt32(DropDownListAño.SelectedValue)
                cmd_reporte.Parameters.Add("@INT_MES", SqlDbType.Int).Value = Convert.ToInt32(DropDownListMes.SelectedValue)
                cmd_reporte.Parameters.Add("@INT_FRACCION", SqlDbType.Int).Value = Convert.ToInt32(DropDownListFraccion.SelectedValue)
                cmd_reporte.CommandText = "usp_OXIEMP_Genera_Reporte"
                con_reporte.Open()
                cmd_reporte.ExecuteNonQuery()
                rAdaptador = New SqlDataAdapter(cmd_reporte)
                rAdaptador.Fill(rDT)
                rAdaptador.Dispose() : cmd_reporte.Dispose() : con_reporte.Close() : con_reporte.Dispose()
                If rDT.Rows.Count <> 0 Then
                    xlsReporte.ImportDataTable("A1", rDT, True)
                    dirInfo = New DirectoryInfo(Server.MapPath("~/Reportes/"))
                    'Primero vaciamos el contenido de la carpeta reportes para no estar generando archivos a lo loco
                    If dirInfo.GetFiles.Count <> 0 Then
                        For Each File In dirInfo.GetFiles
                            File.Delete()
                        Next
                    End If
                    ' despues validamos si existe aun que es por seguridad porque se supone que los acabamos de borrar
                    fInfo = New FileInfo(rDir)
                    'If fInfo.Exists Then
                    '    File.Delete(rDir)
                    '    xlsReporte.SaveAs(rDir)
                    'Else
                    xlsReporte.SaveAs(rDir)
                    'End If
                    statusReporte = True
                    REM borramos todo antes de mandar el reporte 
                Else
                    ErrorL.Text = "Error: Reporte vacio"
                    Elog.save(Me, "Error: Reporte vacio")
                    statusReporte = False
                End If
                xlsReporte.Dispose() : rDT.Dispose()
            End Using
        Catch ex As Exception
            ErrorL.Text = ex.Message.ToString
            Elog.save(Me, ex.Message.ToString)
            statusReporte = False
        Finally
            If statusReporte = True Then
                Response.ContentType = "application/ms-excel"
                'Response.ContentEncoding = System.Text.Encoding.UTF8
                Response.AddHeader("Content-Disposition", "attachment;filename=" & rTabla.ToString & rFracion & ".xlsx")
                Response.ClearContent()
                Response.WriteFile(Server.MapPath("~/Reportes/").ToString & rTabla.ToString & rFracion & ".xlsx")
                Response.Flush()
                Response.End()
            Else
                ButtonReporte.Visible = False
                RadioButtonListOrigenDatos.ClearSelection()
                DropDownListAño.Items.Clear()
                DropDownListMes.Items.Clear()
                DropDownListFraccion.Items.Clear()
                ErrorL.Text = "Error"
                Elog.save(Me, "Error")
            End If
        End Try
    End Sub
End Class
