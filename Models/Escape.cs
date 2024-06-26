static class Escape
{
    private static string[] incognitasSalas {get; set;}
    private static bool[] salasEscapadas{get; set;}
    private static int estadoJuego = 1;
    
    private static void InicializarJuego()
    {
        incognitasSalas = new string[8] {"2", "Rombo", "Aleman", "55+5", "Intercambiar Caballos", "Prender cerilla", "Criada", "Ciego"};
        salasEscapadas = new bool[8]{false, false, false, false, false, false, false, false};
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

    public static bool ResolverSala(int Sala, string Incognita)
    {
        int SalaEstado;

        if (incognitasSalas != null)
        {
            if (incognitasSalas[Sala - 2] == Incognita)
            {
                SalaEstado = GetEstadoJuego();
                salasEscapadas[Sala] = true;


                estadoJuego++;
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