using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
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

        [STAThread]
        internal static void Display()
        {
            if (_alreadyShown)
                return;

            _alreadyShown = true;

            if (TryShowNormally())
                return;

            if (TryShowInThread())
                return;

            ShowFallback();
        }

        private static bool TryShowNormally()
        {
            try
            {
                var w = new License();
                w.Show();
            }
            catch
            {
                return false;
            }
            return true;
        }

        private static bool TryShowInThread()
        {
            try
            {
                var thread = new Thread(() =>
                {
                    var w = new License();
                    w.SizeToContent = SizeToContent.Manual;
                    w.Height = 170;
                    w.Show();
                    System.Windows.Threading.Dispatcher.Run();
                });
                thread.SetApartmentState(ApartmentState.STA);
                thread.IsBackground = true;
                thread.Start();
            }
            catch
            {
                return false;
            }
            return true;
        }

        private static void ShowFallback()
        {
            try
            {
                System.Windows.Forms.MessageBox.Show("This is the Demo of the my-libraries DW.CodedUI 2.0 Package." + Environment.NewLine + "To order a full version visit: www.my-libraries.com");
            }
            catch
            {
                throw new InvalidOperationException("You try to run the DW.CodedUI demo but the license dialog cannot shown. In this case the demo is not working for you. Visit www.my-libraries.com to order a full license.");
            }
        }

        private void ShowInBrowser(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;

            Close();
        }
    }
}
