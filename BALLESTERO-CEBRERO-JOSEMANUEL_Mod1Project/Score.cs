using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Hago que herede de player para usar su nickname y asociarlo a una puntuacion
public class Score
{
    //MIEMBROS
    #region Miembros
    private string nickName;
    private int points;
    #endregion

    //CONSTRUCTORES
    #region Constructores
    //constructor vacio
    public Score()
    {
        this.nickName = "Desconocido";
        this.points = 0;
    }
    //constructor relleno
    public Score(string nickName, int points)
    {
        this.nickName = nickName;
        this.points = points;
    }
    #endregion
    //GETTERS Y SETTERS
    #region GettersSetters
    public int Points
    {
        get
        {
            if (this.points >= 0)
            {
               
                return points;
            }
            else
            {
                Console.WriteLine("El valor introducido no es correcto");
                return 0;
            }

        }
        set
        {
            if (this.points >= 0)
            {
                Console.WriteLine("Puntos modificados");
                points = value;
            }
            else
            {
                points = 0;
            }

        }
    }
    public string NickNameScore
    {
        get { return this.nickName; }
    }
    #endregion

    //Mostrar Puntuacion
    #region MuestraPuntuacio
    //por si tiene que heredar game u otro la forma
    //public virtual void PrintScore()
    //{
    //    Console.WriteLine(string.Format("{0}-{1}", NickNameScore, Points)); 
    //}
    public override string ToString()
    {
        return string.Format("{0}-{1}", NickNameScore, Points);
    }
    #endregion

    //TEST PARA PRUEBAS
    #region Test
    public static void TestScore()
    {
        Score s1 = new Score("Chema", 234242424);
        Score s2 = new Score("laosdk", 456456);
        Score s3 = new Score("casdjasdk", 45645);
        Score s4 = new Score("chema", 46545);

        s2.points = 454;
        Console.WriteLine(s2);
        s2.points = 734564;
        Console.WriteLine(s2);

    }
    #endregion



}



