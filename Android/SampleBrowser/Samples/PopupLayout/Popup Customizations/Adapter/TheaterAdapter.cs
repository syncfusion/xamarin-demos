#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Syncfusion.Android.PopupLayout;
using Android.Content.Res;
using Android.Graphics;
using Android.Util;
using System.Windows.Input;
using Android.Graphics.Drawables;

namespace SampleBrowser
{
    public class TheaterAdapter : BaseAdapter<TableItem>
    {
        private List<TableItem> items;
        private Activity context;
        public static ImageView info;
        private SfPopupLayout termsAndConditionsPopup;
        private SfPopupLayout infoPopup;
        private FrameLayout mainView;
        internal static int counter = 0;
        private TextView timing1;
        private TextView timing2;
        private ImageView infoImage;
        private Button cancelButton;
        private Button okButton;
        private Button proceed;
        private double density;
        TextView seatCountLabel;

        public TheaterAdapter(Activity context, List<TableItem> items, FrameLayout view)
            : base()
        {
            this.context = context;
            this.items = items;
            this.mainView = view;
            this.density = Resources.System.DisplayMetrics.Density;
        }

        public override long GetItemId(int position)
        {
            return position;
        }
        public override TableItem this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            (parent as ListView).ViewDetachedFromWindow += TheaterAdapter_ViewDetachedFromWindow;
            var item = items[position];
            View view = convertView;
            view = context.LayoutInflater.Inflate(Resource.Layout.CustomListView, null);
            return CreateTheaterTile(view as LinearLayout, item);
        }

        private void TheaterAdapter_ViewDetachedFromWindow(object sender, View.ViewDetachedFromWindowEventArgs e)
        {
            timing1.Click -= Timing1_Click;
            timing2.Click -= Timing2_Click;
            infoImage.Click -= Info_Click;
        }

        private LinearLayout CreateTheaterTile(LinearLayout view, TableItem item)
        {
            LinearLayout theaterInfo = new LinearLayout(context);
            theaterInfo.Orientation = Android.Widget.Orientation.Vertical;

            TextView theaterName = new TextView(context);
            theaterName.Text = item.Heading;
            theaterName.SetTextColor(Color.ParseColor("#000000"));
            theaterName.SetTextSize(ComplexUnitType.Dip, 16);
            theaterName.SetPadding((int)(12 * density), 0, 0, (int)(8 * density));

            TextView areaName = new TextView(context);
            areaName.Text = item.SubHeading;
            areaName.SetTextColor(Color.ParseColor("#000000"));
            areaName.SetTextSize(ComplexUnitType.Dip, 12);
            areaName.SetPadding((int)(12 * density), 0, 0, (int)(10 * density));

            LinearLayout timingLayout = new LinearLayout(context);
            timingLayout.Orientation = Android.Widget.Orientation.Horizontal;

            timing1 = new TextView(context);
            timing1.Text = item.Timing1;
            timing1.Click += Timing1_Click;
            timing1.SetX((int)(12 * density));
            timing1.Gravity = GravityFlags.CenterHorizontal | GravityFlags.CenterVertical;
            timing1.SetTextColor(Color.ParseColor("#007CEE"));
            timing1.SetTextSize(ComplexUnitType.Dip, 14);
            timing1.SetBackgroundResource(Resource.Layout.BorderLayout1);

            timing2 = new TextView(context);
            timing2.Text = item.Timing2;
            timing2.SetTextColor(Color.ParseColor("#007CEE"));
            timing2.Gravity = GravityFlags.CenterHorizontal | GravityFlags.CenterVertical;
            timing2.SetX((int)(22 * density));
            if (MainActivity.IsTablet)
                timing2.SetPadding(0, 2, 0, 0);
            else
                timing2.SetPadding(0, 20, 0, 0);
            timing2.SetTextSize(ComplexUnitType.Dip, 14);
            timing2.Click += Timing2_Click;
            timing2.SetBackgroundResource(Resource.Layout.BorderLayout1);

            timingLayout.AddView(timing1, (int)(80 * density), ViewGroup.LayoutParams.MatchParent);
            timingLayout.AddView(timing2, (int)(80 * density), ViewGroup.LayoutParams.MatchParent);

            theaterInfo.AddView(theaterName);
            theaterInfo.AddView(areaName);
            if (MainActivity.IsTablet)
                theaterInfo.AddView(timingLayout, ViewGroup.LayoutParams.MatchParent, (int)(25 * density));
            else
                theaterInfo.AddView(timingLayout, ViewGroup.LayoutParams.MatchParent, (int)(32 * density));

            infoImage = new ImageView(context);
            infoImage.SetImageResource(item.ImageResourceId);
            infoImage.Click += Info_Click;
            infoImage.Alpha = 0.5f;
            infoImage.SetY((int)(38 * density));

            view.AddView(theaterInfo,(int)(Resources.System.DisplayMetrics.WidthPixels - (48 * density)), (int)(100 * density));
            view.AddView(infoImage, (int)(24* density), (int)(24 * density));

            if (item.Timing1 != null)
            {
                timing1.Text = item.Timing1;
            }
            else
            {
                timing1.Visibility = ViewStates.Invisible;
                timing1.Gravity = GravityFlags.CenterHorizontal;
            }
            if (item.Timing2 != null)
            {
                timing2.Text = item.Timing2;
                timing2.Gravity = GravityFlags.CenterHorizontal;
            }
            else
            {
                timing2.Visibility = ViewStates.Invisible;
            }
            return view;
        }

        private void Timing2_Click(object sender, EventArgs e)
        {
            CreateTermsAndConditionsPopup();
            termsAndConditionsPopup.Show();
        }

        private void Timing1_Click(object sender, EventArgs e)
        {
            CreateTermsAndConditionsPopup();
            termsAndConditionsPopup.Show();

        }

        private void CreateTermsAndConditionsPopup()
        {
            termsAndConditionsPopup = new SfPopupLayout(this.context);
            termsAndConditionsPopup.PopupView.SetBackgroundColor(Color.White);
            termsAndConditionsPopup.StaysOpen = true;
            termsAndConditionsPopup.PopupView.HeaderTitle = "Terms & Conditions";
            termsAndConditionsPopup.PopupView.PopupStyle.HeaderTextGravity = GravityFlags.CenterHorizontal | GravityFlags.CenterVertical;
            termsAndConditionsPopup.PopupView.PopupStyle.HeaderBackgroundColor = Color.White;
            termsAndConditionsPopup.PopupView.PopupStyle.HeaderTextColor = Color.Black;
            termsAndConditionsPopup.PopupView.PopupStyle.BorderColor = Color.LightGray;
            termsAndConditionsPopup.PopupView.PopupStyle.BorderThickness = 1;
            termsAndConditionsPopup.PopupView.ShowFooter = true;
            termsAndConditionsPopup.PopupView.ShowCloseButton = false;      
            termsAndConditionsPopup.PopupView.AppearanceMode = AppearanceMode.TwoButton;
            TextView messageView = new TextView(this.context) { Text = "1. Children below the age of 18 cannot be admitted for movies certified A.\n2. Please carry proof of age for movies certified A.\n3. Drinking and alcohol is strictly prohibited inside the premises \n4. Please purchase tickets for children above age of 3."};
            termsAndConditionsPopup.PopupView.ContentView = messageView;
            termsAndConditionsPopup.PopupView.AppearanceMode = AppearanceMode.TwoButton;

            LinearLayout footer = new LinearLayout(context);
            footer.Orientation = Android.Widget.Orientation.Horizontal;

            cancelButton = new Button(context);
            cancelButton.Text = "Decline";
            cancelButton.Click += CancelButton_Click;
            cancelButton.SetBackgroundColor(Color.White);
            cancelButton.Gravity = GravityFlags.Center;
            cancelButton.SetTextSize(ComplexUnitType.Dip, 14);
            cancelButton.SetTextColor(Color.ParseColor("#007CEE"));

            okButton = new Button(context);
            okButton.Text = "Accept";
            okButton.Click += AcceptTerms_Click; 
            okButton.SetTextSize(ComplexUnitType.Dip,14);
            okButton.SetBackgroundColor(Color.White);
            okButton.Gravity = GravityFlags.Center;
            okButton.SetTextColor(Color.ParseColor("#007CEE"));

            if (MainActivity.IsTablet)
            {
                messageView.TextSize = 19;
                messageView.SetTextColor(Color.Gray);
                messageView.SetBackgroundColor(Color.White);
                messageView.SetPadding((int)(10 * density), (int)(30 * density), (int)(10 * density), (int)(30 * density));
                termsAndConditionsPopup.PopupView.WidthRequest = 450;
                termsAndConditionsPopup.PopupView.HeightRequest = 320;
                footer.SetMinimumWidth(450);
                footer.AddView(cancelButton, (int)(225 * density) , ViewGroup.LayoutParams.MatchParent);
                footer.AddView(new View(context) { Background = new ColorDrawable(Color.LightGray) }, (int)(1 * density), ViewGroup.LayoutParams.MatchParent);
                footer.AddView(okButton, (int)(225 * density), ViewGroup.LayoutParams.MatchParent);
            }
            else
            {
                messageView.TextSize = 14;
                messageView.SetTextColor(Color.Gray);
                messageView.SetBackgroundColor(Color.White);
                messageView.SetPadding((int)(10 * density), (int)(10 * density), (int)(10 * density), (int)(10 * density));
                termsAndConditionsPopup.PopupView.WidthRequest = 300;
                termsAndConditionsPopup.PopupView.HeightRequest = 270;
                footer.SetMinimumWidth(300);
                footer.AddView(cancelButton, (int)(150 * density), ViewGroup.LayoutParams.MatchParent);
                footer.AddView(new View(context) {Background = new ColorDrawable(Color.LightGray) }, (int)(1 * density), ViewGroup.LayoutParams.MatchParent);
                footer.AddView(okButton, (int)(150 * density), ViewGroup.LayoutParams.MatchParent);
            }
            termsAndConditionsPopup.PopupView.FooterView = footer;
            termsAndConditionsPopup.PopupView.FooterHeight = 50;
            termsAndConditionsPopup.PopupView.ShowHeader = true;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            termsAndConditionsPopup.Dismiss();
        }

        private void AcceptTerms_Click(object sender, EventArgs e)
        {
            termsAndConditionsPopup.StaysOpen = false;
            termsAndConditionsPopup.PopupView.ShowCloseButton = true;
            if (((termsAndConditionsPopup.PopupView.FooterView as LinearLayout).GetChildAt(0) as Button).Text == "Proceed")
            {
                Toast.MakeText(context, "Tickets booked successfully", ToastLength.Long).Show();
                termsAndConditionsPopup.Dismiss();
            }
            else
            {
                termsAndConditionsPopup.PopupView.HeaderTitle = "How many seats ?";
                termsAndConditionsPopup.PopupView.ContentView = CreateSeatSelectionPage();
            }
        }

        private LinearLayout CreateSeatSelectionPage()
        {
            LinearLayout seatSelectionMainLayout = new LinearLayout(context);
            seatSelectionMainLayout.Orientation = Android.Widget.Orientation.Vertical;
            seatSelectionMainLayout.SetBackgroundColor(Color.White);


            LinearLayout numberOfSeatsLayout = new LinearLayout(context);
            numberOfSeatsLayout.Orientation = Android.Widget.Orientation.Horizontal;

            if (MainActivity.IsTablet)
            {
                numberOfSeatsLayout.AddView(CreateSeatSelectionLayout("1"), (int)((450 * Resources.System.DisplayMetrics.Density) / 8), (int)(42 * Resources.System.DisplayMetrics.Density));
                numberOfSeatsLayout.AddView(CreateSeatSelectionLayout("2", 1), (int)((450 * Resources.System.DisplayMetrics.Density) / 8), (int)(42 * Resources.System.DisplayMetrics.Density));
                numberOfSeatsLayout.AddView(CreateSeatSelectionLayout("3"), (int)((450 * Resources.System.DisplayMetrics.Density) / 8), (int)(42 * Resources.System.DisplayMetrics.Density));
                numberOfSeatsLayout.AddView(CreateSeatSelectionLayout("4"), (int)((450 * Resources.System.DisplayMetrics.Density) / 8), (int)(42 * Resources.System.DisplayMetrics.Density));
                numberOfSeatsLayout.AddView(CreateSeatSelectionLayout("5"), (int)((450 * Resources.System.DisplayMetrics.Density) / 8), (int)(42 * Resources.System.DisplayMetrics.Density));
                numberOfSeatsLayout.AddView(CreateSeatSelectionLayout("6"), (int)((450 * Resources.System.DisplayMetrics.Density) / 8), (int)(42 * Resources.System.DisplayMetrics.Density));
                numberOfSeatsLayout.AddView(CreateSeatSelectionLayout("7"), (int)((450 * Resources.System.DisplayMetrics.Density) / 8), (int)(42 * Resources.System.DisplayMetrics.Density));
                numberOfSeatsLayout.AddView(CreateSeatSelectionLayout("8"), (int)((450 * Resources.System.DisplayMetrics.Density) / 8), (int)(42 * Resources.System.DisplayMetrics.Density));
            }
            else
            {
                numberOfSeatsLayout.AddView(CreateSeatSelectionLayout("1"), (int)((300 * Resources.System.DisplayMetrics.Density) / 8), (int)(42 * Resources.System.DisplayMetrics.Density));
                numberOfSeatsLayout.AddView(CreateSeatSelectionLayout("2", 1), (int)((300 * Resources.System.DisplayMetrics.Density) / 8), (int)(42 * Resources.System.DisplayMetrics.Density));
                numberOfSeatsLayout.AddView(CreateSeatSelectionLayout("3"), (int)((300 * Resources.System.DisplayMetrics.Density) / 8), (int)(42 * Resources.System.DisplayMetrics.Density));
                numberOfSeatsLayout.AddView(CreateSeatSelectionLayout("4"), (int)((300 * Resources.System.DisplayMetrics.Density) / 8), (int)(42 * Resources.System.DisplayMetrics.Density));
                numberOfSeatsLayout.AddView(CreateSeatSelectionLayout("5"), (int)((300 * Resources.System.DisplayMetrics.Density) / 8), (int)(42 * Resources.System.DisplayMetrics.Density));
                numberOfSeatsLayout.AddView(CreateSeatSelectionLayout("6"), (int)((300 * Resources.System.DisplayMetrics.Density) / 8), (int)(42 * Resources.System.DisplayMetrics.Density));
                numberOfSeatsLayout.AddView(CreateSeatSelectionLayout("7"), (int)((300 * Resources.System.DisplayMetrics.Density) / 8), (int)(42 * Resources.System.DisplayMetrics.Density));
                numberOfSeatsLayout.AddView(CreateSeatSelectionLayout("8"), (int)((300 * Resources.System.DisplayMetrics.Density) / 8), (int)(42 * Resources.System.DisplayMetrics.Density));
            }

            TextView title2 = new TextView(context);
            title2.Text = "Select your seat class";
            if(!MainActivity.IsTablet)
                title2.SetY(10);
            title2.SetTextColor(Color.Black);
            title2.SetTextSize(ComplexUnitType.Dip, 14);

            LinearLayout seatClassLayout = new LinearLayout(context);
            seatClassLayout.Orientation = Android.Widget.Orientation.Vertical;
            if (MainActivity.IsTablet)
            {
                seatClassLayout.SetPadding((int)(22 * density), 0, 0, 0);
            }
            else
            {
                seatClassLayout.SetPadding((int)(22 * density), (int)(15 * density), 0, 0);
            }

            seatClassLayout.AddView(CreateSeatClassLayoutTile("Silver"), (int)(300 * density), (int)(40 * density));
            seatClassLayout.AddView(CreateSeatClassLayoutTile("Premier"), (int)(300 * density), (int)(40 * density));

            if (MainActivity.IsTablet)
            {
                numberOfSeatsLayout.SetPadding(0, (int)(15 * density), 0, 0);
                title2.SetPadding((int)(10 * density), 0, 0, 0);
                seatSelectionMainLayout.AddView(numberOfSeatsLayout, ViewGroup.LayoutParams.MatchParent, (int)(84 * Resources.System.DisplayMetrics.Density));
                seatSelectionMainLayout.AddView(title2, ViewGroup.LayoutParams.MatchParent, (int)(45 * density));
                seatSelectionMainLayout.AddView(seatClassLayout, ViewGroup.LayoutParams.MatchParent, (int)(120 * density));
                termsAndConditionsPopup.PopupView.FooterHeight = 60;
            }
            else
            {
                numberOfSeatsLayout.SetPadding(0, (int)(10 * density), 0, 0);
                title2.SetPadding((int)(10 * density), (int)(15 * density), 0, 0);
                seatSelectionMainLayout.AddView(numberOfSeatsLayout, ViewGroup.LayoutParams.MatchParent, (int)(52 * Resources.System.DisplayMetrics.Density));
                seatSelectionMainLayout.AddView(title2, ViewGroup.LayoutParams.MatchParent, (int)(45 * density));
                seatSelectionMainLayout.AddView(seatClassLayout, ViewGroup.LayoutParams.MatchParent, (int)(95 * density));
                termsAndConditionsPopup.PopupView.FooterHeight = 40;
            }

            termsAndConditionsPopup.PopupView.HeaderTitle = "Select your seats";
            termsAndConditionsPopup.PopupView.PopupStyle.HeaderTextColor = Color.Black;
            termsAndConditionsPopup.PopupView.PopupStyle.HeaderBackgroundColor = Color.White;// ParseColor("#007CEE");
            termsAndConditionsPopup.PopupView.PopupStyle.BorderThickness = 1;
            termsAndConditionsPopup.PopupView.ShowFooter = true;
            termsAndConditionsPopup.PopupView.ShowHeader = true;
            if (MainActivity.IsTablet)
                termsAndConditionsPopup.PopupView.HeightRequest = 350;
            else
                termsAndConditionsPopup.PopupView.HeightRequest = 300;
            termsAndConditionsPopup.PopupView.AppearanceMode = AppearanceMode.TwoButton;
            (termsAndConditionsPopup.PopupView.FooterView as LinearLayout).RemoveAllViews();
            proceed = new Button(context);
            proceed.Text = "Proceed";
            proceed.SetTextSize(ComplexUnitType.Dip,14);
            proceed.SetTextColor(Color.White);
            proceed.SetBackgroundColor(Color.ParseColor("#007CEE"));
            proceed.SetMinimumWidth((int)(300 * density));
            (termsAndConditionsPopup.PopupView.FooterView as LinearLayout).AddView(proceed, ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            proceed.Click += AcceptTerms_Click;
            termsAndConditionsPopup.PopupView.PopupStyle.FooterBackgroundColor = Color.White;
            return seatSelectionMainLayout;
        }

        private TextView CreateSeatSelectionLayout(string count, object selected = null)
        {
            seatCountLabel = new TextView(context);
            if (selected == null)
            {
                seatCountLabel.SetBackgroundColor(Android.Graphics.Color.White);
                seatCountLabel.SetTextColor(Color.Black);
            }
            else
            {
                seatCountLabel.SetBackgroundColor(Color.ParseColor("#007CEE"));
                seatCountLabel.SetTextColor(Color.White);
            }
            seatCountLabel.Text = count;
            seatCountLabel.SetTypeface(Android.Graphics.Typeface.Default, TypefaceStyle.Bold);
            seatCountLabel.Gravity = GravityFlags.CenterHorizontal | GravityFlags.CenterVertical;
            seatCountLabel.Click += SeatCountLabel_Click;
            return seatCountLabel;
        }

        private void SeatCountLabel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ((sender as TextView).Parent as LinearLayout).ChildCount; i++)
            {
                // Remove selection color to other date views

                (((sender as TextView).Parent as LinearLayout).GetChildAt(i) as TextView).SetBackgroundColor(Color.White);
                (((sender as TextView).Parent as LinearLayout).GetChildAt(i) as TextView).SetTextColor(Color.Black);
            }
           (sender as TextView).SetBackgroundColor(Color.ParseColor("#007CEE"));
            (sender as TextView).SetTextColor(Color.White);
        }

        private LinearLayout CreateSeatClassLayoutTile(string text)
        {
            LinearLayout linear = new LinearLayout(context);
            linear.Orientation = Android.Widget.Orientation.Horizontal;

            TextView clas = new TextView(context);
            clas.Text = text;
            clas.SetTextColor(Color.Gray);
            clas.SetTextSize(ComplexUnitType.Dip, 14);

            TextView cost = new TextView(context);
            if (text == "Silver")
                cost.Text = "$19.69";
            else
                cost.Text = "$23.65";
            cost.SetTextColor(Color.Black);
            cost.SetTextSize(ComplexUnitType.Dip, 14);

            TextView availability = new TextView(context);
            if (text == "Silver")
            {
                availability.Text = "Available";
                availability.SetTextColor(Color.ParseColor("#00BD81"));
            }
            else
            {
                availability.Text = "Unavailable";
                availability.SetTextColor(Color.Red);
            }
            availability.SetTextSize(ComplexUnitType.Dip, 14);

            linear.AddView(clas, (int)((300 / 3) * density), (int)(30 * density));
            linear.AddView(cost, (int)((300 / 3) * density), (int)(30 * density));
            linear.AddView(availability, (int)((300 / 3) * density), (int)(30 * density));
            return linear;
        }

        private void Info_Click(object sender, EventArgs e)
        {
            CreateInfoLayout(sender);
        }

        private void CreateInfoLayout(object sender)
        {
            var header = (((sender as ImageView).Parent as LinearLayout).GetChildAt(0) as LinearLayout).GetChildAt(0) as TextView;

            LinearLayout bodyView = new LinearLayout(context);
            bodyView.Orientation = Android.Widget.Orientation.Vertical;
            bodyView.SetBackgroundColor(Color.White);

            TextView body = new TextView(context);
            body.Text = ((((sender as ImageView).Parent as LinearLayout).GetChildAt(0) as LinearLayout).GetChildAt(1) as TextView).Text + "421 E DRACHMAN TUCSON AZ 85705 - 7598 USA";
            body.SetTextSize(ComplexUnitType.Dip, 14);
            body.SetPadding((int)(12 * density), (int)(10 * density), 0, 0);
            body.SetTextColor(Color.ParseColor("#007CEE"));

            TextView facilities = new TextView(context);
            facilities.Text = "Available Facilities";
            facilities.Gravity = GravityFlags.CenterHorizontal;
            facilities.SetTextColor(Color.Black);
            facilities.SetTextSize(ComplexUnitType.Dip, 14);

            LinearLayout facilitiesLayout = new LinearLayout(context);
            facilitiesLayout.Orientation = Android.Widget.Orientation.Vertical;
            facilitiesLayout.SetPadding(0, (int)(10 * density), 0, 0);

            LinearLayout iconLayout = new LinearLayout(context);
            iconLayout.Orientation = Android.Widget.Orientation.Horizontal;
            iconLayout.SetHorizontalGravity(GravityFlags.CenterHorizontal);

            LinearLayout iconDescLayout = new LinearLayout(context);
            iconDescLayout.Orientation = Android.Widget.Orientation.Horizontal;
            iconDescLayout.SetHorizontalGravity(GravityFlags.CenterHorizontal);

            ImageView mticket = new ImageView(context);
            mticket.SetImageResource(Resource.Drawable.Popup_MTicket);

            ImageView parking = new ImageView(context);
            parking.SetImageResource(Resource.Drawable.Popup_Parking);

            ImageView foodCourt = new ImageView(context);
            foodCourt.SetImageResource(Resource.Drawable.Popup_FoodCourt);

            iconLayout.AddView(mticket, (int)(100 * density), (int)(30 * density));
            iconLayout.AddView(parking, (int)(100 * density), (int)(30 * density));
            iconLayout.AddView(foodCourt, (int)(100 * density), (int)(30 * density));

            TextView mtick = new TextView(context);
            mtick.Text = "M-Ticket";
            mtick.SetTextSize(ComplexUnitType.Dip, 10);
            mtick.SetTextColor(Color.Black);
            mtick.Gravity = GravityFlags.CenterHorizontal | GravityFlags.CenterVertical;

            TextView park = new TextView(context);
            park.Text = "Parking";
            park.SetTextSize(ComplexUnitType.Dip, 10);
            park.SetTextColor(Color.Black);
            park.Gravity = GravityFlags.CenterHorizontal | GravityFlags.CenterVertical;

            TextView food = new TextView(context);
            food.Text = "Food Court";
            food.SetTextSize(ComplexUnitType.Dip, 10);
            food.SetTextColor(Color.Black);
            food.Gravity = GravityFlags.CenterHorizontal | GravityFlags.CenterVertical;

            iconDescLayout.AddView(mtick, (int)(100 * density), (int)(30 * density));
            iconDescLayout.AddView(park, (int)(100 * density), (int)(30 * density));
            iconDescLayout.AddView(food, (int)(100 * density), (int)(30 * density));

            facilitiesLayout.AddView(iconLayout);
            facilitiesLayout.AddView(iconDescLayout);

            bodyView.AddView(body, ViewGroup.LayoutParams.MatchParent, (int)(50 * density));
            bodyView.AddView(facilities, ViewGroup.LayoutParams.MatchParent, (int)(30 * density));
            bodyView.AddView(facilitiesLayout, ViewGroup.LayoutParams.MatchParent, (int)(70 * density));

            DisplayInfoPopup(bodyView, header.Text);
        }

        private void DisplayInfoPopup(View bodyView,string headerText)
        {
            bodyView.SetPadding(10, 0, 10, 0);
            infoPopup = new SfPopupLayout(context);
            infoPopup.PopupView.HeaderTitle = headerText;
            infoPopup.PopupView.PopupStyle.HeaderTextColor = Color.Black;
            infoPopup.PopupView.PopupStyle.HeaderTextSize = 18;
            infoPopup.PopupView.AppearanceMode = AppearanceMode.OneButton;
            infoPopup.PopupView.PopupStyle.HeaderBackgroundColor = Color.White;
            infoPopup.PopupView.ShowHeader = true;
            infoPopup.PopupView.ShowCloseButton = true;
            infoPopup.StaysOpen = false;
            infoPopup.PopupView.ShowFooter = false;
            if (MainActivity.IsTablet)
                infoPopup.PopupView.WidthRequest = 450;
            else
                infoPopup.PopupView.WidthRequest = 300;
            infoPopup.PopupView.HeightRequest = 250;
            infoPopup.PopupView.ContentView = bodyView;
            infoPopup.PopupView.PopupStyle.BorderThickness = 1;
            infoPopup.IsOpen = true;
        }
    }
}