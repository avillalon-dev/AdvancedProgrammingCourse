using Model;
using System.Diagnostics;

namespace ConsoleApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Debug.WriteLine("Line");
            var humanResources = new HumanResources(new List<SalaryFunction>() { SalaryFunctions.WorkerSalary});
            humanResources.AddWorker("Juan", new DateTime(1995, 12, 24), "", 1, Departments.Automation);
            humanResources.Activate();
        }
    }
}