using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;

namespace rnApp.Droid
{
	[Activity(Label = "rnApp", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		//int count = 1;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			var  btnMap = FindViewById<Button>(Resource.Id.main_menuview_btnMap);
			btnMap.Click += (sender, e) =>
			{
				StartActivity(typeof(MapActivity));
			};

			//button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

			Button btnWeb = FindViewById<Button>(Resource.Id.main_menuview_btnWeb);
			btnWeb.Click += (sender, e) =>
			{
				//StartActivity(typeof(WebActivity));
				//使用另一種寫法
				Intent intent = new Intent(this, typeof(WebActivity));
				//帶參數
				//intent.PutExtra("url", "https://www.google.com.tw");

				StartActivity(intent);
			};

			var btnTable = FindViewById<Button>(Resource.Id.main_menuview_btntableview);
			btnTable.Click += (sender, e) =>
			{
				StartActivity(typeof(MyListViewActivity));
			};
		}
	}
}


