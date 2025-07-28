using System;

namespace ConsoleApp1
{
    public class TypeCasting
    {
        public static void GetTypeCasting()
        {
            // Implicit Casting (ngầm định - an toàn)
            int a = 10;
            double b = (double)a; // Ép kiểu tường minh từ int sang double
            float c = (float)b;   // Ép kiểu tường minh từ double sang float

            // Chuyển đổi số sang chuỗi
            string d = a.ToString(); // int sang string

            Console.WriteLine("==================================== Type Casting ====================================");
            Console.Write($"a: {a}, b: {b}, c: {c}, d: {d}");

            // Sử dụng lớp Convert để chuyển đổi kiểu
            Console.WriteLine(Convert.ToString(a));  // int → string
            Console.WriteLine(Convert.ToDouble(a));  // int → double
            Console.WriteLine(Convert.ToSingle(b));  // double → float
            Console.WriteLine(Convert.ToInt32(c));   // float → int (có thể bị làm tròn)
            Console.WriteLine(Convert.ToInt32(d));   // string → int
            Console.WriteLine(Convert.ToDouble(d));  // string → double
            Console.WriteLine(Convert.ToSingle(d));  // string → float
            Console.WriteLine("======================================================================================");
        }
    }
}