using Flunt.Notifications;
using Flunt.Validations;
using Todo.Domain.Commands.Contracts;

namespace Todo.Domain.Commands;

// Os commands funcionam como DTOs ou ViewModels
public class CreateTodoCommand : Notifiable<Notification>, ICommand
{
    private CreateTodoCommand() { }

    public CreateTodoCommand(string title, DateTime date, string user)
    {
        Title = title;
        Date = date;
        User = user;
    }

    public string Title { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string User { get; set; } = string.Empty;

    public void Validate()
    {
        AddNotifications(
            new Contract<CreateTodoCommand>()
              .Requires()
              .IsGreaterThan(Title, 4, "Title", "Por favor descreva melhor a sua tarefa")
              .IsGreaterThan(User, 6, "User", "Usuário inválido"));
    }
}
