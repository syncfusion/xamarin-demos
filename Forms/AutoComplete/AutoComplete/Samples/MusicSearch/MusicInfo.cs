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

namespace SampleBrowser.SfAutoComplete
{
	[Preserve(AllMembers = true)]
	public class MusicInfo : INotifyPropertyChanged
	{
		#region Fields

		private string songTitle;
		private string songAuther;
		private Color songTheme;
		private Color currentColor;
		private string songSize;
		private string songLength;
		private String songThumbnail;
		private ImageSource selectedImage;
		private ImageSource notselectedImage;
		private bool isSelected;

		#endregion

		#region Properties

		public Color SongTheme
		{
			get
			{
				return songTheme;
			}
			set
			{
				songTheme = value;
				this.RaisePropertyChanged("SongTheme");
			}
		}

		public Color CurrentColor
		{
			get
			{
				return currentColor;
			}
			set
			{
				currentColor = value;
				this.RaisePropertyChanged("CurrentColor");
			}
		}

		/// <summary>
		/// Gets or sets a value that indicates song title. 
		/// </summary>
		public string SongTitle
		{
			get
			{
				return songTitle;
			}
			set
			{
				songTitle = value;
				this.RaisePropertyChanged("SongTitle");
			}
		}

		/// <summary>
		/// Gets or sets the value that indicates the song auther.
		/// </summary>
		public string SongAuther
		{
			get
			{
				return songAuther;
			}
			set
			{
				songAuther = value;
				this.RaisePropertyChanged("SongAuther");
			}
		}

		/// <summary>
		/// Gets or sets a value that indicates song size. 
		/// </summary>
		public string SongSize
		{
			get
			{
				return songSize;
			}
			set
			{
				songSize = value;
				this.RaisePropertyChanged("SongSize");
			}
		}


		public string SongLength
		{
			get
			{
				return songLength;
			}
			set
			{
				songLength = value;
				this.RaisePropertyChanged("SongLength");
			}
		}

		/// <summary>
		/// Gets or sets a ImageSource that indicates Task's image. 
		/// </summary>
		public String SongThumbnail
		{
			get
			{
				return songThumbnail;
			}
			set
			{
				songThumbnail = value;
				this.RaisePropertyChanged("SongThumbnail");
			}
		}


		/// <summary>
		/// Gets or sets a ImageSource that indicates Task's image. 
		/// </summary>
		public ImageSource SelectedImage
		{
			get
			{
				return selectedImage;
			}
			set
			{
				selectedImage = value;
				this.RaisePropertyChanged("SelectedImage");
			}
		}

		/// <summary>
		/// Gets or sets a ImageSource that indicates Task's image. 
		/// </summary>
		public ImageSource NotSelectedImage
		{
			get
			{
				return notselectedImage;
			}
			set
			{
				notselectedImage = value;
				this.RaisePropertyChanged("NotSelectedImage");
			}
		}

		public bool IsSelected
		{
			get { return isSelected; }
			set
			{
				isSelected = value;
				RaisePropertyChanged("IsSelected");
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