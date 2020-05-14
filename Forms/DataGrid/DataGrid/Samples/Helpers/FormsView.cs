#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "FormsView.cs" company="Syncfusion.com">
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
    ///  A layout which positions child elements in a single line which can be oriented vertically or horizontally.
    /// </summary>
    public class FormsView : StackLayout
    {
        #region Fields

        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private OrderInfo swipedRowData;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Syncfusion.SfDataGrid.XForms.SfDataGrid grid;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private bool isSuspend;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private bool isLoaded;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private bool visibility = true;

        #endregion

        #region Constructor 

        /// <summary>
        /// Initializes a new instance of the FormsView class.
        /// </summary>
        /// <param name="grid">Which indicates DataGrid Instance</param>
        public FormsView(Syncfusion.SfDataGrid.XForms.SfDataGrid grid)
        {
            this.isSuspend = true;
            this.grid = grid;
            if (Device.RuntimePlatform != Device.UWP)
            {
                this.Visibility = false;
            }
            else
            {
                this.IsVisible = false;
            }

            this.Columns = grid.Columns;
            this.Spacing = 10;
            this.BackgroundColor = Color.FromRgb(43, 43, 43);
            this.Orientation = StackOrientation.Vertical;
            this.Padding = new Thickness(10);

            this.FormContentView = new StackLayout() { Orientation = StackOrientation.Horizontal, Spacing = 20 };
            if (Device.RuntimePlatform == Device.UWP || Device.RuntimePlatform == Device.macOS)
            {
                this.BackgroundColor = Color.Black;
                this.Footer = new StackLayout() { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.CenterAndExpand, Spacing = 5 };
                this.Save = new Button { WidthRequest = 150, FontSize = 16, Text = "SAVE", HorizontalOptions = LayoutOptions.CenterAndExpand, BackgroundColor = Color.FromHex("#333333"), TextColor = Color.White };
                this.Cancel = new Button { WidthRequest = 150, FontSize = 16, Text = "CANCEL", HorizontalOptions = LayoutOptions.CenterAndExpand, BackgroundColor = Color.FromHex("#333333"), TextColor = Color.White };
            }
            else
            {
                this.Footer = new StackLayout() { Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.EndAndExpand };
                this.Save = new Button { FontSize = 18, Text = "SAVE", HorizontalOptions = LayoutOptions.End, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("#EC407A") };
                this.Cancel = new Button { FontSize = 18, Text = "CANCEL", HorizontalOptions = LayoutOptions.End, BackgroundColor = Color.Transparent, TextColor = Color.FromHex("#EC407A") };
            }

            this.Save.Clicked += this.Save_Clicked;
            this.Cancel.Clicked += this.Cancel_Clicked;
            this.Footer.Children.Add(new ContentView() { Content = this.Save });
            this.Footer.Children.Add(new ContentView() { Content = this.Cancel });
            this.Title = new Label { Text = "Edit Details", Margin = new Thickness(15, 15, 0, 0), FontSize = 20, HeightRequest = 30, TextColor = Color.White };
            this.HeaderView = new StackLayout() { Orientation = StackOrientation.Vertical, Spacing = 5, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };
            this.EditorView = new StackLayout() { Orientation = StackOrientation.Vertical, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand, Spacing = 5 };
            this.EditorView.BindingContextChanged += this.EditView_BindingContextChanged;
            this.isSuspend = false;
        }

        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the value of Columns
        /// </summary>
        public Columns Columns { get; set; }

        /// <summary>
        /// Gets or sets the value of HeaderView
        /// </summary>
        public StackLayout HeaderView { get; set; }

        /// <summary>
        /// Gets or sets the value of EditorView
        /// </summary>
        public StackLayout EditorView { get; set; }

        /// <summary>
        /// Gets or sets the value of Title
        /// </summary>
        public Label Title { get; set; }

        /// <summary>
        /// Gets or sets the value of Footer
        /// </summary>
        public StackLayout Footer { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Visibility has true or false value and notifies user when value has changed
        /// </summary>
        public bool Visibility
        {
            get
            {
                return this.visibility;
            }

            set
            {
                this.visibility = value;
                this.OnPropertyChanged("Visibility");
            }
        }

        /// <summary>
        /// Gets or sets the value of Save
        /// </summary>
        private Button Save { get; set; }

        /// <summary>
        /// Gets or sets the value of Cancel
        /// </summary>
        private Button Cancel { get; set; }

        /// <summary>
        /// Gets or sets the value of FormContentView
        /// </summary>
        private StackLayout FormContentView { get; set; }

        #endregion

        #region Protected Methods

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
        /// Method to decide whether to call <see cref="Xamarin.Forms.VisualElement.InvalidateMeasure()"/> when removing a child.
        /// </summary>
        /// <param name="child">A child of the <see cref="SfDataGrid"/>.</param>
        /// <returns>A boolean value do decide whether to invalidate when removing a child.</returns>
        protected override bool ShouldInvalidateOnChildRemoved(View child)
        {
            return false;
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

            if (this.isSuspend || this.isLoaded)
            {
                return;
            }

            foreach (var column in Columns)
            {
                var labelContentView = new ContentView();
                var editorContentView = new ContentView();
                var colonContentView = new ContentView();
                var label = new Label() { BackgroundColor = Color.Transparent, WidthRequest = (this.Parent as VisualElement).Width / 3, HeightRequest = 50, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand, FontSize = 15, TextColor = Color.Gray, HorizontalTextAlignment = TextAlignment.End, VerticalTextAlignment = TextAlignment.Center, Text = column.HeaderText, BindingContext = this.BindingContext };
                var editor = new GridCustomEntry() { BackgroundColor = Color.Transparent, TextColor = Color.White, WidthRequest = (this.Parent as VisualElement).Width / 3, HeightRequest = 50, HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand, BindingContext = this.BindingContext };
                editor.SetBinding(Entry.TextProperty, new Binding(column.MappingName, BindingMode.TwoWay));
                if (column.MappingName == "Name")
                {
                    label.Text = "Customer Name";
                }

                if (Device.RuntimePlatform == Device.macOS)
                {
                    editor.BackgroundColor = Color.Black;
                    label.HorizontalOptions = LayoutOptions.StartAndExpand;
                }

                labelContentView.Content = label;
                editorContentView.Content = editor;

                this.HeaderView.Children.Add(labelContentView);
                this.EditorView.Children.Add(editorContentView);
            }

            var scrollView = new ScrollView();
            scrollView.Orientation = ScrollOrientation.Vertical;
            scrollView.Content = this.FormContentView;

            this.FormContentView.Children.Add(this.HeaderView);
            this.FormContentView.Children.Add(this.EditorView);
            this.Children.Add(this.Title);
            this.Children.Add(scrollView);
            this.Children.Add(this.Footer);
            this.isLoaded = true;
        }

        #endregion

        #region Private Methods 

        /// <summary>
        /// Triggers while Cancel button was clicked
        /// </summary>
        /// <param name="sender">Cancel_Clicked event sender</param>
        /// <param name="e">Cancel_Clicked event args e</param>
        private void Cancel_Clicked(object sender, EventArgs e)
        {
            var editedrow = this.EditorView.BindingContext as OrderInfo;
            editedrow.CustomerID = this.swipedRowData.CustomerID;
            editedrow.EmployeeID = this.swipedRowData.EmployeeID;
            editedrow.OrderID = this.swipedRowData.OrderID;
            editedrow.ShipCountry = this.swipedRowData.ShipCountry;
            editedrow.FirstName = this.swipedRowData.FirstName;
            if (Device.RuntimePlatform != Device.UWP)
            {
                this.Visibility = false;
            }
            else
            {
                this.IsVisible = false;
            }

            this.grid.Opacity = 1.0;
            this.grid.IsEnabled = true;
        }

        /// <summary>
        /// Triggers while save button was clicked
        /// </summary>
        /// <param name="sender">Save_Clicked event sender</param>
        /// <param name="e">Save_Clicked event args e</param>
        private void Save_Clicked(object sender, EventArgs e)
        {
            if (Device.RuntimePlatform != Device.UWP)
            {
                this.Visibility = false;
            }
            else
            {
                this.IsVisible = false;
            }

            this.grid.Opacity = 1.0;
            this.grid.IsEnabled = true;
        }

        /// <summary>
        /// Triggers while EditView binding context was changed
        /// </summary>
        /// <param name="sender">EditView_BindingContextChanged event sender</param>
        /// <param name="e">EditView_BindingContextChanged event args e</param>
        private void EditView_BindingContextChanged(object sender, EventArgs e)
        {
            var orderInfo = this.EditorView.BindingContext as OrderInfo;
            if (orderInfo != null)
            {
                this.swipedRowData = new OrderInfo() { ShipCountry = orderInfo.ShipCountry, EmployeeID = orderInfo.EmployeeID, OrderID = orderInfo.OrderID, CustomerID = orderInfo.CustomerID, FirstName = orderInfo.FirstName };
                foreach (ContentView child in this.EditorView.Children)
                {
                    child.Content.BindingContext = this.EditorView.BindingContext;
                }
            }            
        }

        #endregion
    }
}
