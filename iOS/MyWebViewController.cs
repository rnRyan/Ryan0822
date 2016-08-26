using System;

using Foundation;
using UIKit;

using Debug = System.Diagnostics.Debug;

namespace rnApp.iOS
{
	public partial class MyWebViewController : UIViewController
	{
		public MyWebViewController(IntPtr handle) : base(handle)
		{
		}

		//like Android onCreate
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
			Title = "Web";

			btnGo.TouchUpInside += (sender, e) =>
			{
				if (txtURL.IsFirstResponder)
				{
					txtURL.ResignFirstResponder();
				}

				btnGoButtonConstraint.Constant = 10;

				webview.LoadRequest(new NSUrlRequest(new NSUrl(txtURL.Text))); ;
			};

			//監控鍵盤的高度變化
			//UIKeyboard.Notifications.ObserveWillChangeFrame((sender, e) =>
			//{
			//	var beginRect = e.FrameBegin;
			//	var endRect = e.FrameEnd;

			//	Debug.WriteLine($"ObserveWillChangeFrame endRect:{endRect.Height}");

			//	//btnGoButtonConstraint->按鈕與superlayout 的間距, 當鍵盤發生變化, 讓間距跟著移動,使得上方的元件跟著移動
			//	btnGoButtonConstraint.Constant = endRect.Height + 5;

			//});

			//UIKeyboard.Notifications.ObserveDidHide((sender, e) =>
			//{
			//	btnGoButtonConstraint.Constant = 10;
			//});

			UIKeyboard.Notifications.ObserveWillShow((sender, e) => 
			{
				var beginRect = e.FrameBegin;
				var endRect = e.FrameEnd;

				Debug.WriteLine($"ObserveWillChangeFrame endRect:{endRect.Height}");

				//btnGoButtonConstraint->按鈕與superlayout 的間距, 當鍵盤發生變化, 讓間距跟著移動,使得上方的元件跟著移動
				btnGoButtonConstraint.Constant = endRect.Height + 5;
			});

			UIKeyboard.Notifications.ObserveWillHide((sender, e) => 
			{ 
				btnGoButtonConstraint.Constant = 10;
			});
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}


