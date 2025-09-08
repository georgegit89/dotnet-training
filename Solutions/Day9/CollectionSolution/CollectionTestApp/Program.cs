
using CRM;

using System.Collections.Generic;

using System.Text.Json;
using System.IO;

string name="John";
int age=30;

Console.WriteLine($"Name: {name}, Age: {age}");

//array of integers
int[] numbers = { 76, 8, 13, 4, 85 };
string[] fruits = { "Apple", "Banana", "Cherry" };


//Before Sorting
Console.WriteLine("Before Sorting");
for (int i = 0; i < numbers.Length; i++)
{
    Console.WriteLine(numbers[i]);
}

foreach (var fruit in fruits)
{
    Console.WriteLine(fruit);
}

//Matrix
//2D array
//Rectangular array  (Balanced Array)
int[,] matrix = {
    {1, 2, 3},
    {4, 5, 6},
    {7, 8, 9}
};

//print matrix
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        Console.Write(matrix[i, j] + " ");
    }
    Console.WriteLine();
}


//Jagged array (Unbalanced Array)
int[][] jaggedArray = new int[3][];
jaggedArray[0] = new int[] { 1, 2 };
jaggedArray[1] = new int[] { 3, 4, 5 };
jaggedArray[2] = new int[] { 6, 7, 8, 9 };

//print jagged array
for (int i = 0; i < jaggedArray.Length; i++)
{
    for (int j = 0; j < jaggedArray[i].Length; j++)
    {
        Console.Write(jaggedArray[i][j] + " ");
    }
    Console.WriteLine();
}



//Sorting



Array.Sort(numbers); //numbers.Reverse();

Console.WriteLine("After Sorting");
foreach (var number in numbers)
{
    Console.WriteLine(number);
}

Array.Sort(fruits);
Console.WriteLine("After Sorting");
foreach (var fruit in fruits)
{
    Console.WriteLine(fruit);
}


List<Customer> topCustomers = new List<Customer>();
topCustomers.Add(new Customer(3, "Smith", 89));
topCustomers.Add(new Customer(4, "Charan", 40));
topCustomers.Add(new Customer(5, "Abhay", 25));

Console.WriteLine("--------------------------------");

Console.WriteLine("Top Customers: before Sorting");
foreach (var customer in topCustomers)
{
    Console.WriteLine(customer);
}


topCustomers.Sort(); //Uses IComparable implementation in Customer class

Console.WriteLine("Top Customers: After Sorting");
foreach (var customer in topCustomers)
{
    Console.WriteLine(customer);
}



//Dictionary
Dictionary<string, Customer> customersDirectory = new Dictionary<string, Customer>();
customersDirectory.Add("9881735801", new Customer(1, "Alice", 56));
customersDirectory.Add("9881735802", new Customer(2, "Bob", 30));
customersDirectory.Add("9881735803", new Customer(3, "Charlie", 40));

//Accessing Dictionary elements
Console.WriteLine("Customer Directory:");
foreach (var entry in customersDirectory)
{
    Console.WriteLine($"ID: {entry.Key}, Name: {entry.Value.Name}, Age: {entry.Value.Age}");
}


//Serialization and Deserialization

Console.WriteLine("Serialization");
string jsonString = JsonSerializer.Serialize(topCustomers);
Console.WriteLine($"Serialized JSON: {jsonString}");
//Write to file
File.WriteAllText("customers.json", jsonString);


Console.WriteLine("Deserialization");
string jsonStringFromFile = File.ReadAllText("customers.json");
List<Customer>? customersFromFile = JsonSerializer.Deserialize<List<Customer>>(jsonStringFromFile);

if (customersFromFile != null)
{
    foreach (var customer in customersFromFile)
    {
        Console.WriteLine(customer);
    }
}