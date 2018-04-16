// Developer Express Code Central Example:
// How to implement hot-track for grid rows during the drag-and-drop operation
// 
// This example illustrates how to highlight rows during the drag-and-drop
// operation. In this example, we have DependencyProperty at the Window class level
// that stores a current row handle of a row over which the mouse is.
// To obtain a
// current row handle, we use the DragOver event. Also, it is necessary to define
// RowStyle and add a trigger that will compare the current row handle with a
// dependency property value and change the current row's background if necessary.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E4415

// Developer Express Code Central Example:
// How to implement hot-track for grid rows during the drag-and-drop operation
// 
// This example illustrates how to highlight rows during the drag-and-drop
// operation. In this example, we have DependencyProperty at the Window class level
// that stores a current row handle of a row over which the mouse is.
// To obtain a
// current row handle, we use the DragOver event. Also, it is necessary to define
// RowStyle and add a trigger that will compare the current row handle with a
// dependency property value and change the current row's background if necessary.
// 
// You can find sample updates and versions for different programming languages here:
// http://www.devexpress.com/example=E4415

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using System.Windows.Data;
using System.Windows;

namespace WpfApplication {
    class RowDragHotTrackConverter : MarkupExtension, IMultiValueConverter {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture) {

            return (int)values[0] == (int)values[1];
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }
}
