using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PrestamosWPF.Models;
using System.Data;

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
                command.CommandText =
                    "insert into labs(id_lab,ubicacion,id_user) values (@id_lab, @ubicacion, @id_user)";
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
                command.CommandText =
                    "UPDATE labs SET id_lab=@id_lab(id_lab,ubicacion,id_user) values (@id_lab, @ubicacion, @id_user)";
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

        public IEnumerable<LabsModel> GetByAll()
        {
            var labsList = new List<LabsModel>();
            using var connection = GetConnection();
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * from labs order by id_lab asc";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var labsModel = new LabsModel()
                        {
                            id_lab = reader[0].ToString(),
                            ubicacion = reader[1].ToString(),
                            id_user = reader[2].ToString()
                        };
                        labsList.Add(labsModel);
                    }
                }
            }
            return labsList;
        }

        //public DataTable GetByAll()
        //{
        //    DataTable dt = new DataTable();
        //    using var connection = GetConnection();
        //    using (var command = new MySqlCommand())
        //    {
        //        connection.Open();
        //        command.Connection = connection;
        //        command.CommandText = "SELECT * from labs order by id_lab asc";
        //        var reader = command.ExecuteReader();
        //        dt.Load(reader);
        //    }

        //    return dt;
        //}

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