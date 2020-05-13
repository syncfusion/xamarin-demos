#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Android.Content;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace SampleBrowser
{
	
	[Preserve(AllMembers = true)]
	[Register("SampleBrowser.SampleBrowser.horizontalScroll")]
	public class SamplesListView : HorizontalScrollView
	{

		Context listViewContext;

		public SamplesListView(Context context) : base(context)
		{
			listViewContext = context;
		}

		public SamplesListView(Context context, IAttributeSet attrs) : base(context, attrs)
		{
			listViewContext = context;
		}

		public SamplesListView(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
		{
			listViewContext = context;
		}

		public SamplesListView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
		{
			listViewContext = context;
		}

		protected SamplesListView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
		{
		}

		public void Add(List<SampleBase> samples)
		{
			int count = samples.Count;
			for (int i = 0; i < samples.Count; i++)
			{
				AddView(GetView(samples[i].Title));
			}
		}

		public TextView GetView(string sampleName)
		{
			if (string.IsNullOrEmpty(sampleName))
				return null;

			TextView view = new TextView(listViewContext)
			{
				LayoutParameters = new ViewGroup.LayoutParams(200, 200)
			};
			view.Text = sampleName;

			return view;
		}

	}
}