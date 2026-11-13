namespace Proyecto_FITLAB;
public class Sesion 
{
    public string? Nombre { get; }

    public int idUsuario { get; }
    public Rol? rol { get; }
    public DateTime Inicio_sesion { get; }

    public Sesion(string nombre, int idUsuario,  Rol rol)
    {
        Nombre = nombre;

        this.idUsuario = idUsuario;

        this.rol = rol;

        Inicio_sesion = DateTime.Now;
    }
}
