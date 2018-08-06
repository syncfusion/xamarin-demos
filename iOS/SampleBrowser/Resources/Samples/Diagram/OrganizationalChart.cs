#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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

namespace SampleBrowser
{
	public partial class OrganizationalChart : SampleView
	{
		SfDiagram diagram;
		private UIView parentView;
		private string selectedType;
		private string selectedorientation;
		UILabel verticalLabel;
		UIButton verticalbutton = new UIButton();
		UIButton horizontalbutton = new UIButton();
		UIButton doneButton = new UIButton();
		UIPickerView selectionPicker1;
		DataModel datamodel;
		Dictionary<string, UIColor> FillColor;
		Dictionary<string, CGColor> StrokeColor;

		private readonly IList<string> verticalOrientationlist = new List<string>
		{
			"Alternate",
			"Right",
			"Left"
		};

		public OrganizationalChart()
		{
			parentView = new UIView(this.Frame);
			//Initialize the sfdiagram
			diagram = new SfDiagram();
			//Dictionary collection
			FillColor = new Dictionary<string, UIColor>();
			FillColor.Add("Managing Director", UIColor.FromRGB(239, 75, 93));
			FillColor.Add("Project Manager", UIColor.FromRGB(49, 162, 255));
			FillColor.Add("Senior Manager", UIColor.FromRGB(49, 162, 255));
			FillColor.Add("Project Lead", UIColor.FromRGB(0, 194, 192));
			FillColor.Add("Senior S/W Engg", UIColor.FromRGB(0, 194, 192));
			FillColor.Add("Team Manager", UIColor.FromRGB(0, 194, 192));
			FillColor.Add("Project Trainee", UIColor.FromRGB(255, 129, 0));

			StrokeColor = new Dictionary<string, CGColor>();
			StrokeColor.Add("Managing Director", UIColor.FromRGB(201, 32, 61).CGColor);
			StrokeColor.Add("Project Manager", UIColor.FromRGB(23, 132, 206).CGColor);
			StrokeColor.Add("Senior Manager", UIColor.FromRGB(23, 132, 206).CGColor);
			StrokeColor.Add("Project Lead", UIColor.FromRGB(4, 142, 135).CGColor);
			StrokeColor.Add("Senior S/W Engg", UIColor.FromRGB(4, 142, 135).CGColor);
			StrokeColor.Add("Team Manager", UIColor.FromRGB(4, 142, 135).CGColor);
			StrokeColor.Add("Project Trainee", UIColor.FromRGB(206, 98, 9).CGColor);

			//Defines the picker
			selectionPicker1 = new UIPickerView();
			this.OptionView = new UIView();
			datamodel = new DataModel();

			PickerModel model = new PickerModel(verticalOrientationlist);
			selectionPicker1.Model = model;

			//Represent the vertical label
			verticalLabel = new UILabel();
			verticalLabel.Text = "Orientation and ChartType";
			verticalLabel.TextColor = UIColor.Black;
			verticalLabel.TextAlignment = UITextAlignment.Left;

			//Represent the vertical button
			verticalbutton = new UIButton();
			verticalbutton.SetTitle("Vertical", UIControlState.Normal);
			verticalbutton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			verticalbutton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			verticalbutton.Layer.CornerRadius = 8;
			verticalbutton.Layer.BorderWidth = 2;
			verticalbutton.TouchUpInside += ShowPicker1;
			verticalbutton.BackgroundColor = UIColor.Gray;
			verticalbutton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;

			//Represent the horizontal button
			horizontalbutton = new UIButton();

			horizontalbutton.SetTitle("Horizontal", UIControlState.Normal);
			horizontalbutton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			horizontalbutton.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;
			horizontalbutton.Layer.CornerRadius = 8;
			horizontalbutton.Layer.BorderWidth = 2;
			horizontalbutton.TouchUpInside += ShowPicker1;
			horizontalbutton.Layer.BorderColor = UIColor.FromRGB(246, 246, 246).CGColor;

			//Represent the button
			doneButton.SetTitle("Done\t", UIControlState.Normal);
			doneButton.SetTitleColor(UIColor.Black, UIControlState.Normal);
			doneButton.HorizontalAlignment = UIControlContentHorizontalAlignment.Right;
			doneButton.TouchUpInside += HidePicker;
			doneButton.Hidden = true;
			doneButton.BackgroundColor = UIColor.FromRGB(246, 246, 246);

			model.PickerChanged += SelectedIndexChanged;

			selectionPicker1.ShowSelectionIndicator = true;
			selectionPicker1.Hidden = true;

			this.OptionView = new UIView();
		}

		/// <summary>
		/// Add childview to the parent
		/// </summary>
		public void optionView()
		{
			this.OptionView.AddSubview(verticalLabel);
			this.OptionView.AddSubview(verticalbutton);
			this.OptionView.AddSubview(horizontalbutton);
			this.OptionView.AddSubview(selectionPicker1);
			this.OptionView.AddSubview(doneButton);
		}

		/// <summary>
		/// Show the picker
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void ShowPicker1(object sender, EventArgs e)
		{
			(sender as UIButton).BackgroundColor = UIColor.Gray;
			selectedorientation = (sender as UIButton).CurrentTitle;
			if ((sender as UIButton).CurrentTitle == "Horizontal")
			{
				verticalbutton.BackgroundColor = UIColor.White;
			}
			else
			{
				horizontalbutton.BackgroundColor = UIColor.White;
			}
			doneButton.Hidden = false;
			selectionPicker1.Hidden = false;
		}

		/// <summary>
		/// Hide the picker
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void HidePicker(object sender, EventArgs e)
		{
			doneButton.Hidden = true;
			selectionPicker1.Hidden = true;
		}

		/// <summary>
		/// Change the index value
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SelectedIndexChanged(object sender, PickerChangedEventArgs e)
		{
			this.selectedType = selectedorientation + e.SelectedValue;
			(diagram.LayoutManager.Layout as DirectedTreeLayout).UpdateLayout();
		}

		/// <summary>
		/// Beginnoderender event args
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
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
			var node = args.Item as Node;
			var info = new UIAlertView();
			info.AddButton("OK");
			info.Message = "Name : " + (node.Content as DiagramEmployee).Name + "\n" +
				"Designation : " + (node.Content as DiagramEmployee).Designation + "\n" +
				"Reporting Person : " + (node.Content as DiagramEmployee).ReportingPerson;
			info.Show();
		}

		void Dia_NodeClicked(object sender, NodeClickedEventArgs args)
		{
			if (args.Item.IsExpanded)
			{
				if ((args.Item.Content as DiagramEmployee).HasChild)
				{
					((args.Item.Template as UIView).Subviews[0] as UILabel).Text = "+";
				}
				args.Item.IsExpanded = false;
			}
			else
			{
				if ((args.Item.Content as DiagramEmployee).HasChild)
				{
					((args.Item.Template as UIView).Subviews[0] as UILabel).Text = "-";
				}
				args.Item.IsExpanded = true;
			}
		}

		public override void LayoutSubviews()
		{
			base.LayoutSubviews();

			parentView.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);
			diagram.BeginNodeRender += Dia_BeginNodeRender;
			diagram.BeginNodeLayout += Dia_GetLayoutInfo;
			diagram.ItemLongPressed += Dia_ItemLongPressed;
			diagram.BackgroundColor = UIColor.White;
			diagram.EnableSelectors = false;
			diagram.NodeClicked += Dia_NodeClicked;
			//Initialize Method
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

			//Set width and height for diagram
			diagram.Width = (float)parentView.Frame.Width;
			diagram.Height = (float)parentView.Frame.Height;
			parentView.AddSubview(diagram);
			this.AddSubview(parentView);

			foreach (var view in this.Subviews)
			{
				verticalLabel.Frame = new CGRect(this.Frame.X + 10, 0, PopoverSize.Width - 20, 30);
				verticalbutton.Frame = new CGRect(this.Frame.X + 10, 40, PopoverSize.Width - 20, 30);
				horizontalbutton.Frame = new CGRect(this.Frame.X + 10, 80, PopoverSize.Width - 20, 30);
				selectionPicker1.Frame = new CGRect(0, PopoverSize.Height / 2, PopoverSize.Width, PopoverSize.Height / 3);
				doneButton.Frame = new CGRect(0, PopoverSize.Height / 2.5, PopoverSize.Width, 40);
			}
			this.optionView();
		}

		/// <summary>
		/// Beginnodelayoutinfo event args
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="args"></param>
		void Dia_GetLayoutInfo(object sender, BeginNodeLayoutEventArgs args)
		{
			if ((diagram.LayoutManager.Layout as DirectedTreeLayout).Type == LayoutType.Organization)
			{
				switch (selectedType)
				{
					case "VerticalAlternate":
						if (!args.HasChildNodes)
						{
							args.Type = ChartType.Alternate;
							args.Orientation = Syncfusion.SfDiagram.iOS.Orientation.Vertical;
						}
						break;
					case "VerticalLeft":
						if (!args.HasChildNodes)
						{
							args.Type = ChartType.Left;
							args.Orientation = Syncfusion.SfDiagram.iOS.Orientation.Vertical;
						}
						break;
					case "VerticalRight":
						if (!args.HasChildNodes)
						{
							args.Type = ChartType.Right;
							args.Orientation = Syncfusion.SfDiagram.iOS.Orientation.Vertical;
						}
						break;
					case "HorizontalAlternate":
						if (!args.HasChildNodes)
						{
							args.Type = ChartType.Alternate;
							args.Orientation = Syncfusion.SfDiagram.iOS.Orientation.Horizontal;
						}
						break;
					case "HorizontalLeft":
						if (!args.HasChildNodes)
						{
							args.Type = ChartType.Left;
							args.Orientation = Syncfusion.SfDiagram.iOS.Orientation.Horizontal;
						}
						break;
					case "HorizontalRight":
						if (!args.HasChildNodes)
						{
							args.Type = ChartType.Right;
							args.Orientation = Syncfusion.SfDiagram.iOS.Orientation.Horizontal;
						}
						break;
				}
			}
		}
	}
}