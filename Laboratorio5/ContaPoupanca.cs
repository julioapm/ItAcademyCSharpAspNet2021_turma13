using System;

namespace Laboratorio5
{
    public class ContaPoupanca : Conta
    {
        private decimal taxaJuros;
        private DateTime dataAniversario;

        public ContaPoupanca(decimal j, DateTime d, string t) : base(t)
        {
            taxaJuros = j;
            dataAniversario = d;
        }

        public decimal Juros
        {
            get { return taxaJuros; }
            set { taxaJuros = value; }
        }

        public string DataAniversario
        {
            get { return dataAniversario.ToShortDateString(); }
        }

        public override string Id
        {
            get { return $"{Titular}(CP)"; }
        }
    }
}