#!/bin/bash

# Navigate to the frontend folder and run Angular app
cd ./FoodDeliveyAPI.Frontend/FoodDeliveryAPP
npm install
ng serve --port 4200 --open & 

# Navigate to the backend folder and run .NET app
echo "Changed to Directory: $(pwd)"
cd ../../FoodDeliveryAPI/FoodDeliveryAPI
dotnet run