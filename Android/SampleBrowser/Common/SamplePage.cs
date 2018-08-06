#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Android.Views;
using Android.Content;

namespace SampleBrowser
{
	public class SamplePage
	{
		public SamplePage()
		{

		}

		internal View PropertyView;

		public View SampleView;

		public virtual View GetSampleContent(Context context)
		{
			return new View(context);
		}

		public virtual void OnApplyChanges(View view)
		{
			OnApplyChanges();
		}

		public virtual void OnApplyChanges()
		{

		}

		public virtual View GetPropertyWindowLayout(Context context)
		{
			return null;
		}

		public virtual void Destroy()
		{

		}

	}
}