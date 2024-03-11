FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
#HTTP
EXPOSE 80
EXPOSE 5050
#HTTPS
EXPOSE 5051

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /out
COPY ["src/Qfund.Api/Qfund.Api.csproj", "src/Qfund.Api/"]
COPY ["src/Qfund.Application/Qfund.Application.csproj", "src/Qfund.Application/"]
COPY ["src/Qfund.Domain/Qfund.Domain.csproj", "src/Qfund.Domain/"]
COPY ["src/Qfund.Infrastructure/Qfund.Infrastructure.csproj", "src/Qfund.Infrastructure/"]
COPY ["src/Qfund.Migrations/Qfund.Migrations.csproj", "src/Qfund.Migrations/"]

RUN dotnet restore "src/Qfund.Api/Qfund.Api.csproj"
COPY . .

WORKDIR "/out/src/Qfund.Api"
RUN dotnet build "Qfund.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Qfund.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Qfund.Api.dll"]
