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
        UIPickerView selectionPicker1;
        UILabel gridColor;
        UIScrollView colorView = new UIScrollView();
        UILabel enablegrid;
        UISwitch gridswitch;
		UILabel snapgrid;
		UISwitch snapgridswitch;
		UILabel sizeindicator;
		UIImageView plusimg;
		UIImageView minusimg;
        UILabel gridSize;
		UIButton minus;
        UIButton plus;
        UIButton currentButton;
		int width = 12;
		public FlowDiagram()
		{
			diagram = new SfDiagram();

			selectionPicker1 = new UIPickerView();
			this.OptionView = new UIView();
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
            diagram.EnableTextEditing = false;
			diagram.PageSettings.GridSize = 12;
			diagram.PageSettings.GridColor = UIColor.FromRGB(230, 230, 230);
            this.AddSubview(diagram);

			gridColor = new UILabel();
			gridColor.Text = "Grid Color";
			gridColor.TextColor = UIColor.Black;
			gridColor.TextAlignment = UITextAlignment.Left;
			gridColor.BackgroundColor = UIColor.Clear;

			colorView.BackgroundColor = UIColor.Clear;
			colorView.ScrollEnabled = true;
			colorView.ShowsHorizontalScrollIndicator = true;
			colorView.ShowsVerticalScrollIndicator = false;

			int x = 50;
			colorView.AddSubview(AddColorButton(10, UIColor.Red));
			colorView.AddSubview(AddColorButton((x * 1), UIColor.Orange));
			colorView.AddSubview(AddColorButton((x * 2), UIColor.FromRGB(0, 128, 0)));
			colorView.AddSubview(AddColorButton((x * 3), UIColor.Blue));
			colorView.AddSubview(AddColorButton((x * 4), UIColor.Purple));
			colorView.AddSubview(AddColorButton((x * 5), UIColor.FromRGB(51, 255, 255)));
			colorView.AddSubview(AddColorButton((x * 6), UIColor.FromRGB(255, 0, 255)));
			colorView.AddSubview(AddColorButton((x * 7), UIColor.Gray));
			colorView.AddSubview(AddColorButton((x * 8), UIColor.FromRGB(0, 255, 0)));
			colorView.AddSubview(AddColorButton((x * 9), UIColor.FromRGB(128, 0, 0)));
			colorView.AddSubview(AddColorButton((x * 10), UIColor.FromRGB(0, 0, 128)));
			colorView.AddSubview(AddColorButton((x * 11), UIColor.FromRGB(128, 128, 0)));
			colorView.AddSubview(AddColorButton((x * 12), UIColor.FromRGB(192, 192, 192)));
			colorView.AddSubview(AddColorButton((x * 13), UIColor.FromRGB(0, 128, 128)));
			colorView.ContentSize = new CGSize(850, colorView.ContentSize.Height);
			enablegrid = new UILabel();
			enablegrid.Text = "Show Grid";
			enablegrid.TextColor = UIColor.Black;
			enablegrid.TextAlignment = UITextAlignment.Left;
			enablegrid.BackgroundColor = UIColor.Clear;

			enablegrid = new UILabel();
			enablegrid.Text = "Show Grid";
			enablegrid.TextColor = UIColor.Black;
			enablegrid.TextAlignment = UITextAlignment.Left;
			enablegrid.BackgroundColor = UIColor.Clear;

			gridswitch = new UISwitch();
			gridswitch.TouchUpInside += Gridswitch_TouchUpInside;
			gridswitch.BackgroundColor = UIColor.Clear;

			snapgrid = new UILabel();
			snapgrid.Text = "Snap To Grid";
			snapgrid.TextColor = UIColor.Black;
			snapgrid.TextAlignment = UITextAlignment.Left;
			snapgrid.BackgroundColor = UIColor.Clear;

			snapgridswitch = new UISwitch();
			snapgridswitch.TouchUpInside += Snapgridswitch_TouchUpInside;
			snapgridswitch.BackgroundColor = UIColor.Clear;
			snapgridswitch.Enabled = false;

			gridSize = new UILabel();
			gridSize.Text = "Size";
			gridSize.TextColor = UIColor.Black;
			gridSize.TextAlignment = UITextAlignment.Left;

			plus = new UIButton();
			plus.BackgroundColor = UIColor.White;
			plus.Layer.CornerRadius = 8;
			plus.Layer.BorderWidth = 0.5f;
			plus.TouchUpInside += Plus_TouchUpInside;
			plusimg = new UIImageView();
			plusimg.Image = UIImage.FromBundle("Images/Diagram/CSplus.png");
			plus.AddSubview(plusimg);

			minus = new UIButton();
			minus.BackgroundColor = UIColor.White;
			minus.Layer.CornerRadius = 8;
			minus.Layer.BorderWidth = 0.5f;
			minus.TouchUpInside += Minus_TouchUpInside;
			minusimg = new UIImageView();
			minusimg.Image = UIImage.FromBundle("Images/Diagram/CSsub.png");
			minus.AddSubview(minusimg);

			sizeindicator = new UILabel();
			sizeindicator.Text = width.ToString();
			sizeindicator.BackgroundColor = UIColor.Clear;
			sizeindicator.TextColor = UIColor.Black;
			sizeindicator.TextAlignment = UITextAlignment.Center;
            optionView();


			gridColor.Frame = new CGRect(this.Frame.X + 10, 20, 100, 30);
			colorView.Frame = new CGRect(this.Frame.X + 10, 60, 300, 45);
			colorView.ContentSize = new CGSize(850, colorView.ContentSize.Height);
			enablegrid.Frame = new CGRect(this.Frame.X + 10, 120, 100, 30);
			gridswitch.Frame = new CGRect(this.Frame.X + 250, 120, 40, 30);
			snapgrid.Frame = new CGRect(this.Frame.X + 10, 170, 100, 30);
			snapgridswitch.Frame = new CGRect(this.Frame.X + 250, 170, 40, 30);
			gridSize.Frame = new CGRect(this.Frame.X + 10, 220, PopoverSize.Width - 20, 30);
			plus.Frame = new CGRect(this.Frame.X + 160, 270, 30, 30);
			plusimg.Frame = new CGRect(0, 0, 30, 30);
			minus.Frame = new CGRect(this.Frame.X + 60, 270, 30, 30);
			minusimg.Frame = new CGRect(0, 0, 30, 30);
			sizeindicator.Frame = new CGRect(this.Frame.X + 110, 270, 30, 30);

			diagram.ConnectorClicked += Diagram_ConnectorClicked;
            diagram.ContextMenuSettings.Visibility = false;
		}
		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
            diagram.LayoutSubviews();
            //diagram.EnableSelectors = false;
            UpdateSelectors();
			//Create Node
			
		}
		void Diagram_ConnectorClicked(object sender, ConnectorClickedEventArgs args)
		{
			diagram.ClearSelection();
		}

        private UIButton AddColorButton(int v, UIColor color)
        {
			UIButton button = new UIButton();
            button.BackgroundColor = color;
			button.Frame = new CGRect(v, 5, 30, 30);
			button.Layer.CornerRadius = 15;
            button.Layer.BorderColor = UIColor.White.CGColor;
			button.Layer.BorderWidth = 1.5f;
            button.TouchUpInside+= Button_TouchUpInside;
			return button;
        }

        private void UpdateSelectors()
        {
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
        }

        private void optionView()
        {
            this.OptionView.AddSubview(gridColor);
            this.OptionView.AddSubview(colorView);
            this.OptionView.AddSubview(enablegrid);
            this.OptionView.AddSubview(gridswitch);
			this.OptionView.AddSubview(snapgrid);
			this.OptionView.AddSubview(snapgridswitch);
			this.OptionView.AddSubview(gridSize);
			this.OptionView.AddSubview(plus);
			this.OptionView.AddSubview(minus);
			this.OptionView.AddSubview(sizeindicator);
        }

		void Plus_TouchUpInside(object sender, EventArgs e)
		{
            if (diagram.PageSettings.ShowGrid)
            {
                if (width < 20)
                {
                    width++;
                    diagram.PageSettings.GridSize = width;
                    sizeindicator.Text = diagram.PageSettings.GridSize.ToString();
                }
            }
		}

		void Minus_TouchUpInside(object sender, EventArgs e)
		{
            if (diagram.PageSettings.ShowGrid)
            {
                if (width > 5)
                {
                    width--;
                    diagram.PageSettings.GridSize = width;
                    sizeindicator.Text = diagram.PageSettings.GridSize.ToString();
                }
            }
		}

        void Gridswitch_TouchUpInside(object sender, EventArgs e)
        {
            if((sender as UISwitch).On)
            {
                diagram.PageSettings.ShowGrid = true;
                snapgridswitch.Enabled = true;
            }
            else
			{
                diagram.PageSettings.ShowGrid = false;
                if (snapgridswitch.On)
                    snapgridswitch.Enabled = false;
			}
        }

        void Snapgridswitch_TouchUpInside(object sender, EventArgs e)
        {
            if (gridswitch.On)
            {
                if ((sender as UISwitch).On)
                {
                    diagram.PageSettings.SnapToGrid = true;
                }
                else
                {
                    diagram.PageSettings.SnapToGrid = false;
                }
            }
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

        void Button_TouchUpInside(object sender, EventArgs e)
        {
            if(diagram.PageSettings.ShowGrid)
            {
                if (currentButton != null)
                {
                    currentButton.Layer.BorderColor = UIColor.White.CGColor;
                    (sender as UIButton).Layer.BorderWidth = 1.5f;
                }
				currentButton = sender as UIButton;
                diagram.PageSettings.GridColor = (sender as UIButton).BackgroundColor;
                (sender as UIButton).Layer.BorderColor = UIColor.FromRGB(30, 144, 255).CGColor;
                (sender as UIButton).Layer.BorderWidth = 2.5f;
            }
        }
    }
}