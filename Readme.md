<!-- default file list -->
*Files to look at*:

* [MainWindow.xaml](./CS/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/MainWindow.xaml))
* [MainWindow.xaml.cs](./CS/MainWindow.xaml.cs) (VB: [MainWindow.xaml.vb](./VB/MainWindow.xaml.vb))
* [RowDragHotTrackConverter.cs](./CS/RowDragHotTrackConverter.cs) (VB: [RowDragHotTrackConverter.vb](./VB/RowDragHotTrackConverter.vb))
* [Task.cs](./CS/Task.cs) (VB: [Task.vb](./VB/Task.vb))
<!-- default file list end -->
# How to implement hot-track for grid rows during the drag-and-drop operation


<p>This example illustrates how to highlight rows during the drag-and-drop operation. </p><p>In this example, we have DependencyProperty at the Window class level that  stores a current row handle of a row over which the mouse is.</p><p>To obtain a current row handle, we use the DragOver event.  Also, it is necessary to define RowStyle and add a trigger that will compare the current row handle with a dependency property value and change the current row's background if necessary.</p>

<br/>


