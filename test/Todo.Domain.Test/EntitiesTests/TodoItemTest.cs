using Todo.Domain.Entities;

namespace Todo.Domain.Test.EntitiesTests;

[TestClass]
public class TodoItemTest
{
    [TestMethod]
    public void Dado_um_novo_todo_o_mesmo_nao_pode_ser_concluido()
    {
        var todo = new TodoItem("Título aqui", DateTime.Now, "Teste de Usuário");

        Assert.AreEqual(todo.Done, false);
    }
}
