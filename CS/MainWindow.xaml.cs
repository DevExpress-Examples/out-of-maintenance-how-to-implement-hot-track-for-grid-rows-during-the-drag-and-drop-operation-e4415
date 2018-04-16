// Developer Express Code Central Example:
// How to implement hot-track for grid rows
// 
// This example demonstrates how to implement the hot-track functionality in
// TableView.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E3859

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Grid;
using System.Diagnostics;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window

    {
        public static readonly DependencyProperty HotTrackedRowHandleProperty = DependencyProperty.Register("HotTrackedRowHandle", typeof(int), typeof(MainWindow), new UIPropertyMetadata(-10000));

        public int HotTrackedRowHandle {
            get {
                return (int)GetValue(HotTrackedRowHandleProperty);
            }
            set {
                SetValue(HotTrackedRowHandleProperty, value);
            }
        }       
        public MainWindow()
        {
            InitializeComponent();
            
        }

        void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e) {
           if(e.Key == Key.Escape){
               HotTrackedRowHandle = GridControl.InvalidRowHandle;
               return;
           }
        }

        private void GridDragDropManager_DragOver(object sender, DevExpress.Xpf.Grid.DragDrop.GridDragOverEventArgs e) {
            if (e.HitInfo.InRow) {
                HotTrackedRowHandle = e.HitInfo.RowHandle;        
            }
        }

        private void GridDragDropManager_Dropped(object sender, DevExpress.Xpf.Grid.DragDrop.GridDroppedEventArgs e) {
            HotTrackedRowHandle = GridControl.InvalidRowHandle;
        }
    }
}
