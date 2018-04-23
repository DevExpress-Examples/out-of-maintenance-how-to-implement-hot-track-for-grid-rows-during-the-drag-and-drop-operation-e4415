Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows
Imports System.Windows.Input
Imports System.Collections.ObjectModel
Imports DevExpress.Xpf.Core.Native
Imports DevExpress.Xpf.Grid
Imports DevExpress.Data

Namespace WpfApplication
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Public Tasks As ObservableCollection(Of Task)
		Public Shared ReadOnly HotTrackedRowHandleProperty As DependencyProperty = DependencyProperty.Register("HotTrackedRowHandle", GetType(Integer), GetType(MainWindow), New UIPropertyMetadata(-10000))

		Public Property HotTrackedRowHandle() As Integer
			Get
				Return CInt(Fix(GetValue(HotTrackedRowHandleProperty)))
			End Get
			Set(ByVal value As Integer)
				SetValue(HotTrackedRowHandleProperty, value)
			End Set
		End Property

		Private dragStarted As Boolean
		Private chosenRowHandle As Integer

		Public Sub New()
			InitializeComponent()
			FillData()
			DragDropEventsInit()
		End Sub
		Public Sub FillData()
			Tasks = New ObservableCollection(Of Task)()

			Tasks.Add(New Task("Task1", New DateTime(2012, 9, 3), DateTime.Now, True))
			Tasks.Add(New Task("Task2", DateTime.Now, New DateTime(2012, 9, 7), False))
			Tasks.Add(New Task("Task3", New DateTime(2012, 8, 12), DateTime.Now, True))
			Tasks.Add(New Task("Task4", New DateTime(2012, 9, 3), DateTime.Now, True))
			Tasks.Add(New Task("Task5", New DateTime(2012, 7, 15), New DateTime(2012, 9, 23), False))
			Tasks.Add(New Task("Task6", New DateTime(2012, 4, 3), New DateTime(2012, 4, 2), True))

			gridControl1.ItemsSource = Tasks

		End Sub


		Private Sub DragDropEventsInit()
			AddHandler tableView1.PreviewMouseDown, AddressOf View_PreviewMouseDown
			AddHandler tableView1.PreviewMouseMove, AddressOf View_PreviewMouseMove
			AddHandler tableView1.PreviewDragOver, AddressOf View_DragOver
			AddHandler tableView1.Drop, AddressOf View_Drop
		End Sub

		Private Sub View_Drop(ByVal sender As Object, ByVal e As DragEventArgs)

			Dim sourceRowHandle As Integer = CInt(Fix(e.Data.GetData(GetType(Task))))
			Dim sourceRow As Task = CType(gridControl1.GetRow(sourceRowHandle), Task)
			Dim rowCopy As New Task() With {.FinishDate = sourceRow.FinishDate, .StartDate = sourceRow.StartDate, .IsCompleted = sourceRow.IsCompleted, .Name = sourceRow.Name}
			Tasks.Add(rowCopy)
		End Sub

		Private Sub View_DragOver(ByVal sender As Object, ByVal e As DragEventArgs)

			'IndicatorColumnHeader
			Dim header As FrameworkElement = LayoutHelper.FindParentObject(Of CellItemsControl)(TryCast(e.OriginalSource, DependencyObject))
			HotTrackedRowHandle = tableView1.GetRowHandleByTreeElement(TryCast(e.OriginalSource, DependencyObject))
			If header IsNot Nothing Then
				Dim row As RowData = CType(header.DataContext, RowData)

				If chosenRowHandle = row.RowHandle.Value Then
					e.Effects = DragDropEffects.Copy
				End If
			Else
				e.Effects = DragDropEffects.None
			End If
			e.Handled = True
		End Sub

		Private Sub View_PreviewMouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
			chosenRowHandle = tableView1.GetRowHandleByMouseEventArgs(e)
			If dragStarted Then
				Dim data As DataObject = CreateDataObject(chosenRowHandle)
				DragDrop.DoDragDrop(tableView1.GetRowElementByMouseEventArgs(e), data, DragDropEffects.Move Or DragDropEffects.Copy)
				dragStarted = False
			End If
		End Sub

		Private Sub View_PreviewMouseDown(ByVal sender As Object, ByVal e As MouseButtonEventArgs)
			Dim rowHandle As Integer = tableView1.GetRowHandleByMouseEventArgs(e)
			If rowHandle <> GridDataController.InvalidRow Then
				dragStarted = True
			End If
		End Sub

		Private Function CreateDataObject(ByVal rowHandle As Integer) As DataObject
			Dim data As New DataObject()
			data.SetData(GetType(Task), rowHandle)
			Return data
		End Function
	End Class
End Namespace
