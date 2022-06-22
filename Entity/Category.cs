using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIToDoList.Entity
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int  BoardID { get; set; }
		virtual public Board Board { get; set; }
	}
}
