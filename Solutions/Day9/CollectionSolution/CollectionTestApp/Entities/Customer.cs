namespace CRM;

using System.Collections;
using System.Collections.Generic;
public class Customer : IComparable<Customer>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public Customer(int id, string name, int age = 18)
    {
        Id = id;
        Name = name;
        Age = age;
    }
    public override string ToString()
    {
        return $"  Customer class ToString method :ID: {Id}, Name: {Name}, Age: {Age}";
    }
    public int CompareTo(Customer? other)
    {
        if (other == null) return 1; // Nulls are considered less than any instance

        return this.Age.CompareTo(other.Age);
    }
}