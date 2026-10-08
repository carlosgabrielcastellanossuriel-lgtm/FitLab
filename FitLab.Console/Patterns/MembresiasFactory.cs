namespace Proyecto_FITLAB.Patterns;

internal static class MembresiasFactory 
{
    public static Membresias CrearMembresia(TipoMembresia tipo, Clientes cliente)
    {
        switch (tipo)
        {
            case TipoMembresia.Mensual: return new MembresiaMensualFactory().CrearMembresia(cliente);

            case TipoMembresia.Trimestral: return new MembresiaTrimestralFactory().CrearMembresia(cliente);

            case TipoMembresia.Anual: return new MembresiaAnualFactory().CrearMembresia(cliente); 

            default: throw new Exception("Tipo de membresia no valido!");
        }
    }
}