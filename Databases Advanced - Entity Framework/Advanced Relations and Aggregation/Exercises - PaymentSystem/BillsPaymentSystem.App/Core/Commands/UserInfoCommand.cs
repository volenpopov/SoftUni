
using BillsPaymentSystem.App.Core.Contracts;
using BillsPaymentSystem.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;

namespace BillsPaymentSystem.App.Core.Commands
{
    public class UserInfoCommand : ICommand
    {
        private readonly PaymentSystemContext context;

        public UserInfoCommand(PaymentSystemContext context)
        {
            this.context = context;
        }

        public string Execute(string[] args)
        {
            int userId = int.Parse(args[0]);

            var user = this.context.Users
                .Include(u => u.PaymentMethods)
                .ThenInclude(pm => pm.BankAccount)
                .Include(u => u.PaymentMethods)
                .ThenInclude(pm => pm.CreditCard)
                .FirstOrDefault(x => x.UserId == userId);

            if (user == null)
            {
                throw new ArgumentNullException($"User with id {userId} not found!");
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"User: {user.FirstName + " " + user.LastName}");

            var bankAccounts = user.PaymentMethods
                .Where(x => x.BankAccount != null)
                .Select(x => x.BankAccount);

            var creditCards = user.PaymentMethods
                .Where(x => x.CreditCard != null)
                .Select(x => x.CreditCard);

            sb.AppendLine("Bank Accounts:");
            if (bankAccounts.Any())
            {
                foreach (var acc in bankAccounts)
                {
                    sb.AppendLine($"-- ID: {acc.BankAccountId}");
                    sb.AppendLine($"--- Balance: {acc.Balance:f2}");
                    sb.AppendLine($"--- Bank: {acc.BankName}");
                    sb.AppendLine($"--- SWIFT: {acc.SWIFT}");
                }
            }
            else
            {
                sb.AppendLine("No bank accounts!");
            }

            sb.AppendLine("Credit Cards:");

            if (creditCards.Any())
            {
                foreach (var card in creditCards)
                {
                    sb.AppendLine($"-- ID: {card.CreditCardId}");
                    sb.AppendLine($"--- Limit: {card.Limit:f2}");
                    sb.AppendLine($"--- MoneyOwed: {card.MoneyOwed:f2}");
                    sb.AppendLine($"--- LimitLeft: {card.LimitLeft:f2}");
                    sb.AppendLine($"--- Expiration Date: {card.ExpirationDate:yyyy/MM}");
                }
            }
            else
            {
                sb.AppendLine("No credit cards!");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
