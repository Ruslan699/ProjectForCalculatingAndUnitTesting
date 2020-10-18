using AteshgahApp.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AteshgahApp.Core.Services
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAllClientsAsync();
    }
}
