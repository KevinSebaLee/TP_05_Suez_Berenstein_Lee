static class Escape
{
    private static string[] incognitasSalas {get; set;}
    public static bool[] salasEscapadas{get; set;}

    public static RoomGraph Graph;
    public static int estadoJuego = 1;
    
    public static void InicializarJuego()
    {
        incognitasSalas = new string[8] {"2", "rombo", "Aleman", "55+5", "Intercambiar Caballos", "Prender cerilla", "Criada", "Ciego"};
        salasEscapadas = new bool[17]{false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false};

        Graph = new RoomGraph(17);

        Graph.AddConnection(1, 2); Graph.AddConnection(1, 3); Graph.AddConnection(1, 4);
        Graph.AddConnection(4, 5); Graph.AddConnection(4, 6);
        Graph.AddConnection(6, 7); Graph.AddConnection(6, 8); Graph.AddConnection(6, 9); Graph.AddConnection(6, 15);
        Graph.AddConnection(15, 10); Graph.AddConnection(15, 11); Graph.AddConnection(15, 12); Graph.AddConnection(15, 16); Graph.AddConnection(15, 14); Graph.AddConnection(15, 13);
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