#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;

namespace SampleBrowser
{
    public class SampleModel : Java.Lang.Object, Java.IO.ISerializable
	{
        #region ctor

        public SampleModel()
        {
            Type = string.Empty;
        }

        #endregion

        #region properties

		public string Name { get; set; }

        public string Type { get; set; }

        public string Title { get; set; }

        public string ImageId { get; set; }

        public string Description { get; set; }

        #endregion
    }

    public class ControlModel : SampleModel
    {
        #region ctor

        public ControlModel()
        {
            Features = new List<SampleModel>();
            Samples = new List<SampleModel>();
        }

        #endregion

        #region properties

        public List<SampleModel> Features { get; set; }

		public List<SampleModel> Samples { get; set; }

        #endregion
    }
}