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
using System.Text;
using System.Threading.Tasks;
using SampleBrowser.Core;
using Syncfusion.XForms.ProgressBar;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SampleBrowser.SfProgressBar
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CircularRangeColors : SampleView
	{
		public CircularRangeColors ()
		{
			InitializeComponent ();
		    this.RangeColorProgressBar.AnimationDuration = 2000;
        }

        private void RangeColorProgressBar_ValueChanged(object sender, ProgressValueEventArgs e)
	    {
	        if (e.Progress.Equals(100))
	        {
	            this.RangeColorProgressBar.SetProgress(0, 0, Easing.Linear);
	        }

	        if (e.Progress.Equals(0))
	        {
	            this.RangeColorProgressBar.Progress = 100;
	        }
	    }
    }
}