#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["nh.qhatu.common.api/nh.qhatu.common.api.csproj", "nh.qhatu.common.api/"]
COPY ["nh.qhatu.common.application/nh.qhatu.common.application.csproj", "nh.qhatu.common.application/"]
COPY ["nh.qhatu.common.domain/nh.qhatu.common.domain.csproj", "nh.qhatu.common.domain/"]
COPY ["nh.qhatu.common.infrastructure/nh.qhatu.common.infrastructure.csproj", "nh.qhatu.common.infrastructure/"]
COPY ["nh.qhatu.infrastructure.ioc/nh.qhatu.infrastructure.ioc.csproj", "nh.qhatu.infrastructure.ioc/"]
COPY ["nh.qhatu.domain/nh.qhatu.domain.csproj", "nh.qhatu.domain/"]
COPY ["nh.qhatu.infrastructure.bus/nh.qhatu.infrastructure.bus.csproj", "nh.qhatu.infrastructure.bus/"]
RUN dotnet restore "nh.qhatu.common.api/nh.qhatu.common.api.csproj"
COPY . .
WORKDIR "/src/nh.qhatu.common.api"
RUN dotnet build "nh.qhatu.common.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "nh.qhatu.common.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "nh.qhatu.common.api.dll"]