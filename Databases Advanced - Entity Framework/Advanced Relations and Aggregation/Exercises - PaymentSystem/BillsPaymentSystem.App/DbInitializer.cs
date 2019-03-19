using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BillsPaymentSystem.Data;
using BillsPaymentSystem.Models;
using BillsPaymentSystem.Models.Enums;

namespace BillsPaymentSystem.App
{
    public static class DbInitializer
    {
        public static void Seed(PaymentSystemContext context)
        {
            SeedUsers(context);
            SeedBankAccounts(context);
            SeedCreditCards(context);
            SeedPaymentMethods(context);
        }

        private static void SeedPaymentMethods(PaymentSystemContext context)
        {
            var users = context.Users.ToArray();
            var accounts = context.BankAccounts.ToArray();
            var cards = context.CreditCards.ToArray();

            var methods = new List<PaymentMethod>();

            for (int i = 0; i < 8; i++)
            {
                PaymentMethod currentMethod = new PaymentMethod
                {
                    UserId = users[new Random().Next(0, users.Length - 1)].UserId,
                    PaymentType = i % 2 == 0 ? 
                        PaymentType.BankAccount 
                        : PaymentType.CreditCard
                };

                if (currentMethod.PaymentType == PaymentType.BankAccount)
                {
                    currentMethod.BankAccountId = 
                        accounts[new Random().Next(0, accounts.Length - 1)].BankAccountId;

                    if (methods.Any(m => m.BankAccountId == currentMethod.BankAccountId))
                        continue;
                }
                else
                {
                    currentMethod.CreditCardId =
                        cards[new Random().Next(0, cards.Length - 1)].CreditCardId;

                    if (methods.Any(m => m.CreditCardId == currentMethod.CreditCardId))
                        continue;
                }

                if (IsValid(currentMethod))
                {
                    methods.Add(currentMethod);
                }
            }

            context.PaymentMethod.AddRange(methods);
            context.SaveChanges();
        }

        private static void SeedCreditCards(PaymentSystemContext context)
        {
            List<CreditCard> cards = new List<CreditCard>();

            for (int i = 0; i < 4; i++)
            {
                CreditCard currentCard = new CreditCard
                {
                    Limit = new Random().Next(5000, 70000),
                    MoneyOwed = i * 3000,
                    ExpirationDate = DateTime.Now.AddDays(new Random().Next(-10, 100))
                };

                if (IsValid(currentCard))
                {
                    cards.Add(currentCard);
                }
            }

            context.CreditCards.AddRange(cards);
            context.SaveChanges();
        }

        private static void SeedBankAccounts(PaymentSystemContext context)
        {
            string[] banks =
                { "UniCredit BulBank", "JPMorgan Chase", "First Investment Bank", "GoldmanSachs"};

            string[] SwiftCodes =
                {"RZBBBGSF", "JPMGCH02", "FIBBBGSF", "GSUSAMEX"};

            var accounts = new List<BankAccount>();

            for (int i = 0; i < banks.Length; i++)
            {
                BankAccount currentAccount = new BankAccount
                {
                    Balance = new Random().Next(1500, 200000),
                    BankName = banks[new Random().Next(0, banks.Length - 1)],
                    SWIFT = SwiftCodes[new Random().Next(0, SwiftCodes.Length - 1)]
                };

                if (IsValid(currentAccount))
                {
                    accounts.Add(currentAccount);
                }
            }

            context.BankAccounts.AddRange(accounts.Distinct());
            context.SaveChanges();

        }

        private static void SeedUsers(PaymentSystemContext context)
        {
            string[] firstNames =
                { "Pesho", "Gosho", "Kiro", "Stancho", "Petko", "Rado", ""};

            string[] emails =
                { "pesho@abv.bg", "gosho@yahoo.com", ".bg", "pololo@google.com", "eqewq@eprodsa.org"};

            string[] passwords =
                { "123983921", "asdokfd45", ".sadpov.@!@3", "kyrcho", "_pesho_", "SposDOdq@3&^kFD", null};


            List<User> users = new List<User>();

            for (int i = 0; i < firstNames.Length * 2; i++)
            {
                User currentUser = new User
                {
                    FirstName = firstNames[new Random().Next(0, firstNames.Length - 1)],
                    LastName = String.Concat(firstNames[new Random().Next(0, 7)], "v"),
                    Email = emails[new Random().Next(0, emails.Length - 1)],
                    Password = passwords[new Random().Next(0, passwords.Length - 1)]
                };

                if (IsValid(currentUser))
                {
                    users.Add(currentUser);
                }
            }

            context.Users.AddRange(users.Distinct());
            context.SaveChanges();

        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator
                .TryValidateObject(entity, validationContext, validationResults, true);

            return isValid;
        }
    }
}
