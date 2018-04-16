' Developer Express Code Central Example:
' How to implement hot-track for grid rows
' 
' This example demonstrates how to implement the hot-track functionality in
' TableView.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E3859


Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace WpfApplication
	Public Class ViewModel

		Public Sub New()

		End Sub

		' Fields...
		Private _DataSource As Object


		Public Property DataSource() As Object
			Get
				If _DataSource Is Nothing Then
					_DataSource = DataHelper.GetDataSource(20)
				End If
				Return _DataSource
			End Get
			Set(ByVal value As Object)
				_DataSource = value

			End Set
		End Property
	End Class
End Namespace
