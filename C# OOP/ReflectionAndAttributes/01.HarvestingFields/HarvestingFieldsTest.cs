namespace P01_HarvestingFields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            FieldInfo[] allFields = typeof(HarvestingFields)
                .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            IEnumerable<FieldInfo> fields = null;

            string command;
            while ((command = Console.ReadLine()) != "HARVEST")
            {
                switch (command)
                {
                    case "private":                        
                            fields = allFields.Where(p => p.IsPrivate);                        
                        break;

                    case "public":
                        fields = allFields.Where(p => p.IsPublic);
                        break;

                    case "protected":
                        fields = allFields.Where(p => p.IsFamily);
                        break;

                    case "all":
                        fields = allFields;
                        break;
                }

                foreach (var field in fields)
                {
                    Print(field);
                }
            }
        }

        private static void Print(FieldInfo field)
        {
            string access = field.Attributes.ToString();

            switch (field.Attributes)
            {
                case FieldAttributes.Family:
                    access = "protected";
                    break;
             
                case FieldAttributes.Private:
                    access = "private";
                    break;
                    
                case FieldAttributes.Public:
                    access = "public";
                    break;                
            }

            Console.WriteLine($"{access} {field.FieldType.Name} {field.Name}");
        }
    }
}
