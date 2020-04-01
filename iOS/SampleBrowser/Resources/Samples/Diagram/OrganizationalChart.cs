#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using CoreGraphics;
using Syncfusion.SfDiagram.iOS;
using UIKit;
using Foundation;

namespace SampleBrowser
{
    public partial class OrganizationalChart : SampleView
    {
        SfDiagram diagram;
        DataModel datamodel;
        Dictionary<string, UIColor> FillColor;
        Dictionary<string, CGColor> StrokeColor;
        UIPickerView selectionPicker1;
		private UILabel overviewLabel;
		private UISwitch overviewSwitch;
        private UILabel dragLabel;
        private UISwitch dragSwitch;
        private Node RootNode;
        Overview overviewPanel;

        public OrganizationalChart()
        {
            selectionPicker1 = new UIPickerView();
            this.OptionView = new UIView();

            overviewLabel = new UILabel();
            overviewLabel.Text = "Enable Overview";
            overviewLabel.TextColor = UIColor.Black;
            overviewLabel.TextAlignment = UITextAlignment.Left;
            overviewLabel.BackgroundColor = UIColor.Clear;
            overviewLabel.Frame = new CGRect(this.Frame.X + 10, 10, 150, 30);
            overviewSwitch = new UISwitch();
            overviewSwitch.On = false;
            overviewSwitch.Frame = new CGRect(this.Frame.X + 250, 10, 50, 30);
            overviewSwitch.TouchUpInside += OverviewSwitch_TouchUpInside;
            overviewSwitch.BackgroundColor = UIColor.Clear;

            dragLabel = new UILabel();
            dragLabel.Text = "Enable Layout Drag";
            dragLabel.TextColor = UIColor.Black;
            dragLabel.TextAlignment = UITextAlignment.Left;
            dragLabel.BackgroundColor = UIColor.Clear;
            dragLabel.Frame = new CGRect(this.Frame.X + 10, 70, 150, 30);
            dragSwitch = new UISwitch();
            dragSwitch.On = false;
            dragSwitch.Frame = new CGRect(this.Frame.X + 250, 70, 50, 30);
            dragSwitch.TouchUpInside += dragSwitch_TouchUpInside;
            dragSwitch.BackgroundColor = UIColor.Clear;

            diagram = new SfDiagram();
            //Dictionary collection
            FillColor = new Dictionary<string, UIColor>();
            FillColor.Add("Managing Director", UIColor.FromRGB(239, 75, 93));
            FillColor.Add("Project Manager", UIColor.FromRGB(49, 162, 255));
            FillColor.Add("Senior Manager", UIColor.FromRGB(49, 162, 255));
            FillColor.Add("Project Lead", UIColor.FromRGB(0, 194, 192));
            FillColor.Add("Senior S/W Engg", UIColor.FromRGB(0, 194, 192));
            FillColor.Add("Software Engg", UIColor.FromRGB(0, 194, 192));
            FillColor.Add("Team Lead", UIColor.FromRGB(0, 194, 192));
            FillColor.Add("Project Trainee", UIColor.FromRGB(255, 129, 0));

            StrokeColor = new Dictionary<string, CGColor>();
            StrokeColor.Add("Managing Director", UIColor.FromRGB(201, 32, 61).CGColor);
            StrokeColor.Add("Project Manager", UIColor.FromRGB(23, 132, 206).CGColor);
            StrokeColor.Add("Senior Manager", UIColor.FromRGB(23, 132, 206).CGColor);
            StrokeColor.Add("Project Lead", UIColor.FromRGB(4, 142, 135).CGColor);
            StrokeColor.Add("Senior S/W Engg", UIColor.FromRGB(4, 142, 135).CGColor);
            StrokeColor.Add("Software Engg", UIColor.FromRGB(4, 142, 135).CGColor);
            StrokeColor.Add("Team Lead", UIColor.FromRGB(4, 142, 135).CGColor);
            StrokeColor.Add("Project Trainee", UIColor.FromRGB(206, 98, 9).CGColor);

            diagram.BeginNodeRender += Dia_BeginNodeRender;
            diagram.ItemLongPressed += Dia_ItemLongPressed;
            diagram.BackgroundColor = UIColor.White;
            diagram.EnableSelectors = false;
            diagram.NodeClicked += Dia_NodeClicked;
            diagram.Loaded += Dia_Loaded;
            //Initialize Method
            datamodel = new DataModel();
            datamodel.Data();

            //To Represent DataSourceSttings Properties
            DataSourceSettings settings = new DataSourceSettings();
            settings.ParentId = "ReportingPerson";
            settings.Id = "Name";
            settings.DataSource = datamodel.employee;
            diagram.DataSourceSettings = settings;

            //To Represent LayoutManager Properties
            diagram.LayoutManager = new LayoutManager()
            {
                Layout = new DirectedTreeLayout()
                {
                    Type = LayoutType.Organization,
                    HorizontalSpacing = 35,
                }
            };

            for (int i = 0; i < diagram.Connectors.Count; i++)
            {
                diagram.Connectors[i].TargetDecoratorType = DecoratorType.None;
                diagram.Connectors[i].Style.StrokeBrush = new SolidBrush(UIColor.FromRGB(127, 132, 133));
                diagram.Connectors[i].Style.StrokeWidth = 1;
            }
            this.AddSubview(diagram);
            diagram.Width = (float)this.Frame.Width;
            diagram.Height = (float)this.Frame.Height;
            OptionView.AddSubview(overviewLabel);
            OptionView.AddSubview(overviewSwitch);
            OptionView.AddSubview(dragLabel);
            OptionView.AddSubview(dragSwitch);

            overviewPanel = new Overview();
			overviewPanel.Layer.BorderColor = UIColor.Orange.CGColor;
			overviewPanel.Layer.BorderWidth = 2;
			overviewPanel.Frame = new CGRect(0,
											 0,
											 UIScreen.MainScreen.Bounds.Width / 2,
											 UIScreen.MainScreen.Bounds.Height / 4);
			diagram.AddSubview(overviewPanel);
            diagram.Overview = overviewPanel;
            overviewPanel.Hidden = true;
        }
        private void Diagram_OnLayoutNodeDropped(object sender, OnLayoutNodeDroppedEventArgs args)
        {
            Node draggedNode = args.DraggedItem as Node;
            Node droppedNode = args.DroppedItem as Node;
            bool contain = true;
            if (draggedNode != RootNode && draggedNode != droppedNode)
            {
                Node ParentNode = GetParent((droppedNode.Content as DiagramEmployee).ReportingPerson);
                do
                {

                    if (ParentNode != draggedNode)
                    {
                        contain = false;
                    }
                    else
                    {
                        contain = true;
                        break;

                    }
                    ParentNode = GetParent((ParentNode.Content as DiagramEmployee).ReportingPerson);
                } while (ParentNode != RootNode);

                if (!contain)
                {
                    (draggedNode.Content as DiagramEmployee).ReportingPerson = (droppedNode.Content as DiagramEmployee).Name;
                    diagram.DataSourceSettings.UpdateDataSource();
                    diagram.LayoutManager.Layout.UpdateLayout();
                }
            }
        }
        private Node GetParent(string parentId)
        {
            foreach (Node node in diagram.Nodes)
            {
                if ((node.Content as DiagramEmployee).Name == parentId)
                {
                    return node;
                }
            }
            return RootNode;
        }
        void dragSwitch_TouchUpInside(object sender, EventArgs e)
        {
            if ((sender as UISwitch).On)
            {
                (diagram.LayoutManager.Layout as DirectedTreeLayout).Draggable = true;
            }
            else
            {
                (diagram.LayoutManager.Layout as DirectedTreeLayout).Draggable = false;
            }
        }

        void OverviewSwitch_TouchUpInside(object sender, EventArgs e)
        {
            if ((sender as UISwitch).On)
            {
                overviewPanel.Hidden = false;
            }
            else
            {
                overviewPanel.Hidden = true;
            }
        }

        void Dia_Loaded(object sender)
		{
			diagram.BringToView(diagram.Nodes[0]);
		}

		void Dia_BeginNodeRender(object sender, BeginNodeRenderEventArgs args)
		{
			var node = (args.Item as Node);
			node.Width = 155;
			node.Height = 50;
			DrawTemplate(node);
		}

		void DrawTemplate(Node node)
		{
			var template = new UIView();
			template.Frame = new CGRect(0, 0, node.Width, node.Height);
			template.BackgroundColor = FillColor[(node.Content as DiagramEmployee).Designation];
			template.Layer.BorderColor = StrokeColor[((node.Content as DiagramEmployee).Designation)];
			template.Layer.CornerRadius = 4;
			template.Layer.BorderWidth = 1;
			//EMP IMAGE
			var img = new UIImageView();
			img.Frame = new CGRect(5, 8, 35, 35);
			img.Image = UIImage.FromBundle((node.Content as DiagramEmployee).ImageUrl);
			//EMP NAME
			var name = new UILabel()
			{
				Text = (node.Content as DiagramEmployee).Name,
				Font = UIFont.FromName(".SF UI Text", 12),
				TextColor = UIColor.FromRGB(255, 255, 255),
				Frame = new CGRect(45, -10, node.Width, node.Height)
			};
			name.Layer.ShouldRasterize = true;
			name.Layer.RasterizationScale = UIScreen.MainScreen.Scale;
			//EMP DESIGNATION
			var designation = new UILabel()
			{
				Text = (node.Content as DiagramEmployee).Designation,
				Font = UIFont.FromName(".SF UI Text", 12),
				TextColor = UIColor.FromRGB(255, 255, 255),
				Frame = new CGRect(45, 8, node.Width, node.Height)
			};
			designation.Layer.ShouldRasterize = true;
			designation.Layer.RasterizationScale = UIScreen.MainScreen.Scale;
			if ((node.Content as DiagramEmployee).HasChild)
			{
				template.Frame = new CGRect(0, 0, node.Width + 35, node.Height);
				var indication = new UILabel();
				indication.Frame = new CGRect(node.Width - 2, node.Height / 2 - 22.5, 40, 40);
				indication.Font = UIFont.FromName(".SF UI Text", 35);
				indication.TextAlignment = UITextAlignment.Center;
				indication.TextColor = UIColor.White;
				indication.Text = "-";
				template.AddSubview(indication);
				var indicationLine = new UIView();
				indicationLine.Frame = new CGRect(node.Width - 5, 0, 1, node.Height);
				indicationLine.BackgroundColor = new UIColor(template.Layer.BorderColor);
				template.AddSubview(indicationLine);
				indication.Layer.ShouldRasterize = true;
				indication.Layer.RasterizationScale = UIScreen.MainScreen.Scale;
			}
			template.AddSubview(img);
			template.AddSubview(name);
			template.AddSubview(designation);
			node.Template = template;
		}

        void Dia_ItemLongPressed(object sender, ItemLongPressedEventArgs args)
        {
            if (!((diagram.LayoutManager.Layout as DirectedTreeLayout).Draggable))
            {
                var node = args.Item as Node;
                var info = new UIAlertView();
                info.AddButton("OK");
                info.Message = "Name : " + (node.Content as DiagramEmployee).Name + "\n" +
                    "Designation : " + (node.Content as DiagramEmployee).Designation + "\n" +
                    "ID : " + (node.Content as DiagramEmployee).ID + "\n" +
                    "DOJ : " + (node.Content as DiagramEmployee).DOJ + "\n" +
                    "Reporting Person : " + (node.Content as DiagramEmployee).ReportingPerson;
                info.Show();
            }
        }

        void Dia_NodeClicked(object sender, NodeClickedEventArgs args)
		{
			if (args.Item.IsExpanded)
			{
				if ((args.Item.Content as DiagramEmployee).HasChild)
				{
					((args.Item.Template as UIView).Subviews[0] as UILabel).Font = UIFont.SystemFontOfSize(30);
					((args.Item.Template as UIView).Subviews[0] as UILabel).Text = "+";
				}
				args.Item.IsExpanded = false;
			}
			else
			{
				if ((args.Item.Content as DiagramEmployee).HasChild)
				{
					((args.Item.Template as UIView).Subviews[0] as UILabel).Font = UIFont.SystemFontOfSize(35);
					((args.Item.Template as UIView).Subviews[0] as UILabel).Text = "-";
				}
				args.Item.IsExpanded = true;
			}
		}
    }
}