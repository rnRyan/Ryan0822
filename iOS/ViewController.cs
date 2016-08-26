using System;

using UIKit;

namespace rnApp.iOS
{
	public partial class ViewController : UIViewController
	{
		
		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();


			btnConfirm.TouchUpInside += (sender, e) =>
			{
				PerformSegue("MoveToMap", this);
			};

			Button.TouchUpInside += (sender, e) =>
			{
				PerformSegue("MoveToWeb", this);
			};

			_btnGoTableView.TouchUpInside += (sender, e) =>
			{
				PerformSegue("MoveToTableView", this);
			};
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}

		public override void PrepareForSegue(UIStoryboardSegue segue, Foundation.NSObject sender)
		{
			base.PrepareForSegue(segue, sender);
		}
	}
}
