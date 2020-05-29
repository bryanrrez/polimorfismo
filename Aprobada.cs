namespace Banco
{
    class TransaccionAprobada : Transacciones
    {
        public TransaccionAprobada(int id, string cliente, double monto)
        {
            ID = id;
            Cliente = cliente;
            Monto = monto;
            Estado = "Aprobada";
        }
    }
}