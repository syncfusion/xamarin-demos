#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Drawing;
using CoreGraphics;
using UIKit;

namespace SampleBrowser
{
	public class LinePath
	{
		public int LineWidth { get; set; }
		public UIColor PenColor { get; set; }
		public UIBezierPath Path { get; set; }
	}
	public class CustomDrawing : UIView
	{
		List<LinePath> linePathCollection;
		UIColor penColor;
		// clear the canvas
		public void Clear()
		{
			path.Dispose();
			linePathCollection.Clear();
			path = new UIBezierPath();
			canTouchDraw = false;
			SetNeedsDisplay();
		}

		public CustomDrawing()
		{
			linePathCollection = new List<LinePath>();
			this.Frame = new CGRect(0, 0, UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height);
			path = new UIBezierPath();
			this.PenColor = UIColor.Black;
			this.lineWidth = 8;
			this.BackgroundColor = UIColor.White;
		}
		public event EventHandler<EventArgs> Tapped;
		internal virtual void OnTapped(EventArgs args)
		{
			if (this.Tapped != null)
				this.Tapped(this, args);
		}
		private CGPoint touchLocation;
		private CGPoint prevTouchLocation;
		private bool canTouchDraw;
		private int lineWidth;
		UIBezierPath path;
		public int LineWidth
		{
			get { return lineWidth; }
			set
			{
				lineWidth = value;
			}
		}
		public UIColor PenColor
		{
			get { return penColor; }
			set
			{
				penColor = value;
			}
		}

		public override void TouchesBegan(Foundation.NSSet touches, UIEvent evt)
		{
			this.OnTapped(new EventArgs());
			base.TouchesBegan(touches, evt);
			path = new UIBezierPath();
			UITouch touch = touches.AnyObject as UITouch;
			this.canTouchDraw = true;
			this.touchLocation = touch.LocationInView(this);
			this.prevTouchLocation = touch.PreviousLocationInView(this);
			this.SetNeedsDisplay();

		}

		public override void TouchesMoved(Foundation.NSSet touches, UIEvent evt)
		{
			base.TouchesMoved(touches, evt);

			UITouch touch = touches.AnyObject as UITouch;
			this.touchLocation = touch.LocationInView(this);
			this.prevTouchLocation = touch.PreviousLocationInView(this);
			this.SetNeedsDisplay();
		}

		public override void TouchesEnded(Foundation.NSSet touches, UIEvent evt)
		{
			base.TouchesEnded(touches, evt);
			linePathCollection.Add(new LinePath() { PenColor = penColor, Path = path, LineWidth = lineWidth });
			path.ClosePath();
		}
		public override void Draw(CGRect rect)
		{
			//base.Draw(rect);

			if (this.canTouchDraw)
			{
				for (int i = 0; i < linePathCollection.Count; i++)
				{
					LinePath lPath = linePathCollection[i];
					lPath.PenColor.SetStroke();
					lPath.Path.LineWidth = lPath.LineWidth;
					lPath.Path.LineJoinStyle = CGLineJoin.Round;
					lPath.Path.LineCapStyle = CGLineCap.Round;
					lPath.Path.Stroke();
				}

				penColor.SetStroke();
				path.LineWidth = lineWidth;
				path.LineJoinStyle = CGLineJoin.Round;
				path.LineCapStyle = CGLineCap.Round;
				path.MoveTo(this.prevTouchLocation);
				path.AddLineTo(this.touchLocation);
				path.Stroke();

			}
		}
	}
}

