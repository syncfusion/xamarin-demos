#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.Util;
using System;
using Android.Views;
using SampleBrowser;
using Android.Widget;
using Com.Syncfusion.Autocomplete;
using Android.Graphics;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SampleBrowser
{
    public class ToleratingTyposSamplePage : SamplePage
    {
		LinearLayout mainLayout;
		int width,height;
		double density;
        ListView myList;
        UserData userData;
        MyCustomListAdapter myCustomListAdapter;
        public List<User> ListSource { get; set; }

		public override View GetPropertyWindowLayout(Android.Content.Context context)
		{
			return null;
		}

		public override View GetSampleContent(Android.Content.Context con)
		{
            userData = new UserData();
			width = con.Resources.DisplayMetrics.WidthPixels;
			height = con.Resources.DisplayMetrics.HeightPixels;
			density = con.Resources.DisplayMetrics.Density;
			mainLayout = new LinearLayout(con);
			mainLayout.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
			mainLayout.Orientation = Orientation.Vertical;
			mainLayout.SetGravity(GravityFlags.Center);
            mainLayout.SetPadding(0,20,0,0);

            SearchCountryMethod(con);
            AutoCompleteMethod(con);
            SearchLabelMethod(con);
            ListViewMethod(con);

            return mainLayout;
		}


		private void SearchCountryMethod(Android.Content.Context con)
		{
			TextView textView = new TextView(con);
            textView.LayoutParameters = new LinearLayout.LayoutParams((int)(width * 0.95), (int)(30 * density));
			textView.Hint = "Search by Country";
			textView.TextSize = 18;

			mainLayout.AddView(textView);
		}

        private void AutoCompleteMethod(Android.Content.Context con)
        {
			SfAutoComplete toleratingAutoComplete = new SfAutoComplete(con);
			toleratingAutoComplete.LayoutParameters = new LinearLayout.LayoutParams((int)(width * 0.95), (int)(50));
            toleratingAutoComplete.SetGravity(GravityFlags.Start);
            toleratingAutoComplete.DataSource =new Countrylist().Country;
			toleratingAutoComplete.Filter = AutoCompleteSearch;
            toleratingAutoComplete.SuggestionMode = SuggestionMode.Custom;
            toleratingAutoComplete.DropDownItemHeight = 40;
            toleratingAutoComplete.MaximumDropDownHeight = 150;
            toleratingAutoComplete.Watermark = "Search Here";
			CustomAutoCompleteAdapter customAdapter = new CustomAutoCompleteAdapter();
			customAdapter.autoComplete1 = toleratingAutoComplete;
			toleratingAutoComplete.Adapter = customAdapter;
            ListSource =userData.Users;
			myCustomListAdapter = new MyCustomListAdapter(ListSource);

			toleratingAutoComplete.SelectionChanged += (sender, e) => {
                int valueCount = 0;
                if (e.Value == null || e.Value.ToString() == "")
                    valueCount = 0;
				else
					valueCount=100000;

				foreach (var item in ListSource)
				{
					item.Count = random.Next(valueCount).ToString();
				}
				myCustomListAdapter.NotifyDataSetChanged();
			};

			mainLayout.AddView(toleratingAutoComplete);
        }

		Random random = new Random();
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
				return true;
			else
				return false;

			//int matchValue = 0;

			//var allWords = value2.ToString().ToLower().Split(' ');
			//var keys = value1.ToString().ToLower().Split(' ');

			//foreach (var item in allWords)
			//{
			//	foreach (var key in keys)
			//	{
			//		var itemValue = item;
			//		if (item.Length > key.Length)
			//		{
			//			itemValue = item.Remove(key.Length);
			//		}
			//		if (key == "" || item == "")
			//			continue;
			//		if ((helper.ProcessOnSoundexAlgorithmn(key) == helper.ProcessOnSoundexAlgorithmn(itemValue)))
			//			matchValue++;
			//		if ((helper.ProcessOnSoundexAlgorithmn(key) == helper.ProcessOnSoundexAlgorithmn(item)))
			//			matchValue++;
			//	}
			//}

			//int keysCount = 0;

			//if (matchValue >= keysCount)
			//	return true;
			//return false;
		}

        private void SearchLabelMethod(Android.Content.Context con)
        {
            TextView textViewHeight = new TextView(con);
            textViewHeight.LayoutParameters = new LinearLayout.LayoutParams((int)(width * 0.95), (int)(40 * density));
			mainLayout.AddView(textViewHeight);

			TextView textView = new TextView(con);
            textView.LayoutParameters = new LinearLayout.LayoutParams((int)(width * 0.95), (int)(30 * density));
			textView.Hint = "Search Results";
			textView.TextSize = 15;

			mainLayout.AddView(textView);
        }


		private void ListViewMethod(Android.Content.Context con)
        {
            myList = new ListView(con);
            myList.LayoutParameters=new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(height - (300 * density)));
            myList.FastScrollEnabled = true;
			myList.Adapter = myCustomListAdapter;


			LinearLayout listViewLayout = new LinearLayout(con);
            listViewLayout.SetPadding(20,10,20,10);
			listViewLayout.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
			listViewLayout.AddView(myList);

            mainLayout.AddView(listViewLayout);
		}
	}

	public class ToleratingTyposHelper
	{
		public ToleratingTyposHelper()
		{
			soundexTerms.Add("aeiouhyw");
			soundexTerms.Add("bfpv");
			soundexTerms.Add("cgikqsxz");
			soundexTerms.Add("dt");
			soundexTerms.Add("l");
			soundexTerms.Add("mn");
			soundexTerms.Add("r");
		}

		List<string> soundexTerms = new List<string>();

		/// <summary>
		/// Based on Soundex Algorithmn and DL Distance Algorithmn
		/// </summary>
		/// <returns>The matching.</returns>
		/// <param name="value1">Value1.</param>
		/// <param name="value2">Value2.</param>
		public int IsMatching(string value1, string value2)
		{
			var val1 = ProcessOnSoundexAlgorithmn(value1);
			var val2 = ProcessOnSoundexAlgorithmn(value2);
			return CalcualteDistance(val1, val2);
		}

		public int GetMinValue(int[] value)
		{
			int minValue = 0;
			foreach (var item in value)
			{
				if (item < minValue)
					minValue = item;
			}
			return minValue;
		}

		public int GetDamerauLevenshteinDistance(string source, string target)
		{
			var bounds = new { Height = source.Length + 1, Width = target.Length + 1 };

			int[,] matrix = new int[bounds.Height, bounds.Width];

			for (int height = 0; height < bounds.Height; height++) { matrix[height, 0] = height; };
			for (int width = 0; width < bounds.Width; width++) { matrix[0, width] = width; };

			for (int height = 1; height < bounds.Height; height++)
			{
				for (int width = 1; width < bounds.Width; width++)
				{
					int cost = (source[height - 1] == target[width - 1]) ? 0 : 1;
					int insertion = matrix[height, width - 1] + 1;
					int deletion = matrix[height - 1, width] + 1;
					int substitution = matrix[height - 1, width - 1] + cost;

					int distance = Math.Min(insertion, Math.Min(deletion, substitution));

					if (height > 1 && width > 1 && source[height - 1] == target[width - 2] && source[height - 2] == target[width - 1])
					{
						distance = Math.Min(distance, matrix[height - 2, width - 2] + cost);
					}

					matrix[height, width] = distance;
				}
			}

			return matrix[bounds.Height - 1, bounds.Width - 1];
		}

		/// <summary>
		/// DL Algorithmn Implementation
		/// </summary>
		/// <returns>The distance.</returns>
		/// <param name="value1">Value1.</param>
		/// <param name="value2">Value2.</param>
		public int CalcualteDistance(string value1, string value2)
		{
			int lengthValue1 = value1.Length;
			int lengthValue2 = value2.Length;
			var matrix = new int[lengthValue1 + 1, lengthValue2 + 1];
			for (int i = 0; i <= lengthValue1; i++)
				matrix[i, 0] = i;
			for (int j = 0; j <= lengthValue2; j++)
				matrix[0, j] = j;
			for (int i = 1; i <= lengthValue1; i++)
			{
				for (int j = 1; j <= lengthValue2; j++)
				{
					int cost = value2[j - 1] == value1[i - 1] ? 0 : 1;
					var vals = new int[] {
				matrix[i - 1, j] + 1,
				matrix[i, j - 1] + 1,
				matrix[i - 1, j - 1] + cost
			};
					matrix[i, j] = GetMinValue(vals);
					if (i > 1 && j > 1 && value1[i - 1] == value2[j - 2] && value1[i - 2] == value2[j - 1])
						matrix[i, j] = Math.Min(matrix[i, j], matrix[i - 2, j - 2] + cost);
				}
			}
			return matrix[lengthValue1, lengthValue2];
		}

		/// <summary>
		/// Soundex Algorithmn Implementation
		/// </summary>
		/// <returns>The on soundex algorithmn.</returns>
		/// <param name="value1">Value1.</param>
		/// <param name="moreAccuracy">If set to <c>true</c> more accuracy.</param>
		public string ProcessOnSoundexAlgorithmn(string value1, bool moreAccuracy = true)
		{
			string stringValue = string.Empty;
			foreach (var item in value1.ToLower())
			{
				for (int i = 0; i < soundexTerms.Count; i++)
				{
					if (soundexTerms[i].Contains(item.ToString()))
					{
						stringValue += i.ToString();
						continue;
					}
				}
			}
			if (stringValue.Length > 0)
			{
				if (moreAccuracy)
				{
					stringValue = stringValue.Insert(0, value1[0].ToString());
					stringValue = stringValue.Replace("0", "");
				}
			}
			return stringValue;
		}
	}

	internal class CustomAutoCompleteAdapter : AutoCompleteAdapter
	{
		internal SfAutoComplete autoComplete1;
		
		public Android.Views.View GetView(Com.Syncfusion.Autocomplete.SfAutoComplete autoComplete, string text, int index)
		{
			GC.Collect();
            LinearLayout linearLayout = new LinearLayout(autoComplete.Context);
            linearLayout.SetPadding((int)(3 * autoComplete.GetDensity()),(int)(3 * autoComplete.GetDensity()),(int)(3 * autoComplete.GetDensity()),(int)(3 * autoComplete.GetDensity()));
            linearLayout.LayoutParameters = new ViewGroup.LayoutParams(autoComplete.LayoutParameters.Width, autoComplete.LayoutParameters.Height);
            linearLayout.Orientation = Orientation.Horizontal;
			TextView imageView = new TextView(autoComplete.Context);
			Typeface tf = Typeface.CreateFromAsset(autoComplete.Context.Assets, "icon.ttf");
			imageView.Text = "A";
			imageView.SetPadding((int)(3 * autoComplete.GetDensity()), (int)(3 * autoComplete.GetDensity()), (int)(3 * autoComplete.GetDensity()), 0);
			imageView.Typeface = tf;
            imageView.TextSize = 18;
            imageView.Gravity = GravityFlags.Center;
            imageView.TextAlignment = TextAlignment.Center;

            TextView textView = new TextView(autoComplete.Context);
            textView.SetPadding((int)(3 * autoComplete.GetDensity()),0,0,0);
            textView.Text = text;
            textView.TextSize = 18;
			textView.Gravity = GravityFlags.Center;
			textView.TextAlignment = TextAlignment.Center;

            linearLayout.AddView(imageView);
            linearLayout.AddView(textView);

            return linearLayout;
		}

	}

}
