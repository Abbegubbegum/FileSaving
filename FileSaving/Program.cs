using System;
using System.IO;
using System.Text.Json;


class Program
{
    static void Main(string[] args)
    {

        Box b1 = new Box();
        // {
        //     X = 100,
        //     Y = 200,
        //     Label = "stuff"
        // };

        bool gameLoop = true;

        while (gameLoop)
        {
            Console.WriteLine("What?");
            Console.WriteLine("1-Save\n2-Load\n3-Change\n4-Check\n5-Exit");
            switch (Console.ReadLine())
            {
                case "1":
                    SaveBox(b1);
                    break;

                case "2":
                    b1 = LoadBox();
                    break;
                case "3":
                    SetValue(b1);
                    break;
                case "4":
                    CheckValues(b1);
                    break;
                case "5":
                    gameLoop = false;
                    break;
            }
        }

    }

    static void CheckValues(Box b)
    {
        Console.WriteLine($"X:{b.X}, Y:{b.Y}, Label:{b.Label}");
    }

    static void SaveBox(Box b)
    {
        File.WriteAllText("box.json", JsonSerializer.Serialize<Box>(b));
    }

    static Box LoadBox()
    {
        return JsonSerializer.Deserialize<Box>(File.ReadAllText("box.json"));
    }

    static void SetValue(Box b)
    {
        Console.WriteLine("X then Y then Label");
        b.X = int.Parse(Console.ReadLine());
        b.Y = int.Parse(Console.ReadLine());
        b.Label = Console.ReadLine();
    }
}

