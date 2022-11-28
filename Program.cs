using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

internal class Program
{
    private static void Main(string[] args)
    {
        // Creating a list to save all previous calculations
        List<string> calcHistory = new List<string>() { };

        // Welcome message for user
        Console.WriteLine("Welcome to the calculator.\n");
        Console.WriteLine("Press any key to continue!");
        Console.ReadKey();
        

        // Loop that keeps running and allowing calculations as long as user doesn't choose to exit from MainMenu.
        while (true)
        {
            try
            {
            MainMenu:
                // Show MainMenu where you can see CalcHistory, Exit program or continue.
                MainMenu();
                var keyPressed = Console.ReadKey();
                // Exits program with Esc
                if (keyPressed.Key == ConsoleKey.Escape)
                {
                    return;
                }

                // Using key press H, show history of your calculations in the current session
                else if (keyPressed.Key == ConsoleKey.H)
                {
                    CalcHistoryMenu();
                    goto MainMenu;
                }

                // Show CalcMenu where you see instructions for the calculator
                CalcMenu();
                string userInput = Console.ReadLine();

                if (userInput.Contains("+"))
                {
                    // The + method
                    AddMethod(userInput);
                }

                else if (userInput.Contains("-"))
                {
                    // The - method
                    SubtractMethod(userInput);
                }

                else if (userInput.Contains("*"))
                {
                    // The * method
                    MultiMethod(userInput);
                }

                else if (userInput.Contains("/"))
                {
                    // The / method
                    DivMethod(userInput);
                }

                // Errormessage if userInput does not cointain + - * /.
                else
                {
                    ErrorMessage();
                }

            }

            catch
            {
                ErrorMessage();
            }

        }

        // Method for when user adds numbers
        string AddMethod(string userInput)
        {
            // PLUS Seperate the userInput into two variables
            int operatorIndex = userInput.IndexOf("+");
            string numberOneTxt = userInput[..operatorIndex];
            string numberTwoTxt = userInput[(operatorIndex + 1)..];

            // Converting strings of numbers into int so it can be calculated with
            int numberOneInt = int.Parse(numberOneTxt);
            int numberTwoInt = int.Parse(numberTwoTxt);

            // Calculation
            int calculationInt = numberOneInt + numberTwoInt;

            // Converting the result to a string and adding it to the list
            string calcTxt = Convert.ToString(calculationInt);
            string calcHistoryItem = $"{numberOneTxt}+{numberTwoTxt} = {calcTxt}";
            calcHistory.Add(new string(calcHistoryItem));

            // Printing out the calculation and result
            Console.WriteLine($"{numberOneInt}+{numberTwoInt} = {calculationInt}");
            Console.ReadKey();

            return calcHistoryItem;
        }

        // Method for when user subtracts numbers
        string SubtractMethod(string userInput)
        {
            // MINUS Seperate the userInput into two variables and identify which operator is used
            int operatorIndex = userInput.IndexOf("-");
            string numberOneTxt = userInput[..operatorIndex];
            string numberTwoTxt = userInput[(operatorIndex + 1)..];

            // Converting strings of numbers into int so it can be calculated with
            int numberOneInt = int.Parse(numberOneTxt);
            int numberTwoInt = int.Parse(numberTwoTxt);

            // Calculation
            int calculationInt = numberOneInt - numberTwoInt;

            // Converting the result to a string and adding it to the list
            string calcTxt = Convert.ToString(calculationInt);
            string calcHistoryItem = $"{numberOneTxt}-{numberTwoTxt} = {calcTxt}";
            calcHistory.Add(new string(calcHistoryItem));

            // Printing out the calculation and result
            Console.WriteLine($"{numberOneInt}-{numberTwoInt} = {calculationInt}");
            Console.ReadKey();

            return calcHistoryItem;
        }

        // Method for when user multiplies numbers
        string MultiMethod(string userInput)
        {
            // MULTIPLICATION Seperate the userInput into two variables and identify which operator is used
            int operatorIndex = userInput.IndexOf("*");
            string numberOneTxt = userInput[..operatorIndex];
            string numberTwoTxt = userInput[(operatorIndex + 1)..];

            // Converting strings of numbers into int so it can be calculated with
            int numberOneInt = int.Parse(numberOneTxt);
            int numberTwoInt = int.Parse(numberTwoTxt);

            // Calculation
            int calculationInt = numberOneInt * numberTwoInt;

            // Converting the result to a string and adding it to the list
            string calcTxt = Convert.ToString(calculationInt);
            string calcHistoryItem = $"{numberOneTxt}*{numberTwoTxt} = {calcTxt}";
            calcHistory.Add(new string(calcHistoryItem));

            // Printing out the calculation and result
            Console.WriteLine($"{numberOneInt}*{numberTwoInt} = {calculationInt}");
            Console.ReadKey();

            return calcHistoryItem;
        }

        // Method for when user divides numbers
        string DivMethod(string userInput)
        {
            // DIVISION Seperate the userInput into two variables and identify which operator is used
            int operatorIndex = userInput.IndexOf("/");
            string numberOneTxt = userInput[..operatorIndex];
            string numberTwoTxt = userInput[(operatorIndex + 1)..];

            // Converting strings of numbers into int so it can be calculated with
            int numberOneInt = int.Parse(numberOneTxt);
            int numberTwoInt = int.Parse(numberTwoTxt);

            // Unique error message for when user tries to divide by 0.
            if (numberTwoInt == 0)
            {
                Console.WriteLine("\nYou can not divide by 0.");
                Console.WriteLine("\nYou will now be sent back to the Main Menu.\nPress any key to continue.");
                Console.ReadKey();
                return userInput;
            }

            // Calculation
            double calculationDoub = (double)numberOneInt / numberTwoInt;

            // Converting the result to a string and adding it to the list
            string calcTxt = Convert.ToString(calculationDoub);
            string calcHistoryItem = $"{numberOneTxt}/{numberTwoTxt} = {calcTxt}";
            calcHistory.Add(new string(calcHistoryItem));

            // Printing out the calculation and result
            Console.WriteLine($"{numberOneInt}/{numberTwoInt} = {calculationDoub}");
            Console.ReadKey();

            return calcHistoryItem;
        }

        // Method for showing calculation history menu
        void CalcHistoryMenu()
        {
            Console.Clear();
            Console.WriteLine("Calculation History\n--------------------");
            Console.WriteLine("\nEnter - To continue.");
            Console.WriteLine("---------------------");

            foreach (string s in calcHistory)
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();
        }

        // Method for showing the main menu
        void MainMenu()
        {
            // Main menu where user is given options based on what they want to do (go to calc, history list, or exit) 
            Console.Clear();
            Console.WriteLine("Main Menu\n----------");
            Console.WriteLine("ESC - Exit\nH - Calculation History\nAny other key - Continue");
        }

        // Method that brings user to the calculator
        void CalcMenu()
        {
            // User inputs numbers and operator, only possible with 2 numbers and 1 operator.
            Console.Clear();
            Console.WriteLine("Calculator\n-----------\n");
            Console.WriteLine("Write TWO numbers and the operator you want to calculate.\nExample: 341+85\t\t" + "Available operators: + - * /" + "\n\nEnter - to Calculate and Continue.\n");
        }

        // Method to show an error message when user input is invalid
        void ErrorMessage()
        {
            Console.WriteLine("\n*ERROR*\nSomething went wrong\nYou will be sent to Start Menu\n\nPress any button to continue.");
            Console.ReadKey();
        }
    }

}