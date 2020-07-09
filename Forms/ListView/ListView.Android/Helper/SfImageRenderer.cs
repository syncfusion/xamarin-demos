#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.Android;
using Xamarin.Forms.Platform.Android;
using System.IO;
using System.Reflection;
using Android.Graphics;
using System.ComponentModel;
using System.Threading.Tasks;
using Java.Lang;
using SampleBrowser.SfListView.Droid.Helper;
using SampleBrowser.SfListView;

[assembly: ExportRenderer(typeof(SampleBrowser.SfListView.SfImage), typeof(SfImageRenderer))]
namespace SampleBrowser.SfListView.Droid.Helper
{
    /// <summary>
    /// Represents a renderer of <see cref="Syncfusion.ListView.XForms.SfImage"/>
    /// </summary>
    [Preserve(AllMembers = true)]
    internal class SfImageRenderer : ViewRenderer<SfImage, ImageView>
    {
        #region Fields

        /// <summary>
        /// Used to process the function in the <see cref="Runnable"/> thread in which bitmap image is set to <see cref="ImageView"/>.
        /// </summary>
        private Handler mainHandler;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the <see cref="ImageView"/>.
        /// </summary>
        private ImageView NativeImage { get; set; }

        #endregion

        #region Constructor

#pragma warning disable CS0618 // Type or member is obsolete
        /// <summary>
        /// Initializes a new instance of the <see cref="SfImageRenderer"/> class.
        /// </summary>
        public SfImageRenderer()
        {
            AutoPackage = false;
            mainHandler = new Handler(Looper.MainLooper);
        }

#pragma warning restore CS0618 // Type or member is obsolete

        #endregion

        #region Override Methods

        /// <summary>
        /// Method to define the equivalent native image view  for <see cref="SfImage"/>.
        /// </summary>
        /// <param name="e">Represents the element changed event arguments for <see cref="SfImage"/>.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<SfImage> e)
        {
            if (e.NewElement != null)
            {
                NativeImage = new ImageView(Context);

#pragma warning disable CS0618 // Type or member is obsolete
                NativeImage.DrawingCacheEnabled = true;

#pragma warning restore CS0618 // Type or member is obsolete
                this.SetNativeControl(NativeImage);
                SetImageSourceToNativeView();
                UpdateAspect();
            }
        }

        /// <summary>
        /// Updates the <see cref="SfImageRenderer"/> when <see cref="SfImage"/> properties are changed.
        /// </summary>
        /// <param name="sender">Respresents the <see cref="SfImage"/>.</param>
        /// <param name="e">Represents the property changed event arguments.</param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Source")
            {
                SetImageSourceToNativeView();
            }
            else if (e.PropertyName == "Aspect")
            {
                UpdateAspect();
            }
            else
                base.OnElementPropertyChanged(sender, e);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Updates the <see cref="NativeImage"/>'s scale type based on the <see cref="Image.Aspect"/> property.
        /// </summary>
        private void UpdateAspect()
        {
            if (Element == null || NativeImage == null)
                return;

            ImageView.ScaleType type = this.GetScaleType(Element.Aspect);
            NativeImage.SetScaleType(type);
        }

        /// <summary>
        /// Decodes the <see cref="Bitmap"/> image from <see cref="ImageSource"/>.
        /// </summary>
        /// <returns>Returns the <see cref="Bitmap"/>.</returns>
        private async Task<Bitmap> GetBitMapImageFromSource()
        {
            if (this.Element.Source == null)
                return null;

            var imageHandler = this.GetHandler(Element.Source);
            if (imageHandler != null)
            {
                var bitmapimage = await imageHandler.LoadImageAsync(Element.Source, NativeImage.Context);
                imageHandler = null;
                return bitmapimage;
            }

            imageHandler = null;
            return null;
        }

        /// <summary>
        /// Loads the <see cref="SfImage.Source"/> to <see cref="ImageView"/>.
        /// </summary>
        private async void SetImageSourceToNativeView()
        {
            var bitmapimage = await GetBitMapImageFromSource();
            Runnable myRunnable = new Runnable(() =>
            {
                if (this.Control != null && this.Control.Handle != IntPtr.Zero)
                {
                    this.Control.SetImageBitmap(bitmapimage);
                    ((IVisualElementController)Element).NativeSizeChanged();
                    bitmapimage = null;
                }
            });

            if (mainHandler != null)
                mainHandler.Post(myRunnable);
        }

        /// <summary>
        /// Helper method to initialize the respective <see cref="IImageSourceHandler"/> to native <see cref="ImageView"/> using <see cref="SfImage.Source"/> property.
        /// </summary>
        /// <param name="source">Represents the <see cref="ImageSource"/>.</param>
        /// <returns>Returns the <see cref="IImageSourceHandler"/> based on <see cref="ImageSource"/>.</returns>
        private IImageSourceHandler GetHandler(ImageSource source)
        {
            IImageSourceHandler sourcehandler = null;
            if (source is UriImageSource)
            {
                sourcehandler = new ImageLoaderSourceHandler();
            }
            else if (source is FileImageSource)
            {
                sourcehandler = new FileImageSourceHandler();
            }
            else if (source is StreamImageSource)
            {
                sourcehandler = new StreamImagesourceHandler();
            }
            return sourcehandler;
        }

        /// <summary>
        /// Helper method to get the <see cref="NativeImage"/>'s scale type from the <see cref="Image.Aspect"/> property.
        /// </summary>
        /// <param name="aspect">Represents the <see cref="Aspect"/> property of <see cref="Image"/>.</param>
        /// <returns>Returns the <see cref="ImageView.ScaleType"/> value.</returns>
        public ImageView.ScaleType GetScaleType(Aspect aspect)
        {
            switch (aspect)
            {
                case Aspect.Fill:
                    return ImageView.ScaleType.FitXy;
                case Aspect.AspectFill:
                    return ImageView.ScaleType.CenterCrop;
                default:
                case Aspect.AspectFit:
                    return ImageView.ScaleType.FitCenter;
            }
        }

        #endregion

        #region Dispose Methods

        /// <summary>
        /// Dispose the instances, if parameter is true.
        /// </summary>
        /// <param name="disposing">Represents the boolean value for disposing objects</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                NativeImage = null;
                mainHandler = null;
                GC.SuppressFinalize(this);
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}