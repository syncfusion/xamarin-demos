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

        public GettingStarted()
        {
            InitializeComponent();
            trainProgress.TitleSpace = 25;
            DateTime toStartTime;
            DateTime.TryParse("7:15:00 AM", out toStartTime);
            double timeDiff = DateTime.Now.Subtract(toStartTime).TotalSeconds;
            viewModel.PopulationStationTimeTable(timeDiff);
            BindableLayout.SetItemsSource(trainProgress, viewModel.StationInfoCollection);
            PopulateStepViews();
        }

        private async void PopulateStepViews()
        {
            while (true)
            {
                for (int i = 0; i < viewModel.StationInfoCollection.Count; i++)
                {
                    if (viewModel.StationInfoCollection[i].Status == StepStatus.InProgress)
                        this.upComingStationLabel.Text = viewModel.StationInfoCollection[i].Name + viewModel.NextStationTime;
                }
                await Task.Delay(1000);
            }
        }
    }

    public class StationViewModel
    {
        Station station;
        private ObservableCollection<Station> stationInfoCollection = new ObservableCollection<Station>();
        internal ObservableCollection<DummyStation> tempCollection = new ObservableCollection<DummyStation>();

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
            trainStartTimeDiff = startTimeDiff;
            this.PopulateViewModel();
            for (int i = 0; i < tempCollection.Count; i++)
            {
                DummyStation dummyStation = tempCollection[i];
                StationInfoCollection.Add(CreateStationInfo(dummyStation.Name, dummyStation.ToArrival, dummyStation.ToDistance, dummyStation.FromArrival, i, dummyStation.FromDistance));
            }
        }

        public void PopulateViewModel()
        {
            if (tempCollection.Count == 0)
            {
                tempCollection.Add(new DummyStation() { Name = "New York, NY", ToArrival = "7:15:00 AM", ToDistance = 0, FromArrival = "7 15:00 PM", FromDistance = 0 });
                tempCollection.Add(new DummyStation() { Name = "Yonkers, NY", ToArrival = "7:44:00 AM", ToDistance = 14, FromArrival = "7 15:00 PM", FromDistance = 0 });
                tempCollection.Add(new DummyStation() { Name = "Croton-Harmon, NY", ToArrival = "8:03:00 AM", ToDistance = 32, FromArrival = "7 15:00 PM", FromDistance = 0 });
                tempCollection.Add(new DummyStation() { Name = "Poughkeepsie, NY", ToArrival = "8:53:00 AM", ToDistance = 76, FromArrival = "7 15:00 PM", FromDistance = 0 });
                tempCollection.Add(new DummyStation() { Name = "Rhinecliff, NY", ToArrival = "8:57:00 AM", ToDistance = 81, FromArrival = "7 15:00 PM", FromDistance = 0 });
                tempCollection.Add(new DummyStation() { Name = "Hudson, NY", ToArrival = "9:18:00 AM", ToDistance = 114, FromArrival = "7 15:00 PM", FromDistance = 0 });
                tempCollection.Add(new DummyStation() { Name = "Albany-Rensselaer", ToArrival = "9:50:00 AM", ToDistance = 141, FromArrival = "7 15:00 PM", FromDistance = 0 });
                tempCollection.Add(new DummyStation() { Name = "Schenectady, NY", ToArrival = "10:24:00 AM", ToDistance = 159, FromArrival = "7 15:00 PM", FromDistance = 0 });
                tempCollection.Add(new DummyStation() { Name = "Amsterdam, NY", ToArrival = "10:44:00 AM", ToDistance = 177, FromArrival = "7 15:00 PM", FromDistance = 0 });
                tempCollection.Add(new DummyStation() { Name = "Utica, NY", ToArrival = "11:41:00 AM", ToDistance = 237, FromArrival = "7 15:00 PM", FromDistance = 0 });
                tempCollection.Add(new DummyStation() { Name = "Rome, NY", ToArrival = "11:54:00 AM", ToDistance = 250, FromArrival = "7 15:00 PM", FromDistance = 0 });
                tempCollection.Add(new DummyStation() { Name = "Syracuse, NY", ToArrival = "12:43:00 PM", ToDistance = 291, FromArrival = "7 15:00 PM", FromDistance = 0 });
                tempCollection.Add(new DummyStation() { Name = "Rochester, NY", ToArrival = "1:55:00 PM", ToDistance = 370, FromArrival = "7 15:00 PM", FromDistance = 0 });
                tempCollection.Add(new DummyStation() { Name = "Buffalo-Depew, NY", ToArrival = "3:01:00 PM", ToDistance = 431, FromArrival = "7 15:00 PM", FromDistance = 0 });
                tempCollection.Add(new DummyStation() { Name = "Buffalo-Exchange St., NY", ToArrival = "3:14:00 PM", ToDistance = 437, FromArrival = "7 15:00 PM", FromDistance = 0 });
                tempCollection.Add(new DummyStation() { Name = "Niagara Falls, NY", ToArrival = "4:26:00 PM", ToDistance = 460, FromArrival = "7 15:00 PM", FromDistance = 0 });
                tempCollection.Add(new DummyStation() { Name = "Niagara Falls, ON", ToArrival = "4:33:00 PM", ToDistance = 462, FromArrival = "7 15:00 PM", FromDistance = 0 });
                tempCollection.Add(new DummyStation() { Name = "St. Catharines, ON", ToArrival = "5:08:00 PM", ToDistance = 473, FromArrival = "7 15:00 PM", FromDistance = 0 });
                tempCollection.Add(new DummyStation() { Name = "Grimsby, ON", ToArrival = "5:27:00 PM", ToDistance = 488, FromArrival = "7 15:00 PM", FromDistance = 0 });
                tempCollection.Add(new DummyStation() { Name = "Toronto, ON", ToArrival = "6:40:00 PM", ToDistance = 544, FromArrival = "7 15:00 PM", FromDistance = 0 });
            }
        }

        StepStatus lastStationStatus;

        private DateTime SetTrainTiming(DateTime dateTime)
        {
            return dateTime.AddSeconds(trainStartTimeDiff - 6090);
        }

        public Station CreateStationInfo(string name, string toArrrival, double toDistance, string froArrrival, int index, double froDistance = 0)
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

            station = new Station()
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
                CalcuateProgressedPercentage(dateTimeArr, station, index);
            }
            else
            {
                station.ProgressedDistance = 0;
            }

            previousStationDepaturedTime = dateTimeArr.AddMinutes(2);

            return station;
        }

        private DateTime previousStationDepaturedTime;

        private async void CalcuateProgressedPercentage(DateTime upcomingStationDepaturedTime, Station station, int index)
        {
            station.ProgressedDistance = 0;

            DateTime lastStationDepaturedTime = previousStationDepaturedTime;
            while (station.ProgressedDistance < 100)
            {
                var actualDurationDifference = upcomingStationDepaturedTime.Subtract(lastStationDepaturedTime).TotalMinutes;

                var currentDurationDifference = DateTime.Now.Subtract(lastStationDepaturedTime).TotalMinutes;
                var timeDifference = DateTime.Now.Subtract(station.ArrivalDateTime).TotalSeconds;
                station.ProgressedDistance = (currentDurationDifference / actualDurationDifference) * 100;
                if (StationInfoCollection.Count > index && StationInfoCollection[index].ProgressedDistance < station.ProgressedDistance)
                    StationInfoCollection[index].ProgressedDistance = station.ProgressedDistance;
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

            for (int i = 0; i < tempCollection.Count; i++)
            {
                DummyStation s = tempCollection[i];
                Station tempStation = CreateStationInfo(s.Name, s.ToArrival, s.ToDistance, s.FromArrival, i, s.FromDistance);
                Station currentStation = StationInfoCollection[i];
                if (currentStation.ProgressedDistance != tempStation.ProgressedDistance)
                    StationInfoCollection[i].ProgressedDistance = tempStation.ProgressedDistance;
                if (currentStation.Status != tempStation.Status)
                    StationInfoCollection[i].Status = tempStation.Status;
            }
        }
    }

    public class DummyStation
    {
        public string Name { get; set; }
        public string ToArrival { get; set; }
        public double ToDistance { get; set; }
        public string FromArrival { get; set; }
        public double FromDistance { get; set; }
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