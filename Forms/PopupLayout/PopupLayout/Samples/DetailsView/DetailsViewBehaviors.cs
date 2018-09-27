#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Syncfusion.XForms.PopupLayout;
using System.Reflection;

namespace SampleBrowser.SfPopupLayout
{
    public class DetailsViewBehaviors : Behavior<SampleView>
    {
        Syncfusion.XForms.PopupLayout.SfPopupLayout initialPopup;
        private Syncfusion.XForms.PopupLayout.SfPopupLayout popupLayout;
        private Label sendMessageText;
        private Image sendMessageImage;
        private Label blockSpanText;
        private Image blockSpanImage;
        private Label callDetailText;
        private Image callDetailImage;
        private Syncfusion.ListView.XForms.SfListView listview;
        private ContactsViewModel viewModel;
		private VisualContainer container;

        public DetailsViewBehaviors()
        {
            viewModel = new ContactsViewModel();
        }
		
        protected override void OnAttachedTo(SampleView bindable)
        {
            if (initialPopup == null)
            {
                initialPopup = new DetailsViewInitialPopup().Content as Syncfusion.XForms.PopupLayout.SfPopupLayout;
                initialPopup.Show();
            }
            popupLayout = bindable.FindByName<Syncfusion.XForms.PopupLayout.SfPopupLayout>("popUp");
            listview = bindable.FindByName<Syncfusion.ListView.XForms.SfListView>("listView");
            listview.ItemsSource = viewModel.contactsinfo;
            listview.ItemTapped += ListView_ItemTapped;
            listview.Loaded += Listview_Loaded;
            popupLayout.PopupView.AnimationMode = AnimationMode.None;
            popupLayout.PopupView.ShowHeader = false;
            popupLayout.PopupView.ShowFooter = false;
            popupLayout.PopupView.HeightRequest = 150;
            if (Device.RuntimePlatform == Device.iOS)
            {
                popupLayout.PopupView.PopupStyle.BorderColor = Color.White;
            }

            popupLayout.PopupView.ContentTemplate = new DataTemplate(() =>
        {
            Grid popupcontent = new Grid();
            popupcontent.BackgroundColor = Color.White;
            popupcontent.HorizontalOptions = LayoutOptions.FillAndExpand;
            popupcontent.VerticalOptions = LayoutOptions.FillAndExpand;
            popupcontent.RowDefinitions.Add(new RowDefinition { Height = 40 });
            popupcontent.RowDefinitions.Add(new RowDefinition { Height = 40 });
            popupcontent.RowDefinitions.Add(new RowDefinition { Height = 40 });
            popupcontent.ColumnDefinitions.Add(new ColumnDefinition { Width = 50 });
            popupcontent.ColumnDefinitions.Add(new ColumnDefinition { Width = 500 });

            sendMessageText = new Label();
            sendMessageText.Text = "Send a Message";
            sendMessageText.TextColor = Color.FromHex("#000000");
            sendMessageText.FontSize = 16;
            sendMessageText.HorizontalOptions = LayoutOptions.Start;
            sendMessageText.VerticalOptions = LayoutOptions.Center;
            sendMessageText.Opacity = 87;


            sendMessageImage = new Image();
            sendMessageImage.Opacity = 0.5f;
#if COMMONSB
            sendMessageImage.Source = ImageSource.FromResource("SampleBrowser.Images.SendMessage.png", typeof(DetailsViewBehaviors).GetTypeInfo().Assembly);
#else
            sendMessageImage.Source = ImageSource.FromResource("SampleBrowser.SfPopupLayout.Images.SendMessage.png", typeof(DetailsViewBehaviors).GetTypeInfo().Assembly);
#endif
            sendMessageImage.WidthRequest = 20;
            sendMessageImage.HeightRequest = 20;
            sendMessageImage.HorizontalOptions = LayoutOptions.CenterAndExpand;
            sendMessageImage.VerticalOptions = LayoutOptions.CenterAndExpand;

            blockSpanText = new Label();
            blockSpanText.Text = "Block / Report Spam";
            blockSpanText.TextColor = Color.FromHex("#000000");
            blockSpanText.FontSize = 16;
            blockSpanText.HorizontalOptions = LayoutOptions.Start;
            blockSpanText.VerticalOptions = LayoutOptions.Center;
            blockSpanText.Opacity = 87;


            blockSpanImage = new Image();
            blockSpanImage.Opacity = 0.5f;
#if COMMONSB
            blockSpanImage.Source = ImageSource.FromResource("SampleBrowser.Images.BlockSpan.png", typeof(DetailsViewBehaviors).GetTypeInfo().Assembly);
#else
            blockSpanImage.Source = ImageSource.FromResource("SampleBrowser.SfPopupLayout.Images.BlockSpan.png", typeof(DetailsViewBehaviors).GetTypeInfo().Assembly);
#endif
            blockSpanImage.HeightRequest = 20;
            blockSpanImage.WidthRequest = 20;
            blockSpanImage.HorizontalOptions = LayoutOptions.CenterAndExpand;
            blockSpanImage.VerticalOptions = LayoutOptions.CenterAndExpand;

            callDetailText = new Label();
            callDetailText.Text = "Call details";
            callDetailText.TextColor = Color.FromHex("#000000");
            callDetailText.FontSize = 16;
            callDetailText.HorizontalOptions = LayoutOptions.Start;
            callDetailText.VerticalOptions = LayoutOptions.Center;
            callDetailText.Opacity = 87;


            callDetailImage = new Image();
            callDetailImage.Opacity = 0.5f;
#if COMMONSB
            callDetailImage.Source = ImageSource.FromResource("SampleBrowser.Images.CallDetails.png", typeof(DetailsViewBehaviors).GetTypeInfo().Assembly);
#else
            callDetailImage.Source = ImageSource.FromResource("SampleBrowser.SfPopupLayout.Images.CallDetails.png", typeof(DetailsViewBehaviors).GetTypeInfo().Assembly);
#endif
            callDetailImage.HeightRequest = 20;
            callDetailImage.WidthRequest = 20;
            callDetailImage.HorizontalOptions = LayoutOptions.CenterAndExpand;
            callDetailImage.VerticalOptions = LayoutOptions.CenterAndExpand;

            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.UWP)
            {
                popupcontent.Padding = 10;

                sendMessageText.Margin = new Thickness(0, 10, 0, 0);
                sendMessageText.WidthRequest = 500;
                sendMessageText.HeightRequest = 40;

                sendMessageImage.WidthRequest = 20;
                sendMessageImage.HeightRequest = 20;

                blockSpanText.Margin = new Thickness(0, 10, 0, 0);
                blockSpanText.WidthRequest = 500;
                blockSpanText.HeightRequest = 40;

                blockSpanImage.WidthRequest = 20;
                blockSpanImage.HeightRequest = 20;

                callDetailText.Margin = new Thickness(0, 10, 0, 0);
                callDetailText.WidthRequest = 500;
                callDetailText.HeightRequest = 40;

                callDetailImage.WidthRequest = 20;
                callDetailImage.HeightRequest = 20;
            }

            popupcontent.Children.Add(sendMessageImage, 0, 0);
            popupcontent.Children.Add(sendMessageText, 1, 0);
            popupcontent.Children.Add(blockSpanImage, 0, 1);
            popupcontent.Children.Add(blockSpanText, 1, 1);
            popupcontent.Children.Add(callDetailImage, 0, 2);
            popupcontent.Children.Add(callDetailText, 1, 2);
            return popupcontent;
        });

        }

        private void Listview_Loaded(object sender, ListViewLoadedEventArgs e)
        {
            popupLayout.PopupView.WidthRequest = listview.Width;
            container = listview.GetType().GetTypeInfo().GetDeclaredProperty("VisualContainer").GetValue(listview) as VisualContainer;
        }

        private void ListView_ItemTapped(object sender, Syncfusion.ListView.XForms.ItemTappedEventArgs e)
        {
            var itemIndex = viewModel.contactsinfo.IndexOf(e.ItemData as ContactInfo);
            var visibleLine = container.ScrollRows.GetVisibleLineAtLineIndex(itemIndex);
            double point = listview.Y + visibleLine.ClippedOrigin + visibleLine.Size;
            popupLayout.PopupView.PopupStyle.BorderThickness = 1;
            if (point + 140 <= listview.Height + 25)
                popupLayout.Show(listview.X, listview.Y + visibleLine.ClippedOrigin + visibleLine.ClippedSize + GetRelativeYPoint("top"));
            else
                popupLayout.Show(listview.X, point - GetRelativeYPoint("bottom"));
        }

        private double GetRelativeYPoint(string position)
        {
            if (Device.RuntimePlatform == Device.Android)
                return position == "top" ? 40 : 200;
            else if (Device.RuntimePlatform == Device.iOS)
                return position == "top" ? 80 : 170;
            else
                return position == "top" ? 0 : 240;
            
        }
    }
}
