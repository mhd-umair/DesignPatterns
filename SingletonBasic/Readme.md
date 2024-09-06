# Singleton Pattern Example in C#

This repository demonstrates a basic implementation of the Singleton Design Pattern in C#. The Singleton Pattern ensures that a class has only one instance and provides a global point of access to it.

## Description

The project is a simple console application that shows how to create a Singleton class and ensures that only one instance of the class is created. The example also demonstrates how multiple requests for the singleton instance return the same object.

### Key Concepts

- **Singleton Design Pattern**: A creational design pattern that restricts the instantiation of a class to one "single" instance and provides global access to that instance.
- **Thread-Safety**: The basic example here does not handle thread safety. For thread-safe Singleton, refer to the more advanced version of the Singleton pattern.

## Implementation

The project contains the following files:

- **Singleton.cs**: Contains the Singleton class that ensures only one instance is created.
- **Program.cs**: A simple console application that demonstrates how the Singleton class works.

## Usage

### Singleton.cs

```csharp
using System;

class Singleton
{
    // The single instance of the class is stored in this static field.
    private static Singleton _instance = null;

    // Private constructor prevents instantiation from other classes.
    private Singleton()
    {
        Console.WriteLine("Singleton instance created");
    }

    // Public method to provide access to the instance.
    public static Singleton GetInstance()
    {
        if (_instance == null)
        {
            _instance = new Singleton();
        }
        return _instance;
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}

```
### Program.cs
```csharp
class Program
{
    static void Main(string[] args)
    {
        Singleton instance1 = Singleton.GetInstance();
        Singleton instance2 = Singleton.GetInstance();

        instance1.ShowMessage("Hello from Singleton!");

        // Check if instance1 and instance2 are the same
        if (instance1 == instance2)
        {
            Console.WriteLine("Both instances are the same.");
        }
    }
}

```
### Output
```bash
Singleton instance created
Hello from Singleton!
Both instances are the same.
```
### Explanation
Singleton: This class restricts the instantiation of the class to a single object. It provides a global point of access to that instance through the GetInstance() method.
Main Method: The Main() method creates two instances of the Singleton class, but both will point to the same object, as indicated by the console output.

### How to Run
Clone the repository or copy the files into your local environment.
Open the solution in Visual Studio or your preferred C# development environment.
Build and run the console application.
Observe the output, which confirms that only one instance of the Singleton class is created.

### License
This project is licensed under the MIT License.
