using Torneo.App.Dominio;
using Torneo.App.Persistencia;

namespace Torneo.App.Consola
{
    class Program
    {
        private static IRepositorioMunicipio _repoMunicipio = new RepositorioMunicipio();
        private static IRepositorioDT _repoDT = new RepositorioDT();
        private static IRepositorioEquipo _repoEquipo = new RepositorioEquipo();
        private static IRepositorioPosicion _repoPosicion = new RepositorioPosicion();
        private static IRepositorioJugador _repoJugador = new RepositorioJugador();
        private static IRepositorioPartido _repoPartido = new RepositorioPartido();


        static void Main(string[] args)
        {
            int opcion = 0;
            do
            {
                Console.WriteLine("1. Insertar municipio");
                Console.WriteLine("2. Insertar director tecnico");
                Console.WriteLine("3. Insertar equipo");
                Console.WriteLine("4. Insertar posicion");
                Console.WriteLine("5. Insertar jugador");
                Console.WriteLine("6. Insertar partido");
                Console.WriteLine("7. Mostrar municipios");
                Console.WriteLine("8. Mostrar DTs");
                Console.WriteLine("9. Mostrar equipos");
                Console.WriteLine("10. Mostrar posiciones");
                Console.WriteLine("11. Mostrar jugadores");
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
                        AddPosicion();
                        break;
                    case 5:
                        AddJugador();
                        break;
                    case 6:
                        AddPartido();
                        break;
                    case 7:
                        GetAllMunicipios();
                        break;
                    case 8:
                        GetAllDTs();
                        break;
                    case 9:
                        GetAllEquipos();
                        break;
                    case 10:
                        GetAllPosiciones();
                        break;
                    case 11:
                        GetAllJugadores();
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

        private static void AddPosicion()
        {
            Console.WriteLine("Escriba la posicion del jugador");
            string nombre = Console.ReadLine();
            var posicion = new Posicion
            {
                Nombre = nombre,
            };
            _repoPosicion.AddPosicion(posicion);
        }

        private static void AddJugador()
        {
            Console.WriteLine("Escriba el nombre del jugador");
            string nombre = Console.ReadLine();
            Console.WriteLine("Escriba el numero del jugador");
            int numero = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Escriba el id del Equipo");
            int idEquipo = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Escriba el id de la posicion");
            int idPosicion = Int32.Parse(Console.ReadLine());


            var jugador = new Jugador
            {
                Nombre = nombre,
                Numero = numero,
            };

            _repoJugador.AddJugador(jugador, idEquipo, idPosicion);
        }

        private static void AddPartido()
        {
            Console.WriteLine("Escriba la fecha y hora del partido (AAAA/MM/DD HH:MM:SS)");
            DateTime fechaHora = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Escriba el id del equipo local");
            int local = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Escriba el id del equipo visitante");
            int visitante = Int32.Parse(Console.ReadLine());


            var partido = new Partido
            {
                FechaHora = fechaHora,
                MarcadorLocal = 0,
                MarcadorVisitante = 0,
            };
            _repoPartido.AddPartido(partido, local, visitante);
        }

        private static void GetAllMunicipios()
        {
            foreach (var municipio in _repoMunicipio.GetAllMunicipios())
            {
                Console.WriteLine(municipio.Id + " " + municipio.Nombre);
            }
        }

        private static void GetAllDTs()
        {
            foreach (var dt in _repoDT.GetAllDTs())
            {
                Console.WriteLine(dt.Id + " " + dt.Nombre + " " + dt.Documento + " " + dt.Telefono);
            }
        }

        private static void GetAllEquipos()
        {
            foreach (var equipo in _repoEquipo.GetAllEquipos())
            {
                Console.WriteLine(equipo.Id + " " + equipo.Nombre + " " + equipo.Municipio.Nombre
                + " " + equipo.DirectorTecnico.Nombre);
            }
        }

        private static void GetAllPosiciones()
        {
            foreach (var posicion in _repoPosicion.GetAllPosiciones())
            {
                Console.WriteLine(posicion.Id + " " + posicion.Nombre);
            }
        }

        private static void GetAllJugadores()
        {
            foreach (var jugador in _repoJugador.GetAllJugadores())
            {
                Console.WriteLine(jugador.Nombre + " " + jugador.Numero + " " 
                + jugador.Equipo.Nombre + " " + jugador.Posicion.Nombre);

            }
        }

    }
}