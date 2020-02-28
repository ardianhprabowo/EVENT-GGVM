<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmKontrak
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmKontrak))
		Me.NavKontrak = New DevExpress.XtraBars.Navigation.NavigationPane()
		Me.NavDetailKontrak = New DevExpress.XtraBars.Navigation.NavigationPage()
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.ListMaterial = New System.Windows.Forms.ListView()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.PDaftar = New System.Windows.Forms.Panel()
		Me.BTutupKontrak = New DevExpress.XtraEditors.SimpleButton()
		Me.ListKontrak = New DevComponents.DotNetBar.Controls.ListViewEx()
		Me.LabelX20 = New DevComponents.DotNetBar.LabelX()
		Me.LabelX21 = New DevComponents.DotNetBar.LabelX()
		Me.TCariKontrak = New DevComponents.DotNetBar.Controls.TextBoxX()
		Me.TidKontrak = New DevComponents.DotNetBar.Controls.TextBoxX()
		Me.LabelX16 = New DevComponents.DotNetBar.LabelX()
		Me.BSimpanKontrak = New DevExpress.XtraEditors.SimpleButton()
		Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
		Me.DTPrint = New System.Windows.Forms.DateTimePicker()
		Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
		Me.LabelX17 = New DevComponents.DotNetBar.LabelX()
		Me.TKlien = New DevComponents.DotNetBar.Controls.TextBoxX()
		Me.LabelX18 = New DevComponents.DotNetBar.LabelX()
		Me.TidKlien = New DevComponents.DotNetBar.Controls.TextBoxX()
		Me.DTEnd = New System.Windows.Forms.DateTimePicker()
		Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
		Me.DTStart = New System.Windows.Forms.DateTimePicker()
		Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
		Me.DTKontrak = New System.Windows.Forms.DateTimePicker()
		Me.TAlamat = New DevComponents.DotNetBar.Controls.TextBoxX()
		Me.LabelX15 = New DevComponents.DotNetBar.LabelX()
		Me.TidK = New DevComponents.DotNetBar.Controls.TextBoxX()
		Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
		Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
		Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
		Me.LabelX14 = New DevComponents.DotNetBar.LabelX()
		Me.TKota = New DevComponents.DotNetBar.Controls.TextBoxX()
		Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
		Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
		Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
		Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
		Me.TNilaiKontrak = New DevComponents.DotNetBar.Controls.TextBoxX()
		Me.TKontrak = New DevComponents.DotNetBar.Controls.TextBoxX()
		Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
		Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
		Me.NavImportKontrak = New DevExpress.XtraBars.Navigation.NavigationPage()
		Me.Panel4 = New System.Windows.Forms.Panel()
		Me.ListImport = New DevComponents.DotNetBar.Controls.ListViewEx()
		Me.Panel3 = New System.Windows.Forms.Panel()
		Me.CSubKel = New DevComponents.DotNetBar.Controls.ComboBoxEx()
		Me.ImportBtn = New DevComponents.DotNetBar.ButtonX()
		Me.LabelX19 = New DevComponents.DotNetBar.LabelX()
		Me.InputSheetName = New DevComponents.DotNetBar.Controls.TextBoxX()
		Me.TCari = New DevComponents.DotNetBar.Controls.TextBoxX()
		Me.CariExcel = New DevComponents.DotNetBar.ButtonX()
		Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
		Me.BDaftarKontrak = New DevExpress.XtraEditors.SimpleButton()
		Me.BImport = New DevExpress.XtraEditors.SimpleButton()
		Me.BKeluar = New DevExpress.XtraEditors.SimpleButton()
		Me.BBatal = New DevExpress.XtraEditors.SimpleButton()
		Me.TambahKontrak = New DevExpress.XtraEditors.SimpleButton()
		Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
		Me.TidSubkel = New DevComponents.DotNetBar.Controls.TextBoxX()
		Me.LabelX22 = New DevComponents.DotNetBar.LabelX()
		CType(Me.NavKontrak, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.NavKontrak.SuspendLayout()
		Me.NavDetailKontrak.SuspendLayout()
		Me.Panel2.SuspendLayout()
		Me.Panel1.SuspendLayout()
		Me.PDaftar.SuspendLayout()
		Me.NavImportKontrak.SuspendLayout()
		Me.Panel4.SuspendLayout()
		Me.Panel3.SuspendLayout()
		CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SplitContainer1.Panel1.SuspendLayout()
		Me.SplitContainer1.Panel2.SuspendLayout()
		Me.SplitContainer1.SuspendLayout()
		Me.SuspendLayout()
		'
		'NavKontrak
		'
		Me.NavKontrak.Controls.Add(Me.NavDetailKontrak)
		Me.NavKontrak.Controls.Add(Me.NavImportKontrak)
		Me.NavKontrak.Dock = System.Windows.Forms.DockStyle.Fill
		Me.NavKontrak.Location = New System.Drawing.Point(0, 0)
		Me.NavKontrak.Name = "NavKontrak"
		Me.NavKontrak.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {Me.NavDetailKontrak, Me.NavImportKontrak})
		Me.NavKontrak.RegularSize = New System.Drawing.Size(856, 464)
		Me.NavKontrak.SelectedPage = Me.NavDetailKontrak
		Me.NavKontrak.Size = New System.Drawing.Size(856, 464)
		Me.NavKontrak.State = DevExpress.XtraBars.Navigation.NavigationPaneState.Expanded
		Me.NavKontrak.TabIndex = 0
		Me.NavKontrak.Text = "Daftar Kontrak"
		'
		'NavDetailKontrak
		'
		Me.NavDetailKontrak.Caption = "Daftar Kontrak"
		Me.NavDetailKontrak.Controls.Add(Me.Panel2)
		Me.NavDetailKontrak.Controls.Add(Me.Panel1)
		Me.NavDetailKontrak.Name = "NavDetailKontrak"
		Me.NavDetailKontrak.Size = New System.Drawing.Size(755, 406)
		'
		'Panel2
		'
		Me.Panel2.Controls.Add(Me.ListMaterial)
		Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Panel2.Location = New System.Drawing.Point(0, 196)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(755, 210)
		Me.Panel2.TabIndex = 32
		'
		'ListMaterial
		'
		Me.ListMaterial.Dock = System.Windows.Forms.DockStyle.Fill
		Me.ListMaterial.HideSelection = False
		Me.ListMaterial.Location = New System.Drawing.Point(0, 0)
		Me.ListMaterial.Name = "ListMaterial"
		Me.ListMaterial.Size = New System.Drawing.Size(755, 210)
		Me.ListMaterial.TabIndex = 1
		Me.ListMaterial.UseCompatibleStateImageBehavior = False
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.PDaftar)
		Me.Panel1.Controls.Add(Me.TidKontrak)
		Me.Panel1.Controls.Add(Me.LabelX16)
		Me.Panel1.Controls.Add(Me.BSimpanKontrak)
		Me.Panel1.Controls.Add(Me.LabelX1)
		Me.Panel1.Controls.Add(Me.DTPrint)
		Me.Panel1.Controls.Add(Me.LabelX2)
		Me.Panel1.Controls.Add(Me.LabelX17)
		Me.Panel1.Controls.Add(Me.TKlien)
		Me.Panel1.Controls.Add(Me.LabelX18)
		Me.Panel1.Controls.Add(Me.TidKlien)
		Me.Panel1.Controls.Add(Me.DTEnd)
		Me.Panel1.Controls.Add(Me.LabelX4)
		Me.Panel1.Controls.Add(Me.DTStart)
		Me.Panel1.Controls.Add(Me.LabelX3)
		Me.Panel1.Controls.Add(Me.DTKontrak)
		Me.Panel1.Controls.Add(Me.TAlamat)
		Me.Panel1.Controls.Add(Me.LabelX15)
		Me.Panel1.Controls.Add(Me.TidK)
		Me.Panel1.Controls.Add(Me.LabelX6)
		Me.Panel1.Controls.Add(Me.LabelX13)
		Me.Panel1.Controls.Add(Me.LabelX5)
		Me.Panel1.Controls.Add(Me.LabelX14)
		Me.Panel1.Controls.Add(Me.TKota)
		Me.Panel1.Controls.Add(Me.LabelX11)
		Me.Panel1.Controls.Add(Me.LabelX8)
		Me.Panel1.Controls.Add(Me.LabelX12)
		Me.Panel1.Controls.Add(Me.LabelX7)
		Me.Panel1.Controls.Add(Me.TNilaiKontrak)
		Me.Panel1.Controls.Add(Me.TKontrak)
		Me.Panel1.Controls.Add(Me.LabelX9)
		Me.Panel1.Controls.Add(Me.LabelX10)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel1.Location = New System.Drawing.Point(0, 0)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(755, 196)
		Me.Panel1.TabIndex = 31
		'
		'PDaftar
		'
		Me.PDaftar.BackColor = System.Drawing.Color.SpringGreen
		Me.PDaftar.Controls.Add(Me.BTutupKontrak)
		Me.PDaftar.Controls.Add(Me.ListKontrak)
		Me.PDaftar.Controls.Add(Me.LabelX20)
		Me.PDaftar.Controls.Add(Me.LabelX21)
		Me.PDaftar.Controls.Add(Me.TCariKontrak)
		Me.PDaftar.Location = New System.Drawing.Point(138, 17)
		Me.PDaftar.Name = "PDaftar"
		Me.PDaftar.Size = New System.Drawing.Size(446, 179)
		Me.PDaftar.TabIndex = 32
		Me.PDaftar.Visible = False
		'
		'BTutupKontrak
		'
		Me.BTutupKontrak.Location = New System.Drawing.Point(182, 153)
		Me.BTutupKontrak.Name = "BTutupKontrak"
		Me.BTutupKontrak.Size = New System.Drawing.Size(89, 23)
		Me.BTutupKontrak.TabIndex = 7
		Me.BTutupKontrak.Text = "Tutup"
		'
		'ListKontrak
		'
		'
		'
		'
		Me.ListKontrak.Border.Class = "ListViewBorder"
		Me.ListKontrak.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.ListKontrak.DisabledBackColor = System.Drawing.Color.Empty
		Me.ListKontrak.HideSelection = False
		Me.ListKontrak.Location = New System.Drawing.Point(13, 39)
		Me.ListKontrak.Name = "ListKontrak"
		Me.ListKontrak.Size = New System.Drawing.Size(421, 111)
		Me.ListKontrak.TabIndex = 6
		Me.ListKontrak.UseCompatibleStateImageBehavior = False
		'
		'LabelX20
		'
		'
		'
		'
		Me.LabelX20.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.LabelX20.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelX20.Location = New System.Drawing.Point(13, 8)
		Me.LabelX20.Name = "LabelX20"
		Me.LabelX20.Size = New System.Drawing.Size(75, 20)
		Me.LabelX20.TabIndex = 3
		Me.LabelX20.Text = "No. Kontrak"
		'
		'LabelX21
		'
		'
		'
		'
		Me.LabelX21.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.LabelX21.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelX21.Location = New System.Drawing.Point(94, 8)
		Me.LabelX21.Name = "LabelX21"
		Me.LabelX21.Size = New System.Drawing.Size(10, 20)
		Me.LabelX21.TabIndex = 4
		Me.LabelX21.Text = ":"
		'
		'TCariKontrak
		'
		'
		'
		'
		Me.TCariKontrak.Border.Class = "TextBoxBorder"
		Me.TCariKontrak.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.TCariKontrak.Location = New System.Drawing.Point(110, 7)
		Me.TCariKontrak.Name = "TCariKontrak"
		Me.TCariKontrak.PreventEnterBeep = True
		Me.TCariKontrak.Size = New System.Drawing.Size(295, 21)
		Me.TCariKontrak.TabIndex = 5
		Me.TCariKontrak.WatermarkText = "Cari Nomor Kontrak"
		'
		'TidKontrak
		'
		'
		'
		'
		Me.TidKontrak.Border.Class = "TextBoxBorder"
		Me.TidKontrak.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.TidKontrak.Location = New System.Drawing.Point(645, 15)
		Me.TidKontrak.Name = "TidKontrak"
		Me.TidKontrak.PreventEnterBeep = True
		Me.TidKontrak.Size = New System.Drawing.Size(28, 21)
		Me.TidKontrak.TabIndex = 31
		'
		'LabelX16
		'
		'
		'
		'
		Me.LabelX16.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.LabelX16.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelX16.Location = New System.Drawing.Point(15, 151)
		Me.LabelX16.Name = "LabelX16"
		Me.LabelX16.Size = New System.Drawing.Size(75, 20)
		Me.LabelX16.TabIndex = 23
		Me.LabelX16.Text = "Tanggal"
		'
		'BSimpanKontrak
		'
		Me.BSimpanKontrak.Enabled = False
		Me.BSimpanKontrak.ImageOptions.SvgImage = CType(resources.GetObject("BSimpanKontrak.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
		Me.BSimpanKontrak.ImageOptions.SvgImageSize = New System.Drawing.Size(25, 25)
		Me.BSimpanKontrak.Location = New System.Drawing.Point(439, 153)
		Me.BSimpanKontrak.Name = "BSimpanKontrak"
		Me.BSimpanKontrak.Size = New System.Drawing.Size(200, 25)
		Me.BSimpanKontrak.TabIndex = 3
		Me.BSimpanKontrak.Text = "Simpan Kontrak"
		'
		'LabelX1
		'
		'
		'
		'
		Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.LabelX1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelX1.Location = New System.Drawing.Point(17, 13)
		Me.LabelX1.Name = "LabelX1"
		Me.LabelX1.Size = New System.Drawing.Size(75, 20)
		Me.LabelX1.TabIndex = 0
		Me.LabelX1.Text = "Nama Klien"
		'
		'DTPrint
		'
		Me.DTPrint.CustomFormat = "yyyy/MM/dd"
		Me.DTPrint.Format = System.Windows.Forms.DateTimePickerFormat.Custom
		Me.DTPrint.Location = New System.Drawing.Point(439, 126)
		Me.DTPrint.Name = "DTPrint"
		Me.DTPrint.Size = New System.Drawing.Size(200, 21)
		Me.DTPrint.TabIndex = 30
		'
		'LabelX2
		'
		'
		'
		'
		Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.LabelX2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelX2.Location = New System.Drawing.Point(98, 13)
		Me.LabelX2.Name = "LabelX2"
		Me.LabelX2.Size = New System.Drawing.Size(10, 20)
		Me.LabelX2.TabIndex = 1
		Me.LabelX2.Text = ":"
		'
		'LabelX17
		'
		'
		'
		'
		Me.LabelX17.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.LabelX17.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelX17.Location = New System.Drawing.Point(423, 125)
		Me.LabelX17.Name = "LabelX17"
		Me.LabelX17.Size = New System.Drawing.Size(10, 20)
		Me.LabelX17.TabIndex = 29
		Me.LabelX17.Text = ":"
		'
		'TKlien
		'
		'
		'
		'
		Me.TKlien.Border.Class = "TextBoxBorder"
		Me.TKlien.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.TKlien.Location = New System.Drawing.Point(114, 15)
		Me.TKlien.Name = "TKlien"
		Me.TKlien.PreventEnterBeep = True
		Me.TKlien.Size = New System.Drawing.Size(200, 21)
		Me.TKlien.TabIndex = 2
		'
		'LabelX18
		'
		'
		'
		'
		Me.LabelX18.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.LabelX18.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelX18.Location = New System.Drawing.Point(329, 125)
		Me.LabelX18.Name = "LabelX18"
		Me.LabelX18.Size = New System.Drawing.Size(88, 20)
		Me.LabelX18.TabIndex = 28
		Me.LabelX18.Text = "Tanggal Print"
		'
		'TidKlien
		'
		'
		'
		'
		Me.TidKlien.Border.Class = "TextBoxBorder"
		Me.TidKlien.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.TidKlien.Location = New System.Drawing.Point(64, 72)
		Me.TidKlien.Name = "TidKlien"
		Me.TidKlien.PreventEnterBeep = True
		Me.TidKlien.Size = New System.Drawing.Size(28, 21)
		Me.TidKlien.TabIndex = 3
		Me.TidKlien.Visible = False
		'
		'DTEnd
		'
		Me.DTEnd.CustomFormat = "yyyy/MM/dd"
		Me.DTEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom
		Me.DTEnd.Location = New System.Drawing.Point(439, 99)
		Me.DTEnd.Name = "DTEnd"
		Me.DTEnd.Size = New System.Drawing.Size(200, 21)
		Me.DTEnd.TabIndex = 27
		'
		'LabelX4
		'
		'
		'
		'
		Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.LabelX4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelX4.Location = New System.Drawing.Point(17, 46)
		Me.LabelX4.Name = "LabelX4"
		Me.LabelX4.Size = New System.Drawing.Size(75, 20)
		Me.LabelX4.TabIndex = 4
		Me.LabelX4.Text = "Alamat"
		'
		'DTStart
		'
		Me.DTStart.CustomFormat = "yyyy/MM/dd"
		Me.DTStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
		Me.DTStart.Location = New System.Drawing.Point(439, 72)
		Me.DTStart.Name = "DTStart"
		Me.DTStart.Size = New System.Drawing.Size(200, 21)
		Me.DTStart.TabIndex = 26
		'
		'LabelX3
		'
		'
		'
		'
		Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.LabelX3.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelX3.Location = New System.Drawing.Point(98, 46)
		Me.LabelX3.Name = "LabelX3"
		Me.LabelX3.Size = New System.Drawing.Size(10, 20)
		Me.LabelX3.TabIndex = 5
		Me.LabelX3.Text = ":"
		'
		'DTKontrak
		'
		Me.DTKontrak.CustomFormat = "yyyy/MM/dd"
		Me.DTKontrak.Format = System.Windows.Forms.DateTimePickerFormat.Custom
		Me.DTKontrak.Location = New System.Drawing.Point(114, 152)
		Me.DTKontrak.Name = "DTKontrak"
		Me.DTKontrak.Size = New System.Drawing.Size(200, 21)
		Me.DTKontrak.TabIndex = 25
		'
		'TAlamat
		'
		'
		'
		'
		Me.TAlamat.Border.Class = "TextBoxBorder"
		Me.TAlamat.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.TAlamat.Location = New System.Drawing.Point(114, 48)
		Me.TAlamat.Multiline = True
		Me.TAlamat.Name = "TAlamat"
		Me.TAlamat.PreventEnterBeep = True
		Me.TAlamat.Size = New System.Drawing.Size(200, 63)
		Me.TAlamat.TabIndex = 6
		'
		'LabelX15
		'
		'
		'
		'
		Me.LabelX15.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.LabelX15.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelX15.Location = New System.Drawing.Point(98, 151)
		Me.LabelX15.Name = "LabelX15"
		Me.LabelX15.Size = New System.Drawing.Size(10, 20)
		Me.LabelX15.TabIndex = 24
		Me.LabelX15.Text = ":"
		'
		'TidK
		'
		'
		'
		'
		Me.TidK.Border.Class = "TextBoxBorder"
		Me.TidK.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.TidK.Location = New System.Drawing.Point(30, 72)
		Me.TidK.Name = "TidK"
		Me.TidK.PreventEnterBeep = True
		Me.TidK.Size = New System.Drawing.Size(28, 21)
		Me.TidK.TabIndex = 7
		Me.TidK.Visible = False
		'
		'LabelX6
		'
		'
		'
		'
		Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.LabelX6.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelX6.Location = New System.Drawing.Point(17, 121)
		Me.LabelX6.Name = "LabelX6"
		Me.LabelX6.Size = New System.Drawing.Size(75, 20)
		Me.LabelX6.TabIndex = 8
		Me.LabelX6.Text = "Kota"
		'
		'LabelX13
		'
		'
		'
		'
		Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.LabelX13.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelX13.Location = New System.Drawing.Point(423, 98)
		Me.LabelX13.Name = "LabelX13"
		Me.LabelX13.Size = New System.Drawing.Size(10, 20)
		Me.LabelX13.TabIndex = 21
		Me.LabelX13.Text = ":"
		'
		'LabelX5
		'
		'
		'
		'
		Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.LabelX5.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelX5.Location = New System.Drawing.Point(98, 121)
		Me.LabelX5.Name = "LabelX5"
		Me.LabelX5.Size = New System.Drawing.Size(10, 20)
		Me.LabelX5.TabIndex = 9
		Me.LabelX5.Text = ":"
		'
		'LabelX14
		'
		'
		'
		'
		Me.LabelX14.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.LabelX14.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelX14.Location = New System.Drawing.Point(329, 98)
		Me.LabelX14.Name = "LabelX14"
		Me.LabelX14.Size = New System.Drawing.Size(75, 20)
		Me.LabelX14.TabIndex = 20
		Me.LabelX14.Text = "Berakhir"
		'
		'TKota
		'
		'
		'
		'
		Me.TKota.Border.Class = "TextBoxBorder"
		Me.TKota.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.TKota.Location = New System.Drawing.Point(114, 123)
		Me.TKota.Name = "TKota"
		Me.TKota.PreventEnterBeep = True
		Me.TKota.Size = New System.Drawing.Size(200, 21)
		Me.TKota.TabIndex = 10
		'
		'LabelX11
		'
		'
		'
		'
		Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.LabelX11.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelX11.Location = New System.Drawing.Point(423, 72)
		Me.LabelX11.Name = "LabelX11"
		Me.LabelX11.Size = New System.Drawing.Size(10, 20)
		Me.LabelX11.TabIndex = 18
		Me.LabelX11.Text = ":"
		'
		'LabelX8
		'
		'
		'
		'
		Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.LabelX8.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelX8.Location = New System.Drawing.Point(329, 13)
		Me.LabelX8.Name = "LabelX8"
		Me.LabelX8.Size = New System.Drawing.Size(75, 20)
		Me.LabelX8.TabIndex = 11
		Me.LabelX8.Text = "No. Kontrak"
		'
		'LabelX12
		'
		'
		'
		'
		Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.LabelX12.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelX12.Location = New System.Drawing.Point(329, 73)
		Me.LabelX12.Name = "LabelX12"
		Me.LabelX12.Size = New System.Drawing.Size(75, 20)
		Me.LabelX12.TabIndex = 17
		Me.LabelX12.Text = "Mulai"
		'
		'LabelX7
		'
		'
		'
		'
		Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.LabelX7.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelX7.Location = New System.Drawing.Point(421, 13)
		Me.LabelX7.Name = "LabelX7"
		Me.LabelX7.Size = New System.Drawing.Size(10, 20)
		Me.LabelX7.TabIndex = 12
		Me.LabelX7.Text = ":"
		'
		'TNilaiKontrak
		'
		'
		'
		'
		Me.TNilaiKontrak.Border.Class = "TextBoxBorder"
		Me.TNilaiKontrak.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.TNilaiKontrak.Location = New System.Drawing.Point(439, 43)
		Me.TNilaiKontrak.Name = "TNilaiKontrak"
		Me.TNilaiKontrak.PreventEnterBeep = True
		Me.TNilaiKontrak.Size = New System.Drawing.Size(200, 21)
		Me.TNilaiKontrak.TabIndex = 16
		'
		'TKontrak
		'
		'
		'
		'
		Me.TKontrak.Border.Class = "TextBoxBorder"
		Me.TKontrak.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.TKontrak.Location = New System.Drawing.Point(439, 15)
		Me.TKontrak.Name = "TKontrak"
		Me.TKontrak.PreventEnterBeep = True
		Me.TKontrak.Size = New System.Drawing.Size(200, 21)
		Me.TKontrak.TabIndex = 13
		'
		'LabelX9
		'
		'
		'
		'
		Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.LabelX9.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelX9.Location = New System.Drawing.Point(421, 41)
		Me.LabelX9.Name = "LabelX9"
		Me.LabelX9.Size = New System.Drawing.Size(10, 20)
		Me.LabelX9.TabIndex = 15
		Me.LabelX9.Text = ":"
		'
		'LabelX10
		'
		'
		'
		'
		Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.LabelX10.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelX10.Location = New System.Drawing.Point(329, 41)
		Me.LabelX10.Name = "LabelX10"
		Me.LabelX10.Size = New System.Drawing.Size(75, 20)
		Me.LabelX10.TabIndex = 14
		Me.LabelX10.Text = "Nilai Kontrak"
		'
		'NavImportKontrak
		'
		Me.NavImportKontrak.Caption = "Import Data Kontrak"
		Me.NavImportKontrak.Controls.Add(Me.Panel4)
		Me.NavImportKontrak.Controls.Add(Me.Panel3)
		Me.NavImportKontrak.Name = "NavImportKontrak"
		Me.NavImportKontrak.PageVisible = False
		Me.NavImportKontrak.Size = New System.Drawing.Size(755, 406)
		'
		'Panel4
		'
		Me.Panel4.Controls.Add(Me.ListImport)
		Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
		Me.Panel4.Location = New System.Drawing.Point(0, 95)
		Me.Panel4.Name = "Panel4"
		Me.Panel4.Size = New System.Drawing.Size(755, 311)
		Me.Panel4.TabIndex = 1
		'
		'ListImport
		'
		'
		'
		'
		Me.ListImport.Border.Class = "ListViewBorder"
		Me.ListImport.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.ListImport.DisabledBackColor = System.Drawing.Color.Empty
		Me.ListImport.Dock = System.Windows.Forms.DockStyle.Fill
		Me.ListImport.HideSelection = False
		Me.ListImport.Location = New System.Drawing.Point(0, 0)
		Me.ListImport.Name = "ListImport"
		Me.ListImport.Size = New System.Drawing.Size(755, 311)
		Me.ListImport.TabIndex = 1
		Me.ListImport.UseCompatibleStateImageBehavior = False
		Me.ListImport.View = System.Windows.Forms.View.Details
		'
		'Panel3
		'
		Me.Panel3.Controls.Add(Me.LabelX22)
		Me.Panel3.Controls.Add(Me.TidSubkel)
		Me.Panel3.Controls.Add(Me.CSubKel)
		Me.Panel3.Controls.Add(Me.ImportBtn)
		Me.Panel3.Controls.Add(Me.LabelX19)
		Me.Panel3.Controls.Add(Me.InputSheetName)
		Me.Panel3.Controls.Add(Me.TCari)
		Me.Panel3.Controls.Add(Me.CariExcel)
		Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel3.Location = New System.Drawing.Point(0, 0)
		Me.Panel3.Name = "Panel3"
		Me.Panel3.Size = New System.Drawing.Size(755, 95)
		Me.Panel3.TabIndex = 0
		'
		'CSubKel
		'
		Me.CSubKel.DisplayMember = "Text"
		Me.CSubKel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
		Me.CSubKel.FormattingEnabled = True
		Me.CSubKel.ItemHeight = 16
		Me.CSubKel.Location = New System.Drawing.Point(91, 61)
		Me.CSubKel.Name = "CSubKel"
		Me.CSubKel.Size = New System.Drawing.Size(197, 22)
		Me.CSubKel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
		Me.CSubKel.TabIndex = 9
		'
		'ImportBtn
		'
		Me.ImportBtn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
		Me.ImportBtn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
		Me.ImportBtn.Location = New System.Drawing.Point(531, 33)
		Me.ImportBtn.Name = "ImportBtn"
		Me.ImportBtn.Size = New System.Drawing.Size(176, 23)
		Me.ImportBtn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
		Me.ImportBtn.TabIndex = 8
		Me.ImportBtn.Text = "Masukkan Data"
		'
		'LabelX19
		'
		'
		'
		'
		Me.LabelX19.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.LabelX19.Location = New System.Drawing.Point(10, 34)
		Me.LabelX19.Name = "LabelX19"
		Me.LabelX19.Size = New System.Drawing.Size(75, 23)
		Me.LabelX19.TabIndex = 7
		Me.LabelX19.Text = "Nama Sheet"
		'
		'InputSheetName
		'
		'
		'
		'
		Me.InputSheetName.Border.Class = "TextBoxBorder"
		Me.InputSheetName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.InputSheetName.Location = New System.Drawing.Point(91, 34)
		Me.InputSheetName.Name = "InputSheetName"
		Me.InputSheetName.PreventEnterBeep = True
		Me.InputSheetName.Size = New System.Drawing.Size(197, 21)
		Me.InputSheetName.TabIndex = 6
		Me.InputSheetName.Text = "Sheet1"
		'
		'TCari
		'
		'
		'
		'
		Me.TCari.Border.Class = "TextBoxBorder"
		Me.TCari.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.TCari.Location = New System.Drawing.Point(10, 7)
		Me.TCari.Name = "TCari"
		Me.TCari.PreventEnterBeep = True
		Me.TCari.Size = New System.Drawing.Size(634, 21)
		Me.TCari.TabIndex = 5
		'
		'CariExcel
		'
		Me.CariExcel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
		Me.CariExcel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
		Me.CariExcel.Location = New System.Drawing.Point(650, 7)
		Me.CariExcel.Name = "CariExcel"
		Me.CariExcel.Size = New System.Drawing.Size(57, 23)
		Me.CariExcel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
		Me.CariExcel.TabIndex = 4
		Me.CariExcel.Text = "Cari"
		'
		'SplitContainer1
		'
		Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
		Me.SplitContainer1.Name = "SplitContainer1"
		'
		'SplitContainer1.Panel1
		'
		Me.SplitContainer1.Panel1.Controls.Add(Me.NavKontrak)
		'
		'SplitContainer1.Panel2
		'
		Me.SplitContainer1.Panel2.Controls.Add(Me.BDaftarKontrak)
		Me.SplitContainer1.Panel2.Controls.Add(Me.BImport)
		Me.SplitContainer1.Panel2.Controls.Add(Me.BKeluar)
		Me.SplitContainer1.Panel2.Controls.Add(Me.BBatal)
		Me.SplitContainer1.Panel2.Controls.Add(Me.TambahKontrak)
		Me.SplitContainer1.Size = New System.Drawing.Size(980, 464)
		Me.SplitContainer1.SplitterDistance = 856
		Me.SplitContainer1.TabIndex = 1
		'
		'BDaftarKontrak
		'
		Me.BDaftarKontrak.ImageOptions.SvgImage = CType(resources.GetObject("BDaftarKontrak.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
		Me.BDaftarKontrak.Location = New System.Drawing.Point(8, 147)
		Me.BDaftarKontrak.Name = "BDaftarKontrak"
		Me.BDaftarKontrak.Size = New System.Drawing.Size(105, 41)
		Me.BDaftarKontrak.TabIndex = 4
		Me.BDaftarKontrak.Text = "Kontrak"
		'
		'BImport
		'
		Me.BImport.ImageOptions.SvgImage = CType(resources.GetObject("BImport.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
		Me.BImport.Location = New System.Drawing.Point(8, 283)
		Me.BImport.Name = "BImport"
		Me.BImport.Size = New System.Drawing.Size(105, 41)
		Me.BImport.TabIndex = 3
		Me.BImport.Text = "Import"
		'
		'BKeluar
		'
		Me.BKeluar.ImageOptions.SvgImage = CType(resources.GetObject("BKeluar.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
		Me.BKeluar.Location = New System.Drawing.Point(8, 344)
		Me.BKeluar.Name = "BKeluar"
		Me.BKeluar.Size = New System.Drawing.Size(105, 41)
		Me.BKeluar.TabIndex = 2
		Me.BKeluar.Text = "Keluar"
		'
		'BBatal
		'
		Me.BBatal.ImageOptions.SvgImage = CType(resources.GetObject("BBatal.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
		Me.BBatal.Location = New System.Drawing.Point(8, 62)
		Me.BBatal.Name = "BBatal"
		Me.BBatal.Size = New System.Drawing.Size(105, 41)
		Me.BBatal.TabIndex = 1
		Me.BBatal.Text = "Batal"
		'
		'TambahKontrak
		'
		Me.TambahKontrak.ImageOptions.SvgImage = CType(resources.GetObject("TambahKontrak.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
		Me.TambahKontrak.Location = New System.Drawing.Point(8, 12)
		Me.TambahKontrak.Name = "TambahKontrak"
		Me.TambahKontrak.Size = New System.Drawing.Size(105, 41)
		Me.TambahKontrak.TabIndex = 0
		Me.TambahKontrak.Text = "Tambah"
		'
		'OpenFileDialog1
		'
		Me.OpenFileDialog1.FileName = "OpenFileDialog1"
		'
		'TidSubkel
		'
		'
		'
		'
		Me.TidSubkel.Border.Class = "TextBoxBorder"
		Me.TidSubkel.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.TidSubkel.Location = New System.Drawing.Point(294, 61)
		Me.TidSubkel.Name = "TidSubkel"
		Me.TidSubkel.PreventEnterBeep = True
		Me.TidSubkel.Size = New System.Drawing.Size(29, 21)
		Me.TidSubkel.TabIndex = 10
		Me.TidSubkel.Visible = False
		'
		'LabelX22
		'
		'
		'
		'
		Me.LabelX22.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.LabelX22.Location = New System.Drawing.Point(10, 59)
		Me.LabelX22.Name = "LabelX22"
		Me.LabelX22.Size = New System.Drawing.Size(75, 23)
		Me.LabelX22.TabIndex = 11
		Me.LabelX22.Text = "Subkelompok"
		'
		'FrmKontrak
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(980, 464)
		Me.Controls.Add(Me.SplitContainer1)
		Me.Name = "FrmKontrak"
		Me.Text = "Kontrak"
		CType(Me.NavKontrak, System.ComponentModel.ISupportInitialize).EndInit()
		Me.NavKontrak.ResumeLayout(False)
		Me.NavDetailKontrak.ResumeLayout(False)
		Me.Panel2.ResumeLayout(False)
		Me.Panel1.ResumeLayout(False)
		Me.PDaftar.ResumeLayout(False)
		Me.NavImportKontrak.ResumeLayout(False)
		Me.Panel4.ResumeLayout(False)
		Me.Panel3.ResumeLayout(False)
		Me.SplitContainer1.Panel1.ResumeLayout(False)
		Me.SplitContainer1.Panel2.ResumeLayout(False)
		CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.SplitContainer1.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents NavKontrak As DevExpress.XtraBars.Navigation.NavigationPane
	Friend WithEvents NavDetailKontrak As DevExpress.XtraBars.Navigation.NavigationPage
	Friend WithEvents NavImportKontrak As DevExpress.XtraBars.Navigation.NavigationPage
	Friend WithEvents SplitContainer1 As SplitContainer
	Friend WithEvents BKeluar As DevExpress.XtraEditors.SimpleButton
	Friend WithEvents BBatal As DevExpress.XtraEditors.SimpleButton
	Friend WithEvents TambahKontrak As DevExpress.XtraEditors.SimpleButton
	Friend WithEvents Panel2 As Panel
	Friend WithEvents ListMaterial As ListView
	Friend WithEvents Panel1 As Panel
	Friend WithEvents TidKontrak As DevComponents.DotNetBar.Controls.TextBoxX
	Friend WithEvents LabelX16 As DevComponents.DotNetBar.LabelX
	Friend WithEvents BSimpanKontrak As DevExpress.XtraEditors.SimpleButton
	Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
	Friend WithEvents DTPrint As DateTimePicker
	Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
	Friend WithEvents LabelX17 As DevComponents.DotNetBar.LabelX
	Friend WithEvents TKlien As DevComponents.DotNetBar.Controls.TextBoxX
	Friend WithEvents LabelX18 As DevComponents.DotNetBar.LabelX
	Friend WithEvents TidKlien As DevComponents.DotNetBar.Controls.TextBoxX
	Friend WithEvents DTEnd As DateTimePicker
	Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
	Friend WithEvents DTStart As DateTimePicker
	Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
	Friend WithEvents DTKontrak As DateTimePicker
	Friend WithEvents TAlamat As DevComponents.DotNetBar.Controls.TextBoxX
	Friend WithEvents LabelX15 As DevComponents.DotNetBar.LabelX
	Friend WithEvents TidK As DevComponents.DotNetBar.Controls.TextBoxX
	Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
	Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
	Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
	Friend WithEvents LabelX14 As DevComponents.DotNetBar.LabelX
	Friend WithEvents TKota As DevComponents.DotNetBar.Controls.TextBoxX
	Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
	Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
	Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
	Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
	Friend WithEvents TNilaiKontrak As DevComponents.DotNetBar.Controls.TextBoxX
	Friend WithEvents TKontrak As DevComponents.DotNetBar.Controls.TextBoxX
	Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
	Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
	Friend WithEvents Panel4 As Panel
	Friend WithEvents ListImport As DevComponents.DotNetBar.Controls.ListViewEx
	Friend WithEvents Panel3 As Panel
	Friend WithEvents ImportBtn As DevComponents.DotNetBar.ButtonX
	Friend WithEvents LabelX19 As DevComponents.DotNetBar.LabelX
	Friend WithEvents InputSheetName As DevComponents.DotNetBar.Controls.TextBoxX
	Friend WithEvents TCari As DevComponents.DotNetBar.Controls.TextBoxX
	Friend WithEvents CariExcel As DevComponents.DotNetBar.ButtonX
	Friend WithEvents BImport As DevExpress.XtraEditors.SimpleButton
	Friend WithEvents PDaftar As Panel
	Friend WithEvents ListKontrak As DevComponents.DotNetBar.Controls.ListViewEx
	Friend WithEvents LabelX20 As DevComponents.DotNetBar.LabelX
	Friend WithEvents LabelX21 As DevComponents.DotNetBar.LabelX
	Friend WithEvents TCariKontrak As DevComponents.DotNetBar.Controls.TextBoxX
	Friend WithEvents BDaftarKontrak As DevExpress.XtraEditors.SimpleButton
	Friend WithEvents OpenFileDialog1 As OpenFileDialog
	Friend WithEvents BTutupKontrak As DevExpress.XtraEditors.SimpleButton
	Friend WithEvents CSubKel As DevComponents.DotNetBar.Controls.ComboBoxEx
	Friend WithEvents LabelX22 As DevComponents.DotNetBar.LabelX
	Friend WithEvents TidSubkel As DevComponents.DotNetBar.Controls.TextBoxX
End Class
