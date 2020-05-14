#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Com.Syncfusion.Maps;
using Android.Graphics;
using Android.Views;
using Android.Widget;

namespace SampleBrowser
{
	public class PopulationMarker : MapMarker
	{
		public PopulationMarker (Android.Content.Context con)
		{
			context = con;
		}

		Android.Content.Context context;

		public string Name
        {
			get;
			set;
		}

		public string Population
        {
			get;
			set;
		}
    }

    public class MarkerAdapter : Com.Syncfusion.Maps.MapsAdapter
    {
        Android.Content.Context context;
        public MarkerAdapter(Android.Content.Context con)
        {
            context = con;
        }

        public override View GetMarkerView(MapMarker marker, PointF point)
        {
            LinearLayout layout = new LinearLayout(context);
            
            ImageView imageView = new ImageView(context);
            imageView.SetImageResource(Resource.Drawable.pin);
            float density = context.Resources.DisplayMetrics.Density;

            int layoutWidth = (int)(15 * density);
            int layoutHeight = (int)(40 * density);
            int imageHeight = (int)(20 * density);

            var layoutParams = new LinearLayout.LayoutParams(layoutWidth , layoutHeight);
            layout.Orientation = Orientation.Vertical;           
            layout.SetMinimumHeight(layoutHeight);
            layout.SetMinimumWidth(layoutWidth);
            layout.LayoutParameters = layoutParams;

            var imageViewParams = new LinearLayout.LayoutParams(layoutWidth, imageHeight);
            imageView.LayoutParameters = imageViewParams;
            imageView.SetMinimumHeight(imageHeight);
            imageView.SetMinimumWidth(layoutWidth);
            layout.AddView(imageView);
            return layout;
        }
    }
}