﻿using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Consola
{
    class Program
    {
        private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio();
        private static IRepositorioDT _repoDT = new RepositorioDT();
        private static IRepositorioEquipo _repoEquipo = new RepositorioEquipo();

        static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                Console.WriteLine("1. Insertar municipio");
                Console.WriteLine("2. Insertar director tecnico");
                Console.WriteLine("3. Insertar equipo");
                Console.WriteLine("4. Mostrar municipio");
                Console.WriteLine("0. Salir");
                opcion = Int32.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        AddMunicipio();
                        break;
                    case 2:
                        AddDT();
                        break;
                    case 3:
                        AddEquipo();
                        break;
                    case 4:
                        GetAllMunicipios();
                        break;
                }
            } while (opcion != 0);

        }

        private static void AddMunicipio()
        {
            Console.WriteLine("Escriba el nombre del municipio");
            string nombre = Console.ReadLine();
            var municipio = new Municipio
            {
                Nombre = nombre,
            };
            _repoMunicipio.AddMunicipio(municipio);
        }

        private static void AddDT()
        {
            Console.WriteLine("Escriba el nombre del DT");
            string nombre = Console.ReadLine();
            Console.WriteLine("Escriba el documento del DT");
            string documento = Console.ReadLine();
            Console.WriteLine("Escriba el telefono del DT");
            string telefono = Console.ReadLine();

            var directorTecnico = new DirectorTecnico
            {
                Nombre = nombre,
                Documento = documento,
                Telefono = telefono,
            };
            _repoDT.AddDT(directorTecnico);
        }

        private static void AddEquipo()
        {
            Console.WriteLine("Escriba el nombre del equipo");
            string nombre = Console.ReadLine();
            Console.WriteLine("Escriba el id del municipio");
            int idMunicipio = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Escriba el id del DT");
            int idDT = Int32.Parse(Console.ReadLine());

            var equipo = new Equipo
            {
                Nombre = nombre,
            };

            _repoEquipo.AddEquipo(equipo, idMunicipio, idDT);
        }

        private static void GetAllMunicipios()
        {
            foreach (var municipio in _repoMunicipio.GetAllMunicipios())
            {
                Console.WriteLine(municipio.Id + " " + municipio.Nombre);
            }
        }

    }
}