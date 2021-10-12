using System;
using System.Collections.Generic;

namespace DIO_dotnet_transferencia_bancaria
{
    class Program
    {
        private static List<Conta> listaContas = new List<Conta>();

        private static Conta GetConta(int index)
        {
            Conta conta;
            try
            {
                conta = listaContas[index];
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("\nConta de origem não existente! Tente novamente!");
                Console.WriteLine("\nPressione [ENTER] para voltar:");
                _ = Console.ReadLine();
                return null;
            }

            return conta;
        }

        static void Main(string[] args)
        {
            var opcao = MenuOpcoes();

            while (opcao != "X")
            {
                switch (opcao)
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
                    default:
                        break;
                }

                opcao = MenuOpcoes();
            }
        }

        private static void ListarContas()
        {
            Console.Clear();
            Console.WriteLine("1 - Listar Contas\n");

            for (int i = 0; i < listaContas.Count; i++)
            {
                Console.WriteLine($"N°: {i + 1} | {listaContas[i]}");
            }

            Console.WriteLine("\nPressione [ENTER] para voltar:");
            _ = Console.ReadLine();
        }

        private static void InserirConta()
        {
            Console.Clear();
            Console.WriteLine("2 - Inserir Conta");

            Console.Write("\nDigite 1 para Conta Física e 2 para Conta Jurídica: ");
            var tipoConta = int.Parse(Console.ReadLine());

            if (tipoConta != 1 && tipoConta != 2)
            {
                Console.WriteLine("\nConta inválida! Tente novamente!");
                Console.WriteLine("\nPressione [ENTER] para voltar:");
                _ = Console.ReadLine();
                return;
            }

            Console.Write("\nDigite o Nome do cliente: ");
            var nome = Console.ReadLine();

            Console.Write("\nDigite o saldo inicial: ");
            var saldo = double.Parse(Console.ReadLine());

            Console.Write("\nDigite o crédito: ");
            var credito = double.Parse(Console.ReadLine());

            var novaConta = new Conta((TipoConta)tipoConta, saldo, credito, nome);
            listaContas.Add(novaConta);

            Console.WriteLine("\nPressione [ENTER] para voltar:");
            _ = Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.Clear();
            Console.WriteLine("3 - Transferir");

            Console.Write("\nDigite o número da conta de origem: ");
            var numContaOrigem = int.Parse(Console.ReadLine()) - 1;

            var contaOrigem = GetConta(numContaOrigem);
            if (contaOrigem == null)
                return;

            Console.Write("\nDigite o número da conta de destino: ");
            var numContaDestino = int.Parse(Console.ReadLine()) - 1;

            var contaDestino = GetConta(numContaDestino);
            if (contaDestino == null)
                return;

            Console.Write("\nDigite o valor da transferência: ");
            var valor = double.Parse(Console.ReadLine());

            Console.WriteLine();
            contaOrigem.Transferir(valor, contaDestino);

            Console.WriteLine("\nPressione [ENTER] para voltar:");
            _ = Console.ReadLine();
        }

        private static void Sacar()
        {
            Console.Clear();
            Console.WriteLine("4 - Sacar");

            Console.Write("\nDigite o número da conta: ");
            var numConta = int.Parse(Console.ReadLine()) - 1;

            var conta = GetConta(numConta);
            if (conta == null)
                return;

            Console.Write("\nDigite o valor do saque: ");
            var valor = double.Parse(Console.ReadLine());

            Console.WriteLine();
            conta.Sacar(valor);

            Console.WriteLine("\nPressione [ENTER] para voltar:");
            _ = Console.ReadLine();
        }

        private static void Depositar()
        {
            Console.Clear();
            Console.WriteLine("5 - Depositar");

            Console.Write("\nDigite o número da conta: ");
            var numConta = int.Parse(Console.ReadLine()) - 1;

            var conta = GetConta(numConta);
            if (conta == null)
                return;

            Console.Write("\nDigite o valor do deposito: ");
            var valor = double.Parse(Console.ReadLine());

            Console.WriteLine();
            conta.Depositar(valor);

            Console.WriteLine("\nPressione [ENTER] para voltar:");
            _ = Console.ReadLine();
        }



        private static string MenuOpcoes()
        {
            Console.Clear();

            Console.WriteLine("Informe a Opção desejada:\n");
            Console.WriteLine("\t1 - Listar contas");
            Console.WriteLine("\t2 - Inserir nova conta");
            Console.WriteLine("\t3 - Transferir");
            Console.WriteLine("\t4 - Sacar");
            Console.WriteLine("\t5 - Depositar");
            Console.WriteLine("\tX - Sair");

            var opcao = Console.ReadLine().ToUpper();
            return opcao;
        }
    }
}
