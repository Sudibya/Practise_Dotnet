# Preactise_dotnet
In this I will practice how to use .net core 7 web API


## Star SQL Server

```Terminal Command

    $sa_password = "Pass@word123"

        docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Password@123" -p 1433:1433 -v sqlvolume:/var/opt/mssql -d --rm --name mssql mcr.microsoft.com/mssql/server:2022-latest
```

## Now we will set up the connection string with the help of the secret manager

## The below code is for the terminal.
sa_password= "[SA PASSWORD HERE]"
dotnet user-secrets set "ConnectionStrings:GameStoreContext" "Server=localhost; Database=GameStore;User Id=sa; Password=Password@123; TrustServerCertificate=True"

## How to see the list of al the secrets that was stored

dotnet user-secrets list
