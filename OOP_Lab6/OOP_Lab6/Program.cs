using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab6
{
    public class Triangle
    {
        private Triad triad;
        private static int counter;
        public class Triad
        {
            private double x;
            private double y;
            private double z;
            private static int counter = 0;

            public Triad() { x = 1; y = 1; z = 1; counter++; }
            public Triad(double X, double Y, double Z)  
            {
                if (X >= (Y + Z) || Y >= (X + Z) || Z >= (X + Y) || X == 0 || Y == 0 || Z == 0)
                { x = 1; y = 1; z = 1; }
                else { x = X; y = Y; z = Z;}
                counter++;
            }
            public Triad(Triad a) { x = a.x; y = a.y; z = a.z; counter++; }
            public void setX(double X) { x = X; }
            public void setY(double Y) { y = Y; }
            public void setZ(double Z) { z = Z; }
            public double getX() { return x; }
            public double getY() { return y; }
            public double getZ() { return z; }
            public int getCounter() { return counter; }
            public bool Init(double X, double Y, double Z) 
            {
                if (X > 0 && Y > 0 && Z > 0) { setX(X); setY(Y); setZ(Z); return true; }
                else { return false; }
            }
            public double Sum() 
            {
                double O = x + y + z;
                return O;
            }
            public static Triad operator ++(Triad a)
            {
                return new Triad(a.x++, a.y++, a.z++);
            }
            public static Triad operator --(Triad a)
            {
                return new Triad(a.x--, a.y--, a.z--);
            }
            public void Display() 
            {
                Console.WriteLine($"Counter = {getCounter()}");
                Console.WriteLine("X = {0}\tY = {1}\tZ = {2}", x , y, z);
            }
            public void Read() 
            {
                double X, Y, Z;
                do
                {
                    Console.Write("X = ");
                    X = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Y = ");
                    Y = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Z = ");
                    Z = Convert.ToDouble(Console.ReadLine());
                } while (!Init(X, Y, Z));
            }
            public override String ToString() 
            {
                return "X = " + x + "\tY = " + y + "\tZ = ";
            }
        }
        public Triangle() 
        {
            triad = new Triad(1, 1, 1); 
            counter++; 
        }
        public Triangle(double X, double Y, double Z) 
        {
            triad = new Triad(X, Y, Z);
            counter++;
        }
        public Triangle(Triangle a)
        {
            triad = new Triad(a.triad);
            counter++;
        }
        public Triangle(Triad a) 
        {
            triad = new Triad(a);
            counter++;
        }
        public void setTriad(double X, double Y, double Z) 
        {
            triad = new Triad(X, Y, Z);
        }
        public Triad getTriad() 
        {
            return triad;
        }
        public int getCounter() 
        {
            return counter;
        }
        public double Square() 
        {
            double p = Convert.ToDouble(triad.getX() + triad.getY() + triad.getZ()) / 2;
            double S = Math.Sqrt(p * (p - triad.getX()) * (p - triad.getY()) * (p - triad.getZ()));
            return S;
        }
        public double angleX() 
        {
            double cosX = (triad.getY() * triad.getY() + triad.getZ() * triad.getZ() - triad.getX() * triad.getX()) / (2 * triad.getY() * triad.getZ());
            double Xr = Math.Acos(cosX); // in radians
            double X = Xr * 57.2958;
            return X;
        }
        public double angleY()
        {
            double cosY = (triad.getX() * triad.getX() + triad.getZ() * triad.getZ() - triad.getY() * triad.getY()) / (2 * triad.getX() * triad.getZ());
            double Yr = Math.Acos(cosY); // in radians
            double Y = Yr * 57.2958;
            return Y;
        }
        public double angleZ()
        {
            double cosZ = (triad.getX() * triad.getX() + triad.getY() * triad.getY() - triad.getZ() * triad.getZ()) / (2 * triad.getX() * triad.getY());
            double Zr = Math.Acos(cosZ); // in radians
            double Z = Zr * 57.2958;
            return Z;
        }
        public static Triangle operator ++ (Triangle a) 
        {
            return new Triangle(a.triad++);
        }
        public static Triangle operator -- (Triangle a)
        {
            return new Triangle(a.triad--);
        }
        public override string ToString()
        {
           return "Square: " + this.Square() + "cm\nAngle X = " + Math.Round(angleX(), 3) + "\nAngle Y = " + Math.Round(angleY(), 3) + "\nAngle Z = " + Math.Round(angleZ(), 3);
        }
        public void Display() 
        {
            this.triad.Display();
            Console.WriteLine($"Square: {this.Square()} cm\nAngle X = {Math.Round(angleX(), 3)}\nAngle Y = {Math.Round(angleY(), 3)}\nAngle Z = {Math.Round(angleZ(), 3)}\n");
        }
        public void Read() 
        {
            this.triad.Read();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Triangle a = new Triangle();
            Triangle b = new Triangle();
            a = new Triangle(3, 6, 5);
            a = new Triangle(b);
            a.Read();
            a.Display();


            Console.ReadKey();
        }
    }
}
