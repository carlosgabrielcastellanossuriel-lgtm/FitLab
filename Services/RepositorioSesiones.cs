namespace Proyecto_FITLAB;// [ai-assisted]

internal class RepositorioSesiones
{
    private string ruta = "Sesiones.txt";

    private static RepositorioSesiones? _instancia;
    private RepositorioSesiones() { }
    public static RepositorioSesiones Instancia
    {
        get
        {
            if (_instancia == null) _instancia = new RepositorioSesiones();
            return _instancia;
        }
    }

    public List<Sesion> LeerArchivo()
    {
        List<Sesion> listaSesion = new();

        if (File.Exists(ruta))
        {
            foreach (string linea in File.ReadLines(ruta))
            {
                string[] datosSeparados = linea.Split('|');

                if (datosSeparados.Length >= 3)// Si esta vacia no tendra 3 divisores, entonces continurara
                {
                    string nombre = datosSeparados[0];
                    string idTemp = datosSeparados[1];
                    string rolTemp = datosSeparados[2];

                    if (int.TryParse(idTemp, out int idValido) && Enum.TryParse<Rol>(rolTemp, true, out Rol rolValido))// Si las dos conversiones funcionan entra al bloque. el true indica que no importa que sea minuscula o mayuscula
                    {
                        // Si la conversión fue exitosa, 'rolValido' ya tiene el Enum listo y se agrega a la lista
                        listaSesion.Add(new Sesion(nombre, idValido, rolValido));
                    }
                    else
                    {
                        throw new Exception($"Error de rol o ID invalido de {nombre}, al intentar cargar el archivo!");
                    }
                }

            }
        }

        return listaSesion;
    }

    public void EscribirArchivo(string sesion)
    {
        File.AppendAllLines(ruta, new string[] { sesion });// Aca basicamente creamos un arreglo de strings que tiene directamente solo el elemento string sesion que le pasamos. Esto lo hacemos porque appendAllLines solo recibe conjunto de strins igual que writeAllLines. 
    }

    public void ReescribirArchivo(List<string> ListaSesiones)
    {
        File.WriteAllLines(ruta, ListaSesiones);// WriteAlllines recibe una lista y trata cada elemento como una linea 
    }
}