<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImportBarang
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
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImportBarang))
		Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
		Me.BtnCari = New DevExpress.XtraEditors.SimpleButton()
		Me.TLokasiExcel = New DevComponents.DotNetBar.Controls.TextBoxX()
		Me.GroupBox1 = New System.Windows.Forms.GroupBox()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.BtnKeluar = New DevExpress.XtraEditors.SimpleButton()
		Me.BtnBatal = New DevExpress.XtraEditors.SimpleButton()
		Me.BtnImport = New DevExpress.XtraEditors.SimpleButton()
		Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
		Me.DataGridView1 = New System.Windows.Forms.DataGridView()
		Me.BtnContoh = New DevExpress.XtraEditors.SimpleButton()
		CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SplitContainer1.Panel1.SuspendLayout()
		Me.SplitContainer1.Panel2.SuspendLayout()
		Me.SplitContainer1.SuspendLayout()
		Me.GroupBox1.SuspendLayout()
		Me.Panel1.SuspendLayout()
		CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'SplitContainer1
		'
		Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
		Me.SplitContainer1.Name = "SplitContainer1"
		Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
		'
		'SplitContainer1.Panel1
		'
		Me.SplitContainer1.Panel1.Controls.Add(Me.BtnContoh)
		Me.SplitContainer1.Panel1.Controls.Add(Me.BtnCari)
		Me.SplitContainer1.Panel1.Controls.Add(Me.TLokasiExcel)
		'
		'SplitContainer1.Panel2
		'
		Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox1)
		Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
		Me.SplitContainer1.Size = New System.Drawing.Size(803, 324)
		Me.SplitContainer1.SplitterDistance = 43
		Me.SplitContainer1.TabIndex = 0
		'
		'BtnCari
		'
		Me.BtnCari.ImageOptions.SvgImage = CType(resources.GetObject("BtnCari.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
		Me.BtnCari.ImageOptions.SvgImageSize = New System.Drawing.Size(25, 25)
		Me.BtnCari.Location = New System.Drawing.Point(352, 9)
		Me.BtnCari.Name = "BtnCari"
		Me.BtnCari.Size = New System.Drawing.Size(108, 23)
		Me.BtnCari.TabIndex = 1
		Me.BtnCari.Text = "Browse"
		'
		'TLokasiExcel
		'
		'
		'
		'
		Me.TLokasiExcel.Border.Class = "TextBoxBorder"
		Me.TLokasiExcel.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
		Me.TLokasiExcel.Location = New System.Drawing.Point(12, 12)
		Me.TLokasiExcel.Name = "TLokasiExcel"
		Me.TLokasiExcel.PreventEnterBeep = True
		Me.TLokasiExcel.Size = New System.Drawing.Size(324, 21)
		Me.TLokasiExcel.TabIndex = 0
		'
		'GroupBox1
		'
		Me.GroupBox1.Controls.Add(Me.DataGridView1)
		Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
		Me.GroupBox1.Name = "GroupBox1"
		Me.GroupBox1.Size = New System.Drawing.Size(803, 240)
		Me.GroupBox1.TabIndex = 0
		Me.GroupBox1.TabStop = False
		Me.GroupBox1.Text = "Data Excel"
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.BtnKeluar)
		Me.Panel1.Controls.Add(Me.BtnBatal)
		Me.Panel1.Controls.Add(Me.BtnImport)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Panel1.Location = New System.Drawing.Point(0, 240)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(803, 37)
		Me.Panel1.TabIndex = 1
		'
		'BtnKeluar
		'
		Me.BtnKeluar.ImageOptions.SvgImage = CType(resources.GetObject("BtnKeluar.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
		Me.BtnKeluar.ImageOptions.SvgImageSize = New System.Drawing.Size(25, 25)
		Me.BtnKeluar.Location = New System.Drawing.Point(715, 6)
		Me.BtnKeluar.Name = "BtnKeluar"
		Me.BtnKeluar.Size = New System.Drawing.Size(75, 23)
		Me.BtnKeluar.TabIndex = 2
		Me.BtnKeluar.Text = "Keluar"
		'
		'BtnBatal
		'
		Me.BtnBatal.ImageOptions.SvgImage = CType(resources.GetObject("BtnBatal.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
		Me.BtnBatal.ImageOptions.SvgImageSize = New System.Drawing.Size(25, 25)
		Me.BtnBatal.Location = New System.Drawing.Point(621, 7)
		Me.BtnBatal.Name = "BtnBatal"
		Me.BtnBatal.Size = New System.Drawing.Size(75, 23)
		Me.BtnBatal.TabIndex = 1
		Me.BtnBatal.Text = "Batal"
		'
		'BtnImport
		'
		Me.BtnImport.ImageOptions.SvgImage = CType(resources.GetObject("BtnImport.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
		Me.BtnImport.ImageOptions.SvgImageSize = New System.Drawing.Size(25, 25)
		Me.BtnImport.Location = New System.Drawing.Point(523, 7)
		Me.BtnImport.Name = "BtnImport"
		Me.BtnImport.Size = New System.Drawing.Size(75, 23)
		Me.BtnImport.TabIndex = 0
		Me.BtnImport.Text = "Import"
		'
		'OpenFileDialog1
		'
		Me.OpenFileDialog1.FileName = "OpenFileDialog1"
		'
		'DataGridView1
		'
		Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.DataGridView1.Location = New System.Drawing.Point(3, 17)
		Me.DataGridView1.Name = "DataGridView1"
		Me.DataGridView1.Size = New System.Drawing.Size(797, 220)
		Me.DataGridView1.TabIndex = 1
		'
		'BtnContoh
		'
		Me.BtnContoh.ImageOptions.SvgImage = CType(resources.GetObject("SimpleButton1.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
		Me.BtnContoh.ImageOptions.SvgImageSize = New System.Drawing.Size(25, 25)
		Me.BtnContoh.Location = New System.Drawing.Point(480, 10)
		Me.BtnContoh.Name = "BtnContoh"
		Me.BtnContoh.Size = New System.Drawing.Size(108, 23)
		Me.BtnContoh.TabIndex = 2
		Me.BtnContoh.Text = "Contoh Format"
		'
		'ImportBarang
		'
		Me.ActiveGlowColor = System.Drawing.Color.Red
		Me.Appearance.BackColor = System.Drawing.Color.CornflowerBlue
		Me.Appearance.Options.UseBackColor = True
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(803, 324)
		Me.Controls.Add(Me.SplitContainer1)
		Me.Name = "ImportBarang"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Import Barang"
		Me.SplitContainer1.Panel1.ResumeLayout(False)
		Me.SplitContainer1.Panel2.ResumeLayout(False)
		CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.SplitContainer1.ResumeLayout(False)
		Me.GroupBox1.ResumeLayout(False)
		Me.Panel1.ResumeLayout(False)
		CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents SplitContainer1 As SplitContainer
	Friend WithEvents BtnCari As DevExpress.XtraEditors.SimpleButton
	Friend WithEvents TLokasiExcel As DevComponents.DotNetBar.Controls.TextBoxX
	Friend WithEvents GroupBox1 As GroupBox
	Friend WithEvents BtnKeluar As DevExpress.XtraEditors.SimpleButton
	Friend WithEvents BtnBatal As DevExpress.XtraEditors.SimpleButton
	Friend WithEvents BtnImport As DevExpress.XtraEditors.SimpleButton
	Friend WithEvents OpenFileDialog1 As OpenFileDialog
	Friend WithEvents DataGridView1 As DataGridView
	Friend WithEvents Panel1 As Panel
	Friend WithEvents BtnContoh As DevExpress.XtraEditors.SimpleButton
End Class
