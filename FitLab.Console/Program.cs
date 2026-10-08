using Proyecto_FITLAB;
using Proyecto_FITLAB.Models;

int opc = 0;

Console.WriteLine("============ BIENVENIDO A FITLAB ============");
do
{
    Console.WriteLine(@"
1. Registrar cliente
2. Registrar pago
3. Registrar asistencia
4. Historial de asistencias
5. Buscador de asistencia
6. Membresias activas
7. Clientes registrados
8. Sesiones activas
9. Buscador sesion activa 
10. Cerrar sesion
11. Ingresos de un mes
12. Salir");
    
    try
    {
        opc = Convert.ToInt32(Console.ReadLine()); Console.WriteLine();

        switch (opc)
        {
            case 1:
                {
                    Console.WriteLine("Digite el tipo de cliente:\n" +
                        "1. Regular\n" +
                        "2. Estudiante\n" +
                        "3. Premium\n");
                                                       
                    TipoClientes tipoCliente = Convert.ToInt32(Console.ReadLine()) switch
                    {
                    
                        1 => TipoClientes.Regular,
                        2 => TipoClientes.Estudiante,
                        3 => TipoClientes.Premium,
                        _ => throw new Exception("Opcion invalida!")
                    };
                    
                    Console.WriteLine("Digite el nombre: "); string nombre = Console.ReadLine();
                    
                    Console.WriteLine("Digite el rol:\n" +
                        "1. Cliente\n" +
                        "2. Coach\n"); Rol rol = Convert.ToInt32(Console.ReadLine()) switch
                        {
                            1 => Rol.Cliente,
                            2 => Rol.Coach,
                        };
                    
                    Console.WriteLine("Digite la edad: "); int edad = Convert.ToInt32(Console.ReadLine());
                    
                    Console.WriteLine("\nMembresia: \n" +
                        "1. Mensual(1,500/mes)\n" +
                        "2. Trimestral(4,000/3 meses)\n" +
                        "3. Anual(14,000/año)");
                    
                    TipoMembresia tipoMembresia = Convert.ToInt32(Console.ReadLine()) switch
                    {
                        1 => TipoMembresia.Mensual,
                        2 => TipoMembresia.Trimestral,
                        3 => TipoMembresia.Anual,
                        _ => throw new Exception("Opcion de membresia no valida!")
                    };

                    int id = Gestor.Registrar_cliente(tipoCliente, tipoMembresia, nombre, rol, edad);

                    Console.WriteLine($"Cliente creado satisfactoriamente. Su ID es: {id}");

                    goto case 2;// le dice que pase al caso 2

                }
                

            case 2:
                {
                    Console.WriteLine("Digite su ID: "); int id = Convert.ToInt32(Console.ReadLine());
                                   
                    Membresias membresia = Gestor.ExisteMembresia(id);

                    Console.WriteLine($"Monto a pagar: {membresia.tarifa}\nDesea confirmar el pago? (Presione 1 para confirmar...)"); int confirmar = Convert.ToInt32(Console.ReadLine());

                    if (confirmar == 1)
                    {
                        Console.WriteLine($"Proximo pago: {membresia.fecha_vencimiento.ToShortDateString()}");

                        Gestor.AgregarPago(membresia);

                        Console.WriteLine($"Pago realizado satisfactoriamente.");
                    }

                    else Console.WriteLine("Pago cancelado."); break;
                }

            case 3:
                {
                    Console.WriteLine("Digite su ID: "); int id = Convert.ToInt32(Console.ReadLine());
                   
                    string nombre = Gestor.Registrar_asistencia(id); 
                    
                    Console.WriteLine($"Asistencia confirmada {nombre}."); break;
                }


            case 4: {

                    List<Asistencia> historialAsistencias = Gestor.HistorialAsistencias();

                    foreach (Asistencia a in historialAsistencias)
                    {
                        Console.WriteLine(a);
                    }

                    break;
                }


            case 5:
                {

                    Console.WriteLine("Digite su id: ");  int id = Convert.ToInt32(Console.ReadLine());

                    List<Asistencia> historialAsistencias =  Gestor.BuscadorAsistencias(id);

                    if(historialAsistencias == null) { Console.WriteLine($"No historial previo para el ID: {id}"); }

                    foreach (Asistencia a in historialAsistencias)
                    {
                        Console.WriteLine(a);
                    }

                    break;
                }

            case 6:
                {
                    List<Membresias> ListaMembresiasActivas = Gestor.MembresiasActivas(); 
                    
                    if(ListaMembresiasActivas.Count == 0) Console.WriteLine("No hay membresias activas por el momento.");

                    else
                    {
                        Console.WriteLine("************** MEMBRESIAS ACTIVAS **************");

                        foreach (Membresias m in ListaMembresiasActivas)
                        {
                            Console.WriteLine($"Propietario: {m.Propietario.nombre} || Membresia ID: {m.ID}");
                        }
                    } break;
                }


            case 7:
                {
                    List<Clientes> ListaClientesRegistrados = Gestor.ClientesRegistrados();

                    if (ListaClientesRegistrados.Count == 0) Console.WriteLine("No hay clientes registrados por el momento.");

                    else
                    {
                        Console.WriteLine("************** CLIENTES **************");

                        foreach (Clientes c in ListaClientesRegistrados)
                        {
                            Console.WriteLine($"Nombre: {c.nombre} || ID: {c.ID} || Membresia ID: {c.Membresia_cliente.ID} || Estado membresia: {c.Membresia_cliente.Estado}");
                        }
                    }
                    break;
                }

            case 8:
                {
                    List<Sesion> ListaSesionesActivas = Gestor.Obtener_sesiones_activas();

                    if (ListaSesionesActivas.Count == 0) Console.WriteLine("No hay sesiones activas.");
                    else
                    {
                        Console.WriteLine("************** SESIONES ACTIVAS **************");

                        foreach (Sesion sesion in ListaSesionesActivas)
                        {
                            Console.WriteLine($"{sesion.Nombre} | {sesion.rol} | {sesion.Inicio_sesion}");
                        }

                        Console.WriteLine();

                        Console.WriteLine($"Numero total de sesiones activas: {Gestor.Cantidad_sesiones_activas()}");

                    }
                    break;
                }


            case 9: 
                {

                    Console.WriteLine("Digite su id:");  int id = Convert.ToInt32(Console.ReadLine());
                    
                    Console.WriteLine(Gestor.BuscadorSesion(id));
               
                    break; 
                }


            case 10:
                {
                    Console.WriteLine("Digite su ID: "); int id = Convert.ToInt32(Console.ReadLine());

                    string nombre = Gestor.Cerrar_sesion(id); 

                    Console.WriteLine($"Sesion cerrada correctamente {nombre}."); break;
                }

            case 11:
                {
                    Console.WriteLine("Digite el año buscado: "); int anio = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Digite el mes buscado: "); int mes = Convert.ToInt32(Console.ReadLine());

                    double ingresos = Gestor.Ingresos_mes(anio, mes); 

                    Console.WriteLine($"Ingresos: ${ingresos}"); break;
                }
            
            case 12: Console.WriteLine("Gracias por su visita!"); break;

            default: Console.WriteLine("Opcion invalida!"); break;
        }
    }

    catch (ID_no_encontrado_exception e)
    {
        Console.WriteLine(e.Message);
    }

    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }

} while (opc != 12);

Console.ReadKey();