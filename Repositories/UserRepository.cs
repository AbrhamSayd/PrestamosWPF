using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using MySql.Data.MySqlClient;
using PrestamosWPF.Models;
//Permite de la base da dtos con c#

namespace PrestamosWPF.Repositories;

public class UserRepository : RepositoryBase, IUserRepository
{
    public void Add(UserModel userModel)
    {
        //insert into users(id_user,first_name,last_name,username,password,carrera,tipo_de_empleado,area) values (02, 'Abrham', 'Martinez', 'admin', 'admin','isc', 'admin', 'redes')
        var isExist = false;
        using var connection = GetConnection();
        using (var command = new MySqlCommand())
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText =
                "insert into users(id_user,first_name,last_name,username,password,carrera,tipo_de_empleado,area) values (@id, @first_name, @last_name, @username, @password,@carrera, @tipo_de_empleado, @area)";
            command.Parameters.Add("@id", MySqlDbType.Int64).Value = userModel.Id;
            command.Parameters.Add("@first_name", MySqlDbType.VarChar).Value = userModel.FirstName;
            command.Parameters.Add("@last_name", MySqlDbType.VarChar).Value = userModel.LastName;
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = userModel.Username;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = userModel.Password;
            command.Parameters.Add("@carrera", MySqlDbType.VarChar).Value = userModel.Carrera;
            command.Parameters.Add("@tipo_de_empleado", MySqlDbType.VarChar).Value = userModel.TipoEmpleado;
            command.Parameters.Add("@area", MySqlDbType.VarChar).Value = userModel.Area;
            command.ExecuteScalar();
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
        var isExist = false;
        using var connection = GetConnection();
        using (var command = new MySqlCommand())
        {
            //(id_user,first_name,last_name,username,password,carrera,tipo_de_empleado,area) values (@id, @first_name, @last_name, @username, @password,@carrera, @tipo_de_empleado, @area)
            connection.Open();
            command.Connection = connection;
            command.CommandText =
                "UPDATE users SET id_user=@id, first_name=@first_name, last_name=@last_name, username=@username, password=@password, carrera=@carrera, tipo_de_empleado=@tipo_de_empleado,area=@area WHERE id_user=@id";
            command.Parameters.Add("@id", MySqlDbType.Int64).Value = userModel.Id;
            command.Parameters.Add("@first_name", MySqlDbType.VarChar).Value = userModel.FirstName;
            command.Parameters.Add("@last_name", MySqlDbType.VarChar).Value = userModel.LastName;
            command.Parameters.Add("@username", MySqlDbType.VarChar).Value = userModel.Username;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = userModel.Password;
            command.Parameters.Add("@carrera", MySqlDbType.VarChar).Value = userModel.Carrera;
            command.Parameters.Add("@tipo_de_empleado", MySqlDbType.VarChar).Value = userModel.TipoEmpleado;
            command.Parameters.Add("@area", MySqlDbType.VarChar).Value = userModel.Area;

            command.ExecuteScalar();
        }
    }

    public IEnumerable<UserModel> GetByAll()
    {
        var userList = new List<UserModel>();
        using var connection = GetConnection();
        using (var command = new MySqlCommand())
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText = "SELECT * from users order by first_name asc";
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var userModel = new UserModel
                    {
                        Id = reader[0].ToString(),
                        FirstName = reader[1].ToString(),
                        LastName = reader[2].ToString(),
                        Username = reader[3].ToString(),
                        Password = string.Empty,
                        Carrera = reader[4].ToString(),
                        TipoEmpleado = reader[5].ToString(),
                        Area = reader[6].ToString()
                    };
                    userList.Add(userModel);
                }
            }
        }

        return userList;
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
                user = new UserModel
                {
                    Id = reader[0].ToString(),
                    FirstName = reader[1].ToString(),
                    LastName = reader[2].ToString(),
                    Username = reader[3].ToString(),
                    Password = string.Empty,
                    Carrera = reader[4].ToString(),
                    TipoEmpleado = reader[5].ToString(),
                    Area = reader[6].ToString()
                };
        }

        return user;
    }

    public void Remove(int id)
    {
        throw new NotImplementedException();
    }

    public DataTable GetByAllDataTable()
    {
        var dt = new DataTable();
        using var connection = GetConnection();
        using (var command = new MySqlCommand())
        {
            connection.Open();
            command.Connection = connection;
            command.CommandText = "SELECT * from users order by first_name asc";
            var reader = command.ExecuteReader();
            dt.Load(reader);
        }

        return dt;
    }
}