namespace ConsoleApp1;

public class Maths
{
    public static void GetMath()
    {
        double a = 3.43;
        int x = 10;
        int y = 20;
        int z = 30;
        
        Console.WriteLine("==================================== Maths ====================================");
        // Math.Max(x, y) trả về giá trị lớn nhất giữa x và y 
        // Chỉ có the dùng với 2 tham số
        Console.WriteLine("Math.Max(x, y) = " + Math.Max(x, y));
        
        // Math.Max(x, Math.Max(y, z)) trả về giá trị lớn nhất giữa x, y và z
        // Có thể dùng với nhiều tham số
        Console.WriteLine("Math.Max(x, Math.Max(y, z)) = " + Math.Max(x, Math.Max(y, z)));
        
        // Math.Min(x, Math.Min(y, z)) trả về giá trị nhỏ nhất giữa x, y và z
        // Có thể dung với nhiều tham số
        Console.WriteLine("Math.Min(x, Math.Min(y, z)) = " + Math.Min(x, Math.Min(y, z)));
        
        // Math.Min(x, y) trả về giá trị nhỏ nhất giữa x và y
        // Chỉ có thể dùng với 2 tham số
        Console.WriteLine("Math.Min(x, y) = " + Math.Min(x, y));
        
        // Math.Abs(x) trả về giá trị tuyệt đối của x
        Console.WriteLine("Math.Abs(x) = " + Math.Abs(x));
        
        // Math.Sqrt(x) trả về căn bậc hai của x
        Console.WriteLine("Math.Sqrt(x) = " + Math.Sqrt(x));
        
        // Math.Pow(x, y) trả về x lũy thừa y
        Console.WriteLine("Math.Pow(x, y) = " + Math.Pow(x, y));
        
        // Math.Round(x) làm tròn x đến số nguyên gần nhất
        Console.WriteLine("Math.Round(x) = " + Math.Round(a));
        
        // If else để kiểm tra số dương hay âm
        Console.WriteLine("==================================== If Else ====================================");
        if (a > 0)
        {
            // Math.Ceiling(x) làm tròn x lên số nguyên gần nhất
            Console.WriteLine("Math.Ceiling(x) = " + Math.Ceiling(a));
        }
        else
        {
            // Math.Floor(x) làm tròn x xuống số nguyên gần nhất
            Console.WriteLine("Math.Floor(x) = " + Math.Floor(a));
        }

        // Switch case để kiểm tra số chẵn lẻ
        Console.WriteLine("==================================== Switch Case ====================================");
        switch (x % 2)
        {
            case 0:
                Console.WriteLine("x la so chan");
                break;
            case 1:
                Console.WriteLine("x la so le");
                break;
            default:
                Console.WriteLine("Khong xac dinh");
                break;
        }
        
        // For loop để in ra các số từ 0 đến 9, bỏ qua số 4
        Console.WriteLine("==================================== For Loop ====================================");
        for(int i = 0; i < 10; i++) // for (khởi tạo; điều kiện; bước lặp)
        {
            if (i == 4)
            {
                continue;
            }
            Console.WriteLine(i);
        }
    }
}