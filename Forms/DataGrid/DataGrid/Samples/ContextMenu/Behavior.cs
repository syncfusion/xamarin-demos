#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Syncfusion.SfDataGrid.XForms;
using Syncfusion.XForms.PopupLayout;
using Syncfusion.GridCommon.ScrollAxis;
using System.Reflection;

namespace SampleBrowser.SfDataGrid
{
    public class ContextMenuBehavior : Behavior<SampleView>
    {
        #region Fields
        private Syncfusion.XForms.PopupLayout.SfPopupLayout popupLayout;
        private Syncfusion.SfDataGrid.XForms.SfDataGrid dataGrid;
        private SortingViewModel viewModel;
        private Label sortAscendingLabel;
        private Image sortAscendingImage;
        private Label sortDescendingLabel;
        private Image sortDescendingImage;
        private Label groupingLabel;
        private Image groupingImage;
        private Image clearGroupingImage;
        private Image clearSortingImage;
        private Label clearGroupingLabel;
        private Label clearSortingLabel;
        private string currentColumn;
        private BoxView verticalBoxview;
        private BoxView horizontalBoxview;
        private Grid myGrid;
        private Grid transparent;
        private Grid customView;
        #endregion

        #region constructor
        public ContextMenuBehavior()
        {

        }
        #endregion

        #region Override
        protected async override void OnAttachedTo(SampleView bindable)
        {
            dataGrid = bindable.FindByName<Syncfusion.SfDataGrid.XForms.SfDataGrid>("dataGrid");
            dataGrid.GridLongPressed += DataGrid_GridLongPressed;
            viewModel = bindable.FindByName<SortingViewModel>("viewModel");
            popupLayout = bindable.FindByName<Syncfusion.XForms.PopupLayout.SfPopupLayout>("popUpLayout");
            popupLayout.PopupView.AnimationMode = AnimationMode.Fade;
            popupLayout.PopupView.AnimationDuration = 100;
            popupLayout.PopupView.ShowCloseButton = false;
            popupLayout.PopupView.ShowFooter = false;
            popupLayout.PopupView.ShowHeader = false;
            popupLayout.PopupView.HeightRequest = 195;
            if (Device.Idiom == TargetIdiom.Phone)
            {
                popupLayout.PopupView.WidthRequest = 190;
            }
            else
            {
                popupLayout.PopupView.WidthRequest = 210;
            }
            popupLayout.PopupView.ContentTemplate = new DataTemplate(() =>
            {
                return PopupViewInitialization();
            });

            var assembly = Assembly.GetAssembly(Application.Current.GetType());
            await Task.Delay(200);
            customView = bindable.FindByName<Grid>("customLayout");
            transparent = bindable.FindByName<Grid>("transparent");
            myGrid = new Grid();
            myGrid.VerticalOptions = LayoutOptions.FillAndExpand;
            myGrid.HorizontalOptions = LayoutOptions.FillAndExpand;
            myGrid.RowDefinitions = new RowDefinitionCollection
            {
            new RowDefinition {Height = new GridLength(1.1,GridUnitType.Star)},
            new RowDefinition {Height = new GridLength(1,GridUnitType.Star)},
            };
            myGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            myGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1.8, GridUnitType.Star) });
            myGrid.Children.Add(new Image()
            {
                Opacity = 1.0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
#if COMMONSB
                Source = ImageSource.FromResource("SampleBrowser.Icons.DataGrid.ContextMenuIllustration.png",assembly),
#else
                Source = ImageSource.FromResource("SampleBrowser.SfDataGrid.Icons.DataGrid.ContextMenuIllustration.png", assembly),
#endif
            }, 1, 1);
            myGrid.BackgroundColor = Color.Transparent;
            myGrid.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(Collapse) });
            customView.Children.Add(myGrid);

            base.OnAttachedTo(bindable);
        }
        #endregion

        #region methods

        private void Collapse()
        {
            myGrid.IsEnabled = false;
            myGrid.IsVisible = false;
            transparent.IsVisible = false;
            customView.Children.Remove(myGrid);
            customView.Children.Remove(transparent);
        }

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
 
            verticalBoxview = new BoxView();
            verticalBoxview.BackgroundColor = Color.Gray;
            verticalBoxview.WidthRequest = 3;
            verticalBoxview.Opacity = 0.5f;

            horizontalBoxview = new BoxView();
            horizontalBoxview.BackgroundColor = Color.Gray;
            horizontalBoxview.WidthRequest = 3;
            horizontalBoxview.Opacity = 0.5f;
            horizontalBoxview.Margin = new Thickness(5, 0, 0, 0);

            sortAscendingLabel = CreateLabel("Sort Ascending");
            sortDescendingLabel = CreateLabel("Sort Descending");
            groupingLabel = CreateLabel("Group this Column");
            clearGroupingLabel = CreateLabel("Clear Grouping");
            clearSortingLabel = CreateLabel("Clear Sorting");
            if (dataGrid.GroupColumnDescriptions.Count > 0)
            {
                clearGroupingLabel.Opacity = 1;
            }
            else
            {
                clearGroupingLabel.Opacity = 0.5f;
            }
            if (dataGrid.SortColumnDescriptions.Count > 0 || dataGrid.GroupColumnDescriptions.Count>0)
            {
                clearSortingLabel.Opacity = 1;
            }
            else
            {
                clearSortingLabel.Opacity = 0.5f;
            }

#if COMMONSB
            sortAscendingImage = CreateImage("SampleBrowser.Icons.DataGrid.Sort_Ascending_Icons.png");
            sortDescendingImage = CreateImage("SampleBrowser.Icons.DataGrid.Sort_descending_Icons.png");
            groupingImage = CreateImage("SampleBrowser.Icons.DataGrid.Grouping_Icon.png");
            clearSortingImage = CreateImage("SampleBrowser.Icons.DataGrid.Clear_sorting_Icon.png");
            clearGroupingImage = CreateImage("SampleBrowser.Icons.DataGrid.Clear_grouping_icon.png");
#else
            sortAscendingImage = CreateImage("SampleBrowser.SfDataGrid.Icons.DataGrid.Sort_Ascending_Icons.png");
            sortDescendingImage = CreateImage("SampleBrowser.SfDataGrid.Icons.DataGrid.Sort_descending_Icons.png");
            groupingImage = CreateImage("SampleBrowser.SfDataGrid.Icons.DataGrid.Grouping_Icon.png");
            clearSortingImage = CreateImage("SampleBrowser.SfDataGrid.Icons.DataGrid.Clear_sorting_Icon.png");
            clearGroupingImage = CreateImage("SampleBrowser.SfDataGrid.Icons.DataGrid.Clear_grouping_icon.png");
#endif
            if (dataGrid.GroupColumnDescriptions.Count > 0)
            {
                clearGroupingImage.Opacity = 1;
            }
            else
            {
                clearGroupingImage.Opacity = 0.5f;
            }
            if (dataGrid.SortColumnDescriptions.Count > 0 || dataGrid.GroupColumnDescriptions.Count > 0)
            {
                clearSortingImage.Opacity = 1;
            }
            else
            {
                clearSortingImage.Opacity = 0.5f;
            }
            AddGestureRecognizer();
            popupcontent.Children.Add(sortAscendingImage, 0, 0);
            popupcontent.Children.Add(sortAscendingLabel, 1, 0);
            popupcontent.Children.Add(sortDescendingImage, 0, 1);
            popupcontent.Children.Add(sortDescendingLabel, 1, 1);
            popupcontent.Children.Add(clearSortingImage, 0, 2);
            popupcontent.Children.Add(clearSortingLabel, 1, 2);
            popupcontent.Children.Add(horizontalBoxview, 0, 3);
            popupcontent.Children.Add(groupingImage, 0, 4);
            popupcontent.Children.Add(groupingLabel, 1, 4);
            popupcontent.Children.Add(clearGroupingImage, 0, 5);
            popupcontent.Children.Add(clearGroupingLabel, 1, 5);
            Grid.SetColumnSpan(horizontalBoxview, 3);
            return popupcontent;
        }

        private void DataGrid_GridLongPressed(object sender, GridLongPressedEventArgs e)
        {
            currentColumn = dataGrid.Columns[e.RowColumnIndex.ColumnIndex].MappingName;
            popupLayout.ShowAtTouchPoint();
        }

        private void Clear_Sorting()
        {
            if (dataGrid.SortColumnDescriptions.Count > 0)
            {
                if(dataGrid.GroupColumnDescriptions.Any(x=>x.ColumnName == currentColumn)&& dataGrid.SortColumnDescriptions.Any(x=>x.ColumnName == currentColumn))
                {
                    dataGrid.SortColumnDescriptions.Clear();
                }
                else
                {
                    dataGrid.SortColumnDescriptions.Clear();
                }
            }
            popupLayout.IsOpen = false;
        } 

        private void Clear_Grouping()
        {
            if (dataGrid.GroupColumnDescriptions.Count > 0) 
            {
                
                if ((dataGrid.SortColumnDescriptions.Any(x => x.ColumnName == currentColumn))&& dataGrid.GroupColumnDescriptions.Any(x=>x.ColumnName == currentColumn))
                {
                    dataGrid.GroupColumnDescriptions.Clear();
                    dataGrid.SortColumnDescriptions.Clear();
                }
                else
                {
                    dataGrid.GroupColumnDescriptions.Clear();
                }
            }
            popupLayout.IsOpen = false;
        }

        private void Sorting_Ascending()
        {
            dataGrid.SortColumnDescriptions.Clear();
            dataGrid.SortColumnDescriptions.Add(new SortColumnDescription() { ColumnName = currentColumn, SortDirection = Syncfusion.Data.ListSortDirection.Ascending });
            clearSortingImage.Opacity = 0.5f;
            clearSortingLabel.Opacity = 0.5f;
            popupLayout.IsOpen = false;
        }

        private void Sorting_Descending()
        {
            dataGrid.SortColumnDescriptions.Clear();
            dataGrid.SortColumnDescriptions.Add(new SortColumnDescription() { ColumnName = currentColumn, SortDirection = Syncfusion.Data.ListSortDirection.Descending });
            popupLayout.IsOpen = false;
        }

        private void GroupingColumn()
        {
            dataGrid.GroupColumnDescriptions.Clear();
            dataGrid.GroupColumnDescriptions.Add(new GroupColumnDescription() { ColumnName =  currentColumn });
            popupLayout.IsOpen = false;
        }

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

        private Image CreateImage(string path)
        {
            return new Image()
            {
                Source = ImageSource.FromResource(path, this.GetType().Assembly),
                WidthRequest = 20,
                HeightRequest = 20,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
        }

        private void AddGestureRecognizer()
        {
            sortAscendingImage.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(Sorting_Ascending) });
            sortAscendingLabel.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(Sorting_Ascending) });
            sortDescendingLabel.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(Sorting_Descending) });
            sortDescendingImage.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(Sorting_Descending) });
            groupingLabel.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(GroupingColumn) });
            groupingImage.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(GroupingColumn) });
            clearGroupingImage.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(Clear_Grouping) });
            clearGroupingLabel.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(Clear_Grouping) });
            clearSortingImage.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(Clear_Sorting) });
            clearSortingLabel.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(Clear_Sorting) });
        }
        #endregion

        #region override              
        protected override void OnDetachingFrom(SampleView bindable)
        {
            dataGrid.GridLongPressed -= DataGrid_GridLongPressed;
            sortAscendingLabel = null;
            sortAscendingImage = null;
            sortDescendingLabel = null;
            sortDescendingImage = null;
            groupingLabel = null;
            groupingImage = null;
            clearGroupingImage = null;
            clearSortingImage = null;
            clearGroupingLabel = null;
            clearSortingLabel = null;
            verticalBoxview = null;
            horizontalBoxview = null;
            base.OnDetachingFrom(bindable);
        }
        #endregion
    }
}
