using System;
using System.Windows;
using DW.WPFToolkit.Helpers;

namespace DW.WPFToolkit.Interactivity
{
    /// <summary>
    /// Brings the feature to set the focus to a specific element or on window launch.
    /// </summary>
    public class FocusBehavior : DependencyObject
    {
#if TRIAL
        static FocusBehavior()
        {
            License1.LicenseChecker.Validate();
        }
#endif

        /// <summary>
        /// Gets the control which has to get the focus when its loaded.
        /// </summary>
        /// <param name="obj">The element from which the property value is read.</param>
        /// <returns>The DW.WPFToolkit.Interactivity.FocusBehavior.StartFocusedControl property value for the element.</returns>
        public static UIElement GetStartFocusedControl(DependencyObject obj)
        {
            return (UIElement)obj.GetValue(StartFocusedControlProperty);
        }

        /// <summary>
        /// Attaches the control which has to get the focus when its loaded.
        /// </summary>
        /// <param name="obj">The element to which the attached property is written.</param>
        /// <param name="value">The needed DW.WPFToolkit.Interactivity.FocusBehavior.StartFocusedControl value.</param>
        public static void SetStartFocusedControl(DependencyObject obj, UIElement value)
        {
            obj.SetValue(StartFocusedControlProperty, value);
        }

        /// <summary>
        /// Identifies the <see cref="DW.WPFToolkit.Interactivity.FocusBehavior.GetStartFocusedControl(DependencyObject)" /> <see cref="DW.WPFToolkit.Interactivity.FocusBehavior.SetStartFocusedControl(DependencyObject, UIElement)" /> attached property.
        /// </summary>
        public static readonly DependencyProperty StartFocusedControlProperty =
            DependencyProperty.RegisterAttached("StartFocusedControl", typeof(UIElement), typeof(FocusBehavior), new UIPropertyMetadata(OnStartFocusedControlChanged));

        /// <summary>
        /// Gets a value that indicates the state if the element has the focus or not.
        /// </summary>
        /// <param name="obj">The element from which the property value is read.</param>
        /// <returns>The DW.WPFToolkit.Interactivity.FocusBehavior.HasFocus property value for the element.</returns>
        public static bool GetHasFocus(DependencyObject obj)
        {
            return (bool)obj.GetValue(HasFocusProperty);
        }

        /// <summary>
        /// Attaches a value that indicates the state if the element has the focus or not.
        /// </summary>
        /// <param name="obj">The element to which the attached property is written.</param>
        /// <param name="value">The needed DW.WPFToolkit.Interactivity.FocusBehavior.HasFocus value.</param>
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

            element.Loaded += Element_Loaded;
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
