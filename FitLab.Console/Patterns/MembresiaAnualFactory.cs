namespace Proyecto_FITLAB;

internal class MembresiaAnualFactory : IMembresiaFactory
{
    public Membresias CrearMembresia(Clientes cliente)
    {
        return new Membresia_anual(cliente);
    }
}