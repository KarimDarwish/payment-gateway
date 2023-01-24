FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /src

COPY ./src .

RUN dotnet restore PaymentGateway.API/PaymentGateway.API.csproj
RUN dotnet publish PaymentGateway.API/PaymentGateway.API.csproj --output out --no-restore --configuration Release 

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine3.14

# Creating a new user so that the container is not running with the root user
# Test
RUN addgroup --gid 1000 -S app && adduser --uid 1000 -S app -G app
RUN mkdir /app && chown -R app:app /app

WORKDIR /app
USER app

COPY --from=build-env --chown=app:app /src/out .

ENV ASPNETCORE_URLS=http://*:8080

HEALTHCHECK CMD wget --no-verbose --tries=1 --spider http://localhost:8080/health || exit 1

EXPOSE 8080
ENTRYPOINT ["dotnet", "PaymentGateway.API.dll"]
