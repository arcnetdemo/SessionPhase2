using Xamarin.Forms;
using System;

namespace FormsApplication
{
	public partial class FormsApplicationPage : ContentPage
	{
		private HogeMessageReoisitory _db;

		public FormsApplicationPage()
		{
			InitializeComponent();
			_db = new HogeMessageReoisitory();
			deleteLabel.Text = "全" + _db.GetCount() + "件";
		}

		void OnDeleteButtonClicked(object sender, EventArgs args)
		{
			_db.Truncate();
			deleteLabel.Text = "初期化しました";
		}

		void OnSendButtonClicked(object sender, EventArgs args)
		{
			if (!String.IsNullOrEmpty(inputText.Text))
			{
				// 文字列の入力がある場合、DBに登録する
				HogeMessage item = new HogeMessage();
				item.Text = inputText.Text;
				item.InsertTm = DateTime.Now;
				_db.SaveItem(item);
				deleteLabel.Text = "全" + _db.GetCount() + "件";
			}
			Navigation.PushAsync(new ListViewPage(inputText.Text));
		}
	}
}
