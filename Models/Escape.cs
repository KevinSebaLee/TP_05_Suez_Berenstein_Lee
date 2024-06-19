static class Escape
{
    private static string[] incognitasSalas;

    private static int estadoJuego = 1;


    private static void InicializarJuego()
    {

    }

    public static int GetEstadoJuego()
    {
        int siEscapo = estadoJuego;

        return siEscapo;
    }

    private static bool ResolverSala(int Sala, string Incognita)
    {
        int SalaEstado;

        if (incognitasSalas != null)
        {
            if (incognitasSalas[Sala - 2] == Incognita)
            {
                SalaEstado = GetEstadoJuego();

                estadoJuego++;

                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            InicializarJuego();

            return false;
        }
    }
}