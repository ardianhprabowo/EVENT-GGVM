Imports AutoUpdaterDotNET

Public Class SplashScreen
    Sub New()
        InitializeComponent()
        Me.labelCopyright.Text = "Copyright © 2010-" & DateTime.Now.Year.ToString()
    End Sub
    Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
        MyBase.ProcessCommand(cmd, arg)
    End Sub
    Public Enum SplashScreenCommand
        SomeCommandId
    End Enum

    Private Sub SplashScreen_Load(sender As Object, e As EventArgs) Handles Me.Load
        AutoUpdater.Start("http://srv.geogiven.co.id/updateinhouseapp/event-pe/version.xml")
        AutoUpdater.DownloadPath = Environment.CurrentDirectory
        ' AutoUpdater.Mandatory = True
        AutoUpdater.InstalledVersion = New Version("4.0")
        AutoUpdater.Synchronous = True
        AutoUpdater.ShowSkipButton = False
        AutoUpdater.ShowRemindLaterButton = False
    End Sub
End Class
