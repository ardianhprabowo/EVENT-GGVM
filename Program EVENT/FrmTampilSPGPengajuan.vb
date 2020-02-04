Option Strict Off
Imports System.Data.Odbc
Public Class FrmTampilSPGPengajuan
    Dim brs As Integer
    Private Sub BtnEntry_Click(sender As Object, e As EventArgs) Handles BtnEntry.Click
        Dim f As New FrmSPGPengajuan
        Dim cmd As New OdbcCommand

        tampilSPGMaju = "0"
        'Me.Close()
        'f.MdiParent = Me
        f.ShowDialog()
        'f.Show()
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        Dim ada As Boolean
        Dim brs, jmldt As Integer
        Dim f As New FrmSPGPengajuan
        Dim cmd As New OdbcCommand
        Dim c As String


        ada = False
        jmldt = 0
        For i = 0 To ListMaju.Items.Count - 1
            If ListMaju.Items(i).Checked = True Then
                ada = True
                brs = i
                jmldt = jmldt + 1
            End If
        Next
        If ada = False Then
            MsgBox("Tidak ada data yang akan di EDIT, Pilih dulu datanya!!...", MsgBoxStyle.Information, "Information")
            ListMaju.Focus()
            Exit Sub
        End If
        If jmldt > 1 Then
            MsgBox("Hanya 1(satu) data yg bisa di-EDIT !!...", MsgBoxStyle.Information, "Information")
            ListMaju.Focus()
            Exit Sub
        End If

        Select Case MsgBox(" Pilih [YES] untuk EDIT Data, Pilih [NO] untuk HAPUS Data ??...", MsgBoxStyle.YesNoCancel, "Question")

            Case DialogResult.Yes
                tampilSPGMaju = ListMaju.Items(brs).SubItems(9).Text
                ' Me.Close()
                'f.MdiParent = Me
                f.ShowDialog()
            Case DialogResult.No
                If MsgBox("Anda yakin menghapus DATA PENGAJUAN ??....", MsgBoxStyle.OkCancel, "Question") = MsgBoxResult.Ok Then

                    Me.Cursor = Cursors.WaitCursor
                    GGVM_conn()
                    c = ""
                    c = c & " update pengajuan set "
                    c = c & " time_delete = now(),"
                    c = c & " user_delete = '" & userid & "'"
                    c = c & " where idpengajuan='" & ListMaju.Items(brs).SubItems(9).Text & "'"
                    cmd = New Odbc.OdbcCommand(c, conn)
                    cmd.ExecuteNonQuery()

                    c = ""
                    c = c & " insert into buffer_pengajuan select * from pengajuan"
                    c = c & " where idpengajuan='" & ListMaju.Items(brs).SubItems(9).Text & "'"
                    cmd = New Odbc.OdbcCommand(c, conn)
                    cmd.ExecuteNonQuery()

                    c = ""
                    c = c & " insert into buffer_detail_pengajuan select * from detail_pengajuan"
                    c = c & " where idpengajuan='" & ListMaju.Items(brs).SubItems(9).Text & "'"
                    cmd = New Odbc.OdbcCommand(c, conn)
                    cmd.ExecuteNonQuery()

                    c = ""
                    c = c & " delete from detail_pengajuan"
                    c = c & " where idpengajuan='" & ListMaju.Items(brs).SubItems(9).Text & "'"
                    cmd = New Odbc.OdbcCommand(c, conn)
                    cmd.ExecuteNonQuery()

                    c = ""
                    c = c & " delete from pengajuan"
                    c = c & " where idpengajuan='" & ListMaju.Items(brs).SubItems(9).Text & "'"
                    cmd = New Odbc.OdbcCommand(c, conn)
                    cmd.ExecuteNonQuery()
                    GGVM_conn_close()

                    TampilPengajuan()
                    Me.Cursor = Cursors.Default
                Else
                    Exit Sub
                End If
            Case Windows.Forms.DialogResult.Cancel
                Exit Sub
        End Select

    End Sub


    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        Me.Close()
        Exit Sub
    End Sub
    Private Sub ListHeaderMaju()
        ListMaju.FullRowSelect = True
        ListMaju.MultiSelect = True
        ListMaju.View = View.Details
        ListMaju.CheckBoxes = True
        ListMaju.Columns.Clear()
        ListMaju.Items.Clear()
        ListMaju.Columns.Add("NO.PENGAJUAN", 180, HorizontalAlignment.Left)
        ListMaju.Columns.Add("TANGGAL", 75, HorizontalAlignment.Left)
        ListMaju.Columns.Add("JNS.PENGAJUAN", 150, HorizontalAlignment.Left)
        ListMaju.Columns.Add("KLIEN", 150, HorizontalAlignment.Left)
        ListMaju.Columns.Add("AREA", 130, HorizontalAlignment.Left)
        ListMaju.Columns.Add("NOMINAL", 150, HorizontalAlignment.Right)
        ListMaju.Columns.Add("STATUS TAGIH", 100, HorizontalAlignment.Left)
        ListMaju.Columns.Add("WAKTU BERANGKAT", 130, HorizontalAlignment.Left)
        ListMaju.Columns.Add("WAKTU PULANG", 130, HorizontalAlignment.Left)
        ListMaju.Columns.Add("ID.PENGAJUAN", 100, HorizontalAlignment.Left)
    End Sub
    Private Sub TampilPengajuan()
        Dim s As String
        Dim i As Integer
        Dim tbl As New DataTable

        ListMaju.Items.Clear()

        GGVM_conn()
        s = ""
        s = s & " select x.*,if (klien.nama is null,'',klien.nama)as klien, "
        s = s & " if (area.area is null,'',area.area)as area"
        s = s & " FROM ("
        s = s & "  select a.nopengajuan, a.tanggal, b.pengajuan,a.idarea,"
        s = s & " case "
        s = s & " when  a.statustagih='D' then 'DITAGIHKAN' "
        s = s & " when a.statustagih='T' THEN 'TIDAK DITAGIHKAN'  "
        s = s & " ELSE 'FIX COST' "
        s = s & " end as ststagih ,"
        s = s & " a.waktu_berangkat,a.waktu_pulang,"
        s = s & " if (a.keterangan is null,'',a.keterangan)as keterangan,"
        s = s & " a.nominal, a.idpengajuan, a.idklien,b.pengajuan as jnspengajuan"
        s = s & " from pengajuan a, jenis_pengajuan b,  subdivisi d"
        s = s & " where a.idjnspengajuan = b.idjnspengajuan"
        s = s & " and a.idjnspengajuan in (5,6,7,8,14,15,16)"
        If LevelUser = 1 Then
            s = s & " and a.user_input = '" & Trim(userid) & "'"
        End If
        s = s & " and a.idtrans_bank is null"
        s = s & " and a.idsubdivisi = d.idsubdivisi"
        s = s & " and d.id_divisi in ('2','17')"
        s = s & " and a.acc_manager is null"
        s = s & " and a.acc_finance is null"
        s = s & " and a.acc_dirkeu is null "
        s = s & "  ) x"
        s = s & "  LEFT JOIN klien"
        s = s & "  on x.idklien = klien.id"
        s = s & "  LEFT JOIN area"
        s = s & "  on x.idarea = area.idarea"
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds.Clear()
        tbl = New DataTable
        tbl.Clear()
        da.Fill(tbl)
        For i = 0 To tbl.Rows.Count - 1
            With ListMaju
                .Items.Add(tbl.Rows(i)("nopengajuan"))
                With .Items(.Items.Count - 1).SubItems
                    .Add(tbl.Rows(i)("tanggal"))
                    .Add(tbl.Rows(i)("pengajuan"))
                    .Add(tbl.Rows(i)("klien"))
                    .Add(tbl.Rows(i)("area"))
                    .Add(FormatNumber(tbl.Rows(i)("nominal"), 0, , , TriState.True))
                    .Add(tbl.Rows(i)("ststagih"))
                    .Add(tbl.Rows(i)("waktu_berangkat"))
                    .Add(tbl.Rows(i)("waktu_pulang"))
                    .Add(tbl.Rows(i)("idpengajuan"))
                End With
            End With
        Next
        GGVM_conn_close()
    End Sub
    Private Sub FrmTampilSPGPengajuan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        'Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
        ' Me.MdiParent = MDIGeogiven

        ListHeaderMaju()
        TampilPengajuan()
    End Sub
    Private Sub TampilDetail()
        Dim s As String
        'Dim i As Integer
        Dim tbl As New DataTable

        GridDetail.DataSource = Nothing
        GridDetail.Refresh()
        GGVM_conn()
        s = ""
        s = s & " select x.* from ("
        s = s & " select a.kdbarang as KD_BARANG ,a.barang AS NAMA_BARANG,"
        s = s & " if (a.keterangan is null,'',a.keterangan) as KETERANGAN,"
        s = s & " a.jml_barang AS JML, a.jml_orang AS JML_ORANG, a.jml_hari AS JML_HARI,"
        s = s & " a.harga_estimasi AS HARGA_ESTIMASI, a.sub_total AS SUB_TOTAL"
        's = s & "  a.idbarang, a.iddetail_pengajuan, a.idsatuan, b.satuan"
        s = s & " from detail_pengajuan a, satuan b"
        s = s & " where a.idsatuan = b.idsatuan"
        s = s & "     and a.idpengajuan = '" & ListMaju.Items(brs).SubItems(9).Text & "'"
        s = s & "  order by a.idbarang "
        s = s & ") x "
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "x")
        GridDetail.DataSource = ds.Tables("x")
        GridDetail.Refresh()
        GGVM_conn_close()
        If GridDetail.RowCount = 1 Then
            MsgBox("Data tidak ada !!..", MsgBoxStyle.Information, "Information")
            Exit Sub
        End If
        'GridDetail.Columns(0).Name = "KD_BARANG"
        'GridDetail.Columns(1).Name = "NAMA_BARANG"
        'GridDetail.Columns(1).Width = 150
        'GridDetail.Columns(2).Name = "KETERANGAN"
        'GridDetail.Columns(2).Width = 500
        'GridDetail.Columns(3).Name = "JML"
        'GridDetail.Columns(4).Name = "JML_ORANG"
        'GridDetail.Columns(5).Name = "FREKUENSI"
        'GridDetail.Columns(6).Name = "HRG_ESTIMASI"
        'GridDetail.Columns(7).Name = "SUB_TOTAL"
        GridDetail.AutoResizeColumns()
        GridDetail.AlternatingRowsDefaultCellStyle.BackColor = Color.Plum
    End Sub

    Private Sub ListMaju_DoubleClick(sender As Object, e As EventArgs) Handles ListMaju.DoubleClick
        Me.Cursor = Cursors.WaitCursor
        With Me.ListMaju

            For Each item As ListViewItem In ListMaju.SelectedItems
                brs = item.Index
            Next

        End With
        TampilDetail()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ListMaju_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListMaju.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        With Me.ListMaju

            For Each item As ListViewItem In ListMaju.SelectedItems
                brs = item.Index
            Next

        End With
        TampilKeterangan()
        TampilDetail()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub TampilKeterangan()
        Dim s As String
        Dim tbl As DataTable
        TKeterangan.Text = ""

        GGVM_conn()
        s = ""
        s = s & " select if(keterangan is null,'',keterangan)as keterangan from pengajuan where idpengajuan = '" & ListMaju.Items(brs).SubItems(9).Text & "'"
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds.Clear()
        tbl = New DataTable
        tbl.Clear()
        da.Fill(tbl)
        TKeterangan.Text = tbl.Rows(0)("keterangan")
        GGVM_conn_close()

    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        TampilPengajuan()
    End Sub

    Private Sub BtnCetak_Click(sender As Object, e As EventArgs) Handles BtnCetak.Click
        Dim f As New FrmCetak
        Dim cmd As New OdbcCommand
        Dim ada As Boolean
        Dim brs, jmldt As Integer
        Dim s, c As String
        Dim tbl As DataTable

        ada = False
        jmldt = 0
        For i = 0 To ListMaju.Items.Count - 1
            If ListMaju.Items(i).Checked = True Then
                ada = True
                brs = i
                jmldt = jmldt + 1
            End If
        Next

        If ada = False Then
            MsgBox("Tidak ada data PENGAJUAN yang akan di Cetak, Pilih dulu datanya!!...", MsgBoxStyle.Information, "Information")
            Exit Sub
        End If

        If jmldt > 1 Then
            MsgBox("Hanya 1(satu) data PENGAJUAN yang bisa Cetak !!...", MsgBoxStyle.Information, "Information")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        GGVM_conn()
        s = ""
        s = s & " select y.nopengajuan,y.tanggal,y.subdivisi,y.divisi,y.jnspengajuan,y.ststagih,"
        s = s & " y.nope, y.area, y.propinsi, y.kota, y.sbrdana, y.waktu_berangkat, y.waktu_pulang, y.idpengajuan,y.nominal,"
        s = s & " if (y.nama_bank is null,'',y.nama_bank)as namabank,"
        s = s & " if (y.no_rekening is null,'',y.no_rekening)as norekening,y.user_input,y.keterangan,y.klien"
        s = s & " FROM ("
        s = s & " select x.*,"
        s = s & " if (klien.nama is null,'',klien.nama)as klien,  "
        s = s & " if (area.area is null,'',area.area)as area ,"
        s = s & " if (proyek.nope is null,'',proyek.nope)as nope,"
        s = s & " propinsi.propinsi, kota.kota"
        s = s & " FROM ( "
        s = s & " select a.nopengajuan, a.tanggal, b.pengajuan,a.idarea, "
        s = s & " case  when  a.statustagih='D' then 'DITAGIHKAN'  when a.statustagih='T' THEN 'TIDAK DITAGIHKAN'   ELSE 'FIX COST'  end as ststagih , "
        s = s & " a.waktu_berangkat,a.waktu_pulang,"
        s = s & " if (a.keterangan is null,'',a.keterangan)as keterangan, "
        s = s & " a.nominal, a.idpengajuan, a.idklien,b.pengajuan as jnspengajuan,e.nama as divisi,a.idpe,d.subdivisi,"
        s = s & " a.idpropinsi,a.idkota,"
        s = s & " case when a.sumberdana='T' then 'TUNAI' when a.sumberdana ='B' then 'BANK' end as sbrdana,"
        s = s & " a.nama_bank, a.no_rekening, a.user_input"
        s = s & " from pengajuan a, jenis_pengajuan b,  subdivisi d, divisi e "
        s = s & "         where a.idjnspengajuan = b.idjnspengajuan"
        If LevelUser = 1 Then
            s = s & "  and a.user_input = '" & userid & "'"
        End If
        s = s & " and a.idtrans_bank is null "
        s = s & " and a.idsubdivisi = d.idsubdivisi "
        s = s & " and d.id_divisi = e.id_divisi "
        s = s & " and d.id_divisi in ('2','17') "
        ' s = s & " and a.idjnspengajuan = '1' "
        s = s & " and a.acc_finance is null "
        s = s & " and a.acc_dirkeu is null   "
        s = s & " ) x  LEFT JOIN klien  on x.idklien = klien.id "
        s = s & " LEFT JOIN area  on x.idarea = area.idarea"
        s = s & " LEFT JOIN proyek on x.idpe = proyek.idpe"
        s = s & " left join propinsi on x.idpropinsi = propinsi.idpropinsi"
        s = s & " left join kota on x.idkota = kota.idkota"
        s = s & " ) y"
        s = s & " where y.idpengajuan ='" & ListMaju.Items(brs).SubItems(9).Text & "'"
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds.Clear()
        tbl = New DataTable
        tbl.Clear()
        da.Fill(tbl)
        c = ""
        c = c & " delete from buffer_cetak_pengajuan "
        cmd = New Odbc.OdbcCommand(c, conn)
        cmd.ExecuteNonQuery()

        c = ""
        c = c & " insert buffer_cetak_pengajuan( nopengajuan,tanggal,subdivisi,divisi,jnspengajuan,ststagih,"
        c = c & " nope,area,propinsi,kota,sbrdana,namabank,norekening,waktuberangkat,waktupulang,idpengajuan,nominal,userid,keterangan,klien) values"
        c = c & "('" & tbl.Rows(0)("nopengajuan") & "','" & Format(tbl.Rows(0)("tanggal"), "yyyy/MM/dd") & "','" & tbl.Rows(0)("subdivisi") & "','" & tbl.Rows(0)("divisi") & "','" & tbl.Rows(0)("jnspengajuan") & "','" & tbl.Rows(0)("ststagih") & "',"
        c = c & "'" & tbl.Rows(0)("nope") & "','" & tbl.Rows(0)("area") & "','" & tbl.Rows(0)("propinsi") & "','" & tbl.Rows(0)("kota") & "','" & tbl.Rows(0)("sbrdana") & "','" & tbl.Rows(0)("namabank") & "',"
        c = c & "'" & tbl.Rows(0)("norekening") & "','" & Format(tbl.Rows(0)("waktu_berangkat"), "yyyy/MM/dd") & "','" & Format(tbl.Rows(0)("waktu_pulang"), "yyyy/MM/dd") & "','" & tbl.Rows(0)("idpengajuan") & "','" & tbl.Rows(0)("nominal") & "','" & userid & "','" & tbl.Rows(0)("keterangan") & "','" & tbl.Rows(0)("klien") & "')"
        cmd = New Odbc.OdbcCommand(c, conn)
        cmd.ExecuteNonQuery()

        tampilIdMajuSPG = ListMaju.Items(brs).SubItems(9).Text
        ProsesCetak = "majupaket"
        Me.Cursor = Cursors.Default
        GGVM_conn_close()
        f.ShowDialog()
    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs)

    End Sub
End Class