# .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS dotnet

#Copy
COPY source/Pessoa.Api/Pessoa.Api.csproj .source/PessoaApi
COPY source/Pessoa.Domain/Pessoa.Domain.csproj .source/PessoaDomain
COPY source/Pessoa.Infra/Pessoa.Infra.csproj .source/PessoaInfra
COPY source/Pessoa.Shared/Pessoa.Shared.csproj .source/PessoaShared
COPY source/Pessoa.Test/Pessoa.Test.csproj .source/PessoaTest

RUN dotnet restore ./source/PessoaApi/Pessoa.Api.csproj

COPY source ./source/

RUN dotnet publish ./source/PessoaApi/PessoaApi.Api.csproj -c Release -o /dist --no-restore

# .NET Runtime
FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
WORKDIR /app
COPY --from=dotnet /dist .
ENTRYPOINT ["dotnet", "Pessoa.Api.dll"]