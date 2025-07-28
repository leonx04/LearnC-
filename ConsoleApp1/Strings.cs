namespace ConsoleApp1;

public class Strings
{
    public static void GetStrings()
    {
        Console.WriteLine("==================================== Strings ====================================");
        
        // Khởi tạo chuỗi
        string str1 = "Hello";
        string str2 = "World";
        
        // Nối chuỗi
        string str3 = str1 + ", " + str2 + "!";
        Console.WriteLine("Noi chuoi mac dinh: " + str3);
        
        // Độ dài chuỗi
        Console.WriteLine("Do dai chuoi string: " + str3.Length);
        
        // Chuyển đổi sang chữ hoa
        Console.WriteLine("Chu hoa: " + str3.ToUpper());
        
        // Chuyển đổi sang chữ thường
        Console.WriteLine("Chu thuong: " + str3.ToLower());
        
        string firstName = "Xuan ";
        string lastName = "Dung";
        string name = string.Concat(firstName, lastName);
        Console.WriteLine(name);
        
        string fullName = $" Ten day du la: {firstName} {lastName}";
        Console.WriteLine(fullName);
    }
    
    public static void GetStringInterpolation()
    {
        string name = "Xuan Dung";
        int age = 30;
        
        // Sử dụng chuỗi nội suy (string interpolation)
        string message = $"Ten cua toi la {name} va toi {age} tuoi.";
        Console.WriteLine(message);
    }
    
    public static void GetAccessString()
    {
        string str = "Hello, World!";
        
        // Truy cập ký tự trong chuỗi
        char firstChar = str[0]; // Lay ky tu dau tien
        Console.WriteLine($"Ky tu dau tien: {firstChar}");
        
        char lastChar = str[str.Length - 1]; // Lay ky tu cuoi cung
        Console.WriteLine($"Ky tu cuoi cung: {lastChar}");
        
        // Thay thế ký tự trong chuỗi
        str = str.Replace('H', 'J'); // Thay 'H' bằng 'J'
        Console.WriteLine($"Chuoi sau khi thay the: {str}");
        
        Console.WriteLine($"Vi tri ky tu dau tien: {str.IndexOf('e')}"); // Tìm vị trí của ký tự 'e'
    }
    
    public static void GetSpecialCharacters()
    {
        // Sử dụng ký tự đặc biệt trong chuỗi
        string txt = "Hello,\nWorld!"; // \n là ký tự xuống dòng
        Console.WriteLine(txt);
        
        txt = "Hello,\tWorld!"; // \t là ký tự tab
        Console.WriteLine(txt);
        
        txt = "Hello, \"World!\""; // Dấu ngoặc kép
        Console.WriteLine(txt);
        
        txt = "Hello, \\World!"; // Dấu gạch chéo ngược
        Console.WriteLine(txt);
    }
}