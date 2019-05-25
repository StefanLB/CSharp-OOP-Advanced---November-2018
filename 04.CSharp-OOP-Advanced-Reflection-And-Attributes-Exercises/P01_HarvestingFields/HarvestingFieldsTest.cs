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
            Type type = typeof(HarvestingFields);
            var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

            string input;

            FieldInfo[] fields = type.GetFields(flags);

            while ((input=Console.ReadLine())!="HARVEST")
            {
                //List<FieldInfo> fieldsToPrint = new List<FieldInfo>();

                //if (input=="public")
                //{
                //    fieldsToPrint = fields.Where(x => x.IsPublic).ToList();
                //}
                //else if (input=="protected")
                //{
                //    fieldsToPrint = fields.Where(x => x.IsFamily).ToList();
                //}
                //else if (input =="private")
                //{
                //    fieldsToPrint = fields.Where(x => x.IsPrivate).ToList();
                //}
                //else
                //{
                //    fieldsToPrint = fields.Where(x => (!x.IsStatic)).ToList();
                //}

                FieldInfo[] fieldsToPrint = fields
                    .Where(f => f.Attributes
                        .ToString()
                        .ToLower()
                        .Replace("family","protected") == input)
                    .ToArray();

                if (input=="all")
                {
                    fieldsToPrint = fields.Where(x=>(!x.IsStatic)).ToArray();
                }

                foreach (FieldInfo field in fieldsToPrint)
                {
                    Console.WriteLine($"{field.Attributes.ToString().ToLower().Replace("family","protected")} {field.FieldType.Name} {field.Name}");
                }
            }
        }
    }
}
