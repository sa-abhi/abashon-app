using AbashonWeb.Domain.Entities;
using AbashonWeb.Persistence;
using AbashonWeb.Service.Contract;
using AbashonWeb.Service.Contract.UnitOfWorks;
using AbashonWeb.Service.Features.ClientFeatures.Commands;
using Mapster;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AbashonWeb.Service.Features.ClientFeatures.Handlers
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, int>
    {
        private readonly IClientUnitOfWork _clientUnitOfWork;
        private readonly IDateTimeService _dateTimeService;
        private readonly IMapper<CreateClientCommand, Client> _mapper;
        public CreateClientCommandHandler(IClientUnitOfWork clientUnitOfWork, 
                                          IDateTimeService dateTimeService,
                                          IMapper<CreateClientCommand, Client> mapper)
        {
            _clientUnitOfWork = clientUnitOfWork;
            _dateTimeService = dateTimeService;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            var client = new Client();   

            request.CreatedOn = _dateTimeService.NowUtc;
            request.CreatedBy = "Abhi";           

            var model = _mapper.MapObjects(request, client);

            _clientUnitOfWork.ClientRepository.Add(model);
            await _clientUnitOfWork.Complete();
            return client.Id;            
        }
    }
}
