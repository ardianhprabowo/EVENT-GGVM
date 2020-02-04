<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTampilAllPengajuan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTampilAllPengajuan))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ListMaju = New System.Windows.Forms.ListView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TKeterangan = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GridDetail = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnKeluar = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnGambar = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnRefresh = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnEdit = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnCetak = New DevExpress.XtraEditors.SimpleButton()
        Me.BtnEntry = New DevExpress.XtraEditors.SimpleButton()
        Me.PGambar = New System.Windows.Forms.Panel()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TNoPengajuan = New System.Windows.Forms.TextBox()
        Me.BtnTampil = New System.Windows.Forms.Button()
        Me.TIdPengajuan = New System.Windows.Forms.TextBox()
        Me.BtnSimpanI = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnUpload = New System.Windows.Forms.Button()
        Me.RibbonPage3 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.GridDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.PGambar.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.SplitContainer1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1061, 520)
        Me.Panel1.TabIndex = 0
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 29)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ListMaju)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel3)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GridDetail)
        Me.SplitContainer1.Size = New System.Drawing.Size(1061, 491)
        Me.SplitContainer1.SplitterDistance = 281
        Me.SplitContainer1.TabIndex = 1
        '
        'ListMaju
        '
        Me.ListMaju.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListMaju.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListMaju.GridLines = True
        Me.ListMaju.HideSelection = False
        Me.ListMaju.Location = New System.Drawing.Point(0, 0)
        Me.ListMaju.Name = "ListMaju"
        Me.ListMaju.Size = New System.Drawing.Size(1061, 236)
        Me.ListMaju.TabIndex = 66
        Me.ListMaju.UseCompatibleStateImageBehavior = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.TKeterangan)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 236)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1061, 45)
        Me.Panel3.TabIndex = 0
        '
        'TKeterangan
        '
        Me.TKeterangan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKeterangan.Location = New System.Drawing.Point(192, 19)
        Me.TKeterangan.Name = "TKeterangan"
        Me.TKeterangan.ReadOnly = True
        Me.TKeterangan.Size = New System.Drawing.Size(711, 20)
        Me.TKeterangan.TabIndex = 101
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(169, 13)
        Me.Label2.TabIndex = 100
        Me.Label2.Text = "KETERANGAN PENGAJUAN"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(132, 13)
        Me.Label3.TabIndex = 99
        Me.Label3.Text = "URAIAN PENGAJUAN"
        '
        'GridDetail
        '
        Me.GridDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridDetail.Location = New System.Drawing.Point(0, 0)
        Me.GridDetail.Name = "GridDetail"
        Me.GridDetail.ReadOnly = True
        Me.GridDetail.Size = New System.Drawing.Size(1061, 206)
        Me.GridDetail.TabIndex = 70
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Panel2.Controls.Add(Me.BtnKeluar)
        Me.Panel2.Controls.Add(Me.BtnGambar)
        Me.Panel2.Controls.Add(Me.BtnRefresh)
        Me.Panel2.Controls.Add(Me.BtnEdit)
        Me.Panel2.Controls.Add(Me.BtnCetak)
        Me.Panel2.Controls.Add(Me.BtnEntry)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1061, 29)
        Me.Panel2.TabIndex = 0
        '
        'BtnKeluar
        '
        Me.BtnKeluar.ImageOptions.SvgImage = CType(resources.GetObject("BtnKeluar.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BtnKeluar.ImageOptions.SvgImageSize = New System.Drawing.Size(20, 20)
        Me.BtnKeluar.Location = New System.Drawing.Point(525, 3)
        Me.BtnKeluar.Name = "BtnKeluar"
        Me.BtnKeluar.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[True]
        Me.BtnKeluar.Size = New System.Drawing.Size(75, 23)
        Me.BtnKeluar.TabIndex = 5
        Me.BtnKeluar.Text = "Keluar"
        '
        'BtnGambar
        '
        Me.BtnGambar.ImageOptions.SvgImage = CType(resources.GetObject("BtnGambar.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BtnGambar.ImageOptions.SvgImageSize = New System.Drawing.Size(20, 20)
        Me.BtnGambar.Location = New System.Drawing.Point(259, 3)
        Me.BtnGambar.Name = "BtnGambar"
        Me.BtnGambar.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[True]
        Me.BtnGambar.Size = New System.Drawing.Size(75, 23)
        Me.BtnGambar.TabIndex = 4
        Me.BtnGambar.Text = "Picture"
        '
        'BtnRefresh
        '
        Me.BtnRefresh.ImageOptions.SvgImage = CType(resources.GetObject("BtnRefresh.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BtnRefresh.ImageOptions.SvgImageSize = New System.Drawing.Size(20, 20)
        Me.BtnRefresh.Location = New System.Drawing.Point(340, 3)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[True]
        Me.BtnRefresh.Size = New System.Drawing.Size(75, 23)
        Me.BtnRefresh.TabIndex = 3
        Me.BtnRefresh.Text = "Refresh"
        '
        'BtnEdit
        '
        Me.BtnEdit.ImageOptions.SvgImage = CType(resources.GetObject("BtnEdit.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BtnEdit.ImageOptions.SvgImageSize = New System.Drawing.Size(20, 20)
        Me.BtnEdit.Location = New System.Drawing.Point(97, 3)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[True]
        Me.BtnEdit.Size = New System.Drawing.Size(75, 23)
        Me.BtnEdit.TabIndex = 2
        Me.BtnEdit.Text = "Edit"
        '
        'BtnCetak
        '
        Me.BtnCetak.ImageOptions.SvgImage = CType(resources.GetObject("BtnCetak.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BtnCetak.ImageOptions.SvgImageSize = New System.Drawing.Size(20, 20)
        Me.BtnCetak.Location = New System.Drawing.Point(178, 3)
        Me.BtnCetak.Name = "BtnCetak"
        Me.BtnCetak.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[True]
        Me.BtnCetak.Size = New System.Drawing.Size(75, 23)
        Me.BtnCetak.TabIndex = 1
        Me.BtnCetak.Text = "Cetak"
        '
        'BtnEntry
        '
        Me.BtnEntry.ImageOptions.SvgImage = CType(resources.GetObject("BtnEntry.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
        Me.BtnEntry.ImageOptions.SvgImageSize = New System.Drawing.Size(20, 20)
        Me.BtnEntry.Location = New System.Drawing.Point(12, 3)
        Me.BtnEntry.Name = "BtnEntry"
        Me.BtnEntry.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.[True]
        Me.BtnEntry.Size = New System.Drawing.Size(75, 23)
        Me.BtnEntry.TabIndex = 0
        Me.BtnEntry.Text = "Entry"
        '
        'PGambar
        '
        Me.PGambar.BackColor = System.Drawing.Color.Khaki
        Me.PGambar.Controls.Add(Me.TextBox3)
        Me.PGambar.Controls.Add(Me.TextBox2)
        Me.PGambar.Controls.Add(Me.Button1)
        Me.PGambar.Controls.Add(Me.Label6)
        Me.PGambar.Controls.Add(Me.Label5)
        Me.PGambar.Controls.Add(Me.Label1)
        Me.PGambar.Controls.Add(Me.TNoPengajuan)
        Me.PGambar.Controls.Add(Me.BtnTampil)
        Me.PGambar.Controls.Add(Me.TIdPengajuan)
        Me.PGambar.Controls.Add(Me.BtnSimpanI)
        Me.PGambar.Controls.Add(Me.Label4)
        Me.PGambar.Controls.Add(Me.TextBox1)
        Me.PGambar.Controls.Add(Me.PictureBox1)
        Me.PGambar.Controls.Add(Me.BtnUpload)
        Me.PGambar.Location = New System.Drawing.Point(69, 74)
        Me.PGambar.Name = "PGambar"
        Me.PGambar.Size = New System.Drawing.Size(922, 372)
        Me.PGambar.TabIndex = 104
        Me.PGambar.Visible = False
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(620, 82)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(266, 21)
        Me.TextBox3.TabIndex = 114
        Me.TextBox3.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(620, 59)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(266, 21)
        Me.TextBox2.TabIndex = 113
        Me.TextBox2.Visible = False
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(742, 283)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(115, 47)
        Me.Button1.TabIndex = 112
        Me.Button1.Text = "KELUAR"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(438, 207)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 13)
        Me.Label6.TabIndex = 111
        Me.Label6.Text = "LOKASI :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(438, 156)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 110
        Me.Label5.Text = "NAMA FILE :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(438, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 13)
        Me.Label1.TabIndex = 106
        Me.Label1.Text = "NO.PENGAJUAN"
        '
        'TNoPengajuan
        '
        Me.TNoPengajuan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNoPengajuan.Location = New System.Drawing.Point(441, 120)
        Me.TNoPengajuan.Name = "TNoPengajuan"
        Me.TNoPengajuan.Size = New System.Drawing.Size(184, 20)
        Me.TNoPengajuan.TabIndex = 109
        '
        'BtnTampil
        '
        Me.BtnTampil.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnTampil.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTampil.Image = CType(resources.GetObject("BtnTampil.Image"), System.Drawing.Image)
        Me.BtnTampil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnTampil.Location = New System.Drawing.Point(771, 108)
        Me.BtnTampil.Name = "BtnTampil"
        Me.BtnTampil.Size = New System.Drawing.Size(115, 47)
        Me.BtnTampil.TabIndex = 108
        Me.BtnTampil.Text = "TAMPIL"
        Me.BtnTampil.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnTampil.UseVisualStyleBackColor = True
        Me.BtnTampil.Visible = False
        '
        'TIdPengajuan
        '
        Me.TIdPengajuan.Location = New System.Drawing.Point(652, 33)
        Me.TIdPengajuan.Name = "TIdPengajuan"
        Me.TIdPengajuan.Size = New System.Drawing.Size(124, 21)
        Me.TIdPengajuan.TabIndex = 107
        Me.TIdPengajuan.Visible = False
        '
        'BtnSimpanI
        '
        Me.BtnSimpanI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSimpanI.Enabled = False
        Me.BtnSimpanI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSimpanI.Image = CType(resources.GetObject("BtnSimpanI.Image"), System.Drawing.Image)
        Me.BtnSimpanI.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSimpanI.Location = New System.Drawing.Point(441, 271)
        Me.BtnSimpanI.Name = "BtnSimpanI"
        Me.BtnSimpanI.Size = New System.Drawing.Size(138, 47)
        Me.BtnSimpanI.TabIndex = 106
        Me.BtnSimpanI.Text = "SIMPAN PIC"
        Me.BtnSimpanI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSimpanI.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(438, 233)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 105
        Me.Label4.Text = "Label4"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(441, 172)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(433, 20)
        Me.TextBox1.TabIndex = 104
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(48, 19)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(368, 321)
        Me.PictureBox1.TabIndex = 103
        Me.PictureBox1.TabStop = False
        '
        'BtnUpload
        '
        Me.BtnUpload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnUpload.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpload.Image = CType(resources.GetObject("BtnUpload.Image"), System.Drawing.Image)
        Me.BtnUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnUpload.Location = New System.Drawing.Point(441, 19)
        Me.BtnUpload.Name = "BtnUpload"
        Me.BtnUpload.Size = New System.Drawing.Size(115, 47)
        Me.BtnUpload.TabIndex = 102
        Me.BtnUpload.Text = "UPLOAD"
        Me.BtnUpload.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnUpload.UseVisualStyleBackColor = True
        '
        'RibbonPage3
        '
        Me.RibbonPage3.Name = "RibbonPage3"
        Me.RibbonPage3.Text = "RibbonPage3"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'FrmTampilAllPengajuan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1061, 520)
        Me.Controls.Add(Me.PGambar)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FrmTampilAllPengajuan"
        Me.Text = "Pengajuan"
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.GridDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.PGambar.ResumeLayout(False)
        Me.PGambar.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ListMaju As ListView
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TKeterangan As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GridDetail As DataGridView
    Friend WithEvents BtnKeluar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnGambar As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnRefresh As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnEdit As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnCetak As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BtnEntry As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents PGambar As Panel
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TNoPengajuan As TextBox
    Friend WithEvents BtnTampil As Button
    Friend WithEvents TIdPengajuan As TextBox
    Friend WithEvents BtnSimpanI As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BtnUpload As Button
    Friend WithEvents RibbonPage3 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
