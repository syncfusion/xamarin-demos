using UIKit;
using Syncfusion.iOS.TreeView;

namespace SampleBrowser
{
    public class GettingStartedAdapter : TreeViewAdapter
    {
        public GettingStartedAdapter()
        {

        }
        protected override void UpdateContentView(UIView view, TreeViewItemInfoBase itemInfo)
        {
            var label = view as UILabel;
            if (label != null)
                label.Text = (itemInfo.Node.Content as FoodSpecies).SpeciesName;
        }
    }
}