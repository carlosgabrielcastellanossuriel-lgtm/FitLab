namespace Proyecto_FITLAB.Services;

internal class GestorPagos
{
    private static GestorPagos _instancia;
    private List<Pagos> _listaPagos = new List<Pagos>();

    private GestorPagos() { }

    public static GestorPagos Instancia
    {
        get
        {
            if (_instancia == null) _instancia = new GestorPagos();
            return _instancia;
        }
    }

    //*********
    // METOODOS
    //*********

    public Pagos CrearPago(Membresias membresia)
    {
        Pagos pago = new Pagos(membresia);

        _listaPagos.Add(pago);

        return pago;
    }

    public List<Pagos> HistorialPagos()
    {
        return new List<Pagos>(_listaPagos);
    }

    public double Ingresos_mes(int anio, int mes)
    {
        double ingresos_mes = _listaPagos.Where(p => p.Fecha.Month == mes && p.Fecha.Year == anio).Sum(p => p.monto_pagado);// Sumamos el campo monto_pagado de esos objetos pagos. Si no encuentra nada devuelve 0

        return ingresos_mes;
    }
}
