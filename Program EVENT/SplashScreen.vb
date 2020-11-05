Public Class SplashScreen
    Sub New
        InitializeComponent()
        Me.labelCopyright.Text = "Copyright © 2010-" & DateTime.Now.Year.ToString()
    End Sub

    Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
        MyBase.ProcessCommand(cmd, arg)
    End Sub

    Private Sub SplashScreen_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        FrmLogin.TUsername.Focus()
    End Sub

    Public Enum SplashScreenCommand
        SomeCommandId
    End Enum
End Class
