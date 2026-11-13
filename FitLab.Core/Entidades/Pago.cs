using FitLab.Core.Interfaces; // Para usar IIdentificador e IMostrar_datos

namespace FitLab.Core.Entidades;

public class Pago : IIdentificador, IMostrar_datos
{
    static int proximo_ID = 1;
    public Membresia membresia { get; private set;}
    public int ID { get; private set; }
    public DateTime Fecha { get; private set;}
    public decimal monto_pagado { get; private set;}
    
    //**************
    // CONSTRUCTOR
    //**************
    public Pago(Membresia membresia)
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
