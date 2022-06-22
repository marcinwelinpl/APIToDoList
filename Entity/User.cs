using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIToDoList.Entity
{
	public class User
	{
		public int Id { get; set; }
		public string Login { get; set; }
		public string Passoword { get; set; }
		public int BoardId { get; set; }
		virtual public Board Board { get; set; }
	}
}
