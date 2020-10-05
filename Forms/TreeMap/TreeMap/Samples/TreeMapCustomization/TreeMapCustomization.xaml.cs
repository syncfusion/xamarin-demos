#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfTreeMap.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfTreeMap
{
    [Preserve(AllMembers = true)]
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TreeMapCustomization : SampleView
    {
        public TreeMapCustomization()
        {
            InitializeComponent();
            this.TreeMap.DataSource = new OlymicMedalsViewModel().OlympicMedalsDetails;
            UniColorMapping uniMapping = new UniColorMapping() { Color = Color.FromHex("#D21243") };
        }
    }
}
