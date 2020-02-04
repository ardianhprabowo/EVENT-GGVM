Option Strict Off
Imports System.Data.Odbc
Public Class FrmACCLPJ
    Dim brs As Integer

    Private Sub FrmACCLPJ_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListHeaderLPJ()
        TampilAllLPJ()
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
        s = s & " f.nominal_pengajuan, f.selisih "
        s = s & " from lpj a, jenis_pengajuan b,  subdivisi d, divisi e,trans_pengajuan_lpj f"
        s = s & " where a.idjnspengajuan = b.idjnspengajuan"
        s = s & " and f.idtrans_bank is null"
        s = s & " and f.acc_manager is null"
        s = s & " and f.acc_finance is null "
        s = s & " and a.idpengajuan = f.idpengajuan"
        If LevelUser = 1 Then
            s = s & " and a.user_input = '" & Trim(userid) & "'"
        End If
        s = s & " and a.idtrans_bank is not null"
        s = s & " and a.idsubdivisi = d.idsubdivisi"
        s = s & " and d.id_divisi = e.id_divisi"
        s = s & " and d.id_divisi = '2'"
        s = s & "  ) x"
        s = s & "  LEFT JOIN klien"
        s = s & "  on x.idklien = klien.id"
        s = s & "  LEFT JOIN area"
        s = s & "  on x.idarea = area.idarea"
        da = New OdbcDataAdapter(s, conn)
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
        ListLPJ.Columns.Add("NOMINAL LPJ", 150, HorizontalAlignment.Right)
        ListLPJ.Columns.Add("NOMINAL PENGAJUAN", 150, HorizontalAlignment.Right)
        ListLPJ.Columns.Add("SELISIH LPJ", 150, HorizontalAlignment.Right)
        ListLPJ.Columns.Add("STATUS TAGIH", 100, HorizontalAlignment.Left)
        ListLPJ.Columns.Add("WAKTU BERANGKAT", 130, HorizontalAlignment.Left)
        ListLPJ.Columns.Add("WAKTU PULANG", 130, HorizontalAlignment.Left)
        ListLPJ.Columns.Add("ID.PENGAJUAN", 100, HorizontalAlignment.Left)
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

    Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
        Me.Close()
        Exit Sub
    End Sub

    Private Sub ListLPJ_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListLPJ.SelectedIndexChanged
        Me.Cursor = Cursors.WaitCursor
        With Me.ListLPJ

            For Each item As ListViewItem In ListLPJ.SelectedItems
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
        s = s & " select if(keterangan is null,'',keterangan)as keterangan from pengajuan where idpengajuan = '" & ListLPJ.Items(brs).SubItems(12).Text & "'"
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds.Clear()
        tbl = New DataTable
        tbl.Clear()
        da.Fill(tbl)
        TKeterangan.Text = tbl.Rows(0)("keterangan")
        GGVM_conn_close()

    End Sub

    Private Sub BtnACC_Click(sender As Object, e As EventArgs) Handles BtnACC.Click
        Dim j As Integer
        '  Dim f As New FrmMaju
        Dim c As String
        Dim cmd As New OdbcCommand

        If MsgBox("Anda yakin untuk ACC LPJ ?...", MsgBoxStyle.OkCancel, "Question") = MsgBoxResult.Ok Then

            GGVM_conn()
            For j = 0 To ListLPJ.Items.Count - 1
                If ListLPJ.Items(j).Checked = True Then
                    c = ""
                    c = c & " update trans_pengajuan_lpj set "
                    c = c & " time_acc_manager = now(),"
                    c = c & " acc_manager = '" & userid & "'"
                    c = c & " where idpengajuan='" & ListLPJ.Items(j).SubItems(12).Text & "'"
                    cmd = New Odbc.OdbcCommand(c, conn)
                    cmd.ExecuteNonQuery()
                End If
            Next
            GGVM_conn_close()
            TampilAllLPJ()
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click
        ListHeaderLPJ()
        TampilAllLPJ()
    End Sub
End Class