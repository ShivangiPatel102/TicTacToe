using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static char[] arr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static char[] duplicateArr = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        public static void Main(string[] args)
        {
            int player = 1;
            int input = 0;

            //loop 1: main game loop
            do
            {
                bool exception = false;
                bool inputCorrect = true;

                //Winner Checking
                char[] playerChar = { 'X', 'O' };
                foreach (char a in playerChar)
                {
                    if (((arr[1] == a) && (arr[2] == a) && (arr[3] == a))     //horizontal - 1
                       || ((arr[4] == a) && (arr[5] == a) && (arr[6] == a))  //horizontal - 2
                       || ((arr[7] == a) && (arr[8] == a) && (arr[9] == a))  //horizontal - 3
                       || ((arr[1] == a) && (arr[4] == a) && (arr[7] == a))  // vertical - 1
                       || ((arr[2] == a) && (arr[5] == a) && (arr[8] == a))  // vertical - 2
                       || ((arr[3] == a) && (arr[6] == a) && (arr[9] == a))  //vertical - 3
                       || ((arr[1] == a) && (arr[5] == a) && (arr[9] == a))  // diagonal 1
                       || ((arr[3] == a) && (arr[5] == a) && (arr[7] == a))) // diagonal 2
                    {
                        Display(arr);
                        
                        if (a == 'X')
                        {
                            Console.WriteLine(" Winner is Player 1");
                            
                            Reset(duplicateArr);
                            break;
                        }
                        else if (a == 'O')
                        {
                            Console.WriteLine(" Winner is Player 2");
                            Reset(duplicateArr);
                            break;
                        }
                    }
                    else if ((arr[0] != '0') && (arr[1] != '1') && (arr[2] != '2') && (arr[3] != '3') && (arr[4] != '4') && (arr[5] != '5') && (arr[6] != '6') && (arr[7] != '7') && (arr[8] != '8') && (arr[9] != '9'))
                    {
                        Display(arr);


                        Console.WriteLine("The match is Draw!");
                        Reset(duplicateArr);
                        break;
                    }
                }

                //Player Switching and Setting up the Display field
                if (player == 2 && input != 0)
                    player = 1;

                else if(player == 1 && input != 0)
                    player = 2;

                else if(input == 0)
                    arr = setXorO(player, input, arr);

                
                Display(arr);
                

                
                //loop 2: for Player Input with error handling
                do
                {
                    exception = false;
                    
                    Console.WriteLine("Player {0}: Choose your field! ", player);
                   
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                        
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Incorrect Input,  Pls enter a number!");
                        exception = true;
                        
                    }

                    
                    if (exception == false) 
                    {
                        
                        if ((input == 1) && (arr[1] == '1'))
                            inputCorrect = true;
                        else if ((input == 2) && (arr[2] == '2'))
                            inputCorrect = true;
                        else if ((input == 3) && (arr[3] == '3'))
                            inputCorrect = true;
                        else if ((input == 4) && (arr[4] == '4'))
                            inputCorrect = true;
                        else if ((input == 5) && (arr[5] == '5'))
                            inputCorrect = true;
                        else if ((input == 6) && (arr[6] == '6'))
                            inputCorrect = true;
                        else if ((input == 7) && (arr[7] == '7'))
                            inputCorrect = true;
                        else if ((input == 8) && (arr[8] == '8'))
                            inputCorrect = true;
                        else if ((input == 9) && (arr[9] == '9'))
                            inputCorrect = true;
                        else
                        {
                            Console.WriteLine("Incorrect  Input! Please enter another field");
                            inputCorrect = false;
                        }
                    }
                    else
                    {
                        inputCorrect = false;
                    }
                    arr = setXorO(player, input, arr);


                } while (!inputCorrect);


            } while (true);

            //Console.ReadKey();
        }
        public static void Display(char[] arr)
        {
            Console.Clear();
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" {0} | {1} | {2} ", arr[1], arr[2], arr[3]);
            Console.WriteLine("___|___|___");
            //-----------------------------------------------------------------
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" {0} | {1} | {2} ", arr[4], arr[5], arr[6]);
            Console.WriteLine("___|___|___");
            //-----------------------------------------------------------------
            Console.WriteLine("   |   |   ");
            Console.WriteLine(" {0} | {1} | {2} ", arr[7], arr[8], arr[9]);
            Console.WriteLine("   |   |   ");
            //-----------------------------------------------------------------
        }

        public static char[] setXorO(int player, int input, char[] arr) 
        {
            if ((player == 1) && (input != 0))
                arr[input] = 'X';



            else if ((player == 2) && (input != 0))
                arr[input] = 'O';

            else if (input == 0)
                arr[input] = 'd';


            return arr;
        }


        public static void Reset( char[] duplicateArr)
        {

            Console.WriteLine("Press any key to play again!");
            string inputReset = Console.ReadLine();
            if(inputReset != null)
            {
                
                arr = duplicateArr;
                Display(arr);
            }
        }
    }

}  