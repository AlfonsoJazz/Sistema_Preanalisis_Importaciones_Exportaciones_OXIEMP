Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Web
Imports System.IO
Imports System.Diagnostics
Public Class Elog
    Public Shared Sub save(ByVal obj As Object, ByVal message As String)
        Dim fecha As String = System.DateTime.Now.ToString("yyyyMMdd")
        Dim hora As String = System.DateTime.Now.ToString("HH:mm:ss")
        Dim path As String = HttpContext.Current.Request.MapPath("~/log/" & fecha & ".txt")
        Dim sw As StreamWriter = New StreamWriter(Path, True)
        Dim stacktrace As StackTrace = New StackTrace()
        sw.WriteLine(obj.[GetType]().FullName & " " & hora)
        'sw.WriteLine(stacktrace.GetFrame(1).GetMethod().Name & " - " & ex.message)
        sw.WriteLine(stacktrace.GetFrame(1).GetMethod().Name & " - " & message.ToString)
        sw.WriteLine("")
        sw.Flush()
        sw.Close()
    End Sub
End Class
