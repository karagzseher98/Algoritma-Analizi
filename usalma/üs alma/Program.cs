using System;

class Program
{
    static void Main()
    {
        Console.Write("Tabanı ve üssü girin (örneğin, 2^3 için 2 3): ");
        string[] input = Console.ReadLine().Split(' ');

        if (input.Length == 2 && double.TryParse(input[0], out double taban) && int.TryParse(input[1], out int us))
        {
            Console.WriteLine($"{taban}^{us} = {UsAl(taban, us)}");
        }
        else
        {
            Console.WriteLine("Hatalı giriş!");
        }

        Console.ReadLine();
    }

    static double UsAl(double taban, int us) => (us == 0) ? 1 : (us > 0) ? taban * UsAl(taban, us - 1) : 1 / (taban * UsAl(taban, -us - 1));
}
