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
Imports System.Configuration
Imports System.Data
Imports System.Linq
Imports System.Windows

Namespace WpfApplication
	''' <summary>
	''' Interaction logic for App.xaml
	''' </summary>
	Partial Public Class App
		Inherits Application

	End Class
End Namespace
