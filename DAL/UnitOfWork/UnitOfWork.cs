using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Context;
using DAL.Repository;
using EFCache;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
            Cache = new InMemoryCache();
            _context = new DataContext();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories == null)
                _repositories = new Dictionary<string, object>();

            var type = typeof (TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof (GenericRepository<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof (TEntity)),
                    _context);
                _repositories.Add(type, repositoryInstance);
            }

            return (GenericRepository<TEntity>) _repositories[type];
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        #region Fields

        private bool _disposed;
        private readonly DataContext _context;
        private Dictionary<string, object> _repositories;
        public static InMemoryCache Cache;

        #endregion

        #region Dispose

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}