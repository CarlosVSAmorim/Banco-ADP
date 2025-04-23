using System;

namespace Banco
{
    class Program
    {
        static void Main()
        {
            ContaCorrente conta1 = new ContaCorrente(123, 1000, 500);
            ContaCorrente conta2 = new ContaCorrente(456, 300, 200);

            conta1.Depositar(200);
            conta1.Sacar(100);
            conta1.Transferir(conta2, 300);
            conta1.ConsultarSaldo();
            conta1.EmitirExtrato();

            Console.WriteLine();
            conta2.EmitirExtrato();
        }
    }
}