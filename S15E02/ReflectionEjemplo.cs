﻿using System.ComponentModel;
using System.Net;
using System.Reflection;

namespace App06
{
    public class ReflectionEjemplo
    {
        private static void ListGenericMethods(Type type)
        {
            var metodos = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine($"Metodos son del tipo {type.Name}");
            Console.WriteLine("Nombre     |IsGeneric       |IsGenericDef     |ContainsGenParam");
            int colWidth = 12;

            foreach ( var metod in metodos )
            {
                int maxNombreLength = Math.Min(metod.Name.Length, colWidth);
                Console.Write(metod.Name.Substring(0, maxNombreLength).PadRight(colWidth));
                Console.Write("|");
                Console.Write(metod.IsGenericMethod.ToString().PadRight(colWidth));
                Console.Write("|");
                Console.Write(metod.IsGenericMethodDefinition.ToString().PadRight(colWidth));
                Console.Write("|");
                Console.WriteLine(metod.ContainsGenericParameters.ToString().PadRight(colWidth));
            }
            Console.WriteLine();
        }

        private static void ListTypeDetails(List<Type> types)
        {
            Console.WriteLine("Type Nombre".PadRight(20) + "|" + "IsGenericType?".PadRight(20)
                + "|" + "IsGenericDefinition".PadRight(20)
                );

            foreach (var type in types)
            {
                string output = type.Name.PadRight(20) + "|";
                output += type.IsGenericType.ToString().PadRight(20) + "|";
                output += type.IsGenericTypeDefinition;

                ListGenericMethods(type);
                Console.WriteLine(output);
            }

        }
        
        public static void execute()
        {
            var types = new List<Type>
            {
                typeof(IProcessor<>),
                typeof(IProcessor<Cliente>),
                typeof(Processor<>),
                typeof(Processor<Cliente>),
                typeof(ClienteProcessor)
            };

            ListTypeDetails(types);
           
        }
    }
}
