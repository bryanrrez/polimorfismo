using System;
using System.Linq;


namespace Banco
{
    class Transacciones
    {
        public int ID;
        public string Cliente;
        public double Monto;
        public string Estado;

        public void Editar(Model db, int id, string cliente, double monto)
        {
            Transacciones transaccionAEditar = db.Transacciones.Where(t => t.ID == id).First();

            transaccionAEditar.Cliente = cliente;
            transaccionAEditar.Monto = monto;

            Console.WriteLine($"\n¡EDITADO! Transacción #{id} editada exitosamente\n");
        }

        public void Eliminar(Model db, int id)
        {
            Transacciones transaccion = db.Transacciones.Where(t => t.ID == id).First();
            
            if (transaccion.Estado == "Aprobada")
            {
                transaccion.Estado = "Cancelada";
            }
            else if (transaccion.Estado == "Rechazada")
            {
                transaccion.Estado = "Eliminada";
            }
        }      
    }
}