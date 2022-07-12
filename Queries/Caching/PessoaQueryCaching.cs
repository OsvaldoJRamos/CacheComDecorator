using CacheComDecorator.Models;
using Microsoft.Extensions.Caching.Memory;

namespace CacheComDecorator.Queries.Caching
{
    public class PessoaQueryCaching : IPessoaQuery
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IPessoaQuery _inner;
        private readonly ILogger<PessoaQueryCaching> _logger;

        public PessoaQueryCaching(IMemoryCache memoryCache, IPessoaQuery inner, ILogger<PessoaQueryCaching> logger)
        {
            _memoryCache = memoryCache;
            _inner = inner;
            _logger = logger;
        }
        public PessoaDto GetAll()
        {
            var key = "pessoas";
            var items = _memoryCache.Get<PessoaDto>(key);
            if (items == null)
            {
                items = _inner.GetAll();
                _logger.LogTrace("Cache miss for {CacheKey}", key);
                if (items != null)
                {
                    _logger.LogTrace("Setting items in cache for {CacheKey}", key);
                    _memoryCache.Set(key, items, TimeSpan.FromMinutes(1));
                }
            }
            else
            {
                items.FromMemory();
                _logger.LogTrace("Cache hit for {CacheKey}", key);
            }

            return items;
        }
    }
}