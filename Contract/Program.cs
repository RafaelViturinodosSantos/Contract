using System;
using Contract.Entities.Enums;
using Contract.Entities;
using System.Globalization;
namespace Contract
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name:");
            string depName = Console.ReadLine();
            Console.WriteLine("Enter work data: ");
            Console.Write("Name:");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(depName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.WriteLine("How many contracts to this worker ?");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Enter #{0} contract data: ", i);
                Console.Write("Date (DD/MM/YYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration {hours): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);

                Console.WriteLine();
                Console.WriteLine("Enter month and year to calculate income (MM/YYYY): ");
                string monthAndYear = Console.ReadLine();
                int month = int.Parse(monthAndYear.Substring(0, 2));
                int year = int.Parse(monthAndYear.Substring(3));

                Console.WriteLine("Name: " + worker.Name);
                Console.WriteLine("Departmente: " + worker.Department.Name);
                Console.WriteLine("Income for " + monthAndYear + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));
                Console.ReadLine();
            }
        }
    }
}
