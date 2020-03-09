Option Strict Off
Imports System.Data.Odbc
Imports System.Math
Public Class FrmBarang
    Dim s, idM As String
    Private Panel1Captured As Boolean
    Private Panel1Grabbed As Point
    Private Sub FrmBarang_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            Call AutoCompBarangPenawaran()
            Call AutoCompKontrak()
            Call ComboSatuan()
            Call ListHeaderBarangPenawaran()
			Call ListHeaderAktual()
			Call BersihBarang()
			'Call TampilBarangAktual()
			'Call TampilBarangPenawaran()
		Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub
#Region "AUTOCOMPLETE"
    Private Sub AutoCompBarangAktual()
        Try
            GGVM_conn()
            sql = ""
            sql = sql & "SELECT xbrg.* FROM ( SELECT c.barang,c.kdbarang "
            sql = sql & "FROM	subkelompok a,	kelompok b,	barang_penawaran c, evn_barang_aktual d "
            sql = sql & " WHERE a.idkelompok = b.idkelompok AND c.idsubkel = a.idsubkel "
            sql = sql & "AND b.idkelompok NOT IN ( 3, 7, 8, 9, 10, 11, 13, 14 )"
            sql = sql & ") as xbrg"
            da = New OdbcDataAdapter(sql, conn)
            ds = New DataSet
            da.Fill(ds)
            Dim Aktual As New AutoCompleteStringCollection
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                Aktual.Add(ds.Tables(0).Rows(i)("barang"))
            Next
            With TBAktual
                .AutoCompleteSource = AutoCompleteSource.CustomSource
                .AutoCompleteCustomSource = Aktual
                .AutoCompleteMode = AutoCompleteMode.Suggest
            End With
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
        GGVM_conn_close()
    End Sub
    Private Sub AutoCompBarangPenawaran()
        GGVM_conn()
        Try
            If DivUser = "0" Then
                sql = "select a.barang from barang_penawaran a, subkelompok b, kelompok c WHERE c.idkelompok = b.idkelompok and b.idsubkel = a.idsubkel and b.idkelompok in (7,18,20)"
            End If
            If DivUser = "2" Then
                sql = "select a.barang from barang_penawaran a, subkelompok b, kelompok c WHERE c.idkelompok = b.idkelompok and b.idsubkel = a.idsubkel and b.idkelompok = '7'"
            End If
            If DivUser = "17" Then
                sql = "select a.barang from barang_penawaran a, subkelompok b, kelompok c WHERE c.idkelompok = b.idkelompok and b.idsubkel = a.idsubkel and b.idkelompok = '18'"
            End If
            If DivUser = "18" Then
                sql = "select a.barang from barang a, subkelompok b, kelompok c WHERE c.idkelompok = b.idkelompok and b.idsubkel = a.idsubkel and b.idkelompok = '20'"
            End If
            da = New OdbcDataAdapter(sql, conn)
            ds = New DataSet
            da.Fill(ds)
            Dim Penawaran As New AutoCompleteStringCollection
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                Penawaran.Add(ds.Tables(0).Rows(i)("barang"))
            Next
            With TBarangPE
                .AutoCompleteSource = AutoCompleteSource.CustomSource
                .AutoCompleteCustomSource = Penawaran
                .AutoCompleteMode = AutoCompleteMode.Suggest
            End With
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
        GGVM_conn_close()
        da.Dispose()
        conn.Dispose()
    End Sub
    Private Sub AutoCompKontrak()
        GGVM_conn()
        Try
            sql = "SELECT a.idkontrak,a.valuecontract, b.nama from evn_kontrak a, klien b where a.idklien = b.id"
            da = New OdbcDataAdapter(sql, conn)
            ds = New DataSet
            da.Fill(ds)
            Dim ValueKontrak As New AutoCompleteStringCollection
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                ValueKontrak.Add(ds.Tables(0).Rows(i)("nama"))
            Next
            With TKontrak
                .AutoCompleteSource = AutoCompleteSource.CustomSource
                .AutoCompleteCustomSource = ValueKontrak
                .AutoCompleteMode = AutoCompleteMode.Suggest
            End With
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
        GGVM_conn_close()
        da.Dispose()
        conn.Dispose()
    End Sub
#End Region
#Region "COMBOBOX"
    Private Sub ComboKategori()
        GGVM_conn()
        Try
            CKategori.Items.Clear()
            sql = ""
            If DivUser = "0" Then
                sql = sql & "Select kelompok, idkelompok from kelompok where idkelompok in (7,12,18,19,20,21)"
            Else
                sql = sql & "Select kelompok, idkelompok from kelompok where iddivisi = '" & DivUser & "'"
            End If
            cmd = New OdbcCommand(sql, conn)
            dr = cmd.ExecuteReader
            Do While dr.Read
                CKategori.Items.Add(dr("kelompok"))
            Loop
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
        GGVM_conn_close()
    End Sub
    Private Sub ComboSubKategori()
        GGVM_conn()
        Try
			CSubKat.Items.Clear()
			cmd = New OdbcCommand("select * from subkelompok where idkelompok = '" & TidKel.Text & "'", conn)
            dr = cmd.ExecuteReader
            Do While dr.Read
                CSubKat.Items.Add(dr("subkel"))
            Loop
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
        GGVM_conn_close()
    End Sub
    Private Sub ComboSatuan()
        GGVM_conn()
        Try
            CSatuan.Items.Clear()
            cmd = New OdbcCommand("Select * from satuan", conn)
            dr = cmd.ExecuteReader
            Do While dr.Read
                CSatuan.Items.Add(dr("satuan"))
            Loop
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
        GGVM_conn_close()
    End Sub
    Private Sub ComboKota()
        Try
            GGVM_conn()
            CBKota.Items.Clear()
            cmd = New OdbcCommand("Select * from kota", conn)
            dr = cmd.ExecuteReader
            Do While dr.Read
                CBKota.Items.Add(dr("kota"))
            Loop
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
        GGVM_conn_close()
    End Sub
#End Region
#Region "Deklarasi Perintah"
    Sub BersihBarang()
        TBarangInp.Text = ""
        idBaca.Text = ""
        TBacaStatus.Text = ""
        CKategori.Text = ""
        CSubKat.Text = ""
        TidKel.Text = ""
        TidBarangPE.Text = ""
        TidSubkel.Text = ""
        TBacaSubkel.Text = ""
        KdBarang.Text = ""
        TKet.Text = ""
        TT.Text = ""
        TL.Text = ""
        TP.Text = ""
        HasilX.Text = ""
        TidSatuan.Text = ""
        THargaUnit.Text = ""
        TMaterial.Text = ""
        TBarangPE.Text = ""
        TidKontrak.Text = ""
        TKontrak.Text = ""
        CSatuan.Text = ""
        TidSatuan.Text = ""
        CSubKat.Text = ""
        CKategori.Text = ""
        SimpanBarangPE.Enabled = False
        CKategori.Enabled = False
        CSubKat.Enabled = False
        TBarangInp.Enabled = True
		TKet.Enabled = False
		TMaterial.Enabled = False
		THargaUnit.Enabled = False
        TT.Enabled = False
        TP.Enabled = False
        TL.Enabled = False
        BtnHasilX.Enabled = False
        SimpanBarangPE.Enabled = False
    End Sub
    Sub DataBaru()
        CKategori.Enabled = True
        CSubKat.Enabled = True
        TBarangInp.Enabled = True
		TKet.Enabled = True
		TMaterial.Enabled = True
		THargaUnit.Enabled = True
        TT.Enabled = True
        TP.Enabled = True
        TL.Enabled = True
        BtnHasilX.Enabled = True
        SimpanBarangPE.Enabled = True
    End Sub
    Sub EditData()
        CKategori.Enabled = True
		CSubKat.Enabled = True
		TMaterial.Enabled = True
		TBarangInp.Enabled = False
        THargaUnit.Enabled = True
        TKet.Enabled = True
        TT.Enabled = True
        TP.Enabled = True
        TL.Enabled = True
        BtnHasilX.Enabled = True
        SimpanBarangPE.Enabled = True
    End Sub
    Sub BacaMaterial()
        GGVM_conn()
        s = ""
        s = s & "select barangmaterial from evn_material_aktual where idbarang_pe ='" & idBaca.Text & "' "
        cmd = New OdbcCommand(s, conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If Not dr.HasRows Then
            TMaterial.Text = ""
        Else
            TMaterial.Text = dr.Item("barangmaterial").ToString
        End If
        GGVM_conn_close()
    End Sub
    Private Sub SimpanAktual()
        Dim c As String
        GGVM_conn()
        If TBAktual.Text = "" Or TJumlah.Text = "" Or TPanjang.Text = "" Then
            MsgBox("Data Tidak Lengkap!", MsgBoxStyle.Critical, "Message !!")
            Exit Sub
        Else
            sql = "select * from evn_barang_aktual where idbarang = '" & TidBarangA.Text & "'"
            cmd = New OdbcCommand(sql, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If Not dr.HasRows Then
                If MsgBox("Apakah data ingin disimpan??", MsgBoxStyle.Information Or MsgBoxStyle.YesNo, "Pemberitahuan !!") = MsgBoxResult.Yes Then
                    Try
                        sql = ""
                        sql = sql & "insert into evn_barang_aktual (idbarang,idbarang_pe,"
                        If TLebar.Text <> "" Then
                            sql = sql & "lebar,"
                        End If
                        If TPanjang.Text <> "" Then
                            sql = sql & "panjang,"
                        End If
                        If TTinggi.Text <> "" Then
                            sql = sql & "tinggi,"
                        End If
                        sql = sql & "jml)"
                        sql = sql & "value ('" & TidBarangA.Text & "','" & TidBarangPE.Text & "',"
                        If TLebar.Text <> "" Then
                            sql = sql & "'" & TLebar.Text & "',"
                        End If
                        If TPanjang.Text <> "" Then
                            sql = sql & "'" & TPanjang.Text & "',"
                        End If
                        If TTinggi.Text <> "" Then
                            sql = sql & "'" & TTinggi.Text & "',"
                        End If
                        sql = sql & "'" & TJumlah.Text & "')"
                        cmd = New OdbcCommand(sql, conn)
                        cmd.ExecuteNonQuery()

                        c = ""
                        c = c & " Select max(idaktual)As id from evn_barang_aktual "
                        da = New OdbcDataAdapter(c, conn)
                        dt = New DataTable
                        da.Fill(dt)
                        If dt.Rows.Count > 0 Then
                            TidAktual.Text = dt.Rows(0)("id")
                        End If

                        If idKotaBK.Text AndAlso TNominalBK.Text <> "" Then
                            sql = "insert into evn_budget_kota (idaktual,idkota,nominal) values ('" & TidAktual.Text & "','" & idKotaBK.Text & "','" & TNominalBK.Text & "')"
                            cmd = New OdbcCommand(sql, conn)
                            cmd.ExecuteNonQuery()
                        End If
                        MsgBox("Data sudah di-SIMPAN !!..", MsgBoxStyle.Information, "Information")
                        Call TampilBarangAktual()
                        Call TampilBarangPenawaran()
                    Catch ex As Exception
                        MsgBox("Data Gagal di Simpan", MsgBoxStyle.Critical, "Message !!")
                        Exit Sub
                    End Try
                    GGVM_conn_close()
                End If
            Else
                If MsgBox("Apakah data ingin di Perbarui??", MsgBoxStyle.Information Or MsgBoxStyle.YesNo, "Pemberitahuan !!") = MsgBoxResult.Yes Then
                    Try
                        sql = ""
                        sql = sql & "update set evn_barang_aktual idbarang ='" & TidBarangA.Text & "', idbarang_pe = '" & TidBarangPE.Text & "', "
                        sql = sql & "panjang = '" & TPanjang.Text & "',tinggi = '" & TTinggi.Text & "',jml = '" & TJumlah.Text & "'"
                        cmd = New OdbcCommand(sql, conn)
                        cmd.ExecuteNonQuery()
                        MsgBox("Data sudah di-perbarui !!..", MsgBoxStyle.Information, "Information")
                        Call TampilBarangAktual()
                        Call TampilBarangPenawaran()
                    Catch ex As Exception
                        MsgBox("Data Gagal di perbarui", MsgBoxStyle.Critical, "Message !!")
                        Exit Sub
                    End Try
                    GGVM_conn_close()
                End If
            End If
        End If
        GGVM_conn_close()
    End Sub
#End Region
    Private Sub ListHeaderBarangPenawaran()
        With ListBarangPenawaran
            .FullRowSelect = True
            .MultiSelect = False
            .View = View.Details
            .CheckBoxes = False
            .Columns.Clear()
            .Items.Clear()
            .Columns.Add("Kode Barang", 90, HorizontalAlignment.Left)
            .Columns.Add("Barang Penawaran", 250, HorizontalAlignment.Left)
            .Columns.Add("idbarang", 0, HorizontalAlignment.Left)
        End With
    End Sub
    Private Sub TampilBarangPenawaran()
        Try
            GGVM_conn()
            If TidBarangA.Text = "" Then
                If DivUser = CInt("2") Then
                    sql = "select a.barang from barang a, subkelompok b, kelompok c WHERE c.idkelompok = b.idkelompok and b.idsubkel = a.idsubkel and b.idkelompok = '7' "
                ElseIf DivUser = CInt("17") Then
                    sql = "select a.barang from barang a, subkelompok b, kelompok c WHERE c.idkelompok = b.idkelompok and b.idsubkel = a.idsubkel and b.idkelompok = '18'"
                ElseIf DivUser = CInt("18") Then
                    sql = "select a.barang from barang a, subkelompok b, kelompok c WHERE c.idkelompok = b.idkelompok and b.idsubkel = a.idsubkel and b.idkelompok = '20'"
                ElseIf DivUser = CInt("0") Then
                    sql = "select a.barang from barang a, subkelompok b, kelompok c WHERE c.idkelompok = b.idkelompok and b.idsubkel = a.idsubkel and b.idkelompok in (7,18,20)"
                End If
            Else
                sql = ""
                sql = sql & "select b.kdbarang, b.barang,a.* from evn_barang_aktual a  "
                sql = sql & " join barang_penawaran b on a.idbarang_pe = b.idbarang and a.idbarang ='" & TidBarangA.Text & "' "
                sql = sql & " group by barang"
            End If
            da = New Odbc.OdbcDataAdapter(sql, conn)
            ds.Clear()
            dt = New DataTable
            dt.Clear()
            da.Fill(dt)
            ListBarangPenawaran.Items.Clear()
            ListBarangPenawaran.BeginUpdate()
            For i = 0 To dt.Rows.Count - 1
                With ListBarangPenawaran
                    .Items.Add(dt.Rows(i)("kdbarang"))
                    With .Items(.Items.Count - 1).SubItems
                        .Add(dt.Rows(i)("barang"))
                        .Add(dt.Rows(i)("idbarang"))
                    End With
                End With
            Next
            ListBarangPenawaran.EndUpdate()
        Catch ex As Exception
            MsgBox("Terjadi kesalahan ! " & ex.Message)
        End Try
        GGVM_conn_close()
        dt.Clear()
        'conn.Dispose()
    End Sub
    Private Sub ListHeaderAktual()
        With ListAktual
            .FullRowSelect = True
            .MultiSelect = False
            .View = View.Details
            .CheckBoxes = False
            .Columns.Clear()
            .Items.Clear()
            .Columns.Add("Kode Barang", 90, HorizontalAlignment.Left)
            .Columns.Add("Barang Aktual", 300, HorizontalAlignment.Left)
            .Columns.Add("idbarang", 0, HorizontalAlignment.Left)
            .Columns.Add("idbarang_pe", 0, HorizontalAlignment.Left)
        End With
    End Sub
    Private Sub TampilBarangAktual()
        Try
            GGVM_conn()
            sql = ""
            sql = sql & "select b.kdbarang,b.barang,a.* from evn_barang_aktual a "
            sql = sql & " join barang_penawaran b on a.idbarang = b.idbarang "
            If TidBarangPE.Text <> "" Then
                sql = sql & " where a.idbarang_pe ='" & TidBarangPE.Text & "' "
            End If
            sql = sql & " group by barang"
            da = New Odbc.OdbcDataAdapter(sql, conn)
            ds.Clear()
            dt = New DataTable
            dt.Clear()
            da.Fill(dt)
            ListAktual.Items.Clear()
            ListAktual.BeginUpdate()
            For i = 0 To dt.Rows.Count - 1
                With ListAktual
                    .Items.Add(dt.Rows(i)("kdbarang"))
                    With .Items(.Items.Count - 1).SubItems
                        .Add(dt.Rows(i)("barang"))
                        .Add(dt.Rows(i)("idbarang"))
                        .Add(dt.Rows(i)("idbarang_pe"))
                    End With
                End With
            Next
            ListAktual.EndUpdate()
        Catch ex As Exception
            MsgBox("Terjadi kesalahan ! " & ex.Message)
        End Try
        GGVM_conn_close()
        dt.Clear()
        conn.Dispose()
    End Sub
    Private Sub TBarangInp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBarangInp.KeyPress
        If e.KeyChar = Chr(13) Then
            Call ComboKategori()
            GGVM_conn()
            s = ""
            s = s & "select a.idbarang,a.idsubkel,a.idsatuan,a.dimensi, a.kdbarang , a.barang, a.keterangan, a.harga_pe, b.idkelompok "
            s = s & " from barang_penawaran a, subkelompok b, kelompok c"
            s = s & " WHERE c.idkelompok = b.idkelompok and b.idsubkel = a.idsubkel "
            If DivUser = "17" Then
                s = s & "And b.idkelompok = '18' And a.barang = '" & TBarangInp.Text & "'"
            ElseIf DivUser = "18" Then
                s = s & "And b.idkelompok = '20' and a.barang = '" & TBarangInp.Text & "'"
            ElseIf DivUser = "0" Then
                s = s & "And b.idkelompok in (7,18,20) And a.barang = '" & TBarangInp.Text & "'"
            Else
                Return
            End If
            da = New OdbcDataAdapter(s, conn)
            dt = New DataTable
            dt.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                Call EditData()
                idBaca.Text = dt.Rows(0)("idbarang").ToString
                TidSatuan.Text = dt.Rows(0)("idsatuan")
                KdBarang.Text = dt.Rows(0)("kdbarang")
                TBarangInp.Text = dt.Rows(0)("barang")
                HasilX.Text = dt.Rows(0)("dimensi").ToString
                TBarangPE.Text = "" & TBarangInp.Text & ""
                TKet.Text = dt.Rows(0)("keterangan").ToString
                THargaUnit.Text = dt.Rows(0)("harga_pe")
                TidKel.Text = dt.Rows(0)("idkelompok")
                TBacaSubkel.Text = dt.Rows(0)("idsubkel")
                'Call BacaMaterial()
            Else
                Call DataBaru()
            End If
        End If
        GGVM_conn_close()
        dr.Close()
    End Sub
    Sub HitungDimensi()
        Dim HasilDimensi As Double
        If TT.Text <> "" Then
            HasilDimensi = Val(CDbl(TP.Text)) + Val(CDbl(TL.Text)) + Val(CDbl(TT.Text))
        Else
            HasilDimensi = Val(CDbl(TP.Text)) * Val(CDbl(TL.Text))
        End If
        HasilX.Text = HasilDimensi
    End Sub
    Private Sub BtnHasiX_Click(sender As Object, e As EventArgs) Handles BtnHasilX.Click
        Try
            Call HitungDimensi()
        Catch ex As Exception
            MsgBox("Terjadi Kesalahan !" & ex.Message)
        End Try
    End Sub
    Private Sub TP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TP.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ",") And Not Char.IsControl(e.KeyChar) Then
            MessageBox.Show("Hanya Boleh Angka !")
            e.Handled = True
        End If
    End Sub
    Private Sub TT_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TT.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ",") And Not Char.IsControl(e.KeyChar) Then
            MessageBox.Show("Hanya Boleh Angka !")
            e.Handled = True
        End If
    End Sub
    Private Sub TL_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TL.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ",") And Not Char.IsControl(e.KeyChar) Then
            MessageBox.Show("Hanya Boleh Angka !")
            e.Handled = True
        End If
    End Sub
    Private Sub DetailMaterials_Click(sender As Object, e As EventArgs) Handles DetailMaterials.Click
        PAddMaterials.Visible = True
        AddMaterials.Text = ""
    End Sub
    Private Sub HapusMaterials_Click(sender As Object, e As EventArgs) Handles HapusMaterial.Click
        LBMaterials.Items.Remove(LBMaterials.SelectedItem)
        AddMaterials.Clear()
        AddMaterials.Focus()
    End Sub
    Private Sub BAddMaterials_Click(sender As Object, e As EventArgs) Handles BAddMaterials.Click
        TMaterial.Text = String.Join(",", LBMaterials.Items.Cast(Of String).ToArray())
        PAddMaterials.Visible = False
        AddMaterials.Text = ""
        LBMaterials.Items.Clear()
    End Sub
    Private Sub AddMaterials_KeyPress(sender As Object, e As KeyPressEventArgs) Handles AddMaterials.KeyPress
        If (e.KeyChar = Chr(13)) Then
            LBMaterials.Items.Add(AddMaterials.Text)
            AddMaterials.Clear()
            AddMaterials.Focus()
        End If
    End Sub
    Private Sub CKategori_TextChanged(sender As Object, e As EventArgs) Handles CKategori.TextChanged
        Try
            GGVM_conn()
            s = ""
            s = s & "Select * from kelompok a, subkelompok b where a.idkelompok = b.idkelompok and a.kelompok = '" & CKategori.Text & "'"
            cmd = New Odbc.OdbcCommand(s, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If Not dr.HasRows Then
                TidKel.Text = ""
                CSubKat.Text = ""
                TidSubkel.Text = ""
                CSubKat.Items.Clear()
            Else
                TidKel.Text = dr.Item("idkelompok")
                CSubKat.Text = ""
                TidSubkel.Text = ""
                CSubKat.Items.Clear()
                Call ComboSubKategori()
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
        GGVM_conn_close()
    End Sub
    Private Sub TidKel_TextChanged(sender As Object, e As EventArgs) Handles TidKel.TextChanged
        Try
            GGVM_conn()
            s = "Select * from kelompok where idkelompok= '" & TidKel.Text & "'"
            cmd = New OdbcCommand(s, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If Not dr.HasRows Then
                CKategori.Text = ""
                TidSubkel.Text = ""
                CSubKat.Items.Clear()
            Else
                CKategori.Text = dr.Item("kelompok")
                If TBacaSubkel.Text <> "" Then
                    TidSubkel.Text = "" & TBacaSubkel.Text & ""
                End If
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
        GGVM_conn_close()
    End Sub
    Private Sub CSubKat_TextChanged(sender As Object, e As EventArgs) Handles CSubKat.TextChanged
        Try
            GGVM_conn()
            s = ""
            s = s & "Select * from subkelompok where subkel= '" & CSubKat.Text & "' and idkelompok ='" & TidKel.Text & "' "
            cmd = New OdbcCommand(s, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If Not dr.HasRows Then
                TidSubkel.Text = ""
            Else
                'TBacaSubkel.Text = ""
                TidSubkel.Text = dr.Item("idsubkel")
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
        GGVM_conn_close()
    End Sub
    Private Sub TidSubkel_TextChanged(sender As Object, e As EventArgs) Handles TidSubkel.TextChanged
        Try
            GGVM_conn()
            s = ""
            s = s & "Select * from subkelompok where idsubkel = '" & TidSubkel.Text & "' And idkelompok = '" & TidKel.Text & "'"
            cmd = New OdbcCommand(s, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If Not dr.HasRows Then
                CSubKat.Text = ""
            Else
                CSubKat.Text = dr.Item("subkel")
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
        GGVM_conn_close()
    End Sub
    Private Sub TBacaSubkel_TextChanged(sender As Object, e As EventArgs) Handles TBacaSubkel.TextChanged
        Try
            GGVM_conn()
            s = ""
            s = s & "Select * from subkelompok where idsubkel = '" & TBacaSubkel.Text & "' And idkelompok = '" & TidKel.Text & "'"
            cmd = New OdbcCommand(s, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If Not dr.HasRows Then
                CSubKat.Text = ""
            Else
                CSubKat.Text = dr.Item("subkel")
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
        GGVM_conn_close()
    End Sub
    Private Sub SimpanBA_Click(sender As Object, e As EventArgs) Handles SimpanBA.Click
        Try
            Call SimpanAktual()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
    Private Sub PAddMaterials_MouseDown(sender As Object, e As MouseEventArgs) Handles PAddMaterials.MouseDown
        Panel1Captured = True
        Panel1Grabbed = e.Location
    End Sub
    Private Sub PAddMaterials_MouseMove(sender As Object, e As MouseEventArgs) Handles PAddMaterials.MouseMove
        If (Panel1Captured) Then PAddMaterials.Location = PAddMaterials.Location + e.Location - Panel1Grabbed
    End Sub
    Private Sub PAddMaterials_MouseUp(sender As Object, e As MouseEventArgs) Handles PAddMaterials.MouseUp
        Panel1Captured = False
    End Sub
    Private Sub TidAktual_TextChanged(sender As Object, e As EventArgs) Handles TidAktual.TextChanged
        Try
            GGVM_conn()
            sql = "select b.*, a.barang from barang_penawaran a,evn_barang_aktual b where a.idbarang = b.idbarang and b.idaktual = '" & TidAktual.Text & "'"
            cmd = New OdbcCommand(sql, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If Not dr.HasRows Then
                TBAktual.Text = ""
                TidBarangPE.Text = ""
            Else
                TBAktual.Text = dr.Item("barang")
                TidBarangPE.Text = dr.Item("idbarang_pe")
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
        GGVM_conn_close()
    End Sub
    Private Sub ListAktual_DoubleClick(sender As Object, e As EventArgs) Handles ListAktual.DoubleClick
        With Me.ListAktual
            Dim i As Integer
            For Each item As ListViewItem In ListAktual.SelectedItems
                i = item.Index
            Next
            Dim innercounter As Integer = 0
            For Each subItem As ListViewItem.ListViewSubItem In ListAktual.Items(i).SubItems
                Dim myString As String = ListAktual.Items(i).SubItems(innercounter).Text
                Select Case innercounter
                    Case 2
                        TidBarangA.Text = myString
                    Case 3
                        TidBarangPE.Text = myString
                End Select
                innercounter += 1
            Next
            ListBarangPenawaran.Items.Clear()
            Call TampilBarangPenawaran()
        End With
    End Sub
    Private Sub ListBarangPenawaran_DoubleClick(sender As Object, e As EventArgs) Handles ListBarangPenawaran.DoubleClick
        With Me.ListBarangPenawaran
            Dim i As Integer
            For Each item As ListViewItem In ListBarangPenawaran.SelectedItems
                i = item.Index
            Next
            Dim innercounter As Integer = 0
            For Each subItem As ListViewItem.ListViewSubItem In ListBarangPenawaran.Items(i).SubItems
                Dim myString As String = ListBarangPenawaran.Items(i).SubItems(innercounter).Text
                Select Case innercounter
                    Case 1
                        TBarangPE.Text = myString
                End Select
                innercounter += 1
            Next
            ListAktual.Items.Clear()
            Call TampilBarangAktual()
        End With
    End Sub
    Private Sub TBAktual_TextChanged(sender As Object, e As EventArgs) Handles TBAktual.TextChanged
        Try
            GGVM_conn()
            s = " select * from barang_penawaran where barang =  '" & TBAktual.Text & "'"
            cmd = New OdbcCommand(s, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If Not dr.HasRows Then
                TidBarangA.Text = ""
            Else
                TidBarangA.Text = dr.Item("idbarang")
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
        GGVM_conn_close()
    End Sub
    Private Sub TidBarangA_TextChanged(sender As Object, e As EventArgs) Handles TidBarangA.TextChanged
        Try
            GGVM_conn()
            s = " select b.*, a.barang from barang_penawaran a,evn_barang_aktual b where a.idbarang = b.idbarang and a.idbarang =  '" & TidBarangA.Text & "'"
            da = New OdbcDataAdapter(s, conn)
            dt = New DataTable
            dt.Clear()
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                TidAktual.Text = dt.Rows(0)("idaktual").ToString
                TLebar.Text = dt.Rows(0)("lebar").ToString
                TTinggi.Text = dt.Rows(0)("tinggi").ToString
                TPanjang.Text = dt.Rows(0)("panjang").ToString
                TJumlah.Text = dt.Rows(0)("jml").ToString
            Else
                TidAktual.Text = ""
                TLebar.Text = ""
                TTinggi.Text = ""
                TPanjang.Text = ""
                TJumlah.Text = ""
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
        GGVM_conn_close()
    End Sub
    Private Sub SimpanBarangPE_Click(sender As Object, e As EventArgs) Handles SimpanBarangPE.Click
        Dim c, kd As String
        Dim idsatuan As Integer
        Dim ratecard_gg As Double = 0
        Dim fee_barang As Double = 0
        Dim pph23_barang As Double = 0

        Integer.TryParse(TidSatuan.Text, idsatuan)
        GGVM_conn()
        s = ""
        s = s & "select a.idbarang,a.idsubkel, a.kdbarang , a.barang, a.keterangan, a.harga_pe, b.idkelompok "
        s = s & " from barang_penawaran a, subkelompok b, kelompok c"
        s = s & " WHERE c.idkelompok = b.idkelompok and b.idsubkel = a.idsubkel "
        If DivUser = "2" Then
            s = s & "And b.idkelompok = '7' And a.barang = '" & TBarangInp.Text & "'"
        ElseIf DivUser = "17" Then
            s = s & "And b.idkelompok = '18' And a.barang = '" & TBarangInp.Text & "'"
        ElseIf DivUser = "18" Then
            s = s & "And b.idkelompok = '20' and a.barang = '" & TBarangInp.Text & "'"
        ElseIf DivUser = "0" Then
            s = s & "And b.idkelompok in (7,18,20) And a.barang = '" & TBarangInp.Text & "'"
        End If
        's = "select * from barang where idsubkel In (73,93,94,95,96,97,98,99,100,101,102,103,104,105,106,107,108,109) and barang = '" & TBarangInp.Text & "'"
        cmd = New OdbcCommand(s, conn)
        dr = cmd.ExecuteReader
        dr.Read()
        If Not dr.HasRows Then
            If MsgBox("Apakah data ingin disimpan??", MsgBoxStyle.Information Or MsgBoxStyle.YesNo, "Pemberitahuan !!") = MsgBoxResult.Yes Then
                'Masukkan ke Table Barang
                s = ""
                s = s & "insert barang_penawaran (idsubkel,barang,"
                If TKet.Text <> "" Then
                    s = s & "keterangan,"
                End If
                s = s & "idsatuan,"
                If HasilX.Text <> "" Then
                    s = s & "dimensi,"
                End If
                s = s & "harga_pe)"
                s = s & "values ('" & TidSubkel.Text & "','" & TBarangInp.Text & "',"
                If TKet.Text <> "" Then
                    s = s & "'" & TKet.Text & "',"
                End If
                s = s & "'1',"
                If HasilX.Text <> "" Then
                    s = s & "'" & HasilX.Text & "',"
                End If
                s = s & "'" & THargaUnit.Text & "')"
                cmd = New OdbcCommand(s, conn)
                cmd.ExecuteNonQuery()

                'Count Kode Barang
                s = ""
                s = s & " Select max(idbarang)As id from barang_penawaran "
                cmd = New OdbcCommand(s, conn)
                dr = cmd.ExecuteReader
                dr.Read()
                kd = "000000" + dr.GetString(0)
                kd = Microsoft.VisualBasic.Right(kd, 6)
                TidBarangPE.Text = dr.Item("id")

                'Fill ID Barang
                sql = ""
                sql = sql & " Select max(idbarang)As id from barang_penawaran "
                da = New OdbcDataAdapter(sql, conn)
                dt = New DataTable
                da.Fill(dt)
                If dt.Rows.Count > 0 Then
                    TidBarangPE.Text = dt.Rows(0)("id")
                End If
                'Fill Kode Barang

                ratecard_gg = Math.Round(Val(CDbl(THargaUnit.Text) * 0.98) / 1.1)
                fee_barang = Math.Round(Val(CDbl(ratecard_gg) * 1.1) - Val(CDbl(ratecard_gg)))
                pph23_barang = Math.Round(Val(CDbl(THargaUnit.Text))) - Math.Round(Val(CDbl(ratecard_gg) * 1.1))

                c = ""
                c = c & " update barang_penawaran Set"
                c = c & " kdbarang ='" & kd & "', ratecard_gg = '" & ratecard_gg & "', fee = '" & fee_barang & "',"
                c = c & " pph23 = '" & pph23_barang & "'"
                c = c & " where idbarang ='" & TidBarangPE.Text & "'"
                cmd = New Odbc.OdbcCommand(c, conn)
                cmd.ExecuteNonQuery()

                If TMaterial.Text <> "" Then
                    c = ""
                    c = c & " insert evn_material_aktual (idbarang_pe,barangmaterial)"
                    c = c & "value ('" & TidBarangPE.Text & "', '" & TMaterial.Text & "')"
                    cmd = New Odbc.OdbcCommand(c, conn)
                    cmd.ExecuteNonQuery()
                End If
                Call BersihBarang()
                MsgBox("Data sudah di-SIMPAN !!..", MsgBoxStyle.Information, "Information")
            End If
            GGVM_conn_close()
        Else
            If MsgBox("Apakah data ingin di Perbarui??", MsgBoxStyle.Information Or MsgBoxStyle.YesNo, "Pemberitahuan !!") = MsgBoxResult.Yes Then
                Try
                    ratecard_gg = Math.Round(Val(CDbl(THargaUnit.Text) * 0.98) / 1.1)
                    fee_barang = Math.Round(Val(CDbl(ratecard_gg) * 1.1) - Val(CDbl(ratecard_gg)))
                    pph23_barang = Math.Round(Val(CDbl(THargaUnit.Text))) - Math.Round(Val(CDbl(ratecard_gg) * 1.1))

                    s = ""
                    s = s & "update barang_penawaran set idsubkel = '" & TidSubkel.Text & "',barang = '" & TBarangInp.Text & "',"
                    If HasilX.Text <> "" Then
                        s = s & "dimensi = '" & HasilX.Text & "' ,"
                    End If
                    If TKet.Text <> "" Then
                        s = s & "keterangan = '" & TKet.Text & "',"
                    End If
                    s = s & "idsatuan ='" & idsatuan & "' ,harga_pe = '" & THargaUnit.Text & "',"
                    s = s & "ratecard_gg = '" & ratecard_gg & "', fee = '" & fee_barang & "',pph23 = '" & pph23_barang & "'"
                    s = s & "where idbarang = '" & idBaca.Text & "'"
                    cmd = New OdbcCommand(s, conn)
                    cmd.ExecuteNonQuery()

                    If TMaterial.Text <> "" Then
                        c = ""
                        c = c & " insert evn_material_aktual (idbarang_pe,barangmaterial)"
                        c = c & "value ('" & TidBarangPE.Text & "', '" & TMaterial.Text & "')"
                        cmd = New Odbc.OdbcCommand(c, conn)
                        cmd.ExecuteNonQuery()
                    End If

                    Call BersihBarang()
                    MsgBox("Data sudah di Perbarui !!..", MsgBoxStyle.Information, "Information")

                    'sql = ""
                    'sql = sql & " Select max(idbarang)As id from barang_penawaran "
                    'da = New OdbcDataAdapter(sql, conn)
                    'dt = New DataTable
                    'da.Fill(dt)
                    'If dt.Rows.Count > 0 Then
                    '    TidBarangPE.Text = dt.Rows(0)("id")
                    'End If
                Catch ex As Exception
                    MsgBox("Data Gagal di Perbarui", MsgBoxStyle.Critical, "Message !!")
                End Try
                GGVM_conn_close()
            End If
        End If
        GGVM_conn_close()
    End Sub
    Private Sub TKontrak_TextChanged(sender As Object, e As EventArgs) Handles TKontrak.TextChanged
        Try
            GGVM_conn()
            s = ""
            s = s & "SELECT a.idkontrak,a.valuecontract, b.nama from evn_kontrak a, klien b where a.idklien = b.id and b.nama = '" & TKontrak.Text & "'"
            cmd = New OdbcCommand(s, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If Not dr.HasRows Then
                TidKontrak.Text = ""
            Else
                TidKontrak.Text = dr.Item("idkontrak")
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
        GGVM_conn_close()
    End Sub
    Private Sub CBKota_TextChanged(sender As Object, e As EventArgs) Handles CBKota.TextChanged
        Try
            GGVM_conn()
            s = ""
            s = s & "select * from kota where kota = '" & CBKota.Text & "'"
            cmd = New OdbcCommand(s, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If Not dr.HasRows Then
                idKotaBK.Text = ""
            Else
                idKotaBK.Text = dr.Item("idkota")
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
        GGVM_conn_close()
    End Sub
    Private Sub idKotaBK_TextChanged(sender As Object, e As EventArgs) Handles idKotaBK.TextChanged
        Try
            GGVM_conn()
            s = ""
            s = s & "select * from kota where idkota = '" & idKotaBK.Text & "'"
            cmd = New OdbcCommand(s, conn)
            dr = cmd.ExecuteReader
            dr.Read()
            If Not dr.HasRows Then
                CBKota.Text = ""
            Else
                CBKota.Text = dr.Item("kota")
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
        GGVM_conn_close()
    End Sub

    Private Sub TBarangPE_TextChanged(sender As Object, e As EventArgs) Handles TBarangPE.TextChanged

    End Sub
    Private Sub CekBarangPE_CheckedChanged(sender As Object, e As EventArgs) Handles CekBarangPE.CheckedChanged
        If CekBarangPE.Checked = True Then
            Call TampilBarangPenawaran()
        ElseIf CekBarangPE.Checked = False Then
            ListBarangPenawaran.Items.Clear()
        Else
            MsgBox("Terjadi Kesalahan")
        End If
    End Sub

    Private Sub CekBarangPE_CheckStateChanged(sender As Object, e As EventArgs) Handles CekBarangPE.CheckStateChanged
        If CekBarangPE.Checked = True Then
            Call TampilBarangPenawaran()
        ElseIf CekBarangPE.Checked = False Then
            ListBarangPenawaran.Items.Clear()
        Else
            MsgBox("Terjadi Kesalahan")
        End If
    End Sub

    Private Sub BtnTutup_Click(sender As Object, e As EventArgs) Handles BtnTutup.Click
        For i = System.Windows.Forms.Application.OpenForms.Count - 1 To 1 Step -1
            Dim form As Form = System.Windows.Forms.Application.OpenForms(i)
			Me.Close()
		Next i
    End Sub

	Private Sub BtnImport_Click(sender As Object, e As EventArgs) Handles BtnImport.Click
		Dim f As New ImportBarang
		f.ShowDialog()
	End Sub

	Private Sub TidSatuan_TextChanged(sender As Object, e As EventArgs) Handles TidSatuan.TextChanged
		Try
			GGVM_conn()
			s = ""
			s = s & "Select * from satuan where idsatuan = '" & TidSatuan.Text & "'"
			cmd = New OdbcCommand(s, conn)
			dr = cmd.ExecuteReader
			dr.Read()
			If Not dr.HasRows Then
				CSatuan.Text = ""
			Else
				CSatuan.Text = dr.Item("satuan")
			End If
		Catch ex As Exception
			MsgBox("Terjadi kesalahan! " & ex.Message)
		End Try
		GGVM_conn_close()
	End Sub
End Class