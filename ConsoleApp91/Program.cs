using System;
using ConsoleApp91.Entity;

namespace ConsoleApp91
{
    class Program
    {
        static void Main(string[] args)
        {
             _ = new Author("van cao");
            _ = new Author("huy can");

            _ = new Readers("hanh",new DateTime(2099,2,20));
            _ = new Readers("hung", new DateTime(4000, 1, 15));

            _ = new Publisher("NXB tre");
            _ = new Publisher("NXB gia");

            _ = new Book("lao hac", 120.6, 1997, 200, new DateTime(2022, 1,12), 1, 1, 1);
            _ = new Book("tat den", 100.1, 1097, 2100, new DateTime(2000, 2, 10), 1, 2, 2);

            _ = new LoanSlip(1, 1, 1, 1);
            _ = new LoanSlip(2, 2, 2, 2);

            Console.WriteLine(123);



           
        }
    }
}
