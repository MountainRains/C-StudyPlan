using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace reflectAndAttribute
{
    class Program
    {
        static void ShowHelp(MemberInfo member)
        {
            HelpAttribute a = Attribute.GetCustomAttribute(member, typeof(HelpAttribute)) as HelpAttribute;
            if (a == null)
            {
                Console.WriteLine("No help for {0}", member);
            }
            else
            {
                Console.WriteLine("Help for {0}:", member);
                Console.WriteLine(" Url={0}, Topic={1}", a.Url, a.Topic);
            }
        }
        static void Main(string[] args)
        {
            ShowHelp(typeof(Widget));
            ShowHelp(typeof(Widget).GetMethod("Display"));
        }
    }

    [Help("http://msdn.microsoft.com/.../MyClass.htm")]
    public class Widget
    {
        [Help("http://msdn.microsoft.com/.../MyClass.htm",Topic = "Display")]
        public void Display(string text) { }

    }
}
