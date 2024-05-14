using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Project
{

    // can you use exception to change program flow as a return
    public class StupidLittleFuckwit
    {
        public static int PromptInt(string message)
        {
            while (true)
            {
                Console.WriteLine(message);
                var input = Console.ReadLine();
                try
                {
                    var number = ParseInt(input);
                    return number;
                }
                catch (Exception e)
                {
                }
            }
        }

        public static int ParseInt(string intStr)
        {
            if (string.IsNullOrEmpty(intStr)) throw new NotImplementedException("intStr must be non-null and non-empty");
            int parsed;
            if (!int.TryParse(intStr, out parsed)) throw new ArgumentException("intStr isn't a number");
            return parsed;
        }

        public static void Foo()
        {
            try
            {
                throw new Exception("This method isn't finished");
                throw new NotImplementedException();
            }
            catch (NotImplementedException)
            {

            }
            catch
            {

            }

        }
    }
}