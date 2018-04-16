' Developer Express Code Central Example:
' How to implement hot-track for grid rows during the drag-and-drop operation
' 
' This example illustrates how to highlight rows during the drag-and-drop
' operation. In this example, we have DependencyProperty at the Window class level
' that stores a current row handle of a row over which the mouse is.
' To obtain a
' current row handle, we use the DragOver event. Also, it is necessary to define
' RowStyle and add a trigger that will compare the current row handle with a
' dependency property value and change the current row's background if necessary.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E4415

' Developer Express Code Central Example:
' How to implement hot-track for grid rows
' 
' This example demonstrates how to implement the hot-track functionality in
' TableView.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E3859

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
Imports DevExpress.Xpf.Grid
Imports System.Diagnostics

Namespace WpfApplication
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Shared ReadOnly HotTrackedRowHandleProperty As DependencyProperty = DependencyProperty.Register("HotTrackedRowHandle", GetType(Integer), GetType(MainWindow), New UIPropertyMetadata(-10000))

        Public Property HotTrackedRowHandle() As Integer
            Get
                Return DirectCast(GetValue(HotTrackedRowHandleProperty), Integer)
            End Get
            Set(ByVal value As Integer)
                SetValue(HotTrackedRowHandleProperty, value)
            End Set
        End Property
        Public Sub New()
            InitializeComponent()

        End Sub

        Private Sub MainWindow_PreviewKeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
           If e.Key = Key.Escape Then
               HotTrackedRowHandle = GridControl.InvalidRowHandle
               Return
           End If
        End Sub

        Private Sub GridDragDropManager_DragOver(ByVal sender As Object, ByVal e As DevExpress.Xpf.Grid.DragDrop.GridDragOverEventArgs)
            If e.HitInfo.InRow Then
                HotTrackedRowHandle = e.HitInfo.RowHandle
            End If
        End Sub

        Private Sub GridDragDropManager_Dropped(ByVal sender As Object, ByVal e As DevExpress.Xpf.Grid.DragDrop.GridDroppedEventArgs)
            HotTrackedRowHandle = GridControl.InvalidRowHandle
        End Sub
    End Class
End Namespace
