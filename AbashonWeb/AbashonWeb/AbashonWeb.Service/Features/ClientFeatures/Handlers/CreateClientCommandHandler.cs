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
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace AbashonWeb.Service.Features.ClientFeatures.Handlers
{
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, int>
    {
        private readonly IClientUnitOfWork _clientUnitOfWork;
        private readonly IErrorLogUnitOfWork _errorLogUnitOfWork;
        private readonly IDateTimeService _dateTimeService;
        private readonly IMapper<CreateClientCommand, Client> _mapper;       

        public CreateClientCommandHandler(IClientUnitOfWork clientUnitOfWork,
                                          IErrorLogUnitOfWork errorLogUnitOfWork,
                                          IDateTimeService dateTimeService,
                                          IMapper<CreateClientCommand, Client> mapper)
        {
            _clientUnitOfWork = clientUnitOfWork;           
            _errorLogUnitOfWork = errorLogUnitOfWork;
            _dateTimeService = dateTimeService;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var client = new Client();

                request.CreatedOn = _dateTimeService.NowUtc;
                request.CreatedBy = "Abhi";

                var model = _mapper.MapObjects(request, client);
               
                await _clientUnitOfWork.ClientRepository.AddAsync(model);
                await _clientUnitOfWork.Complete();

                return client.Id;
            }
            catch (Exception ex)
            {
                var errorLog = new ErrorLog();
                errorLog.Source = ex.Source;
                errorLog.Method = "CreateClientCommandHandler/Handle";
                errorLog.Arguments = JsonSerializer.Serialize(request);
                errorLog.Message = ex.Message;                
                errorLog.StackTrace = ex.StackTrace ?? null;
                errorLog.CreatedOn = _dateTimeService.NowUtc;
                errorLog.CreatedBy = "Abhi";

                await _errorLogUnitOfWork.ErrorLogRepository.AddAsync(errorLog);
                await _errorLogUnitOfWork.Complete();

                throw;
            }
                       
        }
    }
}
