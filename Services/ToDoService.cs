using APIToDoList.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIToDoList.Services
{
	public class ToDoService : IToDoService
	{
		private readonly ToDoListDbContext _dbContext;
		public ToDoService(ToDoListDbContext context)
		{
			_dbContext = context;
		}
		public User GetUser(int id)
		{
			return _dbContext.User.FirstOrDefault(x => x.Id == id);
		}
		public bool CheckUserExist(string login)
		{
			var user = _dbContext.User.FirstOrDefault(x => x.Login == login);
			if (user==null)
			{
				return false;
			}
			return true;
		}
		public int CreateUser(User user)
		{
			User User = user;
			_dbContext.User.Add(User);
			_dbContext.SaveChanges();
			CreateBoard("Main", "Default Board", user.Id);
			return User.Id;
		}
		public int CreateBoard(string name, string descriptino, int UserId)
		{
			Board board = new Board()
			{
				Name = name,
				Description = descriptino,
				UserId = UserId
			};
			_dbContext.Boards.Add(board);
			_dbContext.SaveChanges();
			return board.Id;
		}
	}
}
