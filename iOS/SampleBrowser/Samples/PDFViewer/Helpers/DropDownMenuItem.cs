using System;

namespace SampleBrowser
{
	/// <summary>
	/// Drop down list item.
	/// </summary>
	public class DropDownMenuItem{
		
		/// <summary>
		/// Gets or sets the display text.
		/// </summary>
		/// <value>The display text.</value>
		public string DisplayText
        {
            get;
            set;
        }
		
        /// <summary>
        /// Gets or sets the item.
        /// </summary>
		public bool IsSelected
        {
            get;
            set;
        }
	}
	
}
