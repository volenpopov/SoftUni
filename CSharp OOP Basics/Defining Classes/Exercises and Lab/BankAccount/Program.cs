    using System;
using System.Collections.Generic;

public class Program
{
    static void Main(string[] args)
    {
        BankAccount acc = new BankAccount();
        Dictionary<int, BankAccount> ClientsAccounts = new Dictionary<int,BankAccount>();

        string inputLine = Console.ReadLine();
        while (inputLine != "End")
        {
            string[] commandElements = inputLine.Split();
            string command = commandElements[0];
            int accountId = int.Parse(commandElements[1]);

            switch (command)
            {
                case "Create":
                    if (!ClientsAccounts.ContainsKey(accountId))
                        ClientsAccounts.Add(accountId, new BankAccount(accountId, 0));
                    else
                        Console.WriteLine("Account already exists");
                    break;

                case "Deposit":
                    if (!ClientsAccounts.ContainsKey(accountId))
                        Console.WriteLine("Account does not exist");
                    else
                    {
                        int amount = int.Parse(commandElements[2]);
                        ClientsAccounts[accountId].Deposit(amount);
                    }
                    break;

                case "Withdraw":
                    if (!ClientsAccounts.ContainsKey(accountId))
                        Console.WriteLine("Account does not exist");
                    else
                    {
                        int amount = int.Parse(commandElements[2]);
                        if (ClientsAccounts[accountId].Balance < amount)
                            Console.WriteLine("Insufficient balance");
                        else
                            ClientsAccounts[accountId].Withdraw(amount);
                    }
                    break;

                case "Print":
                    if (!ClientsAccounts.ContainsKey(accountId))
                        Console.WriteLine("Account does not exist");
                    else
                        Console.WriteLine(ClientsAccounts[accountId]);
                    break;
            }
            inputLine = Console.ReadLine();
        }
    }
}

