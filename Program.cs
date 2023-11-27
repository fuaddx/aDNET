using AdoNet.Services;

namespace AdoNet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine($"Password hash: {UserService.HashPasword("clear_password", out var salt)}");
            Console.WriteLine($"Generated salt: {Convert.ToHexString(salt)}");
        }
    }
}