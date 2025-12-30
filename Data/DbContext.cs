using developer_evaluation_mvvm_di.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Microsoft.Maui.Storage;

namespace developer_evaluation_mvvm_di.Data
{
    public class DbContext
    {
        private static SQLiteAsyncConnection? _database;
        public static SQLiteAsyncConnection GetConnection()
        {
            if (_database != null)
                return _database;

            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "clients.db3");
            _database = new SQLiteAsyncConnection(dbPath);
            return _database;
        }
    }
}
