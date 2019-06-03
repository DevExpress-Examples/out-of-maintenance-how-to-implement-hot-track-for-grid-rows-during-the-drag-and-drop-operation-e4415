using System;
using System.Collections.ObjectModel;

namespace WpfApplication {
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

    public class GridItem {
        public GridItem(DateTime date, string name, int iD) {
            Date = date;
            Name = name;
            ID = iD;
        }

        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int ID { get; set; }
    }
}