using APIToDoList.Entity;

namespace APIToDoList.Services
{
	public interface IToDoService
	{
		int CreateBoard(string name, string descriptino, int UserId);
		int CreateUser(User user);
		User GetUser(int id);
		bool CheckUserExist(string login);
	}
}