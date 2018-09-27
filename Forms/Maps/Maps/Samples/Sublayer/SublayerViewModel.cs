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
using System.Text;

namespace SampleBrowser.SfMaps
{
    public class SublayerViewModel
    {
        public SublayerViewModel()
        {
            DataSource = new ObservableCollection<AgricultureData>();
            DataSource.Add(new AgricultureData("Alabama", "AL", 42));
            DataSource.Add(new AgricultureData("Alaska", "AK", 0));
            DataSource.Add(new AgricultureData("Arizona", "AR", 36));
            DataSource.Add(new AgricultureData("Arkansas", "AN", 46));
            DataSource.Add(new AgricultureData("California", "CA", 24));
            DataSource.Add(new AgricultureData("Colorado", "CO", 31));
            DataSource.Add(new AgricultureData("Connecticut", "CN", 18));
            DataSource.Add(new AgricultureData("Delaware", "DE", 28));
            DataSource.Add(new AgricultureData("District of Columbia", "DC", 27));
            DataSource.Add(new AgricultureData("Florida", "FL", 48));
            DataSource.Add(new AgricultureData("Georgia", "GE", 44));
            DataSource.Add(new AgricultureData("Hawaii", "HA", 49));
            DataSource.Add(new AgricultureData("Idaho", "ID", 8));
            DataSource.Add(new AgricultureData("Illinois", "IL", 26));
            DataSource.Add(new AgricultureData("Indiana", "IN", 21));
            DataSource.Add(new AgricultureData("Iowa", "IO", 13));
            DataSource.Add(new AgricultureData("Kansas", "KA", 33));
            DataSource.Add(new AgricultureData("Kentucky", "KE", 32));
            DataSource.Add(new AgricultureData("Louisiana", "LO", 47));
            DataSource.Add(new AgricultureData("Maine", "MA", 3));
            DataSource.Add(new AgricultureData("Maryland", "MY", 30));
            DataSource.Add(new AgricultureData("Massachusetts", "MS", 14));
            DataSource.Add(new AgricultureData("Michigan", "MI", 50));
            DataSource.Add(new AgricultureData("Minnesota", "MN", 10));
            DataSource.Add(new AgricultureData("Mississippi", "MP", 43));
            DataSource.Add(new AgricultureData("Missouri", "MO", 35));
            DataSource.Add(new AgricultureData("Montana", "MT", 2));
            DataSource.Add(new AgricultureData("Nebraska", "NE", 15));
            DataSource.Add(new AgricultureData("Nevada", "NV", 22));
            DataSource.Add(new AgricultureData("New Hampshire", "NH", 12));
            DataSource.Add(new AgricultureData("New Jersey", "NJ", 20));
            DataSource.Add(new AgricultureData("New Mexico", "NM", 41));
            DataSource.Add(new AgricultureData("New York", "NY", 16));
            DataSource.Add(new AgricultureData("North Carolina", "NC", 38));
            DataSource.Add(new AgricultureData("North Dakota", "ND", 4));
            DataSource.Add(new AgricultureData("Ohio", "OH", 25));
            DataSource.Add(new AgricultureData("Oklahoma", "OK", 37));
            DataSource.Add(new AgricultureData("Oregon", "OR", 11));
            DataSource.Add(new AgricultureData("Pennsylvania", "PE", 17));
            DataSource.Add(new AgricultureData("Rhode Island", "RH", 19));
            DataSource.Add(new AgricultureData("South Carolina", "SC", 45));
            DataSource.Add(new AgricultureData("South Dakota", "SD", 5));
            DataSource.Add(new AgricultureData("Tennessee", "TE", 39));
            DataSource.Add(new AgricultureData("Texas", "TX", 40));
            DataSource.Add(new AgricultureData("Utah", "UT", 23));
            DataSource.Add(new AgricultureData("Vermont", "VE", 9));
            DataSource.Add(new AgricultureData("Virginia", "VI", 34));
            DataSource.Add(new AgricultureData("Washington", "WA", 1));
            DataSource.Add(new AgricultureData("West Virginia", "WE", 29));
            DataSource.Add(new AgricultureData("Wisconsin", "WI", 7));
            DataSource.Add(new AgricultureData("Wyoming", "WY", 6));
        }
        public ObservableCollection<AgricultureData> DataSource { get; set; }
    }

}
