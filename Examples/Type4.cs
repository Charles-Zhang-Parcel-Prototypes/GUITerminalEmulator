// TUI (Terminal User Interface)

using System.Text;
StringBuilder results = new();

for(int i = 0; i < Console.WindowWidth; i++)
{
    for(int j = 0; j < Console.WindowHeight; j++)
    {
        Console.CursorLeft = i;
        Console.CursorTop = j;
        Write(' ');
    }
}

while(true)
{
    ConsoleKey key = Console.ReadKey(true).Key;

    switch(key)
    {
        case ConsoleKey.LeftArrow:
            Console.CursorLeft--;
            break;
        case ConsoleKey.RightArrow:
            Console.CursorLeft++;
            break;
        case ConsoleKey.UpArrow:
            Console.CursorTop--;
            break;
        case ConsoleKey.DownArrow:
            Console.CursorTop++;
            break;
        case ConsoleKey.Escape:
            goto End;
        default:
            Console.Write(key.ToString());
            break;
    }

    results.AppendLine(key.ToString());
}

End:
WriteLine("Ended");
File.WriteAllText("Outputs.txt", results.ToString().Trim());