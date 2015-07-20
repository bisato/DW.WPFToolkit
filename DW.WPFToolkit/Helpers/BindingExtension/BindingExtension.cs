#region License
/*
The MIT License (MIT)

Copyright (c) 2009-2015 David Wendland

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE
*/
#endregion License

using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DW.WPFToolkit.Helpers
{
    public class BindingExtension : FrameworkElement
    {
        private readonly bool _isChangedInternally;

        public BindingExtension()
        {
            _isChangedInternally = true;

            new Binding().CopyInto(this);

            _isChangedInternally = false;
        }

        internal FrameworkElement Owner
        {
            get { return (FrameworkElement)GetValue(OwnerProperty); }
            set { SetValue(OwnerProperty, value); }
        }

        internal static readonly DependencyProperty OwnerProperty =
            DependencyProperty.Register("Owner", typeof(FrameworkElement), typeof(BindingExtension), new PropertyMetadata(OnDataChanged));

        public DependencyProperty Property
        {
            get { return (DependencyProperty)GetValue(PropertyProperty); }
            set { SetValue(PropertyProperty, value); }
        }

        public static readonly DependencyProperty PropertyProperty =
            DependencyProperty.Register("Property", typeof(DependencyProperty), typeof(BindingExtension), new PropertyMetadata(OnDataChanged));

        public UpdateSourceTrigger UpdateSourceTrigger
        {
            get { return (UpdateSourceTrigger)GetValue(UpdateSourceTriggerProperty); }
            set { SetValue(UpdateSourceTriggerProperty, value); }
        }

        public static readonly DependencyProperty UpdateSourceTriggerProperty =
            DependencyProperty.Register("UpdateSourceTrigger", typeof(UpdateSourceTrigger), typeof(BindingExtension), new PropertyMetadata(OnDataChanged));

        public bool ValidatesOnDataErrors
        {
            get { return (bool)GetValue(ValidatesOnDataErrorsProperty); }
            set { SetValue(ValidatesOnDataErrorsProperty, value); }
        }

        public static readonly DependencyProperty ValidatesOnDataErrorsProperty =
            DependencyProperty.Register("ValidatesOnDataErrors", typeof(bool), typeof(BindingExtension), new PropertyMetadata(OnDataChanged));

        public BindingMode Mode
        {
            get { return (BindingMode)GetValue(ModeProperty); }
            set { SetValue(ModeProperty, value); }
        }

        public static readonly DependencyProperty ModeProperty =
            DependencyProperty.Register("Mode", typeof(BindingMode), typeof(BindingExtension), new PropertyMetadata(OnDataChanged));

        public PropertyPath Path
        {
            get { return (PropertyPath)GetValue(PathProperty); }
            set { SetValue(PathProperty, value); }
        }

        public static readonly DependencyProperty PathProperty =
            DependencyProperty.Register("Path", typeof(PropertyPath), typeof(BindingExtension), new PropertyMetadata(OnDataChanged));
        
        public object AsyncState
        {
            get { return (object)GetValue(AsyncStateProperty); }
            set { SetValue(AsyncStateProperty, value); }
        }

        public static readonly DependencyProperty AsyncStateProperty =
            DependencyProperty.Register("AsyncState", typeof(object), typeof(BindingExtension), new PropertyMetadata(OnDataChanged));

        public string BindingGroupName
        {
            get { return (string)GetValue(BindingGroupNameProperty); }
            set { SetValue(BindingGroupNameProperty, value); }
        }

        public static readonly DependencyProperty BindingGroupNameProperty =
            DependencyProperty.Register("BindingGroupName", typeof(string), typeof(BindingExtension), new PropertyMetadata(OnDataChanged));

        public bool BindsDirectlyToSource
        {
            get { return (bool)GetValue(BindsDirectlyToSourceProperty); }
            set { SetValue(BindsDirectlyToSourceProperty, value); }
        }

        public static readonly DependencyProperty BindsDirectlyToSourceProperty =
            DependencyProperty.Register("BindsDirectlyToSource", typeof(bool), typeof(BindingExtension), new PropertyMetadata(OnDataChanged));

        public IValueConverter Converter
        {
            get { return (IValueConverter)GetValue(ConverterProperty); }
            set { SetValue(ConverterProperty, value); }
        }

        public static readonly DependencyProperty ConverterProperty =
            DependencyProperty.Register("Converter", typeof(IValueConverter), typeof(BindingExtension), new PropertyMetadata(OnDataChanged));

        public CultureInfo ConverterCulture
        {
            get { return (CultureInfo)GetValue(ConverterCultureProperty); }
            set { SetValue(ConverterCultureProperty, value); }
        }

        public static readonly DependencyProperty ConverterCultureProperty =
            DependencyProperty.Register("ConverterCulture", typeof(CultureInfo), typeof(BindingExtension), new PropertyMetadata(OnDataChanged));
        
        public object ConverterParameter
        {
            get { return (object)GetValue(ConverterParameterProperty); }
            set { SetValue(ConverterParameterProperty, value); }
        }

        public static readonly DependencyProperty ConverterParameterProperty =
            DependencyProperty.Register("ConverterParameter", typeof(object), typeof(BindingExtension), new PropertyMetadata(OnDataChanged));

        public string ElementName
        {
            get { return (string)GetValue(ElementNameProperty); }
            set { SetValue(ElementNameProperty, value); }
        }

        public static readonly DependencyProperty ElementNameProperty =
            DependencyProperty.Register("ElementName", typeof(string), typeof(BindingExtension), new PropertyMetadata(OnDataChanged));

        public object FallbackValue
        {
            get { return (object)GetValue(FallbackValueProperty); }
            set { SetValue(FallbackValueProperty, value); }
        }

        public static readonly DependencyProperty FallbackValueProperty =
            DependencyProperty.Register("FallbackValue", typeof(object), typeof(BindingExtension), new PropertyMetadata(OnDataChanged));

        public bool IsAsync
        {
            get { return (bool)GetValue(IsAsyncProperty); }
            set { SetValue(IsAsyncProperty, value); }
        }

        public static readonly DependencyProperty IsAsyncProperty =
            DependencyProperty.Register("IsAsync", typeof(bool), typeof(BindingExtension), new PropertyMetadata(OnDataChanged));

        public bool NotifyOnSourceUpdated
        {
            get { return (bool)GetValue(NotifyOnSourceUpdatedProperty); }
            set { SetValue(NotifyOnSourceUpdatedProperty, value); }
        }

        public static readonly DependencyProperty NotifyOnSourceUpdatedProperty =
            DependencyProperty.Register("NotifyOnSourceUpdated", typeof(bool), typeof(BindingExtension), new PropertyMetadata(OnDataChanged));

        public bool NotifyOnTargetUpdated
        {
            get { return (bool)GetValue(NotifyOnTargetUpdatedProperty); }
            set { SetValue(NotifyOnTargetUpdatedProperty, value); }
        }

        public static readonly DependencyProperty NotifyOnTargetUpdatedProperty =
            DependencyProperty.Register("NotifyOnTargetUpdated", typeof(bool), typeof(BindingExtension), new PropertyMetadata(OnDataChanged));

        public bool NotifyOnValidationError
        {
            get { return (bool)GetValue(NotifyOnValidationErrorProperty); }
            set { SetValue(NotifyOnValidationErrorProperty, value); }
        }

        public static readonly DependencyProperty NotifyOnValidationErrorProperty =
            DependencyProperty.Register("NotifyOnValidationError", typeof(bool), typeof(BindingExtension), new PropertyMetadata(OnDataChanged));

        public string StringFormat
        {
            get { return (string)GetValue(StringFormatProperty); }
            set { SetValue(StringFormatProperty, value); }
        }

        public static readonly DependencyProperty StringFormatProperty =
            DependencyProperty.Register("StringFormat", typeof(string), typeof(BindingExtension), new PropertyMetadata(OnDataChanged));

        public object TargetNullValue
        {
            get { return (object)GetValue(TargetNullValueProperty); }
            set { SetValue(TargetNullValueProperty, value); }
        }

        public static readonly DependencyProperty TargetNullValueProperty =
            DependencyProperty.Register("TargetNullValue", typeof(object), typeof(BindingExtension), new PropertyMetadata(OnDataChanged));

        public UpdateSourceExceptionFilterCallback UpdateSourceExceptionFilter
        {
            get { return (UpdateSourceExceptionFilterCallback)GetValue(UpdateSourceExceptionFilterProperty); }
            set { SetValue(UpdateSourceExceptionFilterProperty, value); }
        }

        public static readonly DependencyProperty UpdateSourceExceptionFilterProperty =
            DependencyProperty.Register("UpdateSourceExceptionFilter", typeof(UpdateSourceExceptionFilterCallback), typeof(BindingExtension), new PropertyMetadata(OnDataChanged));

        public bool ValidatesOnExceptions
        {
            get { return (bool)GetValue(ValidatesOnExceptionsProperty); }
            set { SetValue(ValidatesOnExceptionsProperty, value); }
        }

        public static readonly DependencyProperty ValidatesOnExceptionsProperty =
            DependencyProperty.Register("ValidatesOnExceptions", typeof(bool), typeof(BindingExtension), new PropertyMetadata(OnDataChanged));

        public string XPath
        {
            get { return (string)GetValue(XPathProperty); }
            set { SetValue(XPathProperty, value); }
        }

        public static readonly DependencyProperty XPathProperty =
            DependencyProperty.Register("XPath", typeof(string), typeof(BindingExtension), new PropertyMetadata(OnDataChanged));

        private static void OnDataChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var extension = (BindingExtension)d;
            extension.Update();
        }

        private void Update()
        {
            if (_isChangedInternally)
                return;

            if (Owner == null || Property == null)
                return;

            var expression = Owner.GetBindingExpression(Property);
            if (expression == null || expression.ParentBinding == null)
                return;

            var refreshedBinding = expression.ParentBinding.Clone();
            refreshedBinding.Take(this);

            Owner.SetBinding(Property, refreshedBinding);
        }
    }
}
