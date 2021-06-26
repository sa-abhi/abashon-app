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
        TDestination MapObjects(TSource source, TDestination destination);
    }
}
