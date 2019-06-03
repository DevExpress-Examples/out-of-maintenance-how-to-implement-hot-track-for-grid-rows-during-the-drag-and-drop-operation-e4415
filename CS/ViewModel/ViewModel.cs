namespace WpfApplication {
    public class ViewModel {
        private object _DataSource;


        public object DataSource
        {
            get
            {
                if(_DataSource == null)
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
