using MySql.Data.MySqlClient;//Permite de la base da dtos con c#
using PrestamosWPF.Models;
using System;
using System.Collections.Generic;
using System.Net;

namespace PrestamosWPF.Repositories;

public class UserRepository : RepositoryBase, IUserRepository
{
    public void Add(UserModel userModel)
    {
        //insert into users(id_user,first_name,last_name,username,password,carrera,tipo_de_empleado,area) values (02, 'Abrham', 'Martinez', 'admin', 'admin','isc', 'admin', 'redes')
        bool isExist = false;
        using var connection = GetConnection();
        using (var command = new MySqlCommand())
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText = "insert into users(id_user,first_name,last_name,username,password,carrera,tipo_de_empleado,area) values (@id, @first_name, @last_name, @username, @password,@carrera, @tipo_de_empleado, @area)";
            command.Parameters.Add("@id", MySqlDbType.Int64).Value = userModel.Id;
            command.Parameters.Add("@first_name", MySqlDbType.VarChar).Value = userModel.FirstName;
            command.Parameters.Add("@last_name", MySqlDbType.VarChar).Value = userModel.LastName;
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = userModel.Username;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = userModel.Password;
            command.Parameters.Add("@carrera", MySqlDbType.VarChar).Value = userModel.Carrera;
            command.Parameters.Add("@tipo_de_empleado", MySqlDbType.VarChar).Value = userModel.TipoEmpleado;
            command.Parameters.Add("@area", MySqlDbType.VarChar).Value = userModel.Area;
            
        }
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
                    FirstName = reader[1].ToString(),
                    LastName = reader[2].ToString(),
                    Username = reader[3].ToString(),
                    Password = string.Empty,
                    Carrera = reader[4].ToString(),
                    TipoEmpleado = reader[5].ToString(),
                    Area = reader[6].ToString(),
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