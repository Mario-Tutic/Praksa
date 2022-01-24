using System;

namespace Praksa_OOP_ponavljanje
{
    class Program
    {
        static void Main(string[] args)
        {

            // object of derived class
            Car ford = new Suv(); //polymorphism
            ford.Display();
            //Console.WriteLine(ford.serialNumber) ne radi jer je serialNumber private,
            //ali properties nam omogucuje citanje i pisanje privatnih varijabli 
            Console.Write("Unesi serijski broj automobila:");
            ford.SerialNumber=Console.ReadLine();
            Console.WriteLine("Serijski broj automobila je:"+ford.SerialNumber);
        }
    }
}
