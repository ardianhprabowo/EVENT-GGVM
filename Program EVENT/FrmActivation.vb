Imports System.Data.Odbc

Public Class FrmActivation
    Private ItemsBackup As New List(Of ListViewItem)
    Private Panel1Captured As Boolean
    Private Panel1Grabbed As Point
    Private strName As String
    Private HitungNominal As String
    Private thn, bln, count, divisiid, urutpe, c As String
    Private StartBln, StartThn, StartTgl, tglevent, EndBln, EndThn, EndTgl As String
    Private PeriodeHR As Double = 0
    Dim spasi() As Char = (" ")
    Dim Qoma() As Char = (",")
    Private KondisiInputEvn, KondisiInputProject, KondisiInputHR, KondisiSimpan, KondisiSimpanAlasan, ProsesPE As String
    Private HapusDetailEvent, HapusDetailProject As String

#Region "Deklarasi Perintah"
    Private Sub KondisiAwalPE()
        TNoPE.Enabled = False
        TidPE.Text = ""
        TidKlien.Text = ""
        TidKuartalPE.Text = ""
        TidKontrakAct.Text = ""
        TAgencyRP.Text = "0"
        TTotal.Text = "0"
        TRpPPN.Text = "0"
        TAgencyRP.Text = "0"
        TTotalVAT.Text = "0"
        TAgencyRP.Text = "0"
        TAgentFee.Text = "0"
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
        'CetakPE.Enabled = True
        'SimpanPE.Enabled = False
        'RevisiPE.Enabled = False
        BatalTools.Enabled = False
        HapusPE.Enabled = False
        TambahPE.Enabled = True
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

    End Sub
End Class