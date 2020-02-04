Option Strict Off
Imports System.Data.Odbc
Public Class FrmEditLPJ
    Dim tgl As Date
    Dim LoadDt As String
    Dim StsItem As String
    Dim Loadbrg As String

    Private Sub FrmEditLPJ_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TIdPengajuan.Text = tampilLPJ
        BtnTambahMaju.Enabled = True
        BtnEditMaju.Enabled = True
        ListHeader()
        TampilLPJAll()
        TampilDetail()
        BtnTambahMaju.Focus()
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
        ListItem.Columns.Add("HRG.AKTUAL", 100, HorizontalAlignment.Right)
        ListItem.Columns.Add("SUB.TOTAL", 100, HorizontalAlignment.Right)
        ListItem.Columns.Add("ID BARANG", 50, HorizontalAlignment.Left)
        ListItem.Columns.Add("ID DETAIL", 50, HorizontalAlignment.Left)
        ListItem.Columns.Add("ID SATUAN", 50, HorizontalAlignment.Left)
        ListItem.Columns.Add("ID DETAIL LPJ ", 50, HorizontalAlignment.Left)
    End Sub
    Private Sub TampilLPJAll()
        Dim s As String
        'Dim i As Integer
        Dim tbl As New DataTable

        'KURANG PE KURANG PO
        GGVM_conn()
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
        s = s & " from lpj a, subdivisi b,divisi c, jenis_pengajuan d, status_pe e"
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
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds.Clear()
        tbl = New DataTable
        tbl.Clear()
        da.Fill(tbl)

        TDivisi.Text = CType(tbl.Rows(0)("divisi"), String)
        TIdDivisi.Text = tbl.Rows(0)("id_divisi")
        TSubDivisi.Text = tbl.Rows(0)("subdivisi")
        TIdSubDivisi.Text = tbl.Rows(0)("idsubdivisi")
        DTTanggal.Text = tbl.Rows(0)("tanggal")
        TNoPengajuan.Text = tbl.Rows(0)("nopengajuan")
        TJnsPengajuan.Text = tbl.Rows(0)("pengajuan")
        TIdJnsPengajuan.Text = tbl.Rows(0)("idpengajuan")
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
        TIdSubArea.Text = tbl.Rows(0)("idpropinsi")
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
        Dim [date] As Date = tbl.Rows(0)("waktu_berangkat")
        DTBerangkat.Value = [date]
        DTPulang.Value = tbl.Rows(0)("waktu_pulang")
        THari.Text = tbl.Rows(0)("jml_hari")
        TJmlKota.Text = tbl.Rows(0)("jml_kota")
        TJmlToko.Text = tbl.Rows(0)("jml_toko")
        TKeterangan.Text = tbl.Rows(0)("keterangan")
        TNominal.Text = FormatNumber(tbl.Rows(0)("nominal"), 0, , , TriState.True)

        'menampilkan totalpengajuan dan selisih
        s = ""
        s = s & " select nominal_pengajuan,selisih from trans_pengajuan_lpj"
        s = s & " where idpengajuan = '" & TIdPengajuan.Text & "'"
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds.Clear()
        tbl = New DataTable
        tbl.Clear()
        da.Fill(tbl)

        TNominalMaju.Text = FormatNumber(tbl.Rows(0)("nominal_pengajuan"), 0, , , TriState.True)
        TSelisih.Text = FormatNumber(tbl.Rows(0)("selisih"), 0, , , TriState.True)
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
        s = s & "  a.idbarang,"
        s = s & " if (a.iddetail_pengajuan is null,'',a.iddetail_pengajuan) as iddetail_pengajuan,"
        s = s & " a.idsatuan, b.satuan,a.iddetaillpj"
        s = s & " from detail_lpj a, satuan b"
        s = s & " where a.idsatuan = b.idsatuan"
        s = s & "     and a.idpengajuan = '" & TIdPengajuan.Text & "'"
        s = s & " order by a.iddetaillpj"
        da = New Odbc.OdbcDataAdapter(s, conn)
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
                    .Add(tbl.Rows(i)("iddetaillpj"))
                End With
            End With
        Next
        GGVM_conn_close()
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
    End Sub

    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        Dim keluar As MsgBoxResult
        keluar = MsgBox("Apakah anda yakin untuk keluar program ?...", MsgBoxStyle.YesNo, "Peringatan")
        If keluar = MsgBoxResult.Yes Then
            Me.Close()
            Exit Sub
        End If
    End Sub

    Private Sub BtnEditMaju_Click(sender As Object, e As EventArgs) Handles BtnEditMaju.Click
        Dim ada As Boolean
        Dim brs, jmldt As Integer

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
        Else
            StsItem = "Delete"
            BtnSimpanBrg.Focus()
        End If
        PTItem.Text = ListItem.Items(brs).SubItems(12).Text
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
        PItem.Visible = True
    End Sub

    Private Sub BtnKelompok_Click(sender As Object, e As EventArgs) Handles BtnKelompok.Click
        LoadKelompok()
        Loadbrg = "Kelompok"
    End Sub

    Private Sub LoadKelompok()
        Dim s As String

        GGVM_conn()
        s = " select kelompok,idkelompok from kelompok where idkelompok in ('1','2','3','4','5') and status='1'  order by kelompok "
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

    Private Sub BtnSubKel_Click(sender As Object, e As EventArgs) Handles BtnSubKel.Click
        LoadSubKelompok()
        Loadbrg = "SubKelompok"
    End Sub

    Private Sub BtnBarang_Click(sender As Object, e As EventArgs) Handles BtnBarang.Click
        LoadBarang()
        Loadbrg = "Barang"
    End Sub

    Private Sub BtnSatuan_Click(sender As Object, e As EventArgs) Handles BtnSatuan.Click
        Loadbrg = "Satuan"
        LoadSatuan()
    End Sub

    Private Sub LoadSatuan()
        Dim s As String

        GGVM_conn()
        DtBrg.DataSource = Nothing
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

    Private Sub PTKeterangan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PTKeterangan.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            PTJml.Focus()
        End If
    End Sub

    Private Sub PTKeterangan_TextChanged(sender As Object, e As EventArgs) Handles PTKeterangan.TextChanged

    End Sub

    Private Sub PTJml_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PTJml.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            PTJmlOrang.Focus()
        End If
    End Sub

    Private Sub PTJml_TextChanged(sender As Object, e As EventArgs) Handles PTJml.TextChanged

    End Sub

    Private Sub PTJmlHari_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PTJmlHari.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            PTHrgEstimasi.Focus()
        End If
    End Sub

    Private Sub PTJmlHari_TextChanged(sender As Object, e As EventArgs) Handles PTJmlHari.TextChanged

    End Sub

    Private Sub PTHrgEstimasi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PTHrgEstimasi.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            PTSubTotal.Text = PTJml.Text * PTJmlHari.Text * PTJmlOrang.Text * PTHrgEstimasi.Text
            PTHrgEstimasi.Text = FormatNumber(PTHrgEstimasi.Text, 0, , , TriState.True)
            PTSubTotal.Focus()
        End If

    End Sub

    Private Sub PTHrgEstimasi_TextChanged(sender As Object, e As EventArgs) Handles PTHrgEstimasi.TextChanged

    End Sub

    Private Sub PTSubTotal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PTSubTotal.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            PTSubTotal.Text = FormatNumber(PTSubTotal.Text, 0, , , TriState.True)
            BtnSimpanBrg.Focus()
        End If
    End Sub

    Private Sub PTSubTotal_TextChanged(sender As Object, e As EventArgs) Handles PTSubTotal.TextChanged

    End Sub

    Private Sub BtnSimpanBrg_Click(sender As Object, e As EventArgs) Handles BtnSimpanBrg.Click
        Dim c, s As String
        Dim cmd As New OdbcCommand
        Dim tbl As DataTable
        Dim PThrg As Double
        Dim PTSttl As Double
        Dim np As Double
        Dim nl As Double
        Dim selisih As Double


        'MAINTENAN ITEM
        Me.Cursor = Cursors.WaitCursor
        PThrg = PTHrgEstimasi.Text
        PTSttl = PTSubTotal.Text
        GGVM_conn()
        Select Case StsItem
            Case "Entry"
                c = ""
                c = c & " insert into detail_lpj (idpengajuan, idbarang,kdbarang,barang, "
                c = c & " idsatuan,type_pengajuan,jml_barang,jml_orang,jml_hari,harga_estimasi,sub_total,keterangan)"
                c = c & " values ('" & TIdPengajuan.Text & "','" & PTIdBarang.Text & "','" & PTKdBarang.Text & "','" & PTBarang.Text & "',"
                c = c & "'" & PTIdSatuan.Text & "','B','1','" & PTJmlOrang.Text & "','" & PTJmlHari.Text & "','" & PThrg & "','" & PTSttl & "','" & PTKeterangan.Text & "')"
                cmd = New Odbc.OdbcCommand(c, conn)
                cmd.ExecuteNonQuery()

            Case "Edit"

                c = ""
                c = c & " update detail_lpj set "
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
                c = c & " where iddetaillpj = '" & PTItem.Text & "'"
                cmd = New Odbc.OdbcCommand(c, conn)
                cmd.ExecuteNonQuery()

            Case "Delete"

                c = ""
                c = c & " delete from detail_lpj"
                c = c & " where iddetail_pengajuan = '" & PTItem.Text & "'"
                cmd = New Odbc.OdbcCommand(c, conn)
                cmd.ExecuteNonQuery()
        End Select
        s = ""
        s = s & " select sum(sub_total)as subtotal from detail_lpj"
        s = s & " where idpengajuan = '" & TIdPengajuan.Text & "'"
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds.Clear()
        tbl = New DataTable
        tbl.Clear()
        da.Fill(tbl)
        TNominal.Text = FormatNumber(tbl.Rows(0)("subtotal"), 0, , , TriState.True)
        nl = tbl.Rows(0)("subtotal")

        c = ""
        c = c & " update lpj set nominal = '" & tbl.Rows(0)("SubTotal") & "'"
        c = c & " where idpengajuan = '" & TIdPengajuan.Text & "'"
        cmd = New Odbc.OdbcCommand(c, conn)
        cmd.ExecuteNonQuery()

        s = ""
        s = s & " select nominal_pengajuan from trans_pengajuan_lpj"
        s = s & " where idpengajuan = '" & TIdPengajuan.Text & "'"
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds.Clear()
        tbl = New DataTable
        tbl.Clear()
        da.Fill(tbl)
        np = FormatNumber(tbl.Rows(0)("nominal_pengajuan"), 0, , , TriState.True)
        selisih = np - nl

        c = ""
        c = c & " update trans_pengajuan_lpj set nominal_lpj = '" & nl & "',"
        c = c & " selisih = '" & selisih & "'"
        c = c & " where idpengajuan = '" & TIdPengajuan.Text & "'"
        cmd = New Odbc.OdbcCommand(c, conn)
        cmd.ExecuteNonQuery()


        Me.Cursor = Cursors.Default
        Select Case StsItem
            Case "Entry"
                MsgBox("DATA SUDAH DI-SIMPAN !!...", MsgBoxStyle.Information, "INFORMATION")
            Case "Edit"
                MsgBox("DATA SUDAH DI-EDIT !!...", MsgBoxStyle.Information, "INFORMATION")
            Case "Delete"
                MsgBox("DATA SUDAH DI-HAPUS !!...", MsgBoxStyle.Information, "INFORMATION")
        End Select

        s = ""
        s = s & " select nominal_pengajuan,nominal_lpj,selisih from trans_pengajuan_lpj"
        s = s & " where idpengajuan = '" & TIdPengajuan.Text & "'"
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds.Clear()
        tbl = New DataTable
        tbl.Clear()
        da.Fill(tbl)
        TNominal.Text = FormatNumber(tbl.Rows(0)("nominal_lpj"), 0, , , TriState.True)
        TNominalMaju.Text = FormatNumber(tbl.Rows(0)("nominal_pengajuan"), 0, , , TriState.True)
        TSelisih.Text = FormatNumber(tbl.Rows(0)("selisih"), 0, , , TriState.True)
        PItem.Visible = False
        GGVM_conn_close()

        TampilDetail()
    End Sub

    Private Sub BtnTutupBrg_Click(sender As Object, e As EventArgs) Handles BtnTutupBrg.Click
        PItem.Visible = False
    End Sub

    Private Sub DtBrg_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DtBrg.CellContentClick

    End Sub

    Private Sub DtBrg_DoubleClick(sender As Object, e As EventArgs) Handles DtBrg.DoubleClick
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

        If e.KeyChar = Convert.ToChar(13) Then
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
        End If
    End Sub

    Private Sub PTJmlOrang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PTJmlOrang.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            PTJmlHari.Focus()
        End If
    End Sub

    Private Sub PTJmlOrang_TextChanged(sender As Object, e As EventArgs) Handles PTJmlOrang.TextChanged

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
            s = s & " from barang a, satuan c, subkelompok d "
            s = s & " where a.barang like '%" & Trim(PTCariBrg.Text) & "%'"
            s = s & " and a.status='1'"
            s = s & " and a.idsatuan = c.idsatuan"
            s = s & " and a.idsubkel = d.idsubkel"
            s = s & " and d.idkelompok not in ('7','8','9','10','11','13','14')"
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

    Private Sub GridPanel_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles GridPanel.CellContentClick

    End Sub

    Private Sub BtnProsesMaju_Click(sender As Object, e As EventArgs) Handles BtnProsesMaju.Click

    End Sub

    Private Sub Panel10_Paint(sender As Object, e As PaintEventArgs) Handles Panel10.Paint

    End Sub

    Private Sub BtnHitung_Click(sender As Object, e As EventArgs) Handles BtnHitung.Click
        PTSubTotal.Text = PTJml.Text * PTJmlHari.Text * PTJmlOrang.Text * PTHrgEstimasi.Text
        PTHrgEstimasi.Text = FormatNumber(PTHrgEstimasi.Text, 0, , , TriState.True)
        PTSubTotal.Text = FormatNumber(PTSubTotal.Text, 0, , , TriState.True)
    End Sub

    Private Sub TNominal_TextChanged(sender As Object, e As EventArgs) Handles TNominal.TextChanged

    End Sub

    Private Sub Label36_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub
End Class