#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5002

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DataArchiver/DataArchiver.csproj", "DataArchiver/"]
RUN dotnet restore "DataArchiver/DataArchiver.csproj"
COPY . .
WORKDIR "/src/DataArchiver"
RUN dotnet build "DataArchiver.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DataArchiver.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DataArchiver.dll"]