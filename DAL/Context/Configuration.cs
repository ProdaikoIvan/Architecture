using System.Data.Entity;
using System.Data.Entity.Core.Common;
using EFCache;

namespace DAL.Context
{
    public class Configuration : DbConfiguration
    {
        public Configuration()
        {
            var transactionHandler = new CacheTransactionHandler(UnitOfWork.UnitOfWork.Cache);

            AddInterceptor(transactionHandler);

            var cachingPolicy = new CachingPolicy();

            Loaded += (sender, args) => args.ReplaceService<DbProviderServices>((s, _) =>
                new CachingProviderServices(s, transactionHandler, cachingPolicy));
        }
    }
}