using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PrestamosWPF.Models;

namespace PrestamosWPF.Repositories
{
    public class LendingRepository : RepositoryBase,ILendingRepository
    {
        public void Add(LendingModel lendingModel)
        {
            using var connection = GetConnection();
            using (var command = new MySqlCommand())
            {
                connection.OpenAsync();
                command.Connection = connection;
                command.CommandText =
                    "insert into lendings(id_user, id_tool, name, fecha_prestamo) values (@id_user, @id_tool, @name, @fecha_prestamo)";
                command.Parameters.Add("@id_user", MySqlDbType.VarChar).Value = lendingModel.id_user;
                command.Parameters.Add("@id_tool", MySqlDbType.VarChar).Value = lendingModel.id_tool;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = lendingModel.name;
                command.Parameters.Add("@fecha_prestamo", MySqlDbType.DateTime).Value = lendingModel.fecha_prestamo;
                command.ExecuteScalar();
            }
        }

        public void Edit(LendingModel lendingModel)
        {
            using var connection = GetConnection();
            using (var command = new MySqlCommand())
            {
                connection.OpenAsync();
                command.Connection = connection;
                command.CommandText =
                    "UPDATE lendings SET (id_user, id_tool, name, fecha_prestamo) values (@id_user, @id_tool, @name, @fecha_prestamo)";
                command.Parameters.Add("@id_user", MySqlDbType.VarChar).Value = lendingModel.id_user;
                command.Parameters.Add("@id_tool", MySqlDbType.VarChar).Value = lendingModel.id_tool;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = lendingModel.name;
                command.Parameters.Add("@fecha_prestamo", MySqlDbType.DateTime).Value = lendingModel.fecha_prestamo;
                command.ExecuteScalar();
            }
        }

        public void Remove(LendingModel lendingModel)
        {
            throw new NotImplementedException();
        }

        public LendingModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LendingModel> GetByAll()
        {
            var lendingList = new List<LendingModel>();
            using var connection = GetConnection();
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * from lendings order by id_lending asc";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var lendingModel = new LendingModel()
                        {
                            id_lending = int.Parse(reader[0].ToString()),
                            id_user = reader[1].ToString(),
                            id_tool = reader[2].ToString(),
                            name = reader[3].ToString(),
                            fecha_prestamo = DateTime.Parse(reader[4].ToString())
                        };
                        lendingList.Add(lendingModel);
                    }
                }
            }

            return lendingList;
        }
    }
}
