#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Syncfusion.Core.XForms;
using Avatar = Syncfusion.XForms.AvatarView;
using Syncfusion.XForms.AvatarView;
using Syncfusion.XForms.Graphics;

namespace SampleBrowser.SfAvatarView
{
    #region Getting Started Sample Class
    public partial class AvatarGettingStartedSample : SampleView
    {

        private bool useDefinedAvatar = false;

        public bool UseDefinedAvatar
        {
            get
            {
                return useDefinedAvatar;
            }
            set
            {
                useDefinedAvatar = value;

                if (value)
                {
                    UseCustomAvatar = false;
                    UseInitialAvatar = true;
                    ContentType = ContentType.AvatarCharacter;
                }
                else if (!UseCustomAvatar)
                {
                    ContentType = ContentType.Initials;
                    UseInitialAvatar = true;
                }


                this.OnPropertyChanged();
            }
        }

        private SfGradientBrush gradientBrush;

        public SfGradientBrush GradientBrush
        {
            get
            {
                return gradientBrush;
            }
            set
            {
                gradientBrush = value;
                this.OnPropertyChanged();
            }
        }


        private bool useCustomAvatar = false;

        public bool UseCustomAvatar
        {
            get
            {
                return useCustomAvatar;
            }
            set
            {
                useCustomAvatar = value;

                if (value)
                {
                    UseDefinedAvatar = false;
                    UseInitialAvatar = false;
                    ContentType = ContentType.Custom;
                }
                else if (!UseDefinedAvatar)
                {
                    ContentType = ContentType.Initials;
                    UseInitialAvatar = true;
                }

                this.OnPropertyChanged();
            }
        }

        private ContentType contentType;

        public ContentType ContentType
        {
            get
            {
                return contentType;
            }
            set
            {
                contentType = value;
                this.OnPropertyChanged();
            }
        }

        private AvatarCharacter definedAvatarItem;

        public AvatarCharacter DefinedAvatarItem
        {
            get
            {
                return definedAvatarItem;
            }
            set
            {
                definedAvatarItem = value;
                this.OnPropertyChanged();
            }
        }

        private bool editionIsVisible = true;

        public bool EditionIsVisible
        {
            get
            {
                return editionIsVisible;
            }
            set
            {
                editionIsVisible = value;
                this.OnPropertyChanged();
            }
        }

        private bool useInitialAvatar = true;

        public bool UseInitialAvatar
        {
            get
            {
                return useInitialAvatar;
            }
            set
            {
                useInitialAvatar = value;
                if (value)
                    ColorPickerOpacity = 1;
                else
                    ColorPickerOpacity = 0.3;
                this.OnPropertyChanged();
            }
        }

        private bool useGradients;

        public bool UseGradients
        {
            get
            {
                return useGradients;
            }
            set
            {
                useGradients = value;

                SetGradients();
                SetColorToAvatar();

                this.OnPropertyChanged();
            }
        }



        private String firstName = "Ellana";

        public String FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                UserName = FirstName + " " + LastName;
                this.OnPropertyChanged();
            }
        }

        private String lastName;

        public String LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                UserName = FirstName + " " + LastName;
                this.OnPropertyChanged();
            }
        }


        private String userName;

        public String UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
                TitleText = value;
                this.OnPropertyChanged();
            }
        }


        private String titleText;

        public String TitleText
        {
            get
            {
                if (UserName == String.Empty || UserName == " ")
                    return String.Empty;
                return "Hi " + titleText;
            }
            set
            {
                titleText = value;
                this.OnPropertyChanged();
            }
        }

        private Color profileColor;

        public Color ProfileColor
        {
            get
            {
                return profileColor;
            }
            set
            {
                profileColor = value;
                this.OnPropertyChanged();
            }
        }

        private Color textColor;

        public Color TextColor
        {
            get
            {
                return textColor;
            }
            set
            {
                textColor = value;
                this.OnPropertyChanged();
            }
        }

        private double colorPickerOpacity = 1;

        public double ColorPickerOpacity
        {
            get
            {
                return colorPickerOpacity;
            }
            set
            {
                colorPickerOpacity = value;
                this.OnPropertyChanged();
            }
        }



        private ObservableCollection<ColorBackgroundAvatar> colorItemCollection = new ObservableCollection<ColorBackgroundAvatar>();

        public ObservableCollection<ColorBackgroundAvatar> ColorItemCollection
        {
            get
            {
                return colorItemCollection;
            }
            set
            {
                colorItemCollection = value;
                this.OnPropertyChanged();
            }
        }

        private ObservableCollection<Avatar.SfAvatarView> definedAvatarCollection = new ObservableCollection<Avatar.SfAvatarView>();

        public ObservableCollection<Avatar.SfAvatarView> DefinedAvatarCollection
        {
            get
            {
                return definedAvatarCollection;
            }
            set
            {
                definedAvatarCollection = value;
                this.OnPropertyChanged();
            }
        }

        public AvatarGettingStartedSample()
        {
            InitializeComponent();
            this.cmdButton.Clicked += CmdButton_Clicked;
            this.StatusIndicatorSwitch.Toggled += StatusIndicatorSwitch_Toggled;
            this.BindingContext = this;
            PopulateCollection();

            tappedAvatar = ColorItemCollection[0];
            DefinedAvatarCollection[0].BorderWidth = 1;
            DefinedAvatarCollection[0].BorderColor = Color.FromHex("#9E9E9E");

            UseGradients = true;

            if(Device.Idiom == TargetIdiom.Tablet )
            {    
                gradientcollection.Margin = 70;
                definedcollection.Margin = 70;
           }
        }

        private void StatusIndicatorSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if (this.StatusIndicatorSwitch.IsToggled)
            {
                this.StatusBadge.BadgeSettings.BadgeIcon = Syncfusion.XForms.BadgeView.BadgeIcon.Available;
            }
            else
            {
                this.StatusBadge.BadgeSettings.BadgeIcon = Syncfusion.XForms.BadgeView.BadgeIcon.None;
            }
        }

        private void PopulateCollection()
        {
            for(int i = 1; i<=10;i++)
            {
                DefinedAvatarCollection.Add(GetDefinedAvatarItem("Avatar" + i));
            }            
            PopulateColorCollection();
        }

        private void PopulateColorCollection()
        {
            ColorItemCollection.Clear();

            ColorItemCollection.Add(GetColorPickerItem(Color.FromHex("#976F0C"),Color.FromHex("#58B7C6"), Color.FromHex("#7FB3E8")));
            ColorItemCollection.Add(GetColorPickerItem(Color.FromHex("#740A1C"),Color.FromHex("#95479B"), Color.FromHex("#FF8F8F")));
            ColorItemCollection.Add(GetColorPickerItem(Color.FromHex("#5C2E91"),Color.FromHex("#3C7F91"), Color.FromHex("#71B280")));
            ColorItemCollection.Add(GetColorPickerItem(Color.FromHex("#004E8C"),Color.FromHex("#525CE5"), Color.FromHex("#9437C3")));
            ColorItemCollection.Add(GetColorPickerItem(Color.FromHex("#B73EAA"),Color.FromHex("#80C6CF"), Color.FromHex("#87DFAC")));
            ColorItemCollection.Add(GetColorPickerItem(Color.FromHex("#90DDFE"),Color.FromHex("#E7A8FA"), Color.FromHex("#F3DED6")));
            ColorItemCollection.Add(GetColorPickerItem(Color.FromHex("#9FCC69"),Color.FromHex("#FFDBC7"), Color.FromHex("#FC9F9F")));
            ColorItemCollection.Add(GetColorPickerItem(Color.FromHex("#FCCE65"),Color.FromHex("#A6F0FF"), Color.FromHex("#BCC1FF")));
            ColorItemCollection.Add(GetColorPickerItem(Color.FromHex("#FE9B90"),Color.FromHex("#BCC2F4"), Color.FromHex("#E8BEF7")));
            ColorItemCollection.Add(GetColorPickerItem(Color.FromHex("#9AA8F5"),Color.FromHex("#96E6A1"), Color.FromHex("#DCFA97")));

        }

        private Avatar.SfAvatarView GetDefinedAvatarItem(String avatar)
        {
            Avatar.SfAvatarView defaultAvatar = new Avatar.SfAvatarView();
            defaultAvatar.AvatarShape = AvatarShape.Circle;
            defaultAvatar.AvatarSize = AvatarSize.Medium;
            defaultAvatar.VerticalOptions = LayoutOptions.Center;
            defaultAvatar.HorizontalOptions = LayoutOptions.Center;
            defaultAvatar.BorderWidth = 5;
            defaultAvatar.BorderColor = Color.White;
            defaultAvatar.ContentType = ContentType.AvatarCharacter;
            defaultAvatar.AvatarCharacter = (AvatarCharacter)Enum.Parse(typeof(AvatarCharacter), avatar, true);

            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;
            defaultAvatar.GestureRecognizers.Add(tapGestureRecognizer);

            return defaultAvatar;
        }

     

        private ColorBackgroundAvatar GetColorPickerItem(Color backgroundColor, Color startcolor, Color stopcolor)
        {
            ColorBackgroundAvatar colorAvatar = new ColorBackgroundAvatar();
            colorAvatar.BackgroundColor = backgroundColor;
            colorAvatar.BorderColor = Color.FromHex("#9E9E9E");
            colorAvatar.InitialsColor = Color.Transparent;
            colorAvatar.AvatarShape = AvatarShape.Circle;
            colorAvatar.AvatarSize = AvatarSize.Medium;
            colorAvatar.VerticalOptions = LayoutOptions.Center;
            colorAvatar.HorizontalOptions = LayoutOptions.Center;
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += ColorTapGestureRecognizer_Tapped;
            colorAvatar.GestureRecognizers.Add(tapGestureRecognizer);

            colorAvatar.StartColor = startcolor;
            colorAvatar.StopColor = stopcolor;
            return colorAvatar;
        }

        private void SetGradients()
        {
            foreach (var item in ColorItemCollection)
            {
                if (this.UseGradients)
                    if (ColorItemCollection.IndexOf(item) < 5)
                        item.BackgroundGradient = GetGradients(item.StartColor,item.StopColor);
                    else
                        item.BackgroundGradient = GetGradients(item.StartColor, item.StopColor);
                else
                    item.BackgroundGradient = null;
            }
        }

        private SfLinearGradientBrush GetGradients(Color startColor, Color endColor)
        {
            SfLinearGradientBrush linearGradientBrush = new SfLinearGradientBrush();
            linearGradientBrush.GradientStops = new GradientStopCollection()
            {
                new SfGradientStop(){Color = startColor, Offset=0.0},
                new SfGradientStop(){Color = endColor, Offset=1.0},
            };

            return linearGradientBrush;
        }

        Avatar.SfAvatarView tappedAvatarView;

        ColorBackgroundAvatar tappedAvatar;

        
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            tappedAvatarView = (sender as Avatar.SfAvatarView);

            if (tappedAvatarView.ContentType == ContentType.AvatarCharacter)
            {
                SetDefaultAvatar();
            }
            else
            {
                SetColorToAvatar();
            }
        }


        private void ColorTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            tappedAvatar = (sender as ColorBackgroundAvatar);

            if (tappedAvatar.ContentType == ContentType.AvatarCharacter)
            {
                SetDefaultAvatar();
            }
            else
            {
                SetColorToAvatar();
            }
        }

        private void SetDefaultAvatar()
        {
            foreach (var item in DefinedAvatarCollection)
            {
                item.BorderWidth = 5;
                item.BorderColor = Color.White;
            }

            tappedAvatarView.BorderWidth = 1;
            tappedAvatarView.BorderColor = Color.FromHex("#9E9E9E");
            DefinedAvatarItem = tappedAvatarView.AvatarCharacter;
        }

        private void SetColorToAvatar()
        {
            if (tappedAvatar == null)
                return;

            foreach (var item in ColorItemCollection)
            {
                item.InitialsColor = Color.Transparent;
            }

            if (ColorItemCollection.IndexOf(tappedAvatar) < 5)
                tappedAvatar.InitialsColor = Color.White;
            else
                tappedAvatar.InitialsColor = Color.Black;


            ProfileColor = tappedAvatar.BackgroundColor;
            TextColor = tappedAvatar.InitialsColor;
            if (UseGradients)
            {
                GradientBrush = tappedAvatar.BackgroundGradient;
            }
            else
            {
                GradientBrush = null;
            }
        }

        private void CmdButton_Clicked(object sender, EventArgs e)
        {
            if ((sender as Button).Text == "Edit Profile")
            {
                (sender as Button).Text = "Done";
                EditionIsVisible = true;
            }
            else
            {
                (sender as Button).Text = "Edit Profile";
                EditionIsVisible = false;
            }
        }

        public class ColorBackgroundAvatar : Avatar.SfAvatarView
        {
            private Color startColor;

            public Color StartColor
            {
                get
                {
                    return startColor;
                }
                set
                {
                    startColor = value;
                    this.OnPropertyChanged();
                }
            }

            private Color stopcolor;

            public Color StopColor
            {
                get
                {
                    return stopcolor;
                }
                set
                {
                    stopcolor = value;
                    this.OnPropertyChanged();
                }
            }
        }
    }

    #endregion
}