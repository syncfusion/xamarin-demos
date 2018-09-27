#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;

using Xamarin.Forms;

namespace SampleBrowser
{
	class RotatorModel
	{
		public RotatorModel(string imagestr)
		{
			Image = imagestr;
		}
		private String _image;
		public String Image
		{
			get { return _image; }
			set { _image = value; }
		}
	}
}



