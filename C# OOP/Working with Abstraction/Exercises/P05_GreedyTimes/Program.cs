using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Potato
    {
        static void Main(string[] args)
        {
            long bagCapacity = long.Parse(Console.ReadLine());
            string[] inputItemQuantityPairs = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();
            long gold = 0;
            long gems = 0;
            long cash = 0;

            for (int i = 0; i < inputItemQuantityPairs.Length; i += 2)
            {
                string name = inputItemQuantityPairs[i];
                long quantity = long.Parse(inputItemQuantityPairs[i + 1]);

                string item = string.Empty;

                item = ProcessItemName(name, item);

                if (item == "")
                    continue;
                else if (bagCapacity < bag.Values.Select(x => x.Values.Sum()).Sum() + quantity)
                    continue;

                switch (item)
                {
                    case "Gem":
                        if (!bag.ContainsKey(item))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (quantity > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[item].Values.Sum() + quantity > bag["Gold"].Values.Sum())
                        {
                            continue;
                        }
                        break;

                    case "Cash":
                        if (!bag.ContainsKey(item))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (quantity > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (bag[item].Values.Sum() + quantity > bag["Gem"].Values.Sum())
                        {
                            continue;
                        }
                        break;
                }

                AddQuantityToBag(bag, name, quantity, item);

                AddQuantityToItem(ref gold, ref gems, ref cash, quantity, item);

            }

            PrintBag(bag);
        }

        private static void PrintBag(Dictionary<string, Dictionary<string, long>> bag)
        {
            foreach (var itemQuantityDict in bag)
            {
                var mainItemName = itemQuantityDict.Key;
                var subItemDict = itemQuantityDict.Value;

                Console.WriteLine($"<{mainItemName}> ${subItemDict.Values.Sum()}");
                foreach (var item2 in subItemDict.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }

        private static void AddQuantityToBag(Dictionary<string, Dictionary<string, long>> bag, string name, long quantity, string item)
        {
            if (!bag.ContainsKey(item))
                bag[item] = new Dictionary<string, long>();

            if (!bag[item].ContainsKey(name))
                bag[item][name] = 0;

            bag[item][name] += quantity;
        }

        private static void AddQuantityToItem(ref long gold, ref long gems, ref long cash, long quantity, string item)
        {
            if (item == "Gold")
                gold += quantity;

            else if (item == "Gem")
                gems += quantity;

            else if (item == "Cash")
                cash += quantity;
        }

        private static string ProcessItemName(string name, string item)
        {
            if (name.Length == 3) // because the Cash given in the input is given as currency - for example USD, JPN, etc.
                item = "Cash";

            else if (name.ToLower().EndsWith("gem"))
                item = "Gem";

            else if (name.ToLower() == "gold")
                item = "Gold";

            return item;
        }
    }
}