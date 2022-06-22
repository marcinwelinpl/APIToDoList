using APIToDoList.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIToDoList.Entity
{
	public class ToDoSeeder
	{
		private readonly ToDoListDbContext _dbContext;
		private readonly IToDoService _service;
		public ToDoSeeder(ToDoListDbContext dBContext, IToDoService service )
		{
			_dbContext = dBContext;
			_service = service;
		}
		public void Seed()
		{
			if (_dbContext.Database.CanConnect())
			{
				if (!_dbContext.User.Any())
				{
					_service.CreateUser(new User() { Login = "Admin", Passoword = "1234" });
				}
			}
		}
	}
}
