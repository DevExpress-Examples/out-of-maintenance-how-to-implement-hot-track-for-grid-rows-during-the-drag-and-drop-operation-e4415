using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using DevExpress.Xpf.Core.Native;
using DevExpress.Xpf.Grid;
using DevExpress.Data;
using System.Diagnostics;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public ObservableCollection<Task> Tasks;
        public static readonly DependencyProperty HotTrackedRowHandleProperty = DependencyProperty.Register("HotTrackedRowHandle", typeof(int), typeof(MainWindow), new UIPropertyMetadata(-10000));

        public int HotTrackedRowHandle {
            get {
                return (int)GetValue(HotTrackedRowHandleProperty);
            }
            set {
                SetValue(HotTrackedRowHandleProperty, value);
            }
        }

        bool dragStarted;
        int chosenRowHandle;

        public MainWindow()
        {
            InitializeComponent();
            FillData();
            DragDropEventsInit();
        }
        public void FillData() {
            Tasks = new ObservableCollection<Task>();

            Tasks.Add(new Task("Task1", new DateTime(2012, 9, 3), DateTime.Now, true));
            Tasks.Add(new Task("Task2", DateTime.Now, new DateTime(2012, 9, 7), false));
            Tasks.Add(new Task("Task3", new DateTime(2012, 8, 12), DateTime.Now, true));
            Tasks.Add(new Task("Task4", new DateTime(2012, 9, 3), DateTime.Now, true));
            Tasks.Add(new Task("Task5", new DateTime(2012, 7, 15), new DateTime(2012, 9, 23), false));
            Tasks.Add(new Task("Task6", new DateTime(2012, 4, 3), new DateTime(2012, 4, 2), true));

            gridControl1.ItemsSource = Tasks;

        }


        private void DragDropEventsInit() {
            tableView1.PreviewMouseDown += View_PreviewMouseDown;
            tableView1.PreviewMouseMove += View_PreviewMouseMove;
            tableView1.PreviewDragOver += View_DragOver;
            tableView1.Drop += View_Drop;
        }

        void View_Drop(object sender, DragEventArgs e) {

            int sourceRowHandle = (int)e.Data.GetData(typeof(Task));
            Task sourceRow = (Task)gridControl1.GetRow(sourceRowHandle);
            Task rowCopy = new Task() { FinishDate = sourceRow.FinishDate, StartDate = sourceRow.StartDate, IsCompleted = sourceRow.IsCompleted, Name = sourceRow.Name };
            Tasks.Insert(HotTrackedRowHandle, rowCopy);
            HotTrackedRowHandle = GridControl.InvalidRowHandle;
        }

        void View_DragOver(object sender, DragEventArgs e) {

            //IndicatorColumnHeader
            FrameworkElement header = LayoutHelper.FindParentObject<CellItemsControl>(e.OriginalSource as DependencyObject);
            HotTrackedRowHandle = tableView1.GetRowHandleByTreeElement(e.OriginalSource as DependencyObject);
            if (header != null) {
                RowData row = (RowData)header.DataContext;

                if (chosenRowHandle == row.RowHandle.Value) {
                    e.Effects = DragDropEffects.Move;
                }
            }
            else
                e.Effects = DragDropEffects.None;
            e.Handled = true;
        }

        void View_PreviewMouseMove(object sender, MouseEventArgs e) {
            chosenRowHandle = tableView1.GetRowHandleByMouseEventArgs(e);
            if (dragStarted) {
                DataObject data = CreateDataObject(chosenRowHandle);
                DragDrop.DoDragDrop(tableView1.GetRowElementByMouseEventArgs(e), data, DragDropEffects.Move | DragDropEffects.Move);
                dragStarted = false;
            }
        }

        void View_PreviewMouseDown(object sender, MouseButtonEventArgs e) {
            int rowHandle = tableView1.GetRowHandleByMouseEventArgs(e);
            if (rowHandle != GridControl.InvalidRowHandle)
                dragStarted = true;
        }

        private DataObject CreateDataObject(int rowHandle) {
            DataObject data = new DataObject();
            data.SetData(typeof(Task), rowHandle);
            return data;
        }

        private void tableView1_QueryContinueDrag(object sender, QueryContinueDragEventArgs e) {
            if (e.EscapePressed) {
                HotTrackedRowHandle = GridControl.InvalidRowHandle;
            }
        }
    }
}
