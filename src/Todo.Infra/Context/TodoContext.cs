using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;

namespace Todo.Infra.Context;

public class TodoContext : DbContext
{
	public TodoContext(DbContextOptions<TodoContext> context) : base(context) { }

	public DbSet<TodoItem> Todos { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.Entity<TodoItem>(todo =>
		{
			todo.ToTable("Todo", "dbo");
			todo.Property(x => x.Id);
			todo.Property(x => x.User).HasMaxLength(100).HasColumnType("Varchar(100)");
			todo.Property(x => x.Title).HasMaxLength(100).HasColumnType("Varchar(100)");
			todo.Property(x => x.Done).HasColumnType("bit");
			todo.Property(x => x.Date).HasMaxLength(100);
			todo.HasIndex(x => x.User);
        });
	}
}
