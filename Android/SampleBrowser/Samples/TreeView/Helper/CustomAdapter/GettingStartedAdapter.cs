using Android.Views;
using Android.Widget;
using Syncfusion.Android.TreeView;

namespace SampleBrowser
{
    public class GettingStartedAdapter : TreeViewAdapter
    {
        public GettingStartedAdapter()
        {
        }

        protected override void UpdateContentView(View view, TreeViewItemInfoBase itemInfo)
        {
            var textView = view as TextView;
            if (textView != null)
            {
                textView.Text = (itemInfo.Node.Content as FoodSpecies).SpeciesName;
            }
        }
    }
}