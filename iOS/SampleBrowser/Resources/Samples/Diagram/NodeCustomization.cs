#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using CoreGraphics;
using Syncfusion.SfDiagram.iOS;
using UIKit;

namespace SampleBrowser
{
	public partial class NodeCustomization : SampleView
	{
		SfDiagram diagram;

		public NodeCustomization()
		{
			//Initialize sfdiagram
			diagram = new SfDiagram();
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			//Set diagram width and height
			diagram.Width = (float)Frame.Width;
			diagram.Height = (float)Frame.Height;
			diagram.EnableSelectors = false;

			var node1 = DrawNode(((float)(280)), 150, 155, 50, ShapeType.RoundedRectangle);
			node1.Style.StrokeBrush = new SolidBrush(UIColor.FromRGB(206, 98, 9));
			node1.Annotations.Add(new Annotation() { Content = CreateLabel("Establish Project and Team", 12) });
			diagram.AddNode(node1);

			var node2 = DrawNode(((float)(280)), (float)(node1.OffsetY + 90), 155, 50, ShapeType.RoundedRectangle);
			node2.Style.StrokeBrush = new SolidBrush(UIColor.FromRGB(206, 98, 9));
			node2.Style.Brush = new LinearGradientBrush(0, 30, 150, 30, new UIColor[] { UIColor.FromRGB(255, 130, 0), UIColor.FromRGB(255, 37, 0) }, GradientDrawingOptions.DrawsAfterEndLocation);
			node2.Style.StrokeWidth = 0;
			node2.Annotations.Add(new Annotation() { Content = CreateLabel("Define Scope", 12) });
			diagram.AddNode(node2);

			var node3 = DrawNode(((float)(280)), (float)(node2.OffsetY + 90), 155, 50, ShapeType.RoundedRectangle);
			node3.Style.StrokeBrush = new SolidBrush(UIColor.FromRGB(206, 98, 9));
			node3.Style.StrokeStyle = StrokeStyle.Dashed;
			node3.Annotations.Add(new Annotation() { Content = CreateLabel("Analyze process As-Is", 12) });
			diagram.AddNode(node3);

			var node4 = DrawNode(((float)(280)), (float)(node3.OffsetY + 90), 155, 50, ShapeType.RoundedRectangle);
			node4.Style.StrokeBrush = new SolidBrush(UIColor.FromRGB(206, 98, 9));
			node4.Style.StrokeWidth = 0;
			node4.Annotations.Add(new Annotation() { Content = CreateLabel("Identify opportunities for improvement", 12) });
			diagram.AddNode(node4);

			var node5 = DrawNode(((float)(280)), (float)(node4.OffsetY + 90), 155, 50, ShapeType.RoundedRectangle);
			node5.Style.StrokeBrush = new SolidBrush(UIColor.FromRGB(206, 98, 9));
			node5.Style.StrokeWidth = 0;
			node5.Annotations.Add(new Annotation() { Content = CreateLabel("Design and implement improved processess", 12) });
			diagram.AddNode(node5);

			var node6 = DrawCustomShape(53, 155);
			node6.Ports.Add(new Port() { NodeOffsetX = 1, NodeOffsetY = 0.5, IsVisible = false });
			diagram.AddNode(node6);
			var labelnode6 = new Node(33.5f, 195, 80, 35);
			labelnode6.Annotations.Add(new Annotation() { Content = "Sponsor", FontSize = 10, });
			labelnode6.Style = new Style()
			{
				StrokeBrush = new SolidBrush(UIColor.Clear),
				Brush = new SolidBrush(UIColor.Clear)
			};
			diagram.AddNode(labelnode6);

			var node7 = DrawCustomShape(53, 347);
			node7.Ports.Add(new Port() { NodeOffsetX = 1, NodeOffsetY = 0, IsVisible = false });
			node7.Ports.Add(new Port() { NodeOffsetX = 1, NodeOffsetY = 0.3, IsVisible = false });
			node7.Ports.Add(new Port() { NodeOffsetX = 1, NodeOffsetY = 0.6, IsVisible = false });
			node7.Ports.Add(new Port() { NodeOffsetX = 1, NodeOffsetY = 1, IsVisible = false });
			diagram.AddNode(node7);
			var labelnode7 = new Node(55, 393, 60, 50);
			labelnode7.Annotations.Add(new Annotation() { Content = "Domain Experts", FontSize = 10, });
			labelnode7.Style = new Style()
			{
				StrokeBrush = new SolidBrush(UIColor.Clear),
				Brush = new SolidBrush(UIColor.Clear)
			};
			diagram.AddNode(labelnode7);

			var node8 = DrawCustomShape(590, 155);
			node8.Ports.Add(new Port() { NodeOffsetX = 0, NodeOffsetY = 0.5, IsVisible = false });
			diagram.AddNode(node8);
			var labelnode8 = new Node(590.5f, 200, 78, 49);
			labelnode8.Annotations.Add(new Annotation() { Content = "Project Manager", FontSize = 10, });
			labelnode8.Style = new Style()
			{
				StrokeBrush = new SolidBrush(UIColor.Clear),
				Brush = new SolidBrush(UIColor.Clear)
			};
			diagram.AddNode(labelnode8);

			var node9 = DrawCustomShape(590, 347);
			node9.Ports.Add(new Port() { NodeOffsetX = 0, NodeOffsetY = 0, IsVisible = false });
			node9.Ports.Add(new Port() { NodeOffsetX = 0, NodeOffsetY = 0.3, IsVisible = false });
			node9.Ports.Add(new Port() { NodeOffsetX = 0, NodeOffsetY = 0.6, IsVisible = false });
			node9.Ports.Add(new Port() { NodeOffsetX = 0, NodeOffsetY = 1, IsVisible = false });
			diagram.AddNode(node9);
			var labelnode9 = new Node(591, 398.5f, 65, 39);
			labelnode9.Annotations.Add(new Annotation() { Content = "Business Analyst", FontSize = 10, });
			labelnode9.Style = new Style()
			{
				StrokeBrush = new SolidBrush(UIColor.Clear),
				Brush = new SolidBrush(UIColor.Clear)
			};
			diagram.AddNode(labelnode9);

			diagram.AddConnector(DrawConnector(node1, node2, node1.Ports[2], node2.Ports[0], SegmentType.OrthoSegment, UIColor.FromRGB(127, 132, 133), StrokeStyle.Default, DecoratorType.Filled45Arrow, UIColor.FromRGB(127, 132, 133), UIColor.FromRGB(127, 132, 133), 8));

			diagram.AddConnector(DrawConnector(node2, node3, node2.Ports[2], node3.Ports[0], SegmentType.OrthoSegment, UIColor.FromRGB(127, 132, 133), StrokeStyle.Default, DecoratorType.Filled45Arrow, UIColor.FromRGB(127, 132, 133), UIColor.FromRGB(127, 132, 133), 8));

			diagram.AddConnector(DrawConnector(node3, node4, node3.Ports[2], node4.Ports[0], SegmentType.OrthoSegment, UIColor.FromRGB(127, 132, 133), StrokeStyle.Default, DecoratorType.Filled45Arrow, UIColor.FromRGB(127, 132, 133), UIColor.FromRGB(127, 132, 133), 8));

			diagram.AddConnector(DrawConnector(node4, node5, node4.Ports[2], node5.Ports[0], SegmentType.OrthoSegment, UIColor.FromRGB(127, 132, 133), StrokeStyle.Default, DecoratorType.Filled45Arrow, UIColor.FromRGB(127, 132, 133), UIColor.FromRGB(127, 132, 133), 8));

			diagram.AddConnector(DrawConnector(node6, node1, node6.Ports[0], node1.Ports[3], SegmentType.OrthoSegment, UIColor.FromRGB(127, 132, 133), StrokeStyle.Dashed, DecoratorType.Filled45Arrow, UIColor.FromRGB(127, 132, 133), UIColor.FromRGB(127, 132, 133), 8));

			diagram.AddConnector(DrawConnector(node8, node1, node8.Ports[0], node1.Ports[1], SegmentType.OrthoSegment, UIColor.FromRGB(127, 132, 133), StrokeStyle.Dashed, DecoratorType.Filled45Arrow, UIColor.FromRGB(127, 132, 133), UIColor.FromRGB(127, 132, 133), 8));

			diagram.AddConnector(DrawConnector(node7, node2, node7.Ports[0], node2.Ports[3], SegmentType.StraightSegment, UIColor.Black, StrokeStyle.Default, DecoratorType.Square, UIColor.Black, UIColor.Black, 6));

			diagram.AddConnector(DrawConnector(node7, node3, node7.Ports[1], node3.Ports[3], SegmentType.StraightSegment, UIColor.Black, StrokeStyle.Default, DecoratorType.Square, UIColor.Black, UIColor.Black, 6));

			diagram.AddConnector(DrawConnector(node7, node4, node7.Ports[2], node4.Ports[3], SegmentType.StraightSegment, UIColor.Black, StrokeStyle.Default, DecoratorType.Square, UIColor.Black, UIColor.Black, 6));

			diagram.AddConnector(DrawConnector(node7, node5, node7.Ports[3], node5.Ports[3], SegmentType.StraightSegment, UIColor.Black, StrokeStyle.Default, DecoratorType.Square, UIColor.Black, UIColor.Black, 6));

			diagram.AddConnector(DrawConnector(node9, node2, node9.Ports[0], node2.Ports[1], SegmentType.StraightSegment, UIColor.Black, StrokeStyle.Default, DecoratorType.Circle, UIColor.Black, UIColor.Black, 6));

			diagram.AddConnector(DrawConnector(node9, node3, node9.Ports[1], node3.Ports[1], SegmentType.StraightSegment, UIColor.Black, StrokeStyle.Default, DecoratorType.Circle, UIColor.Black, UIColor.Black, 6));

			diagram.AddConnector(DrawConnector(node9, node4, node9.Ports[2], node4.Ports[1], SegmentType.StraightSegment, UIColor.Black, StrokeStyle.Default, DecoratorType.Circle, UIColor.Black, UIColor.Black, 6));

			diagram.AddConnector(DrawConnector(node9, node5, node9.Ports[3], node5.Ports[1], SegmentType.StraightSegment, UIColor.Black, StrokeStyle.Default, DecoratorType.Circle, UIColor.Black, UIColor.Black, 6));

			this.AddSubview(diagram);
		}

		//Creates the Node with Specified input
		Node DrawNode(float x, float y, float w, float h, ShapeType shape)
		{
			var node = new Node();
			node.OffsetX = x;
			node.OffsetY = y;
			node.Width = w;
			node.Height = h;
			node.ShapeType = shape;
			node.Style.StrokeWidth = 1;
			node.CornerRadius = 30;
			node.Style.Brush = new SolidBrush(UIColor.FromRGB(255, 129, 0));
			node.Ports.Add(new Port() { NodeOffsetX = 0.5, NodeOffsetY = 0, IsVisible = false });
			node.Ports.Add(new Port() { NodeOffsetX = 1, NodeOffsetY = 0.5, IsVisible = false });
			node.Ports.Add(new Port() { NodeOffsetX = 0.5, NodeOffsetY = 1, IsVisible = false });
			node.Ports.Add(new Port() { NodeOffsetX = 0, NodeOffsetY = 0.5, IsVisible = false });
			return node;
		}

		Node DrawCustomShape(float x, float y)
		{
			var node = new Node(x, y, 40, 40);
			SfGraphics grap = new SfGraphics();
			Pen stroke = new Pen();
			stroke.Brush = new SolidBrush(UIColor.Clear);
			stroke.StrokeWidth = 3;
			stroke.StrokeBrush = new SolidBrush(UIColor.FromRGB(24, 161, 237));
			grap.DrawEllipse(stroke, new System.Drawing.Rectangle(10, 0, 20, 20));
			grap.DrawArc(stroke, 0, 20, 40, 40, 180, 180);
			node.UpdateSfGraphics(grap);
			return node;
		}
		Connector DrawConnector(Node Src, Node Trgt, Port srcport, Port trgtport, SegmentType type, UIColor strokeColor, StrokeStyle style, DecoratorType decorator, UIColor fillColor, UIColor strokeFill, float sw)
		{
			var Conn = new Connector(Src, Trgt);
			Conn.SourcePort = srcport;
			Conn.TargetPort = trgtport;
			Conn.SegmentType = type;
			Conn.TargetDecoratorType = decorator;
			Conn.TargetDecoratorStyle.Fill = fillColor;
			Conn.TargetDecoratorStyle.StrokeColor = strokeFill;
			Conn.Style.StrokeWidth = 1;
			Conn.Style.StrokeBrush = new SolidBrush(strokeColor);
			Conn.Style.StrokeStyle = style;
			Conn.TargetDecoratorStyle.Size = sw;
			Conn.TargetDecoratorStyle.StrokeWidth = 1;
			return Conn;
		}
		//Create Node's Annotation
		UILabel CreateLabel(string text, int Size)
		{
			var label = new UILabel();
			label.Frame = new CGRect(2, 0, 150, 45);
			label.TextAlignment = UITextAlignment.Center;
			label.Text = text;
			label.TextColor = UIColor.White;
			label.Font = UIFont.FromName("Arial", 10);
			label.LineBreakMode = UILineBreakMode.WordWrap;
			label.Lines = 0;
			label.Layer.ShouldRasterize = true;
			label.Layer.RasterizationScale = UIScreen.MainScreen.Scale;
			return label;
		}
	}
}