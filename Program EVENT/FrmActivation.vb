Imports System.Data.Odbc

Public Class FrmActivation
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
#Region "Autocomplete"
    Private Sub LoadKlien()
        GGVM_conn()
        sql = "select * from klien where status='1'"
        Try
            da = New OdbcDataAdapter(sql, conn)
            ds = New DataSet
            da.Fill(ds)
        Catch ex As Exception
            MsgBox("Terjadi Kesalah" + ex.Message)
        End Try
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
    Private Sub LoadSubdivisi()
        GGVM_conn()
        CSubDivisi.Items.Clear()
        If DivUser = "0" Then
            sql = "select subdivisi from subdivisi"
        Else
            sql = "select subdivisi from subdivisi where id_divisi = '" & DivUser & "'"
        End If
        Try
            cmd = New OdbcCommand(sql, conn)
            dr = cmd.ExecuteReader
        Catch ex As Exception
            MsgBox("Terjadi Kesalah !" + ex.Message)
        End Try
        Do While dr.Read
            CSubDivisi.Items.Add(dr("subdivisi"))
        Loop
        GGVM_conn_close()
    End Sub
    'Private Sub LoadPropinsi()
    '    GGVM_conn()
    '    sql = "select * from propinsi where status='1'"
    '    cmd = New OdbcCommand(sql, conn)
    '    dr = cmd.ExecuteReader
    '    Do While dr.Read
    '        CAreaHR.Items.Add(dr("propinsi"))
    '    Loop
    '    GGVM_conn_close()
    'End Sub
#End Region
#Region "Listview Data"
    Private Sub ListHeaderPE()
        With ListPEActivation
            .FullRowSelect = True
            .MultiSelect = False
            .View = View.Details
            .CheckBoxes = False
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
        sql = sql & "SELECT a.nope,b.nama,c.jenis_pe, a.project,if(a.venue is null,'-',a.venue) as venue,if(a.jmlevent is null,'-',a.jmlevent) as jmlevent, "
        sql = sql & " if (a.periode is null,'',a.periode)as periode,if (a.region is null,'',a.region)as region,a.tgl_pe,a.total,a.rp_ppn, "
        sql = sql & " if (a.grandtotal Is null,'Belum Ada Detail',a.grandtotal)as grandtotal,a.approved_by, a.idpe,if(a.idsubdivisi is null,'',a.idsubdivisi) as idsubdivisi "
        sql = sql & "FROM `evn_penawaran`a , klien b , evn_jenis_pe c where a.idklien = b.id And a.idjenis_pe = c.idjenis_pe and c.idjenis_pe = '" & TidJenisPE.Text & "' "
        If LevelUser = "1" Then
            sql = sql & " And a.userid_input = '" & userid & "' "
        End If
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
                    .Add(dt.Rows(j)("venue"))
                    .Add(dt.Rows(j)("jmlevent"))
                    .Add(dt.Rows(j)("periode"))
                    .Add(Format(Val(dt.Rows(j)("grandtotal")), "Rp, ###,###"))
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
        sql = sql & "SELECT if(d.periode is null, '',d.periode) as periode ,a.barang,a.qty, "
        sql = sql & " a.satuan_qty,a.unitcost,a.sub_totalcost,c.subkel, a.iddetail FROM evn_detail_penawaran a  "
        sql = sql & " Join barang_penawaran b ON b.idbarang = a.idbarang "
        sql = sql & " Join subkelompok c on c.idsubkel = b.idsubkel "
        sql = sql & " join evn_penawaran d on d.idpe = a.idpe "
        If TidJenisPE.Text = "5" Then
            If CKuartal.Text <> "" Then
                sql = sql & " LEFT JOIN act_kuartal_pe e on e.iddetail = a.iddetail"
            End If
        End If
        sql = sql & " where a.idpe = '" & TidPE.Text & "'"
        If TidJenisPE.Text = "5" Then
            If CKuartal.Text <> "" Then
                sql = sql & " and e.kuartalke = '" & CKuartal.Text & "'"
            End If
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
    End Sub
    'Penawaran Activation (Event) Start // Fungsi Baca
    Private Sub ListHeaderProduksi()
        With ListEventProduksi
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
    Private Sub BacaDetailEvnProduksi()
        Dim Barang As String
        GGVM_conn()
        sql = ""
        sql = sql & "SELECT a.*,f.subkel FROM act_detail_penawaran a "
        sql = sql & "JOIN barang_penawaran b on a.idbarang = b.idbarang "
        sql = sql & " JOIN evn_detail_penawaran c on a.iddetail = c.iddetail "
        sql = sql & " JOIN evn_penawaran d on a.idpe = d.idpe "
        sql = sql & " JOIN act_jenis_detail e on a.idjenis_detail = e.idjenis_detail "
        sql = sql & " Join subkelompok f on b.idsubkel = f.idsubkel"
        sql = sql & " where a.idpe = '" & TidPE.Text & "' and a.idjenis_detail = '1' and a.kuartal = '" & CKuartal.Text & "'"
        Try
            cmd = New OdbcCommand(sql, conn)
            dr = cmd.ExecuteReader
        Catch ex As Exception
            MsgBox("Terjadi Kesalah" & ex.Message)
            Exit Sub
        End Try
        ListEventProduksi.Items.Clear()
        ListEventProduksi.BeginUpdate()
        While dr.Read
            Barang = dr.Item("barang")
            strName = dr.Item("subkel")
            Dim lvitem As New ListViewItem(Barang)
            Try
                If ListEventProduksi.Groups.Item(strName).Header = strName Then
                    lvitem.Group = ListEventProduksi.Groups(strName)
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
                    ListEventProduksi.Items.Add(lvitem)
                End If
            Catch
                ListEventProduksi.Groups.Add(New ListViewGroup(strName, strName))
                lvitem.Group = ListEventProduksi.Groups(strName)
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
                ListEventProduksi.Items.Add(lvitem)
            End Try
            Call NominalBiaya()
        End While
        ListEventProduksi.EndUpdate()
        GGVM_conn_close()
    End Sub
    Private Sub ListHeaderEksekusi()
        With ListEventEksekusi
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
    Private Sub BacaDetailEvnEksekusi()
        Dim Barang As String
        GGVM_conn()
        sql = ""
        sql = sql & "SELECT a.*,f.subkel FROM act_detail_penawaran a "
        sql = sql & "JOIN barang_penawaran b on a.idbarang = b.idbarang "
        sql = sql & " JOIN evn_detail_penawaran c on a.iddetail = c.iddetail "
        sql = sql & " JOIN evn_penawaran d on a.idpe = d.idpe "
        sql = sql & " JOIN act_jenis_detail e on a.idjenis_detail = e.idjenis_detail "
        sql = sql & " Join subkelompok f on b.idsubkel = f.idsubkel"
        sql = sql & " where a.idpe = '" & TidPE.Text & "' and a.idjenis_detail = '2' and a.kuartal = '" & CKuartal.Text & "'"
        Try
            cmd = New OdbcCommand(sql, conn)
            dr = cmd.ExecuteReader
        Catch ex As Exception
            MsgBox("Terjadi Kesalah" & ex.Message)
            Exit Sub
        End Try
        ListEventEksekusi.Items.Clear()
        ListEventEksekusi.BeginUpdate()
        While dr.Read
            Barang = dr.Item("barang")
            strName = dr.Item("subkel")
            Dim lvitem As New ListViewItem(Barang)
            Try
                If ListEventEksekusi.Groups.Item(strName).Header = strName Then
                    lvitem.Group = ListEventEksekusi.Groups(strName)
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
                    ListEventEksekusi.Items.Add(lvitem)
                End If
            Catch
                ListEventEksekusi.Groups.Add(New ListViewGroup(strName, strName))
                lvitem.Group = ListEventProduksi.Groups(strName)
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
                ListEventEksekusi.Items.Add(lvitem)
            End Try
            Call NominalBiaya()
        End While
        ListEventEksekusi.EndUpdate()
        GGVM_conn_close()
    End Sub
    Private Sub ListHeaderManpower()
        With ListEventManpower
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
    Private Sub BacaDetailManPower()
        Dim Barang As String
        GGVM_conn()
        sql = ""
        sql = sql & "SELECT a.*,f.subkel FROM act_detail_penawaran a "
        sql = sql & "JOIN barang_penawaran b on a.idbarang = b.idbarang "
        sql = sql & " JOIN evn_detail_penawaran c on a.iddetail = c.iddetail "
        sql = sql & " JOIN evn_penawaran d on a.idpe = d.idpe "
        sql = sql & " JOIN act_jenis_detail e on a.idjenis_detail = e.idjenis_detail "
        sql = sql & " Join subkelompok f on b.idsubkel = f.idsubkel"
        sql = sql & " where a.idpe = '" & TidPE.Text & "' and a.idjenis_detail = '3' and a.kuartal = '" & CKuartal.Text & "'"
        Try
            cmd = New OdbcCommand(sql, conn)
            dr = cmd.ExecuteReader
        Catch ex As Exception
            MsgBox("Terjadi Kesalah" & ex.Message)
            Exit Sub
        End Try
        ListEventManpower.Items.Clear()
        ListEventManpower.BeginUpdate()
        While dr.Read
            Barang = dr.Item("barang")
            strName = dr.Item("subkel")
            Dim lvitem As New ListViewItem(Barang)
            Try
                If ListEventManpower.Groups.Item(strName).Header = strName Then
                    lvitem.Group = ListEventManpower.Groups(strName)
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
                    ListEventManpower.Items.Add(lvitem)
                End If
            Catch
                ListEventManpower.Groups.Add(New ListViewGroup(strName, strName))
                lvitem.Group = ListEventProduksi.Groups(strName)
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
                ListEventManpower.Items.Add(lvitem)
            End Try
            Call NominalBiaya()
        End While
        ListEventManpower.EndUpdate()
        GGVM_conn_close()
    End Sub
    'Penawaran Activation (Event) End // Fungsi Baca
#End Region
#Region "Deklarasi Perintah"
    Private Sub KondisiAwalPE()
        TidPE.Text = ""
        TidKlien.Text = ""
        TidKuartalPE.Text = ""
        TidKontrakAct.Text = ""
        TNoPE.Text = ""
        TKlien.Text = ""
        TVenue.Text = ""
        TJmlEvent.Text = ""
        TProject.Text = ""
        TAgentFee.Text = "0"
        TTotal.Text = "0"
        TRpPPN.Text = "0"
        TAgencyRP.Text = "0"
        TTotalVAT.Text = "0"
        TAgencyRP.Text = "0"
        TAgentFee.Text = "0"
        CSubDivisi.Text = ""
        CKontrak.Text = ""
        StartPeriod.Value = DateTime.Now
        EndPeriod.Value = DateTime.Now
        DTTanggal.Value = DateTime.Now
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
        BtnRevisiPE.Enabled = False
        BtnSimpanPE.Enabled = False
        BtnCetakPE.Enabled = True
        BatalTools.Enabled = False
        BtnHapusPE.Enabled = False
        TambahPE.Enabled = True
        ListPEActivation.Enabled = True
    End Sub
    Private Sub KondisiAwalDetailPE()
        TPeriodeCL.Enabled = False
        TQtyCL.Enabled = False
        TBarangCL.Enabled = False
        TKetCL.Enabled = False
        TSubTotalCL.Enabled = False
        TTotalCostCL.Enabled = False
        TAgentFeeCL.Enabled = False
        TRpPPNCL.Enabled = False
        TPph23CL.Enabled = False
        TTotalBeforeVATCL.Enabled = False
        CKuartal.Enabled = False
        TJmlEvnCL.Enabled = False
        CekFee.Enabled = False
        CekFee.Checked = True
        CekPPH.Enabled = False
        CekPPH.Checked = False
        CekPPN.Enabled = False
        CekPPH.Checked = False
        ListDetailPEAct.Enabled = True
    End Sub
    Private Sub KondisiTambahDetailPE()
        TPeriodeCL.Enabled = False
        TQtyCL.Enabled = True
        TBarangCL.Enabled = True
        TKetCL.Enabled = True
        TSubTotalCL.Enabled = False
        TTotalCostCL.Enabled = False
        TAgentFeeCL.Enabled = False
        TRpPPNCL.Enabled = False
        TPph23CL.Enabled = False
        TTotalBeforeVATCL.Enabled = False
        CKuartal.Enabled = False
        TJmlEvnCL.Enabled = False
        CekFee.Enabled = False
        CekFee.Checked = True
        CekPPH.Enabled = True
        CekPPH.Checked = False
        CekPPN.Enabled = True
        CekPPH.Checked = False
        ListDetailPEAct.Enabled = False
    End Sub
    Private Sub HitungMainDetail()
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
        TTotalBeforeVATCL.Text = Val(TTotalCostCL.Text) + Val(TAgentFeeCL.Text) + Val(TRpPPNCL.Text) + Val(TPph23CL.Text)
    End Sub
    Private Sub AturanInput(ByRef e As KeyPressEventArgs)
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ",") And Not Char.IsControl(e.KeyChar) Then
            MessageBox.Show("Hanya Boleh Angka !")
            e.Handled = True
        Else
            Return
        End If
    End Sub
    Private Sub NominalBiaya()
        Dim Nominal As Long = 0
        Dim PPN As Double = 0
        Dim Fee As Double = 0
        Dim TotalBeforeVAT As Double = 0
        Dim PPH As Double = 0

        Dim NominalProd As Double = 0
        Dim ProdFee As Double = 0
        Dim ProdBfrVAT As Double = 0
        Dim ProdNominalPPN As Double = 0
        Dim NominalEks As Double = 0
        Dim EksFee As Double = 0
        Dim EksBfrVAT As Double = 0
        Dim EksNominalPPN As Double = 0
        Dim NominalMan As Double = 0
        Dim ManFee As Double = 0
        Dim ManBfrVAT As Double = 0
        Dim ManNominalPPN As Double = 0
        Const V As Integer = 100
        If TidJenisPE.Text = "5" Then
            'Hitung List Penawaran Produksi
            For i As Integer = 0 To ListEventProduksi.Items.Count - 1
                NominalProd = CLng(NominalProd + Val(ListEventProduksi.Items(i).SubItems(7).Text))
            Next
            TotalProd.Text = NominalProd
            ProdFee = Val(CDbl(NominalProd)) * Val(CDbl(TAgentFee.Text)) / V
            ProdAgentFee.Text = ProdFee
            ProdBfrVAT = Val(CDbl(NominalProd)) + Val(CDbl(ProdFee))
            ProdBeforeVAT.Text = ProdBfrVAT

            'Hitung List Penawaran Eksekusi
            For i As Integer = 0 To ListEventEksekusi.Items.Count - 1
                NominalEks = CLng(NominalEks + Val(ListEventEksekusi.Items(i).SubItems(7).Text))
            Next
            TotalEks.text = NominalEks
            EksFee = Val(CDbl(NominalEks)) * Val(CDbl(TAgentFee.Text)) / V
            EksAgentFee.Text = EksFee
            EksBfrVAT = Val(CDbl(NominalEks)) + Val(CDbl(EksFee))
            EksBeforeVAT.Text = EksBfrVAT

            'Hitung List Penawaran Manpower & Supervisi
            For i As Integer = 0 To ListEventManpower.Items.Count - 1
                NominalEks = CLng(NominalEks + Val(ListEventManpower.Items(i).SubItems(7).Text))
            Next
            TotalMan.Text = NominalMan
            ManFee = Val(CDbl(NominalMan)) * Val(CDbl(TAgentFee.Text)) / V
            ManAgentFee.Text = ManFee
            ManBfrVAT = Val(CDbl(NominalMan)) + Val(CDbl(ManFee))
            ManBeforeVAT.Text = ManBfrVAT

            'Jika ada PPN
            If TongglePPN.IsOn = True Then
                ProdNominalPPN = Val(ProdBfrVAT * 10) / V
                ProdPPN.Text = ProdNominalPPN

                EksNominalPPN = Val(EksBfrVAT * 10) / V
                EksPPN.Text = EksNominalPPN

                ManNominalPPN = Val(ManBfrVAT * 10) / V
                ManPPN.Text = ManNominalPPN
            Else
                ProdPPN.Text = "0"
                EksPPN.Text = "0"
                ManPPN.Text = "0"
                ProdNominalPPN = 0
                EksNominalPPN = 0
                ManNominalPPN = 0
            End If

            'Hitung Total Penawaran Event
            Nominal = Val(NominalProd) + Val(NominalEks) + Val(NominalMan)
            TTotalCost.EditValue = Nominal
            Fee = Val(ProdFee) + Val(EksFee) + Val(ManFee)
            TTotalAgenFee.EditValue = Fee
            TotalBeforeVAT = Nominal + Fee
            TTotalBeforeVAT.EditValue = TotalBeforeVAT
            PPN = Val((TotalBeforeVAT) * 10) / V
            TTotalPPN.EditValue = PPN

        ElseIf TidJenisPE.Text = "6" Then

            For i As Integer = 0 To ListProjectDetail.Items.Count - 1
                Nominal = CLng(Nominal + Val(ListProjectDetail.Items(i).SubItems(7).Text))
            Next
            TTotalCost.EditValue = Nominal
            Fee = Val(CDbl(Nominal) * Val(CDbl(TAgentFee.Text)) / V)
            TTotalAgenFee.EditValue = Fee
            TotalBeforeVAT = Nominal + Fee
            TTotalBeforeVAT.EditValue = TotalBeforeVAT
            'Jika ada PPN
            If TongglePPN.IsOn = True Then
                PPN = Val(TotalBeforeVAT * 10) / V
                TTotalPPN.EditValue = PPN
            Else
                PPN = 0
                TTotalPPN.EditValue = "0"
            End If
        ElseIf TidJenisPE.Text = "7" Then
            'For t As Integer = 0 To DGInputHR.Rows.Count - 1
            '    TTotPersonHR.Text = Val(CDbl(TTotPersonHR.Text)) + Val(DGInputHR.Rows(t).Cells(10).Value)
            '    TPersonMonthHR.Text = Val(CDbl(TPersonMonthHR.Text)) + Val(DGInputHR.Rows(t).Cells(3).Value)
            '    TGross1HR.Text = Val(CDbl(TGross1HR.Text)) + Val(DGInputHR.Rows(t).Cells(11).Value)
            '    TGross2HR.Text = Val(CDbl(TGross2HR.Text)) + Val(DGInputHR.Rows(t).Cells(12).Value)
            '    TAgentFeeHR.Text = Val(CDbl(TAgentFeeHR.Text)) + Val(DGInputHR.Rows(t).Cells(13).Value)
            '    TPpnHR.Text = Val(CDbl(TPpnHR.Text)) + Val(DGInputHR.Rows(t).Cells(14).Value)
            '    TPph23HR.Text = Val(CDbl(TPph23HR.Text)) + Val(DGInputHR.Rows(t).Cells(15).Value)
            '    TGrandTotalHR.Text = Val(CDbl(TGrandTotalHR.Text)) + Val(DGInputHR.Rows(t).Cells(17).Value)
            '    TTakeHomePay.Text = Val(CDbl(TTakeHomePay.Text)) + Val(DGInputHR.Rows(t).Cells(16).Value)
            'Next
        Else
            Return
        End If
    End Sub
#End Region
    Private Sub FrmActivation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        KondisiAwalPE()
        KondisiAwalDetailPE()
        ListHeaderPE() 'LoadHeaderListView
        BacaPE() 'Load daftar penawaran
        ListHeaderMainDetailPE() 'DetailPenawaran
        ListHeaderProduksi() 'Rincian Event
        ListHeaderEksekusi() 'Rincian Event
        ListHeaderManpower() 'Rincian Event

    End Sub
    Private Sub BtnProsesPE_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BtnProsesPE.ItemClick
        If BtnProsesPE.Caption = "Proses Input" Then
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
                GGVM_conn()
                'Dim PeriodeHR As String
                sql = " Select a.nope_activation, a.thnpe_event, b.nama , b.id_divisi from counter a, divisi b where b.id_divisi = '" & DivUser & "' "
                Try
                    cmd = New OdbcCommand(sql, conn)
                    dr = cmd.ExecuteReader
                    dr.Read()
                Catch ex As Exception
                    MsgBox("Terjadi Kesalah !" + ex.Message)
                End Try
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
                Try
                    cmd = New OdbcCommand(c, conn)
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("Terjadi Kesalahan !" + ex.Message)
                    Exit Sub
                Finally
                    GGVM_conn_close()
                End Try

                Select Case ProsesPE
                    Case "Event"
                        GGVM_conn()
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
                        Try
                            cmd = New OdbcCommand(sql, conn)
                            cmd.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox("Terjadi Kesalah !" + ex.Message)
                        Finally
                            GGVM_conn_close()
                        End Try
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
                            Try
                                cmd = New OdbcCommand(sql, conn)
                                cmd.ExecuteNonQuery()
                            Catch ex As Exception
                                MsgBox("Terjadi Kesalahan", MsgBoxStyle.Critical, "Pemberitahuan !!")
                            Finally
                                GGVM_conn_close()
                            End Try
                        End If

                        MsgBox("Data berhasil di Simpan !!", MsgBoxStyle.Information, "Pemberitahuan !!")
                        Dim idno As Integer = 0
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
                        KondisiAwalPE()
                        BacaPE()
                        GGVM_conn_close()
                    Case "Project"
                        GGVM_conn()
                        sql = ""
                        sql = sql & "insert evn_penawaran (nope,idklien,idjenis_pe,project,"
                        sql = sql & "tgl_pe,userid_input,timeinput,iddivisi,"
                        sql = sql & "start_event,end_event,periode,periode_start,periode_end) "
                        sql = sql & " values ('" & urutpe & "','" & TidKlien.Text & "','" & TidJenisPE.Text & "','" & TProject.Text & "',"
                        sql = sql & "'" & Format(DTTanggal.Value, "yyyy/MM/dd") & "','" & userid & "',now(),'" & DivUser & "',"
                        sql = sql & "'" & Format(StartPeriod.Value, "yyyy/MM/dd") & "','" & Format(EndPeriod.Value, "yyyy/MM/dd") & "','" & tglevent & "','" & Format(StartPeriod.Value, "yyyyMM") & "','" & Format(EndPeriod.Value, "yyyyMM") & "')"
                        Try
                            cmd = New OdbcCommand(sql, conn)
                            cmd.ExecuteNonQuery()
                        Catch ex As Exception
                            MsgBox("Terjadi Kesalahan", MsgBoxStyle.Information, "Pemberitahuan !!")
                        End Try

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

                        KondisiAwalPE()
                        BacaPE()
                End Select
                BtnProsesPE.Caption = "Tambah Detail"
            End If
        ElseIf BtnProsesPE.Caption = "Tambah Detail" Then

            BtnProsesPE.Caption = "Simpan Detail"


        End If
    End Sub

End Class