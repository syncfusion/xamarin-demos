using Syncfusion.SfDataGrid;

namespace SampleBrowser
{
	public class CustomStyles : DefaultStyle
	{
		public override GridLinesVisibility GetGridLinesVisibility()
		{
			return GridLinesVisibility.Both;
		}
	}
}