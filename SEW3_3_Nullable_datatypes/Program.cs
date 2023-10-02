namespace SEW3_3_Nullable_datatypes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string myString = "";
            //Console.WriteLine(myString.Length);   // Fehler
            if (myString != null)
            {
                Console.WriteLine(myString.Length);
            }

            string? myNullableString = null;
            //Console.WriteLine(myNullableString.Length); // Fehler
            if (myNullableString != null)
            {
                Console.WriteLine(myNullableString.Length);
            }

            //int i = null;           // nicht möglich
            int? i = null;          // "noch" kein Wert zugewiesen

            Console.WriteLine(i.ToString());    // kein Fehler
            //int j = i * 5;                      // nicht möglich, weil möglicherweise NULL
            if (i.HasValue)
            {
                int j = i.Value * 5;            // Zugriff mit Property Value auf den Wert
                Console.WriteLine(j.ToString());
            }

            i = 6;
            if (i.HasValue)
            {
                int j = i.Value * 5;            // Zugriff mit Property Value auf den Wert
                Console.WriteLine(j.ToString());
            }

            // oder

            int k = i.GetValueOrDefault();
            Console.WriteLine(k.ToString());    // whats the default value?
        }
    }
}