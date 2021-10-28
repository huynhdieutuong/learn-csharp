using System;

namespace Event
{
    public delegate void InputNumberEvent(int x);
    /*
        publisher -> class - emit event
        subscriber -> class - receive event
    */

    // publisher
    class UserInput
    {
        public event InputNumberEvent inputNumberEvt; // 1. "event" to make sure inputNumberEvt only receive += or -=
        public void Input()
        {
            while (true)
            {
                Console.Write("Input a number > 0: ");
                int i = Convert.ToInt32(Console.ReadLine());
                inputNumberEvt?.Invoke(i); // emit event
            }
        }
    }

    // subscriber 1
    class CalSquareRoot
    {
        public void Sub(UserInput input)
        {
            input.inputNumberEvt += SquareRoot; // receive event | 1. only receive += or -=
        }
        public void SquareRoot(int i)
        {
            Console.WriteLine($"Square root of {i} is: " + Math.Sqrt(i));
        }
    }

    // subscriber 2
    class CalSquare
    {
        public void Sub(UserInput input)
        {
            input.inputNumberEvt += Square; // receive event | 1. += addEvent / -= removeEvent
        }
        public void Square(int i)
        {
            Console.WriteLine($"Square of {i} is: {Math.Pow(i, 2)}");
        }
    }

    class Program
    {
        static void Mainx()
        {
            // publisher
            UserInput userInput = new UserInput();

            userInput.inputNumberEvt += i =>
            {
                System.Console.WriteLine($"You entered number: {i}");
            };

            // subscriber 1
            CalSquareRoot calSquareRoot = new CalSquareRoot();
            calSquareRoot.Sub(userInput);

            // subscriber 2
            CalSquare calSquare = new CalSquare();
            calSquare.Sub(userInput);

            userInput.Input();
        }
    }
}