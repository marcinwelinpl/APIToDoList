using APIToDoList.Entity;

namespace APIToDoList.Services
{
	public interface IToDoService
	{
		User GetUser(int id);
		bool CheckUserExist(string login);
		int CreateUser(User user);
		int CreateBoard(string name, string descriptino, int UserId);
		void CreateCategory(string name, int UserId);
		void CreateTask(string name, string descritpion, int? CategoryId, int BoardId);
		bool DeleteUser(int id);
		bool DeleteBoard(int id);
		bool DeleteCategory(int id);
		bool DeleteTask(int id);
	}
}