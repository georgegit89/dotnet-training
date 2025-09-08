
namespace Mathematics;


public class Complex
{

    public const double Pi = 3.14159; //Placeholder for constant

    public readonly int count;

    public double Real { get; set; }
    public double Imaginary { get; set; }

    public Complex() : this(0, 0) //Constructor chaining
    {
    }
    public Complex(double real, double imaginary)
    {
        count++;
        Real = real;
        Imaginary = imaginary;
    }

    public override string ToString()
    {
        return $"{Real} + {Imaginary}i"; 
    }


    public static void Swap(ref Complex a, ref Complex b)
    {
        Complex temp = a;
        a = b;
        b = temp;
    }

    public static Complex operator +(Complex a, Complex b)
    {
        return new Complex(a.Real + b.Real, a.Imaginary + b.Imaginary);
    }

    public static Complex operator -(Complex a, Complex b)
    {
        return new Complex(a.Real - b.Real, a.Imaginary - b.Imaginary);
    }


}
    