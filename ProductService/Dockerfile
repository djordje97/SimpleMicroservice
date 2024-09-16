# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY Common/Common/Common.csproj Common/Common/
COPY ProductService/Core/Core.csproj ProductService/Core/
COPY ProductService/Application/Application.csproj ProductService/Application/
COPY ProductService/Infrastructure/Infrastructure.csproj ProductService/Infrastructure/
COPY ProductService/Presentation/Presentation.csproj ProductService/Presentation/

# Restore dependencies
RUN dotnet restore ProductService/Presentation/Presentation.csproj

# Copy the rest of the 
COPY Common/Common/. Common/Common/
COPY ProductService/Core/. ProductService/Core/
COPY ProductService/Application/. ProductService/Application/
COPY ProductService/Infrastructure/. ProductService/Infrastructure/
COPY ProductService/Presentation/. ProductService/Presentation/

# Build the solution
RUN dotnet build ProductService/Presentation/Presentation.csproj -c Release -o /app/build

# Stage 2: Publish
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS publish
WORKDIR /app

# Copy the build artifacts and project files
COPY --from=build /app/build /app/build
COPY --from=build /app/Common/Common /app/Common/Common
COPY --from=build /app/ProductService/Core /app/ProductService/Core
COPY --from=build /app/ProductService/Application /app/ProductService/Application
COPY --from=build /app/ProductService/Infrastructure /app/ProductService/Infrastructure
COPY --from=build /app/ProductService/Presentation /app/ProductService//Presentation

# Publish the project
RUN dotnet publish ProductService/Presentation/Presentation.csproj -c Release -o /app/publish

# Stage 3: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=publish /app/publish .

# Expose port and define entrypoint
EXPOSE 8082
ENTRYPOINT ["dotnet", "Presentation.dll"]
