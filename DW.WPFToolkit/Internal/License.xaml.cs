using System.Diagnostics;
using System.Windows.Navigation;

namespace License1
{
    internal partial class License
    {
        internal License()
        {
            InitializeComponent();
        }

        private static bool _alreadyShown;

        internal static void Display()
        {
            if (_alreadyShown)
                return;

            _alreadyShown = true;

            var window = new License();
            window.ShowDialog();
        }

        private void ShowInBrowser(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
