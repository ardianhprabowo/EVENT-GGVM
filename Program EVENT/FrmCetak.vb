Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmCetak
	Private Sub FrmCetak_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Dim cryRpt As New ReportDocument

		Select Case ProsesCetak
			Case "peAll"
				cryRpt.Load(Application.StartupPath + "\\Reports\\CetakPE.rpt")
				cryRpt.SetParameterValue("idpe", CetakIdPE)
			Case "penestle"
				cryRpt.Load(Application.StartupPath + "\\Reports\\CetakPENestle.rpt")
				cryRpt.SetParameterValue("idpe", CetakIdPE)
			Case "exhibition"
				cryRpt.Load(Application.StartupPath + "\\Reports\\CetakExhibition.rpt")
				cryRpt.SetParameterValue("idpe", CetakIdPE)
			Case "event"
				cryRpt.Load(Application.StartupPath + "\\Reports\\CrEventAct.rpt")
				cryRpt.SetParameterValue("idpe", CetakIdPE)
			Case "instore"
				cryRpt.Load(Application.StartupPath + "\\Reports\\CrInstoreCoverAct.rpt")
				cryRpt.SetParameterValue("idpe", CetakIdPE)
			Case "project"
				cryRpt.Load(Application.StartupPath + "\\Reports\\CrProjectAct.rpt")
				cryRpt.SetParameterValue("idpe", CetakIdPE)
			Case "Pengajuan"
				cryRpt.Load(Application.StartupPath + "\\Reports\\CetakPengajuan.rpt")
				cryRpt.SetParameterValue("idpengajuan", CetakIdCost)
			Case "majuall"
				cryRpt.Load(Application.StartupPath + "\\Reports\\CrpPengajuanAll.rpt")
				cryRpt.SetParameterValue("myidpengajuan", tampilIdMajuAll)
			Case "majuall-pic"
				cryRpt.Load(Application.StartupPath + "\\Reports\\CrpPengajuanAll-pic.rpt")
				cryRpt.SetParameterValue("myidpengajuan", tampilIdMajuAll)
			Case "majupaket"
				cryRpt.Load(Application.StartupPath + "\\Reports\\CrPengajuanPkt.rpt")
				cryRpt.SetParameterValue("myidpengajuan", tampilIdMajuSPG)
			Case "lpj"
				cryRpt.Load(Application.StartupPath + "\\Reports\\crpLPJ.rpt")
				cryRpt.SetParameterValue("myidpengajuan", CetakIdLPJ)
			Case "pe"
				cryRpt.Load(Application.StartupPath + "\\Reports\\crpPE.rpt")
				' ReportKu.SetParameterValue("myidpe", TampilIdPE)
			Case "sj-gudang"
				cryRpt.Load(Application.StartupPath + "\\Reports\\crpsjgudang.rpt")
				cryRpt.Refresh()
		End Select

		CrystalReportViewer1.ReportSource = cryRpt
		CrystalReportViewer1.Refresh()
	End Sub

	Private Sub CrystalReportViewer1_Load(sender As Object, e As EventArgs) Handles CrystalReportViewer1.Load

	End Sub

	'Private Sub FrmCetak_Resize(sender As Object, e As EventArgs) Handles Me.Resize
	'    CrystalReportViewer1.Height = Me.Height - CrystalReportViewer1.Top - 15
	'    CrystalReportViewer1.Width = Me.Width - 10
	'End Sub
End Class