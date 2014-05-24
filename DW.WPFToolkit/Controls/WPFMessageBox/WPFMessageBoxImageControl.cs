using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace DW.WPFToolkit.Controls
{
    public class WPFMessageBoxImageControl : Control
    {
        static WPFMessageBoxImageControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(WPFMessageBoxImageControl), new FrameworkPropertyMetadata(typeof(WPFMessageBoxImageControl)));
        }

        public WPFMessageBoxImage Image
        {
            get { return (WPFMessageBoxImage)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(WPFMessageBoxImage), typeof(WPFMessageBoxImageControl), new PropertyMetadata(WPFMessageBoxImage.None, OnImageChanged));

        public BitmapSource BitmapSource
        {
            get { return (BitmapSource)GetValue(BitmapSourceProperty); }
            set { SetValue(BitmapSourceProperty, value); }
        }

        public static readonly DependencyProperty BitmapSourceProperty =
            DependencyProperty.Register("BitmapSource", typeof(BitmapSource), typeof(WPFMessageBoxImageControl), new PropertyMetadata(null));

        private static void OnImageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (WPFMessageBoxImageControl)d;
            control.OnImageChanged();
        }

        private void OnImageChanged()
        {
            switch (Image)
            {
                //case WPFMessageBoxImage.Error:
                //case WPFMessageBoxImage.Hand:
                case WPFMessageBoxImage.Stop:
                    BitmapSource = IconToImage(System.Drawing.SystemIcons.Error);
                    break;

                //case WPFMessageBoxImage.Exclamation:
                case WPFMessageBoxImage.Warning:
                    BitmapSource = IconToImage(System.Drawing.SystemIcons.Warning);
                    break;

                //case WPFMessageBoxImage.Asterisk:
                case WPFMessageBoxImage.Information:
                    BitmapSource = IconToImage(System.Drawing.SystemIcons.Information);
                    break;

                case WPFMessageBoxImage.Question:
                    BitmapSource = IconToImage(System.Drawing.SystemIcons.Question);
                    break;
            }
        }

        private BitmapSource IconToImage(System.Drawing.Icon icon)
        {
            return Imaging.CreateBitmapSourceFromHIcon(icon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }
    }
}
