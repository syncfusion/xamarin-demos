#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfStepProgressBar
{
	public partial class GettingStarted : SampleView
	{
        StationViewModel viewModel = new StationViewModel();

        public GettingStarted ()
		{
			InitializeComponent ();
            trainProgress.TitleSpace = 25;
            DateTime toStartTime;
            DateTime.TryParse("7:15:00 AM", out toStartTime);
            double timeDiff = DateTime.Now.Subtract(toStartTime).TotalSeconds;
            viewModel.PopulationStationTimeTable(timeDiff);
            PopulateStepViews();
        }

        private async void PopulateStepViews()
        {
            while (true)
            {
                for (int i = 0; i < viewModel.StationInfoCollection.Count; i++)
                {
                    this.trainProgress.Children[i].BindingContext = viewModel.StationInfoCollection[i];
                    if (viewModel.StationInfoCollection[i].Status == StepStatus.InProgress)
                        this.upComingStationLabel.Text = viewModel.StationInfoCollection[i].Name  + viewModel.NextStationTime;
                }
                await Task.Delay(1000);
            }
        }

    }
    public class StationViewModel
    {
        private ObservableCollection<Station> stationInfoCollection = new ObservableCollection<Station>();

        public ObservableCollection<Station> StationInfoCollection
        {
            get
            {
                return stationInfoCollection;
            }
            set
            {
                stationInfoCollection = value;
            }
        }

        private string nextStationTime;

        public string NextStationTime
        {
            get { return nextStationTime; }
            set { nextStationTime = value; }
        }

        public StationViewModel()
        {
        }

        private double trainStartTimeDiff;

        public void PopulationStationTimeTable(double startTimeDiff)
        {
            StationInfoCollection.Clear();
            trainStartTimeDiff = startTimeDiff;
            StationInfoCollection.Add(CreateStationInfo("New York, NY", "7:15:00 AM", 0, "7 15:00 PM", 0));
            StationInfoCollection.Add(CreateStationInfo("Yonkers, NY", "7:44:00 AM", 14, "7 15:00 PM", 0));
            StationInfoCollection.Add(CreateStationInfo("Croton-Harmon, NY", "8:03:00 AM", 32, "7 15:00 PM", 0));
            StationInfoCollection.Add(CreateStationInfo("Poughkeepsie, NY", "8:53:00 AM", 76, "7 15:00 PM", 0));
            StationInfoCollection.Add(CreateStationInfo("Rhinecliff, NY", "8:57:00 AM", 81, "7 15:00 PM", 0));
            StationInfoCollection.Add(CreateStationInfo("Hudson, NY", "9:18:00 AM", 114, "7 15:00 PM", 0));
            StationInfoCollection.Add(CreateStationInfo("Albany-Rensselaer", "9:50:00 AM", 141, "7 15:00 PM", 0));
            StationInfoCollection.Add(CreateStationInfo("Schenectady, NY", "10:24:00 AM", 159, "7 15:00 PM", 0));
            StationInfoCollection.Add(CreateStationInfo("Amsterdam, NY", "10:44:00 AM", 177, "7 15:00 PM", 0));
            StationInfoCollection.Add(CreateStationInfo("Utica, NY", "11:41:00 AM", 237, "7 15:00 PM", 0));
            StationInfoCollection.Add(CreateStationInfo("Rome, NY", "11:54:00 AM", 250, "7 15:00 PM", 0));
            StationInfoCollection.Add(CreateStationInfo("Syracuse, NY", "12:43:00 PM", 291, "7 15:00 PM", 0));
            StationInfoCollection.Add(CreateStationInfo("Rochester, NY", "1:55:00 PM", 370, "7 15:00 PM", 0));
            StationInfoCollection.Add(CreateStationInfo("Buffalo-Depew, NY", "3:01:00 PM", 431, "7 15:00 PM", 0));
            StationInfoCollection.Add(CreateStationInfo("Buffalo-Exchange St., NY", "3:14:00 PM", 437, "7 15:00 PM", 0));
            StationInfoCollection.Add(CreateStationInfo("Niagara Falls, NY", "4:26:00 PM", 460, "7 15:00 PM", 0));
            StationInfoCollection.Add(CreateStationInfo("Niagara Falls, ON", "4:33:00 PM", 462, "7 15:00 PM", 0));
            StationInfoCollection.Add(CreateStationInfo("St. Catharines, ON", "5:08:00 PM", 473, "7 15:00 PM", 0));
            StationInfoCollection.Add(CreateStationInfo("Grimsby, ON", "5:27:00 PM", 488, "7 15:00 PM", 0));
            StationInfoCollection.Add(CreateStationInfo("Toronto, ON", "6:40:00 PM", 544, "7 15:00 PM", 0));
        }

        StepStatus lastStationStatus;

        private DateTime SetTrainTiming(DateTime dateTime)
        {
            return dateTime.AddSeconds(trainStartTimeDiff-6090);
        }

        public Station CreateStationInfo(string name, string toArrrival, double toDistance, string froArrrival, double froDistance = 0)
        {
            DateTime dateTimeArr;

            DateTime toStartTime;
            DateTime.TryParse("7:00:00 AM", out toStartTime);
            DateTime toEndTime;
            DateTime.TryParse("7:00:00 PM", out toEndTime);

            StepStatus currentStatus = StepStatus.NotStarted;

            DateTime.TryParse(toArrrival, out dateTimeArr);
            dateTimeArr = SetTrainTiming(dateTimeArr);

            if (lastStationStatus == StepStatus.Completed)
            {
                currentStatus = StepStatus.InProgress;
            }
            if (dateTimeArr <= DateTime.Now)
            {
                currentStatus = StepStatus.Completed;
            }

            lastStationStatus = currentStatus;

            var station =  new Station()
            {
                Name = name,
                Arrival = dateTimeArr.TimeOfDay.ToString().Remove(5),
                Depature = dateTimeArr.AddMinutes(2).TimeOfDay.ToString().Remove(5),
                ArrivalDateTime = dateTimeArr,
                DepatureDateTime = dateTimeArr.AddMinutes(2),
                Distance = "Station at " + toDistance.ToString() + " Miles",
                Status = currentStatus
            };

            if (station.Status == StepStatus.Completed)
            {
                station.ProgressedDistance = 100;
            }
            else if (station.Status == StepStatus.InProgress)
            {
                CalcuateProgressedPercentage(dateTimeArr,station);
            }
            else
            {
                station.ProgressedDistance = 0;
            }

            previousStationDepaturedTime = dateTimeArr.AddMinutes(2);

            return station;
        }

        private DateTime previousStationDepaturedTime;

        private async void CalcuateProgressedPercentage( DateTime upcomingStationDepaturedTime, Station station)
        {
            station.ProgressedDistance = 0;

            DateTime lastStationDepaturedTime = previousStationDepaturedTime;
           while (station.ProgressedDistance <= 100)
            {
                var actualDurationDifference = upcomingStationDepaturedTime.Subtract(lastStationDepaturedTime).TotalMinutes;

                var currentDurationDifference = DateTime.Now.Subtract(lastStationDepaturedTime).TotalMinutes;
                var timeDifference = DateTime.Now.Subtract(station.ArrivalDateTime).TotalSeconds;
                station.ProgressedDistance =   (currentDurationDifference / actualDurationDifference) * 100;
                DateTime diffStationTime;
                DateTime.TryParse("0:00:00 AM", out diffStationTime);
                diffStationTime = diffStationTime.AddSeconds((-timeDifference));
                NextStationTime = ", in ";
                if (diffStationTime.Minute > 0)
                {
                    NextStationTime += diffStationTime.Minute.ToString() + " Minute(s)";
                }
                else
                {
                    NextStationTime += diffStationTime.Second.ToString() + " Second(s)";
                }
                await Task.Delay(1000);
            }

            PopulationStationTimeTable(trainStartTimeDiff);


        }
    }

    public class Station : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    RaisePropertyChange();
                }
            }
        }


        private string arrival;
        public string Arrival
        {
            get
            {
                return arrival;
            }
            set
            {
                if (arrival != value)
                {
                    arrival = value;
                    RaisePropertyChange();
                }
            }
        }

        private DateTime arrivalDateTime;
        public DateTime ArrivalDateTime
        {
            get
            {
                return arrivalDateTime;
            }
            set
            {
                if (arrivalDateTime != value)
                {
                    arrivalDateTime = value;
                    RaisePropertyChange();
                }
            }
        }

        private DateTime depatureDateTime;
        public DateTime DepatureDateTime
        {
            get
            {
                return depatureDateTime;
            }
            set
            {
                if (depatureDateTime != value)
                {
                    depatureDateTime = value;
                    RaisePropertyChange();
                }
            }
        }

        private string depature;

        public string Depature
        {
            get
            {
                return depature;
            }
            set
            {
                if (depature != value)
                {
                    depature = value;
                    RaisePropertyChange();
                }
            }
        }

        private double progressDistance = 0;

        public double ProgressedDistance
        {
            get
            {
                return progressDistance;
            }
            set
            {
                if (progressDistance != value)
                {
                    progressDistance = value;
                    RaisePropertyChange("Status");
                    RaisePropertyChange();
                }
            }
        }


        private string distance;

        public string Distance
        {
            get
            {
                return distance;
            }
            set
            {
                if (distance != value)
                {
                    distance = value;
                    RaisePropertyChange();
                }
            }
        }

        private StepStatus status;

        public StepStatus Status
        {
            get
            {
                return status;
            }
            set
            {
                if (status != value)
                {
                    status = value;          
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


    public class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Color.Green;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class StatusToTextVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((DateTime)value > DateTime.Now)
            {
                return Color.FromHex("#4A515E");
            }
            return Color.FromHex("#219F06");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}