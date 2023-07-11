Imports System.Collections.Generic

Namespace Reporting_Create_Report_Parameter_with_Predefined_Dynamic_Values
	Public Class Employee
		Public Property Name() As String
		Public Property Position() As String
	End Class

	Public Class EmployeeDataSource
		Private employees As New List(Of Employee)() From {
			New Employee() With {
				.Name = "Antonio Moreno",
				.Position = "CEO"
			},
			New Employee() With {
				.Name = "Thomas Hardy",
				.Position = "Sales Representative"
			},
			New Employee() With {
				.Name = "Christina Berglund",
				.Position = "Order Administrator"
			},
			New Employee() With {
				.Name = "Frédérique Citeaux",
				.Position = "Marketing Manager"
			},
			New Employee() With {
				.Name = "Hanna Moos",
				.Position = "Software Developer"
			}
		}

		Public Iterator Function GetEmployeeList() As IEnumerable(Of Employee)
			For Each employee In employees
				Yield employee
			Next employee
		End Function
	End Class
End Namespace
