using Android.Views;
using Android.Widget;
using Syncfusion.Android.TreeView;

namespace SampleBrowser
{
    public class NodeImageAdapter : TreeViewAdapter
    {
        public NodeImageAdapter()
        {
        }

        protected override View CreateContentView(TreeViewItemInfoBase itemInfo)
        {
            var gridView = new NodeImageView(TreeView.Context);
            return gridView;
        }

        protected override void UpdateContentView(View view, TreeViewItemInfoBase itemInfo)
        {
            var grid = view as NodeImageView;
            var treeViewNode = itemInfo.Node;
            if (grid != null)
            {
                var icon = grid.GetChildAt(0) as ImageView;
                if (icon != null)
                {
                    var imageID = (treeViewNode.Content as FileManager).ImageIcon;
                    icon.SetImageResource(imageID);
                }

                var label1 = grid.GetChildAt(1) as ContentLabel;
                if (label1 != null)
                {
                    label1.Text = (treeViewNode.Content as FileManager).FileName.ToString();
                }
            }
        }
    }
}