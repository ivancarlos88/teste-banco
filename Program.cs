using System;
using System.Collections.Generic;

namespace Banco
{
    class program
    {

        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            Conta minhaConta = new Conta(TipoConta.PessoaFisica, 0, 0, "Ivan Carlos");
            
            Console.WriteLine(minhaConta.ToString());

            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
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

                    default:
                    throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.ReadLine();
        }

        private static void Transferir()
        {
          Console.WriteLine("Digite o numero da conta de origem: ");
          int indiceContaOrigem = int.Parse(Console.ReadLine()); 

         Console.WriteLine("Digite o numero da conta de destino: ");
         int indiceContaDestino = int.Parse(Console.ReadLine()); 

        Console.WriteLine("Digite o valor a ser transferido: ");
        double valorTransferencia = int.Parse(Console.ReadLine());

        listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);
       
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Sacar(valorSaque);
        }
       private static void Depositar()
        {
            Console.WriteLine("Digite o numero da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indiceConta].Depositar(valorDeposito);
        }
        private static void InserirConta()
        {
            Console.WriteLine("Inserir nonva conta");

            Console.WriteLine("Digite 1 para Conta Fisica ou 2 para Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o Saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

        Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
            saldo: entradaSaldo,
            credito: entradaCredito,
            nome: entradaNome);

            listaContas.Add(novaConta);
        }
        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if (listaContas.Count == 0){
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }
            for(int i = 0; i < listaContas.Count; i++){
                Conta conta = listaContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Este é seu micro Banco");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
            
        }
    }
}
