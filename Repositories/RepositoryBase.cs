using MySql.Data.MySqlClient;

namespace PrestamosWPF.Repositories;

public abstract class RepositoryBase
{
    private readonly string _connectionString;

    public RepositoryBase()
    {
        string server, database, uid, password;
        server = "localhost"; //ip
        database = "itsppprestamosdb";
        uid = "root";
        password = "root";
        _connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" +
                            password + ";";
    }

    public MySqlConnection GetConnection()
    {
        return new MySqlConnection(_connectionString);
    }
}