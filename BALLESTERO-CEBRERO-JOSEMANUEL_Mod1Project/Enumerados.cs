#region Enumerado
//creo lo tipos enumerados con su referencia en tipo int
//siempre añado al valor 0 desconocido por si en algun caso fuera necesario (pruebas)
//tipo Countries
public enum Countries
{
    Desconocido = 0,
    Spain = 1,
    France = 2,
    USA = 3,
    UnitedKingdom = 4,
    Japan = 5,
    Italy = 7,
    Brazil = 8,
    Germany = 9,
    Australia = 10,
    Canada = 11,
}
    //tipo Genres
public enum Genres
{
    Desconocido = 0,
    Action = 1,
    Strategy = 2,
    RPG = 3,
    Puzzles = 4,
    Adventure = 5,
    Simulation = 6,
    SurvivalHorror = 7,
    Sandbox = 8

}
//tipo Platforms
public enum Platforms
{
    Desconocido = 0,
    PC = 1,
    MAC = 2,
    Linux = 3,
    PS4 = 4,
    XBOXONE = 5
}
#endregion
