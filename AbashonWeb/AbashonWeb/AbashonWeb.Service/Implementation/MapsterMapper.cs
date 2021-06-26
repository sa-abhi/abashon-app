using AbashonWeb.Service.Contract;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbashonWeb.Service.Implementation
{
    public class MapsterMapper<TSource, TDestination> : IMapper<TSource, TDestination>
                                                        where TSource : class
                                                        where TDestination : class
    {
        public TDestination MapObjects(TSource source, TDestination destination)
        {
            var result =  source.Adapt(destination);

            return result;
        }
    }
}
