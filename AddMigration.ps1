param (
	[Parameter(Mandatory=$true)]
	[string]$MigrationName
)

dotnet tool install --global dotnet-ef
dotnet ef migrations add $MigrationName
dotnet ef database update