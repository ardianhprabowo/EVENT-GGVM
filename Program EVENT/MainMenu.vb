Option Strict Off
Imports System.Threading
Imports AutoUpdaterDotNET
Public Class MainMenu
    Inherits DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    Public Sub New()
        InitializeComponent()
    End Sub
    Private Sub MainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MenuActive()
        Label1.Text = ShowVertical(Label1.Text)
		Timer1.Enabled = True
        AutoUpdater.Start("http://helpdesk.geogiven.co.id/program/version.xml")
        'AutoUpdater.ShowUpdateForm()
        AutoUpdater.DownloadPath = Environment.CurrentDirectory
        AutoUpdater.Mandatory = True
    End Sub
    Private m_intMarqueeCounter As Integer = 1
    Private m_bolMarqueeIncrementUp As Boolean = True
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Label1.Location.Y + Label1.Height < 0 Then
            Label1.Location = New Point(Label1.Location.X, Panel1.Height)
        Else
            Label1.Location = New Point(Label1.Location.X, Label1.Location.Y - 4)
        End If
    End Sub
    Private Function ShowVertical(ByVal sMyString As String) As String
        Dim sTheString As String = ""
        Dim i As Long
        For i = 1 To Len(sMyString)
            If i < Len(sMyString) Then
                sTheString = sTheString + Mid$(sMyString, i, 1) & vbCrLf
            Else
                sTheString = sTheString + Mid$(sMyString, i, 1)
            End If
        Next
        ShowVertical = sTheString
    End Function
    Private Sub MenuActive()
        If DivUser = CInt("2") Then
            Menu_Event.Enabled = True
        ElseIf DivUser = CInt("17") Then
            Menu_Exhibition.Enabled = True
        ElseIf DivUser = CInt("18") Then
            Menu_Activation.Enabled = True
        Else
            Menu_Event.Enabled = True
            Menu_Exhibition.Enabled = True
            Menu_Activation.Enabled = True
        End If
    End Sub

    Protected Overrides ReadOnly Property ExtendNavigationControlToFormTitle As Boolean
        Get
            Return False
        End Get
    End Property

    Private Sub M_Barang_Click(sender As Object, e As EventArgs) Handles M_Barang.Click
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is FrmBarang Then
                frm.Activate()
                Return
            End If
        Next
        SSManager.ShowWaitForm()
        For i As Integer = 1 To 100
            SSManager.SetWaitFormDescription(i.ToString() & "%")
			Thread.Sleep(20)
		Next
        SSManager.CloseWaitForm()
        Dim f As New FrmBarang
        If Not FluentContainer.Controls.Contains(f) Then
            f.TopLevel = False
            FluentContainer.Controls.Add(f)
            f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            f.Dock = DockStyle.Fill
            f.BringToFront()
            f.Show()
        Else
            Return
        End If
    End Sub
    Private Sub PE_OpsEvn_Click(sender As Object, e As EventArgs) Handles PE_OpsEvn.Click
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is FrmPEEvn Then
                frm.Activate()
                Return
            End If
        Next
        SSManager.ShowWaitForm()
        For i As Integer = 1 To 100
            SSManager.SetWaitFormDescription(i.ToString() & "%")
			Thread.Sleep(20)
		Next
        SSManager.CloseWaitForm()
        Dim f As New FrmPEEvn
        If Not FluentContainer.Controls.Contains(f) Then
            f.TopLevel = False
            FluentContainer.Controls.Add(f)
            f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            f.Dock = DockStyle.Fill
            f.TidJenisPE.Text = "1"
            f.BringToFront()
            f.Show()
        Else
            Return
        End If
    End Sub
    Private Sub PE_BoothEvn_Click(sender As Object, e As EventArgs) Handles PE_BoothEvn.Click
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is FrmPEEvn Then
                frm.Activate()
                Return
            End If
        Next
        SSManager.ShowWaitForm()
        For i As Integer = 1 To 100
            SSManager.SetWaitFormDescription(i.ToString() & "%")
			Thread.Sleep(20)
		Next
        SSManager.CloseWaitForm()
        Dim f As New FrmPEEvn
        If Not FluentContainer.Controls.Contains(f) Then
            f.TopLevel = False
            FluentContainer.Controls.Add(f)
            f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            f.Dock = DockStyle.Fill
            f.TidJenisPE.Text = "2"
            f.BringToFront()
            f.Show()
        Else
            Return
        End If
    End Sub
    Private Sub MainMenu_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
		For i = System.Windows.Forms.Application.OpenForms.Count - 1 To 1 Step -1
			Dim form As Form = System.Windows.Forms.Application.OpenForms(i)
			form.Close()
		Next i
		FrmLogin.Close()
	End Sub

    Private Sub MainMenu_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
		Environment.Exit(1)
		FrmLogin.Close()
	End Sub

    Private Sub PE_RegExh_Click(sender As Object, e As EventArgs) Handles PE_RegExh.Click
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is FrmPEEvn Then
                frm.Activate()
                Return
            End If
        Next
        SSManager.ShowWaitForm()
        For i As Integer = 1 To 100
            SSManager.SetWaitFormDescription(i.ToString() & "%")
			Thread.Sleep(20)
		Next
        SSManager.CloseWaitForm()
        Dim f As New FrmPEEvn
        If Not FluentContainer.Controls.Contains(f) Then
            f.TopLevel = False
            FluentContainer.Controls.Add(f)
            f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            f.Dock = DockStyle.Fill
            f.TidJenisPE.Text = "4"
            f.BringToFront()
            f.Show()
        Else
            Return
        End If
    End Sub

    Private Sub PE_PhotoExh_Click(sender As Object, e As EventArgs) Handles PE_PhotoExh.Click
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is FrmPEEvn Then
                frm.Activate()
                Return
            End If
        Next
        SSManager.ShowWaitForm()
        For i As Integer = 1 To 100
            SSManager.SetWaitFormDescription(i.ToString() & "%")
			Thread.Sleep(20)
		Next
        SSManager.CloseWaitForm()
        Dim f As New FrmPEEvn
        If Not FluentContainer.Controls.Contains(f) Then
            f.TopLevel = False
            FluentContainer.Controls.Add(f)
            f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            f.Dock = DockStyle.Fill
            f.TidJenisPE.Text = "3"
            f.BringToFront()
            f.Show()
        Else
            Return
        End If
    End Sub

    Private Sub M_MintaPO_Click(sender As Object, e As EventArgs) Handles M_MintaPO.Click
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is FrmMaintPO Then
                frm.Activate()
                Return
            End If
        Next
        SSManager.ShowWaitForm()
        For i As Integer = 1 To 100
            SSManager.SetWaitFormDescription(i.ToString() & "%")
            Thread.Sleep(40)
        Next
        SSManager.CloseWaitForm()
        Dim f As New FrmMaintPO
        If Not FluentContainer.Controls.Contains(f) Then
            f.TopLevel = False
            FluentContainer.Controls.Add(f)
            f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            f.Dock = DockStyle.Fill
            f.BringToFront()
            f.Show()
        Else
            Return
        End If
    End Sub

    Private Sub B_LPJ_Click(sender As Object, e As EventArgs) Handles B_LPJ.Click
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is FrmLPJ Then
                frm.Activate()
                Return
            End If
        Next
        SSManager.ShowWaitForm()
        For i As Integer = 1 To 100
            SSManager.SetWaitFormDescription(i.ToString() & "%")
			Thread.Sleep(20)
		Next
        SSManager.CloseWaitForm()
        Dim f As New FrmLPJ
        If Not FluentContainer.Controls.Contains(f) Then
            f.TopLevel = False
            FluentContainer.Controls.Add(f)
            f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            f.Dock = DockStyle.Fill
            f.BringToFront()
            f.Show()
        Else
            Return
        End If
    End Sub

    Private Sub B_HisLPJ_Click(sender As Object, e As EventArgs) Handles B_HisLPJ.Click
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is FrmHistoryLPJ Then
                frm.Activate()
                Return
            End If
        Next
        SSManager.ShowWaitForm()
        For i As Integer = 1 To 100
            SSManager.SetWaitFormDescription(i.ToString() & "%")
			Thread.Sleep(20)
		Next
        SSManager.CloseWaitForm()
        Dim f As New FrmHistoryLPJ
        If Not FluentContainer.Controls.Contains(f) Then
            f.TopLevel = False
            FluentContainer.Controls.Add(f)
            f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            f.Dock = DockStyle.Fill
            f.BringToFront()
            f.Show()
        Else
            Return
        End If
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        For i = System.Windows.Forms.Application.OpenForms.Count - 1 To 1 Step -1
            Dim form As Form = System.Windows.Forms.Application.OpenForms(i)
            form.Close()
        Next i
        Me.Close()
        Exit Sub
    End Sub

    Private Sub M_Penawaran_Click(sender As Object, e As EventArgs) Handles M_Penawaran.Click

    End Sub

	Private Sub P_Gudang_Click(sender As Object, e As EventArgs) Handles P_Gudang.Click
		For Each frm As Form In Application.OpenForms
			If TypeOf frm Is FrmPermintaan Then
				frm.Activate()
				Return
			End If
		Next
		SSManager.ShowWaitForm()
		For i As Integer = 1 To 100
			SSManager.SetWaitFormDescription(i.ToString() & "%")
			Thread.Sleep(20)
		Next
		SSManager.CloseWaitForm()
		Dim f As New FrmPermintaan
		If Not FluentContainer.Controls.Contains(f) Then
			f.TopLevel = False
			FluentContainer.Controls.Add(f)
			f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
			f.Dock = DockStyle.Fill
			f.BringToFront()
			f.Show()
		Else
			Return
		End If
	End Sub
	Private Sub P_Paketing_Click(sender As Object, e As EventArgs) Handles P_Paketing.Click
		For Each frm As Form In Application.OpenForms
			If TypeOf frm Is FrmTampilSPGPengajuan Then
				frm.Activate()
				Return
			End If
		Next
		SSManager.ShowWaitForm()
		For i As Integer = 1 To 100
			SSManager.SetWaitFormDescription(i.ToString() & "%")
			Thread.Sleep(20)
		Next
		SSManager.CloseWaitForm()
		Dim f As New FrmTampilSPGPengajuan
		If Not FluentContainer.Controls.Contains(f) Then
			f.TopLevel = False
			FluentContainer.Controls.Add(f)
			f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
			f.Dock = DockStyle.Fill
			f.BringToFront()
			f.Show()
		Else
			Return
		End If
	End Sub
	Private Sub P_Pengajuan_Click(sender As Object, e As EventArgs) Handles P_Pengajuan.Click
		For Each frm As Form In Application.OpenForms
			If TypeOf frm Is FrmTampilAllPengajuan Then
				frm.Activate()
				Return
			End If
		Next
		SSManager.ShowWaitForm()
		For i As Integer = 1 To 100
			SSManager.SetWaitFormDescription(i.ToString() & "%")
			Thread.Sleep(20)
		Next
		SSManager.CloseWaitForm()
		Dim f As New FrmTampilAllPengajuan
		If Not FluentContainer.Controls.Contains(f) Then
			f.TopLevel = False
			FluentContainer.Controls.Add(f)
			f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
			f.Dock = DockStyle.Fill
			f.BringToFront()
			f.Show()
		Else
			Return
		End If
	End Sub
	Private Sub H_Pengajuan_Click(sender As Object, e As EventArgs) Handles H_Pengajuan.Click
		For Each frm As Form In Application.OpenForms
			If TypeOf frm Is FrmHistoryMaju Then
				frm.Activate()
				Return
			End If
		Next
		SSManager.ShowWaitForm()
		For i As Integer = 1 To 100
			SSManager.SetWaitFormDescription(i.ToString() & "%")
			Thread.Sleep(20)
		Next
		SSManager.CloseWaitForm()
		Dim f As New FrmHistoryMaju
		If Not FluentContainer.Controls.Contains(f) Then
			f.TopLevel = False
			FluentContainer.Controls.Add(f)
			f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
			f.Dock = DockStyle.Fill
			f.BringToFront()
			f.Show()
		Else
			Return
		End If
	End Sub
	Private Sub B_AccLPJ_Click(sender As Object, e As EventArgs) Handles B_AccLPJ.Click
		For Each frm As Form In Application.OpenForms
			If TypeOf frm Is FrmACCLPJ Then
				frm.Activate()
				Return
			End If
		Next
		SSManager.ShowWaitForm()
		For i As Integer = 1 To 100
			SSManager.SetWaitFormDescription(i.ToString() & "%")
			Thread.Sleep(20)
		Next
		SSManager.CloseWaitForm()
		Dim f As New FrmACCLPJ
		If Not FluentContainer.Controls.Contains(f) Then
			f.TopLevel = False
			FluentContainer.Controls.Add(f)
			f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
			f.Dock = DockStyle.Fill
			f.BringToFront()
			f.Show()
		Else
			Return
		End If
	End Sub
	Private Sub PE_EventAct_Click(sender As Object, e As EventArgs) Handles PE_EventAct.Click
		For Each frm As Form In Application.OpenForms
			If TypeOf frm Is FrmActPE Then
				frm.Activate()
				Return
			End If
		Next
		SSManager.ShowWaitForm()
		For i As Integer = 1 To 100
			SSManager.SetWaitFormDescription(i.ToString() & "%")
			Thread.Sleep(20)
		Next
		SSManager.CloseWaitForm()
		Dim f As New FrmActPE
		If Not FluentContainer.Controls.Contains(f) Then
			f.TopLevel = False
			FluentContainer.Controls.Add(f)
			f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
			f.Dock = DockStyle.Fill
			f.TidJenisPE.Text = "5"
			f.DetailEvent.PageVisible = True
			f.BringToFront()
			f.Show()
		Else
			Return
		End If
	End Sub
	Private Sub PE_ProjectAct_Click(sender As Object, e As EventArgs) Handles PE_ProjectAct.Click
		For Each frm As Form In Application.OpenForms
			If TypeOf frm Is FrmActPE Then
				frm.Activate()
				Return
			End If
		Next
		SSManager.ShowWaitForm()
		For i As Integer = 1 To 100
			SSManager.SetWaitFormDescription(i.ToString() & "%")
			Thread.Sleep(20)
		Next
		SSManager.CloseWaitForm()
		Dim f As New FrmActPE
		If Not FluentContainer.Controls.Contains(f) Then
			f.TopLevel = False
			FluentContainer.Controls.Add(f)
			f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
			f.Dock = DockStyle.Fill
			f.TidJenisPE.Text = "6"
			f.DetailProject.PageVisible = True
			f.BringToFront()
			f.Show()
		Else
			Return
		End If
	End Sub
	Private Sub PE_InstoreAct_Click(sender As Object, e As EventArgs) Handles PE_InstoreAct.Click
		For Each frm As Form In Application.OpenForms
			If TypeOf frm Is FrmActPE Then
				frm.Activate()
				Return
			End If
		Next
		SSManager.ShowWaitForm()
		For i As Integer = 1 To 100
			SSManager.SetWaitFormDescription(i.ToString() & "%")
			Thread.Sleep(20)
		Next
		SSManager.CloseWaitForm()
		Dim f As New FrmActPE
		If Not FluentContainer.Controls.Contains(f) Then
			f.TopLevel = False
			FluentContainer.Controls.Add(f)
			f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
			f.Dock = DockStyle.Fill
			f.TidJenisPE.Text = "7"
			f.DetailInstore.PageVisible = True
			f.BringToFront()
			f.Show()
		Else
			Return
		End If
	End Sub

	Private Sub Acc_Pengajuan_Click(sender As Object, e As EventArgs) Handles Acc_Pengajuan.Click
		For Each frm As Form In Application.OpenForms
			If TypeOf frm Is FrmAccPengajuan Then
				frm.Activate()
				Return
			End If
		Next
		SSManager.ShowWaitForm()
		For i As Integer = 1 To 100
			SSManager.SetWaitFormDescription(i.ToString() & "%")
			Thread.Sleep(20)
		Next
		SSManager.CloseWaitForm()
		Dim f As New FrmAccPengajuan
		If Not FluentContainer.Controls.Contains(f) Then
			f.TopLevel = False
			FluentContainer.Controls.Add(f)
			f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
			f.Dock = DockStyle.Fill
			f.BringToFront()
			f.Show()
		Else
			Return
		End If
	End Sub

	Private Sub M_Kontrak_Click(sender As Object, e As EventArgs) Handles M_Kontrak.Click
		For Each frm As Form In Application.OpenForms
			If TypeOf frm Is FrmKontrak Then
				frm.Activate()
				Return
			End If
		Next
		SSManager.ShowWaitForm()
		For i As Integer = 1 To 100
			SSManager.SetWaitFormDescription(i.ToString() & "%")
			Thread.Sleep(20)
		Next
		SSManager.CloseWaitForm()
		Dim f As New FrmKontrak
		If Not FluentContainer.Controls.Contains(f) Then
			f.TopLevel = False
			FluentContainer.Controls.Add(f)
			f.FormBorderStyle = Windows.Forms.FormBorderStyle.None
			f.Dock = DockStyle.Fill
			f.NavImportKontrak.PageVisible = False
			f.BringToFront()
			f.Show()
		Else
			Return
		End If
	End Sub

	Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

	End Sub
End Class
