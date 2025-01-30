using System;
using QuickLook;

namespace SampleBrowser
{
	public class PreviewControllerDS : QLPreviewControllerDataSource
	{
		private QLPreviewItem _item;

		public PreviewControllerDS(QLPreviewItem item)
		{
			_item = item;
		}

		public override nint PreviewItemCount (QLPreviewController controller)
		{
			return (nint)1;
		}

		public override IQLPreviewItem GetPreviewItem (QLPreviewController controller, nint index)
		{
			return _item;
		}
	}
}

