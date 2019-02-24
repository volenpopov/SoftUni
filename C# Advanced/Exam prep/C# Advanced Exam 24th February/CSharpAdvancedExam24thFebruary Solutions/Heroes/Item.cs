﻿using System.Text;

namespace Heroes
{
    public class Item
    {
        public int Strength { get; set; }

        public int Ability { get; set; }

        public int Intelligence { get; set; }

        public Item(int strength, int ability, int inteligence)
        {
            this.Strength = strength;
            this.Ability = ability;
            this.Intelligence = inteligence;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Item:");
            sb.AppendLine($"  * Strength: {this.Strength}");
            sb.AppendLine($"  * Ability: {this.Ability}");
            sb.AppendLine($"  * Intelligence: {this.Intelligence}");

            return sb.ToString();
        }
    }
}
