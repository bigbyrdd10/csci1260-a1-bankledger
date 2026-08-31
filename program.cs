using System;

// This class runs the bank ledger program.
public class Program
{
    public static void Main()
    {
        Account account = new Account("Ada Lovelace", 500.00);
        Ledger ledger = new Ledger(account);

        Console.WriteLine("Opening account: " + account);
        Console.WriteLine();
        Console.WriteLine("Recording five requests...");

        string[] kinds =
        {
            "Deposit",
            "Withdrawal",
            "Withdrawal",
            "Deposit",
            "Deposit"
        };

        double[] amounts =
        {
            250.00,
            125.50,
            10000.00,
            -40.00,
            75.25
        };

        for (int i = 0; i < kinds.Length; i++)
        {
            bool accepted = ledger.Record(kinds[i], amounts[i]);

            if (!accepted)
            {
                Console.WriteLine(
                    string.Format(
                        "  REJECTED: {0} of ${1:N2}",
                        kinds[i],
                        amounts[i]));
            }
        }

        Console.WriteLine();
        Console.WriteLine("Transactions accepted: " + ledger.Count);
        Console.WriteLine();

        ledger.PrintStatement();
    }
}
