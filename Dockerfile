# .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS dotnet

#Copy
COPY source/FastDevlivery.sln ./
COPY source/FastDevlivery.Api/FastDevlivery.Api.csproj ./FastDevlivery.Api/
COPY source/FastDevlivery.Services/FastDevlivery.Services.csproj ./FastDevlivery.Services/
COPY source/FastDevlivery.Domain/FastDevlivery.Domain.csproj ./FastDevlivery.Domain/
COPY source/FastDevlivery.Infra/FastDevlivery.Infra.csproj ./FastDevlivery.Infra/
COPY source/FastDevlivery.Shared/FastDevlivery.Shared.csproj ./FastDevlivery.Shared/
COPY source/FastDevlivery.Test/FastDevlivery.Test.csproj ./FastDevlivery.Test/

# .NET Restore
RUN dotnet restore

# Copy All Files
COPY source ./src/

RUN dotnet publish ./src/FastDevlivery.Api/FastDevlivery.Api.csproj -c Release -o /dist --no-restore

# .NET Runtime
FROM mcr.microsoft.com/dotnet/aspnet:5.0
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
WORKDIR /app
COPY --from=dotnet /dist .
ENTRYPOINT ["dotnet", "FastDevlivery.Api.dll"]