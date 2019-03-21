using BillsPaymentSystem.App.Core.Contracts;
using BillsPaymentSystem.Data;
using BillsPaymentSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
                throw new ArgumentNullException($"User with id #{userId} not found!");
            }

            var userAccounts = user.PaymentMethods
                .Where(u => u.BankAccount != null)
                .Select(u => u.BankAccount)
                .ToArray();

            var userCreditCards = user.PaymentMethods
                .Where(u => u.CreditCard != null)
                .Select(u => u.CreditCard)
                .ToArray();

            Console.WriteLine("Please select payment method: BankAccount or CreditCard");
            string withdrawalMethod = Console.ReadLine();
            
            switch (withdrawalMethod)
            {
                case "BankAccount":
                    result = WithdrawFunds(context, userAccounts);
                    break;

                case "CreditCard":
                    result = WithdrawFunds(context, userCreditCards);
                    break;

                default:
                    throw new ArgumentException("Invalid payment method!");
            }
            
            return result;
        }

        private string WithdrawFunds<T>(PaymentSystemContext context, IEnumerable<T> sourceOfFunds)
        {
            string result = null;

            if (sourceOfFunds.Any())
            {
                string propertyName = $"{sourceOfFunds.Select(f => f.GetType().Name).First()}";

                int[] availableSourceOfFundsIds = sourceOfFunds
                    .Select(a => (int)(a.GetType().GetProperty($"{propertyName}Id").GetValue(a)))
                    .ToArray();

                Console.WriteLine(
                    $"User's {propertyName}Ids available: " +
                    $"{string.Join(", ", availableSourceOfFundsIds.Select(x => $"{propertyName}Id: #{x}"))}");

                Console.Write($"Select {propertyName}Id: #");

                int sourceOfFundsIdToWithdrawFrom = int.Parse(Console.ReadLine());

                if (!availableSourceOfFundsIds.Contains(sourceOfFundsIdToWithdrawFrom))
                {
                    throw new ArgumentNullException(
                        $"Invalid {propertyName}Id #{sourceOfFundsIdToWithdrawFrom}! " +
                        $"The {propertyName}Id must be selected from the above list showing the user's {propertyName}Ids!");
                }

                Console.Write("Amount to withdraw: ");
                decimal amountToWithdraw = decimal.Parse(Console.ReadLine());

                T sourceToWithdrawFrom = sourceOfFunds
                    .Where(s => (int)s
                        .GetType()
                        .GetProperty($"{propertyName}Id")
                        .GetValue(s) == sourceOfFundsIdToWithdrawFrom)
                    .First();

                var balance = (decimal)sourceToWithdrawFrom
                    .GetType()
                    .GetProperties()
                    .First(p => p.Name == "Balance" || p.Name == "LimitLeft")
                    .GetValue(sourceToWithdrawFrom);

                if (balance < amountToWithdraw)
                {
                    throw new InvalidOperationException(
                        $"Insufficient {propertyName} balance! " +
                        $"Balance is: ${balance:f2} and you want to withdraw: ${amountToWithdraw:f2}");
                }

                var propertyToWithdrawFrom = sourceToWithdrawFrom.GetType()
                    .GetProperties()
                    .First(p => p.Name == "Balance" || p.Name == "MoneyOwed");

                if (propertyToWithdrawFrom.Name == "Balance")
                {
                    propertyToWithdrawFrom
                        .SetValue(sourceToWithdrawFrom, balance - amountToWithdraw);
                }
                else if (propertyToWithdrawFrom.Name == "MoneyOwed")
                {
                    var currentMoneyOwed = (decimal)propertyToWithdrawFrom
                        .GetValue(sourceToWithdrawFrom);

                    propertyToWithdrawFrom
                        .SetValue(sourceToWithdrawFrom, currentMoneyOwed + amountToWithdraw);
                }

                context.SaveChanges();

                result += "Successfull withdrawal!"
                    + Environment.NewLine
                    + $"New {propertyName} balance is: ${balance - amountToWithdraw}";
            }
            else
            {
                var sourceToWithdrawFromName = sourceOfFunds.GetType().GetGenericArguments().First().GetType().Name;
                throw new ArgumentNullException($"The user doesn't have a {sourceToWithdrawFromName}!");
            }

            return result;
        }
    }
}
