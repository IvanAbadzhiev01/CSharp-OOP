using P03.Detail_Printer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {

            List<IEmployee> employees = new();
            List<string> document = new List<string> { "document 1", "Document 3333", "dk", "Sicret Document" };
            employees.Add(new Manager("GoShow", document));
            employees.Add(new Programer("Ivan", 13));

            DetailsPrinter detailPrinter = new(employees);
            detailPrinter.PrintDetails();


            //employees.Select(e => e.)




        }
    }
}
