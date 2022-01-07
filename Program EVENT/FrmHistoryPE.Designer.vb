<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHistoryPE
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.TidPE = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.NavigasiPEEvent = New DevExpress.XtraBars.Navigation.NavigationPane()
        Me.NavPenawaran = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.ListPE = New System.Windows.Forms.ListView()
        Me.NavDetailBarang = New DevExpress.XtraBars.Navigation.NavigationPage()
        Me.PInput = New System.Windows.Forms.Panel()
        Me.TInfoKlien = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TInfoKontrak = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.BtnTutup = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnOK = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelX29 = New DevComponents.DotNetBar.LabelX()
        Me.NoItem = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.idInpBarang = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.iddetail = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.NoMaterial = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.idKontrak = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TMaterials = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Remaks = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.SubTotal = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TUnitCost = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TTotal = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TDimensi = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TDay = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.CSDay = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.CSFreq = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.TFreq = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.CSQty = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.TQty = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TCari = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.TampilDetail = New System.Windows.Forms.ListView()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.NavigasiPEEvent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.NavigasiPEEvent.SuspendLayout()
        Me.NavPenawaran.SuspendLayout()
        Me.NavDetailBarang.SuspendLayout()
        Me.PInput.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.TidPE)
        Me.GroupControl1.Controls.Add(Me.NavigasiPEEvent)
        Me.GroupControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupControl1.Location = New System.Drawing.Point(0, 0)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(1143, 448)
        Me.GroupControl1.TabIndex = 1
        Me.GroupControl1.Text = "HISTORY HAPUS PENAWARAN"
        '
        'TidPE
        '
        '
        '
        '
        Me.TidPE.Border.Class = "TextBoxBorder"
        Me.TidPE.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TidPE.Location = New System.Drawing.Point(757, 0)
        Me.TidPE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TidPE.Name = "TidPE"
        Me.TidPE.PreventEnterBeep = True
        Me.TidPE.Size = New System.Drawing.Size(27, 25)
        Me.TidPE.TabIndex = 39
        Me.TidPE.Visible = False
        '
        'NavigasiPEEvent
        '
        Me.NavigasiPEEvent.AllowDrop = True
        Me.NavigasiPEEvent.AllowGlyphSkinning = True
        Me.NavigasiPEEvent.AllowHtmlDraw = True
        Me.NavigasiPEEvent.Controls.Add(Me.Label1)
        Me.NavigasiPEEvent.Controls.Add(Me.NavPenawaran)
        Me.NavigasiPEEvent.Controls.Add(Me.NavDetailBarang)
        Me.NavigasiPEEvent.Cursor = System.Windows.Forms.Cursors.Default
        Me.NavigasiPEEvent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NavigasiPEEvent.ItemOrientation = System.Windows.Forms.Orientation.Vertical
        Me.NavigasiPEEvent.Location = New System.Drawing.Point(2, 28)
        Me.NavigasiPEEvent.LookAndFeel.SkinName = "Office 2013 Dark Gray"
        Me.NavigasiPEEvent.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D
        Me.NavigasiPEEvent.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.NavigasiPEEvent.Name = "NavigasiPEEvent"
        Me.NavigasiPEEvent.PageProperties.AllowCustomHeaderButtonsGlyphSkinning = True
        Me.NavigasiPEEvent.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {Me.NavPenawaran, Me.NavDetailBarang})
        Me.NavigasiPEEvent.RegularSize = New System.Drawing.Size(1139, 418)
        Me.NavigasiPEEvent.SelectedPage = Me.NavPenawaran
        Me.NavigasiPEEvent.Size = New System.Drawing.Size(1139, 418)
        Me.NavigasiPEEvent.State = DevExpress.XtraBars.Navigation.NavigationPaneState.Expanded
        Me.NavigasiPEEvent.TabIndex = 3
        Me.NavigasiPEEvent.Text = "NavigasiPEEvent"
        Me.NavigasiPEEvent.TransitionType = DevExpress.Utils.Animation.Transitions.Dissolve
        '
        'NavPenawaran
        '
        Me.NavPenawaran.Appearance.BackColor = System.Drawing.Color.Aqua
        Me.NavPenawaran.Appearance.BackColor2 = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.NavPenawaran.Appearance.BorderColor = System.Drawing.Color.Aqua
        Me.NavPenawaran.Appearance.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.NavPenawaran.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.NavPenawaran.Appearance.Options.UseBackColor = True
        Me.NavPenawaran.Appearance.Options.UseBorderColor = True
        Me.NavPenawaran.Appearance.Options.UseForeColor = True
        Me.NavPenawaran.Caption = "Daftar Penawaran"
        Me.NavPenawaran.Controls.Add(Me.ListPE)
        Me.NavPenawaran.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.NavPenawaran.Name = "NavPenawaran"
        Me.NavPenawaran.Size = New System.Drawing.Size(1065, 328)
        '
        'ListPE
        '
        Me.ListPE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListPE.HideSelection = False
        Me.ListPE.Location = New System.Drawing.Point(0, 0)
        Me.ListPE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ListPE.Name = "ListPE"
        Me.ListPE.Size = New System.Drawing.Size(1065, 328)
        Me.ListPE.TabIndex = 0
        Me.ListPE.UseCompatibleStateImageBehavior = False
        '
        'NavDetailBarang
        '
        Me.NavDetailBarang.Caption = "Detail Barang"
        Me.NavDetailBarang.Controls.Add(Me.PInput)
        Me.NavDetailBarang.Controls.Add(Me.TampilDetail)
        Me.NavDetailBarang.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.NavDetailBarang.Name = "NavDetailBarang"
        Me.NavDetailBarang.Size = New System.Drawing.Size(1065, 328)
        '
        'PInput
        '
        Me.PInput.Controls.Add(Me.TInfoKlien)
        Me.PInput.Controls.Add(Me.TInfoKontrak)
        Me.PInput.Controls.Add(Me.BtnTutup)
        Me.PInput.Controls.Add(Me.BtnOK)
        Me.PInput.Controls.Add(Me.LabelX29)
        Me.PInput.Controls.Add(Me.NoItem)
        Me.PInput.Controls.Add(Me.idInpBarang)
        Me.PInput.Controls.Add(Me.iddetail)
        Me.PInput.Controls.Add(Me.NoMaterial)
        Me.PInput.Controls.Add(Me.idKontrak)
        Me.PInput.Controls.Add(Me.TMaterials)
        Me.PInput.Controls.Add(Me.Remaks)
        Me.PInput.Controls.Add(Me.SubTotal)
        Me.PInput.Controls.Add(Me.TUnitCost)
        Me.PInput.Controls.Add(Me.TTotal)
        Me.PInput.Controls.Add(Me.TDimensi)
        Me.PInput.Controls.Add(Me.TDay)
        Me.PInput.Controls.Add(Me.CSDay)
        Me.PInput.Controls.Add(Me.CSFreq)
        Me.PInput.Controls.Add(Me.TFreq)
        Me.PInput.Controls.Add(Me.CSQty)
        Me.PInput.Controls.Add(Me.TQty)
        Me.PInput.Controls.Add(Me.TCari)
        Me.PInput.Location = New System.Drawing.Point(15, 14)
        Me.PInput.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PInput.Name = "PInput"
        Me.PInput.Size = New System.Drawing.Size(1188, 107)
        Me.PInput.TabIndex = 2
        Me.PInput.Visible = False
        '
        'TInfoKlien
        '
        '
        '
        '
        Me.TInfoKlien.Border.Class = "TextBoxBorder"
        Me.TInfoKlien.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TInfoKlien.Location = New System.Drawing.Point(757, 52)
        Me.TInfoKlien.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TInfoKlien.Name = "TInfoKlien"
        Me.TInfoKlien.PreventEnterBeep = True
        Me.TInfoKlien.Size = New System.Drawing.Size(37, 25)
        Me.TInfoKlien.TabIndex = 22
        Me.TInfoKlien.Visible = False
        '
        'TInfoKontrak
        '
        '
        '
        '
        Me.TInfoKontrak.Border.Class = "TextBoxBorder"
        Me.TInfoKontrak.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TInfoKontrak.Location = New System.Drawing.Point(715, 52)
        Me.TInfoKontrak.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TInfoKontrak.Name = "TInfoKontrak"
        Me.TInfoKontrak.PreventEnterBeep = True
        Me.TInfoKontrak.Size = New System.Drawing.Size(37, 25)
        Me.TInfoKontrak.TabIndex = 21
        Me.TInfoKontrak.Visible = False
        '
        'BtnTutup
        '
        Me.BtnTutup.Location = New System.Drawing.Point(1067, 65)
        Me.BtnTutup.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnTutup.Name = "BtnTutup"
        Me.BtnTutup.Size = New System.Drawing.Size(87, 30)
        Me.BtnTutup.TabIndex = 18
        Me.BtnTutup.Text = "Tutup"
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(934, 65)
        Me.BtnOK.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(120, 30)
        Me.BtnOK.TabIndex = 12
        Me.BtnOK.Text = "Input"
        '
        'LabelX29
        '
        '
        '
        '
        Me.LabelX29.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX29.Location = New System.Drawing.Point(518, 52)
        Me.LabelX29.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LabelX29.Name = "LabelX29"
        Me.LabelX29.Size = New System.Drawing.Size(58, 30)
        Me.LabelX29.TabIndex = 16
        Me.LabelX29.Text = "NO LINE :"
        '
        'NoItem
        '
        '
        '
        '
        Me.NoItem.Border.Class = "TextBoxBorder"
        Me.NoItem.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.NoItem.Location = New System.Drawing.Point(583, 52)
        Me.NoItem.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.NoItem.Name = "NoItem"
        Me.NoItem.PreventEnterBeep = True
        Me.NoItem.Size = New System.Drawing.Size(85, 25)
        Me.NoItem.TabIndex = 15
        '
        'idInpBarang
        '
        '
        '
        '
        Me.idInpBarang.Border.Class = "TextBoxBorder"
        Me.idInpBarang.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.idInpBarang.Location = New System.Drawing.Point(449, 52)
        Me.idInpBarang.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.idInpBarang.Name = "idInpBarang"
        Me.idInpBarang.PreventEnterBeep = True
        Me.idInpBarang.Size = New System.Drawing.Size(37, 25)
        Me.idInpBarang.TabIndex = 14
        Me.idInpBarang.Visible = False
        '
        'iddetail
        '
        '
        '
        '
        Me.iddetail.Border.Class = "TextBoxBorder"
        Me.iddetail.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.iddetail.Location = New System.Drawing.Point(405, 52)
        Me.iddetail.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.iddetail.Name = "iddetail"
        Me.iddetail.PreventEnterBeep = True
        Me.iddetail.Size = New System.Drawing.Size(37, 25)
        Me.iddetail.TabIndex = 13
        Me.iddetail.Visible = False
        '
        'NoMaterial
        '
        '
        '
        '
        Me.NoMaterial.Border.Class = "TextBoxBorder"
        Me.NoMaterial.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.NoMaterial.Location = New System.Drawing.Point(120, 52)
        Me.NoMaterial.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.NoMaterial.Name = "NoMaterial"
        Me.NoMaterial.PreventEnterBeep = True
        Me.NoMaterial.Size = New System.Drawing.Size(37, 25)
        Me.NoMaterial.TabIndex = 12
        Me.NoMaterial.Visible = False
        '
        'idKontrak
        '
        '
        '
        '
        Me.idKontrak.Border.Class = "TextBoxBorder"
        Me.idKontrak.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.idKontrak.Location = New System.Drawing.Point(163, 52)
        Me.idKontrak.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.idKontrak.Name = "idKontrak"
        Me.idKontrak.PreventEnterBeep = True
        Me.idKontrak.Size = New System.Drawing.Size(37, 25)
        Me.idKontrak.TabIndex = 11
        Me.idKontrak.Visible = False
        '
        'TMaterials
        '
        '
        '
        '
        Me.TMaterials.Border.Class = "TextBoxBorder"
        Me.TMaterials.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TMaterials.Location = New System.Drawing.Point(208, 52)
        Me.TMaterials.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TMaterials.Name = "TMaterials"
        Me.TMaterials.PreventEnterBeep = True
        Me.TMaterials.Size = New System.Drawing.Size(185, 25)
        Me.TMaterials.TabIndex = 10
        Me.TMaterials.WatermarkText = "Material Barang"
        '
        'Remaks
        '
        '
        '
        '
        Me.Remaks.Border.Class = "TextBoxBorder"
        Me.Remaks.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.Remaks.Location = New System.Drawing.Point(995, 17)
        Me.Remaks.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Remaks.Name = "Remaks"
        Me.Remaks.PreventEnterBeep = True
        Me.Remaks.Size = New System.Drawing.Size(176, 25)
        Me.Remaks.TabIndex = 11
        Me.Remaks.WatermarkText = "Keterangan"
        '
        'SubTotal
        '
        '
        '
        '
        Me.SubTotal.Border.Class = "TextBoxBorder"
        Me.SubTotal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.SubTotal.Location = New System.Drawing.Point(863, 17)
        Me.SubTotal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.SubTotal.Name = "SubTotal"
        Me.SubTotal.PreventEnterBeep = True
        Me.SubTotal.Size = New System.Drawing.Size(125, 25)
        Me.SubTotal.TabIndex = 10
        Me.SubTotal.WatermarkText = "Sub Total"
        '
        'TUnitCost
        '
        '
        '
        '
        Me.TUnitCost.Border.Class = "TextBoxBorder"
        Me.TUnitCost.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TUnitCost.Location = New System.Drawing.Point(731, 17)
        Me.TUnitCost.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TUnitCost.Name = "TUnitCost"
        Me.TUnitCost.PreventEnterBeep = True
        Me.TUnitCost.Size = New System.Drawing.Size(125, 25)
        Me.TUnitCost.TabIndex = 9
        Me.TUnitCost.WatermarkText = "Unit Cost"
        '
        'TTotal
        '
        '
        '
        '
        Me.TTotal.Border.Class = "TextBoxBorder"
        Me.TTotal.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TTotal.Location = New System.Drawing.Point(597, 17)
        Me.TTotal.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TTotal.Name = "TTotal"
        Me.TTotal.PreventEnterBeep = True
        Me.TTotal.Size = New System.Drawing.Size(127, 25)
        Me.TTotal.TabIndex = 8
        Me.TTotal.WatermarkText = "Total Item"
        '
        'TDimensi
        '
        '
        '
        '
        Me.TDimensi.Border.Class = "TextBoxBorder"
        Me.TDimensi.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TDimensi.Location = New System.Drawing.Point(465, 35)
        Me.TDimensi.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TDimensi.Name = "TDimensi"
        Me.TDimensi.PreventEnterBeep = True
        Me.TDimensi.Size = New System.Drawing.Size(125, 25)
        Me.TDimensi.TabIndex = 7
        Me.TDimensi.WatermarkText = "Dimensi"
        '
        'TDay
        '
        '
        '
        '
        Me.TDay.Border.Class = "TextBoxBorder"
        Me.TDay.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TDay.Location = New System.Drawing.Point(465, 17)
        Me.TDay.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TDay.Name = "TDay"
        Me.TDay.PreventEnterBeep = True
        Me.TDay.Size = New System.Drawing.Size(45, 25)
        Me.TDay.TabIndex = 5
        Me.TDay.WatermarkText = "Day"
        '
        'CSDay
        '
        Me.CSDay.DisplayMember = "Text"
        Me.CSDay.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CSDay.Font = New System.Drawing.Font("Segoe UI", 7.6!)
        Me.CSDay.FormattingEnabled = True
        Me.CSDay.ItemHeight = 16
        Me.CSDay.Location = New System.Drawing.Point(518, 17)
        Me.CSDay.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CSDay.Name = "CSDay"
        Me.CSDay.Size = New System.Drawing.Size(72, 22)
        Me.CSDay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CSDay.TabIndex = 6
        '
        'CSFreq
        '
        Me.CSFreq.DisplayMember = "Text"
        Me.CSFreq.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CSFreq.FormattingEnabled = True
        Me.CSFreq.ItemHeight = 20
        Me.CSFreq.Location = New System.Drawing.Point(391, 16)
        Me.CSFreq.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CSFreq.Name = "CSFreq"
        Me.CSFreq.Size = New System.Drawing.Size(67, 26)
        Me.CSFreq.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CSFreq.TabIndex = 4
        '
        'TFreq
        '
        '
        '
        '
        Me.TFreq.Border.Class = "TextBoxBorder"
        Me.TFreq.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TFreq.Location = New System.Drawing.Point(338, 16)
        Me.TFreq.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TFreq.Name = "TFreq"
        Me.TFreq.PreventEnterBeep = True
        Me.TFreq.Size = New System.Drawing.Size(45, 25)
        Me.TFreq.TabIndex = 3
        Me.TFreq.WatermarkText = "Freq"
        '
        'CSQty
        '
        Me.CSQty.DisplayMember = "Text"
        Me.CSQty.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CSQty.FormattingEnabled = True
        Me.CSQty.ItemHeight = 20
        Me.CSQty.Location = New System.Drawing.Point(260, 16)
        Me.CSQty.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.CSQty.Name = "CSQty"
        Me.CSQty.Size = New System.Drawing.Size(68, 26)
        Me.CSQty.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CSQty.TabIndex = 2
        '
        'TQty
        '
        '
        '
        '
        Me.TQty.Border.Class = "TextBoxBorder"
        Me.TQty.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TQty.Location = New System.Drawing.Point(208, 16)
        Me.TQty.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TQty.Name = "TQty"
        Me.TQty.PreventEnterBeep = True
        Me.TQty.Size = New System.Drawing.Size(45, 25)
        Me.TQty.TabIndex = 1
        Me.TQty.WatermarkText = "Qty"
        '
        'TCari
        '
        '
        '
        '
        Me.TCari.Border.Class = "TextBoxBorder"
        Me.TCari.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TCari.Location = New System.Drawing.Point(15, 16)
        Me.TCari.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TCari.Name = "TCari"
        Me.TCari.PreventEnterBeep = True
        Me.TCari.Size = New System.Drawing.Size(185, 25)
        Me.TCari.TabIndex = 0
        Me.TCari.WatermarkText = "Cari Barang Penawaran"
        '
        'TampilDetail
        '
        Me.TampilDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TampilDetail.HideSelection = False
        Me.TampilDetail.Location = New System.Drawing.Point(0, 0)
        Me.TampilDetail.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TampilDetail.Name = "TampilDetail"
        Me.TampilDetail.Size = New System.Drawing.Size(1065, 328)
        Me.TampilDetail.TabIndex = 1
        Me.TampilDetail.UseCompatibleStateImageBehavior = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(221, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 23)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Label1"
        '
        'FrmHistoryPE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1143, 448)
        Me.Controls.Add(Me.GroupControl1)
        Me.Name = "FrmHistoryPE"
        Me.Text = "FrmHistoryPE"
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.NavigasiPEEvent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.NavigasiPEEvent.ResumeLayout(False)
        Me.NavigasiPEEvent.PerformLayout()
        Me.NavPenawaran.ResumeLayout(False)
        Me.NavDetailBarang.ResumeLayout(False)
        Me.PInput.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents NavigasiPEEvent As DevExpress.XtraBars.Navigation.NavigationPane
    Friend WithEvents NavPenawaran As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents ListPE As System.Windows.Forms.ListView
    Friend WithEvents NavDetailBarang As DevExpress.XtraBars.Navigation.NavigationPage
    Friend WithEvents PInput As System.Windows.Forms.Panel
    Friend WithEvents TInfoKlien As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TInfoKontrak As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents BtnTutup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelX29 As DevComponents.DotNetBar.LabelX
    Friend WithEvents NoItem As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents idInpBarang As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents iddetail As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents NoMaterial As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents idKontrak As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TMaterials As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Remaks As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents SubTotal As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TUnitCost As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TTotal As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TDimensi As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TDay As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents CSDay As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents CSFreq As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents TFreq As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents CSQty As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents TQty As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TCari As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TampilDetail As System.Windows.Forms.ListView
    Friend WithEvents TidPE As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
