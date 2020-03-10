Option Strict Off
Imports DevExpress.XtraBars.Ribbon
Imports System.Data.Odbc
Imports DevExpress.XtraEditors
Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Navigation

Public Class FrmActPE

	Private ItemsBackup As New List(Of ListViewItem)
	Private Panel1Captured As Boolean
	Private Panel1Grabbed As Point
	Private strName As String
	Private HitungNominal As String
	Private thn, bln, count, divisiid, urutpe, c As String
	Private StartBln, StartThn, StartTgl, tglevent, EndBln, EndThn, EndTgl As String
	Private PeriodeHR As Double = 0
	Dim spasi() As Char = (" ")
	Dim Qoma() As Char = (",")
	Private KondisiInputEvn, KondisiInputProject, KondisiInputHR, KondisiSimpan, KondisiSimpanAlasan, ProsesPE As String
	Private HapusDetailEvent, HapusDetailProject As String

	Public Sub New()
		InitializeComponent()
	End Sub
	Private Sub AturanInput(ByRef e As KeyPressEventArgs)
		If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ",") And Not Char.IsControl(e.KeyChar) Then
			MessageBox.Show("Hanya Boleh Angka !")
			e.Handled = True
		Else
			Return
		End If
	End Sub
#Region "Deklarasi AutoComplete"
	Private Sub LoadKuartal()
		GGVM_conn()
		sql = " select kuartal from act_detail_penawaran where idpe = '" & TidPE.Text & "' GROUP BY kuartal"
		cmd = New OdbcCommand(sql, conn)
		dr = cmd.ExecuteReader
		Do While dr.Read
			CKuartal.Items.Add(dr.Item("kuartal"))
		Loop
		GGVM_conn_close()
	End Sub
	Private Sub ComboKontrak()
		GGVM_conn()
		CKontrak.Items.Clear()
        sql = "Select * From evn_kontrak where iddivisi = '" & DivUser & "'"
        cmd = New OdbcCommand(sql, conn)
		dr = cmd.ExecuteReader
		Do While dr.Read
			CKontrak.Items.Add(dr.Item("valuecontract"))
		Loop
		GGVM_conn_close()
	End Sub
	Private Sub LoadVenue()
		sql = ""
		sql = sql & "SELECT * FROM kota"
		da = New OdbcDataAdapter(sql, conn)
		ds = New DataSet
		da.Fill(ds)
		Dim venue As New AutoCompleteStringCollection
		For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
			venue.Add(ds.Tables(0).Rows(i)("kota").ToString())
		Next
		With TVenue
			.AutoCompleteSource = AutoCompleteSource.CustomSource
			.AutoCompleteCustomSource = venue
			.AutoCompleteMode = AutoCompleteMode.Suggest
		End With
	End Sub
	Private Sub LoadBarangCL()
		sql = ""
		sql = sql & "SELECT * FROM barang_penawaran  where idsubkel = '110' "
		da = New OdbcDataAdapter(sql, conn)
		ds = New DataSet
		da.Fill(ds)
		Dim brgpen As New AutoCompleteStringCollection
		For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
			brgpen.Add(ds.Tables(0).Rows(i)("barang").ToString())
		Next
		With TBarangCL
			.AutoCompleteSource = AutoCompleteSource.CustomSource
			.AutoCompleteCustomSource = brgpen
			.AutoCompleteMode = AutoCompleteMode.Suggest
		End With
	End Sub
	Private Sub LoadBarangEvn()
		sql = ""
		sql = sql & "SELECT a.* FROM barang_penawaran a "
		sql = sql & " JOIN subkelompok b on a.idsubkel = b.idsubkel "
		sql = sql & " JOIN kelompok c on b.idkelompok = c.idkelompok "
		sql = sql & " WHERE c.idkelompok = '20'"
		da = New OdbcDataAdapter(sql, conn)
		ds = New DataSet
		da.Fill(ds)
		Dim brgpen As New AutoCompleteStringCollection
		For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
			brgpen.Add(ds.Tables(0).Rows(i)("barang").ToString())
		Next
		With TBarangEvn
			.AutoCompleteSource = AutoCompleteSource.CustomSource
			.AutoCompleteCustomSource = brgpen
			.AutoCompleteMode = AutoCompleteMode.Suggest
		End With
	End Sub
	Private Sub LoadSubkel()
		GGVM_conn()
		CSubkelEvn.Items.Clear()
		sql = ""
		sql = sql & "SELECT a.* from subkelompok a "
		sql = sql & "JOIN kelompok b on a.idkelompok = b.idkelompok "
		sql = sql & " where b.idkelompok = 20 "
		cmd = New OdbcCommand(sql, conn)
		dr = cmd.ExecuteReader
		Do While dr.Read
			CSubkelEvn.Items.Add(dr("subkel"))
		Loop
		GGVM_conn_close()
	End Sub
	Private Sub LoadJenisDetail()
		GGVM_conn()
		CJenisDetail.Items.Clear()
		sql = ""
		sql = sql & "SELECT * from act_jenis_detail"
		cmd = New OdbcCommand(sql, conn)
		dr = cmd.ExecuteReader
		Do While dr.Read
			CJenisDetail.Items.Add(dr("jenis_detail"))
		Loop
		GGVM_conn_close()
	End Sub
	Private Sub LoadSatuan()
		GGVM_conn()
		CSatQtyEvn.Items.Clear()
		CSatFreqEvn.Items.Clear()
		CQtyProj.Items.Clear()

		sql = ""
		sql = sql & "SELECT * from Satuan"
		cmd = New OdbcCommand(sql, conn)
		dr = cmd.ExecuteReader
		Do While dr.Read
			CSatQtyEvn.Items.Add(dr("satuan"))
			CSatFreqEvn.Items.Add(dr("satuan"))
			CQtyProj.Items.Add(dr("satuan"))
		Loop
		GGVM_conn_close()
	End Sub
	Private Sub LoadItemProject()
		sql = ""
		sql = sql & "SELECT a.* FROM barang_penawaran a "
		sql = sql & " JOIN subkelompok b on a.idsubkel = b.idsubkel "
		sql = sql & " JOIN kelompok c on b.idkelompok = c.idkelompok "
		sql = sql & " WHERE c.idkelompok = '20'"
		da = New OdbcDataAdapter(sql, conn)
		ds = New DataSet
		da.Fill(ds)
		Dim brgpen As New AutoCompleteStringCollection
		For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
			brgpen.Add(ds.Tables(0).Rows(i)("barang").ToString())
		Next
		With TBarangProj
			.AutoCompleteSource = AutoCompleteSource.CustomSource
			.AutoCompleteCustomSource = brgpen
			.AutoCompleteMode = AutoCompleteMode.Suggest
		End With
	End Sub
	Private Sub LoadKlien()
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
	Private Sub LoadSubdivisi()
		GGVM_conn()
		CSubDivisi.Items.Clear()
		If DivUser = "0" Then
			sql = "select subdivisi from subdivisi"
		Else
			sql = "select subdivisi from subdivisi where id_divisi = '" & DivUser & "'"
		End If
		cmd = New OdbcCommand(sql, conn)
		dr = cmd.ExecuteReader
		Do While dr.Read
			CSubDivisi.Items.Add(dr("subdivisi"))
		Loop
		GGVM_conn_close()
	End Sub
	Private Sub LoadPropinsi()
		GGVM_conn()
		sql = "select * from propinsi"
		cmd = New OdbcCommand(sql, conn)
		dr = cmd.ExecuteReader
		Do While dr.Read
			CAreaHR.Items.Add(dr("propinsi"))
		Loop
		GGVM_conn_close()
	End Sub
	Private Sub LoadKota()
		GGVM_conn()
		sql = "select * from kota where idpropinsi = '" & TidAreaHR.Text & "'"
		cmd = New OdbcCommand(sql, conn)
		dr = cmd.ExecuteReader
		Do While dr.Read
			CKotaHR.Items.Add(dr("kota"))
		Loop
		GGVM_conn_close()
	End Sub
	Private Sub LoadRegion()
		GGVM_conn()
		sql = "select * from spg_region"
		da = New OdbcDataAdapter(sql, conn)
		ds = New DataSet
		da.Fill(ds)
		Dim region As New AutoCompleteStringCollection()
		For i = 0 To ds.Tables(0).Rows.Count - 1
			region.Add(ds.Tables(0).Rows(i)("region").ToString())
		Next
		With TRegion
			.AutoCompleteCustomSource = region
			.AutoCompleteMode = AutoCompleteMode.Suggest
			.AutoCompleteSource = AutoCompleteSource.CustomSource
		End With
		GGVM_conn_close()
	End Sub
	Private Sub LoadJabatan()
		GGVM_conn()
		sql = "select * from spg_jabatan where status = '1'"
		da = New OdbcDataAdapter(sql, conn)
		ds = New DataSet
		da.Fill(ds)
		Dim jabatan As New AutoCompleteStringCollection
		For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
			jabatan.Add(ds.Tables(0).Rows(i)("jabatan").ToString())
		Next
		With TPositionHR
			.AutoCompleteSource = AutoCompleteSource.CustomSource
			.AutoCompleteCustomSource = jabatan
			.AutoCompleteMode = AutoCompleteMode.Suggest
		End With
		GGVM_conn_close()
	End Sub
#End Region
#Region "Deklarasi Perintah"
	Private Sub SimpanEvent()
		For Each item As ListViewItem In ListBiayaEvn.Items
			GGVM_conn()
			sql = ""
			sql = sql & "insert into act_detail_penawaran (barang, qty, satuan_qty, freq, satuan_freq, region_event, harga_unit, subtotal, keterangan, idsatuan_qty, idsatuan_freq, idbarang, idpe, iddetail, idjenis_detail,kuartal) "
			sql = sql & " values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)"
			cmd = New OdbcCommand
			With cmd
				.CommandText = (sql)
				.Parameters.Add("@brg", OdbcType.VarChar).Value = item.Text
				.Parameters.Add("@qty", OdbcType.Double).Value = Convert.ToDouble(item.SubItems(1).Text)
				.Parameters.Add("@satqty", OdbcType.VarChar).Value = item.SubItems(2).Text
				.Parameters.Add("@freq", OdbcType.Double).Value = Convert.ToDouble(item.SubItems(3).Text)
				.Parameters.Add("@satfreq", OdbcType.VarChar).Value = item.SubItems(4).Text
				.Parameters.Add("@regionevent", OdbcType.Double).Value = item.SubItems(5).Text
				.Parameters.Add("@hargaunit", OdbcType.Double).Value = item.SubItems(6).Text
				.Parameters.Add("@subtotal", OdbcType.Double).Value = Convert.ToInt32(item.SubItems(7).Text)
				.Parameters.Add("@ket", OdbcType.VarChar).Value = item.SubItems(8).Text
				.Parameters.Add("@idsatqty", OdbcType.Int).Value = Convert.ToInt32(item.SubItems(9).Text)
				.Parameters.Add("@idsatfreq", OdbcType.Int).Value = Convert.ToInt32(item.SubItems(10).Text)
				.Parameters.Add("@idbarang1", OdbcType.BigInt).Value = Convert.ToInt32(item.SubItems(11).Text)
				.Parameters.Add("@idpe", OdbcType.BigInt).Value = Convert.ToInt32(item.SubItems(12).Text)
				.Parameters.Add("@iddetail", OdbcType.BigInt).Value = Convert.ToInt32(item.SubItems(13).Text)
				.Parameters.Add("@idjenisdetail", OdbcType.Int).Value = Convert.ToInt32(item.SubItems(14).Text)
				.Parameters.Add("@quartal", OdbcType.Int).Value = Convert.ToInt32(item.SubItems(16).Text)
				.Connection = conn
			End With
			dr = cmd.ExecuteReader
			Console.WriteLine(cmd.CommandText.ToString)
			While dr.Read
				Console.WriteLine(dr(0))
				Console.WriteLine()
			End While
			Console.ReadLine()
			' conn.Close()
			dr = Nothing
			cmd = Nothing
		Next
		ListBiayaEvn.Items.Clear()
	End Sub
	Private Sub UpdateEvent()
		For Each item As ListViewItem In ListBiayaEvn.Items
			GGVM_conn()
			sql = ""
			sql = sql & "update act_detail_penawaran set barang = ?, qty = ?, satuan_qty = ?, freq = ?, satuan_freq = ?, region_event = ?, harga_unit = ?, subtotal = ?, keterangan = ?, idsatuan_qty = ?, idsatuan_freq = ?, idbarang = ?, idpe = ?, iddetail = ?, idjenis_detail = ?,kuartal = ?"
			sql = sql & " where iddetail_act = ?"
			cmd = New OdbcCommand
			With cmd
				.CommandText = (sql)
				.Parameters.Add("@barang", OdbcType.VarChar).Value = item.Text
				.Parameters.Add("@qty", OdbcType.Double).Value = Convert.ToDouble(item.SubItems(1).Text)
				.Parameters.Add("@satuan_qty", OdbcType.VarChar).Value = item.SubItems(2).Text
				.Parameters.Add("@freq", OdbcType.Double).Value = Convert.ToDouble(item.SubItems(3).Text)
				.Parameters.Add("@satuan_freq", OdbcType.VarChar).Value = item.SubItems(4).Text
				.Parameters.Add("@region_event", OdbcType.Double).Value = item.SubItems(5).Text
				.Parameters.Add("@harga_unit", OdbcType.Double).Value = item.SubItems(6).Text
				.Parameters.Add("@subtotal", OdbcType.Double).Value = Convert.ToInt32(item.SubItems(7).Text)
				.Parameters.Add("@keterangan", OdbcType.VarChar).Value = item.SubItems(8).Text
				.Parameters.Add("@idsatuan_qty", OdbcType.Int).Value = Convert.ToInt32(item.SubItems(9).Text)
				.Parameters.Add("@idsatuan_freq", OdbcType.Int).Value = Convert.ToInt32(item.SubItems(10).Text)
				.Parameters.Add("@idbarang", OdbcType.BigInt).Value = Convert.ToInt32(item.SubItems(11).Text)
				.Parameters.Add("@idpe", OdbcType.BigInt).Value = Convert.ToInt32(item.SubItems(12).Text)
				.Parameters.Add("@iddetail", OdbcType.BigInt).Value = Convert.ToInt32(item.SubItems(13).Text)
				.Parameters.Add("@idjenisdetail", OdbcType.Int).Value = Convert.ToInt32(item.SubItems(14).Text)
				.Parameters.Add("@kuartal", OdbcType.Int).Value = Convert.ToInt32(item.SubItems(16).Text)
				.Parameters.Add("@iddetail_act", OdbcType.BigInt).Value = Convert.ToInt32(item.SubItems(15).Text)
				.Connection = conn
			End With
			dr = cmd.ExecuteReader
			Console.WriteLine(cmd.CommandText.ToString)
			While dr.Read
				Console.WriteLine(dr(0))
				Console.WriteLine()
			End While
			Console.ReadLine()
			' conn.Close()
			dr = Nothing
			cmd = Nothing
		Next
	End Sub
	Private Sub NominalBiaya()
		Dim Nominal As Long = 0
		Dim PPN As Double = 0
		Dim Fee As Double = 0
		Dim BeforeVAT As Double = 0
		Dim IncludePPN As Double = 0
		Dim PPH As Double = 0
		Const V As Integer = 100
		If TidJenisPE.Text = "5" Then
			For i As Integer = 0 To ListBiayaEvn.Items.Count - 1
				Nominal = CLng(Nominal + Val(ListBiayaEvn.Items(i).SubItems(7).Text))
			Next
			TTotalEvn.EditValue = Nominal
			Fee = Val(CDbl(Nominal)) * Val(CDbl(TAgentFee.Text)) / V
			TAgentFeeEvn.EditValue = Val(CDbl(Fee))
			BeforeVAT = Val(CDbl(Nominal)) + Val(CDbl(Fee))
			TTotalVATEvn.EditValue = BeforeVAT
			If AdaPPN.Checked = True Then
				PPN = Val(BeforeVAT * 10) / V
			Else
				PPN = 0
			End If
			TPPNEvn.EditValue = PPN
			TGrandTotalEvn.EditValue = BeforeVAT + PPN
		ElseIf TidJenisPE.Text = "6" Then
			For i As Integer = 0 To ListBiayaProject.Items.Count - 1
				Nominal = Nominal + Val(ListBiayaProject.Items(i).SubItems(4).Text)
			Next
			TTotalProj.EditValue = Nominal
			Fee = Val(CDbl(Nominal)) * Val(CDbl(TAgentFee.Text)) / V
			TAgentFeeProj.EditValue = Val(CDbl(Fee))
			BeforeVAT = Val(CDbl(Nominal)) + Val(CDbl(Fee))
			If AdaPPN.Checked = True Then
				PPN = Val(BeforeVAT * 10) / V
			Else
				PPN = 0
			End If
			TRpPPNProj.EditValue = PPN
			TGrandTotalProj.EditValue = BeforeVAT + PPN
		ElseIf TidJenisPE.Text = "7" Then
			For t As Integer = 0 To DGInputHR.Rows.Count - 1
				TTotPersonHR.Text = Val(CDbl(TTotPersonHR.Text)) + Val(DGInputHR.Rows(t).Cells(10).Value)
				TPersonMonthHR.Text = Val(CDbl(TPersonMonthHR.Text)) + Val(DGInputHR.Rows(t).Cells(3).Value)
				TGross1HR.Text = Val(CDbl(TGross1HR.Text)) + Val(DGInputHR.Rows(t).Cells(11).Value)
				TGross2HR.Text = Val(CDbl(TGross2HR.Text)) + Val(DGInputHR.Rows(t).Cells(12).Value)
				TAgentFeeHR.Text = Val(CDbl(TAgentFeeHR.Text)) + Val(DGInputHR.Rows(t).Cells(13).Value)
				TPpnHR.Text = Val(CDbl(TPpnHR.Text)) + Val(DGInputHR.Rows(t).Cells(14).Value)
				TPph23HR.Text = Val(CDbl(TPph23HR.Text)) + Val(DGInputHR.Rows(t).Cells(15).Value)
				TGrandTotalHR.Text = Val(CDbl(TGrandTotalHR.Text)) + Val(DGInputHR.Rows(t).Cells(17).Value)
				TTakeHomePay.Text = Val(CDbl(TTakeHomePay.Text)) + Val(DGInputHR.Rows(t).Cells(16).Value)
			Next
		Else
			Return
		End If
	End Sub
	Private Sub DataBaruHR()
		Try
			Call HitungInpHR()

			GGVM_conn()
			sql = ""
			sql = sql & "insert act_detail_sdm (idpe,iddetail,idjenis_detail,idjabatan,idarea,idregion,idkota,tahun,"
			sql = sql & "jml_person,basicsalary,"
			If CAdaBPJS.Checked = True Then
				sql = sql & "bpjskes,bpjstk,"
			End If
			If TPostAllow.Text <> "" Then
				sql = sql & "tunjjbt,"
			End If
			If TMeal.Text <> "" Then
				sql = sql & "allowmeal,"
			End If
			If TTransport.Text <> "" Then
				sql = sql & "allowtrans,"
			End If
			If TMotor.Text <> "" Then
				sql = sql & "motorcycle,"
			End If
			If TAtkHR.Text <> "" Then
				sql = sql & "allowatk,"
			End If
			If TRentComp.Text <> "" Then
				sql = sql & "sewakomp,"
			End If
			If TPulse.Text <> "" Then
				sql = sql & "pulsa,"
			End If
			If TMakeUp.Text <> "" Then
				sql = sql & "makeup,"
			End If
			If TMeetingCost.Text <> "" Then
				sql = sql & "bymeeting,"
			End If
			If TIncentive.Text <> "" Then
				sql = sql & "incentive,"
			End If
			If TTravellingHR.Text <> "" Then
				sql = sql & "traveling_cost,"
			End If
			If TFixCostHR.Text <> "" Then
				sql = sql & "fix_cost,"
			End If
			If TTelemarketingHR.Text <> "" Then
				sql = sql & "telemarketing,"
			End If
			If TUangHadir.Text <> "" Then
				sql = sql & "uanghadir,"
			End If
			If TEventHR.Text <> "" Then
				sql = sql & "event_cost,"
			End If
			If TPotBpjsEmp.Text <> "" Then
				sql = sql & "pot_bpjstk,"
			End If
			If TPotBpjsMed.Text <> "" Then
				sql = sql & "pot_bpjskes,"
			End If
			If TThr.Text <> "" Then
				sql = sql & "thr,"
			End If
			If TTrainingCost.Text <> "" Then
				sql = sql & "training_cost,"
			End If
			If TOvertime.Text <> "" Then
				sql = sql & "lembur,"
			End If
			If TSubColl.Text <> "" Then
				sql = sql & "subcollateb,"
			End If
			sql = sql & "gross1,gross2,fee,ppn,pph23,thp,totalperson_cost,grandtotal,"
			sql = sql & "periode, userinput, timeinput)"
			sql = sql & " values ('" & TidPE.Text & "','" & TidDetailCL.Text & "','4','" & TidPositionHR.Text & "','" & TidAreaHR.Text & "','" & TidRegionHR.Text & "','" & TidKotaHR.Text & "', '" & TTahunHR.Text & "',"
			sql = sql & "'" & TPeopleHR.Text & "', '" & TBasicSalaryHR.Text & "',"
			If CAdaBPJS.Checked = True Then
				sql = sql & "'" & TBpjsMed.Text & "','" & TBpjsEmp.Text & "',"
			End If
			If TPostAllow.Text <> "" Then
				sql = sql & "'" & TPostAllow.Text & "',"
			End If
			If TMeal.Text <> "" Then
				sql = sql & "'" & TMeal.Text & "',"
			End If
			If TTransport.Text <> "" Then
				sql = sql & "'" & TTransport.Text & "',"
			End If
			If TMotor.Text <> "" Then
				sql = sql & "'" & TMotor.Text & "',"
			End If
			If TAtkHR.Text <> "" Then
				sql = sql & "'" & TAtkHR.Text & "',"
			End If
			If TRentComp.Text <> "" Then
				sql = sql & "'" & TRentComp.Text & "',"
			End If
			If TPulse.Text <> "" Then
				sql = sql & "'" & TPulse.Text & "',"
			End If
			If TMakeUp.Text <> "" Then
				sql = sql & "'" & TMakeUp.Text & "',"
			End If
			If TMeetingCost.Text <> "" Then
				sql = sql & "'" & TMeetingCost.Text & "',"
			End If
			If TTravellingHR.Text <> "" Then
				sql = sql & "'" & TTravellingHR.Text & "',"
			End If
			If TIncentive.Text <> "" Then
				sql = sql & "'" & TIncentive.Text & "',"
			End If
			If TFixCostHR.Text <> "" Then
				sql = sql & "'" & TFixCostHR.Text & "',"
			End If
			If TTelemarketingHR.Text <> "" Then
				sql = sql & "'" & TTelemarketingHR.Text & "',"
			End If
			If TUangHadir.Text <> "" Then
				sql = sql & "'" & TUangHadir.Text & "',"
			End If
			If TEventHR.Text <> "" Then
				sql = sql & "'" & TEventHR.Text & "',"
			End If
			If TPotBpjsEmp.Text <> "" Then
				sql = sql & "'" & TPotBpjsEmp.Text & "',"
			End If
			If TPotBpjsMed.Text <> "" Then
				sql = sql & "'" & TPotBpjsMed.Text & "',"
			End If
			If TThr.Text <> "" Then
				sql = sql & "'" & TThr.Text & "',"
			End If
			If TTrainingCost.Text <> "" Then
				sql = sql & "'" & TTrainingCost.Text & "',"
			End If
			If TOvertime.Text <> "" Then
				sql = sql & "'" & TOvertime.Text & "',"
			End If
			If TSubColl.Text <> "" Then
				sql = sql & "'" & TSubColl.Text & "',"
			End If
			sql = sql & "'" & TGross1HR.Text & "','" & TGross2HR.Text & "','" & TAgentFeeHR.Text & "','" & TPpnHR.Text & "',"
			sql = sql & "'" & TPph23HR.Text & "','" & TTakeHomePay.Text & "','" & TPersonMonthHR.Text & "','" & TGrandTotalHR.Text & "',"
			sql = sql & "'" & TPeriodeHR.Text & "','" & userid & "',now())"
			cmd = New OdbcCommand(sql, conn)
			cmd.ExecuteNonQuery()

			MsgBox("Data berhasil di Simpan !!", MsgBoxStyle.Information, "Pemberitahuan !!")
		Catch ex As Exception
			MsgBox("Data Gagal di Simpan !!", MsgBoxStyle.Critical, "Eror !!")
		Finally
			GGVM_conn_close()
		End Try
	End Sub
	Private Sub InputMainDetail()
		Dim detailid, idjnsdet As Integer

		TTotalCostCL.Text = Val(CDbl(TQtyCL.Text)) * Val(CDbl(TSubTotalCL.Text))
		GGVM_conn()
		sql = ""
		sql = sql & "insert evn_detail_penawaran (idpe,idbarang,barang,qty,satuan_qty, "
		If TidKontrakAct.Text <> "" Then
			sql = sql & "item, material_no, "
		End If
		If TKetCL.Text <> "" Then
			sql = sql & "remaks,"
		End If
		sql = sql & " total,unitcost,sub_totalcost)"
		sql = sql & " values ('" & TidPE.Text & "','" & TidBarangCL.Text & "','" & TBarangCL.Text & "','" & TQtyCL.Text & "','Paket',"
		If TidKontrakAct.Text <> "" Then
			sql = sql & "'" & TItemNoCL.Text & "','" & TMaterialNoCL.Text & "',"
		End If
		If TKetCL.Text <> "" Then
			sql = sql & "'" & TKetCL.Text & "',"
		End If
		sql = sql & "'" & TQtyCL.Text & "','" & TSubTotalCL.Text & "','" & TTotalCostCL.Text & "')"
		cmd = New OdbcCommand(sql, conn)
		cmd.ExecuteNonQuery()

		If TidJenisPE.Text = "5" Then
			sql = ""
			sql = sql & " Select max(iddetail)As id from evn_detail_penawaran "
			da = New OdbcDataAdapter(sql, conn)
			dt = New DataTable
			da.Fill(dt)
			If dt.Rows.Count > 0 Then
				detailid = dt.Rows(0)("id")
			End If

			c = "SELECT idjenis_detail from act_jenis_detail where jenis_detail = '" & TBarangCL.Text & "'"
			da = New OdbcDataAdapter(c, conn)
			dt = New DataTable
			da.Fill(dt)
			If dt.Rows.Count > 0 Then
				idjnsdet = dt.Rows(0)("idjenis_detail")
			End If

			sql = ""
			sql = sql & "insert act_kuartal_pe (idpe,iddetail,idjenis_detail,jmlevent,subtotal,kuartalke) "
			sql = sql & " values ('" & TidPE.Text & "','" & detailid & "','" & idjnsdet & "','" & TJmlEvnCL.Text & "','" & TSubTotalCL.Text & "', "
			sql = sql & "'1')"
			cmd = New OdbcCommand(sql, conn)
			cmd.ExecuteNonQuery()
		End If

		Call BacaMainDetail()
		Call KondisiBersihDetail()

		MsgBox("Data berhasil di tambahkan !!", MsgBoxStyle.Information, "Pemberitahuan !!")
	End Sub
	Private Sub HitungMainDetail()
		GGVM_conn()
		Dim NominalCL As Double = 0
		For i As Integer = 0 To ListDetailPEAct.Items.Count - 1
			NominalCL = NominalCL + Val(ListDetailPEAct.Items(i).SubItems(5).Text)
		Next
		TTotalCostCL.Text = NominalCL
		If TAgentFee.Text = "" Then
			TAgentFee.Text = "0"
		End If
		If CekFee.Checked = True Then
			TAgentFeeCL.Text = Val(TTotalCostCL.Text) * Val(CDbl(TAgentFee.Text) / 100)
		Else
			TAgentFeeCL.Text = "0"
		End If
		If CekPPN.Checked = True Then
			TRpPPNCL.Text = Val(TTotalCostCL.Text + Val(CDbl(TAgentFeeCL.Text)) * 10) / 100
		Else
			TRpPPNCL.Text = "0"
		End If
		If CekPPH.Checked = True Then
			CekFee.Checked = True
			TPph23CL.Text = Val(TAgentFeeCL.Text * 2) / 100
		Else
			TPph23CL.Text = "0"
		End If
		TGrandTotalCL.Text = Val(TTotalCostCL.Text) + Val(TAgentFeeCL.Text) + Val(TRpPPNCL.Text) + Val(TPph23CL.Text)
	End Sub
	Private Sub SimpanTotalPE()
		GGVM_conn()
		sql = ""
		sql = sql & "update evn_penawaran set total = '" & TTotalCostCL.Text & "',"
		If CekFee.Checked = True Then
			sql = sql & " agent_fee ='" & TAgentFeeCL.Text & "' ,"
		End If
		If CekPPN.Checked = True Then
			sql = sql & "rp_ppn = '" & TRpPPNCL.Text & "',"
		End If
		If CekPPH.Checked = True Then
			sql = sql & "rp_pph23= '" & TPph23CL.Text & "'"
		End If
		sql = sql & "grandtotal = '" & TGrandTotalCL.Text & "',"
		sql = sql & " userid_input = '" & userid & "'"
		sql = sql & " where idpe = '" & TidPE.Text & "'"
		cmd = New OdbcCommand(sql, conn)
		cmd.ExecuteNonQuery()
		GGVM_conn_close()
	End Sub
	Private Sub HitungInpHR()
		Dim people, periode As Double
		Dim TotSalary As Double = 0
		Dim TotOprs As Double = 0
		Dim TotPotPrib As Double = 0
		Double.TryParse(TPeopleHR.Text, people)
		Double.TryParse(TPeriodeHR.Text, periode)
		TotSalary = Val(CDbl(TBasicSalaryHR.Text)) + Val(CDbl(TBpjsMed.Text)) + Val(CDbl(TBpjsEmp.Text)) + Val(CDbl(TUangHadir.Text))
		TotSalary = TotSalary + Val(CDbl(TRentComp.Text)) + Val(CDbl(TIncentive.Text)) + Val(CDbl(TThr.Text)) + Val(CDbl(TPostAllow.Text))
		TotSalary = TotSalary + Val(CDbl(TMeal.Text)) + Val(CDbl(TTransport.Text)) + Val(CDbl(TMotor.Text)) + Val(CDbl(TPulse.Text)) + Val(CDbl(TMakeUp.Text))
		TotOprs = Val(CDbl(TMeetingCost.Text)) + Val(CDbl(TAtkHR.Text)) + Val(CDbl(TEventHR.Text)) + Val(CDbl(TTelemarketingHR.Text)) + Val(CDbl(TTravellingHR.Text))
		TotPotPrib = Val(CDbl(TPotBpjsMed.Text)) + Val(CDbl(TPotBpjsEmp.Text))
		TTotPersonHR.Text =
		TPersonMonthHR.Text = TotSalary + TotOprs
		TGross1HR.Text = Math.Round(Val(CDbl(periode)) * Val(CDbl(people)) * Val(CDbl(TPersonMonthHR.Text)))
		TAgentFeeHR.Text = Math.Round(Val(CDbl(TPersonMonthHR.Text) * Val(CDbl(TAgentFee.Text)) / 100))
		TGross2HR.Text = Math.Round(Val(CDbl(TGross1HR.Text)) + Val(CDbl(TAgentFeeHR.Text)))
		TPpnHR.Text = Math.Round(Val(CDbl(TGross2HR.Text) * 10) / 100)
		TPph23HR.Text = Math.Round(Val(CDbl(TAgentFeeHR.Text) * 2) / 100)
		TGrandTotalHR.Text = Math.Round(Val(CDbl(TGross2HR.Text)) + Val(CDbl(TPpnHR.Text)) - Val(CDbl(TPph23HR.Text)))
		TTakeHomePay.Text = Math.Round(Val(CDbl(TotSalary)) - Val(CDbl(TotPotPrib)))
	End Sub
	Private Sub TanggalEvent()
		StartTgl = Microsoft.VisualBasic.Left(StartPeriod.Text, 2)
		StartBln = Mid(StartPeriod.Text, 4, 3)
		StartThn = Microsoft.VisualBasic.Right(StartPeriod.Text, 4)

		EndTgl = Microsoft.VisualBasic.Left(EndPeriod.Text, 2)
		EndBln = Mid(EndPeriod.Text, 4, 3)
		EndThn = Microsoft.VisualBasic.Right(EndPeriod.Text, 4)

		If StartPeriod.Text = EndPeriod.Text Then
			tglevent = EndPeriod.Text
		ElseIf StartThn = EndThn And StartBln = EndBln Then
			tglevent = EndBln + spasi + EndThn
		ElseIf StartThn = EndThn And StartBln <> EndBln Then
			tglevent = StartBln + "-" + EndBln + spasi + EndThn
		Else
			tglevent = StartTgl + spasi + StartBln + spasi + StartThn + "-" + EndTgl + spasi + EndBln + spasi + EndThn
		End If
	End Sub
#End Region
#Region "Deklarasi Kondisi"
	Public Function Duplicate() As Boolean
		GGVM_conn()
		With Me
			sql = "select * from act_detail_sdm where idjabatan = '" & TidPositionHR.Text & "' and idkota = '" & TidKotaHR.Text & "'"
			da = New OdbcDataAdapter(sql, conn)
			dt = New DataTable
			da.Fill(dt)
			If dt.Rows.Count > 0 Then
				Duplicate = True
			Else
				Duplicate = False
			End If
			conn.Close()
		End With
	End Function
	Public Function Blank() As Boolean
		GGVM_conn()
		With Me
			If .TidKotaHR.Text = "" Or .TidPositionHR.Text = "" Or .TBasicSalaryHR.Text = "" Then
				Blank = True
				MsgBox("Data Tidak Boleh Kosong", MsgBoxStyle.Critical, "Unable to save")
			Else
				Blank = False
			End If
		End With
	End Function
	Private Sub KondisiAwalPE()
		TNoPE.Enabled = False
		TKlien.Enabled = False
		TVenue.Enabled = False
		TJmlEvent.Enabled = False
		TRegion.Enabled = False
		TProject.Enabled = False
		StartPeriod.Enabled = False
		EndPeriod.Enabled = False
		TPIC.Enabled = False
		TTotal.Enabled = False
		TRpPPN.Enabled = False
		TAgencyRP.Enabled = False
		TTotalVAT.Enabled = False
		TAgentFee.Enabled = False
		CKontrak.Enabled = False
		DTTanggal.Enabled = False
		CSubDivisi.Enabled = False
		BtnProsesPE.Enabled = False
		CetakPE.Enabled = True
		SimpanPE.Enabled = False
		RevisiPE.Enabled = False
		BatalTools.Enabled = False
		HapusPE.Enabled = False
		TambahPE.Enabled = True
	End Sub
	Private Sub KondisiTambahPE()
		TKlien.Enabled = True
		TRegion.Enabled = True
		TVenue.Enabled = True
		TJmlEvent.Enabled = True
		TProject.Enabled = True
		StartPeriod.Enabled = True
		EndPeriod.Enabled = True
		TPIC.Enabled = True
		TAgentFee.Enabled = True
		CSubDivisi.Enabled = True
		CKontrak.Enabled = True
		BtnProsesPE.Enabled = True
		TambahPE.Enabled = False
		BatalTools.Enabled = True
	End Sub
	Private Sub KondisiEditPE()
		TKlien.Enabled = True
		TRegion.Enabled = True
		TVenue.Enabled = True
		TJmlEvent.Enabled = True
		TProject.Enabled = True
		StartPeriod.Enabled = True
		EndPeriod.Enabled = True
		TPIC.Enabled = True
		BtnProsesPE.Enabled = False
		CSubDivisi.Enabled = True
		BatalTools.Enabled = True
		SimpanPE.Enabled = True
		RevisiPE.Enabled = False
	End Sub
	Private Sub KondisiTampilPE()
		TNoPE.Enabled = False
		TKlien.Enabled = False
		TVenue.Enabled = False
		TJmlEvent.Enabled = False
		TRegion.Enabled = False
		TProject.Enabled = False
		StartPeriod.Enabled = False
		EndPeriod.Enabled = False
		TPIC.Enabled = False
		TTotal.Enabled = False
		TRpPPN.Enabled = False
		TAgencyRP.Enabled = False
		TTotalVAT.Enabled = False
		TAgentFee.Enabled = False
		CKontrak.Enabled = False
		DTTanggal.Enabled = False
		CSubDivisi.Enabled = False
		BtnProsesPE.Enabled = False
		CetakPE.Enabled = True
		SimpanPE.Enabled = True
		RevisiPE.Enabled = False
		BatalTools.Enabled = True
		HapusPE.Enabled = True
		TambahPE.Enabled = False
	End Sub
	Private Sub KondisiBersihPE()
		TidPE.Text = ""
		TAgentFee.Text = "0"
	End Sub
	Private Sub KondisiTambahDetail()
		TBarangCL.Enabled = True
		TQtyCL.Enabled = True
		TSubTotalCL.Enabled = False
		TKetCL.Enabled = True
		TJmlEvnCL.Enabled = True
		BtnInpDetail.Enabled = True
		ListBiayaProject.Enabled = True
	End Sub
	Private Sub KondisiTampilDetail()
		TBarangCL.Enabled = False
		TQtyCL.Enabled = False
		TSubTotalCL.Enabled = False
		TKetCL.Enabled = False
		BtnInpDetail.Enabled = False
		TJmlEvnCL.Enabled = False
		ListBiayaProject.Enabled = False
	End Sub
	Private Sub KondisiBersihDetail()
		TBarangCL.Text = ""
		TidBarangCL.Text = ""
		TQtyCL.Text = "1"
		TSubTotalCL.Text = "0"
		TKetCL.Text = ""
		TJmlEvnCL.Text = "0"
		BtnInpDetail.Enabled = True
	End Sub
	Private Sub KondisiAwalEvn()
		TBarangEvn.Enabled = False
		TQtyEvn.Enabled = False
		CSatFreqEvn.Enabled = False
		CSatQtyEvn.Enabled = False
		TFreqEvn.Enabled = False
		THargaUnitEvn.Enabled = False
		TSubTotalEvn.Enabled = False
		TKetPEvn.Enabled = False
		RevisiPE.Enabled = False
		BatalTools.Enabled = False
		BtnInpEvn.Enabled = False
		BtnSimpanEvn.Enabled = False
		ListBiayaEvn.Enabled = False
	End Sub
	Private Sub KondisiTambahEvn()
		TBarangEvn.Enabled = True
		TQtyEvn.Enabled = True
		CSatFreqEvn.Enabled = True
		CSatQtyEvn.Enabled = True
		TFreqEvn.Enabled = True
		THargaUnitEvn.Enabled = True
		TSubTotalEvn.Enabled = True
		TKetPEvn.Enabled = True
		RevisiPE.Enabled = False
		BatalTools.Enabled = True
		BtnInpEvn.Enabled = True
		BtnSimpanEvn.Enabled = True
		ListBiayaEvn.Enabled = True
	End Sub
	Private Sub KondisiBersihEvn()
		TBarangEvn.Clear()
		TQtyEvn.Clear()
		CSatQtyEvn.Text = ""
		TFreqEvn.Clear()
		CSatFreqEvn.Text = ""
		THargaUnitEvn.Clear()
		TRegionEvn.Text = TJmlEvnCL.Text
		TSubTotalEvn.Text = "0"
		TKetPEvn.Clear()
		idQtyEvn.Clear()
		idFreqEvn.Clear()
		idBarangEvn.Clear()
		TBarangEvn.Select()
	End Sub
	Private Sub KondisiTampilProject()
		TBarangProj.Enabled = False
		TQtyProj.Enabled = False
		TNominalProj.Enabled = False
		TSubTotalProj.Enabled = False
		TSubTotalProj.Enabled = False
		BtnSaveProj.Enabled = False
		ListBiayaProject.Enabled = False
		BtnInpProj.Enabled = False
	End Sub
	Private Sub KondisiEditProject()
		TBarangProj.Enabled = True
		TQtyProj.Enabled = True
		TNominalProj.Enabled = True
		TSubTotalProj.Enabled = True
		TSubTotalProj.Enabled = True
		BtnSaveProj.Enabled = True
		ListBiayaProject.Enabled = True
		BtnInpProj.Enabled = True
	End Sub
	Private Sub KondisiBersihProject()
		TBarangProj.Clear()
		TidBarangProj.Clear()
		TQtyProj.Clear()
		TNominalProj.Clear()
		TTotalProj.EditValue = "0"
		TidSatuanQtyProj.Clear()
		TSubTotalProj.Clear()
		BtnInpProj.Enabled = True
	End Sub
	Private Sub KondisiEditEvn()
		TBarangEvn.Enabled = True
		TQtyEvn.Enabled = True
		CSatQtyEvn.Enabled = True
		TFreqEvn.Enabled = True
		CSatFreqEvn.Enabled = True
		THargaUnitEvn.Enabled = True
		TSubTotalEvn.Enabled = False
		TKetPEvn.Enabled = True
		RevisiPE.Enabled = False
		BatalTools.Enabled = True
		BtnInpEvn.Enabled = True
		BtnSimpanEvn.Enabled = True
		ListBiayaEvn.Enabled = True
	End Sub
	Private Sub KondisiAwalHR()
		TBasicSalaryHR.Enabled = False
		CAdaBPJS.Checked = False
		CSesuaiUMK.Checked = False
		CPotBPJS.Checked = False
		TBpjsMed.Enabled = False
		TBpjsEmp.Enabled = False
		TMeal.Enabled = False
		TMakeUp.Enabled = False
		TTransport.Enabled = False
		TPostAllow.Enabled = False
		TPulse.Enabled = False
		TMeetingCost.Enabled = False
		TAtkHR.Enabled = False
		TRentComp.Enabled = False
		TIncentive.Enabled = False
		TThr.Enabled = False
		TPositionHR.Enabled = False
		TRegionHR.Enabled = False
		TSubColl.Enabled = False
		TTrainingCost.Text = False
		TOvertime.Text = False
		TPotBpjsEmp.Enabled = False
		TPotBpjsMed.Enabled = False
		TTravellingHR.Enabled = False
		TEventHR.Enabled = False
		TTelemarketingHR.Enabled = False
		TTakeHomePay.Enabled = False
		CAreaHR.Enabled = False
		CKotaHR.Enabled = False
		TPeopleHR.Enabled = False
		TPeriodeHR.Enabled = False
		TUmk.Enabled = False
		TPeriodeHR.Enabled = False
		BtnClearHR.Enabled = False
		BtnInpHR.Enabled = False
	End Sub
	Private Sub KondisiTambahHR()
		TBasicSalaryHR.Enabled = True
		TBpjsMed.Enabled = False
		TBpjsEmp.Enabled = False
		TMeal.Enabled = True
		TMakeUp.Enabled = True
		TTransport.Enabled = True
		TPostAllow.Enabled = True
		TPulse.Enabled = True
		TMeetingCost.Enabled = True
		TAtkHR.Enabled = True
		TRentComp.Enabled = True
		TIncentive.Enabled = True
		TThr.Enabled = True
		TPositionHR.Enabled = True
		TRegionHR.Enabled = True
		CAreaHR.Enabled = True
		CKotaHR.Enabled = True
		TPeopleHR.Enabled = True
		TUmk.Enabled = True
		TPotBpjsEmp.Enabled = False
		TPotBpjsMed.Enabled = False
		TTravellingHR.Enabled = True
		TEventHR.Enabled = True
		TSubColl.Enabled = True
		TTrainingCost.Text = True
		TOvertime.Text = True
		TTelemarketingHR.Enabled = True
		TPeriodeHR.Enabled = False
		TTakeHomePay.Enabled = False
		TPeriodeHR.Enabled = True
		BtnClearHR.Enabled = True
		BtnInpHR.Enabled = True
	End Sub
	Private Sub KondisiEditHR()
		TBasicSalaryHR.Enabled = True
		TBpjsMed.Enabled = False
		TBpjsEmp.Enabled = False
		TMeal.Enabled = True
		TMakeUp.Enabled = True
		TTransport.Enabled = True
		TPostAllow.Enabled = True
		TPulse.Enabled = True
		TMeetingCost.Enabled = True
		TAtkHR.Enabled = True
		TRentComp.Enabled = True
		TIncentive.Enabled = True
		TThr.Enabled = True
		TPositionHR.Enabled = True
		TRegionHR.Enabled = True
		TPeopleHR.Enabled = True
		TUmk.Enabled = True
		TSubColl.Enabled = True
		TTrainingCost.Text = True
		TOvertime.Text = True
		TPotBpjsEmp.Enabled = True
		TPotBpjsMed.Enabled = True
		TTravellingHR.Enabled = True
		TEventHR.Enabled = True
		TTelemarketingHR.Enabled = True
		TTakeHomePay.Enabled = False
		TPeriodeHR.Enabled = True
		BtnClearHR.Enabled = False
		BtnInpHR.Enabled = True
	End Sub
	Private Sub KondisiBersihHR()
		TBasicSalaryHR.Text = "0"
		TBpjsMed.Text = "0"
		TBpjsEmp.Text = "0"
		TMeal.Text = "0"
		TMakeUp.Text = "0"
		TTransport.Text = "0"
		TPostAllow.Text = "0"
		TPulse.Text = "0"
		TMeetingCost.Text = "0"
		TAtkHR.Text = "0"
		TRentComp.Text = "0"
		TIncentive.Text = "0"
		TThr.Text = "0"
		TPotBpjsEmp.Text = "0"
		TPotBpjsMed.Text = "0"
		TTravellingHR.Text = "0"
		TEventHR.Text = "0"
		TTelemarketingHR.Text = "0"
		TTakeHomePay.Text = "0"
		TPeriodeHR.Text = "0"
		TSubColl.Text = "0"
		TTrainingCost.Text = "0"
		TOvertime.Text = "0"
		TUangHadir.Text = "0"
		TTahunHR.Text = "0"
		TPositionHR.Text = "0"
		TRegionHR.Text = ""
		CAreaHR.Text = ""
		CKotaHR.Text = ""
		TPeopleHR.Text = "0"
		TUmk.Text = "0"
		TidDetailSDM.Text = ""
	End Sub
#End Region
#Region "List View"
	Private Sub ListHeaderPE()
		With ListPEActivation
			.FullRowSelect = True
			.MultiSelect = False
			.View = View.Details
			.CheckBoxes = True
			.Columns.Clear()
			.Items.Clear()
			.Columns.Add("NO PE", 180, HorizontalAlignment.Left)
			.Columns.Add("CLIENT.", 200, HorizontalAlignment.Left)
			.Columns.Add("PROJECT", 150, HorizontalAlignment.Left)
			.Columns.Add("REGION", 80, HorizontalAlignment.Left)
			.Columns.Add("EVENT", 80, HorizontalAlignment.Left)
			.Columns.Add("PERIODE EVENT", 110, HorizontalAlignment.Left)
			.Columns.Add("GrandTotal", 150, HorizontalAlignment.Left)
			.Columns.Add("TANGGAL PE", 100, HorizontalAlignment.Left)
			.Columns.Add("idpe", 0, HorizontalAlignment.Left)
		End With
	End Sub
	Private Sub BacaPE()
		GGVM_conn()
		ListPEActivation.Items.Clear()
		sql = ""
		sql = sql & "SELECT a.nope,b.nama,c.jenis_pe, a.project,a.venue,a.jmlevent, a.periode,a.region,a.tgl_pe,a.total,a.rp_ppn,a.grandtotal,a.approved_by, a.idpe,a.idsubdivisi "
		sql = sql & "FROM `evn_penawaran`a , klien b , evn_jenis_pe c where a.idklien = b.id And a.idjenis_pe = c.idjenis_pe and c.idjenis_pe = '" & TidJenisPE.Text & "' and a.userid_input = '" & userid & "' "
		da = New OdbcDataAdapter(sql, conn)
		ds = New DataSet
		da.Fill(ds)
		dt = New DataTable
		dt = ds.Tables(0)
		ListPEActivation.BeginUpdate()
		For j As Integer = 0 To dt.Rows.Count - 1
			With ListPEActivation
				.Items.Add(dt.Rows(j)("nope"))
				With .Items(.Items.Count - 1).SubItems
					.Add(dt.Rows(j)("nama"))
					.Add(dt.Rows(j)("project"))
					If dt.Rows(j)("venue") Is DBNull.Value Then
						.Add("-")
					Else
						.Add(dt.Rows(j)("venue"))
					End If
					If dt.Rows(j)("jmlevent") Is DBNull.Value Then
						.Add("-")
					Else
						.Add(dt.Rows(j)("jmlevent"))
					End If
					.Add(dt.Rows(j)("periode"))
					If dt.Rows(j)("grandtotal") Is DBNull.Value Then
						.Add("Belum Ada Detail")
					Else
						.Add(Format(Val(dt.Rows(j)("grandtotal")), "Rp, ###,###"))
					End If
					.Add(dt.Rows(j)("tgl_pe"))
					.Add(dt.Rows(j)("idpe"))
					.Add(dt.Rows(j)("idsubdivisi"))
				End With
			End With
		Next
		ListPEActivation.EndUpdate()
		GGVM_conn_close()
	End Sub
	Private Sub ListHeaderMainDetailPE()
		With ListDetailPEAct
			.FullRowSelect = True
			.MultiSelect = False
			.View = View.Details
			.CheckBoxes = True
			.Columns.Clear()
			.Items.Clear()
			.Columns.Add("PERIODE", 140, HorizontalAlignment.Left)
			.Columns.Add("ITEMS.", 200, HorizontalAlignment.Left)
			.Columns.Add("QTY.", 90, HorizontalAlignment.Left)
			.Columns.Add("SATUAN.", 90, HorizontalAlignment.Left)
			.Columns.Add("UNIT PRICE", 100, HorizontalAlignment.Left)
			.Columns.Add("SUB TOTAL", 100, HorizontalAlignment.Left)
			.Columns.Add("iddetail", 1, HorizontalAlignment.Left)
		End With
	End Sub
	Private Sub BacaMainDetail()
		GGVM_conn()
		sql = ""
		sql = sql & "SELECT a.*,c.subkel, d.periode FROM evn_detail_penawaran a "
		sql = sql & "Join barang_penawaran b ON b.idbarang = a.idbarang "
		sql = sql & " Join subkelompok c on c.idsubkel = b.idsubkel "
		sql = sql & " join evn_penawaran d on d.idpe = a.idpe"
		If CKuartal.Text <> "" Then
			sql = sql & " LEFT JOIN act_kuartal_pe e on e.iddetail = a.iddetail"
		End If
		sql = sql & " where a.idpe = '" & TidPE.Text & "'"
		If CKuartal.Text <> "" Then
			sql = sql & " and e.kuartalke = '" & CKuartal.Text & "'"
		End If
		da = New OdbcDataAdapter(sql, conn)
		ds = New DataSet
		da.Fill(ds)
		dt = New DataTable
		dt = ds.Tables(0)
		ListDetailPEAct.Items.Clear()
		ListDetailPEAct.BeginUpdate()
		For j As Integer = 0 To dt.Rows.Count - 1
			With ListDetailPEAct
				.Items.Add(dt.Rows(j)("periode"))
				With .Items(.Items.Count - 1).SubItems
					.Add(dt.Rows(j)("barang"))
					.Add(dt.Rows(j)("qty"))
					.Add(dt.Rows(j)("satuan_qty"))
					.Add(dt.Rows(j)("unitcost"))
					.Add(dt.Rows(j)("sub_totalcost"))
					.Add(dt.Rows(j)("iddetail"))
				End With
			End With
		Next
		ListDetailPEAct.EndUpdate()
		Call HitungMainDetail()
		GGVM_conn_close()
		conn.Dispose()
	End Sub
	Private Sub ListHeaderEvn()
		With ListBiayaEvn
			.FullRowSelect = True
			.MultiSelect = False
			.View = View.Details
			.CheckBoxes = True
			.Columns.Clear()
			.Items.Clear()
			.Columns.Add("ITEMS", 200, HorizontalAlignment.Left)
			.Columns.Add("QTY.", 55, HorizontalAlignment.Right)
			.Columns.Add("", 60, HorizontalAlignment.Left)
			.Columns.Add("FREQ", 55, HorizontalAlignment.Right)
			.Columns.Add("", 60, HorizontalAlignment.Left)
			.Columns.Add("REGION/EVENT", 140, HorizontalAlignment.Left)
			.Columns.Add("HARGA UNIT", 200, HorizontalAlignment.Left)
			.Columns.Add("SUB TOTAL", 200, HorizontalAlignment.Left)
			.Columns.Add("KETERANGAN", 250, HorizontalAlignment.Left)
			.Columns.Add("idQty", 0, HorizontalAlignment.Left)
			.Columns.Add("idFreq", 0, HorizontalAlignment.Left)
			.Columns.Add("idBarang", 0, HorizontalAlignment.Left)
			.Columns.Add("idPE", 0, HorizontalAlignment.Left)
			.Columns.Add("idDetail", 0, HorizontalAlignment.Left)
			.Columns.Add("idjenis_detail", 0, HorizontalAlignment.Left)
			.Columns.Add("iddetail_act", 0, HorizontalAlignment.Left)
			.Columns.Add("kuartal", 0, HorizontalAlignment.Left)
		End With
	End Sub
	Private Sub BacaDetailBiayaEvn()
		Dim Barang As String
		GGVM_conn()
		sql = ""
		sql = sql & "SELECT a.*,f.subkel FROM act_detail_penawaran a "
		sql = sql & "JOIN barang_penawaran b on a.idbarang = b.idbarang "
		sql = sql & " JOIN evn_detail_penawaran c on a.iddetail = c.iddetail "
		sql = sql & " JOIN evn_penawaran d on a.idpe = d.idpe "
		sql = sql & " JOIN act_jenis_detail e on a.idjenis_detail = e.idjenis_detail "
		sql = sql & " Join subkelompok f on b.idsubkel = f.idsubkel"
		sql = sql & " where a.idpe = '" & TidPE.Text & "' and a.idjenis_detail ='" & TidJenisDetail.Text & "' and a.kuartal = '" & CKuartal.Text & "'"
		cmd = New OdbcCommand(sql, conn)
		dr = cmd.ExecuteReader
		ListBiayaEvn.Items.Clear()
		ListBiayaEvn.BeginUpdate()
		While dr.Read
			Barang = dr.Item("barang")
			strName = dr.Item("subkel")
			Dim lvitem As New ListViewItem(Barang)
			Try
				If ListBiayaEvn.Groups.Item(strName).Header = strName Then
					lvitem.Group = ListBiayaEvn.Groups(strName)
					lvitem.SubItems.Add(dr.Item("qty"))
					lvitem.SubItems.Add(dr.Item("satuan_qty"))
					lvitem.SubItems.Add(dr.Item("freq"))
					lvitem.SubItems.Add(dr.Item("satuan_freq"))
					lvitem.SubItems.Add(dr.Item("region_event"))
					lvitem.SubItems.Add(dr.Item("harga_unit"))
					lvitem.SubItems.Add(dr.Item("subtotal"))
					lvitem.SubItems.Add(dr.Item("keterangan").ToString)
					lvitem.SubItems.Add(dr.Item("idsatuan_qty"))
					lvitem.SubItems.Add(dr.Item("idsatuan_freq"))
					lvitem.SubItems.Add(dr.Item("idbarang"))
					lvitem.SubItems.Add(dr.Item("idpe"))
					lvitem.SubItems.Add(dr.Item("iddetail"))
					lvitem.SubItems.Add(dr.Item("idjenis_detail"))
					lvitem.SubItems.Add(dr.Item("iddetail_act"))
					lvitem.SubItems.Add(dr.Item("kuartal"))
					ListBiayaEvn.Items.Add(lvitem)
				End If
			Catch
				ListBiayaEvn.Groups.Add(New ListViewGroup(strName, strName))
				lvitem.Group = ListBiayaEvn.Groups(strName)
				lvitem.SubItems.Add(dr.Item("qty"))
				lvitem.SubItems.Add(dr.Item("satuan_qty"))
				lvitem.SubItems.Add(dr.Item("freq"))
				lvitem.SubItems.Add(dr.Item("satuan_freq"))
				lvitem.SubItems.Add(dr.Item("region_event"))
				lvitem.SubItems.Add(dr.Item("harga_unit"))
				lvitem.SubItems.Add(dr.Item("subtotal"))
				lvitem.SubItems.Add(dr.Item("keterangan").ToString)
				lvitem.SubItems.Add(dr.Item("idsatuan_qty"))
				lvitem.SubItems.Add(dr.Item("idsatuan_freq"))
				lvitem.SubItems.Add(dr.Item("idbarang"))
				lvitem.SubItems.Add(dr.Item("idpe"))
				lvitem.SubItems.Add(dr.Item("iddetail"))
				lvitem.SubItems.Add(dr.Item("idjenis_detail"))
				lvitem.SubItems.Add(dr.Item("iddetail_act"))
				lvitem.SubItems.Add(dr.Item("kuartal"))
				ListBiayaEvn.Items.Add(lvitem)
			End Try
			Call NominalBiaya()
		End While
		ListBiayaEvn.EndUpdate()
		GGVM_conn_close()
	End Sub
	Private Sub ListHeaderProject()
		With ListBiayaProject
			.FullRowSelect = True
			.MultiSelect = False
			.View = View.Details
			.CheckBoxes = True
			.Columns.Clear()
			.Items.Clear()
			.Columns.Add("BARANG", 180, HorizontalAlignment.Left)
			.Columns.Add("QTY.", 200, HorizontalAlignment.Left)
			.Columns.Add("SATUAN", 150, HorizontalAlignment.Left)
			.Columns.Add("HARGA UNIT", 80, HorizontalAlignment.Left)
			.Columns.Add("SUB TOTAL", 80, HorizontalAlignment.Left)
			.Columns.Add("idbarang", 0, HorizontalAlignment.Left)
			.Columns.Add("idpe", 0, HorizontalAlignment.Left)
			.Columns.Add("iddetail", 0, HorizontalAlignment.Left)
			.Columns.Add("iddetail_act", 0, HorizontalAlignment.Left)
			.Columns.Add("idjenisdetail", 0, HorizontalAlignment.Left)
		End With
	End Sub
	Private Sub BacaDetailProject()
		GGVM_conn()
		sql = ""
		sql = sql & "select * from act_detail_penawaran where idpe = '" & TidPE.Text & "'"
		da = New OdbcDataAdapter(sql, conn)
		ds = New DataSet
		da.Fill(ds)
		dt = New DataTable
		dt = ds.Tables(0)
		ListBiayaProject.Items.Clear()
		ListBiayaProject.BeginUpdate()
		For j As Integer = 0 To dt.Rows.Count - 1
			With ListBiayaProject
				.Items.Add(dt.Rows(j)("barang"))
				With .Items(.Items.Count - 1).SubItems
					.Add(dt.Rows(j)("qty"))
					.Add(dt.Rows(j)("satuan_qty"))
					.Add(dt.Rows(j)("harga_unit"))
					.Add(dt.Rows(j)("subtotal"))
					.Add(dt.Rows(j)("idbarang"))
					.Add(dt.Rows(j)("idsatuan_qty"))
					.Add(dt.Rows(j)("idpe"))
					.Add(dt.Rows(j)("iddetail"))
					.Add(dt.Rows(j)("iddetail_act"))
					.Add(dt.Rows(j)("idjenis_detail"))
				End With
			End With
		Next
		ListBiayaProject.EndUpdate()
		Call NominalBiaya()
		GGVM_conn_close()
	End Sub
	Private Sub BacaDetailHR()
		GGVM_conn()
		DGInputHR.DataSource = Nothing

		sql = ""
		sql = sql & " Select xbrg.* from ( "
		sql = sql & " SELECT e.jabatan as JABATAN,a.basicsalary as 'BASIC SALARY',a.jml_person as 'TOTAL ORANG', a.totalperson_cost as 'TOTAL SALARY',"
		sql = sql & " f.kota as KOTA,g.propinsi, a.iddetail_sdm,a.idkota,a.idregion,a.tahun,a.jml_person,a.gross1,a.gross2,"
		sql = sql & " a.fee, a.ppn, a.pph23,a.thp,a.grandtotal FROM act_detail_sdm a "
		sql = sql & " JOIN evn_detail_penawaran b On a.iddetail = b.iddetail "
		sql = sql & " JOIN act_jenis_detail c On a.idjenis_detail = c.idjenis_detail "
		sql = sql & " JOIN evn_penawaran d On b.idpe = d.idpe"
		sql = sql & " JOIN spg_jabatan e On e.idjabatan = a.idjabatan "
		sql = sql & " JOIN kota f On f.idkota = a.idkota "
		sql = sql & " JOIN propinsi g on g.idpropinsi = f.idpropinsi"
		sql = sql & " WHERE b.idpe = '" & TidPE.Text & "'"
		sql = sql & " order by e.jabatan ) as xbrg"

		da = New OdbcDataAdapter(sql, conn)
		ds = New DataSet
		ds.Clear()
		da.Fill(ds, "xbrg")

		DGInputHR.DataSource = ds.Tables("xbrg")
		DGInputHR.AutoResizeColumns()
		DGInputHR.Columns(0).Width = 120
		DGInputHR.Columns(1).Width = 120
		DGInputHR.Columns(2).Width = 120
		DGInputHR.Columns(3).Width = 120
		DGInputHR.Columns(4).Width = 120
		DGInputHR.Columns(5).Width = 0
		DGInputHR.Columns(6).Width = 0
		DGInputHR.Columns(7).Width = 0
		DGInputHR.Columns(8).Width = 0
		DGInputHR.Columns(9).Width = 0
		DGInputHR.Columns(10).Width = 0
		DGInputHR.Columns(11).Width = 0
		DGInputHR.Columns(12).Width = 0
		DGInputHR.Columns(13).Width = 0
		DGInputHR.Columns(14).Width = 0
		DGInputHR.Columns(15).Width = 0
		DGInputHR.Columns(16).Width = 0
		DGInputHR.Columns(17).Width = 0
		GGVM_conn_close()
		If DGInputHR.RowCount = 1 Then
			'MsgBox("Data tidak ada !!..", MsgBoxStyle.Information, "Information")
			BtnInpHR.Focus()
		End If
		DGInputHR.Refresh()
		DGInputHR.Focus()
	End Sub
#End Region
	Private Sub FrmActPE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Call KondisiAwalPE()
		Call KondisiAwalEvn()
		Call KondisiAwalHR()
		Call ListHeaderPE()
		Call BacaPE()
		Call ListHeaderMainDetailPE()
		Call KondisiTampilDetail()
		If TidJenisPE.Text = "5" Then
			Call ListHeaderEvn()
			Call KondisiBersihEvn()
			PKuartalEventCL.Visible = True
			CxKuartalPE.Enabled = True
		ElseIf TidJenisPE.Text = "6" Then
			Call ListHeaderProject()
			Call KondisiBersihProject()
		ElseIf TidJenisPE.Text = "7" Then
			Call KondisiBersihHR()
		Else
			MsgBox("Terjadi Kesalahan ! Hubungi Administrator")
		End If
	End Sub
	'Header Main Button
	Private Sub TambahPE_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles TambahPE.ItemClick
		Call LoadKlien()
		Call LoadRegion()
		Call LoadVenue()
		Call KondisiBersihPE()
		Call KondisiTambahPE()
		Call LoadSubdivisi()
		Call KondisiTambahDetail()
		Call ComboKontrak()
		If TidJenisPE.Text = "5" Then
			TRegion.Enabled = False
			ProsesPE = "Event"
			KondisiInputEvn = "DataBaru"
			KondisiSimpan = "Event"
			HapusDetailEvent = "Baru"
			Call KondisiEditEvn()
		ElseIf TidJenisPE.Text = "6" Then
			TVenue.Enabled = False
			TJmlEvent.Enabled = False
			TRegion.Enabled = False
			CSubDivisi.Enabled = True
			ProsesPE = "Project"
			KondisiInputProject = "DataBaru"
			KondisiSimpan = "Project"
			HapusDetailProject = "HapusBaru"
			Call KondisiEditProject()
		ElseIf TidJenisPE.Text = "7" Then
			TVenue.Enabled = False
			TJmlEvent.Enabled = False
			ProsesPE = "Instore"
			KondisiInputHR = "DataBaru"
			KondisiSimpan = "InStore"
			HitungNominal = "NominalInstore"
			Call KondisiTambahHR()
		End If
	End Sub
	Private Sub RevisiPE_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles RevisiPE.ItemClick
		Call KondisiTambahDetail()
		Call KondisiEditPE()
		Call LoadKlien()
		Call LoadSubdivisi()
		If TidJenisPE.Text = "5" Then
			TRegion.Enabled = False
			HapusDetailEvent = "HapusRevisi"
			KondisiInputEvn = "RevisiData"
			KondisiSimpan = "Revisi"
			KondisiSimpanAlasan = "Event"
			Call KondisiEditEvn()
			Call LoadSubkel()
			Call LoadJenisDetail()
			Call LoadBarangEvn()
			Call LoadBarangCL()
		ElseIf TidJenisPE.Text = "6" Then
			TVenue.Enabled = False
			TJmlEvent.Enabled = False
			TRegion.Enabled = False
			HapusDetailProject = "HapusRevisi"
			KondisiInputProject = "RevisiData"
			KondisiSimpan = "Revisi"
			KondisiSimpanAlasan = "Project"
			Call KondisiEditProject()
			Call LoadSatuan()
			Call LoadItemProject()
			Call LoadBarangCL()
		ElseIf TidJenisPE.Text = "7" Then
			TVenue.Enabled = False
			TJmlEvent.Enabled = False
			KondisiSimpan = "Revisi"
			KondisiSimpanAlasan = "InStore"
			KondisiInputHR = "RevisiData"
			Call LoadRegion()
			Call LoadJabatan()
			Call LoadPropinsi()
			Call LoadBarangCL()
		Else
			Return
		End If
	End Sub
	Private Sub HapusPE_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles HapusPE.ItemClick
		Dim jmldt As Integer = 0
		Dim brs As Integer
		ListPEActivation.BeginUpdate()
		Dim I As Integer
		For I = ListPEActivation.Items.Count - 1 To 0 Step -1
			If ListPEActivation.Items(I).Checked = True Then
				brs = I
				jmldt = jmldt + 1
				If jmldt > 1 Then
					MsgBox("Hanya 1(satu) Penawaran yg bisa di-HAPUS !!...", MsgBoxStyle.Information, "Information")
					ListPEActivation.Focus()
					Exit Sub
				Else
					For Each item As ListViewItem In ListPEActivation.CheckedItems
						GGVM_conn()
						sql = " update evn_penawaran set userid_delete= '" & userid & "', timedelete=now() where idpe = '" & item.SubItems(8).Text & "'"
						cmd = New OdbcCommand(sql, conn)
						cmd.ExecuteNonQuery()

						Dim sql1, sql2, sql3, sql4, sql5, sql6 As String
						sql1 = "insert into evn_buffer_penawaran select * from evn_penawaran where idpe = ? "
						cmd = New OdbcCommand
						With cmd
							.CommandText = (sql1)
							.Parameters.Add("@idpe", OdbcType.BigInt).Value = Convert.ToInt32(item.SubItems(8).Text)
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

						sql2 = "insert into evn_tmp_dp select * from evn_detail_penawaran where idpe = ? "
						cmd = New OdbcCommand
						With cmd
							.CommandText = (sql2)
							.Parameters.Add("@idpe", OdbcType.BigInt).Value = Convert.ToInt32(item.SubItems(8).Text)
							.Connection = conn
						End With
						dr = cmd.ExecuteReader
						Console.WriteLine(cmd.CommandText.ToString)
						While dr.Read
							Console.WriteLine(dr(0))
							Console.WriteLine()
						End While
						Console.ReadLine()

						sql3 = "insert into act_dp_temp select * from act_detail_penawaran where idpe = ? "
						cmd = New OdbcCommand
						With cmd
							.CommandText = (sql3)
							.Parameters.Add("@idpe", OdbcType.BigInt).Value = Convert.ToInt32(item.SubItems(8).Text)
							.Connection = conn
						End With
						dr = cmd.ExecuteReader
						Console.WriteLine(cmd.CommandText.ToString)
						While dr.Read
							Console.WriteLine(dr(0))
							Console.WriteLine()
						End While
						Console.ReadLine()

						sql4 = "DELETE FROM subdivisi WHERE idsubdivisi = ? "
						cmd = New OdbcCommand
						With cmd
							.CommandText = (sql4)
							.Parameters.Add("@idsubdivisi", OdbcType.BigInt).Value = Convert.ToInt32(item.SubItems(9).Text)
							.Connection = conn
						End With
						dr = cmd.ExecuteReader
						Console.WriteLine(cmd.CommandText.ToString)
						While dr.Read
							Console.WriteLine(dr(0))
							Console.WriteLine()
						End While
						Console.ReadLine()

						sql5 = "DELETE FROM act_detail_penawaran WHERE idpe = ? "
						cmd = New OdbcCommand
						With cmd
							.CommandText = (sql5)
							.Parameters.Add("@idpe", OdbcType.BigInt).Value = Convert.ToInt32(item.SubItems(8).Text)
							.Connection = conn
						End With
						dr = cmd.ExecuteReader
						Console.WriteLine(cmd.CommandText.ToString)
						While dr.Read
							Console.WriteLine(dr(0))
							Console.WriteLine()
						End While
						Console.ReadLine()

						sql6 = "DELETE FROM evn_penawaran WHERE idpe = ?"
						cmd = New OdbcCommand
						With cmd
							.CommandText = (sql6)
							.Parameters.Add("@idpe", OdbcType.BigInt).Value = Convert.ToInt32(item.SubItems(8).Text)
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
						Call KondisiBersihPE()
						Call KondisiAwalPE()
					Next
				End If
			End If
		Next I
		Call BacaPE()
		Call KondisiBersihPE()
		Call KondisiAwalPE()
		ListPEActivation.EndUpdate()
	End Sub
	Private Sub SimpanPE_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SimpanPE.ItemClick
		Dim c As String
		Select Case KondisiSimpan
			Case "Event"
				Call BacaMainDetail()
				Call HitungMainDetail()
				MsgBox("Data Telah diSimpan !", MsgBoxStyle.Information, "Information")

				Call SimpanTotalPE()

				Call BacaPE()
				Call KondisiBersihPE()
				GGVM_conn_close()
			Case "Project"
				For Each item As ListViewItem In ListBiayaProject.Items
					GGVM_conn()
					sql = ""
					sql = sql & "insert act_detail_penawaran (barang,qty,satuan_qty,harga_unit,subtotal,idbarang,idsatuan_qty,idpe,iddetail,idjenis_detail) "
					sql = sql & " values (?,?,?,?,?,?,?,?,?,?)"
					cmd = New OdbcCommand
					With cmd
						.CommandText = (sql)
						.Parameters.Add("@brg", OdbcType.VarChar).Value = item.Text
						.Parameters.Add("@qty", OdbcType.Double).Value = Convert.ToDouble(item.SubItems(1).Text)
						.Parameters.Add("@satqty", OdbcType.VarChar).Value = item.SubItems(2).Text
						.Parameters.Add("@hargaunit", OdbcType.Double).Value = item.SubItems(3).Text
						.Parameters.Add("@subtotal", OdbcType.Double).Value = Convert.ToInt32(item.SubItems(4).Text)
						.Parameters.Add("@idbarang", OdbcType.BigInt).Value = Convert.ToInt32(item.SubItems(5).Text)
						.Parameters.Add("@idsatuan", OdbcType.BigInt).Value = Convert.ToInt32(item.SubItems(6).Text)
						.Parameters.Add("@idpe", OdbcType.BigInt).Value = Convert.ToInt32(item.SubItems(7).Text)
						.Parameters.Add("@iddetail", OdbcType.BigInt).Value = Convert.ToInt32(item.SubItems(8).Text)
						.Parameters.Add("@idjenisdetail", OdbcType.Int).Value = Convert.ToInt32(item.SubItems(9).Text)
						.Connection = conn
					End With
					dr = cmd.ExecuteReader
					Console.WriteLine(cmd.CommandText.ToString)
					While dr.Read
						Console.WriteLine(dr(0))
						Console.WriteLine()
					End While
					Console.ReadLine()
					' conn.Close()
					dr = Nothing
					cmd = Nothing
				Next

				c = ""
				c = c & "update evn_detail_penawaran set unitcost = '" & TTotalEvn.EditValue & "',sub_totalcost = '" & TTotalEvn.EditValue & "'"
				c = c & "where iddetail = '" & TidDetailCL.Text & "'"
				cmd = New OdbcCommand(c, conn)
				cmd.ExecuteNonQuery()

				Call BacaMainDetail()
				Call HitungMainDetail()

				MsgBox("Data Telah diSimpan !", MsgBoxStyle.Information, "Information")
				Call SimpanTotalPE()
				Call BacaPE()
				Call KondisiBersihPE()
				GGVM_conn_close()
			Case "InStore"
				GGVM_conn()
				sql = ""
				sql = sql & " update evn_detail_penawaran set unitcost = '" & TGrandTotalHR.Text & "',sub_totalcost= '" & TGrandTotalHR.Text & "'"
				sql = sql & " where iddetail = '" & TidDetailCL.Text & "'"
				cmd = New OdbcCommand(sql, conn)
				cmd.ExecuteNonQuery()

				Call BacaMainDetail()
				Call HitungMainDetail()

				c = ""
				c = c & "update evn_penawaran set total = '" & TTotalCostCL.Text & "',agent_fee = '" & TAgentFeeCL.Text & "',rp_ppn = '" & TRpPPNCL.Text & "',"
				c = c & " rp_pph23 = '" & TPph23CL.Text & "',grandtotal = '" & TGrandTotalCL.Text & "'"
				c = c & "where idpe = '" & TidPE.Text & "'"
				cmd = New OdbcCommand(c, conn)
				cmd.ExecuteNonQuery()
				MsgBox("Data Telah diSimpan !", MsgBoxStyle.Information, "Information")
				Call BacaPE()
				GGVM_conn_close()
			Case "Revisi"
				Try
					NavigationFrame1.SelectedPage = NavBuatPE
					PAlasan.Visible = True
					If TidJenisDetail.Text = "5" Then
						KondisiSimpanAlasan = "Event"
					ElseIf TidJenisDetail.Text = "6" Then
						KondisiSimpanAlasan = "Project"
					ElseIf TidJenisDetail.Text = "7" Then
						KondisiSimpanAlasan = "Instore"
					End If
				Catch ex As Exception
					MsgBox("Terjadi kesalahan! " & ex.Message)
				End Try
			Case "KuartalPE"
				GGVM_conn()
				Dim total, agentfee, ppn, pph, grandtotal As Integer

				Call SimpanEvent()

				c = ""
				c = c & "update evn_detail_penawaran set unitcost = '" & TTotalEvn.EditValue & "',sub_totalcost = '" & TTotalEvn.EditValue & "'"
				c = c & "where iddetail = '" & TidDetailCL.Text & "'"
				cmd = New OdbcCommand(c, conn)
				cmd.ExecuteNonQuery()

				Call BacaMainDetail()
				Call HitungMainDetail()

				sql = "select total,agent_fee,rp_ppn,rp_pph23,grandtotal from evn_penawaran where idpe = '" & TidPE.Text & "' "
				da = New OdbcDataAdapter(sql, conn)
				dt = New DataTable
				da.Fill(dt)
				If dt.Rows.Count > 0 Then
					total = dt.Rows(0)("total")
					agentfee = dt.Rows(0)("agent_fee")
					ppn = dt.Rows(0)("rp_ppn")
					pph = dt.Rows(0)("rp_pph23")
					grandtotal = dt.Rows(0)("grandtotal")
				Else
					total = "0"
					agentfee = "0"
					ppn = "0"
					pph = "0"
					grandtotal = "0"
				End If

				total = total + Val(TTotalCostCL.Text)
				agentfee = agentfee + Val(TAgentFeeCL.Text)
				ppn = ppn + Val(TRpPPNCL.Text)
				pph = pph + Val(TPph23CL.Text)
				grandtotal = grandtotal + Val(TGrandTotalCL.Text)

				MsgBox("Data Telah diSimpan !", MsgBoxStyle.Information, "Information")

				sql = ""
				sql = sql & "update evn_penawaran set total = '" & total & "',"
				If CekFee.Checked = True Then
					sql = sql & " agent_fee ='" & agentfee & "' ,"
				End If
				If CekPPN.Checked = True Then
					sql = sql & "rp_ppn = '" & ppn & "',"
				End If
				If CekPPH.Checked = True Then
					sql = sql & "rp_pph23= '" & pph & "'"
				End If
				sql = sql & "grandtotal = '" & grandtotal & "',"
				sql = sql & " userid_input = '" & userid & "'"
				sql = sql & " where idpe = '" & TidPE.Text & "'"
				cmd = New OdbcCommand(sql, conn)
				cmd.ExecuteNonQuery()
				GGVM_conn_close()
		End Select
	End Sub
	Private Sub BtnProsesPE_Click(sender As Object, e As EventArgs) Handles BtnProsesPE.Click
		'Dim s As String
		GGVM_conn()
		If TidKlien.Text = "" Then
			MsgBox("Pilih Nama Klien!", MsgBoxStyle.Critical, "Message !!")
			Exit Sub
		ElseIf TProject.Text = "" Then
			MsgBox("Masukkan Nama Project !", MsgBoxStyle.Critical, "Message !!")
			Exit Sub
		ElseIf TAgentFee.Text = "0" Then
			MsgBox("Masukkan Agent Fee !", MsgBoxStyle.Critical, "Message !!")
			Exit Sub
		Else
			Call TanggalEvent()
			Dim PeriodeHR As String
			sql = " Select a.nope_activation, a.thnpe_event, b.nama , b.id_divisi from counter a, divisi b where b.id_divisi = '" & DivUser & "' "
			cmd = New OdbcCommand(sql, conn)
			dr = cmd.ExecuteReader
			dr.Read()
			thn = Microsoft.VisualBasic.Right(DTTanggal.Text, 4)
			If thn = dr.GetString(1) Then
				count = dr.Item("nope_activation")
			Else
				count = 0
			End If
			count = count + 1
			divisiid = dr.GetString(3)
			divisiid = Microsoft.VisualBasic.Right("0" & divisiid, 2)
			urutpe = Microsoft.VisualBasic.Right("0000" & count, 4)

			bln = bulan(DTTanggal.Text)
			thn = Microsoft.VisualBasic.Right(DTTanggal.Text, 4)
			urutpe = urutpe + "/GGVM-" + divisiid + "/" + bln + "/" + thn

			c = ""
			c = c & " update counter set nope_activation = '" & count & "',"
			c = c & " thnpe_event = '" & Microsoft.VisualBasic.Right(DTTanggal.Text, 4) & "'"
			cmd = New OdbcCommand(c, conn)
			cmd.ExecuteNonQuery()

			Select Case ProsesPE
				Case "Event"
					sql = ""
					sql = sql & "insert evn_penawaran (nope,idklien,idjenis_pe,project,"
					sql = sql & "venue,jmlevent,"
					If TPIC.Text <> "" Then
						sql = sql & "approved_by,"
					End If
					sql = sql & "tgl_pe,userid_input,timeinput,iddivisi,"
					sql = sql & "start_event,end_event,periode,periode_start,periode_end) "
					sql = sql & " values ('" & urutpe & "','" & TidKlien.Text & "','" & TidJenisPE.Text & "','" & TProject.Text & "',"
					sql = sql & "'" & TVenue.Text & "','" & TJmlEvent.Text & "',"
					If TPIC.Text <> "" Then
						sql = sql & "'" & TPIC.Text & "',"
					End If
					sql = sql & "'" & Format(DTTanggal.Value, "yyyy/MM/dd") & "','" & userid & "',now(),'" & DivUser & "',"
					sql = sql & "'" & Format(StartPeriod.Value, "yyyy/MM/dd") & "','" & Format(EndPeriod.Value, "yyyy/MM/dd") & "','" & tglevent & "','" & Format(StartPeriod.Value, "yyyyMM") & "','" & Format(EndPeriod.Value, "yyyyMM") & "')"
					cmd = New OdbcCommand(sql, conn)
					cmd.ExecuteNonQuery()
					If TidSubdivisi.Text = "" Then
						c = ""
						c = c & "insert subdivisi (id_divisi,subdivisi)"
						c = c & "values ('18', 'ACTIVATION' ' ' '" & TProject.Text & "')"
						cmd = New OdbcCommand(c, conn)
						cmd.ExecuteNonQuery()

						c = ""
						c = c & " Select max(idsubdivisi) As id from subdivisi "
						da = New OdbcDataAdapter(c, conn)
						dt = New DataTable
						da.Fill(dt)
						If dt.Rows.Count > 0 Then
							TidSubdivisi.Text = dt.Rows(0)("id")
						End If

						sql = ""
						sql = sql & "update subdivisi set fee = '" & TAgentFee.Text & "'"
						sql = sql & " where subdivisi = '" & CSubDivisi.Text & "'"
						cmd = New OdbcCommand(sql, conn)
						cmd.ExecuteNonQuery()
					End If

					MsgBox("Data berhasil di Simpan !!", MsgBoxStyle.Information, "Pemberitahuan !!")
					Dim idno As Integer
					c = ""
					c = c & " Select max(idpe)As id from evn_penawaran "
					da = New OdbcDataAdapter(c, conn)
					dt = New DataTable
					da.Fill(dt)
					If dt.Rows.Count > 0 Then
						idno = dt.Rows(0)("id")
					End If

					c = ""
					c = c & "update evn_penawaran set idsubdivisi = '" & TidSubdivisi.Text & "'"
					c = c & " where idpe = '" & idno & "'"
					cmd = New OdbcCommand(c, conn)
					cmd.ExecuteNonQuery()

					TidPE.Text = idno

					Call KondisiTampilPE()
					Call BacaPE()

					With NavigationFrame1
						.SelectedPage = NavDetailPE
						With DetailEvent
							.PageVisible = True
							Call ListHeaderEvn()
						End With
					End With
					HitungNominal = "NominalEvent"
				Case "Project"
					sql = ""
					sql = sql & "insert evn_penawaran (nope,idklien,idjenis_pe,project,"
					sql = sql & "tgl_pe,userid_input,timeinput,iddivisi,"
					sql = sql & "start_event,end_event,periode,periode_start,periode_end) "
					sql = sql & " values ('" & urutpe & "','" & TidKlien.Text & "','" & TidJenisPE.Text & "','" & TProject.Text & "',"
					sql = sql & "'" & Format(DTTanggal.Value, "yyyy/MM/dd") & "','" & userid & "',now(),'" & DivUser & "',"
					sql = sql & "'" & Format(StartPeriod.Value, "yyyy/MM/dd") & "','" & Format(EndPeriod.Value, "yyyy/MM/dd") & "','" & tglevent & "','" & Format(StartPeriod.Value, "yyyyMM") & "','" & Format(EndPeriod.Value, "yyyyMM") & "')"
					cmd = New OdbcCommand(sql, conn)
					cmd.ExecuteNonQuery()

					If TidSubdivisi.Text = "" Then
						c = ""
						c = c & "insert subdivisi (id_divisi,subdivisi)"
						c = c & "values ('18', 'ACTIVATION' ' ' '" & TProject.Text & "')"
						cmd = New OdbcCommand(c, conn)
						cmd.ExecuteNonQuery()

						c = ""
						c = c & " Select max(idsubdivisi) As id from subdivisi "
						da = New OdbcDataAdapter(c, conn)
						dt = New DataTable
						da.Fill(dt)
						If dt.Rows.Count > 0 Then
							TidSubdivisi.Text = dt.Rows(0)("id")
						End If

						sql = ""
						sql = sql & "update subdivisi set fee = '" & TAgentFee.Text & "'"
						sql = sql & " where idsubdivisi = '" & TidSubdivisi.Text & "'"
						cmd = New OdbcCommand(sql, conn)
						cmd.ExecuteNonQuery()
					End If

					MsgBox("Data berhasil di Simpan !!", MsgBoxStyle.Information, "Pemberitahuan !!")

					c = ""
					c = c & " Select max(idpe)As id from evn_penawaran "
					da = New OdbcDataAdapter(c, conn)
					dt = New DataTable
					da.Fill(dt)
					If dt.Rows.Count > 0 Then
						TidPE.Text = dt.Rows(0)("id")
					End If

					c = ""
					c = c & "update evn_penawaran set idsubdivisi = '" & TidSubdivisi.Text & "'"
					c = c & " where idpe = '" & TidPE.Text & "'"
					cmd = New OdbcCommand(c, conn)
					cmd.ExecuteNonQuery()

					Call KondisiTampilPE()
					Call BacaPE()

					With NavigationFrame1
						.SelectedPage = NavDetailPE
						With DetailProject
							.PageVisible = True
							Call ListHeaderProject()
						End With
					End With
					HitungNominal = "NominalProject"
				Case "Instore"
					PeriodeHR = monthDifference(StartPeriod.Value, EndPeriod.Value)
					TPeriodeHR.Text = PeriodeHR

					sql = ""
					sql = sql & "insert evn_penawaran (nope,idklien,idjenis_pe,project,"
					If TRegion.Text <> "" Then
						sql = sql & "region,"
					End If
					sql = sql & "tgl_pe,userid_input,timeinput,iddivisi,"
					sql = sql & "start_event,end_event,periode,periode_start,periode_end) "
					sql = sql & " values ('" & urutpe & "','" & TidKlien.Text & "','" & TidJenisPE.Text & "','" & TProject.Text & "',"
					If TRegion.Text <> "" Then
						sql = sql & "'" & TRegion.Text & "',"
					End If
					sql = sql & "'" & Format(DTTanggal.Value, "yyyy/MM/dd") & "','" & userid & "',now(),'" & DivUser & "',"
					sql = sql & "'" & Format(StartPeriod.Value, "yyyy/MM/dd") & "','" & Format(EndPeriod.Value, "yyyy/MM/dd") & "','" & tglevent & "','" & Format(StartPeriod.Value, "yyyyMM") & "','" & Format(EndPeriod.Value, "yyyyMM") & "')"
					cmd = New OdbcCommand(sql, conn)
					cmd.ExecuteNonQuery()

					c = ""
					c = c & "insert subdivisi (id_divisi,subdivisi)"
					c = c & "values ('3', 'ACTIVATION' ' ' '" & TProject.Text & "')"
					cmd = New OdbcCommand(c, conn)
					cmd.ExecuteNonQuery()

					c = ""
					c = c & " Select max(idsubdivisi) As id from subdivisi "
					da = New OdbcDataAdapter(c, conn)
					dt = New DataTable
					da.Fill(dt)
					If dt.Rows.Count > 0 Then
						TidSubdivisi.Text = dt.Rows(0)("id")
					End If

					sql = ""
					sql = sql & "update subdivisi set fee = '" & TAgentFee.Text & "'"
					sql = sql & " where idsubdivisi = '" & TidSubdivisi.Text & "'"
					cmd = New OdbcCommand(sql, conn)
					cmd.ExecuteNonQuery()

					MsgBox("Data berhasil di Simpan !!", MsgBoxStyle.Information, "Pemberitahuan !!")

					c = ""
					c = c & " Select max(idpe)As id from evn_penawaran "
					da = New OdbcDataAdapter(c, conn)
					dt = New DataTable
					da.Fill(dt)
					If dt.Rows.Count > 0 Then
						TidPE.Text = dt.Rows(0)("id")
					End If

					c = ""
					c = c & "update evn_penawaran set idsubdivisi = '" & TidSubdivisi.Text & "'"
					c = c & " where idpe = '" & TidPE.Text & "'"
					cmd = New OdbcCommand(c, conn)
					cmd.ExecuteNonQuery()

					Call KondisiTampilPE()
					Call BacaPE()

					With NavigationFrame1
						.SelectedPage = NavDetailPE
						CekPPH.Checked = True
						CekPPN.Checked = True
						With DetailInstore
							.PageVisible = True
							Call LoadRegion()
							Call LoadKota()
							Call LoadJabatan()
						End With
					End With
			End Select
		End If
		Call KondisiTambahDetail()
		Call LoadBarangCL()
		Call ListHeaderMainDetailPE()
		RibbonControl.SelectedPage = DetailPanel
		GGVM_conn_close()
	End Sub
	Private Sub BatalTools_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BatalTools.ItemClick
		Call KondisiAwalPE()
		' Call BersihHeaderPE()
		Call KondisiBersihEvn()
		Call KondisiBersihProject()
		Call KondisiBersihHR()
		Call KondisiBersihDetail()
	End Sub
	Private Sub CetakPE_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles CetakPE.ItemClick
		Dim f As New FrmCetak
		Dim ada As Boolean
		Dim jmldt As Integer = 0
		Dim brs As Integer
		'ListPE.BeginUpdate()
		With ListPEActivation
			For i = 0 To ListPEActivation.Items.Count - 1
				If ListPEActivation.Items(i).Checked = True Then
					ada = True
					brs = i
					jmldt = jmldt + i

					If ada = False Then
						MsgBox("Tidak ada data SURAT JALAN yang akan di-CETAK, Pilih dulu datanya!!...", MsgBoxStyle.Information, "Information")
						ListPEActivation.Focus()
						Exit Sub
					ElseIf jmldt > 1 Then
						MsgBox("Hanya 1(satu) data SURAT JALAN yg bisa di-CETAK !!...", MsgBoxStyle.Information, "Information")
						ListPEActivation.Focus()
						Exit Sub
					Else
						For Each item As ListViewItem In ListPEActivation.CheckedItems
							If item.Checked Then
								.CheckedItems.Item(brs).Checked = True
							End If
							CetakIdPE = item.SubItems(8).Text
						Next
						If TidJenisPE.Text = "5" Then
							ProsesCetak = "event"
						ElseIf TidJenisPE.Text = "6" Then
							ProsesCetak = "project"
						ElseIf TidJenisPE.Text = "7" Then
							ProsesCetak = "instore"
						Else
							MsgBox("Gagal Cetak !" & MsgBoxStyle.Critical)
						End If
					End If
				End If
			Next
		End With
		f.ShowDialog()
	End Sub
	Private Sub BtnKeluar_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnKeluar.ItemClick
		Me.Close()
	End Sub
	'Detail Button
	Private Sub BtnInpDetail_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnInpDetail.ItemClick
		Dim s, c, kd As String
		If TidBarangCL.Text = "" Then
			GGVM_conn()
			sql = ""
			sql = sql & "select * from barang_penawaran where barang = '" & TBarangCL.Text & "'"
			cmd = New OdbcCommand(sql, conn)
			dr = cmd.ExecuteReader
			dr.Read()
			If Not dr.HasRows = True Then
				If MsgBox("Barang Belum Ada !, data ingin disimpan??", MsgBoxStyle.Information Or MsgBoxStyle.YesNo, "Pemberitahuan !!") = MsgBoxResult.Yes Then
					'Masukkan ke Table Barang
					s = ""
					s = s & "insert barang_penawaran (idsubkel,barang,"
					s = s & "idsatuan,"
					s = s & "harga_pe)"
					s = s & "values ('110','" & TBarangCL.Text & "',"
					s = s & "'1',"
					s = s & "'0')"
					cmd = New OdbcCommand(s, conn)
					cmd.ExecuteNonQuery()

					'Count Kode Barang
					s = ""
					s = s & " Select max(idbarang)As id from barang_penawaran "
					cmd = New OdbcCommand(s, conn)
					dr = cmd.ExecuteReader
					dr.Read()
					kd = "00000" + dr.GetString(0)
					kd = Microsoft.VisualBasic.Right(kd, 6)
					TidBarangCL.Text = dr.Item("id")

					'Fill ID Barang
					sql = ""
					sql = sql & " Select max(idbarang)As id from barang_penawaran "
					da = New OdbcDataAdapter(sql, conn)
					dt = New DataTable
					da.Fill(dt)
					If dt.Rows.Count > 0 Then
						TidBarangCL.Text = dt.Rows(0)("id")
					End If

					'Fill Kode Barang
					c = ""
					c = c & " update barang_penawaran Set"
					c = c & " kdbarang ='" & kd & "'"
					c = c & " where idbarang ='" & TidBarangCL.Text & "'"
					cmd = New OdbcCommand(c, conn)
					cmd.ExecuteNonQuery()

					If TidJenisPE.Text = "5" Then
						sql = "insert act_jenis_detail (jenis_detail,iddivisi) values ('" & TBarangCL.Text & "', '" & DivUser & "')"
						cmd = New OdbcCommand(sql, conn)
						cmd.ExecuteNonQuery()
					End If

					Call InputMainDetail()
					Call BacaMainDetail()
					GGVM_conn_close()
				Else
					Return
				End If
			Else
				Return
			End If
		ElseIf TidBarangCL.Text <> "" Then
			'Jika Barang Sudah Ada Langsung Input
			Call InputMainDetail()
			Call BacaMainDetail()
		Else
			'Jika Tidak ada yang Sesuai akan Mengeluarkan Pesan Error
			MsgBox("Terjadi Kesalahan Input", MsgBoxStyle.Critical, "Message !!")
			GGVM_conn_close()
		End If
	End Sub
	Private Sub BtnInpEvn_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnInpEvn.ItemClick
		PInpEvent.Visible = True
		Call LoadSubkel()
		Call LoadJenisDetail()
		Call LoadSatuan()
		Call LoadBarangEvn()
		BtnInpEvn.Enabled = False
		BtnSimpanEvn.Enabled = False
	End Sub
	Private Sub BInputEvn_Click(sender As Object, e As EventArgs) Handles BInputEvn.Click
		'Dim c As String
		GGVM_conn()
		If Me.TQtyEvn.Text = "" Then
			MsgBox("Masukkan Qty !", MsgBoxStyle.Critical, "Message !!")
			Exit Sub
		ElseIf THargaUnitEvn.Text = "" Then
			MsgBox("Masukkan Harga Unit!", MsgBoxStyle.Critical, "Message !!")
			Exit Sub
		ElseIf idQtyEvn.Text = "" Then
			MsgBox("Pilih Satuan Qty!", MsgBoxStyle.Critical, "Message !!")
			Exit Sub
		ElseIf idFreqEvn.Text = "" Then
			MsgBox("Pilih Satuan Freq!", MsgBoxStyle.Critical, "Message !!")
			Exit Sub
		ElseIf idBarangEvn.Text = "" Then
			MsgBox("Masukkan Barang !", MsgBoxStyle.Critical, "Message !!")
			Exit Sub
		ElseIf TSubTotalEvn.Text = "" Then
			TSubTotalEvn.Text = Val(CDbl(TQtyEvn.Text)) * Val(CDbl(TFreqEvn.Text)) * Val(CDbl(TRegionEvn.Text)) * Val(CDbl(THargaUnitEvn.Text))
			FormatNumber(TSubTotalEvn, 0, TriState.False)
		Else
			Select Case KondisiInputEvn
				Case "DataBaru"
					If Me.BInputEvn.Text = "Tambahkan" Then
						Dim groupName As String = CSubkelEvn.Text
						Dim newItem As New ListViewItem(TBarangEvn.Text)
						Try
							If ListBiayaEvn.Groups.Item(groupName).Header = groupName Then
								'already exists, add to existing group.
								newItem.Group = ListBiayaEvn.Groups(groupName)
								newItem.SubItems.Add(TQtyEvn.Text)
								newItem.SubItems.Add(CSatQtyEvn.Text)
								newItem.SubItems.Add(TFreqEvn.Text)
								newItem.SubItems.Add(CSatFreqEvn.Text)
								newItem.SubItems.Add(TRegionEvn.Text)
								newItem.SubItems.Add(THargaUnitEvn.Text)
								newItem.SubItems.Add(TSubTotalEvn.Text)
								newItem.SubItems.Add(TKetPEvn.Text)
								newItem.SubItems.Add(idQtyEvn.Text)
								newItem.SubItems.Add(idFreqEvn.Text)
								newItem.SubItems.Add(idBarangEvn.Text)
								newItem.SubItems.Add(TidPE.Text)
								newItem.SubItems.Add(TidDetailCL.Text)
								newItem.SubItems.Add(TidJenisDetail.Text)
								newItem.SubItems.Add(TidDetailActEvn.Text)
								newItem.SubItems.Add(TQuartalPE.EditValue)
								ListBiayaEvn.Items.Add(newItem)
								Call NominalBiaya()
								Call KondisiBersihEvn()
							End If
						Catch
							'doesn't exist, create group and add item to it.
							ListBiayaEvn.Groups.Add(New ListViewGroup(groupName, groupName))
							newItem.Group = ListBiayaEvn.Groups(groupName)
							newItem.SubItems.Add(TQtyEvn.Text)
							newItem.SubItems.Add(CSatQtyEvn.Text)
							newItem.SubItems.Add(TFreqEvn.Text)
							newItem.SubItems.Add(CSatFreqEvn.Text)
							newItem.SubItems.Add(TRegionEvn.Text)
							newItem.SubItems.Add(THargaUnitEvn.Text)
							newItem.SubItems.Add(TSubTotalEvn.Text)
							newItem.SubItems.Add(TKetPEvn.Text)
							newItem.SubItems.Add(idQtyEvn.Text)
							newItem.SubItems.Add(idFreqEvn.Text)
							newItem.SubItems.Add(idBarangEvn.Text)
							newItem.SubItems.Add(TidPE.Text)
							newItem.SubItems.Add(TidDetailCL.Text)
							newItem.SubItems.Add(TidJenisDetail.Text)
							newItem.SubItems.Add(TidDetailActEvn.Text)
							newItem.SubItems.Add(TQuartalPE.EditValue)
							ListBiayaEvn.Items.Add(newItem)
							Call NominalBiaya()

						End Try
					Else
						With Me.ListBiayaEvn.SelectedItems(0).SubItems
							.Item(0).Text = TBarangEvn.Text
							.Item(1).Text = TQtyEvn.Text
							.Item(2).Text = CSatQtyEvn.Text
							.Item(3).Text = TFreqEvn.Text
							.Item(4).Text = CSatFreqEvn.Text
							.Item(5).Text = TRegionEvn.Text
							.Item(6).Text = THargaUnitEvn.Text
							.Item(7).Text = TSubTotalEvn.Text
							.Item(8).Text = TKetPEvn.Text
							.Item(9).Text = idQtyEvn.Text
							.Item(10).Text = idFreqEvn.Text
							.Item(11).Text = idBarangEvn.Text
							.Item(12).Text = TidPE.Text
							.Item(13).Text = TidDetailCL.Text
							.Item(14).Text = TidJenisDetail.Text
							.Item(15).Text = TidDetailActEvn.Text
							.Item(16).Text = TQuartalPE.EditValue
						End With
					End If
					Call KondisiBersihEvn()
				Case "RevisiData"
					If Me.BInputEvn.Text = "Tambahkan" Then
						GGVM_conn()
						sql = ""
						sql = sql & "insert into act_detail_penawaran (barang, qty, satuan_qty, freq, satuan_freq, region_event, harga_unit, subtotal, keterangan, idsatuan_qty, idsatuan_freq, idbarang, idpe, iddetail, idjenis_detail,kuartal) "
						sql = sql & " values ('" & TBarangEvn.Text & "','" & TQtyEvn.Text & "','" & CSatQtyEvn.Text & "','" & TFreqEvn.Text & "',"
						sql = sql & "'" & CSatFreqEvn.Text & "','" & TRegionEvn.Text & "','" & THargaUnitEvn.Text & "','" & TSubTotalEvn.Text & "','" & TKetPEvn.Text & "','" & idQtyEvn.Text & "','" & idFreqEvn.Text & "',"
						sql = sql & "'" & idBarangEvn.Text & "','" & TidPE.Text & "','" & TidDetailCL.Text & "','" & TidJenisDetail.Text & "','" & TQuartalPE.EditValue & "')"
						cmd = New OdbcCommand(sql, conn)
						cmd.ExecuteNonQuery()

						Call BacaDetailBiayaEvn()
					Else
						sql = ""
						sql = sql & " insert into act_dp_temp select * from act_detail_penawaran where iddetail_act ='" & TidDetailActEvn.Text & "'"
						cmd = New OdbcCommand(sql, conn)
						cmd.ExecuteNonQuery()

						With Me.ListBiayaEvn.SelectedItems(0).SubItems
							.Item(0).Text = TBarangEvn.Text
							.Item(1).Text = TQtyEvn.Text
							.Item(2).Text = CSatQtyEvn.Text
							.Item(3).Text = TFreqEvn.Text
							.Item(4).Text = CSatFreqEvn.Text
							.Item(5).Text = TRegionEvn.Text
							.Item(6).Text = THargaUnitEvn.Text
							.Item(7).Text = TSubTotalEvn.Text
							.Item(8).Text = TKetPEvn.Text
							.Item(9).Text = idQtyEvn.Text
							.Item(10).Text = idFreqEvn.Text
							.Item(11).Text = idBarangEvn.Text
							.Item(12).Text = TidPE.Text
							.Item(13).Text = TidDetailCL.Text
							.Item(14).Text = TidJenisDetail.Text
							.Item(15).Text = TidDetailActEvn.Text
							.Item(16).Text = TQuartalPE.EditValue
						End With
						Call UpdateEvent()
					End If
			End Select
			Call NominalBiaya()
			HapusDetailEvent = "Baru"
			Call KondisiBersihEvn()
		End If
		For Each item As ListViewItem In ListBiayaEvn.Items
			ItemsBackup.Add(item)
		Next
	End Sub
	Private Sub BtnTutupEvn_Click(sender As Object, e As EventArgs) Handles BtnTutupEvn.Click
		PInpEvent.Visible = False
		Call KondisiBersihEvn()
		BtnInpEvn.Enabled = True
		BtnSimpanEvn.Enabled = True
	End Sub
	Private Sub BtnInpProj_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnInpProj.ItemClick
		PInpProject.Visible = True
		Call LoadItemProject()
		Call LoadSatuan()
		BtnInpProj.Enabled = False
	End Sub
	Private Sub BtnSaveProj_Click(sender As Object, e As EventArgs) Handles BtnSaveProj.Click
		Dim c As String
		Select Case KondisiInputProject
			Case "DataBaru"
				Dim newItem As New ListViewItem(TBarangProj.Text)
				newItem.SubItems.Add(TQtyProj.Text)
				newItem.SubItems.Add(CQtyProj.Text)
				newItem.SubItems.Add(TNominalProj.Text)
				newItem.SubItems.Add(TSubTotalProj.Text)
				newItem.SubItems.Add(TidBarangProj.Text)
				newItem.SubItems.Add(TidSatuanQtyProj.Text)
				newItem.SubItems.Add(TidPE.Text)
				newItem.SubItems.Add(TidDetailCL.Text)
				newItem.SubItems.Add(TidJenisDetailProj.Text)
				ListBiayaProject.Items.Add(newItem)

				Call KondisiBersihProject()
				Call NominalBiaya()
			Case "RevisiData"
				GGVM_conn()
				sql = ""
				sql = sql & "insert act_detail_penawaran (idpe,iddetail,idjenis_detail,idbarang,barang,qty,satuan_qty,idsatuan_qty,harga_unit,subtotal)"
				sql = sql & " values ('" & TidPE.Text & "','" & TidDetail.Text & "','" & TidJenisDetailProj.Text & "','" & TidBarangProj.Text & "','" & TBarangProj.Text & "','" & TQtyProj.Text & "','" & CQtyProj.Text & "','" & TidSatuanQtyProj.Text & "',"
				sql = sql & "'" & TNominalProj.Text & "','" & TSubTotalProj.Text & "')"
				cmd = New OdbcCommand(sql, conn)
				cmd.ExecuteNonQuery()

				c = ""
				c = c & " Select max(iddetail_act)As id from act_detail_penawaran "
				da = New OdbcDataAdapter(c, conn)
				dt = New DataTable
				da.Fill(dt)
				If dt.Rows.Count > 0 Then
					TidDetailActProj.Text = dt.Rows(0)("id")
				End If

				sql = ""
				sql = sql & " insert into act_dp_temp select * from act_detail_penawaran where iddetail_act ='" & TidDetailActProj.Text & "'"
				cmd = New OdbcCommand(sql, conn)
				cmd.ExecuteNonQuery()

				c = ""
				c = c & " update evn_penawaran set "
				c = c & " userid_edit = '" & userid & "',"
				c = c & " timeupdate = now()"
				c = c & " where idpe = '" & TidPE.Text & "'"
				cmd = New OdbcCommand(c, conn)
				cmd.ExecuteNonQuery()

				MsgBox("Data berhasil di tambahkan !!", MsgBoxStyle.Information, "Pemberitahuan !!")

				Call BacaDetailProject()
				Call KondisiBersihProject()
				Call NominalBiaya()
				GGVM_conn_close()
		End Select
	End Sub
	Private Sub BtnTutupProj_Click(sender As Object, e As EventArgs) Handles BtnTutupProj.Click
		PInpProject.Visible = False
		Call KondisiBersihProject()
		BtnInpProj.Enabled = True
	End Sub
	Private Sub BtnInpHR_Click(sender As Object, e As EventArgs) Handles BtnInpHR.Click
		If TTotPersonHR.Text = "0" Then
			MsgBox("Klik Tombol Hitung Biaya !!", MsgBoxStyle.Information, "Information")
			Exit Sub
		ElseIf TGrandTotalHR.Text = "0" Then
			MsgBox("Klik Tombol Hitung Biaya !!", MsgBoxStyle.Information, "Information")
			Exit Sub
		ElseIf Me.TBasicSalaryHR.Text = "0" Then
			MsgBox("Please, Insert Basic Salary !", MsgBoxStyle.Critical, "Message !!")
			Exit Sub
		ElseIf Me.TUmk.Text = "0" Then
			MsgBox("Please, Insert UMK !", MsgBoxStyle.Critical, "Message !!")
			Exit Sub
		ElseIf Me.TPositionHR.Text = "" Then
			MsgBox("Please, Insert Position !", MsgBoxStyle.Critical, "Message !!")
			Exit Sub
		Else
			Select Case KondisiInputHR
				Case "DataBaru"
					If MsgBox("Apakah data ingin disimpan??", MsgBoxStyle.Information Or MsgBoxStyle.YesNo, "Pemberitahuan !!") = MsgBoxResult.Yes Then
						Call DataBaruHR()
					Else
						MsgBox("Data Tidak Disimpan !!", MsgBoxStyle.Information, "Pemberitahuan !!")
						Return
					End If
				Case "RevisiData"
					Dim c As String
					If Blank() = False Then
						If Duplicate() = False Then
							Call DataBaruHR()

							c = ""
							c = c & " Select max(iddetail_sdm)As id from act_detail_sdm "
							da = New OdbcDataAdapter(c, conn)
							dt = New DataTable
							da.Fill(dt)
							If dt.Rows.Count > 0 Then
								TidDetailSDM.Text = dt.Rows(0)("id")
							End If

							sql = ""
							sql = sql & " insert into act_temp_sdm select * from act_detail_sdm where iddetail_sdm ='" & TidDetailSDM.Text & "'"
							cmd = New OdbcCommand(sql, conn)
							cmd.ExecuteNonQuery()

							Call KondisiBersihHR()
							Call BacaDetailHR()
							Call NominalBiaya()
						Else
							GGVM_conn()
							If MsgBox("Apakah data ingin diUpdate??", MsgBoxStyle.Information Or MsgBoxStyle.YesNo, "Pemberitahuan !!") = MsgBoxResult.Yes Then
								Call HitungInpHR()

								sql = ""
								sql = sql & "update act_detail_sdm set iddetail = '" & TidDetailCL.Text & "',idjabatan = '" & TidPositionHR.Text & "', "
								sql = sql & "idregion = '" & TidRegionHR.Text & "',idkota = '" & TidKotaHR.Text & "',tahun = '" & TTahunHR.Text & "',"
								sql = sql & "jml_person = '" & TPeopleHR.Text & "',basicsalary = '" & TBasicSalaryHR.Text & "',"
								If CAdaBPJS.Checked = True Then
									sql = sql & "bpjskes = '" & TBpjsMed.Text & "',bpjstk = '" & TBpjsEmp.Text & "',"
								End If
								sql = sql & "tunjjbt = '" & TPostAllow.Text & "',allowmeal = '" & TMeal.Text & "',"
								sql = sql & "allowtrans = '" & TTransport.Text & "',motorcycle = '" & TMotor.Text & "',"
								sql = sql & "allowatk = '" & TAtkHR.Text & "',sewakomp = '" & TRentComp.Text & "',"
								sql = sql & "pulsa = '" & TPulse.Text & "',makeup = '" & TMakeUp.Text & "',bymeeting = '" & TMeetingCost.Text & "',"
								sql = sql & "incentive = '" & TIncentive.Text & "',telemarketing = '" & TTelemarketingHR.Text & "',thr = '" & TThr.Text & "', traveling_cost = '" & TThr.Text & "',"
								sql = sql & "pot_bpjskes = '" & TPotBpjsMed.Text & "',pot_bpjstk = '" & TPotBpjsEmp.Text & "',event_cost = '" & TEventHR.Text & "',fix_cost = '" & TFixCostHR.Text & "',"
								sql = sql & "totalperson_cost = '" & TTotPersonHR.Text & "',ppn = '" & TPpnHR.Text & "',pph23 = '" & TPph23HR.Text & "',gross1 = '" & TGross1HR.Text & "',gross2 = '" & TGross2HR.Text & "',thp = '" & TTakeHomePay.Text & "',"
								sql = sql & "grandtotal = '" & TGrandTotalHR.Text & "',lembur ='" & TOvertime.Text & "',training_cost ='" & TTrainingCost.Text & "',subcollateb ='" & TSubColl.Text & "', "
								sql = sql & "fee = '" & TAgentFeeHR.Text & "' ,useredit = '" & userid & "',timeedit = 'now()'"
								sql = sql & "where iddetail_sdm = '" & TidDetailSDM.Text & "'"
								cmd = New OdbcCommand(sql, conn)
								cmd.ExecuteNonQuery()

								sql = ""
								sql = sql & " insert into act_temp_sdm select * from act_detail_sdm where iddetail_sdm ='" & TidDetailSDM.Text & "'"
								cmd = New OdbcCommand(sql, conn)
								cmd.ExecuteNonQuery()

								c = ""
								c = c & " update evn_penawaran set "
								c = c & " userid_edit = '" & userid & "',"
								c = c & " timeupdate = now()"
								c = c & " where idpe = '" & TidPE.Text & "'"
								cmd = New OdbcCommand(c, conn)
								cmd.ExecuteNonQuery()

								MsgBox("Data berhasil di Update !!", MsgBoxStyle.Information, "Pemberitahuan !!")

								Call KondisiBersihHR()
								Call BacaDetailHR()
								Call NominalBiaya()
							Else
								MsgBox("Data Gagal DiUpdate !!", MsgBoxStyle.Information, "Pemberitahuan !!")
								Return
							End If
							GGVM_conn_close()
						End If
					Else
						MsgBox("Data Gagal di Update !!", MsgBoxStyle.Information, "Pemberitahuan !!")
						Return
					End If
			End Select
		End If
	End Sub
	Private Sub BtnSimpanAlasan_Click(sender As Object, e As EventArgs) Handles BtnSimpanAlasan.Click
		GGVM_conn()
		Dim c As String
		If Len(Me.TAlasanRevisi.Text) < 10 Or Len(Me.TAlasanRevisi.Text) > 150 Then
			MsgBox("Alasan Terlalu Pendek, Minimal 10 Huruf !", MsgBoxStyle.Information, "Information !!")
			Exit Sub
		ElseIf TAlasanRevisi.Text = "" Then
			MsgBox("Masukkan Alasan Revisi !!", MsgBoxStyle.Information, "WAJIB ISI !!")
		Else
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
			c = c & " '" & TAlasanRevisi.Text & "',now(),'" & userid & "')"
			cmd = New OdbcCommand(c, conn)
			cmd.ExecuteNonQuery()

			sql = ""
			sql = sql & " select max(revisike) as revisike ,max(idrevisi)as id  from evn_revisi_penawaran where idpe = '" & TidPE.Text & "'"
			da = New Odbc.OdbcDataAdapter(sql, conn)
			dt = New DataTable
			dt.Clear()
			da.Fill(dt)
			Dim count As Integer
			TidRevisi.Text = dt.Rows(0)("id")
			If TidRevisi.Text = dt.Rows(0)("id") Then
				count = dt.Rows(0)("revisike")
			Else
				count = 0
			End If
			count = count + 1

			c = ""
			c = c & "update evn_revisi_penawaran set revisike ='" & count & "' where idrevisi ='" & TidRevisi.Text & "'"
			cmd = New Odbc.OdbcCommand(c, conn)
			cmd.ExecuteNonQuery()

			PAlasan.Visible = False
			Call TanggalEvent()

			sql = ""
			sql = sql & "update evn_penawaran set "
			sql = sql & "idklien ='" & Me.TidKlien.Text & "',idjenis_pe ='" & Me.TidJenisPE.Text & "',"
			sql = sql & "project ='" & Me.TProject.Text & "',venue ='" & Me.TVenue.Text & "', jmlevent ='" & Me.TJmlEvent.Text & "',"
			sql = sql & "approved_by ='" & Me.TPIC.Text & "',region ='" & Me.TRegion.Text & "', "
			sql = sql & "start_event='" & Format(StartPeriod.Value, "yyyy/MM/dd") & "',end_event ='" & Format(EndPeriod.Value, "yyyy/MM/dd") & "' ,"
			sql = sql & "periode = '" & tglevent & "',"
			sql = sql & "periode_start = '" & Format(StartPeriod.Value, "yyyyMM") & "',"
			sql = sql & "periode_end = '" & Format(EndPeriod.Value, "yyyyMM") & "'"
			sql = sql & " where idpe ='" & TidPE.Text & "' "
			cmd = New OdbcCommand(sql, conn)
			cmd.ExecuteNonQuery()

			c = "select * from evn_tmp_dp where idpe = '" & TidPE.Text & "'"
			cmd = New OdbcCommand(c, conn)
			dr = cmd.ExecuteReader
			dr.Read()
			If dr.HasRows = True Then
				sql = ""
				sql = sql & "INSERT INTO evn_revisi_detail_pe "
				sql = sql & " SELECT b.idrevisi,a.*, b.revisike FROM (SELECT * FROM evn_tmp_dp) a "
				sql = sql & " LEFT JOIN evn_revisi_penawaran b on a.Idpe = b.idpe"
				sql = sql & " where b.idpe='" & TidPE.Text & "'"
				cmd = New OdbcCommand(sql, conn)
				cmd.ExecuteNonQuery()
			End If
			sql = ""
			sql = "delete from evn_tmp_dp where idpe ='" & TidPE.Text & "'"
			cmd = New OdbcCommand(sql, conn)
			cmd.ExecuteNonQuery()
			Select Case KondisiSimpanAlasan
				Case "Event"
					GGVM_conn()

					'If TidDetailActEvn.Text = "" Then
					'	Call SimpanEvent()
					'Else
					'	Call UpdateEvent()
					'End If

					c = "select * from act_dp_temp where idpe = '" & TidPE.Text & "'"
					cmd = New OdbcCommand(c, conn)
					dr = cmd.ExecuteReader
					dr.Read()
					If dr.HasRows = True Then
						sql = ""
						sql = sql & "INSERT INTO act_revisi_detail_penawaran "
						sql = sql & " SELECT a.*, b.revisike FROM (SELECT * FROM act_dp_temp) a "
						sql = sql & " LEFT JOIN evn_revisi_penawaran b on a.Idpe = b.idpe "
						sql = sql & " where a.idpe='" & TidPE.Text & "'"
						cmd = New OdbcCommand(sql, conn)
						cmd.ExecuteNonQuery()
					End If
					sql = ""
					sql = "delete from act_dp_temp where idpe ='" & TidPE.Text & "'"
					cmd = New OdbcCommand(sql, conn)
					cmd.ExecuteNonQuery()

					c = ""
					c = c & "update evn_detail_penawaran set unitcost = '" & TGrandTotalEvn.EditValue & "',sub_totalcost = '" & TGrandTotalEvn.EditValue & "'"
					c = c & "where iddetail = '" & TidDetailCL.Text & "'"
					cmd = New OdbcCommand(c, conn)
					cmd.ExecuteNonQuery()

					Call BacaMainDetail()


					MsgBox("Data berhasil di Perbarui !!", MsgBoxStyle.Information, "Pemberitahuan !!")
					Call SimpanTotalPE()
					ListBiayaEvn.Items.Clear()
					Call KondisiAwalPE()
					Call KondisiBersihPE()
					Call KondisiBersihDetail()
					Call KondisiBersihEvn()
					Call BacaPE()
					ListPEActivation.Enabled = True
					GGVM_conn_close()
				Case "Project"
					GGVM_conn()
					c = "select * from act_dp_temp where idpe = '" & TidPE.Text & "'"
					cmd = New OdbcCommand(c, conn)
					dr = cmd.ExecuteReader
					dr.Read()
					If dr.HasRows = True Then
						sql = ""
						sql = sql & "INSERT INTO act_revisi_detail_penawaran"
						sql = sql & "SELECT a.*, b.revisike FROM (SELECT * FROM act_dp_temp) a"
						sql = sql & "LEFT JOIN evn_revisi_penawaran b on a.Idpe = b.idpe "
						sql = sql & " where a.idpe='" & TidPE.Text & "'"
						cmd = New OdbcCommand(sql, conn)
						cmd.ExecuteNonQuery()
					End If
					sql = ""
					sql = "delete from act_dp_temp where idpe ='" & TidPE.Text & "'"
					cmd = New OdbcCommand(sql, conn)
					cmd.ExecuteNonQuery()


					c = ""
					c = c & "update evn_detail_penawaran set unitcost = '" & TGrandTotalProj.EditValue & "',sub_totalcost = '" & TGrandTotalProj.EditValue & "'"
					c = c & "where iddetail = '" & TidDetailCL.Text & "'"
					cmd = New OdbcCommand(c, conn)
					cmd.ExecuteNonQuery()

					Call BacaMainDetail()


					'Call SaveTotal()
					MsgBox("Data berhasil di Perbarui !!", MsgBoxStyle.Information, "Pemberitahuan !!")
					Call SimpanTotalPE()
					ListBiayaProject.Items.Clear()
					Call KondisiAwalPE()
					Call KondisiBersihPE()
					Call KondisiBersihDetail()
					Call KondisiBersihProject()
					Call BacaPE()
					ListPEActivation.Enabled = True
					GGVM_conn_close()
				Case "InStore"
					GGVM_conn()
					c = "select * from act_temp_sdm where idpe = '" & TidPE.Text & "'"
					cmd = New OdbcCommand(c, conn)
					dr = cmd.ExecuteReader
					dr.Read()
					If dr.HasRows = True Then
						sql = ""
						sql = sql & "INSERT INTO act_revisi_detail_sdm "
						sql = sql & " SELECT a.*, b.revisike FROM (SELECT * FROM act_temp_sdm) a "
						sql = sql & " LEFT JOIN evn_revisi_penawaran b on a.Idpe = b.idpe "
						sql = sql & " where a.idpe='" & TidPE.Text & "'"
						cmd = New OdbcCommand(sql, conn)
						cmd.ExecuteNonQuery()
					End If

					sql = ""
					sql = "delete from act_temp_sdm where idpe ='" & TidPE.Text & "'"
					cmd = New OdbcCommand(sql, conn)
					cmd.ExecuteNonQuery()

					'Call SaveTotalHR()
					'Call SaveTotal()
					MsgBox("Data berhasil di Perbarui !!", MsgBoxStyle.Information, "Pemberitahuan !!")
					DGInputHR.DataSource = Nothing
					Call KondisiAwalPE()
					Call KondisiBersihPE()
					Call KondisiBersihDetail()
					Call KondisiBersihHR()
					Call BacaPE()
					ListPEActivation.Enabled = True
					GGVM_conn_close()
			End Select
		End If
		TAlasanRevisi.Text = ""
		PAlasan.Visible = False
	End Sub
	'End Of Header Button
	Private Sub PInpEvent_MouseUp(sender As Object, e As MouseEventArgs) Handles PInpEvent.MouseUp
		Panel1Captured = False
	End Sub
	Private Sub PInpEvent_MouseDown(sender As Object, e As MouseEventArgs) Handles PInpEvent.MouseDown
		Panel1Captured = True
		Panel1Grabbed = e.Location
	End Sub
	Private Sub PInpEvent_MouseMove(sender As Object, e As MouseEventArgs) Handles PInpEvent.MouseMove
		If (Panel1Captured) Then PInpEvent.Location = PInpEvent.Location + e.Location - Panel1Grabbed
	End Sub
	Private Sub PInpProject_MouseUp(sender As Object, e As MouseEventArgs) Handles PInpEvent.MouseUp
		Panel1Captured = False
	End Sub
	Private Sub PInpProject_MouseDown(sender As Object, e As MouseEventArgs) Handles PInpProject.MouseDown
		Panel1Captured = True
		Panel1Grabbed = e.Location
	End Sub
	Private Sub PInpProject_MouseMove(sender As Object, e As MouseEventArgs) Handles PInpProject.MouseMove
		If (Panel1Captured) Then PInpProject.Location = PInpProject.Location + e.Location - Panel1Grabbed
	End Sub
	Private Sub RibbonControl_SelectedPageChanged(sender As Object, e As EventArgs) Handles RibbonControl.SelectedPageChanged
		If RibbonControl.SelectedPage.Category Is RbPenawaran Then
			NavigationFrame1.SelectedPage = NavBuatPE
		ElseIf RibbonControl.SelectedPage.Category Is RbDetail Then
			NavigationFrame1.SelectedPage = NavDetailPE
		Else
			MsgBox("Terjadi Kesalahan !")
		End If
	End Sub
	'Textbox Menu PE
	Private Sub TidJenisPE_TextChanged(sender As Object, e As EventArgs) Handles TidJenisPE.TextChanged
		Try
			GGVM_conn()
			sql = "select * from evn_jenis_pe where idjenis_pe= '" & TidJenisPE.Text & "'"
			cmd = New OdbcCommand(sql, conn)
			dr = cmd.ExecuteReader
			dr.Read()
			TJenisPE.Text = If(Not dr.HasRows, "", DirectCast(dr.Item("jenis_pe"), String))
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		End Try
		GGVM_conn_close()
	End Sub
	Private Sub TidPE_TextChanged(sender As Object, e As EventArgs) Handles TidPE.TextChanged
		GGVM_conn()
		sql = "Select a.*,b.nama,d.fee from evn_penawaran a,"
		sql = sql & " klien b,evn_jenis_pe c, subdivisi d where a.idklien = b.id "
		sql = sql & " And a.idjenis_pe = c.idjenis_pe and d.idsubdivisi = a.idsubdivisi And a.idpe='" & TidPE.Text & "'"
		da = New OdbcDataAdapter(sql, conn)
		dt = New DataTable
		da.Fill(dt)
		If dt.Rows.Count > 0 Then
			TNoPE.Text = dt.Rows(0)("nope")
			TKlien.Text = dt.Rows(0)("nama")
			TProject.Text = dt.Rows(0)("project").ToString
			TVenue.Text = dt.Rows(0)("venue").ToString
			TJmlEvent.Text = dt.Rows(0)("jmlevent").ToString
			'TJmlEvnCL.Text = TJmlEvent.Text
			TRegion.Text = dt.Rows(0)("region").ToString
			StartPeriod.CustomFormat = "dd/MMMM/yyyy"
			StartPeriod.Value = dt.Rows(0)("start_event")
			EndPeriod.CustomFormat = "dd/MMMM/yyyy"
			EndPeriod.Value = dt.Rows(0)("end_event")
			DTTanggal.CustomFormat = "dd/MM/yyyy"
			DTTanggal.Value = dt.Rows(0)("tgl_pe")
			TPIC.Text = dt.Rows(0)("approved_by").ToString
			TTotal.Text = FormatNumber(dt.Rows(0)("total"), 0, , , TriState.True)
			TRpPPN.Text = FormatNumber(dt.Rows(0)("rp_ppn"), 0, , , TriState.True)
			TAgencyRP.Text = FormatNumber(dt.Rows(0)("agent_fee"), 0, , , TriState.True)
			TTotalVAT.Text = FormatNumber(dt.Rows(0)("grandtotal"), 0, , , TriState.True)
			TPeriodeCL.Text = dt.Rows(0)("periode")
			TidSubdivisi.Text = dt.Rows(0)("idsubdivisi")
			TAgentFee.Text = dt.Rows(0)("fee")
		Else
			TNoPE.Text = ""
			TKlien.Text = ""
			TProject.Text = ""
			TVenue.Text = ""
			TJmlEvent.Text = ""
			TJmlEvnCL.Text = ""
			TRegion.Text = ""
			StartPeriod.Value = DateTime.Now
			EndPeriod.Value = DateTime.Now
			DTTanggal.Value = DateTime.Now
			TPIC.Text = ""
			TTotal.Text = "0"
			TRpPPN.Text = "0"
			TAgencyRP.Text = "0"
			TTotalVAT.Text = "0"
			TPeriodeCL.Text = ""
			TidSubdivisi.Text = ""
			TAgentFee.Text = "0"
		End If
	End Sub
	Private Sub TidSubdivisi_TextChanged(sender As Object, e As EventArgs) Handles TidSubdivisi.TextChanged
		Try
			GGVM_conn()
			sql = "Select * from subdivisi where idsubdivisi ='" & TidSubdivisi.Text & "'"
			cmd = New OdbcCommand(sql, conn)
			dr = cmd.ExecuteReader
			dr.Read()
			If Not dr.HasRows Then
				CSubDivisi.Text = ""
				'TAgentFee.Text = "0"
			Else
				CSubDivisi.Text = dr.Item("subdivisi")
				' TAgentFee.Text = dr.Item("fee")
			End If
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		Finally
			GGVM_conn_close()
		End Try
	End Sub
	Private Sub TKlien_TextChanged(sender As Object, e As EventArgs) Handles TKlien.TextChanged
		Try
			GGVM_conn()
			sql = "Select * from klien where nama= '" & TKlien.Text & "'"
			cmd = New OdbcCommand(sql, conn)
			dr = cmd.ExecuteReader
			dr.Read()
			TidKlien.Text = If(Not dr.HasRows, "", DirectCast(dr.Item("id"), Int32))
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
			TKlien.Text = If(Not dr.HasRows, "", DirectCast(dr.Item("nama"), String))
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		End Try
		GGVM_conn_close()
	End Sub
	Private Sub TAgentFee_TextChanged(sender As Object, e As EventArgs) Handles TAgentFee.TextChanged
		PersenASF_1.Text = If(TAgentFee.Text <> "", TAgentFee.Text, "0")
	End Sub
	'End Textbox Menu PE
	'Textbox Detail PE
	Private Sub TidDetailCL_TextChanged(sender As Object, e As EventArgs) Handles TidDetailCL.TextChanged
		Try
			GGVM_conn()
			If TidJenisPE.Text = "5" Then
				sql = ""
				sql = sql & "Select a.*, b.jmlevent,b.kuartalke from evn_detail_penawaran a "
				sql = sql & " join act_kuartal_pe b on a.iddetail = b.iddetail  where a.iddetail ='" & TidDetailCL.Text & "'"
				sql = sql & " and b.kuartalke ='" & CKuartal.Text & "'"
			Else
				sql = "select * from evn_detail_penawaran where iddetail = '" & TidDetailCL.Text & "' "
			End If
			da = New OdbcDataAdapter(sql, conn)
			dt = New DataTable
			da.Fill(dt)
			If dt.Rows.Count > 0 Then
				TBarangCL.Text = dt.Rows(0)("barang")
				TQtyCL.Text = dt.Rows(0)("qty")
				TSubTotalCL.Text = dt.Rows(0)("unitcost")
				TJmlEvnCL.Text = dt.Rows(0)("jmlevent").ToString
				TKetCL.Text = dt.Rows(0)("remaks").ToString
			Else
				TBarangCL.Text = ""
				TQtyCL.Text = ""
				TSubTotalCL.Text = ""
				TJmlEvnCL.Text = ""
				TKetCL.Text = ""
			End If
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		Finally
			GGVM_conn_close()
		End Try
	End Sub
	Private Sub TBarangCL_TextChanged(sender As Object, e As EventArgs) Handles TBarangCL.TextChanged
		Try
			GGVM_conn()
			sql = "Select * from barang_penawaran where barang= '" & TBarangCL.Text & "'"
			cmd = New OdbcCommand(sql, conn)
			dr = cmd.ExecuteReader
			dr.Read()
			If Not dr.HasRows Then
				TidBarangCL.Text = ""
			Else
				TidBarangCL.Text = dr.Item("idbarang")
			End If
			'TidBarangCL.Text = If(Not dr.HasRows, "", DirectCast(dr.Item("idbarang"), Integer))
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		Finally
			GGVM_conn_close()
		End Try
	End Sub
	Private Sub TQtyCL_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TQtyCL.KeyPress
		AturanInput(e)
	End Sub
	Private Sub TGrandTotalCL_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TGrandTotalCL.KeyPress
		AturanInput(e)
	End Sub
	Private Sub TPph23CL_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TPph23CL.KeyPress
		AturanInput(e)
	End Sub
	Private Sub TRpPPNCL_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TRpPPNCL.KeyPress
		AturanInput(e)
	End Sub
	Private Sub TTotalCostCL_Keypress(sender As Object, e As EventArgs) Handles TTotalCostCL.KeyPress
		AturanInput(e)
	End Sub
	Private Sub TSubTotalCL_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TSubTotalCL.KeyPress
		AturanInput(e)
	End Sub
	Private Sub CxRefreshDetailPE_Click(sender As Object, e As EventArgs) Handles CxRefreshDetailPE.Click
		Call BacaMainDetail()
	End Sub
	Private Sub CxHapusDetailPE_Click(sender As Object, e As EventArgs) Handles CxHapusDetailPE.Click
		Dim Nominal As Decimal = 0
		Dim ada As Boolean
		Dim brs, jmldt As Integer
		ada = False
		jmldt = 0
		ListDetailPEAct.BeginUpdate() ' Turn off the ListView
		'Dim I As Integer
		For i = ListDetailPEAct.Items.Count - 1 To 0 Step -1
			If ListDetailPEAct.Items(i).Checked = True Then
				ada = True
				brs = i
				jmldt = jmldt + 1
				Nominal = Val(ListDetailPEAct.Items(brs).SubItems(5).Text) - Nominal

			End If
		Next i
		If Me.ListDetailPEAct.SelectedItems.Count > 0 Then
			Dim lvi As ListViewItem = Me.ListDetailPEAct.SelectedItems(0)
			Me.TidDetailCL.Text = lvi.SubItems(6).Text
		Else
			Me.TidDetailCL.Text = String.Empty
		End If
		For Each item As ListViewItem In ListDetailPEAct.CheckedItems
			GGVM_conn()
			Dim sql1, sql3 As String
			sql1 = "insert into evn_tmp_dp select * from evn_detail_penawaran where iddetail = ? "
			cmd = New OdbcCommand
			With cmd
				.CommandText = (sql1)
				.Parameters.Add("@iddetail", OdbcType.BigInt).Value = Convert.ToInt32(item.SubItems(6).Text)
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

			sql3 = "DELETE FROM evn_detail_penawaran WHERE iddetail = ?"
			cmd = New OdbcCommand
			With cmd
				.CommandText = (sql3)
				.Parameters.Add("@iddetail", OdbcType.BigInt).Value = Convert.ToInt32(item.SubItems(6).Text)
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
			Call KondisiBersihDetail()
			Call BacaMainDetail()
			Call NominalBiaya()
		Next
		ListDetailPEAct.EndUpdate()
	End Sub
	'End Textbox Detail PE
	'Textbox Event PE
	Private Sub TBarangEvn_TextChanged(sender As Object, e As EventArgs) Handles TBarangEvn.TextChanged
		Try
			GGVM_conn()
			sql = "Select * from barang_penawaran a"
			sql = sql & " join subkelompok b on a.idsubkel = b.idsubkel "
			sql = sql & " JOIN kelompok c on b.idkelompok = c.idkelompok"
			sql = sql & " where c.idkelompok = '20' and barang= '" & TBarangEvn.Text & "'"
			da = New OdbcDataAdapter(sql, conn)
			dt = New DataTable
			da.Fill(dt)
			If dt.Rows.Count > 0 Then
				idBarangEvn.Text = dt.Rows(0)("idbarang")
				TidSubkelEvn.Text = dt.Rows(0)("idsubkel")
				THargaUnitEvn.Text = dt.Rows(0)("harga_pe")
			Else
				idBarangEvn.Text = ""
				TidSubkelEvn.Text = ""
				THargaUnitEvn.Text = ""
			End If
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		Finally
			GGVM_conn_close()
		End Try
	End Sub
	Private Sub TidSubkelEvn_TextChanged(sender As Object, e As EventArgs) Handles TidSubkelEvn.TextChanged
		Try
			GGVM_conn()
			sql = "Select * from subkelompok where idsubkel = '" & TidSubkelEvn.Text & "'"
			cmd = New OdbcCommand(sql, conn)
			dr = cmd.ExecuteReader
			dr.Read()
			CSubkelEvn.Text = If(Not dr.HasRows, "", DirectCast(dr.Item("subkel"), String))
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		Finally
			GGVM_conn_close()
		End Try
	End Sub
	Private Sub TQtyEvn_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TQtyEvn.KeyPress
		AturanInput(e)
	End Sub
	Private Sub CSatQtyEvn_Enter(sender As Object, e As EventArgs) Handles CSatQtyEvn.Enter
		CSatQtyEvn.DroppedDown = True
	End Sub
	Private Sub CSatQtyEvn_TextChanged(sender As Object, e As EventArgs) Handles CSatQtyEvn.TextChanged
		Try
			GGVM_conn()
			sql = "Select * from satuan where satuan= '" & CSatQtyEvn.Text & "'"
			cmd = New OdbcCommand(sql, conn)
			dr = cmd.ExecuteReader
			dr.Read()
			idQtyEvn.Text = If(Not dr.HasRows, "", DirectCast(dr.Item("idsatuan"), Int32))
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		Finally
			GGVM_conn_close()
		End Try
	End Sub
	Private Sub TFreqEvn_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TFreqEvn.KeyPress
		AturanInput(e)
	End Sub
	Private Sub CSatFreqEvn_TextChanged(sender As Object, e As EventArgs) Handles CSatFreqEvn.TextChanged
		Try
			GGVM_conn()
			sql = "Select * from satuan where satuan= '" & CSatFreqEvn.Text & "'"
			cmd = New OdbcCommand(sql, conn)
			dr = cmd.ExecuteReader
			dr.Read()
			idFreqEvn.Text = If(Not dr.HasRows, "", DirectCast(dr.Item("idsatuan"), Int32))
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		Finally
			GGVM_conn_close()
		End Try
	End Sub
	Private Sub CSatFreqEvn_Enter(sender As Object, e As EventArgs) Handles CSatFreqEvn.Enter
		CSatFreqEvn.DroppedDown = True
	End Sub
	Private Sub TRegionP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TRegionEvn.KeyPress
		AturanInput(e)
	End Sub
	Private Sub THargaUnitEvn_KeyPress(sender As Object, e As KeyPressEventArgs) Handles THargaUnitEvn.KeyPress
		AturanInput(e)
	End Sub
	Private Sub TKetPEvn_GotFocus(sender As Object, e As EventArgs) Handles TKetPEvn.GotFocus
		Dim HitungSubTot As Double = "0"
		If TQtyEvn.Text = "" Or Not IsNumeric(TQtyEvn.Text) Then
			Exit Sub
		ElseIf TFreqEvn.Text = "" Or Not IsNumeric(TFreqEvn.Text) Then
			Exit Sub
		ElseIf TRegionEvn.Text = "" Or Not IsNumeric(TRegionEvn.Text) Then
			Exit Sub
		ElseIf THargaUnitEvn.Text = "" Or Not IsNumeric(THargaUnitEvn.Text) Then
			Exit Sub
		Else
			HitungSubTot = Val(CDbl(TQtyEvn.Text)) * Val(CDbl(TFreqEvn.Text)) * Val(CDbl(TRegionEvn.Text)) * Val(CDbl(THargaUnitEvn.Text))
			TSubTotalEvn.Text = HitungSubTot
		End If
	End Sub
	Private Sub CJenisDetail_TextChanged(sender As Object, e As EventArgs) Handles CJenisDetail.TextChanged
		Try
			GGVM_conn()
			sql = "Select * from act_jenis_detail where jenis_detail= '" & CJenisDetail.Text & "'"
			cmd = New OdbcCommand(sql, conn)
			dr = cmd.ExecuteReader
			dr.Read()
			TidJenisDetail.Text = If(Not dr.HasRows, "", DirectCast(dr.Item("idjenis_detail"), Int32))
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		Finally
			GGVM_conn_close()
		End Try
	End Sub
	Private Sub CJenisDetail_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CJenisDetail.SelectedIndexChanged
		Call BacaDetailBiayaEvn()
	End Sub
	Private Sub TidJenisDetail_TextChanged(sender As Object, e As EventArgs) Handles TidJenisDetail.TextChanged
		Try
			GGVM_conn()
			sql = "Select * from act_jenis_detail where idjenis_detail= '" & TidJenisDetail.Text & "'"
			cmd = New OdbcCommand(sql, conn)
			dr = cmd.ExecuteReader
			dr.Read()
			CJenisDetail.Text = If(Not dr.HasRows, "", DirectCast(dr.Item("jenis_detail"), String))
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		Finally
			GGVM_conn_close()
		End Try
	End Sub
	Private Sub CSubkelEvn_TextChanged(sender As Object, e As EventArgs) Handles CSubkelEvn.TextChanged
		Try
			GGVM_conn()
			sql = "select * from subkelompok where subkel  = '" & CSubkelEvn.Text & "'"
			cmd = New OdbcCommand(sql, conn)
			dr = cmd.ExecuteReader
			dr.Read()
			TidSubkelEvn.Text = If(Not dr.HasRows, "", DirectCast(dr.Item("idsubkel"), Int32))
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		Finally
			GGVM_conn_close()
		End Try
	End Sub
	Private Sub CxHapusDetailEvent_Click(sender As Object, e As EventArgs) Handles CxHapusDetailEvent.Click
		Dim Nominal As Double = 0
		Dim ada As Boolean
		Dim brs, jmldt As Integer
		ada = False
		jmldt = 0
		Select Case HapusDetailEvent
			Case "HapusBaru"
				ListBiayaEvn.BeginUpdate() ' Turn off the ListView
				For I = ListBiayaEvn.Items.Count - 1 To 0 Step -1
					If ListBiayaEvn.Items(I).Checked = True Then
						ada = True
						brs = I
						jmldt = jmldt + 1
						Nominal = Val(ListBiayaEvn.Items(I).SubItems(7).Text - Nominal)
						ListBiayaEvn.Items.RemoveAt(I)
					End If
				Next I
				ListBiayaEvn.EndUpdate()
				Call NominalBiaya()
			Case "HapusRevisi"
				ListBiayaEvn.BeginUpdate() ' Turn off the ListView
				For I = ListBiayaEvn.Items.Count - 1 To 0 Step -1
					If ListBiayaEvn.Items(I).Checked = True Then
						ada = True
						brs = I
						jmldt = jmldt + 1
						Nominal = Val(ListBiayaEvn.Items(I).SubItems(7).Text - Nominal)
						For Each item As ListViewItem In ListBiayaEvn.CheckedItems
							GGVM_conn()
							Dim sql1, sql2 As String
							sql1 = "insert into act_dp_temp select * from act_detail_penawaran where iddetail_act = ? "
							cmd = New OdbcCommand
							With cmd
								.CommandText = (sql1)
								.Parameters.Add("@iddetailact", OdbcType.BigInt).Value = Convert.ToInt32(item.SubItems(15).Text)
								.Connection = conn
							End With
							dr = cmd.ExecuteReader
							Console.WriteLine(cmd.CommandText.ToString)
							While dr.Read
								Console.WriteLine(dr(0))
								Console.WriteLine()
							End While
							Console.ReadLine()

							sql2 = "DELETE FROM act_detail_penawaran WHERE iddetail_act = ?"
							cmd = New OdbcCommand
							With cmd
								.CommandText = (sql2)
								.Parameters.Add("@iddetailact", OdbcType.BigInt).Value = Convert.ToInt32(item.SubItems(15).Text)
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
						Next
						Call NominalBiaya()
						Call BacaDetailBiayaEvn()
					End If
				Next I
				ListBiayaEvn.EndUpdate()
		End Select
	End Sub
	'End Textbox Event PE
	'Kuartal EVENT
	Private Sub CxKuartalPE_Click(sender As Object, e As EventArgs) Handles CxKuartalPE.Click
		Dim ada As Boolean
		Dim jmldt As Integer = 0
		Dim brs As Integer
		For i = 0 To ListPEActivation.Items.Count - 1
			If ListPEActivation.Items(i).Checked = True Then
				ada = True
				brs = i
				jmldt = jmldt + 1
			End If
		Next
		If ada = False Then
			MsgBox("Tidak ada data yang akan di EDIT, Pilih dulu datanya!!...", MsgBoxStyle.Information, "Information")
			ListPEActivation.Focus()
			Exit Sub
		End If
		If jmldt > 1 Then
			MsgBox("Hanya 1(satu) data yg bisa di-EDIT !!...", MsgBoxStyle.Information, "Information")
			ListPEActivation.Focus()
			Exit Sub
		End If
		PKuartal.Visible = True
		TKidPE.Text = ListPEActivation.Items(brs).SubItems(8).Text
		TKKuartal.Text = ""
		TKidJenisDetailPE.Text = ""
		TKJmlEvent.Text = ""
		'ListPE.BeginUpdate()

	End Sub
	Private Sub LKTutup_Click(sender As Object, e As EventArgs) Handles LKTutup.Click
		PKuartal.Visible = False
		TKidPE.Text = ""
		TKNoPE.Text = ""
		TKKuartal.Text = ""
		TKJmlEvent.Text = ""
	End Sub
	Private Sub TKidPE_TextChanged(sender As Object, e As EventArgs) Handles TKidPE.TextChanged
		GGVM_conn()
		sql = "Select nope from evn_penawaran where idpe ='" & TKidPE.Text & "'"
		da = New OdbcDataAdapter(sql, conn)
		dt = New DataTable
		da.Fill(dt)
		If dt.Rows.Count > 0 Then
			TKNoPE.Text = dt.Rows(0)("nope")
		Else
			TNoPE.Text = ""
		End If
		GGVM_conn_close()
	End Sub
	Private Sub TKidDetailPE_TextChanged(sender As Object, e As EventArgs) Handles TKidJenisDetailPE.TextChanged
		GGVM_conn()
		Dim quartal As Integer
		sql = "select kuartal from act_detail_penawaran where idpe ='" & TKidPE.Text & "' and idjenis_detail= '" & TKidJenisDetailPE.Text & "'"
		da = New OdbcDataAdapter(sql, conn)
		dt = New DataTable
		da.Fill(dt)
		If dt.Rows.Count > 0 Then
			quartal = dt.Rows(0)("kuartal")
		End If
		quartal = quartal + 1
		TKKuartal.Text = quartal
		GGVM_conn_close()
	End Sub
	Private Sub CKDetailPE_TextChanged(sender As Object, e As EventArgs) Handles CKDetailPE.TextChanged
		GGVM_conn()
		sql = "select idjenis_detail from act_jenis_detail where jenis_detail = '" & CKDetailPE.Text & "'"
		da = New OdbcDataAdapter(sql, conn)
		dt = New DataTable
		da.Fill(dt)
		If dt.Rows.Count > 0 Then
			TKidJenisDetailPE.Text = dt.Rows(0)("idjenis_detail")
		Else
			TKidJenisDetailPE.Text = ""
		End If
		GGVM_conn_close()
	End Sub
	Private Sub BtnKProsesPE_Click(sender As Object, e As EventArgs) Handles BtnKProsesPE.Click
		Dim id As Integer
		Call KondisiBersihDetail()
		Call KondisiBersihEvn()

		GGVM_conn()
		sql = ""
		sql = sql & "insert into act_kuartal_pe (idpe,idjenis_detail,jmlevent,kuartalke) values "
		sql = sql & "('" & TKidPE.Text & "', '" & TKidJenisDetailPE.Text & "','" & TKJmlEvent.Text & "','" & TKKuartal.Text & "')"
		cmd = New OdbcCommand(sql, conn)
		cmd.ExecuteNonQuery()

		'Baca ID
		sql = ""
		sql = sql & " Select max(idkuartal)As id from act_kuartal_pe "
		da = New OdbcDataAdapter(sql, conn)
		dt = New DataTable
		da.Fill(dt)
		If dt.Rows.Count > 0 Then
			TidKuartalPE.Text = dt.Rows(0)("id")
		End If

		sql = ""
		sql = sql & " select idbarang from barang_penawaran where barang = '" & CKDetailPE.Text & "'"
		da = New OdbcDataAdapter(sql, conn)
		dt = New DataTable
		da.Fill(dt)
		If dt.Rows.Count > 0 Then
			id = dt.Rows(0)("idbarang")
		End If

		'Insert MainDetail Automatic
		c = ""
		c = c & "insert evn_detail_penawaran (idpe,idbarang,barang,qty,satuan_qty,total,unitcost,sub_totalcost,remaks) "
		c = c & " values ('" & TKidPE.Text & "','" & id & "','" & CKDetailPE.Text & "','1','PAKET','1','0','0','" & TKKet.Text & "')"
		cmd = New OdbcCommand(c, conn)
		cmd.ExecuteNonQuery()

		sql = ""
		sql = sql & " Select max(iddetail)As iddet from evn_detail_penawaran "
		da = New OdbcDataAdapter(sql, conn)
		dt = New DataTable
		da.Fill(dt)
		If dt.Rows.Count > 0 Then
			TidDetailCL.Text = dt.Rows(0)("iddet")
		End If

		c = ""
		c = c & " update act_kuartal_pe set"
		c = c & " iddetail ='" & TidDetailCL.Text & "'"
		c = c & " where idkuartal ='" & TidKuartalPE.Text & "'"
		cmd = New OdbcCommand(c, conn)
		cmd.ExecuteNonQuery()

		Call BacaMainDetail()
		TidJenisDetail.Text = TKidJenisDetailPE.Text
		NavigationFrame1.SelectedPage = NavDetailPE
		RibbonControl.SelectedPage = DetailPanel
		NavigationPane1.SelectedPage = DetailEvent
		TQuartalPE.EditValue = TKKuartal.Text
		TRegionEvn.Text = TKJmlEvent.Text
		CJenisDetail.Enabled = False
		SimpanPE.Enabled = True
		KondisiInputEvn = "DataBaru"
		KondisiSimpan = "KuartalPE"
		HapusDetailEvent = "Baru"
		PKuartal.Visible = False
		Call KondisiEditEvn()
	End Sub
	'End Kuartal Event
	'Textbox Project PE
	Private Sub TidDetailProj_TextChanged(sender As Object, e As EventArgs) Handles TidDetailProj.TextChanged
		Try
			GGVM_conn()
			sql = "Select * from act_detail_penawaran where iddetail_act ='" & TidDetailProj.Text & "'"
			da = New OdbcDataAdapter(sql, conn)
			dt = New DataTable
			da.Fill(dt)
			If dt.Rows.Count > 0 Then
				TBarangProj.Text = dt.Rows(0)("barang")
				TQtyProj.Text = dt.Rows(0)("qty")
				TidSatuanQtyProj.Text = dt.Rows(0)("idsatuan_qty")
				TNominalProj.Text = dt.Rows(0)("harga_unit")
				TSubTotalProj.Text = dt.Rows(0)("subtotal")
			Else
				TBarangCL.Text = ""
				TQtyCL.Text = ""
				TidSatuanQtyProj.Text = ""
				TSubTotalCL.Text = ""
				TKetCL.Text = ""
			End If
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		End Try
		GGVM_conn_close()
	End Sub
	Private Sub TidDetailActProj_TextChanged(sender As Object, e As EventArgs) Handles TidDetailActProj.TextChanged
		Try
			GGVM_conn()
			sql = "Select * from act_detail_penawaran where iddetail_act ='" & TidDetailActProj.Text & "'"
			cmd = New OdbcCommand(sql, conn)
			dr = cmd.ExecuteReader
			dr.Read()
			If Not dr.HasRows Then
				TBarangProj.Text = ""
				TQtyProj.Text = ""
				TidSatuanQtyProj.Text = ""
				TNominalProj.Text = ""
				TSubTotalProj.Text = ""
			Else
				TBarangProj.Text = dr.Item("barang")
				TQtyProj.Text = dr.Item("qty")
				TidSatuanQtyProj.Text = dr.Item("idsatuan_qty")
				TSubTotalProj.Text = dr.Item("subtotal")
			End If
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		Finally
			GGVM_conn_close()
		End Try
		GGVM_conn_close()
	End Sub
	Private Sub TBarangProj_TextChanged(sender As Object, e As EventArgs) Handles TBarangProj.TextChanged
		Try
			GGVM_conn()
			sql = "Select * from barang_penawaran where barang= '" & TBarangProj.Text & "'"
			cmd = New OdbcCommand(sql, conn)
			dr = cmd.ExecuteReader
			dr.Read()
			TidBarangProj.Text = If(Not dr.HasRows, "", DirectCast(dr.Item("idbarang"), Int32))
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		Finally
			GGVM_conn_close()
		End Try
	End Sub
	Private Sub CQtyProj_TextChanged(sender As Object, e As EventArgs) Handles CQtyProj.TextChanged
		Try
			GGVM_conn()
			sql = "Select * from satuan where satuan= '" & CQtyProj.Text & "'"
			cmd = New OdbcCommand(sql, conn)
			dr = cmd.ExecuteReader
			dr.Read()
			TidSatuanQtyProj.Text = If(Not dr.HasRows, "", DirectCast(dr.Item("idsatuan"), Int32))
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		Finally
			GGVM_conn_close()
		End Try
	End Sub
	Private Sub TSubTotalProj_GotFocus(sender As Object, e As EventArgs) Handles TSubTotalProj.GotFocus
		If TNominalProj.Text = "" Then
			MsgBox("Pastikan Nominal Sudah Terisi !!...", MsgBoxStyle.Information, "Information")
			Exit Sub
		ElseIf TQtyProj.Text = "" Then
			MsgBox("Pastikan Qty Sudah Terisi !!...", MsgBoxStyle.Information, "Information")
			Exit Sub
		Else
			TSubTotalProj.Text = Val(CDbl(TQtyProj.Text)) * Val(CDbl(TNominalProj.Text))
		End If
	End Sub
	Private Sub TidSatuanQtyProj_TextChanged(sender As Object, e As EventArgs) Handles TidSatuanQtyProj.TextChanged
		Try
			GGVM_conn()
			sql = "Select * from satuan where idsatuan ='" & TidSatuanQtyProj.Text & "'"
			da = New OdbcDataAdapter(sql, conn)
			dt = New DataTable
			da.Fill(dt)
			CQtyProj.Text = If(dt.Rows.Count > 0, DirectCast(dt.Rows(0)("satuan"), String), "")
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		Finally
			GGVM_conn_close()
		End Try
	End Sub
	Private Sub TidBarangProj_TextChanged(sender As Object, e As EventArgs) Handles TidBarangProj.TextChanged
		Try
			GGVM_conn()
			sql = "select * from barang_penawaran where idbarang = '" & TidBarangProj.Text & "' "
			cmd = New OdbcCommand(sql, conn)
			dr = cmd.ExecuteReader
			dr.Read()
			TBarangProj.Text = If(Not dr.HasRows, "", DirectCast(dr.Item("barang"), String))
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		Finally
			GGVM_conn_close()
		End Try
	End Sub
	Private Sub CxHapusDetailProject_Click(sender As Object, e As EventArgs) Handles CxHapusDetailProject.Click
		Dim Nominal As Double = 0
		Dim ada As Boolean
		Dim brs, jmldt As Integer
		ada = False
		jmldt = 0
		Select Case HapusDetailProject
			Case "HapusBaru"
				ListBiayaProject.BeginUpdate() ' Turn off the ListView
				For I = ListBiayaProject.Items.Count - 1 To 0 Step -1
					If ListBiayaProject.Items(I).Checked = True Then
						ada = True
						brs = I
						jmldt = jmldt + 1
						Nominal = Val(ListBiayaProject.Items(I).SubItems(4).Text - Nominal)
						ListBiayaProject.Items.RemoveAt(I)
					End If
				Next I
				ListBiayaProject.EndUpdate()
				Call NominalBiaya()
			Case "HapusRevisi"
				ListBiayaProject.BeginUpdate() ' Turn off the ListView
				For I = ListBiayaProject.Items.Count - 1 To 0 Step -1
					If ListBiayaProject.Items(I).Checked = True Then
						ada = True
						brs = I
						jmldt = jmldt + 1
						Nominal = Val(ListBiayaProject.Items(I).SubItems(4).Text - Nominal)
						For Each item As ListViewItem In ListBiayaProject.CheckedItems
							GGVM_conn()
							Dim sql1, sql2 As String
							sql1 = "insert into act_dp_temp select * from act_detail_penawaran where iddetail_act = ? "
							cmd = New OdbcCommand
							With cmd
								.CommandText = (sql1)
								.Parameters.Add("@iddetailact", OdbcType.BigInt).Value = Convert.ToInt32(item.SubItems(9).Text)
								.Connection = conn
							End With
							dr = cmd.ExecuteReader
							Console.WriteLine(cmd.CommandText.ToString)
							While dr.Read
								Console.WriteLine(dr(0))
								Console.WriteLine()
							End While
							Console.ReadLine()

							sql2 = "DELETE FROM act_detail_penawaran WHERE iddetail_act = ?"
							cmd = New OdbcCommand
							With cmd
								.CommandText = (sql2)
								.Parameters.Add("@iddetailact", OdbcType.BigInt).Value = Convert.ToInt32(item.SubItems(9).Text)
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
						Next
						Call NominalBiaya()
						Call BacaDetailProject()
					End If
				Next I
				ListBiayaProject.EndUpdate()
		End Select
	End Sub
	'End Textbox Project PE
	'Textbox Instore PE
	Private Sub BtnClearHR_Click(sender As Object, e As EventArgs) Handles BtnClearHR.Click
		Call KondisiBersihHR()
	End Sub
	Private Sub TidDetailSDM_TextChanged(sender As Object, e As EventArgs) Handles TidDetailSDM.TextChanged
		Try
			GGVM_conn()
			sql = ""
			sql = sql & "Select a.*,b.jabatan, c.propinsi,d.kota from act_detail_sdm a"
			sql = sql & " JOIN spg_jabatan b on b.idjabatan = a.idjabatan "
			sql = sql & " JOIN propinsi c on c.idpropinsi = a.idarea "
			sql = sql & " join kota d on d.idkota = a.idkota "
			sql = sql & " where iddetail_sdm ='" & TidDetailSDM.Text & "'"
			da = New OdbcDataAdapter(sql, conn)
			dt = New DataTable
			dt.Clear()
			da.Fill(dt)
			If dt.Rows.Count > 0 Then
				TBasicSalaryHR.Text = dt.Rows(0)("basicsalary")
				If dt.Rows(0)("bpjskes") <> "0" Then
					CAdaBPJS.Checked = True
					TBpjsMed.Text = dt.Rows(0)("bpjskes")
					TBpjsEmp.Text = dt.Rows(0)("bpjstk")
				Else
					CAdaBPJS.Checked = False
				End If
				TPostAllow.Text = dt.Rows(0)("tunjjbt")
				TMeal.Text = dt.Rows(0)("allowmeal")
				TTransport.Text = dt.Rows(0)("allowtrans")
				TMotor.Text = dt.Rows(0)("motorcycle")
				TAtkHR.Text = dt.Rows(0)("allowatk")
				TRentComp.Text = dt.Rows(0)("sewakomp")
				TPulse.Text = dt.Rows(0)("pulsa")
				TMakeUp.Text = dt.Rows(0)("makeup")
				TMeetingCost.Text = dt.Rows(0)("bymeeting")
				TIncentive.Text = dt.Rows(0)("incentive")
				TThr.Text = dt.Rows(0)("thr")
				TTravellingHR.Text = dt.Rows(0)("traveling_cost")
				TEventHR.Text = dt.Rows(0)("event_cost")
				TTelemarketingHR.Text = dt.Rows(0)("telemarketing")
				If dt.Rows(0)("pot_bpjskes") <> "0" Then
					CPotBPJS.Checked = True
					TPotBpjsMed.Text = dt.Rows(0)("pot_bpjskes")
					TPotBpjsEmp.Text = dt.Rows(0)("pot_bpjstk")
				Else
					CPotBPJS.Checked = False
				End If
				TTrainingCost.Text = dt.Rows(0)("training_cost")
				TSubColl.Text = dt.Rows(0)("subcollateb")
				TOvertime.Text = dt.Rows(0)("lembur")
				TidRegionHR.Text = dt.Rows(0)("idregion")
			Else
				TPositionHR.Text = ""
				CAreaHR.Text = ""
				TidRegionHR.Text = ""
				CKotaHR.Text = ""
				TUmk.Text = "0"
				TTahunHR.Text = "0"
				TPeopleHR.Text = "0"
				TBasicSalaryHR.Text = "0"
				TBpjsMed.Text = "0"
				TBpjsEmp.Text = "0"
				TPostAllow.Text = "0"
				TMeal.Text = "0"
				TTransport.Text = "0"
				TMotor.Text = "0"
				TAtkHR.Text = "0"
				TRentComp.Text = "0"
				TPulse.Text = "0"
				TMakeUp.Text = "0"
				TMeetingCost.Text = "0"
				TUangHadir.Text = "0"
				TIncentive.Text = "0"
				TThr.Text = "0"
				TTravellingHR.Text = "0"
				TEventHR.Text = "0"
				TTelemarketingHR.Text = "0"
				TPotBpjsMed.Text = "0"
				TPotBpjsEmp.Text = "0"
				TTrainingCost.Text = "0"
				TSubColl.Text = "0"
				TOvertime.Text = "0"
			End If
			If TBasicSalaryHR.Text = TUmk.Text Then
				CSesuaiUMK.Checked = True
			End If
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		Finally
			GGVM_conn_close()
		End Try
	End Sub
	Private Sub TPositionHR_TextChanged(sender As Object, e As EventArgs) Handles TPositionHR.TextChanged
		GGVM_conn()
		sql = ""
		sql = sql & "select * from spg_jabatan where jabatan = '" & TPositionHR.Text & "'"
		cmd = New OdbcCommand(sql, conn)
		dr = cmd.ExecuteReader
		dr.Read()
		TidPositionHR.Text = If(Not dr.HasRows, "", DirectCast(dr.Item("idjabatan"), Int32))
		GGVM_conn_close()
		dr.Close()
	End Sub
	Private Sub TidPositionHR_TextChanged(sender As Object, e As EventArgs) Handles TidPositionHR.TextChanged
		GGVM_conn()
		sql = ""
		sql = sql & " select * from spg_jabatan where idjabatan = '" & TidPositionHR.Text & "'"
		cmd = New OdbcCommand(sql, conn)
		dr = cmd.ExecuteReader
		dr.Read()
		TPositionHR.Text = If(Not dr.HasRows, "", DirectCast(dr.Item("jabatan"), String))
		GGVM_conn_close()
		dr.Close()
	End Sub
	Private Sub TRegionHR_TextChanged(sender As Object, e As EventArgs) Handles TRegionHR.TextChanged
		Try
			GGVM_conn()
			sql = "Select * from spg_region where region = '" & TRegionHR.Text & "'"
			da = New OdbcDataAdapter(sql, conn)
			dt = New DataTable
			da.Fill(dt)
			TidRegionHR.Text = If(dt.Rows.Count > 0, DirectCast(dt.Rows(0)("idregion"), Int32), "")
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		Finally
			GGVM_conn_close()
		End Try
	End Sub
	Private Sub TidRegionHR_TextChanged(sender As Object, e As EventArgs) Handles TidRegionHR.TextChanged
		Try
			GGVM_conn()
			sql = "Select * from spg_region where idregion = '" & TidRegionHR.Text & "'"
			cmd = New OdbcCommand(sql, conn)
			dr = cmd.ExecuteReader
			dr.Read()
			TRegionHR.Text = If(Not dr.HasRows, "", DirectCast(dr.Item("region"), String))
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		Finally
			GGVM_conn_close()
			'dr.Close()
		End Try
	End Sub
	Private Sub TTahunHR_TextChanged(sender As Object, e As EventArgs) Handles TTahunHR.TextChanged
		GGVM_conn()
		sql = ""
		sql = sql & "select a.basicsalary ,b.idkota from spg_basicsalary a , kota b "
		sql = sql & "WHERE a.kota = b.kota AND b.idkota = '" & TidKotaHR.Text & "' and a.periode = '" & TTahunHR.Text & "'"
		da = New OdbcDataAdapter(sql, conn)
		dt = New DataTable
		da.Fill(dt)
		TUmk.Text = If(dt.Rows.Count > 0, DirectCast(dt.Rows(0)("basicsalary"), Double), "")
		GGVM_conn_close()
		dt.Clear()
	End Sub
	Private Sub TidKotaHR_TextChanged(sender As Object, e As EventArgs) Handles TidKotaHR.TextChanged
		Try
			GGVM_conn()
			sql = "Select  a.kota, b.idregion  from kota a "
			sql = sql & " JOIN spg_kota_region b on a.idkota = b.idkota "
			sql = sql & " where a.idkota ='" & TidKotaHR.Text & "' and a.idpropinsi = '" & TidAreaHR.Text & "'"
			cmd = New OdbcCommand(sql, conn)
			dr = cmd.ExecuteReader
			dr.Read()
			If Not dr.HasRows Then
				CKotaHR.Text = ""
				TidRegionHR.Text = ""
			Else
				CKotaHR.Text = dr.Item("kota")
				TidRegionHR.Text = dr.Item("idregion")
			End If
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		Finally
			GGVM_conn_close()
		End Try
	End Sub
	Private Sub CKotaHR_TextChanged(sender As Object, e As EventArgs) Handles CKotaHR.TextChanged
		Try
			GGVM_conn()
			sql = "Select * from kota where kota ='" & CKotaHR.Text & "' and idpropinsi ='" & TidAreaHR.Text & "' "
			da = New OdbcDataAdapter(sql, conn)
			dt = New DataTable
			da.Fill(dt)
			TidKotaHR.Text = If(dt.Rows.Count > 0, DirectCast(dt.Rows(0)("idkota"), Int32), "")
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		Finally
			GGVM_conn_close()
		End Try
	End Sub
	Private Sub CAreaHR_TextChanged(sender As Object, e As EventArgs) Handles CAreaHR.TextChanged
		Try
			GGVM_conn()
			sql = "SELECT * FROM propinsi a , kota b where a.idpropinsi = b.idpropinsi and a.propinsi ='" & CAreaHR.Text & "'"
			cmd = New Odbc.OdbcCommand(sql, conn)
			dr = cmd.ExecuteReader
			dr.Read()
			If Not dr.HasRows Then
				TidAreaHR.Text = ""
				TidKotaHR.Text = ""
				CKotaHR.Text = ""
				CKotaHR.Items.Clear()
			Else
				TidAreaHR.Text = dr.Item("idpropinsi")
				CKotaHR.Text = ""
				TidKotaHR.Text = ""
				CKotaHR.Items.Clear()
				Call LoadKota()
			End If
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		Finally
			GGVM_conn_close()
		End Try
	End Sub
	Private Sub TidAreaHR_TextChanged(sender As Object, e As EventArgs) Handles TidAreaHR.TextChanged
		Try
			Dim s As String
			GGVM_conn()
			s = "Select * from propinsi where idpropinsi ='" & TidAreaHR.Text & "'"
			cmd = New OdbcCommand(s, conn)
			dr = cmd.ExecuteReader
			dr.Read()
			If Not dr.HasRows Then
				CAreaHR.Text = ""
				TidKotaHR.Text = ""
				CKotaHR.Items.Clear()
			Else
				CAreaHR.Text = dr.Item("propinsi")
				If TBacaIdKota.Text <> "" Then
					TidKotaHR.Text = "" & TBacaIdKota.Text & ""
				End If
			End If
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		Finally
			GGVM_conn_close()
		End Try
	End Sub
	Private Sub CSesuaiUMK_CheckedChanged(sender As Object, e As EventArgs) Handles CSesuaiUMK.CheckedChanged
		If CSesuaiUMK.Checked = True Then
			TBasicSalaryHR.Text = Val(CDbl(TUmk.Text))
		Else
			TBasicSalaryHR.Text = "0"
		End If
	End Sub
	Private Sub CAdaBPJS_CheckedChanged(sender As Object, e As EventArgs) Handles CAdaBPJS.CheckedChanged
		If CAdaBPJS.Checked = True Then
			If TBasicSalaryHR.Text = "0" Then
				MsgBox("Pastikan Basic Salary Sudah Terisi !!...", MsgBoxStyle.Information, "Information")
				Exit Sub
			Else
				TBpjsMed.Text = Math.Round(Val(TBasicSalaryHR.Text * 4) / 100)
				TBpjsEmp.Text = Math.Round(Val(TBasicSalaryHR.Text * 6.24) / 100)
			End If
		Else
			TBpjsMed.Text = "0"
			TBpjsEmp.Text = "0"
		End If
	End Sub
	Private Sub BPotBPJS_Click(sender As Object, e As EventArgs) Handles BPotBPJS.Click
		PPotBPJS.Visible = True
	End Sub
	Private Sub CPotMed_CheckedChanged(sender As Object, e As EventArgs) Handles CPotBPJS.CheckedChanged
		If CPotBPJS.Checked = True Then
			TPotBpjsMed.Text = Math.Round(Val(TBasicSalaryHR.Text * 1) / 100)
			TPotBpjsEmp.Text = Math.Round(Val(TBasicSalaryHR.Text * 3) / 100)
		Else
			TPotBpjsEmp.Text = "0"
			TPotBpjsMed.Text = "0"
		End If
	End Sub
	Private Sub LTutupPBPJS_Click(sender As Object, e As EventArgs) Handles LTutupPBPJS.Click
		PPotBPJS.Visible = False
	End Sub
	Private Sub CTHR_CheckedChanged(sender As Object, e As EventArgs) Handles CTHR.CheckedChanged
		If CTHR.Checked = True Then
			If TBasicSalaryHR.Text = "" Then
				MsgBox("Isi Basic Salary !!", MsgBoxStyle.Information, "Pemberitahuan !!")
				Exit Sub
			Else
				TThr.Text = Math.Round(Val(TBasicSalaryHR.Text) / 12)
			End If
		Else
			TThr.Text = "0"
		End If
	End Sub
	'Keypress
	Private Sub TBasicSalaryHR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBasicSalaryHR.KeyPress
		AturanInput(e)
	End Sub
	Private Sub TBpjsMed_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBpjsMed.KeyPress
		AturanInput(e)
	End Sub
	Private Sub TBpjsEmp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBpjsEmp.KeyPress
		AturanInput(e)
	End Sub
	Private Sub TUangHadir_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TUangHadir.KeyPress
		AturanInput(e)
	End Sub
	Private Sub TRentComp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TRentComp.KeyPress
		AturanInput(e)
	End Sub
	Private Sub TIncentive_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TIncentive.KeyPress
		AturanInput(e)
	End Sub
	Private Sub TThr_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TThr.KeyPress
		AturanInput(e)
	End Sub
	Private Sub TPostAllow_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TPostAllow.KeyPress
		AturanInput(e)
	End Sub
	Private Sub TMeal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TMeal.KeyPress
		AturanInput(e)
	End Sub
	Private Sub TTransport_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TTransport.KeyPress
		AturanInput(e)
	End Sub
	Private Sub TMotor_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TMotor.KeyPress
		AturanInput(e)
	End Sub
	Private Sub TPulse_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TPulse.KeyPress
		AturanInput(e)
	End Sub
	Private Sub TMakeUp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TMakeUp.KeyPress
		AturanInput(e)
	End Sub
	Private Sub TMeetingCost_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TMeetingCost.KeyPress
		AturanInput(e)
	End Sub
	Private Sub TAtk_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TAtkHR.KeyPress
		AturanInput(e)
	End Sub

	Private Sub BtnSimpanEvn_ItemClick(sender As Object, e As ItemClickEventArgs) Handles BtnSimpanEvn.ItemClick
		Call SimpanEvent()
		c = ""
		c = c & "update evn_detail_penawaran set unitcost = '" & TTotalEvn.EditValue & "',sub_totalcost = '" & TTotalEvn.EditValue & "'"
		c = c & "where iddetail = '" & TidDetailCL.Text & "'"
		cmd = New OdbcCommand(c, conn)
		cmd.ExecuteNonQuery()

		NavigationPane1.SelectedPage = DetailPE
		Call BacaMainDetail()
	End Sub

	Private Sub TAgentFeeHR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TAgentFeeHR.KeyPress
		AturanInput(e)
	End Sub
	Private Sub TGrandTotalHR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TGrandTotalHR.KeyPress
		AturanInput(e)
	End Sub
	Private Sub TSubTotalHR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TGross2HR.KeyPress
		AturanInput(e)
	End Sub
	Private Sub TPpnHR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TPpnHR.KeyPress
		AturanInput(e)
	End Sub
	Private Sub TPph23HR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TPph23HR.KeyPress
		AturanInput(e)
	End Sub
	Private Sub TTrainingCost_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TTrainingCost.KeyPress
		AturanInput(e)
	End Sub
	Private Sub TOvertime_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TOvertime.KeyPress
		AturanInput(e)
	End Sub

	'End Keypress
	'End Textbox Instore PE
	Private Sub DGInputHR_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGInputHR.CellMouseDoubleClick
		TPositionHR.Text = DGInputHR.Rows(e.RowIndex).Cells(0).Value
		CKotaHR.Text = DGInputHR.Rows(e.RowIndex).Cells(4).Value
		CAreaHR.Text = DGInputHR.Rows(e.RowIndex).Cells(5).Value
		TidDetailSDM.Text = DGInputHR.Rows(e.RowIndex).Cells(6).Value
		TidKotaHR.Text = DGInputHR.Rows(e.RowIndex).Cells(7).Value
		TidRegionHR.Text = DGInputHR.Rows(e.RowIndex).Cells(8).Value
		TTahunHR.Text = DGInputHR.Rows(e.RowIndex).Cells(9).Value
		TPeopleHR.Text = DGInputHR.Rows(e.RowIndex).Cells(10).Value
		Call NominalBiaya()
	End Sub
	Private Sub ListDetailPEAct_DoubleClick(sender As Object, e As EventArgs) Handles ListDetailPEAct.DoubleClick

		If Me.ListDetailPEAct.SelectedItems.Count > 0 Then
			Dim lvi As ListViewItem = Me.ListDetailPEAct.SelectedItems(0)
			Me.TidDetailCL.Text = lvi.SubItems(6).Text
		Else
			Me.TidDetailCL.Text = String.Empty
		End If
		If TidJenisPE.Text = "5" Then
			GGVM_conn()
			sql = ""
			sql = sql & "select * from act_detail_penawaran where iddetail = '" & TidDetailCL.Text & "'"
			cmd = New OdbcCommand(sql, conn)
			dr = cmd.ExecuteReader
			dr.Read()
			If dr.HasRows = True Then
				NavigationPane1.SelectedPage = DetailEvent
				CJenisDetail.Text = TBarangCL.Text
				TRegionEvn.Text = TJmlEvnCL.Text
				Call BacaDetailBiayaEvn()
			Else
				NavigationPane1.SelectedPage = DetailEvent
				CJenisDetail.Text = TBarangCL.Text
				TRegionEvn.Text = TJmlEvnCL.Text
			End If
		ElseIf TidJenisPE.Text = "6" Then
			NavigationPane1.SelectedPage = DetailProject
			TBarangProj.Text = TBarangCL.Text
			Call BacaDetailProject()
		ElseIf TidJenisPE.Text = "7" Then
			NavigationPane1.SelectedPage = DetailInstore
			PeriodeHR = monthDifference(StartPeriod.Value, EndPeriod.Value)
			TPeriodeHR.Text = PeriodeHR
			Call BacaDetailHR()
		Else
			Return
		End If
	End Sub

	Private Sub ListBiayaEvn_DoubleClick(sender As Object, e As EventArgs) Handles ListBiayaEvn.DoubleClick
		PInpEvent.Visible = True
		If Me.ListBiayaEvn.SelectedItems.Count > 0 Then
			Dim lvi As ListViewItem = Me.ListBiayaEvn.SelectedItems(0)
			Me.TBarangEvn.Text = lvi.SubItems(0).Text
			Me.TQtyEvn.Text = lvi.SubItems(1).Text
			Me.CSatQtyEvn.Text = lvi.SubItems(2).Text
			Me.TFreqEvn.Text = lvi.SubItems(3).Text
			Me.CSatFreqEvn.Text = lvi.SubItems(4).Text
			Me.TRegionEvn.Text = lvi.SubItems(5).Text
			Me.THargaUnitEvn.Text = lvi.SubItems(6).Text
			Me.TSubTotalEvn.Text = lvi.SubItems(7).Text
			Me.TKetPEvn.Text = lvi.SubItems(8).Text
			Me.idQtyEvn.Text = lvi.SubItems(9).Text
			Me.idFreqEvn.Text = lvi.SubItems(10).Text
			Me.idBarangEvn.Text = lvi.SubItems(11).Text
			Me.TidPE.Text = lvi.SubItems(12).Text
			Me.TidDetailCL.Text = lvi.SubItems(13).Text
			Me.TidJenisDetail.Text = lvi.SubItems(14).Text
			Me.TidDetailActEvn.Text = lvi.SubItems(15).Text
			Me.TQuartalPE.EditValue = lvi.SubItems(16).Text
			Me.BInputEvn.Text = "Update"
		Else
			Me.TBarangEvn.Text = String.Empty
			Me.TQtyEvn.Text = String.Empty
			Me.CSatQtyEvn.Text = String.Empty
			Me.TFreqEvn.Text = String.Empty
			Me.CSatFreqEvn.Text = String.Empty
			Me.TRegionEvn.Text = String.Empty
			Me.THargaUnitEvn.Text = String.Empty
			Me.TSubTotalEvn.Text = String.Empty
			Me.TKetPEvn.Text = String.Empty
			Me.idQtyEvn.Text = String.Empty
			Me.idFreqEvn.Text = String.Empty
			Me.idBarangEvn.Text = String.Empty
			Me.TidPE.Text = String.Empty
			Me.TidDetailCL.Text = String.Empty
			Me.TidJenisDetail.Text = String.Empty
			Me.TidDetailActEvn.Text = String.Empty
			Me.TQuartalPE.EditValue = String.Empty
		End If
	End Sub
	Private Sub ListBiayaEvn_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBiayaEvn.SelectedIndexChanged
		If Me.ListBiayaEvn.SelectedIndices.Count > 0 Then
			Me.Label1.Text = String.Format("Item {0} of {1} Selected", Me.ListBiayaEvn.SelectedIndices.Item(0) + 1, Me.ListBiayaEvn.Items.Count)
		End If
		If Me.BInputEvn.Text = "Update" Then
			Me.BInputEvn.Text = "Tambahkan"
		End If
	End Sub
	Private Sub CKuartal_SelectedValueChanged(sender As Object, e As EventArgs) Handles CKuartal.SelectedValueChanged
		Call BacaMainDetail()
		Call BacaDetailBiayaEvn()
	End Sub
	Private Sub AdaPPN_CheckedChanged(sender As Object, e As ItemClickEventArgs) Handles AdaPPN.CheckedChanged
		Call NominalBiaya()
		If AdaPPN.Checked = True Then
			CekPPN.Checked = True
		Else
			CekPPN.Checked = False
		End If
	End Sub
	Private Sub CekPPN_CheckedChanged(sender As Object, e As EventArgs) Handles CekPPN.CheckedChanged
		If CekPPN.Checked = True Then
			AdaPPN.Checked = True
		Else
			AdaPPN.Checked = False
		End If
	End Sub

	Private Sub NavigationPane1_SelectedPageChanging(sender As Object, e As SelectedPageChangingEventArgs) Handles NavigationPane1.SelectedPageChanging
		If NavigationPane1.SelectedPage Is DetailPE Then
			BtnInpDetail.Enabled = False
			If TidJenisPE.Text = "5" Then
				BtnInpEvn.Enabled = True
				BtnSimpanEvn.Enabled = True
				BtnInpProj.Enabled = False
			ElseIf TidJenisPE.Text = "6" Then
				BtnSimpanEvn.Enabled = False
				BtnInpEvn.Enabled = False
				BtnInpProj.Enabled = True
			Else
				BtnInpEvn.Enabled = False
				BtnSimpanEvn.Enabled = False
				BtnInpProj.Enabled = False
			End If
		Else
			BtnInpDetail.Enabled = True
			BtnInpEvn.Enabled = False
			BtnSimpanEvn.Enabled = False
			BtnInpProj.Enabled = False
		End If
	End Sub

	Private Sub ListPEActivation_DoubleClick(sender As Object, e As EventArgs) Handles ListPEActivation.DoubleClick
		Dim ada As Boolean
		Dim jmldt As Integer = 0
		Dim brs As Integer
		For i = 0 To ListPEActivation.Items.Count - 1
			If ListPEActivation.Items(i).Checked = True Then
				ada = True
				brs = i
				jmldt = jmldt + 1
			End If
		Next
		If ada = False Then
			MsgBox("Tidak ada data yang akan di EDIT, Pilih dulu datanya!!...", MsgBoxStyle.Information, "Information")
			ListPEActivation.Focus()
			Exit Sub
		End If
		If jmldt > 1 Then
			MsgBox("Hanya 1(satu) data yg bisa di-EDIT !!...", MsgBoxStyle.Information, "Information")
			ListPEActivation.Focus()
			Exit Sub
		End If
		TidPE.Text = ListPEActivation.Items(brs).SubItems(8).Text
		RevisiPE.Enabled = True
		If TidJenisPE.Text = "5" Then
			CKuartal.Text = "1"
			Call BacaMainDetail()
			Call BacaDetailBiayaEvn()
			Call LoadKuartal()
			CKuartal.Enabled = True
		ElseIf TidJenisPE.Text = "6" Then
			Call BacaMainDetail()
			Call BacaDetailProject()
		ElseIf TidJenisPE.Text = "7" Then
			Call BacaMainDetail()
			Call BacaDetailHR()
		Else
			MsgBox("Hubungi Administrator !!", MsgBoxStyle.Critical, "Eror !!")
		End If
		MsgBox("Klik Revisi Untuk Merubah Data !!", MsgBoxStyle.Information, "Pemberitahuan !!")
		CetakPE.Enabled = True
		RevisiPE.Enabled = True
		HapusPE.Enabled = True
		BatalTools.Enabled = True
		TambahPE.Enabled = False
	End Sub

	Private Sub ListPEActivation_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles ListPEActivation.ItemCheck
		Dim ada As Boolean = False
		Dim jmldt As Integer = 0
		Dim brs As Integer
		For i = 0 To ListPEActivation.Items.Count - 1
			If ListPEActivation.Items(i).Checked = True Then
				ada = True
				brs = i
				jmldt = jmldt + 1
				TidPE.Text = ""
			Else
				TidPE.Text = ListPEActivation.Items(brs).SubItems(8).Text
			End If
		Next
		RevisiPE.Enabled = True
		CetakPE.Enabled = True
		BatalTools.Enabled = True
		HapusPE.Enabled = True
	End Sub

	Private Sub CKontrak_TextChanged(sender As Object, e As EventArgs) Handles CKontrak.TextChanged
		GGVM_conn()
		sql = ""
		sql = sql & "select * from evn_kontrak where valuecontract = '" & CKontrak.Text & "' and iddivisi = '" & DivUser & "' "
		cmd = New OdbcCommand(sql, conn)
		dr = cmd.ExecuteReader
		dr.Read()
		If Not dr.HasRows Then
			TidKontrakAct.Text = ""
		Else
			TidKontrakAct.Text = dr.Item("idkontrak")
		End If
	End Sub
End Class
