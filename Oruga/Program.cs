using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        int width = 40;
        int height = 20;

        while (true)
        {
            PlayGame(width, height);

            Console.SetCursorPosition(0, height + 2);
            Console.WriteLine("Juego terminado. Presiona 'r' para reiniciar o cualquier otra tecla para salir.");
            var key = Console.ReadKey(true).Key;
            if (key != ConsoleKey.R)
            {
                break;
            }
        }
    }

    static void PlayGame(int width, int height)
    {
        int score = 0;
        int speed = 100;
        bool gameOver = false;

        Snake snake = new Snake(width / 2, height / 2);
        Food food = new Food(width, height);

        while (!gameOver)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                snake.ChangeDirection(key.Key);
            }

            snake.Move();

            if (snake.HeadX == food.X && snake.HeadY == food.Y)
            {
                snake.Grow();
                food.GenerateNewPosition(snake, width, height);
                score++;
                speed = Math.Max(10, speed - 2);
            }

            if (snake.HeadX < 0 || snake.HeadX >= width || snake.HeadY < 0 || snake.HeadY >= height || snake.IsCollision())
            {
                gameOver = true;
            }

            Console.Clear();
            DrawBorder(width, height);
            snake.Draw();
            food.Draw();
            Console.SetCursorPosition(0, height + 1);
            Console.WriteLine($"Puntuación: {score}");
            Thread.Sleep(speed);
        }
    }


    static void DrawBorder(int width, int height)
    {
        for (int x = 0; x < width; x++)
        {
            Console.SetCursorPosition(x, 0);
            Console.Write("#");
            Console.SetCursorPosition(x, height - 1);
            Console.Write("#");
        }

        for (int y = 0; y < height; y++)
        {
            Console.SetCursorPosition(0, y);
            Console.Write("#");
            Console.SetCursorPosition(width - 1, y);
            Console.Write("#");
        }
    }
}

class Snake
{
    private List<(int X, int Y)> body;
    private int directionX;
    private int directionY;

    public int HeadX => body.First().X;
    public int HeadY => body.First().Y;

    public Snake(int startX, int startY)
    {
        body = new List<(int X, int Y)> { (startX, startY) };
        directionX = 1;
        directionY = 0;
    }

    public void ChangeDirection(ConsoleKey key)
    {
        switch (key)
        {
            case ConsoleKey.UpArrow:
                if (directionY == 0)
                {
                    directionX = 0;
                    directionY = -1;
                }
                break;
            case ConsoleKey.DownArrow:
                if (directionY == 0)
                {
                    directionX = 0;
                    directionY = 1;
                }
                break;
            case ConsoleKey.LeftArrow:
                if (directionX == 0)
                {
                    directionX = -1;
                    directionY = 0;
                }
                break;
            case ConsoleKey.RightArrow:
                if (directionX == 0)
                {
                    directionX = 1;
                    directionY = 0;
                }
                break;
        }
    }

    public void Move()
    {
        (int X, int Y) newHead = (HeadX + directionX, HeadY + directionY);
        body.Insert(0, newHead);
        body.RemoveAt(body.Count - 1);
    }

    public void Grow()
    {
        (int X, int Y) newHead = (HeadX + directionX, HeadY + directionY);
        body.Insert(0, newHead);
    }

    public bool IsCollision()
    {
        (int X, int Y) head = body.First();
        return body.Skip(1).Any(segment => segment.X == head.X && segment.Y == head.Y);
    }

    public void Draw()
    {
        foreach ((int X, int Y) segment in body)
        {
            Console.SetCursorPosition(segment.X, segment.Y);
            Console.Write("O");
        }
    }
}

class Food
{
    private Random random;
    public int X { get; private set; }
    public int Y { get; private set; }

    public Food(int width, int height)
    {
        random = new Random();
        GenerateNewPosition(width, height);
    }

    public void GenerateNewPosition(int width, int height)
    {
        X = random.Next(1, width - 1);
        Y = random.Next(1, height - 1);
    }

    public void GenerateNewPosition(Snake snake, int width, int height)
    {
        do
        {
            X = random.Next(1, width - 1);
            Y = random.Next(1, height - 1);
        } while (snake.IsCollision());
    }

    public void Draw()
    {
        Console.SetCursorPosition(X, Y);
        Console.Write("*");
    }
}

