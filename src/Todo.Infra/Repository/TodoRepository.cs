using Microsoft.EntityFrameworkCore;
using Todo.Domain.Entities;
using Todo.Domain.Queries;
using Todo.Domain.Repositories;
using Todo.Infra.Context;

namespace Todo.Infra.Repository;

public class TodoRepository : ITodoRepository
{
    private readonly TodoContext _todoContext;

    public TodoRepository(TodoContext todoContext)
    {
        _todoContext = todoContext;
    }

    public void Create(TodoItem todo)
    {
        _todoContext.Add(todo); 
        _todoContext.SaveChanges();
    }

    public IEnumerable<TodoItem> GetAll(string user)
    {
        return _todoContext.Todos.AsNoTracking()
                                 .Where(TodoQueries.GetAll(user))
                                 .OrderBy(x => x.Date)
                                 .ToList();
    }

    public IEnumerable<TodoItem> GetAllDone(string user)
    {
        return _todoContext.Todos.AsNoTracking()
                                 .Where(TodoQueries.GetAllDone(user))
                                 .OrderBy(x => x.Date); 
    }

    public IEnumerable<TodoItem> GetAllUnDone(string user)
    {
        return _todoContext.Todos.AsNoTracking()
                                 .Where(TodoQueries.GetAllUnDone(user))
                                 .OrderBy(x => x.Date);
    }

    public TodoItem? GetById(Guid id, string user)
    {
        return _todoContext.Todos.AsNoTracking()
                                 .FirstOrDefault(x => x.Id == id && x.User == user);    
    }

    public IEnumerable<TodoItem> GetByPeriod(string user, DateTime data, bool done)
    {
        return _todoContext.Todos.AsNoTracking()
                                 .Where(TodoQueries.GetByPeriod(user, data, done))
                                 .OrderBy(x => x.Date);
    }

    public void Update(TodoItem todo)
    {
        // Estou falando para o EntityFramework que o todo passado como argumento foi alterado, nesse sentido ele vai olhar campo 
        // e gerar uma query apenas do campo que foi alterado 
        _todoContext.Entry(todo).State = EntityState.Modified;
        _todoContext.SaveChanges();
    }
}
