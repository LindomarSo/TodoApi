using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands;

public class MarkTodoAsUnDoneCommand : Notifiable<Notification>, ICommand
{
    public MarkTodoAsUnDoneCommand() { }

    public MarkTodoAsUnDoneCommand(Guid id, string user)
    {
        Id = id;
        User = user;
    }

    public Guid Id { get; set; }
    public string User { get; set; } = string.Empty;

    public void Validate()
    {
        AddNotifications(
            new Contract<MarkTodoAsUnDoneCommand>()
                            .Requires()
                            .IsGreaterThan(User, 6, "User", "Usuário inválido")
            );
    }
}
