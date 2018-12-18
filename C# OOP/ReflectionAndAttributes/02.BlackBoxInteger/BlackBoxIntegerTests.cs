namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            Type classType = typeof(BlackBoxInteger);

            var classInstance = (BlackBoxInteger) Activator.CreateInstance(classType, true);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] args = input.Split('_');
                string currentMethod = args[0];
                int num = int.Parse(args[1]);

                MethodInfo method = classType.GetMethod(currentMethod, BindingFlags.NonPublic | BindingFlags.Instance);
                method.Invoke(classInstance,  new object[] { num });

                var innerValue = classType
                    .GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(classInstance);

                Console.WriteLine(innerValue);
            }

        }
    }
}
