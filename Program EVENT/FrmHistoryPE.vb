Imports System.Data.Odbc

Public Class FrmHistoryPE

    Private Sub ListHeaderPE()
        With ListPE
            .FullRowSelect = True
            .MultiSelect = False
            .View = View.Details
            '.CheckBoxes = True
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
            ' .Columns.Add("SISA PE", 150, HorizontalAlignment.Left)
            .Columns.Add("idpe", 0, HorizontalAlignment.Left)
        End With
    End Sub
    Private Sub ListTampilDetail()
        With TampilDetail
            .FullRowSelect = True
            .MultiSelect = False
            .View = View.Details
            '.CheckBoxes = True
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
        sql = sql & "SELECT a.*,c.subkel FROM evn_tmp_dp a "
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
                    .Add(IIf(IsDBNull(dt.Rows(j)("qty")), "", dt.Rows(j)("qty")))
                    .Add(IIf(IsDBNull(dt.Rows(j)("satuan_qty")), "", dt.Rows(j)("satuan_qty")))
                    .Add(IIf(IsDBNull(dt.Rows(j)("freq")), "", dt.Rows(j)("freq")))
                    .Add(IIf(IsDBNull(dt.Rows(j)("satuan_freq")), "", dt.Rows(j)("satuan_freq")))
                    .Add(IIf(IsDBNull(dt.Rows(j)("day")), "", dt.Rows(j)("day")))
                    .Add(IIf(IsDBNull(dt.Rows(j)("satuan_day")), "", dt.Rows(j)("satuan_day")))
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

    Private Sub BacaPE()
        GGVM_conn()
        sql = ""
        sql = sql & "SELECT * from view_hapuspe "
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
                    .Add(IIf(IsDBNull(dt.Rows(j)("venue")), "", dt.Rows(j)("venue")))
                    .Add(IIf(IsDBNull(dt.Rows(j)("tgl_event")), "", dt.Rows(j)("tgl_event")))
                    '.Add(dt.Rows(j)("tgl_event"))
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
                    '.Add(IIf(IsDBNull(dt.Rows(j)("sisape")), "Belum Ada PO", dt.Rows(j)("sisape")))
                    .Add(dt.Rows(j)("idpe"))
                End With
            End With
        Next
        ListPE.EndUpdate()
        GGVM_conn_close()
    End Sub
    Private Sub FrmHistoryPE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListHeaderPE()
        BacaPE()
        ListTampilDetail()
    End Sub

    Private Sub ListPE_DoubleClick(sender As Object, e As EventArgs) Handles ListPE.DoubleClick
        GGVM_conn()
        Dim StatusBarang As String = ""
        With ListPE
            For Each item As ListViewItem In ListPE.SelectedItems
                If item.Selected Then
                    .SelectedItems.Item(0).Selected = True
                    ' .CheckedItems.Item(0).Checked = True
                End If
                TidPE.Text = item.SubItems(9).Text
                Label1.Text = "NO PE: " + item.SubItems(0).Text
            Next
            Call BacaDetailPE()
            NavigasiPEEvent.SelectedPage = NavDetailBarang
            'Call AutoCompKlien()
            'Call AutoCompProject()
            'Call AutoCompVenue()
            'Call AwalTampil()
            'Call NominalPenawaran()
            'Call DetailTampil()
            'EditPE.Enabled = True
            'BatalTool.Enabled = True
            'CetakTool.Enabled = True
            'DealPe.Enabled = True
            If StatusBarang = "Belum Ada Barang" Then
                'TambahDetail.Enabled = True
                'SimpanDetail.Enabled = True
                'ProsesDetail = "Tambah"
            Else
                'TambahDetail.Enabled = False
                'SimpanDetail.Enabled = False
            End If
        End With
    End Sub

    Private Sub ListPE_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListPE.SelectedIndexChanged
        
    End Sub
End Class