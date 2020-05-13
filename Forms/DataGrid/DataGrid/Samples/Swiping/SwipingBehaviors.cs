#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "SwipingBehaviors.cs" company="Syncfusion.com">
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
    using SampleBrowser.Core;
    using Syncfusion.SfDataGrid.XForms;
  
    using Xamarin.Forms;

    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]

    /// <summary>
    ///  Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    ///  Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the  Swiping samples
    /// </summary>
    public class SwipingBehaviors : Behavior<SampleView>
    {
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Syncfusion.SfDataGrid.XForms.SfDataGrid dataGrid;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private SwipingViewModel viewModel;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Image leftImage;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private Image rightImage;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private int swipedRowIndex;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private FormsView formView;
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed. Suppression is OK here.Private field does not need documentation")]
        private CustomLayout customLayout;

        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="bindAble">SampleView type parameter as bindAble</param>
        protected override void OnAttachedTo(SampleView bindAble)
        {
            this.customLayout = bindAble.FindByName<CustomLayout>("custumLayout");
            this.dataGrid = bindAble.FindByName<Syncfusion.SfDataGrid.XForms.SfDataGrid>("dataGrid");
            this.rightImage = (Image)bindAble.Resources["rightImage"];
            this.leftImage = (Image)bindAble.Resources["leftImage"];
            this.viewModel = new SwipingViewModel();
            bindAble.BindingContext = this.viewModel;
            this.dataGrid.ItemsSource = this.viewModel.OrdersInfo;
            bindAble.PropertyChanged += this.Swiping_PropertyChanged;
            this.formView = new FormsView(this.dataGrid);
            this.customLayout.Children.Add(this.formView);
            this.dataGrid.GridTapped += this.DataGrid_GridTapped;
            this.rightImage.BindingContextChanged += this.RightImage_BindingContextChanged;
            this.leftImage.BindingContextChanged += this.LeftImage_BindingContextChanged;
            this.dataGrid.SwipeEnded += this.DataGrid_SwipeEnded;
            base.OnAttachedTo(bindAble);
        }
       
        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="bindAble">SampleView type of bindAble parameter</param>
        protected override void OnDetachingFrom(SampleView bindAble)
        {
            bindAble.PropertyChanged -= this.Swiping_PropertyChanged;
            this.dataGrid.GridTapped -= this.DataGrid_GridTapped;
            this.rightImage.BindingContextChanged -= this.RightImage_BindingContextChanged;
            this.leftImage.BindingContextChanged -= this.LeftImage_BindingContextChanged;
            this.dataGrid.SwipeEnded -= this.DataGrid_SwipeEnded;
            base.OnDetachingFrom(bindAble);
        }

        #region Private Methods

        /// <summary>
        /// triggers while Swiping Property was changed
        /// </summary>
        /// <param name="sender">Swiping_PropertyChanged event sender</param>
        /// <param name="e">Swiping_PropertyChanged event args e</param>
        private void Swiping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Width" && this.formView != null && this.formView.Width != -1)
            {
                if (this.formView.Visibility == true && this.formView.IsVisible == true)
                {
                    if (Device.RuntimePlatform == Device.macOS)
                    {
                        this.LayoutMacFormsView(true);
                    }
                    else
                    {
                        this.LayoutFormsView(true);
                    }
                }
                else
                {
                    if (Device.RuntimePlatform == Device.macOS)
                    {
                        this.LayoutMacFormsView(false);
                    }
                    else
                    {
                        this.LayoutFormsView(false);
                    }

                    this.dataGrid.Opacity = 1.0;
                }
            }
        }

        /// <summary>
        /// Triggers while DataGrid was tapped.
        /// </summary>
        /// <param name="sender">DataGrid_GridTapped event sender</param>
        /// <param name="e">DataGrid_GridTapped event args</param>
        private void DataGrid_GridTapped(object sender, GridTappedEventArgs e)
        {
            if (Device.RuntimePlatform != Device.UWP)
            {
                this.formView.Visibility = false;
            }
            else
            {
                this.formView.IsVisible = false;
            }

            this.dataGrid.Opacity = 1.0;
            this.dataGrid.IsEnabled = true;
        }

        /// <summary>
        /// Triggers while left image binding context was changed.
        /// </summary>
        /// <param name="sender">leftImage_BindingContextChanged event sender</param>
        /// <param name="e">leftImage_BindingContextChanged event args</param>
        private void LeftImage_BindingContextChanged(object sender, EventArgs e)
        {
            if (this.leftImage.Source == null)
            {
                this.LayoutFormsView(false);
                this.leftImage = sender as Image;
                this.leftImage.IsVisible = true;
                (this.leftImage.Parent.Parent as View).GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(this.Edit) });
                this.leftImage.Source = new FontImageSource
                {
                    Glyph = "\ue747",
                    FontFamily = (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.macOS) ? "Sync FontIcons" : Device.RuntimePlatform == Device.Android ? "Sync FontIcons.ttf#" : "Sync FontIcons.ttf#Sync FontIcons",
                    Color = Color.White
                };
            }
        }

        /// <summary>
        /// Used this method to get a Edit View of Swiping 
        /// </summary>
        private void Edit()
        {
            this.dataGrid.Opacity = 0.25;
            this.dataGrid.IsEnabled = false;

            if (Device.RuntimePlatform != Device.macOS)
            {
                this.LayoutFormsView(true);
            }
            else
            {
                this.LayoutMacFormsView(true);
            }
        }

        /// <summary>
        /// Layouts the FormsView in Mac platform
        /// </summary>
        /// <param name="visisble">Indicates true or false type parameter visible</param>
        private void LayoutMacFormsView(bool visisble)
        {
            if (Device.RuntimePlatform != Device.UWP)
            {
                this.formView.LayoutTo(new Rectangle(this.dataGrid.Width * (Device.Idiom == TargetIdiom.Phone ? 0.025 : 0.1), (this.dataGrid.Height / 2) - (350 / 2), this.dataGrid.Width - (this.dataGrid.Width * (Device.Idiom == TargetIdiom.Phone ? 0.05 : 0.2)), 350), 350, null);
                this.formView.Visibility = visisble;
                this.formView.IsVisible = visisble;
            }
            else
            {
                this.formView.IsVisible = visisble;
            }
        }

        /// <summary>
        /// Layouts the FormsView in all platform except MAC
        /// </summary>
        /// <param name="visible">Indicates true or false type parameter visible</param>
        private async void LayoutFormsView(bool visible)
        {
            await Task.Delay(10);
            if (Device.RuntimePlatform != Device.macOS)
            {
                string orientation = DependencyService.Get<IDataGridDependencyService>().GetOrientation();
                if (orientation != "Portrait" && orientation != "PortraitUpsideDown")
                {
                    await this.formView.LayoutTo(new Rectangle(this.dataGrid.Width / 8, (this.dataGrid.Height / 2) - (250 / 2), this.dataGrid.Width - (this.dataGrid.Width / 4), 250), 0, null);
                }
                else
                {
                    if (Device.RuntimePlatform != Device.UWP)
                    {
                        await this.formView.LayoutTo(new Rectangle(this.dataGrid.Width * (Device.Idiom == TargetIdiom.Phone ? 0.025 : 0.1), (this.dataGrid.Height / 2) - (350 / 2), this.dataGrid.Width - (this.dataGrid.Width * (Device.Idiom == TargetIdiom.Phone ? 0.05 : 0.2)), 350), 0, null);
                    }
                    else
                    {
                        await this.formView.LayoutTo(new Rectangle(this.dataGrid.Width * (Device.Idiom == TargetIdiom.Phone ? 0.025 : 0.1), (this.dataGrid.Height / 2) - (350 / 2), this.dataGrid.Width - (this.dataGrid.Width * (Device.Idiom == TargetIdiom.Phone ? 0.05 : 0.2)), 350), 0, null);
                    }
                }
            }

            if (Device.RuntimePlatform != Device.UWP)
            {
                this.formView.Visibility = visible;
                this.formView.IsVisible = visible;
                this.formView.ForceLayout();
            }
            else
            {
                this.formView.Visibility = visible;
                this.formView.IsVisible = visible;
                this.formView.ForceLayout();
            }
        }

        /// <summary>
        /// Used this method to delete a Row records while Delete Image was pressed
        /// </summary>
        private void Delete()
        {
            this.viewModel.OrdersInfo.RemoveAt(this.swipedRowIndex - 1);
        }

        /// <summary>
        /// Triggers while RightImage Binding Context was changed
        /// </summary>
        /// <param name="sender">RightImage_BindingContextChanged event sender</param>
        /// <param name="e">RightImage_BindingContextChanged event args e</param>
        private void RightImage_BindingContextChanged(object sender, EventArgs e)
        {
            if (this.rightImage.Source == null)
            {
                this.rightImage = sender as Image;
                (this.rightImage.Parent.Parent as View).GestureRecognizers.Add(new TapGestureRecognizer() { Command = new Command(this.Delete) });
                this.rightImage.Source = new FontImageSource
                {
                    Glyph = "\ue735",
                    FontFamily = (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.macOS) ? "Sync FontIcons" : Device.RuntimePlatform == Device.Android ? "Sync FontIcons.ttf#" : "Sync FontIcons.ttf#Sync FontIcons",
                    Color = Color.White
                };
            }
        }

        /// <summary>
        /// Triggers while Swiping was ended
        /// </summary>
        /// <param name="sender">DataGrid_SwipeEnded event sender</param>
        /// <param name="e">DataGrid_SwipeEnded event args</param>
        private void DataGrid_SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            this.formView.BindingContext = e.RowData;
            this.swipedRowIndex = e.RowIndex;
        }

        #endregion
    }
}