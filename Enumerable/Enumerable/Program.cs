using System;
using Enumerable.Entities;
using Enumerable.Entities.Enums;
using System.Globalization;

namespace Enumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            //Perguntando o nome do departamento;
            Console.Write("Enter department's name: ");
            string deptName = Console.ReadLine();

            //Dados do Trabalhador;
            Console.WriteLine("Enter worker data:");
            //Perguntando o nome do Trabalhador;
            Console.Write("Name: ");
            string name = Console.ReadLine();
            //`Perguntando o nivel do Trabalhador;
            Console.Write("Level (Junior/Mid_Level/Senior): ");
            //O nivel do trabalhador é um ENUM do Tipo WorkerLevel Estanciado na Pasta ENUMS;
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            //Perguntando o Salario do Trabalhador;
            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            //Estanciando um Departamento;
            Department dept = new Department(deptName);
            //Estanciando um trabalhador: nome, nivel, salario Base e o Departamento(estanciado acima. objeto do tipo Departamento);
            Worker worker = new Worker(name, level, baseSalary, dept);

            //Perguntando o numero de contratos;
            Console.Write("How Many contracts to this worker?: ");
            int n = int.Parse(Console.ReadLine());

            //Laço de repetição de n(n° de contratos) digitado acima
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} contract data:");
                //Perguntado a Data do Contrato
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                //Perguntando o valor por horas
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                //Perguntando a duração do contrato;
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                //Estanciando um contrato: data, valorPorHora e Horas;
                HourContract contract = new HourContract(date, valuePerHour, hours);

                //Adicionando o contrato para o trabalhador;
                worker.AddContract(contract);
            }

            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            //Armazenando em uma string o mes/ano
            string montAndYear = Console.ReadLine();
            //Cortando o mes da string mes/ano
            int month = int.Parse(montAndYear.Substring(0, 2));
            //Cortando o ano da string mes/ano, da posicao tres até o fim da string
            int year = int.Parse(montAndYear.Substring(3));

            //Imprimindo o nome do Trabalhador;
            Console.WriteLine("Name: " + worker.Name);
            //Imprimindo o Departamento do Trabalhador;
            Console.WriteLine("Department: " + worker.Department.Name);
            //Chamando o método worker.Income da classe Worker que calcula o valor dos contratos com base no mes e ano;
            Console.WriteLine("Income for " + montAndYear + " :" + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));
        }

    }
}

