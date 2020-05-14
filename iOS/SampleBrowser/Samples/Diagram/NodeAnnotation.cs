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
	public partial class NodeAnnotation : SampleView
	{
        SfDiagram diagram;

		public NodeAnnotation()
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

            //Create Node
			Node n1 = DrawNode(270, 165, 100, 60);
			n1.Style.Brush = new SolidBrush(UIColor.White);
			n1.Annotations.Add(new Annotation() {  Content = "NODE" });
            diagram.AddNode(n1);

			Node n2 = DrawNode(50, (float)141.5, 110, 110);
			n2.Style.Brush = new SolidBrush(UIColor.White);
			n2.Style.StrokeWidth = 3;
			var img = new UIImageView(UIImage.FromBundle("Images/Diagram/emp.png"));
			img.Frame = new CGRect(n2.Style.StrokeWidth/2,n2.Style.StrokeWidth/2, n2.Width-n2.Style.StrokeWidth, n2.Height-n2.Style.StrokeWidth);
			n2.Annotations.Add(new Annotation() { Content = img });
            diagram.AddNode(n2);

			Node n3 = DrawNode(50, 300, 230, 140);
			n3.ShapeType = ShapeType.RoundedRectangle;
			n3.CornerRadius = 8;
			n3.Style.Brush = new SolidBrush(UIColor.FromRGB(58, 179, 255));
			n3.Style.StrokeBrush =new SolidBrush( UIColor.FromRGB(0,117,168));
			n3.Style.StrokeWidth = 3;

            //To defines the button properties
			var button = new UIButton();
			button.Frame = new CGRect(60, 100, 110, 30);
			button.SetTitle("View Profile", UIControlState.Normal);
			button.SetTitleColor(UIColor.White, UIControlState.Normal);
			button.Layer.CornerRadius = 5;
			button.Layer.BorderWidth = 2;
			button.Layer.BorderColor = UIColor.White.CGColor;
			button.Font = UIFont.BoldSystemFontOfSize(10);

            //Create new uiimageview
			var emp = new UIImageView(UIImage.FromBundle("Images/Diagram/Paul.png"));
			emp.Frame = new CGRect(14, 14, 70, 70);

            //Defines the lable for node
			var label = new UILabel()
			{
				Text = "JOHN STEEL \n Business Analyst",
				TextColor = UIColor.White,
				Font = UIFont.FromName(".SF UI Text", 12),
				LineBreakMode = UILineBreakMode.WordWrap,
				Lines = 0,
				Frame = new CGRect(95, -25, n3.Width, n3.Height)
			};

            //Add annotation to the node.
			n3.Annotations.Add(new Annotation() { Content = label });
			n3.Annotations.Add(new Annotation() { Content = button });
			n3.Annotations.Add(new Annotation() { Content = emp });
			diagram.AddNode(n3);

			Node n4 = DrawNode(390, 300, 140, 140);
			n4.Style.StrokeWidth = 0;
			n4.Style.Brush = new SolidBrush(UIColor.FromRGB(69, 179, 157));
			var txt = new UILabel()
			{
				Text = "CONTENT SHAPE",
				Font = UIFont.FromName("ArialMT", 14),
				TextAlignment= UITextAlignment.Center
			};
			txt.Frame = new CGRect(2, 45, n4.Width, n4.Height);
			var contentShape = new Shape(n4);
			n4.Annotations.Add(new Annotation() { Content = contentShape });
			n4.Annotations.Add(new Annotation() { Content = txt });
			diagram.AddNode(n4);

            //Create Connector
            Connector c1 = new Connector(n1, n2);
			c1.SegmentType = SegmentType.StraightSegment;
            diagram.AddConnector(c1);
            
            Connector c2 = new Connector(n1, n3);
			c2.SegmentType = SegmentType.StraightSegment;
            diagram.AddConnector(c2);
            
            Connector c3 = new Connector(n1, n4);
			c3.SegmentType = SegmentType.StraightSegment;
            diagram.AddConnector(c3);

			this.AddSubview(diagram);
        }

        //Creates the Node with Specified input
        Node DrawNode(float x, float y, float w, float h)
		{
			var node = new Node();
			node.OffsetX = x;
			node.OffsetY = y;
			node.Width = w;
			node.Height = h;
			return node;
		}

        //Create Node's Annotation
        UILabel CreateLabel(string text, nfloat width, nfloat height)
		{
			var label = new UILabel()
			{
				Text = text,
				TextColor = UIColor.Black,
				Font = UIFont.FromName(".SF UI Text", 13),
				LineBreakMode = UILineBreakMode.WordWrap,
				Lines = 0,
				Frame = new CGRect(0, 0, width, height)
			};
			return label;
		}

		/// <summary>
		/// Class to render custom shape
		/// </summary>
		class Shape : UIView
		{
			public Shape(Node node)
			{
				Frame = new CGRect(node.Width/2-25, node.Height/2-40, 50, 50);
				BackgroundColor = UIColor.Clear;
			}
			public override void Draw(CGRect rect)
			{
				base.Draw(rect);
				using (CGContext g = UIGraphics.GetCurrentContext())
				{
					var sample = new CGPath();
					sample.AddLines(new CGPoint[] {
					new CGPoint(Frame.Width/2, 0),new CGPoint(Frame.Width/2.8, Frame.Height/2.5),
					new CGPoint(0, Frame.Height/2.5),
					new CGPoint(Frame.Width/3.5, Frame.Height/1.75),
					new CGPoint(Frame.Width/7, Frame.Height),
						new CGPoint(Frame.Width/2, Frame.Height/1.4),
						new CGPoint(Frame.Width/1.2, Frame.Height),
						new CGPoint(Frame.Width/1.4, Frame.Height/1.75),
					new CGPoint(Frame.Width, Frame.Height/2.5),
					new CGPoint(Frame.Width/1.6, Frame.Height/2.5),
					new CGPoint(Frame.Width/2, 0)
				});
					g.AddPath(sample);
					UIColor.White.SetStroke();
					UIColor.White.SetFill();
					g.DrawPath(CGPathDrawingMode.FillStroke);
				}
			}
		}
	}
}
