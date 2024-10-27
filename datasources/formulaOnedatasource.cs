using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

using ConsoleF1.models;

namespace datasource.FormulaOnedatasource;

class FormulaOnedatasource {

    private string connectionString;

    public FormulaOnedatasource() {

        var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("/Users/pereiracc/Desktop/F1Console/appsettings.json")
                .Build();

        connectionString = configuration.GetConnectionString("F1Connection");

    }

    public List<Team> getDataF1() {
        return getTeams();
    }

    private List<Team> getTeams() {

        List<Team> teams = new List<Team>();

        using (var connection = new SqlConnection(connectionString))
        {
            try
                {
                    connection.Open();

                    // Crear un comando SQL
                    string query = "SELECT * FROM Team";
                    SqlCommand command = new SqlCommand(query, connection);

                    // Ejecutar el comando y leer los datos
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Leer los datos
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string fullname = reader.GetString(2);
                            string chasis = reader.GetString(3);
                            string motor = reader.GetString(4);

                            List<Driver> drivers = getDrivers(id);

                            Team team = new Team(id, name, fullname, chasis, motor, drivers);
                            teams.Add(team);
                        }
                    }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error en la conexión o en la consulta: {ex.Message}");
            }
        }

        return teams;

    }

    private List<Driver> getDrivers(int IDTeam) {

        List<Driver> drivers = new List<Driver>();

        using (var connection = new SqlConnection(connectionString))
        {
            try
                {
                    connection.Open();

                    // Crear un comando SQL
                    string query = "SELECT IDDriver, fullname, number FROM dbo.Driver WHERE IDTeam = " + IDTeam;
                    SqlCommand command = new SqlCommand(query, connection);

                    // Ejecutar el comando y leer los datos
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Leer los datos
                            int id = reader.GetInt32(0);
                            string fullname = reader.GetString(1);
                            string number = reader.GetString(2);

                            Driver driver = new Driver(id, fullname, number);
                            drivers.Add(driver);
                        }

                    }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error en la conexión o en la consulta: {ex.Message}");
            }
        }

        return drivers;

    }

}