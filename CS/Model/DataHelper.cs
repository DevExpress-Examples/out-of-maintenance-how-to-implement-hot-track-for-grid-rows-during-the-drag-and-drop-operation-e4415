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
using System.Collections.ObjectModel;

namespace WpfApplication
{
    public class DataHelper
    {
        public static object GetDataSource(int count)
        {
         ObservableCollection<GridItem> collection = new ObservableCollection<GridItem>();
            for (int i = 0; i < count; i++)
            {
                collection.Add(new GridItem(DateTime.Now.AddMinutes(count * i).AddDays((i - count / 2) * count), String.Format("Name{0}", i), i));
            }
            return collection;
        }
  
    }

    public class GridItem
    {
        /// <summary>
        /// Initializes a new instance of the GridItem class.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="name"></param>
        /// <param name="iD"></param>
        public GridItem(DateTime date, string name, int iD)
        {
            _Date = date;
            _Name = name;
            _ID = iD;
        }
        public GridItem()
        {
       
        }

        // Fields...
        private DateTime _Date;
        private string _Name;


        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
            }
        }

        // Fields...
        private int _ID;


        public int ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
            }
        }


        public DateTime Date
        {
            get { return _Date; }
            set
            {
                _Date = value;

            }
        }
    }
}