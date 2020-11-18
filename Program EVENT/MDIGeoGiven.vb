Imports System.Data.Odbc
Imports System.Threading
Imports AutoUpdaterDotNET
Public Class MDIGeoGiven

#Region "Kondisi"
    Private Sub Logout()
        Rib_AplMenu.Visible = True
    End Sub
    Private Sub Login()
        Rib_AplMenu.Visible = True
        If LevelUser = 0 And DivUser = 0 Then
            Group_Control.Enabled = True
            Group_Transaksi.Enabled = True
            Group_Produksi.Enabled = True
            Group_Internal.Enabled = True
            Group_LPJ.Enabled = True
            Group_Event.Enabled = True
        ElseIf DivUser = 1 & DivUser = 3 Then
            Group_Produksi.Enabled = True
            Group_Control.Enabled = True
            With Group_Control
                SubUser_Create.Enabled = False
            End With
            Group_Transaksi.Enabled = True
            With Group_Transaksi
                Sub_BuatPE.Enabled = True
                Sub_DataPE.Enabled = True
                Sub_POKlien.Enabled = True
            End With

        End If
    End Sub
#End Region
    Private Sub SubUser_Create_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SubUser_Create.ItemClick
        'Dim f As FrmUserLogin = New FrmUserLogin
        'f.MdiParent = Me
        'f.Show()
    End Sub

    Private Sub MDIGeoGiven_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        AutoUpdater.Start("http://helpdesk.geogiven.co.id/program/version.xml")
        'AutoUpdater.ShowUpdateForm()
        AutoUpdater.DownloadPath = Environment.CurrentDirectory
        AutoUpdater.Mandatory = True
        Call Logout()
    End Sub

    Private Sub SubLPJ_Buat_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SubLPJ_Buat.ItemClick
        Dim f As FrmLPJ = New FrmLPJ
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub SubItem_Inter_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SubItem_Inter.ItemClick
        'Dim f As FrmMasterBarangInt = New FrmMasterBarangInt
        'f.MdiParent = Me
        'f.Show()
    End Sub

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        Dim Query As String
        Dim oMD5 As CMD5 = New CMD5
        Dim MD5Hash As String = oMD5.computeHash(TPassword.Text)
        Try
            GGVM_conn()
        Catch myerror As OdbcException
            MessageBox.Show("Connection Error!: " & myerror.Message)
        End Try
        Query = ""
        Query &= " select if (fullname is null,'User',fullname) as fullname,level,iddivisi,if (menu is null,'',menu)as menu from user "
        Query = Query & " where username = '" & Trim(TUsername.Text) & "' and password = '" & MD5Hash & "'"
        cmd = New OdbcCommand(Query, conn)
        dr = cmd.ExecuteReader
        If dr.HasRows = 0 Then
            MessageBox.Show("Your login details are not a valid.", "Geo Given System: Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            userid = TUsername.Text
            If dr.Item("fullname") = "User" Then
                Fullname = userid
            Else
                Fullname = dr.Item("fullname")
            End If
            LevelUser = dr.Item("level")
            DivUser = dr.Item("iddivisi")
            Usermenu = dr.Item("menu")
            Call Login()
            PLogin.Visible = False
            RibbonControl1.Visible = True
            M_UserMan.Caption = Fullname
            LogedInBy.Caption = Fullname
        End If

    End Sub
    'Private Sub SubMkt_CreateDO_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SubMkt_CreateDO.ItemClick
    '    Dim f As FrmDO = New FrmDO
    '    f.MdiParent = Me
    '    f.Show()
    'End Sub

    'Private Sub SubUser_Edit_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SubUser_Edit.ItemClick
    '    Dim f As FrmUserDetail = New FrmUserDetail
    '    f.MdiParent = Me
    '    f.Show()
    'End Sub

    'Private Sub SubP2P_PODsn_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SubP2P_PODsn.ItemClick
    '    Dim f As FrmPage1 = New FrmPage1
    '    f.MdiParent = Me
    '    f.Show()
    'End Sub

    'Private Sub SubItem_PE_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SubItem_PE.ItemClick
    '    Dim f As FrmMasterBarangPE = New FrmMasterBarangPE
    '    f.MdiParent = Me
    '    f.Show()
    'End Sub

    'Private Sub SubP2P_POMarketing_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SubP2P_POMarketing.ItemClick
    '    Dim f As FrmKirimPOInt = New FrmKirimPOInt
    '    f.MdiParent = Me
    '    f.Show()
    'End Sub

    'Private Sub M_Lokasi_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles M_Lokasi.ItemClick
    '    Dim f As FrmMasterArea = New FrmMasterArea
    '    f.MdiParent = Me
    '    f.Show()
    'End Sub

    'Private Sub SubP2P_Simulasi_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SubP2P_Simulasi.ItemClick
    '    Dim f As FrmSimulasiPE = New FrmSimulasiPE
    '    f.MdiParent = Me
    '    f.Show()
    'End Sub

    'Private Sub SubP2P_History_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SubP2P_History.ItemClick

    'End Sub

    'Private Sub SubP2P_POProduksi_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SubP2P_POProduksi.ItemClick

    'End Sub

    'Private Sub SubP2P_MajuSurvei_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SubP2P_MajuSurvei.ItemClick
    '    'Dim f As New FrmMajuSurvei
    '    'f.MdiParent = Me
    '    'f.Show()
    'End Sub

    Private Sub BtnPEOps_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPEOps.ItemClick
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is FrmPEEvent Then
                frm.Activate()
                MsgBox("Tutup Dulu Form yang Aktif !")
                Return
            End If
        Next
        SSManager.ShowWaitForm()
        For i As Integer = 1 To 100
            SSManager.SetWaitFormDescription(i.ToString() & "%")
            Thread.Sleep(10)
        Next
        SSManager.CloseWaitForm()
        Dim f As FrmPEEvent = New FrmPEEvent
        f.MdiParent = Me
        f.TidJenisPE.Text = "1"
        f.Show()
    End Sub

    Private Sub BtnPEBooth_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPEBooth.ItemClick
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is FrmPEEvent Then
                frm.Activate()
                MsgBox("Tutup Dulu Form yang Aktif !")
                Return
            End If
        Next
        SSManager.ShowWaitForm()
        For i As Integer = 1 To 100
            SSManager.SetWaitFormDescription(i.ToString() & "%")
            Thread.Sleep(10)
        Next
        SSManager.CloseWaitForm()
        Dim f As FrmPEEvent = New FrmPEEvent
        f.MdiParent = Me
        f.TidJenisPE.Text = "2"
        f.Show()
    End Sub

    Private Sub BtnPeReguler_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPeReguler.ItemClick
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is FrmPEEvent Then
                frm.Activate()
                MsgBox("Tutup Dulu Form yang Aktif !")
                Return
            End If
        Next
        SSManager.ShowWaitForm()
        For i As Integer = 1 To 100
            SSManager.SetWaitFormDescription(i.ToString() & "%")
            Thread.Sleep(10)
        Next
        SSManager.CloseWaitForm()
        Dim f As FrmPEEvent = New FrmPEEvent
        f.MdiParent = Me
        f.TidJenisPE.Text = "4"
        f.Show()
    End Sub

    Private Sub BtnPEPhoto_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnPEPhoto.ItemClick
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is FrmPEEvent Then
                frm.Activate()
                MsgBox("Tutup Dulu Form yang Aktif !")
                Return
            End If
        Next
        SSManager.ShowWaitForm()
            For i As Integer = 1 To 100
            SSManager.SetWaitFormDescription(i.ToString() & "%")
            Thread.Sleep(10)
        Next
        SSManager.CloseWaitForm()
        Dim f As FrmPEEvent = New FrmPEEvent
        f.MdiParent = Me
        f.TidJenisPE.Text = "3"
        f.Show()
    End Sub

    Private Sub BtnTmbhKontrak_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnTmbhKontrak.ItemClick
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is FrmKontrak Then
                frm.Activate()
                MsgBox("Tutup Dulu Form yang Aktif !")
                Return
            End If
        Next
        SSManager.ShowWaitForm()
        For i As Integer = 1 To 100
            SSManager.SetWaitFormDescription(i.ToString() & "%")
            Thread.Sleep(10)
        Next
        SSManager.CloseWaitForm()
        Dim f As FrmKontrak = New FrmKontrak
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub BtnListKontrak_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnListKontrak.ItemClick
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is FrmKontrak Then
                frm.Activate()
                MsgBox("Tutup Dulu Form yang Aktif !")
                Return
            End If
        Next
        SSManager.ShowWaitForm()
        For i As Integer = 1 To 100
            SSManager.SetWaitFormDescription(i.ToString() & "%")
            Thread.Sleep(10)
        Next
        SSManager.CloseWaitForm()
        Dim f As FrmKontrak = New FrmKontrak
        f.MdiParent = Me
        f.Show()
    End Sub
    Private Sub BtnMainPO_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnMainPO.ItemClick
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is FrmMaintPO Then
                frm.Activate()
                MsgBox("Tutup Dulu Form yang Aktif !")
                Return
            End If
        Next
        SSManager.ShowWaitForm()
        For i As Integer = 1 To 100
            SSManager.SetWaitFormDescription(i.ToString() & "%")
            Thread.Sleep(10)
        Next
        SSManager.CloseWaitForm()
        Dim f As FrmMaintPO = New FrmMaintPO
        f.MdiParent = Me
        f.Show()
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Me.Close()
    End Sub
    Private Sub BtnActEvent_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnActEvent.ItemClick
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is FrmActivation Then
                frm.Activate()
                MsgBox("Tutup Dulu Form yang Aktif !")
                Return
            End If
        Next
        SSManager.ShowWaitForm()
        For i As Integer = 1 To 100
            SSManager.SetWaitFormDescription(i.ToString() & "%")
            Thread.Sleep(10)
        Next
        SSManager.CloseWaitForm()
        Dim f As FrmActivation = New FrmActivation
        f.MdiParent = Me
        f.TidJenisPE.Text = "5"
        f.Show()
    End Sub

    Private Sub BtnActProject_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnActProject.ItemClick
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is FrmActivation Then
                frm.Activate()
                MsgBox("Tutup Dulu Form yang Aktif !")
                Return
            End If
        Next
        SSManager.ShowWaitForm()
        For i As Integer = 1 To 100
            SSManager.SetWaitFormDescription(i.ToString() & "%")
            Thread.Sleep(10)
        Next
        SSManager.CloseWaitForm()
        Dim f As FrmActivation = New FrmActivation
        f.MdiParent = Me
        f.TidJenisPE.Text = "6"
        f.Show()
    End Sub

    Private Sub BtnActInstore_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnActInstore.ItemClick
        For Each frm As Form In Application.OpenForms
            If TypeOf frm Is FrmActivation Then
                frm.Activate()
                MsgBox("Tutup Dulu Form yang Aktif !")
                Return
            End If
        Next
        SSManager.ShowWaitForm()
        For i As Integer = 1 To 100
            SSManager.SetWaitFormDescription(i.ToString() & "%")
            Thread.Sleep(10)
        Next
        SSManager.CloseWaitForm()
        Dim f As FrmActivation = New FrmActivation
        f.MdiParent = Me
        f.TidJenisPE.Text = "7"
        f.Show()
    End Sub
End Class