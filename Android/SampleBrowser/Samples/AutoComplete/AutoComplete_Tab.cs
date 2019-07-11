#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.Views.InputMethods;
using Android.Util;
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
    public class AutoComplete_Tab : SamplePage
    {
       /*********************************
        **Local Variable Inizialisation**
        *********************************/
        Spinner suggestionModeSpinner, autoCompleteModeSpinner;
        EditText minPrefixCharacterText, maxDropDownHeightText, popUpDelayText;
        SuggestionMode suggestionModes = SuggestionMode.StartsWith;
        AutoCompleteMode autoCompleteMode = AutoCompleteMode.Suggest;
        LinearLayout propertylayout;
        int minimum = 1, popupdelay = 100, maximum = 150;
        ArrayAdapter<String> suggestionModeDataAdapter, autoCompleteModeDataAdapter;
        SfAutoComplete countryNameAutoComplete, jobFieldAutoComplete;
        TextView jobSearchLabel, countryLabel, jobFieldLabel, experienceLabel, jobSearchLabelSpacing;
        TextView countryLabelSpacing, countryAutoCompleteSpacing, jobFieldLabelSpacing, jobFieldAutoCompleteSpacing;
        TextView experienceLabelSpacing, experienceSpinnerSpacing, searchButtonSpacing, closeLabel;
        Button propertyButton;
        FrameLayout propertyFrameLayout, buttomButtonLayout;
        Button searchButton;
        int jobNumber = 0;
        Spinner experienceSpinner;
        AlertDialog.Builder resultsDialog;
        List<String> Title = new List<String>();
        List<String> Country = new List<String>();
        List<String> Experience = new List<String>();
        int selectionPosition = 0, autoCompletModePosition = 0, totalWidth;
        int minPrefixCharPosition = 1, maxDropDownPosition = 200, popUpDelayPosition = 100;
        double actionBarHeight, navigationBarHeight, totalHeight;
        FrameLayout frame;
        Android.Content.Context con,context;
		ScrollView scrollView;
        public View GetPropertyLayout(Android.Content.Context context)
        {
           
            totalWidth = (context.Resources.DisplayMetrics.WidthPixels);          
            propertylayout = new LinearLayout(context);
            propertylayout.Orientation = Orientation.Vertical;

            OptionViewLayout();
            SuggestionModeLayout();
            AutoCompleteModeLayout();
            MinimumPrefixCharacterLayout();
            MaximumDropHeightLayout();
            PopUpDelayLayout();

            return propertylayout;
        }

        FrameLayout topProperty;
        LinearLayout proprtyOptionsLayout;
        private void OptionViewLayout()
        {
            /****************
             **Options View**
             ****************/
            TextView propertyLabel = new TextView(context);
            propertyLabel.SetTextColor(Color.ParseColor("#282828"));
            propertyLabel.Gravity = GravityFlags.CenterVertical;
            propertyLabel.TextSize = 18;
            propertyLabel.SetPadding(0, 10, 0, 10);
            propertyLabel.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent, GravityFlags.Left | GravityFlags.CenterHorizontal);
            propertyLabel.Text = "  " + "OPTIONS";

            //CloseLabel
            closeLabel = new TextView(context);
            closeLabel.SetBackgroundColor(Color.Transparent);
            closeLabel.Gravity = GravityFlags.CenterVertical;
            closeLabel.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent, GravityFlags.Right | GravityFlags.CenterHorizontal);
            closeLabel.SetBackgroundResource(Resource.Drawable.sfclosebutton);

            //CloseLayout
            FrameLayout closeLayout = new FrameLayout(context);
            closeLayout.SetBackgroundColor(Color.Transparent);
            closeLayout.SetPadding(0, 10, 0, 10);
            closeLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent, GravityFlags.Right | GravityFlags.CenterHorizontal);
            closeLayout.AddView(closeLabel);

            //TopProperty
            topProperty = new FrameLayout(context);
            topProperty.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            topProperty.SetBackgroundColor(Color.Rgb(230, 230, 230));
            topProperty.AddView(propertyLabel);
            topProperty.AddView(closeLayout);

            //topProperty Touch Event
            topProperty.Touch += (object sendar, View.TouchEventArgs e) =>
            {
                propertyFrameLayout.RemoveAllViews();
                buttomButtonLayout.RemoveAllViews();
                buttomButtonLayout.AddView(propertyButton);
            };
            proprtyOptionsLayout = new LinearLayout(context);
            proprtyOptionsLayout.Orientation = Android.Widget.Orientation.Vertical;

            //SpaceText
            TextView spaceText1 = new TextView(context);
            spaceText1.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 38, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText1);
        }

        private void SuggestionModeLayout()
        {
            /******************
            **SuggestionMode**
            ******************/
            TextView suggestionModeLabel = new TextView(context);
            suggestionModeLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            suggestionModeLabel.Text = "Suggestion Mode";
            suggestionModeLabel.TextSize = 15;
            suggestionModeLabel.Gravity = GravityFlags.Left;

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

            suggestionModeSpinner = new Spinner(context,SpinnerMode.Dialog);
            suggestionModeDataAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, suggestionModeList);
            suggestionModeDataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            suggestionModeSpinner.Adapter = suggestionModeDataAdapter;
            suggestionModeSpinner.SetSelection(selectionPosition);
            suggestionModeSpinner.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);

            //suggestionModeSpinner ItemSelected Listener
            suggestionModeSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
                selectionPosition = e.Position;
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
                ApplyChanges();
            };

            LinearLayout suggestionModeLayout = new LinearLayout(context);
            suggestionModeLayout.Orientation = Android.Widget.Orientation.Horizontal;
            suggestionModeLayout.AddView(suggestionModeLabel);
            suggestionModeLayout.AddView(suggestionModeSpinner);

            proprtyOptionsLayout.AddView(suggestionModeLayout);
            TextView spaceText2 = new TextView(context);
            spaceText2.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 38, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText2);
        }

        private void AutoCompleteModeLayout()
        {
            /*******************
            **AutoCompleteMode**
            ********************/
            TextView autoCompleteModeLabel = new TextView(context);
            autoCompleteModeLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            autoCompleteModeLabel.Text = "AutoComplete Mode";
            autoCompleteModeLabel.TextSize = 15;
            autoCompleteModeLabel.Gravity = GravityFlags.Left;

            //autoCompleteModeSpinner
            autoCompleteModeSpinner = new Spinner(context,SpinnerMode.Dialog);
            autoCompleteModeSpinner.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            List<String> autoCompleteModeList = new List<String>();
            autoCompleteModeList.Add("Suggest");
            autoCompleteModeList.Add("SuggestAppend");
            autoCompleteModeList.Add("Append");

            //autoCompleteModeDataAdapter
            autoCompleteModeDataAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, autoCompleteModeList);
            autoCompleteModeDataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            autoCompleteModeSpinner.Adapter = autoCompleteModeDataAdapter;
            autoCompleteModeSpinner.SetSelection(autoCompletModePosition);

            //autoCompleteModeSpinner ItemSelected Listener
            autoCompleteModeSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
                autoCompletModePosition = e.Position;
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
                ApplyChanges();
            };

            LinearLayout autoCompleteModeLayout = new LinearLayout(context);
            autoCompleteModeLayout.Orientation = Android.Widget.Orientation.Horizontal;
            autoCompleteModeLayout.AddView(autoCompleteModeLabel);
            autoCompleteModeLayout.AddView(autoCompleteModeSpinner);

            proprtyOptionsLayout.AddView(autoCompleteModeLayout);
            TextView spaceText3 = new TextView(context);
            spaceText3.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 38, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText3);
        }

        private void MinimumPrefixCharacterLayout()
        {
            /************************
           **Min Prefix Character**
           ************************/
            TextView minPrefixCharaterLabel = new TextView(context);
            minPrefixCharaterLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            minPrefixCharaterLabel.Text = "Min Prefix Character";
            minPrefixCharaterLabel.TextSize = 15;

            //minPrefixCharacterText
            minPrefixCharacterText = new EditText(context);
            minPrefixCharacterText.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            minPrefixCharacterText.Text = minPrefixCharPosition.ToString();
            minPrefixCharacterText.TextSize = 16;
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
                minPrefixCharPosition = minimum;
                ApplyChanges();
            };

            //minPrefixCharaterLayout
            LinearLayout minPrefixCharaterLayout = new LinearLayout(context);
            minPrefixCharaterLayout.Orientation = Android.Widget.Orientation.Horizontal;
            minPrefixCharaterLayout.AddView(minPrefixCharaterLabel);
            minPrefixCharaterLayout.AddView(minPrefixCharacterText);

            proprtyOptionsLayout.AddView(minPrefixCharaterLayout);
            TextView spaceText4 = new TextView(context);
            spaceText4.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 38, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText4);
        }

        private void MaximumDropHeightLayout()
        {
            /***********************
             **max DropDown height**
             ***********************/
            TextView maxDropDownHeightLabel = new TextView(context);
            maxDropDownHeightLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            maxDropDownHeightLabel.Text = "Max DropDown Height";
            maxDropDownHeightLabel.TextSize = 15;

            //maxDropDownHeightText
            maxDropDownHeightText = new EditText(context);
            maxDropDownHeightText.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            maxDropDownHeightText.Text = maxDropDownPosition.ToString();
            maxDropDownHeightText.TextSize = 16;
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
				catch
                { 
				
				}

                maxDropDownPosition = maximum;
                ApplyChanges();
            };

            //maxDropDownHeightLayout
            LinearLayout maxDropDownHeightLayout = new LinearLayout(context);
            maxDropDownHeightLayout.Orientation = Android.Widget.Orientation.Horizontal;
            maxDropDownHeightLayout.AddView(maxDropDownHeightLabel);
            maxDropDownHeightLayout.AddView(maxDropDownHeightText);

            proprtyOptionsLayout.AddView(maxDropDownHeightLayout);
            TextView spaceText5 = new TextView(context);
            spaceText5.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 38, GravityFlags.Center);
            proprtyOptionsLayout.AddView(spaceText5);
        }

        private void PopUpDelayLayout()
        {
            /***************
            **Popup Delay**
            ***************/
            TextView popUpDelayLabel = new TextView(context);
            popUpDelayLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            popUpDelayLabel.Text = "PopUp Delay";
            popUpDelayLabel.TextSize = 15;

            //popUpDelayText
            popUpDelayText = new EditText(context);
            popUpDelayText.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.33), ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            popUpDelayText.Text = popUpDelayPosition.ToString();
            popUpDelayText.TextSize = 16;
            popUpDelayText.InputType = Android.Text.InputTypes.ClassPhone;
            minPrefixCharacterText.SetWidth(50);
            maxDropDownHeightText.SetWidth(50);
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

                popUpDelayPosition = popupdelay;
                ApplyChanges();
            };
            LinearLayout popUpDelayLayout = new LinearLayout(context);
            popUpDelayLayout.Orientation = Android.Widget.Orientation.Horizontal;
            popUpDelayLayout.AddView(popUpDelayLabel);
            popUpDelayLayout.AddView(popUpDelayText);
            proprtyOptionsLayout.AddView(popUpDelayLayout);

            TextView spaceLabel = new TextView(context);
            spaceLabel.LayoutParameters = new FrameLayout.LayoutParams((int)(totalWidth * 0.167), ViewGroup.LayoutParams.WrapContent);

            LinearLayout layout1 = new LinearLayout(context);
            layout1.Orientation = Android.Widget.Orientation.Horizontal;
            layout1.AddView(spaceLabel);
            layout1.AddView(proprtyOptionsLayout);

            propertylayout.AddView(topProperty);
            propertylayout.AddView(layout1);
            propertylayout.SetBackgroundColor(Color.Rgb(240, 240, 240));
        }
        public override View GetSampleContent(Android.Content.Context con1)
        {
            con = context=con1;
            InitialMethod();
            ResultsLayout();
            ExperienceLayout();
            LabelInitialization();

            //countryNameAutoComplete
            ArrayAdapter<String> countryAdapter = new ArrayAdapter<String>(con,
                Android.Resource.Layout.SimpleListItem1, new Countrylist().Country);
            countryNameAutoComplete.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 50);
            countryNameAutoComplete.AutoCompleteSource = countryAdapter;
            countryNameAutoComplete.SuggestionMode = SuggestionMode.StartsWith;
            countryNameAutoComplete.MaximumDropDownHeight = 150;
            countryNameAutoComplete.Watermark = "Enter a country name";
            countryNameAutoComplete.GetAutoEditText().FocusChange += AutoEditText_FocusChange;
			countryNameAutoComplete.TextHighlightMode = OccurrenceMode.FirstOccurrence;
			countryNameAutoComplete.HighlightedTextColor = Color.Blue;

            //jobFieldAutoComplete
            ArrayAdapter<String> titleAdapter = new ArrayAdapter<String>(con,
                Android.Resource.Layout.SimpleListItem1, Title);
            jobFieldAutoComplete.AutoCompleteSource = titleAdapter;
            jobFieldAutoComplete.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 50);
            jobFieldAutoComplete.SuggestionMode = SuggestionMode.Contains;
            jobFieldAutoComplete.MaximumDropDownHeight = 150;
            jobFieldAutoComplete.Watermark = "Starts with ’S’, ‘M’ or ‘B’";
            jobFieldAutoComplete.GetAutoEditText().FocusChange += AutoEditText_FocusChange1;
            countryNameAutoComplete.GetAutoEditText().SetTextSize(ComplexUnitType.Sp, 20);
            jobFieldAutoComplete.GetAutoEditText().SetTextSize(ComplexUnitType.Sp, 20);
			jobFieldAutoComplete.TextHighlightMode = OccurrenceMode.FirstOccurrence;
			jobFieldAutoComplete.HighlightedTextColor = Color.Blue;

            SearchButtonLayout();
            MainLayout();

            return frame;
        }

        private void InitialMethod()
        {
            frame = new FrameLayout(con);
            totalHeight = con.Resources.DisplayMetrics.HeightPixels;

            TypedValue tv = new TypedValue();
            if (con.Theme.ResolveAttribute(Android.Resource.Attribute.ActionBarSize, tv, true))
            {
                actionBarHeight = TypedValue.ComplexToDimensionPixelSize(tv.Data, con.Resources.DisplayMetrics);
            }
            
            navigationBarHeight = getNavigationBarHeight(con);

            totalHeight = totalHeight - navigationBarHeight - actionBarHeight;
        }

        private void ResultsLayout()
        {
            //resultsDialog
            resultsDialog = new AlertDialog.Builder(con);
            resultsDialog.SetTitle("Results");
            resultsDialog.SetPositiveButton("OK", (object sender, DialogClickEventArgs e) =>
            {
            });
            resultsDialog.SetCancelable(true);
            Title.Add("Software");
            Title.Add("Banking");
            Title.Add("Media");
            Title.Add("Medical");
        }

        private void ExperienceLayout()
        {
            //experienceSpinner
            experienceSpinner = new Spinner(con,SpinnerMode.Dialog);
            experienceSpinner.DropDownWidth = 500;
            experienceSpinner.SetBackgroundColor(Color.Rgb(92, 178, 224));

            ArrayAdapter<String> experienceDataAdapter = new ArrayAdapter<String>
                (con, Android.Resource.Layout.SimpleSpinnerItem, Experience);
            experienceDataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            experienceSpinner.Adapter = experienceDataAdapter;
            Country.Add("UAE");
            Country.Add("Uruguay");
            Country.Add("United States");
            Country.Add("United Kingdom");
            Country.Add("Ukraine");
            Experience.Add("1");
            Experience.Add("2");
        }

        private void LabelInitialization()
        {
            //LabelInizialization
            countryNameAutoComplete = new SfAutoComplete(con);
            jobFieldAutoComplete = new SfAutoComplete(con);
            jobSearchLabel = new TextView(con);
            countryLabel = new TextView(con);
            jobFieldLabel = new TextView(con);
            experienceLabel = new TextView(con);
            jobSearchLabelSpacing = new TextView(con);
            countryLabelSpacing = new TextView(con);
            countryAutoCompleteSpacing = new TextView(con);
            jobFieldLabelSpacing = new TextView(con);
            jobFieldAutoCompleteSpacing = new TextView(con);
            experienceLabelSpacing = new TextView(con);
            experienceSpinnerSpacing = new TextView(con);
            searchButtonSpacing = new TextView(con);


            countryLabelSpacing.SetHeight(10);
            countryAutoCompleteSpacing.SetHeight(30);
            jobFieldLabelSpacing.SetHeight(10);
            jobFieldAutoCompleteSpacing.SetHeight(30);
            experienceLabelSpacing.SetHeight(10);
            experienceSpinnerSpacing.SetHeight(30);
            searchButtonSpacing.SetHeight(30);
            jobSearchLabel.Text = "Job Search";
            jobSearchLabel.TextSize = 30;
            jobSearchLabel.Typeface = Typeface.DefaultBold;
            countryLabel.Text = "Country";
            countryLabel.TextSize = 16;
            jobFieldLabel.Text = "Job Field";
            jobFieldLabel.TextSize = 16;
            experienceLabel.Text = "Experience";
            experienceLabel.TextSize = 16;
            jobSearchLabelSpacing.SetHeight(40);
        }

        private void SearchButtonLayout()
        {
            //searchButton
            searchButton = new Button(con);
            searchButton.SetWidth(ActionBar.LayoutParams.MatchParent);
            searchButton.SetHeight(40);
            searchButton.Text = "Search";
            searchButton.SetTextColor(Color.White);
            searchButton.SetBackgroundColor(Color.Rgb(72, 178, 224));

            searchButton.Click += (object sender, EventArgs e) => {
                GetResult();
                resultsDialog.SetMessage(jobNumber + " Jobs Found");
                resultsDialog.Create().Show();
            };
        }

        private void MainLayout()
        {           
            ArrayAdapter<String> experienceAdapter = new ArrayAdapter<String>(con,
               Android.Resource.Layout.SimpleListItem1, Experience);
            experienceSpinner.Adapter = experienceAdapter;
            experienceSpinner.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, con.Resources.GetDimensionPixelSize(Resource.Dimension.auto_picker_ht));
            //mainLayout
            LinearLayout mainLayout = new LinearLayout(con);
            mainLayout.SetPadding(20, 20, 20, 30);
            mainLayout.SetBackgroundColor(Color.White);
            mainLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.6), GravityFlags.Top | GravityFlags.CenterHorizontal);
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
            mainLayout.Touch += (object sender, View.TouchEventArgs e) =>
            {
				if (countryNameAutoComplete.IsFocused || jobFieldAutoComplete.IsFocused)
				{
					Rect outRect = new Rect();
					countryNameAutoComplete.GetGlobalVisibleRect(outRect);
					jobFieldAutoComplete.GetGlobalVisibleRect(outRect);

					if (!outRect.Contains((int)e.Event.RawX, (int)e.Event.RawY))
					{
						countryNameAutoComplete.ClearFocus();
						jobFieldAutoComplete.ClearFocus();

					}
				}
                hideSoftKeyboard((Activity)con);
            };

            frame.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            frame.SetBackgroundColor(Color.White);
            frame.SetPadding(10, 10, 10, 10);

            //scrollView1
            ScrollView scrollView1 = new ScrollView(con);
            scrollView1.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.6), GravityFlags.Top | GravityFlags.CenterHorizontal);
            scrollView1.AddView(mainLayout);
            frame.AddView(scrollView1);

            //buttomButtonLayout
            buttomButtonLayout = new FrameLayout(con);
            buttomButtonLayout.SetBackgroundColor(Color.Transparent);
            buttomButtonLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.1), GravityFlags.Bottom | GravityFlags.CenterHorizontal);

            //propertyButton
            propertyButton = new Button(con);
            propertyButton.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent, GravityFlags.Bottom | GravityFlags.CenterHorizontal);
            propertyButton.Text = "OPTIONS";
            propertyButton.Gravity = GravityFlags.Start;
            propertyFrameLayout = new FrameLayout(con);
            propertyFrameLayout.SetBackgroundColor(Color.Rgb(236, 236, 236));
            propertyFrameLayout.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.4), GravityFlags.CenterHorizontal);
            propertyFrameLayout.AddView(GetPropertyLayout(con));

            //propertyButton Click Listener
            propertyButton.Click += (object sender, EventArgs e) =>
            {
                buttomButtonLayout.RemoveAllViews();
                propertyFrameLayout.RemoveAllViews();
                countryNameAutoComplete.ClearFocus();
                jobFieldAutoComplete.ClearFocus();
                scrollView.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.4), GravityFlags.Bottom | GravityFlags.CenterHorizontal);

				propertyFrameLayout.AddView(GetPropertyLayout(con));
            };

            //scrollView
            scrollView = new ScrollView(con);
            scrollView.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.4), GravityFlags.Bottom | GravityFlags.CenterHorizontal);
            scrollView.AddView(propertyFrameLayout);

            frame.AddView(scrollView);
            frame.AddView(buttomButtonLayout);
            frame.FocusableInTouchMode = true;
        }
        private void AutoEditText_FocusChange1(object sender, View.FocusChangeEventArgs e)
        {
            if ((sender as EditText).IsFocused)
            {
                propertyFrameLayout.RemoveAllViews();
                buttomButtonLayout.RemoveAllViews();
                scrollView.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.1), GravityFlags.Bottom | GravityFlags.CenterHorizontal);
				buttomButtonLayout.AddView(propertyButton);
            }
        }

        private void AutoEditText_FocusChange(object sender, View.FocusChangeEventArgs e)
        {
            if ((sender as EditText).IsFocused)
            {
                propertyFrameLayout.RemoveAllViews();
                buttomButtonLayout.RemoveAllViews();
                scrollView.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(totalHeight * 0.1), GravityFlags.Bottom | GravityFlags.CenterHorizontal);
				buttomButtonLayout.AddView(propertyButton);
            }
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
        private int getStatusBarHeight(Android.Content.Context con)
        {
            int barHeight = 0;
            int resourceId = con.Resources.GetIdentifier("status_bar_height", "dimen", "android");
            if (resourceId > 0)
            {
                barHeight = con.Resources.GetDimensionPixelSize(resourceId);
            }
            return barHeight;
        }

        private int getNavigationBarHeight(Android.Content.Context con)
        {
            int navBarHeight = 0;
            int resourceId = con.Resources.GetIdentifier("navigation_bar_height", "dimen", "android");
            if (resourceId > 0)
            {
                navBarHeight = con.Resources.GetDimensionPixelSize(resourceId);
            }
            return navBarHeight;
        }
    }
}