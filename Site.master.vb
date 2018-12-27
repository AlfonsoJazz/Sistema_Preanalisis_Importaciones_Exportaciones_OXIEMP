Imports System.Configuration.ConfigurationManager

Partial Class Site
    Inherits System.Web.UI.MasterPage

    Private u As String = String.Empty

    Protected Sub NavigationMenu_MenuItemClick(sender As Object, e As System.Web.UI.WebControls.MenuEventArgs) Handles NavigationMenu.MenuItemClick

        'Select Case NavigationMenu.SelectedValue
        '    Case "Cerrar Sesión"
        '        Elog.save(Me, "El usuario " + Session("Usuario") + " ha cerrado sesión con éxito")
        '        Response.Write("Server event raised -- you clicked: " & Menu.MenuItemClickCommandName.ToString)
        '        Session.RemoveAll()
        '        Session.Abandon()
        '        'Session("USER") = Nothing
        '        FormsAuthentication.SignOut()
        '        FormsAuthentication.RedirectFromLoginPage("n_Usuario", False)
        '        Response.Redirect("~/Account/Login.aspx")
        '    Case "Exportaciones Pre análisis"
        '        Response.Write("Server event raised -- you clicked: " & Menu.MenuItemClickCommandName.ToString)
        '        Dim aSesiones() As String = {"usp_OXIEMP_Genera_Lista_DescQuim", "usp_OXIEMP_Genera_Lista_Clasificacion", _
        '                     "usp_OXIEMP_Genera_Lista_ProductosIdentificados", "usp_OXIEMP_Genera_Lista_Familia", _
        '                     "usp_OXIEMP_Genera_Lista_Comprador", "usp_OXIEMP_Genera_Lista_Paises", "usp_OXIEMP_Genera_Lista_Exportador"}
        '        For i As Integer = 0 To aSesiones.Count - 1
        '            If Not IsNothing(Session(aSesiones(i))) Then
        '                Session.RemoveAt(aSesiones(1))
        '            End If
        '        Next
        'End Select


        If NavigationMenu.SelectedValue = "Cerrar Sesión" Then
            Elog.save(Me, "El usuario " + Session("Usuario") + " ha cerrado sesión con éxito")
            Response.Write("Server event raised -- you clicked: " & Menu.MenuItemClickCommandName.ToString)
            Session.RemoveAll()
            Session.Abandon()
            'Session("USER") = Nothing
            FormsAuthentication.SignOut()
            FormsAuthentication.RedirectFromLoginPage("n_Usuario", False)
            Response.Redirect("~/Account/Login.aspx")
        End If
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim admins() As String = {AppSettings.Get("Admin1").ToString, AppSettings.Get("Admin2").ToString, _
                     AppSettings.Get("Admin3").ToString, AppSettings.Get("Admin4").ToString}
        Dim mnuItems As MenuItemCollection = NavigationMenu.Items
        Dim nuevoItem As New MenuItem

        If Session("Usuario") Is Nothing Then
            Session.RemoveAll()
            Session.Abandon()
            Response.Redirect("~/Account/Login.aspx")
        Else
            u = Session("Usuario").ToString
            UserName.Text = u
            If admins.Contains(u) Then
                UserName.Text = "[Admin] " + u
                AppSettings.Set("Sesion_Actual", "[Admin] " + u)
            End If
        End If
    End Sub
End Class

