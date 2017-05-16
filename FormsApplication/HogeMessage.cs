using System;
using SQLite.Net.Attributes;
namespace FormsApplication
{
	public class HogeMessage
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }
		public string Text { get; set; }
		public DateTime InsertTm { get; set; }
	}
}
