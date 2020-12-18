#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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
using Xamarin.Forms;

namespace SampleBrowser
{
	internal class RotatorViewModel
	{
		public RotatorViewModel()
		{
			if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
			{
				ImageCollection.Add(new RotatorModel("Duck0.png"));
				ImageCollection.Add(new RotatorModel("Duck1.png"));
				ImageCollection.Add(new RotatorModel("Duck2.png"));
				ImageCollection.Add(new RotatorModel("Duck3.png"));
				ImageCollection.Add(new RotatorModel("Duck4.png"));
				ImageCollection.Add(new RotatorModel("Duck5.png"));
			}
		}
		private List<RotatorModel> imageCollection = new List<RotatorModel>();

		public List<RotatorModel> ImageCollection
		{
			get { return imageCollection; }
			set { imageCollection = value; }
		}

	}



}



