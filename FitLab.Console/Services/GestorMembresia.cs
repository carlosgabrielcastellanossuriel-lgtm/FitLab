using Proyecto_FITLAB.Patterns;

namespace Proyecto_FITLAB; // [ai-assisted]

internal class GestorMembresia 
{
    private static GestorMembresia _instancia;
    private List<Membresias>_listaMembresias = new();
    private GestorMembresia(){}

    public static GestorMembresia Instancia
    {
        get
        {
            if (_instancia == null) _instancia = new GestorMembresia();
            return _instancia;
        }
    }
    public Membresias GenerarMembresia(TipoMembresia tipo, Clientes cliente) // Crear una clase factory que haga esto
    {
        Membresias membresia = MembresiasFactory.CrearMembresia(tipo , cliente);

        _listaMembresias.Add(membresia);
        cliente.asignar_membresia(membresia);

        return membresia;
    }

    public Membresias ExisteMembresia(int id)
    {
        Membresias membresia = _listaMembresias.Find(m => m.ID == id);

        if (membresia == null) throw new ID_no_encontrado_exception("Membresia no encontrada");

        return membresia;
    }

    public List<Membresias> MembresiasActivas()
    {
        List<Membresias> ListaMembresiasActivas = _listaMembresias.FindAll(m => m.Estado == Estado_membresia.Activo).ToList();

        return ListaMembresiasActivas;
    }
}