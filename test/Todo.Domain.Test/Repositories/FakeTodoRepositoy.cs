using Todo.Domain.Entities;
using Todo.Domain.Repositories;

namespace Todo.Domain.Test.Repositories;

internal class FakeTodoRepositoy : ITodoRepository
{
    public void Create(TodoItem todo)
    {
    }

    public IEnumerable<TodoItem> GetAll(string user)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TodoItem> GetAllDone(string user)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TodoItem> GetAllUnDone(string user)
    {
        throw new NotImplementedException();
    }

    public TodoItem GetById(Guid id, string user)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TodoItem> GetByPeriod(string user, DateTime data, bool done)
    {
        throw new NotImplementedException();
    }

    public void Update(TodoItem todo)
    {
    }
}
