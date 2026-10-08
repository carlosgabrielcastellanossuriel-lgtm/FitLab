namespace Proyecto_FITLAB; // [ai-assisted]
public class GestorClientes
{
    private static GestorClientes _instancia;
    private List<Clientes> _listaClientes = new List<Clientes>();

    private GestorClientes(){}

    public static GestorClientes Instancia
    {
        get
        {
            if (_instancia == null) _instancia = new GestorClientes();
            return _instancia;
        }
    }

    //*********
    // METOODOS
    //*********

    public Clientes RegistrarCliente(TipoClientes tipoCliente, string nombre, Rol rol, int edad)
    {
        Clientes cliente = ClientesFactory.CrearClientes(tipoCliente, nombre, rol, edad);

        _listaClientes.Add(cliente);

        return cliente;
    }

    public Clientes ClienteExiste(int id)
    {
        Clientes cliente = _listaClientes.Find(cliente => cliente.ID == id);

        if (cliente == null) throw new ID_no_encontrado_exception("Cliente no encontrado");

        return cliente;
    }

    public List<Clientes> ClientesRegistrados()
    {
        return new List<Clientes>(_listaClientes);
    }
}