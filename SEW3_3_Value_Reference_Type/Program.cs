namespace SEW3_3_Value_Reference_Type
{
    internal class Program
    {
        static void Main(string[] args)
        {
            void ChangeValue(int x)
            {
                x = 200;

                Console.WriteLine(x);
            }

            void ChangeReferenceType(Student std2)
            {
                std2.Name = "Steve";
            }

            // value type
            int i = 100;
            Console.WriteLine(i);
            ChangeValue(i);
            Console.WriteLine(i);

            // reference type
            Student bill = new Student();
            //Console.WriteLine(bill.Name); Name is here null
            //if (bill.Name == null)
            //{
            //    Console.WriteLine("bill.Name = null");
            //}
            bill.Name = "Bill";
            Console.WriteLine(bill.Name);
            ChangeReferenceType(bill);
            Console.WriteLine(bill.Name);
        }
    }
    public class Student
    {
        private string name;
        public string Name { get { return name; } set { name = value; } }

    }
}