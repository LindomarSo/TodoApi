using Todo.Domain.Entities;
using Todo.Domain.Queries;

namespace Todo.Domain.Test.QueryTest;

[TestClass]
public class TodoQueryTest
{
    private List<TodoItem> _items;

    public TodoQueryTest()
    {
        _items = new()
        {
            new TodoItem("Tarefa 1", DateTime.Now, "Usuario 1"),
            new TodoItem("Tarefa 2", DateTime.Now, "Usuario 2"),
            new TodoItem("Tarefa 3", DateTime.Now, "Usuario 3"),
            new TodoItem("Tarefa 4", DateTime.Now, "Usuario 4"),
            new TodoItem("Tarefa 5", DateTime.Now, "Teste"),
        };
    }

    [TestMethod]
    public void Dado_a_consulta_deve_retornar_tarefas_apenas_do_usuario_test()
    {
        var result = _items.AsQueryable().Where(TodoQueries.GetAll("Teste"));

        Assert.AreEqual(1, result.Count());
    }
}
