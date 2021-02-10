using System;
using System.IO;

namespace BouncyChar
{
    public class Kurzor
    {
        private int x;
        private int y;
        private string currentDirection;
        private static readonly int frameRate = 100;
        private static readonly char cursor = '#';
        private static readonly int bottomBorder = Console.WindowHeight - 1;
        private static readonly int topBorder = 0;
        private static readonly int rightBorder = Console.WindowWidth - 1;
        private static readonly int leftBorder = 0;
        private static readonly string startingDirection = "JOBB_FEL";

        public Kurzor(int x, int y)
        {
            this.x = x;
            this.y = y;
            currentDirection = startingDirection;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(cursor);
            System.Threading.Thread.Sleep(frameRate);
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
        }

        public void Run()
        {
            while (true)
            {
                switch (currentDirection)
                {
                    case "JOBB_FEL":
                        JobbFel();
                        break;
                    case "JOBB_LE":
                        JobbLe();
                        break;
                    case "BAL_FEL":
                        BalFel();
                        break;
                    case "BAL_LE":
                        BalLe();
                        break;
                }

                Draw();
            }
        }

        public void JobbFel()
        {
            if (RightBorderHit())
            {
                currentDirection = "BAL_FEL";
            } else if (TopBorderHit())
            {
                currentDirection = "JOBB_LE";
            } else
            {
                x += 1;
                y -= 1;
            }
        }

        public void JobbLe()
        {
            if (RightBorderHit())
            {
                currentDirection = "BAL_LE";
            }
            else if (BottomBorderHit())
            {
                currentDirection = "JOBB_FEL";
            }
            else
            {
                x += 1;
                y += 1;
            }
        }

        public void BalFel()
        {
            if (LeftBorderHit())
            {
                currentDirection = "JOBB_FEL";
            }
            else if (TopBorderHit())
            {
                currentDirection = "BAL_LE";
            }
            else
            {
                x -= 1;
                y -= 1;
            }
        }

        public void BalLe()
        {
            if (LeftBorderHit())
            {
                currentDirection = "JOBB_LE";
            }
            else if (BottomBorderHit())
            {
                currentDirection = "BAL_FEL";
            }
            else
            {
                x -= 1;
                y += 1;
            }
        }

        private bool TopBorderHit()
        {
            return (y - 1) < topBorder;
        }

        private bool BottomBorderHit()
        {
            return (y + 1) > bottomBorder;
        }

        private bool RightBorderHit()
        {
            return (x + 1) > rightBorder;
        }

        private bool LeftBorderHit()
        {
            return (x - 1) < leftBorder;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            int x = Console.WindowWidth / 2;
            int y = Console.WindowHeight / 2;

            Console.CursorVisible = false;

            Kurzor c = new Kurzor(x, y);

            c.Run();
        }
    }
}
