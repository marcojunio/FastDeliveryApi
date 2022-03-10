# .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS dotnet

#Copy
COPY source/Pessoa.sln ./
COPY source/Pessoa.Api/Pessoa.Api.csproj ./Pessoa.Api/
COPY source/Pessoa.Services/Pessoa.Services.csproj ./Pessoa.Services/
COPY source/Pessoa.Domain/Pessoa.Domain.csproj ./Pessoa.Domain/
COPY source/Pessoa.Infra/Pessoa.Infra.csproj ./Pessoa.Infra/
COPY source/Pessoa.Shared/Pessoa.Shared.csproj ./Pessoa.Shared/
COPY source/Pessoa.Test/Pessoa.Test.csproj ./Pessoa.Test/

# .NET Restore
RUN dotnet restore

# Copy All Files
COPY source ./src/

RUN dotnet publish ./src/Pessoa.Api/Pessoa.Api.csproj -c Release -o /dist --no-restore

# .NET Runtime
FROM mcr.microsoft.com/dotnet/aspnet:5.0
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
WORKDIR /app
COPY --from=dotnet /dist .
ENTRYPOINT ["dotnet", "Pessoa.Api.dll"]