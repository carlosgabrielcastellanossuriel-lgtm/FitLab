namespace FitLab.Negocio;

internal class GestorPagos
{
    private static GestorPagos _instancia;
    private List<Pago> _listaPagos = new List<Pago>();

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

    public Pago CrearPago(Membresia membresia)
    {
        Pago pago = new Pago(membresia);

        _listaPagos.Add(pago);

        return pago;
    }

    public List<Pago> HistorialPagos()
    {
        return new List<Pago>(_listaPagos);
    }

    public decimal Ingresos_mes(int anio, int mes)
    {
        decimal ingresos_mes = _listaPagos.Where(p => p.Fecha.Month == mes && p.Fecha.Year == anio).Sum(p => p.monto_pagado);// Sumamos el campo monto_pagado de esos objetos pagos. Si no encuentra nada devuelve 0

        return ingresos_mes;
    }
}
