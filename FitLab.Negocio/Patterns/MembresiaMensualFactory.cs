namespace FitLab.Negocio;

internal class MembresiaMensualFactory : IMembresiaFactory
{
    public Membresias CrearMembresia(Cliente cliente)
    {
        return new Membresia_mensual(cliente);
    }
}
