#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Syncfusion.XForms.Border;
using Syncfusion.XForms.Buttons;
using Xamarin.Forms;

namespace SampleBrowser.Chips
{
    /// <summary>
    /// Represents the view model class for holding binding variables from Chip.
    /// </summary>
    public class ChipViewModel : INotifyPropertyChanged
    {
        #region properties

        /// <summary>
        /// The icon property to hold the chip image.
        /// </summary>
		private string icon = "UserContact.png";

        /// <summary>
        /// The property to identify whether left checkbox has been checkde or not.
        /// </summary>
        private bool isLeftCheckBox = true;

        /// <summary>
        /// The television collection.
        /// </summary>
        internal ObservableCollection<string> televisionItems = new ObservableCollection<string>() { "Samsung", "LG" };

        /// <summary>
        /// The washer collection.
        /// </summary>
        internal ObservableCollection<string> washserItems = new ObservableCollection<string>() { "Whirlpool", "Kenmore" };

        /// <summary>
        /// The air conditioner collection.
        /// </summary>
        internal ObservableCollection<string> airConditionerItems = new ObservableCollection<string>() { "Mitsubishi", "Hitachi" };

        /// <summary>
        /// The choice collection.
        /// </summary>
        private List<string> choiceItems = new List<string>() { "Washer", "Television", "Air Conditioner" };

        /// <summary>
        /// The result.
        /// </summary>
        private string result = "No results found";

        /// <summary>
        /// The border color of chip.
        /// </summary>
        private Color borderColor = Color.Black;

        /// <summary>
        /// The background color of chip.
        /// </summary>
        private Color backgroundColor = Color.FromHex("#af2463");

        /// <summary>
        /// Represents the text color
        /// </summary>
        private Color textColor = Color.White;

        /// <summary>
        /// Represents the visibility of image
        /// </summary>
        private bool showImage = true;

        /// <summary>
        /// Represents the font family
        /// </summary>
        private string SegoeFontFamily;

        /// <summary>
        /// The border thickness of chip.
        /// </summary>
        private double borderThickness = 1;

        /// <summary>
        /// The corner radius slider.
        /// </summary>
        private double cornerRadiusSlider = 20;

        /// <summary>
        /// The corner radius of chip.
        /// </summary>
        private Thickness cornerRadius = 20;

        /// <summary>
        /// The default corner radius.
        /// </summary>
        private double defaultCornerRadius = 20;

        /// <summary>
        /// The maximum.
        /// </summary>
        private double maximum = 20;

        /// <summary>
        /// Represents the border width
        /// </summary>
        private double borderWidth = 0;

        /// <summary>
        /// The text of chip.
        /// </summary>
        private string text = "JAMES";

        /// <summary>
        /// The is show visual.
        /// </summary>
        private bool isShowVisual = false;

        /// <summary>
        /// The is show.
        /// </summary>
        private bool isShow = true;

        /// <summary>
        /// The input text.
        /// </summary>
        private string inputText = "";

        /// <summary>
        /// The visual mode.
        /// </summary>
        private string visualMode = "None";

        /// <summary>
        /// The is shown close button.
        /// </summary>
        private bool isShownCloseButton = true;

        /// <summary>
        /// The selected item.
        /// </summary>
        private object selectedItem = "Television";

        /// <summary>
        /// The selected items.
        /// </summary>
        private List<string> selectedItems = new List<string>();

        /// <summary>s
        /// The input collection.
        /// </summary>
        private ObservableCollection<string> brands;

        /// <summary>
        /// The filter collection.
        /// </summary>
        private List<string> filterChips = new List<string>();

        /// <summary>
        /// The action collection.
        /// </summary>
        private List<string> actionChips = new List<string>() { "Search by brands", "Search by features" };

        /// <summary>
        /// The action command.
        /// </summary>
        private ICommand actionCommand;

        /// <summary>
        /// The place holder text.
        /// </summary>
        private string placeHolderText = "Type a brand";

        /// <summary>
        /// Gets or sets the primary colors.
        /// </summary>
        /// <value>The primary colors.</value>
        public ObservableCollection<SfSegmentItem> PrimaryColors { get; set; }

        /// <summary>
        /// Gets or sets the primary text colors.
        /// </summary>
        /// <value>The primary text colors.</value>
        public ObservableCollection<SfSegmentItem> PrimaryTextColors { get; set; }

        /// <summary>
        /// Gets or sets the stepvalue field
        /// </summary>
        private double stepValue;
        #endregion

        #region Fields

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
        /// Gets or sets the icon.
        /// </summary>
        /// <value>The chip icon.</value>
        public string Icon
        {
            get
            {
                return icon;
            }

            set
            {
                icon = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Chip.ViewModel"/> is left check box.
        /// </summary>
        /// <value><c>true</c> if is left check box; otherwise, <c>false</c>.</value>
        public bool IsLeftCheckBox
        {
            get
            {
                return isLeftCheckBox;
            }
            set
            {
                isLeftCheckBox = value;
                this.SliderValue = value == true ? cornerRadius.Left : cornerRadius.Top;
                OnPropertyChanged("IsLeftCheckBox");
            }
        }

        /// <summary>
        /// Gets or sets the color of the border of chip.
        /// </summary>
        /// <value>The color of the border of chip.</value>
        public Color BorderColorProperty
        {
            get
            {
                return borderColor;
            }

            set
            {
                borderColor = value;
                OnPropertyChanged("BorderColorProperty");
            }
        }

        /// <summary>
        /// Gets or sets the background color of chip.
        /// </summary>
        /// <value>The background color of chip</value>
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
                StepValue = value;
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
                return defaultCornerRadius;
            }
            set
            {
                defaultCornerRadius = value;
                CornerRadius = new Thickness(value, cornerRadius.Top, cornerRadius.Right, value);
                OnPropertyChanged("LeftSliderValue");
            }
        }

       /// <summary>
       /// Gets or sets the maximum.
       /// </summary>
       /// <value>The maximum.</value>
        public double Maximum
        {
            get
            {
                return maximum;
                
            }
            set
            {
                maximum = value;
                OnPropertyChanged("Maximum");
            }
        }
        /// <summary>
        /// Gets or sets the slider value.
        /// </summary>
        /// <value>The slider value.</value>
        public double SliderValue
        {
            get
            {
                return cornerRadiusSlider;
            }
            set
            {
                cornerRadiusSlider = value;
                CornerRadius = new Thickness(cornerRadius.Left, value, value, cornerRadius.Bottom);
                OnPropertyChanged("SliderValue");
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
        /// Gets or sets a value indicating whether this <see cref="T:Chip.ChipViewModel"/> is show.
        /// </summary>
        /// <value><c>true</c> if is show; otherwise, <c>false</c>.</value>
        public bool IsShownIcon
        {
            get
            {
                return isShow;
            }
            set
            {
                isShow = value;
                OnPropertyChanged("IsShownIcon");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Chip.ChipViewModel"/> is show visual.
        /// </summary>
        /// <value><c>true</c> if is show visual; otherwise, <c>false</c>.</value>
        public bool IsShownSelection
        {
            get
            {
                return isShowVisual;
            }
            set
            {
                isShowVisual = value;
                OnPropertyChanged("IsShownSelection");
            }
        }


        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Chip.ChipViewModel"/> is show visual.
        /// </summary>
        /// <value><c>true</c> if is show visual; otherwise, <c>false</c>.</value>
        public bool IsShownCloseButton
        {
            get
            {
                return isShownCloseButton;
            }
            set
            {
                isShownCloseButton = value;
                OnPropertyChanged("IsShownCloseButton");
            }
        }


        /// <summary>
        /// Gets or sets the visual mode.
        /// </summary>
        /// <value>The visual mode.</value>
        public string VisualMode
        {
            get
            {
                return visualMode;
            }
            set
            {
                visualMode = value;
                OnPropertyChanged("VisualMode");
            }
        }

        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        /// <value>The selected item.</value>
        public object SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                if (selectedItem != null)
                {
                    if (!string.IsNullOrEmpty("SelectedItem"))
                    {
                        if (selectedItem.Equals("Television"))
                        {
                            InputItems = televisionItems;
                            FilterItems = new List<string>() { "LED", "LCD", "WIFI", "4K", "Ultra HD" };
                            InputText = InputItems.Contains("Lenovo") ? "Type a brand" : "Lenovo";
                        }
                        else if (selectedItem.Equals("Washer"))
                        {
                            InputItems = washserItems;
                            FilterItems = new List<string>() { "Front Load", "Top Load" };
                            InputText = InputItems.Contains("Maytag") ? "Type a brand" : "Maytag";
                        }
                        else if (selectedItem.Equals("Air Conditioner"))
                        {
                            InputItems = airConditionerItems;
                            FilterItems = new List<string>() { "Window", "Portable", "Hybrid" };
                            InputText = InputItems.Contains("Voltas") ? "Type a brand" : "Voltas";
                        }
                    }
                    selectedItems.Clear();
                }
                Result = "No results found";
                OnPropertyChanged("SelectedItem");
            }
        }

        /// <summary>
        /// Gets or sets the input text.
        /// </summary>
        /// <value>The input text.</value>
        public string InputText
        {
            get
            {
                return inputText;
            }
            set
            {
                inputText = value;
                OnPropertyChanged("InputText");
            }
        }

        /// <summary>
        /// Gets or sets the action command.
        /// </summary>
        /// <value>The action command.</value>
        public ICommand ActionCommand
        {
            get
            {
                return actionCommand;
            }
            set
            {
                actionCommand = value;
            }
        }

        /// <summary>
        /// Gets or sets the place holder text.
        /// </summary>
        /// <value>The place holder text.</value>
        public string PlaceHolderText
        {
            get
            {
                return placeHolderText;
            }
            set
            {
                placeHolderText = value;
                OnPropertyChanged("PlaceHolderText");
            }
        }

        /// <summary>
        /// Gets or sets the input collection.
        /// </summary>
        /// <value>The input collection.</value>
        public ObservableCollection<string> InputItems
        {
            get
            {
                return brands;
            }
            set
            {
                brands = value;
                if (brands != null && brands.Count == 0)
                {
                    filterChips.Clear();
                    Result = "No results found";

                }

                OnPropertyChanged("InputItems");
            }
        }

        /// <summary>
        /// Gets or sets the filter collection.
        /// </summary>
        /// <value>The filter collection.</value>
        public List<string> FilterItems
        {
            get
            {
                return filterChips;
            }
            set
            {
                filterChips = value;
                OnPropertyChanged("FilterItems");
            }
        }

        /// <summary>
        /// Gets or sets the action collection.
        /// </summary>
        /// <value>The action collection.</value>
        public List<string> ActionItems
        {
            get
            {
                return actionChips;
            }
            set
            {
                actionChips = value;
                OnPropertyChanged("ActionItems");
            }
        }

        /// <summary>
        /// Gets or sets the selected items.
        /// </summary>
        /// <value>The selected items.</value>
        public List<string> SelectedItems
        {
            get
            {
                return selectedItems;
            }
            set
            {
                selectedItems = value;
                OnPropertyChanged("SelectedItems");
            }
        }

        /// <summary>
        /// Gets or sets the choice collection.
        /// </summary>
        /// <value>The choice collection.</value>
        public List<string> ChoiceItems
        {
            get
            {
                return choiceItems;
            }
            set
            {
                choiceItems = value;
                OnPropertyChanged("ChoiceItems");
            }
        }

        /// <summary>
        /// Gets or sets the result.
        /// </summary>
        /// <value>The result.</value>
        public string Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
                OnPropertyChanged("Result");
            }
        }


        /// <summary>
        /// Gets or sets the step value slider
        /// </summary>
        public double StepValue
        {
            get { return stepValue; }
            set
            {
                if (!value.ToString().Contains(".") || value.ToString().Contains(".0"))
                {
                    stepValue = (int)value;
                }
                OnPropertyChanged("StepValue");
            }
        }

        #endregion

        /// <summary>
        /// Occurs when property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The <see cref=" ChipViewModel" properties changed/>
        /// </summary>
        /// <param name="property">Changed Property.</param>
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Chip.ChipViewModel"/> class.
        /// </summary>
        public ChipViewModel()
        {
            ActionCommand = new Command(HandleAction);

            this.SegoeFontFamily = "chip_Segoe MDL2 Assets.ttf";
            if (Device.RuntimePlatform == Device.UWP)
            {
#if COMMONSB
                this.SegoeFontFamily = "/Assets/Fonts/chip_Segoe MDL2 Assets.ttf.ttf#Segoe MDL2 Assets";
#else
                if (Core.SampleBrowser.IsIndividualSB)
                {
                    this.SegoeFontFamily = "/Assets/Fonts/chip_Segoe MDL2 Assets.ttf#Segoe MDL2 Assets";
                }
                else
                {
                    this.SegoeFontFamily = $"ms-appx:///SampleBrowser.Chips.UWP/Assets/Fonts/chip_Segoe MDL2 Assets.ttf#Segoe MDL2 Assets";
                }
#endif
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                this.SegoeFontFamily = "Segoe MDL2 Assets";
            }

            this.PrimaryColors = GetSegmentCollection();
            this.PrimaryTextColors = GetSegmentTextCollection();
        }

        /// <summary>
        /// Gets the segment collection.
        /// </summary>
        /// <returns>The segment collection.</returns>
        private ObservableCollection<SfSegmentItem> GetSegmentCollection()
        {
            ObservableCollection<SfSegmentItem> segmentColorItems = new ObservableCollection<SfSegmentItem>
            {
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#c6c6c6"), Text="Square",FontIconFontSize=32,  FontIconFontFamily = SegoeFontFamily},
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#538eed"), Text="Square",FontIconFontSize=32,  FontIconFontFamily = SegoeFontFamily},
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#af2463"), Text="Square",FontIconFontSize=32,  FontIconFontFamily = SegoeFontFamily},
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#000000"), Text="Square",FontIconFontSize=32,  FontIconFontFamily = SegoeFontFamily},
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.Accent, Text="Square",FontIconFontSize=32,  FontIconFontFamily = SegoeFontFamily}
            };

            return segmentColorItems;
        }

        private ObservableCollection<SfSegmentItem> GetSegmentTextCollection()
        {
            ObservableCollection<SfSegmentItem> segmentColorItems = new ObservableCollection<SfSegmentItem>
            {
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#ffffff"), Text="Square",FontIconFontSize=32,  FontIconFontFamily = SegoeFontFamily},
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#c6c6c6"), Text="Square",FontIconFontSize=32,  FontIconFontFamily = SegoeFontFamily},
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#538eed"), Text="Square",FontIconFontSize=32,  FontIconFontFamily = SegoeFontFamily},
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#af2463"), Text="Square",FontIconFontSize=32,  FontIconFontFamily = SegoeFontFamily},
                new SfSegmentItem(){IconFont = "\uE91F",  FontIconFontColor=Color.FromHex("#000000"), Text="Square",FontIconFontSize=32,  FontIconFontFamily = SegoeFontFamily},
            };

            return segmentColorItems;
        }

        /// <summary>
        /// Handles the action.
        /// </summary>
        /// <param name="obj">Object.</param>
        void HandleAction(object obj)
        {
            Result = string.Empty;

            if (obj.ToString().Equals("Search by brands"))
            {
                foreach (var brand in brands)
                {
                    Result += new Random().Next(1, 5).ToString() + " " + brand.ToString() + " " + selectedItem.ToString() + " found" + "\n";
                }
            }
            else
            {
                if (selectedItems.Count > 0)
                {
                    foreach (var feature in selectedItems)
                    {
                        foreach (var brand in brands)
                        {
                            Result += new Random().Next(1, 5).ToString() + " " + feature.ToString() + " " + selectedItem.ToString() + " found in " + brand.ToString() + "\n";
                        }
                    }
                }
                else
                {
                    Result = "No results found.";
                }
            }
            if (Result.Contains("\n"))
            {
                Result = Result.Remove(Result.Length - 1);
            }
        }
    }
}
