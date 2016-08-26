
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

using Debug = System.Diagnostics.Debug;

namespace rnApp.Droid
{
	[Activity(Label = "MyListViewActivity")]
	public class MyListViewActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.table_myListView);
			// Create your application here

			ShowTable();
		}


		public void ShowTable()
		{
			var list = new List<Todo>();

			list.Add(new Todo { Name = "瞭解IOC", Description = "控制反轉" });
			list.Add(new Todo { Name = "瞭解DI", Description = "依賴注入" });
			list.Add(new Todo { Name = "瞭解 UI TEST", Description = "準備" });
			list.Add(new Todo { Name = "瞭解 Unit TEST", Description = "準備" });

			var listview = FindViewById<ListView>(Resource.Id.table_listview);

			listview.Adapter = new TodoAdapter(this, list);

			listview.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => {

				Debug.WriteLine($"TodoSelected Name:{ list[e.Position].Name }, Description:{ list[e.Position].Description }");
			};

			//var todoSource = new TodoSource(list);
			////將資料指派給tableView
			//myTableView.Source = todoSource;

			//todoSource.TodoSelected += (object sender, TodoSelectedEventArgs e) =>
			//{
			//	Debug.WriteLine($"TodoSelected Name:{ e.SelectedTodo.Name } Description:{ e.SelectedTodo.Description }");
			//};
		}

		class TodoAdapter : BaseAdapter<Todo>
		{
			private List<Todo> Todoes { get; set; }

			private Activity context = null;

			public TodoAdapter( Activity context, IEnumerable<Todo> source)
			{
				Todoes = new List<Todo> ();
				Todoes.AddRange(source);

				this.context = context;
			}

			public override Todo this[int position] => Todoes[position];

			public override int Count => Todoes.Count;

			public override long GetItemId(int position)
			{
				return position;
			}

			public override View GetView(int position, View convertView, ViewGroup parent)
			{
				var view = convertView;
				if ( null == view ) {

					view = this.context.LayoutInflater.Inflate(Resource.Layout.table_view_cell, parent, false);
				}
				var todo = Todoes[position];

				view.FindViewById<TextView>(Resource.Id.table_mylistview_cell_name).Text = todo.Name;
				view.FindViewById<TextView>(Resource.Id.table_mylistview_cell_description).Text = todo.Description;

				return view;
			}
		}
	}
}

