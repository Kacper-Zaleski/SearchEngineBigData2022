#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5004

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SearchEngine/SearchEngine.csproj", "SearchEngine/"]
RUN dotnet restore "SearchEngine/SearchEngine.csproj"
COPY . .
WORKDIR "/src/SearchEngine"
RUN dotnet build "SearchEngine.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SearchEngine.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SearchEngine.dll"]