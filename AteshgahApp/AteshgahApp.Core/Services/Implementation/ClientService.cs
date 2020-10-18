using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using AteshgahApp.Core.DataContext;
using AteshgahApp.Core.Models;

namespace AteshgahApp.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly MainDataContext _dataContext;

        public ClientService(MainDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await _dataContext.Clients.ToListAsync();
        }
    }
}
