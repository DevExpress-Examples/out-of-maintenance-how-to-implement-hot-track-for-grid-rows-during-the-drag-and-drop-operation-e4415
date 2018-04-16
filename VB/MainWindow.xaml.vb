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
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace WpfApplication
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window

		Public Shared ReadOnly HotTrackedRowHandleProperty As DependencyProperty = DependencyProperty.Register("HotTrackedRowHandle", GetType(Integer), GetType(MainWindow), New UIPropertyMetadata(-10000))

		Public Property HotTrackedRowHandle() As Integer
			Get
				Return CInt(Fix(GetValue(HotTrackedRowHandleProperty)))
			End Get
			Set(ByVal value As Integer)
				SetValue(HotTrackedRowHandleProperty, value)
			End Set
		End Property
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub GridDragDropManager_DragOver(ByVal sender As Object, ByVal e As DevExpress.Xpf.Grid.DragDrop.GridDragOverEventArgs)
			If e.HitInfo.InRow Then

				HotTrackedRowHandle = e.HitInfo.RowHandle
			End If
		End Sub
	End Class
End Namespace
