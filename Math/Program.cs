namespace Math
{
    public delegate void MathOperationHandler(double result);
    class MathOperations
    {
        public event MathOperationHandler AdditionPerformed;
        public event MathOperationHandler SubtractionPerformed;
        public event MathOperationHandler MultiplicationPerformed;
        public event MathOperationHandler DivisionPerformed;

        public void Addition(double a, double b)
        {
            double result = a + b;
            // Pass result to listener?
            AdditionPerformed?.Invoke(result);
        }

        public void Subtraction(double a, double b)
        {
            SubtractionPerformed?.Invoke(a - b);
        }

        public void Multiplication(double a, double b)
        {
            MultiplicationPerformed?.Invoke(a * b);
        }

        public void Division(double a, double b)
        {
            DivisionPerformed?.Invoke(b == 0 ? double.NaN : a / b);
        }
    }


    class ResultDisplay
    {
        public void DisplayAdditionResult(double result)
        {
            Console.WriteLine("Addition: " + result);
        }

        public void DisplaySubtractionResult(double result)
        {
            Console.WriteLine("Subtraction: " + result);
        }

        public void DisplayMultiplicationResult(double result)
        {
            Console.WriteLine("Multiplication: " + result);
        }

        public void DisplayDivisionResult(double result)
        {
            Console.WriteLine("Division: " + result);
        }
    }


    class Program
    {

        static void Main()
        {

            MathOperations mathOperations = new MathOperations();
            ResultDisplay resultDisplay = new ResultDisplay();

            // Subscription
            // Add handler
            mathOperations.AdditionPerformed += resultDisplay.DisplayAdditionResult;
            mathOperations.SubtractionPerformed += resultDisplay.DisplaySubtractionResult;
            mathOperations.MultiplicationPerformed += resultDisplay.DisplayMultiplicationResult;
            mathOperations.DivisionPerformed += resultDisplay.DisplayDivisionResult;

            while (true)
            {
                Console.WriteLine("Please input 2 numbers: (Invalid number will be converted to 0)");
                double d1;
                double d2;

                double.TryParse(Console.ReadLine(), out d1);
                double.TryParse(Console.ReadLine(), out d2);

                Console.WriteLine("Please select an operation (addition, subtraction, multiplication, division, exit): ");
                string action = Console.ReadLine()?.ToLower() ?? "";
                string[] allowedActions = { "addition", "subtraction", "multiplication", "division", "exit" };

                if (action == "exit")
                {
                    Console.WriteLine("Bye");
                    break;
                }

                if (!allowedActions.Contains(action))
                {
                    Console.WriteLine("Invalid Action");
                    break;
                }

                switch (action)
                {
                    case "addition":
                        mathOperations.Addition(d1, d2);
                        break;

                    case "subtraction":
                        mathOperations.Subtraction(d1, d2);
                        break;

                    case "multiplication":
                        mathOperations.Multiplication(d1, d2);
                        break;

                    case "division":
                        mathOperations.Division(d1, d2);
                        break;

                    default:
                        // Unreachable
                        Console.WriteLine("action: " + action);
                        break;
                }
            }
        }
    }

}