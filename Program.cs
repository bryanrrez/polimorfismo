using System;
using System.Collections.Generic;


namespace Banco
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("¡Bienvenido al Scotiabank!");
            Console.WriteLine("--------------------------");

            Menu();
        }

        static void Menu()
        {
            Model db = new Model();
            Validaciones validaciones = new Validaciones();
            Transacciones transaccion = new Transacciones();

            bool noQuieraSalir = true;

            while (noQuieraSalir)
            {
                Console.WriteLine("Inserte una de las siguientes opciones [1]- Agregar transacción [2]- Editar transacción [3]- Eliminar transacción [4]- Listar transacciones [0]- Salir");

                string opcion = Console.ReadLine();

                if (opcion == "1")
                {

                    string cliente = "";
                    string monto;

                    // Posibles respuestas para la inserción del tipo de transacción
                    List<string> posiblesRespuestas = new List<string>() {
                        "A",
                        "a",
                        "R",
                        "r"
                    };

                    Console.WriteLine("\nFavor digitar el nombre del cliente de la transacción:");
                    
                    cliente = Console.ReadLine();

                    string clienteValido = validaciones.ValidarCliente(cliente);
                    
                    Console.WriteLine("\nFavor digitar el monto de la transacción:");

                    monto = Console.ReadLine();

                    double montoValido = validaciones.ValidarMonto(monto);

                    Console.WriteLine("\nFavor digitar el estado de la transacción:");
                    Console.WriteLine("[A] para aprobada | [R] para rechazada");
                    Console.Write("A/R? ");

                    string respuesta = Console.ReadLine();

                    // Si el cliente inserta una respuesta inválida seguirá solicitando la respuesta hasta que provea una válida
                    while (!posiblesRespuestas.Contains(respuesta))
                    {
                        Console.WriteLine("\n¡INFORMACIÓN! Favor proveer una transacción válida");

                        respuesta = Console.ReadLine();
                    }

                    if (respuesta == "A" || respuesta == "a")
                    {
                        db.Transacciones.Add(new TransaccionAprobada(db.Transacciones.Identity(), cliente, montoValido));

                        Console.WriteLine("\n¡INFORMACIÓN! Transacción agregada exitosamente\n");
                    }
                    else if (respuesta == "R" || respuesta == "r")
                    {
                        db.Transacciones.Add(new TransaccionRechazada(db.Transacciones.Identity(), cliente, montoValido));

                        Console.WriteLine("\n¡INFORMACIÓN! Transacción agregada exitosamente\n");
                    }
                }
                else if (opcion == "2")
                {
                    int idValido;
                    bool seDeseeIntentar = true;

                    while (seDeseeIntentar)
                    {
                        Console.WriteLine("\nFavor digitar el ID de la transacción que desea editar:");

                        string id = Console.ReadLine();

                        idValido = validaciones.ValidarID(id);
                        
                        if (db.Transacciones.Exists(t => t.ID == idValido))
                        {
                            string cliente;
                            string clienteValido;
                            string monto;
                            double montoValido;

                            Console.WriteLine($"\nFavor digitar el nuevo cliente de la transacción:");
                        
                            cliente = Console.ReadLine();

                            clienteValido = validaciones.ValidarCliente(cliente);
                            
                            Console.WriteLine("\nFavor digitar el nuevo monto de la transacción:");

                            monto = Console.ReadLine();

                            montoValido = validaciones.ValidarMonto(monto);

                            transaccion.Editar(db, idValido, clienteValido, montoValido);

                            seDeseeIntentar = false;
                        }
                        else
                        {
                            // Posibles respuestas para el reintento de edición de transacción
                            List<string> posiblesRespuestas = new List<string>() {
                                "S",
                                "s",
                                "N",
                                "n"
                            };

                            Console.WriteLine($"\n¡INFORMACIÓN! Transacción #{id} no encontrada");
                            Console.WriteLine("\n¿Desea intentar con otro ID?");
                            Console.Write("\nS/N? ");

                            string respuesta = Console.ReadLine();

                            // Si el cliente inserta una respuesta inválida seguirá solicitando la respuesta hasta que provea una válida
                            while (!posiblesRespuestas.Contains(respuesta))
                            {
                                Console.WriteLine("\n¡INFORMACIÓN! Favor proveer una respuesta válida");

                                respuesta = Console.ReadLine();
                            }

                            if (respuesta == "N" || respuesta == "n")
                            {
                                seDeseeIntentar = false;
                            }
                        }   
                    }
                }
                else if (opcion == "3")
                {
                    int idValido;

                    Console.WriteLine("\nFavor digitar el ID de la transacción que desea eliminar:");

                    string id = Console.ReadLine();

                    idValido = validaciones.ValidarID(id);

                    if (db.Transacciones.Exists(t => t.ID == idValido))
                    {
                        transaccion.Eliminar(db, idValido);

                        Console.WriteLine($"\n¡ELIMINADO! Transacción #{idValido} eliminada exitosamente\n");
                    }
                    else
                    {
                        Console.WriteLine($"\n¡INFORMACIÓN! Transacción #{idValido} no encontrada\n");
                    }
                }
                else if (opcion == "4")
                {
                    db.Transacciones.Listar();
                }
                else if (opcion == "0")
                {
                    noQuieraSalir = false;

                    Console.WriteLine("\n¡Gracias por su visita, vuelva pronto! 👋🏽\n");
                }
            }
        }
    }
}
