Option Strict Off
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Navigation
Imports System.Data.Odbc

Partial Public Class FrmPEEvn
	Private Panel1Captured As Boolean
	Private Panel1Grabbed As Point
	Dim ProsesDetail, Tampil, HapusProses, urutpe, c, divisiid, bln, thn, InputDetail As String
	Dim idNo, idNo1, peNo As String
	Dim idbrng, count As Integer
	Dim StartBln, StartThn, StartTgl, tglevent, waktuevent As String
	Dim EndBln, EndThn, EndTgl As String
	Dim spasi() As Char = (" ")
	Dim Qoma() As Char = (",")
	Private Unitcost, NilaiPPN, GrandTotal, TotalHargaEvent, totalunit, SbTotal As Double
	Private lvwIndex As Integer

	Public Sub New()
		InitializeComponent()
	End Sub
#Region "ListView"
	Private Sub ListHeaderPE()
		With ListPE
			.FullRowSelect = True
			.MultiSelect = False
			.View = View.Details
			.CheckBoxes = True
			.Columns.Clear()
			.Items.Clear()
			.Columns.Add("NO PE", 140, HorizontalAlignment.Left)
			.Columns.Add("CLIENT.", 200, HorizontalAlignment.Left)
			.Columns.Add("JENIS PE", 100, HorizontalAlignment.Left)
			.Columns.Add("PROJECT", 150, HorizontalAlignment.Left)
			.Columns.Add("VENUE", 150, HorizontalAlignment.Left)
			.Columns.Add("TANGGAL EVENT", 110, HorizontalAlignment.Left)
			.Columns.Add("GrandTotal", 150, HorizontalAlignment.Left)
			.Columns.Add("Approved By", 140, HorizontalAlignment.Left)
			.Columns.Add("TANGGAL PE", 100, HorizontalAlignment.Left)
			.Columns.Add("idpe", 1, HorizontalAlignment.Left)
		End With
	End Sub
	Private Sub BacaPE()
		GGVM_conn()
		sql = ""
		sql = sql & "SELECT a.nope,b.nama,c.jenis_pe, a.project,a.venue,a.peserta, a.tgl_event,a.tgl_pe, a.waktu_event,a.total,a.rp_ppn,a.grandtotal,a.approved_by,a.jabatan, a.idpe "
		sql = sql & "FROM `evn_penawaran`a , klien b , evn_jenis_pe c where a.idklien = b.id And a.idjenis_pe = c.idjenis_pe  "
		If DivUser = "2" Then
			sql = sql & "and a.deal is Null and c.idjenis_pe = '" & TidJenisPE.Text & "'"
		ElseIf DivUser = "17" Then
			sql = sql & "and a.deal is Null and c.idjenis_pe = '" & TidJenisPE.Text & "'"
		ElseIf DivUser = "0" Then
			sql = sql & "and a.deal is Null and c.idjenis_pe in (1,2,3,4)"
		Else
			Return
		End If
		da = New OdbcDataAdapter(sql, conn)
		ds = New DataSet
		da.Fill(ds)
		dt = New DataTable
		dt = ds.Tables(0)
		ListPE.Items.Clear()
		ListPE.BeginUpdate()
		For j As Integer = 0 To dt.Rows.Count - 1
			With ListPE
				.Items.Add(dt.Rows(j)("nope"))
				With .Items(.Items.Count - 1).SubItems
					.Add(dt.Rows(j)("nama"))
					.Add(dt.Rows(j)("jenis_pe"))
					.Add(dt.Rows(j)("project"))
					.Add(dt.Rows(j)("venue"))
					.Add(dt.Rows(j)("tgl_event"))
					If dt.Rows(j)("grandtotal") Is DBNull.Value Then
						.Add("Belum Ada Barang")
					Else
						.Add(dt.Rows(j)("grandtotal"))
					End If

					If dt.Rows(j)("approved_by") Is DBNull.Value Then
						.Add("Belum Deal")
					Else
						.Add(dt.Rows(j)("approved_by"))
					End If
					.Add(dt.Rows(j)("tgl_pe"))
					.Add(dt.Rows(j)("idpe"))
				End With
			End With
		Next
		ListPE.EndUpdate()
		GGVM_conn_close()
	End Sub
	Private Sub ListTampilDetail()
		With TampilDetail
			.FullRowSelect = True
			.MultiSelect = False
			.View = View.Details
			.CheckBoxes = True
			.Columns.Clear()
			.Items.Clear()
			.Columns.Add("Barang", 230, HorizontalAlignment.Left)
			.Columns.Add("Item", 80, HorizontalAlignment.Left)
			.Columns.Add("No Material", 90, HorizontalAlignment.Left)
			.Columns.Add("Qty", 40, HorizontalAlignment.Left)
			.Columns.Add("Satuan", 50, HorizontalAlignment.Left)
			.Columns.Add("Freq", 40, HorizontalAlignment.Left)
			.Columns.Add("Satuan", 50, HorizontalAlignment.Left)
			.Columns.Add("Day", 40, HorizontalAlignment.Left)
			.Columns.Add("Satuan", 50, HorizontalAlignment.Left)
			.Columns.Add("Dimensi", 60, HorizontalAlignment.Left)
			.Columns.Add("Material", 100, HorizontalAlignment.Left)
			.Columns.Add("Total Unit", 70, HorizontalAlignment.Left)
			.Columns.Add("Harga Unit", 120, HorizontalAlignment.Left)
			.Columns.Add("Sub Total Cost", 120, HorizontalAlignment.Left)
			.Columns.Add("Remaks", 150, HorizontalAlignment.Left)
			.Columns.Add("iddetail", 1, HorizontalAlignment.Left)
		End With
	End Sub
	Private Sub BacaDetailPE()
		GGVM_conn()
		sql = ""
		sql = sql & "SELECT a.*,c.subkel FROM evn_detail_penawaran a "
		sql = sql & "Join barang_penawaran b ON b.idbarang = a.idbarang "
		sql = sql & " Join subkelompok c on c.idsubkel = b.idsubkel "
		sql = sql & " where a.idpe = '" & TidPE.Text & "'"
		da = New OdbcDataAdapter(sql, conn)
		ds = New DataSet
		da.Fill(ds)
		dt = New DataTable
		dt = ds.Tables(0)
		TampilDetail.Items.Clear()
		TampilDetail.BeginUpdate()
		For j As Integer = 0 To dt.Rows.Count - 1
			With TampilDetail
				.Items.Add(dt.Rows(j)("barang"))
				With .Items(.Items.Count - 1).SubItems
					.Add(dt.Rows(j)("item").ToString)
					.Add(dt.Rows(j)("material_no").ToString)
					.Add(dt.Rows(j)("qty"))
					.Add(dt.Rows(j)("satuan_qty"))
					.Add(dt.Rows(j)("freq"))
					.Add(dt.Rows(j)("satuan_freq"))
					.Add(dt.Rows(j)("day").ToString)
					.Add(dt.Rows(j)("satuan_day").ToString)
					.Add(dt.Rows(j)("dimensi").ToString)
					.Add(dt.Rows(j)("materials").ToString)
					.Add(dt.Rows(j)("total"))
					.Add(Format(Val(dt.Rows(j)("unitcost")), "Rp, ###,###"))
					.Add(Format(Val(dt.Rows(j)("sub_totalcost")), "Rp, ###,###"))
					.Add(dt.Rows(j)("remaks").ToString)
					.Add(dt.Rows(j)("iddetail"))
				End With
			End With
		Next
		TampilDetail.EndUpdate()
		GGVM_conn_close()
		conn.Dispose()
	End Sub
#End Region
#Region "Auto Complete"
	Private Sub HitungBisnis()
		Dim NominalBisnis As Double = 0
		For I = ListPE.Items.Count - 1 To 0 Step -1
			NominalBisnis = ListPE.Items(I).SubItems(6).Text + NominalBisnis
		Next
		TotalBisnis.Caption = Format(Val(NominalBisnis), "Rp, ###,###")
	End Sub
	Private Sub LoadSatuan()
		GGVM_conn()
		CSQty.Items.Clear()
		CSFreq.Items.Clear()
		CSDay.Items.Clear()

		sql = ""
		sql = sql & "SELECT * from Satuan"
		cmd = New OdbcCommand(sql, conn)
		dr = cmd.ExecuteReader
		Do While dr.Read
			CSQty.Items.Add(dr("satuan"))
			CSFreq.Items.Add(dr("satuan"))
			CSDay.Items.Add(dr("satuan"))
		Loop
		GGVM_conn_close()
	End Sub
	Private Sub AutoCompKlien()
		GGVM_conn()
		sql = "select * from klien"
		da = New OdbcDataAdapter(sql, conn)
		ds = New DataSet
		da.Fill(ds)
		Dim Klien As New AutoCompleteStringCollection
		For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
			Klien.Add(ds.Tables(0).Rows(i)("nama").ToString())
		Next
		With TKlien
			.AutoCompleteSource = AutoCompleteSource.CustomSource
			.AutoCompleteCustomSource = Klien
			.AutoCompleteMode = AutoCompleteMode.Suggest
		End With
		GGVM_conn_close()
	End Sub
	Private Sub AutoCompProject()
		GGVM_conn()
		If DivUser = "0" Then
			sql = "select subdivisi from subdivisi"
		Else
			sql = "select subdivisi from subdivisi where id_divisi = '" & DivUser & "'"
		End If
		da = New OdbcDataAdapter(sql, conn)
		ds = New DataSet
		da.Fill(ds)
		Dim Project As New AutoCompleteStringCollection
		For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
			Project.Add(ds.Tables(0).Rows(i)("subdivisi").ToString())
		Next
		With TProject
			.AutoCompleteSource = AutoCompleteSource.CustomSource
			.AutoCompleteCustomSource = Project
			.AutoCompleteMode = AutoCompleteMode.Suggest
		End With
		GGVM_conn_close()
	End Sub
	Private Sub AutoCompVenue()
		GGVM_conn()
		sql = "select * from kota"
		da = New OdbcDataAdapter(sql, conn)
		ds = New DataSet
		da.Fill(ds)
		Dim Venue As New AutoCompleteStringCollection()
		For i = 0 To ds.Tables(0).Rows.Count - 1
			Venue.Add(ds.Tables(0).Rows(i)("kota").ToString())
		Next
		With TVenue
			.AutoCompleteCustomSource = Venue
			.AutoCompleteMode = AutoCompleteMode.Suggest
			.AutoCompleteSource = AutoCompleteSource.CustomSource
		End With
		GGVM_conn_close()
	End Sub
	Private Sub ComboJenisPE()
		GGVM_conn()
		CJenisPE.Items.Clear()
		If DivUser = "0" Then
			sql = "select * from evn_jenis_pe"
		Else
			sql = "select * from evn_jenis_pe where iddivisi = '" & DivUser & "'"
		End If
		cmd = New OdbcCommand(sql, conn)
		dr = cmd.ExecuteReader
		Do While dr.Read
			CJenisPE.Items.Add(dr("jenis_pe"))
		Loop
		GGVM_conn_close()
	End Sub
	Private Sub AutoBarangExhibition()
		'GGVM_conn()
		sql = ""
		sql = sql & "SELECT a.* FROM barang_penawaran a "
		sql = sql & " JOIN subkelompok b on a.idsubkel = b.idsubkel "
		sql = sql & " JOIN kelompok c on b.idkelompok = c.idkelompok "
		sql = sql & " WHERE c.idkelompok = '18'"
		da = New OdbcDataAdapter(sql, conn)
		ds = New DataSet
		da.Fill(ds)
	End Sub
	Private Sub AutoBarangEvent()
		GGVM_conn()
		If TInfoKontrak.Text <> "" Then
			sql = ""
			sql = sql & "SELECT b.item_no, b.material_no, a.barang from barang_penawaran a"
			sql = sql & " JOIN evn_material b on a.idbarang = b.idbarang  "
			sql = sql & " JOIN evn_kontrak c on c.idkontrak = b.idkontrak "
			sql = sql & " WHERE c.idkontrak = '" & TInfoKontrak.Text & "'"
		Else
			sql = "SELECT barang from barang_penawaran where idsubkel = '71' and idkontrak is nULL"
		End If
		da = New OdbcDataAdapter(sql, conn)
		ds = New DataSet
		da.Fill(ds)
	End Sub
	Private Sub SuperSUBarangPE()
		sql = ""
		sql = sql & "SELECT a.* FROM barang_penawaran a "
		sql = sql & " JOIN subkelompok b on a.idsubkel = b.idsubkel "
		sql = sql & " JOIN kelompok c on b.idkelompok = c.idkelompok "
		sql = sql & " WHERE c.idkelompok in (7,18)"
		da = New OdbcDataAdapter(sql, conn)
		ds = New DataSet
		da.Fill(ds)
	End Sub
	Private Sub CompleteBarangPE()
		GGVM_conn()
		If DivUser = "17" Then
			TDay.Visible = False
			CSDay.Visible = False
			Call AutoBarangExhibition()
		ElseIf DivUser = "2" Then
			Call AutoBarangEvent()
			TMaterials.Visible = False
			TDimensi.Visible = False
		Else
			Call SuperSUBarangPE()
		End If
		Dim brgpen As New AutoCompleteStringCollection
		For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
			brgpen.Add(ds.Tables(0).Rows(i)("barang").ToString())
		Next
		With TCari
			.AutoCompleteSource = AutoCompleteSource.CustomSource
			.AutoCompleteCustomSource = brgpen
			.AutoCompleteMode = AutoCompleteMode.Suggest
		End With
	End Sub
#End Region
#Region "Deklarasi Perintah"
	Sub KondisiTambah()
		TNoPE.Clear()
		TProject.Clear()
		TKlien.Clear()
		TVenue.Clear()
		TPeserta.Clear()
		TTotalEvent.Text = "0"
		RpPPN.Text = "0"
		StartDate.Value = DateTime.Now
		EndDate.Value = DateTime.Now
		TimeStart.Value = DateTime.Now
		TimeEnd.Value = DateTime.Now
		PPN.EditValue = "0"
		TApprov.Clear()
		TJabatan.Clear()
        DTTanggal.Value = DateTime.Now
        TidPE.Clear()
        TidProject.Clear()
        TidKlien.Clear()
        TidVenue.Clear()
        CJenisPE.Enabled = False
        TProject.Enabled = True
        TKlien.Enabled = True
        TVenue.Enabled = True
        TPeserta.Enabled = True
        StartDate.Enabled = True
        EndDate.Enabled = True
        TimeStart.Enabled = True
        TimeEnd.Enabled = True
        PPN.Enabled = True
        TApprov.Enabled = True
        TJabatan.Enabled = True
        DTTanggal.Enabled = True
        BuatPE.Enabled = False
        EditPE.Enabled = False
        ProsesInput.Enabled = True
        CetakTool.Enabled = True
        BatalTool.Enabled = True
        SimpanDetail.Enabled = True
        SelesaiDetail.Enabled = True
    End Sub
    Sub AwalTampil()
        CJenisPE.Enabled = False
        TProject.Enabled = False
        TKlien.Enabled = False
        TVenue.Enabled = False
        TPeserta.Enabled = False
        StartDate.Enabled = False
        EndDate.Enabled = False
        TimeStart.Enabled = False
        TimeEnd.Enabled = False
        PPN.Enabled = False
        TApprov.Enabled = False
        TJabatan.Enabled = False
        DTTanggal.Enabled = False
        BuatPE.Enabled = False
        EditPE.Enabled = False
        CetakTool.Enabled = True
        ProsesInput.Enabled = False
        BatalTool.Enabled = False
    End Sub
    Sub KondisiEdit()
        CJenisPE.Enabled = False
        TProject.Enabled = True
        TKlien.Enabled = True
        TVenue.Enabled = True
        TPeserta.Enabled = True
        StartDate.Enabled = True
        EndDate.Enabled = True
        TimeStart.Enabled = True
        TimeEnd.Enabled = True
        PPN.Enabled = True
        TApprov.Enabled = True
        TJabatan.Enabled = True
        DTTanggal.Enabled = False
        BuatPE.Enabled = False
        EditPE.Enabled = False
        CetakTool.Enabled = True
        ProsesInput.Enabled = True
        BatalTool.Enabled = True
        SelesaiDetail.Enabled = False
    End Sub
    Sub BersihPE()
        TNoPE.Clear()
        TProject.Clear()
        TKlien.Clear()
        TVenue.Clear()
        TPeserta.Clear()
        TTotalEvent.Text = "0"
        RpPPN.Text = "0"
        TotalEvent.EditValue = "0"
        PPN.EditValue = "0"
        TGrandTotal.EditValue = "0"
        StartDate.Value = DateTime.Now
        EndDate.Value = DateTime.Now
        TimeStart.Value = DateTime.Now
        TimeEnd.Value = DateTime.Now
        PPN.EditValue = "0"
        TApprov.Clear()
        TJabatan.Clear()
        DTTanggal.Value = DateTime.Now
        TidPE.Clear()
        TidProject.Clear()
        TidKlien.Clear()
        TidVenue.Clear()
        BuatPE.Enabled = True
        EditPE.Enabled = False
        CetakTool.Enabled = True
        ProsesInput.Enabled = False
        BatalTool.Enabled = False
        SelesaiDetail.Enabled = False
    End Sub
    Sub DetailTambah()
        TambahDetail.Enabled = True
        SimpanDetail.Enabled = True
        HapusDetail.Enabled = True
        TampilDetail.Enabled = True

    End Sub
    Sub DetailTampil()
        TambahDetail.Enabled = False
        SimpanDetail.Enabled = False
        HapusDetail.Enabled = False
        TampilDetail.Enabled = False
        SelesaiDetail.Enabled = True
    End Sub
    Private Sub Data()
        StartTgl = Microsoft.VisualBasic.Left(StartDate.Text, 2)
        StartBln = Microsoft.VisualBasic.Mid(StartDate.Text, 4, 3)
        StartThn = Microsoft.VisualBasic.Right(StartDate.Text, 4)

        EndTgl = Microsoft.VisualBasic.Left(EndDate.Text, 2)
        EndBln = Microsoft.VisualBasic.Mid(EndDate.Text, 4, 3)
        EndThn = Microsoft.VisualBasic.Right(EndDate.Text, 4)

        If StartDate.Text = EndDate.Text Then
            tglevent = EndDate.Text
        ElseIf StartThn = EndThn And StartBln = EndBln Then
            tglevent = StartTgl + "-" + EndTgl + spasi + EndBln + spasi + EndThn
        ElseIf StartThn = EndThn And StartBln <> EndBln Then
            tglevent = StartTgl + spasi + StartBln + "-" + EndTgl + spasi + EndBln + spasi + EndThn
        Else
            tglevent = StartTgl + spasi + StartBln + spasi + StartThn + "-" + EndTgl + spasi + EndBln + spasi + EndThn
        End If

        waktuevent = TimeStart.Text + spasi + "-" + spasi + TimeEnd.Text
    End Sub
    Private Sub ClearOK()
        TCari.Clear()
        TQty.Clear()
        TFreq.Clear()
        TDay.Clear()
        TUnitCost.Clear()
        TTotal.Clear()
        SubTotal.Clear()
        Remaks.Clear()
        TDimensi.Clear()
        TMaterials.Clear()
        iddetail.Text = ""
        idInpBarang.Text = ""
        NoMaterial.Text = ""
        NoItem.Text = ""
        idKontrak.Text = ""
        TCari.Focus()
    End Sub
    Private Sub CekMaterials()
        GGVM_conn()
        sql = ""
        sql = sql & "Select barangmaterial from evn_material_aktual where idbarang_pe = '" & idInpBarang.Text & "'  "
        cmd = New OdbcCommand(sql, conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If Not dr.HasRows Then
            TMaterials.Text = ""
        Else
            TMaterials.Text = dr.Item("barangmaterial")
        End If
    End Sub
    Private Sub CekKontrak()
        GGVM_conn()
        sql = "select * from evn_material where idkontrak = '" & idKontrak.Text & "' and idbarang = '" & idInpBarang.Text & "' "
        da = New OdbcDataAdapter(sql, conn)
        dt = New DataTable
        da.Fill(dt)
        If dt.Rows.Count > 0 Then
            NoMaterial.Text = dt.Rows(0)("material_no").ToString
            NoItem.Text = dt.Rows(0)("item_no").ToString
            TUnitCost.Text = dt.Rows(0)("price").ToString
        Else
            NoMaterial.Text = ""
            NoItem.Text = ""
            TUnitCost.Text = ""
        End If
        GGVM_conn_close()
    End Sub
    Private Sub cariHarga()
        GGVM_conn()
        sql = "select * from barang_penawaran where idbarang ='" & idInpBarang.Text & "' "
        cmd = New OdbcCommand(sql, conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If Not dr.HasRows Then
            TUnitCost.Text = ""
            TDimensi.Text = ""
        Else
            TUnitCost.Text = dr.Item("harga_pe")
            If dr.Item("dimensi") Is DBNull.Value Then
                TDimensi.Text = ""
            Else
                TDimensi.Text = dr.Item("dimensi")
            End If
        End If
    End Sub
    Private Sub CariPE()
        GGVM_conn()
        sql = ""
        sql = sql & "SELECT a.nope,b.nama,c.jenis_pe, a.project,a.venue,a.peserta, a.tgl_event,a.tgl_pe, a.waktu_event,a.total,a.rp_ppn,a.grandtotal,a.approved_by,a.jabatan, a.idpe "
        sql = sql & "FROM `evn_penawaran`a , klien b , evn_jenis_pe c where a.idklien = b.id And a.idjenis_pe = c.idjenis_pe and a.project Like '%" & TCariPE.Text.Replace("'", "''") & "%' or b.nama like '%" & TCariPE.Text.Replace("'", "''") & "%' "
        If DivUser = "2" Then
            sql = sql & "and a.deal = 1 and c.idjenis_pe in (1,2)"
        ElseIf DivUser = "17" Then
            sql = sql & "and a.deal = 1 and c.idjenis_pe in (3,4)"
        Else
            Return
        End If
        sql = sql & "group by a.nope"
        da = New OdbcDataAdapter(sql, conn)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds)
        dt = New DataTable
        dt = ds.Tables(0)

        GGVM_conn_close()
    End Sub
    Private Sub SimpanTotal()
        GGVM_conn()
        sql = ""
        sql = sql & "update evn_penawaran set total = '" & TotalHargaEvent & "',rp_ppn = '" & NilaiPPN & "',grandtotal = '" & GrandTotal & "' where idpe = '" & TidPE.Text & "'"
        cmd = New OdbcCommand(sql, conn)
        cmd.ExecuteNonQuery()
        GGVM_conn()
        conn.Dispose()
    End Sub
    Private Sub NominalPenawaran()
        Dim Nominal As Double
        Dim Pajak As Double
        Dim Semua As Double
        GGVM_conn()
        sql = "SELECT SUM(sub_totalcost) as SubTotal FROM evn_detail_penawaran where idpe = '" & TidPE.Text & "'"
        cmd = New OdbcCommand(sql, conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows = True Then
            If dr.Item("SubTotal") Is DBNull.Value Then
                Nominal = "0"
            Else
                Nominal = Math.Round(Val(dr.Item("SubTotal")), 3)
            End If
        Else
            Nominal = "0"
        End If
        TotalEvent.EditValue = "Rp." & Format(Nominal, "###,###,###")
        TotalHargaEvent = FormatNumber(Nominal, 0, TriState.True)
        Pajak = If(CekAdaPPN.Checked = True, Val(CDbl(Nominal) * 10) / 100, 0)
        PPN.EditValue = "Rp." & Format(Pajak, "###,###,###")
        NilaiPPN = FormatNumber(Pajak, 0, TriState.True)
        Semua = Val(CDbl(Nominal)) + Val(CDbl(Pajak))
        TGrandTotal.EditValue = "Rp." & Format(Semua, "###,###,###")
        GrandTotal = FormatNumber(Semua, 0, TriState.True)
    End Sub
    Private Sub EditCounter()
        GGVM_conn()
        If DivUser = "2" Then
            c = " update counter set nope_event = '" & TCounter.Text & "'"
        ElseIf DivUser = "17" Then
            c = " update counter set nope_exhibition = '" & TCounter.Text & "'"
        ElseIf DivUser = "18" Then
            c = " update counter set nope_activation = '" & TCounter.Text & "'"
        End If
        cmd = New OdbcCommand(c, conn)
        cmd.ExecuteNonQuery()
        GGVM_conn_close()
    End Sub
    Private Sub CounterLoad()
        GGVM_conn()
        If DivUser = "2" Then
            sql = " Select a.nope_event, a.thnpe_event, b.nama , b.id_divisi from counter a, divisi b where b.id_divisi = '" & DivUser & "' "
        ElseIf DivUser = "17" Then
            sql = " Select a.nope_exhibition, a.thnpe_event, b.nama , b.id_divisi from counter a, divisi b where b.id_divisi = '" & DivUser & "' "
        ElseIf DivUser = "18" Then
            sql = " Select a.nope_activation, a.thnpe_event, b.nama , b.id_divisi from counter a, divisi b where b.id_divisi ='" & DivUser & "'"
        End If
        cmd = New OdbcCommand(sql, conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If DivUser = "2" Then
            TCounter.Text = dr.Item("nope_event")
        ElseIf DivUser = "17" Then
            TCounter.Text = dr.Item("nope_exhibition")
        ElseIf DivUser = "18" Then
            TCounter.Text = dr.Item("nope_activation")
        End If
        GGVM_conn_close()
    End Sub
#End Region
    Private Sub FrmPEEvn_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Call ListTampilDetail()
            StartDate.Format = DateTimePickerFormat.Custom
            StartDate.CustomFormat = "dd/MMM/yyyy"
            EndDate.Format = DateTimePickerFormat.Custom
            EndDate.CustomFormat = "dd/MMM/yyyy"
            Call ListHeaderPE()
            Call ComboJenisPE()
            Call AwalTampil()
            Call BersihPE()
            Call DetailTampil()
            Call BacaPE()
            Call CounterLoad()
            Call HitungBisnis()

            If DivUser = "17" Then
                TDay.Visible = False
                CSDay.Visible = False
            ElseIf DivUser = "2" Then
                TMaterials.Visible = False
                TDimensi.Visible = False
            Else
                Return
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub
    Private Sub ListPE_DoubleClick(sender As Object, e As EventArgs) Handles ListPE.DoubleClick
        GGVM_conn()
        Dim StatusBarang As String = ""
        With ListPE
            For Each item As ListViewItem In ListPE.CheckedItems
                If item.Checked Then
                    .CheckedItems.Item(0).Checked = True
                End If
                TidPE.Text = item.SubItems(9).Text
            Next
            Call BacaDetailPE()
            Call AutoCompKlien()
            Call AutoCompProject()
            Call AutoCompVenue()
            Call AwalTampil()
            Call NominalPenawaran()
            Call DetailTampil()
            EditPE.Enabled = True
            BatalTool.Enabled = True
            CetakTool.Enabled = True
            DealPe.Enabled = True
            If StatusBarang = "Belum Ada Barang" Then
                TambahDetail.Enabled = True
                SimpanDetail.Enabled = True
                ProsesDetail = "Tambah"
            Else
                TambahDetail.Enabled = False
                SimpanDetail.Enabled = False
            End If
        End With
    End Sub
    Private Sub TidPE_TextChanged(sender As Object, e As EventArgs) Handles TidPE.TextChanged
        Try
            GGVM_conn()
            sql = "Select a.*,b.nama,c.idjenis_pe from evn_penawaran a , klien b,evn_jenis_pe c where a.idklien = b.id and a.idjenis_pe = c.idjenis_pe and idpe='" & TidPE.Text & "'"
            da = New OdbcDataAdapter(sql, conn)
            dt = New DataTable
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                TNoPE.Text = dt.Rows(0)("nope").ToString()
                TKlien.Text = dt.Rows(0)("nama")
                TidJenisPE.Text = dt.Rows(0)("idjenis_pe").ToString
                TProject.Text = dt.Rows(0)("project")
                TVenue.Text = dt.Rows(0)("venue")
                TPeserta.Text = dt.Rows(0)("peserta")
                StartDate.CustomFormat = "dd/MM/yyyy"
                StartDate.Value = dt.Rows(0)("start_event")
                EndDate.CustomFormat = "dd/MM/yyyy"
                EndDate.Value = dt.Rows(0)("end_event")
                Me.TimeStart.Text = Date.MinValue.Add(dt.Rows(0)("StartTime"))
                Me.TimeEnd.Text = Date.MinValue.Add(dt.Rows(0)("endtime"))
                DTTanggal.CustomFormat = "dd/MM/yyyy"
                DTTanggal.Value = dt.Rows(0)("tgl_pe")
                If dt.Rows(0)("rp_ppn") <> "0" Then
                    CekAdaPPN.Checked = True
                Else
                    CekAdaPPN.Checked = False
                End If
                RpPPN.Text = FormatNumber(dt.Rows(0)("rp_ppn"), 0, , , TriState.True)
                TTotalEvent.Text = FormatNumber(dt.Rows(0)("total"), 0, , , TriState.True)
                TJabatan.Text = dt.Rows(0)("jabatan").ToString
                TApprov.Text = dt.Rows(0)("approved_by").ToString
            Else
                TKlien.Text = ""
                TidJenisPE.Text = ""
                TProject.Text = ""
                TVenue.Text = ""
                TPeserta.Text = ""
                StartDate.Value = DateTime.Now
                EndDate.Value = DateTime.Now
                TimeStart.Value = DateTime.Now
                TimeEnd.Value = DateTime.Now
                DTTanggal.Value = DateTime.Now
                RpPPN.Text = ""
                TTotalEvent.Text = ""
                TJabatan.Text = ""
                TApprov.Text = ""
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
        GGVM_conn_close()
    End Sub
    Private Sub TidJenisPE_TextChanged(sender As Object, e As EventArgs) Handles TidJenisPE.TextChanged
        Try
            GGVM_conn()
            sql = "select * from evn_jenis_pe where idjenis_pe= '" & TidJenisPE.Text & "'"
            cmd = New OdbcCommand(sql, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If Not dr.HasRows Then
                CJenisPE.Text = ""
            Else
                CJenisPE.Text = dr.Item("jenis_pe")
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
        GGVM_conn_close()
    End Sub
    Private Sub CJenisPE_TextChanged(sender As Object, e As EventArgs) Handles CJenisPE.TextChanged
        Try
            GGVM_conn()
            sql = "select * from evn_jenis_pe where jenis_pe= '" & CJenisPE.Text & "'"
            cmd = New OdbcCommand(sql, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If Not dr.HasRows Then
                TidJenisPE.Text = ""
            Else
                TidJenisPE.Text = dr.Item("idjenis_pe")
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
        GGVM_conn_close()
    End Sub
    Private Sub TProject_TextChanged(sender As Object, e As EventArgs) Handles TProject.TextChanged
        Try
            GGVM_conn()
            sql = "select * from subdivisi where subdivisi= '" & TProject.Text & "'"
            cmd = New OdbcCommand(sql, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If Not dr.HasRows Then
                TidProject.Text = ""
            Else
                TidProject.Text = dr.Item("idsubdivisi")
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
        GGVM_conn_close()
    End Sub
    Private Sub TidProject_TextChanged(sender As Object, e As EventArgs) Handles TidProject.TextChanged
        Try
            GGVM_conn()
            sql = "select * from subdivisi where idsubdivisi= '" & TidProject.Text & "'"
            cmd = New OdbcCommand(sql, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If Not dr.HasRows Then
                TProject.Text = ""
            Else
                TProject.Text = dr.Item("subdivisi")
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
        GGVM_conn_close()
    End Sub
    Private Sub TKlien_TextChanged(sender As Object, e As EventArgs) Handles TKlien.TextChanged
        Try
            GGVM_conn()
            sql = "Select * from klien where nama= '" & TKlien.Text & "'"
            cmd = New OdbcCommand(sql, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If Not dr.HasRows Then
                TidKlien.Text = ""
                TInfoKlien.Text = ""
            Else
                TidKlien.Text = dr.Item("id")
                TInfoKlien.Text = dr.Item("id")
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
        GGVM_conn_close()
    End Sub
    Private Sub TidKlien_TextChanged(sender As Object, e As EventArgs) Handles TidKlien.TextChanged
        Try
            GGVM_conn()
            sql = "Select * from klien where id= '" & TidKlien.Text & "'"
            cmd = New OdbcCommand(sql, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If Not dr.HasRows Then
                TKlien.Text = ""
            Else
                TKlien.Text = dr.Item("nama")
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
        GGVM_conn_close()
    End Sub
    Private Sub TVenue_TextChanged(sender As Object, e As EventArgs) Handles TVenue.TextChanged
        Try
            GGVM_conn()
            sql = "Select * from kota where kota= '" & TVenue.Text & "'"
            cmd = New OdbcCommand(sql, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If Not dr.HasRows Then
                TidVenue.Text = ""
            Else
                TidVenue.Text = dr.Item("idkota")
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
        GGVM_conn_close()
    End Sub
    Private Sub TidVenue_TextChanged(sender As Object, e As EventArgs) Handles TidVenue.TextChanged
        Try
            GGVM_conn()
            sql = "Select * from kota where idkota= '" & TidVenue.Text & "'"
            cmd = New OdbcCommand(sql, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If Not dr.HasRows Then
                TVenue.Text = ""
            Else
                TVenue.Text = dr.Item("kota")
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
        GGVM_conn_close()
    End Sub
    Private Sub TCariPE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TCariPE.KeyPress
        If TCariPE.Text <> "" Then
            Call CariPE()
            ListPE.Items.Clear()
            ListPE.BeginUpdate()
            For j As Integer = 0 To dt.Rows.Count - 1
                With ListPE
                    .Items.Add(dt.Rows(j)("nope"))
                    With .Items(.Items.Count - 1).SubItems
                        .Add(dt.Rows(j)("nama"))
                        .Add(dt.Rows(j)("jenis_pe"))
                        .Add(dt.Rows(j)("project"))
                        .Add(dt.Rows(j)("venue"))
                        .Add(dt.Rows(j)("tgl_event"))
                        If dt.Rows(j)("grandtotal") Is DBNull.Value Then
                            .Add("Belum Ada Barang")
                        Else
                            .Add(Format(Val(dt.Rows(j)("grandtotal")), "Rp, ###,###"))
                        End If

                        If dt.Rows(j)("approved_by") Is DBNull.Value Then
                            .Add("Belum Deal")
                        Else
                            .Add(dt.Rows(j)("approved_by"))
                        End If
                        .Add(dt.Rows(j)("tgl_pe"))
                        .Add(dt.Rows(j)("idpe"))
                    End With
                End With
            Next
            ListPE.EndUpdate()
        Else
            ListPE.Items.Clear()
            Call BacaPE()
        End If
    End Sub
    Private Sub TCari_TextChanged(sender As Object, e As EventArgs) Handles TCari.TextChanged
        Try
            GGVM_conn()
            sql = ""
            sql = sql & "SELECT a.idbarang,a.idkontrak,a.harga_pe, b.subkel FROM barang_penawaran a"
            sql = sql & " JOIN subkelompok b on a.idsubkel = b.idsubkel  "
            sql = sql & " JOIN kelompok c on c.idkelompok = b.idkelompok "
            sql = sql & " where c.idkelompok in (7,18) and a.barang ='" & TCari.Text & "' "
            cmd = New OdbcCommand(sql, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If Not dr.HasRows Then
                idInpBarang.Text = ""
                idKontrak.Text = ""
            Else
                idInpBarang.Text = dr.Item("idbarang")
                If dr.Item("idkontrak") Is DBNull.Value Then
                    idKontrak.Text = ""
                Else
                    idKontrak.Text = dr.Item("idkontrak")
                End If
                Call CekMaterials()
                Call cariHarga()
                If TInfoKontrak.Text <> "" Then
                    Call CekKontrak()
                End If

            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
        GGVM_conn_close()
        dr.Close()
    End Sub
    Private Sub TCari_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TCari.KeyPress
        If e.KeyChar = Chr(13) Then
            TQty.Focus()
        End If
    End Sub
    Private Sub TInfoKlien_TextChanged(sender As Object, e As EventArgs) Handles TInfoKlien.TextChanged
        GGVM_conn()
        sql = ""
        sql = sql & "SELECT a.idkontrak,a.valuecontract, b.nama FROM evn_kontrak a "
        sql = sql & " JOIN klien b on a.idklien= b.id "
        sql = sql & " WHERE periode = YEAR(CURDATE()) AND a.idklien = '" & TInfoKlien.Text & "'"
        cmd = New OdbcCommand(sql, conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If Not dr.HasRows Then
            CKontrak.EditValue = ""
        Else
            CKontrak.EditValue = dr.Item("valuecontract")
        End If
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles BtnOK.Click
        Dim c As String
        Dim ratecard_gg As Double = 0
        Dim fee_barang As Double = 0
        Dim pph23_barang As Double = 0
        GGVM_conn()
        If TCari.Text = "" Or idInpBarang.Text = "" Or TQty.Text = "" Or TFreq.Text = "" Or TUnitCost.Text = "" Or CSQty.Text = "" Or CSFreq.Text = "" Then
            MsgBox("Data Tidak Lengkap", MsgBoxStyle.Exclamation)
            Exit Sub
        Else
            ratecard_gg = Math.Round(Val(CDbl(TUnitCost.Text) * 0.98) / 1.1)
            fee_barang = Math.Round(Val(CDbl(TUnitCost.Text) * 1.1) - Val(CDbl(ratecard_gg)))
            pph23_barang = Math.Round(Val(CDbl(TUnitCost.Text))) - Math.Round(Val(CDbl(ratecard_gg) * 1.1))
            If BtnOK.Text = "Input" Then
                sql = ""
                sql = sql & "insert into evn_detail_penawaran (idpe, "
                If idKontrak.Text <> "" Then
                    sql = sql & "item, material_no, "
                End If
                sql = sql & "idbarang, barang, qty, satuan_qty, freq, satuan_freq,"
                If DivUser = "2" Then
                    sql = sql & "Day, satuan_day,"
                End If
                sql = sql & "total, Unitcost, "
                If Remaks.Text <> "" Then
                    sql = sql & "remaks, "
                End If
                If DivUser = "17" Then
                    sql = sql & "dimensi,materials,"
                End If
                sql = sql & " sub_totalcost,ratecard_gg,fee,pph23)"
                sql = sql & "values ('" & TidPE.Text & "',"
                If idKontrak.Text <> "" Then
                    sql = sql & "'" & NoItem.Text & "','" & NoMaterial.Text & "',"
                End If
                sql = sql & "'" & idInpBarang.Text & "','" & TCari.Text & "','" & TQty.Text & "','" & CSQty.Text & "','" & TFreq.Text & "','" & CSFreq.Text & "',"
                If DivUser = "2" Then
                    sql = sql & "'" & TDay.Text & "','" & CSDay.Text & "',"
                End If
                sql = sql & "'" & totalunit & "','" & Unitcost & "',"
                If Remaks.Text <> "" Then
                    sql = sql & "'" & Remaks.Text & "',"
                End If
                If DivUser = "17" Then
                    sql = sql & "'" & TDimensi.Text & "','" & TMaterials.Text & "',"
                End If
                sql = sql & "'" & SbTotal & "','" & ratecard_gg & "','" & fee_barang & "','" & pph23_barang & "')"
                cmd = New OdbcCommand(sql, conn)
                cmd.ExecuteNonQuery()

                Call NominalPenawaran()
                c = "update evn_penawaran set total = '" & TotalHargaEvent & "' , rp_ppn='" & NilaiPPN & "',grandtotal ='" & GrandTotal & "' where idpe = '" & TidPE.Text & "'"
                cmd = New OdbcCommand(c, conn)
                cmd.ExecuteNonQuery()

                ClearOK()
                Call BacaDetailPE()
                Call CompleteBarangPE()
                GGVM_conn_close()
            ElseIf BtnOK.Text = "Tambah" Then
                sql = ""
                sql = sql & "insert into evn_detail_penawaran (idpe, "
                If idKontrak.Text <> "" Then
                    sql = sql & "item, material_no, "
                End If
                sql = sql & "idbarang, barang, qty, satuan_qty, freq, satuan_freq,"
                If DivUser = "2" Then
                    sql = sql & "Day, satuan_day,"
                End If
                sql = sql & "total, Unitcost, "
                If Remaks.Text <> "" Then
                    sql = sql & "remaks, "
                End If
                If DivUser = "17" Then
                    sql = sql & "dimensi,materials,"
                End If
                sql = sql & " sub_totalcost,ratecard_gg,fee,pph23)"
                sql = sql & "values ('" & TidPE.Text & "',"
                If idKontrak.Text <> "" Then
                    sql = sql & "'" & NoItem.Text & "','" & NoMaterial.Text & "',"
                End If
                sql = sql & "'" & idInpBarang.Text & "','" & TCari.Text & "','" & TQty.Text & "','" & CSQty.Text & "','" & TFreq.Text & "','" & CSFreq.Text & "',"
                If DivUser = "2" Then
                    sql = sql & "'" & TDay.Text & "','" & CSDay.Text & "',"
                End If
                sql = sql & "'" & totalunit & "','" & Unitcost & "',"
                If Remaks.Text <> "" Then
                    sql = sql & "'" & Remaks.Text & "',"
                End If
                If DivUser = "17" Then
                    sql = sql & "'" & TDimensi.Text & "','" & TMaterials.Text & "',"
                End If
                sql = sql & "'" & SbTotal & "','" & ratecard_gg & "','" & fee_barang & "','" & pph23_barang & "')"
                cmd = New OdbcCommand(sql, conn)
                cmd.ExecuteNonQuery()

                c = ""
                c = c & "select max(iddetail) as id from evn_detail_penawaran where idpe = '" & TidPE.Text & "'"
                cmd = New OdbcCommand(c, conn)
                dr = cmd.ExecuteReader
                Try
                    With dr
                        .Read()
                        iddetail.Text = .GetValue(0).ToString
                    End With
                    dr.Close()
                Catch ex As Exception
                    MsgBox("Terjadi Kesalahan !" & ex.Message)
                End Try

                sql = ""
                sql = sql & "insert into evn_tmp_dp select * from evn_detail_penawaran"
                sql = sql & " where iddetail =  '" & iddetail.Text & "'"
                cmd = New OdbcCommand(sql, conn)
                cmd.ExecuteNonQuery()

                Call NominalPenawaran()
                c = "update evn_penawaran set total = '" & TotalHargaEvent & "' , rp_ppn='" & NilaiPPN & "',grandtotal ='" & GrandTotal & "' where idpe = '" & TidPE.Text & "'"
                cmd = New OdbcCommand(c, conn)
                cmd.ExecuteNonQuery()

                ClearOK()
                Call BacaDetailPE()
                Call CompleteBarangPE()
                GGVM_conn_close()
            ElseIf BtnOK.Text = "Edit" Then
                sql = ""
                sql = sql & "update evn_detail_penawaran set idpe ='" & TidPE.Text & "',"
                sql = sql & "item = '" & NoItem.Text & "', material_no='" & NoMaterial.Text & "', "
                sql = sql & "idbarang='" & idInpBarang.Text & "', barang='" & TCari.Text & "',"
                sql = sql & "qty='" & TQty.Text & "', satuan_qty='" & CSQty.Text & "', freq='" & TFreq.Text & "', satuan_freq='" & CSFreq.Text & "',"
                If DivUser = "2" Then
                    sql = sql & "Day='" & TDay.Text & "', satuan_day='" & CSDay.Text & "',"
                End If
                sql = sql & "total='" & totalunit & "', Unitcost='" & Unitcost & "', "
                If Remaks.Text <> "" Then
                    sql = sql & "remaks='" & Remaks.Text & "', "
                End If
                If DivUser = "17" Then
                    sql = sql & "dimensi='" & TDimensi.Text & "',materials='" & TMaterials.Text & "',"
                End If
                sql = sql & " sub_totalcost='" & SbTotal & "',ratecard_gg='" & ratecard_gg & "',fee='" & fee_barang & "',pph23='" & pph23_barang & "'"
                sql = sql & " where iddetail = '" & iddetail.Text & "'"
                cmd = New OdbcCommand(sql, conn)
                cmd.ExecuteNonQuery()

                c = ""
                c = c & "select max(iddetail) as id from evn_detail_penawaran where idpe = '" & TidPE.Text & "'"
                cmd = New OdbcCommand(c, conn)
                dr = cmd.ExecuteReader
                Try
                    With dr
                        .Read()
                        iddetail.Text = .GetValue(0).ToString
                    End With
                    dr.Close()
                Catch ex As Exception
                    MsgBox("Terjadi Kesalahan !" & ex.Message)
                End Try

                sql = ""
                sql = sql & "insert into evn_tmp_dp select * from evn_detail_penawaran"
                sql = sql & " where iddetail =  '" & iddetail.Text & "'"
                cmd = New OdbcCommand(sql, conn)
                cmd.ExecuteNonQuery()

                Call NominalPenawaran()
                c = "update evn_penawaran set total = '" & TotalHargaEvent & "' , rp_ppn='" & NilaiPPN & "',grandtotal ='" & GrandTotal & "' where idpe = '" & TidPE.Text & "'"
                cmd = New OdbcCommand(c, conn)
                cmd.ExecuteNonQuery()

                ClearOK()
                Call BacaDetailPE()
                Call CompleteBarangPE()
                GGVM_conn_close()
            Else
                Return
            End If
            GGVM_conn_close()
        End If
    End Sub
    Private Sub BtnTutup_Click(sender As Object, e As EventArgs) Handles BtnTutup.Click
        PInput.Visible = False
        ClearOK()
    End Sub
    'Ribbon Detail PE
    Private Sub SelesaiDetail_ItemClick(sender As Object, e As EventArgs) Handles SelesaiDetail.ItemClick
        Try
            TambahDetail.Enabled = False
            SimpanDetail.Enabled = False
            HapusDetail.Enabled = False
            TampilDetail.Enabled = False
        Catch ex As Exception
            MsgBox("Terjadi Kesalahan!" & ex.Message)
        End Try
    End Sub
    Private Sub SimpanDetail_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SimpanDetail.ItemClick
        Select Case ProsesDetail
            Case "Tambah"
                Try
                    Call SimpanTotal()
                    TambahDetail.Enabled = False
                    TampilDetail.Items.Clear()
                    Call BersihPE()
                    Call BacaPE()
                    ListPE.Enabled = True
                    MsgBox("Data Telah diTambahkan", MsgBoxStyle.MsgBoxRight)
                Catch ex As Exception
                    conn.Close()
                    MsgBox("Data Gagal", MsgBoxStyle.Critical, "Message !!")
                End Try

            Case "Revisi"
                If MsgBox("Apakah data ingin di Revisi??", MsgBoxStyle.Information Or MsgBoxStyle.YesNo, "Pemberitahuan !!") = MsgBoxResult.Yes Then
                    Try
                        PanelAlasan.Visible = False
                        MsgBox("Masukkan Alasan Revisi.", MsgBoxStyle.Exclamation)
                        PanelAlasan.Visible = True
                        TARevisi.Focus()
                    Catch ex As Exception
                        conn.Close()
                        MsgBox("Data Gagal", MsgBoxStyle.Critical, "Message !!")
                    End Try
                End If
        End Select
    End Sub
    Private Sub TambahDetail_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles TambahDetail.ItemClick
        If DivUser = "17" Then
            TDay.Visible = False
            CSDay.Visible = False
        ElseIf DivUser = "2" Then
            TMaterials.Visible = False
            TDimensi.Visible = False
        Else
            Return
        End If
        If EditPE.Enabled = True Then
            BtnOK.Text = "Input"
        Else
            BtnOK.Text = "Tambah"
        End If
        PInput.Visible = True

        Call CompleteBarangPE()
        Call LoadSatuan()
        TCari.Select()
    End Sub
    'End Ribbon Detail PE
    'Ribbon Penawaran
    Private Sub BuatPE_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BuatPE.ItemClick
        Try
            Call KondisiTambah()
            Call DetailTambah()
            Call AutoCompKlien()
            Call AutoCompProject()
            Call AutoCompVenue()
            Call ComboJenisPE()
            ListPE.Enabled = False
            SelesaiDetail.Enabled = True
            TampilDetail.Items.Clear()
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub
    Private Sub EditPE_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles EditPE.ItemClick
        Try
            If TidPE.Text = "" Then
                MsgBox("Tidak ada data yang akan di revisi, Pilih dulu datanya!!...", MsgBoxStyle.Information, "Information")
                ListPE.Focus()
                Exit Sub
            Else
                TKlien.Focus()
                BtnOK.Text = "Tambah"
            End If

            Call KondisiEdit()
            Call DetailTambah()
            ProsesInput.Enabled = False
            ProsesDetail = "Revisi"
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub
    Private Sub ProsesInput_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ProsesInput.ItemClick
        GGVM_conn()
        If Me.CJenisPE.Text = "" Then
            MsgBox("Pilih jenis PE !", MsgBoxStyle.Critical, "Message !!")
            Exit Sub
        ElseIf TKlien.Text = "" Then
            MsgBox("Pilih Nama Klien!", MsgBoxStyle.Critical, "Message !!")
            Exit Sub
        ElseIf TProject.Text = "" Then
            MsgBox("Masukkan Project !", MsgBoxStyle.Critical, "Message !!")
            Exit Sub
        Else
            Call Data()
            sql = "select * from evn_penawaran where nope = '" & TNoPE.Text & "'"
            cmd = New OdbcCommand(sql, conn)
			dr = cmd.ExecuteReader
			dr.Read()
			If Not dr.HasRows = True Then
				If MsgBox("Apakah data ingin disimpan??", MsgBoxStyle.Information Or MsgBoxStyle.YesNo, "Pemberitahuan !!") = MsgBoxResult.Yes Then
					Try
						If DivUser = "2" Then
							sql = " Select a.nope_event, a.thnpe_event, b.nama , b.id_divisi from counter a, divisi b where b.id_divisi = '" & DivUser & "' "
						ElseIf DivUser = "17" Then
							sql = " Select a.nope_exhibition, a.thnpe_event, b.nama , b.id_divisi from counter a, divisi b where b.id_divisi = '" & DivUser & "' "
						ElseIf DivUser = "18" Then
							sql = " Select a.nope_activation, a.thnpe_event, b.nama , b.id_divisi from counter a, divisi b where b.id_divisi ='" & DivUser & "'"
						End If
						cmd = New OdbcCommand(sql, conn)
						dr = cmd.ExecuteReader
						dr.Read()
						thn = Microsoft.VisualBasic.Right(DTTanggal.Text, 4)
						If thn = dr.GetString(1) Then
							If DivUser = "2" Then
								count = dr.Item("nope_event")
							ElseIf DivUser = "17" Then
								count = dr.Item("nope_exhibition")
							ElseIf DivUser = "18" Then
								count = dr.Item("nope_activation")
							End If
						Else
							count = 0
						End If
						count = count + 1
						divisiid = dr.GetString(3)
						If divisiid = "17" Then
							divisiid = "4"
						End If
						divisiid = Microsoft.VisualBasic.Right("0" & divisiid, 2)
						urutpe = Microsoft.VisualBasic.Right("0000" & count, 4)

						bln = bulan(DTTanggal.Text)
						thn = Microsoft.VisualBasic.Right(DTTanggal.Text, 4)
						urutpe = urutpe + "/GGVM-" + divisiid + "/" + bln + "/" + thn

						c = ""
						If count = 1 Then
							If DivUser = "2" Then
								c = c & " update counter set nope_event = '" & count & "',"
							ElseIf DivUser = "17" Then
								c = c & " update counter set nope_exhibition = '" & count & "',"
							ElseIf DivUser = "18" Then
								c = c & " update counter set nope_activation = '" & count & "',"
							End If
							c = c & " thnpe_event = '" & Microsoft.VisualBasic.Right(DTTanggal.Text, 4) & "'"
						Else
							c = c & " update counter set nope_event = '" & count & "'"
						End If
						cmd = New Odbc.OdbcCommand(c, conn)
						cmd.ExecuteNonQuery()

						sql = ""
						sql = sql & "insert evn_penawaran (nope,idklien,idjenis_pe,project,venue,tgl_event,"
						sql = sql & "start_event,end_event,waktu_event,starttime,endtime,peserta,tgl_pe,total,rp_ppn, "
						If TApprov.Text <> "" Then
							sql = sql & "approved_by,jabatan,"
						End If
						sql = sql & "userid_input,timeinput,iddivisi,idsubdivisi)"
						sql = sql & "values ('" & urutpe & "','" & TidKlien.Text & "','" & TidJenisPE.Text & "','" & TProject.Text & "','" & TVenue.Text & "',"
						sql = sql & "'" & tglevent & "','" & Format(StartDate.Value, "yyyy/MM/dd") & "','" & Format(EndDate.Value, "yyyy/MM/dd") & "','" & waktuevent & "',"
						sql = sql & "'" & Format(TimeStart.Value, "HH:mm") & "','" & Format(TimeEnd.Value, "HH:mm") & "','" & TPeserta.Text & "','" & Format(DTTanggal.Value, "yyyy/MM/dd") & "','" & TTotalEvent.Text & "','" & RpPPN.Text & "',"
						If TApprov.Text <> "" Then
							sql = sql & "'" & TApprov.Text & "','" & TJabatan.Text & "',"
						End If
						sql = sql & "'" & userid & "',now(),'" & DivUser & "','" & TidProject.Text & "')"
						cmd = New OdbcCommand(sql, conn)
						cmd.ExecuteNonQuery()

						Call BacaPE()
						Call BersihPE()
						MsgBox("Data berhasil di Simpan !!", MsgBoxStyle.Information, "Pemberitahuan !!")
						ProsesDetail = "Tambah"
						c = ""
						c = c & " Select max(idpe)As id from evn_penawaran "
						da = New OdbcDataAdapter(c, conn)
						dt = New DataTable
						da.Fill(dt)
						If dt.Rows.Count > 0 Then
							TidPE.Text = dt.Rows(0)("id")
						End If
						Call AwalTampil()
						BuatPE.Enabled = False
						BatalTool.Enabled = True
					Catch ex As Exception
						conn.Close()
						MsgBox("Data Gagal di Simpan", MsgBoxStyle.Critical, "Message !!")
						Exit Sub
						GGVM_conn_close()
					End Try
					GGVM_conn_close()
				Else
					Return
				End If
			Else
				Return
			End If
		End If
	End Sub
	Private Sub BatalTool_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BatalTool.ItemClick
		Try
			Call AwalTampil()
			Call BersihPE()
			BuatPE.Enabled = True
			ListPE.Enabled = True
			TampilDetail.Items.Clear()
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		End Try
	End Sub
	Private Sub CetakTool_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles CetakTool.ItemClick
		Dim f As New FrmCetak
		Dim ada As Boolean
		Dim jmldt As Integer = 0
		Dim brs As Integer
		'ListPE.BeginUpdate()
		For i = 0 To ListPE.Items.Count - 1
			If ListPE.Items(i).Checked = True Then
				ada = True
				brs = i
				jmldt = jmldt + 1

				If ada = False Then
					MsgBox("Tidak ada data SURAT JALAN yang akan di-CETAK, Pilih dulu datanya!!...", MsgBoxStyle.Information, "Information")
					ListPE.Focus()
					Exit Sub
				ElseIf jmldt > 1 Then
					MsgBox("Hanya 1(satu) data SURAT JALAN yg bisa di-CETAK !!...", MsgBoxStyle.Information, "Information")
					ListPE.Focus()
					Exit Sub
				Else
					For Each item As ListViewItem In ListPE.CheckedItems
						If item.Checked Then
							CetakIdPE = item.SubItems(9).Text
						End If
					Next
					If DivUser = "2" Then
						If TidKlien.Text = "1" Then
							ProsesCetak = "penestle"
						Else
							ProsesCetak = "peAll"
						End If
					ElseIf DivUser = "17" Then
						ProsesCetak = "Exhibition"
					Else
						MsgBox("Gagal Cetak !" & MsgBoxStyle.Critical)
					End If
				End If

			End If
		Next
		f.ShowDialog()
	End Sub
	Private Sub DealPe_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DealPe.ItemClick
		If TidPE.Text = "" Then
			MsgBox("Pilih Dulu Datanya !", MsgBoxStyle.Information)
		Else
			PApproved.Visible = True
			TInputApproved.Focus()
		End If
	End Sub
	Private Sub DeletePE_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DeletePE.ItemClick
		Dim ada As Boolean
		Dim brs, jmldt As Integer
		ada = False
		jmldt = 0
		ListPE.BeginUpdate()
		Dim I As Integer
		For I = ListPE.Items.Count - 1 To 0 Step -1
			If ListPE.Items(I).Checked = True Then
				ada = True
				brs = I
				jmldt = jmldt + 1
				For Each item As ListViewItem In ListPE.CheckedItems
					GGVM_conn()
					sql = " update evn_penawaran set userid_delete= '" & userid & "', timedelete=now() where idpe = '" & item.SubItems(9).Text & "'"
					cmd = New OdbcCommand(sql, conn)
					cmd.ExecuteNonQuery()

					Dim sql1, sql2, sql3 As String
					sql1 = "insert into evn_buffer_penawaran select * from evn_penawaran where idpe = ? "
					cmd = New OdbcCommand
					With cmd
						.CommandText = (sql1)
						.Parameters.Add("@idpe", OdbcType.BigInt).Value = Convert.ToInt32(item.SubItems(9).Text)
						.Connection = conn
					End With
					dr = cmd.ExecuteReader
					Console.WriteLine(cmd.CommandText.ToString)
					While dr.Read
						Console.WriteLine(dr(0))
						Console.WriteLine()
					End While
					Console.ReadLine()
					'conn.Close()
					'dr = Nothing
					'cmd = Nothing

					sql3 = "insert into evn_tmp_dp select * from evn_detail_penawaran where idpe = ? "
					cmd = New OdbcCommand
					With cmd
						.CommandText = (sql3)
						.Parameters.Add("@idpe", OdbcType.BigInt).Value = Convert.ToInt32(item.SubItems(9).Text)
						.Connection = conn
					End With
					dr = cmd.ExecuteReader
					Console.WriteLine(cmd.CommandText.ToString)
					While dr.Read
						Console.WriteLine(dr(0))
						Console.WriteLine()
					End While
					Console.ReadLine()

					sql2 = "DELETE FROM evn_penawaran WHERE idpe = ?"
					cmd = New OdbcCommand
					With cmd
						.CommandText = (sql2)
						.Parameters.Add("@iddetail", OdbcType.BigInt).Value = Convert.ToInt32(item.SubItems(9).Text)
						.Connection = conn
					End With
					dr = cmd.ExecuteReader
					Console.WriteLine(cmd.CommandText.ToString)
					While dr.Read
						Console.WriteLine(dr(0))
						Console.WriteLine()
					End While
					Console.ReadLine()
					conn.Close()
					dr = Nothing
					cmd = Nothing

					MsgBox("Penawaran Berhasil diHapus")
					Call BacaPE()
					Call BersihPE()
				Next
			End If
		Next I
		ListPE.EndUpdate()
	End Sub
	'Deal Group
	Private Sub BDeal_Click(sender As Object, e As EventArgs) Handles BDeal.Click
		Dim result1 As DialogResult = MessageBox.Show("Penawaran ini Sudah Deal?", "Update Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
		If result1 = DialogResult.Yes Then
			GGVM_conn()
			sql = ""
			sql = sql & "update evn_penawaran set approved_by = '" & TInputApproved.Text & "',jabatan ='" & TInputJabatan.Text & "' , deal = '1',"
			sql = sql & " userid_edit = '" & userid & "', timeupdate = now() where idpe = '" & TidPE.Text & "'"
			cmd = New OdbcCommand(sql, conn)
			cmd.ExecuteNonQuery()

			Call BacaPE()
			ListPE.SelectedItems.Clear()
			PApproved.Visible = False
			TInputJabatan.Text = ""
			TInputApproved.Text = ""
		Else
			Return
			PApproved.Visible = False
		End If
	End Sub
	Private Sub TutupDeal_Click(sender As Object, e As EventArgs) Handles TutupDeal.Click
		PApproved.Visible = False
		TInputApproved.Text = ""
		TInputJabatan.Text = ""
	End Sub
	'End Deal
	'End Ribbon Penawaran
	Private Sub PInput_MouseDown(sender As Object, e As MouseEventArgs) Handles PInput.MouseDown
		Panel1Captured = True
		Panel1Grabbed = e.Location
	End Sub
	Private Sub PInput_MouseMove(sender As Object, e As MouseEventArgs) Handles PInput.MouseMove
		If (Panel1Captured) Then PInput.Location = PInput.Location + e.Location - Panel1Grabbed
	End Sub

	Private Sub BtnKeluar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnKeluar.ItemClick
		Me.Close()
	End Sub

	Private Sub PInput_MouseUp(sender As Object, e As MouseEventArgs) Handles PInput.MouseUp
		Panel1Captured = False
	End Sub

	Private Sub HapusDetail_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles HapusDetail.ItemClick
		Dim Nominal As Decimal = 0
		Dim ada As Boolean
		Dim brs, jmldt As Integer
		ada = False
		jmldt = 0
		TampilDetail.BeginUpdate() ' Turn off the ListView
		Dim I As Integer
		For I = TampilDetail.Items.Count - 1 To 0 Step -1
			If TampilDetail.Items(I).Checked = True Then
				ada = True
				brs = I
				jmldt = jmldt + 1
				Nominal = Val(TampilDetail.Items(I).SubItems(12).Text) - Nominal
				For Each item As ListViewItem In TampilDetail.CheckedItems
					GGVM_conn()
					Dim sql1, sql2 As String
					sql1 = "insert into evn_tmp_dp select * from evn_detail_penawaran where iddetail = ? "
					cmd = New OdbcCommand
					With cmd
						.CommandText = (sql1)
						.Parameters.Add("@iddetail", OdbcType.BigInt).Value = Convert.ToInt32(item.SubItems(15).Text)
						.Connection = conn
					End With
					dr = cmd.ExecuteReader
					Console.WriteLine(cmd.CommandText.ToString)
					While dr.Read
						Console.WriteLine(dr(0))
						Console.WriteLine()
					End While
					Console.ReadLine()
					'conn.Close()
					'dr = Nothing
					'cmd = Nothing

					sql2 = "DELETE FROM evn_detail_penawaran WHERE iddetail = ?"
					cmd = New OdbcCommand
					With cmd
						.CommandText = (sql2)
						.Parameters.Add("@iddetail", OdbcType.BigInt).Value = Convert.ToInt32(item.SubItems(15).Text)
						.Connection = conn
					End With
					dr = cmd.ExecuteReader
					Console.WriteLine(cmd.CommandText.ToString)
					While dr.Read
						Console.WriteLine(dr(0))
						Console.WriteLine()
					End While
					Console.ReadLine()
					conn.Close()
					dr = Nothing
					cmd = Nothing

					MsgBox("Barang Berhasil diHapus")
					Call BacaDetailPE()
					Call NominalPenawaran()
				Next
			End If
		Next I
		TampilDetail.EndUpdate()
	End Sub

	Private Sub NavigasiPEEvent_SelectedPageChanged(sender As Object, e As SelectedPageChangedEventArgs) Handles NavigasiPEEvent.SelectedPageChanged
		If NavigasiPEEvent.SelectedPage.Caption = "Detail Barang" Then
			mainRibbonControl.SelectedPage = RibbonDetailPE
		Else
			mainRibbonControl.SelectedPage = RibbonPenawaran
		End If
	End Sub

	Private Sub TQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TQty.KeyPress
		If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ",") And Not Char.IsControl(e.KeyChar) Then
			MessageBox.Show("Hanya Boleh Angka !")
			e.Handled = True
		ElseIf e.KeyChar = Chr(13) Then
			CSQty.Focus()
		Else
			Return
		End If
	End Sub
	Private Sub CSQty_GotFocus(sender As Object, e As EventArgs) Handles CSQty.GotFocus
		CSQty.DroppedDown = True
	End Sub
	Private Sub CSQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CSQty.KeyPress
		If e.KeyChar = Chr(13) Then
			TFreq.Focus()
		End If
	End Sub
	Private Sub TFreq_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TFreq.KeyPress
		If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ",") And Not Char.IsControl(e.KeyChar) Then
			MessageBox.Show("Hanya Boleh Angka !")
			e.Handled = True
		ElseIf e.KeyChar = Chr(13) Then
			CSFreq.Focus()
		Else
			Return
		End If
	End Sub
	Private Sub CSFreq_GotFocus(sender As Object, e As EventArgs) Handles CSFreq.GotFocus
		CSFreq.DroppedDown = True
	End Sub
	Private Sub CSFreq_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CSFreq.KeyPress
		If e.KeyChar = Chr(13) Then
			TDay.Focus()
		End If
	End Sub
	Private Sub TDay_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TDay.KeyPress
		If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ",") And Not Char.IsControl(e.KeyChar) Then
			MessageBox.Show("Hanya Boleh Angka !")
			e.Handled = True
		ElseIf e.KeyChar = Chr(13) Then
			CSDay.Focus()
		Else
			Return
		End If
	End Sub
	Private Sub CSday_GotFocus(sender As Object, e As EventArgs) Handles CSDay.GotFocus
		CSDay.DroppedDown = True
	End Sub
	Private Sub CSday_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CSDay.KeyPress
		If e.KeyChar = Chr(13) Then
			TUnitCost.Focus()
		End If
	End Sub
	Private Sub TUnitCost_GotFocus(sender As Object, e As EventArgs) Handles TUnitCost.GotFocus
		TTotal_TextChanged(sender, e)
		If TDay.Text = "" Then
			TDay.Text = 1
		End If
		Dim dimensi As Double
		Double.TryParse(TDimensi.Text, dimensi)
		If TQty.Text = "" Or TFreq.Text = "" Then
			MsgBox("Lengkapi Data !!", MsgBoxStyle.Information, "Pemberitahuan !!")
			Exit Sub
			CSDay.Select()
		Else
			If DivUser = "17" Then
				TTotal.Text = Val(CDbl(TQty.Text)) * Val(CDbl(TFreq.Text)) * Val(CDbl(dimensi))
			ElseIf DivUser = "2" Then
				TTotal.Text = Val(CDbl(TQty.Text)) * Val(CDbl(TFreq.Text)) * Val(CDbl(TDay.Text))
			End If
			FormatNumber(totalunit, 0, TriState.False)
			totalunit = TTotal.Text
		End If
	End Sub
	Private Sub TUnitCost_TextChanged(sender As Object, e As EventArgs) Handles TUnitCost.TextChanged
		If TUnitCost.Text = "" Or Not IsNumeric(TUnitCost.Text) Then
			Exit Sub
		Else
			Unitcost = Val(CDbl(TUnitCost.Text))
		End If
	End Sub
	Private Sub TUnitCost_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TUnitCost.KeyPress
		If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ",") And Not Char.IsControl(e.KeyChar) Then
			MessageBox.Show("Hanya Boleh Angka !")
			e.Handled = True
		ElseIf e.KeyChar = Chr(13) Then
			Remaks.Focus()
		Else
			Return
		End If
	End Sub
	Private Sub Remaks_GotFocus(sender As Object, e As EventArgs) Handles Remaks.GotFocus

		SubTotal_TextChanged(sender, e)
		SubTotal.Text = Val(totalunit) * Val(Unitcost)
		SbTotal = FormatNumber(SubTotal.Text, 0, TriState.True)

	End Sub
	Private Sub SubTotal_TextChanged(sender As Object, e As EventArgs) Handles SubTotal.TextChanged

	End Sub
	Private Sub TTotal_TextChanged(sender As Object, e As EventArgs) Handles TTotal.TextChanged

	End Sub
	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Call EditCounter()
	End Sub
	'Revisi Group
	Private Sub BSimpanRevisi_Click(sender As Object, e As EventArgs) Handles BSimpanRevisi.Click
		Dim c As String
		If Len(Me.TARevisi.Text) < 10 Or Len(Me.TARevisi.Text) > 150 Then
			MsgBox("Alasan Terlalu Pendek, Minimal 10 Huruf !", MsgBoxStyle.Information, "Information !!")
			Exit Sub
		Else
			GGVM_conn()
			c = ""
			c = c & " update evn_penawaran set "
			c = c & " userid_edit = '" & userid & "',"
			c = c & " timeupdate = now()"
			c = c & " where idpe = '" & TidPE.Text & "'"
			cmd = New Odbc.OdbcCommand(c, conn)
			cmd.ExecuteNonQuery()

			c = ""
			c = c & " insert into evn_revisi_penawaran (idpe,alasan,timerevisi,userrevisi)"
			c = c & "values ('" & TidPE.Text & "',"
			c = c & " '" & TARevisi.Text & "',now(),'" & userid & "')"
			cmd = New Odbc.OdbcCommand(c, conn)
			cmd.ExecuteNonQuery()

			sql = ""
			sql = sql & " select max(revisike) as revisike ,max(idrevisi)as id  from evn_revisi_penawaran where idpe = '" & TidPE.Text & "'"
			da = New Odbc.OdbcDataAdapter(sql, conn)
			dt = New DataTable
			dt.Clear()
			da.Fill(dt)
			Dim count As Integer
			idrevisi.Text = dt.Rows(0)("id")
			If idrevisi.Text = dt.Rows(0)("id") Then
				count = dt.Rows(0)("revisike")
			Else
				count = 0
			End If
			count = count + 1

			c = ""
			c = c & "update evn_revisi_penawaran set revisike ='" & count & "' where idrevisi ='" & idrevisi.Text & "'"
			cmd = New Odbc.OdbcCommand(c, conn)
			cmd.ExecuteNonQuery()

			PanelAlasan.Visible = False
			Call Data()
			sql = ""
			sql = sql & "update evn_penawaran set "
			sql = sql & "idklien ='" & Me.TidKlien.Text & "',idjenis_pe ='" & Me.TidJenisPE.Text & "',"
			sql = sql & "project ='" & Me.TProject.Text & "',venue ='" & Me.TVenue.Text & "',"
			sql = sql & " tgl_event='" & tglevent & "',start_event ='" & Format(StartDate.Value, "yyyy/MM/dd") & "' ,"
			sql = sql & "end_event = '" & Format(EndDate.Value, "yyyy/MM/dd") & "',"
			sql = sql & "waktu_event = '" & waktuevent & "',"
			sql = sql & "starttime = '" & Format(TimeStart.Value, "HH:mm") & "',"
			sql = sql & "endtime = '" & Format(TimeEnd.Value, "HH:mm") & "',"
			sql = sql & "peserta = '" & TPeserta.Text & "' where idpe ='" & TidPE.Text & "' "
			cmd = New OdbcCommand(sql, conn)
			cmd.ExecuteNonQuery()

			c = "select * from evn_tmp_dp where idpe = '" & TidPE.Text & "'"
			cmd = New OdbcCommand(c, conn)
			dr = cmd.ExecuteReader
			dr.Read()
			If dr.HasRows = True Then
				sql = ""
				sql = sql & "INSERT INTO evn_revisi_detail_pe"
				sql = sql & " SELECT b.idrevisi,a.*, b.revisike FROM (SELECT * FROM evn_tmp_dp) a "
				sql = sql & " LEFT JOIN evn_revisi_penawaran b on a.idpe = b.idpe"
				sql = sql & " where b.idpe='" & TidPE.Text & "'"
				cmd = New OdbcCommand(sql, conn)
				cmd.ExecuteNonQuery()
			End If

			sql = ""
			sql = "delete from evn_tmp_dp where idpe ='" & TidPE.Text & "'"
			cmd = New OdbcCommand(sql, conn)
			cmd.ExecuteNonQuery()

			Call SimpanTotal()
			MsgBox("Data berhasil di Perbarui !!", MsgBoxStyle.Information, "Pemberitahuan !!")
			TampilDetail.Items.Clear()
			Call BersihPE()
			Call BacaPE()
			TampilDetail.Enabled = False
			ListPE.Enabled = True
			GGVM_conn_close()
		End If
		If NavigasiPEEvent.SelectedPage.Caption = "Detail Barang" Then
			NavigasiPEEvent.SelectedPage = NavPenawaran
			mainRibbonControl.SelectedPage = RibbonPenawaran
		Else
			mainRibbonControl.SelectedPage = RibbonPenawaran
		End If
	End Sub
	Private Sub TutupRevisi_Click(sender As Object, e As EventArgs) Handles TutupRevisi.Click
		PanelAlasan.Visible = False
		TARevisi.Clear()
		idrevisi.Clear()
	End Sub
	'End Revisi'
	Private Sub iddetail_TextChanged(sender As Object, e As EventArgs) Handles iddetail.TextChanged
		Try
			GGVM_conn()
			sql = "select * from evn_detail_penawaran where iddetail ='" & iddetail.Text & "'"
			cmd = New OdbcCommand(sql, conn)
			dr = cmd.ExecuteReader
			dr.Read()
			If Not dr.HasRows Then
				'TCari.Text = ""
				'	idInpBarang.Text = ""
				'TQty.Text = ""
				'CSQty.Text = ""
				'TFreq.Text = ""
				'CSFreq.Text = ""
				'TDay.Text = ""
				'CSDay.Text = ""
				'TDimensi.Text = ""
				'TMaterials.Text = ""
				'TTotal.Text = ""
				'TUnitCost.Text = ""
				'SubTotal.Text = ""
				'Remaks.Text = ""
				'NoItem.Text = ""
				'NoMaterial.Text = ""
			Else
				'TCari.Text = dr.Item("barang")
				'	idInpBarang.Text = dr.Item("idbarang")
				'TQty.Text = Trim(dr.Item("qty").ToString)
				'CSQty.Text = dr.Item("satuan_qty")
				'TFreq.Text = dr.Item("freq")
				'CSFreq.Text = dr.Item("satuan_freq")
				'NoItem.Text = dr.Item("item")
				'NoMaterial.Text = dr.Item("material_no")
				'TDay.Text = dr.Item("day").ToString
				'CSDay.Text = dr.Item("satuan_day").ToString
				'TDimensi.Text = dr.Item("dimensi").ToString
				'TMaterials.Text = dr.Item("materials").ToString
				'TTotal.Text = dr.Item("total").ToString
				'TUnitCost.Text = dr.Item("unitcost").ToString
				'SubTotal.Text = dr.Item("sub_totalcost").ToString
				'Remaks.Text = dr.Item("remaks").ToString
			End If
		Catch ex As Exception
			MsgBox("Terjadi Kesalahan!." & ex.Message)
		Finally
			GGVM_conn_close()
		End Try
	End Sub
	Private Sub TampilDetail_DoubleClick(sender As Object, e As EventArgs) Handles TampilDetail.DoubleClick
		PInput.Visible = True
		BtnOK.Text = "Edit"
		With Me.TampilDetail
			Dim i As Integer
			For Each item As ListViewItem In TampilDetail.SelectedItems
				i = item.Index
			Next
			Dim innercounter As Integer = 0
			For Each subItem As ListViewItem.ListViewSubItem In TampilDetail.Items(i).SubItems
				Dim myString As String = TampilDetail.Items(i).SubItems(innercounter).Text
				Select Case innercounter
					Case 0
						TCari.Text = myString
					Case 1
						NoItem.Text = myString
					Case 2
						NoMaterial.Text = myString
					Case 3
						TQty.Text = myString
					Case 4
						CSQty.Text = myString
					Case 5
						TFreq.Text = myString
					Case 6
						CSFreq.Text = myString
					Case 7
						TDay.Text = myString
					Case 8
						CSDay.Text = myString
					Case 9
						TDimensi.Text = myString
					Case 10
						TMaterials.Text = myString
					Case 11
						TTotal.Text = myString
					Case 12
						TUnitCost.Text = myString
					Case 13
						SubTotal.Text = myString
					Case 14
						Remaks.Text = myString
					Case 15
						iddetail.Text = myString
				End Select
				innercounter += 1
			Next

		End With
	End Sub

	Private Sub CKontrak_EditValueChanged(sender As Object, e As EventArgs) Handles CKontrak.EditValueChanged
		GGVM_conn()
		sql = ""
		sql = sql & "select * from evn_kontrak where valuecontract = '" & CKontrak.EditValue & "' "
		cmd = New OdbcCommand(sql, conn)
		dr = cmd.ExecuteReader
		dr.Read()
		If Not dr.HasRows Then
			TInfoKontrak.Text = ""
		Else
			TInfoKontrak.Text = dr.Item("idkontrak")
		End If
	End Sub

	Private Sub CekAdaPPN_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles CekAdaPPN.CheckedChanged
		Call NominalPenawaran()
	End Sub
End Class
