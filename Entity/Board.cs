using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIToDoList.Entity
{
	public class Board
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int UserId { get; set; }
		public virtual User User {get;set;}
	}
}
