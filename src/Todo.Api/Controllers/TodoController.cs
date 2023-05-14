using Microsoft.AspNetCore.Mvc;
using Todo.Domain.Commands;
using Todo.Domain.Entities;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;

namespace Todo.Api.Controllers;

[Route("api/v1/todos")]
[ApiController]
public class TodoController : ControllerBase
{
    // Chama o repositório quando é leitura e os handlers quando é escrita
    [HttpGet]
    public IEnumerable<TodoItem> GetAll([FromServices] ITodoRepository repository)
    {
        return repository.GetAll("Lindomar Dias");
    }

    [HttpGet("done")]
    public IEnumerable<TodoItem> GetAllDone([FromServices] ITodoRepository repository)
    {
        return repository.GetAllDone("Lindomar Dias");
    }

    [HttpGet("undone")]
    public IEnumerable<TodoItem> GetAllUnDone([FromServices] ITodoRepository repository)
    {
        return repository.GetAllUnDone("Lindomar Dias");
    }

    [HttpGet("done/today")]
    public IEnumerable<TodoItem> GetDoneToday([FromServices] ITodoRepository repository)
    {
        return repository.GetByPeriod("Lindomar Dias", DateTime.Now.Date, true);
    }

    [HttpGet("undone/today")]
    public IEnumerable<TodoItem> GetUnDoneToday([FromServices] ITodoRepository repository)
    {
        return repository.GetByPeriod("Lindomar Dias", DateTime.Now.Date, false);
    }

    [HttpGet("done/tomorrow")]
    public IEnumerable<TodoItem> GetDoneTomorrow([FromServices] ITodoRepository repository)
    {
        return repository.GetByPeriod("Lindomar Dias", DateTime.Now.Date.AddDays(1), true);
    }

    [HttpGet("undone/tomorrow")]
    public IEnumerable<TodoItem> GetUnDoneTomorrow([FromServices] ITodoRepository repository)
    {
        return repository.GetByPeriod("Lindomar Dias", DateTime.Now.Date.AddDays(1), false);
    }

    [HttpPost]
    public GenericCommandResult Post([FromBody] CreateTodoCommand command, [FromServices] TodoHandler todoHandler)
    {
        command.User = "Lindomar Dias";

        return (GenericCommandResult)todoHandler.Handle(command);
    }

    [HttpPut()]
    public GenericCommandResult Put([FromBody] UpdateTodoCommand command, [FromServices] TodoHandler handler)
    {
        command.User = "Lindomar Dias";

        return (GenericCommandResult)handler.Handle(command);
    }

    [HttpPut("mark-as-done")]
    public GenericCommandResult MarkAsDone([FromBody] MarkTodoAsDoneCommand command, [FromServices] TodoHandler handler)
    {
        return (GenericCommandResult)handler.Handle(command);
    }

    [HttpPut("mark-as-undone")]
    public GenericCommandResult MarkAsUnDone([FromBody] MarkTodoAsUnDoneCommand command, [FromServices] TodoHandler handler)
    {
        return (GenericCommandResult)handler.Handle(command);
    }
}
