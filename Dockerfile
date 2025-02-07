# Use the official .NET SDK image for building the app
FROM mcr.microsoft.com/dotnet/aspnet:5.0  AS base
WORKDIR /app
EXPOSE 8080


# Use the official .NET SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:5.0  AS build
WORKDIR /src
COPY ["Coders-Airlines", "Coders-Airlines/"]
RUN dotnet restore "Coders-Airlines/Coders-Airlines.sln" 
COPY . .
WORKDIR "/src/Coders-Airlines"
RUN dotnet build "Coders-Airlines.sln" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Coders-Airlines.sln" -c Release -o /app/publish

# Final image with only the published app
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Coders-Airlines.dll"]
