using System;
using System.IO;

using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;
using Xamarin.Forms;
using FormsApplication.iOS;

[assembly: Dependency(typeof(SQLiteIOS))] // Xamarin.Forms プラットフォーム固有の処理であることの宣言
namespace FormsApplication.iOS
{
	public class SQLiteIOS : ISQLite
	{
		public SQLiteIOS()
		{
		}

		public SQLiteConnection GetConnection()
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var libraryPath = Path.Combine(documentsPath, "..", "Library");
			var path = Path.Combine(libraryPath, "hoge_sqllite.db3");
			return new SQLiteConnection(new SQLitePlatformIOS(), path);
		}
	}
}
