using System;
using System.Globalization;

namespace NotasMoedas
{
    public class Calculo
    {
        public decimal Cedulas { get; set; }
        public decimal Moedas { get; set; }

        static readonly decimal[] valorCedula = { 100.00M, 50.00M, 20.00M, 10.00M, 5.00M, 2.00M };
        static readonly decimal[] valorMoeda = { 1.00M, 0.50M, 0.25M, 0.10M, 0.05M, 0.01M };

        public Calculo()
        {
        }

        public Calculo(decimal cedulas, decimal moedas)
        {
            Cedulas = cedulas;
            Moedas = moedas;
        }

        public void Imprimir()
        {
            decimal n = decimal.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            decimal total = n;
            int[] cedulas = new int[valorCedula.Length];
            int[] moedas = new int[valorMoeda.Length];

            for (int i = 0; i < valorCedula.Length; i++)
            {
                cedulas[i] = Convert.ToInt32(Math.Floor(total / valorCedula[i]));
                total -= (cedulas[i] * valorCedula[i]);
            }

            for (int j = 0; j < valorMoeda.Length; j++)
            {
                moedas[j] = Convert.ToInt32(Math.Floor(total / valorMoeda[j]));
                total -= (moedas[j] * valorMoeda[j]);
            }

            Console.WriteLine("\nNOTAS: ");
            for (int i = 0; i < cedulas.Length; i++)
                Console.WriteLine($"{ cedulas[i] } nota(s) de R$ { valorCedula[i].ToString(CultureInfo.InvariantCulture)}");
            Console.WriteLine("MOEDAS: ");
            for (int j = 0; j < moedas.Length; j++)
                Console.WriteLine($"{ moedas[j] } moeda(s) de R$ { valorMoeda[j].ToString(CultureInfo.InvariantCulture)}");
        }
    }
}