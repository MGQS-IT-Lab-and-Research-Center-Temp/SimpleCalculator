// TO DO

/*
    1. Build a method for the calculator input
    2. Build a method that parses the input for the operands to number type (double)
    3. Build the engine of the calculator that responds based on the operation to be performed
*/
Console.Title = "=====Simple Calculator=====";
Console.WriteLine("=====Simple Calculator=====");

CalculatorInputAndOutPut();

void CalculatorInputAndOutPut()
{
    try
    {
        bool flag = true;

        do
        {
            Console.Write("Enter your first number: ");
            double firstInput = ConvertInputToNumeric(Console.ReadLine()!);

            Console.Write("Enter your operator: ");
            string arithmeticOperator = Console.ReadLine()!;

            Console.Write("Enter your second number: ");
            double secondInput = ConvertInputToNumeric(Console.ReadLine()!);

            var output = CalculatorEngine(firstInput, secondInput, arithmeticOperator);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Result: {output}");
            Console.ResetColor();

            string continueOption = string.Empty;

            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Do you want to continue Y/N: ");
                Console.ResetColor();

                continueOption = Console.ReadLine()!;

            } while (continueOption != "y" && continueOption != "n");

            flag = continueOption == "y";

        } while (flag);

    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Error: {0}", ex.Message);
        Console.ResetColor();
    }
}

double ConvertInputToNumeric(string stringInput)
{
    if (!double.TryParse(stringInput, out double convertedNumber))
    {
        throw new FormatException("Expected a numeric value!");
    }

    return convertedNumber;
}

double CalculatorEngine(double argNumber1, double argNumber2, string argOperation)
{
    double result;

    switch (argOperation.ToLower())
    {
        case "add":
        case "+":
            result = argNumber1 + argNumber2;
            break;
        case "minus":
        case "-":
            result = argNumber1 - argNumber2;
            break;
        case "multiply":
        case "*":
            result = argNumber1 * argNumber2;
            break;
        case "divide":
        case "/":
            result = argNumber1 / argNumber2;
            break;
        case "modulo":
        case "%":
            result = argNumber1 % argNumber2;
            break;
        default:
            throw new InvalidOperationException("Operator not recognized!");
    }

    return result;
}