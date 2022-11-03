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
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ToolsModel> GetByAll()
        {
            throw new NotImplementedException();
        }
    }
}
