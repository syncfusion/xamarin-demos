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
using CoreGraphics;
using System.Drawing;
using Syncfusion.SfDiagram.iOS;
using UIKit;
using SolidBrush = Syncfusion.SfDiagram.iOS.SolidBrush;
using Pen = Syncfusion.SfDiagram.iOS.Pen;

namespace SampleBrowser
{
    public partial class MindMap : SampleView
    {
        Node RootNode;
        UserHandleCollection DefaultHandles;
        UserHandleCollection RightSideHandle;
        UserHandleCollection LeftSideHandles;
        Node SelectedNode;
        UIView Notifier;
        UIView InfoNotifier;
        UITextView textinput;
        UserHandlePosition CurrentHandle;
        Random rnd = new Random();
        UIImageView ExpandTemplate;
        UIImageView CollapseTemplate;
        List<NodeStyle> nodeStyleCollection = new List<NodeStyle>();
        LineStyle lineStyle;
        String path;
        UITextView CommentBoxEntry=new UITextView();
        List<UIColor> FColor = new List<UIColor>();
        List<UIColor> SColor = new List<UIColor>();
        string CommentText;
        int index;
        SfDiagram diagram = new SfDiagram();
        UILabel schemaLabel;
        UIPickerView selectionPicker1;
        UIScrollView scrollView = new UIScrollView();
        object objShape1 = ShapeType.RoundedRectangle;
        object objShape2 = ShapeType.RoundedRectangle;
        object objShape3 = ShapeType.RoundedRectangle;
        object objShape4 = ShapeType.RoundedRectangle;
        object objShape5 = ShapeType.RoundedRectangle;
        SegmentType segment = SegmentType.CurveSegment;
        int themeIndex = 0;
        String simpleCurveTree = "default";
        SfGraphics gra = new SfGraphics();
        List<Point> point = new List<Point>();
        DecoratorType Dectype = DecoratorType.None;
        UIColor connColor = UIColor.Gray;
        ApplyColorFrom connColorFrom = ApplyColorFrom.TargetBorder;
        ApplyColorFrom connDecColorFrom = ApplyColorFrom.TargetBorder;
        VerticalAlignment fontVerticalAlignment = VerticalAlignment.Center;
        UIButton defaultTree=new UIButton();
        UIButton contTree= new UIButton();
        UIButton orgTree= new UIButton();
        UIButton simpleTree= new UIButton();
        private UILabel layoutOptionLabel;
        private UISwitch layoutOptionSwitch;

        public MindMap()
        {
            selectionPicker1 = new UIPickerView();
            this.OptionView = new UIView();

            schemaLabel = new UILabel();
            schemaLabel.Text = "Schema";
            schemaLabel.TextColor = UIColor.Black;
            schemaLabel.TextAlignment = UITextAlignment.Left;
            schemaLabel.BackgroundColor = UIColor.Clear;

            scrollView.BackgroundColor = UIColor.Clear;
            scrollView.ScrollEnabled = true;
            scrollView.ShowsHorizontalScrollIndicator = true;
            scrollView.ShowsVerticalScrollIndicator = false;

            defaultTree = AddLayoutButton(10, "mindmapDefault");
            defaultTree.Layer.BorderWidth = 2;
            defaultTree.Layer.BorderColor = UIColor.FromRGB(30,144,255).CGColor;
            defaultTree.TouchUpInside+= DefaultTree_TouchUpInside;
            scrollView.AddSubview(defaultTree);
            contTree = AddLayoutButton(170, "mindmapconttree");
            contTree.TouchUpInside += ContTree_TouchUpInside;
            scrollView.AddSubview(contTree);
            orgTree = AddLayoutButton(330, "mindmaportho");
            orgTree.TouchUpInside+= OrgTree_TouchUpInside;
            scrollView.AddSubview(orgTree);
            simpleTree = AddLayoutButton(490, "mindmapsimpletree");
            simpleTree.TouchUpInside+= SimpleTree_TouchUpInside;
            scrollView.AddSubview(simpleTree);

            layoutOptionLabel = new UILabel();
            layoutOptionLabel.Text = "Free Form";
            layoutOptionLabel.TextColor = UIColor.Black;
            layoutOptionLabel.TextAlignment = UITextAlignment.Left;
            layoutOptionLabel.BackgroundColor = UIColor.Clear;

            layoutOptionSwitch = new UISwitch();
            layoutOptionSwitch.TouchUpInside += LayoutOptionSwitch_TouchUpInside;
            layoutOptionSwitch.BackgroundColor = UIColor.Clear;

            var width = 150;
            var height = 75;
            path = "Images/Diagram/MindMapImages/";
            var node = AddNode(300, 400, width, height, "Goals");
            AddNodeStyle(node, HexToRGB("#d0ebff"), HexToRGB("#81bfea"));
            RootNode = node;
            diagram.AddNode(node);

            SColor.Add(HexToRGB("#d1afdf"));
            SColor.Add(HexToRGB("#90C8C2"));
            SColor.Add(HexToRGB("#8BC1B7"));
            SColor.Add(HexToRGB("#E2C180"));
            SColor.Add(HexToRGB("#BBBFD6"));
            SColor.Add(HexToRGB("#ACCBAA"));
            FColor.Add(HexToRGB("#e9d4f1"));
            FColor.Add(HexToRGB("#d4efed"));
            FColor.Add(HexToRGB("#c4f2e8"));
            FColor.Add(HexToRGB("#f7e0b3"));
            FColor.Add(HexToRGB("#DEE2FF"));
            FColor.Add(HexToRGB("#E5FEE4"));

            var ch1node = AddNode(100, 100, width, height, "Financial");
            index = rnd.Next(5);
            AddNodeStyle(ch1node, FColor[index], SColor[index]);
            diagram.AddNode(ch1node);

            var ch1childnode = AddNode(100, 100, width, height, "Investment");
            AddNodeStyle(ch1childnode, (ch1node.Style.Brush as SolidBrush).FillColor, (ch1node.Style.StrokeBrush as SolidBrush).FillColor);
            diagram.AddNode(ch1childnode);

            var ch2node = AddNode(100, 600, width, height, "Social");
            index = rnd.Next(5);
            AddNodeStyle(ch2node, FColor[index], SColor[index]);
            diagram.AddNode(ch2node);

            var ch2childnode1 = AddNode(100, 100, width, height, "Friends");
            AddNodeStyle(ch2childnode1, (ch2node.Style.Brush as SolidBrush).FillColor, (ch2node.Style.StrokeBrush as SolidBrush).FillColor);
            diagram.AddNode(ch2childnode1);

            var ch2childnode2 = AddNode(100, 100, width, height, "Family");
            AddNodeStyle(ch2childnode2, (ch2node.Style.Brush as SolidBrush).FillColor, (ch2node.Style.StrokeBrush as SolidBrush).FillColor);
            diagram.AddNode(ch2childnode2);

            var ch3node = AddNode(500, 100, width, height, "Personal");
            index = rnd.Next(5);
            AddNodeStyle(ch3node, FColor[index], SColor[index]);
            diagram.AddNode(ch3node);

            var ch3childnode1 = AddNode(500, 100, width, height, "Sports");
            AddNodeStyle(ch3childnode1, (ch3node.Style.Brush as SolidBrush).FillColor, (ch3node.Style.StrokeBrush as SolidBrush).FillColor);
            diagram.AddNode(ch3childnode1);

            var ch3childnode2 = AddNode(500, 100, width, height, "Food");
            AddNodeStyle(ch3childnode2, (ch3node.Style.Brush as SolidBrush).FillColor, (ch3node.Style.StrokeBrush as SolidBrush).FillColor);
            diagram.AddNode(ch3childnode2);

            var ch4node = AddNode(500, 600, width, height, "Work");
            index = rnd.Next(5);
            AddNodeStyle(ch4node, FColor[index], SColor[index]);
            diagram.AddNode(ch4node);

            var ch4childnode1 = AddNode(500, 100, width, height, "Project");
            AddNodeStyle(ch4childnode1, (ch4node.Style.Brush as SolidBrush).FillColor, (ch4node.Style.StrokeBrush as SolidBrush).FillColor);
            diagram.AddNode(ch4childnode1);

            var ch4childnode2 = AddNode(500, 100, width, height, "Career");
            AddNodeStyle(ch4childnode2, (ch4node.Style.Brush as SolidBrush).FillColor, (ch4node.Style.StrokeBrush as SolidBrush).FillColor);
            diagram.AddNode(ch4childnode2);

            diagram.AddConnector(AddConnector(node, ch1node));
            diagram.AddConnector(AddConnector(node, ch2node));
            diagram.AddConnector(AddConnector(node, ch3node));
            diagram.AddConnector(AddConnector(node, ch4node));
            diagram.AddConnector(AddConnector(ch1node, ch1childnode));
            diagram.AddConnector(AddConnector(ch2node, ch2childnode1));
            diagram.AddConnector(AddConnector(ch2node, ch2childnode2));
            diagram.AddConnector(AddConnector(ch3node, ch3childnode1));
            diagram.AddConnector(AddConnector(ch3node, ch3childnode2));
            diagram.AddConnector(AddConnector(ch4node, ch4childnode1));
            diagram.AddConnector(AddConnector(ch4node, ch4childnode2));

            diagram.UserHandleClicked += Diagram_UserHandleClicked;
            AddHandles();
            diagram.NodeClicked += Diagram_NodeClicked;

            diagram.Clicked += Diagram_DiagramClicked;
            diagram.Loaded += Diagram_Loaded;
            SelectedNode = node;
            diagram.TextChanged += Diagram_TextChanged;
            diagram.ConnectorClicked += Diagram_ConnectorClicked;
            this.AddSubview(diagram);
			diagram.ContextMenuSettings.Visibility = false;

            schemaLabel.Frame = new CGRect(this.Frame.X + 10, 100, 100, 30);
			scrollView.Frame = new CGRect(this.Frame.X + 10, 150, 300, 150);
			layoutOptionLabel.Frame = new CGRect(this.Frame.X + 10, 20, 150, 30);
			layoutOptionSwitch.Frame = new CGRect(this.Frame.X + 240, 20, 50, 30);
            scrollView.ContentSize = new CGSize(700, scrollView.ContentSize.Height);
            optionView();
          
        }

        private void LayoutOptionSwitch_TouchUpInside(object sender, EventArgs e)
        {
            if ((sender as UISwitch).On)
            {
                (diagram.LayoutManager.Layout as MindMapLayout).EnableFreeForm = true;
            }
            else
            {
                (diagram.LayoutManager.Layout as MindMapLayout).EnableFreeForm = false;
               
            }
        }

        void DefaultTree_TouchUpInside(object sender, EventArgs e)
        {
			defaultTree.Layer.BorderWidth = 2;
			defaultTree.Layer.BorderColor = UIColor.FromRGB(30, 144, 255).CGColor;
			contTree.Layer.BorderWidth = 2;
            contTree.Layer.BorderColor = UIColor.Clear.CGColor;
			orgTree.Layer.BorderWidth = 2;
            orgTree.Layer.BorderColor = UIColor.Clear.CGColor;
			simpleTree.Layer.BorderWidth = 2;
            simpleTree.Layer.BorderColor = UIColor.Clear.CGColor;
            simpleCurveTree = "default";
            objShape1 = ShapeType.RoundedRectangle;
            objShape2 = ShapeType.RoundedRectangle;
            objShape3 = ShapeType.RoundedRectangle;
            objShape4 = ShapeType.RoundedRectangle;
            objShape5 = ShapeType.RoundedRectangle;
            segment = SegmentType.CurveSegment;
            fontVerticalAlignment = VerticalAlignment.Center;
            Dectype = DecoratorType.None;
            connColor = UIColor.Black;
            connColorFrom = ApplyColorFrom.TargetBorder;
            connDecColorFrom = ApplyColorFrom.TargetBorder;
            UpdateLayoutStyle(themeIndex);
        }

        void ContTree_TouchUpInside(object sender, EventArgs e)
        {
			defaultTree.Layer.BorderWidth = 2;
            defaultTree.Layer.BorderColor = UIColor.Clear.CGColor;
			contTree.Layer.BorderWidth = 2;
			contTree.Layer.BorderColor = UIColor.FromRGB(30, 144, 255).CGColor;
			orgTree.Layer.BorderWidth = 2;
			orgTree.Layer.BorderColor = UIColor.Clear.CGColor;
			simpleTree.Layer.BorderWidth = 2;
			simpleTree.Layer.BorderColor = UIColor.Clear.CGColor;
            simpleCurveTree = "contCurveTree";
            Pen pe = new Pen();
            pe.StrokeBrush = new SolidBrush(HexToRGB("#949494"));
            pe.StrokeWidth = 3;
            point.Add(new Point(0, 37));
            point.Add(new Point(150, 37));
            gra.DrawLines(pe, point);
            objShape1 = ShapeType.Ellipse;
            objShape2 = gra;
            objShape3 = gra;
            objShape4 = gra;
            objShape5 = gra;
            segment = SegmentType.CurveSegment;
            fontVerticalAlignment = VerticalAlignment.Top;
            Dectype = DecoratorType.None;
            connColor = UIColor.Black;
            connColorFrom = ApplyColorFrom.TargetBorder;
            connDecColorFrom = ApplyColorFrom.TargetBorder;
            UpdateLayoutStyle(themeIndex);
        }

        void OrgTree_TouchUpInside(object sender, EventArgs e)
        {
			defaultTree.Layer.BorderWidth = 2;
			defaultTree.Layer.BorderColor = UIColor.Clear.CGColor;
			contTree.Layer.BorderWidth = 2;
            contTree.Layer.BorderColor = UIColor.Clear.CGColor;
			orgTree.Layer.BorderWidth = 2;
			orgTree.Layer.BorderColor = UIColor.FromRGB(30, 144, 255).CGColor;
			simpleTree.Layer.BorderWidth = 2;
            simpleTree.Layer.BorderColor = UIColor.Clear.CGColor;
			simpleCurveTree = "contCurveTree";
            simpleCurveTree = "orthotree";
            objShape1 = ShapeType.Rectangle;
            objShape2 = ShapeType.Rectangle;
            objShape3 = ShapeType.Rectangle;
            objShape4 = ShapeType.Rectangle;
            objShape5 = ShapeType.Rectangle;
            segment = SegmentType.OrthoSegment;
            fontVerticalAlignment = VerticalAlignment.Center;
            Dectype = DecoratorType.None;
            connColor = UIColor.Black;
            connColorFrom = ApplyColorFrom.TargetBorder;
            connDecColorFrom = ApplyColorFrom.TargetBorder;
            UpdateLayoutStyle(themeIndex);
        }

        void SimpleTree_TouchUpInside(object sender, EventArgs e)
        {
			defaultTree.Layer.BorderWidth = 2;
			defaultTree.Layer.BorderColor = UIColor.Clear.CGColor;
			contTree.Layer.BorderWidth = 2;
			contTree.Layer.BorderColor = UIColor.Clear.CGColor;
			orgTree.Layer.BorderWidth = 2;
            orgTree.Layer.BorderColor = UIColor.Clear.CGColor;
			simpleTree.Layer.BorderWidth = 2;
			simpleTree.Layer.BorderColor = UIColor.FromRGB(30, 144, 255).CGColor;
            simpleCurveTree = "simpleCurveTree";
            objShape1 = ShapeType.RoundedRectangle;
            objShape2 = ShapeType.RoundedRectangle;
            objShape3 = ShapeType.RoundedRectangle;
            objShape4 = ShapeType.RoundedRectangle;
            objShape5 = ShapeType.RoundedRectangle;
            segment = SegmentType.CurveSegment;
            fontVerticalAlignment = VerticalAlignment.Center;
            Dectype = DecoratorType.None;
            connColor = HexToRGB("#949494");
            connColorFrom = ApplyColorFrom.Custom;
            connDecColorFrom = ApplyColorFrom.Custom;
            UpdateLayoutStyle(themeIndex);
        }

        private void UpdateLayoutStyle(int themeIndex)
        {
            if (themeIndex == 0)
            {
                nodeStyleCollection.Clear();
                bool m_repeatmode = true;
				if (simpleCurveTree == "default")
				{
					nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#d7ebf6")), HexToRGB("#d7ebf6"), objShape1, StrokeStyle.Default,
					new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, VerticalAlignment.Center)));
					nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#ffebc4")), HexToRGB("#ffebc4"), objShape2, StrokeStyle.Default,
						new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
					nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#ffcdcd")), HexToRGB("#ffcdcd"), objShape3, StrokeStyle.Default,
					 new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
					nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#e7eeb8")), HexToRGB("#e7eeb8"), objShape4, StrokeStyle.Default,
					   new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
					nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#d7ebf6")), HexToRGB("#d7ebf6"), objShape5, StrokeStyle.Default,
					   new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
				}
				else if (simpleCurveTree == "orthotree")
				{
					nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#d7ebf6")), HexToRGB("#b4d6e8"), objShape1, StrokeStyle.Default,
					new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, VerticalAlignment.Center)));
					nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#ffebc4")), HexToRGB("#f2dcb1"), objShape2, StrokeStyle.Default,
						new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
					nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#ffcdcd")), HexToRGB("#ecb6b6"), objShape3, StrokeStyle.Default,
					 new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
					nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#e7eeb8")), HexToRGB("#d6dda6"), objShape4, StrokeStyle.Default,
					   new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
					nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#d7ebf6")), HexToRGB("#b4d6e8"), objShape5, StrokeStyle.Default,
					   new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
				}
				else if (simpleCurveTree == "simpleCurveTree")
				{
                    m_repeatmode = false;
					nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#d7ebf6")), HexToRGB("#b4d6e8"), objShape1, StrokeStyle.Default,
					new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, VerticalAlignment.Center)));
					nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Clear),UIColor.Clear, objShape2, StrokeStyle.Default,
						new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
					nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Clear),UIColor.Clear, objShape3, StrokeStyle.Default,
					 new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
					nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Clear),UIColor.Clear, objShape4, StrokeStyle.Default,
					   new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
					nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Clear),UIColor.Clear, objShape5, StrokeStyle.Default,
					   new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
				}
				else if (simpleCurveTree == "contCurveTree")
				{
                    m_repeatmode = false;
					nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#d7ebf6")), HexToRGB("#d7ebf6"), objShape1, StrokeStyle.Default,
					new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, VerticalAlignment.Center)));
					nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#949494")), HexToRGB("#949494"), objShape2, StrokeStyle.Default,
						new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
					nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#949494")), HexToRGB("#949494"), objShape3, StrokeStyle.Default,
					 new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
					nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#949494")), HexToRGB("#949494"), objShape4, StrokeStyle.Default,
					   new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
					nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#949494")), HexToRGB("#949494"), objShape5, StrokeStyle.Default,
					   new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
				}
                lineStyle = new LineStyle(segment, StrokeStyle.Default, 3, connColorFrom,Dectype , connDecColorFrom, connDecColorFrom) {Color = connColor };
                (diagram.LayoutManager.Layout as MindMapLayout).UpdateLayoutStyle(new LayoutStyle(nodeStyleCollection, lineStyle, ApplyNodeStyleBy.Branch, m_repeatmode));
            }
            if (themeIndex == 1)
            {
                nodeStyleCollection.Clear();
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#eea4af")),HexToRGB("#ce2340"), objShape1, StrokeStyle.Default,
                    new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, VerticalAlignment.Center)));
                if (simpleCurveTree == "default")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#c6ebb4")),HexToRGB("#7cea56"), objShape2, StrokeStyle.Default,
                        new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#a7c7ed")),HexToRGB("#2f75d3"), objShape3, StrokeStyle.Default,
                         new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#eac4a1")),HexToRGB("#ce7023"), objShape4, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#ede3a2")),HexToRGB("#d6bb29"), objShape5, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                else if (simpleCurveTree == "simpleCurveTree")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Clear),UIColor.Clear, objShape2, StrokeStyle.Default,
                    new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Clear),UIColor.Clear, objShape3, StrokeStyle.Default,
                         new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Clear),UIColor.Clear, objShape4, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Clear),UIColor.Clear, objShape5, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                else if (simpleCurveTree == "contCurveTree")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Gray),UIColor.Gray, objShape2, StrokeStyle.Default,
                        new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Gray),UIColor.Gray, objShape3, StrokeStyle.Default,
                     new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Gray),UIColor.Gray, objShape4, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Gray),UIColor.Gray, objShape5, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                lineStyle = new LineStyle(segment, StrokeStyle.Default, 3, connColorFrom, Dectype, connDecColorFrom, connDecColorFrom) { Color = connColor };
                (diagram.LayoutManager.Layout as MindMapLayout).UpdateLayoutStyle(new LayoutStyle(nodeStyleCollection, lineStyle, ApplyNodeStyleBy.Level, true));
            }
            if (themeIndex == 2)
            {
                nodeStyleCollection.Clear();
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#f0a8e1")),HexToRGB("#da2eb8"), objShape1, StrokeStyle.Default,
                    new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, VerticalAlignment.Center)));
                if (simpleCurveTree == "default")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#eec3eb")),HexToRGB("#ae8fa7"), objShape2, StrokeStyle.Default,
                        new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#f0e8f0")),HexToRGB("#ae8fa7"), objShape3, StrokeStyle.Default,
                         new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#9a88b7")),HexToRGB("#716587"), objShape4, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#efa6c8")),HexToRGB("#ae7893"), objShape5, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                else if (simpleCurveTree == "simpleCurveTree")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Clear),UIColor.Clear, objShape2, StrokeStyle.Default,
                           new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Clear),UIColor.Clear, objShape3, StrokeStyle.Default,
                         new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Clear),UIColor.Clear, objShape4, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Clear),UIColor.Clear, objShape5, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                else if (simpleCurveTree == "contCurveTree")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Gray),UIColor.Gray, objShape2, StrokeStyle.Default,
                        new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Gray),UIColor.Gray, objShape3, StrokeStyle.Default,
                     new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Gray),UIColor.Gray, objShape4, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Gray),UIColor.Gray, objShape5, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                lineStyle = new LineStyle(segment, StrokeStyle.Default, 3, connColorFrom, Dectype, connDecColorFrom, connDecColorFrom) { Color = connColor };
                (diagram.LayoutManager.Layout as MindMapLayout).UpdateLayoutStyle(new LayoutStyle(nodeStyleCollection, lineStyle, ApplyNodeStyleBy.Level, true));
            }
            if (themeIndex == 3)
            {
                nodeStyleCollection.Clear();
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#f3d8d6")),HexToRGB("#e3a39f"), objShape1, StrokeStyle.Default,
                    new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, VerticalAlignment.Center)));
                if (simpleCurveTree == "default")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#e9afa4")),HexToRGB("#cd3e24"), objShape2, StrokeStyle.Default,
                        new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#e6c6a7")),HexToRGB("#c5752d"), objShape3, StrokeStyle.Default,
                         new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#e9d5b3")),HexToRGB("#cc9d44"), objShape4, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#ebc3a2")),HexToRGB("#cf7225"), objShape5, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                else if (simpleCurveTree == "simpleCurveTree")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Clear),UIColor.Clear, objShape2, StrokeStyle.Default,
                              new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Clear),UIColor.Clear, objShape3, StrokeStyle.Default,
                         new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Clear),UIColor.Clear, objShape4, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Clear),UIColor.Clear, objShape5, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                else if (simpleCurveTree == "contCurveTree")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Gray),UIColor.Gray, objShape2, StrokeStyle.Default,
                        new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Gray),UIColor.Gray, objShape3, StrokeStyle.Default,
                     new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Gray),UIColor.Gray, objShape4, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Gray),UIColor.Gray, objShape5, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                lineStyle = new LineStyle(segment, StrokeStyle.Default, 3, connColorFrom, Dectype, connDecColorFrom, connDecColorFrom) { Color = connColor };
                (diagram.LayoutManager.Layout as MindMapLayout).UpdateLayoutStyle(new LayoutStyle(nodeStyleCollection, lineStyle, ApplyNodeStyleBy.Level, true));
            }
            if (themeIndex == 4)
            {
                nodeStyleCollection.Clear();
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#dabeb7")),HexToRGB("#a66757"), objShape1, StrokeStyle.Default,
                    new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, VerticalAlignment.Center)));
                if (simpleCurveTree == "default")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#c4b2a3")),HexToRGB("#714621"), objShape2, StrokeStyle.Default,
                        new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#cec3cd")),HexToRGB("#897386"), objShape3, StrokeStyle.Default,
                         new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#d2c2b9")),HexToRGB("#977460"), objShape4, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#d1c4c0")),HexToRGB("#92736e"), objShape5, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                else if (simpleCurveTree == "simpleCurveTree")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Clear),UIColor.Clear, objShape2, StrokeStyle.Default,
                           new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Clear),UIColor.Clear, objShape3, StrokeStyle.Default,
                         new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Clear),UIColor.Clear, objShape4, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Clear),UIColor.Clear, objShape5, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                else if (simpleCurveTree == "contCurveTree")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Gray),UIColor.Gray, objShape2, StrokeStyle.Default,
                        new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Gray),UIColor.Gray, objShape3, StrokeStyle.Default,
                     new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Gray),UIColor.Gray, objShape4, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Gray),UIColor.Gray, objShape5, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                lineStyle = new LineStyle(segment, StrokeStyle.Default, 3, connColorFrom, Dectype, connDecColorFrom, connDecColorFrom) { Color = connColor };
                (diagram.LayoutManager.Layout as MindMapLayout).UpdateLayoutStyle(new LayoutStyle(nodeStyleCollection, lineStyle, ApplyNodeStyleBy.Level, true));
            }
            if (themeIndex == 5)
            {
                nodeStyleCollection.Clear();
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#c5cacd")),HexToRGB("#747f86"), objShape1, StrokeStyle.Default,
                    new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, VerticalAlignment.Center)));
                if (simpleCurveTree == "default")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#d3d2d6")),HexToRGB("#96979f"), objShape2, StrokeStyle.Default,
                        new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#e7e8e7")),HexToRGB("#c2bac1"), objShape3, StrokeStyle.Default,
                         new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#b3b9bb")),HexToRGB("#475859"), objShape4, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#c9cfce")),HexToRGB("#7f8d8a"), objShape5, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                else if (simpleCurveTree == "simpleCurveTree")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Clear),UIColor.Clear, objShape2, StrokeStyle.Default,
                           new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Clear),UIColor.Clear, objShape3, StrokeStyle.Default,
                         new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Clear),UIColor.Clear, objShape4, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Clear),UIColor.Clear, objShape5, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                else if (simpleCurveTree == "contCurveTree")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Gray),UIColor.Gray, objShape2, StrokeStyle.Default,
                        new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Gray),UIColor.Gray, objShape3, StrokeStyle.Default,
                     new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Gray),UIColor.Gray, objShape4, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Gray),UIColor.Gray, objShape5, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                lineStyle = new LineStyle(segment, StrokeStyle.Default, 3, connColorFrom, Dectype, connDecColorFrom, connDecColorFrom) { Color = connColor };
                (diagram.LayoutManager.Layout as MindMapLayout).UpdateLayoutStyle(new LayoutStyle(nodeStyleCollection, lineStyle, ApplyNodeStyleBy.Level, true));
            }
            if (themeIndex == 6)
            {
                nodeStyleCollection.Clear();
                nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#a1c6de")),HexToRGB("#2174b1"), objShape1, StrokeStyle.Default,
                    new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, VerticalAlignment.Center)));
                if (simpleCurveTree == "default")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#a8c6ee")),HexToRGB("#2f76da"), objShape2, StrokeStyle.Default,
                        new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#a4baef")),HexToRGB("#285cda"), objShape3, StrokeStyle.Default,
                         new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#babaf3")),HexToRGB("#585be4"), objShape4, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(HexToRGB("#b9dadf")),HexToRGB("#57a5b3"), objShape5, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                else if (simpleCurveTree == "simpleCurveTree")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Clear),UIColor.Clear, objShape2, StrokeStyle.Default,
                           new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Clear),UIColor.Clear, objShape3, StrokeStyle.Default,
                         new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Clear),UIColor.Clear, objShape4, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Clear),UIColor.Clear, objShape5, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                else if (simpleCurveTree == "contCurveTree")
                {
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Gray),UIColor.Gray, objShape2, StrokeStyle.Default,
                        new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Gray),UIColor.Gray, objShape3, StrokeStyle.Default,
                     new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Gray),UIColor.Gray, objShape4, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                    nodeStyleCollection.Add(new NodeStyle(new SolidBrush(UIColor.Gray),UIColor.Gray, objShape5, StrokeStyle.Default,
                       new TextStyle((int)(14 ),UIColor.Black, ".SF UI Text", HorizontalAlignment.Center, fontVerticalAlignment)));
                }
                lineStyle = new LineStyle(segment, StrokeStyle.Default, 3, connColorFrom, Dectype, connDecColorFrom, connDecColorFrom) { Color = connColor };
                (diagram.LayoutManager.Layout as MindMapLayout).UpdateLayoutStyle(new LayoutStyle(nodeStyleCollection, lineStyle, ApplyNodeStyleBy.Level, true));
            }
        }

        private UIButton AddLayoutButton(int v, string img)
        {
            UIButton button = new UIButton();
            button.BackgroundColor = UIColor.Clear;
            button.Frame = new CGRect(v, 0, 150, 100);
            var imgView = new UIImageView();
            imgView.Frame = new CGRect(0, 0, 150, 100);
            imgView.Image = UIImage.FromBundle("Images/Diagram/MindMapImages/" + img);
            button.AddSubview(imgView);
            return button;
        }

        private void optionView()
        {
            this.OptionView.AddSubview(schemaLabel);
            this.OptionView.AddSubview(scrollView);
            this.OptionView.AddSubview(layoutOptionLabel);
            this.OptionView.AddSubview(layoutOptionSwitch);
        }

        private UIColor HexToRGB(string hexavalue)
        {
            int r = Convert.ToInt32(hexavalue.Substring(1, 2), 16);
            int g = Convert.ToInt32(hexavalue.Substring(3, 2), 16);
            int b = Convert.ToInt32(hexavalue.Substring(5, 2), 16);
            return UIColor.FromRGB(r, g, b);
        }
        private Connector AddConnector(Node node, Node ch1node)
        {
            var c1 = new Connector();
            c1.SourceNode = node;
            c1.TargetNode = ch1node;
            c1.Style.StrokeBrush = new SolidBrush((c1.TargetNode.Style.StrokeBrush as SolidBrush).FillColor);
            c1.Style.StrokeStyle = StrokeStyle.Dashed;
            c1.Style.StrokeWidth = 3;
            c1.TargetDecoratorStyle.Fill = (c1.TargetNode.Style.StrokeBrush as SolidBrush).FillColor;
            c1.TargetDecoratorStyle.StrokeColor = (c1.TargetNode.Style.StrokeBrush as SolidBrush).FillColor;
            c1.SegmentType = SegmentType.CurveSegment;
            return c1;
        }

        private void AddNodeStyle(Node node, UIColor fill, UIColor Stroke)
        {
            node.Style.Brush = new SolidBrush(fill);
            node.Style.StrokeBrush = new SolidBrush(Stroke);
        }

        Node AddNode(int x, int y, int w, int h, string text)
        {
            var node = new Node(x, y, w, h);
            node.ShapeType = ShapeType.RoundedRectangle;
            node.Style.StrokeWidth = 2;
            node.Annotations.Add(new Annotation() { Content = text, FontSize = 15, TextBrush = new SolidBrush(UIColor.Black) });
            return node;
        }

        private void AddAnnotation(string headertext)
        {
            Notifier = new UIView();
            Notifier.Frame = new CGRect(UIScreen.MainScreen.Bounds.Width / 2 - 150, UIScreen.MainScreen.Bounds.Height / 2 - 190, 300, 150);
            Notifier.Layer.CornerRadius = 5;
            Notifier.BackgroundColor = UIColor.White;
            diagram.PageSettings.BackgroundColor = UIColor.DarkGray;
            diagram.Layer.Opacity = 0.2f;

            var title = new UILabel();
            title.Frame = new CGRect(10, 10, Notifier.Frame.Width, 30);
            title.Text = headertext;
            title.TextColor = UIColor.Black;
            Notifier.AddSubview(title);

            textinput = new UITextView();
            textinput.Frame = new CGRect(0, 50, Notifier.Frame.Width - 20, 50);
            textinput.BecomeFirstResponder();
            Notifier.AddSubview(textinput);

            UIButton ok = new UIButton();
            ok.Frame = new CGRect(0, 100, Notifier.Frame.Width, 50);
            ok.SetTitle("OK", UIControlState.Normal);
            ok.SetTitleColor(UIColor.Black, UIControlState.Normal);
            ok.TouchUpInside += Ok_TouchUpInside; 
            Notifier.AddSubview(ok);

            this.AddSubview(Notifier);
        }


        private void AddHandles()
        {
            var template = new UIImageView();
            template.Frame = new CGRect(0, 0, 25, 25);
            var img = UIImage.FromBundle(path + "plus.png");
            template.Image = img;

            var template1 = new UIImageView();
            template1.Frame = new CGRect(0, 0, 25, 25);
            img = UIImage.FromBundle(path + "plus.png");
            template1.Image = img;


            var deltemplate = new UIImageView();
            deltemplate.Frame = new CGRect(0, 0, 25, 25);
            img = UIImage.FromBundle(path + "delete.png");
            deltemplate.Image = img;
                
            ExpandTemplate = new UIImageView();
            ExpandTemplate.Frame = new CGRect(0, 0, 25, 25);
            img = UIImage.FromBundle(path + "expand.png");
            ExpandTemplate.Image = img;

            CollapseTemplate = new UIImageView();
            CollapseTemplate.Frame = new CGRect(0, 0, 25, 25);
            img = UIImage.FromBundle(path + "collpase.png");
            CollapseTemplate.Image = img;

            var moretemplate = new UIImageView();
            moretemplate.Frame = new CGRect(0, 0, 25, 25);
            img = UIImage.FromBundle(path + "more.png");
            moretemplate.Image = img;


            DefaultHandles = new UserHandleCollection(diagram);
            DefaultHandles.Add(new UserHandle("Left", UserHandlePosition.Left, template));
            DefaultHandles.Add(new UserHandle("Right", UserHandlePosition.Right, template1));
            DefaultHandles.Add(new UserHandle("ExpColl", UserHandlePosition.BottomLeft, CollapseTemplate));
            DefaultHandles.Add(new UserHandle("info", UserHandlePosition.TopRight, moretemplate));
            diagram.UserHandles = DefaultHandles;

            RightSideHandle = new UserHandleCollection(diagram);
            RightSideHandle.Add(new UserHandle("Right", UserHandlePosition.Right, template));
            RightSideHandle.Add(new UserHandle("Delete", UserHandlePosition.Bottom, deltemplate));
            RightSideHandle.Add(new UserHandle("ExpColl", UserHandlePosition.BottomLeft, CollapseTemplate));
            RightSideHandle.Add(new UserHandle("info", UserHandlePosition.TopRight, moretemplate));

            LeftSideHandles = new UserHandleCollection(diagram);
            LeftSideHandles.Add(new UserHandle("Left", UserHandlePosition.Left, template));
            LeftSideHandles.Add(new UserHandle("Delete", UserHandlePosition.Bottom, deltemplate));
            LeftSideHandles.Add(new UserHandle("ExpColl", UserHandlePosition.BottomLeft, CollapseTemplate));
            LeftSideHandles.Add(new UserHandle("info", UserHandlePosition.TopRight, moretemplate));
        }

        void Diagram_TextChanged(object sender, TextChangedEventArgs args)
        {
            args.Item.TextBrush = new SolidBrush(UIColor.Black);
            args.Item.FontSize = 15;
        }

        private void Diagram_Loaded(object sender)
        {
            diagram.EnableDrag = false;
            diagram.ShowSelectorHandle(false, SelectorPosition.SourcePoint);
            diagram.ShowSelectorHandle(false, SelectorPosition.TargetPoint);
            diagram.ShowSelectorHandle(false, SelectorPosition.Rotator);
            diagram.ShowSelectorHandle(false, SelectorPosition.TopLeft);
            diagram.ShowSelectorHandle(false, SelectorPosition.TopRight);
            diagram.ShowSelectorHandle(false, SelectorPosition.MiddleLeft);
            diagram.ShowSelectorHandle(false, SelectorPosition.MiddleRight);
            diagram.ShowSelectorHandle(false, SelectorPosition.BottomCenter);
            diagram.ShowSelectorHandle(false, SelectorPosition.BottomLeft);
            diagram.ShowSelectorHandle(false, SelectorPosition.BottomRight);
            diagram.ShowSelectorHandle(false, SelectorPosition.TopCenter);
            diagram.LayoutManager = new LayoutManager()
            {
                Layout = new MindMapLayout()
                {
                    MindMapOrientation = Syncfusion.SfDiagram.iOS.Orientation.Horizontal,
                    HorizontalSpacing = 70,
                }
            };
            if (!(diagram.LayoutManager.Layout as MindMapLayout).EnableFreeForm)
            {
                diagram.LayoutManager.Layout.UpdateLayout();
            }
            diagram.Select(RootNode);
            diagram.BringToView(RootNode);
            UpdateLayoutStyle(0);
        }

        private void Diagram_DiagramClicked(object sender, DiagramClickedEventArgs args)
        {
            diagram.Layer.Opacity = 1;
            diagram.PageSettings.BackgroundColor = UIColor.White;
            if (Notifier != null && Notifier.Superview==this)
            {
                Notifier.RemoveFromSuperview();
            }
            if (InfoNotifier != null && InfoNotifier.Superview == this)
            {
                if (CommentBoxEntry != null && CommentBoxEntry.Text != null)
                {
                    SelectedNode.Content = CommentBoxEntry.Text;
                }
                InfoNotifier.RemoveFromSuperview();
            }
            SelectedNode = null;
        }

        private void Diagram_UserHandleClicked(object sender, UserHandleClickedEventArgs args)
        {
            if (Notifier != null && Notifier.Superview == this)
            {
                Notifier.RemoveFromSuperview();
                diagram.Layer.Opacity = 1;
                diagram.PageSettings.BackgroundColor = UIColor.White;
            }
            else if (InfoNotifier != null && InfoNotifier.Superview == this)
            {
                InfoNotifier.RemoveFromSuperview();
            }
            else
            {
                if (args.Item.Name == "Delete")
                {
                    diagram.RemoveNode(SelectedNode, true);
                   if (!(diagram.LayoutManager.Layout as MindMapLayout).EnableFreeForm)
                    (diagram.LayoutManager.Layout as MindMapLayout).UpdateLayout();
                }
                else if (args.Item.Name == "ExpColl")
                {
                    if (SelectedNode.IsExpanded)
                    {
                        SelectedNode.IsExpanded = false;
                        args.Item.Content = ExpandTemplate;
                        diagram.UserHandles[0].Visible = false;
                        if (SelectedNode == RootNode)
                            diagram.UserHandles[1].Visible = false;
                    }
                    else
                    {
                        SelectedNode.IsExpanded = true;
                        args.Item.Content = CollapseTemplate;
                        diagram.UserHandles[0].Visible = true;
                        if (SelectedNode == RootNode)
                            diagram.UserHandles[1].Visible = true;
                    }
                    if (!(diagram.LayoutManager.Layout as MindMapLayout).EnableFreeForm)
                    (diagram.LayoutManager.Layout as MindMapLayout).UpdateLayout();
                    diagram.Select(SelectedNode);
                    UpdateHandle();
                }
                else if (args.Item.Name == "info")
                {
                    ShowInfo();
                }
                else
                {
                    if (args.Item.Name == "Left")
                    {
                        CurrentHandle = UserHandlePosition.Left;
                        AddAnnotation("Add Topic");
                    }
                    else if (args.Item.Name == "Right")
                    {
                        CurrentHandle = UserHandlePosition.Right;
                        AddAnnotation("Add Topic");
                    }
                }
            }
        }

        void ShowInfo()
        {
            int iconSize = 30;
            int notifierHeight = 50;
            int iconMargin = 85;
            diagram.PageSettings.BackgroundColor = UIColor.DarkGray;
            diagram.Layer.Opacity = 0.2f;

            InfoNotifier = new UIView();
            InfoNotifier.Frame = new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height - 200);
            InfoNotifier.BackgroundColor = UIColor.FromRGB(39, 144, 249);
            this.AddSubview(InfoNotifier);

            UILabel title = new UILabel();
            title.Frame = new CGRect(15, 5, 150, 50);
            if (SelectedNode.Content == null || (SelectedNode.Content as String).Equals(""))
                title.Text = " Add Note";
            else
                title.Text = " Edit Note";
            title.TextColor = UIColor.White;
            title.Font = UIFont.BoldSystemFontOfSize(18);
            InfoNotifier.AddSubview(title);

            UITextView CommentBoxEntry = new UITextView();
            CommentBoxEntry.BecomeFirstResponder();
            CommentBoxEntry.Frame = new CGRect(0, notifierHeight, InfoNotifier.Frame.Width, InfoNotifier.Frame.Height);
            if (SelectedNode.Content == null)
            {
                CommentBoxEntry.Text = "";
            }
            CommentBoxEntry.Changed+= CommentBoxEntry_Changed;
            CommentBoxEntry.Text = (SelectedNode.Content as String);
            InfoNotifier.AddSubview(CommentBoxEntry);

            UIButton ok = new UIButton();
            ok.Frame = new CGRect(InfoNotifier.Frame.Width - (iconMargin / 2), (notifierHeight / 2) - (iconSize / 2), iconSize, iconSize);
            ok.SetImage(new UIImage("Images/Diagram/MindMapImages/diagramTick.png"), UIControlState.Normal);
            ok.TouchUpInside += Ok_TouchUpInside1;
            InfoNotifier.AddSubview(ok);

            UIButton cancel = new UIButton();
            cancel.Frame = new CGRect(InfoNotifier.Frame.Width - iconMargin, (notifierHeight / 2) - (iconSize / 2), iconSize, iconSize);
            cancel.SetImage(new UIImage("Images/Diagram/MindMapImages/diagramCross.png"), UIControlState.Normal);
            cancel.TouchUpInside += Cancel_TouchUpInside; 
            InfoNotifier.AddSubview(cancel);
        }

        void Ok_TouchUpInside(object sender, EventArgs e)
        {
            diagram.Layer.Opacity = 1;
            diagram.PageSettings.BackgroundColor = UIColor.White;
            Notifier.RemoveFromSuperview();
            if (textinput.Text == null)
            {
                textinput.Text = "";
            }
            var node = new Node();
            if (CurrentHandle == UserHandlePosition.Left)
            {
                node.OffsetX = SelectedNode.OffsetX - SelectedNode.Width - 100;
                node.OffsetY = SelectedNode.OffsetY;
            }
            else if (CurrentHandle == UserHandlePosition.Right)
            {
                node.OffsetX = SelectedNode.OffsetX + SelectedNode.Width + 100;
                node.OffsetY = SelectedNode.OffsetY;
            }
            node.Width = SelectedNode.Width;
            node.Height = SelectedNode.Height;
            node.ShapeType = ShapeType.RoundedRectangle;
            node.Style.StrokeWidth = 3;
            if (SelectedNode == RootNode)
            {
                index = rnd.Next(5);
                node.Style.Brush = new SolidBrush(FColor[index]);
                node.Style.StrokeBrush = new SolidBrush(SColor[index]);
            }
            else
            {
                node.Style = SelectedNode.Style;
            }
            node.Annotations.Add(new Annotation() { Content = textinput.Text, FontSize = 15, TextBrush = new SolidBrush(UIColor.Black) });
            diagram.AddNode(node);
            var c1 = new Connector();
            c1.SourceNode = SelectedNode;
            c1.TargetNode = node;
            c1.Style.StrokeBrush = node.Style.StrokeBrush;
            c1.Style.StrokeWidth = 3;
            c1.TargetDecoratorStyle.Fill = (node.Style.StrokeBrush as SolidBrush).FillColor;
            c1.TargetDecoratorStyle.StrokeColor = (node.Style.StrokeBrush as SolidBrush).FillColor;
            c1.SegmentType = SegmentType.CurveSegment;
            c1.Style.StrokeStyle = StrokeStyle.Dashed;
            diagram.AddConnector(c1);
            if (CurrentHandle == UserHandlePosition.Left)
            {
                diagram.UserHandles = LeftSideHandles;
                if (!(diagram.LayoutManager.Layout as MindMapLayout).EnableFreeForm)
                    (diagram.LayoutManager.Layout as MindMapLayout).UpdateLeftOrTop();
            }
            else if (CurrentHandle == UserHandlePosition.Right)
            {
                diagram.UserHandles = RightSideHandle;
                if (!(diagram.LayoutManager.Layout as MindMapLayout).EnableFreeForm)
                    (diagram.LayoutManager.Layout as MindMapLayout).UpdateRightOrBottom();
            }
            diagram.Select(node);
            SelectedNode = node;
            diagram.BringToView(node);
            if (node.Children.Any())
            {
                diagram.UserHandles[2].Visible = true;
            }
            else
                diagram.UserHandles[2].Visible = false;
            UpdateLayoutStyle(themeIndex);
        }

        void Ok_TouchUpInside1(object sender, EventArgs e)
        {
            diagram.Layer.Opacity = 1;
            diagram.PageSettings.BackgroundColor = UIColor.White;
            if (CommentBoxEntry.Text != null)
            {
                SelectedNode.Content = CommentText;
                CommentText = null;
            }
            InfoNotifier.RemoveFromSuperview();
        }

        void Cancel_TouchUpInside(object sender, EventArgs e)
        {
            diagram.Layer.Opacity = 1;
            diagram.PageSettings.BackgroundColor = UIColor.White;
            InfoNotifier.RemoveFromSuperview();
        }

        private void Diagram_NodeClicked(object sender, NodeClickedEventArgs args)
        {
            SelectedNode = args.Item;
            diagram.Layer.Opacity = 1;
            diagram.PageSettings.BackgroundColor = UIColor.White;

            if (Notifier != null && Notifier.Superview==this)
            {
                Notifier.RemoveFromSuperview();
            }
            else if (InfoNotifier != null && InfoNotifier.Superview == this)
            {
                InfoNotifier.RemoveFromSuperview();
            }
            else
            {
                if (args.Item != RootNode && args.Item.OffsetX > RootNode.OffsetX)
                {
                    diagram.UserHandles = RightSideHandle;
                }
                else if (args.Item != RootNode && args.Item.OffsetX < RootNode.OffsetX)
                {
                    diagram.UserHandles = LeftSideHandles;
                }
                else if (args.Item == RootNode)
                {
                    diagram.UserHandles = DefaultHandles;
                }

                if (SelectedNode.IsExpanded)
                {
                    diagram.UserHandles[0].Visible = true;
                    if (SelectedNode == RootNode)
                        diagram.UserHandles[1].Visible = true;
                    diagram.UserHandles[2].Content = CollapseTemplate;
                }
                else
                {
                    diagram.UserHandles[0].Visible = false;
                    if (SelectedNode == RootNode)
                        diagram.UserHandles[1].Visible = false;
                    diagram.UserHandles[2].Content = ExpandTemplate;
                }

                UpdateHandle();
                if (SelectedNode.Children.Any())
                {
                    diagram.UserHandles[2].Visible = true;
                }
                else
                    diagram.UserHandles[2].Visible = false;
            }
        }

        private String GetNodeDirection(Node node)
        {
            if(node == RootNode)
            {
                return "Center";
            }
            else if (node.OffsetX > RootNode.OffsetX)
            {
                return "Right";
            }
            else 
            {
                return "Left";
            }
        }

        internal void UpdateHandle()
        {
            var side = GetNodeDirection(SelectedNode);
            if (side == "Right")
            {
                if (SelectedNode.IsExpanded)
                {
                    diagram.UserHandles[2].Content = ExpandTemplate;
                }
                else
                {
                    diagram.UserHandles[2].Content = CollapseTemplate;
                }
            }
            else if (side == "Left")
            {
                //ExpColl
                if (SelectedNode.IsExpanded)
                {
                    diagram.UserHandles[2].Content = CollapseTemplate;
                }
                else
                {
                    diagram.UserHandles[2].Content = ExpandTemplate;
                }
            }
           
        }

        void Diagram_ConnectorClicked(object sender, ConnectorClickedEventArgs args)
        {
            diagram.ClearSelection();
            if (Notifier != null && Notifier.Superview == this)
            {
                Notifier.RemoveFromSuperview();
            }
            else if (InfoNotifier != null && InfoNotifier.Superview == this)
            {
                InfoNotifier.RemoveFromSuperview();
            }
        }

        void CommentBoxEntry_Changed(object sender, EventArgs e)
        {
            CommentText = (sender as UITextView).Text;
        }
    }
}