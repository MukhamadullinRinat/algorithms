using System;
using System.Collections;
using System.Reflection;

namespace TestDevSkiller
{
    public class ObjectPrinter
    {
        public List<string> Print(object obj)
        {
            var result = new List<string>();
            PrintRecursive(obj, 0, result);
            return result;
        }

        private void PrintRecursive1(object obj, int level, List<string> result)
        {
            if (obj == null)
            {
                result.Add(new string('*', level) + "null");
                return;
            }

            if (obj is string || obj.GetType().IsPrimitive)
            {
                result.Add(new string('*', level) + obj);
                return;
            }

            if (obj is IEnumerable enumerable && !(obj is string))
            {
                foreach (var item in enumerable)
                {
                    PrintRecursive1(item, level + 1, result);
                }
                return;
            }

            var type = obj.GetType();
            foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var value = prop.GetValue(obj);
                if (value is IEnumerable && !(value is string))
                {
                    foreach (var item in (IEnumerable)value)
                    {
                        PrintRecursive1(item, level + 1, result);
                    }
                }
                else
                {
                    result.Add(new string('*', level) + value);
                }
            }
        }

        private void PrintRecursive(object? obj, int level, List<string> result)
        {
            if (obj == null)
            {
                result.Add(new string('*', level) + "null");
                return;
            }

            if (obj.GetType().IsPrimitive || obj is string)
            {
                result.Add(new string('*', level) + obj.ToString());
                return;
            }

            if (obj is IEnumerable enumerable)
            {
                foreach (var item in enumerable)
                {
                    PrintRecursive(item, level + 1, result);
                }
                return;
            }

            var type = obj.GetType();

            foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var value = prop.GetValue(obj);

                if (value == null || value.GetType().IsPrimitive || value is string)
                    PrintRecursive(value, level, result);
                else
                    PrintRecursive(value, level + 1, result);
            }
        }
    }
}
