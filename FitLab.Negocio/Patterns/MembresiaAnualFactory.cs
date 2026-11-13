namespace FitLab.Negocio;

internal class MembresiaAnualFactory : IMembresiaFactory
{
    public Membresias CrearMembresia(Cliente cliente)
    {
        return new Membresia_anual(cliente);
    }
}