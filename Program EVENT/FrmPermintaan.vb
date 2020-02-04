Option Strict Off
Imports System.Data.Odbc
Public Class FrmPermintaan
    Dim LoadDt, Proses, ProsesSJ, UserMinta As String
    Dim brssj, DivMinta, LevelMinta As Integer
#Region "LISTVIEW"
    Private Sub ListHeaderBrg()
        ListBarang.FullRowSelect = True
        ListBarang.MultiSelect = True
        ListBarang.View = View.Details
        ListBarang.CheckBoxes = True
        ListBarang.Columns.Clear()
        ListBarang.Items.Clear()
        ListBarang.Columns.Add("GUDANG", 100, HorizontalAlignment.Left)
        ListBarang.Columns.Add("TANGGAL", 80, HorizontalAlignment.Left)
        ListBarang.Columns.Add("ID.BARANG", 70, HorizontalAlignment.Left)
        ListBarang.Columns.Add("BARANG", 200, HorizontalAlignment.Left)
        ListBarang.Columns.Add("JUMLAH", 100, HorizontalAlignment.Right)
        ListBarang.Columns.Add("SATUAN", 90, HorizontalAlignment.Left)
        'ListBarang.Columns.Add("IDBRG", 10, HorizontalAlignment.Left)
        ListBarang.Columns.Add("IDMINTA", 100, HorizontalAlignment.Left)
        If RBPRODUKSI.Checked = True Then
            ListBarang.Columns.Add("PO.PRODUKSI", 120, HorizontalAlignment.Left)
            ListBarang.Columns.Add("IDPOPRD", 10, HorizontalAlignment.Left)
        End If
    End Sub
    Private Sub ListHeaderSJ()
        ListSJ.FullRowSelect = True
        ListSJ.MultiSelect = True
        ListSJ.View = View.Details
        ListSJ.CheckBoxes = True
        ListSJ.Columns.Clear()
        ListSJ.Items.Clear()
        ListSJ.Columns.Add("NO.SJ", 100, HorizontalAlignment.Left)
        ListSJ.Columns.Add("TANGGAL", 80, HorizontalAlignment.Left)
        ListSJ.Columns.Add("KIRIM", 300, HorizontalAlignment.Left)
        ListSJ.Columns.Add("PENGIRIM", 150, HorizontalAlignment.Left)
        ListSJ.Columns.Add("IDJS", 10, HorizontalAlignment.Right)
    End Sub
    Private Sub ListDetailSJ()
        ListDetail.FullRowSelect = True
        ListDetail.MultiSelect = True
        ListDetail.View = View.Details
        ListDetail.CheckBoxes = True
        ListDetail.Columns.Clear()
        ListDetail.Items.Clear()
        ListDetail.Columns.Add("ID.BARANG", 100, HorizontalAlignment.Left)
        ListDetail.Columns.Add("BARANG", 300, HorizontalAlignment.Left)
        ListDetail.Columns.Add("JUMLAH", 120, HorizontalAlignment.Right)
        ListDetail.Columns.Add("SATUAN", 120, HorizontalAlignment.Left)
        ListDetail.Columns.Add("IDMINTA", 10, HorizontalAlignment.Left)
    End Sub
#End Region
#Region "Deklarasi Perintah"
    Private Sub TampilMinta()
        Dim s As String
        'Dim i As Integer
        Dim tbl As New DataTable

        Me.Cursor = Cursors.WaitCursor
        GGVM_conn()
        ListBarang.Items.Clear()
        s = ""
        s = s & " select a.*,c.satuan,d.nama as divisi,b.barang"
        If RBATK.Checked = True Then
            s = s & " from permintaan_gdg_atk a, master_barang_atk b, satuan c, divisi d"
        End If
        If RBEVEN.Checked = True Then
            s = s & " from permintaan_gdg_even a, master_barang_even b, satuan c, divisi d"
        End If
        If RBPRODUKSI.Checked = True Then
            s = s & " from permintaan_gdg_produksi a, master_barang_produksi b, satuan c, divisi d"
        End If
        If RBSPG.Checked = True Then
            s = s & " from permintaan_gdg_spg a, master_barang_spg b, satuan c, divisi d"
        End If
        If RBIT.Checked = True Then
            s = s & " from permintaan_gdg_it a, master_barang_it b, satuan c, divisi d"
        End If
        s = s & " where a.idsatuan = c.idsatuan"
        s = s & " and a.idbarang = b.idbarang "
        s = s & " and a.idgudang = d.id_divisi"
        s = s & " and a.time_ambil is null"
        If LevelMinta <> 0 Then
            s = s & " and a.user_input = '" & UserMinta & "'"
        End If
        da = New OdbcDataAdapter(s, conn)
        ds.Clear()
        tbl = New DataTable
        tbl.Clear()
        da.Fill(tbl)
        For i = 0 To tbl.Rows.Count - 1
            With ListBarang
                .Items.Add(tbl.Rows(i)("divisi"))
                With .Items(.Items.Count - 1).SubItems
                    .Add(tbl.Rows(i)("tanggal"))
                    .Add(tbl.Rows(i)("idbarang"))
                    .Add(tbl.Rows(i)("barang"))
                    .Add(tbl.Rows(i)("jml_barang"))
                    .Add(tbl.Rows(i)("satuan"))
                    .Add(tbl.Rows(i)("idminta"))
                    If RBPRODUKSI.Checked = True Then
                        .Add(tbl.Rows(i)("nopo_prd"))
                        .Add(tbl.Rows(i)("idpo_prd"))
                    End If
                End With
            End With
        Next
        GGVM_conn_close()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub TampilSJ()
        Dim s As String
        'Dim i As Integer
        Dim tbl As New DataTable

        Me.Cursor = Cursors.WaitCursor
        GGVM_conn()
        ListSJ.Items.Clear()
        s = ""
        s = s & " select y.* from ( Select a.idsuratjalan"
        If RBATK.Checked = True Then
            s = s & " from permintaan_gdg_atk a"
        End If
        If RBEVEN.Checked = True Then
            s = s & " from permintaan_gdg_even a"
        End If
        If RBPRODUKSI.Checked = True Then
            s = s & " from permintaan_gdg_produksi a"
        End If
        If RBSPG.Checked = True Then
            s = s & " from permintaan_gdg_spg a"
        End If
        If RBIT.Checked = True Then
            s = s & " from permintaan_gdg_it a"
        End If
        s = s & " where a.time_ambil Is null"
        If LevelUser <> "0" Then
            s = s & " and  a.user_input='" & userid & "'"
        End If
        s = s & " group by a.idsuratjalan "
        s = s & " ) x, "
        If RBATK.Checked = True Then
            s = s & " suratjalan_atk y"
        End If
        If RBEVEN.Checked = True Then
            s = s & " suratjalan_even y"
        End If
        If RBPRODUKSI.Checked = True Then
            s = s & " suratjalan_produksi y"
        End If
        If RBSPG.Checked = True Then
            s = s & " suratjalan_spg y"
        End If
        If RBIT.Checked = True Then
            s = s & " suratjalan_it y"
        End If
        s = s & " where x.idsuratjalan = y.idsuratjalan"

        da = New Odbc.OdbcDataAdapter(s, conn)
        ds.Clear()
        tbl = New DataTable
        tbl.Clear()
        da.Fill(tbl)
        For i = 0 To tbl.Rows.Count - 1
            With ListSJ
                .Items.Add(tbl.Rows(i)("nosj"))
                With .Items(.Items.Count - 1).SubItems
                    .Add(tbl.Rows(i)("tanggal"))
                    .Add(replaceNewLine(tbl.Rows(i)("kirim"), False))
                    .Add(tbl.Rows(i)("pengirim"))
                    .Add(tbl.Rows(i)("idsuratjalan"))
                End With
            End With
        Next
        GGVM_conn_close()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub TampilDetailSJ()
        Dim s As String
        'Dim i As Integer
        Dim tbl As New DataTable

        Me.Cursor = Cursors.WaitCursor
        GGVM_conn()
        ListDetail.Items.Clear()
        s = ""
        s = s & " select a.*,c.satuan,d.nama as divisi,b.barang"
        If RBATK.Checked = True Then
            s = s & " from permintaan_gdg_atk a, master_barang_atk b, satuan c, divisi d"
        End If
        If RBEVEN.Checked = True Then
            s = s & " from permintaan_gdg_even a, master_barang_even b, satuan c, divisi d"
        End If
        If RBPRODUKSI.Checked = True Then
            s = s & " from permintaan_gdg_produksi a, master_barang_produksi b, satuan c, divisi d"
        End If
        If RBSPG.Checked = True Then
            s = s & " from permintaan_gdg_spg a, master_barang_spg b, satuan c, divisi d"
        End If
        If RBIT.Checked = True Then
            s = s & " from permintaan_gdg_it a, master_barang_it b, satuan c, divisi d"
        End If
        s = s & " where a.idsatuan = c.idsatuan"
        s = s & " and a.idbarang = b.idbarang "
        s = s & " and a.idgudang = d.id_divisi"
        s = s & " and a.time_ambil is null"
        s = s & " and a.idsuratjalan = '" & ListSJ.Items(brssj).SubItems(4).Text & "'"
        If LevelMinta <> 0 Then
            s = s & " and a.user_input = '" & UserMinta & "'"
        End If
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds.Clear()
        tbl = New DataTable
        tbl.Clear()
        da.Fill(tbl)
        For i = 0 To tbl.Rows.Count - 1
            With ListDetail
                .Items.Add(tbl.Rows(i)("idbarang"))
                With .Items(.Items.Count - 1).SubItems
                    .Add(tbl.Rows(i)("barang"))
                    .Add(tbl.Rows(i)("jml_barang"))
                    .Add(tbl.Rows(i)("satuan"))
                    .Add(tbl.Rows(i)("idminta"))
                End With
            End With
        Next
        GGVM_conn_close()
        Me.Cursor = Cursors.Default
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
    Private Sub LoadPengajuan()
        Dim s As String

        GGVM_conn()
        s = ""
        s = s & " select nopengajuan,idpengajuan from pengajuan "
        s = s & " where nopengajuan like '%" & TNopengajuan.Text & "%'"
        s = s & " and user_input = '" & UserMinta & "'"
        's = s & " and idtrans_bank is null "
        s = s & " order by nopengajuan"
        'da = Nothing
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "pengajuan")

        GridPanel.DataSource = ds.Tables("pengajuan")
        GridPanel.Refresh()
        GridPanel.Columns(0).HeaderText = "NO PENGAJUAN"
        GridPanel.Columns(1).HeaderText = "ID PENGAJUAN"
        GridPanel.Columns(0).Width = 500
        GridPanel.Columns(1).Width = 50
        GGVM_conn_close()
    End Sub
    Private Sub LoadDivisi()
        Dim s As String

        GGVM_conn()
        s = " select nama,id_divisi from divisi"
        If LevelMinta <> 0 Then
            s = s & " where id_divisi='" & DivMinta & "'"
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
#End Region
    Private Sub FrmPermintaan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTTanggal.Format = DateTimePickerFormat.Custom
        DTTanggal.CustomFormat = "dd/MM/yyyy"
        ListHeaderBrg()
        ListHeaderSJ()
        ListDetailSJ()
        'TUserName.Enabled = True
        'TUserName.Focus()
        DivMinta = DivUser
        LevelMinta = LevelUser
        UserMinta = userid
        BtnRefresh.Enabled = True
        BtnEntry.Enabled = True
        BtnEdit.Enabled = True
        DTTanggal.Enabled = True
        RBATK.Enabled = True
        RBEVEN.Enabled = True
        RBPRODUKSI.Enabled = True
        RBSPG.Enabled = True
        RBIT.Enabled = True
        BtnDivisi.Enabled = True
        BtnSubDivisi.Enabled = True
        BtnSubDivisi.Focus()
    End Sub
    Private Sub BtnDivisi_Click(sender As Object, e As EventArgs) Handles BtnDivisi.Click
        LoadDt = "divisi"
        PanelSurvei.Visible = True
        LoadDivisi()
        GridPanel.Focus()
    End Sub
    Private Sub BtnSubDivisi_Click(sender As Object, e As EventArgs) Handles BtnSubDivisi.Click
        LoadDt = "subdivisi"
        PanelSurvei.Visible = True
        LoadSubDivisi()
        GridPanel.Focus()
    End Sub
    Private Sub BtnEntry_Click(sender As Object, e As EventArgs) Handles BtnEntry.Click
        If RBATK.Checked = False And RBEVEN.Checked = False And RBPRODUKSI.Checked = False And RBSPG.Checked = False And RBIT.Checked = False Then
            MsgBox("Pilih dulu GUDANG nya !!!....", MsgBoxStyle.Information, "Information")
            Exit Sub
        End If
        If TIdSubdivisi.Text = "" And TSubDivisi.Text = "" Then
            MsgBox("Pilih dulu SUB DIVISI nya !!!....", MsgBoxStyle.Information, "Information")
            Exit Sub
        End If
        If RBATK.Checked = True Then
            If TIdPengajuan.Text = "" Then
                MsgBox("Inputkan dulu No.Pengajuannya!!...Jika belum lakukan Pengajuan ATK ke Finance dulu..", MsgBoxStyle.Information, "Information")
                TNopengajuan.Focus()
                Exit Sub
            End If
        End If

        PBarang.Visible = True
        TIdMinta.Text = ""
        TIdBarang.Text = ""
        TBarang.Text = ""
        TSaldo.Text = "0"
        TJumlah.Text = "0"
        TSatuan.Text = ""
        TNoPO.Text = ""
        TIDPO.Text = ""
        Proses = "entry"
        If RBPRODUKSI.Checked = True Then
            PPOProduksi.Visible = True
        Else
            PPOProduksi.Visible = False
        End If
        TCariBrg.Focus()

    End Sub
    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        Dim ada As Boolean
        Dim brsP, jmldt As Integer
        Dim cmd As New OdbcCommand
        'Dim s As String
        'Dim tbl As DataTable


        ada = False
        jmldt = 0
        For i = 0 To ListBarang.Items.Count - 1
            If ListBarang.Items(i).Checked = True Then
                ada = True
                brsP = i
                jmldt = jmldt + 1
            End If
        Next
        If ada = False Then
            MsgBox("Tidak ada data PERMINTAAN BARANG yang akan di EDIT, Pilih dulu datanya!!...", MsgBoxStyle.Information, "Information")
            ListBarang.Focus()
            Exit Sub
        End If
        If jmldt > 1 Then
            MsgBox("Hanya 1(satu) data PERMINTAAN BARANG yg bisa di-EDIT !!...", MsgBoxStyle.Information, "Information")
            ListBarang.Focus()
            Exit Sub
        End If
        PBarang.Visible = True
        TIdBarang.Text = ListBarang.Items(brsP).SubItems(2).Text
        TBarang.Text = ListBarang.Items(brsP).SubItems(3).Text
        TJumlah.Text = ListBarang.Items(brsP).SubItems(4).Text
        TSatuan.Text = ListBarang.Items(brsP).SubItems(5).Text
        TIdMinta.Text = ListBarang.Items(brsP).SubItems(6).Text
        TSaldo.Text = "0"
        If RBPRODUKSI.Checked = True Then
            PPOProduksi.Visible = True
            TNoPO.Text = ListBarang.Items(brsP).SubItems(7).Text
            TIDPO.Text = ListBarang.Items(brsP).SubItems(8).Text
        Else
            PPOProduksi.Visible = False
        End If
        Proses = "edit"
        TJumlah.Focus()
    End Sub
    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click
        Dim c, s As String
        Dim cmd As New OdbcCommand
        Dim tbl As DataTable
        Dim jmlMinta, jmlMaju As Integer

        Me.Cursor = Cursors.WaitCursor
        GGVM_conn()
        'CEK PENGAMBILAN BARANG HARUS = PENGAJUAN FINANCE
        If RBATK.Checked = True Then
            s = ""
            s = s & " select count(*)as ada from detail_pengajuan"
            s = s & " where idpengajuan ='" & TIdPengajuan.Text & "' "
            s = s & " and idbarang='" & TIdBarang.Text & "'"
            da = New OdbcDataAdapter(s, conn)
            ds.Clear()
            tbl = New DataTable
            tbl.Clear()
            da.Fill(tbl)

            If tbl.Rows(0)("ada") = 0 Then
                Me.Cursor = Cursors.Default
                MsgBox(" Pengambilan barang di-Gudang harus = Pengajuan di-Finance !!..", MsgBoxStyle.Information, "Information")
                TNopengajuan.Focus()
                Exit Sub
            Else
                s = ""
                s = s & " select * from detail_pengajuan"
                s = s & " where idpengajuan ='" & TIdPengajuan.Text & "' "
                s = s & " and idbarang='" & TIdBarang.Text & "'"
                da = New Odbc.OdbcDataAdapter(s, conn)
                ds.Clear()
                tbl = New DataTable
                tbl.Clear()
                da.Fill(tbl)

                jmlMinta = TJumlah.Text
                jmlMaju = tbl.Rows(0)("Jml_barang")
                If jmlMinta <> jmlMaju Then
                    Me.Cursor = Cursors.Default
                    MsgBox("Jumlah Permintaan Gudang dan Jumlah Pengajuan harus sama !!...", vbInformation, "Information")
                    TJumlah.Focus()
                    Exit Sub
                End If
            End If
        End If
        Select Case Proses
            Case "entry"
                c = ""
                If RBATK.Checked = True Then
                    c = c & " insert into permintaan_gdg_atk (tanggal,idsubdivisi,idgudang,idbarang,jml_barang,idsatuan,user_input,time_input,idpengajuan) values"
                    c = c & " ( now(),'" & TIdSubdivisi.Text & "','11','" & TIdBarang.Text & "','" & TJumlah.Text & "','" & TIdSatuan.Text & "','" & UserMinta & "',now(),'" & TIdPengajuan.Text & "')"
                End If
                If RBEVEN.Checked = True Then
                    c = c & " insert into permintaan_gdg_even (tanggal,idsubdivisi,idgudang,idbarang,jml_barang,idsatuan,user_input,time_input) values"
                    c = c & " ( now(),'" & TIdSubdivisi.Text & "','12','" & TIdBarang.Text & "','" & TJumlah.Text & "','" & TIdSatuan.Text & "','" & UserMinta & "',now())"
                End If
                If RBPRODUKSI.Checked = True Then
                    c = c & " insert into permintaan_gdg_atk (tanggal,idsubdivisi,idgudang,idbarang,jml_barang,idsatuan,user_input,time_input,nopo,idpo) values"
                    c = c & " ( now(),'" & TIdSubdivisi.Text & "','13','" & TIdBarang.Text & "','" & TJumlah.Text & "','" & TIdSatuan.Text & "','" & UserMinta & "',now(),'" & TNoPO.Text & "'"
                    If TIDPO.Text = "" Then
                        c = c & ")"
                    Else
                        c = c & ",'" & TIDPO.Text & "')"
                    End If
                End If
                If RBSPG.Checked = True Then
                    c = c & " insert into permintaan_gdg_spg (tanggal,idsubdivisi,idgudang,idbarang,jml_barang,idsatuan,user_input,time_input) values"
                    c = c & " ( now(),'" & TIdSubdivisi.Text & "','14','" & TIdBarang.Text & "','" & TJumlah.Text & "','" & TIdSatuan.Text & "','" & UserMinta & "',now())"
                End If
                If RBIT.Checked = True Then
                    c = c & " insert into permintaan_gdg_it (tanggal,idsubdivisi,idgudang,idbarang,jml_barang,idsatuan,user_input,time_input) values"
                    c = c & " ( now(),'" & TIdSubdivisi.Text & "','15','" & TIdBarang.Text & "','" & TJumlah.Text & "','" & TIdSatuan.Text & "','" & UserMinta & "',now())"
                End If
                cmd = New OdbcCommand(c, conn)
                cmd.ExecuteNonQuery()

                GGVM_conn_close()
                Me.Cursor = Cursors.Default
                MsgBox("Data sudah Di-SIMPAN !!!....", vbInformation, "Information")
            Case "edit"
                c = ""
                If RBATK.Checked = True Then
                    c = c & " update permintaan_gdg_atk set "
                End If
                If RBEVEN.Checked = True Then
                    c = c & " update permintaan_gdg_even set "
                End If
                If RBSPG.Checked = True Then
                    c = c & " update permintaan_gdg_spg set "
                End If
                If RBPRODUKSI.Checked = True Then
                    c = c & " update permintaan_gdg_produksi set "
                    c = c & " nopo_prd = '" & TNoPO.Text & "',"
                    If TIDPO.Text <> "" Then
                        c = c & " idpo_prd = '" & TIDPO.Text & "',"
                    End If
                End If
                If RBIT.Checked = True Then
                    c = c & " update permintaan_gdg_it set "
                End If
                c = c & " jml_barang = '" & TJumlah.Text & "',"
                c = c & " time_koreksi = now()"
                c = c & " where idminta = '" & TIdMinta.Text & "'"
                cmd = New Odbc.OdbcCommand(c, conn)
                cmd.ExecuteNonQuery()

                GGVM_conn_close()
                Me.Cursor = Cursors.Default
                MsgBox("Data sudah Di-KOREKSI !!!....", vbInformation, "Information")
        End Select
        PBarang.Visible = False
        TampilMinta()

    End Sub
    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        Me.Close()
        Exit Sub
    End Sub
    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        ListHeaderBrg()
        ListHeaderSJ()
        TampilMinta()
        TampilSJ()
    End Sub
    Private Sub BtnTutup_Click(sender As Object, e As EventArgs) Handles BtnTutup.Click
        PBarang.Visible = False
    End Sub
    Private Sub TJumlah_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TJumlah.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            BtnSimpan.Focus()
        End If

    End Sub
    Private Sub BtnTutupPanel_Click(sender As Object, e As EventArgs) Handles BtnTutupPanel.Click
        PanelSurvei.Visible = False
    End Sub
    Private Sub BtnHapus_Click(sender As Object, e As EventArgs) Handles BtnHapus.Click
        Dim ada As Boolean
        Dim brsP, jmldt As Integer
        Dim cmd As New OdbcCommand
        Dim c As String


        ada = False
        jmldt = 0
        For i = 0 To ListBarang.Items.Count - 1
            If ListBarang.Items(i).Checked = True Then
                ada = True
                brsP = i
                jmldt = jmldt + 1
            End If
        Next
        If ada = False Then
            MsgBox("Tidak ada data PERMINTAAN BARANG yang akan di HAPUS, Pilih dulu datanya!!...", MsgBoxStyle.Information, "Information")
            ListBarang.Focus()
            Exit Sub
        End If
        If jmldt > 1 Then
            MsgBox("Hanya 1(satu) data PERMINTAAN BARANG yg bisa di-HAPUS !!...", MsgBoxStyle.Information, "Information")
            ListBarang.Focus()
            Exit Sub
        End If
        If MsgBox(" Anda Yakin mengHAPUS data permintaan barang ?...", MsgBoxStyle.YesNo, "Question") = MsgBoxResult.Yes Then

            TIdMinta.Text = ListBarang.Items(brsP).SubItems(6).Text

            GGVM_conn()
            c = ""
            If RBATK.Checked = True Then
                c = c & " delete from permintaan_gdg_atk "
            End If
            If RBEVEN.Checked = True Then
                c = c & " delete from permintaan_gdg_even "
            End If
            If RBPRODUKSI.Checked = True Then
                c = c & " delete from permintaan_gdg_produksi "
            End If
            If RBSPG.Checked = True Then
                c = c & " delete from permintaan_gdg_spg "
            End If
            If RBIT.Checked = True Then
                c = c & " delete from permintaan_gdg_it "
            End If
            c = c & " where idminta = '" & ListBarang.Items(brsP).SubItems(6).Text & "'"
            cmd = New Odbc.OdbcCommand(c, conn)
            cmd.ExecuteNonQuery()
            GGVM_conn_close()
            MsgBox("Data sudah Di-HAPUS !!!....", vbInformation, "Information")
            TampilMinta()
        End If
    End Sub
    Private Sub BtnSJ_Click(sender As Object, e As EventArgs) Handles BtnEntrySJ.Click
        Dim ada As Boolean
        Dim brsP, jmldt As Integer
        Dim cmd As New OdbcCommand
        'Dim s As String
        'Dim tbl As DataTable

        ada = False
        jmldt = 0
        For i = 0 To ListBarang.Items.Count - 1
            If ListBarang.Items(i).Checked = True Then
                ada = True
                brsP = i
                jmldt = jmldt + 1
            End If
        Next
        If ada = False Then
            MsgBox("Tidak ada data PERMINTAAN BARANG yang akan di BUATKAN SURAT JALAN, Pilih dulu datanya!!...", MsgBoxStyle.Information, "Information")
            ListBarang.Focus()
            Exit Sub
        End If
        ProsesSJ = "entry"
        TIdSJ.Text = ""
        TNoSJ.Text = ""
        TKirim.Text = ""
        TPengirim.Text = ""
        PKirim.Visible = True
        TKirim.Focus()
    End Sub
    Private Sub BtnCetak_Click(sender As Object, e As EventArgs) Handles BtnCetak.Click
        Dim ada As Boolean
        Dim brsP, jmldt As Integer
        Dim cmd As New OdbcCommand
        Dim f As New FrmCetak
        Dim c, krm, s As String
        Dim tbl As DataTable


        ada = False
        jmldt = 0
        For i = 0 To ListSJ.Items.Count - 1
            If ListSJ.Items(i).Checked = True Then
                ada = True
                brsP = i
                jmldt = jmldt + 1
            End If
        Next
        If ada = False Then
            MsgBox("Tidak ada data SURAT JALAN yang akan di-CETAK, Pilih dulu datanya!!...", MsgBoxStyle.Information, "Information")
            ListSJ.Focus()
            Exit Sub
        End If
        If jmldt > 1 Then
            MsgBox("Hanya 1(satu) data SURAT JALAN yg bisa di-CETAK !!...", MsgBoxStyle.Information, "Information")
            ListSJ.Focus()
            Exit Sub
        End If

        GGVM_conn()
        c = ""
        c = c & " delete from buffer_sj_gudang "
        cmd = New Odbc.OdbcCommand(c, conn)
        cmd.ExecuteNonQuery()

        c = ""
        c = c & " delete from buffer_sjdetail_gudang "
        cmd = New Odbc.OdbcCommand(c, conn)
        cmd.ExecuteNonQuery()

        s = ""
        s = s & " select * "
        If RBATK.Checked = True Then
            s = s & " from suratjalan_atk"
        End If
        If RBEVEN.Checked = True Then
            s = s & " from suratjalan_even"
        End If
        If RBPRODUKSI.Checked = True Then
            s = s & " from suratjalan_produksi"
        End If
        If RBSPG.Checked = True Then
            s = s & " from suratjalan_spg"
        End If
        If RBIT.Checked = True Then
            s = s & " from suratjalan_it"
        End If
        s = s & " where idsuratjalan ='" & ListSJ.Items(brsP).SubItems(4).Text & "'"
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds.Clear()
        tbl = New DataTable
        tbl.Clear()
        da.Fill(tbl)


        krm = replaceNewLine(tbl.Rows(0)("kirim"), False)
        c = ""
        c = c & " insert into buffer_sj_gudang ( kirim,pengirim,tanggal,nosj) values"
        c = c & " ( '" & krm & "','" & tbl.Rows(0)("pengirim") & "','" & Format(tbl.Rows(0)("tanggal"), "yyyy/mm/dd") & "','" & tbl.Rows(0)("nosj") & "')"
        cmd = New Odbc.OdbcCommand(c, conn)
        cmd.ExecuteNonQuery()

        s = ""
        s = s & " select b.barang,c.satuan,a.jml_barang "
        If RBATK.Checked = True Then
            s = s & " from permintaan_gdg_atk a, master_barang_atk b, satuan c"
        End If
        If RBEVEN.Checked = True Then
            s = s & " from permintaan_gdg_even a, master_barang_even b, satuan c"
        End If
        If RBPRODUKSI.Checked = True Then
            s = s & " from permintaan_gdg_produksi a, master_barang_produksi b, satuan c"
        End If
        If RBSPG.Checked = True Then
            s = s & " from permintaan_gdg_spg a, master_barang_spg b, satuan c"
        End If
        If RBIT.Checked = True Then
            s = s & " from permintaan_gdg_it a, master_barang_it b, satuan c"
        End If
        s = s & " where idsuratjalan ='" & ListSJ.Items(brsP).SubItems(4).Text & "'"
        s = s & " and a.idbarang = b.idbarang"
        s = s & " and a.idsatuan = c.idsatuan"
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds.Clear()
        tbl = New DataTable
        tbl.Clear()
        da.Fill(tbl)

        Dim urut = 0
        For i = 0 To tbl.Rows.Count - 1
            urut = urut + 1
            c = ""
            c = c & " insert into buffer_sjdetail_gudang (urut,barang,jumlah,satuan) values"
            c = c & " ( '" & urut & "','" & tbl.Rows(0)("barang") & "','" & tbl.Rows(0)("jml_barang") & "','" & tbl.Rows(0)("satuan") & "')"
            cmd = New Odbc.OdbcCommand(c, conn)
            cmd.ExecuteNonQuery()
        Next

        GGVM_conn_close()
        ProsesCetak = "sj-gudang"
        f.ShowDialog()

    End Sub
    Private Sub BtnSimpanSJ_Click(sender As Object, e As EventArgs) Handles BtnSimpanSJ.Click
        Dim c, s, krm As String
        Dim cmd As New OdbcCommand
        Dim tbl As DataTable

        Me.Cursor = Cursors.WaitCursor
        krm = replaceNewLine(TKirim.Text, True)
        GGVM_conn()
        Select Case ProsesSJ
            Case "entry"
                s = ""
                s = s & " select nosj_gudang,blnsj_gudang from counter"
                da = New Odbc.OdbcDataAdapter(s, conn)
                ds.Clear()
                tbl = New DataTable
                tbl.Clear()
                da.Fill(tbl)

                Dim count As Integer
                Dim blnskrng As Integer
                Dim nourut As String

                blnskrng = Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(DTTanggal.Text, 5), 2)
                If blnskrng = tbl.Rows(0)("blnsj_gudang") Then
                    count = tbl.Rows(0)("nosj_gudang")
                Else
                    count = 0
                End If
                count = count + 1
                nourut = Microsoft.VisualBasic.Right("000" & count, 3)
                TNoSJ.Text = Replace(DTTanggal.Text, "/", "") + "-" + nourut

                c = ""
                If count = 1 Then
                    c = c & " update counter set nosj_gudang = '" & count & "',"
                    c = c & " blnsj_gudang = '" & Microsoft.VisualBasic.Right(Microsoft.VisualBasic.Left(DTTanggal.Text, 5), 2) & "'"
                Else
                    c = c & " update counter set nosj_gudang = '" & count & "'"
                End If
                cmd = New Odbc.OdbcCommand(c, conn)
                cmd.ExecuteNonQuery()

                c = ""
                If RBATK.Checked = True Then
                    c = c & " insert into suratjalan_atk (nosj,kirim,pengirim,tanggal) values"
                End If
                If RBEVEN.Checked = True Then
                    c = c & " insert into suratjalan_even (nosj,kirim,pengirim,tanggal) values"
                End If
                If RBPRODUKSI.Checked = True Then
                    c = c & " insert into suratjalan_produksi (nosj,kirim,pengirim,tanggal) values"
                End If
                If RBSPG.Checked = True Then
                    c = c & " insert into suratjalan_spg (nosj,kirim,pengirim,tanggal) values"
                End If
                If RBIT.Checked = True Then
                    c = c & " insert into suratjalan_it (nosj,kirim,pengirim,tanggal) values"
                End If
                c = c & " ( '" & TNoSJ.Text & "','" & krm & "','" & TPengirim.Text & "','" & Format(DTTanggal.Value, "yyyy-MM-dd") & "')"
                cmd = New Odbc.OdbcCommand(c, conn)
                cmd.ExecuteNonQuery()

                s = ""
                s = s & " select max(idsuratjalan)as id "
                If RBATK.Checked = True Then
                    s = s & " from suratjalan_atk"
                End If
                If RBEVEN.Checked = True Then
                    s = s & " from suratjalan_even"
                End If
                If RBPRODUKSI.Checked = True Then
                    s = s & " from suratjalan_produksi"
                End If
                If RBSPG.Checked = True Then
                    s = s & " from suratjalan_spg"
                End If
                If RBIT.Checked = True Then
                    s = s & " from suratjalan_it"
                End If
                da = New Odbc.OdbcDataAdapter(s, conn)
                ds.Clear()
                tbl = New DataTable
                tbl.Clear()
                da.Fill(tbl)
                TIdSJ.Text = tbl.Rows(0)("id")

                For i = 0 To ListBarang.Items.Count - 1
                    If ListBarang.Items(i).Checked = True Then
                        c = ""
                        If RBATK.Checked = True Then
                            c = c & " update permintaan_gdg_atk"
                        End If
                        If RBEVEN.Checked = True Then
                            c = c & " update permintaan_gdg_even"
                        End If
                        If RBPRODUKSI.Checked = True Then
                            c = c & " update permintaan_gdg_produksi"
                        End If
                        If RBSPG.Checked = True Then
                            c = c & " update permintaan_gdg_spg"
                        End If
                        If RBIT.Checked = True Then
                            c = c & " update permintaan_gdg_it"
                        End If
                        c = c & " set idsuratjalan = '" & TIdSJ.Text & "'"
                        c = c & " where idminta = '" & ListBarang.Items(i).SubItems(6).Text & "'"
                        cmd = New Odbc.OdbcCommand(c, conn)
                        cmd.ExecuteNonQuery()
                    End If
                Next

                Me.Cursor = Cursors.Default
                GGVM_conn_close()
                MsgBox("Data SURAT JALAN sudah Di-SIMPAN !!!....", vbInformation, "Information")
            Case "edit"

                c = ""
                If RBATK.Checked = True Then
                    c = c & " update suratjalan_atk "
                End If
                If RBEVEN.Checked = True Then
                    c = c & " update suratjalan_even "
                End If
                If RBSPG.Checked = True Then
                    c = c & " update suratjalan_spg "
                End If
                If RBPRODUKSI.Checked = True Then
                    c = c & " update suratjalan_produksi "
                End If
                If RBIT.Checked = True Then
                    c = c & " update suratjalan_it "
                End If
                c = c & " set kirim ='" & krm & "',"
                c = c & " pengirim = '" & TPengirim.Text & "'"
                c = c & " where idsuratjalan = '" & TIdSJ.Text & "'"
                cmd = New Odbc.OdbcCommand(c, conn)
                cmd.ExecuteNonQuery()
                GGVM_conn_close()
        End Select
        PKirim.Visible = False
        TampilSJ()
    End Sub
    Private Sub BtnEditSJ_Click(sender As Object, e As EventArgs) Handles BtnEditSJ.Click
        Dim ada As Boolean
        Dim brsP, jmldt As Integer
        Dim cmd As New OdbcCommand
        Dim c As String
        'Dim tbl As DataTable

        Select Case MsgBox(" <Yes> untuk EDIT Surat Jalan, <No> untuk DELETE Surat Jalan ?...,", MsgBoxStyle.YesNoCancel, "Question")
            Case MsgBoxResult.Yes
                ada = False
                jmldt = 0
                For i = 0 To ListSJ.Items.Count - 1
                    If ListSJ.Items(i).Checked = True Then
                        ada = True
                        brsP = i
                        jmldt = jmldt + 1
                    End If
                Next
                If ada = False Then
                    MsgBox("Tidak ada data SURAT JALAN yang akan di EDIT, Pilih dulu datanya!!...", MsgBoxStyle.Information, "Information")
                    ListSJ.Focus()
                    Exit Sub
                End If
                If jmldt > 1 Then
                    MsgBox("Hanya 1(satu) data SURAT JALAN yg bisa di-EDIT !!...", MsgBoxStyle.Information, "Information")
                    ListSJ.Focus()
                    Exit Sub
                End If
                ProsesSJ = "edit"
                TNoSJ.Text = ListSJ.Items(brssj).SubItems(0).Text
                TKirim.Text = replaceNewLine(ListSJ.Items(brssj).SubItems(2).Text, False)
                TPengirim.Text = ListSJ.Items(brssj).SubItems(3).Text
                TIdSJ.Text = ListSJ.Items(brssj).SubItems(4).Text
                PKirim.Visible = True
                TKirim.Focus()
            Case MsgBoxResult.No
                ada = False
                jmldt = 0
                For i = 0 To ListDetail.Items.Count - 1
                    If ListDetail.Items(i).Checked = True Then
                        ada = True
                        brsP = i
                        jmldt = jmldt + 1
                    End If
                Next
                If ada = False Then
                    MsgBox("Tidak ada data SURAT JALAN yang akan di EDIT, Pilih dulu datanya!!...", MsgBoxStyle.Information, "Information")
                    ListDetail.Focus()
                    Exit Sub
                End If
                If jmldt > 1 Then
                    MsgBox("Hanya 1(satu) data SURAT JALAN yg bisa di-EDIT !!...", MsgBoxStyle.Information, "Information")
                    ListDetail.Focus()
                    Exit Sub
                End If

                If MsgBox("Anda yakin menghapus detail Surat Jalan !!!..", MsgBoxStyle.OkCancel, "Question") = MsgBoxResult.Ok Then
                    Me.Cursor = Cursors.WaitCursor
                    GGVM_conn()

                    c = ""
                    If RBATK.Checked = True Then
                        c = c & " update permintaan_gdg_atk"
                    End If
                    If RBEVEN.Checked = True Then
                        c = c & " update permintaan_gdg_even"
                    End If
                    If RBPRODUKSI.Checked = True Then
                        c = c & " update permintaan_gdg_produksi"
                    End If
                    If RBSPG.Checked = True Then
                        c = c & " update permintaan_gdg_spg"
                    End If
                    If RBIT.Checked = True Then
                        c = c & " update permintaan_gdg_it"
                    End If
                    c = c & " set idsuratjalan= null"
                    c = c & " where idminta ='" & ListDetail.Items(brsP).SubItems(4).Text & "'"
                    cmd = New Odbc.OdbcCommand(c, conn)
                    cmd.ExecuteNonQuery()

                    GGVM_conn_close()
                    Me.Cursor = Cursors.Default
                Else
                    Exit Sub
                End If
        End Select
    End Sub
    Private Sub BtnACC_Click(sender As Object, e As EventArgs) Handles BtnACC.Click
        Dim ada As Boolean
        Dim brsP, jmldt As Integer
        Dim cmd As New OdbcCommand
        Dim c As String
        'Dim tbl As DataTable


        ada = False
        jmldt = 0
        For i = 0 To ListBarang.Items.Count - 1
            If ListBarang.Items(i).Checked = True Then
                ada = True
                brsP = i
                jmldt = jmldt + 1
            End If
        Next
        If ada = False Then
            MsgBox("Tidak ada data PERMINTAAN BARANG yang akan di ACC, Pilih dulu datanya!!...", MsgBoxStyle.Information, "Information")
            ListBarang.Focus()
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        GGVM_conn()
        For i = 0 To ListBarang.Items.Count - 1
            If ListBarang.Items(i).Checked = True Then
                c = ""
                If RBATK.Checked = True Then
                    c = c & " update permintaan_gdg_atk"
                End If
                If RBEVEN.Checked = True Then
                    c = c & " update permintaan_gdg_even"
                End If
                If RBPRODUKSI.Checked = True Then
                    c = c & " update permintaan_gdg_produksi"
                End If
                If RBSPG.Checked = True Then
                    c = c & " update permintaan_gdg_spg"
                End If
                If RBIT.Checked = True Then
                    c = c & " update permintaan_gdg_it"
                End If
                c = c & " set time_ambil = now()"
                c = c & " where idminta ='" & ListBarang.Items(i).SubItems(6).Text & "'"
                cmd = New Odbc.OdbcCommand(c, conn)
                cmd.ExecuteNonQuery()
            End If
        Next
        GGVM_conn_close()
        Me.Cursor = Cursors.Default

        ListHeaderBrg()
        ListHeaderSJ()
        TampilMinta()
    End Sub
    Private Sub BtnTutupSJ_Click(sender As Object, e As EventArgs) Handles BtnTutupSJ.Click
        TIdSJ.Text = ""
        TNoSJ.Text = ""
        TKirim.Text = ""
        TPengirim.Text = ""
        PKirim.Visible = False
    End Sub
    Private Sub TCariBrg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TCariBrg.KeyPress
        Dim s As String
        Dim tbl As New DataTable


        If e.KeyChar = Convert.ToChar(32) Or e.KeyChar = Convert.ToChar(127) Then
        Else
            'If e.KeyChar = Convert.ToChar(13) Then
            GGVM_conn()
            LoadDt = "caribrg"
            s = ""
            s = s & " select y.* from ("
            s = s & " select a.barang,a.saldo,b.satuan,a.idbarang,a.idsatuan "
            If RBATK.Checked = True Then
                s = s & " from master_barang_atk a,"
            End If
            If RBEVEN.Checked = True Then
                s = s & " from master_barang_even a,"
            End If
            If RBSPG.Checked = True Then
                s = s & " from master_barang_spg a,"
            End If
            If RBPRODUKSI.Checked = True Then
                s = s & " from master_barang_produksi a,"
            End If
            If RBIT.Checked = True Then
                s = s & " from master_barang_it a,"
            End If
            s = s & " satuan b"
            s = s & "  where a.idsatuan = b.idsatuan"
            s = s & " and a.barang like '%" & TCariBrg.Text & "%'"
            s = s & " ) y"
            Me.Cursor = Cursors.WaitCursor
            da = New Odbc.OdbcDataAdapter(s, conn)
            ds = New DataSet
            ds.Clear()
            da.Fill(ds, "y")
            GridPanel.DataSource = ds.Tables("y")
            GridPanel.Refresh()
            GridPanel.Columns(0).Width = 200
            GridPanel.Columns(1).Width = 80
            GridPanel.Columns(2).Width = 100
            GridPanel.Columns(3).Width = 10
            GridPanel.Columns(4).Width = 10
            PanelSurvei.Visible = True
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
                    TIdDivisi.Text = GridPanel.Rows.Item(i).Cells(1).Value
                Case "subdivisi"
                    TSubDivisi.Text = GridPanel.Rows.Item(i).Cells(0).Value
                    TIdSubdivisi.Text = GridPanel.Rows.Item(i).Cells(1).Value
                Case "caribrg"
                    TBarang.Text = GridPanel.Rows.Item(i).Cells(0).Value
                    TSaldo.Text = GridPanel.Rows.Item(i).Cells(1).Value
                    TSatuan.Text = GridPanel.Rows.Item(i).Cells(2).Value
                    TIdBarang.Text = GridPanel.Rows.Item(i).Cells(3).Value
                    TIdSatuan.Text = GridPanel.Rows.Item(i).Cells(4).Value
                Case "maju"
                    TNopengajuan.Text = GridPanel.Rows.Item(i).Cells(0).Value
                    TIdPengajuan.Text = GridPanel.Rows.Item(i).Cells(1).Value
            End Select
            GridPanel.ClearSelection()
            LPanel.Text = ""
            PanelSurvei.Visible = False
            Select Case LoadDt
                Case "divisi"
                    BtnSubDivisi.Focus()
                Case "subdivisi"
                    If RBATK.Checked = True Then
                        TNopengajuan.Focus()
                    Else
                        BtnEntry.Focus()
                    End If
                Case "caribrg"
                    TJumlah.Focus()
                Case "maju"
                    BtnEntry.Focus()
            End Select

        End If

    End Sub
    Private Sub TPengirim_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TPengirim.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            BtnSimpanSJ.Focus()
        End If
    End Sub
    Private Sub TNopengajuan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TNopengajuan.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            LoadDt = "maju"
            PanelSurvei.Visible = True
            LoadPengajuan()
            GridPanel.Focus()
        End If
    End Sub
    Private Sub ListSJ_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListSJ.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        With Me.ListSJ

            For Each item As ListViewItem In ListSJ.SelectedItems
                brssj = item.Index
            Next

        End With
        TampilDetailSJ()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub RBATK_CheckedChanged(sender As Object, e As EventArgs) Handles RBATK.CheckedChanged
        If RBATK.Checked = True Then
            LMaju.Visible = True
            TNopengajuan.Visible = True
        Else
            LMaju.Visible = False
            TNopengajuan.Visible = False
        End If
    End Sub
End Class