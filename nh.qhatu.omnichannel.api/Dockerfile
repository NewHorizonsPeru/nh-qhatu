#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["nh.qhatu.omnichannel.api/nh.qhatu.omnichannel.api.csproj", "nh.qhatu.omnichannel.api/"]
COPY ["nh.qhatu.infrastructure.ioc/nh.qhatu.infrastructure.ioc.csproj", "nh.qhatu.infrastructure.ioc/"]
COPY ["nh.qhatu.domain/nh.qhatu.domain.csproj", "nh.qhatu.domain/"]
COPY ["nh.qhatu.infrastructure.bus/nh.qhatu.infrastructure.bus.csproj", "nh.qhatu.infrastructure.bus/"]
COPY ["nh.qhatu.omnichannel.application/nh.qhatu.omnichannel.application.csproj", "nh.qhatu.omnichannel.application/"]
COPY ["nh.qhatu.omnichannel.domain/nh.qhatu.omnichannel.domain.csproj", "nh.qhatu.omnichannel.domain/"]
COPY ["nh.qhatu.omnichannel.infrastructure/nh.qhatu.omnichannel.infrastructure.csproj", "nh.qhatu.omnichannel.infrastructure/"]
RUN dotnet restore "nh.qhatu.omnichannel.api/nh.qhatu.omnichannel.api.csproj"
COPY . .
WORKDIR "/src/nh.qhatu.omnichannel.api"
RUN dotnet build "nh.qhatu.omnichannel.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "nh.qhatu.omnichannel.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "nh.qhatu.omnichannel.api.dll"]