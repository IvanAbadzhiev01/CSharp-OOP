using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, string[] fildsName)
        {


            Type type = Type.GetType(className);
            object classInstance = Activator.CreateInstance(type);

            FieldInfo[] fields = type.GetFields((BindingFlags)60);
            StringBuilder sb = new();
            sb.AppendLine($"Class under investigation: {type.FullName}");


            foreach (FieldInfo field in fields)
            {
                if (fildsName.Any(f => f == field.Name))
                {
                    sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
                }
            }
            return sb.ToString().TrimEnd();

        }

        public string AnalyzeAccessModifiers(string className)
        {
            Type type = Type.GetType(className);
            FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] nonPublicMethod = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo[] publicMethod = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            StringBuilder sb = new();
            foreach (FieldInfo fild in fields)
            {
                sb.AppendLine($"{fild.Name} must be private!");
            }
            foreach (MethodInfo method in nonPublicMethod.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} have to be public!");
            }
            foreach (MethodInfo method in publicMethod.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            return sb.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new();
            Type type = Type.GetType(className);
            sb.AppendLine($"All Private Methods of Class: {type.FullName}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");
            MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (MethodInfo method in methodInfos)
            {
                sb.AppendLine($"{method.Name}");
            }
            return sb.ToString().TrimEnd();

        }
    }
}
