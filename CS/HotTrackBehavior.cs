using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Xpf.Grid;
using System.Windows;

namespace WpfApplication {
    public class HotTrackBehavior : Behavior<TableView> {

        public static int GetHotTrackedRowHandle(DependencyObject obj) {
            return (int)obj.GetValue(HotTrackedRowHandleProperty);
        }

        public static void SetHotTrackedRowHandle(DependencyObject obj, int value) {
            obj.SetValue(HotTrackedRowHandleProperty, value);
        }

        public static readonly DependencyProperty HotTrackedRowHandleProperty =
            DependencyProperty.RegisterAttached("HotTrackedRowHandle", typeof(int), typeof(HotTrackBehavior), new PropertyMetadata(GridControl.InvalidRowHandle));


        protected override void OnAttached() {
            base.OnAttached();
            this.AssociatedObject.AllowDragDrop = true;
            this.AssociatedObject.DragRecordOver += AssociatedObject_DragRecordOver;
            this.AssociatedObject.CompleteRecordDragDrop += AssociatedObject_CompleteRecordDragDrop;
        }

        private void AssociatedObject_CompleteRecordDragDrop(object sender, DevExpress.Xpf.Core.CompleteRecordDragDropEventArgs e) {
            SetHotTrackedRowHandle(this.AssociatedObject, GridControl.InvalidRowHandle);
        }

        private void AssociatedObject_DragRecordOver(object sender, DevExpress.Xpf.Core.DragRecordOverEventArgs e) {
            SetHotTrackedRowHandle(this.AssociatedObject, e.TargetRowHandle);
        }

        protected override void OnDetaching() {
            this.AssociatedObject.DragRecordOver -= AssociatedObject_DragRecordOver;
            this.AssociatedObject.CompleteRecordDragDrop -= AssociatedObject_CompleteRecordDragDrop;
            base.OnDetaching();
        }
    }
}
