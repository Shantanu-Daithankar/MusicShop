using System.Collections.Generic;

namespace MusicShop.Interfaces
{
    public interface IRepositoryService
    {
        int Delete(string query, object parameters);
        int Execute(string query, object parameters);
        List<T> Get<T>(string query, object parameters);
        int Insert(string query, object parameters);
        int Update(string query, object parameters);
    }
}