#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.XForms.ProgressBar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace SampleBrowser.SfStepProgressBar
{
    public partial class ShipmentTracking : SampleView
    {
        ShipmentViewModel ShipmentViewModel = new ShipmentViewModel();
        public ShipmentTracking()
        {
            InitializeComponent();
            stepProgress.StatusChanged += Step_StatusChanged;
            ShipmentViewModel.PopulateShipmentDetails();
            BindableLayout.SetItemsSource(stepProgress, ShipmentViewModel.ShipmentInfoCollection);
        }

        void Step_StatusChanged(object sender, StatusChangedEventArgs e)
        {
            int index = stepProgress.Children.IndexOf(e.Item);
            if (e.Item == stepProgress.Children[stepProgress.Children.Count - 1] && e.Item.Status == StepStatus.Completed)
            {
                TrackButton.IsEnabled = true;
            }
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            StepView stepView;
            switch (TrackButton.Text)
            {
                case "Track Status":
                    stepProgress.ProgressAnimationDuration = 1000;
                    stepView = stepProgress.Children[3] as StepView;
                    stepView.Status = StepStatus.Completed;
                    TrackButton.Text = "Reset";
                    TrackButton.IsEnabled = false;
                    break;
                default:
                    TrackButton.Text = "Track Status";
                    stepProgress.ProgressAnimationDuration = 1;
                    stepView = stepProgress.Children[0] as StepView;
                    stepView.Status = StepStatus.NotStarted;
                    break;
            }
        }
    }

    /// <summary>
    /// Shipment View Model Class
    /// </summary>
    public class ShipmentViewModel
    {
        private ObservableCollection<Shipment> shipmentInfoCollection = new ObservableCollection<Shipment>();

        /// <summary>
        /// Gets or sets ShipmentInfoCollection
        /// </summary>
        public ObservableCollection<Shipment> ShipmentInfoCollection
        {
            get
            {
                return shipmentInfoCollection;
            }
            set
            {
                shipmentInfoCollection = value;
            }
        }

        /// <summary>
        /// Populate shipment details
        /// </summary>
        public void PopulateShipmentDetails()
        {
            ShipmentInfoCollection.Add(CreateShipmentInfo("Ordered and Approved", "Your Order has been placed.", "Sat, 27th Oct"));
            ShipmentInfoCollection.Add(CreateShipmentInfo("Packed", "Your item has been picked up by courier partner.", "Mon, 29th Oct"));
            ShipmentInfoCollection.Add(CreateShipmentInfo("Shipped", "", ""));
            ShipmentInfoCollection.Add(CreateShipmentInfo("Delivered", "", ""));
        }

        /// <summary>
        /// Create shipment information
        /// </summary>
        /// <param name="title">title text</param>
        /// <param name="titleStatus">status title text</param>
        /// <param name="date">date text</param>
        /// <returns>returns shipment</returns>
        public Shipment CreateShipmentInfo(string title, string titleStatus, string date)
        {
            Shipment shipment = new Shipment()
            {
                Title = title,
                TitleStatus = titleStatus,
                Date = date
            };

            return shipment;
        }
    }

    /// <summary>
    /// Shipment class
    /// </summary>
    public class Shipment : INotifyPropertyChanged
    {
        /// <summary>
        /// title field
        /// </summary>
        private string title;

        /// <summary>
        /// status title field
        /// </summary>
        private string titleStatus;

        /// <summary>
        /// date field
        /// </summary>
        private string date;

        /// <summary>
        /// Gets or sets the Title 
        /// </summary>
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                if (title != value)
                {
                    title = value;
                    RaisePropertyChange();
                }
            }
        }

        /// <summary>
        /// Gets or sets the TitleStatus
        /// </summary>
        public string TitleStatus
        {
            get
            {
                return titleStatus;
            }
            set
            {
                if (titleStatus != value)
                {
                    titleStatus = value;
                    RaisePropertyChange();
                }
            }
        }

        /// <summary>
        /// Gets or sets Date
        /// </summary>
        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                if (date != value)
                {
                    date = value;
                    RaisePropertyChange();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChange([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }

    /// <summary>
    /// Title color value converter
    /// </summary>
    public class TitleColorConverter : IValueConverter
    {
        string checkString = string.Empty;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Span span = parameter as Span;
            Color color = Color.FromHex("#6E6E6E");
            if ((StepStatus)value == StepStatus.Completed)
            {
                if (checkString == string.Empty && span.Text != string.Empty)
                {
                    checkString = span.Text;
                    return color;
                }
                switch (span.ClassId)
                {
                    case "1":
                        color = Color.Black;
                        break;
                }
            }
            else if ((StepStatus)value == StepStatus.NotStarted)
            {
                checkString = string.Empty;
            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Color)value == Color.Black;
        }
    }

    /// <summary>
    /// Sub title color value converter
    /// </summary>
    public class SubTitleColorConverter : IValueConverter
    {
        string checkString = string.Empty;
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Span span = parameter as Span;
            Color color = Color.Transparent;
            if ((StepStatus)value == StepStatus.Completed)
            {
                color = Color.Black;
            }

            return color;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Color)value == Color.Black;
        }
    }
}