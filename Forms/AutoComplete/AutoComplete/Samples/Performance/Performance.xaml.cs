#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;
using SampleBrowser.Core;
using Xamarin.Forms;

namespace SampleBrowser.SfAutoComplete
{
	public partial class Performance : SampleView, INotifyPropertyChanged
	{
		public ObservableCollection<String> AllWords { get; set; }

		private IEnumerable<object> filteredCollection;

		public IEnumerable<object> FilteredCollection
		{
			get { return filteredCollection; }
			set
			{
				if (value != null)
				{
					filteredCollection = value;

					var searchTime = "(" + DateTime.Now.Subtract(searchStart).TotalSeconds.ToString().Remove(5) + " Sec)";

					filtercount = 0;

					this.SearchTime.Text = searchTime;
					foreach (var item in filteredCollection)
					{
						filtercount++;
					}
                   
                    if (filtercount > 0)
                    {
                        this.SearchedItem.Text = filtercount.ToString("#,#", CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        this.SearchedItem.Text = "0";
                    }
					getLoadMoreButton();
					//if (SearchedItem.Text !="0")
					//{
					//    Device.StartTimer(TimeSpan.FromMilliseconds(200), () =>
					//    {
					//        return CanAnimate();
					//    });


					//}
					RaisePropertyChanged("FilteredCollection");
				}
			}
		}
		int filtercount = 0;
		int count = 1;
		public bool CanAnimate()
		{
			if (count > 27)
			{
				count = 0;
				return false;
			}
			if ((count++ % 5) == 0)
				this.SearchedItem.TextColor = this.SearchTime.TextColor = Color.White;
			else
				this.SearchedItem.TextColor = this.SearchTime.TextColor = Color.Black;
			return true;
		}
		private bool isToggled = false;

		public bool IsToggled
		{
			get
			{
				return isToggled;
			}
			set
			{
				isToggled = value;
				this.loadedItem.Text = "Disable load more for on-demand loading";
				if (isToggled)
				{
					autoComplete.MaximumSuggestion = 10;
				}
				else
				{
					autoComplete.MaximumSuggestion = 0;
				}
				getLoadMoreButton();
				RaisePropertyChanged("IsToggled");
			}

		}

		private void getLoadMoreButton()
		{
			if (IsToggled && filtercount > 0)
			{
				this.loadMoreButton.IsVisible = true;
			}
			else
			{
				this.loadMoreButton.IsVisible = false;
			}
		}

		#region INotifyPropertyChanged implementation

		public new event PropertyChangedEventHandler PropertyChanged;

		private void RaisePropertyChanged(String name)
		{
			if (PropertyChanged != null)
				this.PropertyChanged(this, new PropertyChangedEventArgs(name));
		}

		#endregion
		public Performance()
		{
			InitializeComponent();


			this.BindingContext = this;
			searchStart = DateTime.Now;

            IsToggled = false;
            if (Device.RuntimePlatform == Device.UWP)
            {
                AutocompleteRow.Height = 45;
            }

        }

		DateTime searchStart = DateTime.Now;
		private void auto_ValueChanged(object sender, Syncfusion.SfAutoComplete.XForms.ValueChangedEventArgs e)
		{
			if (e.Value != "")
			{
				FilteredCollection = null;
			}
			this.SearchedItem.Text = this.SearchTime.Text = "0";
			searchStart = DateTime.Now;

		}

		private void LoadMore_Clicked(object sender, EventArgs e)
		{
			searchStart = DateTime.Now;
			this.autoComplete.LoadMore();
		}
		private async void Load_Clicked(object sender, EventArgs e)
		{
			(sender as Button).IsVisible = false;
			
			await LoadItems();
			
		}

		private Task<object> LoadItems()
		{

			AllWords = new ObservableCollection<string>();

			var assembly = typeof(ViewModel3).GetTypeInfo().Assembly;
			System.IO.Stream stream = null;
#if COMMONSB
            stream = assembly.GetManifestResourceStream("SampleBrowser.Samples.AutoComplete.words.txt");
#else
            stream = assembly.GetManifestResourceStream("SampleBrowser.SfAutoComplete.words.txt");
#endif

			string text = "";
			using (var reader = new System.IO.StreamReader(stream))
			{
				text = reader.ReadToEnd();
			}
			string[] splittedwords = text.Split('\n');

			for (int i = 0; i < 100000; i++)
			{
				AllWords.Add(splittedwords[i]);
			}

			var startTime = DateTime.Now;
			this.autoComplete.DataSource = AllWords;
			var load = DateTime.Now.Subtract(startTime).TotalSeconds.ToString() + " Sec";
			this.SearchedLoadedItem.Text = AllWords.Count.ToString("#,#", CultureInfo.InvariantCulture);

			return Task.FromResult<object>(null);

		}
	}
}
