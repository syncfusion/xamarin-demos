#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using CoreGraphics;
using Syncfusion.SfDiagram.iOS;
using UIKit;

namespace SampleBrowser
{
	public class MindMap : SampleView
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
		String path;
		UITextView CommentBoxEntry=new UITextView();
		List<UIColor> FColor = new List<UIColor>();
		List<UIColor> SColor = new List<UIColor>();
		int index;
		SfDiagram diagram = new SfDiagram();
		public MindMap()
		{
			var width = 150;
			var height = 75;
			path = "Images/Diagram/MindMapImages";
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
			node.Style.StrokeWidth = 3;
			node.Annotations.Add(new Annotation() { Content = text, FontSize = 15, TextBrush = new SolidBrush(UIColor.Black) });
			return node;
		}

		private void AddAnnotation(string headertext)
		{
			Notifier = new UIView();
			Notifier.Frame = new CGRect(UIScreen.MainScreen.Bounds.Width / 2 - 150, UIScreen.MainScreen.Bounds.Height / 2 - 75, 300, 150);
			Notifier.Layer.CornerRadius = 5;
			Notifier.BackgroundColor = UIColor.White;
			diagram.PageSettings.BackgroundColor = UIColor.DarkGray;
			diagram.Layer.Opacity = 0.2f;

			var title = new UILabel();
			title.Frame = new CGRect(10, 10, Notifier.Frame.Width, 30);
			title.Text = headertext;
			title.TextColor = UIColor.Black;
			Notifier.Add(title);

			textinput = new UITextView();
			textinput.Frame = new CGRect(10, 50, Notifier.Frame.Width, 50);
			textinput.Changed+= Textinput_Changed;

			UIButton ok = new UIButton();
			ok.SetTitle("OK", UIControlState.Normal);
			ok.TouchUpInside += Ok_TouchUpInside; 

			Notifier.AddSubview(textinput);
			Notifier.AddSubview(ok);
			this.AddSubview(Notifier);
		}


		private void AddHandles()
		{
			var template = new UIImageView();
			template.Frame = new CGRect(0, 0, 25, 25);
			var img = new UIImage(path + "plus.png");
			template.Image = img;

			var deltemplate = new UIImageView();
			deltemplate.Frame = new CGRect(0, 0, 25, 25);
			img = new UIImage(path + "delete.png");
			deltemplate.Image = img;
				
			ExpandTemplate = new UIImageView();
			ExpandTemplate.Frame = new CGRect(0, 0, 25, 25);
			img = new UIImage(path + "expand.png");
			ExpandTemplate.Image = img;

			CollapseTemplate = new UIImageView();
			CollapseTemplate.Frame = new CGRect(0, 0, 25, 25);
			img = new UIImage(path + "collpase.png");
			CollapseTemplate.Image = img;

			var moretemplate = new UIImageView();
			moretemplate.Frame = new CGRect(0, 0, 25, 25);
			img = new UIImage(path + "more.png");
			moretemplate.Image = img;


			DefaultHandles = new UserHandleCollection(diagram);
			DefaultHandles.Add(new UserHandle("Left", UserHandlePosition.Left, template));
			DefaultHandles.Add(new UserHandle("Right", UserHandlePosition.Right, template));
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
			diagram.LayoutManager.Layout.UpdateLayout();
			diagram.Select(RootNode);
			diagram.BringToView(RootNode);
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
				if (CommentBoxEntry.Text != null)
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
					(diagram.LayoutManager.Layout as MindMapLayout).UpdateLayout();
				}
				else if (args.Item.Name == "ExpColl")
				{
					if (SelectedNode.IsExpanded)
					{
						SelectedNode.IsExpanded = false;
						args.Item.Content = CollapseTemplate;
						diagram.UserHandles[0].Visible = false;
						if (SelectedNode == RootNode)
							diagram.UserHandles[1].Visible = false;
					}
					else
					{
						SelectedNode.IsExpanded = true;
						args.Item.Content = ExpandTemplate;
						diagram.UserHandles[0].Visible = true;
						if (SelectedNode == RootNode)
							diagram.UserHandles[1].Visible = true;
					}
					(diagram.LayoutManager.Layout as MindMapLayout).UpdateLayout();
					diagram.Select(SelectedNode);
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
			InfoNotifier = new UIView();
			InfoNotifier.Frame = new CGRect(UIScreen.MainScreen.Bounds.Width / 2 - 150, UIScreen.MainScreen.Bounds.Height / 2 - 125, 300, 250);
			InfoNotifier.Layer.CornerRadius = 5;
			InfoNotifier.BackgroundColor = UIColor.White;
			this.AddSubview(InfoNotifier);

			UILabel title = new UILabel();
			title.Frame = new CGRect(0, 0, InfoNotifier.Frame.Width, 30);
			title.Text = " Add Comments";
			title.TextColor = UIColor.Black;
			InfoNotifier.AddSubview(title);

			UITextView CommentBoxEntry = new UITextView();
			CommentBoxEntry.Frame = new CGRect(0, 120, InfoNotifier.Frame.Width, InfoNotifier.Frame.Height - 120);
			if (SelectedNode.Content == null)
			{
				CommentBoxEntry.Text = "";
			}
			CommentBoxEntry.Text = (SelectedNode.Content as String);
			InfoNotifier.AddSubview(CommentBoxEntry);

			UIButton ok = new UIButton();
			ok.Frame = new CGRect(0, 250, InfoNotifier.Frame.Width, 50);
			ok.SetTitle("OK", UIControlState.Normal);
			ok.TouchUpInside+= Ok_TouchUpInside1;
			InfoNotifier.AddSubview(ok);
		}

		void Textinput_Changed(object sender, EventArgs e)
		{
			Notifier.Frame = new CGRect(Notifier.Frame.X, 50, Notifier.Frame.Width, Notifier.Frame.Height);
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
				(diagram.LayoutManager.Layout as MindMapLayout).UpdateLeftOrTop();
			}
			else if (CurrentHandle == UserHandlePosition.Right)
			{
				diagram.UserHandles = RightSideHandle;
				(diagram.LayoutManager.Layout as MindMapLayout).UpdateRightOrBottom();
			}
			diagram.Select(node);
			SelectedNode = node;
			diagram.BringToView(node);
		}

		void Ok_TouchUpInside1(object sender, EventArgs e)
		{
			if (CommentBoxEntry.Text != null)
			{
				SelectedNode.Content = CommentBoxEntry.Text;
			}
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
					diagram.UserHandles[2].Content = ExpandTemplate;
				}
				else
				{
					diagram.UserHandles[0].Visible = false;
					if (SelectedNode == RootNode)
						diagram.UserHandles[1].Visible = false;
					diagram.UserHandles[2].Content = CollapseTemplate;
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

		void Ok_Clicked1(object sender, EventArgs e)
		{
			if (CommentBoxEntry.Text != null)
			{
				SelectedNode.Content = CommentBoxEntry.Text;
			}
			InfoNotifier.RemoveFromSuperview();
		}
	}
}