# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and project files first for better layer caching
COPY FoodDeliveryAPI/FoodDeliveryAPI.sln .
COPY FoodDeliveryAPI/FoodDeliveryAPI/FoodDeliveryAPI.csproj ./FoodDeliveryAPI/
COPY FoodDeliveryAPI/FoodDeliveryAPI.DataAcces/FoodDeliveryAPI.DataAcces.csproj ./FoodDeliveryAPI.DataAcces/
COPY FoodDeliveryAPI/FoodDeliveryAPI.Domain/FoodDeliveryAPI.Domain.csproj ./FoodDeliveryAPI.Domain/

# Restore NuGet packages
RUN dotnet restore

# Copy everything else
COPY FoodDeliveryAPI/ .

# Publish the API project
WORKDIR /src/FoodDeliveryAPI
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy the published output
COPY --from=build /app/publish .

# Expose ports
EXPOSE 80
EXPOSE 443

# Set the entry point
ENTRYPOINT ["dotnet", "FoodDeliveryAPI.dll"]