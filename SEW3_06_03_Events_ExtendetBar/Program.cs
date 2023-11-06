using System.IO;

namespace SEW3_06_02_Events_BarDrinks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bar bar = new Bar();
            Person max = new Person() { Name = "Max" };
            Person franz = new Person() { Name = "Franz" };
            max.enter(bar);
            franz.enter(bar);
            bar.SpendRound();
            franz.leave(bar);
            bar.SpendRound();

            ExtendedBar anotherBar = new ExtendedBar();
            franz.enter(anotherBar);
            anotherBar.SpendNonAlcoholicDrink();
            Person susi = new Person() { Name = "Susi" };
            susi.enter(anotherBar);
            anotherBar.SpendAlcoholicDrink();

            // what happens when someone registers twice or more times for the event?
            // what happens when someone deregisters for a event that was not registered?
        }
    }
    public class Bar
    {
        public event EventHandler SpendRoundEvent;

        public void SpendRound()
        {
            if (this.SpendRoundEvent != null)        // important!!!
            {
                this.SpendRoundEvent(this, EventArgs.Empty);
            }
        }
    }
    public enum DrinkType
    {
        Alcoholic,
        NonAlcoholic
    }
    internal class DrinkEventArgs : EventArgs
    {
        public DrinkEventArgs(DrinkType type)
        {
            this.Drink = type;
        }

        public DrinkType Drink { get; private set; }
    }
    internal class ExtendedBar
    {
        public event EventHandler<DrinkEventArgs> SpendRoundEvent;

        public void SpendAlcoholicDrink()
        {
            if (this.SpendRoundEvent != null)
            {
                this.SpendRoundEvent(this, new DrinkEventArgs(DrinkType.Alcoholic));
            }
        }

        public void SpendNonAlcoholicDrink()
        {
            if (this.SpendRoundEvent != null)
            {
                this.SpendRoundEvent(this, new DrinkEventArgs(DrinkType.NonAlcoholic));
            }
        }
    }
    internal class Person
    {
        public string Name { get; set; }

        public void enter(Bar b)
        {
            // register for event
            b.SpendRoundEvent += receiveDrink;
        }

        public void leave(Bar b)
        {
            b.SpendRoundEvent -= receiveDrink;
        }

        public void receiveDrink(object sender, EventArgs e)
        {
            Console.WriteLine(this.Name + " is happy about the drink!");
        }

        public void enter(ExtendedBar b)
        {
            // register for event
            b.SpendRoundEvent += receiveDrink;
        }

        public void leave(ExtendedBar b)
        {
            b.SpendRoundEvent -= receiveDrink;
        }

        public void receiveDrink(object sender, DrinkEventArgs e)
        {
            string type = "alcoholic";
            if (e.Drink == DrinkType.NonAlcoholic)
            {
                type = "non alcoholic";
            }
            Console.WriteLine(this.Name + " is happy about the " + type + " drink!");
        }
    }
}