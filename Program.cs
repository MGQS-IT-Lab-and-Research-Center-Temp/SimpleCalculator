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
            MessageWithColor($"Result: {output}", ConsoleColor.Green);

            string continueOption = string.Empty;

            do
            {
                MessageWithColor("Do you want to continue Y/N: ", ConsoleColor.Cyan);

                continueOption = Console.ReadLine()!;

            } while (continueOption != "y" && continueOption != "n");

            flag = continueOption == "y";

        } while (flag);

    }
    catch (Exception ex)
    {
        MessageWithColor($"Error: {ex.Message}");
    }
}

double ConvertInputToNumeric(string stringInput)
{
    if (!double.TryParse(stringInput, out double convertedNumber))
    {
        throw new FormatException("A numeric value is expected!!");
    }

    return convertedNumber;
}

double CalculatorEngine(double argNumber1, double argNumber2, string argOperation)
{
    if (argOperation == "divide" || argOperation == "/" && argNumber2 == 0)
    {
        throw new DivideByZeroException("Cannot divide zero!");
    }

    var result = argOperation.ToLower() switch
    {
        "add" or "+" => argNumber1 + argNumber2,
        "minus" or "-" => argNumber1 - argNumber2,
        "multiply" or "*" => argNumber1 * argNumber2,
        "divide" or "/" => argNumber1 / argNumber2,
        "modulo" or "%" => argNumber1 % argNumber2,
        _ => throw new InvalidOperationException("Operator not recognized!")
    };

    return result;
}

void MessageWithColor(string message, ConsoleColor consoleColor = ConsoleColor.Red)
{
    Console.ForegroundColor = consoleColor;
    Console.WriteLine(message);
    Console.ResetColor();
}

