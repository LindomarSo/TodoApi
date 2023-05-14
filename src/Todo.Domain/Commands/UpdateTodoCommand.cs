using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands;

public class UpdateTodoCommand : Notifiable<Notification>, ICommand
{
    private UpdateTodoCommand() { }

    public UpdateTodoCommand(Guid id, string title, DateTime date, string user)
    {
        Id = id;
        Title = title;
        Date = date;
        User = user;
    }

    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string User { get; set; } = string.Empty;

    public void Validate()
    {
        AddNotifications(
            new Contract<UpdateTodoCommand>()
              .Requires()
              .IsLowerThan(Title, 4, "Title", "Por favor descreva melhor a sua tarefa")
              .IsGreaterThan(User, 6, "User", "Usuário inválido"));
    }
}
