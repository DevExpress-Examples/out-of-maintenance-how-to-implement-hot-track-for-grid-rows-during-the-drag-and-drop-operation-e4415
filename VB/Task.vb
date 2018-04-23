Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace WpfApplication
	Public Class Task
		Public Property Name() As String
		Public Property FinishDate() As DateTime
		Public Property StartDate() As DateTime
		Public Property IsCompleted() As Boolean
		Public Sub New()
		End Sub

		Public Sub New(ByVal name As String, ByVal startDate As DateTime, ByVal finishDate As DateTime, ByVal completed As Boolean)
			Name = name
			FinishDate = finishDate
			StartDate = startDate
			IsCompleted = completed
		End Sub
	End Class
End Namespace
