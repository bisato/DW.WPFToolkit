using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
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

        private void AddClick(object sender, RoutedEventArgs e)
        {
            WPFMessageBox.Show(null, "text", "title", WPFMessageBoxButtons.YesNo, WPFMessageBoxImage.Information, WPFMessageBoxResult.OK, new WPFMessageBoxOptions());
            System.Windows.Forms.MessageBox.Show("text", "title", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }
    }
}
