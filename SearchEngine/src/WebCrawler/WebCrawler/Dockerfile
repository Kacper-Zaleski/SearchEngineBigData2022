FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5003

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["WebCrawler/WebCrawler.csproj", "WebCrawler/"]
RUN dotnet restore "WebCrawler/WebCrawler.csproj"
COPY . .
WORKDIR "/src/WebCrawler"
RUN dotnet build "WebCrawler.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebCrawler.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebCrawler.dll"]