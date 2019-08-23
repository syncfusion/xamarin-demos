#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Android.App;
using Android.Util;
using System;
using System.Collections.Generic;

using Android.Content;
using Android.Views;
using Android.Widget;
using Com.Syncfusion.Rating;
using Android.Content.Res;

using Android.Graphics;


namespace SampleBrowser
{
    public class Rating_Mobile
    {
       /*********************************
        **Local Varabile Inizialization**
        *********************************/
        TextView title, movieLabel, time, description, dummyLabel2, dummyLabel, ratingLable, showLable;
        LinearLayout pageLayout, columnLayout, imageLayout, contentLayout, padLayout;
        LinearLayout textLayout, timeLayout, valueLayout, ratingLayout;
        LinearLayout descriptionLayout, propertylayout, countStack;
        TooltipPlacement toolTipPosition = TooltipPlacement.None;
        ArrayAdapter<String> precisionAdapter, placementAdapter;
        SfRatingSettings sfRatingSettings, sfRatingSetings1;
        Precision precisionPosition = Precision.Standard;
        LinearLayout.LayoutParams layoutParams;
        Spinner precisionSpinner, toolTipSpinner;
        int constCount = 5, height, width;
        SfRating sfRating, sfRating1;
        EditText itemCountEntry;
        ImageView imageView;
        Context context;
       
        public View GetSampleContent(Context con)
        {
            height = con.Resources.DisplayMetrics.HeightPixels / 2;
            width = con.Resources.DisplayMetrics.WidthPixels / 2;

            SamplePageContent(con);
           /*************
            **SfRating1**
            *************/
            sfRatingSettings = new SfRatingSettings();
            sfRating1 = new SfRating(con);
            sfRating1.ItemSize = 17;          
            sfRating1.Precision = Precision.Exact;
            sfRating1.Value = 3.5;
            sfRating1.ReadOnly = true;
            sfRating1.ItemSpacing = 0;
            sfRating1.TooltipPlacement = TooltipPlacement.None;
            sfRatingSettings.RatedFill = Color.ParseColor("#fbd10a");
            sfRatingSettings.UnRatedFill = Color.ParseColor("#cdcccb");
            sfRatingSettings.RatedStrokeWidth = 0;
            sfRatingSettings.UnRatedStrokeWidth = 0;
            sfRating1.RatingSettings = sfRatingSettings;
			sfRating1.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent ,(int)(20 * con.Resources.DisplayMetrics.Density));
           /************
            **SfRating**
            ************/
            sfRatingSetings1 = new SfRatingSettings();
            sfRatingSetings1.RatedStroke = Color.ParseColor("#2095f2");
            sfRating = new SfRating(con);         
            sfRating.ItemSize = 40;
            sfRating.ItemSpacing = 20;
            sfRating.ItemCount = 5;
            sfRating.TooltipPrecision = 1;
            sfRating.Value = 3;
            sfRating.RatingSettings = sfRatingSetings1;
			sfRating.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(40 * con.Resources.DisplayMetrics.Density));
			//sfRating Value Changed Listener
            sfRating.ValueChanged += (object sender, ValueChangedEventArgs e) => {
				if (!e.Value.ToString().Equals(""))
                {                    
					UpdateText(e.Value);
                }
            };

            //mainView
            LinearLayout mainView = new LinearLayout(con);
            mainView.AddView(GetView(con));

            return mainView;
        }

        private LinearLayout GetView(Context con)
        {
            //PageLayout
            pageLayout = new LinearLayout(con);
            pageLayout.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.WrapContent,LinearLayout.LayoutParams.WrapContent);
            pageLayout.Orientation = Android.Widget.Orientation.Vertical;
            pageLayout.AddView(title);

            //ColumnLayout
            columnLayout = new LinearLayout(con);
            columnLayout.Orientation = Android.Widget.Orientation.Horizontal;
            columnLayout.SetPadding(0, 10, 0, 0);

            //image Layout
            imageLayout = new LinearLayout(con);
            FrameLayout.LayoutParams layoutParams1 = new FrameLayout.LayoutParams(width, (height), GravityFlags.Center);
            imageLayout.AddView(imageView, layoutParams1);
            imageLayout.SetGravity(GravityFlags.Center);

            //Content Layout
            contentLayout = new LinearLayout(con);
            contentLayout.Orientation = Android.Widget.Orientation.Vertical;
            contentLayout.SetPadding(10, 5, 20, 0);
            contentLayout.AddView(movieLabel);

            //Text Layout
            textLayout = new LinearLayout(con);
            textLayout.Orientation = Android.Widget.Orientation.Horizontal;
            textLayout.SetPadding(0, 5, 0, 0);
            textLayout.AddView(time);
            
            //Rating Layout
            ratingLayout = new LinearLayout(con);
            ratingLayout.SetPadding(5, 2, 0, 0);
            ratingLayout.AddView(sfRating1);
            textLayout.AddView(ratingLayout);
            contentLayout.AddView(textLayout);

            //DescriptionLayout
            descriptionLayout = new LinearLayout(con);
            descriptionLayout.SetPadding(0, 0, 0, 0);
            descriptionLayout.AddView(description);
            contentLayout.AddView(descriptionLayout);
            contentLayout.LayoutParameters = new ViewGroup.LayoutParams(width, height);
            columnLayout.AddView(imageLayout);
            columnLayout.AddView(contentLayout);
            pageLayout.AddView(columnLayout);

            //Time Layout
            timeLayout = new LinearLayout(con);
            timeLayout.SetPadding(30, 35, 30, 0);

            //Separator
            FrameLayout.LayoutParams separatorparams = new FrameLayout.LayoutParams(width * 2, 2, GravityFlags.Center);
            SeparatorView separatorView = new SeparatorView(con, width * 2);
            separatorView.separatorColor = Color.ParseColor("#a5a5a5");
            timeLayout.AddView(separatorView, separatorparams);
            pageLayout.AddView(timeLayout);
            pageLayout.AddView(dummyLabel2);

            //PadLayout
            padLayout = new LinearLayout(con);
            padLayout.Orientation = Android.Widget.Orientation.Horizontal;
            padLayout.AddView(dummyLabel);
            padLayout.AddView(sfRating);
            pageLayout.AddView(padLayout);

            //Value Layout
            valueLayout = new LinearLayout(con);
            valueLayout.Orientation = Android.Widget.Orientation.Horizontal;
            valueLayout.SetPadding(30, 15, 0, 0);
            valueLayout.AddView(ratingLable);
            UpdateText(sfRating.Value);
            valueLayout.AddView(showLable);
            pageLayout.AddView(valueLayout);

            return pageLayout;
        }

        private void SamplePageContent(Context con)
        {
            //TitleLabel
            title = new TextView(con);
            title.TextSize = 25;
            title.SetTextColor(Color.ParseColor("#282828"));
            title.Text = "Movie Rating";
            title.SetPadding(30, 40, 0, 0);

            //ImageView
            imageView = new ImageView(con);
            imageView.SetScaleType(ImageView.ScaleType.FitXy);
            imageView.SetImageResource(Resource.Drawable.movie);
            imageView.SetPadding(30, 10, 10, 0);

            //MovieLabel
            movieLabel = new TextView(con);
            movieLabel.TextSize = 16;
            movieLabel.SetTextColor(Color.ParseColor("#282828"));
            movieLabel.Text = "The walk ( 2015 )";

            //TimeLabel
            time = new TextView(con);
            time.TextSize = 9;
            time.SetTextColor(Color.ParseColor("#282828"));
            time.Text = "PG | 2 h 20 min  ";

            //Description
            description = new TextView(con);          
            description.TextSize = 8;
            description.SetTextColor(Color.ParseColor("#282828"));
            description.SetLineSpacing(6, 1);
            description.Text = "In 1973, French street performer Philippe Petit is trying to make a living in Paris with juggling acts and wire walking, much to the chagrin of his father. During one performance, he eats a hard candy which was given to him by an audience member and injures his tooth. He visits the dentist and, while in the waiting room, sees a picture in a magazine of the Twin Towers in New York City. He analyzes the photo and decides to make it his mission to walk a tightrope between the two buildings. Meanwhile, he is evicted from his parents' house by his father, citing his lack of income and the fact that he's a street performer. Philippe returns to the circus that inspired him to wire walk as a child and practices in the big top after hours, but is caught by Papa Rudy, whom he impresses with his juggling skills. ";
            description.SetPadding(0, 0, 20, 0);

            //Dummy Label
            dummyLabel2 = new TextView(con);
            dummyLabel2.TextSize = 15;
            dummyLabel2.SetPadding(30, 28, 0, 0);
            dummyLabel2.SetTextColor(Color.ParseColor("#282828"));
            dummyLabel2.Text = "Rate";
            dummyLabel = new TextView(con);
            dummyLabel.Text = "      ";

            //Rating Label
            ratingLable = new TextView(con);
            ratingLable.TextSize = 10;
            ratingLable.SetTextColor(Color.ParseColor("#282828"));
            ratingLable.Text = "Rating :  ";

            //Show Label
            showLable = new TextView(con);
            showLable.TextSize = 10;
            showLable.SetTextColor(Color.ParseColor("#282828"));
        }

        private void UpdateText(double rateValue)
        {
            int tempIntValue = (int)rateValue;
            float tempFloatValue = (float)rateValue;
            float diffenceValue = tempFloatValue - tempIntValue;
            String changeValue;
            if (diffenceValue == 0)
                changeValue = tempIntValue.ToString();
            else
            {
                String valueString = String.Format("{0:0.#}", tempFloatValue);
                changeValue = valueString;
            }
            showLable.Text = changeValue + " / " + sfRating.ItemCount;
        }
    
        public void OnApplyChanges()
        {
            sfRating.Precision = precisionPosition;
            sfRating.TooltipPlacement = toolTipPosition;
            sfRating.ItemCount = constCount;
            sfRating.Value = 3;
            if (sfRating.Value > constCount)
                sfRating.Value = 0;
            UpdateText(sfRating.Value);
        }
     
        public View GetPropertyWindowLayout(Context context1)
        {
            context = context1;
            width = (context.Resources.DisplayMetrics.WidthPixels) / 2;
            propertylayout = new LinearLayout(context);
            propertylayout.Orientation = Android.Widget.Orientation.Vertical;
            layoutParams = new LinearLayout.LayoutParams(width * 2, 3);
            layoutParams.SetMargins(0, 0, 0, 10);

            PrecisionLayout();
            TooltipLayout();
            ItemCountLayout();

            return propertylayout;
        }

        private void PrecisionLayout()
        {
            /*************
           **Precision**
           *************/
            TextView precisionLabel = new TextView(context);
            precisionLabel.TextSize = 20;
            precisionLabel.Text = "Precision";

            //Precision Spinner
            precisionSpinner = new Spinner(context,SpinnerMode.Dialog);
            precisionSpinner.SetGravity(GravityFlags.Left);

            //Precision List
            List<String> precisionList = new List<String>();
            precisionList.Add("Standard");
            precisionList.Add("Half");
            precisionList.Add("Exact");

            //precision Adapter
            precisionAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, precisionList);
            precisionAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            precisionSpinner.Adapter = precisionAdapter;

            //Precision Spinner ItemSelected Listener
            precisionSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
                String selectedItem = precisionAdapter.GetItem(e.Position);
                if (selectedItem.Equals("Standard"))
                {
                    precisionPosition = Precision.Standard;
                }
                if (selectedItem.Equals("Half"))
                {
                    precisionPosition = Precision.Half;
                }
                if (selectedItem.Equals("Exact"))
                {
                    precisionPosition = Precision.Exact;
                }
            };

            propertylayout.AddView(precisionLabel);

            //Separator
            SeparatorView separatorLine2 = new SeparatorView(context, width * 2);
            separatorLine2.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
           // propertylayout.AddView(separatorLine2, layoutParams);

            //AdjLabel
            TextView adjLabel2 = new TextView(context);
            adjLabel2.SetHeight(14);
            propertylayout.AddView(adjLabel2);
            precisionSpinner.SetPadding(0, 0, 0, 20);
            propertylayout.AddView(precisionSpinner);

            
        }

        private void TooltipLayout()
        {
            /***********
            **ToolTip**
            ***********/
            TextView tooltipLabel = new TextView(context);
            tooltipLabel.TextSize = 20;
            tooltipLabel.Text = "Tooltip Placement";
            LinearLayout.LayoutParams toollabelParams = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            toollabelParams.SetMargins(0, 10, 0, 0);

            //ToolTip Spinner
            toolTipSpinner = new Spinner(context,SpinnerMode.Dialog);
            toolTipSpinner.SetGravity(GravityFlags.Left);

            //Placement List
            List<String> placementList = new List<String>();
            placementList.Add("None");
            placementList.Add("TopLeft");
            placementList.Add("BottomRight");

            //Placement Adapter
            placementAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, placementList);
            placementAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            toolTipSpinner.Adapter = placementAdapter;
            //ToolTip Spinner Item Selected Listener
            toolTipSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
                String selectedItem = placementAdapter.GetItem(e.Position);
                if (selectedItem.Equals("None"))
                {
                    toolTipPosition = TooltipPlacement.None;
                }
                if (selectedItem.Equals("TopLeft"))
                {
                    toolTipPosition = TooltipPlacement.TopLeft;
                }
                if (selectedItem.Equals("BottomRight"))
                {
                    toolTipPosition = TooltipPlacement.BottomRight;
                }
            };

            //CenterText
            TextView centerText = new TextView(context);
            propertylayout.AddView(centerText);
            propertylayout.AddView(tooltipLabel);

            //Separator
            SeparatorView separate3 = new SeparatorView(context, width * 2);
            separate3.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 5);
           // propertylayout.AddView(separate3, layoutParams);
            toolTipSpinner.SetPadding(0, 0, 0, 20);

            //AdjLabel
            TextView adjLabel3 = new TextView(context);
            adjLabel3.SetHeight(20);
            propertylayout.AddView(adjLabel3);
            propertylayout.AddView(toolTipSpinner);
        }

        private void ItemCountLayout()
        {
            /************
          **ItemCount**
          *************/
            TextView itemLabel = new TextView(context);
            itemLabel.Text = "Item Count";
            itemLabel.Gravity = GravityFlags.CenterVertical;
            itemLabel.TextSize = 20;

            //ItemCount Text
            itemCountEntry = new EditText(context);
            itemCountEntry.Text = "5";
            itemCountEntry.TextSize = 16;
            itemCountEntry.InputType = Android.Text.InputTypes.ClassPhone;
            itemCountEntry.TextChanged += (object sender, Android.Text.TextChangedEventArgs e) => {
				if (itemCountEntry.Text.Length > 0)
				{
					try
					{
						constCount = Convert.ToInt32(e.Text.ToString());
					}
					catch (Exception) { constCount = 1; }
				}
            };

            //EntryParams
            LinearLayout.LayoutParams entryParams = new LinearLayout.LayoutParams(width - 20, ViewGroup.LayoutParams.WrapContent);
            entryParams.Gravity = GravityFlags.Center;
            entryParams.SetMargins(-10, 10, 0, 0);
            LinearLayout.LayoutParams labelParams = new LinearLayout.LayoutParams(width - 20, ViewGroup.LayoutParams.MatchParent);
            labelParams.SetMargins(0, 10, 0, 0);

			TextView centerText = new TextView(context);
			propertylayout.AddView(centerText);
            //CountStack
            countStack = new LinearLayout(context);
            countStack.AddView(itemLabel, labelParams);
            
            countStack.AddView(itemCountEntry, entryParams);
            countStack.Orientation = Android.Widget.Orientation.Horizontal;
            propertylayout.AddView(countStack);

            //Separator
            SeparatorView separatorLine4 = new SeparatorView(context, width * 2);
            separatorLine4.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 3);
            layoutParams.SetMargins(0, 10, 0, 0);
           // propertylayout.AddView(separatorLine4, layoutParams);
            propertylayout.SetPadding(20, 20, 20, 20);
        }
    }
}



