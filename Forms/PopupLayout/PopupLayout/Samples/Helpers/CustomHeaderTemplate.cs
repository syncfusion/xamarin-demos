#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "CustomHeaderTemplate.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfPopupLayout
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    using Syncfusion.SfDataGrid.XForms;

    using Xamarin.Forms;

    /// <summary>
    /// A class contains custom header template.
    /// </summary>
    public class CustomHeaderTemplate : Layout<View>, IDisposable
    {
        /// <summary>
        /// Gets or sets the NumberOfLabel
        /// </summary>
        public int NumberOfLabel { get; set; }

        /// <summary>
        /// Disposes all the objects in the view.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }
       
        /// <summary>
        /// Positions and sizes the children of a Layout.
        /// </summary>
        /// <param name="x">A value representing the x coordinate of the child region bounding box.</param>
        /// <param name="y">A value representing the y coordinate of the child region bounding box.</param>
        /// <param name="width">A value representing the width of the child region bounding box.</param>
        /// <param name="height">A value representing the height of the child region bounding box.</param>
        protected override void LayoutChildren(double x, double y, double width, double height)
        {
        }

        /// <summary>
        /// This method is called when the size of the element is set during a layout cycle. This method is called directly 
        /// before the <see cref="Xamarin.Forms.VisualElement.SizeChanged"/> event is emitted.
        /// </summary>
        /// <param name="width">The new width of the element.</param>
        /// <param name="height">The new height of the element.</param>
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            double w = 0;
            for (var i = 0; i < this.NumberOfLabel; i++)
            {
                this.Children.Add(this.CreateDateLayout(i));
                this.Children[i].Layout(new Rectangle(w, 0, width / this.NumberOfLabel, height));
                w = w + (width / this.NumberOfLabel);
            }
        }

        /// <summary>
        /// Method to decide whether to call <see cref="Xamarin.Forms.VisualElement.InvalidateMeasure()"/> when adding a child.
        /// </summary>
        /// <param name="child">A child of the <see cref="SfDataGrid"/>.</param>
        /// <returns>A boolean value do decide whether to invalidate when adding a child.</returns>
        protected override bool ShouldInvalidateOnChildAdded(View child)
        {
            return false;
        }

        /// <summary>
        /// Disposes all the objects in the view
        /// </summary>
        /// <param name="isDisposing">Disposes the object based on the parameter.</param>
        protected void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                foreach (var dateLayout in this.Children)
                {
                    if (dateLayout.GestureRecognizers.Count > 0)
                    {
                        var tapGesture = dateLayout.GestureRecognizers[0] as TapGestureRecognizer;
                        if (tapGesture != null)
                        {
                            tapGesture.Tapped -= this.DateLayout_Tapped;
                            dateLayout.GestureRecognizers.Remove(tapGesture);
                            tapGesture = null;
                        }
                    }
                }

                this.Children.Clear();
            }
        }

        /// <summary>
        /// Used to Creates Date Layout
        /// </summary>
        /// <param name="i">integer type parameter named as i</param>
        /// <returns>returns the StackLayout value</returns>
        private View CreateDateLayout(int i)
        {
            StackLayout layout = new StackLayout();
            layout.Padding = new Thickness(0, 0, 0, 10);
            layout.Orientation = StackOrientation.Vertical;

            layout.Children.Add(this.CreateDayLabel(i));
            layout.Children.Add(this.CreateDateLabel(i));

            this.SetBackgroundColorForLabels(i, layout);
            this.AddTapGesture(layout);
            return layout;
        }

        /// <summary>
        /// Adding TapGesture to StackLayout
        /// </summary>
        /// <param name="layout">StackLayout type parameter named as layout</param>
        private void AddTapGesture(StackLayout layout)
        {
            var tapGesture = new TapGestureRecognizer();
            layout.GestureRecognizers.Add(tapGesture);
            tapGesture.Tapped += this.DateLayout_Tapped;
        }

        /// <summary>
        /// Triggers when DateLayout is tapped.
        /// </summary>
        /// <param name="sender">DateLayout_Tapped event sender</param>
        /// <param name="e">DateLayout_Tapped args e</param>
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

        /// <summary>
        /// Used to Create Date Label.
        /// </summary>
        /// <param name="i">integer type parameter named as i</param>
        /// <returns>returns newly created label</returns>
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

        /// <summary>
        /// Used to Create day Label.
        /// </summary>
        /// <param name="i">integer type parameter to add days</param>
        /// <returns>returns newly created label</returns>
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

        /// <summary>
        /// Used to Set BackgroundColor For Labels
        /// </summary>
        /// <param name="i">integer typed parameter named as i</param>
        /// <param name="layout">returns the layout</param>
        private void SetBackgroundColorForLabels(int i, StackLayout layout)
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