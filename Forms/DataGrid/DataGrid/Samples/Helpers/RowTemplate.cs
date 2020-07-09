#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "RowTemplate.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfDataGrid
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Syncfusion.SfDataGrid.XForms;

    using Xamarin.Forms;

    /// <summary>
    ///  A layout that arranges views in rows and columns
    /// </summary>
    public class RowTemplate : Grid
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the RowTemplate class.
        /// </summary>
        public RowTemplate()
        {
            this.BackgroundColor = Color.White;
            this.Children.Add(this.CreateLabel("OrderID"));
            this.Children.Add(new BoxView() { Color = Color.Gray, WidthRequest = 1 });
            this.Children.Add(this.CreateLabel("EmployeeID"));
            this.Children.Add(new BoxView() { Color = Color.Gray, WidthRequest = 1 });
            this.Children.Add(this.CreateLabel("CustomerID"));
            this.Children.Add(new BoxView() { Color = Color.Gray, WidthRequest = 1 });
            this.Children.Add(this.CreateLabel("FirstName"));
            this.Children.Add(new BoxView() { Color = Color.Gray, WidthRequest = 1 });
            this.Children.Add(this.CreateLabel("LastName"));
        }

        #endregion

        #region Override Method

        /// <summary>
        ///  Updates the bounds of the element during the layout cycle.
        /// </summary>
        /// <param name="x">A value representing the x coordinate of the child region bounding box.</param>
        /// <param name="y">A value representing the y coordinate of the child region bounding box.</param>
        /// <param name="width">A value representing the width of the child region bounding box.</param>
        /// <param name="height">A value representing the height of the child region bounding box.</param>
        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            foreach (var child in this.Children)
            {
                if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
                {
                    if (child is ContentView)
                    {
                        child.Layout(new Rectangle(x, y, (width / ((Children.Count + 1) / 2)) - 0.5, height));
                    }
                    else
                    {
                        child.Layout(new Rectangle(x, y, 0.5, height));
                    }
                }
                else
                {
                    if (child is ContentView)
                    {
                        child.Layout(new Rectangle(x, y, (width / ((Children.Count + 1) / 2)) - 1, height));
                    }
                    else
                    {
                        child.Layout(new Rectangle(x, y, 1, height));
                    }
                }

                x += child.Width;
            }
        }

        #endregion

        #region Private Method

        /// <summary>
        /// Used to create Label with desired properties
        /// </summary>
        /// <param name="property">string type text</param>
        /// <returns>returns a created label</returns>
        private ContentView CreateLabel(string property)
        {
            var label = new Label();
            label.TextColor = Color.Black;
            label.LineBreakMode = LineBreakMode.NoWrap;
            label.FontSize = 12;
            label.HorizontalTextAlignment = TextAlignment.Center;
            label.VerticalTextAlignment = TextAlignment.Center;
            label.VerticalOptions = LayoutOptions.Center;
            label.SetBinding(Label.TextProperty, property);
            return new ContentView() { Content = label };
        }

        #endregion
    }
}
