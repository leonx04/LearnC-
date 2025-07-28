namespace ConsoleApp1;

public class Variable
{
    public static void GetVariable()
    {
        // Cú pháp : type + tên biến = giá trị 
        string name = "Huy";
        int age = 20;
        double priceStudy = 34.54;
        char letter = 'A';
        bool flag = true;
        
        Console.WriteLine("==================================== Variables ====================================");
        Console.WriteLine(name);
        Console.WriteLine(age);
        Console.WriteLine(priceStudy);
        Console.WriteLine(letter);
        Console.WriteLine(flag);
        Console.WriteLine("====================================");
        
        // Biến có thể thay đổi giá trị
        name = "Huy Nguyen";
        age = 21;
        priceStudy = 45.67;
        letter = 'B';
        flag = false;
        Console.WriteLine(name);
        Console.WriteLine(age);
        Console.WriteLine(priceStudy);
        Console.WriteLine(letter);
        Console.WriteLine(flag);
    }
    
}