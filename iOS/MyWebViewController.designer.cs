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
	[Register ("MyWebViewController")]
	partial class MyWebViewController
	{
		[Outlet]
		UIKit.UIButton btnGo { get; set; }

		[Outlet]
		UIKit.UITextField txtURL { get; set; }

		[Outlet]
		UIKit.UIWebView webview { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnGo != null) {
				btnGo.Dispose ();
				btnGo = null;
			}

			if (txtURL != null) {
				txtURL.Dispose ();
				txtURL = null;
			}

			if (webview != null) {
				webview.Dispose ();
				webview = null;
			}
		}
	}
}
