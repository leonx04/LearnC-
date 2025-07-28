namespace ConsoleApp1;

public class Constants
{
    public static void GetConstants()
    {
        // Cú pháp : const + type + tên biến = giá trị
        const string name = "Huy";
        const int age = 22;
        const double priceStudy = 56.34;
        const char letter = 'B';
        const bool flag = true;

        Console.WriteLine("==================================== Constants ====================================");
        Console.WriteLine(name);
        Console.WriteLine(age);
        Console.WriteLine(priceStudy);
        Console.WriteLine(letter);
        Console.WriteLine(flag);
        
        // Biến hằng không thể thay đổi giá trị
        // name = "Huy Nguyen"; // Lỗi: không thể thay đổi giá trị của biến hằng
    }
}