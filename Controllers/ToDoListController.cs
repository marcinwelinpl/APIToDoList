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
			int id = _service.CreateUser(user);
			return Created($"/ToDoList/{id}", null);
		}
	}
}
