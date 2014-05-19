using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DW.WPFToolkit.Tryout
{
    public partial class MainWindow : INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            
            Items = new ObservableCollection<Item>();
            Items.Add(new Item("First", "First"));
            Items.Add(new Item("Second", "Second"));
            Items.Add(new Item("Third", "Third"));
        }

        public ObservableCollection<Item> Items { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class Item
    {
        public Item(string header, string content)
        {
            Header = header;
            Content = content;
        }

        public string Header { get; set; }
        public string Content { get; set; }
    }
}
