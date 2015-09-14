using System;
using System.Threading.Tasks;
using DAL.Repository;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task Commit();
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}