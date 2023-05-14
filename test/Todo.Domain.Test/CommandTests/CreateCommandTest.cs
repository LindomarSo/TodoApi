using Todo.Domain.Commands;

namespace Todo.Domain.Test.CommandTests;

[TestClass]
public class CreateCommandTest
{
    private readonly CreateTodoCommand _invalidCommand = new CreateTodoCommand("", DateTime.Now, "");
    private readonly CreateTodoCommand _validCommand = new CreateTodoCommand("Teste", DateTime.Now, "Miguel Dias");

    public CreateCommandTest()
    {
        _invalidCommand.Validate();
        _validCommand.Validate();
    }

    [TestMethod]
    public void Dado_um_comando_invalido()
    {
        Assert.AreEqual(_invalidCommand.IsValid, false);
    }

    [TestMethod]
    public void Dado_um_comando_valido()
    {
        Assert.AreEqual(_validCommand.IsValid, true);
    }
}