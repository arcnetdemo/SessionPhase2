using System;
using System.Collections.Generic;
using Xamarin.Forms;
using SQLite.Net;

namespace FormsApplication
{
	public class HogeMessageReoisitory
	{
		static readonly object Locker = new object(); // スレッドセーフのためのロックオブジェジェクト
		readonly SQLiteConnection _db;

		public HogeMessageReoisitory()
		{
			_db = DependencyService.Get<ISQLite>().GetConnection();
			_db.CreateTable<HogeMessage>();
		}

		public TableQuery<HogeMessage> GetItems(int count)
		{
			lock(Locker)
			{
				return _db.Table<HogeMessage>().OrderByDescending(item => item.Id).Take(count);
			}
		}

		public int SaveItem(HogeMessage item)
		{
			lock(Locker)
			{
				if (item.Id != 0)
				{
					_db.Update(item);
					return item.Id;
				}
				return _db.Insert(item);
			}
		}

		public int GetCount()
		{
			return _db.Table<HogeMessage>().Count();
		}

		public int Truncate()
		{
			lock (Locker)
			{
				return _db.DeleteAll<HogeMessage>();
			}
		}
	}
}
