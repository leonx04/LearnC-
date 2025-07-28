namespace ConsoleApp1;

public class MultipleVariables
{
    public static void GetMultipleVariables()
    {
        // Cú pháp : type + tên biến1, tên biến2, ... = giá trị1, giá trị2, ...
        int a = 2, b = 9 , c = 10, d = 20 , tolal = a + b + c + d;
        float pi = 3.14f, e = 2.718f, phi = 1.618f;
        double x = 3.14, y = 1.618, z = 2.718;
        string firstName = "John", lastName = "Doe", fullName = firstName + " " + lastName;
        bool isActive = true, isVerified = false;
        char grade = 'A', initial = 'J';
        

        Console.WriteLine("==================================== Multiple Variables ====================================");
        Console.WriteLine(tolal);
        Console.WriteLine(pi + " " + e + " " + phi);
        Console.WriteLine(x + " " + y + " " + z);
        Console.WriteLine(fullName);
        Console.WriteLine(isActive + " " + isVerified);
        Console.WriteLine(grade + " " + initial);
        Console.WriteLine("====================================");
    }
}