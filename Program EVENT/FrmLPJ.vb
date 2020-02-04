Option Strict Off
Imports System.ComponentModel
Imports System.ComponentModel.DataAnnotations
Imports DevExpress.XtraBars
Imports DevExpress.XtraEditors
Imports System.Data.Odbc
Imports DevExpress.XtraBars.Docking2010

Partial Public Class FrmLPJ
    Dim brs, brsMaju As Integer
    Private users As Boolean = False
    Public Sub New()
        InitializeComponent()
        Dim username As New WindowsUIButton() With {.Tag = "user", .Checked = False}
    End Sub

    Public Property Users1 As Boolean
        Get
            Return users
        End Get
        Set(value As Boolean)
            users = value
        End Set
    End Property
#Region "Listview"
    Private Sub ListHeaderMaju()
        ListMaju.FullRowSelect = True
        ListMaju.MultiSelect = True
        ListMaju.View = View.Details
        ListMaju.CheckBoxes = True
        ListMaju.Columns.Clear()
        ListMaju.Items.Clear()
        ListMaju.Columns.Add("NO.PENGAJUAN", 180, HorizontalAlignment.Left)
        ListMaju.Columns.Add("DIVISI", 100, HorizontalAlignment.Left)
        ListMaju.Columns.Add("TANGGAL", 75, HorizontalAlignment.Left)
        ListMaju.Columns.Add("JNS.PENGAJUAN", 100, HorizontalAlignment.Left)
        ListMaju.Columns.Add("KLIEN", 150, HorizontalAlignment.Left)
        ListMaju.Columns.Add("AREA", 130, HorizontalAlignment.Left)
        ListMaju.Columns.Add("NOMINAL", 150, HorizontalAlignment.Right)
        ListMaju.Columns.Add("STATUS TAGIH", 100, HorizontalAlignment.Left)
        ListMaju.Columns.Add("WAKTU BERANGKAT", 130, HorizontalAlignment.Left)
        ListMaju.Columns.Add("WAKTU PULANG", 130, HorizontalAlignment.Left)
        ListMaju.Columns.Add("ID.PENGAJUAN", 10, HorizontalAlignment.Left)
    End Sub

    Private Sub ListHeaderLPJ()
        ListLPJ.FullRowSelect = True
        ListLPJ.MultiSelect = True
        ListLPJ.View = View.Details
        ListLPJ.CheckBoxes = True
        ListLPJ.Columns.Clear()
        ListLPJ.Items.Clear()
        ListLPJ.Columns.Add("NO.PENGAJUAN", 180, HorizontalAlignment.Left)
        ListLPJ.Columns.Add("DIVISI", 100, HorizontalAlignment.Left)
        ListLPJ.Columns.Add("TANGGAL", 75, HorizontalAlignment.Left)
        ListLPJ.Columns.Add("JNS.PENGAJUAN", 100, HorizontalAlignment.Left)
        ListLPJ.Columns.Add("KLIEN", 150, HorizontalAlignment.Left)
        ListLPJ.Columns.Add("AREA", 130, HorizontalAlignment.Left)
        ListLPJ.Columns.Add("TOTAL LPJ", 150, HorizontalAlignment.Right)
        ListLPJ.Columns.Add("TOTAL PENGAJUAN", 150, HorizontalAlignment.Right)
        ListLPJ.Columns.Add("TOTAL SELISIH", 150, HorizontalAlignment.Right)
        ListLPJ.Columns.Add("STATUS TAGIH", 100, HorizontalAlignment.Left)
        ListLPJ.Columns.Add("WAKTU BERANGKAT", 130, HorizontalAlignment.Left)
        ListLPJ.Columns.Add("WAKTU PULANG", 130, HorizontalAlignment.Left)
        ListLPJ.Columns.Add("ID.PENGAJUAN", 10, HorizontalAlignment.Left)
    End Sub

#End Region
#Region "Deklarasi Perintah"
    Private Sub TampilPengajuan()
        Dim s As String
        Dim i As Integer
        Dim tbl As New DataTable

        ListMaju.Items.Clear()

        GridDetail.DataSource = Nothing
        GGVM_conn()
        s = ""
        s = s & " select n.*"
        s = s & " from ("
        s = s & " select m.*,lpj.idpengajuan as id"
        s = s & " from ( "
        s = s & " select x.*,"
        s = s & " if (klien.nama is null,'',klien.nama)as klien,  "
        s = s & " if (area.area is null,'',area.area)as area "
        s = s & " FROM (  "
        s = s & " select a.nopengajuan, a.tanggal, b.pengajuan,a.idarea, "
        s = s & " case  when  a.statustagih='D' then 'DITAGIHKAN'  "
        s = s & " ELSE 'FIX COST'  end as ststagih , "
        s = s & " a.waktu_berangkat,a.waktu_pulang, "
        s = s & " if (a.keterangan is null,'',a.keterangan)as keterangan, "
        s = s & " a.nominal, a.idpengajuan, a.idklien,b.pengajuan as jnspengajuan,e.nama as divisi "
        s = s & " from pengajuan a, jenis_pengajuan b,  subdivisi d, divisi e "
        s = s & " where a.idjnspengajuan = b.idjnspengajuan"
        If LevelUser = 1 Then
            s = s & " and a.user_input = '" & userid & "' "
        Else
            If Users1 = True Then
                s = s & " and a.user_input = '" & userid & "' "
            End If
        End If
        s = s & " and a.idsubdivisi = d.idsubdivisi "
        s = s & " and d.id_divisi = e.id_divisi "
        s = s & " and  a.idtrans_bank is not null "
        s = s & " and a.bayarorder='B'"
        s = s & " and d.id_divisi in ('2','17') "
        s = s & "  ) x  "
        s = s & " LEFT JOIN klien  on x.idklien = klien.id  "
        s = s & " LEFT JOIN area  on x.idarea = area.idarea"
        s = s & " ) m"
        s = s & " LEFT JOIN lpj on m.idpengajuan= lpj.idpengajuan"
        s = s & " ) n"
        s = s & "         where n.id Is null"

        da = New Odbc.OdbcDataAdapter(s, conn)
        ds.Clear()
        tbl = New DataTable
        tbl.Clear()
        da.Fill(tbl)
        For i = 0 To tbl.Rows.Count - 1
            With ListMaju
                .Items.Add(tbl.Rows(i)("nopengajuan"))
                With .Items(.Items.Count - 1).SubItems
                    .Add(tbl.Rows(i)("divisi"))
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
    Private Sub TampilAllLPJ()
        Dim s As String
        Dim i As Integer
        Dim tbl As New DataTable

        ListLPJ.Items.Clear()

        GridDetail.DataSource = Nothing
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
        s = s & " a.nominal, a.idpengajuan, a.idklien,b.pengajuan as jnspengajuan,e.nama as divisi,"
        s = s & " f.nominal_pengajuan, f.selisih"
        s = s & " from lpj a, jenis_pengajuan b,  subdivisi d, divisi e,trans_pengajuan_lpj f"
        s = s & " where a.idjnspengajuan = b.idjnspengajuan"
        s = s & " and f.idtrans_bank is null"
        s = s & " and a.idpengajuan = f.idpengajuan"
        If LevelUser = 1 Then
            s = s & " and a.user_input = '" & Trim(userid) & "'"
        ElseIf Users1 = True Then
            s = s & " and a.user_input = '" & Trim(userid) & "'"
        End If
        s = s & " and a.idtrans_bank is not null"
        s = s & " and a.idsubdivisi = d.idsubdivisi"
        s = s & " and d.id_divisi = e.id_divisi"
        s = s & " and d.id_divisi in ('2','17')"
        s = s & " and f.acc_manager is null "
        s = s & " and f.acc_finance is null  "
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
            With ListLPJ
                .Items.Add(tbl.Rows(i)("nopengajuan"))
                With .Items(.Items.Count - 1).SubItems
                    .Add(tbl.Rows(i)("divisi"))
                    .Add(tbl.Rows(i)("tanggal"))
                    .Add(tbl.Rows(i)("pengajuan"))
                    .Add(tbl.Rows(i)("klien"))
                    .Add(tbl.Rows(i)("area"))
                    .Add(FormatNumber(tbl.Rows(i)("nominal"), 0, , , TriState.True))
                    .Add(FormatNumber(tbl.Rows(i)("nominal_pengajuan"), 0, , , TriState.True))
                    .Add(FormatNumber(tbl.Rows(i)("selisih"), 0, , , TriState.True))
                    .Add(tbl.Rows(i)("ststagih"))
                    .Add(tbl.Rows(i)("waktu_berangkat"))
                    .Add(tbl.Rows(i)("waktu_pulang"))
                    .Add(tbl.Rows(i)("idpengajuan"))
                End With
            End With
        Next
        GGVM_conn_close()
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
        s = s & " a.harga_estimasi AS HARGA_AKTUAL, a.sub_total AS SUB_TOTAL"
        's = s & "  a.idbarang, a.iddetail_pengajuan, a.idsatuan, b.satuan"
        s = s & " from detail_lpj a, satuan b"
        s = s & " where a.idsatuan = b.idsatuan"
        s = s & "     and a.idpengajuan = '" & ListLPJ.Items(brs).SubItems(12).Text & "'"
        s = s & ") x order by nama_barang"
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
        GridDetail.AutoResizeColumns()
        GridDetail.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCoral
    End Sub
    Private Sub TampilKeterangan()
        Dim s As String
        Dim tbl As DataTable
        TKeterangan.Text = ""

        GGVM_conn()
        s = ""
        s = s & " select if(keterangan is null,'',keterangan)as keterangan from pengajuan where idpengajuan = '" & ListMaju.Items(brsMaju).SubItems(10).Text & "'"
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds.Clear()
        tbl = New DataTable
        tbl.Clear()
        da.Fill(tbl)
        TKeterangan.Text = tbl.Rows(0)("keterangan")
        GGVM_conn_close()
    End Sub
#End Region
    Private Sub FrmLPJ_Load(sender As Object, e As EventArgs) Handles Me.Load
        ListHeaderMaju()
        TampilPengajuan()
        ListHeaderLPJ()
        TampilAllLPJ()
    End Sub
    Private Sub WindowsUIButtonPanel1_ButtonClick(sender As Object, e As ButtonEventArgs) Handles WindowsUIButtonPanel1.ButtonClick
        If e.Button.Properties.Caption = "Refresh" Then
            TampilPengajuan()
        ElseIf e.Button.Properties.Caption = "Proses ke LPJ" Then
            Dim ada As Boolean
            Dim jmldt, brs As Integer
            Dim cmd As New OdbcCommand
            Dim c, s As String
            Dim np As Double
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
                MsgBox("Tidak ada data PENGAJUAN yg ditransfer menjadi LPJ, Pilih dulu datanya!!...", MsgBoxStyle.Information, "Information")
                ListMaju.Focus()
                Exit Sub
            End If
            If jmldt > 1 Then
                MsgBox("Hanya 1(satu) data PENGAJUAN yg bisa ditransfer menjadi LPJ !!...", MsgBoxStyle.Information, "Information")
                ListMaju.Focus()
                Exit Sub
            End If

            GGVM_conn()
            c = ""
            c = c & " insert into lpj select * from pengajuan"
            c = c & " where idpengajuan='" & ListMaju.Items(brs).SubItems(10).Text & "'"
            cmd = New Odbc.OdbcCommand(c, conn)
            cmd.ExecuteNonQuery()

            c = ""
            c = c & " update lpj set tanggal = now()"
            c = c & " where idpengajuan='" & ListMaju.Items(brs).SubItems(10).Text & "'"
            cmd = New Odbc.OdbcCommand(c, conn)
            cmd.ExecuteNonQuery()

            s = ""
            s = s & " select * from detail_pengajuan "
            s = s & " where idpengajuan='" & ListMaju.Items(brs).SubItems(10).Text & "'"
            s = s & " order by iddetail_pengajuan"
            da = New Odbc.OdbcDataAdapter(s, conn)
            ds.Clear()
            tbl = New DataTable
            tbl.Clear()
            da.Fill(tbl)

            For i = 0 To tbl.Rows.Count - 1
                c = ""
                c = c & " insert detail_lpj (iddetail_pengajuan,idpengajuan,idbarang,kdbarang,barang,keterangan,"
                c = c & " idsatuan, type_pengajuan, jml_barang,jml_orang,jml_hari,harga_estimasi,sub_total)"
                c = c & " values ('" & tbl.Rows(i)("iddetail_pengajuan") & "','" & tbl.Rows(i)("idpengajuan") & "','" & tbl.Rows(i)("idbarang") & "',"
                c = c & "'" & tbl.Rows(i)("kdbarang") & "','" & tbl.Rows(i)("barang") & "','" & tbl.Rows(i)("keterangan") & "',"
                c = c & "'" & tbl.Rows(i)("idsatuan") & "','" & tbl.Rows(i)("type_pengajuan") & "','" & tbl.Rows(i)("jml_barang") & "',"
                c = c & "'" & tbl.Rows(i)("jml_orang") & "','" & tbl.Rows(i)("jml_hari") & "','" & tbl.Rows(i)("harga_estimasi") & "','" & tbl.Rows(i)("sub_total") & "')"
                cmd = New Odbc.OdbcCommand(c, conn)
                cmd.ExecuteNonQuery()
            Next

            np = ListMaju.Items(brs).SubItems(6).Text
            c = ""
            c = c & " insert into trans_pengajuan_lpj ( idpengajuan,nominal_pengajuan,nominal_lpj)"
            c = c & " values ('" & ListMaju.Items(brs).SubItems(10).Text & "','" & np & "','" & np & "')"
            cmd = New Odbc.OdbcCommand(c, conn)
            cmd.ExecuteNonQuery()

            GGVM_conn_close()

            TampilAllLPJ()
            TampilPengajuan()
        ElseIf e.Button.Properties.Caption = "Refresh LPJ" Then
            ListHeaderMaju()
            TampilPengajuan()
            ListHeaderLPJ()
            TampilAllLPJ()
        ElseIf e.Button.Properties.Caption = "Edit" Then
            Dim ada As Boolean
            Dim brs, jmldt As Integer
            Dim f As New FrmEditLPJ
            Dim cmd As New OdbcCommand

            ada = False
            jmldt = 0
            For i = 0 To ListLPJ.Items.Count - 1
                If ListLPJ.Items(i).Checked = True Then
                    ada = True
                    brs = i
                    jmldt = jmldt + 1
                End If
            Next
            If ada = False Then
                MsgBox("Tidak ada data LPJ yang akan di EDIT, Pilih dulu datanya!!...", MsgBoxStyle.Information, "Information")
                ListLPJ.Focus()
                Exit Sub
            End If
            If jmldt > 1 Then
                MsgBox("Hanya 1(satu) data LPJ yg bisa di-EDIT !!...", MsgBoxStyle.Information, "Information")
                ListLPJ.Focus()
                Exit Sub
            End If
            tampilLPJ = ListLPJ.Items(brs).SubItems(12).Text
            f.ShowDialog()
        ElseIf e.Button.Properties.Caption = "Cetak" Then
            Dim f As New FrmCetak
            Dim cmd As New OdbcCommand
            Dim ada As Boolean
            Dim brs, jmldt As Integer
            Dim s, c As String
            Dim tbl As DataTable

            ada = False
            jmldt = 0
            For i = 0 To ListLPJ.Items.Count - 1
                If ListLPJ.Items(i).Checked = True Then
                    ada = True
                    brs = i
                    jmldt = jmldt + 1
                End If
            Next

            If ada = False Then
                MsgBox("Tidak ada data LPJ di Cetak, Pilih dulu datanya!!...", MsgBoxStyle.Information, "Information")
                Exit Sub
            End If

            If jmldt > 1 Then
                MsgBox("Hanya 1(satu) data LPJ yang bisa Cetak !!...", MsgBoxStyle.Information, "Information")
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor
            GGVM_conn()
            s = ""
            s = s & " select y.nopengajuan,y.tanggal,y.subdivisi,y.divisi,y.jnspengajuan,y.ststagih,"
            s = s & " y.nope, y.area, y.propinsi, y.kota, y.sbrdana, y.waktu_berangkat, y.waktu_pulang, y.idpengajuan,y.nominal,"
            s = s & " if (y.nama_bank is null,'',y.nama_bank)as namabank,"
            s = s & " if (y.no_rekening is null,'',y.no_rekening)as norekening,y.nominal_pengajuan,y.selisih,y.keterangan,y.klien"
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
            s = s & " a.nama_bank, a.no_rekening, f.nominal_pengajuan,f.selisih"
            s = s & " from lpj a, jenis_pengajuan b,  subdivisi d, divisi e ,trans_pengajuan_lpj f"
            s = s & "         where a.idjnspengajuan = b.idjnspengajuan"
            If LevelUser = 1 Then
                s = s & "  and a.user_input = '" & userid & "'"
            End If
            's = s & " and a.idtrans_bank is null "
            s = s & " and a.idsubdivisi = d.idsubdivisi "
            s = s & " and d.id_divisi = e.id_divisi "
            s = s & " and d.id_divisi in ('2','17') "
            s = s & " and a.idpengajuan = f.idpengajuan "
            ' s = s & " and a.idjnspengajuan = '1' "
            's = s & " and a.acc_finance is null "
            's = s & " and a.acc_dirkeu is null   "
            s = s & " ) x  LEFT JOIN klien  on x.idklien = klien.id "
            s = s & " LEFT JOIN area  on x.idarea = area.idarea"
            s = s & " LEFT JOIN proyek on x.idpe = proyek.idpe"
            s = s & " left join propinsi on x.idpropinsi = propinsi.idpropinsi"
            s = s & " left join kota on x.idkota = kota.idkota"
            s = s & " ) y"
            s = s & " where y.idpengajuan ='" & ListLPJ.Items(brs).SubItems(12).Text & "'"
            da = New Odbc.OdbcDataAdapter(s, conn)
            ds.Clear()
            tbl = New DataTable
            tbl.Clear()
            da.Fill(tbl)
            c = ""
            c = c & " delete from buffer_cetak_lpj "
            cmd = New Odbc.OdbcCommand(c, conn)
            cmd.ExecuteNonQuery()

            c = ""
            c = c & " insert buffer_cetak_lpj( nopengajuan,tanggal,subdivisi,divisi,jnspengajuan,ststagih,"
            c = c & " nope,area,propinsi,kota,sbrdana,namabank,norekening,waktuberangkat,waktupulang,idpengajuan,nominal,userid,nominal_maju,selisih,keterangan,klien) values"
            c = c & "('" & tbl.Rows(0)("nopengajuan") & "','" & Format(tbl.Rows(0)("tanggal"), "yyyy/MM/dd") & "','" & tbl.Rows(0)("subdivisi") & "','" & tbl.Rows(0)("divisi") & "','" & tbl.Rows(0)("jnspengajuan") & "','" & tbl.Rows(0)("ststagih") & "',"
            c = c & "'" & tbl.Rows(0)("nope") & "','" & tbl.Rows(0)("area") & "','" & tbl.Rows(0)("propinsi") & "','" & tbl.Rows(0)("kota") & "','" & tbl.Rows(0)("sbrdana") & "','" & tbl.Rows(0)("namabank") & "',"
            c = c & "'" & tbl.Rows(0)("norekening") & "','" & Format(tbl.Rows(0)("waktu_berangkat"), "yyyy/MM/dd") & "','" & Format(tbl.Rows(0)("waktu_pulang"), "yyyy/MM/dd") & "','" & tbl.Rows(0)("idpengajuan") & "','" & tbl.Rows(0)("nominal") & "','" & userid & "','" & tbl.Rows(0)("nominal_pengajuan") & "','" & tbl.Rows(0)("selisih") & "','" & tbl.Rows(0)("keterangan") & "','" & tbl.Rows(0)("klien") & "')"
            cmd = New Odbc.OdbcCommand(c, conn)
            cmd.ExecuteNonQuery()

            CetakIdLPJ = ListLPJ.Items(brs).SubItems(12).Text
            ProsesCetak = "lpj"
            GGVM_conn_close()
            Me.Cursor = Cursors.Default
            'f.ShowDialog()
        ElseIf e.Button.Properties.Caption = "Keluar" Then
            Me.Close()
            Exit Sub
        End If
    End Sub
    Private Sub ListLPJ_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListLPJ.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        With Me.ListLPJ

            For Each item As ListViewItem In ListLPJ.SelectedItems
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
                brsMaju = item.Index
            Next

        End With
        TampilKeterangan()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub WindowsUIButtonPanel1_ButtonChecked(sender As Object, e As ButtonEventArgs) Handles WindowsUIButtonPanel1.ButtonChecked
        If e.Button.Properties.Caption = "Username" Then
            Users1 = True
        End If
    End Sub

    Private Sub WindowsUIButtonPanel1_ButtonUnchecked(sender As Object, e As ButtonEventArgs) Handles WindowsUIButtonPanel1.ButtonUnchecked
        If e.Button.Properties.Caption = "Username" Then
            Users1 = False
        End If
    End Sub
End Class
