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
		public void CreateCategory(string name, int UserId)
		{
			Category category = new Category()
			{
				Name = name,
				UserId = UserId
			};
			_dbContext.Category.Add(category);
			_dbContext.SaveChanges();
		}
		public void CreateTask(string name,string descritpion , int? CategoryId, int BoardId)
		{
			Entity.Task task = new Entity.Task()
			{
				Name = name,
				Description = descritpion,
				CategoryId = CategoryId,
				BoardID= BoardId
			};
			_dbContext.Task.Add(task);
			_dbContext.SaveChanges();
		}
		public bool DeleteUser(int id)
		{
			User user = _dbContext.User.FirstOrDefault(x => x.Id == id);
			if(user ==null)
			{
				return false;
			}
			_dbContext.User.Remove(user);
			_dbContext.SaveChanges();
			return true;
		}
		public bool DeleteBoard(int id)
		{
			Board board  = _dbContext.Boards.FirstOrDefault(x => x.Id == id);
			if (board == null)
			{
				return false;
			}
			_dbContext.Boards.Remove(board);
			_dbContext.SaveChanges();
			return true;
		}
		public bool DeleteCategory(int id)
		{
			Category category= _dbContext.Category.FirstOrDefault(x => x.Id == id);
			if (category == null)
			{
				return false;
			}
			_dbContext.Category.Remove(category);
			_dbContext.SaveChanges();
			return true;
		}
		public bool DeleteTask(int id)
		{
			Entity.Task task = _dbContext.Task.FirstOrDefault(x => x.Id == id);
			if (task == null)
			{
				return false;
			}
			_dbContext.Task.Remove(task);
			_dbContext.SaveChanges();
			return true;
		}
	}
}
