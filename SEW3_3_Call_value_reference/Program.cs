namespace SEW3_3_Call_value_reference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void SwapD(double a, double b)
            {
                double temp = a;
                a = b;
                b = temp;
            }

            void SwapDRef(ref double a, ref double b)
            {
                double temp = a;
                a = b;
                b = temp;
            }

            void SwapS(Student a, Student b)
            {
                Student temp = a;
                a = b;
                b = temp;
            }

            void SwapSRef(ref Student a, ref Student b)
            {
                Student temp = a;
                a = b;
                b = temp;
            }

            void SwapSName(Student a, Student b)
            {
                string name = a.Name;
                a.Name = b.Name;
                b.Name = name;
            }

            void generateNumber(out int number)
            {
                number = 1;
            }

            void generateNumbers(out int[] numbers)
            {
                numbers = new int[3];
                for (int i = 0; i < numbers.Length; i++)
                {
                    numbers[i] = i * 2;
                }
            }

            double a = 5;
            double b = 4;
            SwapD(a, b);
            Console.WriteLine("a = " + a + " b = " + b);
            SwapDRef(ref a, ref b);
            Console.WriteLine("a = " + a + " b = " + b);

            Student max = new Student() { Name = "Max" };
            Student sep = new Student() { Name = "Sep" };
            SwapS(max, sep);
            Console.WriteLine("max = " + max.Name);
            Console.WriteLine("sep = " + sep.Name);
            SwapSRef(ref max, ref sep);
            Console.WriteLine("max = " + max.Name);
            Console.WriteLine("sep = " + sep.Name);
            SwapSName(max, sep);
            Console.WriteLine("max = " + max.Name);
            Console.WriteLine("sep = " + sep.Name);
            int n;
            //Console.WriteLine(n.ToString());    // Compilerfehler
            generateNumber(out n);
            Console.WriteLine(n.ToString());
            int[] numbers;
            //Console.WriteLine(numbers[0].ToString());    // Compilerfehler
            generateNumbers(out numbers);
            Console.WriteLine(numbers[0].ToString());
        }
    }
    public class Student
    {
        public string Name { get; set; }
    }
}