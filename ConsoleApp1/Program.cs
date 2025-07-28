namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Print "Hello, World!" 
            /*Console.WriteLine("Hello, World!");
            Console.WriteLine(5 + 5);*/
            Console.WriteLine("Hello, World! " + (5 + 5));
            Console.Write("Hello, World! " + 5 + 5);
            
            Variable.GetVariable();
            Constants.GetConstants();
            DisplayVariables.GetDisplayVariables();
            MultipleVariables.GetMultipleVariables();
            TypeCasting.GetTypeCasting();
            TypeCasting.GetTypeCasting();
            Operators.GetAssignmentOperators();
            Operators.GetComparisonOperators();
            Operators.GetLogicalOperators();
            Maths.GetMath();
            Strings.GetStrings();
            Strings.GetStringInterpolation();
            Strings.GetAccessString();
            Strings.GetSpecialCharacters();
            Loops loops = new Loops();
            loops.LoopFor();
            loops.LoopWhile();
            loops.LoopDoWhile();
            loops.LoopForeach();
            Arrays arrays = new Arrays();
            arrays.GetArray();
            arrays.GetArrayString();
            arrays.GetArrayLoop();
            arrays.GetArraySort();
            arrays.GetArraySortReverse();
            arrays.GetArrayMultiDimensional();
            arrays.GetArrayAccessElement();
            UserInput userInput = new UserInput();
            userInput.GetUserInput();
            Methods.PrintName("Huy");
            Methods.PrintSum(5, 10);
        }
    }
}
