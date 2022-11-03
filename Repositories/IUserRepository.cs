using System.Collections.Generic;
using System.Net;
using PrestamosWPF.Models;

namespace PrestamosWPF.Repositories;

public interface IUserRepository
{
    bool AuthenticateUser(NetworkCredential credential);
    void Add(UserModel userModel);
    void Edit(UserModel userModel);
    void Remove(int id);
    UserModel GetById(int id);
    UserModel GetByUsername(string username);
    IEnumerable<UserModel> GetByAll();
}