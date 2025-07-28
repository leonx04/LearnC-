namespace ConsoleApp1;

public class Operators
{
    
    public static void GetAssignmentOperators()
    {
        // Toán tử gán giá trị cho biến.
        int a = 10; // Gán giá trị 10 cho biến a
        int b = 20; // Gán giá trị 20 cho biến b
        
        Console.WriteLine("===================== ASSIGNMENT OPERATORS =====================");
        // Toán tử gán cộng
        a += 5; // Tương đương với a = a + 5,
        // b += 10; // Tương đương với b = b + 10
        Console.WriteLine($"Gia tri cua a sau khi cong: {a}");
        // Toán tử gán trừ
        b -= 5; // Tương đương với b = b - 5
        Console.WriteLine($"Gia tri cua b sau khi tru: {b}");
        // Toán tử gán nhân
        a *= 2; // Tương đương với a = a * 2
        Console.WriteLine($"Gia tri cua a sau khi nhan: {a}");
        // Toán tử gán chia
        b /= 2; // Tương đương với b = b / 2
        Console.WriteLine($"Gia tri cua b sau khi chia: {b}");
        // Toán tử gán chia lấy dư
        a %= 3; // Tương đương với a = a % 3
        Console.WriteLine($"Gia tri cua a sau khi chia lay du: {a}");
    }
    
    public static void GetComparisonOperators()
    {
        int a = 10;
        int b = 20;

        // Toán tử so sánh
        Console.WriteLine("===================== COMPARISON OPERATORS =====================");
        Console.WriteLine(a > b); // Lớn 
        Console.WriteLine(a < b); // Nhỏ
        Console.WriteLine(a >= b); // Lớn hơn hoặc bằng
        Console.WriteLine(a <= b); // Nhỏ hơn hoặc bằng
        Console.WriteLine(a == b); // Bằng
        Console.WriteLine(a != b); // Khác
        // Toán tử so sánh chuỗi
        string str1 = "Hello";
        string str2 = "World";
        Console.WriteLine(str1 == str2); // So sánh hai chuỗi có bằng
        Console.WriteLine(str1 != str2); // So sánh hai chuỗi có khác
        Console.WriteLine(str1.Length > str2.Length); // So sánh độ dài của chuỗi
        Console.WriteLine(str1.Length < str2.Length); // So sánh độ dài của chuỗi
        Console.WriteLine(str1.Length >= str2.Length); // So sánh độ dài của chuỗi
        Console.WriteLine(str1.Length <= str2.Length); // So sánh độ dài của chuỗi
        Console.WriteLine("=======================================");
    }
    
    public static void GetLogicalOperators()
    {
        // Toán tử logic
        Console.WriteLine("===================== LOGICAL OPERATORS =====================");
        int x = 10;
        int y = 20;
        
        Console.WriteLine(x > 5 && y < 30); // Toán tử AND
        Console.WriteLine(x < 5 || y < 30); // Toán tử OR
        Console.WriteLine(!(x > 5)); // Toán tử NOT
        Console.WriteLine("=======================================");
    }
}