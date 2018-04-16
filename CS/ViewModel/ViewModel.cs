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

namespace WpfApplication
{
    public class ViewModel
    {

        public ViewModel()
        {
            
        }

        // Fields...
        private object _DataSource;


        public object DataSource
        {
            get {  
                if (_DataSource == null)
                    _DataSource = DataHelper.GetDataSource(20);
                return _DataSource;
            }
            set
            {
                _DataSource = value;

            }
        }
    }
}
