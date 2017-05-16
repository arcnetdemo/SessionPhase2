using Xamarin.Forms;
using System.Collections.ObjectModel;
using SQLite.Net;
using System.Collections.Generic;

namespace FormsApplication
{
	public partial class ListViewPage : ContentPage
	{
		readonly HogeMessageReoisitory _db = new HogeMessageReoisitory();
		private ObservableCollection<string> _items = new ObservableCollection<string>();

		public ListViewPage()
		{
        	InitializeComponent();
		}

		public ListViewPage(string value)
		{
            InitializeComponent();
			TableQuery<HogeMessage> tableItems = _db.GetItems(10);
			using(IEnumerator<HogeMessage> e = tableItems.GetEnumerator()){
				checked
				{
					while (e.MoveNext())
					{
						_items.Add(e.Current.Text);
					}
				}
			}
			listView.ItemsSource = _items;
		}
	}
}
