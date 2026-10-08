namespace Proyecto_FITLAB;
public interface IIdentificador{
    int ID { get; }//Un atributo ID con al menos un get publico
}

public interface IMostrar_datos
{
    void Mostrar_datos();
}

    
public interface IMembresiaFactory{ 
    public Membresias CrearMembresia(); 
}