using System;

// This class holds the owner's name and account balance.
public class Account
{
    private string owner;
    private double balance;

    public string Owner { get { return owner; } }
    public double Balance { get { return balance; } }

    public Account(string owner, double startingBalance)
    {
        this.owner = owner;
        this.balance = startingBalance;
    }

    public bool Deposit(double amount)
    {
        if (amount <= 0)
        {
            return false;
        }

        balance += amount;
        return true;
    }

    public bool Withdraw(double amount)
    {
        if (amount <= 0 || amount > balance)
        {
            return false;
        }

        balance -= amount;
        return true;
    }

    public override string ToString()
    {
        return string.Format("{0}, ${1:N2}", owner, balance);
    }
}
