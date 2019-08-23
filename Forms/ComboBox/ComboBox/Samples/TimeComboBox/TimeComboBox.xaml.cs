#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using SampleBrowser.Core;
using System.Linq;
using Xamarin.Forms;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace SampleBrowser.SfComboBox
{
    public partial class TimeComboBox : SampleView, INotifyPropertyChanged
    {
        public TimeComboBox()
        {
            InitializeComponent();
            Source = new ViewModelComboBox().GetCountryDetails();
            Source1 = new ViewModelComboBox().GetColor();
			this.BindingContext = this;
            comboBox.SelectedItem = Source[0];
            comboBox1.SelectedItem = Source1[1];

        }


        public ObservableCollection<ModelComboBox> Source { get; set; }
        public ObservableCollection<ModelComboBox> Source1 { get; set; }

        public ModelComboBox selectedItem;
        public ModelComboBox SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedItem"));
                }

            }
        }

        public ModelComboBox selectedItem1;

        public ModelComboBox SelectedItem1
        {
            get
            {
                return selectedItem1;
            }
            set
            {
                selectedItem1 = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SelectedItem1"));
                }

            }
        }

        public new event PropertyChangedEventHandler PropertyChanged;
    }


    public class ViewModelComboBox
    {
        List<Color> Colors = new List<Color>();
        public string countryTime;
        //public int UTC;
        public ViewModelComboBox()
        {
            Colors.Add(Color.LightGray);
            Colors.Add(Color.SkyBlue);
            Colors.Add(Color.Green);
            Colors.Add(Color.RosyBrown);
            Colors.Add(Color.Lime);
            Colors.Add(Color.Pink);
            Colors.Add(Color.Gold);
            Colors.Add(Color.BlueViolet);
            Colors.Add(Color.LawnGreen);
            Colors.Add(Color.Violet);
            Colors.Add(Color.Tomato);
            Colors.Add(Color.Orange);
            Colors.Add(Color.MediumVioletRed);
            Colors.Add(Color.Plum);
            Colors.Add(Color.Purple);
            Colors.Add(Color.CornflowerBlue);
            Colors.Add(Color.RosyBrown);
            Colors.Add(Color.RoyalBlue);
            Colors.Add(Color.OrangeRed);
            Colors.Add(Color.Orchid);
            Colors.Add(Color.ForestGreen);
            Colors.Add(Color.Gray);
            Colors.Add(Color.Red);
            Colors.Add(Color.Brown);
            Colors.Add(Color.Purple);
            Colors.Add(Color.CornflowerBlue);
            Colors.Add(Color.GreenYellow);
            Colors.Add(Color.RoyalBlue);
            Colors.Add(Color.OrangeRed);
            Colors.Add(Color.Orchid);
            Colors.Add(Color.ForestGreen);
            Colors.Add(Color.Gray);
            Colors.Add(Color.DeepPink);
            Colors.Add(Color.Brown);
        }
        public ObservableCollection<ModelComboBox> GetCountryDetails()
        {
            ObservableCollection<ModelComboBox> countryDetails = new ObservableCollection<ModelComboBox>();

            for (int i = 0; i < country.Count(); i++)
            {
                var details = new ModelComboBox()
                {
                    Country = country[i],
                    CountryUTC = countryUTC[i],
                    Time = time[i],
                };
                countryDetails.Add(details);
            }
            return countryDetails;
        }
        public ObservableCollection<ModelComboBox> GetColor()
        {
            ObservableCollection<ModelComboBox> color = new ObservableCollection<ModelComboBox>();

            string space = " ";
            for (int i = 0; i < 15; i++)
            {
                space += space;
                var details = new ModelComboBox()
                {
                    Color = Colors[i],
                    Country = space,
                };
                color.Add(details);
            }
            return color;
        }

        string[] country = new string[]
        {

            "International Date Line West",
			"Coordinated Universal Time-11",
			"Aleutian Islands",
			"Hawaii",
			"Marquesas Islands",
			"Alaska",
			"Coordinated Universal Time-09",
			"Baja California",
			"Coordinated Universal Time-08",
			"PacificTime(US & Canada)",
			"Arizona",
			"Chihuahua,La Paz, Mazatlan",
			"Mountain Time (Us & Canada)",
			"Centeral America",
			"Centera Time (US & Canada)",
			"Easter Island",
			"Guadalajara, Mexico City,Monterrey",
			"Saskatchewan",
			"Bogota,Lima,Quito,Rio Branco",
			"Chetumal",
			"Eastern Time (US & Canada)",
			"Haiti",
			"Havana",
			"Indiana (East)",
			"Asuncion",
			"Atlantic Time (Canada)",
			"Caracas",
			"Cuiaba",
			"Georgetown,LaPaz, Manaus, San Juan",
			"Santiago",
			"Turks and Caicos",
			"Newfoundland",
			"Araguaina",
			"Brasilia",
			"Cayenne, Fortaleza",
			"City of Buenos Aires",
			"GreenLand",
			"Montevideo",
			"Punta Arenas",
			"Saint Pierre and Miquelon",
			"Salvador",
			"Coordinated Universal Time-02",
			"Azores",
			"Cabo Verde Is",
			"Coordinated Universal Time",
			"Casablanca",
			"Dublin, Edinburgh, Lisbon, London",
			"Monrovia, Reykjavik",
			"Asterdam, Berlin, Rome",
			"Belgrade, Prague",
			"Brussels, Madrid, Paris",
			"Sarajevo, Zagreb",
			"West Central Africa",
			"Windhoek",
			"Amman",
			"Athens, Bucharest",
			"Beirut",
			"Cairo",
			"Chisinau",
			"Damascus",
			"Gaza, Hebron",
			"Harare, Pretoria",
			"Helsinki, Riga, Sofia",
			"Jerusalem",
			"Kaliningrad",
			"Tripoli",
			"Baghdad",
			"Istanbul",
			"Kuwait",
			"Minsk",
			"Moscow",
			"Nairobi",
			"Tehran",
			"Abu Dhabi, Muscat",
			"Astrakhan, Ulyanovsk",
			"Baku",
			"Samara",
			"Port Louis",
			"Saratov",
			"Tbilisi",
			"Yerevan",
			"Kabul",
			"Ashgabat,Tashkent",
			"Ekaterinburg",
			"Karachi, Islamabad",
			"Chennai, Kolkata, Mumbai, New Delhi",
			"Sri Jayawardenepura",
			"Kathmandu",
			"Astana",
			"Dhaka",
			"Omsk",
			"Yagon (Rangoon)",
			"Bangkok, Hanoi, Jakarata",
			"Barnaul, Gorno-Altaysk",
			"Hovd",
			"Krasnoyarsk",
			"Novosibirsk",
			"Tomsk",
			"Beijing, HongKong",
			"Irkutsk",
			"kuala Lumpur, Singapore",
			"Perth",
			"Taipei",
			"Ulaanbaatar",
			"Pyongyang",
			"Eucla",
			"Chita",
			"Osaka, Tokyo",
			"Seoul",
			"Yakutsk",
			"Adelaide",
			"Darwin",
			"Brisbane",
			"Melbourne,Sydney",
			"Guam, Port Moresby",
			"HoBart",
			"Vladivostok",
			"Lord Howe Island",
			"Bougainville Island",
			"Chokurdakh",
			"Magadan",
			"Norfolk Island",
			"Sakhalin",
			"Solomon Is., New Caledonia",
			"Anadyr",
			"Auckland, Wellington",
			"Coordinated Universal Time+12",
			"Fiji",
			"Chatham Islands",
			"Coordinated Universal Time+13",
			"Nuku'alofa",
			"Samoa",
			"kiritimati Island",
        };

        string[] countryUTC = new string[]
        {

            "UTC-12:00",
			"UTC-11:00",
			"UTC-10:00",
			"UTC-10:00",
			"UTC-09:30",
			"UTC-09:00",
			"UTC-09:00",
			"UTC-08:00",
			"UTC-08:00",
			"UTC-08:00",
			"UTC-07:00",
			"UTC-07:00",
			"UTC-07:00",
			"UTC-06:00",
			"UTC-06:00",
			"UTC-06:00",
			"UTC-06:00",
			"UTC-06:00",
			"UTC-05:00",
			"UTC-05:00",
			"UTC-05:00",
			"UTC-05:00",
			"UTC-05:00",
			"UTC-05:00",
			"UTC-04:00",
			"UTC-04:00",
			"UTC-04:00",
			"UTC-04:00",
			"UTC-04:00",
			"UTC-04:00",
			"UTC-04:00",
			"UTC-03:30",
			"UTC-03:00",
			"UTC-03:00",
			"UTC-03:00",
			"UTC-03:00",
			"UTC-03:00",
			"UTC-03:00",
			"UTC-03:00",
			"UTC-03:00",
			"UTC-03:00",
			"UTC-02:00",
			"UTC-01:00",
			"UTC-01:00",
			"UTC+00:00",
			"UTC+00:00",
			"UTC+00:00",
			"UTC+00:00",
			"UTC+01:00",
			"UTC+01:00",
			"UTC+01:00",
			"UTC+01:00",
			"UTC+01:00",
			"UTC+01:00",
			"UTC+02:00",
			"UTC+02:00",
			"UTC+02:00",
			"UTC+02:00",
			"UTC+02:00",
			"UTC+02:00",
			"UTC+02:00",
			"UTC+02:00",
			"UTC+02:00",
			"UTC+02:00",
			"UTC+02:00",
			"UTC+02:00",
			"UTC+03:00",
			"UTC+03:00",
			"UTC+03:00",
			"UTC+03:00",
			"UTC+03:00",
			"UTC+03:00",
			"UTC+03:30",
			"UTC+04:00",
			"UTC+04:00",
			"UTC+04:00",
			"UTC+04:00",
			"UTC+04:00",
			"UTC+04:00",
			"UTC+04:00",
			"UTC+04:00",
			"UTC+04:30",
			"UTC+05:00",
			"UTC+05:00",
			"UTC+05:00",
			"UTC+05:30",
			"UTC+05:30",
			"UTC+05:45",
			"UTC+06:00",
			"UTC+06:00",
			"UTC+06:00",
			"UTC+06:30",
			"UTC+07:00",
			"UTC+07:00",
			"UTC+07:00",
			"UTC+07:00",
			"UTC+07:00",
			"UTC+07:00",
			"UTC+08:00",
			"UTC+08:00",
			"UTC+08:00",
			"UTC+08:00",
			"UTC+08:00",
			"UTC+08:00",
			"UTC+08:30",
			"UTC+08:30",
			"UTC+09:00",
			"UTC+09:00",
			"UTC+09:00",
			"UTC+09:00",
			"UTC+09:30",
			"UTC+09:30",
			"UTC+10:00",
			"UTC+10:00",
			"UTC+10:00",
			"UTC+10:00",
			"UTC+10:00",
			"UTC+10:30",
			"UTC+11:00",
			"UTC+11:00",
			"UTC+11:00",
			"UTC+11:00",
			"UTC+11:00",
			"UTC+11:00",
			"UTC+12:00",
			"UTC+12:00",
			"UTC+12:00",
			"UTC+12:00",
			"UTC+12:45",
			"UTC+13:00",
			"UTC+13:00",
			"UTC+13:00",
			"UTC+14:00",

        };

        double[] time = new double[]
        {

            -12,
            -11,
            -10,
            -10,
            -09.30,
            -09,
            -09,
            -08,
            -08,
            -08,
            -07,
            -07,
            -07,
            -06,
            -06,
            -06,
            -06,
            -06,
            -05,
            -05,
            -05,
            -05,
            -05,
            -05,
            -04,
            -04,
            -04,
            -04,
            -04,
            -04,
            -04,
            -03.30,
            -03,
            -03,
            -03,
            -03,
            -03,
            -03,
            -03,
            -03,
            -03,
            -02,
            -01,
            -01,
            +00,
            +00,
            +00,
            +00,
            +01,
            +01,
            +01,
            +01,
            +01,
            +01,
            +02,
            +02,
            +02,
            +02,
            +02,
            +02,
            +02,
            +02,
            +02,
            +02,
            +02,
            +02,
            +03,
            +03,
            +03,
            +03,
            +03,
            +03,
            +03.30,
            +04,
            +04,
            +04,
            +04,
            +04,
            +04,
            +04,
            +04,
            +04.30,
            +05,
            +05,
            +05,
            +05.30,
            +05.30,
            +05.45,
            +06,
            +06,
            +06,
            +06.30,
            +07,
            +07,
            +07,
            +07,
            +07,
            +07,
            +08,
            +08,
            +08,
            +08,
            +08,
            +08,
            +08.30,
            +08.30,
            +09,
            +09,
            +09,
            +09,
            +09.30,
            +09.30,
            +10,
            +10,
            +10,
            +10,
            +10,
            +10.30,
            +11,
            +11,
            +11,
            +11,
            +11,
            +11,
            +12,
            +12,
            +12,
            +12,
            +12.45,
            +13,
            +13,
            +13,
            +14,
        };

    }

    public class ModelComboBox : INotifyPropertyChanged
    {
        private string country;
        private string countryUTC;
        private double time;
        private Color color;
        private string countryTime;


        public ModelComboBox()
        {
            Device.StartTimer(new TimeSpan(0, 0, 0, 0, 1000), TimerElapsed);
        }
        private bool TimerElapsed()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                DateTime dt = timecal(DateTime.Now.TimeOfDay.ToString().Split('.')[0], Time);
                CountryTime = dt.TimeOfDay.ToString().Split('.')[0];

            });
            return true;
        }

        DateTime timecal(string IndiaTime, double timeDifference)
        {
            int td, tdh;
            var tdHours = (int)Math.Truncate(timeDifference);
            var tdMin = ((timeDifference - tdHours) * 100);
            var utcHours = (int)TimeZoneInfo.Local.BaseUtcOffset.Hours;
            var utcMin = (int)TimeZoneInfo.Local.BaseUtcOffset.Minutes;
            if (utcHours > tdHours)
            {
                tdh = (int)tdHours - utcHours;
                tdMin = (int)(tdMin - utcMin);
                td = (tdh * 60) + (int)tdMin;
            }
            else
            {
                tdh = (int)tdHours - utcHours;
                tdMin = (int)(tdMin - utcMin);
                td = (tdh * 60) + (int)tdMin;
            }
            string[] array1 = IndiaTime.Split(':');
            int timeinMinutes = Convert.ToInt32(array1[0]) * 60 + Convert.ToInt32(array1[1]);
            timeinMinutes = timeinMinutes + td;
            int minutes = Math.Abs(timeinMinutes % 60);
            int hour = Math.Abs(timeinMinutes / 60);
            if (hour >= 24)
                hour = Math.Abs(hour - 24);
            String finalTime = Convert.ToString(hour) + ":" + Convert.ToString(minutes) + ":" + Convert.ToString(DateTime.Now.Second);
            DateTime time = Convert.ToDateTime(finalTime);
            return time;
        }

        public string CountryTime
        {
            get
            {
                return countryTime;
            }

            set
            {
                countryTime = value;
                RaisePropertyChanged("CountryTime");
            }

        }
        public string Country
        {
            get { return this.country; }
            set
            {
                this.country = value;
                RaisePropertyChanged("Country");
            }
        }
        public string CountryUTC
        {
            get { return this.countryUTC; }
            set
            {
                this.countryUTC = value;
                RaisePropertyChanged("CountryUTC");
            }
        }

        public double Time
        {
            get { return time; }
            set
            {
                this.time = value;
                RaisePropertyChanged("Time");
            }
        }

        public Color Color
        {
            get { return color; }
            set
            {
                this.color = value;
                RaisePropertyChanged("Color");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(String name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
