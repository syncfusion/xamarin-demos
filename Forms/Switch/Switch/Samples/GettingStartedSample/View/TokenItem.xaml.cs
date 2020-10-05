#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace SampleBrowser.SfSwitch
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TokenItem : ContentView
    {
        #region Memebers
        private String name;
        private String icon;
        private Color color;
        #endregion
        #region Properties
        /// <summary>
        /// get or set the visiblity of the text to segment control which get enabled and disabled from the list view 
        /// </summary>
        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                raisepropertyChanged("Name");
            }
        }
        /// <summary>
        /// get or set the icons
        /// </summary>
        public String Icon
        {
            get
            {
                return icon;
            }
            set
            {
                icon = value;
                raisepropertyChanged("Icon");
            }
        }
        /// <summary>
        /// get or set the color to segment control which get enabled and disabled from the list view 
        /// </summary>
        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
                raisepropertyChanged("Color");
            }
        }
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor of the token items used on the list view
        /// </summary>
        /// <param name="iconFont"></param>
        /// <param name="textValue"></param>
        /// <param name="textColor"></param>
        public TokenItem(AppModel model)
        {
            InitializeComponent();
            this.BindingContext = this;
            Name = model.Name;
            Icon = model.Icon;
            Color = model.IconColor;
        }
        #endregion
        #region PropertyChanged
        public event PropertyChangedEventHandler propertyChanged;
        private void raisepropertyChanged(string property)
        {
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        #endregion
    }
}