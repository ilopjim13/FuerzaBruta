using System;
using System.Globalization;
using System.IO;

namespace FuerzaBruta
{
    class FuerzaBruta
    {
        static string[] _words = [];
        static bool _found = false;
        [STAThread]
        static void Main(string[] args)
        {
            
            try
            {
                using StreamReader reader = new("password.txt");

                string diccionario = reader.ReadToEnd();
                
                _words = diccionario.Split('\n');

                string password = GetPasswordRandom();
                
                Thread thread = new Thread(() => GetPassword(password));
                
                thread.Start();
                
                thread.Join();

                Console.WriteLine($"Palabra aleatoria: {password}");
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        static void GetPassword(string password)
        {
            try
            {
                using StreamReader reader = new("password.txt");
                foreach (var word in _words)
                {
                    if (word == password)
                    {
                        _found = true;
                        Console.WriteLine($"Password found: {word}");
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        static string GetPasswordRandom()
        {
            Random rnd = new();
            return _words[rnd.Next(_words.Length)];
        }
    }
}