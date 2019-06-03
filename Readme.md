
# How to implement hot-track for grid rows during the drag-and-drop operation


Starting with **v17.2**, GridControl supports a Drag-and-Drop mechanism based on native Drag-Drop events (see: [Drag-and-Drop](https://documentation.devexpress.com/WPF/11346/Controls-and-Libraries/Data-Grid/Drag-and-Drop)). Now, it's sufficient to enable TableView's [AllowDragDrop](https://documentation.devexpress.com/WPF/DevExpress.Xpf.Grid.DataViewBase.AllowDragDrop.property) property to enable this functionality. 

For versions prior to v17.2, you need to use [Drag-and-Drop Managers](https://documentation.devexpress.com/WPF/11371/Controls-and-Libraries/Data-Grid/Drag-and-Drop/Drag-and-Drop-Managers) for this purpose. Use this example's implementation from previous branches when you use such managers.

In this example, we illustrated how to highlight a target data row during the Drag-and-Drop operation. We implemented an attached **HotTrackedRowHandle** dependency property that stores a target data row's [RowHandle](https://documentation.devexpress.com/WPF/6322/Controls-and-Libraries/Data-Grid/Grid-View-Data-Layout/Rows-and-Cards/Obtaining-Row-Handles) value. We set this value to a corresponding value at the TableView level in the [DragRecordOver](https://documentation.devexpress.com/WPF/DevExpress.Xpf.Grid.DataViewBase.DragRecordOver.event) event handler. 

When the Drag-and-Drop operation is completed, we disable such highlighting by setting this attached property to ***GridControl.InvalidRowHandle*** in the [CompleteRecordDragDrop](https://documentation.devexpress.com/WPF/DevExpress.Xpf.Grid.DataViewBase.CompleteRecordDragDrop.event) event handler. 

The appearance of the target row is determined by a custom [RowStyle](https://documentation.devexpress.com/WPF/DevExpress.Xpf.Grid.TableView.RowStyle.property) defined in the TableView. This style sets a row's background to a certain color if the value from the attached  **HotTrackedRowHandle** property equals to this row's RowHandle value.

Please refer to the implementation of the ***HotTrackedRowStyle*** style and ***HotTrackBehavior*** attached behavior to see this. 

See also:  
[Behaviors](https://documentation.devexpress.com/WPF/17442/MVVM-Framework/Behaviors)  
[How to: Create a Custom Behavior](https://documentation.devexpress.com/WPF/17458/MVVM-Framework/Behaviors/How-to-Create-a-Custom-Behavior)
