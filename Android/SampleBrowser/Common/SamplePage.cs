using Android.Views;
using Android.Content;

namespace SampleBrowser
{
	public class SamplePage
    {
        #region properties

        public View SampleView { get; set; }

        internal View PropertyView { get; set; }

        #endregion

        #region methods

        public virtual View GetSampleContent(Context context)
		{
			return new View(context);
		}

		public virtual void OnApplyChanges(View view)
		{
			OnApplyChanges();
		}

		public virtual void OnApplyChanges()
		{
		}

		public virtual View GetPropertyWindowLayout(Context context)
		{
			return null;
		}

		public virtual void Destroy()
		{
		}

        #endregion
    }
}