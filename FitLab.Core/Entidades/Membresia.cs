using FitLab.Core.Enums; // Para usar TipoMembresia
using FitLab.Core.Interfaces; // Para usar IIdentificador e IMostrar_datos

namespace FitLab.Core.Entidades;
// [ai-assisted]
public enum Estado_membresia{
    Inactivo,
    Activo,
    Vencida,
    Cancelada
};

public class Membresia : IIdentificador, IMostrar_datos
{
    public TipoMembresia Tipo { get; }

    // La tarifa depende del tipo de membresía y del descuento del propietario
    public decimal tarifa
    {
        get
        {
            decimal tarifa_base;

            switch (Tipo)
            {
                case TipoMembresia.Mensual: tarifa_base = 1500m; break;
                case TipoMembresia.Trimestral: tarifa_base = 4000m; break;
                case TipoMembresia.Anual: tarifa_base = 14000m; break;
                default: tarifa_base = 0m; break;
            }

            return tarifa_base - (tarifa_base * descuento);
        }
    }

    public DateTime fecha_vencimiento { get; private set; }

    static int proximo_ID = 1;
    public int ID { get; private set; }
    public DateTime fecha_inicio { get; private set;}
    public DateTime fecha_creacion { get; private set; }
    public Estado_membresia Estado { get; private set; }
    public decimal descuento { get; private set;}
    public Cliente Propietario { get; private set; }

    //**************
    // CONSTRUCTOR
    //**************
    public Membresia(TipoMembresia tipo, Cliente cliente)
    {
        Tipo = tipo;

        ID = proximo_ID++;

        fecha_creacion = DateTime.Now;

        fecha_inicio = DateTime.Now;

        Estado = Estado_membresia.Inactivo;

        Propietario = cliente;

        descuento = cliente.descuento;

        // La primera fecha de vencimiento depende del tipo de membresía
        switch (Tipo)
        {
            case TipoMembresia.Mensual: fecha_vencimiento = fecha_inicio.AddMonths(1); break;
            case TipoMembresia.Trimestral: fecha_vencimiento = fecha_inicio.AddMonths(3); break;
            case TipoMembresia.Anual: fecha_vencimiento = fecha_inicio.AddYears(1); break;
            default: fecha_vencimiento = fecha_inicio; break;
        }
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

    public void Renovar_membresia()
    {
        Actualizar_fecha_inicio(fecha_vencimiento);

        // La nueva fecha de vencimiento se calcula desde la fecha de vencimiento anterior
        switch (Tipo)
        {
            case TipoMembresia.Mensual: Actualizar_fecha_vencimiento(fecha_vencimiento.AddMonths(1)); break;
            case TipoMembresia.Trimestral: Actualizar_fecha_vencimiento(fecha_vencimiento.AddMonths(3)); break;
            case TipoMembresia.Anual: Actualizar_fecha_vencimiento(fecha_vencimiento.AddYears(1)); break;
        }
    }
}
