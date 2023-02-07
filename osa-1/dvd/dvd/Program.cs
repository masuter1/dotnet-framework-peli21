using System;
using System.Threading;

class Program
{
    public static void Main(string[] args)
    {
        int width = Console.WindowWidth;
        int height = Console.WindowHeight;

        int center_x = width / 2;
        int center_y = height / 2;

        int speed_x = 1;
        int speed_y = 1;
        int text_x = center_x;
        int text_y = center_y;

        Console.BackgroundColor = ConsoleColor.DarkRed;
        Console.ForegroundColor = ConsoleColor.White;

        while(true)
        {
            Thread.Sleep(33);
            text_x += speed_x;
            text_y += speed_y;

            int text_width = 3;
            if (text_x >= width - text_width)
            {
                text_x = width - text_width;
                speed_x *= -1;
            }
            if (text_x <= 0)
            {
                text_x = 0;
                speed_x *= -1;
            }
            if (text_y >= height)
            {
                text_y = height;
                speed_y *= -1;
            }
            if (text_y <= 1)
            {
                text_y = 1;
                speed_y *= -1;
            }
            Console.Clear();
            Console.SetCursorPosition(text_x, text_y);
            Console.Write("DVD");
        }
    }
}