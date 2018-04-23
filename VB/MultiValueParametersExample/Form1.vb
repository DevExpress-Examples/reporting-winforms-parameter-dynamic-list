Imports DevExpress.XtraReports.Parameters
Imports DevExpress.XtraReports.UI
Imports System
Imports System.Windows.Forms
' ...

Namespace MultiValueParametersExample
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            ' Create a report instance.
            Dim report As New XtraReport1()

            ' Create a parameter and specify its name.
            Dim param1 As New Parameter()
            param1.Name = "CatID"

            ' Specify other parameter properties.
            param1.Type = GetType(System.Int32)
            param1.MultiValue = True
            param1.Description = "Categories: "

            Dim lookupSettings As New DynamicListLookUpSettings()
            lookupSettings.DataSource = report.DataSource
            lookupSettings.DataMember = "Categories"
            lookupSettings.DisplayMember = "CategoryName"
            lookupSettings.ValueMember = "CategoryId"

            param1.LookUpSettings = lookupSettings
            param1.Visible = True

            ' Add the parameter to the report.
            report.Parameters.Add(param1)

            ' Specify the report's filter string.
            report.FilterString = "[CategoryID] In (?CatID)"

            ' Assign the report to a ReportPrintTool,
            Dim pt As New ReportPrintTool(report)
            pt.ShowPreviewDialog()
        End Sub
    End Class
End Namespace
