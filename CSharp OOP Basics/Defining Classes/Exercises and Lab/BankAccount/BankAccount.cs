using System;
using System.Collections.Generic;
using System.Text;


public class BankAccount
{
    private int id;
    private decimal balance;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public decimal Balance
    {
        get { return balance; }
        set { balance = value; }
    }

    public BankAccount()
    { }

    public BankAccount(int id, decimal balance)
    {
        this.Id = id;
        this.Balance = balance;
    }

    public void Deposit (decimal amount)
    {
        this.Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        this.Balance -= amount;
    }

    public override string ToString()
    {
        return String.Format($"Account ID{this.Id}, balance {this.Balance:0.00}");
    }
}

