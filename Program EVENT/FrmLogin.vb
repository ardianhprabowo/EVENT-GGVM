Option Strict Off
Imports System.Data.Odbc
Imports DevExpress.XtraSplashScreen
Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Reflection
Imports System.Windows.Forms
Imports System.Threading
Imports AutoUpdaterDotNET
Public Class FrmLogin

    'Public Sub New()
    '    InitializeComponent()
    'End Sub
    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        Me.BackColor = Color.White
        Dim s As String
        Dim oMD5 As CMD5
        Dim pass As String
        Dim f As New MainMenu
        Dim tbl As DataTable

        GGVM_conn()

        s = ""
        s = s & " select count(*)as ada from user"
        s = s & " where username = '" & Trim(TUsername.Text) & "'"
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "user")
        ProgressBar.Value = "20"
        DataGridView1.DataSource = ds.Tables("user")
        If DataGridView1.Item(0, 0).Value = "1" Then
            oMD5 = New CMD5
            pass = oMD5.computeHash(TPassword.Text)
            TextBox1.Text = pass
            ProgressBar.Value = "30"
            s = ""
            s = s & " select count(*)as ada from user"
            s = s & " where username = '" & Trim(TUsername.Text) & "'"
            s = s & " and password = '" & pass & "'"
            da = New Odbc.OdbcDataAdapter(s, conn)
            ds = New DataSet
            ds.Clear()
            da.Fill(ds, "user")
            DataGridView1.DataSource = ds.Tables("user")
            If DataGridView1.Item(0, 0).Value = "1" Then
                userid = TUsername.Text
                s = ""
                s = s & " select level,iddivisi from user"
                s = s & " where username = '" & Trim(TUsername.Text) & "'"
                s = s & " and password = '" & pass & "'"
                da = New Odbc.OdbcDataAdapter(s, conn)
                ds.Clear()
                tbl = New DataTable
                tbl.Clear()
                da.Fill(tbl)
                LevelUser = tbl.Rows(0)("level")
                DivUser = tbl.Rows(0)("iddivisi")
                ProgressBar.Value = "50"
                If DivUser = "0" Then
                    Divisi = "Super User"
                Else
                    s = "select * from divisi where id_divisi = '" & DivUser & "'"
                    cmd = New OdbcCommand(s, conn)
                    dr = cmd.ExecuteReader
                    dr.Read()
                    Divisi = dr.GetString(1)
                End If
                ProgressBar.Value = "70"
                If DivUser = "17" Or DivUser = "2" Or DivUser = "18" Or DivUser = "0" Then
                Else
                    MsgBox("Anda Bukan Divisi EVENT/EXHIBITION/ACTIVATION...coba lagi !!!")
                    Exit Sub
                End If
                ProgressBar.Value = "100"
                Me.Hide()
                f.Show()
                f.LoginUser.Caption = userid
                f.NmDiv.Caption = Divisi
            Else
                MsgBox("Password Salah...coba lagi !!!")
                ProgressBar.Value = "0"
            End If
        Else
            MsgBox("Username Salah...coba lagi !!!")
            TUsername.Focus()
            ProgressBar.Value = "0"
        End If
    End Sub

    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SplashScreenManager.ShowForm(GetType(SplashScreen))
        For i As Integer = 1 To 100
            Thread.Sleep(40)
        Next
        SplashScreenManager.CloseForm()
        Timer1.Enabled = True
        AutoUpdater.Start("http://srv.geogiven.co.id/updateinhouseapp/event-pe/version.xml")
        AutoUpdater.DownloadPath = Environment.CurrentDirectory
        ' AutoUpdater.Mandatory = True
        AutoUpdater.InstalledVersion = New Version("2.6")
        AutoUpdater.Synchronous = True
        AutoUpdater.ShowSkipButton = False
        AutoUpdater.ShowRemindLaterButton = False
        TUsername.Focus()
        TUsername.Select()
    End Sub
    Private Sub FrmLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'If MsgBox("Are you sure you want to exit?",
        '        MsgBoxStyle.YesNo, "Exit") = MsgBoxResult.No Then
        '    e.Cancel = True
        'End If
        '  Me.Close()
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles BtnCancel.Click
        Me.Close()
    End Sub
    Private Sub TUsername_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TUsername.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            TPassword.Focus()
        End If
    End Sub
    Private Sub TPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TPassword.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            Call BtnLogin_Click(sender, e)
        End If
    End Sub
End Class