﻿FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["NetMesnG.Api/NetMesnG.Api.csproj", "NetMesnG.Api/"]
RUN dotnet restore "NetMesnG.Api/NetMesnG.Api.csproj"
COPY . .
WORKDIR "/src/NetMesnG.Api"
RUN dotnet build "NetMesnG.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NetMesnG.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NetMesnG.Api.dll"]
