Imports System.Data.Odbc
Public Class FrmPengajuan
	Dim tgl As Date
	Dim LoadDt As String
	Dim StsItem As String
	Dim Loadbrg As String

	Private Sub TampilPengajuan()
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
		da = New Odbc.OdbcDataAdapter(s, conn)
		ds.Clear()
		tbl = New DataTable
		tbl.Clear()
		da.Fill(tbl)

		TDivisi.Text = tbl.Rows(0)("divisi")
		TidDivisi.Text = tbl.Rows(0)("id_divisi")
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
	Private Sub FrmPengajuan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

		If tampilALLMaju = "0" Then
			BtnProsesMaju.Text = "PROSES ENTRY"
			TidDivisi.Text = "'" & DivUser & "'"
			BtnDivisi.Enabled = True
			TJmlKota.Text = "1"
			PTJmlOrang.Text = "1"
			TJmlKota.Text = "1"
			TJmlOrng.Text = "1"
			BtnDivisi.Focus()
		Else
			TIdPengajuan.Text = tampilALLMaju
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

	Private Sub BtnKeluar_Click(sender As Object, e As EventArgs)
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

		PTCariBrg.Text = ""
		PTCariBrg.Enabled = False
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
		PItem.Visible = True
	End Sub
	'Private Sub LoadDivisi()
	'    Dim s As String

	'    GGVM_conn()
	'    s = " select nama,id_divisi from divisi"
	'    s = s & " order by nama"
	'    'da = Nothing
	'    da = New Odbc.OdbcDataAdapter(s, conn)
	'    ds = New DataSet
	'    ds.Clear()
	'    da.Fill(ds, "divisi")

	'    GridPanel.DataSource = ds.Tables("divisi")
	'    GridPanel.Refresh()
	'    GridPanel.Columns(0).Width = 500
	'    GridPanel.Columns(1).Width = 50
	'    GGVM_conn_close()
	'End Sub


	Private Sub LoadSubDivisi()
		Dim s As String

		GGVM_conn()
		s = ""
		s = s & "select subdivisi,idsubdivisi from subdivisi "
		s = s & " where id_divisi = '" & TidDivisi.Text & "'"
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
		GridPanel.ReadOnly = True
		GGVM_conn_close()
	End Sub
	Private Sub LoadDivisi()
		Dim s As String

		GGVM_conn()
		s = " select nama,id_divisi from divisi"
		s = s & " order by nama"
		'da = Nothing
		da = New Odbc.OdbcDataAdapter(s, conn)
		ds = New DataSet
		ds.Clear()
		da.Fill(ds, "nama")

		GridPanel.DataSource = ds.Tables("nama")
		GridPanel.Refresh()
		GridPanel.Columns(0).HeaderText = "DIVISI"
		GridPanel.Columns(1).HeaderText = "ID DIVISI"
		GridPanel.Columns(0).Width = 500
		GridPanel.Columns(1).Width = 50
		GridPanel.ReadOnly = True
		GGVM_conn_close()
	End Sub
	Private Sub BtnSubDivisi_Click(sender As Object, e As EventArgs) Handles BtnSubDivisi.Click
		LoadDt = "subdivisi"
		PanelSurvei.Visible = True
		LoadSubDivisi()
		GridPanel.Focus()

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

	Private Sub RBBelumPE_CheckedChanged(sender As Object, e As EventArgs) Handles RBBelumPE.CheckedChanged
		If RBBelumPE.Checked = True Then
			BtnPE.Enabled = False
			BtnPO.Enabled = False
			BtnKlien.Enabled = True
			BtnArea.Enabled = True
			RBKlien.Checked = True
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
	Private Sub LoadSubArea()
		Dim s As String

		GGVM_conn()
		s = ""
		s = s & " select concat(x.propinsi,'/',x.kota)as kt,x.idpropinsi,x.idkota  from ("
		s = s & " select a.propinsi,b.kota ,a.idpropinsi,b.idkota"
		s = s & " from propinsi a, kota b"
		s = s & " where a.idpropinsi = b.idpropinsi"
		s = s & " and a.idarea = '" & TIdArea.Text & "') x order by kt "

		'da = Nothing
		da = New Odbc.OdbcDataAdapter(s, conn)
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

	Private Sub RBtunai_CheckedChanged_1(sender As Object, e As EventArgs) Handles RBtunai.CheckedChanged
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
		Else
			TBank.Text = ""
			TNoRek.Text = ""
			TBank.Enabled = False
			TNoRek.Enabled = False
		End If
	End Sub

	Private Sub RBtransfer_Click(sender As Object, e As EventArgs) Handles RBtransfer.Click
		If RBtransfer.Checked = True Then
			TBank.Enabled = True
			TNoRek.Enabled = True
			TBank.Focus()
		Else
			TBank.Text = ""
			TNoRek.Text = ""
			TBank.Enabled = False
			TNoRek.Enabled = False
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
					TidDivisi.Text = GridPanel.Rows.Item(i).Cells(1).Value
				Case "subdivisi"
					TSubDivisi.Text = GridPanel.Rows.Item(i).Cells(0).Value
					TIdSubDivisi.Text = GridPanel.Rows.Item(i).Cells(1).Value
				Case "area"
					TArea.Text = GridPanel.Rows.Item(i).Cells(0).Value
					TIdArea.Text = GridPanel.Rows.Item(i).Cells(1).Value
				Case "subarea"
					TSubArea.Text = GridPanel.Rows.Item(i).Cells(0).Value
					TIdPropinsi.Text = GridPanel.Rows.Item(i).Cells(1).Value
					TIdkota.Text = GridPanel.Rows.Item(i).Cells(2).Value
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

	Private Sub GridPanel_DoubleClick(sender As Object, e As EventArgs) Handles GridPanel.DoubleClick
		Dim i As Integer
		i = GridPanel.CurrentRow.Index
		If i < (GridPanel.RowCount) - 1 Then
			Select Case LoadDt
				Case "divisi"
					TDivisi.Text = GridPanel.Rows.Item(i).Cells(0).Value
					TidDivisi.Text = GridPanel.Rows.Item(i).Cells(1).Value
				Case "subdivisi"
					TSubDivisi.Text = GridPanel.Rows.Item(i).Cells(0).Value
					TIdSubDivisi.Text = GridPanel.Rows.Item(i).Cells(1).Value
				Case "area"
					TArea.Text = GridPanel.Rows.Item(i).Cells(0).Value
					TIdArea.Text = GridPanel.Rows.Item(i).Cells(1).Value
				Case "subarea"
					TSubArea.Text = GridPanel.Rows.Item(i).Cells(0).Value
					TIdPropinsi.Text = GridPanel.Rows.Item(i).Cells(1).Value
					TIdkota.Text = GridPanel.Rows.Item(i).Cells(2).Value
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
						TidDivisi.Text = GridPanel.Rows.Item(i).Cells(1).Value
					Case "subdivisi"
						TSubDivisi.Text = GridPanel.Rows.Item(i).Cells(0).Value
						TIdSubDivisi.Text = GridPanel.Rows.Item(i).Cells(1).Value
					Case "area"
						TArea.Text = GridPanel.Rows.Item(i).Cells(0).Value
						TIdArea.Text = GridPanel.Rows.Item(i).Cells(1).Value
					Case "subarea"
						TSubArea.Text = GridPanel.Rows.Item(i).Cells(0).Value
						TIdPropinsi.Text = GridPanel.Rows.Item(i).Cells(1).Value
						TIdkota.Text = GridPanel.Rows.Item(i).Cells(2).Value
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

	Private Sub PanelSurvei_Paint(sender As Object, e As PaintEventArgs) Handles PanelSurvei.Paint

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

	Private Sub TKeterangan_TextChanged(sender As Object, e As EventArgs) Handles TKeterangan.TextChanged

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
		' Dim i As Integer
		Dim tbl As New DataTable
		Dim cmd As New OdbcCommand


		If TidDivisi.Text = "" Then
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
			GGVM_conn()

			berangkat = DTBerangkat.Value
			pulang = DTPulang.Value
			hr = pulang.Subtract(berangkat)
			THari.Text = hr.Days + 1

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
			divisi = Microsoft.VisualBasic.Right("00" & Trim(TidDivisi.Text), 2)
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
			If TIdkota.Text <> "" Then
				c = c & " idkota,"
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
			If TIdkota.Text <> "" Then
				c = c & "'" & TIdkota.Text & "',"
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

			BtnProsesMaju.Enabled = False
			BtnTambahMaju.Enabled = True
			BtnEditMaju.Enabled = True
			GGVM_conn_close()
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
			If TIdkota.Text <> "" Then
				c = c & " idkota = '" & TIdkota.Text & "',"
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
			cmd = New Odbc.OdbcCommand(c, conn)
			cmd.ExecuteNonQuery()

			GGVM_conn_close()
			Me.Cursor = Cursors.Default
			MsgBox("Data sudah di-EDIT !!!...", MsgBoxStyle.Information, "Information")
		End If
	End Sub

	Private Sub BtnKeluar_Click_1(sender As Object, e As EventArgs) Handles BtnKeluar.Click
		Dim keluar As MsgBoxResult
		keluar = MsgBox("Apakah anda yakin untuk keluar program ?...", MsgBoxStyle.YesNo, "Peringatan")
		If keluar = MsgBoxResult.Yes Then
			Me.Close()
			Exit Sub
		End If
	End Sub

	Private Sub BtnPE_Click(sender As Object, e As EventArgs) Handles BtnPE.Click
		LoadDt = "pe"
		PanelSurvei.Visible = True
		LoadPE()
		GridPanel.Focus()
	End Sub

	Private Sub BtnPO_Click(sender As Object, e As EventArgs) Handles BtnPO.Click
		LoadDt = "po"
		PanelSurvei.Visible = True
		LoadPO()
		GridPanel.Focus()
	End Sub

	Private Sub BtnPO_KeyPress(sender As Object, e As KeyPressEventArgs) Handles BtnPO.KeyPress
		If e.KeyChar = Convert.ToChar(13) Then
			LoadDt = "po"
			PanelSurvei.Visible = True
			LoadPO()
			MsgBox("Data blm ada")
			GridPanel.Focus()
		End If
	End Sub

	Private Sub BtnPE_KeyPress(sender As Object, e As KeyPressEventArgs) Handles BtnPE.KeyPress
		If e.KeyChar = Convert.ToChar(13) Then
			LoadDt = "pe"
			PanelSurvei.Visible = True
			LoadPE()
			MsgBox("Data blm ada")
			GridPanel.Focus()
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
		If GridPanel.RowCount = 1 Then
			MsgBox("Data PO tidak ada !!..", MsgBoxStyle.Information, "Information")
			LPanel.Text = ""
			PanelSurvei.Visible = False
			Exit Sub
		End If
		GridPanel.Refresh()
		GridPanel.Columns(0).HeaderText = "NO.PURCHASE ORDER"
		GridPanel.Columns(1).HeaderText = "ID PO"
		GridPanel.Columns(0).Width = 500
		GridPanel.Columns(1).Width = 50

	End Sub

	Private Sub DTBerangkat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTBerangkat.KeyPress
		If e.KeyChar = Convert.ToChar(13) Then
			DTPulang.Focus()
		End If
	End Sub

	Private Sub DTBerangkat_ValueChanged(sender As Object, e As EventArgs) Handles DTBerangkat.ValueChanged

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
		PTCariBrg.Text = ""
		PTCariBrg.Enabled = True
		PTJml.Text = "1"
		PTJmlHari.Text = "1"
		PTJmlOrang.Text = "1"
		PTCariBrg.Focus()
	End Sub

	Private Sub SisaPO_CheckedChanged(sender As Object, e As EventArgs) Handles SisaPO.CheckedChanged
		If SisaPO.Checked = True Then
			TKeterangan.Text = "SISA P.O. "
		Else
			TKeterangan.Text = ""
		End If
	End Sub

	Private Sub BtnHitung_Click_1(sender As Object, e As EventArgs) Handles BtnHitung.Click
		PTSubTotal.Text = PTJml.Text * PTJmlHari.Text * PTJmlOrang.Text * PTHrgEstimasi.Text
		PTHrgEstimasi.Text = FormatNumber(PTHrgEstimasi.Text, 0, , , TriState.True)
		PTSubTotal.Text = FormatNumber(PTSubTotal.Text, 0, , , TriState.True)
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
		Dim c, s As String
		Dim cmd As New OdbcCommand
		Dim tbl As DataTable
		Dim PThrg As Double
		Dim PTSttl As Double


		'MAINTENAN ITEM
		Me.Cursor = Cursors.WaitCursor
		PThrg = PTHrgEstimasi.Text
		PTSttl = PTSubTotal.Text

		GGVM_conn()
		Select Case StsItem
			Case "Entry"
				c = ""
				c = c & " insert into detail_pengajuan (idpengajuan, idbarang,kdbarang,barang, "
				c = c & " idsatuan,type_pengajuan,jml_barang,jml_orang,jml_hari,harga_estimasi,sub_total,keterangan)"
				c = c & " values ('" & TIdPengajuan.Text & "','" & PTIdBarang.Text & "','" & PTKdBarang.Text & "','" & PTBarang.Text & "',"
				c = c & "'" & PTIdSatuan.Text & "','B','" & PTJml.Text & "','" & PTJmlOrang.Text & "','" & PTJmlHari.Text & "','" & PThrg & "','" & PTSttl & "','" & PTKeterangan.Text & "')"
				cmd = New Odbc.OdbcCommand(c, conn)
				cmd.ExecuteNonQuery()

			Case "Edit"

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

				c = ""
				c = c & " delete from detail_pengajuan"
				c = c & " where iddetail_pengajuan = '" & PTItem.Text & "'"
				cmd = New Odbc.OdbcCommand(c, conn)
				cmd.ExecuteNonQuery()
		End Select
		s = ""
		s = s & " select sum(sub_total)as subtotal from detail_pengajuan"
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

	Private Sub PTJml_TextChanged(sender As Object, e As EventArgs) Handles PTJml.TextChanged

	End Sub

	Private Sub PTJmlOrang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PTJmlOrang.KeyPress
		If e.KeyChar = Convert.ToChar(13) Then
			PTJmlHari.Focus()
		End If
	End Sub

	Private Sub PTJmlOrang_TextChanged(sender As Object, e As EventArgs) Handles PTJmlOrang.TextChanged

	End Sub

	Private Sub PTJmlHari_KeyPress(sender As Object, e As KeyPressEventArgs) Handles PTJmlHari.KeyPress
		If e.KeyChar = Convert.ToChar(13) Then
			PTSubTotal.Text = PTJml.Text * PTJmlHari.Text * PTJmlOrang.Text * PTHrgEstimasi.Text
			PTHrgEstimasi.Focus()
		End If
	End Sub

	Private Sub PTJmlHari_TextChanged(sender As Object, e As EventArgs) Handles PTJmlHari.TextChanged

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
			s = s & " from barang a, satuan c,subkelompok d"
			s = s & " where a.barang like '%" & Trim(PTCariBrg.Text) & "%'"
			s = s & " and a.status='1'"
			s = s & " and a.idsubkel = d.idsubkel"
			s = s & " and d.idkelompok not in ('6','7','8','9','10','11','13','14')"
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
		End If
		PTCariBrg.Focus()

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
		PTSubTotal.Text = PTJml.Text * PTJmlHari.Text * PTJmlOrang.Text * PTHrgEstimasi.Text
		PTHrgEstimasi.Text = FormatNumber(PTHrgEstimasi.Text, 0, , , TriState.True)
		PTSubTotal.Text = FormatNumber(PTSubTotal.Text, 0, , , TriState.True)
	End Sub


	Private Sub PTCariBrg_TextChanged(sender As Object, e As EventArgs) Handles PTCariBrg.TextChanged

	End Sub

	Private Sub BtnDivisi_Click(sender As Object, e As EventArgs) Handles BtnDivisi.Click
		LoadDt = "divisi"
		PanelSurvei.Visible = True
		LoadDivisi()
		GridPanel.Focus()
	End Sub

	Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

	End Sub

	Private Sub FrmPengajuan_ControlAdded(sender As Object, e As ControlEventArgs) Handles Me.ControlAdded

	End Sub
End Class