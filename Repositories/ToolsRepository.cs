using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PrestamosWPF.Models;

namespace PrestamosWPF.Repositories
{
    internal class ToolsRepository : RepositoryBase, IToolsRepository
    {
        public void Add(ToolsModel toolsModel)
        {
            using var connection = GetConnection();
            using (var command = new MySqlCommand())
            {
                connection.OpenAsync();
                command.Connection = connection;
                command.CommandText =
                    "insert into tools(id_tool, nombre, descripcion, cantidad, estado) values (@id_tool, @nombre, @descripcion, @cantidad, @estado)";
                command.Parameters.Add("@id_tool", MySqlDbType.VarChar).Value = toolsModel.id_tool;
                command.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = toolsModel.nombre;
                command.Parameters.Add("@descripcion", MySqlDbType.VarChar).Value = toolsModel.descripcion;
                command.Parameters.Add("@cantidad", MySqlDbType.VarChar).Value = toolsModel.cantidad;
                command.Parameters.Add("@estado", MySqlDbType.VarChar).Value = toolsModel.estado;
                command.ExecuteScalar();
            }
        }

        public void Edit(ToolsModel toolsModel)
        {
            using var connection = GetConnection();
            using (var command = new MySqlCommand())
            {
                connection.OpenAsync();
                command.Connection = connection;
                command.CommandText =
                    "UPDATE tools SET id_tool=@id_tool(id_tool,nombre,descripcion,cantidad,estado) values (@id_tool,@nombre,@descripcion,@cantidad,@estado)";
                command.Parameters.Add("@id_tool", MySqlDbType.VarChar).Value = toolsModel.id_tool;
                command.Parameters.Add("@nombre", MySqlDbType.VarChar).Value = toolsModel.nombre;
                command.Parameters.Add("@descripcion", MySqlDbType.VarChar).Value = toolsModel.descripcion;
                command.Parameters.Add("@cantidad", MySqlDbType.VarChar).Value = toolsModel.cantidad;
                command.Parameters.Add("@estado", MySqlDbType.VarChar).Value = toolsModel.estado;
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
                command.CommandText = "DELETE FROM tools WHERE id_tool=@id_tool";
                command.Parameters.Add("@id_tool", MySqlDbType.VarChar).Value = id.ToString();
                command.ExecuteScalar();
            }
        }

        public IEnumerable<ToolsModel> GetByAll()
        {
            var toolsList = new List<ToolsModel>();
            using var connection = GetConnection();
            using (var command = new MySqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * from tools order by id_tool asc";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var toolsModel = new ToolsModel()
                        {
                            id_tool = reader[0].ToString(),
                            nombre = reader[1].ToString(),
                            descripcion = reader[2].ToString(),
                            cantidad = reader[3].ToString(),
                            estado = reader[4].ToString()
                        };
                        toolsList.Add(toolsModel);
                    }
                }
            }

            return toolsList;
        }
    }
}
