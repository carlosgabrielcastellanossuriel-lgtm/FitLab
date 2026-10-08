namespace Proyecto_FITLAB;
public abstract class Clientes : IIdentificador, IMostrar_datos
{
    public string? nombre { get; private set; }
    public int edad { get; private set; }
    public Rol rol { get; private set; }

    static int proximo_id = 1;
    public int ID { get; private set; }
    virtual public double descuento { get; protected set; }
    public Membresias? Membresia_cliente { get; private set; } //  Aca estara el objeto completo de la membresia que haya escogido este cliente
    public List<DateTime> Asistencia { get; private set; } = new List<DateTime>();


    //**************
    // CONSTRUCTOR
    //**************
    public Clientes(string nombre, Rol rol, int edad)
    {
        this.nombre = nombre;
        this.rol = rol;
        this.edad = edad;
        ID = proximo_id++;
        descuento = 0;
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

public class Regulares : Clientes
{
    override public double descuento { get; protected set; }

    public Regulares(string nombre, Rol rol, int edad) : base(nombre, rol, edad)
    {
        descuento = 0;
    }
}

public class Estudiantes : Clientes
{

    override public double descuento { get; protected set; }
    public Estudiantes(string nombre, Rol rol, int edad) : base(nombre, rol, edad)// base le pasa los argumentos que necesita el constructor padre
    {
        descuento = 0.15;
    }
}

public class Premium : Clientes
{

    override public double descuento { get; protected set; }

    public Premium(string nombre, Rol rol, int edad) : base(nombre, rol, edad)
    {
        descuento = -0.25;
    }
}