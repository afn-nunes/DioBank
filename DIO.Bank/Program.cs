using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario != "X")
            {                             
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    case "X":
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                Console.Clear();
                opcaoUsuario = ObterOpcaoUsuario();
            }

            Console.Clear();
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void Depositar()
        {
            int numeroConta =  ObterNumeroConta();

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            foreach (Conta conta in listContas)
            {
                if (conta.getNumero() == numeroConta)
                {
                    conta.Depositar(valorDeposito);
                    break;
                }
            }            
        }

        private static void Sacar()
        {
            int numeroConta =  ObterNumeroConta();

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            foreach (Conta conta in listContas)
            {
                if (conta.getNumero() == numeroConta)
                {
                    conta.Sacar(valorSaque);
                    break;
                }
            }  
        }

        private static void Transferir()
        {
            int numeroConta =  ObterNumeroConta();

            Console.WriteLine("Digite o número da conta de destino:");
            int numeroContaDestino = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            foreach (Conta conta in listContas)
            {
                if (conta.getNumero() == numeroConta)
                {
                    foreach (Conta contaDestino in listContas)
                    {
                        if(contaDestino.getNumero() == numeroContaDestino)
                          conta.Transferir(valorTransferencia,  contaDestino);
                          break;
                    }
                    
                    break;
                }
            }              
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.Write("Digite 1 para Conta fisica ou 2 para Conta jurídica: ");
            int tipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta: ");
            int numero = int.Parse(Console.ReadLine());
            foreach (Conta conta in listContas)
            {
                if(conta.getNumero() == numero){
                    Console.WriteLine("Número da conta já cadastrado");
                    Console.ReadLine();
                    return;
                }
            }

            Console.Write("Digite o nome do cliente: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o saldo inical: ");
            double saldoInicial = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double credito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta((TipoConta)tipoConta, numero, nome, saldoInicial, credito);
            listContas.Add(novaConta);
        }

        private static void ListarContas()
        {
            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                Console.ReadLine();
                return;
            }

            Console.Clear();
            Console.WriteLine("Lista de contas: \n"); 
            foreach (var conta in listContas)
            {                               
                Console.WriteLine("#{0} - {1}",listContas.IndexOf(conta), conta);                
            }
            Console.ReadLine();
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Bank a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
        private static int ObterNumeroConta()
        {
            Console.Clear();
            Console.Write("Digite o número da conta: ");
            return int.Parse(Console.ReadLine());
        }
    }
}
