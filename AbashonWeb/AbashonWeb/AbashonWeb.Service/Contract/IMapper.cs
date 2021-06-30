using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbashonWeb.Service.Contract
{
    public interface IMapper<TSource, TDestination> where TSource : class
                                                    where TDestination : class
    {
        Task<TDestination> MapObjectsAsync(TSource source, TDestination destination);

        Task<IEnumerable<TDestination>> MapObjectListAsync(IEnumerable<TSource> source, IEnumerable<TDestination> destination);
    }
}
