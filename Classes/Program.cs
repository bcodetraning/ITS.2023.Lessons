using System;

namespace Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {

            
            Square square = new Square(2); 
            Console.WriteLine(square.Area);
        }  

        class Person
        {
            public string Name;
            public int Age; 
        } 
        class Labor:Person
        {         
           
        }

        class GeometricShape
        {
            public decimal Area; 
        }
        class Retangle : GeometricShape
        {
            public Retangle(int Width, int Height)
            {
                base.Area = Width * Height; 
            }
        }

        class Square : Retangle
        {

            public Square(int Lato) : base(Lato, Lato) 
            {
                base.Area = Lato ^ 2 ;
            }
        }
    }
}
