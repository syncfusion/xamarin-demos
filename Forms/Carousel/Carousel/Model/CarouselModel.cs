#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace SampleBrowser.SfCarousel
{
    /// <summary>
    /// Carousel model.
    /// </summary>
    public class CarouselModel : INotifyPropertyChanged
    {
        #region private properties

        /// <summary>
        /// The image.
        /// </summary>
        private string image;

        /// <summary>
        /// The name.
        /// </summary>
        private string name;

        /// <summary>
        /// The close command.
        /// </summary>
        private ICommand closeCommand;

        /// <summary>
        /// The color of the item.
        /// </summary>
        private Color itemColor;

        /// <summary>
        /// 
        /// </summary>
        private string checkValue = "C";
        /// <summary>
        /// The grid visible.
        /// </summary>
        private bool gridVisible = false;

        /// <summary>
        /// The tap command.
        /// </summary>
        private ICommand tapCommand;
        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value.ToString().Replace("-WF", "");
            }
        }

        /// <summary>
        /// Gets or sets the close command.
        /// </summary>
        /// <value>The close command.</value>
        public ICommand CloseCommand
        {
            set { closeCommand = value; }
            get { return closeCommand; }
        }

        /// <summary>
        /// Gets or sets the color of the item.
        /// </summary>
        /// <value>The color of the item.</value>
        public Color ItemColor
        {
            get
            {
                return itemColor;
            }
            set
            {
                itemColor = value;
                RaisePropertyChanged("ItemColor");
            }
        }

        /// <summary>
        /// Gets or sets the color of the item.
        /// </summary>
        /// <value>The color of the item.</value>
        public string CheckValue
        {
            get
            {
                return checkValue;
            }
            set
            {
                checkValue = value;
                RaisePropertyChanged("CheckValue");
            }
        }

        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>The tag.</value>
        public string Tag { get; set; }

        /// <summary>
        /// Gets or sets the unicode.
        /// </summary>
        /// <value>The unicode.</value>
        public string Unicode { get; set; }

        /// <summary>
        /// Gets or sets the name of the watch.
        /// </summary>
        /// <value>The name of the watch.</value>
        public string ImageName
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:SampleBrowser.SfCarousel.CarouselModel"/> grid visible.
        /// </summary>
        /// <value><c>true</c> if grid visible; otherwise, <c>false</c>.</value>
        public bool GridVisible
        {
            get
            {
                return gridVisible;
            }

            set
            {
                gridVisible = value;
                RaisePropertyChanged("GridVisible");
            }
        }

        /// <summary>
        /// Gets or sets the tap command.
        /// </summary>
        /// <value>The tap command.</value>
        public ICommand TapCommand
        {
            set { tapCommand = value; }
            get { return tapCommand; }
        }

        /// <summary>
        /// Occurs when property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;


        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SampleBrowser.SfCarousel.CarouselModel"/> class.
        /// </summary>
        /// <param name="imagestr">Imagestr.</param>
        public CarouselModel(string imagestr)
        {
            ImageName = imagestr;

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:SampleBrowser.SfCarousel.CarouselModel"/> class.
        /// </summary>
        public CarouselModel()
        {
            TapCommand = new Command<Object>(TappedEvent);
            CloseCommand = new Command<Object>(CloseCommandAction);

        }


        #endregion

        #region raised event

        public void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion

        #region tap event action

        /// <summary>
        /// Closes the command action.
        /// </summary>
        /// <param name="s">S.</param>
        private void CloseCommandAction(Object s)
        {
            (s as Grid).IsVisible = false;
        }
        /// <summary>
        /// Tappeds the event.
        /// </summary>
        /// <param name="s">S.</param>
        private void TappedEvent(Object s)
        {
            ItemColor = (Color)s;
        }

        #endregion
    }

}
