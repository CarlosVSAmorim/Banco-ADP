using System;
using System.Collections.Generic;

namespace Banco
{
    public class ContaCorrente
    {
        public int Numero { get; }
        public double Saldo { get; private set; }
        public double Limite { get; }

        private List<Movimentacao> movimentacoes;

        public ContaCorrente(int numero, double saldoInicial, double limite)
        {
            Numero = numero;
            Saldo = saldoInicial;
            Limite = limite;
            movimentacoes = new List<Movimentacao>();
        }

        public bool Sacar(double valor)
        {
            if (valor <= Saldo + Limite)
            {
                Saldo -= valor;
                movimentacoes.Add(new Movimentacao(valor, TipoTransacao.Debito));
                return true;
            }
            return false;
        }

        public void Depositar(double valor)
        {
            Saldo += valor;
            movimentacoes.Add(new Movimentacao(valor, TipoTransacao.Credito));
        }

        public void Transferir(ContaCorrente destino, double valor)
        {
            if (Sacar(valor))
            {
                destino.Depositar(valor);
                Console.WriteLine($"Transferência de R${valor:F2} para conta {destino.Numero} realizada com sucesso.");
            }
            else
            {
                Console.WriteLine("Transferência não realizada: saldo insuficiente.");
            }
        }

        public void ConsultarSaldo()
        {
            Console.WriteLine($"Saldo atual: R${Saldo:F2}");
        }

        public void EmitirExtrato()
        {
            Console.WriteLine($"Extrato da conta {Numero}:");
            foreach (var mov in movimentacoes)
            {
                Console.WriteLine(mov);
            }
        }
    }
}