using Proyecto_FITLAB.Models;

namespace Proyecto_FITLAB;// [ai-assisted]

internal class RepositorioAsistencia
{
    private string ruta = "Asistencia.txt";

    private static RepositorioAsistencia? _instancia;
    private RepositorioAsistencia() { }
    public static RepositorioAsistencia Instancia
    {
        get
        {
            if (_instancia == null) _instancia = new RepositorioAsistencia();
            return _instancia;
        }
    }

    public List<Asistencia> LeerArchivo()
    {
        List<Asistencia> listaAsistencia = new();

        if (File.Exists(ruta))
        {
            foreach (string linea in File.ReadLines(ruta))
            {
                string[] datosSeparados = linea.Split('|');

                if (datosSeparados.Length >= 3)// Si esta vacia no tendra 3 divisores, entonces continurara
                {
                    string idTemp = datosSeparados[0];
                    string fechaTemp = datosSeparados[1];

                    if (int.TryParse(idTemp, out int idValido) && Enum.TryParse<DateTime>(fechaTemp, true, out DateTime fechaValida))
                    {
                        listaAsistencia.Add(new Asistencia(idValido, fechaValida));
                    }
                    else
                    {
                        throw new Exception($"Error de fecha o ID invalido, al intentar cargar el archivo!");
                    }
                }

            }
        }

        return listaAsistencia;
    }

    public void EscribirArchivo(string asistencia)
    {
        File.AppendAllLines(ruta, new string[] { asistencia }); 
    }

    public void ReescribirArchivo(List<string> ListaAsistenciaes)
    {
        File.WriteAllLines(ruta, ListaAsistenciaes);
    }
}