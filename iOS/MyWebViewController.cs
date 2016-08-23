using System;

using Foundation;
using UIKit;

namespace rnApp.iOS
{
	public partial class MyWebViewController : UIViewController
	{
		public MyWebViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			Title = "Web";

			btnGo.TouchUpInside += (sender, e) =>
			{
				webview.LoadRequest(new NSUrlRequest(new NSUrl(@"https://www.google.com.tw"))); ;
			};
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


