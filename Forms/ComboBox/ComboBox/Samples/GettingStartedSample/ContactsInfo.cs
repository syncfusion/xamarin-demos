#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace SampleBrowser.SfComboBox
{
	[Preserve(AllMembers = true)]
	public class SizeInfo : INotifyPropertyChanged
	{

		#region Fields

		private string sizeList;

		#endregion

		#region Constructor

		public SizeInfo()
		{

		}

		#endregion

		#region Public Properties

		public string SizeList
		{
			get { return this.sizeList; }
			set
			{
				this.sizeList = value;
				RaisePropertyChanged("SizeList");
			}
		}


		#endregion

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		private void RaisePropertyChanged(String name)
		{
			if (PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(name));
		}

		#endregion
	}
	public class SizeInfo1 : INotifyPropertyChanged
	{
		#region Fields

		private string resolutionList;


		#endregion

		#region Constructor

		public SizeInfo1()
		{

		}

		#endregion

		#region Public Properties


		public string ResolutionList
		{
			get { return resolutionList; }
			set
			{
				this.resolutionList = value;
				RaisePropertyChanged("ResolutionList");
			}
		}



		#endregion

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		private void RaisePropertyChanged(String name)
		{
			if (PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(name));
		}

		#endregion
	}
	public class SizeInfo2 : INotifyPropertyChanged
	{
		#region Fields


		private string orientationList;


		#endregion

		#region Constructor

		public SizeInfo2()
		{

		}

		#endregion

		#region Public Properties



		public string OrientationList
		{
			get { return orientationList; }
			set
			{
				this.orientationList = value;
				RaisePropertyChanged("OrientationList");
			}
		}



		#endregion

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		private void RaisePropertyChanged(String name)
		{
			if (PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(name));
		}

		#endregion
	}
}