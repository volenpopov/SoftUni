using System.Collections.Generic;

namespace Repository
{
    public class Repository
    {
        private Dictionary<int, Person> data;

        public Repository()
        {
            this.data = new Dictionary<int, Person>();
        }

        public int Count => this.data.Count;

        public void Add(Person person)
        {
            if (this.data.Count == 0)
                this.data.Add(0, person);
            else
            {
                int nextKey = this.data.Count + 1;
                this.data.Add(nextKey, person);
            }
        }

        public Person Get(int id)
        {
            return this.data[id];
        }

        public bool Update(int id, Person newPerson)
        {
            if (!this.data.ContainsKey(id))
                return false;

            this.data[id] = newPerson;

            return true;
        }

        public bool Delete(int id)
        {
            if (!this.data.ContainsKey(id))
                return false;

            this.data.Remove(id);

            return true;
        }
    }
}
