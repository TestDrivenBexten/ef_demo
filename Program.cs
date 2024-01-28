
using EfDemo;

using var db = new DemoContext();

var account = new Account { AccountNumber = "X1000", OwnerName="Jack Daniels" };
var share = new Share { ShareAmount = 10.00M };
account.Shares.Add(share);
db.SaveChanges();

Console.WriteLine("Account saved");

var fetchedAccount = db.Accounts.First();
Console.WriteLine(fetchedAccount);

