<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128651380/11.2.13%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4415)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
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


