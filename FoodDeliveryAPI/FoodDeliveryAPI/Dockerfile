# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy only the project file
COPY FoodDeliveryAPI.csproj ./

# Restore dependencies
RUN dotnet restore

# Copy the rest of the code
COPY . .

# Publish the app
RUN dotnet publish -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 80
ENTRYPOINT ["dotnet", "FoodDeliveryAPI.dll"]
