#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Xamarin.Forms;

namespace SampleBrowser.SfListView
{
	public class BehaviorBase<T> : Behavior<T> where T : BindableObject
	{
		public T AssociatedObject { get; private set; }

		protected override void OnAttachedTo (T bindable)
		{
			base.OnAttachedTo (bindable);
			AssociatedObject = bindable;

			if (bindable.BindingContext != null) {
				BindingContext = bindable.BindingContext;
			}

			bindable.BindingContextChanged += OnBindingContextChanged;
		}

		protected override void OnDetachingFrom (T bindable)
		{
			base.OnDetachingFrom (bindable);
			bindable.BindingContextChanged -= OnBindingContextChanged;
			AssociatedObject = null;
		}

		void OnBindingContextChanged (object sender, EventArgs e)
		{
			OnBindingContextChanged ();
		}

		protected override void OnBindingContextChanged ()
		{
			base.OnBindingContextChanged ();
			BindingContext = AssociatedObject.BindingContext;
		}
	}
}
