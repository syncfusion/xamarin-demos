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
using Com.Syncfusion.Charts;
using Android.Graphics;

namespace SampleBrowser
{
    public class CustomTooltipBehavior : ChartTooltipBehavior
    {
        Context context;

        public CustomTooltipBehavior(Context con)
        {
            context = con;
        }

        protected override View GetView(TooltipView p0)
        {
            ImageView imageView = new ImageView(context);
            imageView.SetImageResource(Resource.Drawable.grain);
            LinearLayout rootLayout = new LinearLayout(context);
            LinearLayout.LayoutParams layoutParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent,
                    LinearLayout.LayoutParams.MatchParent);
            rootLayout.Orientation = Orientation.Horizontal;
            rootLayout.LayoutParameters = layoutParams;
            rootLayout.SetPadding(5, 5, 5, 5);
            rootLayout.AddView(imageView);

            TextView xLabel = new TextView(context);
            xLabel.Text = (p0.ChartDataPoint as DataPoint).XValue.ToString();
            xLabel.TextSize = 12;
            xLabel.SetTextColor(Color.ParseColor("#FFA500"));

            TextView yLabel = new TextView(context);
            yLabel.Text = (p0.ChartDataPoint as DataPoint).YValue.ToString() +"M";
            yLabel.TextSize = 15;
            yLabel.SetTextColor(Color.White);

            LinearLayout layout = new LinearLayout(context);
            LinearLayout.LayoutParams linearlayoutParams = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent,
                    LinearLayout.LayoutParams.MatchParent);
            layout.Orientation = Orientation.Vertical;
            linearlayoutParams.SetMargins(10, 10, 10, 10);
            layout.LayoutParameters = linearlayoutParams;


            layout.AddView(xLabel);
            layout.AddView(yLabel);
            rootLayout.AddView(layout);
            p0.AddView(rootLayout);

            return p0;
        }

    }
}