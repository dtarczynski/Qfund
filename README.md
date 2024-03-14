# Qfund transactions tracker

[![Maintenance](https://img.shields.io/badge/Maintained%3F-yes-green.svg)](https://GitHub.com/Naereen/StrapDown.js/graphs/commit-activity)
![CI](https://github.com/dtarczynski/Qfund/actions/workflows/dotnet.yml/badge.svg)

## The main objectives of this project

- 🔭 CleanArchitecture
- 🤔 Low coupling
- ⚡ Distributed messaging
- ⚡ Docker as local stack
- 💬 Cloud integration

## How to run

From the root directory where `docker-compose.yml` file is located, simply run:

```
docker compose up
```
## DB migrations how to
Database is create and updated from SQL scripts located in `Migrations` project and applied on application startup.
In order to change or update db write SQL script and start the `Api`. 

## Powered by
- Wolverine the Next Generation .NET Mediator and Message Bus
- Postgresql
- RabbitMq
