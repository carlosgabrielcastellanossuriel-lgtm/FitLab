
namespace FitLab.Negocio; // [ai-assisted]

internal class GestorMembresia 
{
    private static GestorMembresia _instancia;
    private List<Membresia>_listaMembresias = new();
    private GestorMembresia(){}

    public static GestorMembresia Instancia
    {
        get
        {
            if (_instancia == null) _instancia = new GestorMembresia();
            return _instancia;
        }
    }
    public Membresia GenerarMembresia(TipoMembresia tipo, Cliente cliente)
    {
        Membresia membresia = new Membresia(tipo, cliente);

        _listaMembresias.Add(membresia);
        cliente.asignar_membresia(membresia);

        return membresia;
    }

    public Membresia ExisteMembresia(int id)
    {
        Membresia membresia = _listaMembresias.Find(m => m.ID == id);

        if (membresia == null) throw new ID_no_encontrado_exception("Membresia no encontrada");

        return membresia;
    }

    public List<Membresia> MembresiasActivas()
    {
        List<Membresia> ListaMembresiasActivas = _listaMembresias.FindAll(m => m.Estado == Estado_membresia.Activo).ToList();

        return ListaMembresiasActivas;
    }
}