namespace CustomForms.Api.Repositories.Interfaces;

public interface IAuditableEntity
{
    // All entities should have a created and modified field
    // NOTE: All times are stored in UTC

    DateTime CreatedOnUtc { get; set; }
    DateTime ModifiedOnUtc { get; set; }
}
