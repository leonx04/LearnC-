namespace ConsoleApp1;

public class DisplayVariables
{
    public static void  GetDisplayVariables()
    {
        int a = 300;
        int b = 200;
        int c = a + b;
        int d = a - b;
        Console.WriteLine("==================================== Display Variables ====================================");
        Console.WriteLine("a = " + a);
        Console.WriteLine("b = " + b);
        Console.WriteLine("c = a + b = " + c);
        Console.WriteLine("d = a - b = " + d);
        Console.WriteLine("====================================");
    }
    
}