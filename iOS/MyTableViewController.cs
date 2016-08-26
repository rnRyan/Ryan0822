using System;
using System.Collections.Generic;
using System.Diagnostics;
using Foundation;
using UIKit;

using Debug = System.Diagnostics.Debug;

namespace rnApp.iOS
{
	public partial class MyTableViewController : UIViewController
	{
		//建立一個 viewController 需要把原建構子 () : base("MyTableViewController", null) 
		//換成 (IntPtr handle) : base(handle)
		public MyTableViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			ShowTable();
		}

		public void ShowTable()
		{
			var list = new List<Todo>();

			list.Add(new Todo { Name = "瞭解IOC", Description = "控制反轉" });
			list.Add(new Todo { Name = "瞭解DI", Description = "依賴注入" });
			list.Add(new Todo { Name = "瞭解 UI TEST", Description = "準備" });
			list.Add(new Todo { Name = "瞭解 Unit TEST", Description = "準備" });

			var todoSource = new TodoSource(list);
			//將資料指派給tableView
			myTableView.Source = todoSource;

			todoSource.TodoSelected += (object sender, TodoSelectedEventArgs e) =>
			{
				Debug.WriteLine($"TodoSelected Name:{ e.SelectedTodo.Name } Description:{ e.SelectedTodo.Description }");
			};
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}

		class TodoSource : UITableViewSource
		{
			private List<Todo> TodoesList { get; set; }

			public event EventHandler<TodoSelectedEventArgs> TodoSelected;

			const string MyTableViewCellIdentifier = "MyTableViewCell";

			public TodoSource(IEnumerable<Todo> source)
			{
				TodoesList = new List<Todo>();
				TodoesList.AddRange(source);
			}

			public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
			{
				MyTableViewCell cell = tableView.DequeueReusableCell( MyTableViewCellIdentifier, indexPath ) as MyTableViewCell;

				var todo = TodoesList[indexPath.Row];
				cell.UpdateUI(todo);

				return cell;
			}

			public override nint RowsInSection(UITableView tableview, nint section)
			{
				//應該顯示的筆數
				return TodoesList.Count;
			}

			public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
			{
				//
				//base.RowSelected(tableView, indexPath);
				//加上動畫
				tableView.DeselectRow(indexPath, true);

				var todo = TodoesList[indexPath.Row];

				EventHandler<TodoSelectedEventArgs> handle = TodoSelected;

				if ( null != handle ){
					handle(this, new TodoSelectedEventArgs { SelectedTodo = todo });
				}
			}
		}

		public class TodoSelectedEventArgs : EventArgs
		{
			public Todo SelectedTodo { get; set; }
		}

	}
}


