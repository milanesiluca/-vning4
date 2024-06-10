using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        /// 
        private static List<string> theList = new List<string>();
        private static List<string> errorLog = new List<string>();

        private static Queue<string> theQueue = new Queue<string>();
        private static Stack<string> theStack = new Stack<string>();
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n0. Exit the application\n");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    Console.Write("Chose your option: ");
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            //List<string> theList = new List<string>();
            //string input = Console.ReadLine();
            //char nav = input[0];
            //string value = input.substring(1);

            //switch(nav){...}
            char input = ' ';
            bool exit = false;
            string? inputStr = null;
            Console.Clear();
            do {
                
                Console.WriteLine("Available option:"
                        + "\n'+' and string to add an element to the List"
                        + "\n'-' and string to remove an element from the List"
                        + "\n'1' write the complete List"
                        + "\n'*' Exit\n");
                try
                {
                    Console.Write("Chose your option: ");
                    inputStr = Console.ReadLine()!.Trim();
                    input = inputStr![0]; 
                }
                catch (Exception ex)
                {
                    errorLog.Add("No valid Key inserted: " + ex.GetType().Name);
                }
                finally
                {
                    Console.WriteLine();
                }

                switch (input)
                {
                    case '+':
                        if (!string.IsNullOrEmpty(inputStr) && inputStr.Trim().Length > 1)
                            theList.Add(inputStr.Substring(1, inputStr.Length - 1).Trim());
                        else
                            Console.WriteLine("The input cannot be only '+'\n");
                        break;
                    case '-':
                        if (!string.IsNullOrEmpty(inputStr) && inputStr.Trim().Length > 1)
                        {
                            int existingElement = checkElementList(inputStr.Substring(1, inputStr.Length - 1));
                            if (existingElement != -1 )
                                theList.RemoveAt(existingElement);
                            else
                                Console.WriteLine("The Item is not in the list");
                        }   
                        else
                            Console.WriteLine("The input cannot be only '-'\n");
                        break;
                    case '*':
                        exit = true;
                        break;
                    case '1':
                        Console.Clear();
                        foreach (string str in theList)
                            Console.WriteLine(str);
                        Console.WriteLine($"\nItems in the list: {theList.Count}\n");
                        break;
                    case '%':
                        ShowErrorLog();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Clear();
                        Console.WriteLine("invalid Input: your input must have '+' or '-' as first char");
                        Console.ResetColor();
                        break;
                }

            } while (!exit);
            Console.Clear() ;
        }

        private static int checkElementList(string inputStr)
        {
            for (int i = 0; i < theList.Count; i++)
            {
                if (theList[i] == inputStr.Trim())
                    return i;
            }
            return - 1;      
        }

        private static void ShowErrorLog() {
            Console.WriteLine($"Execption List: {errorLog.Count} error found");
            foreach (var strErr in errorLog)
                Console.WriteLine(strErr);
            Console.WriteLine();
        }




        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            char input = ' ';
            bool exit = false;
            string? inputStr = null;
            Console.Clear();
            do {

                Console.WriteLine("Available option:"
                        + "\n'+' and string to add an element to the Queue"
                        + "\n'-' to remove a String from the Queue"
                        + "\n'1' write the complete Queue"
                        + "\n'*' Exit\n");

                try
                {
                    Console.Write("Chose your option: ");
                    inputStr = Console.ReadLine()!.Trim();
                    input = inputStr![0];
                }
                catch (Exception ex)
                {
                    errorLog.Add("No valid Key inserted: " + ex.GetType().Name);
                }
                finally
                {
                    Console.WriteLine();
                }

                switch (input)
                {
                    case '+':
                        if (!string.IsNullOrEmpty(inputStr) && inputStr.Trim().Length > 1)
                            theQueue.Enqueue(inputStr.Substring(1, inputStr.Length - 1).Trim());
                        else
                            Console.WriteLine("The input cannot be only '+'\n");
                        break;
                    case '-':
                        if (theQueue.Count > 0) {
                            theQueue.Dequeue();
                            Console.WriteLine($"\nThe first inserted element has been removed\n");
                        } else
                            Console.WriteLine($"\nNo element in the queue\n");

                        break;
                    case '*':
                        exit = true;
                        break;
                    case '1':
                        Console.Clear();
                        foreach (string str in theQueue)
                            Console.WriteLine(str);
                        Console.WriteLine($"\nItems in the Queue: {theQueue.Count}\n");
                        break;
                    case '%':
                        ShowErrorLog();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Clear();
                        Console.WriteLine("invalid Input: your input must have '+' or '-' as first char");
                        Console.ResetColor();
                        break;
                }

            } while (!exit);
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            char input = ' ';
            bool exit = false;
            string? inputStr = null;
            Console.Clear();
            do
            {

                Console.WriteLine("Available option:"
                        + "\n'+' and string to add an element to the Stack"
                        + "\n'-' to remove an element from the Stack"
                        + "\n'1' write the complete Stack"
                        + "\n'*' Exit\n");

                try
                {
                    Console.Write("Chose your option: ");
                    inputStr = Console.ReadLine()!.Trim();
                    input = inputStr![0];
                }
                catch (Exception ex)
                {
                    errorLog.Add("No valid Key inserted: " + ex.GetType().Name);
                }
                finally
                {
                    Console.WriteLine();
                }

                switch (input)
                {
                    case '+':
                        if (!string.IsNullOrEmpty(inputStr) && inputStr.Trim().Length > 1)
                            theStack.Push(inputStr.Substring(1, inputStr.Length - 1).Trim());
                        else
                            Console.WriteLine("The input cannot be only '+'\n");
                        break;
                    case '-':
                        if (theStack.Count > 0)
                        {
                            theStack.Pop();
                            Console.WriteLine($"\nThe last inserted element has been removed\n");
                        }
                        else
                            Console.WriteLine($"\nNo element in the queue\n");

                        break;
                    case '*':
                        exit = true;
                        break;
                    case '1':
                        Console.Clear();
                        foreach (string str in theStack)
                            Console.WriteLine(str);
                        Console.WriteLine($"\nItems in the Queue: {theStack.Count}\n");
                        break;
                    case '%':
                        ShowErrorLog();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Clear();
                        Console.WriteLine("invalid Input: your input must have '+' or '-' as first char");
                        Console.ResetColor();
                        break;
                }

            } while (!exit);
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            Console.Write("Insert a String: ");
            string? vattelaApesca = Console.ReadLine();
            if (string.IsNullOrEmpty(vattelaApesca)) {
                Console.WriteLine("No string inserted (idiot!)");
                return;
            }

            char[] charArray = vattelaApesca.ToCharArray();

            List<char> monsterList = new List<char>() { '{', '[', '(', ')', ']', '}' };
            var parList = charArray
                          .Where(parCh => monsterList.Contains(parCh)).ToList();

            if (parList.Count % 2 != 0) {
                Console.WriteLine("\nThe paranthesis in the inserted string are incorrect\n");
                return;
            }


            List<string> correctStfList = new List<string>() { "()", "{}", "[]"}; 
            for (int i = 0; i < parList.Count / 2; i++) {
                for (int j = parList.Count - 1; j > parList.Count / 2 - 1 && j < parList.Count
                    ; j--) {
                    string correctStr = parList[i].ToString() + parList[j].ToString();
                    if (correctStfList.Contains(correctStr))
                        continue;
                    else
                    {
                        Console.WriteLine("\nThe paranthesis in the inserted string are not correct\n");
                        return;
                    }
                       
                }
            }

            Console.WriteLine("\nThe paranthesis in the inserted string are correct\n");

        }

    }
}

