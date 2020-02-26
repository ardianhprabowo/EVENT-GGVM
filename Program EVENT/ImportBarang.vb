Imports System.Data.Odbc
Imports System.ComponentModel
Imports ClosedXML.Excel
Imports Microsoft.Office.Interop

Public Class ImportBarang
	Dim tblImport As DataTable
	Private Sub ImportBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Call GGVM_conn()
	End Sub

	Private Sub BtnCari_Click(sender As Object, e As EventArgs) Handles BtnCari.Click
		OpenFileDialog1.ShowDialog()
	End Sub

	Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
		Dim c, kd, s As String
		Dim idsatuan As Integer
		Dim ratecard_gg As Double = 0
		Dim fee_barang As Double = 0
		Dim pph23_barang As Double = 0
		Dim idsubkel, idkelompok, idbarang As Integer

		If DivUser = "18" Then
			idkelompok = "20"
		ElseIf DivUser = "17" Then
			idkelompok = "18"
		ElseIf DivUser = "2" Then
			idkelompok = "7"
		Else
			MsgBox("Tidak BISA IMPORT DATA!", MsgBoxStyle.Critical, "Kesalahan!")
			Exit Sub
		End If
		For baris As Integer = 0 To DataGridView1.Rows.Count - 1
			GGVM_conn()
			c = "select idsubkel from subkelompok WHERE subkel = '" & DataGridView1.Rows(baris).Cells(0).Value & "' and idkelompok = '" & idkelompok & "'"
			cmd = New OdbcCommand(c, conn)
			dr = cmd.ExecuteReader
			dr.Read()
			If Not dr.HasRows Then
				sql = "Insert IGNORE into subkelompok (idkelompok,subkel) values" +
					"('" & idkelompok & "','" & DataGridView1.Rows(baris).Cells(0).Value & "')"
				cmd = New OdbcCommand(sql, conn)
				cmd.ExecuteNonQuery()

				c = ""
				c = c & " Select max(idsubkel)As id from subkelompok "
				da = New OdbcDataAdapter(c, conn)
				dt = New DataTable
				da.Fill(dt)
				If dt.Rows.Count > 0 Then
					idsubkel = dt.Rows(0)("id")
				End If
			Else
				idsubkel = dr.Item("idsubkel")
			End If

			sql = "Insert IGNORE INTO barang_penawaran (idsubkel,barang,harga_pe) VALUES " +
			"('" & idsubkel & "','" & DataGridView1.Rows(baris).Cells(1).Value & "'," +
			"'" & DataGridView1.Rows(baris).Cells(2).Value & "')"
			cmd = New OdbcCommand(sql, conn)
			cmd.ExecuteNonQuery()

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
			ratecard_gg = Math.Round(Val(CDbl(DataGridView1.Rows(baris).Cells(2).Value) * 0.98) / 1.1)
			fee_barang = Math.Round(Val(CDbl(ratecard_gg) * 1.1) - Val(CDbl(ratecard_gg)))
			pph23_barang = Math.Round(Val(CDbl(DataGridView1.Rows(baris).Cells(2).Value))) - Math.Round(Val(CDbl(ratecard_gg) * 1.1))

			c = ""
			c = c & " update barang_penawaran Set"
			c = c & " kdbarang ='" & kd & "', ratecard_gg = '" & ratecard_gg & "', fee = '" & fee_barang & "',"
			c = c & " pph23 = '" & pph23_barang & "'"
			c = c & " where idbarang ='" & idbarang & "'"
			cmd = New OdbcCommand(c, conn)
			cmd.ExecuteNonQuery()

			GGVM_conn_close()

		Next
		MsgBox("Proses Import Selesai!", MsgBoxStyle.Information, "Informasi")
		DataGridView1.DataSource = Nothing
		DataGridView1.Rows.Clear()
		TLokasiExcel.Text = String.Empty
	End Sub

	Private Sub BtnBatal_Click(sender As Object, e As EventArgs) Handles BtnBatal.Click
		DataGridView1.DataSource = Nothing
		DataGridView1.Rows.Clear()
		TLokasiExcel.Text = String.Empty
	End Sub

	Private Sub BtnKeluar_Click(sender As Object, e As EventArgs) Handles BtnKeluar.Click
		Me.Close()
	End Sub

	Private Sub OpenFileDialog1_FileOk(sender As Object, e As CancelEventArgs) Handles OpenFileDialog1.FileOk
		Dim filePath As String = OpenFileDialog1.FileName
		Using workBook As New XLWorkbook(filePath)
			Dim workSheet As IXLWorksheet = workBook.Worksheet(1)
			TLokasiExcel.Text = filePath
			Dim dt As New DataTable()
			Dim firstRow As Boolean = True
			For Each row As IXLRow In workSheet.Rows()
				If firstRow Then
					For Each cell As IXLCell In row.Cells()
						dt.Columns.Add(cell.Value.ToString())
					Next
					firstRow = False
				Else
					dt.Rows.Add()
					Dim i As Integer = 0
					For Each cell As IXLCell In row.Cells()
						dt.Rows(dt.Rows.Count - 1)(i) = cell.Value.ToString()
						i += 1
					Next
				End If
				DataGridView1.DataSource = dt
				DataGridView1.AllowUserToAddRows = False
			Next
		End Using
	End Sub
	Friend myExcel As Excel.Application
	Friend myWorkBookCollection As Excel.Workbooks
	Friend myWorkBook As Excel.Workbook
	Friend myWorkSheet As Excel.Worksheet
	Private xlsFileName As String = Application.StartupPath + "\\Contoh\\import.xlsx"
	Private Sub BtnContoh_Click(sender As Object, e As EventArgs) Handles BtnContoh.Click
		myExcel = New Excel.Application
		If myExcel Is Nothing Then
			MessageBox.Show("Tidak bisa Load Excel.exe")
			Exit Sub
		End If
		myWorkBookCollection = myExcel.Workbooks
		myWorkBook = myWorkBookCollection.Open(xlsFileName)
		myWorkSheet = myWorkBook.Sheets.Item(1)
		myExcel.Visible = True
	End Sub
End Class