using System;
using System.Collections.Generic;
using System.Linq;


namespace Banco
{
    class Validaciones
    {
        public string ValidarCliente(string cliente)
        {
            // Si el usuario inserta un cliente inválido seguira intentando hasta que provea uno válido
            while (string.IsNullOrEmpty(cliente)) {
                Console.WriteLine("\n¡INFORMACIÓN! Favor proveer un cliente válido");

                cliente = Console.ReadLine();
            }

            return cliente;
        }

        public double ValidarMonto(string monto)
        {
            double montoValido;

            // Si el usuario inserta un monto inválido seguirá solicitanto el monto hasta que provea uno válido
            while (string.IsNullOrEmpty(monto) || !double.TryParse(monto, out montoValido)) {
                Console.WriteLine("\n¡INFORMACIÓN! Favor proveer un monto válido");

                monto = Console.ReadLine();
            }

            return montoValido;
        }

        public int ValidarID(string id)
        {
            int idValido;

            // Si el cliente inserta un ID inválido seguirá solicitando el ID hasta que provea uno válida
            while (string.IsNullOrEmpty(id) || !int.TryParse(id, out idValido))
            {
                Console.WriteLine("\n¡INFORMACIÓN! Favor proveer un ID válido");

                id = Console.ReadLine();
            }

            return idValido;
        }
    }

    static class ExtenstionMethods
    {
        public static int Identity(this List<Transacciones> items)
        {
            if (items.Count < 1)
            {
                return 1;
            }
            else
            {
                return items.Last().ID + 1;
            }
        }

        public static void Listar(this List<Transacciones> items)
        {
            if (items.Count < 1)
            {
                Console.WriteLine("\nNo se encontraron registros\n");
            }
            else
            {
                Console.WriteLine("\n| ID | Cliente | Monto | Estado |");

                foreach (var item in items)
                {
                    Console.WriteLine($"| {item.ID} | {item.Cliente} | ${string.Format("{0:0.00}", item.Monto)} | {item.Estado} |");
                }

                Console.WriteLine("\n");
            }
        }
    }
}