namespace HR;


//Mother of all classes is object class
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Employee(int id, string name)
    {
        Id = id;
        Name = name;
    }

    //Object Oriented Programming
    //Encapsulation
    //Inheritance
    //Polymorphism
                //Overriding parent behavior in child class
    //Abstraction

    //Polymorphism
    //Change the default implementation of ToString method here in this Employee class
    public override string ToString()
    {
        return $"  Employee class ToString method :ID: {Id}, Name: {Name}";
    }
}