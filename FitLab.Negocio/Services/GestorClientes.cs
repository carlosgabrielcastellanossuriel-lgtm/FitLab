namespace FitLab.Negocio; // [ai-assisted]
public class GestorClientes
{
    private static GestorClientes _instancia;
    private List<Cliente> _listaClientes = new List<Cliente>();

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

    public Cliente RegistrarCliente(TipoCliente tipoCliente, string nombre, Rol rol, int edad)
    {
        Cliente cliente = new Cliente(tipoCliente, nombre, rol, edad);

        _listaClientes.Add(cliente);

        return cliente;
    }

    public Cliente ClienteExiste(int id)
    {
        Cliente cliente = _listaClientes.Find(cliente => cliente.ID == id);

        if (cliente == null) throw new ID_no_encontrado_exception("Cliente no encontrado");

        return cliente;
    }

    public List<Cliente> ClientesRegistrados()
    {
        return new List<Cliente>(_listaClientes);
    }
}