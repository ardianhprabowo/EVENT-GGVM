Option Strict Off
Imports System.Data.Odbc
Public Class FrmHistoryLPJ
    Dim brs As Integer

    Private Sub FrmHistoryLPJ_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTTanggal2.Format = DateTimePickerFormat.Custom
        DTTanggal2.CustomFormat = "dd/MM/yyyy"

        DTTanggal1.Format = DateTimePickerFormat.Custom
        DTTanggal1.CustomFormat = "dd/MM/yyyy"
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
        ListMaju.Columns.Add("NO.LPJ", 180, HorizontalAlignment.Left)
        ListMaju.Columns.Add("TANGGAL", 75, HorizontalAlignment.Left)
        ListMaju.Columns.Add("JNS.LPJ", 150, HorizontalAlignment.Left)
        ListMaju.Columns.Add("SUB DIVISI", 100, HorizontalAlignment.Left)
        ListMaju.Columns.Add("USER INPUT", 150, HorizontalAlignment.Left)
        ListMaju.Columns.Add("NOMINAL PENGAJUAN", 150, HorizontalAlignment.Left)
        ListMaju.Columns.Add("NOMINAL LPJ", 150, HorizontalAlignment.Left)
        ListMaju.Columns.Add("SELISIH LPJ", 150, HorizontalAlignment.Left)
        ListMaju.Columns.Add("ACC MANAGER", 150, HorizontalAlignment.Left)
        ListMaju.Columns.Add("ACC FINANCE", 150, HorizontalAlignment.Left)
        ListMaju.Columns.Add("EKSEKUSI", 150, HorizontalAlignment.Left)
        ListMaju.Columns.Add("ID", 10, HorizontalAlignment.Left)
    End Sub

    Private Sub TampilPengajuan()
        Dim s As String
        Dim i As Integer
        Dim tbl As New DataTable

        ListMaju.Items.Clear()
        GGVM_conn()
        s = ""
        s = s & " SELECT y.nopengajuan, date_format(y.tanggal,'%d/%m/%Y')as tanggal,y.pengajuan,y.subdivisi,y.user_input, y.acc_manager,y.acc_finance,y.idtrans_bank as eksekusi,y.id,y.nominal_pengajuan,y.nominal_lpj,y.selisih"
        s = s & " from ("
        s = s & " select d.idpengajuan as  id, a.nopengajuan,a.tanggal,c.pengajuan,b.subdivisi, a.user_input, "
        s = s & " if (d.time_acc_manager is null,'BELUM ACC',d.time_acc_manager)as acc_manager, "
        s = s & " if (d.time_acc_finance is null,'BELUM ACC',d.time_acc_finance)as acc_finance, "
        s = s & " if (d.idtrans_bank is null,'BELUM EKSEKUSI',d.idtrans_bank)as idtrans_bank, "
        s = s & " a.idpengajuan,d.nominal_pengajuan,d.nominal_lpj,d.selisih"
        s = s & " from lpj a, subdivisi b, jenis_pengajuan c , trans_pengajuan_lpj d      "
        s = s & "         where a.idsubdivisi = b.idsubdivisi"
        s = s & " and b.id_divisi='2'"
        s = s & " and a.idjnspengajuan = c.idjnspengajuan "
        s = s & " and a.idpengajuan = d.idpengajuan"
        s = s & " order by d.idpengajuan"
        s = s & " ) y "
        s = s & " where  date_format(y.tanggal,'%d/%m/%Y') between '" & DTTanggal1.Text & "' and '" & DTTanggal2.Text & "'"
        s = s & " order by y.tanggal desc "

        da = New Odbc.OdbcDataAdapter(s, conn)
        ds.Clear()
        tbl = New DataTable
        tbl.Clear()
        da.Fill(tbl)
        If tbl.Rows.Count > 0 Then
            For i = 0 To tbl.Rows.Count - 1
                With ListMaju
                    .Items.Add(tbl.Rows(i)("nopengajuan"))
                    With .Items(.Items.Count - 1).SubItems
                        .Add(tbl.Rows(i)("tanggal"))
                        .Add(tbl.Rows(i)("pengajuan"))
                        .Add(tbl.Rows(i)("subdivisi"))
                        .Add(tbl.Rows(i)("user_input"))
                        .Add(FormatNumber(tbl.Rows(i)("nominal_pengajuan"), 0, , , TriState.True))
                        .Add(FormatNumber(tbl.Rows(i)("nominal_lpj"), 0, , , TriState.True))
                        .Add(FormatNumber(tbl.Rows(i)("selisih"), 0, , , TriState.True))
                        .Add(tbl.Rows(i)("acc_manager"))
                        .Add(tbl.Rows(i)("acc_finance"))
                        .Add(tbl.Rows(i)("eksekusi"))
                        .Add(tbl.Rows(i)("id"))
                    End With
                End With
            Next
        Else
        End If
        GGVM_conn_close()
    End Sub

    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        Me.Close()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        TampilPengajuan()
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
        s = s & " from detail_lpj a, satuan b"
        s = s & " where a.idsatuan = b.idsatuan"
        s = s & "     and a.idpengajuan = '" & ListMaju.Items(brs).SubItems(11).Text & "'"
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
End Class