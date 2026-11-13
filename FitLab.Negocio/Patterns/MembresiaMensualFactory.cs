namespace FitLab.Negocio;

internal class MembresiaMensualFactory : IMembresiaFactory
{
    public Membresias CrearMembresia(Clientes cliente)
    {
        return new Membresia_mensual(cliente);
    }
}
