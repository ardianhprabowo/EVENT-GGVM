<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAccPengajuan
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmAccPengajuan))
		Me.Panel3 = New System.Windows.Forms.Panel()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.TIdDivisi = New System.Windows.Forms.TextBox()
		Me.TDivisi = New System.Windows.Forms.TextBox()
		Me.BtnDivisi = New System.Windows.Forms.Button()
		Me.PictureBox1 = New System.Windows.Forms.PictureBox()
		Me.ListMaju = New System.Windows.Forms.ListView()
		Me.GridDetail = New System.Windows.Forms.DataGridView()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.BtnKeluar = New System.Windows.Forms.Button()
		Me.BtnACC = New System.Windows.Forms.Button()
		Me.PanelSurvei = New System.Windows.Forms.Panel()
		Me.Plist = New System.Windows.Forms.ListView()
		Me.BtnTutupPanel = New System.Windows.Forms.Button()
		Me.LPanel = New System.Windows.Forms.Label()
		Me.TKeterangan = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
		Me.ButtonItem15 = New DevComponents.DotNetBar.ButtonItem()
		Me.ApplicationMenu1 = New DevExpress.XtraBars.Ribbon.ApplicationMenu(Me.components)
		Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
		Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
		Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
		Me.Bar1 = New DevExpress.XtraBars.Bar()
		Me.BAccPengajuan = New DevExpress.XtraBars.BarButtonItem()
		Me.BKeluar = New DevExpress.XtraBars.BarButtonItem()
		Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
		Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
		Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
		Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
		Me.Panel3.SuspendLayout()
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.GridDetail, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.PanelSurvei.SuspendLayout()
		CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SplitContainer1.Panel1.SuspendLayout()
		Me.SplitContainer1.Panel2.SuspendLayout()
		Me.SplitContainer1.SuspendLayout()
		CType(Me.ApplicationMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Panel3
		'
		Me.Panel3.BackColor = System.Drawing.Color.LightCoral
		Me.Panel3.Controls.Add(Me.Label1)
		Me.Panel3.Controls.Add(Me.TIdDivisi)
		Me.Panel3.Controls.Add(Me.TDivisi)
		Me.Panel3.Controls.Add(Me.BtnDivisi)
		Me.Panel3.Controls.Add(Me.PictureBox1)
		Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
		Me.Panel3.Location = New System.Drawing.Point(0, 0)
		Me.Panel3.Name = "Panel3"
		Me.Panel3.Size = New System.Drawing.Size(910, 74)
		Me.Panel3.TabIndex = 62
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.BackColor = System.Drawing.Color.LightCoral
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
		Me.Label1.Location = New System.Drawing.Point(326, 28)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(51, 16)
		Me.Label1.TabIndex = 65
		Me.Label1.Text = "DIVISI"
		Me.Label1.Visible = False
		'
		'TIdDivisi
		'
		Me.TIdDivisi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.TIdDivisi.Location = New System.Drawing.Point(711, 28)
		Me.TIdDivisi.Name = "TIdDivisi"
		Me.TIdDivisi.Size = New System.Drawing.Size(40, 21)
		Me.TIdDivisi.TabIndex = 64
		Me.TIdDivisi.Visible = False
		'
		'TDivisi
		'
		Me.TDivisi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.TDivisi.Location = New System.Drawing.Point(382, 27)
		Me.TDivisi.Name = "TDivisi"
		Me.TDivisi.Size = New System.Drawing.Size(249, 20)
		Me.TDivisi.TabIndex = 63
		Me.TDivisi.Visible = False
		'
		'BtnDivisi
		'
		Me.BtnDivisi.Cursor = System.Windows.Forms.Cursors.Hand
		Me.BtnDivisi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.BtnDivisi.Image = CType(resources.GetObject("BtnDivisi.Image"), System.Drawing.Image)
		Me.BtnDivisi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.BtnDivisi.Location = New System.Drawing.Point(637, 25)
		Me.BtnDivisi.Name = "BtnDivisi"
		Me.BtnDivisi.Size = New System.Drawing.Size(49, 26)
		Me.BtnDivisi.TabIndex = 0
		Me.BtnDivisi.Text = "- - -"
		Me.BtnDivisi.UseVisualStyleBackColor = True
		Me.BtnDivisi.Visible = False
		'
		'PictureBox1
		'
		Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
		Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
		Me.PictureBox1.Location = New System.Drawing.Point(801, 0)
		Me.PictureBox1.Name = "PictureBox1"
		Me.PictureBox1.Size = New System.Drawing.Size(109, 74)
		Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.PictureBox1.TabIndex = 70
		Me.PictureBox1.TabStop = False
		'
		'ListMaju
		'
		Me.ListMaju.Dock = System.Windows.Forms.DockStyle.Fill
		Me.ListMaju.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.ListMaju.GridLines = True
		Me.ListMaju.HideSelection = False
		Me.ListMaju.Location = New System.Drawing.Point(0, 74)
		Me.ListMaju.Name = "ListMaju"
		Me.ListMaju.Size = New System.Drawing.Size(910, 142)
		Me.ListMaju.TabIndex = 66
		Me.ListMaju.UseCompatibleStateImageBehavior = False
		'
		'GridDetail
		'
		Me.GridDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		Me.GridDetail.Dock = System.Windows.Forms.DockStyle.Fill
		Me.GridDetail.Location = New System.Drawing.Point(0, 13)
		Me.GridDetail.Name = "GridDetail"
		Me.GridDetail.ReadOnly = True
		Me.GridDetail.Size = New System.Drawing.Size(910, 117)
		Me.GridDetail.TabIndex = 71
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
		Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.Location = New System.Drawing.Point(0, 0)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(132, 13)
		Me.Label3.TabIndex = 70
		Me.Label3.Text = "URAIAN PENGAJUAN"
		'
		'BtnKeluar
		'
		Me.BtnKeluar.Cursor = System.Windows.Forms.Cursors.Hand
		Me.BtnKeluar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.BtnKeluar.Image = CType(resources.GetObject("BtnKeluar.Image"), System.Drawing.Image)
		Me.BtnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.BtnKeluar.Location = New System.Drawing.Point(923, 384)
		Me.BtnKeluar.Name = "BtnKeluar"
		Me.BtnKeluar.Size = New System.Drawing.Size(115, 47)
		Me.BtnKeluar.TabIndex = 73
		Me.BtnKeluar.Text = "KELUAR"
		Me.BtnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.BtnKeluar.UseVisualStyleBackColor = True
		'
		'BtnACC
		'
		Me.BtnACC.Cursor = System.Windows.Forms.Cursors.Hand
		Me.BtnACC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.BtnACC.Image = CType(resources.GetObject("BtnACC.Image"), System.Drawing.Image)
		Me.BtnACC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.BtnACC.Location = New System.Drawing.Point(923, 121)
		Me.BtnACC.Name = "BtnACC"
		Me.BtnACC.Size = New System.Drawing.Size(115, 47)
		Me.BtnACC.TabIndex = 72
		Me.BtnACC.Text = "ACC"
		Me.BtnACC.UseVisualStyleBackColor = True
		'
		'PanelSurvei
		'
		Me.PanelSurvei.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
		Me.PanelSurvei.Controls.Add(Me.Plist)
		Me.PanelSurvei.Controls.Add(Me.BtnTutupPanel)
		Me.PanelSurvei.Controls.Add(Me.LPanel)
		Me.PanelSurvei.Location = New System.Drawing.Point(404, 6)
		Me.PanelSurvei.Name = "PanelSurvei"
		Me.PanelSurvei.Size = New System.Drawing.Size(221, 236)
		Me.PanelSurvei.TabIndex = 75
		Me.PanelSurvei.Visible = False
		'
		'Plist
		'
		Me.Plist.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Plist.HideSelection = False
		Me.Plist.Location = New System.Drawing.Point(6, 8)
		Me.Plist.Name = "Plist"
		Me.Plist.Size = New System.Drawing.Size(209, 198)
		Me.Plist.TabIndex = 6
		Me.Plist.UseCompatibleStateImageBehavior = False
		'
		'BtnTutupPanel
		'
		Me.BtnTutupPanel.Cursor = System.Windows.Forms.Cursors.Hand
		Me.BtnTutupPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.BtnTutupPanel.Location = New System.Drawing.Point(4, 209)
		Me.BtnTutupPanel.Name = "BtnTutupPanel"
		Me.BtnTutupPanel.Size = New System.Drawing.Size(213, 23)
		Me.BtnTutupPanel.TabIndex = 3
		Me.BtnTutupPanel.Text = "Tutup"
		Me.BtnTutupPanel.UseVisualStyleBackColor = True
		'
		'LPanel
		'
		Me.LPanel.AutoSize = True
		Me.LPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LPanel.Location = New System.Drawing.Point(14, 3)
		Me.LPanel.Name = "LPanel"
		Me.LPanel.Size = New System.Drawing.Size(0, 18)
		Me.LPanel.TabIndex = 2
		'
		'TKeterangan
		'
		Me.TKeterangan.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.TKeterangan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.TKeterangan.Location = New System.Drawing.Point(0, 229)
		Me.TKeterangan.Name = "TKeterangan"
		Me.TKeterangan.ReadOnly = True
		Me.TKeterangan.Size = New System.Drawing.Size(910, 20)
		Me.TKeterangan.TabIndex = 102
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label2.ForeColor = System.Drawing.Color.Black
		Me.Label2.Location = New System.Drawing.Point(0, 216)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(169, 13)
		Me.Label2.TabIndex = 101
		Me.Label2.Text = "KETERANGAN PENGAJUAN"
		'
		'SplitContainer1
		'
		Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.SplitContainer1.Location = New System.Drawing.Point(0, 26)
		Me.SplitContainer1.Name = "SplitContainer1"
		Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
		'
		'SplitContainer1.Panel1
		'
		Me.SplitContainer1.Panel1.Controls.Add(Me.PanelSurvei)
		Me.SplitContainer1.Panel1.Controls.Add(Me.ListMaju)
		Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
		Me.SplitContainer1.Panel1.Controls.Add(Me.TKeterangan)
		Me.SplitContainer1.Panel1.Controls.Add(Me.Panel3)
		'
		'SplitContainer1.Panel2
		'
		Me.SplitContainer1.Panel2.Controls.Add(Me.GridDetail)
		Me.SplitContainer1.Panel2.Controls.Add(Me.Label3)
		Me.SplitContainer1.Panel2.Controls.Add(Me.BtnKeluar)
		Me.SplitContainer1.Size = New System.Drawing.Size(910, 383)
		Me.SplitContainer1.SplitterDistance = 249
		Me.SplitContainer1.TabIndex = 71
		'
		'ButtonItem15
		'
		Me.ButtonItem15.Name = "ButtonItem15"
		Me.ButtonItem15.Text = "ButtonItem15"
		'
		'ApplicationMenu1
		'
		Me.ApplicationMenu1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem2)})
		Me.ApplicationMenu1.Name = "ApplicationMenu1"
		'
		'BarButtonItem1
		'
		Me.BarButtonItem1.Caption = "ACC"
		Me.BarButtonItem1.Id = 0
		Me.BarButtonItem1.Name = "BarButtonItem1"
		'
		'BarButtonItem2
		'
		Me.BarButtonItem2.Caption = "KELUAR"
		Me.BarButtonItem2.Id = 1
		Me.BarButtonItem2.Name = "BarButtonItem2"
		'
		'BarManager1
		'
		Me.BarManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() {Me.Bar1})
		Me.BarManager1.DockControls.Add(Me.barDockControlTop)
		Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
		Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
		Me.BarManager1.DockControls.Add(Me.barDockControlRight)
		Me.BarManager1.Form = Me
		Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarButtonItem1, Me.BarButtonItem2, Me.BAccPengajuan, Me.BKeluar})
		Me.BarManager1.MainMenu = Me.Bar1
		Me.BarManager1.MaxItemId = 4
		'
		'Bar1
		'
		Me.Bar1.BarName = "Custom 2"
		Me.Bar1.DockCol = 0
		Me.Bar1.DockRow = 0
		Me.Bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
		Me.Bar1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BAccPengajuan), New DevExpress.XtraBars.LinkPersistInfo(Me.BKeluar)})
		Me.Bar1.OptionsBar.MultiLine = True
		Me.Bar1.OptionsBar.UseWholeRow = True
		Me.Bar1.Text = "Custom 2"
		'
		'BAccPengajuan
		'
		Me.BAccPengajuan.Caption = "ACC"
		Me.BAccPengajuan.Hint = "ACC"
		Me.BAccPengajuan.Id = 2
		Me.BAccPengajuan.ImageOptions.SvgImage = CType(resources.GetObject("BarButtonItem3.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
		Me.BAccPengajuan.Name = "BAccPengajuan"
		Me.BAccPengajuan.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
		'
		'BKeluar
		'
		Me.BKeluar.Caption = "KELUAR"
		Me.BKeluar.Id = 3
		Me.BKeluar.ImageOptions.SvgImage = CType(resources.GetObject("BKeluar.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
		Me.BKeluar.Name = "BKeluar"
		Me.BKeluar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
		'
		'barDockControlTop
		'
		Me.barDockControlTop.CausesValidation = False
		Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
		Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
		Me.barDockControlTop.Manager = Me.BarManager1
		Me.barDockControlTop.Size = New System.Drawing.Size(910, 26)
		'
		'barDockControlBottom
		'
		Me.barDockControlBottom.CausesValidation = False
		Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.barDockControlBottom.Location = New System.Drawing.Point(0, 409)
		Me.barDockControlBottom.Manager = Me.BarManager1
		Me.barDockControlBottom.Size = New System.Drawing.Size(910, 0)
		'
		'barDockControlLeft
		'
		Me.barDockControlLeft.CausesValidation = False
		Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
		Me.barDockControlLeft.Location = New System.Drawing.Point(0, 26)
		Me.barDockControlLeft.Manager = Me.BarManager1
		Me.barDockControlLeft.Size = New System.Drawing.Size(0, 383)
		'
		'barDockControlRight
		'
		Me.barDockControlRight.CausesValidation = False
		Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
		Me.barDockControlRight.Location = New System.Drawing.Point(910, 26)
		Me.barDockControlRight.Manager = Me.BarManager1
		Me.barDockControlRight.Size = New System.Drawing.Size(0, 383)
		'
		'FrmAccPengajuan
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(910, 409)
		Me.ControlBox = False
		Me.Controls.Add(Me.SplitContainer1)
		Me.Controls.Add(Me.BtnACC)
		Me.Controls.Add(Me.barDockControlLeft)
		Me.Controls.Add(Me.barDockControlRight)
		Me.Controls.Add(Me.barDockControlBottom)
		Me.Controls.Add(Me.barDockControlTop)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
		Me.Name = "FrmAccPengajuan"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "ACC PENGAJUAN"
		Me.Panel3.ResumeLayout(False)
		Me.Panel3.PerformLayout()
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.GridDetail, System.ComponentModel.ISupportInitialize).EndInit()
		Me.PanelSurvei.ResumeLayout(False)
		Me.PanelSurvei.PerformLayout()
		Me.SplitContainer1.Panel1.ResumeLayout(False)
		Me.SplitContainer1.Panel1.PerformLayout()
		Me.SplitContainer1.Panel2.ResumeLayout(False)
		Me.SplitContainer1.Panel2.PerformLayout()
		CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.SplitContainer1.ResumeLayout(False)
		CType(Me.ApplicationMenu1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
	Friend WithEvents Panel3 As System.Windows.Forms.Panel
	Friend WithEvents ListMaju As System.Windows.Forms.ListView
	Friend WithEvents GridDetail As System.Windows.Forms.DataGridView
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents BtnKeluar As System.Windows.Forms.Button
	Friend WithEvents BtnACC As System.Windows.Forms.Button
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents TIdDivisi As System.Windows.Forms.TextBox
	Friend WithEvents TDivisi As System.Windows.Forms.TextBox
	Friend WithEvents BtnDivisi As System.Windows.Forms.Button
	Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
	Friend WithEvents PanelSurvei As System.Windows.Forms.Panel
	Friend WithEvents BtnTutupPanel As System.Windows.Forms.Button
	Friend WithEvents LPanel As System.Windows.Forms.Label
	Friend WithEvents Plist As System.Windows.Forms.ListView
	Friend WithEvents TKeterangan As System.Windows.Forms.TextBox
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents SplitContainer1 As SplitContainer
	Friend WithEvents ButtonItem15 As DevComponents.DotNetBar.ButtonItem
	Friend WithEvents ApplicationMenu1 As DevExpress.XtraBars.Ribbon.ApplicationMenu
	Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
	Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
	Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
	Friend WithEvents Bar1 As DevExpress.XtraBars.Bar
	Friend WithEvents BAccPengajuan As DevExpress.XtraBars.BarButtonItem
	Friend WithEvents BKeluar As DevExpress.XtraBars.BarButtonItem
	Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
	Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
	Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
	Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
End Class
