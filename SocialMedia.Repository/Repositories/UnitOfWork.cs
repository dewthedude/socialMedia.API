using CustomForms.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Repository.EF.Context;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _appdbContext;

    private bool _disposed = false;
    public UnitOfWork(AppDbContext appDbContext)
    {
        _appdbContext = appDbContext;
    }

    public DbContext Db
    {
        get { return _appdbContext; }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing)
            {
                _appdbContext.Dispose();
            }
        }
        this._disposed = true;
    }

    public void Save()
    {
        try
        {
            _appdbContext.SaveChanges();
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
        finally
        {
        }
    }

    public void Dispose()
    {
        Dispose(true);
    }
}
