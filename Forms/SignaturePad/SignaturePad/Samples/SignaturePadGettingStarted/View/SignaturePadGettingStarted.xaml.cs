#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SampleBrowser.Core;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using Syncfusion.XForms.Border;
using Avatar =  Syncfusion.XForms.AvatarView;
using System.Globalization;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SampleBrowser.SfSignaturePad
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignaturePadGettingStarted : SampleView
    {
        ViewModel view = new ViewModel();
        public SignaturePadGettingStarted()
        {
            InitializeComponent();
            this.BindingContext = view;
        }

        /// <summary>
        /// override method for size allocated 
        /// </summary>
        /// <param name="width">The width of the page</param>
        /// <param name="height">The height of the page</param>
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (width > height)
            {
                optionsGrid.Height = 100;
            }
            else
            {
                optionsGrid.Height = 250;
            }
        }

        Image image1 = new Image();

        private  void Save_Clicked(object sender, EventArgs e)
        {
            signaturepad.Save();

            if (signaturepad.ImageSource != null)
            {
                Navigation.PushAsync(new SignatureImagePage(signaturepad.ImageSource));
            }
        }

        private void Clear_Clicked(object sender, EventArgs e)
        {
            signaturepad.Clear();
        }
    }

    public class ViewModel : INotifyPropertyChanged
    {
        private Color pencolor;

        public Color PenColor
        {
            get { return pencolor; }
            set 
            {
                pencolor = value;
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private ObservableCollection<Avatar.SfAvatarView> colorItemCollection = new ObservableCollection<Avatar.SfAvatarView>();

        public ObservableCollection<Avatar.SfAvatarView> ColorItemCollection   
        {
            get { return colorItemCollection; }
            set { colorItemCollection = value; }
        }

        private void PopulateColorCollection()
        {
            ColorItemCollection.Clear();

            ColorItemCollection.Add(GetColorPickerItem(Color.FromHex("#030303")));
            ColorItemCollection.Add(GetColorPickerItem(Color.FromHex("#F60618")));
            ColorItemCollection.Add(GetColorPickerItem(Color.FromHex("#0C15F1")));
            ColorItemCollection.Add(GetColorPickerItem(Color.FromHex("#34AB0A")));
            ColorItemCollection.Add(GetColorPickerItem(Color.FromHex("#FBAD0A")));
            ColorItemCollection.Add(GetColorPickerItem(Color.FromHex("#D50BF4")));
            ColorItemCollection[0].BorderWidth = 2;
            ColorItemCollection[0].BorderColor = Color.FromHex("9E9E9E");
            PenColor = ColorItemCollection[0].BackgroundColor;
        }



        private Avatar.SfAvatarView GetColorPickerItem(Color backgroundColor)
        {
            Avatar.SfAvatarView colorAvatar = new Avatar.SfAvatarView();
            colorAvatar.BackgroundColor = backgroundColor;
            colorAvatar.BorderWidth = 1;
            colorAvatar.BorderColor = Color.White;
            colorAvatar.InitialsColor = Color.Transparent;
            colorAvatar.AvatarShape = Avatar.AvatarShape.Circle;
            colorAvatar.AvatarSize = Avatar.AvatarSize.Medium;
            colorAvatar.VerticalOptions = LayoutOptions.Center;
            colorAvatar.HorizontalOptions = LayoutOptions.Center;
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += ColorTapGestureRecognizer_Tapped;
            colorAvatar.GestureRecognizers.Add(tapGestureRecognizer);
            return colorAvatar;

        }

        Avatar.SfAvatarView tappedAvatarView = new Avatar.SfAvatarView();

        public event PropertyChangedEventHandler PropertyChanged;

        private void ColorTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            foreach(var items in ColorItemCollection)
            {
                items.BorderWidth = 1;
                items.BorderColor = Color.White;
            }
            tappedAvatarView = (sender as Avatar.SfAvatarView);
            tappedAvatarView.BorderWidth = 2;
            tappedAvatarView.BorderColor = Color.FromHex("9E9E9E");
            PenColor = tappedAvatarView.BackgroundColor;
            
        }


        public ViewModel()
        {
            PopulateColorCollection();
        }
    }

}