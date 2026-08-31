using System;
using System.Collections.Generic;

// This class manages the account and its transaction history.
public class Ledger
{
    private Account account;
    private List<Transaction> history;
    private int nextId;

    public int Count
    {
        get { return history.Count; }
    }

    public Ledger(Account account)
    {
        this.account = account;
        history = new List<Transaction>();
        nextId = 1;
    }

    public bool Record(string kind, double amount)
    {
        bool accepted = false;

        if (kind == "Deposit")
        {
            accepted = account.Deposit(amount);
        }
        else if (kind == "Withdrawal")
        {
            accepted = account.Withdraw(amount);
        }

        if (!accepted)
        {
            return false;
        }

        Transaction transaction = new Transaction(nextId, kind, amount);
        history.Add(transaction);
        nextId++;

        return true;
    }

    public double Total(string kind)
    {
        double total = 0;

        foreach (Transaction transaction in history)
        {
            if (transaction.Kind == kind)
            {
                total += transaction.Amount;
            }
        }

        return total;
    }

    public void PrintStatement()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("  STATEMENT FOR " + account.Owner.ToUpper());
        Console.WriteLine("========================================");
        Console.WriteLine("  ID  TYPE              AMOUNT");
        Console.WriteLine("----------------------------------------");

        foreach (Transaction transaction in history)
        {
            Console.WriteLine(transaction.Describe());
        }

        Console.WriteLine("----------------------------------------");
        Console.WriteLine(string.Format(
            "  {0,-17}${1,10:N2}", "Deposits:", Total("Deposit")));

        Console.WriteLine(string.Format(
            "  {0,-17}${1,10:N2}", "Withdrawals:", Total("Withdrawal")));

        Console.WriteLine(string.Format(
            "  {0,-17}${1,10:N2}", "Ending balance:", account.Balance));

        Console.WriteLine("========================================");
    }
}
