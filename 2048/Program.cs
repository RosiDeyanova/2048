using System;

namespace _2048
{
    class Program
    {
        int[,] table = new int[4, 4];

        void blankTable()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    table[i, j] = 0;
                }
            }

            spanwRandomNum();
            spanwRandomNum();
        } //creates a blank table
        int randomNum(int range) {
            Random rnd = new Random();
            int n = rnd.Next(0, range);
            return n;
        }  //generates a random num in a range
        void drawTable()
        {
            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                Console.Write(' ');
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(table[i, j].ToString() + "   ");
                }
                Console.WriteLine();
            }


        } //draws a formatted table
        char play() {
            Console.WriteLine("Use the AWSD controls:");
            char input = Char.Parse(Console.ReadLine());
            return input;


        } //gets the user input
        bool isGameDone(int[,] table) {
            bool isThereSpace = false;
            bool isThereWin = false;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (table[i, j] == 0)
                    {
                        isThereSpace = true;
                    }
                    if (table[i, j] == 2048)
                    {
                        isThereWin = true;
                    }
                }
            }
            if (isThereWin == true) { Console.WriteLine("You won!"); }
            if (isThereSpace == false) { Console.WriteLine("You lost."); }
            if (isThereWin == true || isThereSpace == false) { return true; } else { return false; }

        } //checks if the player has won or lost
        void playerInput(char input)
        {
            if (input == 'A'){ LEFT(table); }
            else if (input == 'D') { RIGHT(table); }
            else if (input == 'W') { UP(table); }
            else if (input == 'S') { DOWN(table); }
            else { Console.WriteLine("Wrong controls"); }
        }  //A-left D-right W-up S-down, receives the player input
        void spanwRandomNum() {

            int k, m;
            k = randomNum(4); m = randomNum(4);
            if (table[k, m] == 0)
            {
                table[k, m] = 2;
            }
            else { spanwRandomNum(); };


        } //spanws a 2 on a random place

        void UP(int[,] table) 
        {
            
            for (int i = 1; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int k = i;
                    while (k != 0)
                    {
                        if (table[k, j] == table[k - 1, j])
                        {
                            table[k - 1, j] *= 2;
                            table[k, j] = 0;
                            break;
                        }
                        else if ((table[k, j] != table[k - 1, j]) && table[k - 1, j] == 0)
                        {
                            table[k - 1, j] = table[k, j];
                            table[k, j] = 0;
                        }
                        k--;
                    }
                   
                }
            }

            spanwRandomNum();

        }
        void DOWN(int[,] table) 
        {
            for (int i = 2; i >=0 ; i--)
            {
                for (int j = 0; j < 4; j++)
                {
                    int k = i;
                    while (k != 3)
                    {
                        if (table[k, j] == table[k + 1, j])
                        {
                            table[k + 1, j] *= 2;
                            table[k, j] = 0;
                            break;
                        }
                        else if ((table[k, j] != table[k + 1, j]) && table[k + 1, j] == 0)
                        {
                            table[k + 1, j] = table[k, j];
                            table[k, j] = 0;
                        }
                        k++;
                    }
                }
               

            }

            spanwRandomNum();

        }
        void RIGHT(int[,] table) {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 2; j >=0; j--)
                {
                    int k = j;
                    while (k != 3)
                    {
                        if (table[i, k] == table[i, k+1])
                        {
                            table[i, k+1] *= 2;
                            table[i,k] = 0;
                            break;
                        }
                        else if ((table[i,k] != table[i,k+1]) && table[i,k+1] == 0)
                        {
                            table[i, k+1] = table[i,k];
                            table[i,k] = 0;
                        }
                        k++;
                    }
                }
            }
            spanwRandomNum();
        }
        void LEFT(int[,] table) {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 1; j <=3; j++)
                {
                    int k = j;
                    while (k != 0)
                    {
                        if (table[i, k] == table[i, k - 1])
                        {
                            table[i, k - 1] *= 2;
                            table[i, k] = 0;
                            break;
                        }
                        else if ((table[i, k] != table[i, k - 1]) && table[i, k - 1] == 0)
                        {
                            table[i, k - 1] = table[i, k];
                            table[i, k] = 0;
                        }
                        k--;
                    }
                }
            }
            spanwRandomNum();
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            p.blankTable();
            p.drawTable();
           

            while (p.isGameDone(p.table) != true) //while the player hasn't lost or won, the game is running
            {
                p.playerInput(p.play());
                p.drawTable();
            }
            Environment.Exit(0);
        }
    }
}
