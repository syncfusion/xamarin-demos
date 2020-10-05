#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using SampleBrowser.Core;
using Xamarin.Forms;

namespace SampleBrowser.SfCarousel
{

    #region ImageAdv
    /// <summary>
    /// Image adv.
    /// </summary>
    public class ImageAdv : Label
    {

        /// <summary>
        /// Gets or sets an instance of the Template class that defines the visual structure of a SfPicker item.
        /// </summary>
        /// <value>The default value is null.</value>
        public CarouselModel ModelObject
        {
            get { return (CarouselModel)GetValue(ModelObjectProperty); }
            set { SetValue(ModelObjectProperty, value); }
        }

        /// <summary>
        /// An instance of the Template class that defines the visual structure of a Carousel item.
        /// </summary>
        public static readonly BindableProperty ModelObjectProperty =
            BindableProperty.Create("ModelObject", typeof(CarouselModel), typeof(ImageAdv), null, BindingMode.Default, null, null, null, null, null);
    }

    #endregion

    #region LoadMore Default

    /// <summary>
    /// Load more default.
    /// </summary>
    public partial class LoadMore_Default : SampleView
    {


        /// <summary>
        /// Initializes a new instance of the <see cref="T:SampleBrowser.SfCarousel.LoadMore_Default"/> class.
        /// </summary>
        #region constructor

        public LoadMore_Default()
        {
            InitializeComponent();
            carouselLayout.BindingContext = new CarouselViewModel();
        }

        #endregion

        #region SB view

        /// <summary>
        /// Gets the content.
        /// </summary>
        /// <returns>The content.</returns>
        public View getContent()
        {
            return this.Content;
        }

        #endregion

        #region handle event

        /// <summary>
        /// Handles the tapped.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void Handle_Tapped(object sender, System.EventArgs e)
        {
            if (previousLabel != null)
                previousLabel.Text = "C";
            selectedModel = (sender as ImageAdv).ModelObject;
            this.iconName.Text = selectedModel.Unicode;
            this.iconText.Text = selectedModel.Name.Replace("-"," ").Replace("0","").Replace("1", "").Replace("2", "").Replace("3", "").Replace("4", "").Replace("5", "").Replace("6", "").Replace("7", "").Replace("8", "").Replace("9", "");
            this.iconName.TextColor = selectedModel.ItemColor;
            this.Dialog.IsVisible = true;
            this.Dialog.Opacity = 0;
            this.Dialog.FadeTo(1, 500, Easing.Linear);
        }


        /// <summary>
        /// Handles the tapped.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void Color_Tapped(object sender, System.EventArgs e)
        {
            if (previousLabel != null)
                previousLabel.Text = "C";
            (sender as Label).Text = "B";
            selectedModel.ItemColor = (sender as Label).TextColor;
            this.iconName.TextColor = selectedModel.ItemColor;
            previousLabel = (sender as Label);
        }

        /// <summary>
        /// Yeses the handle.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void Yes_Handle(object sender, System.EventArgs e)
        {
            this.Dialog.Opacity = 1;
            this.Dialog.IsVisible = false;
            selectedModel = null;
        }

        #endregion

        #region Member

        private Label previousLabel = null;
        private CarouselModel selectedModel = null;
        #endregion
    }
    #endregion

}

