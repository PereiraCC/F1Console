using System;
using System.Collections.Generic;

using ConsoleF1.models;
using datasource.FormulaOnedatasource;

namespace F1Console;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido F1 Console");

        FormulaOnedatasource f1 = new FormulaOnedatasource();

        List<Team> teams = f1.getDataF1();

        string? option;

        do
        {
            foreach( Team team in teams ) {
                Console.WriteLine($"{team.IDTeam}. {team.Name}");
            }

            Console.WriteLine($"{teams.Count + 1}. Salir");

            Console.WriteLine("Seleccione un F1 Team");
            option = Console.ReadLine();

            showInfo( teams, Int32.Parse(option == "" ? "0" : option) );

        } while (Int32.Parse(option == "" ? "0" : option) != teams.Count + 1 );

    }

    private static void showInfo(List<Team> teams, int IDTeam) {

        if( teams.Count == 0 ) return;
        if( IDTeam == 0 ) return;
        if( IDTeam == teams.Count + 1 ) return;

        Team team = teams.Find( team => team.IDTeam == IDTeam );

        Console.WriteLine("=======================================");
        Console.WriteLine($"Nombre: {team.Name}");
        Console.WriteLine($"Nombre oficial: {team.FullName}");
        Console.WriteLine($"Chasis: {team.Chasis}");
        Console.WriteLine($"Motor: {team.Motor}");
        Console.WriteLine("====== Pilotos =======");

        foreach( Driver driver in team.Drivers ) {
            Console.WriteLine($"{driver.Number} {driver.FullName}");
        }

        Console.WriteLine("=======================================");

    }
}


//TODO: Crear la BD y la data de equipos, pilotos y monoplazas => Listo
//TODO: Crear los modelos => Listo
//TODO: Crear los metodo para obtener la informacion => Listo
//TODO: Crear mostrar los datos en console => Listo
//TODO: Crear el DockerFile
//TODO: Crear build de la imagen de docker
//TODO: Publicar la imagen de Docker
//TODO: Subir codigo fuente a GIT
//TODO: Crear docker compose para utilizar el app dockerizada