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
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace SampleBrowser
{
    internal class StampSelectionView : FrameLayout
    {
        FrameLayout root;
        LinearLayout linear, stampTitle, bottomBar;
        Button backButton, closeButton;
        TextView title;
        ImageButton approved, notApproved, draft, expired, confidential;
        CustomToolBarPdfViewerDemo mainPage;
        internal bool isShowing;
        internal StampSelectionView(Context context, CustomToolBarPdfViewerDemo mainPage) : base(context)
        {
            this.mainPage = mainPage;
            LayoutInflater inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            root = (FrameLayout)inflater.Inflate(Resources.GetLayout(Resource.Layout.StampViewList), this, true);
            linear = root.FindViewById<LinearLayout>(Resource.Id.linearView);
            backButton = root.FindViewById<Button>(Resource.Id.backButton);
            stampTitle = root.FindViewById<LinearLayout>(Resource.Id.stampTitlebar);
            bottomBar = root.FindViewById<LinearLayout>(Resource.Id.bottomBar);
            closeButton = root.FindViewById<Button>(Resource.Id.closeBtn);
            closeButton.Click += CloseButton_Click;
            closeButton.SetBackgroundColor(Color.Transparent);
            closeButton.SetTextColor(mainPage.fontColor);
            backButton.Typeface = mainPage.bookmarkFont;
            backButton.Click += BackButton_Click;
            title = root.FindViewById<TextView>(Resource.Id.title);
            linear.SetBackgroundColor(Color.White);

            if (mainPage.IsDeviceTablet)
            {
                LayoutParams newParams = new LayoutParams(600, 350);
                newParams.Gravity = GravityFlags.Center;
                backButton.Visibility = ViewStates.Gone;
                LayoutParams titleLayoutParams = new LayoutParams(LayoutParams.MatchParent, LayoutParams.WrapContent);
                titleLayoutParams.Gravity = GravityFlags.Center;
                title.LayoutParameters = titleLayoutParams;
                linear.LayoutParameters = newParams;
                title.SetTextColor(Color.Black);
                title.Text = "Choose Stamp";
            }
            else
            {
                bottomBar.Visibility = ViewStates.Invisible;
                stampTitle.LayoutParameters = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, 150);
                title.SetTextColor(mainPage.fontColor);
            }

            approved = root.FindViewById<ImageButton>(Resource.Id.approved);
            approved.SetBackgroundColor(Color.Transparent);
            approved.Click += StampChosen;
            notApproved = root.FindViewById<ImageButton>(Resource.Id.notapproved);
            notApproved.SetBackgroundColor(Color.Transparent);
            notApproved.Click += StampChosen;
            draft = root.FindViewById<ImageButton>(Resource.Id.draft);
            draft.SetBackgroundColor(Color.Transparent);
            draft.Click += StampChosen;
            expired = root.FindViewById<ImageButton>(Resource.Id.expired);
            expired.SetBackgroundColor(Color.Transparent);
            expired.Click += StampChosen;
            confidential = root.FindViewById<ImageButton>(Resource.Id.confidential);
            confidential.SetBackgroundColor(Color.Transparent);
            confidential.Click += StampChosen;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
			mainPage.m_bottomToolbars.Visibility = ViewStates.Visible;
            mainPage.m_topToolbars.Visibility = ViewStates.Visible;
            Hide();
        }

        private void StampChosen(object sender, EventArgs e)
        {
            ImageView stamp = new ImageView(Context);
            ImageButton button = sender as ImageButton;
            if (button == approved)
                stamp.SetImageResource(Resource.Drawable.Approved);
            else if (button == notApproved)
                stamp.SetImageResource(Resource.Drawable.NotApproved);
            else if (button == draft)
                stamp.SetImageResource(Resource.Drawable.Draft);
            else if (button == confidential)
                stamp.SetImageResource(Resource.Drawable.Confidential);
            else if (button == expired)
                stamp.SetImageResource(Resource.Drawable.Expired);
            stamp.SetAdjustViewBounds(false);

            stamp.SetScaleType(ImageView.ScaleType.FitXy);
            stamp.Layout(100, 100, 300, 60);
            mainPage.pdfViewerControl.AddStamp(stamp, mainPage.pdfViewerControl.PageNumber);
			mainPage.m_bottomToolbars.Visibility = ViewStates.Visible;
            mainPage.m_topToolbars.Visibility = ViewStates.Visible;
            Hide();
        }

        private void Hide()
        {
            if (mainPage.IsDeviceTablet)
                mainPage.popup.Dismiss();
            else
                (Parent as LinearLayout).RemoveView(this);
            isShowing = false;
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
			mainPage.m_bottomToolbars.Visibility = ViewStates.Visible;
            mainPage.m_topToolbars.Visibility = ViewStates.Visible;
            Hide();
        }
    }
}