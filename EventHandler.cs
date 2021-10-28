using System;

// EventHanler is event delegate
namespace _EventHandler
{
    // public delegate void InputNumberEvent(int i); (1)

    // Publisher
    class UserInput
    {
        // public event InputNumberEvent inputNumberEvt; (2)
        public event EventHandler inputNumberEvt; // 1. EventHandler ~ (1) & (2)
        public void Input()
        {
            while (true)
            {
                Console.Write("Please enter a number > 0: ");
                int i = Convert.ToInt32(Console.ReadLine());
                inputNumberEvt.Invoke(this, new InputData(i)); // 2. inputNumberEvt.Invoke(object? sender, EventArgs args)
            }
        }
    }

    class InputData : EventArgs // 2. EventArgs
    {
        public int Data { get; set; }
        public InputData(int x)
        {
            Data = x;
        }
    }

    // Subscriber 1
    class SquareRoot
    {
        public void Sub(UserInput input)
        {
            input.inputNumberEvt += CalSquareRoot;
        }
        // protected void CalSquareRoot(int i)
        // {
        //     Console.WriteLine($"Square root of {i} is: {Math.Sqrt(i)}");
        // }
        protected void CalSquareRoot(object sender, EventArgs e) // 3. Convert i from EventArgs
        {
            InputData inputData = (InputData)e;
            int i = inputData.Data;
            Console.WriteLine($"Square root of {i} is: {Math.Sqrt(i)}");
        }
    }

    // Subscriber 2
    class Square
    {
        public void Sub(UserInput input)
        {
            input.inputNumberEvt += CalSquare;
        }
        // protected void CalSquare(int i)
        // {
        //     Console.WriteLine($"Square of {i} is: {i * i}");
        // }
        protected void CalSquare(object sender, EventArgs e) // 3. Convert i from EventArgs
        {
            InputData inputData = (InputData)e;
            int i = inputData.Data;
            Console.WriteLine($"Square of {i} is: {i * i}");
        }
    }

    public class Program
    {
        static void Mainx()
        {
            Console.CancelKeyPress += (sender, e) => // 4. When Ctrl C, this EventHandler will call
            {
                System.Console.WriteLine();
                System.Console.WriteLine("Quit app");
            };

            // publisher
            UserInput input = new UserInput();

            input.inputNumberEvt += (sender, e) => // 3. Since lambda, can remove object & EventArgs type
            {
                InputData inputData = (InputData)e;
                int i = inputData.Data;
                Console.WriteLine($"You entered number: {i}");
            };

            // subscriber 1
            SquareRoot squareRoot = new SquareRoot();
            squareRoot.Sub(input);

            // subscriber 2
            Square square = new Square();
            square.Sub(input);

            input.Input();
        }
    }
}