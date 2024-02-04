
using EfDemo;

using var db = new DemoContext();
const decimal MINIMUM_BALANCE = 10.00M;

void ClearDatabase() {
    Console.WriteLine("Clearing database...");
    db.ShareTransactions.RemoveRange(db.ShareTransactions.ToList());
    db.Shares.RemoveRange(db.Shares.ToList());
    db.Accounts.RemoveRange(db.Accounts.ToList());
    db.SaveChanges();
    Console.WriteLine("Database cleared...");
}

Account CreateMinimumDepositAccount(string ownerName, string accountNumber)
{
    var account = new Account { AccountNumber = accountNumber, OwnerName = ownerName };
    var share = new Share { ShareAmount = MINIMUM_BALANCE };
    account.Shares.Add(share);
    return account;
}

void AddTransactionsToShare(Share share, params decimal[] amountList)
{
    var transactionList = amountList.Select(x => new ShareTransaction { BalanceChange = x }).ToList();
    var totalChange = transactionList.Sum(x => x.BalanceChange);
    share.ShareAmount += totalChange;
    foreach(var transaction in transactionList)
    {
        share.ShareTransactions.Add(transaction);
    }
}

/*
 * Initial setup
 */
ClearDatabase();
var account = CreateMinimumDepositAccount("Jack Daniels", "X1000");
db.Accounts.Add(account);
db.SaveChanges();
Console.WriteLine("Account saved");

/*
 * Add transactions to shares
 */
var share = db.Shares.First();
Console.WriteLine($"Adding transactions to share {share.ShareId} with balance {share.ShareAmount}");
AddTransactionsToShare(share, 15.00M, 25.00M, -45.00M);
db.SaveChanges();
Console.WriteLine($"Share {share.ShareId} balance now at {share.ShareAmount}");

// ClearDatabase();
