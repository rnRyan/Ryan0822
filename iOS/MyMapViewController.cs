﻿using System;

using UIKit;

namespace rnApp.iOS
{
	public partial class MyMapViewController : UIViewController
	{
		public MyMapViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			Title = "Map";
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


