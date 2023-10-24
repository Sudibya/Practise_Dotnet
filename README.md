# Preactise_dotnet
In this I will practice how to use .net core 7 web API


## Star SQL Server

```Terminal Command

    $sa_password = "Pass@word123"

        docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=sa_passward" -p 1433:1433 -v sqlvolume:/var/opt/mssql -d --rm --name mssql mcr.microsoft.com/mssql/server:2022-latest
```

## Now we will set up the connection string with the help of the secret manager

## The below code is for the terminal.
sa_password= "[SA PASSWORD HERE]"
dotnet user-secrets set "ConnectionStrings:GameStoreContext" "ServerConnection=localhost; Database=GameStore;User Id=sa; Password=PASSWORD-GOES-HERE; TrustServerCertificate=True"

## How to see the list of al the secrets that was stored

dotnet user-secrets list
