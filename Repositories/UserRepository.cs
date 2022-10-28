﻿using MySql.Data.MySqlClient;//Permite de la base da dtos con c#
using PrestamosWPF.Models;
using System;
using System.Collections.Generic;
using System.Net;

namespace PrestamosWPF.Repositories;

public class UserRepository : RepositoryBase, IUserRepository
{
    public void Add(UserModel userModel)
    {
        throw new NotImplementedException();
    }

    
    public bool AuthenticateUser(NetworkCredential credential)
    {
        bool validUser;
        using var connection = GetConnection();
        using (var command = new MySqlCommand())
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText = "select * from users where username=@username and password=@password";
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = credential.UserName;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = credential.Password;
            validUser = command.ExecuteScalar() != null;
        }

        return validUser;
    }

    public void Edit(UserModel userModel)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<UserModel> GetByAll()
    {
        throw new NotImplementedException();
    }

    public UserModel GetById(int id)
    {
        throw new NotImplementedException();
    }

    public UserModel GetByUsername(string username)
    {
        UserModel user = null;
        using var connection = GetConnection();
        using var command = new MySqlCommand();
        connection.Open();
        command.Connection = connection;
        command.CommandText = "select * from users where username=@username";
        command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
        using (var reader = command.ExecuteReader())
        {
            if (reader.Read())
            {
                user = new UserModel()
                {
                    Id = reader[0].ToString(),
                    Username = reader[1].ToString(),
                    Password = string.Empty,
                    Name = reader[3].ToString(),
                    LastName = reader[4].ToString()
                };


            }
        }

        return user;
    }

    public void Remove(int id)
    {
        throw new NotImplementedException();
    }
}