// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace rnApp.iOS
{
	[Register ("MyTableViewController")]
	partial class MyTableViewController
	{
		[Outlet]
		UIKit.UITableView myTableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (myTableView != null) {
				myTableView.Dispose ();
				myTableView = null;
			}
		}
	}
}
