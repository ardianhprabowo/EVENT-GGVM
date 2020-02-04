Option Strict Off
Imports System.Data.Odbc
Imports DevExpress.XtraBars

Public Class FrmHistoryMaju
    Dim brs As Integer
    Private Sub FrmHistoryMaju_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListHeaderMaju()
        TampilPengajuan()
    End Sub

    Private Sub ListHeaderMaju()
        ListMaju.FullRowSelect = True
        ListMaju.MultiSelect = True
        ListMaju.View = View.Details
        'ListMaju.CheckBoxes = True
        ListMaju.Columns.Clear()
        ListMaju.Items.Clear()
        ListMaju.Columns.Add("NO.PENGAJUAN", 150, HorizontalAlignment.Left)
        ListMaju.Columns.Add("TANGGAL", 75, HorizontalAlignment.Left)
        ListMaju.Columns.Add("JNS.PENGAJUAN", 130, HorizontalAlignment.Left)
        ListMaju.Columns.Add("SUB DIVISI", 100, HorizontalAlignment.Left)
        ListMaju.Columns.Add("USER INPUT", 100, HorizontalAlignment.Left)
        ListMaju.Columns.Add("KLIEN", 130, HorizontalAlignment.Left)
        ListMaju.Columns.Add("KOTA", 80, HorizontalAlignment.Left)
        ListMaju.Columns.Add("KETERANGAN", 400, HorizontalAlignment.Left)
        ListMaju.Columns.Add("NOMINAL", 100, HorizontalAlignment.Right)
        ListMaju.Columns.Add("ACC MANAGER", 130, HorizontalAlignment.Left)
        ListMaju.Columns.Add("ACC FINANCE", 130, HorizontalAlignment.Left)
        ListMaju.Columns.Add("ACC DIRKEU", 130, HorizontalAlignment.Left)
        ListMaju.Columns.Add("EKSEKUSI", 130, HorizontalAlignment.Left)
        ListMaju.Columns.Add("ID.PENGAJUAN", 10, HorizontalAlignment.Left)

    End Sub

    Private Sub TampilPengajuan()
        Dim s As String
        Dim i As Integer
        Dim tbl As New DataTable

        ListMaju.Items.Clear()
        GGVM_conn()
        s = ""
        s = s & " select y.nopengajuan, y.tanggal,y.pengajuan,y.subdivisi,y.user_input,"
        s = s & " y.acc_manager,y.acc_dirkeu,y.acc_finance,y.idtrans_bank as eksekusi,y.idpengajuan,y.nominal,y.kota,y.klien,"
        s = s & " if (y.keterangan is null,'',y.keterangan) as keterangan"
        s = s & " from("
        s = s & " select x.*,"
        s = s & " lpj.idpengajuan as idlpj, if (kota.kota is null ,'',kota.kota)as kota, if (klien.nama is null ,'',klien.nama)as klien"
        s = s & " from ("
        s = s & " select a.nopengajuan,a.tanggal,c.pengajuan,b.subdivisi, a.user_input,"
        s = s & " if (a.time_acc_manager is null,'BELUM ACC',a.time_acc_manager)as acc_manager,"
        s = s & " if (a.time_acc_finance is null,'BELUM ACC',a.time_acc_finance)as acc_finance,"
        s = s & " if (a.time_acc_dirkeu is null,'BELUM ACC',a.time_acc_dirkeu)as acc_dirkeu,"
        s = s & " if (a.idtrans_bank is null,'BELUM','SUDAH EKSEKUSI')as idtrans_bank,"
        s = s & " a.idpengajuan,a.nominal,a.keterangan,a.idkota,a.idklien"
        s = s & " from pengajuan a, subdivisi b, jenis_pengajuan c"
        s = s & " where a.idsubdivisi = b.idsubdivisi"
        If LevelUser = 1 Then
            s = s & " and a.user_input = '" & userid & "'"
        End If
        If LevelUser = 0 Then
            s = s & " and b.id_divisi in ('1','5','9','10')"
        End If
        s = s & " and a.idjnspengajuan = c.idjnspengajuan"
        s = s & " order by a.tanggal,a.idpengajuan"
        s = s & " ) x "
        s = s & " left join lpj on x.idpengajuan = lpj.idpengajuan"
        s = s & " left join kota on x.idkota = kota.idkota left join klien on x.idklien = klien.id"
        s = s & " ) y"
        s = s & " where y.idlpj Is null order by y.tanggal desc "
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
                    .Add(tbl.Rows(i)("subdivisi"))
                    .Add(tbl.Rows(i)("user_input"))
                    .Add(tbl.Rows(i)("klien"))
                    .Add(tbl.Rows(i)("kota"))
                    .Add(tbl.Rows(i)("keterangan"))
                    .Add(FormatNumber(tbl.Rows(i)("nominal"), 0, , , TriState.True))
                    .Add(tbl.Rows(i)("acc_manager"))
                    .Add(tbl.Rows(i)("acc_finance"))
                    .Add(tbl.Rows(i)("acc_dirkeu"))
                    .Add(tbl.Rows(i)("eksekusi"))
                    .Add(tbl.Rows(i)("idpengajuan"))
                End With
            End With
        Next
        GGVM_conn_close()
    End Sub

    Private Sub ListMaju_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListMaju.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        With Me.ListMaju

            For Each item As ListViewItem In ListMaju.SelectedItems
                brs = item.Index
            Next

        End With
        TampilDetail()
        Me.Cursor = Cursors.Default
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
        s = s & "     and a.idpengajuan = '" & ListMaju.Items(brs).SubItems(13).Text & "'"
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
        GridDetail.AlternatingRowsDefaultCellStyle.BackColor = Color.CornflowerBlue
    End Sub

    Private Sub BtnKeluar_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnKeluar.ItemClick
        Me.Close()
    End Sub

    Private Sub BtnRefresh_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnRefresh.ItemClick
        TampilPengajuan()
    End Sub
End Class