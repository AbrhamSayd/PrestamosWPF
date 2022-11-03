using PrestamosWPF.Models;
using System.Collections.Generic;
using System.Data;
using System.Net;

namespace PrestamosWPF.Repositories
{
    public interface IUserRepository
    {
        bool AuthenticateUser(NetworkCredential credential);
        void Add(UserModel userModel);
        void Edit(UserModel userModel);
        void Remove(int id);
        UserModel GetById(int id);
        UserModel GetByUsername(string username);
        IEnumerable<UserModel> GetByAll();
        DataTable GetByAllDataTable();
    }
}
