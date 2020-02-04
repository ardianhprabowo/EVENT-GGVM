Imports System.Data.Odbc
Public Class FrmAccPengajuan
    Dim brs As Integer
    Dim LoadDt As String
	Dim Pbrs As Integer
	Private Sub TampilPengajuan()
        Dim s As String
        Dim i As Integer
        Dim tbl As New DataTable

        ListMaju.Items.Clear()
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
        s = s & " a.nominal, a.idpengajuan, a.idklien,b.pengajuan as jnspengajuan,e.nama as divisi"
        s = s & " from pengajuan a, jenis_pengajuan b,  subdivisi d, divisi e"
        s = s & " where a.idjnspengajuan = b.idjnspengajuan"
        s = s & " and a.idtrans_bank is null"
        s = s & " and a.idsubdivisi = d.idsubdivisi"
        s = s & " and d.id_divisi = e.id_divisi "
        s = s & " and d.id_divisi in ('2','17')"
        s = s & " and a.acc_manager is null ) x "
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
    Private Sub FrmAccPengajuan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
        'Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
        ListHeaderMaju()
        TampilPengajuan()
    End Sub
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
        ListMaju.Columns.Add("ID.PENGAJUAN", 100, HorizontalAlignment.Left)
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
        s = s & "     and a.idpengajuan = '" & ListMaju.Items(brs).SubItems(10).Text & "'"
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
        GridDetail.AlternatingRowsDefaultCellStyle.BackColor = Color.MistyRose
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

    Private Sub BtnACC_Click(sender As Object, e As EventArgs) Handles BtnACC.Click

	End Sub

    Private Sub BtnFilter_Click(sender As Object, e As EventArgs)
        If TIdDivisi.Text <> "" Then
            TampilPengajuan()
        Else
            MsgBox("Pilih dulu Divisi nya !!!.....", MsgBoxStyle.Information, "Information")
            Exit Sub
        End If
    End Sub
    Private Sub LoadDivisi()
        Dim s As String
        Dim tbl As New DataTable

        Plist.FullRowSelect = True
        Plist.MultiSelect = True
        Plist.View = View.Details
        Plist.Columns.Clear()
        PList.Items.Clear()
        Plist.Columns.Add("DIVISI", 200, HorizontalAlignment.Left)
        Plist.Columns.Add("ID DIVISI", 10, HorizontalAlignment.Left)

        GGVM_conn()
        s = " select nama,id_divisi from divisi"
        s = s & " order by nama"
        da = New Odbc.OdbcDataAdapter(s, conn)
        tbl = New DataTable
        tbl.Clear()
        da.Fill(tbl)
        GGVM_conn_close()
        For i = 0 To tbl.Rows.Count - 1
            With PList
                .Items.Add(tbl.Rows(i)("nama"))
                With .Items(.Items.Count - 1).SubItems
                    .Add(tbl.Rows(i)("id_divisi"))
                End With
            End With
        Next
        Plist.Focus()

    End Sub
    Private Sub BtnDivisi_Click(sender As Object, e As EventArgs) Handles BtnDivisi.Click
        LoadDt = "divisi"
        PanelSurvei.Visible = True
        LoadDivisi()
        Plist.Focus()
    End Sub

    Private Sub BtnDivisi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles BtnDivisi.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            LoadDt = "divisi"
            PanelSurvei.Visible = True
            LoadDivisi()
            Plist.Focus()
        End If
    End Sub


    

    Private Sub BtnTutupPanel_Click(sender As Object, e As EventArgs) Handles BtnTutupPanel.Click
        PanelSurvei.Visible = False
    End Sub

    Private Sub ListMaju_TabStopChanged(sender As Object, e As EventArgs) Handles ListMaju.TabStopChanged

    End Sub

    Private Sub Plist_DoubleClick(sender As Object, e As EventArgs) Handles Plist.DoubleClick
        Select Case LoadDt
            Case "divisi"
                TDivisi.Text = Plist.Items(Pbrs).SubItems(0).Text
                TIdDivisi.Text = Plist.Items(Pbrs).SubItems(1).Text
        End Select
        Plist.Clear()
        PanelSurvei.Visible = False
    End Sub

    Private Sub Plist_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Plist.KeyPress
        If e.KeyChar = Convert.ToChar(13) Then
            Select Case LoadDt
                Case "divisi"
                    TDivisi.Text = Plist.Items(Pbrs).SubItems(0).Text
                    TIdDivisi.Text = Plist.Items(Pbrs).SubItems(1).Text
            End Select
            Plist.Clear()
            PanelSurvei.Visible = False
        End If
    End Sub

    Private Sub Plist_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Plist.SelectedIndexChanged
        With Me.Plist
            For Each item As ListViewItem In Plist.SelectedItems
                Pbrs = item.Index
            Next
        End With
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
        s = s & " select if(keterangan is null,'',keterangan)as keterangan from pengajuan where idpengajuan = '" & ListMaju.Items(brs).SubItems(10).Text & "'"
        da = New Odbc.OdbcDataAdapter(s, conn)
        ds.Clear()
        tbl = New DataTable
        tbl.Clear()
        da.Fill(tbl)
        TKeterangan.Text = tbl.Rows(0)("keterangan")
        GGVM_conn_close()
    End Sub

	Private Sub BKeluar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BKeluar.ItemClick
		Me.Close()
		Exit Sub
	End Sub

	Private Sub BAccPengajuan_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BAccPengajuan.ItemClick
		Dim j As Integer
		Dim f As New FrmPengajuan
		Dim c As String
		Dim cmd As New OdbcCommand

		If MsgBox("Anda yakin untuk ACC Pengajuan ?...", MsgBoxStyle.OkCancel, "Question") = MsgBoxResult.Ok Then
			GGVM_conn()
			For j = 0 To ListMaju.Items.Count - 1
				If ListMaju.Items(j).Checked = True Then
					c = ""
					c = c & " update pengajuan set "
					c = c & " time_acc_manager = now(),"
					c = c & " acc_manager = '" & userid & "'"
					c = c & " where idpengajuan='" & ListMaju.Items(j).SubItems(10).Text & "'"
					cmd = New Odbc.OdbcCommand(c, conn)
					cmd.ExecuteNonQuery()
				End If
			Next
			GGVM_conn_close()
			TampilPengajuan()
		End If
	End Sub
End Class