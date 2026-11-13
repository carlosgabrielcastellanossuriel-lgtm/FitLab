namespace Proyecto_FITLAB;
// [ai-assisted]
public enum Estado_membresia{
    Inactivo,
    Activo,
    Vencida,
    Cancelada
};

abstract public class Membresias : IIdentificador, IMostrar_datos// las clases hijas heredan los contratos tambien
{
    public abstract double tarifa { get; }
    public abstract DateTime fecha_vencimiento { get; protected set; }// si pongo private set en este caso, luego no podria escribirlo en las clases hijas

    static int proximo_ID = 1;
    public int ID { get; private set; }
    public DateTime fecha_inicio { get; private set;}
    public DateTime fecha_creacion { get; private set; }
    public Estado_membresia Estado { get; private set; }
    public double descuento { get; private set;}
    public Clientes Propietario { get; private set; }

    //**************
    // CONSTRUCTOR
    //**************
    protected Membresias(Clientes cliente) // protected permite que se herede el constructor pero que no se pueda inicializar desde afuera
    {
        ID = proximo_ID++;

        fecha_creacion = DateTime.Now;

        fecha_inicio = DateTime.Now;

        Estado = Estado_membresia.Inactivo;

        Propietario = cliente;

        descuento = cliente.descuento;
    }

    public void Cambiar_estado(Estado_membresia nuevo_estado)
    {
        Estado = nuevo_estado;
    }

    public void Mostrar_datos()
    {
        Console.WriteLine($@"ID membresia: {ID}
Estado: {Estado}
Fecha de creacion: {fecha_creacion.ToShortDateString()}");
}

    public void Actualizar_fecha_vencimiento(DateTime fecha_actualizada)
    {
        fecha_vencimiento = fecha_actualizada;
    }

    public void Actualizar_fecha_inicio(DateTime fecha_actualizada)
    {
        fecha_inicio = fecha_actualizada;
    }
    abstract public void Renovar_membresia();
}

public class Membresia_mensual : Membresias
{
    override public double tarifa { get { return 1500 - (1500 * descuento);  } } // NO creamos set porque esto no se deberia de editar, lo ponemos afuera del constructor porque asi luego podria cambiar el monto. si lo dejo en el constructor se crea y se queda asi para siempre 
    override public DateTime fecha_vencimiento { get; protected set; }

    //*************
    // CONSTRUCTOR
    //*************
    public Membresia_mensual(Clientes cliente) : base (cliente)
    {
        fecha_vencimiento = fecha_inicio.AddMonths(1);
    }
    override public void Renovar_membresia() {
        Actualizar_fecha_inicio(fecha_vencimiento);

        Actualizar_fecha_vencimiento(fecha_vencimiento.AddMonths(1));
    }
}

public class Membresia_trimestral: Membresias
{
    override public double tarifa { get { return 4000 - (4000 * descuento); } }
    override public DateTime fecha_vencimiento { get; protected set; }

    //**************
    // CONSTRUCTOR
    //**************
    public Membresia_trimestral(Clientes cliente) : base (cliente)
    {
        fecha_vencimiento = fecha_inicio.AddMonths(3);
    }
    override public void Renovar_membresia()
    {
        Actualizar_fecha_inicio(fecha_vencimiento);

        Actualizar_fecha_vencimiento(fecha_vencimiento.AddMonths(3));
    }
}

public class Membresia_anual : Membresias
{
    override public double tarifa { get { return 14000 - (14000 * descuento); } }
    override public DateTime fecha_vencimiento { get; protected set; }

    //**************
    // CONSTRUCTOR
    //**************
    public Membresia_anual(Clientes cliente) : base(cliente)
    {
        fecha_vencimiento = fecha_inicio.AddYears(1);
    }

    override public void Renovar_membresia()
    {
        Actualizar_fecha_inicio(fecha_vencimiento);

        Actualizar_fecha_vencimiento(fecha_vencimiento.AddYears(1));
    }
}