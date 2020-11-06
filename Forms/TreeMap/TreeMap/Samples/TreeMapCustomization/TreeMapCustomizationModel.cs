#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfTreeMap
{
   [Preserve(AllMembers = true)]
    public class OlympicMedals
    {
        public string Country { get; set; }
        public string GameName { get; set; }
        public double GoldMedals { get; set; }
        public double SilverMedals { get; set; }
        public double BronzeMedals { get; set; }
        public double TotalMedals { get; set; }
        public ImageSource GameImgSource { get; set; }
        private string imagename;
        public string ImageName
        {

            get { return imagename; }
            set
            {
                imagename = value;
                if (Device.RuntimePlatform == Device.UWP)
                {
#if COMMONSB
                    GameImgSource = ImageSource.FromResource("SampleBrowser.Icons." + imagename, typeof(OlympicMedals).GetTypeInfo().Assembly);
#else
                    GameImgSource = ImageSource.FromResource("SampleBrowser.SfTreeMap.Icons." + imagename, typeof(OlympicMedals).GetTypeInfo().Assembly);
#endif
                }
                else
                {
#if COMMONSB
                    GameImgSource = ImageSource.FromResource("SampleBrowser.Icons." + imagename);
#else
                    GameImgSource = ImageSource.FromResource("SampleBrowser.SfTreeMap.Icons." + imagename);
#endif
                }
            }
        }



    }
}
