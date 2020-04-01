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

namespace SampleBrowser
{
	public class DiacriticSamplePage : SamplePage
	{
		LinearLayout mainLayout;
		int width;
		double density;
		public override View GetPropertyWindowLayout(Android.Content.Context context)
		{
			return null;
		}

		public override View GetSampleContent(Android.Content.Context con)
		{
			width = con.Resources.DisplayMetrics.WidthPixels;
			density = con.Resources.DisplayMetrics.Density;
			mainLayout = new LinearLayout(con);
			mainLayout.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
			mainLayout.Orientation = Orientation.Vertical;
			mainLayout.SetPadding(20, 20, 20, 20);
			LabelMethod(con);
			AutoCompleteMethod(con);

			return mainLayout;
		}

		private void LabelMethod(Android.Content.Context con)
		{
			TextView textView = new TextView(con);
			textView.LayoutParameters = new LinearLayout.LayoutParams((int)(width * 0.95), (int)(30 * density));
			textView.Hint = " AutoComplete";
			textView.TextSize = 18;

			mainLayout.AddView(textView);
		}

		private void AutoCompleteMethod(Android.Content.Context con)
		{
			SfAutoComplete diacriticAutoComplete = new SfAutoComplete(con);
			diacriticAutoComplete.LayoutParameters = new LinearLayout.LayoutParams((int)(width * 0.95), (int)(50));
			diacriticAutoComplete.SetGravity(GravityFlags.Center);
			diacriticAutoComplete.DisplayMemberPath = "SongTitle";
			diacriticAutoComplete.DataSource = new MusicInfoRepository().GetMusicInfo();
			diacriticAutoComplete.MaximumDropDownHeight = 150;
			diacriticAutoComplete.Watermark = "Search here";
			diacriticAutoComplete.SuggestionMode = SuggestionMode.Contains;
			diacriticAutoComplete.TextHighlightMode = OccurrenceMode.MultipleOccurrence;
			diacriticAutoComplete.DropDownItemHeight = 40;
			diacriticAutoComplete.IgnoreDiacritic = false;


			mainLayout.AddView(diacriticAutoComplete);
		}
	}
}