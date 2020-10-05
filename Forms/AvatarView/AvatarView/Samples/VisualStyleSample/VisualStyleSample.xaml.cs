#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Syncfusion.XForms.AvatarView;
using System.Collections.ObjectModel;
using Avatar = Syncfusion.XForms.AvatarView;
using Xamarin.Forms;
using System;

namespace SampleBrowser.SfAvatarView
{
    #region Visual Style Sample

    public partial class VisualStyleSample : SampleView
    {
        private ContentType avatarType;

        public ContentType AvatarType
        {
            get
            {
                return avatarType;
            }
            set
            {
                avatarType = value;

                this.OnPropertyChanged();
            }
        }

        public ObservableCollection<People> TotalPeople { get; set; }

        #region Constructor
        public VisualStyleSample()
        {
            InitializeComponent();

            this.InitialAvatar.AvatarSize = this.DefaultAvatar.AvatarSize = this.CustomAvatar.AvatarSize = this.GroupAvatar.AvatarSize = AvatarSize.Large;
            this.DefaultAvatar.BorderColor = this.CustomAvatar.BorderColor = this.GroupAvatar.BorderColor = Color.White;
            this.DefaultAvatar.BorderWidth = this.CustomAvatar.BorderWidth = this.GroupAvatar.BorderWidth = 6;
            this.InitialAvatar.BorderWidth = 2;
            this.InitialAvatar.BorderColor = Color.Black;
            this.AddTapGestures();

            this.TotalPeople = new ObservableCollection<People>();
            this.TotalPeople.Add(new People() { Name = "Michael", Image = "People_Square30.png" });
            this.TotalPeople.Add(new People() { Name = "Kyle", Image = "Avatar2.png" });
            this.TotalPeople.Add(new People() { Name = "Nora" });

            this.BindingContext = this;

        }

        #endregion

        private void AddTapGestures()
        {
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += TapGestureRecognizer_Tapped;

            this.InitialAvatar.GestureRecognizers.Add(tapGestureRecognizer);
            this.DefaultAvatar.GestureRecognizers.Add(tapGestureRecognizer);
            this.CustomAvatar.GestureRecognizers.Add(tapGestureRecognizer);
            this.GroupAvatar.GestureRecognizers.Add(tapGestureRecognizer);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            this.InitialAvatar.BorderColor = this.DefaultAvatar.BorderColor = this.CustomAvatar.BorderColor = this.GroupAvatar.BorderColor = Color.White;
            this.InitialAvatar.BorderWidth = this.DefaultAvatar.BorderWidth = this.CustomAvatar.BorderWidth = this.GroupAvatar.BorderWidth = 6;

            Avatar.SfAvatarView tappedAvatar = (sender as Avatar.SfAvatarView);
            this.AvatarType = tappedAvatar.ContentType;
            tappedAvatar.BorderColor = Color.Black;
            tappedAvatar.BorderWidth = 2;
        }
    }
    #endregion
}