using Microsoft.Extensions.Caching.Distributed;
using StackExchange.Redis;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Cache
{
    public class RedisCacheService : IDistributedCache
    {
        private readonly IDatabase _database;

        public RedisCacheService(string connectionString)
        {
            var options = ConfigurationOptions.Parse(connectionString);
            var connection = ConnectionMultiplexer.Connect(options);
            _database = connection.GetDatabase();
        }

        // IDistributedCache arayüzündeki metodların implementasyonları
        public byte[] Get(string key)
        {
            return _database.StringGet(key);
        }

        public void Set(string key, byte[] value, DistributedCacheEntryOptions options)
        {
            _database.StringSet(key, value);
        }

        public async Task<byte[]> GetAsync(string key, CancellationToken token = default)
        {
            return await Task.FromResult(Get(key));
        }

        public async Task SetAsync(string key, byte[] value, DistributedCacheEntryOptions options, CancellationToken token = default)
        {
            Set(key, value, options);
            await Task.CompletedTask;
        }

        public void Refresh(string key)
        {
            // Implement refresh logic if necessary
        }

        public Task RefreshAsync(string key, CancellationToken token = default)
        {
            Refresh(key);
            return Task.CompletedTask;
        }

        public void Remove(string key)
        {
            _database.KeyDelete(key);
        }

        public Task RemoveAsync(string key, CancellationToken token = default)
        {
            Remove(key);
            return Task.CompletedTask;
        }
    }
}


