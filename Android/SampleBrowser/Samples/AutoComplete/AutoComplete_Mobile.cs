#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
using Android.Views.InputMethods;
using Android.Util;

#endregion
using System;
using Com.Syncfusion.Autocomplete;
using Android.Widget;
using Android.Views;
using System.Runtime.Remoting.Contexts;
using Android.Graphics;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Android.App;
using Android.Content;

using SampleBrowser;

namespace SampleBrowser
{
    public class AutoComplete_Mobile
    {
        /*********************************
        **Local Variable Inizialisation**
        *********************************/
        int minimum = 1, popupdelay = 100, maximum = 150, jobNumber = 0, width;  
        TextView jobSearchLabel, countryLabel, jobFieldLabel, experienceLabel, jobSearchLabelSpacing;
        TextView countryLabelSpacing, countryAutoCompleteSpacing, jobFieldLabelSpacing, jobFieldAutoCompleteSpacing;
        TextView experienceLabelSpacing, experienceSpinnerSpacing, searchButtonSpacing;
        EditText minPrefixCharacterText, maxDropDownHeightText, popUpDelayText;       
        Spinner suggestionModeSpinner, autoCompleteModeSpinner, experienceSpinner;          
        LinearLayout propertylayout, minPrefixCharaterStack, maxDropDownHeightStack, popUpDelayStack;      
        ArrayAdapter<String> suggestionModeDataAdapter, autoCompleteModeDataAdapter;
        SfAutoComplete countryNameAutoComplete, jobFieldAutoComplete;
        SuggestionMode suggestionModes = SuggestionMode.StartsWith;
        AutoCompleteMode autoCompleteMode = AutoCompleteMode.Suggest;
        List<String> Title = new List<String>();
        List<String> Experience = new List<String>();
        AlertDialog.Builder resultsDialog;
        Button searchButton;
        Android.Content.Context context;

        public View GetPropertyLayout(Android.Content.Context context1)
        {
            context = context1;
            width = context.Resources.DisplayMetrics.WidthPixels / 2;
            propertylayout = new LinearLayout(context);
            propertylayout.Orientation = Orientation.Vertical;

            SuggestionModeLayout();
            AutoCompleteModeLayout();
            MinimumPrefixCharacterLayout();
            MaximumDropDownLayout();
            PopUpDelayLayout();

			ScrollView scroll = new ScrollView(context1);
			scroll.AddView(propertylayout);
            
            return scroll;
        }

        private void SuggestionModeLayout()
        {
            /*****************
            **SuggestionMode**
            ******************/
            TextView suggestionModeLabel = new TextView(context);
            suggestionModeLabel.Text = "Suggestion Mode";
            suggestionModeLabel.TextSize = 20;
            suggestionModeLabel.Gravity = GravityFlags.Left;

            //SpaceText
            TextView spacingText = new TextView(context);
            propertylayout.AddView(spacingText);
			suggestionModeSpinner = new Spinner(context,SpinnerMode.Dialog);
            propertylayout.AddView(suggestionModeLabel);
            propertylayout.AddView(suggestionModeSpinner);

            //SuggestionList
            List<String> suggestionModeList = new List<String>();
            suggestionModeList.Add("StartsWith");
            suggestionModeList.Add("StartsWithCaseSensitive");
            suggestionModeList.Add("Contains");
            suggestionModeList.Add("ContainsWithCaseSensitive");
            suggestionModeList.Add("EndsWith");
            suggestionModeList.Add("EndsWithCaseSensitive");
            suggestionModeList.Add("Equals");
            suggestionModeList.Add("EqualsWithCaseSensitive");
            suggestionModeDataAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, suggestionModeList);
            suggestionModeDataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            suggestionModeSpinner.Adapter = suggestionModeDataAdapter;

            //suggestionModeSpinner ItemSelected Listener
            suggestionModeSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
                String selectedItem = suggestionModeDataAdapter.GetItem(e.Position);
                if (selectedItem.Equals("StartsWith"))
                {
                    suggestionModes = SuggestionMode.StartsWith;
                }
                else if (selectedItem.Equals("StartsWithCaseSensitive"))
                {
                    suggestionModes = SuggestionMode.StartsWithCaseSensitive;
                }
                else if (selectedItem.Equals("Contains"))
                {
                    suggestionModes = SuggestionMode.Contains;
                }
                else if (selectedItem.Equals("ContainsWithCaseSensitive"))
                {
                    suggestionModes = SuggestionMode.ContainsWithCaseSensitive;
                }
                else if (selectedItem.Equals("EndsWith"))
                {
                    suggestionModes = SuggestionMode.EndsWith;
                }
                else if (selectedItem.Equals("EndsWithCaseSensitive"))
                {
                    suggestionModes = SuggestionMode.EndsWithCaseSensitive;
                }
                else if (selectedItem.Equals("Equals"))
                {
                    suggestionModes = SuggestionMode.Equals;
                }
                else if (selectedItem.Equals("EqualsWithCaseSensitive"))
                {
                    suggestionModes = SuggestionMode.EqualsWithCaseSensitive;
                }
            };

            //Separator
            SeparatorView suggestionModeSeparate = new SeparatorView(context, width * 2);
            suggestionModeSeparate.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
            LinearLayout.LayoutParams suggestionModeLayoutParam = new LinearLayout.LayoutParams(width * 2, 5);
            suggestionModeLayoutParam.SetMargins(0, 20, 0, 0);
           // propertylayout.AddView(suggestionModeSeparate, suggestionModeLayoutParam);
        }

        private void AutoCompleteModeLayout()
        {
            /*******************
            **AutoCompleteMode**
            ********************/
            TextView autoCompleteModeLabel = new TextView(context);
            autoCompleteModeLabel.Text = "AutoComplete Mode";
            autoCompleteModeLabel.TextSize = 20;
            autoCompleteModeLabel.Gravity = GravityFlags.Left;

            //SpaceTExt
            TextView textSpacing = new TextView(context);
            propertylayout.AddView(textSpacing);
			autoCompleteModeSpinner = new Spinner(context,SpinnerMode.Dialog);
            propertylayout.AddView(autoCompleteModeLabel);
            propertylayout.AddView(autoCompleteModeSpinner);

            //AutoCompleteModeList
            List<String> autoCompleteModeList = new List<String>();
            autoCompleteModeList.Add("Suggest");
            autoCompleteModeList.Add("SuggestAppend");
            autoCompleteModeList.Add("Append");
            autoCompleteModeDataAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, autoCompleteModeList);
            autoCompleteModeDataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            autoCompleteModeSpinner.Adapter = autoCompleteModeDataAdapter;

            //autoCompleteModeSpinner ItemSelected Listener
            autoCompleteModeSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
                String selectedItem = autoCompleteModeDataAdapter.GetItem(e.Position);
                if (selectedItem.Equals("Suggest"))
                {
                    autoCompleteMode = AutoCompleteMode.Suggest;

                }
                else if (selectedItem.Equals("SuggestAppend"))
                {
                    autoCompleteMode = AutoCompleteMode.SuggestAppend;

                }
                else if (selectedItem.Equals("Append"))
                {
                    autoCompleteMode = AutoCompleteMode.Append;
                }
            };

            //Separator
            SeparatorView separate1 = new SeparatorView(context, width * 2);
            separate1.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
            LinearLayout.LayoutParams autoCompleteModeLayoutParams = new LinearLayout.LayoutParams(width * 2, 5);
            autoCompleteModeLayoutParams.SetMargins(0, 20, 0, 0);
            propertylayout.SetPadding(5, 0, 5, 0);

            //autoCompleteModeSeparator
            SeparatorView autoCompleteModeSeparate = new SeparatorView(context, width * 2);
            autoCompleteModeSeparate.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
            //propertylayout.AddView(autoCompleteModeSeparate, autoCompleteModeLayoutParams);
        }

        private void MinimumPrefixCharacterLayout()
        {
            /************************
             **Min Prefix Character**
             ************************/
            TextView minPrefixCharaterLabel = new TextView(context);
            minPrefixCharaterLabel.Text = "Min Prefix Character";
            minPrefixCharaterLabel.TextSize = 20;

            //MinPrefixCharacterText
            minPrefixCharacterText = new EditText(context);
            minPrefixCharacterText.Text = "1";
            minPrefixCharacterText.TextSize = 16;
            minPrefixCharacterText.SetWidth(50);
            minPrefixCharacterText.InputType = Android.Text.InputTypes.ClassPhone;
            minPrefixCharacterText.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
				try
				{
					if (minPrefixCharacterText.Text.Length > 0)
						minimum = Convert.ToInt32(e.Text.ToString());
					else
						minimum = 1;
				}
				catch
                {
					
				}
            };

            //MinPrefixCharaterTextLayoutParams
            LinearLayout.LayoutParams minPrefixCharaterTextLayoutParams = new LinearLayout.LayoutParams(
                width - 10, ViewGroup.LayoutParams.WrapContent);
            minPrefixCharaterTextLayoutParams.SetMargins(-10, 10, 0, 0);
            LinearLayout.LayoutParams minPrefixCharaterLabelLayoutParams = new LinearLayout.LayoutParams(
                width - 10, ViewGroup.LayoutParams.WrapContent);
            minPrefixCharaterLabelLayoutParams.SetMargins(0, 10, 0, 0);

			TextView spacingText = new TextView(context);
			propertylayout.AddView(spacingText);
            //MinPrefixCharaterStack
            minPrefixCharaterStack = new LinearLayout(context);
            minPrefixCharaterStack.AddView(minPrefixCharaterLabel, minPrefixCharaterLabelLayoutParams);
            minPrefixCharaterStack.AddView(minPrefixCharacterText, minPrefixCharaterTextLayoutParams);
            minPrefixCharaterStack.Orientation = Orientation.Horizontal;
            propertylayout.AddView(minPrefixCharaterStack);

            //MinPrefixCharaterSeparate
            SeparatorView minPrefixCharaterSeparate = new SeparatorView(context, width * 2);
            minPrefixCharaterSeparate.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
            LinearLayout.LayoutParams minPrefixCharaterLayoutParams = new LinearLayout.LayoutParams(width * 2, 5);
            minPrefixCharaterLayoutParams.SetMargins(0, 20, 0, 0);
           // propertylayout.AddView(minPrefixCharaterSeparate, minPrefixCharaterLayoutParams);
        }

        private void MaximumDropDownLayout()
        {
            /***********************
            **max DropDown height**
            ***********************/
            TextView maxDropDownHeightLabel = new TextView(context);
            maxDropDownHeightLabel.Text = "Max DropDown Height";
            maxDropDownHeightLabel.TextSize = 20;

            //MaxDropDownHeightText
            maxDropDownHeightText = new EditText(context);
            maxDropDownHeightText.Text = "200";
            maxDropDownHeightText.TextSize = 16;
            maxDropDownHeightText.SetWidth(50);
            maxDropDownHeightText.InputType = Android.Text.InputTypes.ClassPhone;
            maxDropDownHeightText.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
				try
				{
					if (maxDropDownHeightText.Text.Length > 0)
						maximum = Convert.ToInt32(e.Text.ToString());
					else
						maximum = 150;
				}
				catch{
					
				}
            };

            //MaxDropDownHeightTextLayoutParams
            LinearLayout.LayoutParams maxDropDownHeightTextLayoutParams = new LinearLayout.LayoutParams(
                width - 10, ViewGroup.LayoutParams.WrapContent);
            maxDropDownHeightTextLayoutParams.SetMargins(-10, 10, 0, 0);
            LinearLayout.LayoutParams maxDropDownHeightLabelLayoutParams = new LinearLayout.LayoutParams(
                width - 10, ViewGroup.LayoutParams.WrapContent);
            maxDropDownHeightLabelLayoutParams.SetMargins(0, 10, 0, 0);

			TextView spacingText = new TextView(context);
			propertylayout.AddView(spacingText);
            //MaxDropDownHeightStack
            maxDropDownHeightStack = new LinearLayout(context);
            maxDropDownHeightStack.AddView(maxDropDownHeightLabel, maxDropDownHeightLabelLayoutParams);
            maxDropDownHeightStack.AddView(maxDropDownHeightText, maxDropDownHeightTextLayoutParams);
            maxDropDownHeightStack.Orientation = Orientation.Horizontal;
            propertylayout.AddView(maxDropDownHeightStack);

            //MaxDropDownHeightSeparate
            SeparatorView maxDropDownHeightSeparate = new SeparatorView(context, width * 2);
            maxDropDownHeightSeparate.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
            LinearLayout.LayoutParams maxDropDownHeightLayoutParams = new LinearLayout.LayoutParams(width * 2, 5);
            maxDropDownHeightLayoutParams.SetMargins(0, 20, 0, 0);
           // propertylayout.AddView(maxDropDownHeightSeparate, maxDropDownHeightLayoutParams);
        }

        private void PopUpDelayLayout()
        {
            /***************
            **Popup Delay**
            ***************/
            TextView popUpDelayLabel = new TextView(context);
            popUpDelayLabel.Text = "PopUp Delay";
            popUpDelayLabel.TextSize = 20;

            //PopUpDelayText
            popUpDelayText = new EditText(context);
            popUpDelayText.Text = "100";
            popUpDelayText.TextSize = 16;
            popUpDelayText.InputType = Android.Text.InputTypes.ClassPhone;
            popUpDelayText.SetWidth(50);

            //popUpDelayText TextChanged Listener
            popUpDelayText.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
            {
				try
				{
					if (popUpDelayText.Text.Length > 0)
						popupdelay = Convert.ToInt32(e.Text.ToString());
					else
						popupdelay = 100;
				}
				catch
                { 
				
				}
            };

            LinearLayout.LayoutParams popUpDelayTextLayoutParams = new LinearLayout.LayoutParams(
                width - 10, ViewGroup.LayoutParams.WrapContent);
            popUpDelayTextLayoutParams.SetMargins(-10, 10, 0, 0);
            LinearLayout.LayoutParams popUpDelayLabelLayoutParams = new LinearLayout.LayoutParams(
                width - 10, ViewGroup.LayoutParams.WrapContent);
            popUpDelayLabelLayoutParams.SetMargins(0, 10, 0, 0);

			TextView spacingText = new TextView(context);
			propertylayout.AddView(spacingText);
            //PopUpDelayStack
            popUpDelayStack = new LinearLayout(context);
            popUpDelayStack.AddView(popUpDelayLabel, popUpDelayLabelLayoutParams);
            popUpDelayStack.AddView(popUpDelayText, popUpDelayTextLayoutParams);
            popUpDelayStack.Orientation = Orientation.Horizontal;
            propertylayout.AddView(popUpDelayStack);

            //PopUpDelaySeparate
            SeparatorView popUpDelaySeparate = new SeparatorView(context, width * 2);
            popUpDelaySeparate.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
            LinearLayout.LayoutParams popUpDelayLayoutParams = new LinearLayout.LayoutParams(width * 2, 5);
            popUpDelayLayoutParams.SetMargins(0, 20, 0, 0);
         //   propertylayout.AddView(popUpDelaySeparate, popUpDelayLayoutParams);
        }
        public View GetSampleContent(Android.Content.Context con)
        {
            SamplePageContents(con);        

            //countryNameAutoComplete
            countryNameAutoComplete = new SfAutoComplete(con);         
            ArrayAdapter<String> countryAdapter = new ArrayAdapter<String>(con,
                Android.Resource.Layout.SimpleListItem1, new Countrylist().Country);
            countryNameAutoComplete.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 50);
            countryNameAutoComplete.AutoCompleteSource = (countryAdapter);
            countryNameAutoComplete.SuggestionMode = SuggestionMode.StartsWith;
            countryNameAutoComplete.MaximumDropDownHeight = 150;
            countryNameAutoComplete.Watermark = "Enter a country name";
            countryNameAutoComplete.GetAutoEditText().SetTextSize(ComplexUnitType.Sp, 20);
			countryNameAutoComplete.TextHighlightMode = OccurrenceMode.FirstOccurrence;
			countryNameAutoComplete.HighlightedTextColor = Color.Blue;

            //jobFieldAutoComplete
            jobFieldAutoComplete = new SfAutoComplete(con);         
            ArrayAdapter<String> titleAdapter = new ArrayAdapter<String>(con,
                Android.Resource.Layout.SimpleListItem1, Title);
            jobFieldAutoComplete.AutoCompleteSource = (titleAdapter);
            jobFieldAutoComplete.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 50);
            jobFieldAutoComplete.SuggestionMode = SuggestionMode.Contains;
            jobFieldAutoComplete.MaximumDropDownHeight = 150;
            jobFieldAutoComplete.Watermark = "Starts with ’S’, ‘M’ or ‘B’";
            jobFieldAutoComplete.GetAutoEditText().SetTextSize(ComplexUnitType.Sp, 20);
			jobFieldAutoComplete.TextHighlightMode = OccurrenceMode.FirstOccurrence;
			jobFieldAutoComplete.HighlightedTextColor = Color.Blue;

            //main view
            LinearLayout mainView = GetView(con);
            return mainView;          
        }

        private LinearLayout GetView(Android.Content.Context con)
        {
            //mainLayout
            LinearLayout mainLayout = new LinearLayout(con);
            mainLayout.SetPadding(20, 20, 20, 30);
            mainLayout.SetBackgroundColor(Color.Rgb(236, 236, 236));
            mainLayout.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            mainLayout.Orientation = Orientation.Vertical;
            mainLayout.AddView(jobSearchLabel);
            mainLayout.AddView(jobSearchLabelSpacing);
            mainLayout.AddView(countryLabel);
            mainLayout.AddView(countryLabelSpacing);
            mainLayout.AddView(countryNameAutoComplete);
            mainLayout.AddView(countryAutoCompleteSpacing);
            mainLayout.AddView(jobFieldLabel);
            mainLayout.AddView(jobFieldLabelSpacing);
            mainLayout.AddView(jobFieldAutoComplete);
            mainLayout.AddView(jobFieldAutoCompleteSpacing);
            mainLayout.AddView(experienceLabel);
            mainLayout.AddView(experienceLabelSpacing);
            mainLayout.AddView(experienceSpinner);
            mainLayout.AddView(experienceSpinnerSpacing);
            mainLayout.AddView(searchButtonSpacing);
            mainLayout.AddView(searchButton);
            mainLayout.Touch += (object sender, View.TouchEventArgs e) => {
                Rect outRect = new Rect();
                countryNameAutoComplete.GetGlobalVisibleRect(outRect);
                jobFieldAutoComplete.GetGlobalVisibleRect(outRect);

                if (!outRect.Contains((int)e.Event.RawX, (int)e.Event.RawY))
                {
                    countryNameAutoComplete.ClearFocus();
                    jobFieldAutoComplete.ClearFocus();

                }
                hideSoftKeyboard((Activity)con);
            };

            return mainLayout;
        }

        private void SamplePageContents(Android.Content.Context con)
        {
            //Title list
            Title.Add("Software");
            Title.Add("Banking");
            Title.Add("Media");
            Title.Add("Medical");

            //jobSearchLabel
            jobSearchLabel = new TextView(con);
            jobSearchLabel.Text = "Job Search";
            jobSearchLabel.TextSize = 30;
            jobSearchLabel.Typeface = Typeface.DefaultBold;

            //jobSearchLabelSpacing
            jobSearchLabelSpacing = new TextView(con);
            jobSearchLabelSpacing.SetHeight(40);

            //countryLabel
            countryLabel = new TextView(con);
            countryLabel.Text = "Country";
            countryLabel.TextSize = 16;

            //countryLabelSpacing
            countryLabelSpacing = new TextView(con);
            countryLabelSpacing.SetHeight(10);

            //countryAutoCompleteSpacing
            countryAutoCompleteSpacing = new TextView(con);
            countryAutoCompleteSpacing.SetHeight(30);

            //jobFieldLabel
            jobFieldLabel = new TextView(con);
            jobFieldLabel.Text = "Job Field";
            jobFieldLabel.TextSize = 16;

            //jobFieldLabelSpacing
            jobFieldLabelSpacing = new TextView(con);
            jobFieldLabelSpacing.SetHeight(10);

            //jobFieldAutoCompleteSpacing
            jobFieldAutoCompleteSpacing = new TextView(con);
            jobFieldAutoCompleteSpacing.SetHeight(30);

            //experienceLabel
            experienceLabel = new TextView(con);
            experienceLabel.Text = "Experience";
            experienceLabel.TextSize = 16;
          
            //experienceLabelSpacing
            experienceLabelSpacing = new TextView(con);
            experienceLabelSpacing.SetHeight(10);

            //Experience list
            Experience.Add("1");
            Experience.Add("2");

            //searchButton
            searchButton = new Button(con);
            searchButton.SetWidth(ActionBar.LayoutParams.MatchParent);
            searchButton.SetHeight(40);
            searchButton.Text = "Search";
            searchButton.SetTextColor(Color.White);
            searchButton.SetBackgroundColor(Color.Gray);
            searchButton.Click += (object sender, EventArgs e) => {
                GetResult();
                resultsDialog.SetMessage(jobNumber + " Jobs Found");
                resultsDialog.Create().Show();
            };

            //searchButtonSpacing
            searchButtonSpacing = new TextView(con);
            searchButtonSpacing.SetHeight(30);
          
            //experience Spinner
			experienceSpinner = new Spinner(con,SpinnerMode.Dialog);
            experienceSpinner.DropDownWidth = 500;
            experienceSpinner.SetBackgroundColor(Color.Gray);
            ArrayAdapter<String> experienceDataAdapter = new ArrayAdapter<String>
                (con, Android.Resource.Layout.SimpleSpinnerItem, Experience);
            experienceDataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            experienceSpinner.Adapter = experienceDataAdapter;

            //experienceSpinnerSpacing
            experienceSpinnerSpacing = new TextView(con);
            experienceSpinnerSpacing.SetHeight(30);

            //results dialog
            resultsDialog = new AlertDialog.Builder(con);
            resultsDialog.SetTitle("Results");
            resultsDialog.SetPositiveButton("OK", (object sender, DialogClickEventArgs e) =>
            {
            });
            resultsDialog.SetCancelable(true);
        }
        public void GetResult()
        {
            jobNumber = 0;
            if (countryNameAutoComplete.Text.ToString().Equals("") || jobFieldAutoComplete.Text.ToString().Equals(""))
            {
            }
            else
            {
                Random r = new Random();
                jobNumber = r.Next(5, 60);
            }
        }
        public static void hideSoftKeyboard(Activity activity)
        {
            InputMethodManager inputMethodManager = (InputMethodManager)activity.GetSystemService(Activity.InputMethodService);
            inputMethodManager.HideSoftInputFromWindow(activity.CurrentFocus.WindowToken, 0);

        }
        public void ApplyChanges()
        {
            countryNameAutoComplete.SuggestionMode = suggestionModes;
            countryNameAutoComplete.AutoCompleteMode = autoCompleteMode;
            countryNameAutoComplete.MinimumPrefixCharacters = minimum;
            countryNameAutoComplete.PopUpDelay = popupdelay;
            countryNameAutoComplete.MaximumDropDownHeight = maximum;
            jobFieldAutoComplete.SuggestionMode = suggestionModes;
            jobFieldAutoComplete.AutoCompleteMode = autoCompleteMode;
            jobFieldAutoComplete.MinimumPrefixCharacters = minimum;
            jobFieldAutoComplete.PopUpDelay = popupdelay;
            jobFieldAutoComplete.MaximumDropDownHeight = maximum;
        }
    }
}