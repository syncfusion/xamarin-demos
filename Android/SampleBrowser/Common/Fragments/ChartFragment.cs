#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Android.App;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.Widget;

namespace SampleBrowser
{
    public class ChartFragment : Fragment
    {
        #region fields

        private FrameLayout sampleView;

        private SampleModel selectedSample;

        private AllControlsSamplePage allControlsSamplePage;

        private List<SampleModel> chartSamples;

        #endregion

        #region ctor

        public ChartFragment(List<SampleModel> samples, AllControlsSamplePage activity)
        {
            chartSamples = samples;

            allControlsSamplePage = activity;

            if (chartSamples.Count > 0)
            {
                selectedSample = chartSamples[0];
            }
        }

        #endregion

        #region methods

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            sampleView = (FrameLayout)view.FindViewById(Resource.Id.SampleView);
            var layoutManager = new LinearLayoutManager(allControlsSamplePage, LinearLayoutManager.Horizontal, false);

            var recyclerView = view.FindViewById<RecyclerView>(Resource.Id.horizontal_RecyclerView);
            recyclerView.SetLayoutManager(layoutManager);

            var selectedIndex = chartSamples.IndexOf(selectedSample);

            var adapter = new RecyclerViewAdapter(chartSamples);
            adapter.ItemClick += Adapter_ItemClick;
            recyclerView.SetAdapter(adapter);
            RefreshSample(selectedSample);

            if (selectedIndex > 0)
            {
                new Handler().PostDelayed(() => recyclerView.FindViewHolderForLayoutPosition(selectedIndex).ItemView.PerformClick(), 100);
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.TypesLayout, null);
        }

        private void Adapter_ItemClick(object sender, ListViewSelectionChangedEventArgs e)
        {
            var index = e.SelectedIndex;
            TextView selectedItem = e.SelectedItem, prevSelectedItem = e.PreviousSelectedItem;
            if (selectedItem.Text != prevSelectedItem?.Text)
            {
                selectedSample = chartSamples[index];
                RefreshSample(selectedSample);
            }

            selectedItem?.SetTextColor(Color.ParseColor("#0277F5"));
            prevSelectedItem?.SetTextColor(Color.Black);
        }

        private void RefreshSample(SampleModel selectedSample)
        {
            SamplePage samplePage;
            bool isClassExists = Type.GetType("SampleBrowser." + selectedSample.Name) != null;

            if (isClassExists)
            {
                var handle = Activator.CreateInstance(null, "SampleBrowser." + selectedSample.Name);
                samplePage = (SamplePage)handle.Unwrap();
                sampleView.RemoveAllViews();

                if (allControlsSamplePage.CurrentSamplePage != null)
                {
                    allControlsSamplePage.CurrentSamplePage.Destroy();
                }

                allControlsSamplePage.CurrentSamplePage = samplePage;
                sampleView.AddView(samplePage.GetSampleContent(View.Context));

                allControlsSamplePage.SettingsButton.Visibility = samplePage.GetPropertyWindowLayout(allControlsSamplePage) != null
                    ? ViewStates.Visible : ViewStates.Invisible;
            }
        }

        #endregion
    }
}