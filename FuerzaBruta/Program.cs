using System;
using System.IO;

namespace FuerzaBruta
{
    class Class1
    {
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                // Open the text file using a stream reader.
                using StreamReader reader = new("C:\\Users\\UsuarioT\\RiderProjects\\FuerzaBruta\\FuerzaBruta\\password.txt");

                // Read the stream as a string.
                string text = reader.ReadToEnd();

                // Write the text to the console.
                Console.WriteLine(text);
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
    }
}