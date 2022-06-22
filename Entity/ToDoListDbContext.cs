using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIToDoList.Entity
{
	public class ToDoListDbContext  :DbContext
	{
		private string _connectionString = "Server=(localdb)\\MSSQLLocalDB; Database=ToDoListDB;Integrated Security=true";
		public DbSet<Board> Boards { get; set; }
		public DbSet<Category> Category { get; set; }
		public DbSet<Task> Task { get; set; }
		public DbSet<User> User { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Board>()
				.Property(e => e.Name)
				.IsRequired();
			modelBuilder.Entity<Category>()
				.Property(e => e.Name)
				.IsRequired();
			modelBuilder.Entity<Task>()
				.Property(e => e.Name)
				.IsRequired();
			modelBuilder.Entity<User>()
				.Property(e => e.Login)
				.IsRequired();
			modelBuilder.Entity<User>()
				.Property(e => e.Passoword)
				.IsRequired();

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(_connectionString);
		}
	}
}
