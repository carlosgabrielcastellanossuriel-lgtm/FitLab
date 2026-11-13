namespace FitLab.Negocio;

internal class MembresiaTrimestralFactory : IMembresiaFactory
{
    public Membresias CrearMembresia(Clientes cliente)
    {
        return new Membresia_trimestral(cliente);
    }
}
