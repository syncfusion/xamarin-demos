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
using Android.Graphics;
using Syncfusion.SfPullToRefresh;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SampleBrowser
{
    public class ListViewInPullToRefresh : SamplePage
    {
        SfPullToRefresh pullToRefresh;
        ListView listView;
        CustomBaseAdapter adapter;
        InboxRepositiory repository;

        public ListViewInPullToRefresh()
        {

        }

        public override View GetSampleContent(Context context)
        {
            pullToRefresh = new SfPullToRefresh(context);
            pullToRefresh.TransitionType = TransitionType.Push;
            pullToRefresh.Refreshing += Pull_Refreshing;
            listView = new ListView(context);
            repository = new InboxRepositiory();
            adapter = new CustomBaseAdapter((Activity)context, repository.InboxItems);
            listView.Adapter = adapter;
            pullToRefresh.PullableContent = listView;
            return pullToRefresh;
        }

        private async void Pull_Refreshing(object sender, RefreshingEventArgs e)
        {
            await Task.Delay(3000);
            repository.RefreshItemSource();
            adapter.NotifyDataSetChanged();
            e.Refreshed = true;
        }

        public override View GetPropertyWindowLayout(Context context)
        {
            FrameLayout propertyLayout = new FrameLayout(context);
            LinearLayout container = new LinearLayout(context);
            container.Orientation = Orientation.Vertical;
            container.SetBackgroundColor(Color.White);
            container.SetPadding(15, 15, 15, 20);
            TextView transitiontype = new TextView(context);
            transitiontype.Text = "Tranisition Type";
            transitiontype.TextSize = 20;
            transitiontype.SetPadding(0, 0, 0, 10);
            transitiontype.SetTextColor(Color.Black);
            Spinner transitionTypeSpinner = new Spinner(context, SpinnerMode.Dialog);
            transitionTypeSpinner.SetMinimumHeight(60);
            transitionTypeSpinner.SetBackgroundColor(Color.Gray);
            transitionTypeSpinner.DropDownWidth = 600;
            transitionTypeSpinner.SetPadding(10, 10, 0, 10);
            transitionTypeSpinner.SetGravity(GravityFlags.CenterHorizontal);
            container.AddView(transitiontype);
            container.AddView(transitionTypeSpinner);
            List<String> list = new List<String>();
            list.Add("SlideOnTop");
            list.Add("Push");
            ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>(context, Android.Resource.Layout.SimpleSpinnerItem, list);
            dataAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            transitionTypeSpinner.Adapter = dataAdapter;
            transitionTypeSpinner.ItemSelected += transitionTypeSpinner_ItemSelected;
            if (pullToRefresh.TransitionType == TransitionType.SlideOnTop)
                transitionTypeSpinner.SetSelection(0);
            else
                transitionTypeSpinner.SetSelection(1);
            propertyLayout.AddView(container);
            return propertyLayout;

        }

        void transitionTypeSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {

            Spinner spinner = (Spinner)sender;
            String selectedItem = spinner.GetItemAtPosition(e.Position).ToString();

            if (pullToRefresh != null)
            {
                if (selectedItem.Equals("SlideOnTop"))
                {
                    pullToRefresh.TransitionType = TransitionType.SlideOnTop;
                    pullToRefresh.RefreshContentThreshold = 0;
                }
                else if (selectedItem.Equals("Push"))
                {
                    pullToRefresh.TransitionType = TransitionType.Push;
                    pullToRefresh.RefreshContentThreshold = 25;
                }
            }
        }

        public override void Destroy()
        {
            pullToRefresh.Refreshing -= Pull_Refreshing;
            pullToRefresh.Dispose();
            pullToRefresh = null;
        }

    }
}