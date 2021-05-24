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
        }
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
                Console.Write('|');
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(table[i, j].ToString() + " | ");
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

        }
        void playerInput(char input)
        {
            if (input == 'A'){ moveLeft(table,0); }
            else if (input == 'D') { moveRight(table, 3); }
            else if (input == 'W') { moveUp(table, 0); }
            else if (input == 'S') { moveDown(table, 3); }
            else { Console.WriteLine("Wrong controls"); }
        }  //A-left D-right W-up S-down
        void spanwRandomNum() {

            int k, m;
            k = randomNum(4); m = randomNum(4);
            if (table[k, m] == 0)
            {
                table[k, m] = 2;
            }
            else { spanwRandomNum(); };


        } //spanws a 2 on a random place
        void moveLeft(int[,] table, int _j)
        {
            int zeroCount=0;
            for (int i = 0; i <4; i++)
            {
                while (true)
                {
                    if (table[i, _j] == 0) //recognizes a zero
                    {
                        zeroCount++;
                        _j++;
                    }
                    else //recognizes a number 
                    {
                        if (zeroCount != 0) //moves a number over zeros
                        {
                            table[i, _j - 1 * zeroCount] = table[i, _j];
                            table[i, _j] = 0;
                            if (_j!=0 && zeroCount<_j && table[i, _j - (1 * zeroCount)] != table[i, _j - (1 * zeroCount) - 1])
                            {
                                _j++;
                            }
                            

                        }
                        if (_j - 1 * zeroCount != 0) // it sums the numbers if it needs to
                        {
                            if (table[i, _j - 1 * zeroCount] == table[i, _j - (1 * zeroCount) - 1])
                            {
                                table[i, _j - (1 * zeroCount) - 1] *= 2;
                                table[i, _j - 1 * zeroCount] = 0;
                            }
                        }
                        else if((_j - 1 * zeroCount != 0)==false && (zeroCount != 0)==false)
                        { _j++; } //regognizes a number, that doesn't need to be moved
                    }
                  
                   
                    if (_j>3){ _j = 0; zeroCount = 0; break;}
                }
                
            }
            spanwRandomNum();

        } 

        void moveRight(int[,] table, int _j)
        {
            int zeroCount = 0;
            for (int i = 3; i >=0; i--)
            {
                while (true)
                {
                    if (table[i, _j] == 0) //recognizes a zero
                    {
                        zeroCount++;
                        _j--;
                    }
                    else //recognizes a number 
                    {
                        if (zeroCount != 0) //moves a number over zeros
                        {
                            table[i, _j +  zeroCount] = table[i, _j];
                            table[i, _j] = 0;
                            

                        }
                        if (_j + zeroCount != 3) // it sums the numbers if it needs to
                        {
                            if (_j == -1)
                            {
                                _j = 0;
                            }
                            if (table[i, _j + zeroCount + 1] == table[i, _j + zeroCount])
                            {
                                table[i, _j +  zeroCount+ 1] *= 2;
                                table[i, _j + zeroCount] = 0;
                            }
                            _j--;
                        }
                        else if((_j + 1 * zeroCount != 3)==false && (zeroCount != 0)==false)
                        { _j--; } //regognizes a number, that doesn't need to be moved
                    }


                    if (_j <0) { _j = 3; zeroCount = 0; break; }
                }

            }
            spanwRandomNum();

        }
        void moveUp(int[,] table, int i)
        {
            int zeroCount = 0;
            for (int _j = 0; _j <4; _j++)
            {
                while (true)
                {
                    if (table[i, _j] == 0) //recognizes a zero
                    {
                        zeroCount++;
                        i++;
                    }
                    else //recognizes a number 
                    {
                        if (zeroCount != 0) //moves a number over zeros
                        {
                            table[i - 1 * zeroCount, _j] = table[i, _j];
                            table[i, _j] = 0;
                            if (i != 0 && zeroCount < i && table[i - (1 * zeroCount), _j] != table[i - (1 * zeroCount)-1, _j])
                            {
                                i++;
                            }


                        }
                        if (i - 1 * zeroCount != 0) // it sums the numbers if it needs to
                        {
                            if (table[i - 1 * zeroCount, _j] == table[i - (1 * zeroCount) - 1, _j])
                            {
                                table[i - (1 * zeroCount) - 1, _j] *= 2;
                                table[i - 1 * zeroCount, _j] = 0;
                            }
                        }
                        else if ((i - 1 * zeroCount != 0) == false && (zeroCount != 0) == false)
                        { i++; } //regognizes a number, that doesn't need to be moved
                    }


                    if (i > 3) { i = 0; zeroCount = 0; break; }
                }

            }
            spanwRandomNum();

        }
        void moveDown(int[,] table, int i)
        {
            int zeroCount = 0;
            for (int _j = 3; _j >= 0; _j--)
            {
                while (true)
                {
                    if (table[i, _j] == 0) //recognizes a zero
                    {
                        zeroCount++;
                        i--;
                    }
                    else //recognizes a number 
                    {
                        if (zeroCount != 0) //moves a number over zeros
                        {
                            table[i + 1 * zeroCount, _j] = table[i, _j];
                            table[i, _j] = 0;
                            if (i != 3 && zeroCount <= 3-i && table[i + (1 * zeroCount), _j] != table[i + (1 * zeroCount) - 1, _j])
                            {
                                i--;
                            }


                        }
                        if (i + 1 * zeroCount != 3) // it sums the numbers if it needs to
                        {
                            if (i==-1)
                            {
                                i = 0;
                            }
                            if (table[i + 1 * zeroCount, _j] == table[i + (1 * zeroCount) + 1, _j])
                            {
                                table[i + (1 * zeroCount) + 1, _j] *= 2;
                                table[i + 1 * zeroCount, _j] = 0;
                            }
                        }
                        else if ((i + 1 * zeroCount != 3) == false && (zeroCount != 0) == false)
                        { i--; } //regognizes a number, that doesn't need to be moved
                    }


                    if (i <0) { i = 3; zeroCount = 0; break; }
                }

            }
            spanwRandomNum();

        }

        static void Main(string[] args)
        {
            Program p = new Program();
            p.blankTable();
            p.drawTable();
           

            while (p.isGameDone(p.table) != true)
            {
                p.playerInput(p.play());
                p.drawTable();
            }
            Environment.Exit(0);
        }
    }
}
