using System.ComponentModel;
using System.Windows;
using DW.WPFToolkit.Controls;

namespace DW.WPFToolkit.Tryout
{
    public partial class MainWindow : INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Show(object sender, RoutedEventArgs e)
        {
            var options = new WPFMessageBoxOptions();
            options.ShowHelpButton = true;
            options.ShowYesToAllButton = true;
            options.ShowNoToAllButton = true;
            var result = WPFMessageBox.Show(this,
                "This is the messagebox text",
                "Title",
                WPFMessageBoxButtons.YesNo,
                WPFMessageBoxImage.Information,
                WPFMessageBoxResult.Retry,
                options);

            if (result == WPFMessageBoxResult.NoToAll)
            {
            }

            if (result == WPFMessageBoxResult.YesToAll)
            {
            }
        }
    }
}
