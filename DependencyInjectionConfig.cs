using CacheComDecorator.Queries;
using CacheComDecorator.Queries.Caching;

namespace CacheComDecorator
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IPessoaQuery, PessoaQuery>();
        }

        public static void EnableDecorator(this IServiceCollection services)
        {
            services.Decorate<IPessoaQuery, PessoaQueryCaching>();
        }
    }
}
