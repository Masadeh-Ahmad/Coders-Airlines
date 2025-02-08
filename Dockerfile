# Use the official .NET runtime for running the app
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

# Set the default environment to Production
ENV ASPNETCORE_ENVIRONMENT=Production

# Use the official .NET SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

# Copy solution and restore dependencies
COPY ["Coders-Airlines", "Coders-Airlines/"]
RUN dotnet restore "Coders-Airlines/Coders-Airlines.sln"

# Copy all files and build the project
COPY . .
WORKDIR "/src/Coders-Airlines"
RUN dotnet build "Coders-Airlines.sln" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "Coders-Airlines.sln" -c Release -o /app/publish

# Final image for running the app
FROM base AS final
WORKDIR /app

# Copy the published files to the final image
COPY --from=publish /app/publish .

# Entry point for running the application
ENTRYPOINT ["dotnet", "Coders-Airlines.dll"]
