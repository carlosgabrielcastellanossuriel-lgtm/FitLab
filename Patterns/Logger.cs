namespace Proyecto_FITLAB; // [ai-assisted]

public class Logger
{
    private static Logger? _instancia;
    private string rutaLog = "Eventos_FITLAB.txt";

    private Logger() { }

    public static Logger Instancia
    {
        get
        {
            if (_instancia == null) _instancia = new Logger();
            return _instancia;
        }
    }

    public void RegistrarEvento(string mensaje)
    {
        string registro = $"[{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}] - {mensaje}\n";

        File.AppendAllText(rutaLog, registro);
    }
}