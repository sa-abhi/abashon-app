using AbashonWeb.Domain.Entities;
using AbashonWeb.Service.Contract.Services;
using AbashonWeb.Service.Contract.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AbashonWeb.Infrastructure.Implementation.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientUnitOfWork _clientUnitOfWork;
        private readonly IErrorLogUnitOfWork _errorLogUnitOfWork;
        private readonly IDateTimeService _dateTimeService;

        public ClientService(IClientUnitOfWork clientUnitOfWork,
                             IErrorLogUnitOfWork errorLogUnitOfWork,
                             IDateTimeService dateTimeService)
        {
            _clientUnitOfWork = clientUnitOfWork;
            _errorLogUnitOfWork = errorLogUnitOfWork;
            _dateTimeService = dateTimeService;
        }
       
        public async Task<int> CreateClientAsync(Client client)
        {
            try
            {
                await _clientUnitOfWork.ClientRepository.AddAsync(client);
                await _clientUnitOfWork.Complete();
                return client.Id;
            }
            catch (Exception ex)
            {
                var errorLog = new ErrorLog();
                errorLog.Source = ex.Source;
                errorLog.Method = "CreateClientAsynce";
                errorLog.Arguments = JsonSerializer.Serialize(client);
                errorLog.Message = ex.Message;
                errorLog.StackTrace = ex.StackTrace;
                errorLog.CreatedOn = _dateTimeService.NowUtc;
                errorLog.CreatedBy = "Abhi";

                await _errorLogUnitOfWork.ErrorLogRepository.AddAsync(errorLog);
                await _errorLogUnitOfWork.Complete();

                throw;
            }           
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            try
            {
                var clients = await _clientUnitOfWork.ClientRepository.GetAllAsync();
                return clients;
            }
            catch (Exception ex)
            {
                var errorLog = new ErrorLog();
                errorLog.Source = ex.Source;
                errorLog.Method = "GetClientsAsync";                
                errorLog.Message = ex.Message;
                errorLog.StackTrace = ex.StackTrace;
                errorLog.CreatedOn = _dateTimeService.NowUtc;
                errorLog.CreatedBy = "Abhi";

                await _errorLogUnitOfWork.ErrorLogRepository.AddAsync(errorLog);
                await _errorLogUnitOfWork.Complete();

                throw;
            }
        }
    }
}
