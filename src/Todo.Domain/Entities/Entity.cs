namespace Todo.Domain.Entities;
                        
                            // IEquatable permite que eu faça comparação entre objetos do mesmo tipo
public abstract class Entity : IEquatable<Entity>
{

    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; private set; }

    public bool Equals(Entity? other)
    {
        return Id == other?.Id;
    }
}
