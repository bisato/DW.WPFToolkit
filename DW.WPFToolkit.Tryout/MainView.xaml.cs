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

using System.Linq;
using System.Windows;

namespace DW.WPFToolkit.Tryout
{
    public partial class MainView
    {
        public MainView()
        {
            MainViewModel mainViewModel = new MainViewModel();
            DataContext = mainViewModel;
            InitializeComponent();
            
        }

        private void Button_Select_Maggie(object sender, RoutedEventArgs e)
        {
            SelectSimpson("Maggie");
        }

        private void Button_Select_Bart(object sender, RoutedEventArgs e)
        {
            SelectSimpson("Bart");
        }

        private void Button_Select_Homer(object sender, RoutedEventArgs e)
        {
            SelectSimpson("Homer");
        }

        private void SelectSimpson(string s)
        {
            var dc = DataContext as MainViewModel;
            if (dc != null)
            {
                var newSelected = dc.MyItems.Flatten(b => b.Children).FirstOrDefault(n => n.Name == s);
                dc.SelectedItem = newSelected;
            }
        }
    }
}
