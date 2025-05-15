#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.XForms.ComboBox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfComboBox
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GettingStartedWPFSample : SampleView, INotifyPropertyChanged
    {
        public ObservableCollection<string> Source1 { get; set; }
        public ObservableCollection<string> Source2 { get; set; }
        public ObservableCollection<string> Source3 { get; set; }

        private string watermark = "Search Here";
        public string Watermark
        {
            get
            {
                return watermark;
            }
            set
            {
                watermark = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Watermark"));
                }
            }
        }

        private int textSize = 17;
        public int TextSize
        {
            get
            {
                return textSize;
            }
            set
            {
                textSize = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("TextSize"));
                }
            }
        }

        private bool isEditableComboBox = false;
        public bool IsEditableComboBox
        {
            get
            {
                return isEditableComboBox;
            }
            set
            {
                isEditableComboBox = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IsEditableComboBox"));
                }
            }
        }

        private bool isIgnoreDiacritic = false;
        public bool IsIgnoreDiacritic
        {
            get
            {
                return isIgnoreDiacritic;
            }
            set
            {
                isIgnoreDiacritic = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("IsIgnoreDiacritic"));
                }
            }
        }

        public new event PropertyChangedEventHandler PropertyChanged;
        public GettingStartedWPFSample()
        {
            InitializeComponent();
            Source1 = new ContactsInfoRepository().GetSizeDetails();
            Source2 = new ContactsInfoRepository().GetResolutionDetails();
            Source3 = new ContactsInfoRepository().GetOrientationDetails();
            this.BindingContext = this;
            optionLayout.BindingContext = this;
            PickerMethod();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            comboBox3.SuggestionBoxPlacement = SuggestionBoxPlacement.Bottom;
            base.OnSizeAllocated(width, height);
        }
       
        private void PickerMethod()
        {
            ColorPicker.SelectedIndex = 0;
            BackColorPicker.SelectedIndex = 0;
            SizePicker.SelectedIndex = 2;
            ComboBoxModePicker.SelectedIndex = 0;
            SizePicker.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                switch (SizePicker.SelectedIndex)
                {
                    case 0:
                        {
                            TextSize = 13;
                        }
                        break;
                    case 1:
                        {
                            TextSize = 15;
                        }
                        break;
                    case 2:
                        {
                            TextSize = 17;
                        }
                        break;
                }
            };
        }
    }

}
   