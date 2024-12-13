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