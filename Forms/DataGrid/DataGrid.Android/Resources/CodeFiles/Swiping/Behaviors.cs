#region Copyright Syncfusion Inc. 2001-2017.
// Copyright Syncfusion Inc. 2001-2017. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.SfDataGrid.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SampleBrowser.SfDataGrid
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class SwipingBehaviors : Behavior<SampleView>
    {
        private Syncfusion.SfDataGrid.XForms.SfDataGrid dataGrid;
        private SwipingViewModel viewModel;
        private Image leftImage;
        private Image rightImage;
        private int swipedRowIndex;
        private FormsView formView;
        private CustomLayout customLayout;
        protected override void OnAttachedTo(SampleView bindable)
        {
            customLayout = bindable.FindByName<CustomLayout>("custumLayout");
            dataGrid = bindable.FindByName<Syncfusion.SfDataGrid.XForms.SfDataGrid>("dataGrid");
            rightImage = (Image)bindable.Resources["rightImage"];
            leftImage = (Image)bindable.Resources["leftImage"];
            viewModel = new SwipingViewModel();
            bindable.BindingContext = viewModel;
            dataGrid.ItemsSource = viewModel.OrdersInfo;
            bindable.PropertyChanged += Swiping_PropertyChanged;
            formView = new FormsView(dataGrid);
            customLayout.Children.Add(formView);
            dataGrid.GridTapped += dataGrid_GridTapped;
            rightImage.BindingContextChanged += rightImage_BindingContextChanged;
            leftImage.BindingContextChanged += leftImage_BindingContextChanged;
            dataGrid.SwipeEnded += dataGrid_SwipeEnded;
            base.OnAttachedTo(bindable);
        }
        #region Private Methods

        private void Swiping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Width" && this.formView != null && this.formView.Width != -1)
            {
                if (formView.Visibility == true && formView.IsVisible == true)
                {
                    if (Device.RuntimePlatform == Device.macOS)
                        LayoutMacFormsView(true);
                    else
                        this.LayoutFormsView(true);
                }
                else
                {
                    if (Device.RuntimePlatform == Device.macOS)
                        LayoutMacFormsView(false);
                    else
                        this.LayoutFormsView(false);
                    dataGrid.Opacity = 1.0;
                }
            }
        }

        private void dataGrid_GridTapped(object sender, GridTappedEventArgs e)
        {
            if (Device.RuntimePlatform != Device.WinPhone && Device.RuntimePlatform != Device.UWP)
                formView.Visibility = false;
            else
                formView.IsVisible = false;
            dataGrid.Opacity = 1.0;
            dataGrid.IsEnabled = true;
        }

        private void leftImage_BindingContextChanged(object sender, EventArgs e)
        {
            if (leftImage.Source == null)
            {
                leftImage = sender as Image;
                leftImage.IsVisible = true;
                (leftImage.Parent.Parent as View).GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(Edit) });
#if COMMONSB
                if (Device.RuntimePlatform == Device.Android)
                    leftImage.Source = ImageSource.FromResource("SampleBrowser.Icons.DataGrid.Edit.png", this.GetType().Assembly);
                else if (Device.RuntimePlatform == Device.iOS)
                    leftImage.Source = ImageSource.FromResource("SampleBrowser.Icons.DataGrid.SwipingIcon_iOS_Edit.png", this.GetType().Assembly);
                else
                    leftImage.Source = ImageSource.FromResource("SampleBrowser.Icons.DataGrid.SwipingIcon_UWP_Edit.png", this.GetType().Assembly);
#else
                if (Device.RuntimePlatform == Device.Android)
                    leftImage.Source = ImageSource.FromResource("SampleBrowser.SfDataGrid.Icons.DataGrid.Edit.png", this.GetType().Assembly);
                else if (Device.RuntimePlatform == Device.iOS)
                    leftImage.Source = ImageSource.FromResource("SampleBrowser.SfDataGrid.Icons.DataGrid.SwipingIcon_iOS_Edit.png", this.GetType().Assembly);
                else
                    leftImage.Source = ImageSource.FromResource("SampleBrowser.SfDataGrid.Icons.DataGrid.SwipingIcon_UWP_Edit.png", this.GetType().Assembly);
#endif
            }
        }

        private void Edit()
        {
            this.dataGrid.Opacity = 0.25;
            this.dataGrid.IsEnabled = false;

            if (Device.RuntimePlatform != Device.macOS)
            {
                LayoutFormsView(true);
            }
            else
            {
                LayoutMacFormsView(true);
            }
        }

        private void LayoutMacFormsView(bool visisble)
        {
            if (Device.RuntimePlatform != Device.WinPhone && Device.RuntimePlatform != Device.UWP)
            {
                formView.LayoutTo(new Rectangle(this.dataGrid.Width * (Device.Idiom == TargetIdiom.Phone ? 0.025 : 0.1), (dataGrid.Height / 2) - (350 / 2), this.dataGrid.Width - (this.dataGrid.Width * (Device.Idiom == TargetIdiom.Phone ? 0.05 : 0.2)), 350), 350, null);
                formView.Visibility = visisble;
                formView.IsVisible = visisble;
            }
            else
                formView.IsVisible = visisble;
        }

        private async void LayoutFormsView(bool visible)
        {
            await Task.Delay(10);
            string orientation = DependencyService.Get<IDataGridDependencyService>().GetOrientation();
            if (orientation != "Portrait" && orientation != "PortraitUpsideDown")
            {
               await formView.LayoutTo(new Rectangle(this.dataGrid.Width / 8, (this.dataGrid.Height / 2) - (250 / 2), this.dataGrid.Width - (this.dataGrid.Width / 4), 250), 0, null);
            }
            else
            {
                if (Device.RuntimePlatform != Device.UWP)
                  await formView.LayoutTo(new Rectangle(this.dataGrid.Width * (Device.Idiom == TargetIdiom.Phone ? 0.025 : 0.1), (dataGrid.Height / 2) - (350 / 2), this.dataGrid.Width - (this.dataGrid.Width * (Device.Idiom == TargetIdiom.Phone ? 0.05 : 0.2)), 350), 0, null);
                else
                   await formView.LayoutTo(new Rectangle(this.dataGrid.Width * (Device.Idiom == TargetIdiom.Phone ? 0.025 : 0.1), (this.dataGrid.Height / 2) - (350 / 2), this.dataGrid.Width - (this.dataGrid.Width * (Device.Idiom == TargetIdiom.Phone ? 0.05 : 0.2)), 350), 0, null);
            }

            if (Device.RuntimePlatform != Device.WinPhone && Device.RuntimePlatform != Device.UWP)
            {
                formView.Visibility = visible;
                formView.IsVisible = visible;
            }
            else
            {
                formView.Visibility = visible;
                formView.IsVisible = visible;
            }
        }

        private void Delete()
        {
            this.viewModel.OrdersInfo.RemoveAt(swipedRowIndex - 1);
        }

        private void rightImage_BindingContextChanged(object sender, EventArgs e)
        {
            if (rightImage.Source == null)
            {
                rightImage = sender as Image;
                (rightImage.Parent.Parent as View).GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(Delete) });
#if COMMONSB
                if (Device.RuntimePlatform == Device.Android)
                    rightImage.Source = ImageSource.FromResource("SampleBrowser.Icons.DataGrid.Delete.png", this.GetType().Assembly);
                else if (Device.RuntimePlatform == Device.iOS)
                    rightImage.Source = ImageSource.FromResource("SampleBrowser.Icons.DataGrid.SwipingIcon_iOS_Delete.png", this.GetType().Assembly);
                else
                    rightImage.Source = ImageSource.FromResource("SampleBrowser.Icons.DataGrid.SwipingIcon_UWP_Delete.png", this.GetType().Assembly);
#else
                if (Device.RuntimePlatform == Device.Android)
                    rightImage.Source = ImageSource.FromResource("SampleBrowser.SfDataGrid.Icons.DataGrid.Delete.png", this.GetType().Assembly);
                else if (Device.RuntimePlatform == Device.iOS)
                    rightImage.Source = ImageSource.FromResource("SampleBrowser.SfDataGrid.Icons.DataGrid.SwipingIcon_iOS_Delete.png", this.GetType().Assembly);
                else
                    rightImage.Source = ImageSource.FromResource("SampleBrowser.SfDataGrid.Icons.DataGrid.SwipingIcon_UWP_Delete.png", this.GetType().Assembly);
#endif
            }
        }

        private void dataGrid_SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            formView.BindingContext = e.RowData;
            swipedRowIndex = e.RowIndex;
        }

#endregion
        protected override void OnDetachingFrom(SampleView bindable)
        {
            bindable.PropertyChanged -= Swiping_PropertyChanged;
            dataGrid.GridTapped -= dataGrid_GridTapped;
            rightImage.BindingContextChanged -= rightImage_BindingContextChanged;
            leftImage.BindingContextChanged -= leftImage_BindingContextChanged;
            dataGrid.SwipeEnded -= dataGrid_SwipeEnded;
            base.OnDetachingFrom(bindable);
        }
    }
}

