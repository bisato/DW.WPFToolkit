using System;
using System.Windows;
using DW.WPFToolkit.Helpers;

namespace DW.WPFToolkit.Interactivity
{
    public class FocusBehavior : DependencyObject
    {
        public static UIElement GetStartFocusedControl(DependencyObject obj)
        {
            return (UIElement)obj.GetValue(StartFocusedControlProperty);
        }

        public static void SetStartFocusedControl(DependencyObject obj, UIElement value)
        {
            obj.SetValue(StartFocusedControlProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Interactivity.FocusBehavior.GetStartFocusedControl(DependencyObject)" /> <see cref="DW.WPFToolkit.Interactivity.FocusBehavior.SetStartFocusedControl(DependencyObject, UIElement)" /> attached property.
        /// </summary>
        public static readonly DependencyProperty StartFocusedControlProperty =
            DependencyProperty.RegisterAttached("StartFocusedControl", typeof(UIElement), typeof(FocusBehavior), new UIPropertyMetadata(OnStartFocusedControlChanged));

        public static bool GetHasFocus(DependencyObject obj)
        {
            return (bool)obj.GetValue(HasFocusProperty);
        }

        public static void SetHasFocus(DependencyObject obj, bool value)
        {
            obj.SetValue(HasFocusProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Interactivity.FocusBehavior.GetHasFocus(DependencyObject)" /> <see cref="DW.WPFToolkit.Interactivity.FocusBehavior.SetHasFocus(DependencyObject, bool)" /> attached property.
        /// </summary>
        public static readonly DependencyProperty HasFocusProperty =
            DependencyProperty.RegisterAttached("HasFocus", typeof(bool), typeof(FocusBehavior), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnHasFocusChanged));

        private static void OnStartFocusedControlChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var element = sender as FrameworkElement;
            if (element == null)
                throw new InvalidOperationException("The FocusBehavior.StartFocusedControl only can be attached to an FrameworkElement");

            element.Loaded += new RoutedEventHandler(Element_Loaded);
        }

        private static void Element_Loaded(object sender, RoutedEventArgs e)
        {
            var target = GetStartFocusedControl((DependencyObject)sender);
            ControlFocus.GiveFocus(target);
        }

        private static void OnHasFocusChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var element = sender as FrameworkElement;
            if (element == null)
                throw new InvalidOperationException("The FocusBehavior.HasFocus only can be attached to an FrameworkElement");

            if ((bool)e.NewValue)
            {
                ControlFocus.GiveFocus(element);
                element.LostFocus += new RoutedEventHandler(Element_LostFocus);
            }
        }

        private static void Element_LostFocus(object sender, RoutedEventArgs e)
        {
            var element = sender as FrameworkElement;
            element.LostFocus -= new RoutedEventHandler(Element_LostFocus);
            SetHasFocus(element, false);
        }
    }
}
