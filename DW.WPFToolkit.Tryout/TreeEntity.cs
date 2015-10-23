using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;


namespace DW.WPFToolkit.Tryout
{
    public class TreeEntity : INotifyPropertyChanged
    {
        private ObservableCollection<TreeEntity> _children;

        private string _name;

        public TreeEntity()
        {
            Children = new ObservableCollection<TreeEntity>();
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public ObservableCollection<TreeEntity> Children
        {
            get
            {
                return _children;
            }
            set
            {
                _children = value;
                OnPropertyChanged("Children");
            }
        }

        public override string ToString()
        {
            return Name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
