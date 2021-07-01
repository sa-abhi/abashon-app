using AbashonWeb.Service.Contract;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbashonWeb.Infrastructure.Implementation
{
    public class MapsterMapper<TSource, TDestination> : IMapper<TSource, TDestination>
                                                        where TSource : class
                                                        where TDestination : class
    {
        public async Task<TDestination> MapObjectsAsync(TSource source, TDestination destination)
        {
            var result =  Task.FromResult(source.Adapt(destination));

            return await result;
        }

        public async Task<IEnumerable<TDestination>> MapObjectListAsync(IEnumerable<TSource> source, IEnumerable<TDestination> destination)
        {
            var result = Task.FromResult(source.Adapt(destination).ToList());
            return await result;
        }
    }
}
