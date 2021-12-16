<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLogin
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim SplashScreenManager As DevExpress.XtraSplashScreen.SplashScreenManager = New DevExpress.XtraSplashScreen.SplashScreenManager(Me, GetType(Global.Program_EVENT.SplashScreen), True, True)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogin))
        Me.FluentDesignFormContainer1 = New DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer()
        Me.ItemPanel1 = New DevComponents.DotNetBar.ItemPanel()
        Me.ProgressBar = New DevComponents.DotNetBar.Controls.ProgressBarX()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TPassword = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.PictureEdit1 = New DevExpress.XtraEditors.PictureEdit()
        Me.TUsername = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.ControlContainerItem1 = New DevComponents.DotNetBar.ControlContainerItem()
        Me.ItemContainer1 = New DevComponents.DotNetBar.ItemContainer()
        Me.ItemContainer2 = New DevComponents.DotNetBar.ItemContainer()
        Me.LabelItem1 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem3 = New DevComponents.DotNetBar.LabelItem()
        Me.ControlContainerItem2 = New DevComponents.DotNetBar.ControlContainerItem()
        Me.ItemContainer3 = New DevComponents.DotNetBar.ItemContainer()
        Me.LabelItem2 = New DevComponents.DotNetBar.LabelItem()
        Me.LabelItem4 = New DevComponents.DotNetBar.LabelItem()
        Me.ControlContainerItem3 = New DevComponents.DotNetBar.ControlContainerItem()
        Me.ItemContainer4 = New DevComponents.DotNetBar.ItemContainer()
        Me.BtnLogin = New DevComponents.DotNetBar.ButtonItem()
        Me.BtnCancel = New DevComponents.DotNetBar.ButtonItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.FluentDesignFormContainer1.SuspendLayout()
        Me.ItemPanel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplashScreenManager
        '
        SplashScreenManager.ClosingDelay = 300
        '
        'FluentDesignFormContainer1
        '
        Me.FluentDesignFormContainer1.Controls.Add(Me.ItemPanel1)
        Me.FluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FluentDesignFormContainer1.Location = New System.Drawing.Point(0, 0)
        Me.FluentDesignFormContainer1.Name = "FluentDesignFormContainer1"
        Me.FluentDesignFormContainer1.Size = New System.Drawing.Size(476, 234)
        Me.FluentDesignFormContainer1.TabIndex = 4
        '
        'ItemPanel1
        '
        '
        '
        '
        Me.ItemPanel1.BackgroundStyle.Class = "ItemPanel"
        Me.ItemPanel1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemPanel1.ContainerControlProcessDialogKey = True
        Me.ItemPanel1.Controls.Add(Me.ProgressBar)
        Me.ItemPanel1.Controls.Add(Me.TextBox1)
        Me.ItemPanel1.Controls.Add(Me.DataGridView1)
        Me.ItemPanel1.Controls.Add(Me.TPassword)
        Me.ItemPanel1.Controls.Add(Me.PictureEdit1)
        Me.ItemPanel1.Controls.Add(Me.TUsername)
        Me.ItemPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ItemPanel1.DragDropSupport = True
        Me.ItemPanel1.Items.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ControlContainerItem1, Me.ItemContainer1})
        Me.ItemPanel1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemPanel1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F"
        Me.ItemPanel1.Location = New System.Drawing.Point(0, 0)
        Me.ItemPanel1.Name = "ItemPanel1"
        Me.ItemPanel1.ReserveLeftSpace = False
        Me.ItemPanel1.Size = New System.Drawing.Size(476, 234)
        Me.ItemPanel1.TabIndex = 0
        Me.ItemPanel1.Text = "ItemPanel1"
        '
        'ProgressBar
        '
        '
        '
        '
        Me.ProgressBar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ProgressBar.Location = New System.Drawing.Point(0, 211)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(476, 23)
        Me.ProgressBar.TabIndex = 7
        Me.ProgressBar.Text = "ProgressBar"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(326, 216)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 22)
        Me.TextBox1.TabIndex = 4
        Me.TextBox1.Visible = False
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(366, 171)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(60, 39)
        Me.DataGridView1.TabIndex = 3
        Me.DataGridView1.Visible = False
        '
        'TPassword
        '
        '
        '
        '
        Me.TPassword.Border.Class = "TextBoxBorder"
        Me.TPassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TPassword.Location = New System.Drawing.Point(182, 133)
        Me.TPassword.Name = "TPassword"
        Me.TPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TPassword.PreventEnterBeep = True
        Me.TPassword.Size = New System.Drawing.Size(149, 22)
        Me.TPassword.TabIndex = 2
        Me.TPassword.UseSystemPasswordChar = True
        '
        'PictureEdit1
        '
        Me.PictureEdit1.EditValue = Global.Program_EVENT.My.Resources.Resources.ggvm
        Me.PictureEdit1.Location = New System.Drawing.Point(143, 3)
        Me.PictureEdit1.Name = "PictureEdit1"
        Me.PictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureEdit1.Size = New System.Drawing.Size(189, 93)
        Me.PictureEdit1.TabIndex = 0
        '
        'TUsername
        '
        '
        '
        '
        Me.TUsername.Border.Class = "TextBoxBorder"
        Me.TUsername.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TUsername.FocusHighlightEnabled = True
        Me.TUsername.Location = New System.Drawing.Point(182, 99)
        Me.TUsername.Name = "TUsername"
        Me.TUsername.PreventEnterBeep = True
        Me.TUsername.Size = New System.Drawing.Size(149, 22)
        Me.TUsername.TabIndex = 0
        '
        'ControlContainerItem1
        '
        Me.ControlContainerItem1.AllowItemResize = False
        Me.ControlContainerItem1.Control = Me.PictureEdit1
        Me.ControlContainerItem1.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem1.Name = "ControlContainerItem1"
        '
        'ItemContainer1
        '
        '
        '
        '
        Me.ItemContainer1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer1.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
        Me.ItemContainer1.ItemSpacing = 10
        Me.ItemContainer1.LayoutOrientation = DevComponents.DotNetBar.eOrientation.Vertical
        Me.ItemContainer1.Name = "ItemContainer1"
        Me.ItemContainer1.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.ItemContainer2, Me.ItemContainer3, Me.ItemContainer4})
        '
        '
        '
        Me.ItemContainer1.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ItemContainer1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'ItemContainer2
        '
        '
        '
        '
        Me.ItemContainer2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer2.Name = "ItemContainer2"
        Me.ItemContainer2.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem1, Me.LabelItem3, Me.ControlContainerItem2})
        '
        '
        '
        Me.ItemContainer2.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ItemContainer2.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'LabelItem1
        '
        Me.LabelItem1.Name = "LabelItem1"
        Me.LabelItem1.Text = "USERNAME"
        Me.LabelItem1.Width = 90
        '
        'LabelItem3
        '
        Me.LabelItem3.Name = "LabelItem3"
        Me.LabelItem3.Text = ":"
        '
        'ControlContainerItem2
        '
        Me.ControlContainerItem2.AllowItemResize = False
        Me.ControlContainerItem2.Control = Me.TUsername
        Me.ControlContainerItem2.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem2.Name = "ControlContainerItem2"
        '
        'ItemContainer3
        '
        '
        '
        '
        Me.ItemContainer3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer3.Name = "ItemContainer3"
        Me.ItemContainer3.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.LabelItem2, Me.LabelItem4, Me.ControlContainerItem3})
        '
        '
        '
        Me.ItemContainer3.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ItemContainer3.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'LabelItem2
        '
        Me.LabelItem2.Name = "LabelItem2"
        Me.LabelItem2.Text = "PASSWORD"
        Me.LabelItem2.Width = 90
        '
        'LabelItem4
        '
        Me.LabelItem4.Name = "LabelItem4"
        Me.LabelItem4.Text = ":"
        '
        'ControlContainerItem3
        '
        Me.ControlContainerItem3.AllowItemResize = False
        Me.ControlContainerItem3.Control = Me.TPassword
        Me.ControlContainerItem3.MenuVisibility = DevComponents.DotNetBar.eMenuVisibility.VisibleAlways
        Me.ControlContainerItem3.Name = "ControlContainerItem3"
        '
        'ItemContainer4
        '
        '
        '
        '
        Me.ItemContainer4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ItemContainer4.EqualItemSize = True
        Me.ItemContainer4.HorizontalItemAlignment = DevComponents.DotNetBar.eHorizontalItemsAlignment.Center
        Me.ItemContainer4.ItemSpacing = 10
        Me.ItemContainer4.Name = "ItemContainer4"
        Me.ItemContainer4.SubItems.AddRange(New DevComponents.DotNetBar.BaseItem() {Me.BtnLogin, Me.BtnCancel})
        '
        '
        '
        Me.ItemContainer4.TitleMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        '
        '
        Me.ItemContainer4.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        '
        'BtnLogin
        '
        Me.BtnLogin.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnLogin.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue
        Me.BtnLogin.FixedSize = New System.Drawing.Size(150, 30)
        Me.BtnLogin.FontBold = True
        Me.BtnLogin.ImagePaddingHorizontal = 15
        Me.BtnLogin.ImagePaddingVertical = 5
        Me.BtnLogin.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        Me.BtnLogin.Name = "BtnLogin"
        Me.BtnLogin.SubItemsExpandWidth = 20
        Me.BtnLogin.Symbol = "59389"
        Me.BtnLogin.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.BtnLogin.Text = "LOGIN"
        '
        'BtnCancel
        '
        Me.BtnCancel.ButtonStyle = DevComponents.DotNetBar.eButtonStyle.ImageAndText
        Me.BtnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue
        Me.BtnCancel.FixedSize = New System.Drawing.Size(150, 30)
        Me.BtnCancel.FontBold = True
        Me.BtnCancel.ImagePaddingHorizontal = 15
        Me.BtnCancel.ImagePaddingVertical = 5
        Me.BtnCancel.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Center
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.SubItemsExpandWidth = 20
        Me.BtnCancel.Symbol = "59590"
        Me.BtnCancel.SymbolSet = DevComponents.DotNetBar.eSymbolSet.Material
        Me.BtnCancel.Text = "CANCEL"
        '
        'FrmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(476, 234)
        Me.Controls.Add(Me.FluentDesignFormContainer1)
        Me.IconOptions.Icon = CType(resources.GetObject("FrmLogin.IconOptions.Icon"), System.Drawing.Icon)
        Me.Name = "FrmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Halaman Login"
        Me.FluentDesignFormContainer1.ResumeLayout(False)
        Me.ItemPanel1.ResumeLayout(False)
        Me.ItemPanel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents FluentDesignFormContainer1 As DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer
    Friend WithEvents ItemPanel1 As DevComponents.DotNetBar.ItemPanel
    Friend WithEvents PictureEdit1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents ControlContainerItem1 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ItemContainer1 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents ItemContainer2 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents LabelItem1 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem3 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ItemContainer3 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents LabelItem2 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents LabelItem4 As DevComponents.DotNetBar.LabelItem
    Friend WithEvents ItemContainer4 As DevComponents.DotNetBar.ItemContainer
    Friend WithEvents BtnLogin As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents BtnCancel As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents ProgressBar As DevComponents.DotNetBar.Controls.ProgressBarX
    Friend WithEvents TPassword As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents TUsername As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents ControlContainerItem2 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents ControlContainerItem3 As DevComponents.DotNetBar.ControlContainerItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
