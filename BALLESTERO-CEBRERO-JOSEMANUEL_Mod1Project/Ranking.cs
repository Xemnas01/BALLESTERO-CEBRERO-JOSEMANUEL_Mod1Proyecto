using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Ranking 
{
    //MIEMBROS  
    #region Miembros
    private string name;
    private List<Score> scores;
    #endregion

    //CONSTRUCTORES
    #region Constructores
    //constructor vacio
    public Ranking()
    {
        this.name = "Deconocido";
        this.scores = null;
    }

    //constructor completo
    public Ranking(string name, List<Score> scores)
    {
        this.name = name;
        this.scores = scores;
    }


    #endregion

    //GETTERS Y SETTERS
    #region GettersSetters

    public List<Score> Scores
    {
        get { return scores; }
    }


    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    #endregion

    //TOSTRING
    #region Tostring
    public override string ToString()
    {
        //creo un contador para que lo vaya mostrando segun el numero que haya de puntuaciones en la ista
        int cont = 1;
        Console.WriteLine("Ranking:" + Name);
        //foreach que me recorre las puntuaciones(nombre y puntos) de la lista de puntuaciones
        foreach (Score score in scores)
        {
            //s = string.Format(cont + ".{0}-{1}\n", score.NickNameScore, score.Points);
            Console.WriteLine(string.Format(cont + ".{0}-{1}", score.NickNameScore, score.Points));
            cont++;
        }

        return "";
    }
    #endregion

    //TEST PARA PRUEBAS
    #region Test
    public static void TestRanking()
    {
       Score s1 = new Score("Chema", 8787);
       Score s2 = new Score("Juan", 121);
       Score s3 = new Score("Pepe", 67);
       
       List<Score> lis1 = new List<Score>();
       lis1.Add(s1);
       lis1.Add(s2);
       lis1.Add(s3);

        //prueba de que se añadian y se mostraba
        /* foreach (Score s in lis1)
         {
             Console.WriteLine(s);

         }*/
       
        Ranking ra1 = new Ranking("Ranking de Prueba", lis1);
       
        Console.WriteLine(ra1);
        
    }
    #endregion

}

