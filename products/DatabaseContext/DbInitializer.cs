using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.EntityFrameworkCore;
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
        string cmdInitDb = $"DROP DATABASE IF EXISTS products;CREATE DATABASE products;";

        using (NpgsqlCommand cmd = new NpgsqlCommand(cmdInitDb, _initConnection))
            {
                await cmd.ExecuteNonQueryAsync();
            }
        _initConnection.Close();
            
    }

    private async Task GenerateTables()
    {   
        _defaultConnection.Open();
        string cmdTableCreate = $"CREATE TABLE product (" +
                         "product_id INT PRIMARY KEY," +
                         "product_name VARCHAR(255) NOT NULL," +
                         "product_description TEXT," +
                         "product_image Text," +
                         "product_price DECIMAL(10,2)," +
                         "product_quantity INT);";
        string productData = File.ReadAllText("DatabaseContext/products.sql");
        using (NpgsqlCommand cmd = new NpgsqlCommand(cmdTableCreate, _defaultConnection))
        {
            await cmd.ExecuteNonQueryAsync();
        }
        using (NpgsqlCommand cmd = new NpgsqlCommand(productData, _defaultConnection))
        {
            await cmd.ExecuteNonQueryAsync();
        }
        _defaultConnection.Close();
    }
}
