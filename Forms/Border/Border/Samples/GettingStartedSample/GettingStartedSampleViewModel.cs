#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.XForms.Buttons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleBrowser.SfBorder
{
    #region View Model for Getting Started Sample
    public class GettingStartedSampleViewModel : INotifyPropertyChanged
    {

        #region Fields
        
        /// <summary>
        /// The border color of button.
        /// </summary>
        private Color borderColor = Color.LightGray;

        /// <summary>
        /// The background color of button.
        /// </summary>
        private Color backgroundColor = Color.FromHex("#2f7dc0");

        /// <summary>
        /// The left side corner radius slider.
        /// </summary>
        private double leftSideValue = 0;

        /// <summary>
        /// The right side corner value
        /// </summary>
        private double rightSideValue = 25;

        /// <summary>
        /// The right side corner value
        /// </summary>
        private double bottomrightSideValue = 0;

        /// <summary>
        /// The right side corner value
        /// </summary>
        private double bottomleftSideValue = 16;

        /// <summary>
        /// The corner radius of button.
        /// </summary>
        private Thickness cornerRadius = 10;

        /// <summary>
        /// Represents the border width
        /// </summary>
        private double borderWidth = 1;

        /// <summary>
        /// Represents the font family
        /// </summary>
        private string SegoeFontFamily;

        /// <summary>
        /// Represents the enable or disable the shadow
        /// </summary>
        private bool enableShadow = false;

        /// <summary>
        /// Represents the border offset
        /// </summary>
        private double borderOffset = 0;

        #endregion

        #region Property

        public ObservableCollection<SfSegmentItem> PrimaryColors { get; set; }

        /// <summary>
        /// Gets or sets the color of the border of button.
        /// </summary>
        /// <value>The color of the border of button.</value>
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }

            set
            {
                borderColor = value;
                OnPropertyChanged("BorderColor");
            }
        }

       
        /// <summary>
        /// Gets or sets the background color of button.
        /// </summary>
        /// <value>The background color of button</value>
        public Color BackgroundColor
        {
            get
            {
                return backgroundColor;
            }
            set
            {
                backgroundColor = value;
                OnPropertyChanged("BackgroundColor");
            }
        }
        
        
        /// <summary>
        /// Gets or sets the slider value.
        /// </summary>
        /// <value>The slider value.</value>
        public double LeftSliderValue
        {
            get
            {
                return leftSideValue;
            }
            set
            {
                leftSideValue = value;
                CornerRadius = new Thickness(value, cornerRadius.Top, cornerRadius.Right, cornerRadius.Bottom);
                OnPropertyChanged("LeftSliderValue");
            }
        }

        /// <summary>
        /// Gets or Sets the right side corner value
        /// </summary>
        public double RightSliderValue
        {
            get
            {
                return rightSideValue;
            }
            set
            {
                rightSideValue = value;
                CornerRadius = new Thickness(cornerRadius.Left, value, cornerRadius.Right, cornerRadius.Bottom);
                OnPropertyChanged("RightSliderValue");
            }
        }

        /// <summary>
        /// Gets or sets the slider value.
        /// </summary>
        /// <value>The slider value.</value>
        public double BottomLeftSliderValue
        {
            get
            {
                return bottomleftSideValue;
            }
            set
            {
                bottomleftSideValue = value;
                CornerRadius = new Thickness(cornerRadius.Left, cornerRadius.Top, cornerRadius.Right, value);
                OnPropertyChanged("BottomLeftSliderValue");
            }
        }

        /// <summary>
        /// Gets or sets the slider value.
        /// </summary>
        /// <value>The slider value.</value>
        public double BottomRightSliderValue
        {
            get
            {
                return bottomrightSideValue;
            }
            set
            {
                bottomrightSideValue = value;
                CornerRadius = new Thickness(cornerRadius.Left, cornerRadius.Top, value, cornerRadius.Bottom);
                OnPropertyChanged("BottomRightSliderValue");
            }
        }
        /// <summary>
        /// Gets or sets the corner radius.
        /// </summary>
        /// <value>The corner radius.</value>
        public Thickness CornerRadius
        {
            get
            {
                return cornerRadius;
            }
            set
            {
                cornerRadius = value;
                OnPropertyChanged("CornerRadius");
            }
        }

        /// <summary>
        /// Gets or sets the border width.
        /// </summary>
        public double BorderWidth
        {
            get
            {
                return borderWidth;
            }
            set
            {
                borderWidth = value;
                OnPropertyChanged("BorderWidth");
            }
        }

        /// <summary>
        /// Gets or sets whether shadow enable or disable
        /// </summary>
        public bool EnableShadow
        {
            get
            {
                return enableShadow;
            }
            set
            {
                enableShadow = value;
                OnPropertyChanged("EnableShadow");
            }
        }

        /// <summary>
        /// Gets or sets the border offset.
        /// </summary>
        public double BorderOffset
        {
            get
            {
                return borderOffset;
            }
            set
            {
                borderOffset = value;
                OnPropertyChanged("BorderOffset");
            }
        }


        #endregion

        #region Property changed method

        /// <summary>
        /// Occurs when property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The <see cref=" buttonViewModel" properties changed/>
        /// </summary>
        /// <param name="property">Changed Property.</param>
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="T:button.buttonViewModel"/> class.
        /// </summary>
        public GettingStartedSampleViewModel()
        {
            this.SegoeFontFamily = "border_Segoe MDL2 Assets.ttf";
            if (Device.RuntimePlatform == Device.UWP || (Device.RuntimePlatform == Device.iOS))
            {

                    this.SegoeFontFamily = "Segoe MDL2 Assets";
            }

            this.PrimaryColors = GetSegmentCollection();

        }

        private ObservableCollection<SfSegmentItem> GetSegmentCollection()
        {
            ObservableCollection<SfSegmentItem> segmentCollection = new ObservableCollection<SfSegmentItem>
            {
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#cccccc"), Text="Square",FontIconFontSize=32,  FontIconFontFamily = SegoeFontFamily},
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#32318e"), Text="Square",FontIconFontSize=32,  FontIconFontFamily = SegoeFontFamily},
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#963376"), Text="Square",FontIconFontSize=32,  FontIconFontFamily = SegoeFontFamily},
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#b53f3f"), Text="Square",FontIconFontSize=32,  FontIconFontFamily = SegoeFontFamily},
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#f19741"), Text="Square",FontIconFontSize=32,  FontIconFontFamily = SegoeFontFamily},
            };

            return segmentCollection;
        }
        #endregion
    }

    #endregion
}
