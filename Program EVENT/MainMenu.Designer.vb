<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainMenu
    Inherits DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainMenu))
		Me.SSManager = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.Program_EVENT.FrmWait), True, True)
		Me.RepositoryItemHypertextLabel1 = New DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel()
		Me.FluentContainer = New DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer()
		Me.AccordionControl1 = New DevExpress.XtraBars.Navigation.AccordionControl()
		Me.M_Menu = New DevExpress.XtraBars.Navigation.AccordionControlElement()
		Me.M_Barang = New DevExpress.XtraBars.Navigation.AccordionControlElement()
		Me.M_Kontrak = New DevExpress.XtraBars.Navigation.AccordionControlElement()
		Me.M_Penawaran = New DevExpress.XtraBars.Navigation.AccordionControlElement()
		Me.Menu_Event = New DevExpress.XtraBars.Navigation.AccordionControlElement()
		Me.PE_OpsEvn = New DevExpress.XtraBars.Navigation.AccordionControlElement()
		Me.PE_BoothEvn = New DevExpress.XtraBars.Navigation.AccordionControlElement()
		Me.Menu_Exhibition = New DevExpress.XtraBars.Navigation.AccordionControlElement()
		Me.PE_RegExh = New DevExpress.XtraBars.Navigation.AccordionControlElement()
		Me.PE_PhotoExh = New DevExpress.XtraBars.Navigation.AccordionControlElement()
		Me.Menu_Activation = New DevExpress.XtraBars.Navigation.AccordionControlElement()
		Me.PE_EventAct = New DevExpress.XtraBars.Navigation.AccordionControlElement()
		Me.PE_ProjectAct = New DevExpress.XtraBars.Navigation.AccordionControlElement()
		Me.PE_InstoreAct = New DevExpress.XtraBars.Navigation.AccordionControlElement()
		Me.M_PO = New DevExpress.XtraBars.Navigation.AccordionControlElement()
		Me.M_MintaPO = New DevExpress.XtraBars.Navigation.AccordionControlElement()
		Me.M_Pengajuan = New DevExpress.XtraBars.Navigation.AccordionControlElement()
		Me.P_Pengajuan = New DevExpress.XtraBars.Navigation.AccordionControlElement()
		Me.P_Purchasing = New DevExpress.XtraBars.Navigation.AccordionControlElement()
		Me.P_Paketing = New DevExpress.XtraBars.Navigation.AccordionControlElement()
		Me.P_Activation = New DevExpress.XtraBars.Navigation.AccordionControlElement()
		Me.Acc_Pengajuan = New DevExpress.XtraBars.Navigation.AccordionControlElement()
		Me.H_Pengajuan = New DevExpress.XtraBars.Navigation.AccordionControlElement()
		Me.M_LPJ = New DevExpress.XtraBars.Navigation.AccordionControlElement()
		Me.B_LPJ = New DevExpress.XtraBars.Navigation.AccordionControlElement()
		Me.B_AccLPJ = New DevExpress.XtraBars.Navigation.AccordionControlElement()
		Me.B_HisLPJ = New DevExpress.XtraBars.Navigation.AccordionControlElement()
		Me.M_Gudang = New DevExpress.XtraBars.Navigation.AccordionControlElement()
		Me.P_Gudang = New DevExpress.XtraBars.Navigation.AccordionControlElement()
		Me.BtnExit = New DevExpress.XtraBars.Navigation.AccordionControlElement()
		Me.FluentDesignFormControl1 = New DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl()
		Me.LoginUser = New DevExpress.XtraBars.BarStaticItem()
		Me.BarStaticItem2 = New DevExpress.XtraBars.BarStaticItem()
		Me.NmDiv = New DevExpress.XtraBars.BarStaticItem()
		Me.BarStaticItem4 = New DevExpress.XtraBars.BarStaticItem()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
		CType(Me.RepositoryItemHypertextLabel1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.AccordionControl1, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.FluentDesignFormControl1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel1.SuspendLayout()
		Me.SuspendLayout()
		'
		'SSManager
		'
		Me.SSManager.ClosingDelay = 500
		'
		'RepositoryItemHypertextLabel1
		'
		Me.RepositoryItemHypertextLabel1.Name = "RepositoryItemHypertextLabel1"
		'
		'FluentContainer
		'
		Me.FluentContainer.Dock = System.Windows.Forms.DockStyle.Fill
		Me.FluentContainer.Location = New System.Drawing.Point(163, 47)
		Me.FluentContainer.Margin = New System.Windows.Forms.Padding(2)
		Me.FluentContainer.Name = "FluentContainer"
		Me.FluentContainer.Size = New System.Drawing.Size(504, 483)
		Me.FluentContainer.TabIndex = 0
		'
		'AccordionControl1
		'
		Me.AccordionControl1.Dock = System.Windows.Forms.DockStyle.Left
		Me.AccordionControl1.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.M_Menu, Me.M_Penawaran, Me.M_PO, Me.M_Pengajuan, Me.M_LPJ, Me.M_Gudang, Me.BtnExit})
		Me.AccordionControl1.Location = New System.Drawing.Point(0, 47)
		Me.AccordionControl1.Margin = New System.Windows.Forms.Padding(2)
		Me.AccordionControl1.Name = "AccordionControl1"
		Me.AccordionControl1.OptionsMinimizing.AllowMinimizeMode = DevExpress.Utils.DefaultBoolean.[True]
		Me.AccordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch
		Me.AccordionControl1.Size = New System.Drawing.Size(163, 483)
		Me.AccordionControl1.TabIndex = 1
		Me.AccordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu
		'
		'M_Menu
		'
		Me.M_Menu.Appearance.Disabled.BackColor = System.Drawing.Color.Lime
		Me.M_Menu.Appearance.Disabled.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.M_Menu.Appearance.Disabled.ForeColor = System.Drawing.Color.White
		Me.M_Menu.Appearance.Disabled.Options.UseBackColor = True
		Me.M_Menu.Appearance.Disabled.Options.UseFont = True
		Me.M_Menu.Appearance.Disabled.Options.UseForeColor = True
		Me.M_Menu.Appearance.Normal.BackColor = System.Drawing.Color.Transparent
		Me.M_Menu.Appearance.Normal.BackColor2 = System.Drawing.Color.White
		Me.M_Menu.Appearance.Normal.Options.UseBackColor = True
		Me.M_Menu.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.M_Barang, Me.M_Kontrak})
		Me.M_Menu.Expanded = True
		Me.M_Menu.ImageOptions.Image = CType(resources.GetObject("M_Menu.ImageOptions.Image"), System.Drawing.Image)
		Me.M_Menu.Name = "M_Menu"
		Me.M_Menu.Text = "MASTER"
		'
		'M_Barang
		'
		Me.M_Barang.Expanded = True
		Me.M_Barang.ImageOptions.SvgImage = CType(resources.GetObject("M_Barang.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
		Me.M_Barang.Name = "M_Barang"
		Me.M_Barang.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
		Me.M_Barang.Text = "Barang"
		'
		'M_Kontrak
		'
		Me.M_Kontrak.ImageOptions.SvgImage = CType(resources.GetObject("M_Kontrak.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
		Me.M_Kontrak.Name = "M_Kontrak"
		Me.M_Kontrak.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
		Me.M_Kontrak.Text = "Kontrak"
		'
		'M_Penawaran
		'
		Me.M_Penawaran.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.Menu_Event, Me.Menu_Exhibition, Me.Menu_Activation})
		Me.M_Penawaran.Expanded = True
		Me.M_Penawaran.ImageOptions.Image = CType(resources.GetObject("M_Penawaran.ImageOptions.Image"), System.Drawing.Image)
		Me.M_Penawaran.Name = "M_Penawaran"
		Me.M_Penawaran.Text = "PENAWARAN"
		'
		'Menu_Event
		'
		Me.Menu_Event.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.PE_OpsEvn, Me.PE_BoothEvn})
		Me.Menu_Event.Enabled = False
		Me.Menu_Event.Name = "Menu_Event"
		Me.Menu_Event.Text = "EVENT"
		'
		'PE_OpsEvn
		'
		Me.PE_OpsEvn.Name = "PE_OpsEvn"
		Me.PE_OpsEvn.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
		Me.PE_OpsEvn.Text = "Operasional"
		'
		'PE_BoothEvn
		'
		Me.PE_BoothEvn.Name = "PE_BoothEvn"
		Me.PE_BoothEvn.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
		Me.PE_BoothEvn.Text = "Booth"
		'
		'Menu_Exhibition
		'
		Me.Menu_Exhibition.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.PE_RegExh, Me.PE_PhotoExh})
		Me.Menu_Exhibition.Enabled = False
		Me.Menu_Exhibition.Name = "Menu_Exhibition"
		Me.Menu_Exhibition.Text = "EXHIBITION"
		'
		'PE_RegExh
		'
		Me.PE_RegExh.Name = "PE_RegExh"
		Me.PE_RegExh.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
		Me.PE_RegExh.Text = "Reguler"
		'
		'PE_PhotoExh
		'
		Me.PE_PhotoExh.Name = "PE_PhotoExh"
		Me.PE_PhotoExh.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
		Me.PE_PhotoExh.Text = "Photo Booth"
		'
		'Menu_Activation
		'
		Me.Menu_Activation.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.PE_EventAct, Me.PE_ProjectAct, Me.PE_InstoreAct})
		Me.Menu_Activation.Enabled = False
		Me.Menu_Activation.Name = "Menu_Activation"
		Me.Menu_Activation.Text = "ACTIVATION"
		'
		'PE_EventAct
		'
		Me.PE_EventAct.Name = "PE_EventAct"
		Me.PE_EventAct.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
		Me.PE_EventAct.Text = "Event"
		'
		'PE_ProjectAct
		'
		Me.PE_ProjectAct.Name = "PE_ProjectAct"
		Me.PE_ProjectAct.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
		Me.PE_ProjectAct.Text = "Project"
		'
		'PE_InstoreAct
		'
		Me.PE_InstoreAct.Name = "PE_InstoreAct"
		Me.PE_InstoreAct.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
		Me.PE_InstoreAct.Text = "In Store"
		'
		'M_PO
		'
		Me.M_PO.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.M_MintaPO})
		Me.M_PO.ImageOptions.Image = CType(resources.GetObject("M_PO.ImageOptions.Image"), System.Drawing.Image)
		Me.M_PO.Name = "M_PO"
		Me.M_PO.Text = "PURCHASE ORDER"
		'
		'M_MintaPO
		'
		Me.M_MintaPO.Name = "M_MintaPO"
		Me.M_MintaPO.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
		Me.M_MintaPO.Text = "Minta P.O"
		'
		'M_Pengajuan
		'
		Me.M_Pengajuan.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.P_Pengajuan, Me.P_Purchasing, Me.P_Paketing, Me.P_Activation, Me.Acc_Pengajuan, Me.H_Pengajuan})
		Me.M_Pengajuan.ImageOptions.Image = CType(resources.GetObject("M_Pengajuan.ImageOptions.Image"), System.Drawing.Image)
		Me.M_Pengajuan.Name = "M_Pengajuan"
		Me.M_Pengajuan.Text = "PENGAJUAN"
		'
		'P_Pengajuan
		'
		Me.P_Pengajuan.Name = "P_Pengajuan"
		Me.P_Pengajuan.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
		Me.P_Pengajuan.Text = "Pengajuan"
		'
		'P_Purchasing
		'
		Me.P_Purchasing.Name = "P_Purchasing"
		Me.P_Purchasing.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
		Me.P_Purchasing.Text = "Purchasing / Operasional"
		'
		'P_Paketing
		'
		Me.P_Paketing.Name = "P_Paketing"
		Me.P_Paketing.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
		Me.P_Paketing.Text = "Paketing"
		'
		'P_Activation
		'
		Me.P_Activation.Name = "P_Activation"
		Me.P_Activation.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
		Me.P_Activation.Text = "Activation"
		'
		'Acc_Pengajuan
		'
		Me.Acc_Pengajuan.Name = "Acc_Pengajuan"
		Me.Acc_Pengajuan.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
		Me.Acc_Pengajuan.Text = "ACC Pengajuan"
		'
		'H_Pengajuan
		'
		Me.H_Pengajuan.Name = "H_Pengajuan"
		Me.H_Pengajuan.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
		Me.H_Pengajuan.Text = "History Pengajuan"
		'
		'M_LPJ
		'
		Me.M_LPJ.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.B_LPJ, Me.B_AccLPJ, Me.B_HisLPJ})
		Me.M_LPJ.ImageOptions.Image = CType(resources.GetObject("M_LPJ.ImageOptions.Image"), System.Drawing.Image)
		Me.M_LPJ.Name = "M_LPJ"
		Me.M_LPJ.Text = "LAPORAN"
		'
		'B_LPJ
		'
		Me.B_LPJ.Name = "B_LPJ"
		Me.B_LPJ.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
		Me.B_LPJ.Text = "BUAT LPJ"
		'
		'B_AccLPJ
		'
		Me.B_AccLPJ.Name = "B_AccLPJ"
		Me.B_AccLPJ.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
		Me.B_AccLPJ.Text = "ACC LPJ"
		'
		'B_HisLPJ
		'
		Me.B_HisLPJ.Name = "B_HisLPJ"
		Me.B_HisLPJ.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
		Me.B_HisLPJ.Text = "History LPJ"
		'
		'M_Gudang
		'
		Me.M_Gudang.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.P_Gudang})
		Me.M_Gudang.ImageOptions.Image = CType(resources.GetObject("M_Gudang.ImageOptions.Image"), System.Drawing.Image)
		Me.M_Gudang.Name = "M_Gudang"
		Me.M_Gudang.Text = "GUDANG"
		'
		'P_Gudang
		'
		Me.P_Gudang.Name = "P_Gudang"
		Me.P_Gudang.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
		Me.P_Gudang.Text = "Permintaan Gudang"
		'
		'BtnExit
		'
		Me.BtnExit.ImageOptions.SvgImage = CType(resources.GetObject("BtnExit.ImageOptions.SvgImage"), DevExpress.Utils.Svg.SvgImage)
		Me.BtnExit.Name = "BtnExit"
		Me.BtnExit.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
		Me.BtnExit.Text = "Keluar"
		'
		'FluentDesignFormControl1
		'
		Me.FluentDesignFormControl1.FluentDesignForm = Me
		Me.FluentDesignFormControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.LoginUser, Me.BarStaticItem2, Me.NmDiv, Me.BarStaticItem4})
		Me.FluentDesignFormControl1.Location = New System.Drawing.Point(0, 0)
		Me.FluentDesignFormControl1.Margin = New System.Windows.Forms.Padding(2)
		Me.FluentDesignFormControl1.Name = "FluentDesignFormControl1"
		Me.FluentDesignFormControl1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemHypertextLabel1})
		Me.FluentDesignFormControl1.Size = New System.Drawing.Size(706, 47)
		Me.FluentDesignFormControl1.TabIndex = 2
		Me.FluentDesignFormControl1.TabStop = False
		Me.FluentDesignFormControl1.TitleItemLinks.Add(Me.LoginUser)
		Me.FluentDesignFormControl1.TitleItemLinks.Add(Me.BarStaticItem2)
		Me.FluentDesignFormControl1.TitleItemLinks.Add(Me.NmDiv)
		Me.FluentDesignFormControl1.TitleItemLinks.Add(Me.BarStaticItem4)
		'
		'LoginUser
		'
		Me.LoginUser.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
		Me.LoginUser.Caption = "user"
		Me.LoginUser.Id = 1
		Me.LoginUser.Name = "LoginUser"
		Me.LoginUser.RightIndent = 10
		'
		'BarStaticItem2
		'
		Me.BarStaticItem2.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
		Me.BarStaticItem2.Caption = "USER :"
		Me.BarStaticItem2.Id = 2
		Me.BarStaticItem2.Name = "BarStaticItem2"
		Me.BarStaticItem2.Size = New System.Drawing.Size(60, 0)
		Me.BarStaticItem2.Width = 60
		'
		'NmDiv
		'
		Me.NmDiv.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
		Me.NmDiv.Caption = "divisi"
		Me.NmDiv.Id = 3
		Me.NmDiv.Name = "NmDiv"
		'
		'BarStaticItem4
		'
		Me.BarStaticItem4.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right
		Me.BarStaticItem4.Caption = "DIVISI :"
		Me.BarStaticItem4.Id = 4
		Me.BarStaticItem4.Name = "BarStaticItem4"
		'
		'Panel1
		'
		Me.Panel1.Controls.Add(Me.Label1)
		Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
		Me.Panel1.Location = New System.Drawing.Point(667, 47)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(39, 483)
		Me.Panel1.TabIndex = 3
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
		Me.Label1.Font = New System.Drawing.Font("Talat Unicode", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label1.Location = New System.Drawing.Point(1, 89)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(137, 18)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "SELAMAT BEKERJA"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Timer1
		'
		'
		'MainMenu
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(706, 530)
		Me.ControlContainer = Me.FluentContainer
		Me.Controls.Add(Me.FluentContainer)
		Me.Controls.Add(Me.AccordionControl1)
		Me.Controls.Add(Me.Panel1)
		Me.Controls.Add(Me.FluentDesignFormControl1)
		Me.FluentDesignFormControl = Me.FluentDesignFormControl1
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Margin = New System.Windows.Forms.Padding(2)
		Me.Name = "MainMenu"
		Me.NavigationControl = Me.AccordionControl1
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "EVENT | PT GEO GIVEN VISI MANDIRI"
		Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
		CType(Me.RepositoryItemHypertextLabel1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.AccordionControl1, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.FluentDesignFormControl1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		Me.ResumeLayout(False)

	End Sub
	Friend WithEvents FluentContainer As DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer
    Friend WithEvents AccordionControl1 As DevExpress.XtraBars.Navigation.AccordionControl
    Friend WithEvents M_Menu As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents FluentDesignFormControl1 As DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl
    Friend WithEvents Menu_Event As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents PE_OpsEvn As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents M_Barang As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents M_Kontrak As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents Menu_Activation As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents PE_EventAct As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents PE_BoothEvn As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents Menu_Exhibition As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents PE_RegExh As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents PE_PhotoExh As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents PE_ProjectAct As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents PE_InstoreAct As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents M_Penawaran As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents M_Pengajuan As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents P_Pengajuan As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents P_Purchasing As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents P_Paketing As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents P_Activation As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents Acc_Pengajuan As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents H_Pengajuan As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents M_PO As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents M_MintaPO As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents M_LPJ As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents B_LPJ As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents B_AccLPJ As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents B_HisLPJ As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents M_Gudang As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents P_Gudang As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents LoginUser As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarStaticItem2 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents NmDiv As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents BarStaticItem4 As DevExpress.XtraBars.BarStaticItem
    Friend WithEvents RepositoryItemHypertextLabel1 As DevExpress.XtraEditors.Repository.RepositoryItemHypertextLabel
    Friend WithEvents SSManager As DevExpress.XtraSplashScreen.SplashScreenManager
    Friend WithEvents BtnExit As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label1 As Label
End Class
