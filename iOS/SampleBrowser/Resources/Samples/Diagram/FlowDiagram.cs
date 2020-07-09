#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using CoreGraphics;
using Syncfusion.SfDiagram.iOS;
using UIKit;

namespace SampleBrowser
{
	public partial class FlowDiagram : SampleView
	{
		SfDiagram diagram;
		public FlowDiagram()
		{
			diagram = new SfDiagram();
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

			//Set diagram width and height
			diagram.Width = (float)Frame.Width;
			diagram.Height = (float)Frame.Height;
			diagram.EnableSelectors = false;

			//Create Node
			Node n1 = DrawNode(100, 30, 160, 55, ShapeType.RoundedRectangle, "New idea identified", 30, UIColor.FromRGB(49, 162, 255), UIColor.FromRGB(23, 132, 206));
			diagram.AddNode(n1);

			Node n2 = DrawNode(100, 130, 160, 55, ShapeType.RoundedRectangle, "Meeting With Board", 4, UIColor.FromRGB(49, 162, 255), UIColor.FromRGB(23, 132, 206));
			diagram.AddNode(n2);

			Node n3 = DrawNode(105, 230, 150, 150, ShapeType.Diamond, "Board decides \n whether to \n proceed ", 0, UIColor.FromRGB(0, 194, 192), UIColor.FromRGB(4, 142, 135));
			diagram.AddNode(n3);

			Node n4 = DrawNode(105, 425, 150, 150, ShapeType.Diamond, "Find Project  \n Manager, write \n specification", 0, UIColor.FromRGB(0, 194, 192), UIColor.FromRGB(4, 142, 135));
			diagram.AddNode(n4);

			Node n5 = DrawNode(90, 620, 180, 60, ShapeType.RoundedRectangle, "Implement and deliver", 30, UIColor.FromRGB(49, 162, 255), UIColor.FromRGB(23, 132, 206));
			diagram.AddNode(n5);

			Node n6 = DrawNode(320, 275, 200, 60, ShapeType.RoundedRectangle, "Reject and report the reason", 4, UIColor.FromRGB(239, 75, 93), UIColor.FromRGB(201, 32, 61));
			diagram.AddNode(n6);

			Node n7 = DrawNode(320, 470, 200, 60, ShapeType.RoundedRectangle, "Hire new resources", 4, UIColor.FromRGB(239, 75, 93), UIColor.FromRGB(201, 32, 61));
			diagram.AddNode(n7);

			//Create Connector
			Connector c1 = new Connector(n1, n2);
			diagram.AddConnector(c1);

			Connector c2 = new Connector(n2, n3);
			diagram.AddConnector(c2);

			Connector c3 = new Connector(n3, n4);
			c3.Annotations.Add(new Annotation() { Content = CreateConnectorLabel("Yes", -25, 10, 25, 20) });
			diagram.AddConnector(c3);

			Connector c4 = new Connector(n4, n5);
			c4.Annotations.Add(new Annotation() { Content = CreateConnectorLabel("Yes", -25, 10, 25, 20) });
			diagram.AddConnector(c4);

			Connector c5 = new Connector(n3, n6);
			c5.Annotations.Add(new Annotation() { Content = CreateConnectorLabel("No", 15, 15, 25, 20) });
			diagram.AddConnector(c5);

			Connector c6 = new Connector(n4, n7);
			c6.Annotations.Add(new Annotation() { Content = CreateConnectorLabel("No", 15, 15, 25, 20) });
			diagram.AddConnector(c6);

			for (int i = 0; i < diagram.Connectors.Count; i++)
			{
				diagram.Connectors[i].Style.StrokeBrush = new SolidBrush(UIColor.FromRGB(127, 132, 133));
				diagram.Connectors[i].TargetDecoratorStyle.Fill = (UIColor.FromRGB(127, 132, 133));
				diagram.Connectors[i].TargetDecoratorStyle.StrokeColor = (UIColor.FromRGB(127, 132, 133));
				diagram.Connectors[i].TargetDecoratorStyle.StrokeWidth = 1;
				diagram.Connectors[i].Style.StrokeWidth = 1;
			}

			this.AddSubview(diagram);
		}

		//Creates the Node with Specified input
		private Node DrawNode(float x, float y, float w, float h, ShapeType shape, string annotation, float CornerRadius, UIColor fill, UIColor stroke)
		{
			var node = new Node();
			node.OffsetX = x;
			node.OffsetY = y;
			node.Width = w;
			node.Height = h;
			node.ShapeType = shape;
			node.CornerRadius = CornerRadius;
			node.Annotations.Add(new Annotation()
			{
				Content = CreateNodeLabel(annotation, node.Width, node.Height),
				HorizontalAlignment = HorizontalAlignment.Center,
				VerticalAlignment = VerticalAlignment.Center
			});
			node.Style.Brush = new SolidBrush(fill);
			node.Style.StrokeBrush = new SolidBrush(stroke);
			node.Style.StrokeWidth = 1;
			return node;
		}

		//Create Node's Annotation
		UILabel CreateNodeLabel(string text, nfloat width, nfloat height)
		{
			var label = new UILabel()
			{
				Text = text,
				TextAlignment = UITextAlignment.Center,
				TextColor = UIColor.FromRGB(255, 255, 255),
				Font = UIFont.FromName(".SF UI Text", 14),
				LineBreakMode = UILineBreakMode.WordWrap,
				Lines = 0
			};
			label.Layer.ShouldRasterize = true;
			label.Layer.RasterizationScale = UIScreen.MainScreen.Scale;
			label.Frame = new CGRect(0, 0, width, label.Text.StringSize(label.Font).Height * 3);
			return label;
		}

		//Create Connector's Annotationn
		UILabel CreateConnectorLabel(string text, int x, int y, int w, int h)
		{
			var label = new UILabel()
			{
				Text = text,
				TextColor = UIColor.FromRGB(127, 132, 133),
				Font = UIFont.FromName("Arial", 14),
				Frame = new CGRect(x, y, w, h)
			};
			label.Layer.RasterizationScale = UIScreen.MainScreen.Scale;
			label.Layer.ShouldRasterize = true;
			return label;
		}
	}
}