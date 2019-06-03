Imports DevExpress.Mvvm.UI.Interactivity
Imports DevExpress.Xpf.Grid
Imports System.Windows

Namespace WpfApplication
	Public Class HotTrackBehavior
		Inherits Behavior(Of TableView)

		Public Shared Function GetHotTrackedRowHandle(ByVal obj As DependencyObject) As Integer
			Return DirectCast(obj.GetValue(HotTrackedRowHandleProperty), Integer)
		End Function

		Public Shared Sub SetHotTrackedRowHandle(ByVal obj As DependencyObject, ByVal value As Integer)
			obj.SetValue(HotTrackedRowHandleProperty, value)
		End Sub

		Public Shared ReadOnly HotTrackedRowHandleProperty As DependencyProperty = DependencyProperty.RegisterAttached("HotTrackedRowHandle", GetType(Integer), GetType(HotTrackBehavior), New PropertyMetadata(GridControl.InvalidRowHandle))


		Protected Overrides Sub OnAttached()
			MyBase.OnAttached()
			Me.AssociatedObject.AllowDragDrop = True
			AddHandler AssociatedObject.DragRecordOver, AddressOf AssociatedObject_DragRecordOver
			AddHandler AssociatedObject.CompleteRecordDragDrop, AddressOf AssociatedObject_CompleteRecordDragDrop
		End Sub

		Private Sub AssociatedObject_CompleteRecordDragDrop(ByVal sender As Object, ByVal e As DevExpress.Xpf.Core.CompleteRecordDragDropEventArgs)
			SetHotTrackedRowHandle(Me.AssociatedObject, GridControl.InvalidRowHandle)
		End Sub

		Private Sub AssociatedObject_DragRecordOver(ByVal sender As Object, ByVal e As DevExpress.Xpf.Core.DragRecordOverEventArgs)
			SetHotTrackedRowHandle(Me.AssociatedObject, e.TargetRowHandle)
		End Sub

		Protected Overrides Sub OnDetaching()
			RemoveHandler AssociatedObject.DragRecordOver, AddressOf AssociatedObject_DragRecordOver
			RemoveHandler AssociatedObject.CompleteRecordDragDrop, AddressOf AssociatedObject_CompleteRecordDragDrop
			MyBase.OnDetaching()
		End Sub
	End Class
End Namespace
