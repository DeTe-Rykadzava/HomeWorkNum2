// See https://aka.ms/new-console-template for more information

using System.Reflection;

namespace HomeWorkNum2;

public class Program
{
    public static void Main(string[] args)
    {
        // all operations with methods processing
        var operations = new Dictionary<char, Func<double, double, double>>();
        operations.Add('+', (double a, double b) => a + b);
        operations.Add('-', (double a, double b) => a - b);
        operations.Add('*', (double a, double b) => a * b);
        operations.Add('/', (double a, double b) => a / b);
        // showing version and operations 
        var version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "1.0.0";
        begin:
        Console.WriteLine($"Calc Т-1000 v.{version}\n");
        Console.WriteLine("Select operation:\n"  +
                          "==================\n" +
                          "Addition:\t+\n"       +
                          "Subtraction:\t-\n"    +
                          "Multiplication:\t*\n" +
                          "Division:\t/\n"       +
                          "==================");
        selectingOperation:
                
        // getting user input operation
        Console.Write("Selected operation:\t");
        var operationChar = Console.ReadLine();
                
        // validate user input and show error if input non valid
        if (string.IsNullOrWhiteSpace(operationChar) || operationChar.Length != 1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[ERROR] The selected operation cannot be empty or consist of other characters!");
            Console.WriteLine("Try again!");
            Console.ForegroundColor = ConsoleColor.White;
            goto selectingOperation;
        }
                
        // find operation
        var operation = operations.FirstOrDefault(x => x.Key == operationChar[0]);
                
        // show error if operation not found
        if (operation.Value == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[ERROR] An operation on the input character was not found!");
            Console.WriteLine("Try again!");
            Console.ForegroundColor = ConsoleColor.White;
            goto selectingOperation;
        }
                
        Console.WriteLine("\nPlease input operators:");
        Console.WriteLine("=======================\n");
        // get operator A
        gettingOperatorA:
            
        Console.Write("Operator A:\t");
        var aString = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(aString) || !double.TryParse(aString, out var a))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[ERROR] The input operator A cannot be empty or not be a number!");
            Console.WriteLine("Try again!");
            Console.ForegroundColor = ConsoleColor.White;
            goto gettingOperatorA;
        }
                
        // get operator B
        gettingOperatorB:
            
        Console.Write("Operator B:\t");
        var bString = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(aString) || !double.TryParse(bString, out var b))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[ERROR] The input operator B cannot be empty or not be a number!");
            Console.WriteLine("Try again!");
            Console.ForegroundColor = ConsoleColor.White;
            goto gettingOperatorB;
        }
        Console.WriteLine("\n=======================\n");
                
        Console.Write("The result of the operation ");        
        
        switch (operationChar[0])
        {
            case '+':
                Console.WriteLine($"addition is {operation.Value.Invoke(a,b)}");
                break;
            case '-':
                Console.WriteLine($"subtraction is {operation.Value.Invoke(a,b)}");
                break;
            case '*':
                Console.WriteLine($"multiplication is {operation.Value.Invoke(a,b)}");
                break;
            case '/':
                Console.WriteLine($"division is {operation.Value.Invoke(a,b)}");
                break;
        }

        Console.Write("\nIf you want to use other operations, press {Enter}\t");
        var key = Console.ReadKey();
        if (key.Key == ConsoleKey.Enter)
        {
            Console.Clear();
            goto begin;
        }
            
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nThank you for using this calculator. Goodbye!\n");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Press any key for exit");
    }
}