using System;

using Foundation;
using UIKit;

namespace rnApp.iOS
{
	public partial class MyTableViewCell : UITableViewCell
	{
		protected MyTableViewCell(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}

		public void UpdateUI( Todo todo ){

			lbName.Text 		= todo.Name;
			lbDescroption.Text 	= todo.Description;
		}
	}
}
