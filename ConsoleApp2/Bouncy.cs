using System;

namespace BouncyChar
{
    public class Ball
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
        private static readonly string startingDirection = "RIGHT_UP";

        public Ball(int x, int y)
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
                    case "RIGHT_UP":
                        RightAndUp();
                        break;
                    case "RIGHT_DOWN":
                        RightAndDown();
                        break;
                    case "LEFT_UP":
                        LeftAndUp();
                        break;
                    case "LEFT_DOWN":
                        LeftAndDown();
                        break;
                }

                Draw();
            }
        }

        public void RightAndUp()
        {
            if (RightBorderHit())
            {
                currentDirection = "LEFT_UP";
            } else if (TopBorderHit())
            {
                currentDirection = "RIGHT_DOWN";
            } else
            {
                x += 1;
                y -= 1;
            }
        }

        public void RightAndDown()
        {
            if (RightBorderHit())
            {
                currentDirection = "LEFT_DOWN";
            }
            else if (BottomBorderHit())
            {
                currentDirection = "RIGHT_UP";
            }
            else
            {
                x += 1;
                y += 1;
            }
        }

        public void LeftAndUp()
        {
            if (LeftBorderHit())
            {
                currentDirection = "RIGHT_UP";
            }
            else if (TopBorderHit())
            {
                currentDirection = "LEFT_DOWN";
            }
            else
            {
                x -= 1;
                y -= 1;
            }
        }

        public void LeftAndDown()
        {
            if (LeftBorderHit())
            {
                currentDirection = "RIGHT_DOWN";
            }
            else if (BottomBorderHit())
            {
                currentDirection = "LEFT_UP";
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

    class Bouncy
    {
        static void Main()
        {
            int startingX = Console.WindowWidth / 2;
            int startingY = Console.WindowHeight / 2;

            Console.CursorVisible = false;

            Ball bouncyBall = new Ball(startingX, startingY);

            bouncyBall.Run();
        }
    }
}
