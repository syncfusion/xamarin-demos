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
using Com.Syncfusion.Autocomplete;
using System.Linq;


namespace SampleBrowser
{
    public class TokensSamplePage : SamplePage
    {
        LinearLayout mainLayout;
        int width,height;
        double density;
        public override View GetPropertyWindowLayout(Android.Content.Context context)
        {
			return null;
        }

		public override View GetSampleContent(Android.Content.Context con)
		{
            width = con.Resources.DisplayMetrics.WidthPixels;
            height = con.Resources.DisplayMetrics.HeightPixels;
            density = con.Resources.DisplayMetrics.Density;
            mainLayout = new LinearLayout(con);
			mainLayout.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
			mainLayout.Orientation = Orientation.Vertical;
            mainLayout.SetGravity(GravityFlags.CenterHorizontal);
			HeaderMethod(con);
            ToMethod(con);
            CcMethod(con);
            BccMethod(con);
            SubjectMethod(con);
            ContentMethod(con);

            return mainLayout;
		}

        private void HeaderMethod(Android.Content.Context con)
        {
            LinearLayout hearderLayout = new LinearLayout(con);
            hearderLayout.LayoutParameters=new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(50 * density));
            hearderLayout.Orientation = Orientation.Horizontal;
            hearderLayout.SetBackgroundColor(Color.ParseColor("#2A4D72"));
            hearderLayout.SetGravity(GravityFlags.Center);

            TextView emailText = new TextView(con);
            emailText.SetPadding((int)(10 * density),0,0,0);
			emailText.LayoutParameters = new LinearLayout.LayoutParams((int)(width * 0.60), (int)(50 * density));
			emailText.Text = "Email-Compose";
            emailText.SetTextColor(Color.White);
            emailText.TextSize =16;
            emailText.Typeface = Typeface.DefaultBold;
            emailText.TextAlignment = TextAlignment.Center;
            emailText.Gravity = GravityFlags.CenterVertical;
            hearderLayout.AddView(emailText);

			TextView attachText = new TextView(con);
			attachText.LayoutParameters = new LinearLayout.LayoutParams((int)(width * 0.25), (int)(50 * density));
			attachText.Text = "ATTACH";
			attachText.SetTextColor(Color.White);
			attachText.TextSize = 16;
			attachText.Typeface = Typeface.DefaultBold;
			attachText.TextAlignment = TextAlignment.Center;

			attachText.Gravity = GravityFlags.CenterVertical;
			hearderLayout.AddView(attachText);

			TextView sendText = new TextView(con);
			sendText.LayoutParameters = new LinearLayout.LayoutParams((int)(width * 0.15), (int)(50 * density));
			sendText.Text = "SEND";
			sendText.SetTextColor(Color.White);
			sendText.TextSize = 16;
			sendText.Typeface = Typeface.DefaultBold;
            sendText.TextAlignment = TextAlignment.Center;
            sendText.Gravity = GravityFlags.CenterVertical;
			hearderLayout.AddView(sendText);

            mainLayout.AddView(hearderLayout);
        }

        private void ToMethod(Android.Content.Context con)
        {
			LinearLayout toLayout = new LinearLayout(con);
			toLayout.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(50 * density));
			toLayout.Orientation = Orientation.Horizontal;
			toLayout.SetGravity(GravityFlags.Center);
            toLayout.SetPadding(0,0,10,0);

			TextView toText = new TextView(con);
			toText.LayoutParameters = new LinearLayout.LayoutParams((int)(width * 0.15), (int)(50 * density));
			toText.Text = "To";
			toText.TextSize = 20;
			toText.TextAlignment = TextAlignment.Center;
            toText.Gravity = GravityFlags.Center;
			toLayout.AddView(toText);

            SfAutoComplete toAutoComplete = new SfAutoComplete(con);
			toAutoComplete.LayoutParameters = new LinearLayout.LayoutParams((int)(width * 0.85), (int)(45 ));
            toAutoComplete.MultiSelectMode = MultiSelectMode.Token;
            toAutoComplete.SetGravity(GravityFlags.Center);
            toAutoComplete.DataSource = new AutoCompleteContactsInfoRepository().GetContactDetails();
			toAutoComplete.DisplayMemberPath = "ContactName";
			toAutoComplete.TokensWrapMode = TokensWrapMode.Wrap;
			toAutoComplete.DropDownCornerRadius = 4;
			toAutoComplete.ImageMemberPath = "ContactImage";
            toAutoComplete.MaximumDropDownHeight = 150;
            toAutoComplete.DropDownItemHeight = 60;
	    	toAutoComplete.IsFocused = true;
			CustomAutoCompleteAdapterToken customAdapter = new CustomAutoCompleteAdapterToken();
			customAdapter.autoComplete1 = toAutoComplete;
			toAutoComplete.Adapter = customAdapter;
			toLayout.AddView(toAutoComplete);
			toAutoComplete.FocusChanged += (sender, e) => {
     //           if (e.HasFocus)
     //           {
     //               toLayout.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(90 * density));
     //               toText.LayoutParameters = new LinearLayout.LayoutParams((int)(width * 0.15), (int)(90 * density));
     //               toAutoComplete.LayoutParameters = new LinearLayout.LayoutParams((int)(width * 0.85), (int)(90 ));
     //           }
     //           else{
					//toLayout.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(50 * density));
					//toText.LayoutParameters = new LinearLayout.LayoutParams((int)(width * 0.15), (int)(50 * density));
					//toAutoComplete.LayoutParameters = new LinearLayout.LayoutParams((int)(width * 0.85), (int)(50 ));
                //}
			};

            mainLayout.AddView(toLayout);
		}

		private void CcMethod(Android.Content.Context con)
		{
			LinearLayout ccLayout = new LinearLayout(con);
			ccLayout.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(50 * density));
			ccLayout.Orientation = Orientation.Horizontal;
			ccLayout.SetGravity(GravityFlags.Center);
			ccLayout.SetPadding(0, 0, 10, 0);

			TextView ccText = new TextView(con);
			ccText.LayoutParameters = new LinearLayout.LayoutParams((int)(width * 0.15), (int)(50 * density));
			ccText.Text = "Cc";
			ccText.TextSize = 20;
			ccText.TextAlignment = TextAlignment.Center;
			ccText.Gravity = GravityFlags.Center;
			ccLayout.AddView(ccText);

			SfAutoComplete ccAutoComplete = new SfAutoComplete(con);
			ccAutoComplete.LayoutParameters = new LinearLayout.LayoutParams((int)(width * 0.85), (int)(45 ));
			ccAutoComplete.MultiSelectMode = MultiSelectMode.Token;
			ccAutoComplete.SetGravity(GravityFlags.Center);
			ccAutoComplete.DataSource = new AutoCompleteContactsInfoRepository().GetContactDetails();
			ccAutoComplete.DisplayMemberPath = "ContactName";
			ccAutoComplete.TokensWrapMode = TokensWrapMode.Wrap;
			ccAutoComplete.DropDownCornerRadius = 4;
			ccAutoComplete.ImageMemberPath = "ContactImage";
            ccAutoComplete.MaximumDropDownHeight = 150;
			ccAutoComplete.DropDownItemHeight = 60;
			CustomAutoCompleteAdapterToken customAdapter = new CustomAutoCompleteAdapterToken();
			customAdapter.autoComplete1 = ccAutoComplete;
			ccAutoComplete.Adapter = customAdapter;
			ccLayout.AddView(ccAutoComplete);
			ccAutoComplete.FocusChanged += (sender, e) =>
			{
				//if (e.HasFocus)
				//{
				//	ccLayout.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(90 * density));
				//	ccText.LayoutParameters = new LinearLayout.LayoutParams((int)(width * 0.15), (int)(90 * density));
				//	ccAutoComplete.LayoutParameters = new LinearLayout.LayoutParams((int)(width * 0.85), (int)(90 ));
				//}
				//else
				//{
				//	ccLayout.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(50 * density));
				//	ccText.LayoutParameters = new LinearLayout.LayoutParams((int)(width * 0.15), (int)(50 * density));
				//	ccAutoComplete.LayoutParameters = new LinearLayout.LayoutParams((int)(width * 0.85), (int)(45 ));
				//}
			};

			mainLayout.AddView(ccLayout);
		}

		private void BccMethod(Android.Content.Context con)
		{
			LinearLayout bccLayout = new LinearLayout(con);
			bccLayout.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(50 * density));
			bccLayout.Orientation = Orientation.Horizontal;
			bccLayout.SetGravity(GravityFlags.Center);
			bccLayout.SetPadding(0, 0, 10, 0);

			TextView bccText = new TextView(con);
			bccText.LayoutParameters = new LinearLayout.LayoutParams((int)(width * 0.15), (int)(50 * density));
			bccText.Text = "Bcc";
			bccText.TextSize = 20;
			bccText.TextAlignment = TextAlignment.Center;
			bccText.Gravity = GravityFlags.Center;
			bccLayout.AddView(bccText);

			SfAutoComplete bccAutoComplete = new SfAutoComplete(con);
			bccAutoComplete.LayoutParameters = new LinearLayout.LayoutParams((int)(width * 0.85), (int)(45 ));
			bccAutoComplete.MultiSelectMode = MultiSelectMode.Token;
			bccAutoComplete.SetGravity(GravityFlags.Center);
			bccAutoComplete.DataSource = new AutoCompleteContactsInfoRepository().GetContactDetails();
            bccAutoComplete.DisplayMemberPath = "ContactName";
            bccAutoComplete.TokensWrapMode = TokensWrapMode.Wrap;
            bccAutoComplete.DropDownCornerRadius = 4;
            bccAutoComplete.ImageMemberPath = "ContactImage";
            bccAutoComplete.MaximumDropDownHeight = 150;
			bccAutoComplete.DropDownItemHeight = 60;
			CustomAutoCompleteAdapterToken customAdapter = new CustomAutoCompleteAdapterToken();
			customAdapter.autoComplete1 = bccAutoComplete;
			bccAutoComplete.Adapter = customAdapter;
			bccLayout.AddView(bccAutoComplete);
			bccAutoComplete.FocusChanged += (sender, e) =>
			{
				//if (e.HasFocus)
				//{
				//	bccLayout.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(90 * density));
				//	bccText.LayoutParameters = new LinearLayout.LayoutParams((int)(width * 0.15), (int)(90 * density));
				//	bccAutoComplete.LayoutParameters = new LinearLayout.LayoutParams((int)(width * 0.85), (int)(90 ));
				//}
				//else
				//{
				//	bccLayout.LayoutParameters = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(50 * density));
				//	bccText.LayoutParameters = new LinearLayout.LayoutParams((int)(width * 0.15), (int)(50 * density));
				//	bccAutoComplete.LayoutParameters = new LinearLayout.LayoutParams((int)(width * 0.85), (int)(50 ));
				//}
			};

			mainLayout.AddView(bccLayout);
		}

        private void SubjectMethod(Android.Content.Context con)
        {
            EditText editText = new EditText(con);
            editText.LayoutParameters = new LinearLayout.LayoutParams((int)(width * 0.95), (int)(50 * density));
			editText.Hint = "Subject";
            editText.TextSize = 15;

            mainLayout.AddView(editText);
		}

        private void ContentMethod(Android.Content.Context con)
        {
			EditText editText = new EditText(con);
            editText.LayoutParameters = new LinearLayout.LayoutParams((int)(width * 0.95), (int)(height - (400 * density)));
            editText.Text = "Sent from my smartphone";
            editText.TextSize = 12;
            editText.Gravity=GravityFlags.Start;

            mainLayout.AddView(editText);
		}
	}

	internal class CustomAutoCompleteAdapterToken : AutoCompleteAdapter
	{
		internal SfAutoComplete autoComplete1;

        public Android.Views.View GetView(Com.Syncfusion.Autocomplete.SfAutoComplete autoComplete, string text, int index)
        {
            GC.Collect();
            string contactTypeValue="",contactImageValue="",contactNameValue="",contactNumberValue="";

            var contactType = autoComplete.DataSource.ElementAt(index);

            foreach (var property in contactType.GetType().GetProperties())
            {
                if (property.Name.Equals("ContactType"))
                {
                    contactTypeValue=(property.GetValue(contactType).ToString().ToLower());
                    contactTypeValue = contactTypeValue.Split('.')[0];
                }
				else if (property.Name.Equals("ContactImage"))
				{
                    contactImageValue = (property.GetValue(contactType).ToString().ToLower());
					contactImageValue = contactImageValue.Split('.')[0];

				}
				else if (property.Name.Equals("ContactName"))
				{
					contactNameValue = (property.GetValue(contactType).ToString());
				}
				else if (property.Name.Equals("ContactNumber"))
				{
					contactNumberValue = (property.GetValue(contactType).ToString());
				}
            }

            ImageView contactTypeImage = new ImageView(autoComplete.Context);
			contactTypeImage.SetImageResource(autoComplete.GetImageResId(contactTypeValue));
            LinearLayout.LayoutParams parms = new LinearLayout.LayoutParams((int)(40 * autoComplete.GetDensity()), (int)(40 * autoComplete.GetDensity()));
			contactTypeImage.LayoutParameters = parms;

			ImageView contactImageImage = new ImageView(autoComplete.Context);
			contactImageImage.SetImageResource(autoComplete.GetImageResId(contactImageValue));
			LinearLayout.LayoutParams parms12 = new LinearLayout.LayoutParams((int)(40 * autoComplete.GetDensity()), (int)(40 * autoComplete.GetDensity()));
			contactImageImage.LayoutParameters = parms12;

			FrameLayout frameLayout = new FrameLayout(autoComplete.Context);
            frameLayout.SetPadding((int)(10 * autoComplete.GetDensity()),(int)(3 * autoComplete.GetDensity()),0,0);
			FrameLayout.LayoutParams parmsFrame = new FrameLayout.LayoutParams((int)(50 * autoComplete.GetDensity()), (int)(43 * autoComplete.GetDensity()));
			frameLayout.LayoutParameters = parmsFrame;
			//frameLayout.AddView(contactTypeImage);
            frameLayout.AddView(contactImageImage);


            TextView nameText = new TextView(autoComplete.Context);
            nameText.Text = contactNameValue;
            nameText.TextSize = 16;

			TextView emailText = new TextView(autoComplete.Context);
			emailText.Text = contactNumberValue;
			emailText.TextSize = 12;

			LinearLayout textLayout = new LinearLayout(autoComplete.Context);
			textLayout.SetPadding((int)(10 * autoComplete.GetDensity()), (int)(3 * autoComplete.GetDensity()), (int)(3 * autoComplete.GetDensity()), (int)(3 * autoComplete.GetDensity()));
			textLayout.LayoutParameters = new ViewGroup.LayoutParams(autoComplete.LayoutParameters.Width, autoComplete.LayoutParameters.Height);
            textLayout.Orientation = Android.Widget.Orientation.Vertical;
            textLayout.AddView(nameText);
            textLayout.AddView(emailText);

			LinearLayout linearLayout = new LinearLayout(autoComplete.Context);
			linearLayout.SetPadding((int)(3 * autoComplete.GetDensity()), (int)(3 * autoComplete.GetDensity()), (int)(3 * autoComplete.GetDensity()), (int)(3 * autoComplete.GetDensity()));
			linearLayout.LayoutParameters = new ViewGroup.LayoutParams(autoComplete.LayoutParameters.Width, autoComplete.LayoutParameters.Height);
            linearLayout.Orientation = Android.Widget.Orientation.Horizontal;
            linearLayout.AddView(frameLayout);
            linearLayout.AddView(textLayout);
            linearLayout.SetGravity(GravityFlags.CenterVertical);

			return linearLayout;
        }
	}
}