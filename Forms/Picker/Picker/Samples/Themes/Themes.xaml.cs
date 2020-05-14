#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleBrowser.Core;
using Syncfusion.SfPicker.XForms;
using Xamarin.Forms;

namespace SampleBrowser.SfPicker
{
    public partial class Themes : SampleView
    {
        public Themes()
        {
            InitializeComponent();
            this.picker.BindingContext = new PickerViewModel();
        }
    }
    public class ColorName
    {
        public string Name
        {
            get;
            set;
        }
    }
    public class PickerViewModel 
    {
        private ObservableCollection<object> sportsCollection = new ObservableCollection<object>();
        private ObservableCollection<object> selectedItemCollection = new ObservableCollection<object>();


        public ObservableCollection<object> Items
        {
            get
            {
                return sportsCollection;
            }
            set
            {
                if (sportsCollection != value)
                {
                    sportsCollection = value;

                }
            }
        }

        public ObservableCollection<object> SelectedItem
        {
            get
            {
                return selectedItemCollection;
            }
            set
            {
                if (selectedItemCollection != value)
                {
                    selectedItemCollection = value;
                }
            }
        }
        public PickerViewModel()
        {
            ObservableCollection<object> sportsCollection = new ObservableCollection<object>();
            sportsCollection.Add("Cricket");
            sportsCollection.Add("Volley Ball");
            sportsCollection.Add("Hockey");
            sportsCollection.Add("Foot Ball");
            sportsCollection.Add("Basket Ball");
            sportsCollection.Add("Golf");
            sportsCollection.Add("Badminton");
            sportsCollection.Add("Tennis");
            Items = sportsCollection;
            ObservableCollection<object> selectedItemCollection = new ObservableCollection<object>();
            selectedItemCollection.Add("Cricket");
            SelectedItem = selectedItemCollection;
        }
    }
}
