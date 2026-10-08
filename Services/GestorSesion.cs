namespace Proyecto_FITLAB; // [ai-assisted]
public class GestorSesion
{
    private static GestorSesion _instancia;
    private List<Sesion> _listaSesiones = new List<Sesion>();

    private GestorSesion()
    {
        _listaSesiones = RepositorioSesiones.Instancia.LeerArchivo();
    }

    public static GestorSesion Instancia{
        get
        {
            if (_instancia == null) _instancia = new GestorSesion();
            return _instancia;
        }
    }

    //*********
    // METOODOS
    //*********

    public void IniciarSesion(string nombre, int id, Rol rol)
    {
        Sesion nueva_sesion = new Sesion(nombre, id, rol); // Se crea una nueva sesion

        _listaSesiones.Add(nueva_sesion); // Se agrega a la lista esa seccion

        // Y LUEGO SE PASA AL ARCHIVO

        string sesion_string = $"{nueva_sesion.Nombre} | {nueva_sesion.idUsuario} | {nueva_sesion.rol}";// Modificamos como queremos escribirlo en el archivo. 

        RepositorioSesiones.Instancia.EscribirArchivo(sesion_string);
    }

    public void CerrarSesion(int idBuscado)
    {
        Sesion sesionCerrar = _listaSesiones.FirstOrDefault(s => s.idUsuario == idBuscado);//  Esto recorre la lista itereando los elementos 's' y devuelve el objeto con la primera conicidencia entre el IdUsuario de la sesion y id buscado sino encuentra nada devuelve null que es el default de los objetos

        if (sesionCerrar != null)
        {
            _listaSesiones.Remove(sesionCerrar);// Remove a diferencia de removeat pide un objeto, lo busca y lo elimina

            List<string> ListaSesionString = new List<string>();

            foreach (Sesion sesion in _listaSesiones)
            {
                ListaSesionString.Add($"{sesion.Nombre} | {sesion.idUsuario} | {sesion.rol}");// el salto de linea no es necesario ya que AppendAllLines y write all liens lo hace automatico 
            }

            RepositorioSesiones.Instancia.ReescribirArchivo(ListaSesionString);// Reescribimos el archivo con esa lista nueva

        }

        else throw new Exception("El cliente no esta logueado!");
    }

    public List<Sesion> Obtener_sesiones_activas()
    {
        return new List<Sesion>(_listaSesiones); // Devuelve una copia de nuestra lista original, pero con los mismos elementos
    }

    public int Cantidad_sesiones_activas()
    {
        return _listaSesiones.Count();
    }

    public string BuscadorSesion(int idCliente)
    {
        foreach (Sesion sesion in _listaSesiones)
        {
            if (idCliente == sesion.idUsuario) return $"La sesion de {sesion.Nombre} se encuentra activa!";
        }
        return $"La sesion no se encuentra activa!";
    }
}