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
