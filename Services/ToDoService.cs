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
		public int CreateUser(User user)
		{
			User User = user;
			User.BoardId = CreateBoard("Main", "Defoult Board");
			_dbContext.User.Add(User);
			_dbContext.SaveChanges();
			return User.Id;
		}
		public int CreateBoard(string name, string descriptino)
		{
			Board board = new Board()
			{
				Name = name,
				Description = descriptino
			};
			_dbContext.Boards.Add(board);
			_dbContext.SaveChanges();
			return board.Id;
		}
	}
}
