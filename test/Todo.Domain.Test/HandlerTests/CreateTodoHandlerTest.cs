using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Test.Repositories;

namespace Todo.Domain.Test.HandlerTests;

[TestClass]
public class CreateTodoHandlerTest
{
    private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Teste de criação", DateTime.Now, "Usuário de Test");
    private readonly CreateTodoCommand _inValidCommand = new CreateTodoCommand("", DateTime.Now, "");
    private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepositoy());

    [TestMethod]
    public void Dado_um_comando_invalido_deve_interromper_a_execução()
    {
        var result = (GenericCommandResult)_handler.Handle(_inValidCommand);

        Assert.AreEqual(result.Success, false);
    }

    [TestMethod]
    public void Dado_um_comando_valido_deve_criar_a_tarefa()
    {
        var result = (GenericCommandResult)_handler.Handle(_validCommand);

        Assert.AreEqual(result.Success, true);
    }
}
