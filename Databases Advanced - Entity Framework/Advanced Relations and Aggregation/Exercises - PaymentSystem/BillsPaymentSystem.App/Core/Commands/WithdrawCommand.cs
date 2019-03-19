using BillsPaymentSystem.App.Core.Contracts;
using BillsPaymentSystem.Data;
using BillsPaymentSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;


namespace BillsPaymentSystem.App.Core.Commands
{
    public class WithdrawCommand : ICommand
    {
        private readonly PaymentSystemContext context;

        public WithdrawCommand(PaymentSystemContext context)
        {
            this.context = context;
        }

        public string Execute(string[] args)
        {
            if (args.Count() > 0)
            {
                throw new ArgumentException("Please try again! Arguments are not needed for this command!");
            }

            string result = string.Empty;

            Console.Write("From user with Id: #");
            int userId = int.Parse(Console.ReadLine());

            User user = this.context.Users
                .Include(u => u.PaymentMethods)
                .ThenInclude(pm => pm.BankAccount)
                .Include(u => u.PaymentMethods)
                .ThenInclude(pm => pm.CreditCard)
                .FirstOrDefault(u => u.UserId == userId);

            if (user == null)
            {
                throw new ArgumentNullException($"User with id {userId} not found!");
            }

            var userAccounts = user.PaymentMethods
                .Where(u => u.BankAccount != null)
                .Select(u => u.BankAccount);

            var userCreditCards = user.PaymentMethods
                .Where(u => u.CreditCard != null)
                .Select(u => u.CreditCard);

            Console.WriteLine("Please select payment method: BankAccount or CreditCard");
            string paymentMethod = Console.ReadLine();
            
            switch (paymentMethod)
            {
                case "BankAccount":
                    if (userAccounts.Any())
                    {
                        int[] availableAccounts = userAccounts.Select(a => a.BankAccountId).ToArray();

                        Console.WriteLine(
                            $"User's accountIds available: {string.Join(", ", availableAccounts.Select(x => $"accId: #{x}"))}");

                        Console.Write("Select accountId: ");

                        int accountId = int.Parse(Console.ReadLine());

                        if (!availableAccounts.Contains(accountId))
                        {
                            throw new ArgumentNullException($"Invalid account Id #{accountId}! The accountId must be selected from the above list showing the user's accounts!");
                        }

                        Console.Write("Amount to withdraw: ");
                        decimal amountToWithdraw = decimal.Parse(Console.ReadLine());

                        BankAccount account = context.BankAccounts
                            .First(a => a.BankAccountId == accountId);

                        if (account.Balance < amountToWithdraw)
                        {
                            throw new InvalidOperationException($"Insufficient account balance! Balance is: ${account.Balance:f2} and you want to withdraw: ${amountToWithdraw:f2}");
                        }

                        account.Balance -= amountToWithdraw;

                        result += "Successfull withdrawal!"
                            + Environment.NewLine
                            + $"New account balance is: ${account.Balance}";
                    }
                    else
                    {
                        throw new ArgumentNullException($"{user.FirstName + " " + user.LastName} doesn't have a bank account!");
                    }
                    break;

                case "CreditCard":
                    if (userCreditCards.Any())
                    {
                        int[] availableCreditCards = userCreditCards.Select(c => c.CreditCardId).ToArray();

                        Console.WriteLine(
                            $"User's creditCardsIds available: {string.Join(", ", availableCreditCards.Select(x => $"creditCardId: #{x}"))}");

                        Console.Write("Select creditCardsId: #");

                        int creditCardId = int.Parse(Console.ReadLine());

                        if (!availableCreditCards.Contains(creditCardId))
                        {
                            throw new ArgumentNullException($"Invalid creditCard Id #{creditCardId}! The creditCard Id must be selected from the above list showing the user's credit cards!");
                        }

                        Console.Write("Amount to withdraw: ");
                        decimal amountToWithdraw = decimal.Parse(Console.ReadLine());

                        CreditCard card = context.CreditCards
                            .First(a => a.CreditCardId == creditCardId);

                        if (card.LimitLeft < amountToWithdraw)
                        {
                            throw new InvalidOperationException($"Insufficient credit card balance! Balance is: ${card.LimitLeft:f2} and you want to withdraw: ${amountToWithdraw:f2}");
                        }

                        card.MoneyOwed += amountToWithdraw;

                        result += "Successfull withdrawal!"
                            + Environment.NewLine
                            + $"Amount remaining on credit card: ${card.LimitLeft}";
                    }
                    else
                    {
                        throw new ArgumentNullException($"{user.FirstName + " " + user.LastName} doesn't have a credit card!");
                    }
                    break;

                default:
                    throw new ArgumentException("Invalid payment method!");
            }

            context.SaveChanges();

            return result;
        }
    }
}
