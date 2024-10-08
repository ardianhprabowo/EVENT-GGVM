﻿Imports System.Data.Odbc
Imports Microsoft.Office.Interop
Public Class FrmKontrak
#Region "ListView"
	Private Sub ListHeaderKontrak()
		With ListKontrak
			.FullRowSelect = True
			.MultiSelect = False
			.View = View.Details
			.CheckBoxes = False
			.Columns.Clear()
			.Items.Clear()
			.Columns.Add("No.Kontrak", 150, HorizontalAlignment.Left)
			.Columns.Add("Klien", 249, HorizontalAlignment.Left)
			.Columns.Add("idklien", 0, HorizontalAlignment.Left)
			.Columns.Add("idkontrak", 0, HorizontalAlignment.Left)
		End With
	End Sub
	Private Sub ListHeaderMaterial()
		With ListMaterial
			.FullRowSelect = True
			.MultiSelect = False
			.View = View.Details
			.CheckBoxes = False
			.Columns.Clear()
			.Items.Clear()
			.Columns.Add("Barang", 150, HorizontalAlignment.Left)
			.Columns.Add("Item No", 100, HorizontalAlignment.Left)
			.Columns.Add("Material No", 100, HorizontalAlignment.Left)
			.Columns.Add("Price", 100, HorizontalAlignment.Left)
		End With
	End Sub
	Private Sub BacaMaterial()
		GGVM_conn()
		sql = ""
		sql = sql & "SELECT a.*,b.barang from evn_material a "
		sql = sql & " JOIN barang_penawaran b on b.idbarang = a.idbarang "
		sql = sql & " where a.idkontrak = '" & TidKontrak.Text & "' and a.idkontrak = b.idkontrak"
		da = New OdbcDataAdapter(sql, conn)
		ds = New DataSet
		da.Fill(ds, "MaterialItem")
		dt = New DataTable
		dt = ds.Tables(0)
		ListMaterial.Items.Clear()
		ListMaterial.BeginUpdate()
		For j As Integer = 0 To dt.Rows.Count - 1
			With ListMaterial
				.Items.Add(dt.Rows(j)("barang"))
				With .Items(.Items.Count - 1).SubItems
					.Add(dt.Rows(j)("item_no"))
					.Add(dt.Rows(j)("material_no"))
					.Add(dt.Rows(j)("price"))
				End With
			End With
		Next
		ListMaterial.EndUpdate()
		GGVM_conn_close()
	End Sub
#End Region

#Region "Deklarasi Perintah"
	Private Sub AutoCompKlien()
		Try
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
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		End Try
		GGVM_conn_close()
	End Sub
	Private Sub CariKontrak()
		GGVM_conn()
		sql = "Select a.nama,b.* from klien a, evn_kontrak b where a.id = b.idklien and b.valuecontract like '%" & TCariKontrak.Text & "%'"
		da = New OdbcDataAdapter(sql, conn)
		ds = New DataSet
		da.Fill(ds)
		dt = New DataTable
		dt = ds.Tables(0)
	End Sub
	Private Sub KillExcelProcess()
		Try
			Dim Xcel() As Process = Process.GetProcessesByName("EXCEL")
			For Each Process As Process In Xcel
				Process.Kill()
			Next
		Catch ex As Exception
		End Try
	End Sub
	Private Sub TampilData()
		TKlien.Enabled = False
		TKota.Enabled = False
		TAlamat.Enabled = False
		TNilaiKontrak.Enabled = False
		TKontrak.Enabled = False
		DTKontrak.Enabled = False
		DTPrint.Enabled = False
		DTStart.Enabled = False
		DTEnd.Enabled = False
		BBatal.Enabled = False
		BSimpanKontrak.Enabled = False
	End Sub
	Private Sub KondisiBersih()
		TidKlien.Clear()
		TKlien.Clear()
		TNilaiKontrak.Clear()
		TKontrak.Clear()
		BSimpanKontrak.Enabled = False
	End Sub
	Private Sub KondisiTambah()
		TKlien.Enabled = True
		TKota.Enabled = False
		TAlamat.Enabled = False
		TNilaiKontrak.Enabled = True
		TKontrak.Enabled = True
		DTKontrak.Enabled = True
		DTPrint.Enabled = True
		DTStart.Enabled = True
		DTEnd.Enabled = True
		BSimpanKontrak.Enabled = True
		BBatal.Enabled = True
	End Sub
	Private Sub AmbilXLFile()
		Dim xlApp As Excel.Application
		Dim xlWorkbook As Excel.Workbook
		Dim xlWorkSheet As Excel.Worksheet
		Dim xlRange As Excel.Range

		Dim xlCol As Integer
		Dim xlRow As Integer

		Dim strDestination As String
		Dim Data(0 To 100) As String

		With OpenFileDialog1
			.Filter = "Excel Office|*.xls;*.xlsx"
			.FileName = ""
			.ShowDialog()
			strDestination = .FileName

			TCari.Text = .FileName
		End With

		With ListImport
			.View = View.Details
			.FullRowSelect = True
			.GridLines = True
			.Columns.Clear()
			.Items.Clear()
			.Columns.Add("ITEM", 100, HorizontalAlignment.Left)
			.Columns.Add("MATERIAL NO.", 100, HorizontalAlignment.Left)
			.Columns.Add("DESKRIPSI", 250, HorizontalAlignment.Left)
			.Columns.Add("PRICE", 170, HorizontalAlignment.Left)
			.Columns.Add("QUANTITY", 100, HorizontalAlignment.Left)
			.Columns.Add("PERIODE", 100, HorizontalAlignment.Left)

			If strDestination <> "" And InputSheetName.Text <> "" Then
				xlApp = New Excel.Application

				xlWorkbook = xlApp.Workbooks.Open(strDestination)
				xlWorkSheet = xlWorkbook.Worksheets(InputSheetName.Text)
				xlRange = xlWorkSheet.UsedRange

				If xlRange.Columns.Count > 0 Then
					If xlRange.Rows.Count > 0 Then

						''Header
						'For xlCol = 1 To xlRange.Columns.Count
						'	.Columns.Add("Column" & xlCol)
						'Next

						'Detail
						For xlRow = 2 To xlRange.Rows.Count
							For xlCol = 1 To xlRange.Columns.Count
								Data(xlCol) = xlRange.Cells(xlRow, xlCol).text
								If xlCol = 1 Then
									.Items.Add(Data(xlCol).ToString)
								Else
									.Items(xlRow - 2).SubItems.Add(Data(xlCol).ToString)
								End If
							Next
						Next
						xlWorkbook.Close()
						xlApp.Quit()

						KillExcelProcess()
					End If
				End If
			Else
				MessageBox.Show("Pls. input correct attributes", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
			End If
		End With
	End Sub
	Private Sub BacaKontrak()
		GGVM_conn()
		sql = ""
		sql = sql & "Select a.nama,b.* from klien a, evn_kontrak b where a.id = b.idklien"
		da = New OdbcDataAdapter(sql, conn)
		ds = New DataSet
		da.Fill(ds)
		dt = New DataTable
		dt = ds.Tables(0)
		ListKontrak.Items.Clear()
		ListKontrak.BeginUpdate()
		For j As Integer = 0 To dt.Rows.Count - 1
			With ListKontrak
				.Items.Add(dt.Rows(j)("valuecontract"))
				With .Items(.Items.Count - 1).SubItems
					.Add(dt.Rows(j)("nama"))
					.Add(dt.Rows(j)("idklien"))
					.Add(dt.Rows(j)("idkontrak"))
				End With
			End With
		Next
		ListKontrak.EndUpdate()
		GGVM_conn_close()
	End Sub
	Private Sub ComboSubKategori()
		GGVM_conn()
		Try
			CSubKel.Items.Clear()

			cmd = New OdbcCommand("select * from subkelompok where idsubkel in ('71','110')", conn)
			dr = cmd.ExecuteReader
			Do While dr.Read
				CSubKel.Items.Add(dr("subkel"))
			Loop
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		End Try
		GGVM_conn_close()
	End Sub
#End Region

	Private Sub FrmKontrak_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Call TampilData()
		Call ListHeaderKontrak()
		Call BacaKontrak()
		Call AutoCompKlien()
		Call ListHeaderMaterial()
		Call ComboSubKategori()
	End Sub

	Private Sub TidKlien_TextChanged(sender As Object, e As EventArgs) Handles TidKlien.TextChanged
		GGVM_conn()
		sql = "select * from klien where id='" & TidKlien.Text & "'"
		cmd = New OdbcCommand(sql, conn)
		dr = cmd.ExecuteReader
		dr.Read()
		If Not dr.HasRows Then
			TKlien.Text = ""
			TAlamat.Text = ""
			'TKota.Text = ""
		Else
			TKlien.Text = dr.Item("nama")
			TAlamat.Text = dr.Item("alamat")
			TKota.Text = dr.Item("kota")
		End If
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
			Else
				TidKlien.Text = dr.Item("id")
			End If
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		Finally
			GGVM_conn_close()
		End Try
	End Sub
	Private Sub CariExcel_Click(sender As Object, e As EventArgs) Handles CariExcel.Click
		Try
			Call AmbilXLFile()
		Catch ex As Exception
			MsgBox("Terjadi Kesalahan !" & ex.Message)
		End Try
	End Sub
	Private Sub ImportBtn_Click(sender As Object, e As EventArgs) Handles ImportBtn.Click
		Dim c, kd, s As String
		Dim ratecard_gg As Double = 0
		Dim fee_barang As Double = 0
		Dim pph23_barang As Double = 0
		Dim idbarang As Integer
		For Each item As ListViewItem In ListImport.Items
			Dim harga As Double
			Double.TryParse(item.SubItems(3).Text, harga)
			GGVM_conn()
			sql = ""
			sql = sql & "insert barang_penawaran (idsubkel,barang,"
			sql = sql & "idsatuan,harga_pe,idkontrak)"
			sql = sql & "values ('" & TidSubkel.Text & "',?,?,?,'" & TidKontrak.Text & "')"
			cmd = New OdbcCommand
			With cmd
				.CommandText = (sql)
				'.Parameters.Add("@idsubkel", OdbcType.Int).Value = Convert.ToInt32("71")
				'.Parameters.Add("@kdbarang", OdbcType.Char).Value = item.Text
				.Parameters.Add("@brg", OdbcType.VarChar).Value = item.SubItems(2).Text
				.Parameters.Add("@idsat", OdbcType.Int).Value = Convert.ToInt32("1")
				.Parameters.Add("@harga_pe", OdbcType.Double).Value = item.SubItems(3).Text
				'.Parameters.Add("@kontrak", OdbcType.BigInt).Value = Convert.ToInt32("1")
				.Connection = conn
			End With
			dr = cmd.ExecuteReader
			Console.WriteLine(cmd.CommandText.ToString)
			While dr.Read
				Console.WriteLine(dr(0))
				Console.WriteLine()
			End While
			Console.ReadLine()


			'Count Kode Barang
			s = ""
			s = s & " Select max(idbarang)As id from barang_penawaran "
			cmd = New OdbcCommand(s, conn)
			dr = cmd.ExecuteReader
			dr.Read()
			kd = "000000" + dr.GetString(0)
			kd = Microsoft.VisualBasic.Right(kd, 6)
			idbarang = dr.Item("id")

			'Fill ID Barang
			sql = ""
			sql = sql & " Select max(idbarang)As id from barang_penawaran "
			da = New OdbcDataAdapter(sql, conn)
			dt = New DataTable
			da.Fill(dt)
			If dt.Rows.Count > 0 Then
				idbarang = dt.Rows(0)("id")
			End If
			'Fill Kode Barang
			ratecard_gg = Math.Round(Val(CDbl(item.SubItems(3).Text) * 0.98) / 1.1)
			fee_barang = Math.Round(Val(CDbl(ratecard_gg) * 1.1) - Val(CDbl(ratecard_gg)))
			pph23_barang = Math.Round(Val(CDbl(item.SubItems(3).Text))) - Math.Round(Val(CDbl(ratecard_gg) * 1.1))

			c = ""
			c = c & " update barang_penawaran Set"
			c = c & " kdbarang ='" & kd & "', ratecard_gg = '" & ratecard_gg & "', fee = '" & fee_barang & "',"
			c = c & " pph23 = '" & pph23_barang & "'"
			c = c & " where idbarang ='" & idbarang & "'"
			cmd = New OdbcCommand(c, conn)
			cmd.ExecuteNonQuery()

			'GGVM_conn_close()

			Dim itemno As Integer
			Dim price As Decimal
			Integer.TryParse(item.SubItems(0).Text, itemno)
			'	Integer.TryParse(item.SubItems(6).Text, idbrg)
			Decimal.TryParse(item.SubItems(3).Text, price)
			GGVM_conn()
			sql = ""
			sql = sql & "insert evn_material (idkontrak,idbarang,item_no,"
			sql = sql & "material_no,price,qty,periode)"
			sql = sql & "values ('" & TidKontrak.Text & "','" & idbarang & "',?,?,?,?,?)"
			cmd = New OdbcCommand
			With cmd
				.CommandText = (sql)
				'	.Parameters.Add("@kontrak", OdbcType.BigInt).Value = Convert.ToInt32(" & TKontrak.Text & ")
				'.Parameters.Add("@idbarang", OdbcType.BigInt).Value = idbrg
				.Parameters.Add("@item_no", OdbcType.Int).Value = item.Text
				.Parameters.Add("@material", OdbcType.VarChar).Value = item.SubItems(1).Text
				.Parameters.Add("@price", OdbcType.Decimal).Value = item.SubItems(3).Text
				.Parameters.Add("@qty", OdbcType.Double).Value = item.SubItems(4).Text
				.Parameters.Add("@periode", OdbcType.Double).Value = item.SubItems(5).Text
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

			Call TampilData()
			Call KondisiBersih()
		Next
		NavImportKontrak.PageVisible = False
		NavKontrak.SelectedPage = NavDetailKontrak
	End Sub
	Private Sub BImport_Click(sender As Object, e As EventArgs) Handles BImport.Click
		NavImportKontrak.PageVisible = True
		NavKontrak.SelectedPage = NavImportKontrak
	End Sub
	Private Sub BDaftarKontrak_Click(sender As Object, e As EventArgs) Handles BDaftarKontrak.Click
		Try
			PDaftar.Visible = True
			TCariKontrak.Select()
		Catch ex As Exception
			MsgBox("Terjadi Kesalahan! " & ex.Message)
		End Try
	End Sub
	Private Sub ListKontrak_DoubleClick(sender As Object, e As EventArgs) Handles ListKontrak.DoubleClick
		With Me.ListKontrak
			Dim i As Integer
			For Each item As ListViewItem In ListKontrak.SelectedItems
				i = item.Index
			Next
			Dim innercounter As Integer = 0
			For Each subItem As ListViewItem.ListViewSubItem In ListKontrak.Items(i).SubItems
				Dim myString As String = ListKontrak.Items(i).SubItems(innercounter).Text
				Select Case innercounter
					Case 3
						TidKontrak.Text = myString
				End Select
				innercounter += 1

			Next
			Call BacaMaterial()
			PDaftar.Visible = False
		End With
	End Sub
	Private Sub TCariKontrak_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TCariKontrak.KeyPress
		Try
			Call CariKontrak()
			ListKontrak.Items.Clear()
			ListKontrak.BeginUpdate()
			For j As Integer = 0 To dt.Rows.Count - 1
				With ListKontrak
					.Items.Add(dt.Rows(j)("valuecontract"))
					With .Items(.Items.Count - 1).SubItems
						.Add(dt.Rows(j)("nama"))
						.Add(dt.Rows(j)("idklien"))
						.Add(dt.Rows(j)("idkontrak"))
					End With
				End With
			Next
			ListKontrak.EndUpdate()
			ListKontrak.Items.Clear()
			Call BacaKontrak()

			If TCariKontrak.Text = "" Then
				Call BacaKontrak()
			End If
		Catch ex As Exception
			MsgBox("Terjadi Kesalahan! " & ex.Message)
		End Try
	End Sub
	Private Sub BSimpanKontrak_Click(sender As Object, e As EventArgs) Handles BSimpanKontrak.Click
		GGVM_conn()
		Dim periode, c As String
		periode = Microsoft.VisualBasic.Right(DTEnd.Text, 4)
		sql = ""
		sql = sql & "insert into evn_kontrak (valuecontract,idklien,start_date,end_date,periode,printed,contract_value)"
		sql = sql & "values ('" & TKontrak.Text & "','" & TidKlien.Text & "','" & Format(DTStart.Value, "yyyy/MM/dd") & "','" & Format(DTEnd.Value, "yyyy/MM/dd") & "',"
		sql = sql & "'" & periode & "','" & Format(DTPrint.Value, "yyyy/MM/dd") & "','" & TNilaiKontrak.Text & "')"
		cmd = New OdbcCommand(sql, conn)
		cmd.ExecuteNonQuery()

		c = ""
		c = c & " Select max(idkontrak)As id from evn_kontrak "
		da = New OdbcDataAdapter(c, conn)
		dt = New DataTable
		da.Fill(dt)
		If dt.Rows.Count > 0 Then
			TidKontrak.Text = dt.Rows(0)("id")
		End If
		GGVM_conn_close()
		conn.Dispose()
	End Sub
	Private Sub TidK_TextChanged(sender As Object, e As EventArgs)

	End Sub
	Private Sub TambahKontrak_Click(sender As Object, e As EventArgs) Handles TambahKontrak.Click
		Try
			Call KondisiTambah()
		Catch ex As Exception
			MsgBox("Terjadi Kesalahan! " & ex.Message)
		End Try
	End Sub

	Private Sub BBatal_Click(sender As Object, e As EventArgs) Handles BBatal.Click
		Try
			Call KondisiBersih()
			Call TampilData()
		Catch ex As Exception
			MsgBox("Terjadi Kesalahan! " & ex.Message)
		End Try
	End Sub

	Private Sub BTutupKontrak_Click(sender As Object, e As EventArgs) Handles BTutupKontrak.Click
		PDaftar.Visible = False
		TCariKontrak.Text = ""
	End Sub

	Private Sub BKeluar_Click(sender As Object, e As EventArgs) Handles BKeluar.Click
		For i = System.Windows.Forms.Application.OpenForms.Count - 1 To 1 Step -1
			Dim form As Form = System.Windows.Forms.Application.OpenForms(i)
			Me.Close()
		Next i
	End Sub

	Private Sub CSubKel_TextChanged(sender As Object, e As EventArgs) Handles CSubKel.TextChanged
		Try
			GGVM_conn()
			sql = ""
			sql = sql & "Select * from subkelompok where subkel = '" & CSubKel.Text & "'"
			cmd = New OdbcCommand(sql, conn)
			dr = cmd.ExecuteReader
			dr.Read()
			If Not dr.HasRows Then
				TidSubkel.Text = ""
			Else
				TidSubkel.Text = dr.Item("idsubkel")
			End If
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		Finally
			GGVM_conn_close()
		End Try
	End Sub

	Private Sub TidKontrak_TextChanged(sender As Object, e As EventArgs) Handles TidKontrak.TextChanged
		Try
			GGVM_conn()
			sql = "Select a.nama,a.alamat,a.kota,a.id,b.* from klien a, evn_kontrak b where a.id = b.idklien and b.idkontrak =  '" & TidKontrak.Text & "'"
			da = New OdbcDataAdapter(sql, conn)
			dt = New DataTable
			da.Fill(dt)
			If dt.Rows.Count > 0 Then
				TKlien.Text = dt.Rows(0)("nama")
				TAlamat.Text = dt.Rows(0)("alamat")
				TKota.Text = dt.Rows(0)("kota")
				TKontrak.Text = dt.Rows(0)("valuecontract")
				TNilaiKontrak.Text = dt.Rows(0)("contract_value")
				DTStart.CustomFormat = "yyyy/MM/dd"
				DTStart.Value = dt.Rows(0)("start_date")
				DTEnd.CustomFormat = "yyyy/MM/dd"
				DTEnd.Value = dt.Rows(0)("end_date")
				DTPrint.CustomFormat = "yyyy/MM/dd"
				DTPrint.Value = dt.Rows(0)("printed")
				TidKlien.Text = dt.Rows(0)("id")
			Else
				TKlien.Text = ""
				TKota.Text = ""
				TAlamat.Text = ""
				TKontrak.Text = ""
				TNilaiKontrak.Text = ""
				DTStart.Value = DateTime.Now
				DTEnd.Value = DateTime.Now
				DTPrint.Value = DateTime.Now
				TidKlien.Text = ""
			End If
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		Finally
			GGVM_conn_close()
		End Try
	End Sub
End Class