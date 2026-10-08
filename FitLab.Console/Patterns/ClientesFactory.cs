namespace Proyecto_FITLAB; // Aca aplicamos factory simple, para centralizar los new y usar el polimorfismo
internal static class ClientesFactory
{
    public static Clientes CrearClientes(TipoClientes tipo, string nombre, Rol rol, int edad)
    {
        switch (tipo)
        {
            case TipoClientes.Regular: return new Regulares(nombre, rol, edad);
            
            case TipoClientes.Estudiante: return new Estudiantes(nombre, rol, edad);
            
            case TipoClientes.Premium: return new Premium(nombre, rol, edad);

            default: throw new Exception("Tipo de cliente no valido!");
        }
    }
}
