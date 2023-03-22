using Microsoft.EntityFrameworkCore;

namespace CustomForms.Api.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    DbContext Db { get; }
    void Save();
}


    

