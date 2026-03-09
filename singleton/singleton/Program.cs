using System;

public class Central_911
{
    private static Central_911 _instance;
    private static readonly object _lock = new object();

    public string Central { get; private set; }

    private Central_911()
    {
        Central = "Central 911";
    }

    public static Central_911 Obtener_Instancia()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Central_911();
                }
            }
        }
        return _instance;
    }

    public void ConectarLlamada(Operador operador, string tipoEmergencia)
    {
        Console.WriteLine("\nLlamada conectada con el operador " + operador.Nombre);
        operador.AtiendeEmergencia(tipoEmergencia);
    }
}

public class Operador
{
    public int Id_Operador { get; set; }
    public string Nombre { get; set; }

    public Operador(int id, string nombre)
    {
        Id_Operador = id;
        Nombre = nombre;
    }

    public void AtiendeEmergencia(string tipoEmergencia)
    {
        Console.WriteLine($"Operador {Nombre} atendiendo emergencia de tipo: {tipoEmergencia}");

        switch (tipoEmergencia)
        {
            case "Intento de suicidio":
                Console.WriteLine("Enviando unidades de apoyo y rescate");
                break;
            case "Incendio":
                Console.WriteLine("Enviando bomberos");
                break;
            case "Accidente":
                Console.WriteLine("Enviando paramedicos y oficiales");
                break;
            case "Violencia":
                Console.WriteLine("Enviando patrulla policial");
                break;
            case "Robo":
                Console.WriteLine("Enviando unidad policial inmediata");
                break;
            default:
                Console.WriteLine("Tipo de emergencia no reconocido.");
                break;
        }
    }
}

internal class Program
{
    static void Main(string[] args)
    {
        Central_911 central1 = Central_911.Obtener_Instancia();
        Central_911 central2 = Central_911.Obtener_Instancia();

        Operador op1 = new Operador(1, "Laura");
        Operador op2 = new Operador(2, "Carlos");
        Operador op3 = new Operador(3, "Ana");
        Operador op4 = new Operador(4, "Miguel");

        central1.ConectarLlamada(op1, "Incendio");
        central2.ConectarLlamada(op2, "Accidente");
        central1.ConectarLlamada(op3, "Robo");
        central2.ConectarLlamada(op4, "Violencia");
        central1.ConectarLlamada(op1, "Intento de suicidio");
        central2.ConectarLlamada(op2, "Incendio");

        Console.WriteLine("\nVerificando si es la misma instancia:");
        Console.WriteLine("ReferenceEquals: " + ReferenceEquals(central1, central2));

        Console.ReadKey();
    }
}