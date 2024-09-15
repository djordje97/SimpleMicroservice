# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

COPY Core/Core.csproj Core/
COPY Application/Application.csproj Application/
COPY Infrastructure/Infrastructure.csproj Infrastructure/
COPY Presentation/Presentation.csproj Presentation/

# Restore dependencies
RUN dotnet restore Presentation/Presentation.csproj

# Copy the rest of the code
COPY Core/. Core/
COPY Application/. Application/
COPY Infrastructure/. Infrastructure/
COPY Presentation/. Presentation/

# Build the solution
RUN dotnet build Presentation/Presentation.csproj -c Release -o /app/build

# Stage 2: Publish
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS publish
WORKDIR /app

# Copy the build artifacts and project files
COPY --from=build /app/build /app/build
COPY --from=build /app/Core /app/Core
COPY --from=build /app/Application /app/Application
COPY --from=build /app/Infrastructure /app/Infrastructure
COPY --from=build /app/Presentation /app/Presentation

# Publish the project
RUN dotnet publish Presentation/Presentation.csproj -c Release -o /app/publish

# Stage 3: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=publish /app/publish .

# Expose port and define entrypoint
EXPOSE 8081
ENTRYPOINT ["dotnet", "Presentation.dll"]
