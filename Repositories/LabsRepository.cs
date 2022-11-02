using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using PrestamosWPF.Models;

namespace PrestamosWPF.Repositories
{
    public class LabsRepository : RepositoryBase, ILabsRepository
    {

        public void Add(LabsModel labsModel)
        {
            using var connection = GetConnection();
            using (var command = new MySqlCommand())
            {
                connection.OpenAsync();
                command.Connection = connection;
                command.CommandText = "insert into labs(id_lab,ubicacion,id_user) values (@id_lab, @ubicacion, @id_user)";
                command.Parameters.Add("@id_lab", MySqlDbType.VarChar).Value = labsModel.id_lab;
                command.Parameters.Add("@ubicacion", MySqlDbType.VarChar).Value = labsModel.ubicacion;
                command.Parameters.Add("@id_user", MySqlDbType.VarChar).Value = labsModel.id_user;
                command.ExecuteScalar();
            }
        }

        public void Edit(LabsModel labsModel)
        {
            using var connection = GetConnection();
            using (var command = new MySqlCommand())
            {
                connection.OpenAsync();
                command.Connection = connection;
                command.CommandText = "UPDATE labs SET id_lab=@id_lab(id_lab,ubicacion,id_user) values (@id_lab, @ubicacion, @id_user)";
                command.Parameters.Add("@id_lab", MySqlDbType.VarChar).Value = labsModel.id_lab;
                command.Parameters.Add("@ubicacion", MySqlDbType.VarChar).Value = labsModel.ubicacion;
                command.Parameters.Add("@id_user", MySqlDbType.VarChar).Value = labsModel.id_user;
                command.ExecuteScalar();
            }
        }

        public void Remove(int id)
        {
            using var connection = GetConnection();
            using (var command = new MySqlCommand())
            {
                connection.OpenAsync();
                command.Connection = connection;
                command.CommandText = "DELETE FROM labs WHERE id_lab=@id_lab";
                command.Parameters.Add("@id_lab", MySqlDbType.VarChar).Value = id.ToString();
                command.ExecuteScalar();
            }
        }

        public DataTable GetByAll()
        {
            DataTable dt = new DataTable();
            using var connection = GetConnection();
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * from labs order by id_lab asc";
                var reader = command.ExecuteReader();
                dt.Load(reader);
            }

            return dt;
        }

        public LabsModel GetById(int id)
        {
            LabsModel labs = null;
            using var connection = GetConnection();
            using (var command = new MySqlCommand())
            {
                connection.OpenAsync();
                command.Connection = connection;
                command.CommandText = "SELECT * from labs WHERE id_lab=@id_lab";
                command.Parameters.Add("@id_lab", MySqlDbType.VarChar).Value = id.ToString();
                command.ExecuteScalar();
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        labs = new LabsModel()
                        {
                            id_lab = reader[0].ToString(),
                            ubicacion = reader[1].ToString(),
                            id_user = reader[2].ToString(),
                        };
                    }
                }
            }

            return labs;
        }
    }
}
