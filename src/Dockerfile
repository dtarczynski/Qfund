FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
#HTTP
EXPOSE 80
EXPOSE 5050
#HTTPS
EXPOSE 5051

ENV ASPNETCORE_ENVIRONMENT=Development

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["/Qfund.Api/Qfund.Api.csproj", "src/Qfund.Api/"]
COPY ["/Qfund.Application/Qfund.Application.csproj", "src/Qfund.Application/"]
COPY ["/Qfund.Domain/Qfund.Domain.csproj", "src/Qfund.Domain/"]
COPY ["/Qfund.Infrastructure/Qfund.Infrastructure.csproj", "src/Qfund.Infrastructure/"]
COPY ["/Qfund.Migrations/Qfund.Migrations.csproj", "src/Qfund.Migrations/"]

RUN dotnet restore "src/Qfund.Api/Qfund.Api.csproj"
COPY . .
WORKDIR "/src/Qfund.Api"
RUN dotnet build "Qfund.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Qfund.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Qfund.Api.dll"]
