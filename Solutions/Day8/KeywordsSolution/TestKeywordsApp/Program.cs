using Mathematics;


using HR;

Complex cDefault = new Complex();

Complex c1 = new Complex(1, 2);
Complex c2 = new Complex(3, 4);


//To increase readability
Complex c3 = c1 + c2; //Using overloaded + operator
Complex c4 = c2 - c1; //Using overloaded - operator

Console.WriteLine($"Before Swap: c1 = {c1}, c2 = {c2}");
Complex.Swap(ref c1, ref c2);
Console.WriteLine($"After Swap: c1 = {c1}, c2 = {c2}");


object obj = new Employee(1, "Alice");  //Act of Polymorphism

Console.WriteLine(obj.ToString());