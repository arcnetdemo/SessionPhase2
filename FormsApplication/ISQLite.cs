using System;
using SQLite.Net;

namespace FormsApplication
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}
