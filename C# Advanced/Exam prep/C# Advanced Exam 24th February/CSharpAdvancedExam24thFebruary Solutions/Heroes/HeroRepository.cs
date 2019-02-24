using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> heroes;

        public HeroRepository()
        {
            this.heroes = new List<Hero>();
        }

        public int Count => this.heroes.Count;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var hero in heroes)
            {
                sb.Append(hero.ToString());
            }

            return sb.ToString();
        }

        public void Add(Hero hero)
        {
            this.heroes.Add(hero);
        }

        public void Remove(string name)
        {
            Hero hero = this.heroes.FirstOrDefault(h => h.Name == name);

            if (hero != null)
            {
                this.heroes.Remove(hero);
            }
        }

        public Hero GetHeroWithHighestStrength()
        {
            Hero currentHero = heroes[0];

            for (int i = 1; i < this.heroes.Count; i++)
            {
                if (this.heroes[i].Item.Strength > currentHero.Item.Strength)
                {
                    currentHero = this.heroes[i];
                }
            }

            return currentHero;
        }

        public Hero GetHeroWithHighestAbility()
        {
            Hero currentHero = heroes[0];

            for (int i = 1; i < this.heroes.Count; i++)
            {
                if (this.heroes[i].Item.Ability > currentHero.Item.Ability)
                {
                    currentHero = this.heroes[i];
                }
            }

            return currentHero;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            Hero currentHero = heroes[0];

            for (int i = 1; i < this.heroes.Count; i++)
            {
                if (this.heroes[i].Item.Intelligence > currentHero.Item.Intelligence)
                {
                    currentHero = this.heroes[i];
                }
            }

            return currentHero;
        }
    }
}
