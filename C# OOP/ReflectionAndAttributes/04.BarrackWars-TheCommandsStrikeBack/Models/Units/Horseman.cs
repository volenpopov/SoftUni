namespace _03BarracksFactory.Models.Units
{
    public class Horseman : Unit
    {
        private const int DefaultHealth = 25;
        private const int DefaultDamage = 7;

        public Horseman()
            : base(DefaultHealth, DefaultDamage)
        {
        }
    }
}