using developer_evaluation_mvvm_di.Data;
using developer_evaluation_mvvm_di.Model;
using SQLite;
using System;

namespace developer_evaluation_mvvm_di.Services
{
    public class ClientService : IClientService
    {
        private readonly SQLiteAsyncConnection _db;
        public ClientService()
        {
            _db = DbContext.GetConnection();
            _db.CreateTableAsync<Client>().Wait();
        }


        public Task<List<Client>> GetAllAsync()
        {
            return _db.Table<Client>().ToListAsync();
        }

        public Task<Client?> GetByIdAsync(int id)
        {
            return _db.Table<Client>()
                .Where(c => c.ID == id)
                .FirstOrDefaultAsync();
           
        }

        public Task Create(Client client)
        {
            return _db.InsertAsync(client);
        }

        public Task Update(Client client)
        {
            return _db.UpdateAsync(client);
        }

        public Task Delete(int id)
        {
            return _db.DeleteAsync<Client>(id);
        }
    }

}
