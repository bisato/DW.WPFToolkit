using System;
using System.ComponentModel;
using System.Text;
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
            var message = "Dies ist der Text der in der MessageBox angezeigt wird." + Environment.NewLine + Environment.NewLine + "Inklusive Newlines.";
            WPFMessageBox.Show(null, message, "title", WPFMessageBoxButtons.YesNo, WPFMessageBoxImage.Information, WPFMessageBoxResult.OK, new WPFMessageBoxOptions());
            System.Windows.Forms.MessageBox.Show(message, "title", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
        }
    }
}
