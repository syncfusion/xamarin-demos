#region Copyright Syncfusion Inc. 2001-2017.
// ------------------------------------------------------------------------------------
// <copyright file = "OnBoardHelpsBehavior.cs" company="Syncfusion.com">
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
// </copyright>
// ------------------------------------------------------------------------------------
#endregion
namespace SampleBrowser.SfPopupLayout
{
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Reflection;
    using System.Threading.Tasks;
    using Core;
    using Syncfusion.SfDataGrid.XForms;
    using Syncfusion.XForms.PopupLayout;
    using Xamarin.Forms;
    using SfDataGrid = Syncfusion.SfDataGrid.XForms.SfDataGrid;

    /// <summary>
    /// Base generic class for generalized user-defined behaviors that can respond to arbitrary conditions and events.
    /// Type parameters:T: The type of the objects with which this Forms.Behavior`1 can be associated in the  OnBoardHelps samples
    /// </summary>
    public class OnBoardHelpsBehavior : Behavior<SampleView>
    {
        /// <summary>
        /// Holds the instance of the DataGrid.
        /// </summary>
        private SfDataGrid datagrid;

        /// <summary>
        /// Holds the instance of DragAndDropIllustration image.
        /// </summary>
        private Image dragAndDropIllustration;

        /// <summary>
        /// Holds the instance of DragAndDropLayout.
        /// </summary>
        private RelativeLayout dragdropLayout;

        /// <summary>
        /// Holds the edit illustration image,
        /// </summary>
        private Image editIllustration;

        /// <summary>
        /// Holds the hand symbol of the drag and drop layout.
        /// </summary>
        private Image handSymbol;

        /// <summary>
        /// Holds the instance of NextLabel.
        /// </summary>
        private Label nextlabel;

        /// <summary>
        /// Holds the instance of Ok Label.
        /// </summary>
        private Label oklabel;

        /// <summary>
        /// Holds the instance of PopupLayout.
        /// </summary>
        private SfPopupLayout popupLayout;

        /// <summary>
        /// RelativeLayout which is layout over the entire screen.
        /// </summary>
        private RelativeLayout overlay;

        /// <summary>
        /// Layout that holds the resizing illustration.
        /// </summary>
        private StackLayout resizingIllustration;

        /// <summary>
        /// Holds the resizing illustration image.
        /// </summary>
        private Image resizingIllustrationImage;

        /// <summary>
        /// Holds the layout of SwipeIllustration.
        /// </summary>
        private StackLayout swipeIllustration;

        /// <summary>
        /// Holds the SwipeIllustration image.
        /// </summary>
        private Image swipeIllustrationImage;

        /// <summary>
        /// Field that holds the tap count.
        /// </summary>
        private int tappingCount;

        /// <summary>
        /// Tap gesture added for the overlay to change the popups.
        /// </summary>
        private TapGestureRecognizer overlayTapGesture;

        /// <summary>
        /// You can override this method to subscribe to AssociatedObject events and initialize properties.
        /// </summary>
        /// <param name="bindAble">SampleView type parameter named as bindAble</param>
        protected override void OnAttachedTo(SampleView bindAble)
        {
            base.OnAttachedTo(bindAble);

            this.popupLayout = bindAble.Content.FindByName<SfPopupLayout>("popupLayout");

            this.datagrid = bindAble.Content.FindByName<SfDataGrid>("dataGrid");
            this.datagrid.GridLoaded += this.Datagrid_GridLoaded;
            this.datagrid.AutoGeneratingColumn += this.Datagrid_AutoGeneratingColumn;

            this.overlay = bindAble.FindByName<RelativeLayout>("overlay");
            this.overlay.BackgroundColor = Color.FromRgba(0, 0, 0, 0.8);
            this.AddLayoutTapGesture();

            this.resizingIllustration = (StackLayout)bindAble.Resources["ResizingIllustration"];
            this.resizingIllustrationImage = (Image)this.resizingIllustration.Children[0];
#if COMMONSB
            resizingIllustrationImage.Source =
 ImageSource.FromResource("SampleBrowser.Icons.ResizingIllustration.png", typeof(OnBoardHelpsBehavior).GetTypeInfo().Assembly);
#else
            this.resizingIllustrationImage.Source = ImageSource.FromResource(
                "SampleBrowser.SfPopupLayout.Icons.ResizingIllustration.png",
                typeof(OnBoardHelpsBehavior).GetTypeInfo().Assembly);
#endif

            this.editIllustration = (Image)bindAble.Resources["EditIllustration"];
#if COMMONSB
            editIllustration.Source =
 ImageSource.FromResource("SampleBrowser.Icons.EditIllustration.png", typeof(OnBoardHelpsBehavior).GetTypeInfo().Assembly);
#else
            this.editIllustration.Source = ImageSource.FromResource(
                "SampleBrowser.SfPopupLayout.Icons.EditIllustration.png",
                typeof(OnBoardHelpsBehavior).GetTypeInfo().Assembly);
#endif

            this.swipeIllustration = (StackLayout)bindAble.Resources["SwipeIllustration"];
            this.swipeIllustrationImage = (Image)this.swipeIllustration.Children[0];
#if COMMONSB
            swipeIllustrationImage.Source =
 ImageSource.FromResource("SampleBrowser.Icons.SwipeIllustration.png", typeof(OnBoardHelpsBehavior).GetTypeInfo().Assembly);
#else
            this.swipeIllustrationImage.Source = ImageSource.FromResource(
                "SampleBrowser.SfPopupLayout.Icons.SwipeIllustration.png",
                typeof(OnBoardHelpsBehavior).GetTypeInfo().Assembly);
#endif

            this.dragdropLayout = (RelativeLayout)bindAble.Resources["dragDropLayout"];
            this.handSymbol = this.dragdropLayout.Children[0] as Image;
#if COMMONSB
            handSymbol.Source =
 ImageSource.FromResource("SampleBrowser.Icons.HandSymbol.png", typeof(OnBoardHelpsBehavior).GetTypeInfo().Assembly);
            dragAndDropIllustration = dragdropLayout.Children[1] as Image;
            dragAndDropIllustration.Source =
 ImageSource.FromResource("SampleBrowser.Icons.DragAndDropIllustration.png", typeof(OnBoardHelpsBehavior).GetTypeInfo().Assembly);
#else
            this.handSymbol.Source = ImageSource.FromResource(
                "SampleBrowser.SfPopupLayout.Icons.HandSymbol.png",
                typeof(OnBoardHelpsBehavior).GetTypeInfo().Assembly);
            this.dragAndDropIllustration = this.dragdropLayout.Children[1] as Image;
            this.dragAndDropIllustration.Source = ImageSource.FromResource(
                "SampleBrowser.SfPopupLayout.Icons.DragAndDropIllustration.png",
                typeof(OnBoardHelpsBehavior).GetTypeInfo().Assembly);
#endif

            this.nextlabel = bindAble.FindByName<Label>("label");
            this.oklabel = bindAble.FindByName<Label>("oklabel");
            this.oklabel.IsVisible = false;
        }

        /// <summary>
        /// You can override this method while View was detached from window
        /// </summary>
        /// <param name="bindAble">SampleView type parameter named as bindAble</param>
        protected override void OnDetachingFrom(SampleView bindAble)
        {
            this.datagrid.AutoGeneratingColumn -= this.Datagrid_AutoGeneratingColumn;
            this.datagrid.GridLoaded -= this.Datagrid_GridLoaded;
            this.editIllustration = null;
            this.resizingIllustrationImage = null;
            this.overlayTapGesture.Tapped -= this.OverlayTapGesture_Tapped;
            this.overlay.GestureRecognizers.Remove(this.overlayTapGesture);
            this.popupLayout.Dispose();
            this.popupLayout = null;
            this.overlay = null;
            base.OnDetachingFrom(bindAble);
        }

        /// <summary>
        /// Fired when DataGrid comes in to the View
        /// </summary>
        /// <param name="sender">DataGrid_GridLoaded event sender</param>
        /// <param name="e">DataGrid_GridLoaded events args e</param>
        private void Datagrid_GridLoaded(object sender, GridLoadedEventArgs e)
        {
            this.popupLayout.PopupView.ContentTemplate = new DataTemplate(() => { return this.resizingIllustration; });
            if (Device.RuntimePlatform == Device.UWP)
            {
                this.popupLayout.Show(
                    this.datagrid.Columns[0].ActualWidth + this.datagrid.Columns[1].ActualWidth - 200,
                    0);
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                this.popupLayout.Show(this.datagrid.Columns[0].ActualWidth, 80);
            }
            else
            {
                this.popupLayout.Show(this.datagrid.Columns[0].ActualWidth + this.datagrid.Columns[1].ActualWidth, 40);
            }

            this.AnimateResizingIllustrationImage();
            this.tappingCount++;
        }

        /// <summary>
        /// Occurs when <see cref="AutoGenerateColumns"/>is set as true. Using this event, the user 
        /// can customize the columns being generated automatically.
        /// </summary>
        /// <param name="sender">DataGrid_AutoGeneratingColumn event sender</param>
        /// <param name="e">DataGrid_AutoGeneratingColumn event args e</param>
        private void Datagrid_AutoGeneratingColumn(object sender, AutoGeneratingColumnEventArgs e)
        {
            e.Column.HeaderFontAttribute = FontAttributes.Bold;
        }

        /// <summary>
        /// Adding TapGesture for relativePage
        /// </summary>
        private void AddLayoutTapGesture()
        {
            this.overlayTapGesture = new TapGestureRecognizer();
            this.overlay.GestureRecognizers.Add(this.overlayTapGesture);
            this.overlayTapGesture.Tapped += this.OverlayTapGesture_Tapped;
        }

        /// <summary>
        /// Call back for overlay's Tap event.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private async void OverlayTapGesture_Tapped(object sender, System.EventArgs e)
        {
            if (this.tappingCount == 1 && this.popupLayout.IsOpen)
            {
                this.resizingIllustrationImage.IsVisible = false;
                this.popupLayout.IsOpen = false;
                await Task.Delay(1);
                this.popupLayout.PopupView.HeightRequest = 140;
                this.popupLayout.PopupView.WidthRequest = 140;
                this.popupLayout.PopupView.ContentTemplate = new DataTemplate(() => { return this.editIllustration; });
                this.popupLayout.Show(100, (double)200);
                this.oklabel.IsVisible = false;
                this.editIllustration.IsVisible = true;
                this.AnimateEditIllustrationImage();
                this.tappingCount++;
            }
            else if (this.tappingCount == 2 && this.popupLayout.IsOpen)
            {
                this.popupLayout.IsOpen = false;
                await Task.Delay(1);
                this.popupLayout.PopupView.HeightRequest = 200;
                this.popupLayout.PopupView.WidthRequest = 400;
                this.popupLayout.PopupView.ContentTemplate = new DataTemplate(() => { return this.swipeIllustration; });
                this.popupLayout.Show(0, (double)200);
                this.editIllustration.IsVisible = false;
                this.oklabel.IsVisible = false;
                this.swipeIllustrationImage.IsVisible = true;
                this.AnimateSwipeIllustration();
                this.tappingCount++;
            }
            else if (this.tappingCount == 3 && this.popupLayout.IsOpen)
            {
                this.popupLayout.IsOpen = false;
                await Task.Delay(1);
                this.popupLayout.PopupView.HeightRequest = 200;
                this.popupLayout.PopupView.WidthRequest = 200;
                this.popupLayout.PopupView.ContentTemplate = new DataTemplate(() => { return this.dragdropLayout; });
                this.popupLayout.Show(0, (double)200);
                this.swipeIllustrationImage.IsVisible = false;
                this.nextlabel.IsVisible = false;
                this.handSymbol.IsVisible = true;
                this.dragAndDropIllustration.IsVisible = true;
                this.oklabel.IsVisible = true;
                this.AnimateDragAndDropIllustration();
                this.tappingCount++;
            }
            else
            {
                if (this.popupLayout.IsOpen)
                {
                    this.handSymbol.IsVisible = false;
                    this.dragAndDropIllustration.IsVisible = false;
                    this.popupLayout.IsOpen = false;
                }
                else
                {
                    this.nextlabel.IsVisible = false;
                    this.oklabel.IsVisible = false;
                }

                this.overlay.IsVisible = false;
            }
        }

        /// <summary>
        /// Used to for animate the resizing illustration image.
        /// </summary>
        private async void AnimateResizingIllustrationImage()
        {
            // Where we animate image based on its xposition value.
            if (!this.datagrid.IsVisible)
            {
                return;
            }

            // Move to left xposition
            await this.resizingIllustrationImage.TranslateTo(100, 0, 1000);
            //// Move to initial xposition
            await this.resizingIllustrationImage.TranslateTo(0, 0, 0);
            //// Repeat animation while resizingIllustration was visible.
            if (this.resizingIllustrationImage.IsVisible)
            {
                this.AnimateResizingIllustrationImage();
            }
        }

        /// <summary>
        /// Used animate edit Illustration Image
        /// </summary>
        private async void AnimateEditIllustrationImage()
        {
            // Where we animate image based on its Opacity value, we have change opacity value Simultaneously.
            if (!this.datagrid.IsVisible)
            {
                return;
            }

            // Default opacity value as zero and we set 1 as dynamically, we have dont this operation two time due to achive 
            // double click animate view.
            this.editIllustration.Opacity = 0;
            await this.editIllustration.FadeTo(1, 250);
            this.editIllustration.Opacity = 0;
            await this.editIllustration.FadeTo(1, 250);

            // Repeat animation while editIllustration image is visible.
            if (this.editIllustration.IsVisible)
            {
                await Task.Delay(1000);
                this.AnimateEditIllustrationImage();
            }
        }

        /// <summary>
        /// used to animate swiping illustration.
        /// </summary>
        private async void AnimateSwipeIllustration()
        {
            // Where we animate image based on its xposition value.

            // Move to right xposition value
            if (!this.datagrid.IsVisible)
            {
                return;
            }

            await this.swipeIllustrationImage.TranslateTo(90, 0, 1800);
            await this.swipeIllustrationImage.TranslateTo(0, 0, 0);

            // Repeat animation while swipeIllustration image is visible.
            if (this.swipeIllustrationImage.IsVisible)
            {
                this.AnimateSwipeIllustration();
            }
        }

        /// <summary>
        /// used to animate drag and drop image illustration.
        /// </summary>
        private async void AnimateDragAndDropIllustration()
        {
            if (!this.datagrid.IsVisible)
            {
                return;
            }

            this.handSymbol.AnchorY = 10;
            //// Rotate View to 10 degree
            await this.handSymbol.RotateTo(10, 500);

            ////transalte View to based on x, y point
            await this.handSymbol.TranslateTo(25, 25, 500);

            ////Reset rotaion,x,y position
            this.handSymbol.Rotation = 0;
            await this.handSymbol.TranslateTo(0, 0, 0);

            ////Repeat animation while both images are visible
            if (this.handSymbol.IsVisible && this.dragAndDropIllustration.IsVisible)
            {
                this.AnimateDragAndDropIllustration();
            }
        }
    }
}