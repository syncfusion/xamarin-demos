#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Threading.Tasks;
using SampleBrowser.Core;
using Xamarin.Forms;
using Syncfusion.SfDataGrid.XForms;
using System.Collections.ObjectModel;
using Syncfusion.XForms.PopupLayout;
using System.Reflection;

namespace SampleBrowser.SfPopupLayout
{
    public class OnBoardHelpsBehavior : Behavior<SampleView>
    {
        private Syncfusion.XForms.PopupLayout.SfPopupLayout popupLayout;
        private Image infoNotification;
        private Image resizingIllustrationImage;
        private Image editIllustration;
        private Image swipeIllustrationImage;
        private Image handSymbol;
        private Image dragAndDropIllustration;
        private RelativeLayout relativePage;
        private Label nextlabel;
        private Label oklabel;
        private int tappingCount = 0;
        private SwipingViewModel viewModel;
        private Syncfusion.SfDataGrid.XForms.SfDataGrid datagrid;
        private RelativeLayout dragdropLayout;
        private StackLayout resizingIllustration;
        private StackLayout swipeIllustration;

        protected override void OnAttachedTo(SampleView bindable)
        {
            base.OnAttachedTo(bindable);
            popupLayout = bindable.Content.FindByName<Syncfusion.XForms.PopupLayout.SfPopupLayout>("popupLayout");
            datagrid = bindable.Content.FindByName<Syncfusion.SfDataGrid.XForms.SfDataGrid>("dataGrid");
			datagrid.GridLoaded += Datagrid_GridLoaded;
            viewModel = new SwipingViewModel();
            bindable.BindingContext = viewModel;
            viewModel.SetRowstoGenerate(30);
            datagrid.ItemsSource = viewModel.OrdersInfo;

            datagrid.AutoGeneratingColumn += Datagrid_AutoGeneratingColumn;
            relativePage = bindable.FindByName<RelativeLayout>("relativeLayout");
            relativePage.BackgroundColor =  Color.FromRgba(0, 0, 0, 0.8);
            AddLayoutTapGeture();

            infoNotification = (Image)bindable.Resources["InfoNotification"];
#if COMMONSB
            infoNotification.Source = ImageSource.FromResource("SampleBrowser.Icons.InfoNotification.png",typeof(OnBoardHelpsBehavior).GetTypeInfo().Assembly);
#else
            infoNotification.Source = ImageSource.FromResource("SampleBrowser.SfPopupLayout.Icons.InfoNotification.png", typeof(OnBoardHelpsBehavior).GetTypeInfo().Assembly);
#endif
            resizingIllustration = (StackLayout)bindable.Resources["ResizingIllustration"];
            resizingIllustrationImage = (Image)resizingIllustration.Children[0];
#if COMMONSB
            resizingIllustrationImage.Source = ImageSource.FromResource("SampleBrowser.Icons.ResizingIllustration.png", typeof(OnBoardHelpsBehavior).GetTypeInfo().Assembly);
#else
            resizingIllustrationImage.Source = ImageSource.FromResource("SampleBrowser.SfPopupLayout.Icons.ResizingIllustration.png", typeof(OnBoardHelpsBehavior).GetTypeInfo().Assembly);
#endif

            editIllustration = (Image)bindable.Resources["EditIllustration"];
#if COMMONSB
            editIllustration.Source = ImageSource.FromResource("SampleBrowser.Icons.EditIllustration.png", typeof(OnBoardHelpsBehavior).GetTypeInfo().Assembly);
#else
            editIllustration.Source = ImageSource.FromResource("SampleBrowser.SfPopupLayout.Icons.EditIllustration.png", typeof(OnBoardHelpsBehavior).GetTypeInfo().Assembly);
#endif
            swipeIllustration = (StackLayout)bindable.Resources["SwipeIllustration"];
            swipeIllustrationImage = (Image)swipeIllustration.Children[0];
#if COMMONSB
            swipeIllustrationImage.Source = ImageSource.FromResource("SampleBrowser.Icons.SwipeIllustration.png", typeof(OnBoardHelpsBehavior).GetTypeInfo().Assembly);
#else
             swipeIllustrationImage.Source = ImageSource.FromResource("SampleBrowser.SfPopupLayout.Icons.SwipeIllustration.png", typeof(OnBoardHelpsBehavior).GetTypeInfo().Assembly);
#endif
            dragdropLayout = (RelativeLayout)bindable.Resources["dragDropLayout"];

            handSymbol = dragdropLayout.Children[0] as Image;
#if COMMONSB
            handSymbol.Source = ImageSource.FromResource("SampleBrowser.Icons.HandSymbol.png", typeof(OnBoardHelpsBehavior).GetTypeInfo().Assembly);
            dragAndDropIllustration = dragdropLayout.Children[1] as Image;
            dragAndDropIllustration.Source = ImageSource.FromResource("SampleBrowser.Icons.DragAndDropIllustration.png", typeof(OnBoardHelpsBehavior).GetTypeInfo().Assembly);
#else
            handSymbol.Source = ImageSource.FromResource("SampleBrowser.SfPopupLayout.Icons.HandSymbol.png", typeof(OnBoardHelpsBehavior).GetTypeInfo().Assembly);
            dragAndDropIllustration = dragdropLayout.Children[1] as Image;
            dragAndDropIllustration.Source = ImageSource.FromResource("SampleBrowser.SfPopupLayout.Icons.DragAndDropIllustration.png", typeof(OnBoardHelpsBehavior).GetTypeInfo().Assembly);
#endif

            nextlabel = bindable.FindByName<Label>("label");
            oklabel = bindable.FindByName<Label>("oklabel");
            oklabel.IsVisible = false;
            viewModel.PopupContentTemplate = new DataTemplate(() =>
            {
                return infoNotification;
            });
        }


        private void Datagrid_GridLoaded(object sender, GridLoadedEventArgs e)
        {
            popupLayout.PopupView.HeightRequest = 140;
            popupLayout.PopupView.WidthRequest = 200;
            popupLayout.PopupView.AnimationMode = AnimationMode.None;
            if(Device.RuntimePlatform == Device.UWP)
            {
                popupLayout.ShowRelativeToView(datagrid, RelativePosition.AlignTopRight, -275, 80);
            }
            else if(Device.RuntimePlatform == Device.iOS)
            {
                popupLayout.ShowRelativeToView(datagrid, RelativePosition.AlignTopRight, -225, 120);
            }
            else
            {
                popupLayout.ShowRelativeToView(datagrid, RelativePosition.AlignTopRight, -225, 80);
            }
            AnimateinfoNotificationImage();
        }

        private void Datagrid_AutoGeneratingColumn(object sender, AutoGeneratingColumnEventArgs e)
        {
            e.Column.HeaderFontAttribute = FontAttributes.Bold;
        }

        private void AddLayoutTapGeture()
        {
            var relativePage_Gesture = new TapGestureRecognizer();
            relativePage.GestureRecognizers.Add(relativePage_Gesture);
            relativePage_Gesture.Tapped += (object sender, EventArgs e) => {
                if (tappingCount == 0 && popupLayout.IsOpen)
                {
                    popupLayout.Dismiss();
                    popupLayout.PopupView.HeightRequest = 200;
                    popupLayout.PopupView.WidthRequest = 400;
                    viewModel.PopupContentTemplate = new DataTemplate(() =>
                    {
                        return resizingIllustration;
                    });
                    if (Device.RuntimePlatform == Device.UWP)
                        popupLayout.Show(datagrid.Columns[0].ActualWidth + datagrid.Columns[1].ActualWidth - 200, 0);
                    else if (Device.RuntimePlatform == Device.iOS)
                        popupLayout.Show(datagrid.Columns[0].ActualWidth, 80);
                    else
                        popupLayout.Show(datagrid.Columns[0].ActualWidth + datagrid.Columns[1].ActualWidth, 40);
                    AnimateResizingIllustrationImage();
                    tappingCount++;
                }
                else if (tappingCount == 1 && popupLayout.IsOpen)
                {
                    resizingIllustrationImage.IsVisible = false;
                    popupLayout.IsOpen = false;
                    popupLayout.PopupView.HeightRequest = 140;
                    popupLayout.PopupView.WidthRequest = 140;
                    viewModel.PopupContentTemplate = new DataTemplate(() =>
                    {
                        return editIllustration;
                    });
                    popupLayout.Show((double)100, (double)200);
                    oklabel.IsVisible = false;
                    editIllustration.IsVisible = true;
                    AnimateEditIllustrationImage();
                    tappingCount++;
                }
                else if (tappingCount == 2 && popupLayout.IsOpen)
                {
                    popupLayout.IsOpen = false;
                    popupLayout.PopupView.HeightRequest = 200;
                    popupLayout.PopupView.WidthRequest =  400;
                    viewModel.PopupContentTemplate  = new DataTemplate(() =>
                    {
                        return swipeIllustration;
                    });
                    popupLayout.Show((double)0, (double)200);
                    editIllustration.IsVisible = false;
                    oklabel.IsVisible = false;
                    swipeIllustrationImage.IsVisible = true;
                    AnimateSwipeIllustration();
                    tappingCount++;
                }
                else if (tappingCount == 3 && popupLayout.IsOpen)
                {
                    popupLayout.IsOpen = false;
                    popupLayout.PopupView.HeightRequest = 200;
                    popupLayout.PopupView.WidthRequest = 200;
                    viewModel.PopupContentTemplate = new DataTemplate(() =>
                    {
                        return dragdropLayout;
                    });
                    popupLayout.Show((double)0, (double)200);
                    swipeIllustrationImage.IsVisible = false;
                    nextlabel.IsVisible = false;
                    handSymbol.IsVisible = true;
                    dragAndDropIllustration.IsVisible = true;
                    oklabel.IsVisible = true;
                    AnimateDragAndDropIllustration();
                    tappingCount++;
                }
                else
                {
                    if (popupLayout.IsOpen)
                    {
                        handSymbol.IsVisible = false;
                        dragAndDropIllustration.IsVisible = false;
                        popupLayout.IsOpen = false;
                    }
                    else
                    {
                        nextlabel.IsVisible = false;
                        oklabel.IsVisible = false;
                    }
                    relativePage.IsVisible = false;
                }
            };
        }

        private async void AnimateinfoNotificationImage()
        {
            // Where we animate image based on its yposition value.
            if (!datagrid.IsVisible)
                return;
            // Move to top yposition
            await infoNotification.TranslateTo(0, -40, 1000);
            // Move to initial yposition
            await infoNotification.TranslateTo(0, 50, 1000);
            // Repeat animation while infoNotification image was visible.
            if (infoNotification.IsVisible)
                AnimateinfoNotificationImage();
        }

        private async void AnimateResizingIllustrationImage()
        {
            // Where we animate image based on its xposition value.
            if (!datagrid.IsVisible)
                return;
            // Move to left xposition
            await resizingIllustrationImage.TranslateTo(100, 0, 1000);
            // Move to initial xposition
            await resizingIllustrationImage.TranslateTo(0, 0, 0);
            // Repeat animation while resizingIllustration was visible.
            if (resizingIllustrationImage.IsVisible)
                AnimateResizingIllustrationImage();
        }

        private async void AnimateEditIllustrationImage()
        {
            // Where we animate image based on its Opacity value, we have change opacity value Simultaneously.
            if (!datagrid.IsVisible)
                return;
            // Default opacity value as zero and we set 1 as dynamically, we have dont this operation two time due to achive 
            // double click animate view.
            editIllustration.Opacity = 0;
            await editIllustration.FadeTo(1, 250);
            editIllustration.Opacity = 0;
            await editIllustration.FadeTo(1, 250);

            // Repeat animation while editIllustration image is visible.
            if (editIllustration.IsVisible)
            {
                await Task.Delay(1000);
                AnimateEditIllustrationImage();
            }
        }
        private async void AnimateSwipeIllustration()
        {
            // Where we animate image based on its xposition value.

            // Move to right xposition value
            if (!datagrid.IsVisible)
                return;
            await swipeIllustrationImage.TranslateTo(90, 0, 1800);
            await swipeIllustrationImage.TranslateTo(0, 0, 0);

            // Repeat animation while swipeIllustration image is visible.
            if (swipeIllustrationImage.IsVisible)
                AnimateSwipeIllustration();
        }
        private async void AnimateDragAndDropIllustration()
        {
            if (!datagrid.IsVisible)
                return;
            handSymbol.AnchorY = 10;
            // Rotate View to 10 degree
            await handSymbol.RotateTo(10, 500);

            //transalte View to based on x, y point
            await handSymbol.TranslateTo(25, 25, 500);

            //Reset rotaion,x,y position
            handSymbol.Rotation = 0;
            await handSymbol.TranslateTo(0, 0, 0);

            //Repeat animation while both images are visible
            if (handSymbol.IsVisible && dragAndDropIllustration.IsVisible)
                AnimateDragAndDropIllustration();
        }
        protected override void OnDetachingFrom(SampleView bindable)
        {
            infoNotification = null;
            editIllustration = null;
            resizingIllustrationImage = null;
            popupLayout = null;
            relativePage = null;
            base.OnDetachingFrom(bindable);
        }
    }

    public class SwipeDeleteBehavior : Behavior<Label>

    {
        private Syncfusion.SfDataGrid.XForms.SfDataGrid datagrid;
        private int swipedRowIndex;
        private ObservableCollection<OrderInfo> viewModel;

        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Parameter", typeof(object), typeof(SwipeDeleteBehavior), null);
        public object Parameter
        {
            get
            {
                return (object)GetValue(CommandProperty);
            }
            set
            {
                SetValue(CommandProperty, value);
            }
        }

        protected override void OnAttachedTo(Label bindable)
        {
            base.OnAttachedTo(bindable);
            datagrid = Parameter as Syncfusion.SfDataGrid.XForms.SfDataGrid;
            viewModel = datagrid.ItemsSource as ObservableCollection<OrderInfo>;
            datagrid.SwipeEnded += Datagrid_SwipeEnded;

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                viewModel.RemoveAt(swipedRowIndex - 1);
            };
            (bindable as Label).GestureRecognizers.Add(tapGestureRecognizer);
        }

        private void Datagrid_SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            swipedRowIndex = e.RowIndex;
        }
    }
}
