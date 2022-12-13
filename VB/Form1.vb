Imports DevExpress.DataAccess.ObjectBinding
Imports DevExpress.XtraReports.Parameters
Imports Parameter = DevExpress.XtraReports.Parameters.Parameter
Imports System.Windows.Forms
Imports System
Imports DevExpress.XtraReports.UI

Namespace Reporting_Create_Report_Parameter_with_Predefined_Dynamic_Values
	Partial Public Class Form1
		Inherits Form

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
			' Create and set up an Object data source.
			Dim objectDataSource = New ObjectDataSource()
			objectDataSource.Name = "Employees"
			objectDataSource.DataSource = GetType(EmployeeDataSource)
			objectDataSource.DataMember = "GetEmployeeList"
			objectDataSource.Constructor = New ObjectConstructorInfo()
			objectDataSource.Fill()

			' Create a report parameter.
			Dim param As New Parameter()
			param.Name = "employeePosition"
			param.Description = "Employee position:"
			param.Type = GetType(String)

			' Create a DynamicListLookUpSettings instance and
			' set up its properties.
			Dim lookupSettings = New DynamicListLookUpSettings()
			lookupSettings.DataSource = objectDataSource
			lookupSettings.ValueMember = "Name"
			lookupSettings.DisplayMember = "Position"

			' Assign data storage settings to the parameter's ValueSourceSettings property.
			param.ValueSourceSettings = lookupSettings

			' Create a report instance and add the parameter to the report's Parameters collection.
			Dim report = New XtraReport1()
			report.Parameters.Add(param)

			report.ShowPreview()
		End Sub
	End Class
End Namespace
