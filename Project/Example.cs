using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

    public class Car
    {
        // static
        public static string VehicleType = "Car";
        // instance
        public string Model;

        // Doesn't work because we can't access instance-level fields in a static context
        public static void Print(string variableName, Car car)
        {
            Console.WriteLine(variableName + ": " + Car.VehicleType + " - " + car.Model);
        }

        public void PrintInstanced(string variableName)
        {
            Console.WriteLine(variableName + ": " + Car.VehicleType + " - " + this.Model);
        }

        public List<int> SomeNumberStuffWithLists()
        {
            var numStr = "1,2,3";
            var numbers = numStr.Split(",").Select(n => int.Parse(n)).ToList();
            var arr = new int[0];
            var counter = 0;
            foreach (var n in numbers)
            {
                Array.Resize(ref arr, arr.Length + 1);
                arr[counter] = numbers[counter];
                counter++;
            }

            var list = new List<int>();
            foreach (var n in numbers)
            {
                list.Add(n);
            }
            return list;
        }
    }

    public class Factory
    {
        public static void MakeCars()
        {
            var volvo = new Car { Model = "Volvo" };
            Car.Print("volvo", volvo);
            volvo.PrintInstanced(nameof(volvo));
            var tesla = new Car { Model = "Tesla" };
            tesla.PrintInstanced(nameof(tesla));
            var ferrari = new Car { Model = "Ferrari" };
            ferrari.PrintInstanced(nameof(ferrari));
            volvo.Model = "Prius";
            volvo.PrintInstanced(nameof(volvo));
            tesla.PrintInstanced(nameof(tesla));
            ferrari.PrintInstanced(nameof(ferrari));
            Car.VehicleType = "Automobile";
            volvo.PrintInstanced(nameof(volvo));
            tesla.PrintInstanced(nameof(tesla));
            ferrari.PrintInstanced(nameof(ferrari));
        }
    }
}