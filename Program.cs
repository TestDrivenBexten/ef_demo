
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

IList<ShareSummary> QueryBelowMinimumBalanceShares()
{
    var summaryList = db.Shares
        .Where(x => x.ShareAmount < MINIMUM_BALANCE)
        .Join(
            db.Accounts, // Table to join
            share => share.Account.AccountId, // Key for left hand table
            account => account.AccountId, // Key for right hand table
            (share, account) => new ShareSummary(
                account.AccountNumber,
                account.OwnerName,
                share.ShareId,
                share.ShareAmount
            )
        )
        // .Where(x => x.Balance < MINIMUM_BALANCE)
        .ToList();
    return summaryList;
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

/*
 * Add another account with various shares
 */
var secondAccount = CreateMinimumDepositAccount("Ferret Faucet", "X1001"); // Charlie's Angels
var belowMinimumShare = new Share { ShareAmount = 5.00M };
var aboveMinimumShare = new Share { ShareAmount = 1_102_030.00M };
secondAccount.Shares.Add(belowMinimumShare);
secondAccount.Shares.Add(aboveMinimumShare);
db.Accounts.Add(secondAccount);
db.SaveChanges();

/*
 * Get Share Ids for shares below minimum balance
 */
var shareSummaryList = QueryBelowMinimumBalanceShares();
Console.WriteLine($"There are {shareSummaryList.Count()} shares below the minimum balance of {MINIMUM_BALANCE}");
foreach (var shareSummary in shareSummaryList)
{
    var (accountNumber, ownerName, shareId, balance) = shareSummary;
    Console.WriteLine($"  Account {accountNumber} for {ownerName}, share {shareSummary} with balance {balance}");
}

// ClearDatabase();

record ShareSummary(
    string AccountNumber,
    string OwnerName,
    int ShareId,
    decimal Balance
);
