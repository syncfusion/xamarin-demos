#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.Data.Extensions;
using Syncfusion.SfDataGrid.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser.SfDataGrid
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class ResizingBehaviors: Behavior<SampleView>
    {
        private Syncfusion.SfDataGrid.XForms.SfDataGrid datagrid;
        private Grid myGrid;
        private PickerExt ResizingPicker;
        private Grid customView;
        private Grid transparent;
        protected async override void OnAttachedTo(SampleView bindable)
        {
            var assembly = Assembly.GetAssembly(this.GetType());
            await Task.Delay(200);
            customView = bindable.FindByName<Grid>("customLayout");
            transparent = bindable.FindByName<Grid>("transparent");
            datagrid = bindable.FindByName<Syncfusion.SfDataGrid.XForms.SfDataGrid>("dataGrid");
            ResizingPicker = bindable.FindByName<PickerExt>("ResizingPicker");
            if (Device.RuntimePlatform == Device.UWP && Device.Idiom == TargetIdiom.Desktop)
                datagrid.Columns.ForEach(column => column.MaximumWidth = 500);
            if(Device.RuntimePlatform != Device.UWP)
            {
                datagrid.ResizingMode = ResizingMode.OnMoved;
                ResizingPicker.SelectedIndex = 0;
            }
            else
            {
                datagrid.ResizingMode = ResizingMode.OnTouchUp;
                ResizingPicker.SelectedIndex = 1;
            }
            ResizingPicker.SelectedIndexChanged += OnSelectionChanged;
            datagrid.GridStyle = new DefaultStyle();
            myGrid = new Grid();
            myGrid.VerticalOptions = LayoutOptions.FillAndExpand;
            myGrid.HorizontalOptions = LayoutOptions.FillAndExpand;
            myGrid.RowDefinitions = new RowDefinitionCollection
            {
                new RowDefinition {Height = new GridLength(0.6,GridUnitType.Star)},
                new RowDefinition {Height = new GridLength(1,GridUnitType.Star)},
            };
            myGrid.Children.Add(new Image()
            {
                Opacity = 1.0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
#if COMMONSB
                Source = ImageSource.FromResource("SampleBrowser.Icons.DataGrid.ResizingIllustration.png",assembly),
#else
                Source = ImageSource.FromResource("SampleBrowser.SfDataGrid.Icons.DataGrid.ResizingIllustration.png", assembly),
#endif
            }, 0, 0);
            myGrid.BackgroundColor = Color.Transparent;
            myGrid.GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(Collapse) });
            customView.Children.Add(myGrid);

            base.OnAttachedTo(bindable);
        }
        private void Collapse()
        {
            myGrid.Opacity = 1.0;
            myGrid.IsEnabled = false;
            myGrid.IsVisible = false;
            transparent.IsVisible = false;
            customView.Children.Remove(myGrid);
            customView.Children.Remove(transparent);
        }
        void OnSelectionChanged(object sender, EventArgs e)
        {
            if (ResizingPicker.SelectedIndex == 0)
                datagrid.ResizingMode = ResizingMode.OnMoved;
            else
                datagrid.ResizingMode = ResizingMode.OnTouchUp;
        }
        protected override void OnDetachingFrom(SampleView bindable)
        {
            ResizingPicker.SelectedIndexChanged -= OnSelectionChanged;
            datagrid = null;
            myGrid = null;
            transparent = null;
            customView = null;
            ResizingPicker = null;
            base.OnDetachingFrom(bindable);
        }
    }
}
