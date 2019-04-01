#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using Syncfusion.iOS.Buttons;
using System.Collections.ObjectModel;


#if __UNIFIED__
using Foundation;
using UIKit;
using CoreGraphics;

#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.CoreGraphics;
using nint = System.Int32;
using nuint = System.Int32;
using CGSize = System.Drawing.SizeF;
using CGRect = System.Drawing.RectangleF;
using nfloat  = System.Single;
#endif
namespace SampleBrowser
{
    public class SegementViewGettingStarted : SampleView
    {

        SfSegmentedControl segmentedView,colorSegmentedView,sizeSegmentedView;
        UILabel clothTypeLabel, clothNameLabel, clothPriceLabel, colorLabel, sizeLabel, descriptionLabel, descriptionText, fontIconText;
        internal ObservableCollection<SfSegmentItem> SizeCollection;
        internal ObservableCollection<string> SettingCollection = new ObservableCollection<string>();
        internal ObservableCollection<SfSegmentItem> EntertainCollection = new ObservableCollection<SfSegmentItem>();
        internal ObservableCollection<string> ClothTypeCollection = new ObservableCollection<string>();
        internal ObservableCollection<string> SwitchCollection;
        internal ObservableCollection<SfSegmentItem> PrimaryColors = new ObservableCollection<SfSegmentItem>();
        public SegementViewGettingStarted()
        {
            segmentedView = new SfSegmentedControl();
            colorSegmentedView = new SfSegmentedControl();
            sizeSegmentedView = new SfSegmentedControl();
            fontIconText = new UILabel();
            AddCollection();

            //SegmentedView
            segmentedView.ItemsSource = ClothTypeCollection;
            segmentedView.FontColor = UIColor.Black;
            segmentedView.Font = UIFont.SystemFontOfSize(12);
            segmentedView.CornerRadius = 20;
			segmentedView.SegmentHeight = 40;
            segmentedView.SegmentWidth = 20;
            segmentedView.BackgroundColor = UIColor.Clear;
            segmentedView.VisibleSegmentsCount = 3;
            segmentedView.SelectedIndex = 0;
            segmentedView.BorderThickness = 1;
            segmentedView.BorderColor = UIColor.FromRGB(63, 63, 63);
            segmentedView.SelectionTextColor = UIColor.FromRGB(2, 160, 174);
            segmentedView.SelectionChanged += SegmentedView_SelectionChanged;
            segmentedView.SelectionIndicatorSettings = new SelectionIndicatorSettings()
            {
                Color = UIColor.Clear,
                CornerRadius = 20
            };

            clothTypeLabel = new UILabel();
            clothTypeLabel.Text = "A";
            clothTypeLabel.TextAlignment = UITextAlignment.Center;
            clothTypeLabel.Font = UIFont.FromName("Segmented", 115);
            clothTypeLabel.TextColor = UIColor.FromRGB(0, 141, 127);

            clothNameLabel = new UILabel();
            clothNameLabel.Text = "Best trendy outfits for men.";
            clothNameLabel.Font = UIFont.SystemFontOfSize(12);
            clothNameLabel.TextColor = UIColor.FromRGB(63, 63, 63);
            clothNameLabel.TextAlignment = UITextAlignment.Left;

            clothPriceLabel = new UILabel();
            clothPriceLabel.Text="$300";
            clothPriceLabel.Font=UIFont.FromName("Helvetica-Bold", 10f);

            colorLabel = new UILabel();
            colorLabel.Text = "Color";
            colorLabel.Font = UIFont.FromName("Helvetica-Bold", 10f);

            //ColorSegmentedView
            colorSegmentedView.ItemsSource = PrimaryColors;
            colorSegmentedView.CornerRadius = 3;
            colorSegmentedView.SegmentHeight = 50;
            colorSegmentedView.SegmentWidth = 20;
            colorSegmentedView.BorderThickness = 1;
            colorSegmentedView.BackgroundColor = UIColor.Clear;
            colorSegmentedView.BorderColor = UIColor.FromRGB(238, 238, 238);
            colorSegmentedView.SelectedIndex = 6;
            colorSegmentedView.Font = UIFont.SystemFontOfSize(8);
            colorSegmentedView.FontIconFontColor = UIColor.Black;
            colorSegmentedView.SelectionTextColor = UIColor.FromRGB(0, 141, 127);
            colorSegmentedView.VisibleSegmentsCount = 7;
            colorSegmentedView.SegmentCornerRadius = 15;
            colorSegmentedView.DisplayMode = SegmentDisplayMode.Image;
            colorSegmentedView.SelectionIndicatorSettings = new SelectionIndicatorSettings() { Color = UIColor.FromRGB(238, 238, 238), Position = SelectionIndicatorPosition.Fill };
            colorSegmentedView.SelectionChanged += ColorSegmentedView_SelectionChanged;

            //SizeSegment

            sizeLabel = new UILabel();
            sizeLabel.Text = "Size";
            sizeLabel.Font = UIFont.FromName("Helvetica-Bold", 10f);

            sizeSegmentedView.ItemsSource = SizeCollection;
            sizeSegmentedView.CornerRadius = 25;
            sizeSegmentedView.BorderColor = UIColor.Black;
            sizeSegmentedView.SelectionTextColor =UIColor.White;
            sizeSegmentedView.DisplayMode = SegmentDisplayMode.Image;
            sizeSegmentedView.Font = UIFont.SystemFontOfSize(16);
            sizeSegmentedView.FontIconFontColor = UIColor.Black;
            sizeSegmentedView.VisibleSegmentsCount = 5;
            sizeSegmentedView.SegmentHeight = 50;
            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {

                sizeSegmentedView.BorderThickness = 3;
            }
            else
            {
            sizeSegmentedView.BorderThickness = 1;
            }
            sizeSegmentedView.SegmentWidth = 20;
            sizeSegmentedView.SelectionIndicatorSettings = new SelectionIndicatorSettings() { Color = UIColor.FromRGB(44, 123, 188), Position = SelectionIndicatorPosition.Fill };
          
            //Description Segement

            descriptionLabel = new UILabel();
            descriptionLabel.Text = "Description";
            descriptionLabel.Font = UIFont.FromName("Helvetica-Bold", 10f);

            descriptionText = new UILabel();
            descriptionText.Text = "95% Polyester, 5% Spandex, imported, machine wash, casual wear. This outfit keeps you cool and comfortable in quick-dry fabric that wicks away moisture.";
            descriptionText.Font = UIFont.SystemFontOfSize(10);
            descriptionText.Lines = 5;

            if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
            {
                clothTypeLabel.Font = UIFont.FromName("Segmented", 250);
                clothNameLabel.Font = UIFont.SystemFontOfSize(20);
                clothPriceLabel.Font = UIFont.FromName("Helvetica-Bold", 20f);
                colorLabel.Font = UIFont.FromName("Helvetica-Bold", 20f);
                sizeLabel.Font = UIFont.FromName("Helvetica-Bold", 20f);
                descriptionLabel.Font = UIFont.FromName("Helvetica-Bold", 20f);
                descriptionText.Font = UIFont.SystemFontOfSize(18);
            }

            //Add Views
            this.AddSubview(segmentedView);
            this.AddSubview(clothTypeLabel);
            this.AddSubview(clothNameLabel);
            this.AddSubview(clothPriceLabel);
            this.AddSubview(colorLabel);
            this.AddSubview(colorSegmentedView);
            this.AddSubview(sizeLabel);
            this.AddSubview(sizeSegmentedView);
            this.AddSubview(descriptionLabel);
            this.AddSubview(descriptionText);
        }

        private void AddCollection()
        {
            ClothTypeCollection.Add("Formals");
            ClothTypeCollection.Add("Casuals");
            ClothTypeCollection.Add("Trendy");

            UIFont fontFamily = UIFont.FromName("Segmented", 10f);
            UIFont colorfontFamily = UIFont.FromName("Segoe MDL2 Assets", 32f);

            SwitchCollection = new ObservableCollection<string>() { "", "" };

            SizeCollection = new ObservableCollection<SfSegmentItem>
            {
                new SfSegmentItem(){Text = "A", IconFont="XS"},
                 new SfSegmentItem(){Text = "A", IconFont="S"},
                  new SfSegmentItem(){Text = "A", IconFont="M"},
                   new SfSegmentItem(){Text = "A", IconFont="L"},
                    new SfSegmentItem(){Text = "A", IconFont="XL"},
            };

            SettingCollection = new ObservableCollection<string> { "Off", "Manual", "Auto" };

            EntertainCollection = new ObservableCollection<SfSegmentItem>
            {
                new SfSegmentItem(){IconFont = "A",  FontIconFontColor=UIColor.FromRGB(35,58,126), FontIconFont = fontFamily},
                new SfSegmentItem(){IconFont = "A",  FontIconFontColor=UIColor.FromRGB(126,129,136), FontIconFont = fontFamily},
                new SfSegmentItem(){IconFont = "A",  FontIconFontColor=UIColor.FromRGB(41,38,57), FontIconFont = fontFamily},
                new SfSegmentItem(){IconFont = "A",  FontIconFontColor=UIColor.FromRGB(17,117,109), FontIconFont = fontFamily},
                new SfSegmentItem(){IconFont = "A",  FontIconFontColor=UIColor.FromRGB(110,0,34), FontIconFont = fontFamily},
            };

            PrimaryColors = new ObservableCollection<SfSegmentItem>
            {
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=UIColor.FromRGB(50,49,142), Text="Square",Font=UIFont.SystemFontOfSize(32),  FontIconFont = colorfontFamily},
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=UIColor.FromRGB(47,125,192), Text="Square",Font=UIFont.SystemFontOfSize(32),  FontIconFont = colorfontFamily},
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=UIColor.FromRGB(149,51,118), Text="Square",Font=UIFont.SystemFontOfSize(32),  FontIconFont = colorfontFamily},
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=UIColor.FromRGB(179,63,63), Text="Square",Font=UIFont.SystemFontOfSize(32),  FontIconFont = colorfontFamily},
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=UIColor.FromRGB(241,151,63), Text="Square",Font=UIFont.SystemFontOfSize(32),  FontIconFont = colorfontFamily},
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=UIColor.FromRGB(201,214,86), Text="Square",Font=UIFont.SystemFontOfSize(32),  FontIconFont = colorfontFamily},
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=UIColor.FromRGB(0,141,127), Text="Square",Font=UIFont.SystemFontOfSize(32),  FontIconFont = colorfontFamily},
            };
        }

        public override void LayoutSubviews()
        {

            foreach (var view in this.Subviews)
            {
                view.Frame = Bounds;
                if ((UIDevice.CurrentDevice).UserInterfaceIdiom == UIUserInterfaceIdiom.Pad)
                {
                    segmentedView.Frame = new CGRect(100, 40, view.Frame.Width -230, 40);
                    clothTypeLabel.Frame = new CGRect(230, 130, 300, 250);
                    clothNameLabel.Frame = new CGRect(10, 380, view.Frame.Width, 30);
                    clothPriceLabel.Frame = new CGRect(10, 420, view.Frame.Width, 30);
                    colorLabel.Frame = new CGRect(10, 460, view.Frame.Width, 30);
                    colorSegmentedView.Frame = new CGRect(100, 500, view.Frame.Width-200, 50);
                    sizeLabel.Frame = new CGRect(10, 570, view.Frame.Width, 30);
                    sizeSegmentedView.Frame = new CGRect(100, 600, view.Frame.Width -230, 50);
                    descriptionLabel.Frame = new CGRect(10, 680, view.Frame.Width, 30);
                    descriptionText.Frame = new CGRect(10, 720, view.Frame.Width, 120); 
                }
                else
                {
                    segmentedView.Frame = new CGRect(10, 30, view.Frame.Width-20, 40);
                    clothTypeLabel.Frame = new CGRect(100, 80, 120, 100);
                    clothNameLabel.Frame = new CGRect(5, 200, view.Frame.Width, 10);
                    clothPriceLabel.Frame = new CGRect(5, 215, view.Frame.Width, 15);
                    colorLabel.Frame = new CGRect(5, 240, view.Frame.Width, 10);
                    colorSegmentedView.Frame = new CGRect(5, 260, view.Frame.Width-12, 50);
                    sizeLabel.Frame = new CGRect(5, 320, view.Frame.Width, 10);
                    sizeSegmentedView.Frame = new CGRect(10, 340, view.Frame.Width -20, 50);
                    descriptionLabel.Frame = new CGRect(10, 410, view.Frame.Width, 10);
                    descriptionText.Frame = new CGRect(10, 420, view.Frame.Width, 55);
                }
            }

            base.LayoutSubviews();
        }

        void SegmentedView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var index = e.Index;
            if (index == 0)
            {
                fontIconText.Text = "A";
            }
            else if (index == 1)
            {
                fontIconText.Text = "B";
            }
            else
            {
                fontIconText.Text = "C";
            }

            this.clothTypeLabel.Text = fontIconText.Text;
        }

        void ColorSegmentedView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.colorSegmentedView.SelectionTextColor = PrimaryColors[e.Index].FontIconFontColor;
            this.clothTypeLabel.TextColor = PrimaryColors[e.Index].FontIconFontColor;
        }
    }
}
