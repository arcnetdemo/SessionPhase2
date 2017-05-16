using System;
using System.IO;
using FormsApplication.Droid;
using Xamarin.Forms;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;

[assembly: Dependency(typeof(SQLiteDroid))] // Xamarin.Forms プラットフォーム固有の処理であることの宣言
namespace FormsApplication.Droid
{
	public class SQLiteDroid : ISQLite
	{
		public SQLiteDroid()
		{
		}

		public SQLiteConnection GetConnection()
		{
			var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var path = Path.Combine(documentsPath, "hoge_sqllite.db3");
			return new SQLiteConnection(new SQLitePlatformAndroid(), path);
		}
	}
}
