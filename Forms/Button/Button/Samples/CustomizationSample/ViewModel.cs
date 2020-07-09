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

namespace SampleBrowser.SfButton
{
    #region View Model for Getting Started Sample
    public class ViewModel : INotifyPropertyChanged
    {

        #region Fields
        
        /// <summary>
        /// The border color of button.
        /// </summary>
        private Color borderColor = Color.Black;

        /// <summary>
        /// The background color of button.
        /// </summary>
        private Color backgroundColor = Color.FromHex("#af2463");

        /// <summary>
        /// Represents the text color
        /// </summary>
        private Color textColor = Color.White;

        /// <summary>
        /// The border thickness of button.
        /// </summary>
        private double borderThickness = 0;

        /// <summary>
        /// The left side corner radius slider.
        /// </summary>
        private double leftSideValue = 25;

        /// <summary>
        /// The right side corner value
        /// </summary>
        private double rightSideValue = 25;

        /// <summary>
        /// The corner radius of button.
        /// </summary>
        private Thickness cornerRadius = 20;

        /// <summary>
        /// The text of button.
        /// </summary>
        private string text = "ADD TO CART";
        
        /// <summary>
        /// The can show background image
        /// </summary>
        private bool canShowBackgroundImage = false;

        /// <summary>
        /// Represents the font family
        /// </summary>
        private string SegoeFontFamily;

        /// <summary>
        /// Represents the border width
        /// </summary>
        private double borderWidth = 1;

        /// <summary>
        /// Represents the visibility of image
        /// </summary>
        private bool showImage = true;

        /// <summary>
        /// Represents the enable or disable the shadow
        /// </summary>
        private bool enableShadow;
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
        /// Gets or Sets the text color
        /// </summary>
        public Color TextColor
        {
            get
            {
                return textColor;
            }

            set
            {
                textColor = value;
                OnPropertyChanged("TextColor");
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
        /// Gets or sets the thickness of border.
        /// </summary>
        /// <value>The border thickness.</value>
        public double BorderThickness
        {
            get
            {
                return borderThickness;
            }
            set
            {
                borderThickness = value;
                OnPropertyChanged("BorderThickness");
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
                CornerRadius = new Thickness(value, cornerRadius.Top, cornerRadius.Right, value);
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
                CornerRadius = new Thickness(cornerRadius.Left, value, value, cornerRadius.Bottom);
                OnPropertyChanged("RightSliderValue");
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
                StepValue = value;
                OnPropertyChanged("BorderWidth");
            }
        }

        /// <summary>
        /// Gets or Sets the image visibility
        /// </summary>
        public bool ShowImage
        {
            get
            {
                return showImage;
            }
            set
            {
                showImage = value;
               
                OnPropertyChanged("ShowImage");
            }
        }
        

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:button.buttonViewModel"/> is enable stack.
        /// </summary>
        /// <value><c>true</c> if is enable stack; otherwise, <c>false</c>.</value>
        public bool CanShowBackgroundImage
        {
            get
            {
                return canShowBackgroundImage;
            }
            set
            {
                canShowBackgroundImage = value;
                if (value)
                {
                    BackgroudImage = "buttonbackground.png";
                }
                else
                {
                    BackgroudImage = string.Empty;
                }
                OnPropertyChanged("CanShowBackgroundImage");
                OnPropertyChanged("BackgroudImage");
            }
        }

        /// <summary>
        /// Source for transparent background
        /// </summary>
        public string BackgroudImage { get; set; }

        private double _stepValue;

        public double StepValue
        {
            get { return _stepValue; }
            set
            {
                if (!value.ToString().Contains(".") || value.ToString().Contains(".0"))
                {
                    _stepValue = (int)value;
                }
                OnPropertyChanged("StepValue");
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
        public ViewModel()
        {
            this.SegoeFontFamily = "button_Segoe MDL2 Assets.ttf";
            if (Device.RuntimePlatform == Device.UWP)
            {
#if COMMONSB
                this.SegoeFontFamily = "/Assets/Fonts/button_Segoe MDL2 Assets.ttf.ttf#Segoe MDL2 Assets";
#else
                if (Core.SampleBrowser.IsIndividualSB)
                {
                    this.SegoeFontFamily = "/Assets/Fonts/button_Segoe MDL2 Assets.ttf#Segoe MDL2 Assets";
                }
                else
                {
                    this.SegoeFontFamily = $"ms-appx:///SampleBrowser.SfButton.UWP/Assets/Fonts/button_Segoe MDL2 Assets.ttf#Segoe MDL2 Assets";
                }
#endif
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                this.SegoeFontFamily = "Segoe MDL2 Assets";
            }

            this.PrimaryColors = GetSegmentCollection();
        }

        private ObservableCollection<SfSegmentItem> GetSegmentCollection()
        {
            ObservableCollection<SfSegmentItem> segmentCollection = new ObservableCollection<SfSegmentItem>
            {
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#ffffff"), Text="Square",FontIconFontSize=32,  FontIconFontFamily = SegoeFontFamily},
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#c6c6c6"), Text="Square",FontIconFontSize=32,  FontIconFontFamily = SegoeFontFamily},
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#538eed"), Text="Square",FontIconFontSize=32,  FontIconFontFamily = SegoeFontFamily},
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#af2463"), Text="Square",FontIconFontSize=32,  FontIconFontFamily = SegoeFontFamily},
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#000000"), Text="Square",FontIconFontSize=32,  FontIconFontFamily = SegoeFontFamily},
            };

            return segmentCollection;
        }
        #endregion
    }

    #endregion
}
