#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS="http://+:80"

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MockVault/MockVault.csproj", "MockVault/"]
RUN dotnet restore "MockVault/MockVault.csproj"
COPY . .
WORKDIR "/src/MockVault"
RUN dotnet build "MockVault.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MockVault.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MockVault.dll"]