using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Game
{
    //MIEMBROS
    #region Miembros
    private string name;
    private Genres genres;
    private List<Platforms> listaPlatforms;
    private int releaseDate;
    private Dictionary<Platforms, Ranking> rankings;
    #endregion
    //CONSTRUCTORES
    #region Constructores
        //constructor vacio
    public Game()
    {
        this.name = "Desconocido";
        this.genres = 0;
        this.listaPlatforms = null;
        this.releaseDate = 0;
        this.rankings = null;
    }
    //constructor relleno
    public Game(string name, Genres genres, List<Platforms> platformList, int releaseDate, Dictionary<Platforms, Ranking> dictionary)
    {
        this.name = name;
        this.genres = genres;
        this.listaPlatforms = platformList;
        this.releaseDate = releaseDate;
        this.rankings = dictionary;
    }

    //constructor cadena de datos para import
    public Game(string datos)
    {
        string[] splittedData = datos.Split('-');
        string[] splittedData2 = datos.Split(',');
        this.name = splittedData[0];
        this.genres = (Genres)int.Parse(splittedData[1]);
        this.releaseDate = int.Parse(splittedData[2]);
        this.listaPlatforms = Platforms;
    }
    #endregion
    //GETTERS Y SETTERS
    #region GettersSetters
    public Dictionary<Platforms, Ranking> Rankings
    {
        get { return rankings; }
    }


    public int ReleaseDate
    {
        get
        {
            //para controlar que la fecha de lanzamiento este comprendida entre 1980 y 2018
            if (releaseDate >= 1980 && releaseDate <= 2018)
            {
                return releaseDate;
            }
            else
            {
                Console.WriteLine("Fecha de lanzamiento incorrecta");
                return 0000;
            }
        }
    }


    public List<Platforms> Platforms
    {
        get { return listaPlatforms; }

    }

    public Genres Genres
    {
        //Consultable pero no modificable
        get { return genres; }

    }

    //Consultable pero no modificable
    public string Name
    {
        get { return name; }

    }
    #endregion


    //TOSTRING
    #region Tostring
    public override string ToString()
    {
        string s = "";

        //para controlar la cadena de plataformas
        string plataformas = "";
            foreach (Platforms plat1 in listaPlatforms)
            {
                    plataformas += plat1.ToString() + ",";
            }

        //para controar la cadena de rankings
        Ranking ranAux = new Ranking();
        foreach (Ranking ran in rankings.Values)
        {
            //TODO RANKINGS  4 y 5 por hacer  ranAux.Scores[].Points
            s = string.Format("--{0} ({1}) - {2} - {3}--\nRankings:\n-{4}({5})", Name, ReleaseDate, plataformas, Genres, ran.Name,ran.Scores.Count);

        }
        return s;
    }
    #endregion

    //TEST DE PRUEBA
    #region Test
    public static void Test()
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


        Ranking rank1 = new Ranking("Ranking1-Lis1", lis1);
        Ranking rank2 = new Ranking("Tanking-", lis2);

        Dictionary<Platforms, Ranking> dict1 = new Dictionary<global::Platforms, Ranking>();
        dict1.Add(global::Platforms.MAC, rank1);

        Dictionary<Platforms, Ranking> dict2 = new Dictionary<global::Platforms, Ranking>();
         dict2.Add(global::Platforms.PC, rank2);
       
        //dict2.Add(global::Platforms.XBOXONE, rank2);
        //dict2.Add(global::Platforms.Linux, rank1);
        Game g1 = new Game("NuevoJuego1istPlatDic1", Genres.Simulation, lisPlat, 2010, dict1);;
        Game g2 = new Game("JUEGONUMERO2", Genres.Desconocido, lisPlat2, 1980, dict2); ;

        Console.WriteLine(g1);
        Console.WriteLine(g2);

    }
    #endregion



}

