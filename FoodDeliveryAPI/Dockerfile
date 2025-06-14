# Stage 1 - Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . .

RUN dotnet restore ./FoodDeliveryAPI/FoodDeliveryAPI.sln
RUN dotnet publish ./FoodDeliveryAPI/FoodDeliveryAPI.csproj -c Release -o /app/publish

# Stage 2 - Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "FoodDeliveryAPI.dll"]
