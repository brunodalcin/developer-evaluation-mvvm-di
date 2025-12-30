using developer_evaluation_mvvm_di.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace developer_evaluation_mvvm_di.Services
{
    public interface IClientService
    {
        Task<List<Client>> GetAllAsync();
        Task<Client?> GetByIdAsync(int id);
        Task Create(Client client);
        Task Update(Client client);
        Task Delete(int id);
    }

}
