internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Console.WriteLine($"short - size: {sizeof(short)}");

        Console.WriteLine($"{Convert.ToString(int.MaxValue, 2)}");
        char c = "c";
        string s = "string";
        string s = "abcd";
        byte[] bm = new byte [8];
        Console.WriteLine($"{bm}");
    }
}