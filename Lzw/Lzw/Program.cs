Console.Write("Instructions:\nType -c to compress\nType -u to decompress\nType -e to exit\n");
while (true)
{
    Console.Write("Input key: ");
    string? key = Console.ReadLine();
    switch (key)
    {
        case "-c":
        {
            Console.Write("Path: ");
            string? path = Console.ReadLine();
            if (path == null)
            {
                Console.WriteLine("Wrong input data: null path");
                return;
            }
            Lzw.Lzw.Compress(path);
            break;
        }
        case "-u":
        {
            Console.Write("Path: ");
            string? path = Console.ReadLine();
            if (path == null)
            {
                Console.WriteLine("Wrong input data: null path");
                return;
            }
            Lzw.Lzw.Decompress(path);
            break;
        }
        case "-e":
        {
            Console.WriteLine("exiting...");
            return;
        }
        default:
        {
            Console.WriteLine("Wrong input, read instructions carefully");
            break;
        }
    }
}