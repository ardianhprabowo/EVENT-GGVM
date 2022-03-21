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
        Me.BtnClose = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.GroupControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(980, 343)
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
        Me.TidPE.Location = New System.Drawing.Point(649, 0)
        Me.TidPE.Name = "TidPE"
        Me.TidPE.PreventEnterBeep = True
        Me.TidPE.Size = New System.Drawing.Size(23, 22)
        Me.TidPE.TabIndex = 39
        Me.TidPE.Visible = False
        '
        'NavigasiPEEvent
        '
        Me.NavigasiPEEvent.AllowDrop = True
        Me.NavigasiPEEvent.AllowGlyphSkinning = True
        Me.NavigasiPEEvent.AllowHtmlDraw = True
        Me.NavigasiPEEvent.Controls.Add(Me.BtnClose)
        Me.NavigasiPEEvent.Controls.Add(Me.Label1)
        Me.NavigasiPEEvent.Controls.Add(Me.NavPenawaran)
        Me.NavigasiPEEvent.Controls.Add(Me.NavDetailBarang)
        Me.NavigasiPEEvent.Cursor = System.Windows.Forms.Cursors.Default
        Me.NavigasiPEEvent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NavigasiPEEvent.ItemOrientation = System.Windows.Forms.Orientation.Vertical
        Me.NavigasiPEEvent.Location = New System.Drawing.Point(2, 23)
        Me.NavigasiPEEvent.LookAndFeel.SkinName = "Office 2013 Dark Gray"
        Me.NavigasiPEEvent.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D
        Me.NavigasiPEEvent.Name = "NavigasiPEEvent"
        Me.NavigasiPEEvent.PageProperties.AllowCustomHeaderButtonsGlyphSkinning = True
        Me.NavigasiPEEvent.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {Me.NavPenawaran, Me.NavDetailBarang})
        Me.NavigasiPEEvent.RegularSize = New System.Drawing.Size(1139, 418)
        Me.NavigasiPEEvent.SelectedPage = Me.NavPenawaran
        Me.NavigasiPEEvent.Size = New System.Drawing.Size(976, 318)
        Me.NavigasiPEEvent.State = DevExpress.XtraBars.Navigation.NavigationPaneState.Expanded
        Me.NavigasiPEEvent.TabIndex = 3
        Me.NavigasiPEEvent.Text = "NavigasiPEEvent"
        Me.NavigasiPEEvent.TransitionType = DevExpress.Utils.Animation.Transitions.Dissolve
        '
        'BtnClose
        '
        Me.BtnClose.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.Appearance.Options.UseFont = True
        Me.BtnClose.Location = New System.Drawing.Point(701, 9)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(75, 23)
        Me.BtnClose.TabIndex = 5
        Me.BtnClose.Text = "Tutup"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(189, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 19)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Label1"
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
        Me.NavPenawaran.Name = "NavPenawaran"
        Me.NavPenawaran.Size = New System.Drawing.Size(920, 245)
        '
        'ListPE
        '
        Me.ListPE.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListPE.HideSelection = False
        Me.ListPE.Location = New System.Drawing.Point(0, 0)
        Me.ListPE.Name = "ListPE"
        Me.ListPE.Size = New System.Drawing.Size(920, 245)
        Me.ListPE.TabIndex = 0
        Me.ListPE.UseCompatibleStateImageBehavior = False
        '
        'NavDetailBarang
        '
        Me.NavDetailBarang.Caption = "Detail Barang"
        Me.NavDetailBarang.Controls.Add(Me.PInput)
        Me.NavDetailBarang.Controls.Add(Me.TampilDetail)
        Me.NavDetailBarang.Name = "NavDetailBarang"
        Me.NavDetailBarang.Size = New System.Drawing.Size(916, 245)
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
        Me.PInput.Location = New System.Drawing.Point(13, 11)
        Me.PInput.Name = "PInput"
        Me.PInput.Size = New System.Drawing.Size(1018, 82)
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
        Me.TInfoKlien.Location = New System.Drawing.Point(649, 40)
        Me.TInfoKlien.Name = "TInfoKlien"
        Me.TInfoKlien.PreventEnterBeep = True
        Me.TInfoKlien.Size = New System.Drawing.Size(32, 22)
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
        Me.TInfoKontrak.Location = New System.Drawing.Point(613, 40)
        Me.TInfoKontrak.Name = "TInfoKontrak"
        Me.TInfoKontrak.PreventEnterBeep = True
        Me.TInfoKontrak.Size = New System.Drawing.Size(32, 22)
        Me.TInfoKontrak.TabIndex = 21
        Me.TInfoKontrak.Visible = False
        '
        'BtnTutup
        '
        Me.BtnTutup.Location = New System.Drawing.Point(915, 50)
        Me.BtnTutup.Name = "BtnTutup"
        Me.BtnTutup.Size = New System.Drawing.Size(75, 23)
        Me.BtnTutup.TabIndex = 18
        Me.BtnTutup.Text = "Tutup"
        '
        'BtnOK
        '
        Me.BtnOK.Location = New System.Drawing.Point(801, 50)
        Me.BtnOK.Name = "BtnOK"
        Me.BtnOK.Size = New System.Drawing.Size(103, 23)
        Me.BtnOK.TabIndex = 12
        Me.BtnOK.Text = "Input"
        '
        'LabelX29
        '
        '
        '
        '
        Me.LabelX29.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX29.Location = New System.Drawing.Point(444, 40)
        Me.LabelX29.Name = "LabelX29"
        Me.LabelX29.Size = New System.Drawing.Size(50, 23)
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
        Me.NoItem.Location = New System.Drawing.Point(500, 40)
        Me.NoItem.Name = "NoItem"
        Me.NoItem.PreventEnterBeep = True
        Me.NoItem.Size = New System.Drawing.Size(73, 22)
        Me.NoItem.TabIndex = 15
        '
        'idInpBarang
        '
        '
        '
        '
        Me.idInpBarang.Border.Class = "TextBoxBorder"
        Me.idInpBarang.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.idInpBarang.Location = New System.Drawing.Point(385, 40)
        Me.idInpBarang.Name = "idInpBarang"
        Me.idInpBarang.PreventEnterBeep = True
        Me.idInpBarang.Size = New System.Drawing.Size(32, 22)
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
        Me.iddetail.Location = New System.Drawing.Point(347, 40)
        Me.iddetail.Name = "iddetail"
        Me.iddetail.PreventEnterBeep = True
        Me.iddetail.Size = New System.Drawing.Size(32, 22)
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
        Me.NoMaterial.Location = New System.Drawing.Point(103, 40)
        Me.NoMaterial.Name = "NoMaterial"
        Me.NoMaterial.PreventEnterBeep = True
        Me.NoMaterial.Size = New System.Drawing.Size(32, 22)
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
        Me.idKontrak.Location = New System.Drawing.Point(140, 40)
        Me.idKontrak.Name = "idKontrak"
        Me.idKontrak.PreventEnterBeep = True
        Me.idKontrak.Size = New System.Drawing.Size(32, 22)
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
        Me.TMaterials.Location = New System.Drawing.Point(178, 40)
        Me.TMaterials.Name = "TMaterials"
        Me.TMaterials.PreventEnterBeep = True
        Me.TMaterials.Size = New System.Drawing.Size(159, 22)
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
        Me.Remaks.Location = New System.Drawing.Point(853, 13)
        Me.Remaks.Name = "Remaks"
        Me.Remaks.PreventEnterBeep = True
        Me.Remaks.Size = New System.Drawing.Size(151, 22)
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
        Me.SubTotal.Location = New System.Drawing.Point(740, 13)
        Me.SubTotal.Name = "SubTotal"
        Me.SubTotal.PreventEnterBeep = True
        Me.SubTotal.Size = New System.Drawing.Size(107, 22)
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
        Me.TUnitCost.Location = New System.Drawing.Point(627, 13)
        Me.TUnitCost.Name = "TUnitCost"
        Me.TUnitCost.PreventEnterBeep = True
        Me.TUnitCost.Size = New System.Drawing.Size(107, 22)
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
        Me.TTotal.Location = New System.Drawing.Point(512, 13)
        Me.TTotal.Name = "TTotal"
        Me.TTotal.PreventEnterBeep = True
        Me.TTotal.Size = New System.Drawing.Size(109, 22)
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
        Me.TDimensi.Location = New System.Drawing.Point(399, 27)
        Me.TDimensi.Name = "TDimensi"
        Me.TDimensi.PreventEnterBeep = True
        Me.TDimensi.Size = New System.Drawing.Size(107, 22)
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
        Me.TDay.Location = New System.Drawing.Point(399, 13)
        Me.TDay.Name = "TDay"
        Me.TDay.PreventEnterBeep = True
        Me.TDay.Size = New System.Drawing.Size(39, 22)
        Me.TDay.TabIndex = 5
        Me.TDay.WatermarkText = "Day"
        '
        'CSDay
        '
        Me.CSDay.DisplayMember = "Text"
        Me.CSDay.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CSDay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CSDay.Font = New System.Drawing.Font("Segoe UI", 7.6!)
        Me.CSDay.FormattingEnabled = True
        Me.CSDay.ItemHeight = 16
        Me.CSDay.Location = New System.Drawing.Point(444, 13)
        Me.CSDay.Name = "CSDay"
        Me.CSDay.Size = New System.Drawing.Size(62, 22)
        Me.CSDay.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CSDay.TabIndex = 6
        '
        'CSFreq
        '
        Me.CSFreq.DisplayMember = "Text"
        Me.CSFreq.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CSFreq.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CSFreq.FormattingEnabled = True
        Me.CSFreq.ItemHeight = 17
        Me.CSFreq.Location = New System.Drawing.Point(335, 12)
        Me.CSFreq.Name = "CSFreq"
        Me.CSFreq.Size = New System.Drawing.Size(58, 23)
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
        Me.TFreq.Location = New System.Drawing.Point(290, 12)
        Me.TFreq.Name = "TFreq"
        Me.TFreq.PreventEnterBeep = True
        Me.TFreq.Size = New System.Drawing.Size(39, 22)
        Me.TFreq.TabIndex = 3
        Me.TFreq.WatermarkText = "Freq"
        '
        'CSQty
        '
        Me.CSQty.DisplayMember = "Text"
        Me.CSQty.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.CSQty.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CSQty.FormattingEnabled = True
        Me.CSQty.ItemHeight = 17
        Me.CSQty.Location = New System.Drawing.Point(223, 12)
        Me.CSQty.Name = "CSQty"
        Me.CSQty.Size = New System.Drawing.Size(59, 23)
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
        Me.TQty.Location = New System.Drawing.Point(178, 12)
        Me.TQty.Name = "TQty"
        Me.TQty.PreventEnterBeep = True
        Me.TQty.Size = New System.Drawing.Size(39, 22)
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
        Me.TCari.Location = New System.Drawing.Point(13, 12)
        Me.TCari.Name = "TCari"
        Me.TCari.PreventEnterBeep = True
        Me.TCari.Size = New System.Drawing.Size(159, 22)
        Me.TCari.TabIndex = 0
        Me.TCari.WatermarkText = "Cari Barang Penawaran"
        '
        'TampilDetail
        '
        Me.TampilDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TampilDetail.HideSelection = False
        Me.TampilDetail.Location = New System.Drawing.Point(0, 0)
        Me.TampilDetail.Name = "TampilDetail"
        Me.TampilDetail.Size = New System.Drawing.Size(916, 245)
        Me.TampilDetail.TabIndex = 1
        Me.TampilDetail.UseCompatibleStateImageBehavior = False
        '
        'FrmHistoryPE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(980, 343)
        Me.Controls.Add(Me.GroupControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
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
    Friend WithEvents BtnTutup As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnOK As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TampilDetail As System.Windows.Forms.ListView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents TInfoKlien As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents TInfoKontrak As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents LabelX29 As DevComponents.DotNetBar.LabelX
    Private WithEvents NoItem As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents idInpBarang As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents iddetail As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents NoMaterial As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents idKontrak As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents TMaterials As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents Remaks As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents SubTotal As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents TUnitCost As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents TTotal As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents TDimensi As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents TDay As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents CSDay As DevComponents.DotNetBar.Controls.ComboBoxEx
    Private WithEvents CSFreq As DevComponents.DotNetBar.Controls.ComboBoxEx
    Private WithEvents TFreq As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents CSQty As DevComponents.DotNetBar.Controls.ComboBoxEx
    Private WithEvents TQty As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents TCari As DevComponents.DotNetBar.Controls.TextBoxX
    Private WithEvents TidPE As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents BtnClose As DevExpress.XtraEditors.SimpleButton
End Class
