using Npgsql;

namespace products.DatabaseContext;

public class DbInitializer
{
    private readonly NpgsqlConnection _initConnection;
    private readonly NpgsqlConnection _defaultConnection;
    private bool dbExists;
    public DbInitializer (IConfiguration configuration)
    {
        _initConnection = new NpgsqlConnection(configuration.GetConnectionString("InitConnection"));
        _defaultConnection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
    }

    public async Task InitializeDatabaseAsync()
    {

        _initConnection.Open();
            string cmdText = "SELECT 1 FROM pg_database WHERE datname='products'";
            using (NpgsqlCommand cmd = new NpgsqlCommand(cmdText, _initConnection))
            {
                dbExists = cmd.ExecuteScalar() != null;
            }
            
            await GenerateDatabase();
            await GenerateTables();

    }


    private async Task GenerateDatabase()
    {
        string cmdInitDb = $"DROP DATABASE IF EXISTS product_data;CREATE DATABASE product_data;";

        using (NpgsqlCommand cmd = new NpgsqlCommand(cmdInitDb, _initConnection))
            {
                await cmd.ExecuteNonQueryAsync();
            }
        _initConnection.Close();
            
    }

    private async Task GenerateTables()
    {   
        _defaultConnection.Open();
        string dbData = File.ReadAllText("DatabaseContext/products.sql");
        using (NpgsqlCommand cmd = new NpgsqlCommand(dbData, _defaultConnection))
        {
            await cmd.ExecuteNonQueryAsync();
        }
        _defaultConnection.Close();
    }
}
