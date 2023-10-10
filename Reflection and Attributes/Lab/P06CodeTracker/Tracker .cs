using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AuthorProblem
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            Type type = typeof(StartUp);
            MethodInfo[] methodInfos = type.GetMethods((BindingFlags)60);
            foreach (MethodInfo methodInfo in methodInfos)
            {
                if (methodInfo.CustomAttributes.Any(n => n.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = methodInfo.GetCustomAttributes(false);
                    foreach (AuthorAttribute attribute in attributes)
                    {
                        Console.WriteLine($"{methodInfo.Name} is written by {attribute.Name}");

                    }
                }
            }
        }
    }
}
