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
'INSTANT VB NOTE: The variable date was renamed since Visual Basic does not handle local variables named the same as class members well:
'INSTANT VB NOTE: The variable name was renamed since Visual Basic does not handle local variables named the same as class members well:
'INSTANT VB NOTE: The variable iD was renamed since Visual Basic does not handle local variables named the same as class members well:
		Public Sub New(ByVal date_Renamed As DateTime, ByVal name_Renamed As String, ByVal iD_Renamed As Integer)
			Me.Date = date_Renamed
			Me.Name = name_Renamed
			Me.ID = iD_Renamed
		End Sub

		Public Property [Date]() As DateTime
		Public Property Name() As String
		Public Property ID() As Integer
	End Class
End Namespace