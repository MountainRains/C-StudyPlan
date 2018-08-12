using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflect_attribute
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dateTime = new DateTime();

            Type type = dateTime.GetType();
            foreach (System.Reflection.PropertyInfo property in type.GetProperties())
            {
                Console.WriteLine(property.Name);
            }
        }
    }
}
