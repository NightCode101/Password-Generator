using System;
using System.Text;

public class PasswordGenerator
{
    public static void Main()
    {
        bool generateAgain = true;

        while (generateAgain)
        {
            Console.Clear();
            Console.WriteLine("          SIMPLE PASSWORD GENERATOR   ");
            Console.WriteLine(">-------------------------------------------<\n");

            Console.Write("  Password Length: ");
            int length = int.Parse(Console.ReadLine());


            Console.Clear();

            Console.WriteLine("          SIMPLE PASSWORD GENERATOR   ");
            Console.WriteLine(">-------------------------------------------<\n");

            string password = GeneratePassword(length);
            Console.WriteLine($"  Generated Password: {password}");


            Console.Write("\n  Generate another password? (Y/N): ");
            string response = Console.ReadLine().Trim().ToUpper();

            if (response != "Y")
            {
                generateAgain = false;
            }
        }

        Console.WriteLine("\n  Thank you for using the password generator!");
        Console.ReadLine();
    }

    public static string GeneratePassword(int length)
    {
        const string lower = "abcdefghijklmnopqrstuvwxyz";
        const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string digits = "0123456789";
        const string special = "!@#$%^&*()";

        string allChars = lower + upper + digits + special;

        StringBuilder password = new StringBuilder();
        Random random = new Random();

        password.Append(lower[random.Next(lower.Length)]);
        password.Append(upper[random.Next(upper.Length)]);
        password.Append(digits[random.Next(digits.Length)]);
        password.Append(special[random.Next(special.Length)]);

        for (int i = 4; i < length; i++)
        {
            password.Append(allChars[random.Next(allChars.Length)]);
        }

        char[] passwordArray = password.ToString().ToCharArray();
        for (int i = passwordArray.Length - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            char temp = passwordArray[i];
            passwordArray[i] = passwordArray[j];
            passwordArray[j] = temp;
        }

        return new string(passwordArray);
    }
}
