
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Webkit;
using Android.Views.InputMethods;
using Debug = System.Diagnostics.Debug;
using AndroidHUD;

namespace rnApp.Droid
{
	[Activity(Label = "WebActivity")]
	public class WebActivity : Activity
	{
		private WebView 	myWebView { get; set; }
		private Button		btnGo { get; set; }
		private EditText	edTextUrl { get; set; }

		private InputMethodManager _InputMethodManager;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here
			//var url = Intent.GetStringExtra("url");

			_InputMethodManager = (InputMethodManager)GetSystemService(Context.InputMethodService);

			SetContentView(Resource.Layout.web_mywebview);

			myWebView = FindViewById<WebView>(Resource.Id.mywebview);
			btnGo = FindViewById<Button>(Resource.Id.btn_Go);
			edTextUrl = FindViewById<EditText>(Resource.Id.edit_webURL);

			var client = new ContentWebViewClient();

			client.WebViewLocaitonChanged += (object sender, ContentWebViewClient.WebViewLocaitonChangedEventArgs e) =>
			{

				Debug.WriteLine(e.CommandString);

			};

			client.WebViewLoadCompleted += (object sender, ContentWebViewClient.WebViewLoadCompletedEventArgs e) =>
			{

				RunOnUiThread(() =>
				{

					AndHUD.Shared.Dismiss(this);

				});

			};


			//myWebView.LoadUrl(url);
			//避免手機使用其他Load url
			myWebView.SetWebViewClient( client );
			myWebView.RequestFocus();


			btnGo.Click += (object sender, EventArgs e) =>
			{
				//RunOnUiThread(() =>
				//{
				//	myWebView.EvaluateJavascript(@"msg();", callResult);
				//});

				//EditText 輸入的資料
				var url = edTextUrl.Text.Trim() ;
				AlertDialog.Builder alert = new AlertDialog.Builder (this);
				alert.SetTitle (url);
				alert.SetNegativeButton( "取消", (senderAlert, args) =>{
				});
				alert.SetPositiveButton( "確認", (senderAlert, args) =>{
					RunOnUiThread(
						()=>{
							AndHUD.Shared.Show(this, "Status Message", -1, MaskType.Clear);
						}
					);
					myWebView.LoadUrl (url);
				});
				RunOnUiThread (() => {
					alert.Show();
				} );
				// 
				_InputMethodManager.HideSoftInputFromWindow( 
					edTextUrl.WindowToken, 
					HideSoftInputFlags.None );
			};
		}

		public class ContentWebViewClient : WebViewClient
		{

			public event EventHandler<WebViewLocaitonChangedEventArgs> WebViewLocaitonChanged;

			public event EventHandler<WebViewLoadCompletedEventArgs> WebViewLoadCompleted;

			public override bool ShouldOverrideUrlLoading(WebView view, string url)
			{
				EventHandler<WebViewLocaitonChangedEventArgs> handler =
					WebViewLocaitonChanged;

				if (null != handler)
				{
					handler(this,
						new WebViewLocaitonChangedEventArgs
						{
							CommandString = url
						});
				}

				return base.ShouldOverrideUrlLoading(view, url);

			}


			public override void OnPageFinished(WebView view, string url)
			{
				base.OnPageFinished(view, url);

				EventHandler<WebViewLoadCompletedEventArgs> handler =
					WebViewLoadCompleted;

				if (null != handler)
				{
					handler(this,
						new WebViewLoadCompletedEventArgs());
				}
			}

			public class WebViewLocaitonChangedEventArgs : EventArgs
			{

				public string CommandString { get; set; }
			}

			public class WebViewLoadCompletedEventArgs : EventArgs
			{

			}
		}
	}
}

