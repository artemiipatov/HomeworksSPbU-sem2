Console.Write("Instructions:\nType -ct to compress using bwt\nType -cf to compress without bwt\nType -u to decompress\nType -e to exit\n");
while (true)
{
    Console.Write("Input key: ");
    string? key = Console.ReadLine();
    switch (key)
    {
        case "-ct":
        {
            Console.Write("Path: ");
            string? path = Console.ReadLine();
            if (path == null)
            {
                Console.WriteLine("Wrong input data: null path");
                return;
            }
            Console.WriteLine(Lzw.Lzw.Compress(path, true));
            break;
        }
        case "-cf":
            {
                Console.Write("Path: ");
                string? path = Console.ReadLine();
                if (path == null)
                {
                    Console.WriteLine("Wrong input data: null path");
                    return;
                }
                Console.WriteLine(Lzw.Lzw.Compress(path, false));
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