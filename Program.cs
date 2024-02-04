
using EfDemo;

using var db = new DemoContext();

void ClearDatabase() {
    Console.WriteLine("Clearing database...");
    db.Shares.RemoveRange(db.Shares.ToList());
    db.Accounts.RemoveRange(db.Accounts.ToList());
    db.SaveChanges();
    Console.WriteLine("Database cleared...");
}
ClearDatabase();

var account = new Account { AccountNumber = "X1000", OwnerName="Jack Daniels" };
var share = new Share { ShareAmount = 10.00M };
account.Shares.Add(share);
db.Accounts.Add(account);
db.SaveChanges();

Console.WriteLine("Account saved");

var fetchedAccount = db.Accounts
    .First(x => x.AccountId == account.AccountId);
Console.WriteLine($"Fetched account: {fetchedAccount.AccountNumber}");
Console.WriteLine($"Share count: {fetchedAccount.Shares.Count}");

// ClearDatabase();
