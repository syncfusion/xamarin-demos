#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "ContextMenuBehavior.cs" company="Syncfusion.com">
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
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;   
    using SampleBrowser.Core;
    using Syncfusion.GridCommon.ScrollAxis;
    using Syncfusion.SfDataGrid.XForms;
    using Syncfusion.XForms.PopupLayout;
    using Xamarin.Forms;

    /// <summary>
    ///  Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    ///  Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the ContextMenu samples
    /// </summary>
    public class ContextMenuBehavior : Behavior<SampleView>
    {
        #region Fields
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Syncfusion.XForms.PopupLayout.SfPopupLayout popupLayout;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Syncfusion.SfDataGrid.XForms.SfDataGrid dataGrid;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private SortingViewModel viewModel;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Label sortAscendingLabel;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Image sortAscendingImage;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Label sortDescendingLabel;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Image sortDescendingImage;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Label groupingLabel;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Image groupingImage;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Image clearGroupingImage;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Image clearSortingImage;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Label clearGroupingLabel;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Label clearSortingLabel;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private string currentColumn;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private BoxView verticalBoxview;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private BoxView horizontalBoxview;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Grid myGrid;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Grid transparent;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Grid customView;
        #endregion

        #region constructor

        /// <summary>
        /// Initializes a new instance of the ContextMenuBehavior class.
        /// </summary>
        public ContextMenuBehavior()
        {
        }
        #endregion

        #region Override
        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="bindAble">SampleView type of bindAble</param>
        protected async override void OnAttachedTo(SampleView bindAble)
        {
            this.dataGrid = bindAble.FindByName<Syncfusion.SfDataGrid.XForms.SfDataGrid>("dataGrid");
            this.dataGrid.GridLongPressed += this.DataGrid_GridLongPressed;
            this.viewModel = bindAble.FindByName<SortingViewModel>("viewModel");
            this.popupLayout = bindAble.FindByName<Syncfusion.XForms.PopupLayout.SfPopupLayout>("popUpLayout");
            this.popupLayout.PopupView.AnimationMode = AnimationMode.Fade;
            this.popupLayout.PopupView.AnimationDuration = 100;
            this.popupLayout.PopupView.ShowCloseButton = false;
            this.popupLayout.PopupView.ShowFooter = false;
            this.popupLayout.PopupView.ShowHeader = false;
            this.popupLayout.PopupView.HeightRequest = 195;
            if (Device.Idiom == TargetIdiom.Phone)
            {
                this.popupLayout.PopupView.WidthRequest = 190;
            }
            else
            {
                this.popupLayout.PopupView.WidthRequest = 210;
            }

            this.popupLayout.PopupView.ContentTemplate = new DataTemplate(() =>
            {
                return PopupViewInitialization();
            });

            var assembly = Assembly.GetAssembly(Application.Current.GetType());
            await Task.Delay(200);
            this.customView = bindAble.FindByName<Grid>("customLayout");
            this.transparent = bindAble.FindByName<Grid>("transparent");
            this.myGrid = new Grid();
            this.myGrid.VerticalOptions = LayoutOptions.FillAndExpand;
            this.myGrid.HorizontalOptions = LayoutOptions.FillAndExpand;
            this.myGrid.RowDefinitions = new RowDefinitionCollection
            {
            new RowDefinition { Height = new GridLength(1.1, GridUnitType.Star) },
            new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
            };
            this.myGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            this.myGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1.8, GridUnitType.Star) });
            this.myGrid.Children.Add(
                new Image()
            {
                Opacity = 1.0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Source = "ContextMenuIllustration.png"
                }, 
            1, 
            1);
            this.myGrid.BackgroundColor = Color.Transparent;
            this.myGrid.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(this.Collapse) });
            this.customView.Children.Add(this.myGrid);

            base.OnAttachedTo(bindAble);
        }
        #endregion

        #region override         

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="bindAble">SampleView type of bindAble parameter</param>
        protected override void OnDetachingFrom(SampleView bindAble)
        {
            this.dataGrid.GridLongPressed -= this.DataGrid_GridLongPressed;
            this.sortAscendingLabel = null;
            this.sortAscendingImage = null;
            this.sortDescendingLabel = null;
            this.sortDescendingImage = null;
            this.groupingLabel = null;
            this.groupingImage = null;
            this.clearGroupingImage = null;
            this.clearSortingImage = null;
            this.clearGroupingLabel = null;
            this.clearSortingLabel = null;
            this.verticalBoxview = null;
            this.horizontalBoxview = null;
            base.OnDetachingFrom(bindAble);
        }

        #endregion

        #region methods

        /// <summary>
        /// Method for removing the child element of CustomView 
        /// </summary>
        private void Collapse()
        {
            this.myGrid.IsEnabled = false;
            this.myGrid.IsVisible = false;
            this.transparent.IsVisible = false;
            this.customView.Children.Remove(this.myGrid);
            this.customView.Children.Remove(this.transparent);
        }

        /// <summary>
        /// Method that initializes a PopUpView 
        /// </summary>
        /// <returns>returns the popupContent which was added</returns>
        private Grid PopupViewInitialization()
        {
            Grid popupcontent = new Grid();
            popupcontent.Padding = new Thickness(4, 2, 5, 2);
            popupcontent.BackgroundColor = Color.White;
            popupcontent.HorizontalOptions = LayoutOptions.FillAndExpand;
            popupcontent.VerticalOptions = LayoutOptions.FillAndExpand;
            popupcontent.RowDefinitions.Add(new RowDefinition { Height = 30 });
            popupcontent.RowDefinitions.Add(new RowDefinition { Height = 30 });
            popupcontent.RowDefinitions.Add(new RowDefinition { Height = 30 });
            popupcontent.RowDefinitions.Add(new RowDefinition { Height = 1 });
            popupcontent.RowDefinitions.Add(new RowDefinition { Height = 30 });
            popupcontent.RowDefinitions.Add(new RowDefinition { Height = 30 });
            popupcontent.ColumnDefinitions.Add(new ColumnDefinition { Width = 20 });
            popupcontent.ColumnDefinitions.Add(new ColumnDefinition { Width = 140 });

            this.verticalBoxview = new BoxView();
            this.verticalBoxview.BackgroundColor = Color.Gray;
            this.verticalBoxview.WidthRequest = 3;
            this.verticalBoxview.Opacity = 0.5f;

            this.horizontalBoxview = new BoxView();
            this.horizontalBoxview.BackgroundColor = Color.Gray;
            this.horizontalBoxview.WidthRequest = 3;
            this.horizontalBoxview.Opacity = 0.5f;
            this.horizontalBoxview.Margin = new Thickness(5, 0, 0, 0);

            this.sortAscendingLabel = this.CreateLabel("Sort Ascending");
            this.sortDescendingLabel = this.CreateLabel("Sort Descending");
            this.groupingLabel = this.CreateLabel("Group this Column");
            this.clearGroupingLabel = this.CreateLabel("Clear Grouping");
            this.clearSortingLabel = this.CreateLabel("Clear Sorting");
            if (this.dataGrid.GroupColumnDescriptions.Count > 0)
            {
                this.clearGroupingLabel.Opacity = 1;
            }
            else
            {
                this.clearGroupingLabel.Opacity = 0.5f;
            }

            if (this.dataGrid.SortColumnDescriptions.Count > 0 || this.dataGrid.GroupColumnDescriptions.Count > 0)
            {
                this.clearSortingLabel.Opacity = 1;
            }
            else
            {
                this.clearSortingLabel.Opacity = 0.5f;
            }

            this.sortAscendingImage = this.CreateImage("\ue71e");
            this.sortDescendingImage = this.CreateImage("\ue729");
            this.groupingImage = this.CreateImage("\ue75c");
            this.clearSortingImage = this.CreateImage("\ue75d");
            this.clearGroupingImage = this.CreateImage("\ue70d");
            if (this.dataGrid.GroupColumnDescriptions.Count > 0)
            {
                this.clearGroupingImage.Opacity = 1;
            }
            else
            {
                this.clearGroupingImage.Opacity = 0.5f;
            }

            if (this.dataGrid.SortColumnDescriptions.Count > 0 || this.dataGrid.GroupColumnDescriptions.Count > 0)
            {
                this.clearSortingImage.Opacity = 1;
            }
            else
            {
                this.clearSortingImage.Opacity = 0.5f;
            }

            this.AddGestureRecognizer();
            popupcontent.Children.Add(this.sortAscendingImage, 0, 0);
            popupcontent.Children.Add(this.sortAscendingLabel, 1, 0);
            popupcontent.Children.Add(this.sortDescendingImage, 0, 1);
            popupcontent.Children.Add(this.sortDescendingLabel, 1, 1);
            popupcontent.Children.Add(this.clearSortingImage, 0, 2);
            popupcontent.Children.Add(this.clearSortingLabel, 1, 2);
            popupcontent.Children.Add(this.horizontalBoxview, 0, 3);
            popupcontent.Children.Add(this.groupingImage, 0, 4);
            popupcontent.Children.Add(this.groupingLabel, 1, 4);
            popupcontent.Children.Add(this.clearGroupingImage, 0, 5);
            popupcontent.Children.Add(this.clearGroupingLabel, 1, 5);
            Grid.SetColumnSpan(this.horizontalBoxview, 3);
            return popupcontent;
        }

        /// <summary>
        /// Fired when grid is long pressed 
        /// </summary>
        /// <param name="sender">DataGrid_GridLongPressed event sender</param>
        /// <param name="e">DataGrid_GridLongPressed args e</param>
        private void DataGrid_GridLongPressed(object sender, GridLongPressedEventArgs e)
        {
            this.currentColumn = this.dataGrid.Columns[e.RowColumnIndex.ColumnIndex].MappingName;
            this.popupLayout.ShowAtTouchPoint();
        }

        /// <summary>
        /// Clear the sort column descriptions in DataGrid.
        /// </summary>
        private void Clear_Sorting()
        {
            if (this.dataGrid.SortColumnDescriptions.Count > 0)
            {
                if (this.dataGrid.GroupColumnDescriptions.Any(x => x.ColumnName == this.currentColumn) && this.dataGrid.SortColumnDescriptions.Any(x => x.ColumnName == this.currentColumn))
                {
                    this.dataGrid.SortColumnDescriptions.Clear();
                }
                else
                {
                    this.dataGrid.SortColumnDescriptions.Clear();
                }
            }

            this.popupLayout.IsOpen = false;
        }

        /// <summary>
        /// Clear the group column descriptions in DataGrid
        /// </summary>
        private void Clear_Grouping()
        {
            if (this.dataGrid.GroupColumnDescriptions.Count > 0)
            {
                if (this.dataGrid.SortColumnDescriptions.Any(x => x.ColumnName == this.currentColumn) && this.dataGrid.GroupColumnDescriptions.Any(x => x.ColumnName == this.currentColumn))
                {
                    this.dataGrid.GroupColumnDescriptions.Clear();
                    this.dataGrid.SortColumnDescriptions.Clear();
                }
                else
                {
                    this.dataGrid.GroupColumnDescriptions.Clear();
                }
            }

            this.popupLayout.IsOpen = false;
        }

        /// <summary>
        /// Sorts the data in ascending order
        /// </summary>
        private void Sorting_Ascending()
        {
            this.dataGrid.SortColumnDescriptions.Clear();
            this.dataGrid.SortColumnDescriptions.Add(new SortColumnDescription() { ColumnName = this.currentColumn, SortDirection = Syncfusion.Data.ListSortDirection.Ascending });
            this.clearSortingImage.Opacity = 0.5f;
            this.clearSortingLabel.Opacity = 0.5f;
            this.popupLayout.IsOpen = false;
        }

        /// <summary>
        /// Sorts the data in descending order
        /// </summary>
        private void Sorting_Descending()
        {
            this.dataGrid.SortColumnDescriptions.Clear();
            this.dataGrid.SortColumnDescriptions.Add(new SortColumnDescription() { ColumnName = this.currentColumn, SortDirection = Syncfusion.Data.ListSortDirection.Descending });
            this.popupLayout.IsOpen = false;
        }

        /// <summary>
        /// Adds a group column description to the DataGrid
        /// </summary>
        private void GroupingColumn()
        {
            this.dataGrid.GroupColumnDescriptions.Clear();
            this.dataGrid.GroupColumnDescriptions.Add(new GroupColumnDescription() { ColumnName = this.currentColumn });
            this.popupLayout.IsOpen = false;
        }

        /// <summary>
        /// Used to create Label with desired properties
        /// </summary>
        /// <param name="text">string type text</param>
        /// <returns>returns a created label</returns>
        private Label CreateLabel(string text)
        {
            return new Label()
            {
                Text = text,
                TextColor = Color.FromHex("#000000"),
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                Opacity = 87,
            };
        }

        /// <summary>
        /// Used to create Image with desired properties
        /// </summary>
        /// <param name="path">string type path</param>
        /// <returns>returns a created Image</returns>
        private Image CreateImage(string path)
        {
            return new Image()
            {
                Source = new FontImageSource
                {
                    Glyph = path,
                    FontFamily = (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.macOS) ? "Sync FontIcons" : Device.RuntimePlatform == Device.Android ? "Sync FontIcons.ttf#" : "Sync FontIcons.ttf#Sync FontIcons",
                    Color = Color.FromRgb(88, 88, 89),
                },
                WidthRequest = 20,
                HeightRequest = 20,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
        }

        /// <summary>
        /// Method for adding TapGesture
        /// </summary>
        private void AddGestureRecognizer()
        {
            this.sortAscendingImage.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(this.Sorting_Ascending) });
            this.sortAscendingLabel.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(this.Sorting_Ascending) });
            this.sortDescendingLabel.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(this.Sorting_Descending) });
            this.sortDescendingImage.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(this.Sorting_Descending) });
            this.groupingLabel.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(this.GroupingColumn) });
            this.groupingImage.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(this.GroupingColumn) });
            this.clearGroupingImage.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(this.Clear_Grouping) });
            this.clearGroupingLabel.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(this.Clear_Grouping) });
            this.clearSortingImage.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(this.Clear_Sorting) });
            this.clearSortingLabel.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(this.Clear_Sorting) });
        }
        #endregion
    }
}
