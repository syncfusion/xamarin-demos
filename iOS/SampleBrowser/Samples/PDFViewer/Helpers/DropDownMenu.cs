#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using UIKit;
using CoreGraphics;
using System;
using System.Threading.Tasks;

namespace SampleBrowser
{
	/// <summary>
	/// Drop down list changed handler.
	/// </summary>
	public delegate void DropDownMenuItemChangedHandler(int itemIndex, DropDownMenuItem listItem);
	/// <summary>
	/// Drop down list.
	/// </summary>
	public class DropDownMenu: UIView
	{
		/// <summary>
		/// Occurs when drop down list changed.
		/// </summary>
		public event DropDownMenuItemChangedHandler DropDownMenuItemChanged;
		private UIView container;
		private UITableView table;
		private DropDownMenuItem[] m_ListItems;
		private DropDownDataSource m_Source;
		private bool m_isOpened;
		private UIColor m_TextColor;		

		/// <summary>
		/// Gets or sets the opacity.
		/// </summary>
		/// <value>The opacity.</value>
		public float Opacity
        {
            get
            {
                return this.Layer.Opacity;
            }
            set
            {
                this.Layer.Opacity = value;
            }
        }
        public bool IsOpened
        {
            get
            {
                return m_isOpened;
            }
            set
            {
                m_isOpened = value;
            }

        }
        public override CGRect Frame
        {
            get
            {
                return base.Frame;
            }

            set
            {
                base.Frame = value;
            }
        }

        /// <summary>
        /// Gets or sets the width of the border.
        /// </summary>
        /// <value>The width of the border.</value>
        public nfloat BorderWidth
        {
            get
            {
                return this.Layer.BorderWidth;
            }
            set
            {
                this.Layer.BorderWidth = value;
            }
        }

		/// <summary>
		/// Gets or sets the color of the border.
		/// </summary>
		/// <value>The color of the border.</value>
		public CGColor BorderColor
        {
            get
            {
                return this.Layer.BorderColor;
            }
            set
            {
                this.Layer.BorderColor = value;
            }
        }

		/// <summary>
		/// Gets or sets the color of the text.
		/// </summary>
		/// <value>The color of the text.</value>
		public UIColor TextColor
        {
            get
            {
                return m_TextColor != null ? m_TextColor : UIColor.Black;
            }
            set
            {
                if (value != null)
                {
                    m_TextColor = value;
                    if (m_Source == null)
                    {
                        InitTableAndSource();
                    }
                    m_Source.TextColor = value;
                }
            }
        }

		/// <summary>
		/// Gets or sets the drop down top inset.  Default is 60
		/// </summary>
		/// <value>The drop down top inset.</value>
		public nfloat DropDownTopInset{ get; set; }

        /// <summary>
        /// Brings the DropDownMenu to view.
        /// </summary>
        public void Open()
        {
            table.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);            
            this.container.Add(this);
            m_isOpened = true;
        }

        /// <summary>
        /// Removes the DropDownMenu from view.
        /// </summary>
        public void Close()
        {
            table.Frame = new CGRect(0, 0, this.Frame.Width, this.Frame.Height);
            this.RemoveFromSuperview();
            m_isOpened = false;
        }

		/// <summary>
		/// Initializes a new instance of the <see cref="DropDownList"/> class.
		/// </summary>
		/// <param name="listItems">List items.</param>
		public DropDownMenu (UIView view, DropDownMenuItem[] listItems)
		{
			this.container = view;
			this.m_ListItems = listItems;
			InitializeEffects ();
		}
		private void InitializeEffects(){
			Layer.Frame = this.Frame;					
			Layer.Opacity = 1;
            Layer.CornerRadius = 10;
            ClipsToBounds = true;
		}
		private void InitTableAndSource ()
		{
            if (m_Source == null)
            {
                m_Source = new DropDownDataSource(m_ListItems, this.m_TextColor);
                m_Source.DropDownMenuItemChanged += DropDownMenuItemChangedMethod;
                table = new UITableView(new CGRect(0, 0, this.Frame.Width, this.Frame.Height));
                if (DropDownTopInset == 0)
                    DropDownTopInset = 60;
                table.ContentInset = new UIEdgeInsets(0, 0, 0, 0);
                table.Source = m_Source;
                this.Add(table);
            }
		}
		private void DropDownMenuItemChangedMethod(int index, DropDownMenuItem item)
		{
			if (DropDownMenuItemChanged != null) {
                DropDownMenuItemChanged(index, item);
			}
		}
	}
}
