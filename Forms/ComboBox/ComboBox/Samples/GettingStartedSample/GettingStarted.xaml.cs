#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfComboBox
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GettingStarted : SampleView
    {
		public GettingStarted ()
		{
			InitializeComponent ();
            if (Device.RuntimePlatform == Device.WPF)
            {
              this.PropertyView = GettingStartedWPF.PropertyView;
            }
            else
            {
                this.PropertyView = GettingStartedDefault.PropertyView;
            }
        }
	}
}