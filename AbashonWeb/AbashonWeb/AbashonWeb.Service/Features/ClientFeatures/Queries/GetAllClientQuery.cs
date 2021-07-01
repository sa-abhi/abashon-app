using AbashonWeb.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbashonWeb.Service.Features.ClientFeatures.Queries
{
    public class GetAllClientQuery : IRequest<IEnumerable<Client>>
    {
       
    }
}
