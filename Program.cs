
using EfDemo;

using var db = new DemoContext();

void ClearDatabase() {
    Console.WriteLine("Clearing database...");
    db.Shares.RemoveRange(db.Shares.ToList());
    db.Accounts.RemoveRange(db.Accounts.ToList());
    db.SaveChanges();
    Console.WriteLine("Database cleared...");
}

Account CreateMinimumDepositAccount(string ownerName, string accountNumber)
{
    var account = new Account { AccountNumber = accountNumber, OwnerName = ownerName };
    var share = new Share { ShareAmount = 10.00M };
    account.Shares.Add(share);
    return account;
}

ClearDatabase();
var account = CreateMinimumDepositAccount("Jack Daniels", "X1000");
db.Accounts.Add(account);
db.SaveChanges();

Console.WriteLine("Account saved");

var fetchedAccount = db.Accounts
    .First(x => x.AccountId == account.AccountId);
Console.WriteLine($"Fetched account: {fetchedAccount.AccountNumber}");
Console.WriteLine($"Share count: {fetchedAccount.Shares.Count}");

// ClearDatabase();
