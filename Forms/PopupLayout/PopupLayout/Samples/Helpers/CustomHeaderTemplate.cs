#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser.SfPopupLayout
{
    public class CustomHeaderTemplate : Layout<View>
    {
        public CustomHeaderTemplate()
        {

        }

        public int NumberOfLabel
        {
            get;
            set;
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
        }

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            return base.OnMeasure(widthConstraint, heightConstraint);
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            double w = 0;
            for (int i = 0; i < NumberOfLabel; i++)
            {
                this.Children.Add(CreateDateLayout(i));
                this.Children[i].Layout(new Rectangle(w, 0, width / NumberOfLabel, height));
                w = w + (width / NumberOfLabel);
            }
        }

        protected override bool ShouldInvalidateOnChildAdded(View child)
        {
            return false;
        }

        private View CreateDateLayout(int i)
        {
            StackLayout layout = new StackLayout();
            layout.Padding = new Thickness(0, 0, 0, 10);
            layout.Orientation = StackOrientation.Vertical;

            layout.Children.Add(CreateDayLabel(i));
            layout.Children.Add(CreateDateLabel(i));

            SetBackgroundColorForLabels(i, layout);
            AddTapGeture(layout);
            return layout;
        }

        private void AddTapGeture(StackLayout layout)
        {
            var tapGesture = new TapGestureRecognizer();
            layout.GestureRecognizers.Add(tapGesture);
            tapGesture.Tapped += DateLayout_Tapped; 
        }

        private void DateLayout_Tapped(object sender, EventArgs e)
        {
            var stackLayout = sender as StackLayout;

            // Update background color for other date cells
            foreach (var children in (stackLayout.Parent as CustomHeaderTemplate).Children)
            {
                children.BackgroundColor = Color.White;
                ((children as StackLayout).Children[0] as Label).TextColor = Color.Gray;
                ((children as StackLayout).Children[1] as Label).TextColor = Color.Black;
            }

            // Update background color for selected date cell
            stackLayout.BackgroundColor = Color.FromHex("#007CEE");
            (stackLayout.Children[0] as Label).TextColor = Color.White;
            (stackLayout.Children[1] as Label).TextColor = Color.White;
            stackLayout = null;
        }

        private View CreateDateLabel(int i)
        {
            Label dateLabel = new Label();
            dateLabel.Opacity = 87;
            dateLabel.FontSize = 14;
            dateLabel.HorizontalOptions = LayoutOptions.CenterAndExpand;
            dateLabel.VerticalOptions = LayoutOptions.CenterAndExpand;
            dateLabel.VerticalTextAlignment = TextAlignment.End;
            dateLabel.HeightRequest = 31;
            dateLabel.FontAttributes = FontAttributes.Bold;
            dateLabel.Text = DateTime.Now.AddDays(i).Day.ToString();
            return dateLabel;
        }

        private Label CreateDayLabel(int i)
        {
            Label dayLabel = new Label();
            dayLabel.TextColor = Color.White;
            dayLabel.Opacity = 54;
            dayLabel.FontSize = 12;
            dayLabel.HorizontalOptions = LayoutOptions.CenterAndExpand;
            dayLabel.VerticalOptions = LayoutOptions.EndAndExpand;
            dayLabel.VerticalTextAlignment = TextAlignment.End;
            dayLabel.HeightRequest = 31;
            dayLabel.Text = DateTime.Now.AddDays(i).DayOfWeek.ToString().Substring(0, 3).ToUpper();
            return dayLabel;
        }

        private void SetBackgroundColorForLabels(int i,StackLayout layout)
        {
            if (i == 0)
            {
                layout.BackgroundColor = Color.FromRgb(0, 124, 238);
                layout.BackgroundColor = Color.FromRgb(0, 124, 238);
                (layout.Children[0] as Label).TextColor = Color.White;
                (layout.Children[1] as Label).TextColor = Color.White;
            }
            else
            {
                layout.BackgroundColor = Color.White;
                layout.BackgroundColor = Color.White;
                (layout.Children[0] as Label).TextColor = Color.Gray;
                (layout.Children[1] as Label).TextColor = Color.Black;
            }
        }
    }
}
