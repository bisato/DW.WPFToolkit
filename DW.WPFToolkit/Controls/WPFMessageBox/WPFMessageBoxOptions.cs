#region License
/*
The MIT License (MIT)

Copyright (c) 2009-2014 David Wendland

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

using System;
using System.Windows;
using System.Windows.Media;

namespace DW.WPFToolkit.Controls
{
    public class WPFMessageBoxOptions
    {
        public WPFMessageBoxOptions()
        {
            WindowOptions = new WindowOptionsContainer();
            Styles = new StylesContainer();

            MessageCopyFormatter = new DefaultMessageCopyFormatter();
            Strings = new MessageBoxStrings();
            ShowHelpButton = false;
            HelpRequestCallback = null;
            ShowYesToAllButton = false;
            ShowNoToAllButton = false;
            ShowDoNotShowAgainCheckBox = false;
            IsDoNotShowAgainChecked = false;
            ShowDetails = false;
            DetailsContent = null;
            CustomItem = null;
            BackgroundControl = null;
        }

        public IMessageCopyFormatter MessageCopyFormatter { get; set; }
        public MessageBoxStrings Strings { get; set; }
        public bool ShowHelpButton { get; set; }
        public Action HelpRequestCallback { get; set; }
        public bool ShowYesToAllButton { get; set; }
        public bool ShowNoToAllButton { get; set; }
        public bool ShowDetails { get; set; }
        public bool ShowDoNotShowAgainCheckBox { get; set; }
        public bool IsDoNotShowAgainChecked { get; set; }
        public object DetailsContent { get; set; }
        public object CustomItem { get; set; }
        public object BackgroundControl { get; set; }

        public WindowOptionsContainer WindowOptions { get; private set; }
        public StylesContainer Styles { get; private set; }

        public class WindowOptionsContainer
        {
            internal WindowOptionsContainer()
            {
                ShowSystemMenu = false;
                Icon = null;
                StartupLocation = WindowStartupLocation.CenterOwner;
                ShowInTaskbar = false;
                ResizeMode = ResizeMode.NoResize;
                Position = new Point();
                MinWidth = 249;
                MaxWidth = 494;
                MinHeight = 172;
                MaxHeight = double.PositiveInfinity;
                DetailedMinWidth = 249;
                DetailedMaxWidth = 494;
                DetailedMinHeight = 350;
                DetailedMaxHeight = double.PositiveInfinity;
                DetailedResizeMode = ResizeMode.NoResize;
            }

            public bool ShowSystemMenu { get; set; }
            public ImageSource Icon { get; set; }
            public WindowStartupLocation StartupLocation { get; set; }
            public bool ShowInTaskbar { get; set; }
            public ResizeMode ResizeMode { get; set; }
            public Point Position { get; set; }
            public double MinWidth { get; set; }
            public double MaxWidth { get; set; }
            public double MinHeight { get; set; }
            public double MaxHeight { get; set; }
            public double DetailedMinWidth { get; set; }
            public double DetailedMaxWidth { get; set; }
            public double DetailedMinHeight { get; set; }
            public double DetailedMaxHeight { get; set; }
            public ResizeMode DetailedResizeMode { get; set; }
        }

        public class StylesContainer
        {
            internal StylesContainer()
            {
                ImageControlStyle = null;
                ScrollViewerControlStyle = null;
                TextControlStyle = null;
                ButtonsPanelStyle = null;
                ButtonControlStyle = null;
                CheckBoxControlStyle = null;
                DetailsButtonControlStyle = null;
                DetailsPresenterStyle = null;
            }

            public Style ImageControlStyle { get; set; }
            public Style ScrollViewerControlStyle { get; set; }
            public Style TextControlStyle { get; set; }
            public Style ButtonsPanelStyle { get; set; }
            public Style ButtonControlStyle { get; set; }
            public Style CheckBoxControlStyle { get; set; }
            public Style DetailsButtonControlStyle { get; set; }
            public Style DetailsPresenterStyle { get; set; }
        }
    }
}