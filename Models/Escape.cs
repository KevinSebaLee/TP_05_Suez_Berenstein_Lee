static class Escape
{
    private static string[] incognitasSalas {get; set;}
    private static bool[] salasEscapadas{get; set;}
    public static int estadoJuego = 1;
    
    public static void InicializarJuego()
    {
        incognitasSalas = new string[8] {"2", "Rombo", "Aleman", "55+5", "Intercambiar Caballos", "Prender cerilla", "Criada", "Ciego"};
        salasEscapadas = new bool[15]{false, false, false, false, false, false, false, false, false, false, false, false, false, false, false};
    }

    public static int GetEstadoJuego()
    {
        int siEscapo = estadoJuego;

        return siEscapo;
    }

    public static bool TerminoSala()
    {
        if(GetEstadoJuego() == incognitasSalas.Count()){
            return true;
        }
        else{
            return false;
        }
    }

    public static bool ResolverSala(string Incognita)
    {
        int SalaEstado;

        Console.WriteLine(incognitasSalas[GetEstadoJuego() - 1]);

        if (incognitasSalas != null)
        {
            if (incognitasSalas[GetEstadoJuego() - 1] == Incognita)
            {
                Console.WriteLine(GetEstadoJuego());

                SalaEstado = GetEstadoJuego();
                salasEscapadas[SalaEstado] = true;

                return true;
            }
            else
                return false;
        }
        else
        {
            InicializarJuego();

            return false;
        }
    }
}