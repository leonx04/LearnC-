namespace ConsoleApp1;

public class Arrays
{
    public Array GetArray()
    {
        Console.WriteLine("==================================== Arrays ====================================");
        // Khởi tạo mảng số nguyên với 5 phần tử
        int[] numbers = new int[5] { 1, 2, 3, 4, 5 };
        
        // In ra các phần tử của mảng
        foreach (int number in numbers)
        {
            Console.WriteLine($"Phan tu trong mang: {number}");
        }
        return numbers;
    }

    public Array GetArrayString()
    {
        Console.WriteLine("==================================== Arrays String ====================================");
        // Khởi tạo mảng chuỗi với 3 phần tử
        string[] nameMember = new string[3] { "Hoai", "BNam", "Tien" };
        // In ra các phần tử của mảng
        Console.WriteLine($"Phan tu 1 trong mang: {nameMember[0]}");
        Console.WriteLine($"Phan tu 2 trong mang: {nameMember[1]}");
        Console.WriteLine($"Phan tu 3 trong mang: {nameMember[2]}");
        // In ra toàn bộ mảng
        Console.WriteLine("Toan bo mang: " + string.Join(", ", nameMember));
        return nameMember;
    }
    
    public Array GetArrayLoop()
    {
        Console.WriteLine("==================================== Arrays Loop ====================================");
        // Khởi tạo mảng số nguyên với 5 phần tử
        int[] numbers = new int[5] { 1, 2, 3, 4, 5 };
        
        // In ra các phần tử của mảng bằng vòng lặp for
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine($"Phan tu {i + 1} trong mang: {numbers[i]}");
        }
        return numbers;
    }
    
    public Array GetArraySort()
    {
        Console.WriteLine("==================================== Arrays Sort ====================================");
        // Khởi tạo mảng chuỗi theo thứ tự chữ cái a-z
        string[] cars = {"Volvo", "BMW", "Ford", "Mazda"};
        Array.Sort(cars);
        foreach (string car in cars)
        {
            Console.WriteLine(car);
        }
        return cars;
    }
    
    public Array GetArraySortReverse()
    {
        Console.WriteLine("==================================== Arrays Sort Reverse ====================================");
        // Khởi tạo mảng chuỗi theo thứ tự chữ cái z-a
        string[] cars = {"Volvo", "BMW", "Ford", "Mazda"};
        Array.Sort(cars);
        Array.Reverse(cars);
        foreach (string car in cars)
        {
            Console.WriteLine(car);
        }
        return cars;
    }
    
    public Array GetArrayMultiDimensional()
    {
        Console.WriteLine("==================================== Arrays Multi Dimensional ====================================");
        // Khởi tạo mảng hai chiều
        int[,] numbers = { {1, 4, 2}, {3, 6, 8} };
        
        // In ra các phần tử của mảng hai chiều
        for (int i = 0; i < numbers.GetLength(0); i++)
        {
            for (int j = 0; j < numbers.GetLength(1); j++)
            {
                Console.WriteLine($"Phan tu [{i}, {j}] trong mang: {numbers[i, j]}");
            }
        }
        return numbers;
    }

    public Array GetArrayAccessElement()
    {
        Console.WriteLine(
            "==================================== Arrays Access Element ====================================");
        // Khởi tạo mảng số nguyên với 5 phần tử
        int[,] numbers = { { 1, 4, 2 }, { 3, 6, 8 } };

        // Truy cập và in ra phần tử thứ hai trong mảng
        Console.WriteLine($"Phan tu thu hai trong mang: {numbers[0, 2]}");
        return numbers;
    }

}
