using System;
using System.ComponentModel;
using System.Diagnostics;

namespace DW.WPFToolkit.Tryout
{
    public partial class MainWindow : INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            //IsChecked = true;
        }

        public int Number
        {
            get { return _number; }
            set
            {
                _number = value;
                Debug.WriteLine(value);
                OnPropertyChanged("Number");
            }
        }
        private int _number;

        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                Debug.WriteLine(value);
                OnPropertyChanged("IsChecked");
            }
        }
        private bool _isChecked;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
