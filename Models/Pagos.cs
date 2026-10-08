namespace Proyecto_FITLAB;

public class Pagos : IIdentificador, IMostrar_datos
{
    static int proximo_ID = 1;
    public Membresias membresia { get; private set;}
    public int ID { get; private set; }
    public DateTime Fecha { get; private set;}
    public double monto_pagado { get; private set;}
    
    //**************
    // CONSTRUCTOR
    //**************
    public Pagos(Membresias membresia)
    {
        this.membresia = membresia;

        Fecha = DateTime.Now;

        monto_pagado = membresia.tarifa;

        ID = proximo_ID++;

        if (membresia.Estado != Estado_membresia.Activo) membresia.Cambiar_estado(Estado_membresia.Activo); // La membresia estara activa solo cuando se pague 

        membresia.Renovar_membresia();
    }

    public void Mostrar_datos()
    {
        Console.WriteLine(@$"ID pago: {ID}
Monto pagado: ${monto_pagado}
Fecha: {Fecha}");
    }
}
