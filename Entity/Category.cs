﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIToDoList.Entity
{
	public class Category
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int UserId { get; set; }
		public virtual User User { get; set; }
	}
}
