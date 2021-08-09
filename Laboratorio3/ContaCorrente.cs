namespace Laboratorio3
{
    public class ContaCorrente
    {
        public string Titular { get; set; }
        private decimal saldo;
        public const decimal MINIMO_DEPOSITO = 100;
        public void Depositar(decimal valor)
        {
            if (valor >= MINIMO_DEPOSITO)
            {
                saldo = saldo + valor;
            }
        }
        public void Sacar(decimal valor)
        {
            saldo -= valor;
        }

        public decimal Saldo
        {
            get { return saldo; }
        }

        public ContaCorrente(string titular, decimal saldoInicial)
        {
            Titular = titular;
            saldo = saldoInicial;
        }

        public ContaCorrente(string titular) : this(titular, 0)
        {
        }
    }
}