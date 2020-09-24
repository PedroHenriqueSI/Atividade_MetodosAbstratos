using System;
using System.Collections.Generic;
using System.Globalization;

namespace AbstractMethods.Atv1.Entities
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> taxPayers = new List<TaxPayer>();

            Console.Write("Enter the number of tax payers: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Tax payer #{i} data:");
                Console.Write("Individual or company (i/c)? ");
                char l = char.Parse(Console.ReadLine());

                if (l == 'i' || l == 'I')
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Anual Income: ");
                    double anual = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.Write("Health expenditures: ");
                    double health = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    taxPayers.Add(new Individual(name, anual, health));
                }
                else
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Anual Income: ");
                    double anual = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.Write("Number of employees: ");
                    int number = int.Parse(Console.ReadLine());

                    taxPayers.Add(new Company(name, anual, number));
                }
            }
            
            double sum = 0.0;
            Console.WriteLine();
            Console.WriteLine("TAXES PAID: ");

            foreach (TaxPayer tax in taxPayers)
            {
                double tp = tax.Tax();
                Console.WriteLine("Name: " + tax.Name + " $" + tp.ToString("F2", CultureInfo.InvariantCulture));
                sum += tp;
            }
            Console.WriteLine();
            Console.WriteLine("TOTAL TAXES: $ " + sum.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
