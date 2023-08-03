using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TodoGuru
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<UserTask>();
        }

        public Task<List<UserTask>> getTaskAsync()
        {
            return _database.Table<UserTask>().ToListAsync();
        }

        public Task<int> saveUserTaskAsync(UserTask userTask)
        {
            return _database.InsertAsync(userTask);
        }

        public Task<int> updateUserTaskAsync(UserTask userTask)
        {
            return _database.UpdateAsync(userTask);
        }

        public Task<int> deleteUserTaskAsync(UserTask userTask)
        {
            return _database.DeleteAsync(userTask);
        }
    }
}