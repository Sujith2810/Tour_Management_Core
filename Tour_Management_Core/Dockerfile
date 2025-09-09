# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src

# Copy csproj and restore as distinct layers
COPY Tour_Management_Core/*.csproj ./Tour_Management_Core/
RUN dotnet restore ./Tour_Management_Core/Tour_Management_Core.csproj

# Copy all files and build
COPY . .
WORKDIR /src/Tour_Management_Core
RUN dotnet build -c Release -o /app/build
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 80

ENTRYPOINT ["dotnet", "Tour_Management_Core.dll"]
