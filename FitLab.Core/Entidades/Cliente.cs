using FitLab.Core.Enums; // Para usar Rol y TipoCliente
using FitLab.Core.Interfaces; // Para usar IIdentificador e IMostrar_datos

namespace FitLab.Core.Entidades;

public class Cliente : IIdentificador, IMostrar_datos
{
    public TipoCliente Tipo { get; }
    public string? nombre { get; private set; }
    public int edad { get; private set; }
    public Rol rol { get; private set; }

    static int proximo_id = 1;
    public int ID { get; private set; }

    // El descuento ya no se guarda: se calcula según el tipo del cliente
    public double descuento
    {
        get
        {
            switch (Tipo)
            {
                case TipoCliente.Regular: return 0;
                case TipoCliente.Estudiante: return 0.15;
                case TipoCliente.Premium: return -0.25;
                default: return 0;
            }
        }
    }

    public Membresias? Membresia_cliente { get; private set; } //  Aca estara el objeto completo de la membresia que haya escogido este cliente
    public List<DateTime> Asistencia { get; private set; } = new List<DateTime>();


    //**************
    // CONSTRUCTOR
    //**************
    public Cliente(TipoCliente tipo, string nombre, Rol rol, int edad)
    {
        Tipo = tipo;
        this.nombre = nombre;
        this.rol = rol;
        this.edad = edad;
        ID = proximo_id++;
    }

    public void asignar_membresia(Membresias membresia)
    {
        Membresia_cliente = membresia;
    }

    public void anotar_asistencia()
    {
        Asistencia.Add(DateTime.Now);
    }

    public void Mostrar_datos()
    {
        Console.WriteLine($@"Nombre: {nombre}
Edad: {edad}
ID: {ID}");
    }
}
