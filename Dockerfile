# Steg 1: Bygg ASP.NET Core-applikasjonen
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["RestaurantTips.csproj", "./"]
RUN dotnet restore "RestaurantTips.csproj"

COPY . .
RUN dotnet publish "RestaurantTips.csproj" -c Release -o /app/publish


# Steg 2: Kjør applikasjonen
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 8080

ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "RestaurantTips.dll"]