using System.Collections.ObjectModel;
using System.ComponentModel;
using DW.WPFToolkit.Helpers;

namespace DW.WPFToolkit.Tryout
{
    public partial class MainWindow : INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            Items = new ObservableCollection<string>();
            _watcher = new KeyboardWatcher();
            _watcher.AddCallback(Callback);

            _watcher.BeginWatch();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private KeyboardWatcher _watcher;
        public ObservableCollection<string> Items { get; private set; }

        private void Callback(KeyStateChangedArgs keyStateChangedArgs)
        {
            Items.Add(keyStateChangedArgs.Key + " " + keyStateChangedArgs.State);
        }
    }
}
