using System;

namespace Banco
{
    public class Movimentacao
    {
        public DateTime Data { get; }
        public double Valor { get; }
        public TipoTransacao Tipo { get; }

        public Movimentacao(double valor, TipoTransacao tipo)
        {
            Data = DateTime.Now;
            Valor = valor;
            Tipo = tipo;
        }

        public override string ToString()
        {
            return $"{Data:g} - {Tipo} de R${Valor:F2}";
        }
    }
}