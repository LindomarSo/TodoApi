using System.Linq.Expressions;
using Todo.Domain.Entities;

namespace Todo.Domain.Queries;

public static class TodoQueries
{
    public static Expression<Func<TodoItem, bool>> GetAll(string user) => todo => todo.User == user;

    public static Expression<Func<TodoItem, bool>> GetAllDone(string user) => todo => todo.User == user && todo.Done;

    public static Expression<Func<TodoItem, bool>> GetAllUnDone(string user) => todo => todo.User == user && !todo.Done;

    public static Expression<Func<TodoItem, bool>> GetByPeriod(string user, DateTime data, bool done) 
        => todo => todo.User == user && todo.Done == done && todo.Date.Date == data.Date;
}
