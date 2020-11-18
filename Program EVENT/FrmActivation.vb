Imports System.Data.Odbc

Public Class FrmActivation
    Private ItemsBackup As New List(Of ListViewItem)
    Private Panel1Captured As Boolean
    Private Panel1Grabbed As Point
    Private strName As String
    Private HitungNominal As String
    Private thn, bln, count, divisiid, urutpe, c As String
    Private StartBln, StartThn, StartTgl, tglevent, EndBln, EndThn, EndTgl As String

    Private Sub BtnProsesPE_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnProsesPE.ItemClick
        If BtnProsesPE.Caption = "Proses Input" Then

            BtnProsesPE.Caption = "Tambah Detail"
        ElseIf BtnProsesPE.Caption = "Tambah Detail" Then

            BtnProsesPE.Caption = "Simpan Detail"


        End If
    End Sub

    Private PeriodeHR As Double = 0
    Dim spasi() As Char = (" ")
    Dim Qoma() As Char = (",")
    Private KondisiInputEvn, KondisiInputProject, KondisiInputHR, KondisiSimpan, KondisiSimpanAlasan, ProsesPE As String
    Private HapusDetailEvent, HapusDetailProject As String

#Region "Deklarasi Perintah"
    Private Sub KondisiAwalPE()
        TidPE.Text = ""
        TidKlien.Text = ""
        TidKuartalPE.Text = ""
        TidKontrakAct.Text = ""
        TNoPE.Text = ""
        TKlien.Text = ""
        TVenue.Text = ""
        TJmlEvent.Text = ""
        TProject.Text = ""
        TAgentFee.Text = "0"
        TTotal.Text = "0"
        TRpPPN.Text = "0"
        TAgencyRP.Text = "0"
        TTotalVAT.Text = "0"
        TAgencyRP.Text = "0"
        TAgentFee.Text = "0"
        CSubDivisi.Text = ""
        CKontrak.Text = ""
        StartPeriod.Value = DateTime.Now
        EndPeriod.Value = DateTime.Now
        DTTanggal.Value = DateTime.Now
        TNoPE.Enabled = False
        TKlien.Enabled = False
        TVenue.Enabled = False
        TJmlEvent.Enabled = False
        TRegion.Enabled = False
        TProject.Enabled = False
        StartPeriod.Enabled = False
        EndPeriod.Enabled = False
        TPIC.Enabled = False
        TTotal.Enabled = False
        TRpPPN.Enabled = False
        TAgencyRP.Enabled = False
        TTotalVAT.Enabled = False
        TAgentFee.Enabled = False
        CKontrak.Enabled = False
        DTTanggal.Enabled = False
        CSubDivisi.Enabled = False
        BtnProsesPE.Enabled = False
        BtnRevisiPE.Enabled = False
        BtnSimpanPE.Enabled = False
        BtnCetakPE.Enabled = True
        BatalTools.Enabled = False
        BtnHapusPE.Enabled = False
        TambahPE.Enabled = True
        ListPEActivation.Enabled = True
    End Sub
    Private Sub KondisiAwalDetailPE()
        TPeriodeCL.Enabled = False
        TQtyCL.Enabled = False
        TBarangCL.Enabled = False
        TKetCL.Enabled = False
        TSubTotalCL.Enabled = False
        TTotalCostCL.Enabled = False
        TAgentFeeCL.Enabled = False
        TRpPPNCL.Enabled = False
        TPph23CL.Enabled = False
        TGrandTotalCL.Enabled = False
        CKuartal.Enabled = False
        TJmlEvnCL.Enabled = False
        CekFee.Enabled = False
        CekFee.Checked = True
        CekPPH.Enabled = False
        CekPPH.Checked = False
        CekPPN.Enabled = False
        CekPPH.Checked = False
        ListDetailPEAct.Enabled = True
    End Sub
    Private Sub KondisiTambahDetailPE()
        TPeriodeCL.Enabled = False
        TQtyCL.Enabled = True
        TBarangCL.Enabled = True
        TKetCL.Enabled = True
        TSubTotalCL.Enabled = False
        TTotalCostCL.Enabled = False
        TAgentFeeCL.Enabled = False
        TRpPPNCL.Enabled = False
        TPph23CL.Enabled = False
        TGrandTotalCL.Enabled = False
        CKuartal.Enabled = False
        TJmlEvnCL.Enabled = False
        CekFee.Enabled = False
        CekFee.Checked = True
        CekPPH.Enabled = True
        CekPPH.Checked = False
        CekPPN.Enabled = True
        CekPPH.Checked = False
        ListDetailPEAct.Enabled = False
    End Sub
    Private Sub AturanInput(ByRef e As KeyPressEventArgs)
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ",") And Not Char.IsControl(e.KeyChar) Then
            MessageBox.Show("Hanya Boleh Angka !")
            e.Handled = True
        Else
            Return
        End If
    End Sub
#End Region
    Private Sub FrmActivation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        KondisiAwalPE()
        KondisiAwalDetailPE()
    End Sub
End Class