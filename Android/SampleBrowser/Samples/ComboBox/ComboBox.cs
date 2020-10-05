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
using Android.Graphics;
using Syncfusion.Android.ComboBox;
using System.Collections.Generic;

namespace SampleBrowser
{
	public class ComboBox : SamplePage
	{
		public ComboBox()
		{

		}

		LinearLayout mainLayout;
		public override View GetSampleContent(Android.Content.Context con)
		{
			SamplePageContents(con);
			ControlPageContents(con);
			mainLayout = new LinearLayout(con);
			mainLayout.SetPadding(20, 20, 20, 30);
			mainLayout.Orientation = Orientation.Vertical;
            mainLayout.FocusableInTouchMode = true;
			mainLayout.AddView(scaleLabel);
			mainLayout.AddView(scaleLabelSpacing);

			mainLayout.AddView(sizeLabel);
			mainLayout.AddView(sizeComboBox);
			mainLayout.AddView(sizeLabelSpacing);
			mainLayout.AddView(resolutionLabelSpacing);

			mainLayout.AddView(resolutionLabel);
			mainLayout.AddView(resolutionComboBox);
			mainLayout.AddView(controlSpacing1);

			mainLayout.AddView(controlSpacing2);
			mainLayout.AddView(orientationLabel);
			mainLayout.AddView(orientationComboBox);
			mainLayout.AddView(orientationLabelSpacing);

			return mainLayout;
		}

		public override View GetPropertyWindowLayout(Android.Content.Context context)
		{
			Editable(context);
			DiacriticMethod(context);
			AutoCompleteModeLayout(context);
			//SizeLayout(context);
			TextColorLayout(context);
			BackColorLayout(context);
			WaterMarkLayout(context);

			LinearLayout ln = new LinearLayout(context);
			ln.AddView(propertyLayout);

			return ln;
		}

		private TextView scaleLabel, sizeLabel, scaleLabelSpacing, sizeLabelSpacing;
		private TextView resolutionLabel, resolutionLabelSpacing, orientationLabel, orientationLabelSpacing;
		private TextView controlSpacing1, controlSpacing2;
		private void SamplePageContents(Android.Content.Context con)
		{

			//scaleLabel
			scaleLabel = new TextView(con);
			scaleLabel.Text = "Scale and layout";
			scaleLabel.TextSize = 18;
			scaleLabel.Typeface = Typeface.DefaultBold;

			//jobSearchLabelSpacing
			scaleLabelSpacing = new TextView(con);
			scaleLabelSpacing.SetHeight(40);

			//sizeLabel
			sizeLabel = new TextView(con);
			sizeLabel.Text = "Change the size of the text, apps and other items";
			sizeLabel.TextSize = 18;

			//countryLabelSpacing
			sizeLabelSpacing = new TextView(con);
			sizeLabelSpacing.SetHeight(10);

			//countryAutoCompleteSpacing
			controlSpacing1 = new TextView(con);
			controlSpacing1.SetHeight(30);

			//jobFieldLabel
			resolutionLabel = new TextView(con);
			resolutionLabel.Text = "Resolution";
			resolutionLabel.TextSize = 18;

			//jobFieldLabelSpacing
			resolutionLabelSpacing = new TextView(con);
			resolutionLabelSpacing.SetHeight(30);

			//jobFieldAutoCompleteSpacing
			controlSpacing2 = new TextView(con);
			controlSpacing2.SetHeight(30);

			//orientationLabel
			orientationLabel = new TextView(con);
			orientationLabel.Text = "Orientation";
			orientationLabel.TextSize = 18;

			//experienceLabelSpacing
			orientationLabelSpacing = new TextView(con);
			orientationLabelSpacing.SetHeight(10);

		}

		private SfComboBox sizeComboBox, orientationComboBox, resolutionComboBox;
		private void ControlPageContents(Android.Content.Context con)
		{
			List<string> sizeList = new List<string>();
			sizeList.Add("100%");
			sizeList.Add("125%");
			sizeList.Add("150% (Recommended)");
			sizeList.Add("175%");

			List<string> resolutionList = new List<string>();
			resolutionList.Add("1920 x 1080 (Recommended)");
			resolutionList.Add("1680 x 1050");
			resolutionList.Add("1600 x 900");
			resolutionList.Add("1440 x 900");
			resolutionList.Add("1400 x 1050");
			resolutionList.Add("1366 x 768");
			resolutionList.Add("1360 x 768");
			resolutionList.Add("1280 x 1024");
			resolutionList.Add("1280 x 960");
			resolutionList.Add("1280 x 720");
			resolutionList.Add("854 x 480");
			resolutionList.Add("800 x 480");
			resolutionList.Add("480 X 640");
			resolutionList.Add("480 x 320");
			resolutionList.Add("432 x 240");
			resolutionList.Add("360 X 640");
			resolutionList.Add("320 x 240");

			List<string> orientationList = new List<string>();
			orientationList.Add("Landscape");
			orientationList.Add("Portrait");
			orientationList.Add("Landscape (flipped)");
			orientationList.Add("Portrait (flipped)");

			sizeComboBox = new SfComboBox(con);
			sizeComboBox.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 45);
			sizeComboBox.Watermark = "Search Here";
			sizeComboBox.GetAutoEditText().SetTextSize(ComplexUnitType.Sp, 16);
			sizeComboBox.Text = "150% (Recommended)";
			sizeComboBox.DataSource = sizeList;


			resolutionComboBox = new SfComboBox(con);
			resolutionComboBox.MaximumDropDownHeight = 200;
			resolutionComboBox.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 45);
			resolutionComboBox.Watermark = "Search Here";
			resolutionComboBox.GetAutoEditText().SetTextSize(ComplexUnitType.Sp, 16);
			resolutionComboBox.Text = "1920 x 1080 (Recommended)";
			resolutionComboBox.DataSource = resolutionList;


			orientationComboBox = new SfComboBox(con);
			orientationComboBox.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, 45);
			orientationComboBox.Watermark = "Search Here";
			orientationComboBox.GetAutoEditText().SetTextSize(ComplexUnitType.Sp, 16);
			orientationComboBox.Text = "Landscape";
			orientationComboBox.DataSource = orientationList;
		}

		private bool isEditable;
		private LinearLayout isEditableLayout, propertyLayout;
		int width;
		private void Editable(Android.Content.Context context)
		{
			width = context.Resources.DisplayMetrics.WidthPixels - 40;
			propertyLayout = new LinearLayout(context);
			//propertyLayout.SetBackgroundColor(Color.Red);
			propertyLayout.Orientation = Orientation.Vertical;
			/*************
            **IsEditable**
            *************/
			TextView isEditableText = new TextView(context);
			isEditableText.Text = "IsEditable";
			isEditableText.TextAlignment = TextAlignment.TextStart;
			isEditableText.Gravity = GravityFlags.Start;
			isEditableText.LayoutParameters = new LinearLayout.LayoutParams((int)(width - (100 * context.Resources.DisplayMetrics.Density)), LinearLayout.LayoutParams.MatchParent);

			isEditableText.TextSize = 20;

			//isEditableCheckBox
			Switch isEditableCheckBox = new Switch(context);
			isEditableCheckBox.LayoutParameters = new LinearLayout.LayoutParams((int)(100 * context.Resources.DisplayMetrics.Density), LinearLayout.LayoutParams.MatchParent);

			isEditableCheckBox.Checked = false;
			isEditableCheckBox.CheckedChange += (object send, CompoundButton.CheckedChangeEventArgs eve) =>
			{
				if (!eve.IsChecked)
					isEditable = false;
				else
					isEditable = true;
			};

			TextView textSpacing = new TextView(context);
			textSpacing.LayoutParameters = new LinearLayout.LayoutParams((int)(width / 2.2), 10);

			TextView textSpacing1 = new TextView(context);
			propertyLayout.AddView(textSpacing1);

			//isEditableLayout
			isEditableLayout = new LinearLayout(context);
			isEditableLayout.LayoutParameters = new LinearLayout.LayoutParams(width, LinearLayout.LayoutParams.MatchParent);
			isEditableLayout.AddView(isEditableText);
			//isEditableLayout.AddView(textSpacing);
			isEditableLayout.AddView(isEditableCheckBox);
			isEditableLayout.Orientation = Orientation.Horizontal;
			propertyLayout.AddView(isEditableLayout);

			TextView textSpacing2 = new TextView(context);
			//propertyLayout.AddView(textSpacing2);
		}

		private bool diacritic = false;
		private void DiacriticMethod(Android.Content.Context context)
		{
			/*************
            **Diacritic**
            *************/
			TextView diacriticText = new TextView(context);
			diacriticText.TextAlignment = TextAlignment.TextStart;
			diacriticText.Gravity = GravityFlags.Start;
			diacriticText.LayoutParameters = new LinearLayout.LayoutParams((int)(width - (100 * context.Resources.DisplayMetrics.Density)), LinearLayout.LayoutParams.MatchParent);

			diacriticText.Text = "Diacritic";
			diacriticText.TextSize = 20;

			//isEditableCheckBox
			Switch diacriticCheckBox = new Switch(context);
			diacriticCheckBox.LayoutParameters = new LinearLayout.LayoutParams((int)(100 * context.Resources.DisplayMetrics.Density), LinearLayout.LayoutParams.MatchParent);

            diacriticCheckBox.Checked = false;
			diacriticCheckBox.CheckedChange += (object send, CompoundButton.CheckedChangeEventArgs eve) =>
			{
				if (!eve.IsChecked)
					diacritic = false;
				else
					diacritic = true;
			};

			TextView textSpacing = new TextView(context);
			textSpacing.LayoutParameters = new LinearLayout.LayoutParams((int)(width / 2), 10);

			TextView textSpacing1 = new TextView(context);
			propertyLayout.AddView(textSpacing1);
			//isEditableLayout
			isEditableLayout = new LinearLayout(context);
			isEditableLayout.LayoutParameters = new LinearLayout.LayoutParams(width, LinearLayout.LayoutParams.MatchParent);
			isEditableLayout.AddView(diacriticText);
			//isEditableLayout.AddView(textSpacing);
			isEditableLayout.AddView(diacriticCheckBox);
			isEditableLayout.Orientation = Orientation.Horizontal;
			propertyLayout.AddView(isEditableLayout);
		}

		Spinner comboBoxModeSpinner;
		LinearLayout comboBoxModeLayout;
		ArrayAdapter<String> comboBoxModeDataAdapter;
		ComboBoxMode comboBoxMode;
		private void AutoCompleteModeLayout(Android.Content.Context context)
		{
			/*******************
            **AutoCompleteMode**
            ********************/
			TextView comboBoxModeLabel = new TextView(context);
			comboBoxModeLabel.Text = "ComboBox Mode";
			comboBoxModeLabel.TextSize = 20;
			comboBoxModeLabel.Gravity = GravityFlags.Left;

			TextView textSpacing1 = new TextView(context);
			propertyLayout.AddView(textSpacing1);

			comboBoxModeSpinner = new Spinner(context, SpinnerMode.Dialog);
			comboBoxModeSpinner.LayoutParameters = new LinearLayout.LayoutParams(width, LinearLayout.LayoutParams.MatchParent);

			comboBoxModeLayout = new LinearLayout(context);
			comboBoxModeLayout.AddView(comboBoxModeLabel);
			comboBoxModeLayout.AddView(comboBoxModeSpinner);
			comboBoxModeLayout.Orientation = Orientation.Vertical;
			propertyLayout.AddView(comboBoxModeLayout);

			//ComboBoxModeList
			List<String> comboBoxModeList = new List<String>();
			comboBoxModeList.Add("Suggest");
			comboBoxModeList.Add("SuggestAppend");
			comboBoxModeList.Add("Append");
			comboBoxModeDataAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, comboBoxModeList);
			comboBoxModeDataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			comboBoxModeSpinner.Adapter = comboBoxModeDataAdapter;

			//autoCompleteModeSpinner ItemSelected Listener
			comboBoxModeSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
			{
				String selectedItem = comboBoxModeDataAdapter.GetItem(e.Position);
				if (selectedItem.Equals("Suggest"))
				{
					comboBoxMode = ComboBoxMode.Suggest;

				}
				else if (selectedItem.Equals("SuggestAppend"))
				{
					comboBoxMode = ComboBoxMode.SuggestAppend;

				}
				else if (selectedItem.Equals("Append"))
				{
					comboBoxMode = ComboBoxMode.Append;
				}
			};
		}

		Spinner sizeSpinner;
		LinearLayout sizeLayout;
		ArrayAdapter<String> sizeDataAdapter;
		int textSize = 18;
		private void SizeLayout(Android.Content.Context context)
		{
			/*******************
            **AutoCompleteMode**
            ********************/
			TextView sizeLabel = new TextView(context);
			sizeLabel.Text = "Size";
			sizeLabel.TextSize = 20;
			sizeLabel.Gravity = GravityFlags.Left;

			TextView textSpacing1 = new TextView(context);
			propertyLayout.AddView(textSpacing1);

			sizeSpinner = new Spinner(context, SpinnerMode.Dialog);
			sizeSpinner.LayoutParameters = new LinearLayout.LayoutParams(width, LinearLayout.LayoutParams.MatchParent);

			sizeLayout = new LinearLayout(context);
			sizeLayout.AddView(sizeLabel);
			sizeLayout.AddView(sizeSpinner);
			sizeLayout.Orientation = Orientation.Vertical;
			propertyLayout.AddView(sizeLayout);

			//ComboBoxModeList
			List<String> sizeList = new List<String>();
			sizeList.Add("Small");
			sizeList.Add("Medium");
			sizeList.Add("Large");
			sizeDataAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, sizeList);
			sizeDataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			sizeSpinner.Adapter = sizeDataAdapter;

			//autoCompleteModeSpinner ItemSelected Listener
			sizeSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
			{
				String selectedItem = comboBoxModeDataAdapter.GetItem(e.Position);
				if (selectedItem.Equals("Small"))
				{
					textSize = 14;

				}
				else if (selectedItem.Equals("Medium"))
				{
					textSize = 18;

				}
				else if (selectedItem.Equals("Large"))
				{
					textSize = 20;
				}
			};
		}

		Spinner textColorSpinner;
		LinearLayout textColorLayout;
		ArrayAdapter<String> textColorDataAdapter;
		Color textColor = Color.Black;
		private void TextColorLayout(Android.Content.Context context)
		{
			/*******************
            **AutoCompleteMode**
            ********************/
			TextView textColorLabel = new TextView(context);
			textColorLabel.Text = "Text Color";
			textColorLabel.TextSize = 20;
			textColorLabel.Gravity = GravityFlags.Left;

			TextView textSpacing1 = new TextView(context);
			propertyLayout.AddView(textSpacing1);

			textColorSpinner = new Spinner(context, SpinnerMode.Dialog);
			textColorSpinner.LayoutParameters = new LinearLayout.LayoutParams(width, LinearLayout.LayoutParams.MatchParent);

			textColorLayout = new LinearLayout(context);
			textColorLayout.AddView(textColorLabel);
			textColorLayout.AddView(textColorSpinner);
			textColorLayout.Orientation = Orientation.Vertical;
			propertyLayout.AddView(textColorLayout);

			//ComboBoxModeList
			List<String> textColorList = new List<String>();
			textColorList.Add("Black");
			textColorList.Add("Blue");
			textColorList.Add("Red");
			textColorList.Add("Yellow");
			textColorDataAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, textColorList);
			textColorDataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			textColorSpinner.Adapter = textColorDataAdapter;

			//autoCompleteModeSpinner ItemSelected Listener
			textColorSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
			{
				String selectedItem = textColorDataAdapter.GetItem(e.Position);
				if (selectedItem.Equals("Black"))
				{
					textColor = Color.Black;
				}
				else if (selectedItem.Equals("Blue"))
				{
					textColor = Color.Blue;
				}
				else if (selectedItem.Equals("Red"))
				{
					textColor = Color.Red;
				}
				else if (selectedItem.Equals("Yellow"))
				{
					textColor = Color.Yellow;
				}
			};
		}

		Spinner backColorSpinner;
		LinearLayout backColorLayout;
		ArrayAdapter<String> backColorDataAdapter;
		Color backColor = Color.Transparent;
		private void BackColorLayout(Android.Content.Context context)
		{
			/*******************
            **AutoCompleteMode**
            ********************/
			TextView backColorLabel = new TextView(context);
			backColorLabel.Text = "Background Color";
			backColorLabel.TextSize = 20;
			backColorLabel.Gravity = GravityFlags.Left;

			TextView textSpacing1 = new TextView(context);
			propertyLayout.AddView(textSpacing1);

			backColorSpinner = new Spinner(context, SpinnerMode.Dialog);
			backColorSpinner.LayoutParameters = new LinearLayout.LayoutParams(width, LinearLayout.LayoutParams.MatchParent);

			backColorLayout = new LinearLayout(context);
			backColorLayout.AddView(backColorLabel);
			backColorLayout.AddView(backColorSpinner);
			backColorLayout.Orientation = Orientation.Vertical;
			propertyLayout.AddView(backColorLayout);

			//ComboBoxModeList
			List<String> backColorList = new List<String>();
			backColorList.Add("Transparent");
			backColorList.Add("Blue");
			backColorList.Add("Red");
			backColorList.Add("Yellow");
			backColorDataAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, backColorList);
			backColorDataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			backColorSpinner.Adapter = backColorDataAdapter;

			//autoCompleteModeSpinner ItemSelected Listener
			backColorSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) =>
			{
				String selectedItem = backColorDataAdapter.GetItem(e.Position);
				if (selectedItem.Equals("Transparent"))
				{
					backColor = Color.Transparent;
				}
				else if (selectedItem.Equals("Blue"))
				{
					backColor = Color.Blue;
				}
				else if (selectedItem.Equals("Red"))
				{
					backColor = Color.Red;
				}
				else if (selectedItem.Equals("Yellow"))
				{
					backColor = Color.Yellow;
				}
			};
		}


		EditText watermarkText;
		string waterMark;
		LinearLayout watermarkLayout;
		private void WaterMarkLayout(Android.Content.Context context)
		{
			/************************
             **Watermark**
             ************************/
			TextView watermarkLabel = new TextView(context);
			watermarkLabel.LayoutParameters = new LinearLayout.LayoutParams((int)(width - (200 * context.Resources.DisplayMetrics.Density)), LinearLayout.LayoutParams.MatchParent);

			watermarkLabel.Text = "Watermark";
			watermarkLabel.TextSize = 20;

			//watermarkText
			watermarkText = new EditText(context);
			watermarkText.LayoutParameters = new LinearLayout.LayoutParams((int)(200 * context.Resources.DisplayMetrics.Density), LinearLayout.LayoutParams.MatchParent);
			watermarkText.Text = "Search Here";
			watermarkText.TextSize = 16;
			//watermarkText.SetWidth(450);
			watermarkText.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) =>
			{
				waterMark = e.Text.ToString();
			};


			TextView spacingText = new TextView(context);
			propertyLayout.AddView(spacingText);

			TextView spacingText2 = new TextView(context);
			spacingText2.LayoutParameters = new LinearLayout.LayoutParams((int)(width / 3), LinearLayout.LayoutParams.MatchParent);

			//MinPrefixCharaterStack
			watermarkLayout = new LinearLayout(context);
			watermarkLayout.LayoutParameters = new LinearLayout.LayoutParams(width, LinearLayout.LayoutParams.MatchParent);
			watermarkLayout.AddView(watermarkLabel);
			// watermarkLayout.AddView(spacingText2);
			watermarkLayout.AddView(watermarkText);
			watermarkLayout.Orientation = Orientation.Horizontal;
			propertyLayout.AddView(watermarkLayout);
		}

		public override void OnApplyChanges()
		{
			sizeComboBox.IsEditableMode = isEditable;
			resolutionComboBox.IsEditableMode = isEditable;
			orientationComboBox.IsEditableMode = isEditable;

			sizeComboBox.IgnoreDiacritic = !diacritic;
			resolutionComboBox.IgnoreDiacritic = !diacritic;
			orientationComboBox.IgnoreDiacritic = !diacritic;

			sizeComboBox.ComboBoxMode = comboBoxMode;
			resolutionComboBox.ComboBoxMode = comboBoxMode;
			orientationComboBox.ComboBoxMode = comboBoxMode;

			sizeComboBox.TextSize = textSize;
			resolutionComboBox.TextSize = textSize;
			orientationComboBox.TextSize = textSize;

			sizeComboBox.TextColor = textColor;
			resolutionComboBox.TextColor = textColor;
			orientationComboBox.TextColor = textColor;

            sizeComboBox.SetBackgroundColor(backColor);
            resolutionComboBox.SetBackgroundColor(backColor);
            orientationComboBox.SetBackgroundColor(backColor);

			sizeComboBox.Watermark = waterMark;
			resolutionComboBox.Watermark = waterMark;
			orientationComboBox.Watermark = waterMark;
		}

	}
}