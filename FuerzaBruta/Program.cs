using System;
using System.Globalization;
using System.IO;

namespace FuerzaBruta
{
    class FuerzaBruta
    {
        static string[] _words = [];
        static volatile bool _found;
        [STAThread]
        static void Main(string[] args)
        {
            
            try
            {
                LoadDiccionario();

                string password = GetPasswordRandom();
                
                Thread thread = new Thread(() => GetPassword(password));
                Thread thread2 = new Thread(() => GetPassword2(password));
                
                thread.Start();
                thread2.Start();
                
                thread.Join();
                thread2.Join();

                Console.WriteLine($"Password: {password}");
            }
            catch (IOException e)
            {
                Console.WriteLine("No se ha podido leer el archivo");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Terminado");
            }
        }

        static void GetPassword(string password)
        {
            try
            {
                foreach (var word in _words)
                {
                    if (_found) break;
                    if (word == password)
                    {
                        _found = true;
                        Console.WriteLine($"Password found for 1: {word}");
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
        
        static void GetPassword2(string password)
        {
            try
            {
                foreach (var word in _words.Reverse())
                {
                    if (_found) break;
                    if (word == password)
                    {
                        _found = true;
                        Console.WriteLine($"Password found for 2: {word}");
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

        static void LoadDiccionario()
        {
            using StreamReader reader = new("password.txt");
            string diccionario = reader.ReadToEnd();
            _words = diccionario.Split('\n');
        }
    }
}