Option Strict Off
Imports System.Data.Odbc
Public Class FrmSPGPengajuan
    Dim LoadDt As String
    Dim StsItem As String
    Dim Loadbrg As String
    Private Sub TampilPengajuan()
        Dim s As String
        'Dim i As Integer
        Dim tbl As New DataTable

        GGVM_conn()
        'KURANG PE KURANG PO
        s = ""
        s = s & " select x.*,if (y.nama is null,'',y.nama) as klien,"
        s = s & " if (y.jns_klien is null,'',y.jns_klien)as jns_klien, "
        s = s & " if (k.propinsi is null,'',k.propinsi) as propinsi,"
        s = s & " if (l.kota is null,'',l.kota) as kota,"
        s = s & " if (j.area is null,'',j.area)as area"
        s = s & " from ("
        s = s & " select a.idpengajuan,a.idsubdivisi,b.subdivisi,c.id_divisi,c.nama as divisi,a.tanggal,nopengajuan,"
        s = s & " a.idjnspengajuan,d.pengajuan,a.idstatus_pe,e.status_pe,"
        s = s & " if (a.idpe is null,'',a.idpe)as idpe,if (a.idpo is null,'',a.idpo)as idpo,"
        s = s & " if (a.idklien is null ,'',a.idklien)as idklien,"
        s = s & " if (a.idarea is null,'',a.idarea) as idarea,"
        s = s & " if (a.idpropinsi is null,'',a.idpropinsi) as idpropinsi,"
        s = s & " if (a.idkota is null,'',a.idkota)as idkota,"
        s = s & " a.statustagih,a.sumberdana,"
        s = s & " if (a.nama_bank is  null,'',a.nama_bank)as nama_bank,"
        s = s & " if (a.no_rekening is null,'',a.no_rekening)as no_rekening,"
        s = s & " a.keterangan, date_format(a.waktu_berangkat,'%d/%m/%Y %k:%i:%s') as waktu_berangkat, "
        s = s & " date_format(a.waktu_pulang,'%d/%m/%Y %k:%i:%s') as waktu_pulang, a.jml_hari, a.jml_kota, a.jml_orang, a.jml_toko, a.nominal"
        s = s & " from pengajuan a, subdivisi b,divisi c, jenis_pengajuan d, status_pe e"
        s = s & " where a.idpengajuan = '" & TIdPengajuan.Text & "'"
        s = s & " and a.idsubdivisi = b.idsubdivisi"
        s = s & " and b.id_divisi = c.id_divisi"
        s = s & " and a.idjnspengajuan = d.idjnspengajuan"
        s = s & " and a.idstatus_pe = e.idstatus_pe"
        s = s & " ) x"
        s = s & " LEFT JOIN klien y on x.idklien = y.id"
        s = s & " LEFT JOIN propinsi k on x.idpropinsi = k.idpropinsi"
        s = s & " LEFT JOIN kota l on x.idkota = l.idkota"
        s = s & " LEFT JOIN AREA J ON X.idarea = j.idarea"
        da = New OdbcDataAdapter(s, conn)
        ds.Clear()
        tbl = New DataTable
        tbl.Clear()
        da.Fill(tbl)

        TDivisi.Text = tbl.Rows(0)("divisi")
        TIdDivisi.Text = tbl.Rows(0)("id_divisi")
        TSubDivisi.Text = tbl.Rows(0)("subdivisi")
        TIdSubDivisi.Text = tbl.Rows(0)("idsubdivisi")
        DTTanggal.Text = tbl.Rows(0)("tanggal")
        TNoPengajuan.Text = tbl.Rows(0)("nopengajuan")
        TJnsPengajuan.Text = tbl.Rows(0)("pengajuan")
        TIdJnsPengajuan.Text = tbl.Rows(0)("idjnspengajuan")
        TIdStatusPE.Text = tbl.Rows(0)("idstatus_pe")
        Select Case TIdStatusPE.Text
            Case "1"
                RBAdaPE.Checked = True
                BtnPE.Enabled = True
            Case "2"
                RBBelumPE.Checked = True
                BtnKlien.Enabled = True
                BtnArea.Enabled = True
                BtnSubArea.Enabled = True
            Case "3"
                RBTidakPE.Checked = True
                BtnKlien.Enabled = True
                BtnArea.Enabled = True
                BtnSubArea.Enabled = True
        End Select

        TIdPE.Text = tbl.Rows(0)("idpe")
        TIdPO.Text = tbl.Rows(0)("idpo")
        'TPE.Text =""
        'TPO.Text =""
        If tbl.Rows(0)("jns_klien") = "K" Then
            RBKlien.Checked = True
        ElseIf tbl.Rows(0)("jns_klien") = "D" Then
            RBDistributor.Checked = True
        End If
        TIdKlien.Text = tbl.Rows(0)("idklien")
        TKlien.Text = tbl.Rows(0)("klien")
        TIdArea.Text = tbl.Rows(0)("idarea")
        TArea.Text = tbl.Rows(0)("area")
        TIdPropinsi.Text = tbl.Rows(0)("idpropinsi")
        TSubArea.Text = tbl.Rows(0)("propinsi")
        'kota
        If tbl.Rows(0)("statustagih") = "D" Then
            RBditagihkan.Checked = True
        End If
        If tbl.Rows(0)("statustagih") = "T" Then
            RBNotagih.Checked = True
        End If
        If tbl.Rows(0)("statustagih") = "F" Then
            RBFixcost.Checked = True
        End If
        If tbl.Rows(0)("sumberdana") = "T" Then
            RBtunai.Checked = True
        Else
            RBtransfer.Checked = True
        End If
        TBank.Text = tbl.Rows(0)("nama_bank")
        TNoRek.Text = tbl.Rows(0)("no_rekening")
        DTBerangkat.Value = tbl.Rows(0)("waktu_berangkat")
        DTPulang.Value = tbl.Rows(0)("waktu_pulang")
        THari.Text = tbl.Rows(0)("jml_hari")
        TJmlKota.Text = tbl.Rows(0)("jml_kota")
        TJmlToko.Text = tbl.Rows(0)("jml_toko")
        TKeterangan.Text = tbl.Rows(0)("keterangan")
        TNominal.Text = FormatNumber(tbl.Rows(0)("nominal"), 0, , , TriState.True)
        GGVM_conn_close()
    End Sub

    Private Sub TampilDetail()
        Dim s As String
        Dim i As Integer
        Dim tbl As New DataTable

        ListItem.Items.Clear()
        GGVM_conn()
        s = ""
        s = s & " select a.kdbarang ,a.barang,"
        s = s & " if (a.keterangan is null,'',a.keterangan) as keterangan,"
        s = s & " a.jml_barang, a.jml_orang, a.jml_hari,"
        s = s & " a.harga_estimasi, a.sub_total,"
        s = s & "  a.idbarang, a.iddetail_pengajuan, a.idsatuan, b.satuan"
        s = s & " from detail_pengajuan a, satuan b"
        s = s & " where a.idsatuan = b.idsatuan"
        s = s & "     and a.idpengajuan = '" & TIdPengajuan.Text & "'"
        s = s & " order by a.idbarang "
        da = New OdbcDataAdapter(s, conn)
        ds.Clear()
        tbl = New DataTable
        tbl.Clear()
        da.Fill(tbl)

        For i = 0 To tbl.Rows.Count - 1
            With ListItem
                .Items.Add(tbl.Rows(i)("kdbarang"))
                With .Items(.Items.Count - 1).SubItems
                    .Add(tbl.Rows(i)("barang"))
                    .Add(tbl.Rows(i)("keterangan"))
                    .Add(tbl.Rows(i)("satuan"))
                    .Add(tbl.Rows(i)("jml_barang"))
                    .Add(tbl.Rows(i)("jml_orang"))
                    .Add(tbl.Rows(i)("jml_hari"))
                    .Add(FormatNumber(tbl.Rows(i)("harga_estimasi"), 0, , , TriState.True))
                    .Add(FormatNumber(tbl.Rows(i)("sub_total"), 0, , , TriState.True))
                    .Add(tbl.Rows(i)("idbarang"))
                    .Add(tbl.Rows(i)("iddetail_pengajuan"))
                    .Add(tbl.Rows(i)("idsatuan"))
                End With
            End With
        Next
        GGVM_conn_close()
    End Sub
    Private Sub ListHeader()
        ListItem.FullRowSelect = True
        ListItem.MultiSelect = False
        ListItem.View = View.Details
        ListItem.CheckBoxes = True
        ListItem.Columns.Clear()
        ListItem.Items.Clear()
        ListItem.Columns.Add("KD.BRG", 75, HorizontalAlignment.Left)
        ListItem.Columns.Add("NAMA BARANG", 300, HorizontalAlignment.Left)
        ListItem.Columns.Add("KETERANGAN", 200, HorizontalAlignment.Left)
        ListItem.Columns.Add("SATUAN", 80, HorizontalAlignment.Left)
        ListItem.Columns.Add("JML", 50, HorizontalAlignment.Right)
        ListItem.Columns.Add("JML.ORANG", 100, HorizontalAlignment.Right)
        ListItem.Columns.Add("FREKUENSI", 100, HorizontalAlignment.Right)
        ListItem.Columns.Add("HRG.ESTIMASI", 100, HorizontalAlignment.Right)
        ListItem.Columns.Add("SUB.TOTAL", 100, HorizontalAlignment.Right)
        ListItem.Columns.Add("ID BARANG", 10, HorizontalAlignment.Left)
        ListItem.Columns.Add("ID DETAIL", 10, HorizontalAlignment.Left)
        ListItem.Columns.Add("ID SATUAN", 10, HorizontalAlignment.Left)
    End Sub
    Private Sub LoadDistributor()
        Dim s As String

        GGVM_conn()
        s = "select nama ,id from klien where jns_klien = 'D' order by nama"

        'da = Nothing
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "klien")

        GridPanel.DataSource = ds.Tables("klien")
        GGVM_conn_close()

        If GridPanel.RowCount = 1 Then
            MsgBox("Data DISTRIBUTOR tidak ada !!..", MsgBoxStyle.Information, "Information")
            LPanel.Text = ""
            PanelSurvei.Visible = False
            Exit Sub
        End If
        GridPanel.Refresh()
        GridPanel.Columns(0).Width = 500
        GridPanel.Columns(1).Width = 50
    End Sub
    Private Sub Loadklien()
        Dim s As String

        GGVM_conn()
        s = "select nama ,id from klien where jns_klien = 'K' order by nama"

        'da = Nothing
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "klien")

        GridPanel.DataSource = ds.Tables("klien")
        GGVM_conn_close()

        If GridPanel.RowCount = 1 Then
            MsgBox("Data KLIEN tidak ada !!..", MsgBoxStyle.Information, "Information")
            LPanel.Text = ""
            PanelSurvei.Visible = False
            Exit Sub
        End If
        GridPanel.Refresh()
        GridPanel.Columns(0).Width = 500
        GridPanel.Columns(1).Width = 50

    End Sub

    Private Sub LoadSubArea()
        Dim s As String

        GGVM_conn()
        s = ""
        s = s & " select concat(x.propinsi,'/',x.kota)as kt,x.idpropinsi,x.idkota  from ("
        s = s & " select a.propinsi,b.kota ,a.idpropinsi,b.idkota"
        s = s & " from propinsi a, kota b"
        s = s & " where a.idpropinsi = b.idpropinsi"
        s = s & " and a.idarea = '" & TIdArea.Text & "') x order by kt"

        'da = Nothing
        da = New OdbcDataAdapter(s, conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "x")

        GridPanel.DataSource = ds.Tables("x")
        GGVM_conn_close()
        If GridPanel.RowCount = 1 Then
            MsgBox("Data PROPINSI tidak ada !!..", MsgBoxStyle.Information, "Information")
            LPanel.Text = ""
            PanelSurvei.Visible = False
            Exit Sub
        End If
        GridPanel.Refresh()
        GridPanel.Columns(0).Width = 500
        GridPanel.Columns(1).Width = 50
        GridPanel.Columns(2).Width = 50

    End Sub
    Private Sub LoadArea()
        Dim s As String

        GGVM_conn()
        s = " select area,idarea from area"
        s = s & " order by area"
        'da = Nothing
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "area")

        GridPanel.DataSource = ds.Tables("area")
        GridPanel.Refresh()
        GridPanel.Columns(0).Width = 500
        GridPanel.Columns(1).Width = 50
        GGVM_conn_close()

    End Sub
    Private Sub LoadSubDivisi()
        Dim s As String

        GGVM_conn()
        s = " select subdivisi,idsubdivisi from subdivisi"
        s = s & " where id_divisi = '" & TIdDivisi.Text & "'"
        s = s & " order by subdivisi"
        'da = Nothing
        da = New OdbcDataAdapter(s, conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "subdivisi")

        GridPanel.DataSource = ds.Tables("subdivisi")
        GridPanel.Refresh()
        GridPanel.Columns(0).HeaderText = "SUB DIVISI"
        GridPanel.Columns(1).HeaderText = "ID DIVISI"
        GridPanel.Columns(0).Width = 500
        GridPanel.Columns(1).Width = 50
        GGVM_conn_close()

    End Sub

    Private Sub FrmSPGPengajuan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim tbl As New DataTable

        ' Me.LayoutMdi(MdiLayout.Cascade)
        Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2

        DTTanggal.Format = DateTimePickerFormat.Custom
        DTTanggal.CustomFormat = "dd/MM/yyyy"
        DTBerangkat.Format = DateTimePickerFormat.Custom
        DTBerangkat.CustomFormat = "dd/MM/yyyy hh:mm:ss"
        DTPulang.Format = DateTimePickerFormat.Custom
        DTPulang.CustomFormat = "dd/MM/yyyy hh:mm:ss"
        ListHeader()

        If tampilSPGMaju = "0" Then
            BtnProsesMaju.Text = "PROSES ENTRY"
            TDivisi.Text = "EVENT"
            TIdDivisi.Text = "2"
            TJnsPengajuan.Text = ""
            TIdJnsPengajuan.Text = ""
            BtnSubDivisi.Enabled = True
            BtnSubDivisi.Focus()
        Else
            TIdPengajuan.Text = tampilSPGMaju
            BtnProsesMaju.Text = "PROSES EDIT"
            BtnTambahMaju.Enabled = True
            BtnEditMaju.Enabled = True
            BtnDivisi.Enabled = False
            BtnSubDivisi.Enabled = False
            BtnJnsMaju.Enabled = False
            TampilPengajuan()
            TampilDetail()
        End If
    End Sub

    Private Sub BtnSubDivisi_Click(sender As Object, e As EventArgs) Handles BtnSubDivisi.Click
        LoadDt = "subdivisi"
        PanelSurvei.Visible = True
        LoadSubDivisi()
        GridPanel.Focus()
    End Sub

    Private Sub BtnSubDivisi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles BtnSubDivisi.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            LoadDt = "subdivisi"
            PanelSurvei.Visible = True
            LoadSubDivisi()
            GridPanel.Focus()
        End If
    End Sub
    Private Sub LoadJnsPengajuan()
        Dim s As String

        GGVM_conn()
        s = " select pengajuan,idjnspengajuan from jenis_pengajuan"
        s = s & " where idjnspengajuan IN ('8','14','15','16')"
        s = s & " order by pengajuan"
        'da = Nothing
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "jenis_pengajuan")

        GridPanel.DataSource = ds.Tables("jenis_pengajuan")
        GGVM_conn_close()
        GridPanel.Refresh()
        GridPanel.Columns(0).HeaderText = "JENIS PENGAJUAN"
        GridPanel.Columns(1).HeaderText = "ID PENGAJUAN"
        GridPanel.Columns(0).Width = 500
        GridPanel.Columns(1).Width = 50

    End Sub

    Private Sub BtnJnsMaju_Click(sender As Object, e As EventArgs) Handles BtnJnsMaju.Click
        LoadDt = "jnspengajuan"
        PanelSurvei.Visible = True
        LoadJnsPengajuan()
        GridPanel.Focus()
    End Sub

    Private Sub BtnJnsMaju_KeyPress(sender As Object, e As KeyPressEventArgs) Handles BtnJnsMaju.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            LoadDt = "jnspengajuan"
            PanelSurvei.Visible = True
            LoadJnsPengajuan()
            GridPanel.Focus()
        End If
    End Sub

    Private Sub RBditagihkan_CheckedChanged(sender As Object, e As EventArgs) Handles RBditagihkan.CheckedChanged
        If RBditagihkan.Checked = True Then
            TIdStatusTagih.Text = "D"
        End If
    End Sub

    Private Sub RBditagihkan_Click(sender As Object, e As EventArgs) Handles RBditagihkan.Click
        If RBditagihkan.Checked = True Then
            TIdStatusTagih.Text = "D"
        End If
    End Sub

    Private Sub RBNotagih_CheckedChanged(sender As Object, e As EventArgs) Handles RBNotagih.CheckedChanged
        If RBNotagih.Checked = True Then
            TIdStatusTagih.Text = "T"
        End If
    End Sub

    Private Sub RBNotagih_Click(sender As Object, e As EventArgs) Handles RBNotagih.Click
        If RBNotagih.Checked = True Then
            TIdStatusTagih.Text = "T"
        End If
    End Sub

    Private Sub RBFixcost_CheckedChanged(sender As Object, e As EventArgs) Handles RBFixcost.CheckedChanged
        If RBFixcost.Checked = True Then
            TIdStatusTagih.Text = "F"
        End If
    End Sub

    Private Sub RBFixcost_Click(sender As Object, e As EventArgs) Handles RBFixcost.Click
        If RBFixcost.Checked = True Then
            TIdStatusTagih.Text = "F"
        End If
    End Sub

    Private Sub RBtunai_CheckedChanged(sender As Object, e As EventArgs) Handles RBtunai.CheckedChanged
        If RBtunai.Checked = True Then
            TBank.Enabled = False
            TNoRek.Enabled = False
        End If
    End Sub

    Private Sub RBtunai_Click(sender As Object, e As EventArgs) Handles RBtunai.Click
        If RBtunai.Checked = True Then
            TBank.Enabled = False
            TNoRek.Enabled = False
        End If
    End Sub

    Private Sub RBtransfer_CheckedChanged(sender As Object, e As EventArgs) Handles RBtransfer.CheckedChanged
        If RBtransfer.Checked = True Then
            TBank.Enabled = True
            TNoRek.Enabled = True
            TBank.Focus()
            If TIdJnsPengajuan.Text = "14" Or TIdJnsPengajuan.Text = "15" Or TIdJnsPengajuan.Text = "16" Then
                TBank.Text = "MANDIRI"
                TNoRek.Text = "EVENT"
            End If
        Else
            TBank.Text = ""
            TNoRek.Text = ""
            TBank.Enabled = False
            TNoRek.Enabled = False
        End If
    End Sub

    Private Sub TBank_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBank.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            TNoRek.Focus()
        End If
    End Sub

    Private Sub TBank_TextChanged(sender As Object, e As EventArgs) Handles TBank.TextChanged

    End Sub

    Private Sub TNoRek_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TNoRek.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            DTBerangkat.Focus()
        End If
    End Sub

    Private Sub TNoRek_TextChanged(sender As Object, e As EventArgs) Handles TNoRek.TextChanged

    End Sub

    Private Sub DTBerangkat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTBerangkat.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            DTPulang.Focus()
        End If
    End Sub

    Private Sub DTBerangkat_ValueChanged(sender As Object, e As EventArgs) Handles DTBerangkat.ValueChanged

    End Sub

    Private Sub DTPulang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPulang.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            TJmlKota.Focus()
        End If
    End Sub

    Private Sub DTPulang_ValueChanged(sender As Object, e As EventArgs) Handles DTPulang.ValueChanged

    End Sub

    Private Sub TJmlKota_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TJmlKota.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            TJmlOrng.Focus()
        End If
    End Sub

    Private Sub TJmlKota_TextChanged(sender As Object, e As EventArgs) Handles TJmlKota.TextChanged

    End Sub

    Private Sub TJmlOrng_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TJmlOrng.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            TKeterangan.Focus()
        End If
    End Sub

    Private Sub TJmlOrng_TextChanged(sender As Object, e As EventArgs) Handles TJmlOrng.TextChanged

    End Sub

    Private Sub TKeterangan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TKeterangan.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            BtnProsesMaju.Focus()
        End If
    End Sub

    Private Sub GridPanel_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridPanel.CellContentClick

    End Sub

    Private Sub GridPanel_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridPanel.CellDoubleClick
        Dim i As Integer

        i = GridPanel.CurrentRow.Index
        If i < (GridPanel.RowCount) - 1 Then
            Select Case LoadDt
                Case "divisi"
                    TDivisi.Text = GridPanel.Rows.Item(i).Cells(0).Value
                    TIdDivisi.Text = GridPanel.Rows.Item(i).Cells(1).Value
                Case "subdivisi"
                    TSubDivisi.Text = GridPanel.Rows.Item(i).Cells(0).Value
                    TIdSubDivisi.Text = GridPanel.Rows.Item(i).Cells(1).Value
                Case "jnspengajuan"
                    TJnsPengajuan.Text = GridPanel.Rows.Item(i).Cells(0).Value
                    TIdJnsPengajuan.Text = GridPanel.Rows.Item(i).Cells(1).Value

                Case "area"
                    TArea.Text = GridPanel.Rows.Item(i).Cells(0).Value
                    TIdArea.Text = GridPanel.Rows.Item(i).Cells(1).Value
                Case "subarea"
                    TSubArea.Text = GridPanel.Rows.Item(i).Cells(0).Value
                    TIdPropinsi.Text = GridPanel.Rows.Item(i).Cells(1).Value
                    TIdKota.Text = GridPanel.Rows.Item(i).Cells(2).Value
                Case "klien"
                    TKlien.Text = GridPanel.Rows.Item(i).Cells(0).Value
                    TIdKlien.Text = GridPanel.Rows.Item(i).Cells(1).Value
                Case "distributor"
                    TKlien.Text = GridPanel.Rows.Item(i).Cells(0).Value
                    TIdKlien.Text = GridPanel.Rows.Item(i).Cells(1).Value
                Case "pe"
                    TPE.Text = GridPanel.Rows.Item(i).Cells(0).Value
                    TIdPE.Text = GridPanel.Rows.Item(i).Cells(1).Value
                Case "po"
                    TPO.Text = GridPanel.Rows.Item(i).Cells(0).Value
                    TIdPO.Text = GridPanel.Rows.Item(i).Cells(1).Value
            End Select
            GridPanel.ClearSelection()
            LPanel.Text = ""
            PanelSurvei.Visible = False
            Select Case LoadDt
                Case "divisi"
                    BtnSubDivisi.Focus()
                Case "subdivisi"
                    BtnJnsMaju.Focus()
                Case "jnspengajuan"
                    RBAdaPE.Focus()
                Case "pe"
                    BtnPO.Enabled = True
                    BtnPO.Focus()
                Case "klien"
                    BtnArea.Focus()
                Case "distributor"
                    BtnArea.Focus()
                Case "area"
                    BtnSubArea.Focus()
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
                        TIdDivisi.Text = GridPanel.Rows.Item(i).Cells(1).Value
                    Case "subdivisi"
                        TSubDivisi.Text = GridPanel.Rows.Item(i).Cells(0).Value
                        TIdSubDivisi.Text = GridPanel.Rows.Item(i).Cells(1).Value
                    Case "jnspengajuan"
                        TJnsPengajuan.Text = GridPanel.Rows.Item(i).Cells(0).Value
                        TIdJnsPengajuan.Text = GridPanel.Rows.Item(i).Cells(1).Value
                    Case "area"
                        TArea.Text = GridPanel.Rows.Item(i).Cells(0).Value
                        TIdArea.Text = GridPanel.Rows.Item(i).Cells(1).Value
                    Case "subarea"
                        TSubArea.Text = GridPanel.Rows.Item(i).Cells(0).Value
                        TIdPropinsi.Text = GridPanel.Rows.Item(i).Cells(1).Value
                        TIdKota.Text = GridPanel.Rows.Item(i).Cells(2).Value
                    Case "klien"
                        TKlien.Text = GridPanel.Rows.Item(i).Cells(0).Value
                        TIdKlien.Text = GridPanel.Rows.Item(i).Cells(1).Value
                    Case "distributor"
                        TKlien.Text = GridPanel.Rows.Item(i).Cells(0).Value
                        TIdKlien.Text = GridPanel.Rows.Item(i).Cells(1).Value
                    Case "pe"
                        TPE.Text = GridPanel.Rows.Item(i).Cells(0).Value
                        TIdPE.Text = GridPanel.Rows.Item(i).Cells(1).Value
                    Case "po"
                        TPO.Text = GridPanel.Rows.Item(i).Cells(0).Value
                        TIdPO.Text = GridPanel.Rows.Item(i).Cells(1).Value
                End Select
                GridPanel.ClearSelection()
                LPanel.Text = ""
                PanelSurvei.Visible = False
                Select Case LoadDt
                    Case "divisi"
                        BtnSubDivisi.Focus()
                    Case "subdivisi"
                        BtnJnsMaju.Focus()
                    Case "jnspengajuan"
                        RBAdaPE.Focus()
                    Case "pe"
                        BtnPO.Enabled = True
                        BtnPO.Focus()
                    Case "klien"
                        BtnArea.Focus()
                    Case "distributor"
                        BtnArea.Focus()
                    Case "area"
                        BtnSubArea.Focus()
                End Select
            End If
        End If
    End Sub

    Private Sub BtnTutupPanel_Click(sender As Object, e As EventArgs) Handles BtnTutupPanel.Click
        GridPanel.ClearSelection()
        LPanel.Text = ""
        PanelSurvei.Visible = False
    End Sub

    Private Sub BtnProsesMaju_Click(sender As Object, e As EventArgs) Handles BtnProsesMaju.Click
        Dim hr As TimeSpan
        Dim berangkat As Date
        Dim pulang As Date
        Dim s As String
        Dim c As String
        Dim i As Integer
        Dim tbl As New DataTable
        Dim cmd As New OdbcCommand
        Dim paket As Boolean


        If TIdDivisi.Text = "" Then
            MsgBox("Pilih dulu Divisi-nya !!...", MsgBoxStyle.Information, "Information")
            BtnDivisi.Focus()
            Exit Sub
        ElseIf TIdSubDivisi.Text = "" Then
            MsgBox("Pilih dulu Sub Divisi-nya !!...", MsgBoxStyle.Information, "Information")
            BtnSubDivisi.Focus()
            Exit Sub
        ElseIf TIdJnsPengajuan.Text = "" Then
            MsgBox("Pilih dulu Jenis Pengajuan-nya !!...", MsgBoxStyle.Information, "Information")
            BtnJnsMaju.Focus()
            Exit Sub
        ElseIf RBAdaPE.Checked = False And RBBelumPE.Checked = False And RBTidakPE.Checked = False Then
            MsgBox("Pilih dulu Status PE nya !!...", MsgBoxStyle.Information, "Information")
            Exit Sub
        ElseIf RBditagihkan.Checked = False And RBNotagih.Checked = False And RBFixcost.Checked = False Then
            MsgBox("Pilih dulu Status Penagihan-nya !!...", MsgBoxStyle.Information, "Information")
            Exit Sub
        ElseIf RBtunai.Checked = False And RBtransfer.Checked = False Then
            MsgBox("Pilih dulu Sumber Dana-nya !!...", MsgBoxStyle.Information, "Information")
            Exit Sub
        ElseIf RBtransfer.Checked = True Then
            If TBank.Text = "" Or TNoRek.Text = "" Then
                MsgBox("Jika Transfer isi dulu Nama Bank dan No.Rekeningnya !!...", MsgBoxStyle.Information, "Information")
                Exit Sub
            End If
        End If

        If BtnProsesMaju.Text = "PROSES ENTRY" Then
            Me.Cursor = Cursors.WaitCursor
            If TIdJnsPengajuan.Text = "14" Or TIdJnsPengajuan.Text = "15" Or TIdJnsPengajuan.Text = "16" Then
                PFee.Visible = True
                BtnProsesMaju.Enabled = False
                Torang.Focus()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            berangkat = DTBerangkat.Value
            pulang = DTPulang.Value
            hr = pulang.Subtract(berangkat)
            THari.Text = hr.Days + 1

            GGVM_conn()
            'INSERT PENGAJUAN
            s = ""
            s = s & " select nopengajuan,blnpengajuan from counter"
            da = New Odbc.OdbcDataAdapter(s, conn)
            ds.Clear()
            tbl = New DataTable
            tbl.Clear()
            da.Fill(tbl)

            Dim nourut As String
            Dim divisi As String
            Dim bln As String
            Dim thn As String

            Dim count As Integer
            Dim blnskrng As Integer

            blnskrng = Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(DTTanggal.Text, 5), 2)
            If blnskrng = tbl.Rows(0)("blnpengajuan") Then
                count = tbl.Rows(0)("nopengajuan")
            Else
                count = 0
            End If
            count = count + 1
            divisi = Microsoft.VisualBasic.Right("00" & Trim(TIdDivisi.Text), 2)
            nourut = Microsoft.VisualBasic.Right("0000" & count, 4)
            bln = bulan(DTTanggal.Text)
            thn = Microsoft.VisualBasic.Right(DTTanggal.Text, 4)
            nourut = nourut + "/GGVM-" + divisi + "/" + bln + "/" + thn

            c = ""
            If count = 1 Then
                c = c & " update counter set nopengajuan = '" & count & "',"
                c = c & " blnpengajuan = '" & Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(DTTanggal.Text, 5), 2) & "'"
            Else
                c = c & " update counter set nopengajuan = '" & count & "'"
            End If
            cmd = New Odbc.OdbcCommand(c, conn)
            cmd.ExecuteNonQuery()


            c = ""
            c = c & " insert into pengajuan (nopengajuan,idsubdivisi,idjnspengajuan,tanggal,idstatus_pe, "
            If TIdPE.Text <> "" Then
                c = c & " idpe,"
            End If
            If TIdPO.Text <> "" Then
                c = c & " idpo,"
            End If
            If TIdKlien.Text <> "" Then
                c = c & " idklien,"
            End If
            If TIdArea.Text <> "" Then
                c = c & " idarea, "
            End If
            If TIdPropinsi.Text <> "" Then
                c = c & " idpropinsi,"
            End If
            c = c & " statustagih, sumberdana, "
            If TBank.Text <> "" Then
                c = c & "nama_bank,"
            End If
            If TNoRek.Text <> "" Then
                c = c & "no_rekening,"
            End If
            If TKeterangan.Text <> "" Then
                c = c & "keterangan,"
            End If
            c = c & " waktu_berangkat,waktu_pulang,jml_hari,jml_kota,jml_toko,jml_orang,nominal,"
            c = c & " time_input,user_input)"
            c = c & " values ('" & nourut & "','" & TIdSubDivisi.Text & "','" & TIdJnsPengajuan.Text & "','" & Format(DTTanggal.Value, "yyyy-MM-dd") & "','" & TIdStatusPE.Text & "',"
            If TIdPE.Text <> "" Then
                c = c & "'" & TIdPE.Text & "',"
            End If
            If TIdPO.Text <> "" Then
                c = c & "'" & TIdPO.Text & "',"
            End If
            If TIdKlien.Text <> "" Then
                c = c & " '" & TIdKlien.Text & "',"
            End If
            If TIdArea.Text <> "" Then
                c = c & "'" & TIdArea.Text & "',"
            End If
            If TIdPropinsi.Text <> "" Then
                c = c & "'" & TIdPropinsi.Text & "',"
            End If
            c = c & "'" & TIdStatusTagih.Text & "',"
            If RBtunai.Checked = True Then
                c = c & "'T',"
            Else
                c = c & "'B',"
            End If
            If TBank.Text <> "" Then
                c = c & "'" & TBank.Text & "',"
            End If
            If TNoRek.Text <> "" Then
                c = c & "'" & TNoRek.Text & "',"
            End If
            If TKeterangan.Text <> "" Then
                c = c & "'" & Microsoft.VisualBasic.RTrim(TKeterangan.Text) & "',"
            End If
            c = c & "'" & Format(DTBerangkat.Value, "yyyy/MM/dd hh:mm:dd") & "','" & Format(DTPulang.Value, "yyyy/MM/dd hh:mm:dd") & "','" & THari.Text & "','" & TJmlKota.Text & "','" & TJmlToko.Text & "','" & TJmlOrng.Text & "','0',"
            c = c & "now(),'" & userid & "')"
            cmd = New OdbcCommand(c, conn)
            cmd.ExecuteNonQuery()

            s = ""
            s = s & " select max(idpengajuan)as id from pengajuan "
            da = New Odbc.OdbcDataAdapter(s, conn)
            tbl = New DataTable
            tbl.Clear()
            da.Fill(tbl)
            TIdPengajuan.Text = tbl.Rows(0)("id")
            TNoPengajuan.Text = nourut


            Select Case Trim(TIdJnsPengajuan.Text)
                Case "8"
                    'even 
                    paket = True
                    s = ""
                    s = s & " select idbarang,kdbarang,barang,idsatuan,hpp from barang"
                    s = s & " where idsubkel  in('43' ) "
                    s = s & " and status='1'"
                    s = s & " order by idbarang"
                Case "14"
                    'even 
                    paket = True
                    s = ""
                    s = s & " select idbarang,kdbarang,barang,idsatuan,hpp from barang"
                    s = s & " where idbarang  in('325','1289' ) "
                    s = s & " and status='1'"
                    s = s & " order by idbarang"
                Case "15"
                    'even 
                    paket = True
                    s = ""
                    s = s & " select idbarang,kdbarang,barang,idsatuan,hpp from barang"
                    s = s & " where idbarang  in('325','1289' ) "
                    s = s & " and status='1'"
                    s = s & " order by idbarang"
            End Select

            GGVM_conn_close()
            If paket = True Then
                da = New Odbc.OdbcDataAdapter(s, conn)
                tbl = New DataTable
                tbl.Clear()
                da.Fill(tbl)

                GGVM_conn()
                For i = 0 To tbl.Rows.Count - 1
                    c = ""
                    c = c & " insert into detail_pengajuan (idpengajuan, idbarang,kdbarang,barang, "
                    c = c & " idsatuan,type_pengajuan,jml_barang,jml_orang,jml_hari,harga_estimasi,sub_total)"
                    c = c & " values ('" & TIdPengajuan.Text & "','" & tbl.Rows(i)("idbarang") & "','" & tbl.Rows(i)("kdbarang") & "','" & tbl.Rows(i)("barang") & "',"
                    c = c & "'" & tbl.Rows(i)("idsatuan") & "','B','1','" & TJmlOrng.Text & "','" & THari.Text & "','" & tbl.Rows(i)("hpp") & "','0')"
                    cmd = New Odbc.OdbcCommand(c, conn)
                    cmd.ExecuteNonQuery()
                Next
                GGVM_conn_close()
                TampilDetail()
            End If

            BtnProsesMaju.Enabled = False
            BtnTambahMaju.Enabled = True
            BtnEditMaju.Enabled = True
            Me.Cursor = Cursors.Default
        Else
            'EDIT DATA PENGAJUAN

            Me.Cursor = Cursors.WaitCursor
            GGVM_conn()
            c = ""
            c = c & " update pengajuan set"
            c = c & " idstatus_pe = '" & TIdStatusPE.Text & "',"
            If TIdPE.Text <> "" Then
                c = c & " idpe = '" & TIdPE.Text & "',"
            End If
            If TIdPO.Text <> "" Then
                c = c & " idpo = '" & TIdPO.Text & "',"
            End If
            If TIdKlien.Text <> "" Then
                c = c & " idklien = '" & TIdKlien.Text & "',"
            End If
            If TIdArea.Text <> "" Then
                c = c & " idarea = '" & TIdArea.Text & "',"
            End If
            If TIdPropinsi.Text <> "" Then
                c = c & " idpropinsi = '" & TIdPropinsi.Text & "',"
            End If
            c = c & " statustagih = '" & TIdStatusTagih.Text & "',"
            If RBtunai.Checked = True Then
                c = c & "sumberdana = 'T',"
            End If
            If RBtransfer.Checked = True Then
                c = c & "sumberdana = 'B',"
            End If
            If TBank.Text <> "" Then
                c = c & " nama_bank = '" & TBank.Text & "',"
            End If
            If TNoRek.Text <> "" Then
                c = c & " no_rekening = '" & TNoRek.Text & "',"
            End If
            c = c & " waktu_berangkat = '" & Format(DTBerangkat.Value, "yyyy/MM/dd hh:mm:dd") & "',"
            c = c & " waktu_pulang = '" & Format(DTPulang.Value, "yyyy/MM/dd hh:mm:dd") & "',"
            c = c & " jml_hari = '" & THari.Text & "',"
            c = c & " jml_kota = '" & TJmlKota.Text & "',"
            c = c & " jml_toko = '" & TJmlToko.Text & "',"
            c = c & " time_koreksi = now(),"
            c = c & " user_koreksi = '" & userid & "',"
            c = c & " keterangan = '" & TKeterangan.Text & "'"
            c = c & " where idpengajuan = '" & TIdPengajuan.Text & "'"
            cmd = New OdbcCommand(c, conn)
            cmd.ExecuteNonQuery()

            Me.Cursor = Cursors.Default
            GGVM_conn_close()
            MsgBox("Data sudah di-EDIT !!!...", MsgBoxStyle.Information, "Information")
        End If
    End Sub

    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        Dim keluar As MsgBoxResult
        Dim f As New FrmTampilSPGPengajuan
        keluar = MsgBox("Apakah anda yakin untuk keluar program ?...", MsgBoxStyle.YesNo, "Peringatan")
        If keluar = MsgBoxResult.Yes Then
            Me.Close()
            'f.Show()
            Exit Sub
        End If
    End Sub

    Private Sub RBAdaPE_CheckedChanged(sender As Object, e As EventArgs) Handles RBAdaPE.CheckedChanged
        If RBAdaPE.Checked = True Then
            BtnPE.Enabled = True
            BtnKlien.Enabled = False
            BtnArea.Enabled = False
            BtnSubArea.Enabled = False
            RBditagihkan.Enabled = True
            RBditagihkan.Checked = True
            RBFixcost.Enabled = True
            RBNotagih.Enabled = False
            TIdStatusPE.Text = "1"
            BtnPE.Focus()
        Else
            BtnPE.Enabled = False
            BtnPO.Enabled = False
            BtnKlien.Enabled = False
            BtnArea.Enabled = False
            BtnSubArea.Enabled = False
            RBditagihkan.Enabled = False
            RBditagihkan.Checked = False
            RBFixcost.Enabled = False
            RBFixcost.Checked = False
            RBNotagih.Enabled = False
        End If

    End Sub

    Private Sub RBAdaPE_Click(sender As Object, e As EventArgs) Handles RBAdaPE.Click
        If RBAdaPE.Checked = True Then
            BtnPE.Enabled = True
            BtnKlien.Enabled = False
            BtnArea.Enabled = False
            BtnSubArea.Enabled = False
            RBditagihkan.Enabled = True
            RBditagihkan.Checked = True
            RBFixcost.Enabled = True
            RBNotagih.Enabled = False
            TIdStatusPE.Text = "1"
            BtnPE.Focus()
        Else
            BtnPE.Enabled = False
            BtnPO.Enabled = False
            BtnKlien.Enabled = False
            BtnArea.Enabled = False
            BtnSubArea.Enabled = False
            RBditagihkan.Enabled = False
            RBditagihkan.Checked = False
            RBFixcost.Enabled = False
            RBFixcost.Checked = False
            RBNotagih.Enabled = False
        End If

    End Sub
    Private Sub LoadPE()
        Dim s As String

        GGVM_conn()
        s = ""
        s = s & " select nope,idpe from proyek"
        s = s & " where iddivisi = 3"
        s = s & " and time_closing is NULL"
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "proyek")

        GridPanel.DataSource = ds.Tables("jenis_pengajuan")
        GGVM_conn_close()
        If GridPanel.RowCount = 0 Then
            MsgBox("Data PE tidak ada !!..", MsgBoxStyle.Information, "Information")
            LPanel.Text = ""
            PanelSurvei.Visible = False
            Exit Sub
        Else
            GridPanel.Refresh()
            GridPanel.Columns(0).HeaderText = "NO.PE"
            GridPanel.Columns(1).HeaderText = "ID PE"
            GridPanel.Columns(0).Width = 500
            GridPanel.Columns(1).Width = 50
        End If

    End Sub

    Private Sub LoadPO()
        'Dim s As String

        's = " select pengajuan,idjnspengajuan from jenis_pengajuan"
        's = s & " where idjnspengajuan IN ( 2,3,4)"
        's = s & " order by pengajuan"
        'da = New Odbc.OdbcDataAdapter(s, conn)
        'ds = New DataSet
        ds.Clear()
        'da.Fill(ds, "jenis_pengajuan")

        'GridPanel.DataSource = ds.Tables("jenis_pengajuan")
        GridPanel.Refresh()
        GridPanel.Columns(0).HeaderText = "NO.PURCHASE ORDER"
        GridPanel.Columns(1).HeaderText = "ID PO"
        GridPanel.Columns(0).Width = 500
        GridPanel.Columns(1).Width = 50

    End Sub

    Private Sub BtnPE_Click(sender As Object, e As EventArgs) Handles BtnPE.Click
        LoadDt = "pe"
        PanelSurvei.Visible = True
        LoadPE()
        MsgBox("Data blm ada")
        GridPanel.Focus()
    End Sub

    Private Sub BtnPO_Click(sender As Object, e As EventArgs) Handles BtnPO.Click
        LoadDt = "po"
        PanelSurvei.Visible = True
        LoadPO()
        MsgBox("Data blm ada")
        GridPanel.Focus()
    End Sub

    Private Sub RBBelumPE_CheckedChanged(sender As Object, e As EventArgs) Handles RBBelumPE.CheckedChanged
        If RBBelumPE.Checked = True Then
            BtnPE.Enabled = False
            BtnPO.Enabled = False
            BtnKlien.Enabled = True
            BtnArea.Enabled = True
            BtnSubArea.Enabled = True
            RBditagihkan.Enabled = True
            RBNotagih.Enabled = True
            RBFixcost.Enabled = True
            TIdStatusPE.Text = "2"
            RBKlien.Checked = True
            BtnKlien.Focus()
        Else
            BtnPE.Enabled = False
            BtnPO.Enabled = False
            BtnKlien.Enabled = False
            BtnArea.Enabled = False
            BtnSubArea.Enabled =
            RBditagihkan.Enabled = False
            RBNotagih.Enabled = False
            RBFixcost.Enabled = False
        End If
    End Sub

    Private Sub RBBelumPE_Click(sender As Object, e As EventArgs) Handles RBBelumPE.Click
        If RBBelumPE.Checked = True Then
            BtnPE.Enabled = False
            BtnPO.Enabled = False
            BtnKlien.Enabled = True
            BtnArea.Enabled = True
            BtnSubArea.Enabled = True
            RBditagihkan.Enabled = True
            RBNotagih.Enabled = True
            RBFixcost.Enabled = True
            TIdStatusPE.Text = "2"
            BtnKlien.Focus()
        Else
            BtnPE.Enabled = False
            BtnPO.Enabled = False
            BtnKlien.Enabled = False
            BtnArea.Enabled = False
            BtnSubArea.Enabled =
            RBditagihkan.Enabled = False
            RBNotagih.Enabled = False
            RBFixcost.Enabled = False
        End If
    End Sub

    Private Sub RBKlien_CheckedChanged(sender As Object, e As EventArgs) Handles RBKlien.CheckedChanged
        If RBKlien.Checked = True Then
            BtnKlien.Focus()
        End If
    End Sub

    Private Sub RBKlien_Click(sender As Object, e As EventArgs) Handles RBKlien.Click
        If RBKlien.Checked = True Then
            BtnKlien.Focus()
        End If
    End Sub

    Private Sub RBDistributor_CheckedChanged(sender As Object, e As EventArgs) Handles RBDistributor.CheckedChanged
        If RBDistributor.Checked = True Then
            BtnKlien.Focus()
        End If
    End Sub

    Private Sub RBDistributor_Click(sender As Object, e As EventArgs) Handles RBDistributor.Click
        If RBDistributor.Checked = True Then
            BtnKlien.Focus()
        End If
    End Sub

    Private Sub RBTidakPE_CheckedChanged(sender As Object, e As EventArgs) Handles RBTidakPE.CheckedChanged
        If RBTidakPE.Checked = True Then
            BtnPE.Enabled = False
            BtnPO.Enabled = False
            BtnKlien.Enabled = True
            BtnArea.Enabled = True
            BtnSubArea.Enabled = True
            RBditagihkan.Enabled = False
            RBNotagih.Enabled = True
            RBFixcost.Enabled = True
            TIdStatusPE.Text = "3"
            BtnKlien.Focus()
        Else
            BtnPE.Enabled = False
            BtnPO.Enabled = False
            BtnKlien.Enabled = False
            BtnArea.Enabled = False
            BtnSubArea.Enabled = False
            RBditagihkan.Enabled = False
            RBNotagih.Enabled = False
            RBFixcost.Enabled = False

        End If
    End Sub

    Private Sub RBTidakPE_Click(sender As Object, e As EventArgs) Handles RBTidakPE.Click
        If RBTidakPE.Checked = True Then
            BtnPE.Enabled = False
            BtnPO.Enabled = False
            BtnKlien.Enabled = True
            BtnArea.Enabled = True
            BtnSubArea.Enabled = True
            RBditagihkan.Enabled = False
            RBNotagih.Enabled = True
            RBFixcost.Enabled = True
            TIdStatusPE.Text = "3"
            BtnKlien.Focus()
        Else
            BtnPE.Enabled = False
            BtnPO.Enabled = False
            BtnKlien.Enabled = False
            BtnArea.Enabled = False
            BtnSubArea.Enabled = False
            RBditagihkan.Enabled = False
            RBNotagih.Enabled = False
            RBFixcost.Enabled = False

        End If
    End Sub

    Private Sub BtnArea_Click(sender As Object, e As EventArgs) Handles BtnArea.Click
        LoadDt = "area"
        PanelSurvei.Visible = True
        LoadArea()
        GridPanel.Focus()
    End Sub

    Private Sub BtnArea_KeyPress(sender As Object, e As KeyPressEventArgs) Handles BtnArea.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            LoadDt = "area"
            PanelSurvei.Visible = True
            LoadArea()
            GridPanel.Focus()
        End If
    End Sub

    Private Sub BtnSubArea_Click(sender As Object, e As EventArgs) Handles BtnSubArea.Click
        LoadDt = "subarea"
        PanelSurvei.Visible = True
        LoadSubArea()
        GridPanel.Focus()
    End Sub

    Private Sub BtnSubArea_KeyPress(sender As Object, e As KeyPressEventArgs) Handles BtnSubArea.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            LoadDt = "subarea"
            PanelSurvei.Visible = True
            LoadSubArea()
            GridPanel.Focus()
        End If
    End Sub

    Private Sub BtnTambahMaju_Click(sender As Object, e As EventArgs) Handles BtnTambahMaju.Click
        StsItem = "Entry"
        PItem.Visible = True
        PTItem.Text = ""
        PTKelompok.Text = ""
        PTIdKelompok.Text = ""
        PTSubKel.Text = ""
        PTIdSubKel.Text = ""
        PTBarang.Text = ""
        PTIdBarang.Text = ""
        PTKdBarang.Text = ""
        PTKeterangan.Text = ""
        PTHrgEstimasi.Text = "0"
        PTSubTotal.Text = "0"

        PTJml.Text = "1"
        PTJmlHari.Text = THari.Text
        PTJmlOrang.Text = TJmlOrng.Text
        BtnKelompok.Focus()
        PTCariBrg.Text = ""

    End Sub

    Private Sub BtnEditMaju_Click(sender As Object, e As EventArgs) Handles BtnEditMaju.Click
        Dim ada As Boolean
        Dim brs, jmldt As Integer
        Dim s As String
        Dim tblC As New DataTable

        ada = False
        jmldt = 0
        For i = 0 To ListItem.Items.Count - 1
            If ListItem.Items(i).Checked = True Then
                ada = True
                brs = i
                jmldt = jmldt + 1
            End If
        Next
        If ada = False Then
            MsgBox("Tidak ada data yang akan di EDIT, Pilih dulu datanya!!...", MsgBoxStyle.Information, "Information")
            ListItem.Focus()
            Exit Sub
        End If
        If jmldt > 1 Then
            MsgBox("Hanya 1(satu) data yg bisa di-EDIT !!...", MsgBoxStyle.Information, "Information")
            ListItem.Focus()
            Exit Sub
        End If

        If MsgBox("Pilih [Yes] untuk EDIT Item atau [No] untuk HAPUS item ???....", MsgBoxStyle.YesNo, "Question") = MsgBoxResult.Yes Then
            StsItem = "Edit"
            PTJml.Enabled = True
            PTJml.Focus()

            PTKeterangan.Focus()
        Else
            StsItem = "Delete"
            BtnSimpanBrg.Focus()
        End If
        PTItem.Text = ListItem.Items(brs).SubItems(10).Text
        PTIdBarang.Text = ListItem.Items(brs).SubItems(9).Text
        PTKdBarang.Text = ListItem.Items(brs).SubItems(0).Text
        PTBarang.Text = ListItem.Items(brs).SubItems(1).Text
        PTKeterangan.Text = ListItem.Items(brs).SubItems(2).Text
        PTSatuan.Text = ListItem.Items(brs).SubItems(3).Text
        PTJml.Text = ListItem.Items(brs).SubItems(4).Text
        PTJmlOrang.Text = ListItem.Items(brs).SubItems(5).Text
        PTJmlHari.Text = ListItem.Items(brs).SubItems(6).Text
        PTHrgEstimasi.Text = FormatNumber(ListItem.Items(brs).SubItems(7).Text, 0, , , TriState.True)
        PTSubTotal.Text = FormatNumber(ListItem.Items(brs).SubItems(8).Text, 0, , , TriState.True)
        PTIdSatuan.Text = ListItem.Items(brs).SubItems(11).Text

        If TIdJnsPengajuan.Text = "14" Or TIdJnsPengajuan.Text = "15" Or TIdJnsPengajuan.Text = "16" Then
            PTBank.Enabled = True
            PTRek.Enabled = True
            PTPenerima.Enabled = True
            TNikKtp.Enabled = True
            TNpwp.Enabled = True
            TAlamat.Enabled = True
            PTBank.Text = ""
            PTRek.Text = ""
            PTPenerima.Text = ""
            TNikKtp.Text = ""
            TNpwp.Text = ""
            TAlamat.Text = ""

            s = ""
            s = s & " select * from trans_detail_pengajuan_pph"
            s = s & " where iddetailpengajuan_fee = '" & PTItem.Text & "'"
            da = New Odbc.OdbcDataAdapter(s, conn)
            tblC = New DataTable
            tblC.Clear()
            da.Fill(tblC)
            If tblC.Rows.Count > 0 Then
                PTBank.Text = tblC.Rows(0)("bank")
                PTRek.Text = tblC.Rows(0)("norekening")
                PTPenerima.Text = tblC.Rows(0)("penerima")
                TNikKtp.Text = tblC.Rows(0)("nik_ktp")
                TNpwp.Text = tblC.Rows(0)("npwp")
                TAlamat.Text = tblC.Rows(0)("alamat")
            End If
        Else
            PTBank.Enabled = False
            PTRek.Enabled = False
            PTPenerima.Enabled = False
            TNikKtp.Enabled = False
            TNpwp.Enabled = False
            TAlamat.Enabled = False
        End If
        PItem.Visible = True
    End Sub

    Private Sub BtnKelompok_Click(sender As Object, e As EventArgs) Handles BtnKelompok.Click
        LoadKelompok()
        Loadbrg = "Kelompok"
    End Sub

    Private Sub BtnKelompok_KeyPress(sender As Object, e As KeyPressEventArgs) Handles BtnKelompok.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            LoadKelompok()
            Loadbrg = "Kelompok"
        End If
    End Sub

    Private Sub BtnSubKel_Click(sender As Object, e As EventArgs) Handles BtnSubKel.Click
        LoadSubKelompok()
        Loadbrg = "SubKelompok"
    End Sub

    Private Sub BtnSubKel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles BtnSubKel.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            LoadSubKelompok()
            Loadbrg = "SubKelompok"
        End If
    End Sub

    Private Sub LoadKelompok()
        Dim s As String

        GGVM_conn()
        s = " select kelompok,idkelompok from kelompok where idkelompok in ('1','2','5','4') and status='1'  order by kelompok "
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "kelompok")

        DtBrg.DataSource = ds.Tables("kelompok")
        GGVM_conn_close()
        If DtBrg.RowCount = 1 Then
            MsgBox("Data tidak ada !!..", MsgBoxStyle.Information, "Information")
            BtnKelompok.Focus()
        End If
        DtBrg.AutoResizeColumns()
        DtBrg.Refresh()
        DtBrg.Focus()
    End Sub

    Private Sub LoadSubKelompok()
        Dim s As String

        GGVM_conn()
        s = ""
        s = s & " select xsubkel.* from ("
        s = s & " select a.subkel ,a.idsubkel  from subkelompok a, kelompok b"
        s = s & " where a.status = '1' "
        s = s & " and b.idkelompok = '" & Trim(PTIdKelompok.Text) & "'"
        s = s & " and a.idkelompok = b.idkelompok"
        s = s & " order by subkel ) xsubkel "
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "subkelompok")

        DtBrg.DataSource = ds.Tables("Subkelompok")
        GGVM_conn_close()
        If DtBrg.RowCount = 1 Then
            MsgBox("Data tidak ada !!..", MsgBoxStyle.Information, "Information")
            BtnSubKel.Focus()
        End If
        DtBrg.AutoResizeColumns()
        DtBrg.Refresh()
        DtBrg.Focus()
    End Sub

    Private Sub BtnBarang_Click(sender As Object, e As EventArgs) Handles BtnBarang.Click
        LoadBarang()
        Loadbrg = "Barang"
    End Sub

    Private Sub BtnBarang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles BtnBarang.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            LoadBarang()
            Loadbrg = "Barang"
        End If
    End Sub
    Private Sub LoadBarang()
        Dim s As String

        DtBrg.DataSource = Nothing

        GGVM_conn()
        s = ""
        s = s & " select xbrg.* from ( "
        s = s & " select a.barang as BARANG ,a.kdbarang AS KDBARANG,a.hpp as HARGA_ESTIMASI ,c.satuan AS SATUAN,a.idbarang AS IDBARANG,c.idsatuan AS IDSATUAN"
        s = s & " from barang a, satuan c"
        s = s & " where a.idsubkel='" & Trim(PTIdSubKel.Text) & "'"
        s = s & " and a.status='1'"
        s = s & " and a.idsatuan = c.idsatuan"
        s = s & " order by a.barang ) as xbrg"

        da = New Odbc.OdbcDataAdapter(s, conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "xbrg")

        DtBrg.DataSource = ds.Tables("xbrg")
        DtBrg.AutoResizeColumns()
        GGVM_conn_close()

        If DtBrg.RowCount = 1 Then
            MsgBox("Data tidak ada !!..", MsgBoxStyle.Information, "Information")
            BtnBarang.Focus()
        End If
        DtBrg.Refresh()
        DtBrg.Focus()
    End Sub

    Private Sub BtnSatuan_Click(sender As Object, e As EventArgs) Handles BtnSatuan.Click
        Loadbrg = "Satuan"
        LoadSatuan()
    End Sub

    Private Sub BtnSatuan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles BtnSatuan.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            Loadbrg = "Satuan"
            LoadSatuan()
        End If
    End Sub
    Private Sub LoadSatuan()
        Dim s As String

        DtBrg.DataSource = Nothing

        GGVM_conn()
        s = ""
        s = s & " select satuan,idsatuan "
        s = s & " from satuan "
        s = s & " order by satuan "

        da = New Odbc.OdbcDataAdapter(s, conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "satuan")

        DtBrg.DataSource = ds.Tables("satuan")
        DtBrg.AutoResizeColumns()
        GGVM_conn_close()

        If DtBrg.RowCount = 1 Then
            MsgBox("Data tidak ada !!..", MsgBoxStyle.Information, "Information")
            BtnSatuan.Focus()
        End If
        DtBrg.Refresh()
        DtBrg.Focus()
    End Sub

    Private Sub DtBrg_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtBrg.CellContentClick

    End Sub

    Private Sub DtBrg_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtBrg.CellDoubleClick
        Dim i As Integer

        i = DtBrg.CurrentRow.Index
        Select Case Loadbrg
            Case "Kelompok"
                PTKelompok.Text = DtBrg.Rows.Item(i).Cells(0).Value
                PTIdKelompok.Text = DtBrg.Rows.Item(i).Cells(1).Value
                DtBrg.DataSource = Nothing
                BtnSubKel.Focus()
            Case "SubKelompok"
                PTSubKel.Text = DtBrg.Rows.Item(i).Cells(0).Value
                PTIdSubKel.Text = DtBrg.Rows.Item(i).Cells(1).Value
                DtBrg.DataSource = Nothing
                BtnBarang.Focus()
            Case "Barang"
                PTBarang.Text = DtBrg.Rows.Item(i).Cells(0).Value
                PTKdBarang.Text = DtBrg.Rows.Item(i).Cells(1).Value
                PTHrgEstimasi.Text = DtBrg.Rows.Item(i).Cells(2).Value
                PTSatuan.Text = DtBrg.Rows.Item(i).Cells(3).Value
                PTIdBarang.Text = DtBrg.Rows.Item(i).Cells(4).Value
                PTIdSatuan.Text = DtBrg.Rows.Item(i).Cells(5).Value
                DtBrg.DataSource = Nothing
                BtnSatuan.Focus()
            Case "Satuan"
                PTSatuan.Text = DtBrg.Rows.Item(i).Cells(0).Value
                PTIdSatuan.Text = DtBrg.Rows.Item(i).Cells(1).Value
                DtBrg.DataSource = Nothing
                PTJml.Focus()
        End Select
    End Sub

    Private Sub DtBrg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DtBrg.KeyPress
        Dim i As Integer

        i = DtBrg.CurrentRow.Index
        i = i - 1
        Select Case Loadbrg
            Case "Kelompok"
                PTKelompok.Text = DtBrg.Rows.Item(i).Cells(0).Value
                PTIdKelompok.Text = DtBrg.Rows.Item(i).Cells(1).Value
                DtBrg.DataSource = Nothing
                BtnSubKel.Focus()
            Case "SubKelompok"
                PTSubKel.Text = DtBrg.Rows.Item(i).Cells(0).Value
                PTIdSubKel.Text = DtBrg.Rows.Item(i).Cells(1).Value
                DtBrg.DataSource = Nothing
                BtnBarang.Focus()
            Case "Barang"
                PTBarang.Text = DtBrg.Rows.Item(i).Cells(0).Value
                PTKdBarang.Text = DtBrg.Rows.Item(i).Cells(1).Value
                PTHrgEstimasi.Text = DtBrg.Rows.Item(i).Cells(2).Value
                PTSatuan.Text = DtBrg.Rows.Item(i).Cells(3).Value
                PTIdBarang.Text = DtBrg.Rows.Item(i).Cells(4).Value
                PTIdSatuan.Text = DtBrg.Rows.Item(i).Cells(5).Value
                DtBrg.DataSource = Nothing
                BtnSatuan.Focus()
            Case "Satuan"
                PTSatuan.Text = DtBrg.Rows.Item(i).Cells(0).Value
                PTIdSatuan.Text = DtBrg.Rows.Item(i).Cells(1).Value
                DtBrg.DataSource = Nothing
                PTJml.Focus()
        End Select
    End Sub

    Private Sub BtnSimpanBrg_Click(sender As Object, e As EventArgs) Handles BtnSimpanBrg.Click
        Dim Pph, Fee, Xstotal, Xpph, YPph, YFee, ZPph As Double
        Dim c, s, ketBy As String
        Dim cmd As New OdbcCommand
        Dim tbl, tblC, tblP As DataTable
        Dim PThrg As Double
        Dim PTSttl, Pembagi As Double


        'MAINTENAN ITEM
        Me.Cursor = Cursors.WaitCursor
        PThrg = PTHrgEstimasi.Text
        PTSttl = PTSubTotal.Text

        GGVM_conn()
        Select Case StsItem
            Case "Entry"
                If TIdJnsPengajuan.Text = "14" Or TIdJnsPengajuan.Text = "15" Or TIdJnsPengajuan.Text = "16" Then
                    If PTIdBarang.Text <> "325" And PTIdBarang.Text <> "1881" And PTIdBarang.Text <> "1882" And PTIdBarang.Text <> "1888" Then
                        MsgBox("Hanya bisa nambah kode barang 325 (FEE SPEAKER ) 1881 (FEE MODERATOR) 1882 (FEE FASILITATOR) 1888 (FEE KONSULTAN) !!...", MsgBoxStyle.Information, "Information")
                        Exit Sub
                    End If
                End If

                c = ""
                c = c & " insert into detail_pengajuan (idpengajuan, idbarang,kdbarang,barang, "
                c = c & " idsatuan,type_pengajuan,jml_barang,jml_orang,jml_hari,harga_estimasi,sub_total,keterangan)"
                c = c & " values ('" & TIdPengajuan.Text & "','" & PTIdBarang.Text & "','" & PTKdBarang.Text & "','" & PTBarang.Text & "',"
                c = c & "'" & PTIdSatuan.Text & "','B','1','" & PTJmlOrang.Text & "','" & PTJmlHari.Text & "','" & PThrg & "','" & PTSttl & "','" & PTKeterangan.Text & "')"
                cmd = New Odbc.OdbcCommand(c, conn)
                cmd.ExecuteNonQuery()

            Case "Edit"
                ketBy = ""
                If TIdJnsPengajuan.Text = "14" Or TIdJnsPengajuan.Text = "15" Or TIdJnsPengajuan.Text = "16" Then
                    If PTSttl = 0 Then
                        Me.Cursor = Cursors.Default
                        MsgBox("Isi dulu harganya !!..")
                        Exit Sub
                    End If
                    If TNikKtp.Text = "" Or TNpwp.Text = "" Then
                        Me.Cursor = Cursors.Default
                        MsgBox("NIK KTP dan No. NPWP harus diisi !!...", MsgBoxStyle.Information, "Information")
                        Exit Sub
                    End If
                    If TNpwp.Text = "0" Or TNpwp.Text = " " Then
                    Else
                        If Microsoft.VisualBasic.Len(TNpwp.Text) <> 15 Then
                            Me.Cursor = Cursors.Default
                            MsgBox("No. NPWP harus diisi 15 digit !!...", MsgBoxStyle.Information, "Information")
                            Exit Sub
                        End If
                    End If

                    Select Case TIdJnsPengajuan.Text
                        Case "14" 'DIPOTONG PAJAK
                            Pembagi = (Fee * 50 / 100)
                            YFee = 0
                            YPph = 0
                            'ADA NPWP
                            If Microsoft.VisualBasic.Len(TNpwp.Text) = 15 Then
                                Fee = PTHrgEstimasi.Text
                                Xpph = (Fee * (2.5 / 100))
                            End If
                            'TIDAK ADA NPWP
                            If (TNpwp.Text = "0") Or (TNpwp.Text = "") Then
                                Fee = PTHrgEstimasi.Text
                                Xpph = ((Fee * (2.5 / 100)) * (120 / 100))
                            End If
                            If Pembagi > 50000000 Then
                                YFee = Pembagi - 50000000
                                If (TNpwp.Text = "0") Or (TNpwp.Text = "") Then
                                    YPph = ((YFee * (15 / 100)) * (120 / 100))
                                Else
                                    YPph = YFee * (15 / 100)
                                End If
                            End If
                            Pph = Xpph + YPph
                            Xstotal = Fee
                        Case "15"
                            Pembagi = (Fee * 50 / 100)
                            YFee = 0
                            YPph = 0
                            'ADA NPWP
                            If Microsoft.VisualBasic.Len(TNpwp.Text) = 15 Then
                                Fee = PTHrgEstimasi.Text
                                Xpph = (Fee * (2.5 / 100))
                            End If
                            'TIDAK ADA NPWP
                            If (TNpwp.Text = "0") Or (TNpwp.Text = "") Then
                                Fee = PTHrgEstimasi.Text
                                Xpph = ((Fee * (2.5 / 100)) * (120 / 100))
                            End If
                            If Pembagi > 50000000 Then
                                YFee = Pembagi - 50000000
                                If (TNpwp.Text = "0") Or (TNpwp.Text = "") Then
                                    YPph = ((YFee * (15 / 100)) * (120 / 100))
                                Else
                                    YPph = YFee * (15 / 100)
                                End If
                            End If
                            Pph = Xpph + YPph
                            Xstotal = Fee + Pph
                        Case "16"
                            Pembagi = (Fee * 50 / 100)
                            YFee = 0
                            YPph = 0
                            ZPph = 0
                            If (TNpwp.Text = "0") Or (TNpwp.Text = "") Then
                                'HITUNGAN DITAGIHKAN
                                Fee = PTHrgEstimasi.Text
                                ZPph = (Fee * (2.5 / 100))
                                'HITUNGAN TIDAK DITAGIHKAN
                                Xpph = ZPph * (20 / 100)
                            End If
                            If Pembagi > 50000000 Then
                                YFee = Pembagi - 50000000
                                YPph = ((YFee * (15 / 100)) * (120 / 100))
                            End If
                            Pph = ZPph + Xpph + YPph
                            Xstotal = Fee + ZPph
                    End Select
                    'Xpph = Pph
                    Pph = Pph * (-1)
                    PThrg = Xstotal
                    PTSttl = Xstotal

                    'cek apa ada di trans_detail_pengajuan_pph
                    s = ""
                    s = s & " select * from trans_detail_pengajuan_pph"
                    s = s & " where iddetailpengajuan_fee = '" & PTItem.Text & "'"
                    da = New Odbc.OdbcDataAdapter(s, conn)
                    tblC = New DataTable
                    tblC.Clear()
                    da.Fill(tblC)
                    If tblC.Rows.Count = 0 Then
                        'belum ada data
                        'INSERT biaya pph21
                        ketBy = PTBank.Text & "/" & PTRek.Text & "/" & PTPenerima.Text & "/Npwp:" & TNpwp.Text
                        c = ""
                        c = c & " insert into detail_pengajuan (idpengajuan, idbarang,kdbarang,barang, "
                        c = c & " idsatuan,type_pengajuan,jml_barang,jml_orang,jml_hari,harga_estimasi,sub_total,keterangan)"
                        c = c & " values ('" & TIdPengajuan.Text & "','1289','001289','BIAYA PPH PS.21 / " & PTKeterangan.Text & " ',"
                        c = c & "'1','B','1','1','1','" & Pph & "','" & Pph & "','" & ketBy & "')"
                        cmd = New Odbc.OdbcCommand(c, conn)
                        cmd.ExecuteNonQuery()

                        s = ""
                        s = s & " select max(iddetail_pengajuan)as id from detail_pengajuan "
                        da = New Odbc.OdbcDataAdapter(s, conn)
                        tblP = New DataTable
                        tblP.Clear()
                        da.Fill(tblP)

                        c = ""
                        c = c & " Insert into trans_detail_pengajuan_pph"
                        c = c & " (idpengajuan,iddetailpengajuan,iddetailpengajuan_fee,idbarang,penerima,npwp,nominal_fee,nominal_pph,alamat,bank,norekening,nik_ktp) values"
                        c = c & " ('" & TIdPengajuan.Text & "','" & tblP.Rows(0)("id") & "','" & PTItem.Text & "','1289',"
                        c = c & " '" & PTPenerima.Text & "','" & TNpwp.Text & "','" & Fee & "','" & Xpph & "','" & TAlamat.Text & "','" & PTBank.Text & "','" & PTRek.Text & "','" & TNikKtp.Text & "')"
                        cmd = New Odbc.OdbcCommand(c, conn)
                        cmd.ExecuteNonQuery()

                    Else
                        'ada data
                        ketBy = PTBank.Text & "/" & PTRek.Text & "/" & PTPenerima.Text & "/Npwp:" & TNpwp.Text
                        s = ""
                        s = s & " select * from trans_detail_pengajuan_pph "
                        s = s & " where iddetailpengajuan_fee='" & PTItem.Text & "'"
                        da = New Odbc.OdbcDataAdapter(s, conn)
                        tblP = New DataTable
                        tblP.Clear()
                        da.Fill(tblP)

                        c = ""
                        c = c & " update detail_pengajuan set"
                        c = c & " barang ='BIAYA PPH PS.21 / " & PTKeterangan.Text & "' ,"
                        c = c & " keterangan='" & ketBy & "',"
                        c = c & " harga_estimasi='" & Pph & "',"
                        c = c & " sub_Total='" & Pph & "'"
                        c = c & " where iddetail_pengajuan='" & tblP.Rows(0)("iddetailpengajuan") & "'"
                        cmd = New Odbc.OdbcCommand(c, conn)
                        cmd.ExecuteNonQuery()

                        c = ""
                        c = c & " update trans_detail_pengajuan_pph set"
                        c = c & " bank='" & PTBank.Text & "',"
                        c = c & " norekening='" & PTRek.Text & "',"
                        c = c & " penerima='" & PTPenerima.Text & "',"
                        c = c & " nik_ktp='" & TNikKtp.Text & "',"
                        c = c & " npwp='" & TNpwp.Text & "',"
                        c = c & " alamat='" & TAlamat.Text & "',"
                        c = c & " nominal_fee='" & Fee & "',"
                        c = c & " nominal_pph='" & Xpph & "'"
                        c = c & " where iddetailpengajuan_fee='" & PTItem.Text & "'"
                        c = c & " and iddetailpengajuan='" & tblP.Rows(0)("iddetailpengajuan") & "'"
                        cmd = New Odbc.OdbcCommand(c, conn)
                        cmd.ExecuteNonQuery()

                        'koreksi detail_pengajuan untuk biaya pph
                    End If
                End If
                c = ""
                c = c & " update detail_pengajuan set "
                c = c & " idbarang = '" & PTIdBarang.Text & "',"
                c = c & " kdbarang = '" & PTKdBarang.Text & "',"
                c = c & " barang = '" & PTBarang.Text & "',"
                c = c & " keterangan = '" & PTKeterangan.Text & "',"
                c = c & " idsatuan ='" & PTIdSatuan.Text & "',"
                c = c & " jml_barang = '" & PTJml.Text & "',"
                c = c & " jml_orang = '" & PTJmlOrang.Text & "',"
                c = c & " jml_hari = '" & PTJmlHari.Text & "',"
                c = c & " harga_estimasi = '" & PThrg & "',"
                c = c & " sub_total = '" & PTSttl & "',"
                c = c & " keterangan = '" & PTKeterangan.Text & "'"
                c = c & " where iddetail_pengajuan = '" & PTItem.Text & "'"
                cmd = New Odbc.OdbcCommand(c, conn)
                cmd.ExecuteNonQuery()

            Case "Delete"
                If TIdJnsPengajuan.Text = "14" Or TIdJnsPengajuan.Text = "15" Or TIdJnsPengajuan.Text = "16" Then
                    s = ""
                    s = s & " select * from trans_detail_pengajuan_pph "
                    s = s & " where iddetailpengajuan_fee='" & PTItem.Text & "'"
                    da = New Odbc.OdbcDataAdapter(s, conn)
                    tblP = New DataTable
                    tblP.Clear()
                    da.Fill(tblP)

                    If tblP.Rows.Count > 0 Then
                        c = ""
                        c = c & " delete from detail_pengajuan"
                        c = c & " where iddetail_pengajuan = '" & tblP.Rows(0)("iddetailpengajuan") & "'"
                        cmd = New Odbc.OdbcCommand(c, conn)
                        cmd.ExecuteNonQuery()

                        c = ""
                        c = c & " delete from trans_detail_pengajuan_pph"
                        c = c & " where iddetailpengajuan_fee = '" & PTItem.Text & "'"
                        cmd = New Odbc.OdbcCommand(c, conn)
                        cmd.ExecuteNonQuery()
                    End If
                End If

                c = ""
                c = c & " delete from detail_pengajuan"
                c = c & " where iddetail_pengajuan = '" & PTItem.Text & "'"
                cmd = New Odbc.OdbcCommand(c, conn)
                cmd.ExecuteNonQuery()
        End Select
        s = ""
        s = s & " select if (sum(sub_total) is null,0,sum(sub_total))as subtotal from detail_pengajuan"
        s = s & " where idpengajuan = '" & TIdPengajuan.Text & "'"
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds.Clear()
        tbl = New DataTable
        tbl.Clear()
        da.Fill(tbl)
        TNominal.Text = FormatNumber(tbl.Rows(0)("subtotal"), 0, , , TriState.True)

        c = ""
        c = c & " update pengajuan set nominal = '" & tbl.Rows(0)("SubTotal") & "'"
        c = c & " where idpengajuan = '" & TIdPengajuan.Text & "'"
        cmd = New Odbc.OdbcCommand(c, conn)
        cmd.ExecuteNonQuery()

        If TIdJnsPengajuan.Text = "14" Or TIdJnsPengajuan.Text = "15" Or TIdJnsPengajuan.Text = "16" Then
            PTBank.Text = ""
            PTRek.Text = ""
            PTPenerima.Text = ""
            TNikKtp.Text = ""
            TNpwp.Text = ""
            TAlamat.Text = ""
            PTBank.Enabled = True
            PTRek.Enabled = True
            PTPenerima.Enabled = True
            TNikKtp.Enabled = True
            TNpwp.Enabled = True
        End If

        Me.Cursor = Cursors.Default
        Select Case StsItem
            Case "Entry"
                MsgBox("DATA SUDAH DI-SIMPAN !!...", MsgBoxStyle.Information, "INFORMATION")
            Case "Edit"
                MsgBox("DATA SUDAH DI-EDIT !!...", MsgBoxStyle.Information, "INFORMATION")
            Case "Delete"
                MsgBox("DATA SUDAH DI-HAPUS !!...", MsgBoxStyle.Information, "INFORMATION")
        End Select
        PItem.Visible = False
        GGVM_conn_close()
        TampilDetail()
    End Sub

    Private Sub BtnTutupBrg_Click(sender As Object, e As EventArgs) Handles BtnTutupBrg.Click
        PItem.Visible = False
    End Sub

    Private Sub PTJml_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PTJml.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            PTJmlOrang.Focus()
        End If
    End Sub

    Private Sub PTJmlOrang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PTJmlOrang.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            PTJmlHari.Focus()
        End If
    End Sub

    Private Sub PTJmlHari_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PTJmlHari.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            PTSubTotal.Text = PTJml.Text * PTJmlHari.Text * PTJmlOrang.Text * PTHrgEstimasi.Text
            PTHrgEstimasi.Focus()
        End If
    End Sub

    Private Sub PTHrgEstimasi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PTHrgEstimasi.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            PTHrgEstimasi.Text = FormatNumber(PTHrgEstimasi.Text, 0, , , TriState.True)
            PTSubTotal.Text = PTJml.Text * PTJmlHari.Text * PTJmlOrang.Text * PTHrgEstimasi.Text
            PTSubTotal.Focus()
        End If
    End Sub

    Private Sub PTHrgEstimasi_TextChanged(sender As Object, e As EventArgs) Handles PTHrgEstimasi.TextChanged

    End Sub

    Private Sub PTSubTotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PTSubTotal.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            PTSubTotal.Text = PTJml.Text * PTJmlHari.Text * PTJmlOrang.Text * PTHrgEstimasi.Text
            PTSubTotal.Text = FormatNumber(PTSubTotal.Text, 0, , , TriState.True)
            BtnSimpanBrg.Focus()
        End If
    End Sub


    Private Sub PTKeterangan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PTKeterangan.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            PTJml.Focus()
        End If
    End Sub

    Private Sub PTCariBrg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PTCariBrg.KeyPress
        Dim s As String

        If e.KeyChar = Convert.ToChar(32) Or e.KeyChar = Convert.ToChar(127) Then

        Else
            Loadbrg = "Barang"
            GGVM_conn()

            s = ""
            s = s & " select xbrg.* from ( "
            s = s & " select a.barang as BARANG ,a.kdbarang AS KDBARANG,a.hpp as HARGA_ESTIMASI ,c.satuan AS SATUAN,a.idbarang AS IDBARANG,c.idsatuan AS IDSATUAN"
            s = s & " from barang a, satuan c, subkelompok d"
            s = s & " where a.barang like '%" & Trim(PTCariBrg.Text) & "%'"
            s = s & " and a.status='1'"
            s = s & " and a.idsatuan = c.idsatuan"
            s = s & " and a.idsubkel = d.idsubkel "
            s = s & " and d.idkelompok not in ('3','7','8','9','10','11','13','14') "
            s = s & " order by a.barang ) as xbrg"

            da = New Odbc.OdbcDataAdapter(s, conn)
            ds = New DataSet
            ds.Clear()
            da.Fill(ds, "xbrg")

            DtBrg.DataSource = ds.Tables("xbrg")
            DtBrg.AutoResizeColumns()
            GGVM_conn_close()

            If DtBrg.RowCount = 1 Then
                MsgBox("Data tidak ada !!..", MsgBoxStyle.Information, "Information")
                BtnBarang.Focus()
            End If
            DtBrg.Refresh()
        End If
        PTCariBrg.Focus()

    End Sub

    Private Sub PTCariBrg_TextChanged(sender As Object, e As EventArgs) Handles PTCariBrg.TextChanged

    End Sub

    Private Sub BtnDivisi_Click(sender As Object, e As EventArgs) Handles BtnDivisi.Click

    End Sub

    Private Sub BtnKlien_Click(sender As Object, e As EventArgs) Handles BtnKlien.Click
        If RBKlien.Checked = False And RBDistributor.Checked = False Then
            MsgBox("Pilih dulu KLIEN atau DISTRIBUTOR !!...", MsgBoxStyle.Information, "Information")
            Exit Sub
        End If
        If RBKlien.Checked = True Then
            LoadDt = "klien"
            PanelSurvei.Visible = True
            Loadklien()
            GridPanel.Focus()
        End If
        If RBDistributor.Checked = True Then
            LoadDt = "distributor"
            PanelSurvei.Visible = True
            LoadDistributor()
            GridPanel.Focus()
        End If
    End Sub

    Private Sub PItem_Paint(sender As Object, e As PaintEventArgs) Handles PItem.Paint

    End Sub

    Private Sub PTSubTotal_TextChanged(sender As Object, e As EventArgs) Handles PTSubTotal.TextChanged

    End Sub

    Private Sub BtnHitung_Click(sender As Object, e As EventArgs) Handles BtnHitung.Click
        Dim Pph, Fee, Xstotal As Double
        Dim c As String
        Dim cmd As New OdbcCommand

        Pph = 0
        PTSubTotal.Text = PTJml.Text * PTJmlHari.Text * PTJmlOrang.Text * PTHrgEstimasi.Text
        If TIdJnsPengajuan.Text = "14" Or TIdJnsPengajuan.Text = "15" Then
            If TIdJnsPengajuan.Text = "14" Then
                Fee = PTSubTotal.Text
                Pph = (Fee / 102.5) * -1
                Xstotal = Pph
            End If
            If TIdJnsPengajuan.Text = "15" Then
                Fee = PTSubTotal.Text
                Pph = (Fee * (2.5 / 100))
                Xstotal = 0
            End If
            c = ""
            c = c & " update detail_pengajuan set "
            c = c & " jml_barang = '1',"
            c = c & " jml_orang = '1',"
            c = c & " jml_hari = '1',"
            c = c & " harga_estimasi = '" & Pph & "',"
            c = c & " sub_total = '" & Xstotal & "',"
            c = c & " where idbarang = 1289"
            c = c & " and idpengajuan='" & TIdPengajuan.Text & "'"
            cmd = New Odbc.OdbcCommand(c, conn)
            cmd.ExecuteNonQuery()
        End If

        PTHrgEstimasi.Text = FormatNumber(PTHrgEstimasi.Text, 0, , , TriState.True)
        PTSubTotal.Text = FormatNumber(PTSubTotal.Text, 0, , , TriState.True)

    End Sub

    Private Sub SisaPO_CheckedChanged(sender As Object, e As EventArgs) Handles SisaPO.CheckedChanged
        If SisaPO.Checked = True Then
            TKeterangan.Text = "SISA P.O. "
        Else
            TKeterangan.Text = ""
        End If
    End Sub

    Private Sub TJnsPengajuan_TextChanged(sender As Object, e As EventArgs) Handles TJnsPengajuan.TextChanged

    End Sub

    Private Sub BtnMajuPph_Click(sender As Object, e As EventArgs) Handles BtnMajuPph.Click
        Dim hr As TimeSpan
        Dim berangkat As Date
        Dim pulang As Date
        Dim s As String
        Dim c As String
        ' Dim i As Integer
        Dim tbl As New DataTable
        Dim cmd As New OdbcCommand
        Dim paket As Boolean
        Dim jmlorang As Integer

        If BtnProsesMaju.Text = "PROSES ENTRY" Then
            If TIdDivisi.Text = "" Then
                MsgBox("Pilih dulu Divisi-nya !!...", MsgBoxStyle.Information, "Information")
                BtnDivisi.Focus()
                Exit Sub
            ElseIf TIdSubDivisi.Text = "" Then
                MsgBox("Pilih dulu Sub Divisi-nya !!...", MsgBoxStyle.Information, "Information")
                BtnSubDivisi.Focus()
                Exit Sub
            ElseIf TIdJnsPengajuan.Text = "" Then
                MsgBox("Pilih dulu Jenis Pengajuan-nya !!...", MsgBoxStyle.Information, "Information")
                BtnJnsMaju.Focus()
                Exit Sub
            ElseIf RBAdaPE.Checked = False And RBBelumPE.Checked = False And RBTidakPE.Checked = False Then
                MsgBox("Pilih dulu Status PE nya !!...", MsgBoxStyle.Information, "Information")
                Exit Sub
            ElseIf RBditagihkan.Checked = False And RBNotagih.Checked = False And RBFixcost.Checked = False Then
                MsgBox("Pilih dulu Status Penagihan-nya !!...", MsgBoxStyle.Information, "Information")
                Exit Sub
            ElseIf RBtunai.Checked = False And RBtransfer.Checked = False Then
                MsgBox("Pilih dulu Sumber Dana-nya !!...", MsgBoxStyle.Information, "Information")
                Exit Sub
            End If


            Me.Cursor = Cursors.WaitCursor
            GGVM_conn()
            'berangkat = DTBerangkat.Value
            'pulang = DTPulang.Value
            hr = pulang.Subtract(berangkat)
            'THari.Text = hr.Days + 1

            'INSERT PENGAJUAN
            s = ""
            s = s & " select nopengajuan,blnpengajuan from counter"
            da = New Odbc.OdbcDataAdapter(s, conn)
            ds.Clear()
            tbl = New DataTable
            tbl.Clear()
            da.Fill(tbl)

            Dim nourut As String
            Dim divisi As String
            Dim bln As String
            Dim thn As String

            Dim count As Integer
            Dim blnskrng As Integer

            blnskrng = Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(DTTanggal.Text, 5), 2)
            If blnskrng = tbl.Rows(0)("blnpengajuan") Then
                count = tbl.Rows(0)("nopengajuan")
            Else
                count = 0
            End If
            count = count + 1
            divisi = Microsoft.VisualBasic.Right("00" & Trim(TIdDivisi.Text), 2)
            nourut = Microsoft.VisualBasic.Right("0000" & count, 4)
            bln = bulan(DTTanggal.Text)
            thn = Microsoft.VisualBasic.Right(DTTanggal.Text, 4)
            nourut = nourut + "/GGVM-" + divisi + "/" + bln + "/" + thn

            c = ""
            If count = 1 Then
                c = c & " update counter set nopengajuan = '" & count & "',"
                c = c & " blnpengajuan = '" & Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(DTTanggal.Text, 5), 2) & "'"
            Else
                c = c & " update counter set nopengajuan = '" & count & "'"
            End If
            cmd = New Odbc.OdbcCommand(c, conn)
            cmd.ExecuteNonQuery()


            c = ""
            c = c & " insert into pengajuan (nopengajuan,idsubdivisi,idjnspengajuan,tanggal,idstatus_pe, "
            If TIdPO.Text <> "" Then
                c = c & " idpo,"
            End If
            If TIdKlien.Text <> "" Then
                c = c & " idklien,"
            End If
            If TIdArea.Text <> "" Then
                c = c & " idarea, "
            End If
            If TIdPropinsi.Text <> "" Then
                c = c & " idpropinsi,"
            End If
            c = c & " statustagih, sumberdana, "
            If TBank.Text <> "" Then
                c = c & "nama_bank,"
            End If
            If TNoRek.Text <> "" Then
                c = c & "no_rekening,"
            End If
            If TKeterangan.Text <> "" Then
                c = c & "keterangan,"
            End If
            c = c & " waktu_berangkat,waktu_pulang,jml_hari,jml_kota,jml_toko,jml_orang,nominal,"
            c = c & " time_input,user_input)"
            c = c & " values ('" & nourut & "','" & TIdSubDivisi.Text & "','" & TIdJnsPengajuan.Text & "','" & Format(DTTanggal.Value, "yyyy-MM-dd") & "','1',"
            If TIdPO.Text <> "" Then
                c = c & "'" & TIdPO.Text & "',"
            End If
            If TIdKlien.Text <> "" Then
                c = c & " '" & TIdKlien.Text & "',"
            End If
            If TIdArea.Text <> "" Then
                c = c & "'" & TIdArea.Text & "',"
            End If
            If TIdPropinsi.Text <> "" Then
                c = c & "'" & TIdPropinsi.Text & "',"
            End If
            c = c & "'D',"
            If RBtunai.Checked = True Then
                c = c & "'T',"
            Else
                c = c & "'B',"
            End If
            If TBank.Text <> "" Then
                c = c & "'" & TBank.Text & "',"
            End If
            If TNoRek.Text <> "" Then
                c = c & "'" & TNoRek.Text & "',"
            End If
            If TKeterangan.Text <> "" Then
                c = c & "'" & Microsoft.VisualBasic.RTrim(TKeterangan.Text) & "',"
            End If
            c = c & "now(),now(),'1','1','0','1','0',"
            c = c & "now(),'" & userid & "')"
            cmd = New Odbc.OdbcCommand(c, conn)
            cmd.ExecuteNonQuery()

            s = ""
            s = s & " select max(idpengajuan)as id from pengajuan "
            da = New Odbc.OdbcDataAdapter(s, conn)
            tbl = New DataTable
            tbl.Clear()
            da.Fill(tbl)
            TIdPengajuan.Text = tbl.Rows(0)("id")
            TNoPengajuan.Text = nourut


            If TIdJnsPengajuan.Text = "14" Or TIdJnsPengajuan.Text = "15" Or TIdJnsPengajuan.Text = "16" Then
                paket = True
                s = ""
                s = s & " select idbarang,kdbarang,barang,idsatuan,hpp from barang"
                If RbSpeaker.Checked = True Then
                    s = s & " where idbarang  in('325' ) "
                End If
                If RbModerator.Checked = True Then
                    s = s & " where idbarang  in('1881' ) "
                End If
                If RBFasilitator.Checked = True Then
                    s = s & " where idbarang  in('1882' ) "
                End If
                If rBKonsultan.Checked = True Then
                    s = s & " where idbarang  in('1888' ) "
                End If
                s = s & " and status='1'"
                s = s & " order by idbarang"
            End If

            GGVM_conn_close()
            If paket = True Then
                da = New Odbc.OdbcDataAdapter(s, conn)
                tbl = New DataTable
                tbl.Clear()
                da.Fill(tbl)
                jmlorang = Torang.Text
                GGVM_conn()
                For j = 1 To jmlorang
                    For i = 0 To tbl.Rows.Count - 1
                        c = ""
                        c = c & " insert into detail_pengajuan (idpengajuan, idbarang,kdbarang,barang, "
                        c = c & " idsatuan,type_pengajuan,jml_barang,jml_orang,jml_hari,harga_estimasi,sub_total)"
                        c = c & " values ('" & TIdPengajuan.Text & "','" & tbl.Rows(i)("idbarang") & "','" & tbl.Rows(i)("kdbarang") & "','" & tbl.Rows(i)("barang") & "',"
                        c = c & "'" & tbl.Rows(i)("idsatuan") & "','B','1','1','1','" & tbl.Rows(i)("hpp") & "','0')"
                        cmd = New Odbc.OdbcCommand(c, conn)
                        cmd.ExecuteNonQuery()
                    Next
                Next

                GGVM_conn_close()
                TampilDetail()
            End If
            BtnProsesMaju.Enabled = False
            BtnTambahMaju.Enabled = True
            BtnEditMaju.Enabled = True
            Torang.Text = "1"
            PFee.Visible = False
            GGVM_conn_close()
            Me.Cursor = Cursors.Default
        Else
            'EDIT DATA PENGAJUAN

            Me.Cursor = Cursors.WaitCursor
            GGVM_conn()
            c = ""
            c = c & " update pengajuan set"
            c = c & " idstatus_pe = '" & TIdStatusPE.Text & "',"
            If TIdPO.Text <> "" Then
                c = c & " idpo = '" & TIdPO.Text & "',"
            End If
            If TIdKlien.Text <> "" Then
                c = c & " idklien = '" & TIdKlien.Text & "',"
            End If
            If TIdArea.Text <> "" Then
                c = c & " idarea = '" & TIdArea.Text & "',"
            End If
            If TIdPropinsi.Text <> "" Then
                c = c & " idpropinsi = '" & TIdPropinsi.Text & "',"
            End If
            c = c & " statustagih = '" & TIdStatusTagih.Text & "',"
            If RBtunai.Checked = True Then
                c = c & "sumberdana = 'T',"
            End If
            If RBtransfer.Checked = True Then
                c = c & "sumberdana = 'B',"
            End If
            If TBank.Text <> "" Then
                c = c & " nama_bank = '" & TBank.Text & "',"
            End If
            If TNoRek.Text <> "" Then
                c = c & " no_rekening = '" & TNoRek.Text & "',"
            End If
            c = c & " waktu_berangkat = now(),"
            c = c & " waktu_pulang = now(),"
            c = c & " jml_hari = '1',"
            c = c & " jml_kota = '1',"
            c = c & " jml_toko = '0',"
            c = c & " time_koreksi = now(),"
            c = c & " user_koreksi = '" & userid & "',"
            c = c & " keterangan = '" & TKeterangan.Text & "'"
            c = c & " where idpengajuan = '" & TIdPengajuan.Text & "'"
            cmd = New Odbc.OdbcCommand(c, conn)
            cmd.ExecuteNonQuery()
            GGVM_conn_close()

            Me.Cursor = Cursors.Default
            MsgBox("Data sudah di-EDIT !!!...", MsgBoxStyle.Information, "Information")
        End If
    End Sub
End Class