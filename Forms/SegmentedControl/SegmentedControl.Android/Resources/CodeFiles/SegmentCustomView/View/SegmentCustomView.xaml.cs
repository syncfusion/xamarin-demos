#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using SampleBrowser.Core;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using SampleBrowser.SfSegmentedControl.Samples.SegmentCustomView.View;

namespace SampleBrowser.SfSegmentedControl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SegmentCustomView : SampleView
    {
        #region Properties
        private Image likeButton = new Image { Source = ImagePathConverter.GetImageSource("SampleBrowser.SfSegmentedControl.like.png") };
        private Image loveButton = new Image { Source = ImagePathConverter.GetImageSource("SampleBrowser.SfSegmentedControl.love.png") };
        private Image laughButton = new Image { Source = ImagePathConverter.GetImageSource("SampleBrowser.SfSegmentedControl.laugh.png") };
        private Image wowButton = new Image { Source = ImagePathConverter.GetImageSource("SampleBrowser.SfSegmentedControl.wow.png") };
        private Image sadButton = new Image { Source = ImagePathConverter.GetImageSource("SampleBrowser.SfSegmentedControl.sad.png") };
        private Image angryButton = new Image { Source = ImagePathConverter.GetImageSource("SampleBrowser.SfSegmentedControl.angry.png") };

        /// <summary>
        /// Like button initialization and its customisation code
        /// </summary>
        private Button likeViewButton = new Button
        {
            Text = "Like",
            TextColor = Color.Black,
            BackgroundColor = Color.White,
            BorderColor = Color.FromHex("#979797"),
            BorderWidth = 1,
            BorderRadius = 4,
            HeightRequest = 50,
            VerticalOptions = LayoutOptions.Center
        };

        /// <summary>
        /// Share button initialization and its customisation codes.
        /// </summary>
        private Button shareViewButton = new Button
        {
            Text = "Share",
            TextColor = Color.Black,
            BackgroundColor = Color.White,
            BorderColor = Color.FromHex("#979797"),
            BorderWidth = 1,
            BorderRadius = 4,
            HeightRequest = 50,
            VerticalOptions = LayoutOptions.Center
        };
        #endregion

        /// <summary>
        /// Custom view constructor
        /// </summary>
        public SegmentCustomView()
        {
            InitializeComponent();
            timeLabel.Text = DateTime.Now.ToString("MMM dd, h:mm:ss tt");
            var reactionView = new ReactionView();
            CustomSegmentsContainer.ItemsSource = new ObservableCollection<View>
            {
                likeButton,
                loveButton,
                laughButton,
                wowButton,
                sadButton,
                angryButton
            };
            buttonContainer.ItemsSource = new ObservableCollection<View>
            {
                likeViewButton,
                shareViewButton
            };
            if (Device.RuntimePlatform == Device.UWP)
            {
                CustomSegmentsContainer.BackgroundColor = Color.White;

            }
            else if(Device.RuntimePlatform == Device.Android)
            {
                CustomSegmentsContainer.BackgroundColor = Color.White;
            }
            else if(Device.RuntimePlatform == Device.iOS)
            {
                CustomSegmentsContainer.BackgroundColor = Color.Transparent;
            }
            likeViewButton.Clicked += (sender, args) =>
            {
                if (this.frame.Opacity == 0)
                {
                    likeViewButton.BorderColor = Color.FromHex("#007DE6");
                    likeViewButton.TextColor = Color.FromHex("#007DE6");
                    this.frame.FadeTo(1, 1000, Easing.Linear);
                }
                else
                {
                    this.CollapseSmileys();
                }
            };
            shareViewButton.Clicked += ShareViewButtonOnClicked;
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width > height)
            {
                MainGrid.HeightRequest = width;
            }
            else
                MainGrid.HeightRequest = height;
        }

        /// <summary>
        /// Raise when click the Share button
        /// </summary>
        /// <param name="o"></param>
        /// <param name="eventArgs"></param>
        private async void ShareViewButtonOnClicked(object o, EventArgs eventArgs)
        {
            try
            {
                shareViewButton.BorderColor = Color.FromHex("#007DE6");
                shareViewButton.TextColor = Color.FromHex("#007DE6");
                this.CollapseSmileys();
                var result = await Application.Current.MainPage.DisplayAlert("Status", "This post has been shared successfully.", null, "Ok");
                if (!result)
                {
                    shareViewButton.BorderColor = Color.FromHex("#979797");
                    shareViewButton.TextColor = Color.Black;
                }
            }
            catch(Exception e)
            {

            }
        }

        /// <summary>
        /// Raise when the frame get collapsed
        /// </summary>
        private void CollapseSmileys()
        {
            likeViewButton.BorderColor = Color.FromHex("#979797");
            likeViewButton.TextColor = Color.Black;
            this.frame.FadeTo(0, 1000, Easing.Linear);
        }
        /// <summary>
        /// Raise when click the follow button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FollowButton_OnClicked(object sender, EventArgs e)
        {
            this.followButton.Text = followButton.Text.Equals("Follow") ? "Following" : "Follow";
            var  selectionColor = Color.FromHex("#007DE6");
            
            if (followButton.Text.Equals("Follow"))
            {
                this.followButton.BorderColor = Color.FromHex("#979797");
                this.followButton.TextColor = Color.Black;
            }
            else
            {
                this.followButton.BorderColor = selectionColor;
                this.followButton.TextColor = selectionColor;
            }
            this.CollapseSmileys();
        }
        /// <summary>
        /// Gesture raised to collapse the frame which contains the smilies
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
        {
            this.CollapseSmileys();
        }
    }
}