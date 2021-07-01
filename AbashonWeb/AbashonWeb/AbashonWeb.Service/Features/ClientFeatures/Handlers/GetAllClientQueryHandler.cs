using AbashonWeb.Domain.Entities;
using AbashonWeb.Service.Contract.Services;
using AbashonWeb.Service.Contract.UnitOfWorks;
using AbashonWeb.Service.Features.ClientFeatures.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AbashonWeb.Service.Features.ClientFeatures.Handlers
{
    public class GetAllClientQueryHandler : IRequestHandler<GetAllClientQuery, IEnumerable<Client>>
    {
        private readonly IClientService _clientService;       
        private readonly IDateTimeService _dateTimeService;

        public GetAllClientQueryHandler(
                                         IClientService clientService,                                                                               
                                         IDateTimeService dateTimeService
                                       )
        {            
            _clientService = clientService;           
            _dateTimeService = dateTimeService;
        }
    
        public async Task<IEnumerable<Client>> Handle(GetAllClientQuery query, CancellationToken cancellationToken)
        {
            var clients = await _clientService.GetClientsAsync();                
            return clients;            
        }
    }
}
