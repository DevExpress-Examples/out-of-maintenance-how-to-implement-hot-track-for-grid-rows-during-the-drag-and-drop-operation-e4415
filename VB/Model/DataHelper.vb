Imports System
Imports System.Collections.ObjectModel

Namespace WpfApplication
	Public Class DataHelper
		Public Shared Function GetDataSource(ByVal count As Integer) As Object
		 Dim collection As New ObservableCollection(Of GridItem)()
			For i As Integer = 0 To count - 1
				collection.Add(New GridItem(DateTime.Now.AddMinutes(count * i).AddDays((i - count \ 2) * count), String.Format("Name{0}", i), i))
			Next i
			Return collection
		End Function

	End Class

	Public Class GridItem
		Public Sub New(ByVal [date] As DateTime, ByVal name As String, ByVal iD As Integer)
			Me.Date = [date]
			Me.Name = name
			Me.ID = iD
		End Sub

		Public Property [Date]() As DateTime
		Public Property Name() As String
		Public Property ID() As Integer
	End Class
End Namespace