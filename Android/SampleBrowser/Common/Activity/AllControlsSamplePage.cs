#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace SampleBrowser
{
    [Activity(Theme = "@style/PropertyApp", MainLauncher = false, ScreenOrientation = ScreenOrientation.Portrait)]
    public class AllControlsSamplePage : Activity
    {
        #region fields

        private bool isselected = true;

        #endregion

        #region properties

        internal SampleModel SelectedGroup { get; set; }

        internal SamplePage CurrentSamplePage { get; set; }

        internal RelativeLayout SettingsButton { get; set; }

        #endregion

        #region methods

        public override void OnBackPressed()
        {
            Finish();
            base.OnBackPressed();
        }

        public override void Finish()
        {
            if (CurrentSamplePage != null)
            {
                CurrentSamplePage.Destroy();
                CurrentSamplePage = null;
            }

            base.Finish();
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
            {
                Finish();
            }

            return base.OnOptionsItemSelected(item);
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            ActionBar.SetDisplayShowCustomEnabled(true);
            ActionBar.SetIcon(new ColorDrawable(Color.Transparent));
            ActionBar.SetDisplayShowTitleEnabled(false);

            LayoutInflater layoutInflater = LayoutInflater.From(this);
            View customActionBar = layoutInflater.Inflate(Resource.Layout.CustomActionBar, null);
            RelativeLayout imageButton = (RelativeLayout)customActionBar.FindViewById(Resource.Id.imageButton);

            View propertyWindow = layoutInflater.Inflate(Resource.Layout.Propertywindow, null);
            View mainView = layoutInflater.Inflate(Resource.Layout.layout, null);
            SettingsButton = imageButton;
            SetContentView(mainView);

            var popup = new PopupWindow(propertyWindow, ViewGroup.LayoutParams.MatchParent, ViewGroup.LayoutParams.MatchParent);
            popup.Focusable = true;

            popup.DismissEvent += (s, e) => isselected = true;
            imageButton.Click += delegate
            {
                popup.ContentView = propertyWindow;
                if (CurrentSamplePage.PropertyView == null)
                {
                    CurrentSamplePage.PropertyView = CurrentSamplePage.GetPropertyWindowLayout(this);
                }

                var linear = (LinearLayout)propertyWindow.FindViewById(Resource.Id.container);
                linear.RemoveAllViews();
                linear.AddView(CurrentSamplePage.PropertyView);
                if (isselected)
                {
                    popup.ShowAsDropDown(imageButton, 0, 280);
                    popup.Focusable = true;
                    popup.Update();
                    isselected = false;
                }

                ImageView iconclose = (ImageView)propertyWindow.FindViewById(Resource.Id.close);
                Button discard = (Button)propertyWindow.FindViewById(Resource.Id.discard);
                Button apply = (Button)propertyWindow.FindViewById(Resource.Id.apply);

                iconclose.Click += delegate
                {
                    popup.Dismiss();
                    isselected = true;
                };

                discard.Click += delegate
                {
                    popup.Dismiss();
                    isselected = true;
                };

                apply.Click += delegate
                {
                    CurrentSamplePage.OnApplyChanges(CurrentSamplePage.SampleView);
                    popup.Dismiss();
                    isselected = true;
                };
            };

            ActionBar.CustomView = customActionBar;
            SelectedGroup = (ControlModel)MainActivity.SelectedIntent.GetSerializableExtra("sample");
            var textView = (TextView)FindViewById(Resource.Id.title_text);
            textView.Text = SelectedGroup.Title;
            var textParent = (RelativeLayout)FindViewById(Resource.Id.textParent);
            textParent.Click += (s, e) => Finish();

            if ((SelectedGroup as ControlModel).Features.Count > 0)
            {
                ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
                AddTab("Types", new ChartFragment((SelectedGroup as ControlModel).Samples, this));
                AddTab("Features", new ChartFragment((SelectedGroup as ControlModel).Features, this));
            }
            else
            {
                ActionBar.NavigationMode = ActionBarNavigationMode.Standard;
                FrameLayout frameLayout = (FrameLayout)mainView.FindViewById(Resource.Id.fragment_content);
                var sampleViewActivity = new SampleViewActivity((SelectedGroup as ControlModel).Samples, frameLayout, this, 0);
                if ((SelectedGroup as ControlModel).Samples.Count > 0)
                {
                    textView.Text = (SelectedGroup as ControlModel).Samples[0].Title;
                }

                sampleViewActivity.BaseTextView = textView;
            }

            if (savedInstanceState != null && ActionBar.TabCount > 0)
            {
                ActionBar.SelectTab(this.ActionBar.GetTabAt(savedInstanceState.GetInt("tab")));
            }

            base.OnCreate(savedInstanceState);
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            outState.PutInt("tab", this.ActionBar.SelectedNavigationIndex);
            base.OnSaveInstanceState(outState);
        }

        private void AddTab(string tabText, Fragment view)
        {
            var tab = ActionBar.NewTab();
            tab.SetText(tabText);

            tab.TabSelected += delegate(object sender, ActionBar.TabEventArgs e)
            {
                var fragment = FragmentManager.FindFragmentById(Resource.Id.fragment_content);
                if (fragment != null)
                {
                    e.FragmentTransaction.Remove(fragment);
                }

                e.FragmentTransaction.Add(Resource.Id.fragment_content, view);
            };

            tab.TabUnselected += delegate(object sender, ActionBar.TabEventArgs e)
            {
                e.FragmentTransaction.Remove(view);
            };

            ActionBar.AddTab(tab);
        }

        #endregion
    }
}