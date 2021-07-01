using AbashonWeb.Domain.Entities;
using AbashonWeb.Service.Contract;
using AbashonWeb.Service.Contract.Services;
using AbashonWeb.Service.Features.ClientFeatures.Commands;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace AbashonWeb.Service.Features.ClientFeatures.Handlers
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, int>
    {        
        public readonly IClientService _clientService;
        private readonly IDateTimeService _dateTimeService;
        private readonly IMapper<CreateClientCommand, Client> _mapper;       

        public CreateClientCommandHandler(
                                          IClientService clientService,
                                          IDateTimeService dateTimeService,
                                          IMapper<CreateClientCommand, Client> mapper
                                         )
        {            
            _clientService = clientService;
            _dateTimeService = dateTimeService;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {            
            var client = new Client();
            request.CreatedOn = _dateTimeService.NowUtc;
            request.CreatedBy = "Abhi";

            var model = await _mapper.MapObjectsAsync(request, client);
            var result =  await _clientService.CreateClientAsync(model);                

            return result;           
        }
    }
}
