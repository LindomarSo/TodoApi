using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands;

public class MarkTodoAsDoneCommand : Notifiable<Notification>, ICommand
{
    public MarkTodoAsDoneCommand() { }

    public MarkTodoAsDoneCommand(Guid id, string user)
    {
        Id = id;
        User = user;
    }

    public Guid Id { get; set; }
    public string User { get; set; } = string.Empty;

    public void Validate()
    {
        AddNotifications(
            new Contract<MarkTodoAsDoneCommand>()
                            .Requires()
                            .IsGreaterThan(User, 6, "User", "Usuário inválido")
            );
    }
}
