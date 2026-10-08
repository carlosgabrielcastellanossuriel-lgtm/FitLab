using Proyecto_FITLAB.Models;
using Proyecto_FITLAB.Services;

namespace Proyecto_FITLAB; // [ai-assisted]

// Para explorar diferentes opciones y definiciones de terminos utilice la IA en esta clase.
public static class Gestor 
{
    //**********
    // METODOS
    //***********

    // OPCION 1
    public static int Registrar_cliente(TipoClientes tipoCliente, TipoMembresia tipoMembresia, string nombre, Rol rol, int edad)
    {
        Clientes cliente = GestorClientes.Instancia.RegistrarCliente(tipoCliente, nombre, rol, edad);

        Membresias membresia = GestorMembresia.Instancia.GenerarMembresia(tipoMembresia, cliente); Logger.Instancia.RegistrarEvento($"NUEVO CLIENTE: {nombre} con membresia {tipoMembresia} y ID: {membresia.ID}.");

        return cliente.ID;
    }

    // OPCION 2

    public static Membresias ExisteMembresia(int id)
    {
        return GestorMembresia.Instancia.ExisteMembresia(id);
    }

    public static void AgregarPago(Membresias membresia)
    {
        Pagos pago = GestorPagos.Instancia.CrearPago(membresia); Logger.Instancia.RegistrarEvento($"NUEVO PAGO. ID: {pago.ID}.");
    }

    // OPCION 3
    public static string Registrar_asistencia(int id)
    {
        Clientes cliente = GestorClientes.Instancia.ClienteExiste(id);// Si el cliente no existe lanzara la excepcion de id no encontrado antes de tratar de buscarlo en una asistencia

        GestorAsistencia.Instancia.RegistrarAsitencia(id);

        return cliente.nombre;
    }


    // OPCION 4

    public static List<Asistencia> HistorialAsistencias()
    {
        return GestorAsistencia.Instancia.HistorialAsistencias();
    }


    // OPCION 5
    public static List<Asistencia> BuscadorAsistencias(int id)
    {
        GestorClientes.Instancia.ClienteExiste(id);

        return  GestorAsistencia.Instancia.BuscadorAsistencia(id);
    }


    // OPCION 6
    public static List<Membresias> MembresiasActivas()
    {
        return GestorMembresia.Instancia.MembresiasActivas();
    }

    // OPCION 7
    public static List<Clientes> ClientesRegistrados()
    {
        return GestorClientes.Instancia.ClientesRegistrados();
    }

    // OPCION 8

    public static List<Sesion> Obtener_sesiones_activas()
    {
        return GestorSesion.Instancia.Obtener_sesiones_activas();
    }


    public static int Cantidad_sesiones_activas()
    {
        return GestorSesion.Instancia.Cantidad_sesiones_activas();
    }

    // OPCION 9
    public static string BuscadorSesion(int id)
    {
        GestorClientes.Instancia.ClienteExiste(id);

        return GestorSesion.Instancia.BuscadorSesion(id);
    }


    // OPCION 10
    public static string Cerrar_sesion(int id)
    {
        Clientes cliente = GestorClientes.Instancia.ClienteExiste(id);

        GestorSesion.Instancia.CerrarSesion(cliente.ID);

        return cliente.nombre;
    }

    // OPCION 11
    public static double Ingresos_mes(int anio, int mes)
    {
        return GestorPagos.Instancia.Ingresos_mes(anio, mes);
    }
}