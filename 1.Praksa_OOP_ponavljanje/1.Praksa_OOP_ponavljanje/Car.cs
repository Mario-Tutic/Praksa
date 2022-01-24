using System;
using System.Collections.Generic;
using System.Text;

namespace Praksa_OOP_ponavljanje
{
    // base class
    abstract class Car : IVehicle
    {
        public int hp;
        public string name, color;
        private string serialNumber;

        public Car()
        {
            hp = 0;
            name = "";
            color = "";
            serialNumber = "";
        }
        public string SerialNumber
        {
            get { return serialNumber; }
            set { serialNumber = value; }
        }
        string GetSerialNumber()
        {
            return serialNumber;
        }


        public void Drive()
        {
            Console.WriteLine("Car drives on 4 wheels");
        }
        abstract public void Display();
    }
    class Suv : Car
    {
        public override void Display()
        {
            Console.WriteLine("Suv is bigger than normal car");
        }
    }

}