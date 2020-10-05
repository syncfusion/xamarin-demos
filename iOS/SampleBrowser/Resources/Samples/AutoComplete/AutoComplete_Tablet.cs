#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.SfRangeSlider.iOS;
using System.Collections.Generic;
using Syncfusion.SfAutoComplete.iOS;


#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;

#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using nint = System.Int32;
using nuint = System.Int32;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
using nfloat  = System.Single;
#endif

namespace SampleBrowser
{
	public class AutoComplete_Tablet: SampleView
	{
		NSMutableArray countryList = new NSMutableArray();
		UILabel suggestionModeLabel,autoCompleteModeLabel,minPrefixCharacterLabel,maxDropDownHeightLabel,popupDelayLabel;
		UIButton suggestionButton = new UIButton ();
		UIButton closeButton = new UIButton ();
		UIButton showPropertyButton=new UIButton();
		UIButton autoCompleteButton = new UIButton ();
		UIButton autoCompleteDoneButton = new UIButton ();
		UILabel propertiesLabel = new UILabel ();
		UIView contentView = new UIView ();
		UIView controlView = new UIView ();
		UIButton suggestionDoneButton=new UIButton();
		UIPickerView suggestionModePicker, autoCompleteModePicker;
		UITextView minimumText,maximumText,popUpDelayText;
		UIScrollView subView;
		PickerModel suggestionModel, autoCompleteModel, experienceModel;

		private UIView activeview;             // Controller that activated the keyboard
		private float scroll_amount = 0.0f;    // amount to scroll 
		private float bottom = 0.0f;           // bottom point
		private float offset = 10.0f;          // extra offset
		private bool moveViewUp = false;

		private string selectedType;
		private readonly IList<string> exp = new List<string> ();
		private string experienceSelectedType;
		UIPickerView experiencePicker = new UIPickerView ();
		SFAutoComplete countryAutoComplete,jobFieldAutoComplete;
		UILabel jobSearchLabel,countryLabel,jobTitleLabel,experienceLabel;
		UIButton searchButton = new UIButton ();
		UIButton experienceButton = new UIButton ();
		UIButton autoCompleteModeDoneButton = new UIButton ();
		NSMutableArray jobTitle = new NSMutableArray ();
		private readonly IList<string> suggestionModeList = new List<string>{
			"StartsWith",
			"StartsWithCaseSensitive",
			"Contains",
			"ContainsWithCaseSensitive",
			"EndsWith",
			"EndsWithCaseSensitive",
			"Equals",
			"EqualsWithCaseSensitive"
		};
		private readonly IList<string> autoCompleteModeList = new List<string>{
			"Append",
			"Suggest",
			"SuggestAppend"
		};
		private readonly IList<string> experienceList = new List<string>{
			"1",
			"2"
		};

		public AutoComplete_Tablet()
		{
			addingCountryList ();
			variableDeclaration();

			//countryAutoComplete
			countryAutoComplete = new SFAutoComplete();
			countryAutoComplete.AutoCompleteSource =countryList ;
			countryAutoComplete.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeStartsWith;
			countryAutoComplete.Watermark= (NSString)"Enter a country name";
			countryAutoComplete.MaxDropDownHeight=90;
			countryAutoComplete.AutoCompleteMode= SFAutoCompleteAutoCompleteMode.SFAutoCompleteAutoCompleteModeSuggest;
			controlView.AddSubview(countryAutoComplete);


			//jobFieldAutoComplete
			jobFieldAutoComplete = new SFAutoComplete();
			jobFieldAutoComplete.AutoCompleteSource = jobTitle;
			jobFieldAutoComplete.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeStartsWith;
			jobFieldAutoComplete.Watermark=(NSString)"Starts with ’S’, ‘M’ or ‘B’";
			jobFieldAutoComplete.MaxDropDownHeight=90;
			jobFieldAutoComplete.AutoCompleteMode= SFAutoCompleteAutoCompleteMode.SFAutoCompleteAutoCompleteModeSuggest;
			controlView.AddSubview(jobFieldAutoComplete);

			this.AddSubview(controlView);
			mainPageDesign();
			autoHide();
			this.loadOptionView();
		}

		public void autoHide()
		{
			NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.DidShowNotification, KeyBoardUpNotification);
			NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, KeyBoardDownNotification);
		}
		private void KeyBoardUpNotification(NSNotification notification)
		{
			
			// get the keyboard size
			var r = UIKeyboard.BoundsFromNotification(notification);

			// Find what opened the keyboard
			foreach (UIView view in this.contentView.Subviews)
			{
				if (view.IsFirstResponder)
					activeview = view;
			}


			if(activeview!=null)
			// Bottom of the controller = initial position + height + offset      
			bottom = ((float)(activeview.Frame.Y + activeview.Frame.Height + offset));

			// Calculate how far we need to scroll
			scroll_amount = ((float)(r.Height - (contentView.Frame.Size.Height - bottom)));

			// Perform the scrolling
			if (scroll_amount > 0)
			{
				moveViewUp = true;
				ScrollTheView(moveViewUp);
			}
			else {
				moveViewUp = false;
			}

		}

		private void KeyBoardDownNotification(NSNotification notification)
		{
			
			if (moveViewUp) { ScrollTheView(false); }
			propertiesLabel.Hidden = false;
			closeButton.Hidden = false;
			activeview = null;
		}

		private void ScrollTheView(bool move)
		{

			// scroll the view up or down
			UIView.BeginAnimations(string.Empty, System.IntPtr.Zero);
			UIView.SetAnimationDuration(0.1);

			var frame = contentView.Frame;

			if (move)
			{
				frame.Y -= scroll_amount;
			}
			else {
				frame.Y += scroll_amount;
				scroll_amount = 0;
			}

			contentView.Frame = frame;
			propertiesLabel.Hidden = true;
			closeButton.Hidden = true;
			UIView.CommitAnimations();
		}

		public void mainPageDesign()
		{ 
			this.jobTitle.Add((NSString)"Banking");
			this.jobTitle.Add((NSString)"Software");
			this.jobTitle.Add((NSString)"Media");
			this.jobTitle.Add((NSString)"Medical");
			this.exp.Add((NSString)"1");
			this.exp.Add((NSString)"2");

			//jobSearchLabel
			jobSearchLabel.Text = "Job  Search";
			jobSearchLabel.TextColor = UIColor.Black;
			jobSearchLabel.TextAlignment = UITextAlignment.Left;
			jobSearchLabel.Font = UIFont.FromName("Helvetica-Bold", 20f);

			//countryLabel
			countryLabel.Text = "Country";
			countryLabel.TextColor = UIColor.Black;
			countryLabel.TextAlignment = UITextAlignment.Left;
			countryLabel.Font = UIFont.FromName("Helvetica", 16f);

			//jobTitleLabel
			jobTitleLabel.Text = "Job Title";
			jobTitleLabel.TextColor = UIColor.Black;
			jobTitleLabel.TextAlignment = UITextAlignment.Left;
			jobTitleLabel.Font = UIFont.FromName("Helvetica", 16f);

			//experienceLabel
			experienceLabel.Text = "Experience";
			experienceLabel.TextColor = UIColor.Black;
			experienceLabel.TextAlignment = UITextAlignment.Left;
			experienceLabel.Font = UIFont.FromName("Helvetica", 16f);

			//searchButton
			searchButton.SetTitle("Search", UIControlState.Normal);
			searchButton.BackgroundColor = UIColor.FromRGB(50, 150, 221);
			searchButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			searchButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			searchButton.Layer.CornerRadius = 8;
			searchButton.Layer.BorderWidth = 2;
			searchButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
			searchButton.TouchUpInside += SelectResults;

			//experienceButton
			experienceButton.SetTitle("1", UIControlState.Normal);
			experienceButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			experienceButton.BackgroundColor = UIColor.Clear;
			experienceButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			experienceButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;
			experienceButton.Layer.BorderWidth = 4;
			experienceButton.Layer.CornerRadius = 8;
			experienceButton.TouchUpInside += ShowExperiencePicker;
			controlView.AddSubview(experienceButton);

			PickerModel models = new PickerModel(this.exp);
			models.PickerChanged += (sender, e) =>
			{
				this.experienceSelectedType = e.SelectedValue;
				experienceButton.SetTitle(experienceSelectedType, UIControlState.Normal);
			};

			//experiencePicker
			experiencePicker.ShowSelectionIndicator = true;
			experiencePicker.Hidden = true;
			experiencePicker.Model = experienceModel;
			experiencePicker.BackgroundColor = UIColor.Gray;

			//autoCompleteDoneButton
			autoCompleteDoneButton.SetTitle("Done\t", UIControlState.Normal);
			autoCompleteDoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			autoCompleteDoneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
			autoCompleteDoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			autoCompleteDoneButton.Hidden = true;
			autoCompleteDoneButton.Font = UIFont.FromName("Helvetica", 16f);
			autoCompleteDoneButton.TouchUpInside += HideexperiencePicker;

			//add view
			controlView.AddSubview(experiencePicker);
			controlView.AddSubview(autoCompleteDoneButton);
			controlView.AddSubview(jobSearchLabel);
			controlView.AddSubview(countryLabel);
			controlView.AddSubview(jobTitleLabel);
			controlView.AddSubview(experienceLabel);
			controlView.AddSubview(searchButton);
			this.AddSubview(controlView);

		}
		public void variableDeclaration()
		{ 
			suggestionModePicker = new UIPickerView();
			autoCompleteModePicker = new UIPickerView();
			suggestionModel = new PickerModel(suggestionModeList);
			suggestionModePicker.Model = suggestionModel;
			autoCompleteModel = new PickerModel(autoCompleteModeList);
			autoCompleteModePicker.Model = autoCompleteModel;
			experienceModel = new PickerModel(experienceList);
			suggestionModeLabel = new UILabel();
			autoCompleteModeLabel = new UILabel();
			minPrefixCharacterLabel = new UILabel();
			maxDropDownHeightLabel = new UILabel();
			popupDelayLabel = new UILabel();
			suggestionButton = new UIButton();
			showPropertyButton = new UIButton();
			autoCompleteButton = new UIButton();
			jobSearchLabel = new UILabel();
			countryLabel = new UILabel();
			jobTitleLabel = new UILabel();
			experienceLabel = new UILabel();
			searchButton = new UIButton();
		}

		public void loadOptionView()
		{
			
			//suggestionModeLabell
			suggestionModeLabel.Text = "Suggestion Mode";
			suggestionModeLabel.TextColor = UIColor.Black;
			suggestionModeLabel.Font = UIFont.FromName("Helvetica", 14f);
			suggestionModeLabel.TextAlignment = UITextAlignment.Left;
			autoCompleteModeLabel.Text = "AutoComplete Mode";
			autoCompleteModeLabel.TextColor = UIColor.Black;
			autoCompleteModeLabel.Font = UIFont.FromName("Helvetica", 14f);
			autoCompleteModeLabel.TextAlignment = UITextAlignment.Left;

			//minPrefixCharacterLabel
			minPrefixCharacterLabel.Text = "Min Prefix Character";
			minPrefixCharacterLabel.TextColor = UIColor.Black;
			minPrefixCharacterLabel.TextAlignment = UITextAlignment.Left;
			minPrefixCharacterLabel.Font = UIFont.FromName("Helvetica", 14f);

			//maxDropDownHeightLabel
			maxDropDownHeightLabel.Text = "Max DropDownHeight";
			maxDropDownHeightLabel.TextColor = UIColor.Black;
			maxDropDownHeightLabel.TextAlignment = UITextAlignment.Left;
			maxDropDownHeightLabel.Font = UIFont.FromName("Helvetica", 14f);

			//popupDelayLabel
			popupDelayLabel.Text = "Popup Delay";
			popupDelayLabel.TextColor = UIColor.Black;
			popupDelayLabel.TextAlignment = UITextAlignment.Left;
			popupDelayLabel.Font = UIFont.FromName("Helvetica", 14f);

			//suggestionButton
			suggestionButton.SetTitle("StartsWith", UIControlState.Normal);
			suggestionButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			suggestionButton.Font = UIFont.FromName("Helvetica", 14f);
			suggestionButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			suggestionButton.Layer.CornerRadius = 8;
			suggestionButton.Layer.BorderWidth = 2;
			suggestionButton.TouchUpInside += ShowsuggestionModePicker;
			suggestionButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;

			//ShowPropertyButton
			showPropertyButton.SetTitle("PROPERTIES\t", UIControlState.Normal);
			showPropertyButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			showPropertyButton.BackgroundColor = UIColor.FromRGB(230, 230, 230);
			showPropertyButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			showPropertyButton.TouchUpInside += ShowsuggestionModePicker;

			//Minimum and Maximum text
			minimumText = new UITextView();
			maximumText = new UITextView();
			popUpDelayText = new UITextView();
			minimumText.Layer.BorderColor = UIColor.Black.CGColor;
			minimumText.TextAlignment = UITextAlignment.Center;
			maximumText.Layer.BorderColor = UIColor.Black.CGColor;
			maximumText.TextAlignment = UITextAlignment.Center;
			popUpDelayText.Layer.BorderColor = UIColor.Black.CGColor;
			popUpDelayText.TextAlignment = UITextAlignment.Center;
			minimumText.BackgroundColor = UIColor.FromRGB(246, 246, 246);
			maximumText.BackgroundColor = UIColor.FromRGB(246, 246, 246);
			popUpDelayText.BackgroundColor = UIColor.FromRGB(246, 246, 246);
			minimumText.KeyboardType = UIKeyboardType.NumberPad;
			maximumText.KeyboardType = UIKeyboardType.NumberPad;
			popUpDelayText.KeyboardType = UIKeyboardType.NumberPad;
			minimumText.Text = "1";
			maximumText.Text = "400";
			popUpDelayText.Text = "100";
			maximumText.Changed += (object sender, EventArgs e) =>
			 {
				 if (maximumText.Text.Length > 0)
				 {
					 countryAutoComplete.MaxDropDownHeight = double.Parse(maximumText.Text);
					 jobFieldAutoComplete.MaxDropDownHeight = double.Parse(maximumText.Text);
				 }
				 else {
					 countryAutoComplete.MaxDropDownHeight = 200;
					 jobFieldAutoComplete.MaxDropDownHeight = 200;
				 }
			 };
			minimumText.Changed += (object sender, EventArgs e) =>
			 {
				 if (minimumText.Text.Length > 0)
				 {
					 countryAutoComplete.MinimumPrefixCharacters = int.Parse(minimumText.Text);
					 jobFieldAutoComplete.MinimumPrefixCharacters = int.Parse(minimumText.Text);
				 }
				 else {
					 countryAutoComplete.MinimumPrefixCharacters = 1;
					 jobFieldAutoComplete.MinimumPrefixCharacters = 1;
				 }
			 };
			popUpDelayText.Changed += (object sender, EventArgs e) =>
			 {
				 if (popUpDelayText.Text.Length > 0)
				 {
					 countryAutoComplete.PopUpDelay = double.Parse(popUpDelayText.Text);
					 jobFieldAutoComplete.PopUpDelay = double.Parse(popUpDelayText.Text);
				 }
				 else
				 {
					 countryAutoComplete.PopUpDelay = 100;
					 jobFieldAutoComplete.PopUpDelay = 100;
				 }
			 };

			//autoCompleteButton
			autoCompleteButton.SetTitle("Suggest", UIControlState.Normal);
			autoCompleteButton.Font = UIFont.FromName("Helvetica", 14f);
			autoCompleteButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			autoCompleteButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			autoCompleteButton.Layer.CornerRadius = 8;
			autoCompleteButton.Layer.BorderWidth = 2;
			autoCompleteButton.TouchUpInside += ShowautoCompleteModePicker;
			autoCompleteButton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;

			//suggestionDoneButton
			suggestionDoneButton.SetTitle("Done\t", UIControlState.Normal);
			suggestionDoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			suggestionDoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			suggestionDoneButton.TouchUpInside += HidePicker;
			suggestionDoneButton.Hidden = true;
			suggestionDoneButton.Font = UIFont.FromName("Helvetica", 16f);
			suggestionDoneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);

			//autocompleteModeDoneButton
			autoCompleteModeDoneButton.SetTitle("Done\t", UIControlState.Normal);
			autoCompleteModeDoneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			autoCompleteModeDoneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			autoCompleteModeDoneButton.TouchUpInside += HidePicker;
			autoCompleteModeDoneButton.Hidden = true;
			autoCompleteDoneButton.Font = UIFont.FromName("Helvetica", 16f);
			autoCompleteModeDoneButton.BackgroundColor = UIColor.FromRGB(240, 240, 240);
			suggestionModel.PickerChanged += suggestionSelectedIndexChanged;
			autoCompleteModel.PickerChanged += autoCompleteSelectedIndexChanged;
			experienceModel.PickerChanged += experienceSelectedIndexChanged;
			suggestionModePicker.ShowSelectionIndicator = true;
			suggestionModePicker.Hidden = true;
			suggestionModePicker.BackgroundColor = UIColor.Gray;
			autoCompleteModePicker.BackgroundColor = UIColor.Gray;
			autoCompleteModePicker.ShowSelectionIndicator = true;
			autoCompleteModePicker.Hidden = true;

			// property window
			subView = new UIScrollView();
			subView.ContentSize = new CGSize(Frame.Width, 450); 
			contentView.AddSubview(suggestionModeLabel);
			contentView.AddSubview(suggestionButton);
			contentView.AddSubview(suggestionModePicker);
			contentView.AddSubview(suggestionDoneButton);
			contentView.AddSubview(autoCompleteModeLabel);
			contentView.AddSubview(autoCompleteButton);
			contentView.AddSubview(autoCompleteModePicker);
			contentView.AddSubview(popupDelayLabel);
			contentView.AddSubview(popUpDelayText);
			contentView.AddSubview(minPrefixCharacterLabel);
			contentView.AddSubview(minimumText);
			contentView.AddSubview(maxDropDownHeightLabel);
			contentView.AddSubview(maximumText);
			contentView.AddSubview(autoCompleteModeDoneButton);
			subView.AddSubview(closeButton);
			contentView.BackgroundColor = UIColor.FromRGB(240, 240, 240);
			subView.BackgroundColor = UIColor.FromRGB(230, 230, 230);
			subView.AddSubview(contentView);
			this.AddSubview(subView);

			propertiesLabel.Text = " OPTIONS";
			subView.AddSubview(propertiesLabel);

			//showPropertyButton
			showPropertyButton.Hidden = true;
			showPropertyButton.SetTitle(" OPTIONS\t", UIControlState.Normal);
			showPropertyButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
			showPropertyButton.BackgroundColor = UIColor.FromRGB(230, 230, 230);
			showPropertyButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			showPropertyButton.TouchUpInside += (object sender, EventArgs e) =>
			{
				subView.Hidden = false;
				showPropertyButton.Hidden = true;
			};
			this.AddSubview(showPropertyButton);

			//closeButton
			closeButton.SetTitle("X\t", UIControlState.Normal);
			closeButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Left;
			closeButton.BackgroundColor = UIColor.FromRGB(230, 230, 230);
			closeButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			closeButton.TouchUpInside += (object sender, EventArgs e) =>
			{
				subView.Hidden = true;
				showPropertyButton.Hidden = false;
			};

			//Adding Gesture
			UITapGestureRecognizer tapgesture = new UITapGestureRecognizer(() =>
			{
				subView.Hidden = true;
				showPropertyButton.Hidden = false;
			}
			);
			propertiesLabel.UserInteractionEnabled = true;
			propertiesLabel.AddGestureRecognizer(tapgesture);
		}

		public void addingCountryList()
		{
			countryList.Add ((NSString)"Afghanistan");
			countryList.Add ((NSString)"Akrotiri");
			countryList.Add ((NSString)"Albania");
			countryList.Add ((NSString)"Algeria");
			countryList.Add ((NSString)"American Samoa");
			countryList.Add ((NSString)"Andorra");
			countryList.Add ((NSString)"Angola");
			countryList.Add ((NSString)"Anguilla");
			countryList.Add ((NSString)"Antarctica");
			countryList.Add ((NSString)"Antigua and Barbuda");
			countryList.Add ((NSString)"Argentina");
			countryList.Add ((NSString)"Armenia");
			countryList.Add ((NSString)"Aruba");
			countryList.Add ((NSString)"Ashmore and Cartier Islands");
			countryList.Add ((NSString)"Australia");
			countryList.Add ((NSString)"Austria");
			countryList.Add ((NSString)"Azerbaijan");
			countryList.Add ((NSString)"Bahamas, The");
			countryList.Add ((NSString)"Bahrain");
			countryList.Add ((NSString)"Bangladesh");
			countryList.Add ((NSString)"Barbados");
			countryList.Add ((NSString)"Bassas da India");
			countryList.Add ((NSString)"Belarus");
			countryList.Add ((NSString)"Belgium");
			countryList.Add ((NSString)"Belize");
			countryList.Add ((NSString)"Benin");
			countryList.Add ((NSString)"Bermuda");
			countryList.Add ((NSString)"Bhutan");
			countryList.Add ((NSString)"Bolivia");
			countryList.Add ((NSString)"Bosnia and Herzegovina");
			countryList.Add ((NSString)"Botswana");
			countryList.Add ((NSString)"Bouvet Island");
			countryList.Add ((NSString)"Brazil");
			countryList.Add ((NSString)"British Indian Ocean Territory");
			countryList.Add ((NSString)"British Virgin Islands");
			countryList.Add ((NSString)"Brunei");
			countryList.Add ((NSString)"Bulgaria");
			countryList.Add ((NSString)"Burkina Faso");
			countryList.Add ((NSString)"Burma");
			countryList.Add ((NSString)"Burundi");
			countryList.Add ((NSString)"Cambodia");
			countryList.Add ((NSString)"Cameroon");
			countryList.Add ((NSString)"Canada");
			countryList.Add ((NSString)"Cape Verde");
			countryList.Add ((NSString)"Cayman Islands");
			countryList.Add ((NSString)"Central African Republic");
			countryList.Add ((NSString)"Chad");
			countryList.Add ((NSString)"Chile");
			countryList.Add ((NSString)"China");
			countryList.Add ((NSString)"Christmas Island");
			countryList.Add ((NSString)"Clipperton Island");
			countryList.Add ((NSString)"Cocos (Keeling) Islands");
			countryList.Add ((NSString)"Colombia");
			countryList.Add ((NSString)"Comoros");
			countryList.Add ((NSString)"Congo");
			countryList.Add ((NSString)"Congo, Republic of the");
			countryList.Add ((NSString)"Cook Islands");
			countryList.Add ((NSString)"Coral Sea Islands");
			countryList.Add ((NSString)"Costa Rica");
			countryList.Add ((NSString)"Cote d'Ivoire");
			countryList.Add ((NSString)"Croatia");
			countryList.Add ((NSString)"Cuba");
			countryList.Add ((NSString)"Cyprus");
			countryList.Add ((NSString)"Czech Republic");
			countryList.Add ((NSString)"Denmark");
			countryList.Add ((NSString)"Dhekelia");
			countryList.Add ((NSString)"Djibouti");
			countryList.Add ((NSString)"Dominica");
			countryList.Add ((NSString)"Dominican Republic");
			countryList.Add ((NSString)"Ecuador");
			countryList.Add ((NSString)"Egypt");
			countryList.Add ((NSString)"El Salvador");
			countryList.Add ((NSString)"Equatorial Guinea");
			countryList.Add ((NSString)"Eritrea");
			countryList.Add ((NSString)"Estonia");
			countryList.Add ((NSString)"Ethiopia");
			countryList.Add ((NSString)"Europa Island");
			countryList.Add ((NSString)"Falkland Islands");
			countryList.Add ((NSString)"Faroe Islands");
			countryList.Add ((NSString)"Fiji");
			countryList.Add ((NSString)"Finland");
			countryList.Add ((NSString)"France");
			countryList.Add ((NSString)"French Guiana");
			countryList.Add ((NSString)"French Polynesia");
			countryList.Add ((NSString)"French Southern and Antarctic Lands");
			countryList.Add ((NSString)"Gabon");
			countryList.Add ((NSString)"Gambia, The");
			countryList.Add ((NSString)"Gaza Strip");
			countryList.Add ((NSString)"Georgia");
			countryList.Add ((NSString)"Germany");
			countryList.Add ((NSString)"Ghana");
			countryList.Add ((NSString)"Gibraltar");
			countryList.Add ((NSString)"Glorioso Islands");
			countryList.Add ((NSString)"Greece");
			countryList.Add ((NSString)"Greenland");
			countryList.Add ((NSString)"Grenada");
			countryList.Add ((NSString)"Guadeloupe");
			countryList.Add ((NSString)"Guam");
			countryList.Add ((NSString)"Guatemala");
			countryList.Add ((NSString)"Guernsey");
			countryList.Add ((NSString)"Guinea");
			countryList.Add ((NSString)"Guinea-Bissau");
			countryList.Add ((NSString)"Guyana");
			countryList.Add ((NSString)"Haiti");
			countryList.Add ((NSString)"Heard Island and McDonald Islands");
			countryList.Add ((NSString)"Holy See");
			countryList.Add ((NSString)"Honduras");
			countryList.Add ((NSString)"Hong Kong");
			countryList.Add ((NSString)"Hungary");
			countryList.Add ((NSString)"Iceland");
			countryList.Add ((NSString)"India");
			countryList.Add ((NSString)"Indonesia");
			countryList.Add ((NSString)"Iran");
			countryList.Add ((NSString)"Iraq");
			countryList.Add ((NSString)"Ireland");
			countryList.Add ((NSString)"Isle of Man");
			countryList.Add ((NSString)"Israel");
			countryList.Add ((NSString)"Italy");
			countryList.Add ((NSString)"Jamaica");
			countryList.Add ((NSString)"Jan Mayen");
			countryList.Add ((NSString)"Japan");
			countryList.Add ((NSString)"Jersey");
			countryList.Add ((NSString)"Jordan");
			countryList.Add ((NSString)"Juan de Nova Island");
			countryList.Add ((NSString)"Kazakhstan");
			countryList.Add ((NSString)"Kenya");
			countryList.Add ((NSString)"Kiribati");
			countryList.Add ((NSString)"Korea, North");
			countryList.Add ((NSString)"Korea, South");
			countryList.Add ((NSString)"Kuwait");
			countryList.Add ((NSString)"Kyrgyzstan");
			countryList.Add ((NSString)"Laos");
			countryList.Add ((NSString)"Latvia");
			countryList.Add ((NSString)"Lebanon");
			countryList.Add ((NSString)"Lesotho");
			countryList.Add ((NSString)"Liberia");
			countryList.Add ((NSString)"Libya");
			countryList.Add ((NSString)"Liechtenstein");
			countryList.Add ((NSString)"Lithuania");
			countryList.Add ((NSString)"Luxembourg");
			countryList.Add ((NSString)"Macau");
			countryList.Add ((NSString)"Macedonia");
			countryList.Add ((NSString)"Madagascar");
			countryList.Add ((NSString)"Malawi");
			countryList.Add ((NSString)"Malaysia");
			countryList.Add ((NSString)"Maldives");
			countryList.Add ((NSString)"Mali");
			countryList.Add ((NSString)"Malta");
			countryList.Add ((NSString)"Marshall Islands");
			countryList.Add ((NSString)"Martinique");
			countryList.Add ((NSString)"Mauritania");
			countryList.Add ((NSString)"Mauritius");
			countryList.Add ((NSString)"Mayotte");
			countryList.Add ((NSString)"Mexico");
			countryList.Add ((NSString)"Micronesia");
			countryList.Add ((NSString)"Moldova");
			countryList.Add ((NSString)"Monaco");
			countryList.Add ((NSString)"Mongolia");
			countryList.Add ((NSString)"Montserrat");
			countryList.Add ((NSString)"Morocco");
			countryList.Add ((NSString)"Mozambique");
			countryList.Add ((NSString)"Namibia");
			countryList.Add ((NSString)"Nauru");
			countryList.Add ((NSString)"Navassa Island");
			countryList.Add ((NSString)"Nepal");
			countryList.Add ((NSString)"Netherlands");
			countryList.Add ((NSString)"Netherlands Antilles");
			countryList.Add ((NSString)"New Caledonia");
			countryList.Add ((NSString)"New Zealand");
			countryList.Add ((NSString)"Nicaragua");
			countryList.Add ((NSString)"Niger");
			countryList.Add ((NSString)"Nigeria");
			countryList.Add ((NSString)"Niue");
			countryList.Add ((NSString)"Norfolk Island");
			countryList.Add ((NSString)"Northern Mariana Islands");
			countryList.Add ((NSString)"Norway");
			countryList.Add ((NSString)"Oman");
			countryList.Add ((NSString)"Pakistan");
			countryList.Add ((NSString)"Palau");
			countryList.Add ((NSString)"Panama");
			countryList.Add ((NSString)"Papua New Guinea");
			countryList.Add ((NSString)"Paracel Islands");
			countryList.Add ((NSString)"Paraguay");
			countryList.Add ((NSString)"Peru");
			countryList.Add ((NSString)"Philippines");
			countryList.Add ((NSString)"Pitcairn Islands");
			countryList.Add ((NSString)"Poland");
			countryList.Add ((NSString)"Portugal");
			countryList.Add ((NSString)"Puerto Rico");
			countryList.Add ((NSString)"Qatar");
			countryList.Add ((NSString)"Reunion");
			countryList.Add ((NSString)"Romania");
			countryList.Add ((NSString)"Russia");
			countryList.Add ((NSString)"Rwanda");
			countryList.Add ((NSString)"Saint Helena");
			countryList.Add ((NSString)"Saint Kitts and Nevis");
			countryList.Add ((NSString)"Saint Lucia");
			countryList.Add ((NSString)"Saint Pierre and Miquelon");
			countryList.Add ((NSString)"Saint Vincent");
			countryList.Add ((NSString)"Samoa");
			countryList.Add ((NSString)"San Marino");
			countryList.Add ((NSString)"Sao Tome and Principe");
			countryList.Add ((NSString)"Saudi Arabia");
			countryList.Add ((NSString)"Senegal");
			countryList.Add ((NSString)"Serbia and Montenegro");
			countryList.Add ((NSString)"Seychelles");
			countryList.Add ((NSString)"Sierra Leone");
			countryList.Add ((NSString)"Singapore");
			countryList.Add ((NSString)"Slovakia");
			countryList.Add ((NSString)"Slovenia");
			countryList.Add ((NSString)"Solomon Islands");
			countryList.Add ((NSString)"Somalia");
			countryList.Add ((NSString)"South Africa");
			countryList.Add ((NSString)"South Georgia");
			countryList.Add ((NSString)"Spain");
			countryList.Add ((NSString)"Spratly Islands");
			countryList.Add ((NSString)"Sri Lanka");
			countryList.Add ((NSString)"Sudan");
			countryList.Add ((NSString)"Suriname");
			countryList.Add ((NSString)"Svalbard");
			countryList.Add ((NSString)"Swaziland");
			countryList.Add ((NSString)"Sweden");
			countryList.Add ((NSString)"Switzerland");
			countryList.Add ((NSString)"Syria");
			countryList.Add ((NSString)"Taiwan");
			countryList.Add ((NSString)"Tajikistan");
			countryList.Add ((NSString)"Tanzania");
			countryList.Add ((NSString)"Thailand");
			countryList.Add ((NSString)"Timor-Leste");
			countryList.Add ((NSString)"Togo");
			countryList.Add ((NSString)"Tokelau");
			countryList.Add ((NSString)"Tonga");
			countryList.Add ((NSString)"Trinidad and Tobago");
			countryList.Add ((NSString)"Tromelin Island");
			countryList.Add ((NSString)"Tunisia");
			countryList.Add ((NSString)"Turkey");
			countryList.Add ((NSString)"Turkmenistan");
			countryList.Add ((NSString)"Turks and Caicos Islands");
			countryList.Add ((NSString)"Tuvalu");
			countryList.Add ((NSString)"Uganda");
			countryList.Add ((NSString)"Ukraine");
			countryList.Add ((NSString)"United Arab Emirates");
			countryList.Add ((NSString)"United Kingdom");
			countryList.Add ((NSString)"United States");
			countryList.Add ((NSString)"Uruguay");
			countryList.Add ((NSString)"Uzbekistan");
			countryList.Add ((NSString)"Vanuatu");
			countryList.Add ((NSString)"Venezuela");
			countryList.Add ((NSString)"Vietnam");
			countryList.Add ((NSString)"Virgin Islands");
			countryList.Add ((NSString)"Wake Island");
			countryList.Add ((NSString)"Wallis and Futuna");
			countryList.Add ((NSString)"West Bank");
			countryList.Add ((NSString)"Western Sahara");
			countryList.Add ((NSString)"Yemen");
			countryList.Add ((NSString)"Zambia");
			countryList.Add ((NSString)"Zimbabwe");
		}

		void ShowExperiencePicker (object sender, EventArgs e) {
			searchButton.Hidden = true;
			autoCompleteDoneButton.Hidden = false;
			experiencePicker.Hidden = false;
			this.BecomeFirstResponder ();

		}

		public override void TouchesBegan (NSSet touches, UIEvent evt){
			this.EndEditing (true);
		}

		void SelectResults (object sender, EventArgs e) {
			if (countryAutoComplete.TextField.Text != "" && jobFieldAutoComplete.TextField.Text != "") {
				NSString s1 = (NSString)countryAutoComplete.Text;
				NSString s2 = (NSString)jobFieldAutoComplete.Text;
				nint s4 = 0;
				if (s1 != null && s2 != null) {
					Random r = new Random();
					s4 = r.Next (5,60);
				}
				UIAlertView v = new UIAlertView ();
				v.Title = "Results";
				if (s4 > 0)
					v.Message = s4 + " Jobs found";
				else
					v.Message = "0 Jobs found";
				v.AddButton ("OK");
				v.Show ();
			} else {
				UIAlertView v1 = new UIAlertView ();
				v1.Title = "Results";
				v1.AddButton ("OK");
				v1.Message = "0 Jobs found";
				v1.Show ();
			}
			this.BecomeFirstResponder ();
		}

		void HideexperiencePicker (object sender, EventArgs e) {
			searchButton.Hidden = false;
			autoCompleteDoneButton.Hidden = true;
			experiencePicker.Hidden = true;
			this.BecomeFirstResponder ();
			popUpDelayText.Hidden = false;
			popupDelayLabel.Hidden = false;
			maxDropDownHeightLabel.Hidden = false;
			maximumText.Hidden = false;
			minimumText.Hidden = false;
			minPrefixCharacterLabel.Hidden = false;
			autoCompleteButton.Hidden = false;

		}

		public override void LayoutSubviews ()
		{

			foreach (var view in this.Subviews) {
				view.Frame = Bounds;
				subView.Frame = new CGRect (0, view.Frame.Size.Height-view.Frame.Size.Height/3, view.Frame.Size.Width, view.Frame.Height / 3 );
				controlView.Frame=new CGRect(150,40,view.Frame.Size.Width-300,view.Frame.Size.Height-40);
				contentView.Frame=new CGRect(0,40,subView.Frame.Size.Width,subView.Frame.Size.Height);
				suggestionModeLabel.Frame = new CGRect ( 110,10,200, 30);
				autoCompleteModeLabel.Frame = new CGRect ( 110, 60, 200, 30);
				minPrefixCharacterLabel.Frame = new CGRect ( 110, 110,contentView.Frame.Width-210 , 30);
				maxDropDownHeightLabel.Frame = new CGRect (110, 160, contentView.Frame.Width - 210, 30);
				suggestionButton.Frame=new CGRect(340, 10, contentView.Frame.Size.Width - 520, 30);	
				popupDelayLabel.Frame = new CGRect (110, 210, contentView.Frame.Width - 210, 30);
				autoCompleteButton.Frame=new CGRect(340, 60, contentView.Frame.Size.Width - 520, 30);	
				minimumText.Frame = new CGRect (340, 110, contentView.Frame.Size.Width - 520, 30);
				maximumText.Frame = new CGRect (340, 160, contentView.Frame.Size.Width - 520, 30);
				popUpDelayText.Frame = new CGRect (340, 210, contentView.Frame.Size.Width - 520, 30);
				showPropertyButton.Frame = new CGRect (0,this.Frame.Size.Height-25,this.Frame.Size.Width,30);
				suggestionModePicker.Frame = new CGRect (100, 20, contentView.Frame.Size.Width-200, 200);
				autoCompleteModePicker.Frame = new CGRect (100, 20, contentView.Frame.Size.Width-200 , 200);
				suggestionDoneButton.Frame = new CGRect (100, 20, contentView.Frame.Size.Width-200, 30);
				autoCompleteModeDoneButton.Frame=new CGRect (100, 20, contentView.Frame.Size.Width-200, 30);
				jobSearchLabel.Frame = new CGRect ( 10, 10, view.Frame.Width, 30);
				countryLabel.Frame = new CGRect ( 10, 50, view.Frame.Width, 30);
				jobTitleLabel.Frame = new CGRect ( 10,130 ,view.Frame.Width, 30);
				experienceLabel.Frame = new CGRect ( 10,210, controlView.Frame.Width, 30);
				countryAutoComplete.Frame = new CGRect ( 10, 80, controlView.Frame.Size.Width -20, 40);
				jobFieldAutoComplete.Frame = new CGRect ( 10, 160, controlView.Frame.Size.Width - 20, 40);
				experienceButton.Frame = new CGRect ( 10, 240, controlView.Frame.Size.Width - 20, 40);
				experiencePicker.Frame=new CGRect(0,325, controlView.Frame.Size.Width,150);
				autoCompleteDoneButton.Frame=new CGRect(0, 325, controlView.Frame.Size.Width, 30);
				searchButton.Frame = new CGRect ( 10,300, controlView.Frame.Size.Width -20, 40);
				closeButton.Frame = new CGRect (view.Frame.Width - 30, 5, 20, 30);
				propertiesLabel.Frame = new CGRect (10, 5, view.Frame.Width, 30);
			}
			base.LayoutSubviews ();
		}


		void ShowsuggestionModePicker (object sender, EventArgs e) {
			minimumText.EndEditing(true);
			maximumText.EndEditing(true);
			popUpDelayText.EndEditing(true);
			suggestionDoneButton.Hidden = false;
			autoCompleteModeDoneButton.Hidden = true;
			suggestionModePicker.Hidden = false;
			autoCompleteModePicker.Hidden = true;
			popUpDelayText.Hidden = true;
			popupDelayLabel.Hidden = true;
			autoCompleteModeLabel.Hidden = true;
			maxDropDownHeightLabel.Hidden = true;
			maximumText.Hidden = true;
			minimumText.Hidden = true;
			minPrefixCharacterLabel.Hidden = true;
			autoCompleteButton.Hidden = true;
			suggestionModeLabel.Hidden = true;
			suggestionButton.Hidden = true;
		}

		void HidePicker (object sender, EventArgs e) {

			suggestionDoneButton.Hidden = true;
			autoCompleteModeDoneButton.Hidden = true;
			autoCompleteModePicker.Hidden = true;
			suggestionModePicker.Hidden = true;
			autoCompleteModeLabel.Hidden = false;
			popUpDelayText.Hidden =false;
			popupDelayLabel.Hidden = false;
			maxDropDownHeightLabel.Hidden = false;
			maximumText.Hidden = false;
			minimumText.Hidden = false;
			minPrefixCharacterLabel.Hidden = false;
			autoCompleteButton.Hidden = false;
			suggestionModeLabel.Hidden = false;
			suggestionButton.Hidden = false;
			autoCompleteModeLabel.Hidden = false;
		}

		void ShowautoCompleteModePicker (object sender, EventArgs e) {
			minimumText.EndEditing(true);
			maximumText.EndEditing(true);
			popUpDelayText.EndEditing(true);
			suggestionDoneButton.Hidden = false;
			autoCompleteModeDoneButton.Hidden = false;
			suggestionModePicker.Hidden = true;
			autoCompleteModePicker.Hidden = false;
			popUpDelayText.Hidden = true;
			popupDelayLabel.Hidden = true;
			maxDropDownHeightLabel.Hidden = true;
			maximumText.Hidden = true;
			minimumText.Hidden = true;
			minPrefixCharacterLabel.Hidden = true;
			autoCompleteButton.Hidden = true;
			autoCompleteModeLabel.Hidden = true;
			suggestionModeLabel.Hidden = true;
			suggestionButton.Hidden = true;

		}

		private void suggestionSelectedIndexChanged(object sender, PickerChangedEventArgs e)
		{
			this.selectedType = e.SelectedValue;
			suggestionButton.SetTitle (selectedType, UIControlState.Normal);
			if (selectedType == "StartsWith") {
				countryAutoComplete.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeStartsWith;
				jobFieldAutoComplete.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeStartsWith;
			} else if (selectedType == "StartsWithCaseSensitive") {
				countryAutoComplete.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeStartsWithCaseSensitive;
				jobFieldAutoComplete.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeStartsWithCaseSensitive;
			} else if (selectedType == "Contains") {
				countryAutoComplete.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeContains;
				jobFieldAutoComplete.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeContains;

			} else if (selectedType == "ContainsWithCaseSensitive") {
				countryAutoComplete.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeContainsCaseSensitive;
				jobFieldAutoComplete.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeContainsCaseSensitive;

			} else if (selectedType == "EndsWith") {
				countryAutoComplete.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeEndsWith;
				jobFieldAutoComplete.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeEndsWith;
			} else if (selectedType == "EndsWithCaseSensitive") {
				countryAutoComplete.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeEndsWithCaseSensitive;
				jobFieldAutoComplete.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeEndsWithCaseSensitive;
			} else if (selectedType == "Equals") {
				countryAutoComplete.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeEquals;
				jobFieldAutoComplete.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeEquals;

			}
			else if (selectedType == "EqualsWithCaseSenstive"){
				countryAutoComplete.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeEqualsCaseSensitive;
				jobFieldAutoComplete.SuggestionMode = SFAutoCompleteSuggestionMode.SFAutoCompleteSuggestionModeEqualsCaseSensitive;
			}
		}
		private void autoCompleteSelectedIndexChanged(object sender, PickerChangedEventArgs e)
		{
			this.selectedType = e.SelectedValue;
			autoCompleteButton.SetTitle (selectedType, UIControlState.Normal);
			if (selectedType == "Append") {
				countryAutoComplete.AutoCompleteMode = SFAutoCompleteAutoCompleteMode.SFAutoCompleteAutoCompleteModeAppend;
				jobFieldAutoComplete.AutoCompleteMode = SFAutoCompleteAutoCompleteMode.SFAutoCompleteAutoCompleteModeAppend;
			}
			else if (selectedType == "Suggest") {
				countryAutoComplete.AutoCompleteMode = SFAutoCompleteAutoCompleteMode.SFAutoCompleteAutoCompleteModeSuggest;
				jobFieldAutoComplete.AutoCompleteMode = SFAutoCompleteAutoCompleteMode.SFAutoCompleteAutoCompleteModeSuggest;
			}
			else if (selectedType == "SuggestAppend")
			{
				countryAutoComplete.AutoCompleteMode = SFAutoCompleteAutoCompleteMode.SFAutoCompleteAutoCompleteModeSuggestAppend;
				jobFieldAutoComplete.AutoCompleteMode = SFAutoCompleteAutoCompleteMode.SFAutoCompleteAutoCompleteModeSuggestAppend;
			}
		}

		private void experienceSelectedIndexChanged(object sender, PickerChangedEventArgs e)
		{
			this.selectedType = e.SelectedValue;
			experienceButton.SetTitle (selectedType, UIControlState.Normal);
		}
	}
}
