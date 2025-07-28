namespace ConsoleApp1;

public class Loops
{
    public int LoopFor()
    {
        Console.WriteLine("==================================== For Loop ====================================");
        int sum = 0;
        for (int i = 1; i <= 10; i++)
        {
            sum += i;
            Console.WriteLine($"Tong tu 1 den {i} la: {sum}");
        }
        return sum;
    }
    
    public void LoopWhile()
    {
        Console.WriteLine("==================================== While Loop ====================================");
        int i = 1;
        int sum = 0;
        while (i <= 10)
        {
            sum += i;
            Console.WriteLine($"Tong tu 1 den {i} la: {sum}");
            i++;
        }
    }
    
    public void LoopDoWhile()
    {
        Console.WriteLine("==================================== Do While Loop ====================================");
        int i = 1;
        int sum = 0;
        do
        {
            sum += i;
            Console.WriteLine($"Tong tu 1 den {i} la: {sum}");
            i++;
        } while (i <= 10);
    }
    
    public void LoopForeach()
    {
        Console.WriteLine("==================================== Foreach Loop ====================================");
        string[] names = { "Huy", "Dung", "Nguyen" };
        foreach (string name in names)
        {
            Console.WriteLine($"Hello, {name}!");
        }
    }
}