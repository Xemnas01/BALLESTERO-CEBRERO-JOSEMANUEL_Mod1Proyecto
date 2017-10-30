using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Player
{
    //MIEMBROS
    #region Miembros
    //creo los miembros de la clase playes
    public string nickNamePlayer;
    public string email;
    //del tipo enumerado Countries
    public Countries countries;

    #endregion

    //CONSTRUCTORES
    #region Contructores
    //contructor por defecto
    public Player()
    {
        this.nickNamePlayer = "Desconocido";
        this.email = "Desconocido";
        this.countries = 0;
    }
    //constructor relleno
    public Player(string nickNamePlayer, string email, Countries countries)
    {
        this.nickNamePlayer = nickNamePlayer;
        this.email = email;
        this.countries = countries;
    }

    //constructor mediante cadena de datos para el import
    public Player(string datos)
    {
        string[] splittedData = datos.Split('-');
        this.nickNamePlayer = splittedData[0];
        this.email = splittedData[1];
        this.countries =(Countries) int.Parse(splittedData[2]);
    }

    #endregion

    //GETTERSYSETTERS
    #region GettersSetters
    public Countries Countries
    {
        get { return countries; }
        set { countries = value; }
    }



    public string Email
    {
        get { return email; }
        set { email = value; }
    }


    public string NickNamePlayer
    {
        get { return nickNamePlayer; }
    }
    #endregion

    //TOSTRING
    #region Tostring
    public override string ToString()
    {
        //cambiar el tipo de fuente "cursiva"
        return string.Format("{0}-{1}-{2}", NickNamePlayer, Email, Countries);
    }
    #endregion

    //CRITERIO DE IGUALAD
    #region CriterioIgualdad
    public bool SonIguales(Player player)
    {

        bool reto = false;


        if (player.nickNamePlayer == this.nickNamePlayer)
        {
            Console.WriteLine("Ambos jugadores son iguales");
            reto = true;
        }
        else
        {
            Console.WriteLine("Ambos jugadores son diferentes");
        }
        return reto;
    }
    #endregion

    //TEST PARA PRUEBAS
    #region Test
    public static void Test()
    {
        //Comprobaciones
        #region comprobaciones
        //comprobacion funcon SonIguales
        Player p1 = new Player("asdoa", "asjasidjasd", Countries.Canada);
        // Player p2 = new Player("chema", "spdokaspodk@asodkaspo.com", Countries.Canada);
        // Player p3 = new Player("askjhd", "spdokaspodk@asodkaspo.com", Countries.Canada);
        // Player p4 = new Player("qweqwr", "spdokaspodk@asodkaspo.com", Countries.Canada);
        // Player p5 = new Player("vxcvxc", "spdokaspodk@asodkaspo.com", Countries.Canada);
        // Player p6 = new Player("chema", "spdokaspodk@asodkaspo.com", Countries.Canada);
        // p2.SonIguales(p1);
        // p1.SonIguales(p4);
        // p2.SonIguales(p6);
        //Console.WriteLine(p5);
        //Console.WriteLine(p6);
        //Console.WriteLine(p1);
        //Console.WriteLine(p3);
        #endregion
    }
    #endregion

}

