using Proyecto_FITLAB.Models;

namespace Proyecto_FITLAB; // [ai-assisted]
public class GestorAsistencia
{
    private static GestorAsistencia _instancia;

    private List<Asistencia> _listaAsistencias = new List<Asistencia>();

    private GestorAsistencia()
    {
        _listaAsistencias = RepositorioAsistencia.Instancia.LeerArchivo();
    }

    public static GestorAsistencia Instancia
    {
        get
        {
            if (_instancia == null) _instancia = new GestorAsistencia();
            return _instancia;
        }
    }


    //*********
    // METOODOS
    //*********
    public void RegistrarAsitencia(int id)
    {
        Asistencia nuevaAsistencia = new Asistencia(id); // Se crea una nueva asistencia

        _listaAsistencias.Add(nuevaAsistencia); // Se agrega a la lista esa seccion

        // Y LUEGO SE PASA AL ARCHIVO

        string asistenciaString = $"{nuevaAsistencia.IdCliente} | {nuevaAsistencia.fecha}";// Modificamos como queremos escribirlo en el archivo. 

        RepositorioAsistencia.Instancia.EscribirArchivo(asistenciaString);
    }

    public List<Asistencia> ObtenerCantidadAsistencias()
    {
        return new List<Asistencia>(_listaAsistencias); // Devuelve una copia de nuestra lista original, pero con los mismos elementos
    }


    public List<Asistencia> HistorialAsistencias()
    {
        return new List<Asistencia>(_listaAsistencias);
    }

    public List<Asistencia> BuscadorAsistencia(int idBuscado)
    {
        List<Asistencia> ListaAsistencias = _listaAsistencias.FindAll(a => a.IdCliente == idBuscado).ToList();// Busca todos los objetos asistencias que tengan ese idBuscado

        return ListaAsistencias;
    }
}