Option Strict Off
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors
Imports System.Data.Odbc
Partial Public Class FrmMaintPO
    Private Panel1Captured As Boolean
    Private Panel1Grabbed As Point
    Dim tgl As Date
    Dim LoadDt, Proses As String
    Dim pohead As Boolean
#Region "ListHeader"
    Private Sub ListHeaderPO()
        ListPO.FullRowSelect = True
        ListPO.MultiSelect = True
        ListPO.View = View.Details
        ListPO.CheckBoxes = True
        ListPO.Columns.Clear()
        ListPO.Items.Clear()
        ListPO.Columns.Add("TANGGAL", 100, HorizontalAlignment.Left)
        ListPO.Columns.Add("DIVISI", 100, HorizontalAlignment.Left)
        ListPO.Columns.Add("NO.PO", 180, HorizontalAlignment.Left)
        ListPO.Columns.Add("KLIEN", 150, HorizontalAlignment.Left)
        ListPO.Columns.Add("NO.PE", 150, HorizontalAlignment.Left)
        ListPO.Columns.Add("TITLE", 300, HorizontalAlignment.Left)
        ListPO.Columns.Add("NOMINAL", 150, HorizontalAlignment.Right)
        ListPO.Columns.Add("PPN", 150, HorizontalAlignment.Right)
        ListPO.Columns.Add("GRAND TOTAL", 150, HorizontalAlignment.Right)
        ListPO.Columns.Add("REFERENSI", 150, HorizontalAlignment.Left)
        ListPO.Columns.Add("USERS", 150, HorizontalAlignment.Left)
        ListPO.Columns.Add("REVISI", 50, HorizontalAlignment.Left)
        ListPO.Columns.Add("ID.PO", 10, HorizontalAlignment.Left)
        ListPO.Columns.Add("ID.DIV", 10, HorizontalAlignment.Left)
        ListPO.Columns.Add("ID.KLIEN", 10, HorizontalAlignment.Left)
        ListPO.Columns.Add("ID.PE", 10, HorizontalAlignment.Left)
        ListPO.Columns.Add("ID.SUBDVISI", 10, HorizontalAlignment.Left)
    End Sub
    Private Sub ListHeaderPOClosing()
        ListPO.FullRowSelect = True
        ListPO.MultiSelect = True
        ListPO.View = View.Details
        ListPO.CheckBoxes = True
        ListPO.Columns.Clear()
        ListPO.Items.Clear()
        ListPO.Columns.Add("TANGGAL", 100, HorizontalAlignment.Left)
        ListPO.Columns.Add("DIVISI", 100, HorizontalAlignment.Left)
        ListPO.Columns.Add("NO.PO", 180, HorizontalAlignment.Left)
        ListPO.Columns.Add("KLIEN", 150, HorizontalAlignment.Left)
        ListPO.Columns.Add("TOTAL PO", 150, HorizontalAlignment.Right)
        ListPO.Columns.Add("TOTAL INVOICE", 150, HorizontalAlignment.Right)
        ListPO.Columns.Add("NO.PE", 150, HorizontalAlignment.Left)
        ListPO.Columns.Add("TITLE", 300, HorizontalAlignment.Left)
        ListPO.Columns.Add("REFERENSI", 150, HorizontalAlignment.Left)
        ListPO.Columns.Add("USERS", 150, HorizontalAlignment.Left)
        ListPO.Columns.Add("REVISI", 50, HorizontalAlignment.Left)
        ListPO.Columns.Add("ID.PO", 10, HorizontalAlignment.Left)
        ListPO.Columns.Add("ID.DIV", 10, HorizontalAlignment.Left)
        ListPO.Columns.Add("ID.KLIEN", 10, HorizontalAlignment.Left)
        ListPO.Columns.Add("ID.PE", 10, HorizontalAlignment.Left)
        ListPO.Columns.Add("ID.SUBDVISI", 10, HorizontalAlignment.Left)
    End Sub
#End Region
#Region "Deklarasi Perintah"
    Private Sub ClearAll()
        DTTanggal.Text = FormatDateTime(Now)
        DTTanggal.Format = DateTimePickerFormat.Custom
        DTTanggal.CustomFormat = "dd/MM/yyyy"
        TglCounter.Text = FormatDateTime(Now)
        TglCounter.Format = DateTimePickerFormat.Custom
        TglCounter.CustomFormat = "dd/MM/yyyy"
        'TDivisi.Text = ""
        'TIdDivisi.Text = ""
        TKlien.Text = ""
        TIdKlien.Text = ""
        TNoPE.Text = ""
        TIdPE.Text = ""
        TTitle.Text = ""
        TNoPO.Text = ""
        TNominal.Text = "0"
        TUsers.Text = ""
        TIdPO.Text = ""
        TReferensi.Text = ""
        TRevisi.Text = "0"
        TKeterangan.Text = ""
        BtnEntry.Enabled = True
        BtnEdit.Enabled = True
        BtnHapus.Enabled = True
        BtnSimpan.Caption = "SIMPAN"
        BtnSimpan.Enabled = False
        ' BtnDivisi.Enabled = False
        BtnKlien.Enabled = False
        BtnSubdivisi.Enabled = False
        BtnPE.Enabled = False
        BtnKeluar.Caption = "KELUAR"
        PAlasan.Visible = False
        NOPO.Enabled = False
        NOPE.Enabled = False
        Referensi.Enabled = False
    End Sub
    Private Sub TampilPO()
        Dim s As String
        Dim i As Integer
        Dim tbl As New DataTable

        If TidDivisi.Text = "" Then
            MsgBox("Pilih dulu Divisinya !!..", vbInformation, "Information")
            Exit Sub
        End If

        ListPO.Items.Clear()
        GGVM_conn()
        s = ""
        s = s & " select k.* "
        s = s & " from ( "
        s = s & " select x.*,y.idpo as idpoinv,if (z.idpe is null,'',z.idpe)as idproyek,if(x.idsubdivisi is null,'',x.idsubdivisi)as idsubdiv "
        s = s & " from ( "
        s = s & " select a.* ,b.nama as divisi,c.nama as klien "
        s = s & " from po_klien a, divisi b, klien c "
        s = s & " where a.iddivisi = b.id_divisi"
        s = s & " and a.idklien = c.id"
        s = s & " ) x left join invoice y on x.idpo = y.idpo "
        s = s & " left join proyek z on x.idpe = z.idpe "
        s = s & " ) k "
        s = s & " where K.tglclosing Is null and k.nominalinv = 0 and k.iddivisi = '" & TidDivisi.Text & "'"
        If TidSubdivisi.Text <> "" Then
            s = s & " and k.idsubdiv='" & TidSubdivisi.Text & "'"
        End If
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds.Clear()
        tbl = New DataTable
        tbl.Clear()
        da.Fill(tbl)
        For i = 0 To tbl.Rows.Count - 1
            With ListPO
                .Items.Add(tbl.Rows(i)("printed"))
                With .Items(.Items.Count - 1).SubItems
                    .Add(tbl.Rows(i)("divisi")) '1
                    .Add(tbl.Rows(i)("nopo")) '2
                    .Add(tbl.Rows(i)("klien")) '3
                    .Add(tbl.Rows(i)("referensi")) '4
                    .Add(replaceNewLine(tbl.Rows(i)("title"), False))
                    .Add(FormatNumber(tbl.Rows(i)("nominal"), 0, , , TriState.True))
                    .Add(FormatNumber(tbl.Rows(i)("ppn"), 0, , , TriState.True))
                    .Add(FormatNumber(tbl.Rows(i)("grandtotal"), 0, , , TriState.True))
                    .Add(tbl.Rows(i)("referensi"))
                    .Add(tbl.Rows(i)("users"))
                    .Add(tbl.Rows(i)("revisike"))
                    .Add(tbl.Rows(i)("idpo"))
                    .Add(tbl.Rows(i)("iddivisi"))
                    .Add(tbl.Rows(i)("idklien"))
                    .Add(tbl.Rows(i)("idproyek"))
                    .Add(tbl.Rows(i)("idsubdiv"))
                End With
            End With
        Next
        GGVM_conn_close()
    End Sub
    Private Sub TampilPOClosing()
        Dim s As String
        Dim i As Integer
        Dim tbl As New DataTable

        If TidDivisi.Text = "" Then
            MsgBox("Pilih dulu Divisinya !!..", vbInformation, "Information")
            Exit Sub
        End If
        ListPO.Items.Clear()
        GGVM_conn()
        s = ""
        s = s & " select k.*,if (k.idsubdivisi is null,'',k.idsubdivisi)as idsubdiv  "
        s = s & " from ( "
        s = s & " select x.*,if (z.idpe is null,'',z.idpe)as idproyek"
        s = s & " from ( "
        s = s & " select a.* ,b.nama as divisi,c.nama as klien "
        s = s & " from po_klien a, divisi b, klien c "
        s = s & "             where a.iddivisi = b.id_divisi"
        s = s & " and a.idklien = c.id"
        s = s & " ) x  "
        s = s & " left join proyek z on x.idpe = z.idpe "
        s = s & " ) k "
        s = s & " where K.tglclosing Is null and k.nominalinv > 0 and k.iddivisi = '" & TidDivisi.Text & "'"
        If TidSubdivisi.Text <> "" Then
            s = s & " and k.idsubdivisi='" & TidSubdivisi.Text & "'"
        End If
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds.Clear()
        tbl = New DataTable
        tbl.Clear()
        da.Fill(tbl)
        For i = 0 To tbl.Rows.Count - 1
            With ListPO
                .Items.Add(tbl.Rows(i)("printed"))
                With .Items(.Items.Count - 1).SubItems
                    .Add(tbl.Rows(i)("divisi"))
                    .Add(tbl.Rows(i)("nopo"))
                    .Add(tbl.Rows(i)("klien"))
                    .Add(FormatNumber(tbl.Rows(i)("nominal"), 0, , , TriState.True))
                    .Add(FormatNumber(tbl.Rows(i)("nominalinv"), 0, , , TriState.True))
                    .Add(tbl.Rows(i)("referensi"))
                    .Add(replaceNewLine(tbl.Rows(i)("title"), False))
                    .Add(tbl.Rows(i)("referensi"))
                    .Add(tbl.Rows(i)("users"))
                    .Add(tbl.Rows(i)("revisike"))
                    .Add(tbl.Rows(i)("idpo"))
                    .Add(tbl.Rows(i)("iddivisi"))
                    .Add(tbl.Rows(i)("idklien"))
                    .Add(tbl.Rows(i)("idproyek"))
                    .Add(tbl.Rows(i)("idsubdiv"))
                End With
            End With
        Next
        GGVM_conn_close()
    End Sub
    Private Sub TampilMIGO()
        Dim s As String
        Dim i As Integer
        Dim tbl As New DataTable

        ListPO.Items.Clear()
        GGVM_conn()
        s = ""
        s = s & " select m.*,if (m.idsubdivisi is null,'',m.idsubdivisi)as idsubdiv from ( "
        s = s & " select k.*,l.idmigo "
        s = s & " from ( "
        s = s & " select x.*,y.idpo as idpoinv,if (z.idpe is null,'',z.idpe)as idproyek "
        s = s & " from ( "
        s = s & " select a.* ,b.nama as divisi,c.nama as klien "
        s = s & " from po_klien a, divisi b, klien c "
        s = s & "             where a.iddivisi = b.id_divisi"
        s = s & " and a.idklien = c.id"
        s = s & " ) x left join invoice y on x.idpo = y.idpo "
        s = s & " left join proyek z on x.idpe = z.idpe "
        s = s & " ) k "
        s = s & " left join detail_migo l on k.idpo = l.idpo "
        s = s & " ) m where m.idmigo is null"
        If TidSubdivisi.Text <> "" Then
            s = s & " and m.idsubdivisi='" & TidSubdivisi.Text & "'"
        End If
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds.Clear()
        tbl = New DataTable
        tbl.Clear()
        da.Fill(tbl)
        For i = 0 To tbl.Rows.Count - 1
            With ListPO
                .Items.Add(tbl.Rows(i)("printed"))
                With .Items(.Items.Count - 1).SubItems
                    .Add(tbl.Rows(i)("divisi"))
                    .Add(tbl.Rows(i)("nopo"))
                    .Add(tbl.Rows(i)("klien"))
                    .Add(tbl.Rows(i)("referensi"))
                    .Add(replaceNewLine(tbl.Rows(i)("title"), False))
                    .Add(FormatNumber(tbl.Rows(i)("nominal"), 0, , , TriState.True))
                    .Add(FormatNumber(tbl.Rows(i)("ppn"), 0, , , TriState.True))
                    .Add(FormatNumber(tbl.Rows(i)("grandtotal"), 0, , , TriState.True))
                    .Add(tbl.Rows(i)("referensi"))
                    .Add(tbl.Rows(i)("users"))
                    .Add(tbl.Rows(i)("revisike"))
                    .Add(tbl.Rows(i)("idpo"))
                    .Add(tbl.Rows(i)("iddivisi"))
                    .Add(tbl.Rows(i)("idklien"))
                    .Add(tbl.Rows(i)("idproyek"))
                    .Add(tbl.Rows(i)("idsubdiv"))
                End With
            End With
        Next
        GGVM_conn_close()

    End Sub
    Private Sub LoadPE()
        Dim s As String

        GGVM_conn()
        s = ""
        If TidDivisi.Text = "2" Or TidDivisi.Text = "17" Or TidDivisi.Text = "18" Then
            s = s & " select nope,project,venue,idpe from evn_penawaran"
            s = s & " where iddivisi = '" & TidDivisi.Text & "'"
            s = s & " order by nope"
        End If
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "proyek")

        GridPanel.DataSource = ds.Tables("proyek")
        If GridPanel.RowCount = 1 Then
            MsgBox("Data PE tidak ada !!..", MsgBoxStyle.Information, "Information")
            LPanel.Text = ""
            PanelSurvei.Visible = False
            Exit Sub
        End If
        GridPanel.Refresh()
        'GridPanel.Columns(0).HeaderText = "NO.PROJECT ESTIMATION"
        'GridPanel.Columns(1).HeaderText = "ID PE"
        GridPanel.Columns(0).Width = 200
        GridPanel.Columns(1).Width = 150
        GridPanel.Columns(2).Width = 150
        GridPanel.Columns(3).Width = 10
        GGVM_conn_close()
    End Sub
    Private Sub Loadklien()
        Dim s As String

        GGVM_conn()
        s = "select nama ,id from klien where  status = '1' order by nama"

        'da = Nothing
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "klien")

        GridPanel.DataSource = ds.Tables("klien")
        GridPanel.Refresh()
        GridPanel.Columns(0).Width = 300
        GridPanel.Columns(1).Width = 50
        GGVM_conn_close()
    End Sub
    Private Sub LoadDistributor()
        Dim s As String

        GGVM_conn()
        s = "select nama ,id from klien where jns_klien = 'D' and status='1' order by nama"

        'da = Nothing
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "klien")

        GridPanel.DataSource = ds.Tables("klien")
        GridPanel.Refresh()
        GridPanel.Columns(0).Width = 300
        GridPanel.Columns(1).Width = 50
        GGVM_conn_close()
    End Sub
    Private Sub LoadDivisi()
        Dim s As String

        GGVM_conn()
        s = ""
        s = s & " select nama,id_divisi from divisi where id_divisi in ('1','2','3','16','17','18')"
        If DivUser = "0" Then
        Else
            If DivUser <> "0" Or DivUser = "4" Or DivUser <> "16" Then
                If DivUser = "5" Then
                    s = s & " and id_divisi='1'"
                Else
                    If DivUser = "16" Then
                        s = s & " and id_divisi in ('1','2','16')"
                    Else
                        s = s & " and id_divisi='" & DivUser & "'"
                    End If

                End If
            End If
        End If
        s = s & " order by nama"
        'da = Nothing
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "divisi")

        GridPanel.DataSource = ds.Tables("divisi")
        GridPanel.Refresh()
        GridPanel.Columns(0).Width = 500
        GridPanel.Columns(1).Width = 50
        GGVM_conn_close()
    End Sub
    Private Sub Loadsubdivisi()
        Dim s As String

        GGVM_conn()
        s = ""

        If TidDivisi.Text = "3" Then
            s = s & " select subdivisi ,idsubdivisi from spg_subdivisi where  status = '1'  "
            If TIdKlien.Text = "31" Or TIdKlien.Text = "72" Or TIdKlien.Text = "76" Or TIdKlien.Text = "74" Or TIdKlien.Text = "77" Or TIdKlien.Text = "73" Then
                s = s & " and idklien='31'"
            Else
                s = s & " and idklien='" & TIdKlien.Text & "'"
            End If
            s = s & " order by subdivisi"
        Else
            s = s & " select subdivisi ,idsubdivisi from subdivisi "
            s = s & " where id_divisi='" & TidDivisi.Text & "'"
            s = s & " order by subdivisi"
        End If
        'da = Nothing
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "klien")

        GridPanel.DataSource = ds.Tables("klien")
        GridPanel.Refresh()
        GridPanel.Columns(0).Width = 300
        GridPanel.Columns(1).Width = 50
        GGVM_conn_close()
    End Sub
    Private Sub TampilDapatPO()
        Dim s As String
        Dim i As Integer
        Dim tbl As New DataTable

        Me.Cursor = Cursors.WaitCursor
        ListPO.Items.Clear()
        GGVM_conn()

        s = ""
        If TidDivisi.Text = "2" Or TidDivisi.Text = "17" Or TidDivisi.Text = "18" Then
            s = s & "  select x.idpo,x.divisi,x.iddivisi,x.idklien,x.klien,x.nopo,x.printed,x.ppn,x.grandtotal,x.title,x.nominal,x.users,x.referensi,x.idpe,x.revisike,x.zidpe,x.nope, "
            s = s & " if(x.idsubdivisi is null,'',x.idsubdivisi)as idsubdiv"
            s = s & " from ("
            s = s & " select k.* ,if (l.nominaldtl is null,'0',l.nominaldtl)as nominaldtl"
            s = s & " from (  "
            s = s & " select x.*,y.idpo as idpoinv,if (z.idpe is null,'',z.idpe)as zidpe,if (z.nope is null,'',z.nope)as nope  "
            s = s & " from (  "
            s = s & " select a.* ,b.nama as divisi,c.nama as klien  "
            s = s & " from po_klien a, divisi b, klien c              "
            s = s & " where a.iddivisi = b.id_divisi"
            s = s & " and a.idklien = c.id "
            s = s & " and a.idpo = '" & TIdPO.Text & "'"
            s = s & " ) x left join invoice y on x.idpo = y.idpo  "
            s = s & " left join evn_penawaran z on x.idpe = z.idpe  "
            s = s & " ) k  LEFT JOIN"
            s = s & " ( select idpo,sum(nominal)as nominaldtl from detail_po_klien group by idpo ) l on k.idpo = l.idpo "
            s = s & " ) x where x.nominal <> x.nominaldtl"
            s = s & " group by x.idpo desc"
        End If

        If TidDivisi.Text = "3" Or TidDivisi.Text = "1" Or TidDivisi.Text = "16" Then 'divisi OUTSOURCING DAN PRODUKSI & P.AGENT
            s = s & "  select x.idpo,x.divisi,x.iddivisi,x.idklien,x.klien,x.nopo,x.ppn,x.grandtotal,x.printed,x.title,x.nominal,x.users,x.referensi,x.idpe,x.revisike,x.zidpe,x.nope, "
            s = s & " if(x.idsubdivisi is null,'',x.idsubdivisi)as idsubdiv"
            s = s & " from ("
            s = s & " select k.* ,if (l.nominaldtl is null,'0',l.nominaldtl)as nominaldtl"
            s = s & " from (  "
            s = s & " select x.*,y.idpo as idpoinv,if (z.idpe is null,'',z.idpe)as zidpe,  if (z.nope is null,'',z.nope)as nope"
            s = s & " from (  "
            s = s & " select a.* ,b.nama as divisi,c.nama as klien  "
            s = s & " from po_klien a, divisi b, klien c              "
            s = s & " where a.iddivisi = b.id_divisi"
            s = s & " and a.idklien = c.id "
            s = s & " and a.idpo = '" & TIdPO.Text & "'"
            s = s & " ) x left join invoice y on x.idpo = y.idpo  "
            s = s & " left join proyek z on x.idpe = z.idpe  "
            s = s & " ) k  LEFT JOIN"
            s = s & " ( select idpo,sum(nominal)as nominaldtl from detail_po_klien group by idpo ) l on k.idpo = l.idpo "
            s = s & " ) x where x.nominal <> x.nominaldtl"
            s = s & " group by x.idpo desc"
        End If
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds.Clear()
        tbl = New DataTable
        tbl.Clear()
        da.Fill(tbl)


        For i = 0 To tbl.Rows.Count - 1
            With ListPO
                .Items.Add(tbl.Rows(i)("printed"))
                With .Items(.Items.Count - 1).SubItems
                    .Add(tbl.Rows(i)("divisi"))
                    .Add(tbl.Rows(i)("nopo"))
                    .Add(tbl.Rows(i)("klien"))
                    .Add(tbl.Rows(i)("nope"))
                    .Add(replaceNewLine(tbl.Rows(i)("title"), False))
                    .Add(FormatNumber(tbl.Rows(i)("nominal"), 0, , , TriState.True))
                    .Add(FormatNumber(tbl.Rows(i)("ppn"), 0, , , TriState.True))
                    .Add(FormatNumber(tbl.Rows(i)("grandtotal"), 0, , , TriState.True))
                    .Add(tbl.Rows(i)("referensi"))
                    .Add(tbl.Rows(i)("users"))
                    .Add(tbl.Rows(i)("revisike"))
                    .Add(tbl.Rows(i)("idpo"))
                    .Add(tbl.Rows(i)("iddivisi"))
                    .Add(tbl.Rows(i)("idklien"))
                    .Add(tbl.Rows(i)("zidpe"))
                    .Add(tbl.Rows(i)("idsubdiv"))
                End With
            End With
        Next
        GGVM_conn_close()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub Tampil_PE_Event()
        Dim s As String
        Dim tbl As New DataTable

        Me.Cursor = Cursors.WaitCursor
        GGVM_conn()
        s = ""
        s = s & " SELECT x.*,y.nama as nmklien"
        s = s & " from ("
        s = s & " select * from evn_penawaran"
        s = s & " where idpe='" & TIdPE.Text & "'"
        s = s & " ) x left join klien y on x.idklien=y.id "
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds.Clear()
        tbl = New DataTable
        tbl.Clear()
        da.Fill(tbl)

        TKlien.Text = tbl.Rows(0)("nmklien")
        TIdKlien.Text = tbl.Rows(0)("idklien")
        TReferensi.Text = tbl.Rows(0)("nope")
        TTitle.Text = tbl.Rows(0)("project") & " / " & tbl.Rows(0)("venue")
        TNominal.Text = FormatNumber(tbl.Rows(0)("grandtotal"), 0, , , TriState.True)

        GGVM_conn_close()
        Me.Cursor = Cursors.Default
    End Sub
#End Region
    Private Sub FrmMaintPO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTTanggal.Format = DateTimePickerFormat.Custom
        DTTanggal.CustomFormat = "dd/MM/yyyy"
        ListHeaderPO()
        RadioData.Properties.Items(RadioData.SelectedIndex).Description = "DATA PO BELUM INVOICE"
        'RBBelumInv.Checked = True
        pohead = True
    End Sub
    Private Sub BtnDivisi_Click(sender As Object, e As EventArgs) Handles BtnDivisi.Click
        LoadDt = "divisi"
        PanelSurvei.Visible = True
        LoadDivisi()
        GridPanel.Focus()
    End Sub
    Private Sub BtnKlien_Click(sender As Object, e As EventArgs) Handles BtnKlien.Click
        BtnSubdivisi.Enabled = True
        LoadDt = "klien"
        PanelSurvei.Visible = True
        Loadklien()
        GridPanel.Focus()
    End Sub
    Private Sub BtnPE_Click(sender As Object, e As EventArgs) Handles BtnPE.Click
        LoadDt = "btn pe"
        PanelSurvei.Visible = True
        LoadPE()
        GridPanel.Focus()
    End Sub
    Private Sub TNoPE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TNoPE.KeyPress
        Dim s As String
        Dim tbl As New DataTable


        If e.KeyChar = Convert.ToChar(13) Then
            LoadDt = "cari pe"
            PanelSurvei.Visible = True
            GGVM_conn()
            If TidDivisi.Text = "2" Or TidDivisi.Text = "17" Or TidDivisi.Text = "18" Then
                s = ""
                s = s & " select nope,project,venue,idpe from evn_penawaran"
                s = s & " where nope like '%" & TNoPE.Text & "%'"
                s = s & " and iddivisi='" & TidDivisi.Text & "'"
                s = s & " order by nope"
                da = New Odbc.OdbcDataAdapter(s, conn)
                ds = New DataSet
                ds.Clear()
                da.Fill(ds, "y")
            End If
            Me.Cursor = Cursors.WaitCursor

            GridPanel.DataSource = ds.Tables("y")
            GridPanel.Refresh()
            GridPanel.Columns(0).Width = 200
            GridPanel.Columns(1).Width = 150
            GridPanel.Columns(2).Width = 150
            GridPanel.Columns(3).Width = 10

            GGVM_conn_close()
            Me.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub TNoPO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TNoPO.KeyPress
        Dim s As String
        Dim tbl As DataTable

        If e.KeyChar = Convert.ToChar(13) Then
            GGVM_conn()
            s = ""
            s = s & " select count(*)as ada from po_klien"
            s = s & " where nopo='" & TNoPO.Text & "'"
            da = New Odbc.OdbcDataAdapter(s, conn)
            ds.Clear()
            tbl = New DataTable
            tbl.Clear()
            da.Fill(tbl)
            GGVM_conn_close()
            If tbl.Rows(0)("ada") > 0 Then
                MsgBox("No PO : '" & TNoPO.Text & "'   SUDAH ADA !!..", MsgBoxStyle.Information, "Information")
                TNoPO.Focus()
                Exit Sub
            End If
        End If
    End Sub
    Private Sub TNominal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TNominal.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            TNominal.Text = FormatNumber(TNominal.Text, 0, , , TriState.True)
            TReferensi.Focus()
        End If
    End Sub
    Private Sub TUsers_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TUsers.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            BtnSimpan.Links(0).Focus()
        End If
    End Sub
    Private Sub TCariPO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TCariPO.KeyPress
        Dim s As String
        Dim tbl As New DataTable

        If e.KeyChar = Convert.ToChar(13) Then

            If TidDivisi.Text = "" Then
                MsgBox("Pilih Dulu Divisinya !!...", MsgBoxStyle.Information, "Information")
                PanelSurvei.Visible = False
                Exit Sub
            End If

            GGVM_conn()
            s = ""
            If TidDivisi.Text = "2" Or TidDivisi.Text = "17" Or TidDivisi.Text = "18" Then
                s = s & " select y.nopo,y.printed,y.klien,y.nominal,y.title,y.idpo from ("
                s = s & " select k.* ,if (l.nominaldtl is null,'0',l.nominaldtl)as nominaldtl"
                s = s & " from (  "
                s = s & " select x.*,y.idpo as idpoinv,if (z.idpe is null,'',z.idpe)as idproyek  "
                s = s & " from (  "
                s = s & " select a.* ,b.nama as divisi,c.nama as klien  "
                s = s & " from po_klien a, divisi b, klien c              "
                s = s & "         where a.iddivisi = b.id_divisi"
                s = s & " and a.idklien = c.id "
                s = s & " and a.iddivisi = '" & TidDivisi.Text & "'"
                s = s & " ) x left join invoice y on x.idpo = y.idpo  "
                s = s & " left join evn_penawaran z on x.idpe = z.idpe  "
                s = s & " ) k  LEFT JOIN"
                s = s & " ( select idpo,sum(nominal)as nominaldtl from detail_po_klien group by idpo ) l on k.idpo = l.idpo"
                s = s & " ) y where y.nopo like '%" & TCariPO.Text & "%'"
                s = s & " group by y.idpo desc"
            End If
            If TidDivisi.Text = "1" Or TidDivisi.Text = "3" Or TidDivisi.Text = "16" Then 'OUTSOURCING & PRODUKSI & PA
                s = s & " select y.nopo,y.printed,y.klien,y.nominal,y.title,y.idpo from ("
                s = s & " select k.* ,if (l.nominaldtl is null,'0',l.nominaldtl)as nominaldtl"
                s = s & " from (  "
                s = s & " select x.*,y.idpo as idpoinv,if (z.idpe is null,'',z.idpe)as idproyek  "
                s = s & " from (  "
                s = s & " select a.* ,b.nama as divisi,c.nama as klien  "
                s = s & " from po_klien a, divisi b, klien c              "
                s = s & "         where a.iddivisi = b.id_divisi"
                s = s & " and a.idklien = c.id "
                s = s & " and a.iddivisi = '" & TidDivisi.Text & "'"
                s = s & " ) x left join invoice y on x.idpo = y.idpo  "
                s = s & " left join proyek z on x.idpe = z.idpe  "
                s = s & " ) k  LEFT JOIN"
                s = s & " ( select idpo,sum(nominal)as nominaldtl from detail_po_klien group by idpo ) l on k.idpo = l.idpo"
                s = s & " ) y where y.nopo like '%" & TCariPO.Text & "%'"
                s = s & " group by y.idpo desc"
            End If
            Me.Cursor = Cursors.WaitCursor
            da = New Odbc.OdbcDataAdapter(s, conn)
            ds = New DataSet
            ds.Clear()
            da.Fill(ds, "y")
            GridPanel.DataSource = ds.Tables("y")
            GridPanel.Refresh()
            GridPanel.Columns(0).Width = 100
            GridPanel.Columns(1).Width = 80
            GridPanel.Columns(2).Width = 100
            GridPanel.Columns(3).Width = 150
            GridPanel.Columns(4).Width = 250
            GridPanel.Columns(5).Width = 10
            GGVM_conn_close()
            Me.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub TReferensi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TReferensi.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            TUsers.Focus()
        End If
    End Sub
    Private Sub TJudul_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TJudul.KeyPress
        Dim s As String
        Dim tbl As New DataTable


        If e.KeyChar = Convert.ToChar(13) Then

            If TidDivisi.Text = "" Then
                MsgBox("Pilih Dulu Divisinya !!...", MsgBoxStyle.Information, "Information")
                PanelSurvei.Visible = False
                Exit Sub
            End If

            GGVM_conn()
            s = ""
            If TidDivisi.Text = "2" Or TidDivisi.Text = "17" Or TidDivisi.Text = "18" Then
                s = ""
                s = s & " select y.nopo,y.printed,y.klien,y.nominal,y.title,y.idpo from ("
                s = s & " select k.* ,if (l.nominaldtl is null,'0',l.nominaldtl)as nominaldtl"
                s = s & " from (  "
                s = s & " select x.*,y.idpo as idpoinv,if (z.idpe is null,'',z.idpe)as idproyek  "
                s = s & " from (  "
                s = s & " select a.* ,b.nama as divisi,c.nama as klien  "
                s = s & " from po_klien a, divisi b, klien c              "
                s = s & "         where a.iddivisi = b.id_divisi"
                s = s & " and a.idklien = c.id "
                s = s & " and a.iddivisi = '" & TidDivisi.Text & "'"
                s = s & " ) x left join invoice y on x.idpo = y.idpo  "
                s = s & " left join evn_penawaran z on x.idpe = z.idpe  "
                s = s & " ) k  LEFT JOIN"
                s = s & " ( select idpo,sum(nominal)as nominaldtl from detail_po_klien group by idpo ) l on k.idpo = l.idpo"
                s = s & " ) y where y.title like '%" & TJudul.Text & "%'"
                s = s & " group by y.idpo desc"
            End If
            If TidDivisi.Text = "3" Or TidDivisi.Text = "1" Or TidDivisi.Text = "16" Then 'divisi OUTSOURCING DAN PRODUKSI & P.AGENT
                s = ""
                s = s & " select y.nopo,y.printed,y.klien,y.nominal,y.title,y.idpo from ("
                s = s & " select k.* ,if (l.nominaldtl is null,'0',l.nominaldtl)as nominaldtl"
                s = s & " from (  "
                s = s & " select x.*,y.idpo as idpoinv,if (z.idpe is null,'',z.idpe)as idproyek  "
                s = s & " from (  "
                s = s & " select a.* ,b.nama as divisi,c.nama as klien  "
                s = s & " from po_klien a, divisi b, klien c              "
                s = s & "         where a.iddivisi = b.id_divisi"
                s = s & " and a.idklien = c.id "
                s = s & " and a.iddivisi = '" & TidDivisi.Text & "'"
                s = s & " ) x left join invoice y on x.idpo = y.idpo  "
                s = s & " left join proyek z on x.idpe = z.idpe  "
                s = s & " ) k  LEFT JOIN"
                s = s & " ( select idpo,sum(nominal)as nominaldtl from detail_po_klien group by idpo ) l on k.idpo = l.idpo"
                s = s & " ) y where y.title like '%" & TJudul.Text & "%'"
                s = s & " group by y.idpo desc"
            End If
            Me.Cursor = Cursors.WaitCursor
            da = New Odbc.OdbcDataAdapter(s, conn)
            ds = New DataSet
            ds.Clear()
            da.Fill(ds, "y")
            GridPanel.DataSource = ds.Tables("y")
            GridPanel.Refresh()
            GridPanel.Columns(0).Width = 100
            GridPanel.Columns(1).Width = 80
            GridPanel.Columns(2).Width = 100
            GridPanel.Columns(3).Width = 110
            GridPanel.Columns(4).Width = 350
            GridPanel.Columns(5).Width = 10
            GGVM_conn_close()
            Me.Cursor = Cursors.Default
        End If
    End Sub
    Private Sub GridPanel_DoubleClick(sender As Object, e As EventArgs) Handles GridPanel.DoubleClick
        Dim i As Integer

        i = GridPanel.CurrentRow.Index
        If i < (GridPanel.RowCount) - 1 Then
            Select Case LoadDt
                Case "divisi"
                    TDivisi.Text = GridPanel.Rows.Item(i).Cells(0).Value
                    TidDivisi.Text = GridPanel.Rows.Item(i).Cells(1).Value
                Case "klien"
                    TKlien.Text = GridPanel.Rows.Item(i).Cells(0).Value
                    TIdKlien.Text = GridPanel.Rows.Item(i).Cells(1).Value
                Case "btn pe"
                    TNoPE.Text = GridPanel.Rows.Item(i).Cells(0).Value
                    TIdPE.Text = GridPanel.Rows.Item(i).Cells(3).Value
                    Tampil_PE_Event()
                Case "cari pe"
                    TNoPE.Text = GridPanel.Rows.Item(i).Cells(0).Value
                    TIdPE.Text = GridPanel.Rows.Item(i).Cells(3).Value
                    Tampil_PE_Event()
                Case "CariPO"
                    TIdPO.Text = GridPanel.Rows.Item(i).Cells(5).Value
                    TampilDapatPO()
                    ListPO.Focus()
                Case "subdivisi"
                    TSubdivisi.Text = GridPanel.Rows.Item(i).Cells(0).Value
                    TidSubdivisi.Text = GridPanel.Rows.Item(i).Cells(1).Value
                Case "CariJudul"
                    TIdPO.Text = GridPanel.Rows.Item(i).Cells(5).Value
                    TampilDapatPO()
                    ListPO.Focus()
            End Select
            GridPanel.ClearSelection()
            LPanel.Text = ""
            PanelSurvei.Visible = False
            Select Case LoadDt
                Case "divisi"
                    BtnKlien.Focus()
                Case "pe"
                    TTitle.Focus()
                Case "klien"
                    BtnPE.Focus()
                Case "distributor"
                    BtnPE.Focus()
            End Select

        End If
    End Sub
    Private Sub GridPanel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles GridPanel.KeyPress
        Dim i As Integer
        If e.KeyChar = Convert.ToChar(13) Then
            i = GridPanel.CurrentRow.Index
            i = i - 1
            If i < (GridPanel.RowCount) - 1 Then
                Select Case LoadDt
                    Case "divisi"
                        TDivisi.Text = GridPanel.Rows.Item(i).Cells(0).Value
                        TidDivisi.Text = GridPanel.Rows.Item(i).Cells(1).Value
                    Case "klien"
                        TKlien.Text = GridPanel.Rows.Item(i).Cells(0).Value
                        TIdKlien.Text = GridPanel.Rows.Item(i).Cells(1).Value
                    Case "btn pe"
                        TNoPE.Text = GridPanel.Rows.Item(i).Cells(0).Value
                        TIdPE.Text = GridPanel.Rows.Item(i).Cells(3).Value
                        Tampil_PE_Event()
                    Case "cari pe"
                        TNoPE.Text = GridPanel.Rows.Item(i).Cells(0).Value
                        TIdPE.Text = GridPanel.Rows.Item(i).Cells(3).Value
                        Tampil_PE_Event()
                    Case "CariPO"
                        TIdPO.Text = GridPanel.Rows.Item(i).Cells(5).Value
                        TampilDapatPO()
                        ListPO.Focus()
                    Case "subdivisi"
                        TSubdivisi.Text = GridPanel.Rows.Item(i).Cells(0).Value
                        TidSubdivisi.Text = GridPanel.Rows.Item(i).Cells(1).Value
                    Case "CariJudul"
                        TIdPO.Text = GridPanel.Rows.Item(i).Cells(5).Value
                        TampilDapatPO()
                        ListPO.Focus()
                End Select
                GridPanel.ClearSelection()
                LPanel.Text = ""
                PanelSurvei.Visible = False
                Select Case LoadDt
                    Case "divisi"
                        BtnKlien.Focus()
                    Case "btn pe"
                        TTitle.Focus()
                    Case "car pe"
                        TTitle.Focus()
                    Case "klien"
                        BtnPE.Focus()
                    Case "distributor"
                        BtnPE.Focus()
                End Select
            End If
        End If
    End Sub
    Private Sub BtnEntry_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnEntry.ItemClick
        Proses = "Entry"
        BtnDivisi.Enabled = True
        BtnKlien.Enabled = True
        BtnSubdivisi.Enabled = True
        'BtnPE.Enabled = True
        BtnEntry.Enabled = False
        BtnEdit.Enabled = False
        BtnHapus.Enabled = False
        BtnSimpan.Enabled = True
        BtnKeluar.Caption = "BATAL"
        TRevisi.Text = 0

        NOPO.Enabled = True
        NOPE.Enabled = True
        Referensi.Enabled = True
        BtnDivisi.Focus()
    End Sub
    Private Sub BtnEdit_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnEdit.ItemClick
        Dim ada As Boolean
        Dim brs, jmldt As Integer
        Dim cmd As New OdbcCommand
        Dim tbl As New DataTable

        ada = False
        jmldt = 0
        For i = 0 To ListPO.Items.Count - 1
            If ListPO.Items(i).Checked = True Then
                ada = True
                brs = i
                jmldt = jmldt + 1
            End If
        Next
        If ada = False Then
            MsgBox("Tidak ada data yang akan di EDIT, Pilih dulu datanya!!...", MsgBoxStyle.Information, "Information")
            ListPO.Focus()
            Exit Sub
        End If
        If jmldt > 1 Then
            MsgBox("Hanya 1(satu) data yg bisa di-EDIT !!...", MsgBoxStyle.Information, "Information")
            ListPO.Focus()
            Exit Sub
        End If
        
        Proses = "EDIT"
        If pohead = True Then
            DTTanggal.Text = ListPO.Items(brs).SubItems(0).Text
            TDivisi.Text = ListPO.Items(brs).SubItems(1).Text
            TNoPO.Text = ListPO.Items(brs).SubItems(2).Text
            TKlien.Text = ListPO.Items(brs).SubItems(3).Text
            TNoPE.Text = ListPO.Items(brs).SubItems(4).Text
            TTitle.Text = ListPO.Items(brs).SubItems(5).Text
            TNominal.Text = ListPO.Items(brs).SubItems(6).Text
            TRpPPN.Text = ListPO.Items(brs).SubItems(7).Text
            TGrandTotal.Text = ListPO.Items(brs).SubItems(8).Text
            TReferensi.Text = ListPO.Items(brs).SubItems(9).Text
            TUsers.Text = ListPO.Items(brs).SubItems(10).Text
            TRevisi.Text = ListPO.Items(brs).SubItems(11).Text
            TIdPO.Text = ListPO.Items(brs).SubItems(12).Text
            TidDivisi.Text = ListPO.Items(brs).SubItems(13).Text
            TIdKlien.Text = ListPO.Items(brs).SubItems(14).Text
            TIdPE.Text = ListPO.Items(brs).SubItems(15).Text
            TidSubdivisi.Text = ListPO.Items(brs).SubItems(16).Text
        Else
            DTTanggal.Text = ListPO.Items(brs).SubItems(0).Text
            TDivisi.Text = ListPO.Items(brs).SubItems(1).Text
            TNoPO.Text = ListPO.Items(brs).SubItems(2).Text
            TKlien.Text = ListPO.Items(brs).SubItems(3).Text
            TNoPE.Text = ListPO.Items(brs).SubItems(4).Text
            TTitle.Text = ListPO.Items(brs).SubItems(5).Text
            TNominal.Text = ListPO.Items(brs).SubItems(6).Text
            TRpPPN.Text = ListPO.Items(brs).SubItems(7).Text
            TGrandTotal.Text = ListPO.Items(brs).SubItems(8).Text
            TReferensi.Text = ListPO.Items(brs).SubItems(9).Text
            TUsers.Text = ListPO.Items(brs).SubItems(10).Text
            TRevisi.Text = ListPO.Items(brs).SubItems(11).Text
            TIdPO.Text = ListPO.Items(brs).SubItems(12).Text
            TidDivisi.Text = ListPO.Items(brs).SubItems(13).Text
            TIdKlien.Text = ListPO.Items(brs).SubItems(14).Text
            TIdPE.Text = ListPO.Items(brs).SubItems(15).Text
            TidSubdivisi.Text = ListPO.Items(brs).SubItems(16).Text
        End If

        PAlasan.Visible = True
        TAlasan.Text = ""

        BtnEntry.Enabled = False
        BtnEdit.Enabled = False
        BtnHapus.Enabled = False
        BtnSimpan.Enabled = True
        BtnKeluar.Caption = "BATAL"
        SplitContainerControl1.Panel1.Enabled = True

        BtnKlien.Enabled = True
        BtnSubdivisi.Enabled = True
        NOPO.Enabled = True
        NOPE.Enabled = True
        Referensi.Enabled = True
    End Sub
    Private Sub BtnSimpan_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnSimpan.ItemClick
        Dim cmd As New OdbcCommand
        Dim c, jdl, s As String
        Dim nominal As Double
        Dim tbl As DataTable
        Dim ke As Integer

        Me.Cursor = Cursors.WaitCursor
        jdl = replaceNewLine(TTitle.Text, True)
        nominal = TNominal.Text
        If TIdKlien.Text = "" And TIdKlien.Text = "0" Then
            MsgBox("Isi dulu Kliennya !!!...", MsgBoxStyle.Information, "Information")
            Exit Sub
        End If

        GGVM_conn()
        Select Case Proses
            Case "Entry"

                s = ""
                s = s & " select count(*)as ada from po_klien"
                s = s & " where nopo='" & Trim(TNoPO.Text) & "'"
                da = New Odbc.OdbcDataAdapter(s, conn)
                ds.Clear()
                tbl = New DataTable
                tbl.Clear()
                da.Fill(tbl)

                If tbl.Rows(0)("ada") > 0 Then
                    MsgBox("No PO : '" & TNoPO.Text & "'   SUDAH ADA !!..", MsgBoxStyle.Information, "Information")
                    GGVM_conn_close()
                    TNoPO.Focus()
                    Exit Sub
                End If


                c = ""
                c = c & " insert into po_klien (iddivisi,idsubdivisi,nopo,idklien,printed,title,nominal,sisapo,plafon_lpj,sisa_plafon, "
                If TIdPE.Text <> "" Then
                    c = c & " idpe, "
                End If
                If CFee.Checked = True Then
                    c = c & "fee, "
                End If
                If CFixedCost.Checked = True Then
                    c = c & "fixedcost, "
                End If
                c = c & " ppn,grandtotal, users,referensi,revisike,timeinput,userinput,adapo,keterangan) values "
                c = c & " ('" & TidDivisi.Text & "','" & TidSubdivisi.Text & "','" & TNoPO.Text & "','" & TIdKlien.Text & "','" & Format(DTTanggal.Value, "yyyy/MM/dd") & "',"
                c = c & " '" & jdl & "','" & nominal & "','" & nominal & "','" & nominal & "','" & nominal & "',"
                If TIdPE.Text <> "" Then
                    c = c & "'" & TIdPE.Text & "',"
                End If
                If CFee.Checked = True Then
                    c = c & "'" & TFee.Text & "',"
                End If
                If CFixedCost.Checked = True Then
                    c = c & "'" & TFixedCost.Text & "',"
                End If
                c = c & "'" & TRpPPN.Text & "','" & TGrandTotal.Text & "','" & TUsers.Text & "','" & TReferensi.Text & "','" & TRevisi.Text & "',now(),'" & userid & "',"
                If NOPO.Checked = True Then
                    c = c & "'0',"
                Else
                    c = c & "'1',"
                End If
                c = c & "'" & TKeterangan.Text & "')"
                cmd = New Odbc.OdbcCommand(c, conn)
                cmd.ExecuteNonQuery()

                s = ""
                s = s & " select idpo from po_klien where nopo = '" & Microsoft.VisualBasic.Trim(TNoPO.Text) & "'"
                da = New Odbc.OdbcDataAdapter(s, conn)
                ds.Clear()
                tbl = New DataTable
                tbl.Clear()
                da.Fill(tbl)
                TIdPO.Text = tbl.Rows(0)("idpo")

                Me.Cursor = Cursors.Default
                MsgBox("Data Sudah di-SIMPAN !!..", MsgBoxStyle.Information, "Information")

            Case "EDIT"
                Dim RpInv As Double
                Dim SisaPlafon, PakaiPlafon As Integer

                s = ""
                s = s & " select *  from po_klien"
                s = s & " where idpo = '" & TIdPO.Text & "'"
                da = New Odbc.OdbcDataAdapter(s, conn)
                ds.Clear()
                tbl = New DataTable
                tbl.Clear()
                da.Fill(tbl)
                RpInv = tbl.Rows(0)("nominalinv")
                PakaiPlafon = tbl.Rows(0)("pakai_plafon")
                SisaPlafon = nominal - PakaiPlafon

                ke = TRevisi.Text
                ke = ke + 1
                c = ""
                c = c & " update po_klien set "
                c = c & " iddivisi = '" & TidDivisi.Text & "',"
                c = c & " idsubdivisi = '" & TidSubdivisi.Text & "',"
                c = c & " nopo = '" & TNoPO.Text & "',"
                c = c & " idklien = '" & TIdKlien.Text & "',"
                If TIdPE.Text <> "" Then
                    c = c & " idpe = '" & TIdPE.Text & "',"
                End If
                If CFee.Checked = True Then
                    c = c & " fee = '" & TFee.Text & "',"
                End If
                If CFixedCost.Checked = True Then
                    c = c & " fixed = '" & TFixedCost.Text & "', "
                End If
                c = c & " ppn = '" & TRpPPN.Text & "' ,"
                c = c & " grandtotal ='" & TGrandTotal.Text & "', "
                c = c & " printed = '" & Format(DTTanggal.Value, "yyyy/MM/dd") & "',"
                c = c & " title = '" & jdl & "',"
                c = c & " nominal = '" & nominal & "',"
                If tbl.Rows(0)("nominalinv") = 0 Then
                    c = c & " sisapo = '" & nominal & "',"
                Else
                    nominal = nominal - RpInv
                    c = c & " sisapo = '" & nominal & "',"
                End If
                c = c & " referensi = '" & TReferensi.Text & "',"
                c = c & " users = '" & TUsers.Text & "',"
                If NOPO.Checked = True Then
                    c = c & " adapo = '0',"
                Else
                    c = c & " adapo = '1',"
                End If
                c = c & " revisike = '" & ke & "',"
                c = c & " sisa_plafon='" & SisaPlafon & "',"
                c = c & " keterangan = '" & TKeterangan.Text & "'"
                c = c & " where idpo = '" & TIdPO.Text & "'"
                cmd = New Odbc.OdbcCommand(c, conn)
                cmd.ExecuteNonQuery()
                Me.Cursor = Cursors.Default
                MsgBox("Data Sudah di-EDIT !!..", MsgBoxStyle.Information, "Information")
        End Select
        GGVM_conn_close()
        If RadioData.Properties.Items(RadioData.SelectedIndex).Description = "DATA PO BELUM INVOICE" Then
            TampilPO()
        ElseIf RadioData.Properties.Items(RadioData.SelectedIndex).Description = "DATA PO BELUM MIGO" Then
            TampilMIGO()
        Else
            Return
        End If
        ClearAll()
    End Sub
    Private Sub BtnHapus_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnHapus.ItemClick
        Dim ada As Boolean
        Dim brs, jmldt As Integer
        Dim cmd As New OdbcCommand
        Dim c As String


        ada = False
        jmldt = 0
        For i = 0 To ListPO.Items.Count - 1
            If ListPO.Items(i).Checked = True Then
                ada = True
                brs = i
                jmldt = jmldt + 1
            End If
        Next
        If ada = False Then
            MsgBox("ThenTidak ada data yang akan di EDIT, Pilih dulu datanya!!...", MsgBoxStyle.Information, "Information")
            ListPO.Focus()
            Exit Sub
        End If
        If jmldt > 1 Then
            MsgBox("Hanya 1(satu) data yg bisa di-EDIT !!...", MsgBoxStyle.Information, "Information")
            ListPO.Focus()
            Exit Sub
        End If

        BtnKeluar.Caption = "BATAL"
        If MsgBox("Anda yakin menghapus DATA PO ??....", MsgBoxStyle.OkCancel, "Question") = MsgBoxResult.Ok Then

            Me.Cursor = Cursors.WaitCursor
            GGVM_conn()
            c = ""
            c = c & " update po_klien set "
            c = c & " timedelete = now()"
            c = c & " where idpo='" & ListPO.Items(brs).SubItems(13).Text & "'"
            cmd = New Odbc.OdbcCommand(c, conn)
            cmd.ExecuteNonQuery()

            c = ""
            c = c & " insert into buffer_po_klien select * from po_klien"
            c = c & " where idpo='" & ListPO.Items(brs).SubItems(13).Text & "'"
            cmd = New Odbc.OdbcCommand(c, conn)
            cmd.ExecuteNonQuery()

            c = ""
            c = c & " insert into buffer_detail_po_klien select * from detail_po_klien"
            c = c & " where idpo='" & ListPO.Items(brs).SubItems(13).Text & "'"
            cmd = New Odbc.OdbcCommand(c, conn)
            cmd.ExecuteNonQuery()

            c = ""
            c = c & " delete from detail_migo"
            c = c & " where idpo='" & ListPO.Items(brs).SubItems(13).Text & "'"
            cmd = New Odbc.OdbcCommand(c, conn)
            cmd.ExecuteNonQuery()


            c = ""
            c = c & " delete from po_klien"
            c = c & " where idpo='" & ListPO.Items(brs).SubItems(13).Text & "'"
            cmd = New Odbc.OdbcCommand(c, conn)
            cmd.ExecuteNonQuery()

            GGVM_conn_close()

            TampilPO()
            Me.Cursor = Cursors.Default
        End If
        ClearAll()

    End Sub
    Private Sub BtnRefresh_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnRefresh.ItemClick
        If RadioData.Properties.Items(RadioData.SelectedIndex).Description = "DATA PO BELUM INVOICE" Then
            ListHeaderPO()
            TampilPO()
            pohead = True
        ElseIf RadioData.Properties.Items(RadioData.SelectedIndex).Description = "DATA PO BELUM MIGO" Then
            ListHeaderPO()
            TampilMIGO()
            pohead = True
        ElseIf RadioData.Properties.Items(RadioData.SelectedIndex).Description = "DATA PO SUDAH INVOICE" Then
            ListHeaderPOClosing()
            TampilPOClosing()
            pohead = False
        End If
    End Sub
    Private Sub BtnKeluar_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnKeluar.ItemClick
        If BtnKeluar.Caption = "BATAL" Then
            ClearAll()
        Else
            Me.Close()
            Exit Sub
        End If
    End Sub
    Private Sub BtnClose_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnClose.ItemClick
        Dim ada As Boolean
        Dim brs, jmldt As Integer
        Dim cmd As New OdbcCommand
        Dim c As String

        ada = False
        jmldt = 0
        For i = 0 To ListPO.Items.Count - 1
            If ListPO.Items(i).Checked = True Then
                ada = True
                brs = i
                jmldt = jmldt + 1
            End If
        Next
        If ada = False Then
            MsgBox("Tidak ada data PO yang akan di-Closing, Pilih dulu datanya!!...", MsgBoxStyle.Information, "Information")
            ListPO.Focus()
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        GGVM_conn()
        For i = 0 To ListPO.Items.Count - 1

            If ListPO.Items(i).Checked = True Then
                c = ""
                c = c & " update po_klien set "
                c = c & " tglclosing = now() "
                c = c & " where idpo = '" & ListPO.Items(brs).SubItems(11).Text & "'"
                cmd = New Odbc.OdbcCommand(c, conn)
                cmd.ExecuteNonQuery()
            End If
        Next
        Me.Cursor = Cursors.Default
        GGVM_conn_close()
        MsgBox("Proses Closing PO sudah selesai !!..", MsgBoxStyle.Information, "Information")
        ListPO.Focus()
    End Sub

    Private Sub CariPO_CheckedChanged(sender As Object, e As EventArgs) Handles CariPO.CheckedChanged
        TCariPO.Text = ""
        If CariPO.Checked = True Then
            ListHeaderPO()
            PanelSurvei.Visible = True
            TCariPO.ReadOnly = False
            GridPanel.DataSource = Nothing
            LoadDt = "CariPO"
            TCariPO.Focus()
        Else
            PanelSurvei.Visible = False
            TCariPO.ReadOnly = True
        End If
    End Sub
    Private Sub NOPO_CheckedChanged(sender As Object, e As EventArgs) Handles NOPO.CheckedChanged
        Dim s, c, nourut, u, Xtgl As String
        Dim tbl As DataTable
        Dim urut As Integer
        Dim cmd As New OdbcCommand

        If NOPO.Checked = True Then
            TNoPO.ReadOnly = True
            Me.Cursor = Cursors.WaitCursor
            GGVM_conn()
            Xtgl = Replace(Format(TglCounter.Value, "dd/MM/yyy"), "/", "")
            'TNoPO.Text = Replace(DTTanggal.Text, "/", "")

            s = ""
            s = s & "select tgl_po_smtr,no_po_smtr  from counter"
            da = New Odbc.OdbcDataAdapter(s, conn)
            ds.Clear()
            tbl = New DataTable
            tbl.Clear()
            da.Fill(tbl)

            If Trim(Xtgl) = Trim(tbl.Rows(0)("tgl_po_smtr")) Then
                urut = tbl.Rows(0)("no_po_smtr")
                urut = urut + 1
            Else
                urut = 1
            End If

            u = urut
            nourut = Microsoft.VisualBasic.Right("0000" + u, 4)
            TNoPO.Text = Xtgl + "-" + nourut

            c = ""
            c = c & " update  counter set "
            c = c & " tgl_po_smtr = '" & Xtgl & "',"
            c = c & " no_po_smtr = '" & urut & "'"
            cmd = New Odbc.OdbcCommand(c, conn)
            cmd.ExecuteNonQuery()
            GGVM_conn_close()
            Me.Cursor = Cursors.Default
        Else
            TNoPO.ReadOnly = False
            TNoPO.Text = ""
        End If
    End Sub
    Private Sub NOPE_CheckedChanged(sender As Object, e As EventArgs) Handles NOPE.CheckedChanged
        If NOPE.Checked = True Then
            TNoPE.Text = ""
            TNoPE.ReadOnly = False
            BtnPE.Enabled = True
            BtnPE.Focus()
        Else
            TNoPE.Text = ""
            TTitle.Text = ""
            TNominal.Text = "0"
            TReferensi.Text = ""
            TKeterangan.Text = ""

            TNoPE.ReadOnly = True
            BtnPE.Enabled = True
        End If
    End Sub
    Private Sub Referensi_CheckedChanged(sender As Object, e As EventArgs) Handles Referensi.CheckedChanged
        If Referensi.Checked = True Then
            TReferensi.ReadOnly = False
            TReferensi.Text = ""
            TReferensi.Focus()
        End If
    End Sub
    Private Sub CJudul_CheckedChanged(sender As Object, e As EventArgs) Handles CJudul.CheckedChanged
        TJudul.Text = ""
        If CJudul.Checked = True Then
            ListHeaderPO()
            PanelSurvei.Visible = True
            TJudul.ReadOnly = False
            GridPanel.DataSource = Nothing
            LoadDt = "CariJudul"
            TJudul.Focus()
        Else
            PanelSurvei.Visible = False
            TJudul.Text = ""
            TJudul.ReadOnly = True
        End If
    End Sub
    Private Sub BtnSimpanAls_Click(sender As Object, e As EventArgs) Handles BtnSimpanAls.Click
        Dim c, als As String
        Dim cmd As New OdbcCommand
        Dim ke As Integer

        If MsgBox("Yakin untuk simpan alasan edit data PO ?..", MsgBoxStyle.OkCancel, "Question") = vbOK Then

            GGVM_conn()
            als = replaceNewLine(TAlasan.Text, True)
            ke = TRevisi.Text
            ke = ke + 1
            c = ""
            c = c & " insert into revisi_po_klien ( idpo,alasan,timerevisi,revisike) values"
            c = c & " ( '" & TIdPO.Text & "','" & als & "',now(),'" & ke & "')"
            cmd = New Odbc.OdbcCommand(c, conn)
            cmd.ExecuteNonQuery()
            BtnDivisi.Focus()
            GGVM_conn_close()
            SplitContainerControl1.Panel1.Enabled = True
        Else
            ClearAll()
        End If

        PAlasan.Visible = False
    End Sub
    Private Sub BtnTutup_Click(sender As Object, e As EventArgs) Handles BtnTutup.Click
        ClearAll()
        PAlasan.Visible = False
        SplitContainerControl1.Panel1.Enabled = True
    End Sub
    Private Sub BtnSubdivisi_Click(sender As Object, e As EventArgs) Handles BtnSubdivisi.Click
        LoadDt = "subdivisi"
        PanelSurvei.Visible = True
        Loadsubdivisi()
        GridPanel.Focus()
    End Sub
    Private Sub BtnTutupPanel_Click(sender As Object, e As EventArgs) Handles BtnTutupPanel.Click
        PanelSurvei.Visible = False
    End Sub

    Private Sub PAlasan_MouseUp(sender As Object, e As MouseEventArgs) Handles PAlasan.MouseUp
        Panel1Captured = False
    End Sub
    Private Sub PAlasan_MouseMove(sender As Object, e As MouseEventArgs) Handles PAlasan.MouseMove
        If (Panel1Captured) Then PAlasan.Location = PAlasan.Location + e.Location - Panel1Grabbed
    End Sub
    Private Sub PAlasan_MouseDown(sender As Object, e As MouseEventArgs) Handles PAlasan.MouseDown
        Panel1Captured = True
        Panel1Grabbed = e.Location
    End Sub
    Private Sub PanelSurvei_MouseMove(sender As Object, e As MouseEventArgs) Handles PanelSurvei.MouseMove
        If (Panel1Captured) Then PanelSurvei.Location = PanelSurvei.Location + e.Location - Panel1Grabbed
    End Sub
    Private Sub PanelSurvei_MouseUp(sender As Object, e As MouseEventArgs) Handles PanelSurvei.MouseUp
        Panel1Captured = False
    End Sub
    Private Sub PanelSurvei_MouseDown(sender As Object, e As MouseEventArgs) Handles PanelSurvei.MouseDown
        Panel1Captured = True
        Panel1Grabbed = e.Location
    End Sub

    Private Sub CFee_CheckedChanged(sender As Object, e As EventArgs) Handles CFee.CheckedChanged
        If CFee.Checked = True Then
            TPersenFee.Enabled = True
            TFee.Enabled = True
        Else
            TPersenFee.Enabled = False
            TFee.Enabled = False
        End If
    End Sub

    Private Sub CFixedCost_CheckedChanged(sender As Object, e As EventArgs) Handles CFixedCost.CheckedChanged
        If CFixedCost.Checked = True Then
            TFixedCost.Enabled = True
        Else
            TFixedCost.Enabled = False
        End If
    End Sub


    Private Sub TPersenFee_TextChanged(sender As Object, e As EventArgs) Handles TPersenFee.TextChanged
        Dim fee As Decimal
        fee = Val(CDec(TNominal.Text)) * Val(CDec(TPersenFee.Text)) / 100
        TFee.Text = fee
    End Sub

    Private Sub TNominal_TextChanged(sender As Object, e As EventArgs) Handles TNominal.TextChanged
        Dim ppn As Decimal
        ppn = (Val(CDec(TNominal.Text)) * 10) / 100
        TRpPPN.Text = ppn
        TGrandTotal.Text = Val(CDec(TNominal.Text)) + Val(CDec(TRpPPN.Text))
    End Sub
End Class
