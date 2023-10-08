#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["nh.qhatu.security.api/nh.qhatu.security.api.csproj", "nh.qhatu.security.api/"]
COPY ["nh.qhatu.infrastructure.ioc/nh.qhatu.infrastructure.ioc.csproj", "nh.qhatu.infrastructure.ioc/"]
COPY ["nh.qhatu.domain/nh.qhatu.domain.csproj", "nh.qhatu.domain/"]
COPY ["nh.qhatu.infrastructure.bus/nh.qhatu.infrastructure.bus.csproj", "nh.qhatu.infrastructure.bus/"]
COPY ["nh.qhatu.security.application/nh.qhatu.security.application.csproj", "nh.qhatu.security.application/"]
COPY ["nh.qhatu.infrasctructure.crosscutting/nh.qhatu.infrasctructure.crosscutting.csproj", "nh.qhatu.infrasctructure.crosscutting/"]
COPY ["nh.qhatu.security.domain/nh.qhatu.security.domain.csproj", "nh.qhatu.security.domain/"]
COPY ["nh.qhatu.security.infrastructure/nh.qhatu.security.infrastructure.csproj", "nh.qhatu.security.infrastructure/"]
RUN dotnet restore "nh.qhatu.security.api/nh.qhatu.security.api.csproj"
COPY . .
WORKDIR "/src/nh.qhatu.security.api"
RUN dotnet build "nh.qhatu.security.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "nh.qhatu.security.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "nh.qhatu.security.api.dll"]