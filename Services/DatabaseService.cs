using Dapper;
using MusicShop.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace MusicShop.Services
{
    public class DatabaseService : IRepositoryService
    {
        string _dbFile;
        
        public DatabaseService(string dbfilePath)
        {
            _dbFile = dbfilePath;
        }

        private SQLiteConnection GetDbConnection()
        {
            return new SQLiteConnection("Data Source=" + _dbFile);
        }

        public int Execute(string query, object parameters)
        {
            using (var cnn = GetDbConnection())
            {
                var resultSet = cnn.Execute(query, parameters);

                return cnn.Changes;
            }
        }

        public List<T> Get<T>(string query, object parameters)
        {
            using (var cnn = GetDbConnection())
            {
                var resultSet = cnn.Query<T>(query, parameters).ToList();

                return resultSet;
            }
        }

        public int Insert(string query, object parameters)
        {
            return Execute(query, parameters);
        }

        public int Update(string query, object parameters)
        {
            return Execute(query, parameters);
        }

        public int Delete(string query, object parameters)
        {
            return Execute(query, parameters);
        }
    }
}