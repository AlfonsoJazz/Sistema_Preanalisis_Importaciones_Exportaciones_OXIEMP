Imports Oxiteno.Seguridad.ActiveDirectory
Imports System.Configuration.ConfigurationManager
Imports Oxiteno.Seguridad.Cifrado
Imports System.Configuration

Partial Class Account_Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Response.AddHeader("pragma", "no-cache")
        Response.AddHeader("cache-control", "private")
        Response.CacheControl = "no-cache"
        Response.Cache.SetExpires(DateTime.Now.AddMinutes(-1))
        Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Cache.SetNoStore()
        If Request.QueryString("ReturnURL") IsNot Nothing Then
            Response.Redirect("~/Account/Login.aspx")
        End If
    End Sub

    Private Sub Autentica()
        Dim oCifrado As EncriptadorOX = New EncriptadorOX()
        Dim domainName As String = oCifrado.Desencriptar(ConfigurationManager.AppSettings("DomainName").ToString)
        Dim oTicket As FormsAuthenticationTicket
        Dim hash, path As String
        Dim cookie As HttpCookie
        Dim oAuth As LDAPAuthentication = New LDAPAuthentication()
        REM remover esta linea despues

        If oAuth.IsAuthenticatedSinGrupo(domainName, Me.txtUser.Text, Me.txtPassword.Text) = True Then
            FormsAuthentication.Initialize()
            oTicket = New FormsAuthenticationTicket(1, Me.txtUser.Text, DateTime.Now, DateTime.Now.AddMinutes(10), True, Me.txtUser.Text)
            hash = FormsAuthentication.Encrypt(oTicket)
            cookie = New HttpCookie(FormsAuthentication.FormsCookieName, hash)
            If oTicket.IsPersistent Then
                cookie.Expires = oTicket.Expiration
            End If
            Response.Cookies.Add(cookie)
            path = FormsAuthentication.GetRedirectUrl(txtUser.Text, oTicket.IsPersistent)
            AppSettings.Set("n_Usuario", oAuth.Nombre)
            If Session("Usuario") IsNot Nothing Then
                ELog.save(Me, "Se ha cerrado la sesión del usuario: " + Session("Usuario").ToString + " por ingresar de nuevo al sistema")
                Session.RemoveAll()
                Session.Add("Usuario", oAuth.Nombre)
                Session("Usuario") = oAuth.Nombre
            Else
                Session.Add("Usuario", oAuth.Nombre)
                Session("Usuario") = oAuth.Nombre
            End If
            ELog.save(Me, "El usuario " + Session("Usuario").ToString + " accedió al sistema")

            Server.Transfer(path)
        ElseIf oAuth.Nombre = String.Empty Then
            Me.lblResults.Visible = True
            Me.lblResults.Text = "Usuario y/o Password erróneos. Por favor intente nuevamente."
        Else
            Me.lblResults.Visible = True
            Me.lblResults.Text = "Acceso denegado."
        End If
    End Sub

    Protected Sub btnEntrar_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles btnEntrar.Click
        Me.Autentica()
    End Sub
End Class
