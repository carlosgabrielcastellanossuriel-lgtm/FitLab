namespace Proyecto_FITLAB;

public class ID_no_encontrado_exception : Exception // hereda de la clase exception la cual es la clase por defecto de c# para las excepciones
{
    public ID_no_encontrado_exception(string mensaje) : base(mensaje){// Le pasara el mensaje a la clase padre
    }
}
