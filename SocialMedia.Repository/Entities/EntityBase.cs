namespace CustomForms.Api.Repositories.Entities;

public abstract class EntityBase<T>
{
    public T Id { get; set; }
    public DateTime CreatedOnUtc { get; set; }
    public DateTime ModifiedOnUtc { get; set; }

}
