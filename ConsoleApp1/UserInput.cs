namespace ConsoleApp1;

public class UserInput
{
    public void GetUserInput()
    {
        Console.WriteLine("==================================== User Input ====================================");
        Console.WriteLine("Nhap  ten vao:");
        string name = Console.ReadLine();
        Console.WriteLine("Hello, " + name + "!");

        Console.WriteLine("Nhap tuoi vao:");
        string ageInput = Console.ReadLine();
        if (int.TryParse(ageInput, out int age))
        {
            Console.WriteLine("Ban la " + name + " va ban co " + age + " tuoi roi.");
        }
        else
        {
            Console.WriteLine("Khong the chuyen doi tuoi sang so nguyen.");
        }
    }
}
