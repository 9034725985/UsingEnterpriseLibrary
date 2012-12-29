using System;
using System.IO;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using Microsoft.Practices.EnterpriseLibrary.Caching.Expirations;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace CachingBlockDemo
{
    [Serializable]
    public class FileRefreshAction : ICacheItemRefreshAction
    {
        private readonly string _filename;

        public FileRefreshAction(string filename)
        {
            _filename = filename;
        }

        public void Refresh(string removedKey, object expiredValue, CacheItemRemovedReason removalReason)
        {
            var cacheManager = EnterpriseLibraryContainer.Current.GetInstance<ICacheManager>();
            var fileContents = File.ReadAllText(_filename);
            var refreshAction = new FileRefreshAction(_filename);
            var expiration = new FileDependency(_filename);

            cacheManager.Add(removedKey, fileContents, CacheItemPriority.Normal, refreshAction, expiration);
        }
    }
}
