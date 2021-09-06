using System;

namespace DIO.Bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private int numero{get; set;}
        private string nome { get; set; }
        private double saldo { get; set; }
        private double credito { get; set; }
        
        public Conta(TipoConta tipoConta, int numero, string nome, double saldo, double credito)
        {
            this.TipoConta = tipoConta;
            this.numero = numero;
            this.nome = nome;
            this.saldo = saldo;
            this.credito = credito;

        }

        public int getNumero(){
            return this.numero;
        }
        public bool Sacar(double valorSaque)
        {
            if (this.saldo - valorSaque < (this.credito * -1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            this.saldo -= valorSaque;
             ImprimirSaldo();
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.saldo += valorDeposito;
            ImprimirSaldo();
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
        }
        private void ImprimirSaldo()
        {
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.nome, this.saldo);
            Console.ReadLine();
        }

        public override string ToString()
        {
           return String.Format
           (
               "Tipo de conta: {0} | Número: {1}  | Nome: {2} | Saldo: {3} | Crédito: {4}",
                this.TipoConta, 
                this.numero,
                this.nome, 
                this.saldo, 
                this.credito
            ) ;
        }
    }
}