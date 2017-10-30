using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public static class GameServices
{
    //MIEMBROS
    #region Miembros
    private static List<Player> listPlayer= new List<Player>()    ;
    private static List<Game> listGames = new List<Game>();


    const string Path  = "../../Resources/Export.txt";
    #endregion

    //GETTERS Y STTERS
    #region GetterSetters
    public static List<Game> ListGames
    {
        get { return listGames; }
    }


    public static List<Player> ListPlayer
    {
        get { return listPlayer; }

    }
    #endregion


    //TODO EXPORTAR E IMPORTAR
    #region Export
    public static void Export()
    {
        // Convertir todas los jugadores en string con el formato
        string playerData = ConvertPlayerToString();
        // Convertir todas los juegos en string con el formato
        string gameData = ConvertGameToString();
        //Convertir todos los rankings en string con el formato indicado
        string rankingData = ConvertRankingToString();

        // Escribir en el fichero los datos anteriores separados por el patron '*+++*'
        try
        {
            StreamWriter file = File.CreateText(Path);
            string completeData = playerData + "*+*+*+*\n" + gameData + " *+*+*+*\n"+rankingData;
            file.Write(completeData);
            file.Close();
            Console.WriteLine("Datos exportados correctamente");
        }
        catch (Exception e)
        {
            Console.WriteLine("Error al exportar los datos. " + e);
        }
    }

    //para convertir los jugadores a string como cadena para el export
    private static string ConvertPlayerToString()
    {
        string data = "";

        foreach (Player player in listPlayer)
        {
            string playerData = "";
            //songData = song.Name + "-" + song.Author + "-" + song.Duration + "-" + song.Year + "-" + song.Genre + "-" + song.Score;
            playerData = string.Format("{0}-{1}-{2}",player.NickNamePlayer,player.Email,player.Countries);
            playerData += "\n";
            data += playerData;
        }

        return data;
    }
    //convertir los juegos en string para el xport
    private static string ConvertGameToString()
    {
        string data = "";

        foreach (Game game in listGames)
        {
            //para controlar la cadena de plataformas
            string plataformas = "";
            foreach (Platforms plat1 in game.Platforms)
            {
                plataformas += plat1.ToString() + ",";
            }
            string gameData = "";
            //songData = song.Name + "-" + song.Author + "-" + song.Duration + "-" + song.Year + "-" + song.Genre + "-" + song.Score;
            gameData = string.Format("{0}-{1}-{2}", game.Name,game.Genres,plataformas);
            gameData += "\n";
            data += gameData;
        }
        return data;
    }

    //Convertir los rankings con sus puntos en una cadena string para export
    private static string ConvertRankingToString()
    {
        string data = "";
        string rankingData = "";
        //recorremos la lista de juegos para poder acceder a los rankings
        foreach (Game game in listGames)
        {
            //recorremos los ranking para acceder a la lista de scores
            foreach (Ranking rank1 in game.Rankings.Values)
            {
               //almacenamos el nombre del juego y e nombre del ranking en un string
                rankingData = string.Format("{0}-{1}-", game.Name, rank1.Name);
                //recorremos la lista de scores con sus respectivos jugadores
                foreach (Score scor in rank1.Scores)
                { 
                    //almacenamos los datos de los jugadores del ranking en un strin
                    rankingData += string.Format("{0}={1},",scor.NickNameScore,scor.Points);
                   
                    
                }
            }
            //juntamos los string con el juego y el nombre del ranking y las puntuaciones y lo metemos todo en uno el cual devolveremos
            data += rankingData;

        }
        return data;

    }
    #endregion

    //Import
    #region Import
        //imposible
    public static void Import(string ruta)
    {
        List<string> lines = new List<string>();
        List<string> playerLines = new List<string>();
        List<string> gamesLines = new List<string>();
        List<string> rankingLines = new List<string>();
        bool isPlayer = false;
        bool isRanking = false;
        foreach (string line in lines)
        {
            if (line == "*+*+*+*")
            {
                isPlayer = true;
            }
            else
            {
                if (!isPlayer)
                {
                    playerLines.Add(line);
                }
                else if(!isRanking)
                {
                    gamesLines.Add(line);
                }
            }
        }

        foreach (string line in playerLines)
        {
            Player p1 = new Player(line);
            listPlayer.Add(p1);
        }

        foreach (string line in gamesLines)
        {
            Game g1 = new Game(line);
            listGames.Add(g1);
        }

    }
    #endregion


    //FUNCIONALIDADES PARTE 3
    #region FuncionalidadesParte3
    //mas antiguo
    public static Game MasAntiguo()
    {
        Game res = null;
        foreach (Game game in listGames)
        {
            if (res == null || res.ReleaseDate < game.ReleaseDate)
            {
                res = game;
            }
        }
        return res;
    }

    //numero de puntuaciones un ranking de un juegp introduciendo el nombre de juego y nombre de ranking
    public static int NumeroPuntuacionesRankingJuegoDet(string gameName, string rankingName)
    {
        int res = 0;
        foreach (Game game in listGames)
        {
            if (game.Name == gameName)
            {
                if (game.Rankings != null)
                {
                    if (game.Rankings.Values.ToString().ToLower() == rankingName.ToLower())
                    {
                        res = game.Rankings.Count;
                    }
                }
                else
                {
                    Console.WriteLine("El juego no tiene ranking");
                }
            }
        }

        return res;
    }

    //numero juegos de un determinado genero
    public static int NumeroJuegosDeterminadoGenero(Genres genre)
    {
        int aux = 0;
        foreach (Game game in ListGames)
        {
            if (game.Genres == genre)
            {
                aux++;
            }
        }

        return aux;
    }

    //juego con mas puntuaciones registradas
    public static Game JuegoMayorPuntuacionRegistrada()
    {
        Game aux = null;

        foreach (Game game in listGames)
        {
            if (game == null || aux.Rankings.Values.Count < game.Rankings.Values.Count)
            {
                aux = game;
            }
        }

        return aux;
    }

    //juego que contenga a palabra Call en su nombre
    public static bool ContenidaCall()
    {
        bool res = false;
        string s = "Call";
        foreach (Game game in listGames)
        {
            if (game.Name.Contains("Call"))
            {
                res = true;
            }
        }
        return res;
    }
    //INVENTADO ASI K MIRATELO
    //jjuegos a los que un determinado jugador ha jugado
    public static List<Game> JuegosJugadosPor(string playerName)
    {
        List<Game> juegosJugados = null;
        //para recorrer la lista de juegos y poder acceder al nombre de la puntuacion del ranking correspondiente
        foreach (Game game in listGames)
        {
            //para acceder al los rankings del juego
            foreach (Ranking ran in game.Rankings.Values)
            {
                //recorremos la lista de puntuaciones de los valores del diccionario que es una lista de puntuaciones
                foreach (Score scor in ran.Scores)
                {
                    if (scor.NickNameScore == playerName)
                    {
                        juegosJugados.Add(game);
                    }
                }
            }
        }
        return juegosJugados;
    }

    //juegos jugados por cada jugador
    //hay que devolver un diccionario con el jugador y una lista de juegos a los que ha jugado
    public static Dictionary<string, List<Game>> GamesByPlayer()
    {
        int contPlayer = 0;
        List<Game> gameAux = null;
        Dictionary<string, List<Game>> aux = null;

        //para recorrer la lista de jugadores e ir almacenandola en el diccionario despues
        foreach (Player player in listPlayer)
        {
            //para recorrer la lista de juegos y poder acceder al nombre de la puntuacion del ranking correspondiente
            foreach (Game game in listGames)
            {
                //para acceder al los rankings del juego
                foreach (Ranking ran in game.Rankings.Values)
                {
                    //recorremos la lista de puntuaciones de los valores del diccionario que es una lista de puntuaciones
                    foreach (Score score in ran.Scores)
                    {
                        //si el nnombre de la puntuacion coincide con el nombre del jugador
                        if(score.NickNameScore == player.NickNamePlayer)
                        {
                            //me añade el juego a la lista de juegos
                            gameAux.Add(game);
                            
                        }
                    }
                }

            }
            aux.Add(player.NickNamePlayer, gameAux);
        }

        return aux;
    }

    #endregion


    //INTERPRETE CONSOLA
    #region InterpreteConsola
        //El interprete se encuentra debajo de los objetos creados para pruebas
    public static void RealizarTest()
    {

        Score s1 = new Score("Score1Chema", 45);
        Score s2 = new Score("Score2Juan", 55);
        Score s3 = new Score("Score3Pepe", 123);
        Score s4 = new Score("score4", 897);
        Score s5 = new Score("score5", 78);
        Score s6 = new Score("score6", 6456);
        Score s7 = new Score("Score7", 4);
        Score s8 = new Score("score8", 3);
        Score s9 = new Score("score9", 89);
        List<Score> lis1 = new List<Score>();
        lis1.Add(s1);
        lis1.Add(s2);
        lis1.Add(s3);
        lis1.Add(s4);

        List<Score> lis2 = new List<Score>();
        lis2.Add(s1);
        lis2.Add(s2);
        lis2.Add(s3);
        lis2.Add(s4);
        lis2.Add(s5);
        lis2.Add(s6);

        lis2.Add(s7);
        lis2.Add(s8);
        List<Platforms> lisPlat = new List<Platforms>();
        lisPlat.Add(global::Platforms.MAC);
        lisPlat.Add(global::Platforms.Linux);

        List<Platforms> lisPlat2 = new List<Platforms>();
        lisPlat2.Add(global::Platforms.PC);
        lisPlat2.Add(global::Platforms.PS4);
        lisPlat2.Add(global::Platforms.Linux);

        Player p1 = new Player("Player1", "emaildelplayer1", Countries.France);
        Player p2 = new Player("Player2", "Emailplayer2", Countries.Spain);

        

        Ranking rank1 = new Ranking("Ranking1-Lis1", lis1);
        Ranking rank2 = new Ranking("Tanking-", lis2);

        Dictionary<Platforms, Ranking> dict1 = new Dictionary<global::Platforms, Ranking>();
        dict1.Add(global::Platforms.MAC, rank1);

        Dictionary<Platforms, Ranking> dict2 = new Dictionary<global::Platforms, Ranking>();
        dict2.Add(global::Platforms.PC, rank2);

        //dict2.Add(global::Platforms.XBOXONE, rank2);
        //dict2.Add(global::Platforms.Linux, rank1);
        Game g1 = new Game("NuevoJuego1istPlatDic1", Genres.Simulation, lisPlat, 2010, dict1); ;
        Game g2 = new Game("JUEGONUMERO2", Genres.Desconocido, lisPlat2, 1980, dict2); ;


        listPlayer.Add(p1);
        listPlayer.Add(p2);

        listGames.Add(g1);
        listGames.Add(g2);
        //para llamar a la funcion de GenerarDatosAleatorios
        //RepasoListas.DatosRandomPrueba(24);

        while (true)
        {
            Console.Write("Introduce un comando: ");
            string frase1 = Console.ReadLine();
            //Add{color}
            //Remove{color}
            //1º lo ponesmos en minuscula
            frase1 = frase1.ToLower();
            //2ºTrocear ara averiguar el comando y el valor
            string[] arrayParaTrocear1 = frase1.Split(' ');
            string comando1 = arrayParaTrocear1[0];
            //LA INICIAMOS VACIA PARA COMPROBAR SI LLEGA 1 O 2 ELEMENTOS AL ARRAY   
            string valor1 = "";
            //PARA COMPROBAR QUE EL ARRAY TIENE MAS DE 1 VALOR
            if (arrayParaTrocear1.Length > 2)
            {
                valor1 = arrayParaTrocear1[2];
            }



            //3ºAveriguar con un switch el comando ntroducido
            switch (comando1)
            {
                case "import":
                    Console.WriteLine("Introduzca ruta de importacion");
                    string ruta = Console.ReadLine();
                    Import(ruta);
                    break;

                case "export":
                    Export();
                    break;

                case "oldest":
                    Console.WriteLine("El juego más antigüo es: "+MasAntiguo().Name + " Fecha de lanzamiento: "+MasAntiguo().ReleaseDate);
                    break;
                case "scorecount":
                    Console.WriteLine("Introduce nombre de juego");
                    string nameAux = Console.ReadLine();
                    Console.WriteLine("Introduce nombre de ranking");
                    string nameRanking = Console.ReadLine();
                    Console.WriteLine("El ranking; " + nameRanking + " tiene un total de :" + NumeroPuntuacionesRankingJuegoDet(nameAux, nameRanking) + "puntuaciones");
                    break;
                case "gamescountbygenre":
                    Console.WriteLine("Introduce genero");
                    string nombreGenero = Console.ReadLine();
                    //para comprobar si el string intrducido esta contenido en el enumerado Genereos
                    Genres genre = (Genres)Enum.Parse(typeof(Genres), nombreGenero);
                    Console.WriteLine("Para el genero" + nombreGenero + " hay un total de: " + NumeroJuegosDeterminadoGenero(genre) + " de titulos");
                    break;

                case "gamesbyplayer":

                    string nickName = "";
                    string games = "";
                    string gamesByPlayer = "";
                    Dictionary<string, List<Game>> aux = GamesByPlayer();
                    //Para recorrer el diccionario por key - value
                    foreach (KeyValuePair<string, List<Game>> item in aux)
                    {
                        nickName = item.Key;
                        foreach (Game game in item.Value)
                        {
                            games += game.Name + ",";
                        }

                        gamesByPlayer = string.Format("->{0}:\n ===========>{1}", nickName, games);
                    }

                    Console.WriteLine(gamesByPlayer);
                    break;
                default:
                    break;
            }
        }
    }


    #endregion

    //INTERPRETE CONSOLA


}

