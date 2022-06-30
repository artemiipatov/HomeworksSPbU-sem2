static void Main(string[] args)
{
    switch (args[0])
    {
        case "-ct":
        {
            if (args.Length == 1 || args[1] == null)
            {
                Console.WriteLine("Wrong input data: null path");
                return;
            }
            Console.WriteLine(Lzw.Lzw.Compress(args[1], true));
            return;
        }
        case "-cf":
        {
            if (args.Length == 1 || args[1] == null)
            {
                Console.WriteLine("Wrong input data: null path");
                return;
            }
            Console.WriteLine(Lzw.Lzw.Compress(args[1], false));
            return;
        }
        case "-u":
        {
            if (args.Length == 1 || args[1] == null)
            {
                Console.WriteLine("Wrong input data: null path");
                return;
            }
            Lzw.Lzw.Decompress(args[1]);
            return;
        }
        default:
        {
            Console.WriteLine("Wrong input, read instructions carefully");
            return;
        }
    }
}