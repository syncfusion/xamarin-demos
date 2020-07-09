#region Copyright Syncfusion Inc. 2001 - 2020.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfSunburstChart
{
   [Preserve(AllMembers = true)]
    public class SunburstModel
    {
        public string JobDescription { get; set; }
        public string JobGroup { get; set; }
        public string JobRole { get; set; }
        public double EmployeesCount { get; set; }  
        public string Country { get; set; }

        public string Quarter { get; set; }
        public string Month { get; set; }
        public string Week { get; set; }
        public double Sales { get; set; }

        public string Continent { get; set; }  
        public string State { get; set; }
        public double Population { get; set; }
    }
}
