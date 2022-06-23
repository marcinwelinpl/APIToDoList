using APIToDoList.Entity;
using APIToDoList.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIToDoList.Controllers
{
	[Route("ToDoList")]
	public class ToDoListController : Controller
	{
		private readonly IToDoService _service;
		public ToDoListController(IToDoService toDoService)
		{
			_service = toDoService;
		}
		[HttpGet()]
		public ActionResult Index()
		{
			return Ok();
		}
		[HttpGet("{id}")]
		public ActionResult Details(int id)
		{
			return Ok(_service.GetUser(id));
		}

		[HttpPost]
		public ActionResult CreateUser([FromBody] User user)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			if(_service.CheckUserExist(user.Login))
			{
				return BadRequest("In database exist account in this login");
			}
			int id = _service.CreateUser(user);
			return Created($"/ToDoList/{id}", null);
		}
		[HttpPost("board")]
		public ActionResult CreateBoard([FromBody] Board board)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			int id = _service.CreateBoard(board.Name,board.Description,board.UserId);
			return Created($"/ToDoList/{id}", null);
		}
		[HttpPost("category")]
		public ActionResult CreateCategory([FromBody] Category category)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			_service.CreateCategory(category.Name, category.UserId);
			return Ok();
		}
		[HttpPost("task")]
		public ActionResult CreateTask([FromBody] Entity.Task task)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			_service.CreateTask(task.Name, task.Description, task.CategoryId ,task.BoardID);
			return Ok();
		}


		[HttpDelete]
		public ActionResult DeleteUser(int id)
		{
			bool response = _service.DeleteUser(id);
			if(!response)
			{
				return BadRequest("Item cant delete");
			}
			return Ok();
		}
		[HttpDelete("board")]
		public ActionResult DeleteBoard(int id)
		{
			bool response = _service.DeleteBoard(id);
			if (!response)
			{
				return BadRequest("Item cant delete");
			}
			return Ok();
		}
		[HttpDelete("category")]
		public ActionResult DeleteCategory(int id)
		{
			bool response = _service.DeleteCategory(id);
			if (!response)
			{
				return BadRequest("Item cant delete");
			}
			return Ok();
		}
		[HttpDelete("task")]
		public ActionResult DeleteTask(int id)
		{
			bool response = _service.DeleteTask(id);
			if (!response)
			{
				return BadRequest("Item cant delete");
			}
			return Ok();
		}
	}
}
