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
using System.IO;
using System.Reflection;
using SampleBrowser.Core;
using Xamarin.Forms;

namespace SampleBrowser.SfAutoComplete
{
	public partial class ToleratingTypos : SampleView, INotifyPropertyChanged
	{
		public ObservableCollection<string> Source { get; set; }
		public ObservableCollection<ListModel> ListSource { get; set; }
		public ObservableCollection<SearchData> DummySource { get; set; }
        private ObservableCollection<string> stringDummySource { get; set; }
		public object selectedItem;
		public object SelectedItem
		{
			get
			{
				return selectedItem;
			}
			set
			{
				selectedItem = value;
				if (selectedItem == null || selectedItem.ToString() == "")
					Results(0);
				else
					Results(100000);

				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("SelectedItem"));
				}
			}
		}

		private IEnumerable<object> filteredCollection;

		public IEnumerable<object> FilteredCollection
		{
			get
			{
				return filteredCollection;
			}
			set
			{
                if (filteredCollection != value)
                {
                    filteredCollection = value;
                    filteredCollection = getOrder(DummySource);
                    DummySource = new ObservableCollection<SearchData>();
                    stringDummySource.Clear();
                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("FilteredCollection"));
                    }
                }
			}
		}

		public ObservableCollection<string> getOrder(ObservableCollection<SearchData> sourceOrder)
		{
			ObservableCollection<string> orderedSource = new ObservableCollection<string>();
			for (int i = 0; i < 10; i++)
			{
                int count=0;
                for (int c = 0; c < sourceOrder.Count; c++)
                {
                    count++;
                    if (sourceOrder[c] != null && sourceOrder[c].Distance == i)
                    {
                        orderedSource.Add(sourceOrder[c].Item);
                    }
                }
			}
			return orderedSource;
		}

		private string text;

		public string Text
		{
			get
			{

				return text;
			}
			set
			{
				text = value;

				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Text"));
				}
			}
		}

		public ToleratingTypos()
		{
			InitializeComponent();
			Source = new StringData().GetStringCollection();
			ListSource = new StringData().GetListCollection();
			this.autoComplete.Filter = AutoCompleteSearch;
			DummySource = new ObservableCollection<SearchData>();
            stringDummySource = new ObservableCollection<string>();

			this.BindingContext = this;
		}

		ToleratingTyposHelper helper = new ToleratingTyposHelper();

		public bool AutoCompleteSearch(object value1, object value2)
		{
			var string1 = value1.ToString().ToLower();
			var string2 = value2.ToString().ToLower();
			if (string1.Length > 0 && string2.Length > 0)
				if (string1[0] != string2[0])
					return false;
			var originalString1 = string.Empty;
			var originalString2 = string.Empty;

			if (string1.Length < string2.Length)
			{
				originalString2 = string2.Remove(string1.Length);
				originalString1 = string1;

			}

			if (string2.Length < string1.Length)
			{
				return false;
			}
			if (string2.Length == string1.Length)
			{
				originalString1 = string1;
				originalString2 = string2;
			}

			bool IsMatchSoundex = helper.ProcessOnSoundexAlgorithmn(originalString1) == helper.ProcessOnSoundexAlgorithmn(originalString2);
			int Distance = helper.GetDamerauLevenshteinDistance(originalString1, originalString2);

			if (IsMatchSoundex || Distance <= 4)
			{
                var searchData = new SearchData() { Item = value2.ToString(), Distance = Distance };
                if (!stringDummySource.Contains(value2.ToString()))
                {
                    DummySource.Add(searchData);
                    stringDummySource.Add(value2.ToString());
                }
				return true;
			}
			else
				return false;

        }

		Random random = new Random();

		public new event PropertyChangedEventHandler PropertyChanged;
		public void Results(int value)
		{
			foreach (var item in ListSource)
			{
				item.Count = random.Next(value).ToString();
			}
		}
	}

	public class SearchData
	{
		public string Item
		{
			get;
			set;
		}

		public int Distance
		{
			get;
			set;
		}
	}

	public class StringData
	{
		public ObservableCollection<string> GetStringCollection()
		{
			var assembly = typeof(StringData).GetTypeInfo().Assembly;
            Stream stream = null;
#if COMMONSB
            stream = assembly.GetManifestResourceStream("SampleBrowser.Samples.AutoComplete.strings.txt");
#else
            stream = assembly.GetManifestResourceStream("SampleBrowser.SfAutoComplete.strings.txt");
#endif
			ObservableCollection<string> stringCollection = new ObservableCollection<string>();
			string text = "";
			using (var reader = new System.IO.StreamReader(stream))
			{
				while ((text = reader.ReadLine()) != null)
				{
					stringCollection.Add(text);
				}
			}
			return stringCollection;
		}

		public ObservableCollection<ListModel> GetListCollection()
		{
			ObservableCollection<ListModel> listCollection = new ObservableCollection<ListModel>();

			listCollection.Add(new ListModel() { Text = "General", Image = "AllApps.png" });
			listCollection.Add(new ListModel() { Text = "Maps", Image = "Maps_Violet.png" });
			listCollection.Add(new ListModel() { Text = "Images", Image = "Picture.png" });
			listCollection.Add(new ListModel() { Text = "News", Image = "Newspaper.png" });
			listCollection.Add(new ListModel() { Text = "Video", Image = "Media.png" });
			listCollection.Add(new ListModel() { Text = "Music", Image = "Music.png" });
			listCollection.Add(new ListModel() { Text = "Books", Image = "Book_Icon.png" });
			listCollection.Add(new ListModel() { Text = "Flight", Image = "Aeroplane.png" });
			listCollection.Add(new ListModel() { Text = "Quick Search", Image = "Spaceship.png" });

			return listCollection;
		}
	}

	public class ListModel : INotifyPropertyChanged
	{
		public string Text { get; set; }
		public string Image { get; set; }

		public string count = "0";

		public string Count
		{
			get
			{
				return "About " + count + " results";
			}
			set
			{
				count = value;
				if (PropertyChanged != null)
				{
					PropertyChanged(this, new PropertyChangedEventArgs("Count"));
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}