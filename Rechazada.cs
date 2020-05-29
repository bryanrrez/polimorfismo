namespace Banco
{
    class TransaccionRechazada : Transacciones
    {
        public TransaccionRechazada(int id, string cliente, double monto)
        {
            ID = id;
            Cliente = cliente;
            Monto = monto;
            Estado = "Rechazada";
        }
    }
}