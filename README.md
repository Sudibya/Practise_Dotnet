# Preactise_dotnet
In this I will practice how to use .net core 7 web API


## Star SQL Server

```Terminal Command

    $sa_password = "Pass@word123"

        docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=sa_passward" -p 1433:1433 -v sqlvolume:/var/opt/mssql -d --rm --name mssql mcr.microsoft.com/mssql/server:2022-latest
```