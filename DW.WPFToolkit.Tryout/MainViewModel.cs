﻿#region License
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

using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DW.WPFToolkit.Tryout
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private TreeEntity _selectedItem;

        private TreeEntity lisa;

        private TreeEntity maggie;

        public MainViewModel()
        {
            MyItems = new ObservableCollection<TreeEntity>();
            var homer = new TreeEntity() {Name = "Homer"};
            homer.Children.Add(new TreeEntity(){Name = "Bart"});
            var marge = new TreeEntity() { Name = "Marge" };
            lisa = new TreeEntity() { Name = "Lisa" };
            marge.Children.Add(lisa);
            maggie = new TreeEntity() { Name = "Maggie" };
            marge.Children.Add(maggie);
            MyItems.Add(marge);
            MyItems.Add(homer);
        }

        public ObservableCollection<TreeEntity> MyItems { get; set; }

        public TreeEntity SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
