using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fildsName)
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
    }
}
