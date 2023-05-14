using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers;

public class TodoHandler : Notifiable<Notification>,
                           IHandler<CreateTodoCommand>,
                           IHandler<UpdateTodoCommand>,
                           IHandler<MarkTodoAsDoneCommand>,
                           IHandler<MarkTodoAsUnDoneCommand>
{
    private readonly ITodoRepository _todoRepository;

    public TodoHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public ICommandResult Handle(CreateTodoCommand command)
    {
        // Fail fast validation
        command.Validate();

        if (!command.IsValid)
            return new GenericCommandResult(false, "Opa, parece que a sua tarefa está errada!", command.Notifications);

        // Gera new TodoItem
        var todo = new TodoItem(command.Title, command.Date, command.User);

        // Salva no banco
        _todoRepository.Create(todo);

        return new GenericCommandResult(true, "Tarefa salva", todo);
    }

    public ICommandResult Handle(UpdateTodoCommand command)
    {
        // Fail Fast Validation
        command.Validate();

        if (!command.IsValid)
            return new GenericCommandResult(false, "Opa, parece que a sua tarefa está errada!", command.Notifications);

        // Recupera o TodoItem
        var todo = _todoRepository.GetById(command.Id, command.User);

        // Salva no banco 
        if (todo is not null)
            _todoRepository.Update(todo);

        // Retorna o resultado
        return new GenericCommandResult(true, "Tarefa atualizada", command);
    }

    public ICommandResult Handle(MarkTodoAsUnDoneCommand command)
    {
        // Fail Fast
        command.Validate();
        if (!command.IsValid)
            return new GenericCommandResult(false, "Opa, parece que a sua tarefa está errada!", command.Notifications);

        // Reidrata o TodoItem
        var todo = _todoRepository.GetById(command.Id, command.User);

        // Marca como não concluida
        todo?.MarkAsUnDone();

        // Salva 
        if (todo is not null)
            _todoRepository.Update(todo);

        // Retorna o resultado
        return todo is not null ? new GenericCommandResult(true, "Tarafa marcada como salva", todo) : new GenericCommandResult(false, "Todo não encontrado!", command.Notifications);
    }

    public ICommandResult Handle(MarkTodoAsDoneCommand command)
    {
        // Fail Fast
        command.Validate();
        if (!command.IsValid)
            return new GenericCommandResult(false, "Opa, parece que a sua tarefa está errada!", command.Notifications);

        // Reidrata o TodoItem
        var todo = _todoRepository.GetById(command.Id, command.User);

        // Marca a tarefa como concluida
        todo?.MarkAsDone();

        // Salva
        if (todo is not null)
            _todoRepository.Update(todo);

        // retorna o resultado
        return todo is not null ? new GenericCommandResult(true, "Tarafa marcada como salva", todo) : new GenericCommandResult(false, "Todo não encontrado!", command.Notifications);
    }
}
