using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO_dotnet_transferencia_bancaria
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            TipoConta = tipoConta;
            Saldo = saldo;
            Credito = credito;
            Nome = nome;
        }

        public bool Sacar(double valor)
        {
            if (Saldo + Credito < valor)
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }

            Saldo -= valor;
            Console.WriteLine($"O saldo da conta de {Nome} foi de {Saldo + valor} para {Saldo}!");

            return true;
        }

        public void Depositar(double valor)
        {
            Saldo += valor;
            Console.WriteLine($"O saldo da conta de {Nome} foi de {Saldo - valor} para {Saldo}!");
        }

        public bool Transferir(double valor, Conta destino)
        {
            if (this.Equals(destino))
            {
                Console.WriteLine("As contas de origem e destino não podem ser as mesmas!");
                return false;
            }

            if (Sacar(valor))
            {
                destino.Depositar(valor);
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return $"TipoConta: {TipoConta} | " +
            $"Nome: {Nome} | " +
            $"Saldo: {Saldo} | " +
            $"Crédito: {Credito}";
        }
    }
}