dotnet tool install --global dotnet-ef
dotnet ef migrations add RenameShareTransactionTable
dotnet ef database update