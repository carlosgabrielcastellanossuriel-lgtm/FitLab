namespace Proyecto_FITLAB.Models;

public class Asistencia
{
    public DateTime fecha {get;}

    public int IdCliente { get; }

    public Asistencia(int idCliente)
    {
        fecha = DateTime.Now;

        this.IdCliente = idCliente;
    }

    public Asistencia(int idCliente, DateTime fechaLeidaArchivo)
    {
        fecha = fechaLeidaArchivo;

        IdCliente = idCliente;
    }

    public override string ToString()
    {
        return $"ID: {IdCliente} || {fecha}";
    }
}
