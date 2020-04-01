#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleBrowser.SfStepProgressBar
{
    #region Rotator Model

    /// <summary>
    /// Rotator Model for Rotator View
    /// </summary>
    public class RotatorModel
    {
        /// <summary>
        /// Rotator Model Constructor.
        /// </summary>
        /// <param name="imagestr"></param>
        public RotatorModel(string imagestr)
        {
            Image = imagestr;
        }

        private string _image;

        /// <summary>
        /// Gets or sets the image for rotator model.
        /// </summary>
        public string Image
        {
            get { return _image; }
            set { _image = value; }
        }
    }

    #endregion

    #region Rotator View Model

    /// <summary>
    /// Rotator View Model for Rotator View
    /// </summary>
    public class RotatorViewModel
    {
        /// <summary>
        /// Rotator View Model Constructor.
        /// </summary>
        public RotatorViewModel()
        {
            ImageCollection.Add(new RotatorModel("image2.png"));
            ImageCollection.Add(new RotatorModel("image2.png"));
            ImageCollection.Add(new RotatorModel("image2.png"));
        }
        private List<RotatorModel> imageCollection = new List<RotatorModel>();

        /// <summary>
        /// Gets or sets the imagecollection.
        /// </summary>
        public List<RotatorModel> ImageCollection
        {
            get { return imageCollection; }
            set { imageCollection = value; }
        }
    }

    #endregion
}
