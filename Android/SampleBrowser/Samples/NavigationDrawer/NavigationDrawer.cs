#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
using Android.Util;


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
using Android.Graphics;
using Com.Syncfusion.Navigationdrawer;

namespace SampleBrowser
{
    [Activity(Label = "NavigationDrawer")]
    public class NavigationDrawer : SamplePage
    {
        /*********************************
         **Local Variable Inizialisation**
         *********************************/
        LinearLayout inboxLayout, mail1, mail2, mail3, mail4, mail9, mail10, mail11,mail18, mail19, mail20;
        LinearLayout secondaryDrawerLayout, Item1, Item2, Item3, Item4, Item5, Item6, Item7;
        LinearLayout ItemLayout1, ItemLayout2, ItemLayout3, ItemLayout4, ItemLayout5, ItemLayout6, ItemLayout7;
        LinearLayout.LayoutParams layoutParams5, layoutParams,layoutParamsSecondaryDrawer;
        SeparatorView separatorView1, separatorView2, separatorView3, separatorView4, separatorView5, separatorView6, separatorView7;
        SeparatorView labelSeparator4, labelSeparator3, labelSeparator5;
        SeparatorView labelSeparator6, labelSeparator7, labelSeparator8, labelSeparator9,labelSeparator18, labelSeparator19, labelSeparator20;
        LinearLayout outboxlayout, mail12, mail13, mail14, mail15, mail16, mail17;
        LinearLayout mail5, mail6, profilelayout, linear2;
        SeparatorView labelSeparator10, labelSeparator11, labelSeparator12, labelSeparator13;
        SeparatorView labelSeparator14, labelSeparator15, labelSeparator16, labelSeparator17;
        Button iconbutton,iconbutton1;
        ListView viewItem;
        SfNavigationDrawer slideDrawer;
        DrawerSettings drawerSettings;
        LinearLayout propertylayout;
        ArrayAdapter<String> dataAdapter, dataAdapter1, arrayAdapter, dataAdapter2, dataAdapter3;
        Spinner positionSpinner,positionSpinner1, animationSpinner, animationSpinner1;
        Position sliderposition = Position.Left,sliderposition1 = Position.Right;
        Transition sliderTransition = Transition.SlideOnTop,sliderTransition1 = Transition.SlideOnTop;
        Context context;
        int height, width;
        double actionBarHeight;   
        TextView profileContentLabel;       
        FrameLayout ContentFrame;
        ScrollView textScroller,textScroller1, textScroller2;              

        public override void OnApplyChanges()
        {
            base.OnApplyChanges();
            slideDrawer.Position = sliderposition;
            slideDrawer.Transition = sliderTransition;
            slideDrawer.SecondaryDrawerSettings.Position = sliderposition1;
            slideDrawer.SecondaryDrawerSettings.Transition = sliderTransition1;
        }
       
        public override View GetPropertyWindowLayout(Context context)
        {          
            int width = (context.Resources.DisplayMetrics.WidthPixels) / 2;
            propertylayout = new LinearLayout(context);
            propertylayout.Orientation = Orientation.Vertical;
            layoutParams = new LinearLayout.LayoutParams(width * 2, 3);
            layoutParams.SetMargins(0, 20, 0, 0);

            positionLabelLayout();
            AnimationLayout();

            return propertylayout;
        }

        private void positionLabelLayout()
        {
            //cultureLabel
            TextView cultureLabel = new TextView(context);
            cultureLabel.TextSize = 20;
            cultureLabel.Text = "Default Drawer Position";

            TextView cultureLabel1 = new TextView(context);
            cultureLabel1.TextSize = 20;
            cultureLabel1.Text = " Secondary Drawer Position";
           
            //positionlist
            List<String> positionlist = new List<String>();
            positionlist.Add("Left");
            positionlist.Add("Right");
            positionlist.Add("Top");
            positionlist.Add("Bottom");

            List<String> positionlist1 = new List<String>();
            positionlist1.Add("Left");
            positionlist1.Add("Right");
            positionlist1.Add("Top");
            positionlist1.Add("Bottom");
            //dataAdapter
            dataAdapter = new ArrayAdapter<String>
                (context, Android.Resource.Layout.SimpleSpinnerItem, positionlist);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            dataAdapter2 = new ArrayAdapter<String>
               (context, Android.Resource.Layout.SimpleSpinnerItem, positionlist1);
            dataAdapter2.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);

            //positionSpinner
            positionSpinner = new Spinner(context,SpinnerMode.Dialog);
            positionSpinner.SetGravity(GravityFlags.Left);
            positionSpinner.Adapter = dataAdapter;
            positionSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
                String selectedItem = dataAdapter.GetItem(e.Position);
                if (selectedItem.Equals("Left"))
                {
                    sliderposition = Position.Left;
                }
                if (selectedItem.Equals("Right"))
                {
                    sliderposition = Position.Right;
                }
                if (selectedItem.Equals("Top"))
                {
                    sliderposition = Position.Top;
                }
                if (selectedItem.Equals("Bottom"))
                {
                    sliderposition = Position.Bottom;
                }
            };

            positionSpinner1 = new Spinner(context, SpinnerMode.Dialog);
            positionSpinner1.SetGravity(GravityFlags.Left);
            positionSpinner1.Adapter = dataAdapter2;
            positionSpinner1.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
                String selectedItem = dataAdapter2.GetItem(e.Position);
                if (selectedItem.Equals("Left"))
                {
                    sliderposition1 = Position.Left;
                }
                if (selectedItem.Equals("Right"))
                {
                    sliderposition1 = Position.Right;
                }
                if (selectedItem.Equals("Top"))
                {
                    sliderposition1 = Position.Top;
                }
                if (selectedItem.Equals("Bottom"))
                {
                    sliderposition1 = Position.Bottom;
                }

            };

            propertylayout.AddView(cultureLabel);
            propertylayout.AddView(positionSpinner);
            propertylayout.AddView(cultureLabel1);
            propertylayout.AddView(positionSpinner1);

            //labelSeparator
            SeparatorView labelSeparator = new SeparatorView(context, width * 2);
            labelSeparator.separatorColor = Color.LightGray;
            labelSeparator.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 3);
            //propertylayout.AddView(labelSeparator, layoutParams);
        }

        private void AnimationLayout()
        {
            //cultureLabel1
            TextView cultureLabel1 = new TextView(context);
            cultureLabel1.TextSize = 20;
            cultureLabel1.Text = "Default Drawer Animations";   

            //cultureLabel2
            TextView cultureLabel2 = new TextView(context);
            cultureLabel2.TextSize = 20;
            cultureLabel2.Text = "Secondary Drawer Animations";           

            //transitionlist
            List<String> transitionlist = new List<String>();
            transitionlist.Add("SlideOnTop");
            transitionlist.Add("Reveal");
            transitionlist.Add("Push");

            //transitionlist
            List<String> transitionlist1 = new List<String>();
            transitionlist1.Add("SlideOnTop");
            transitionlist1.Add("Reveal");
            transitionlist1.Add("Push");

            //dataAdapter1
            dataAdapter1 = new ArrayAdapter<String>
                (context, Android.Resource.Layout.SimpleSpinnerItem, transitionlist);
            dataAdapter1.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem); ;

            dataAdapter3 = new ArrayAdapter<String>
               (context, Android.Resource.Layout.SimpleSpinnerItem, transitionlist1);
            dataAdapter3.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem); ;

            //animationSpinner
            animationSpinner = new Spinner(context,SpinnerMode.Dialog);
            animationSpinner.SetGravity(GravityFlags.Left);
            animationSpinner.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
                String selectedItem = dataAdapter1.GetItem(e.Position);
                if (selectedItem.Equals("SlideOnTop"))
                {
                    sliderTransition = Transition.SlideOnTop;
                }
                if (selectedItem.Equals("Reveal"))
                {
                    sliderTransition = Transition.Reveal;
                }
                if (selectedItem.Equals("Push"))
                {
                    sliderTransition = Transition.Push;
                }
            };

            animationSpinner1 = new Spinner(context, SpinnerMode.Dialog);
            animationSpinner1.SetGravity(GravityFlags.Left);
            animationSpinner1.ItemSelected += (object sender, AdapterView.ItemSelectedEventArgs e) => {
                String selectedItem = dataAdapter3.GetItem(e.Position);
                if (selectedItem.Equals("SlideOnTop"))
                {
                    sliderTransition1 = Transition.SlideOnTop;
                }
                if (selectedItem.Equals("Reveal"))
                {
                    sliderTransition1 = Transition.Reveal;
                }
                if (selectedItem.Equals("Push"))
                {
                    sliderTransition1 = Transition.Push;
                }
            };

			TextView textSpacing = new TextView(context);
			propertylayout.AddView(textSpacing);

            animationSpinner.Adapter = dataAdapter1;
            animationSpinner1.Adapter = dataAdapter3;
            propertylayout.AddView(cultureLabel1);
            propertylayout.AddView(animationSpinner);
            propertylayout.AddView(cultureLabel2);
            propertylayout.AddView(animationSpinner1);

            //labelSeparator1
            SeparatorView labelSeparator1 = new SeparatorView(context, width * 2);
            labelSeparator1.separatorColor = Color.LightGray;
            labelSeparator1.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 3);
            //propertylayout.AddView(labelSeparator1, layoutParams);

            propertylayout.SetPadding(5, 0, 5, 0);
        }
      
        public override View GetSampleContent(Context context1)
        {
            context = context1;
            IconButtonLayout();
            HomeContentLayout();
            MainContentLayout();          
            ProfileContentLayout();
            InboxContentLayout();
            SecondaryDrawerLayout();
            OutBoxLayout();
            ClickListenerLayout();

            return slideDrawer;
        }

        private void IconButtonLayout()
        {
            //iconbutton
            iconbutton = new Button(context);
            iconbutton.SetBackgroundResource(Resource.Drawable.burgericon);
            FrameLayout.LayoutParams btlayoutParams = new FrameLayout.LayoutParams(getDimensionPixelSize(context, Resource.Dimension.nav_drawer_btn_wt), getDimensionPixelSize(context, Resource.Dimension.nav_drawer_btn_ht), GravityFlags.Center);
            iconbutton.LayoutParameters = btlayoutParams;
            iconbutton.SetPadding(10, 0, 0, 0);
            if (context.Resources.DisplayMetrics.Density > 1.5)
            {
                iconbutton.SetX(10);
            }
            iconbutton.Gravity = GravityFlags.CenterVertical;

            iconbutton1 = new Button(context);
            Typeface tf = Typeface.CreateFromAsset(context.Assets, "Segoe_MDL2_Assets.ttf");
            iconbutton1.Text = "\uE823";
            iconbutton1.Typeface = tf;
            iconbutton1.SetTextColor(Color.White);
            iconbutton1.SetBackgroundColor(Color.Rgb(47, 173, 227));
            FrameLayout.LayoutParams btlayoutParams1 = new FrameLayout.LayoutParams(getDimensionPixelSize(context, Resource.Dimension.nav_drawer_btn_wt), getDimensionPixelSize(context, Resource.Dimension.nav_drawer_btn_ht), GravityFlags.Center);
            iconbutton1.LayoutParameters = btlayoutParams1;
            iconbutton1.SetPadding(10, 0, 0, 0);
            if (context.Resources.DisplayMetrics.Density > 1.5)
            {
                iconbutton1.SetX(10);
            }
            iconbutton1.Gravity = GravityFlags.CenterVertical;
        }
       
        private void HomeContentLayout()
        {
            //HomeLabel
            profileContentLabel = new TextView(context);
            profileContentLabel.TextSize = 20;
            profileContentLabel.Text = "Home";
            profileContentLabel.SetTextColor(Color.White);
            profileContentLabel.Gravity = GravityFlags.Center;

            //linearLayout
            LinearLayout linearLayout = new LinearLayout(context);
            FrameLayout.LayoutParams layoutParams = new FrameLayout.LayoutParams((int)(context.Resources.DisplayMetrics.WidthPixels - (68 * context.Resources.DisplayMetrics.Density)), getDimensionPixelSize(context, Resource.Dimension.nav_drawer_header_ht), GravityFlags.Center);
            layoutParams.SetMargins(10, 0, 0, 0);
            linearLayout.SetPadding(10, 0, 0, 0);
            linearLayout.AddView(iconbutton);
            linearLayout.AddView(profileContentLabel, layoutParams);
            linearLayout.AddView(iconbutton1);
            linearLayout.SetBackgroundColor(Color.Rgb(47, 173, 227));

            TypedValue tv = new TypedValue();
            if (context.Theme.ResolveAttribute(Android.Resource.Attribute.ActionBarSize, tv, true))
            {
                actionBarHeight = TypedValue.ComplexToDimensionPixelSize(tv.Data, context.Resources.DisplayMetrics);
            }
            height = Convert.ToInt32(context.Resources.DisplayMetrics.HeightPixels - actionBarHeight);
            width = context.Resources.DisplayMetrics.WidthPixels;

            //linear2
            linear2 = new LinearLayout(context);
            linear2.Orientation = Orientation.Vertical;
            linear2.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            FrameLayout.LayoutParams layout2 = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent, GravityFlags.Center);
            linear2.AddView(linearLayout, layout2);
        }
       
        private void MainContentLayout()
        {
            //textScroller
            textScroller = new ScrollView(context);
            textScroller.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);

            //textView
            TextView textView = new TextView(context);
            textView.Text = "\n \t Lorem ipsum dolor sit amet, lacus amet amet ultricies. Quisque mi venenatis morbi libero, orci dis, mi ut et class porta, massa ligula magna enim, aliquam orci vestibulum tempus. Turpis facilisis vitae consequat, cum a a, turpis dui consequat massa in dolor per, felis non amet. Auctor eleifend in omnis elit vestibulum, donec non elementum tellus est mauris, id aliquam, at lacus, arcu pretium proin lacus dolor et. Eu tortor, vel ultrices amet dignissim mauris vehicula. Lorem tortor neque, purus taciti quis id. Elementum integer orci accumsan minim phasellus vel.";
            textView.TextSize = 16;
            textView.SetPadding(20, 0, 20, 0);
            textScroller.AddView(textView);
            ContentFrame = new FrameLayout(context);
            ContentFrame.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            ContentFrame.SetBackgroundColor(Color.White);
            ContentFrame.AddView(textScroller);
            textScroller.SetBackgroundColor(Color.White);
            linear2.AddView(ContentFrame);

            //contentLayout
            LinearLayout contentLayout = new LinearLayout(context);
            RoundedImageView roundedImg = new RoundedImageView(context, getDimensionPixelSize(context, Resource.Dimension.nav_drawer_imd_size), getDimensionPixelSize(context, Resource.Dimension.nav_drawer_imd_size));
            roundedImg.SetPadding(0, 10, 0, 10);
            roundedImg.SetImageResource(Resource.Drawable.user);
            LinearLayout.LayoutParams layparams8 = new LinearLayout.LayoutParams(getDimensionPixelSize(context, Resource.Dimension.nav_drawer_imd_size), getDimensionPixelSize(context, Resource.Dimension.nav_drawer_imd_size));
            layparams8.Gravity = GravityFlags.Center;
            roundedImg.LayoutParameters = new ViewGroup.LayoutParams(getDimensionPixelSize(context, Resource.Dimension.nav_drawer_imd_size), getDimensionPixelSize(context, Resource.Dimension.nav_drawer_imd_size));

            //userNameLabel1
            TextView userNameLabel1 = new TextView(context);
            userNameLabel1.Text = "James Pollock";
            userNameLabel1.Gravity = GravityFlags.Center;
            userNameLabel1.TextSize = 17;
            userNameLabel1.SetTextColor(Color.White);
            userNameLabel1.SetPadding(0, 20, 0, 0);
            userNameLabel1.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);

            //headerLayout
            LinearLayout headerLayout = new LinearLayout(context);
            headerLayout.Orientation = Orientation.Vertical;
            headerLayout.SetBackgroundColor(Color.Rgb(47, 173, 227));
            headerLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, getDimensionPixelSize(context, Resource.Dimension.nav_drawer_slider_ht));
            headerLayout.SetGravity(GravityFlags.Center);
            headerLayout.AddView(roundedImg, layparams8);
            headerLayout.AddView(userNameLabel1);
            LinearLayout.LayoutParams layparams2 = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (int)(height * 0.15));
            layparams2.Gravity = GravityFlags.Center;
            contentLayout.AddView(headerLayout);
            LinearLayout.LayoutParams layparams5 = new LinearLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, (2));
            contentLayout.AddView(new SeparatorView(context, width) { separatorColor = Color.LightGray }, layparams5);
            contentLayout.SetBackgroundColor(Color.White);
            linear2.SetBackgroundColor(Color.White);

            //slideDrawer
            slideDrawer = new Com.Syncfusion.Navigationdrawer.SfNavigationDrawer(context);
            slideDrawer.ContentView = linear2;
            slideDrawer.DrawerWidth = (float)(200);
            slideDrawer.DrawerHeight = (float)(300);
            slideDrawer.Transition = Transition.SlideOnTop;
            slideDrawer.TouchThreshold = 90;
            slideDrawer.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            viewItem = new ListView(context);
            viewItem.VerticalScrollBarEnabled = true;
            iconbutton.Click += (object sender, EventArgs e) => {
                slideDrawer.ToggleDrawer();
            };

            iconbutton1.Click += (object sender, EventArgs e) => {
                slideDrawer.ToggleSecondaryDrawer();
            };

            //positionlist
            List<String> positionlist = new List<String>();
            positionlist.Add("Home");
            positionlist.Add("Profile");
            positionlist.Add("Inbox");
            positionlist.Add("Outbox");
            positionlist.Add("Sent Items");
            positionlist.Add("Trash");

            arrayAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleListItem1, positionlist);
            viewItem.Adapter = arrayAdapter;
            viewItem.SetBackgroundColor(Color.White);
            viewItem.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            contentLayout.AddView(viewItem);
            contentLayout.Orientation = Orientation.Vertical;

            //frameLayout
            FrameLayout frameLayout = new FrameLayout(context);
            frameLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            frameLayout.SetBackgroundColor(Color.White);
            frameLayout.AddView(contentLayout);
            slideDrawer.DrawerContentView = frameLayout;
        }
       
        private void ProfileContentLayout()
        {
            //profilelayout
            profilelayout = new LinearLayout(context);
            profilelayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            profilelayout.Orientation = Orientation.Vertical;
            LinearLayout linearLayout2 = new LinearLayout(context);
            linearLayout2.SetGravity(GravityFlags.Center);
            linearLayout2.SetPadding(0, 30, 0, 30);
            linearLayout2.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            RoundedImageView roundedImg1 = new RoundedImageView(context, getDimensionPixelSize(context, Resource.Dimension.nav_drawer_prof_ht), getDimensionPixelSize(context, Resource.Dimension.nav_drawer_prof_ht));
            roundedImg1.LayoutParameters = new ViewGroup.LayoutParams(getDimensionPixelSize(context, Resource.Dimension.nav_drawer_prof_ht), getDimensionPixelSize(context, Resource.Dimension.nav_drawer_prof_ht));
            roundedImg1.SetImageResource(Resource.Drawable.user);
            LinearLayout txtlayout = new LinearLayout(context);
            txtlayout.SetPadding(40, 0, 0, 0);
            txtlayout.Orientation = Orientation.Vertical;

            //userNameLabel2
            TextView userNameLabel2 = new TextView(context);
            userNameLabel2.TextSize = 20;
            userNameLabel2.Text = "JamesPollock";
            userNameLabel2.SetTextColor(Color.Black);

            //userAgeLabel
            TextView userAgeLabel = new TextView(context);
            userAgeLabel.Text = "Age 30";
            userAgeLabel.TextSize = 13;
            userAgeLabel.SetTextColor(Color.Black);

            //txtlayout
            txtlayout.AddView(userNameLabel2);
            txtlayout.AddView(userAgeLabel);
            linearLayout2.AddView(roundedImg1);
            linearLayout2.AddView(txtlayout);
            linearLayout2.SetBackgroundColor(Color.White);
            profilelayout.AddView(linearLayout2);
            profilelayout.Orientation = Orientation.Vertical;

            //separatorparams
            FrameLayout.LayoutParams separatorparams = new FrameLayout.LayoutParams(width, 2, GravityFlags.Center);
            SeparatorView labelSeparator2 = new SeparatorView(context, width);
            labelSeparator2.separatorColor = Color.LightGray;
            labelSeparator2.SetPadding(20, 0, 20, 20);
            profilelayout.AddView(labelSeparator2, separatorparams);

            //profiledescriptionLabel
            TextView profiledescriptionLabel = new TextView(context);
            profiledescriptionLabel.TextSize = 16;
            profiledescriptionLabel.SetPadding(20, 0, 20, 0);
            profiledescriptionLabel.SetBackgroundColor(Color.White);
            profiledescriptionLabel.Text = "\n" +
                "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters.\n" +
                "\n" + "\n" + "when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters.\n" +
                "\n" + "\n" + "James Pollock";
            profilelayout.AddView(profiledescriptionLabel);
            profilelayout.SetBackgroundColor(Color.White);
        }

        
        private void InboxContentLayout()
        {
            LinearLayout ContentLayout = new LinearLayout(context);
            ContentLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);

            TextView date = new TextView(context);
            date.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            date.Text = "Jan 17";
            date.Typeface = Typeface.DefaultBold;
            date.SetTextColor(Color.ParseColor("#006BCD"));
            date.Gravity = GravityFlags.End;

            //inboxLayout
            inboxLayout = new LinearLayout(context);
            inboxLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent);
            inboxLayout.SetBackgroundColor(Color.White);
            inboxLayout.Orientation = Orientation.Vertical;
            mail1 = new LinearLayout(context);

            //userNameLabel3
            TextView userNameLabel3 = new TextView(context);
            userNameLabel3.Text = "John";
            userNameLabel3.Typeface = Typeface.DefaultBold;
            userNameLabel3.TextSize = 15;
            userNameLabel3.Gravity = GravityFlags.Start;
            TextView updateLabel1 = new TextView(context);
            updateLabel1.Text = "Goto Meeting";
            updateLabel1.Typeface = Typeface.DefaultBold;
            updateLabel1.SetTextColor(Color.ParseColor("#006BCD"));
            updateLabel1.TextSize = 13;
            TextView messageLabel1 = new TextView(context);
            messageLabel1.Text = "Join meeting to discuss about daily status,workflow,pending work and improve process";

            TextView spaceText1 = new TextView(context);
            spaceText1.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 20);
            TextView Text1 = new TextView(context);
            Text1.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 20);

            //labelSeparator3
            labelSeparator3 = new SeparatorView(context, width * 2);
            labelSeparator3.separatorColor = Color.LightGray;
            labelSeparator3.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 3);

            //layoutParams5
            layoutParams5 = new LinearLayout.LayoutParams(width * 2, 3);
            layoutParams5.SetMargins(0, 10, 15, 0);
            messageLabel1.TextSize = 12;

            ContentLayout.AddView(userNameLabel3);
            ContentLayout.AddView(date);

            mail1.AddView(ContentLayout);
            mail1.AddView(spaceText1);
            mail1.AddView(updateLabel1);
            mail1.AddView(Text1);
            mail1.AddView(messageLabel1);

            //mail2
            LinearLayout ContentLayout1 = new LinearLayout(context);
            ContentLayout1.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            TextView date1 = new TextView(context);
            date1.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            date1.Text = "Jan 8";
            date1.Typeface = Typeface.DefaultBold;
            date1.SetTextColor(Color.ParseColor("#006BCD"));
            date1.Gravity = GravityFlags.End;
            mail2 = new LinearLayout(context);
            TextView userNameLabel4 = new TextView(context);
            userNameLabel4.Text = "Caster";
            userNameLabel4.Typeface = Typeface.DefaultBold;
            userNameLabel4.TextSize = 15;
            TextView updateLabel2 = new TextView(context);
            updateLabel2.Text = "FW:Status Update";
            updateLabel2.Typeface = Typeface.DefaultBold;
            updateLabel2.SetTextColor(Color.ParseColor("#006BCD"));
            updateLabel2.TextSize = 13;
            TextView messageLabel2 = new TextView(context);
            messageLabel2.Text = "Hi, Please find the today's status";
            messageLabel2.TextSize = 12;
            TextView spaceText2 = new TextView(context);
            spaceText2.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 20);
            TextView Text2 = new TextView(context);
            Text2.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 20);
            ContentLayout1.AddView(userNameLabel4);
            ContentLayout1.AddView(date1);

            mail2.AddView(ContentLayout1);
            mail2.AddView(spaceText2);
            mail2.AddView(updateLabel2);
            mail2.AddView(Text2);
            mail2.AddView(messageLabel2);
            labelSeparator4 = new SeparatorView(context, width * 2);
            labelSeparator4.separatorColor = Color.LightGray;
            labelSeparator4.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));

            //mail3
            LinearLayout ContentLayout2 = new LinearLayout(context);
            ContentLayout2.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            TextView date2 = new TextView(context);
            date2.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            date2.Text = "Mar 9";
            date2.Typeface = Typeface.DefaultBold;
            date2.SetTextColor(Color.ParseColor("#006BCD"));
            date2.Gravity = GravityFlags.End;
            mail3 = new LinearLayout(context);
            TextView userNameLabel5 = new TextView(context);
            userNameLabel5.Text = "Joey";
            userNameLabel5.Typeface = Typeface.DefaultBold;
            userNameLabel5.TextSize = 15;
            TextView updateLabel3 = new TextView(context);
            updateLabel3.Text = "Greetings! Congrats";
            updateLabel3.Typeface = Typeface.DefaultBold;
            updateLabel3.SetTextColor(Color.ParseColor("#006BCD"));
            updateLabel3.TextSize = 13;
            TextView messageLabel3 = new TextView(context);
            messageLabel3.Text = "Hi, Congrats you have won the raffle";
            messageLabel3.TextSize = 12;
            TextView spaceText3 = new TextView(context);
            spaceText3.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 20);
            TextView Text3 = new TextView(context);
            Text3.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 20);
            ContentLayout2.AddView(userNameLabel5);
            ContentLayout2.AddView(date2);

            mail3.AddView(ContentLayout2);
            mail3.AddView(spaceText3);
            mail3.AddView(updateLabel3);
            mail3.AddView(Text3);
            mail3.AddView(messageLabel3);
            labelSeparator5 = new SeparatorView(context, width * 2);
            labelSeparator5.separatorColor = Color.LightGray;
            labelSeparator5.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));

            //mail4
            LinearLayout ContentLayout3 = new LinearLayout(context);
            ContentLayout3.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            TextView date3 = new TextView(context);
            date3.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            date3.Text = "Apr 10";
            date3.Typeface = Typeface.DefaultBold;
            date3.SetTextColor(Color.ParseColor("#006BCD"));
            date3.Gravity = GravityFlags.End;
            mail4 = new LinearLayout(context);
            TextView userNameLabel6 = new TextView(context);
            userNameLabel6.Text = "Xavier";
            userNameLabel6.Typeface = Typeface.DefaultBold;
            userNameLabel6.TextSize = 15;
            TextView updateLabel4 = new TextView(context);
            updateLabel4.Text = "Report Monitor";
            updateLabel4.Typeface = Typeface.DefaultBold;
            updateLabel4.SetTextColor(Color.ParseColor("#006BCD"));
            updateLabel4.TextSize = 13;
            TextView messageLabel4 = new TextView(context);
            messageLabel4.Text = "Do not reply, Please find the attachment. Attachment have the full details of monitor report with timing";
            messageLabel4.TextSize = 12;

            TextView spaceText4 = new TextView(context);
            spaceText4.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 20);
            TextView Text4 = new TextView(context);
            Text4.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 20);
            ContentLayout3.AddView(userNameLabel6);
            ContentLayout3.AddView(date3);

            mail4.AddView(ContentLayout3);
            mail4.AddView(spaceText4);
            mail4.AddView(updateLabel4);
            mail4.AddView(Text4);
            mail4.AddView(messageLabel4);
            labelSeparator6 = new SeparatorView(context, width * 2);
            labelSeparator6.separatorColor = Color.LightGray;
            labelSeparator6.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));

            //mail9
            LinearLayout ContentLayout4 = new LinearLayout(context);
            ContentLayout4.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            TextView date4 = new TextView(context);
            date4.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            date4.Text = "May 11";
            date4.Typeface = Typeface.DefaultBold;
            date4.SetTextColor(Color.ParseColor("#006BCD"));
            date4.Gravity = GravityFlags.End;
            mail9 = new LinearLayout(context);
            TextView userNameLabel7 = new TextView(context);
            userNameLabel7.Text = "Gonzalez";
            userNameLabel7.Typeface = Typeface.DefaultBold;
            userNameLabel7.TextSize = 15;
            TextView updateLabel5 = new TextView(context);
            updateLabel5.Text = "News Letter";
            updateLabel5.Typeface = Typeface.DefaultBold;
            updateLabel5.SetTextColor(Color.ParseColor("#006BCD"));
            updateLabel5.TextSize = 13;
            TextView messageLabel5 = new TextView(context);
            messageLabel5.Text = "Hi, Please find the attached news letter";
            messageLabel5.TextSize = 12;

            TextView spaceText5 = new TextView(context);
            spaceText5.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 20);
            TextView Text5 = new TextView(context);
            Text5.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 20);
            ContentLayout4.AddView(userNameLabel7);
            ContentLayout4.AddView(date4);

            mail9.AddView(ContentLayout4);
            mail9.AddView(spaceText5);
            mail9.AddView(updateLabel5);
            mail9.AddView(Text5);
            mail9.AddView(messageLabel5);
            labelSeparator7 = new SeparatorView(context, width * 2);
            labelSeparator7.separatorColor = Color.LightGray;
            labelSeparator7.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));

            //mail10
            LinearLayout ContentLayout5 = new LinearLayout(context);
            ContentLayout5.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            TextView date5 = new TextView(context);
            date5.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            date5.Text = "May 12";
            date5.Typeface = Typeface.DefaultBold;
            date5.SetTextColor(Color.ParseColor("#006BCD"));
            date5.Gravity = GravityFlags.End;
            mail10 = new LinearLayout(context);
            TextView userNameLabel8 = new TextView(context);
            userNameLabel8.Text = "Rodriguez";
            userNameLabel8.Typeface = Typeface.DefaultBold;
            userNameLabel8.TextSize = 15;
            TextView updateLabel6 = new TextView(context);
            updateLabel6.Text = "Conference about Latest Technology";
            updateLabel6.Typeface = Typeface.DefaultBold;
            updateLabel6.SetTextColor(Color.ParseColor("#006BCD"));
            updateLabel6.TextSize = 13;
            TextView messageLabel6 = new TextView(context);
            messageLabel6.Text = "Hi,We are scheduled a conference meeting";
            messageLabel6.TextSize = 12;

            TextView spaceText6 = new TextView(context);
            spaceText6.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 20);
            TextView Text6 = new TextView(context);
            Text6.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 20);

            ContentLayout5.AddView(userNameLabel8);
            ContentLayout5.AddView(date5);

            mail10.AddView(ContentLayout5);
            mail10.AddView(spaceText6);
            mail10.AddView(updateLabel6);
            mail10.AddView(Text6);
            mail10.AddView(messageLabel6);
            labelSeparator8 = new SeparatorView(context, width * 2);
            labelSeparator8.separatorColor = Color.LightGray;
            labelSeparator8.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));

            //mail11
            LinearLayout ContentLayout6 = new LinearLayout(context);
            ContentLayout6.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            TextView date6 = new TextView(context);
            date6.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            date6.Text = "May 13";
            date6.Typeface = Typeface.DefaultBold;
            date6.SetTextColor(Color.ParseColor("#006BCD"));
            date6.Gravity = GravityFlags.End;
            mail11 = new LinearLayout(context);
            TextView userNameLabel9 = new TextView(context);
            userNameLabel9.Text = "Ruben";
            userNameLabel9.TextSize = 15;
            userNameLabel9.Typeface = Typeface.DefaultBold;

            TextView updateLabel7 = new TextView(context);
            updateLabel7.Text = "RE:Status Update";
            updateLabel7.SetTextColor(Color.ParseColor("#006BCD"));
            updateLabel7.Typeface = Typeface.DefaultBold;
            updateLabel7.TextSize = 13;
            TextView messageLabel7 = new TextView(context);
            messageLabel7.Text = "Thanks for the status report";
            messageLabel7.TextSize = 12;

            TextView spaceText7 = new TextView(context);
            spaceText7.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 20);
            TextView Text7 = new TextView(context);
            Text7.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 20);
            ContentLayout6.AddView(userNameLabel9);
            ContentLayout6.AddView(date6);

            mail11.AddView(ContentLayout6);
            mail11.AddView(spaceText7);
            mail11.AddView(updateLabel7);
            mail11.AddView(Text7);
            mail11.AddView(messageLabel7);

            labelSeparator9 = new SeparatorView(context, width * 2);
            labelSeparator9.separatorColor = Color.LightGray;
            labelSeparator9.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));

            //mail18
            mail18 = new LinearLayout(context);
            TextView userNameLabel18 = new TextView(context);
            userNameLabel18.Text = "Frank";
            userNameLabel18.TextSize = 15;

            TextView updateLabel18 = new TextView(context);
            updateLabel18.Text = "Monthly Reports Documents";
            updateLabel18.TextSize = 13;
            TextView messageLabel18 = new TextView(context);
            messageLabel18.Text = "Hi,All documents are reviewed";
            messageLabel18.TextSize = 12;

            TextView spaceText18 = new TextView(context);
            spaceText18.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 20);
            TextView Text18 = new TextView(context);
            Text18.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 20);

            mail18.AddView(userNameLabel18);
            mail18.AddView(spaceText18);
            mail18.AddView(updateLabel18);
            mail18.AddView(Text18);
            mail18.AddView(messageLabel18);

            labelSeparator18 = new SeparatorView(context, width * 2);
            labelSeparator18.separatorColor = Color.LightGray;
            labelSeparator18.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));

            //mail19
            mail19 = new LinearLayout(context);
            TextView userNameLabel19 = new TextView(context);
            userNameLabel19.Text = "Michael";
            userNameLabel19.TextSize = 15;

            TextView updateLabel19 = new TextView(context);
            updateLabel19.Text = "Metting Confirmation";
            updateLabel19.TextSize = 13;
            TextView messageLabel19 = new TextView(context);
            messageLabel19.Text = "Thanks for scheduling the metting";
            messageLabel19.TextSize = 12;

            TextView spaceText19 = new TextView(context);
            spaceText19.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 20);
            TextView Text19 = new TextView(context);
            Text19.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 20);

            mail19.AddView(userNameLabel19);
            mail19.AddView(spaceText19);
            mail19.AddView(updateLabel19);
            mail19.AddView(Text19);
            mail19.AddView(messageLabel19);

            labelSeparator19 = new SeparatorView(context, width * 2);
            labelSeparator19.separatorColor = Color.LightGray;
            labelSeparator19.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));

            //mail20
            mail20 = new LinearLayout(context);
            TextView userNameLabel20 = new TextView(context);
            userNameLabel20.Text = "Robin";
            userNameLabel20.TextSize = 15;

            TextView updateLabel20 = new TextView(context);
            updateLabel20.Text = "Success! Report Automation";
            updateLabel20.TextSize = 13;
            TextView messageLabel20 = new TextView(context);
            messageLabel20.Text = "Do not reply, Automation result will update soon";
            messageLabel20.TextSize = 12;

            TextView spaceText20 = new TextView(context);
            spaceText20.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 20);
            TextView Text20 = new TextView(context);
            Text20.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 20);

            mail20.AddView(userNameLabel20);
            mail20.AddView(spaceText20);
            mail20.AddView(updateLabel20);
            mail20.AddView(Text20);
            mail20.AddView(messageLabel20);

            labelSeparator20 = new SeparatorView(context, width * 2);
            labelSeparator20.separatorColor = Color.LightGray;
            labelSeparator20.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));

            //mail Orientation 
            mail1.Orientation = Orientation.Vertical;
            mail2.Orientation = Orientation.Vertical;
            mail3.Orientation = Orientation.Vertical;
            mail4.Orientation = Orientation.Vertical;
            mail9.Orientation = Orientation.Vertical;
            mail10.Orientation = Orientation.Vertical;
            mail11.Orientation = Orientation.Vertical;
            mail18.Orientation = Orientation.Vertical;
            mail19.Orientation = Orientation.Vertical;
            mail20.Orientation = Orientation.Vertical;

            //mail LayoutParameters
            mail1.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail1.SetPadding(20, 10, 10, 5);
            mail2.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail2.SetPadding(20, 10, 10, 5);
            mail3.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail3.SetPadding(20, 10, 10, 5);
            mail4.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail4.SetPadding(20, 10, 10, 5);
            mail9.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail9.SetPadding(20, 10, 10, 5);
            mail10.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail10.SetPadding(20, 10, 10, 5);
            mail11.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail11.SetPadding(20, 10, 10, 5);
            mail18.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail18.SetPadding(20, 10, 10, 5);
            mail19.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail19.SetPadding(20, 10, 10, 5);
            mail20.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail20.SetPadding(20, 10, 10, 5);

            //inboxview
            inboxLayout.SetPadding(20, 0, 20, 20);
            inboxLayout.AddView(mail1);
            inboxLayout.AddView(labelSeparator3, layoutParams5);
            inboxLayout.AddView(mail2);
            inboxLayout.AddView(labelSeparator4, layoutParams5);
            inboxLayout.AddView(mail3);
            inboxLayout.AddView(labelSeparator5, layoutParams5);
            inboxLayout.AddView(mail4);
            inboxLayout.AddView(labelSeparator6, layoutParams5);
            inboxLayout.AddView(mail9);
            inboxLayout.AddView(labelSeparator7, layoutParams5);
            inboxLayout.AddView(mail10);
            inboxLayout.AddView(labelSeparator9, layoutParams5);
            inboxLayout.AddView(mail11);
            inboxLayout.AddView(labelSeparator8, layoutParams5);
            inboxLayout.AddView(mail18);
            inboxLayout.AddView(labelSeparator18, layoutParams5);
            inboxLayout.AddView(mail19);
            inboxLayout.AddView(labelSeparator19, layoutParams5);
            inboxLayout.AddView(mail20);
            inboxLayout.AddView(labelSeparator20, layoutParams5);
        }

        private void SecondaryDrawerLayout()
        {
            //textScroller
            textScroller1 = new ScrollView(context);
            textScroller1.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);


            TextView headerView = new TextView(context);
            headerView.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            headerView.SetBackgroundColor(Color.Rgb(47, 173, 227));
            headerView.SetPadding(20, 0, 0, 0);
            headerView.Text = "Notifications";
            headerView.TextSize = 20;
            headerView.Gravity = GravityFlags.CenterVertical;
            headerView.SetTextColor(Color.White);

            //slideDrawer
            drawerSettings = new DrawerSettings();
            drawerSettings.DrawerWidth = (float)(230);
            drawerSettings.DrawerHeight = (float)(250);
            drawerSettings.DrawerHeaderHeight = 40;
            drawerSettings.Transition = Transition.SlideOnTop;
            drawerSettings.Position = Position.Right;
            drawerSettings.EnableSwipeGesture = true;
            drawerSettings.TouchThreshold = 90;
            drawerSettings.DrawerHeaderView = headerView;

            //ItemLAyout
            ItemLayout1 = new LinearLayout(context);
            ItemLayout1.Orientation = Orientation.Horizontal;
            ItemLayout2 = new LinearLayout(context);
            ItemLayout2.Orientation = Orientation.Horizontal;
            ItemLayout3 = new LinearLayout(context);
            ItemLayout3.Orientation = Orientation.Horizontal;
            ItemLayout4 = new LinearLayout(context);
            ItemLayout4.Orientation = Orientation.Horizontal;
            ItemLayout5 = new LinearLayout(context);
            ItemLayout5.Orientation = Orientation.Horizontal;
            ItemLayout6 = new LinearLayout(context);
            ItemLayout6.Orientation = Orientation.Horizontal;
            ItemLayout7 = new LinearLayout(context);
            ItemLayout7.Orientation = Orientation.Horizontal;

            //secondaryDrawerLayout
            secondaryDrawerLayout = new LinearLayout(context);
            secondaryDrawerLayout.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            secondaryDrawerLayout.SetBackgroundColor(Color.White);
            secondaryDrawerLayout.Orientation = Orientation.Vertical;

            //layoutParamsSecondaryDrawer
            layoutParamsSecondaryDrawer = new LinearLayout.LayoutParams(width * 2, 3);
            layoutParamsSecondaryDrawer.SetMargins(0, 10, 15, 0);

            //ItemImage
            ImageView imag1 = new ImageView(context);
            imag1.LayoutParameters = new ViewGroup.LayoutParams(120, 120);
            imag1.SetPadding(0, 20, 0, 0);
            imag1.SetImageResource(Resource.Drawable.a5);

            ImageView imag2 = new ImageView(context);
            imag2.LayoutParameters = new ViewGroup.LayoutParams(120, 120);
            imag2.SetPadding(0, 20, 0, 0);
            imag2.SetImageResource(Resource.Drawable.a0);

            ImageView imag3 = new ImageView(context);
            imag3.LayoutParameters = new ViewGroup.LayoutParams(120, 120);
            imag3.SetPadding(0, 20, 0, 0);
            imag3.SetImageResource(Resource.Drawable.a1);

            ImageView imag4 = new ImageView(context);
            imag4.LayoutParameters = new ViewGroup.LayoutParams(120, 120);
            imag4.SetPadding(0, 20, 0, 0);
            //LinearLayout.LayoutParams layparams8 = new LinearLayout.LayoutParams(30,30);
            imag4.SetImageResource(Resource.Drawable.a2);

            ImageView imag5 = new ImageView(context);
            imag5.LayoutParameters = new ViewGroup.LayoutParams(120, 120);
            imag5.SetPadding(0, 20, 0, 0);
            imag5.SetImageResource(Resource.Drawable.a3);

            ImageView imag6 = new ImageView(context);
            imag6.LayoutParameters = new ViewGroup.LayoutParams(120, 120);
            imag6.SetPadding(0, 20, 0, 0);
            imag6.SetImageResource(Resource.Drawable.a4);

            ImageView imag7 = new ImageView(context);
            imag7.LayoutParameters = new ViewGroup.LayoutParams(120, 120);
            imag7.SetPadding(0, 20, 0, 0);
            imag7.SetImageResource(Resource.Drawable.user);

            //Item1
            Item1 = new LinearLayout(context);
            Item1.Orientation = Orientation.Vertical;
            Item1.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            Item1.SetPadding(20, 10, 10, 5);
            //John
            TextView userNameLabel1 = new TextView(context);
            userNameLabel1.Text = "John";
            userNameLabel1.Typeface = Typeface.DefaultBold;
            userNameLabel1.TextSize = 15;

            TextView spaceText = new TextView(context);
            spaceText.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 3);
            TextView Text1 = new TextView(context);
            Text1.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 4);
            TextView messageLabel1 = new TextView(context);
            messageLabel1.SetTextColor(Color.Rgb(0, 107, 205));
            messageLabel1.Text = "Goto Meeting";
            messageLabel1.Typeface = Typeface.DefaultBold;

            TextView description1 = new TextView(context);
            description1.TextSize = 12;
            description1.Text = "Join meeting to discuss about daily status, workflow, pending work and improve process";
            Item1.AddView(userNameLabel1);
            Item1.AddView(spaceText);
            Item1.AddView(messageLabel1);
            Item1.AddView(Text1);
            Item1.AddView(description1);

            //separatorView
            separatorView1 = new SeparatorView(context, width * 2);
            separatorView1.separatorColor = Color.LightGray;
            separatorView1.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 3);

            ItemLayout1.AddView(imag1);
            ItemLayout1.AddView(Item1);

            //Item2
            Item2 = new LinearLayout(context);
            Item2.Orientation = Orientation.Vertical;
            Item2.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            Item2.SetPadding(20, 10, 10, 5);
            //Caster
            TextView userNameLabel2 = new TextView(context);
            userNameLabel2.Text = "Caster";
            userNameLabel2.Typeface = Typeface.DefaultBold;
            userNameLabel2.TextSize = 15;
            TextView spaceText2 = new TextView(context);
            spaceText2.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 3);
            TextView Text2 = new TextView(context);
            Text2.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 4);
            TextView messageLabel2 = new TextView(context);
            messageLabel2.SetTextColor(Color.Rgb(0, 107, 205));
            messageLabel2.Text = "FW:Status Update";
            messageLabel2.Typeface = Typeface.DefaultBold;

            TextView description2 = new TextView(context);
            description2.TextSize = 12;
            description2.Text = "Hi, Please find the today's status";
            Item2.AddView(userNameLabel2);
            Item2.AddView(spaceText2);
            Item2.AddView(messageLabel2);
            Item1.AddView(Text2);
            Item2.AddView(description2);

            //separatorView
            separatorView2 = new SeparatorView(context, width * 2);
            separatorView2.separatorColor = Color.LightGray;
            separatorView2.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 3);

            ItemLayout2.AddView(imag2);
            ItemLayout2.AddView(Item2);

            //Item3
            Item3 = new LinearLayout(context);
            Item3.Orientation = Orientation.Vertical;
            Item3.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            Item3.SetPadding(20, 10, 10, 5);
            //Joey
            TextView userNameLabel3 = new TextView(context);
            userNameLabel3.Text = "Joey";
            userNameLabel3.Typeface = Typeface.DefaultBold;
            userNameLabel3.TextSize = 15;
            TextView spaceText3 = new TextView(context);
            spaceText3.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 3);
            TextView Text3 = new TextView(context);
            Text3.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 4); TextView messageLabel3 = new TextView(context);
            messageLabel3.SetTextColor(Color.Rgb(0, 107, 205));
            messageLabel3.Text = "Greetings! Congrats";
            messageLabel3.Typeface = Typeface.DefaultBold;


            TextView description3 = new TextView(context);
            description3.TextSize = 12;
            description3.Text = "Hi, Congrats you have won the raffle";
            Item3.AddView(userNameLabel3);
            Item3.AddView(spaceText3);
            Item3.AddView(messageLabel3);
            Item3.AddView(Text3);
            Item3.AddView(description3);

            //separatorView
            separatorView3 = new SeparatorView(context, width * 2);
            separatorView3.separatorColor = Color.LightGray;
            separatorView3.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 3);


            ItemLayout3.AddView(imag3);
            ItemLayout3.AddView(Item3);

            //Item4
            Item4 = new LinearLayout(context);
            Item4.Orientation = Orientation.Vertical;
            Item4.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            Item4.SetPadding(20, 10, 10, 5);
            //Xavier
            TextView userNameLabel4 = new TextView(context);
            userNameLabel4.Text = "Xavier";
            userNameLabel4.Typeface = Typeface.DefaultBold;
            userNameLabel4.TextSize = 15;
            TextView spaceText4 = new TextView(context);
            spaceText4.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 3);
            TextView Text4 = new TextView(context);
            Text4.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 4);
            TextView messageLabel4 = new TextView(context);
            messageLabel4.SetTextColor(Color.Rgb(0, 107, 205));
            messageLabel4.Text = "Report Monitor";
            messageLabel4.Typeface = Typeface.DefaultBold;


            TextView description4 = new TextView(context);
            description4.TextSize = 12;
            description4.Text = "Do not reply, Please find the attachment. Attachment have the full details of monitor report with timing";
            Item4.AddView(userNameLabel4);
            Item4.AddView(spaceText4);
            Item4.AddView(messageLabel4);
            Item4.AddView(Text4);
            Item4.AddView(description4);

            //separatorView
            separatorView4 = new SeparatorView(context, width * 2);
            separatorView4.separatorColor = Color.LightGray;
            separatorView4.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 3);


            ItemLayout4.AddView(imag4);
            ItemLayout4.AddView(Item4);


            //Item5
            Item5 = new LinearLayout(context);
            Item5.Orientation = Orientation.Vertical;
            Item5.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            Item5.SetPadding(20, 10, 10, 5);
            //Gonzalez
            TextView userNameLabel5 = new TextView(context);
            userNameLabel5.Text = "Gonzalez";
            userNameLabel5.Typeface = Typeface.DefaultBold;
            userNameLabel5.TextSize = 15;
            TextView spaceText5 = new TextView(context);
            spaceText5.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 3);
            TextView Text5 = new TextView(context);
            Text5.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 4); TextView messageLabel5 = new TextView(context);
            messageLabel5.SetTextColor(Color.Rgb(0, 107, 205));
            messageLabel5.Text = "News Letter";
            messageLabel5.Typeface = Typeface.DefaultBold;


            TextView description5 = new TextView(context);
            description5.TextSize = 12;
            description5.Text = "Hi, Please find the attached news letter";
            Item5.AddView(userNameLabel5);
            Item5.AddView(spaceText5);
            Item5.AddView(messageLabel5);
            Item5.AddView(Text5);
            Item5.AddView(description5);

            //separatorView
            separatorView5 = new SeparatorView(context, width * 2);
            separatorView5.separatorColor = Color.LightGray;
            separatorView5.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 3);


            ItemLayout5.AddView(imag5);
            ItemLayout5.AddView(Item5);

            //Item6
            Item6 = new LinearLayout(context);
            Item6.Orientation = Orientation.Vertical;
            Item6.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            Item6.SetPadding(20, 10, 10, 5);
            //Rodriguez
            TextView userNameLabel6 = new TextView(context);
            userNameLabel6.Text = "Rodriguez";
            userNameLabel6.Typeface = Typeface.DefaultBold;
            userNameLabel6.TextSize = 15;
            TextView spaceText6 = new TextView(context);
            spaceText6.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 3);
            TextView Text6 = new TextView(context);
            Text6.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 4); TextView messageLabel6 = new TextView(context);
            messageLabel6.SetTextColor(Color.Rgb(0, 107, 205));
            messageLabel6.Text = "Conference about Latest Technology";
            messageLabel6.Typeface = Typeface.DefaultBold;


            TextView description6 = new TextView(context);
            description6.TextSize = 12;
            description6.Text = "Hi,We are scheduled a conference meeting";
            Item6.AddView(userNameLabel6);
            Item6.AddView(spaceText6);
            Item6.AddView(messageLabel6);
            Item6.AddView(Text6);
            Item6.AddView(description6);

            //separatorView
            separatorView6 = new SeparatorView(context, width * 2);
            separatorView6.separatorColor = Color.LightGray;
            separatorView6.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 3);


            ItemLayout6.AddView(imag6);
            ItemLayout6.AddView(Item6);

            //Item7
            Item7 = new LinearLayout(context);
            Item7.Orientation = Orientation.Vertical;
            Item7.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            Item7.SetPadding(20, 10, 10, 5);
            //Ruben
            TextView userNameLabel7 = new TextView(context);
            userNameLabel7.Text = "Ruben";
            userNameLabel7.Typeface = Typeface.DefaultBold;
            userNameLabel7.TextSize = 15;
            TextView spaceText7 = new TextView(context);
            spaceText7.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 3);
            TextView Text7 = new TextView(context);
            Text7.LayoutParameters = new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, 4); TextView messageLabel7 = new TextView(context);
            messageLabel7.SetTextColor(Color.Rgb(0, 107, 205));
            messageLabel7.Text = "RE:Status Update";
            messageLabel7.Typeface = Typeface.DefaultBold;


            TextView description7 = new TextView(context);
            description7.TextSize = 12;
            description7.Text = "Thanks for the status report";
            Item7.AddView(userNameLabel7);
            Item7.AddView(spaceText7);
            Item7.AddView(messageLabel7);
            Item7.AddView(description7);
            Item7.AddView(Text7);


            //separatorView
            separatorView7 = new SeparatorView(context, width * 2);
            separatorView7.separatorColor = Color.LightGray;
            separatorView7.LayoutParameters = new ViewGroup.LayoutParams(width * 2, 3);


            ItemLayout7.AddView(imag7);
            ItemLayout7.AddView(Item7);


            //secondaryDrawerLayout
            secondaryDrawerLayout.SetPadding(20, 0, 20, 20);
            secondaryDrawerLayout.AddView(ItemLayout1);
            secondaryDrawerLayout.AddView(separatorView1, layoutParamsSecondaryDrawer);
            secondaryDrawerLayout.AddView(ItemLayout2);
            secondaryDrawerLayout.AddView(separatorView2, layoutParamsSecondaryDrawer);
            secondaryDrawerLayout.AddView(ItemLayout3);
            secondaryDrawerLayout.AddView(separatorView3, layoutParamsSecondaryDrawer);
            secondaryDrawerLayout.AddView(ItemLayout4);
            secondaryDrawerLayout.AddView(separatorView4, layoutParamsSecondaryDrawer);
            secondaryDrawerLayout.AddView(ItemLayout5);
            secondaryDrawerLayout.AddView(separatorView5, layoutParamsSecondaryDrawer);
            secondaryDrawerLayout.AddView(ItemLayout6);
            secondaryDrawerLayout.AddView(separatorView6, layoutParamsSecondaryDrawer);
            secondaryDrawerLayout.AddView(ItemLayout7);
            secondaryDrawerLayout.AddView(separatorView7, layoutParamsSecondaryDrawer);

            textScroller1.AddView(secondaryDrawerLayout);

            drawerSettings.DrawerContentView = textScroller1;
            slideDrawer.SecondaryDrawerSettings = drawerSettings;
        }
       
        private void OutBoxLayout()
        {
            //outboxlayout
            outboxlayout = new LinearLayout(context);
            outboxlayout.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent));
            outboxlayout.SetBackgroundColor(Color.White);
            outboxlayout.Orientation = (Orientation.Vertical);

            //mail5
            mail5 = new LinearLayout(context);
            TextView userNameLabel10 = new TextView(context);
            userNameLabel10.Text = "Ruben";
            userNameLabel10.TextSize = 20;
            TextView updateLabel8 = new TextView(context);
            updateLabel8.Text = "Update on Timeline";
            updateLabel8.SetTextColor(Color.ParseColor("#1CAEE4"));
            updateLabel8.TextSize = 16;
            TextView messageLabel8 = new TextView(context);
            messageLabel8.Text = "Hi Ruben, see you at 6PM";
            labelSeparator10 = new SeparatorView(context, width * 2);
            labelSeparator10.separatorColor = Color.LightGray;
            labelSeparator10.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));
            messageLabel8.TextSize = 13;
            mail5.AddView(userNameLabel10);
            mail5.AddView(messageLabel8);

            //mail6
            mail6 = new LinearLayout(context);
            TextView userNameLabel11 = new TextView(context);
            userNameLabel11.Text = "Rodriguez";
            userNameLabel11.TextSize = 20;
            TextView updateLabel9 = new TextView(context);
            updateLabel9.Text = "Update on Timeline";
            updateLabel9.SetTextColor(Color.ParseColor("#1CAEE4"));
            updateLabel9.TextSize = 16;
            TextView messageLabel9 = new TextView(context);
            messageLabel9.Text = "Hi Rodriguez, see you at 4PM";
            messageLabel9.TextSize = 13;
            mail6.AddView(userNameLabel11);
            mail6.AddView(messageLabel9);

            //mail12
            mail12 = new LinearLayout(context);
            TextView userNameLabel12 = new TextView(context);
            userNameLabel12.Text = "Gonzalez";
            userNameLabel12.TextSize = 20;
            TextView updateLabel10 = new TextView(context);
            updateLabel10.Text = "Update on Timeline";
            updateLabel10.SetTextColor(Color.ParseColor("#1CAEE4"));
            updateLabel10.TextSize = 16;
            TextView messageLabel10 = new TextView(context);
            messageLabel10.Text = "Hi Gonzalez, see you at 3PM";
            mail12.AddView(userNameLabel12);
            mail12.AddView(messageLabel10);
            labelSeparator11 = new SeparatorView(context, width * 2);
            labelSeparator11.separatorColor = Color.LightGray;
            labelSeparator11.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));          
            mail12.Orientation = Orientation.Vertical;
            mail12.Orientation = (Orientation.Vertical);
            mail5.Orientation = Orientation.Vertical;
            mail6.Orientation = Orientation.Vertical;

            //mail13
            mail13 = new LinearLayout(context);
            TextView userNameLabel13 = new TextView(context);
            userNameLabel13.Text = "Xavier";
            userNameLabel13.TextSize = 20;
            TextView updateLabel11 = new TextView(context);
            updateLabel11.Text = "Update on Timeline";
            updateLabel11.SetTextColor(Color.ParseColor("#1CAEE4"));
            updateLabel11.TextSize = 16;
            TextView messageLabel11 = new TextView(context);
            messageLabel11.Text = "Hi Xavier, see you at 2PM";
            labelSeparator12 = new SeparatorView(context, width * 2);
            labelSeparator12.separatorColor = Color.LightGray;
            labelSeparator12.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));
            mail13.AddView(userNameLabel13);
            mail13.AddView(messageLabel11);
            mail13.Orientation = (Orientation.Vertical);
            mail13.Orientation = (Orientation.Vertical);

            //mail14
            mail14 = new LinearLayout(context);
            TextView userNameLabel14 = new TextView(context);
            userNameLabel14.Text = "Joey";
            userNameLabel14.TextSize = 20;
            TextView updateLabel12 = new TextView(context);
            updateLabel12.Text = "Update on Timeline";
            updateLabel12.SetTextColor(Color.ParseColor("#1CAEE4"));
            updateLabel12.TextSize = 16;
            TextView messageLabel12 = new TextView(context);
            messageLabel12.Text = "Hi Joey, see you at 1PM";
            labelSeparator13 = new SeparatorView(context, width * 2);
            labelSeparator13.separatorColor = Color.LightGray;
            labelSeparator13.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));
            mail14.AddView(userNameLabel14);
            mail14.AddView(messageLabel12);
            mail14.Orientation = (Orientation.Vertical);
            mail14.Orientation = (Orientation.Vertical);

            //mail15
            mail15 = new LinearLayout(context);
            TextView userNameLabel15 = new TextView(context);
            userNameLabel15.Text = "Joey";
            userNameLabel15.TextSize = 20;
            TextView updateLabel13 = new TextView(context);
            updateLabel13.Text = "Update on Timeline";
            updateLabel13.SetTextColor(Color.ParseColor("#1CAEE4"));
            updateLabel13.TextSize = 16;
            TextView messageLabel13 = new TextView(context);
            messageLabel13.Text = "Hi Joey, see you at 1PM";
            labelSeparator14 = new SeparatorView(context, width * 2);
            labelSeparator14.separatorColor = Color.LightGray;
            labelSeparator14.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));
            mail15.AddView(userNameLabel15);
            mail15.AddView(messageLabel13);
            mail15.Orientation = (Orientation.Vertical);
            mail15.Orientation = (Orientation.Vertical);

            //mail16
            mail16 = new LinearLayout(context);
            TextView userNameLabel16 = new TextView(context);
            userNameLabel16.Text = ("Caster");
            userNameLabel16.TextSize = (20);
            TextView updateLabel14 = new TextView(context);
            updateLabel14.Text = ("Update on Timeline");
            updateLabel14.SetTextColor(Color.ParseColor("#1CAEE4"));
            updateLabel14.TextSize = (16);
            TextView messageLabel14 = new TextView(context);
            messageLabel14.Text = ("Hi Caster, see you at 11PM");
            labelSeparator15 = new SeparatorView(context, width * 2);
            labelSeparator15.separatorColor = Color.LightGray;
            labelSeparator15.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));
            mail16.AddView(userNameLabel16);
            mail16.AddView(messageLabel14);
            mail16.Orientation = (Orientation.Vertical);
            mail16.Orientation = (Orientation.Vertical);

            //mail17
            mail17 = new LinearLayout(context);
            TextView userNameLabel17 = new TextView(context);
            userNameLabel17.Text = "john";
            userNameLabel17.TextSize = 20;
            TextView updateLabel15 = new TextView(context);
            updateLabel15.Text = ("Update on Timeline");
            updateLabel15.SetTextColor(Color.ParseColor("#1CAEE4"));
            updateLabel15.TextSize = (16);
            TextView messageLabel15 = new TextView(context);
            messageLabel15.Text = ("Hi John, see you at 10AM");
            labelSeparator16 = new SeparatorView(context, width * 2);
            labelSeparator16.separatorColor = Color.LightGray;
            labelSeparator16.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));
            mail17.AddView(userNameLabel17);
            mail17.AddView(messageLabel15);
            mail17.Orientation = (Orientation.Vertical);
            mail17.Orientation = (Orientation.Vertical);

            //mail LayoutParameters
            mail6.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail6.SetPadding(20, 10, 10, 10);
            mail5.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail5.SetPadding(20, 10, 10, 5);
            mail12.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail12.SetPadding(20, 10, 10, 5);
            mail13.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail13.SetPadding(20, 10, 10, 5);
            mail14.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail14.SetPadding(20, 10, 10, 5);
            mail15.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail15.SetPadding(20, 10, 10, 5);
            mail16.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail16.SetPadding(20, 10, 10, 5);
            mail17.LayoutParameters = (new ViewGroup.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.WrapContent));
            mail17.SetPadding(20, 10, 10, 5);

            labelSeparator17 = new SeparatorView(context, width * 2);
            labelSeparator17.separatorColor = Color.LightGray;
            labelSeparator17.LayoutParameters = (new ViewGroup.LayoutParams(width * 2, 3));

            //outboxView
            outboxlayout.SetPadding(20, 0, 20, 20);
            outboxlayout.AddView(mail5);
            outboxlayout.AddView(labelSeparator17, layoutParams5);
            outboxlayout.AddView(mail6);
            outboxlayout.AddView(labelSeparator10, layoutParams5);
            outboxlayout.AddView(mail12);
            outboxlayout.AddView(labelSeparator11, layoutParams5);
            outboxlayout.AddView(mail13);
            outboxlayout.AddView(labelSeparator12, layoutParams5);
            outboxlayout.AddView(mail15);
            outboxlayout.AddView(labelSeparator14, layoutParams5);
            outboxlayout.AddView(mail16);
            outboxlayout.AddView(labelSeparator15, layoutParams5);
            outboxlayout.AddView(mail17);
            outboxlayout.AddView(labelSeparator16, layoutParams5);
        }

        private void ClickListenerLayout()
        {
            //textScroller
            textScroller2 = new ScrollView(context);
            textScroller2.LayoutParameters = new FrameLayout.LayoutParams(ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);

            //Item click Listener
            viewItem.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {
                String selectedItem = arrayAdapter.GetItem(e.Position);
                if (selectedItem.Equals("Home"))
                {
                    ContentFrame.RemoveAllViews();
                    ContentFrame.AddView(textScroller);
                    profileContentLabel.Text = "Home";

                }
                if (selectedItem.Equals("Profile"))
                {
                    ContentFrame.RemoveAllViews();
                    ContentFrame.AddView(profilelayout);
                    profileContentLabel.Text = "Profile";

                }
                if (selectedItem.Equals("Inbox"))
                {
                    ContentFrame.RemoveAllViews();
                    inboxLayout.RemoveAllViews();
                    textScroller2.RemoveAllViews();
                    inboxLayout.SetPadding(20, 0, 20, 20);
                    inboxLayout.AddView(mail1);
                    inboxLayout.AddView(labelSeparator3, layoutParams5);
                    inboxLayout.AddView(mail2);
                    inboxLayout.AddView(labelSeparator4, layoutParams5);
                    inboxLayout.AddView(mail3);
                    inboxLayout.AddView(labelSeparator5, layoutParams5);
                    inboxLayout.AddView(mail4);
                    inboxLayout.AddView(labelSeparator6, layoutParams5);
                    inboxLayout.AddView(mail9);
                    inboxLayout.AddView(labelSeparator7, layoutParams5);
                    inboxLayout.AddView(mail10);
                    inboxLayout.AddView(labelSeparator9, layoutParams5);
                    inboxLayout.AddView(mail11);
                    inboxLayout.AddView(labelSeparator8, layoutParams5);
                    inboxLayout.AddView(mail18);
                    inboxLayout.AddView(labelSeparator18, layoutParams5);
                    inboxLayout.AddView(mail19);
                    inboxLayout.AddView(labelSeparator19, layoutParams5);
                    inboxLayout.AddView(mail20);
                    inboxLayout.AddView(labelSeparator20, layoutParams5);
                    textScroller2.AddView(inboxLayout);
                    ContentFrame.AddView(textScroller2);
                    profileContentLabel.Text = "Inbox";
                }
                if (selectedItem.Equals("Outbox"))
                {

                    ContentFrame.RemoveAllViews();
                    outboxlayout.RemoveAllViews();
                    outboxlayout.SetPadding(20, 0, 20, 20);
                    outboxlayout.AddView(mail5);
                    outboxlayout.AddView(labelSeparator17, layoutParams5);
                    outboxlayout.AddView(mail6);
                    outboxlayout.AddView(labelSeparator10, layoutParams5);
                    outboxlayout.AddView(mail12);
                    outboxlayout.AddView(labelSeparator11, layoutParams5);
                    outboxlayout.AddView(mail13);
                    outboxlayout.AddView(labelSeparator12, layoutParams5);
                    outboxlayout.AddView(mail15);
                    outboxlayout.AddView(labelSeparator14, layoutParams5);
                    outboxlayout.AddView(mail16);
                    outboxlayout.AddView(labelSeparator15, layoutParams5);
                    outboxlayout.AddView(mail17);
                    outboxlayout.AddView(labelSeparator16, layoutParams5);
                    ContentFrame.AddView(outboxlayout);
                    profileContentLabel.Text = "Outbox";
                }
                if (selectedItem.Equals("Sent Items"))
                {
                    ContentFrame.RemoveAllViews();
                    inboxLayout.RemoveAllViews();
                    inboxLayout.SetPadding(20, 0, 20, 20);
                    textScroller2.RemoveAllViews();

                    inboxLayout.AddView(mail10);
                    inboxLayout.AddView(labelSeparator4, layoutParams5);
                    inboxLayout.AddView(mail9);
                    inboxLayout.AddView(labelSeparator5, layoutParams5);
                    inboxLayout.AddView(mail4);
                    inboxLayout.AddView(labelSeparator6, layoutParams5);
                    inboxLayout.AddView(mail3);
                    inboxLayout.AddView(labelSeparator8, layoutParams5);
                    inboxLayout.AddView(mail11);
                    inboxLayout.AddView(labelSeparator3, layoutParams5);
                    inboxLayout.AddView(mail1);
                    inboxLayout.AddView(labelSeparator7, layoutParams5);
                    inboxLayout.AddView(mail2);
                    inboxLayout.AddView(labelSeparator9, layoutParams5);
                    textScroller2.AddView(inboxLayout);
                    ContentFrame.AddView(textScroller2);
                    profileContentLabel.Text = "Sent Items";
                }
                if (selectedItem.Equals("Trash"))
                {
                    ContentFrame.RemoveAllViews();
                    outboxlayout.RemoveAllViews();
                    outboxlayout.SetPadding(20, 0, 20, 20);
                    outboxlayout.AddView(mail13);
                    outboxlayout.AddView(labelSeparator12, layoutParams5);
                    outboxlayout.AddView(mail5);
                    outboxlayout.AddView(labelSeparator17, layoutParams5);
                    outboxlayout.AddView(mail12);
                    outboxlayout.AddView(labelSeparator11, layoutParams5);
                    outboxlayout.AddView(mail15);
                    outboxlayout.AddView(labelSeparator14, layoutParams5);
                    outboxlayout.AddView(mail17);
                    outboxlayout.AddView(labelSeparator16, layoutParams5);
                    outboxlayout.AddView(mail16);
                    outboxlayout.AddView(labelSeparator15, layoutParams5);
                    outboxlayout.AddView(mail6);
                    outboxlayout.AddView(labelSeparator10, layoutParams5);
                    ContentFrame.AddView(outboxlayout);
                    profileContentLabel.Text = "Trash";
                }
                slideDrawer.ToggleDrawer();
            };
        }
        private int getDimensionPixelSize(Context con, int id)
        {
            return con.Resources.GetDimensionPixelSize(id);
        }
    }
}

