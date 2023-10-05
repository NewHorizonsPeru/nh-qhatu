#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["nh.qhatu.security.api/nh.qhatu.security.api.csproj", "nh.qhatu.security.api/"]
COPY ["nh.qhatu.infrastructure.ioc/nh.qhatu.infrastructure.ioc.csproj", "nh.qhatu.infrastructure.ioc/"]
COPY ["nh.qhatu.common.infrastructure.data/nh.qhatu.common.infrastructure.data.csproj", "nh.qhatu.common.infrastructure.data/"]
COPY ["nh.qhatu.common.domain.core/nh.qhatu.common.domain.core.csproj", "nh.qhatu.common.domain.core/"]
COPY ["nh.qhatu.customer.infrastructure.data/nh.qhatu.customer.infrastructure.data.csproj", "nh.qhatu.customer.infrastructure.data/"]
COPY ["nh.qhatu.customer.domain.core/nh.qhatu.customer.domain.core.csproj", "nh.qhatu.customer.domain.core/"]
COPY ["nh.qhatu.infrastructure.bus/nh.qhatu.infrastructure.bus.csproj", "nh.qhatu.infrastructure.bus/"]
COPY ["nh.qhatu.domain.core/nh.qhatu.domain.core.csproj", "nh.qhatu.domain.core/"]
COPY ["nh.qhatu.omnichannel.infrastructure.data/nh.qhatu.omnichannel.infrastructure.data.csproj", "nh.qhatu.omnichannel.infrastructure.data/"]
COPY ["nh.qhatu.omnichannel.domain.core/nh.qhatu.omnichannel.domain.core.csproj", "nh.qhatu.omnichannel.domain.core/"]
COPY ["nh.qhatu.security.infrastructure.data/nh.qhatu.security.infrastructure.data.csproj", "nh.qhatu.security.infrastructure.data/"]
COPY ["nh.qhatu.security.domain.core/nh.qhatu.security.domain.core.csproj", "nh.qhatu.security.domain.core/"]
COPY ["nh.qhatu.security.application.core/nh.qhatu.security.application.core.csproj", "nh.qhatu.security.application.core/"]
COPY ["nh.qhatu.infrasctructure.crosscutting/nh.qhatu.infrasctructure.crosscutting.csproj", "nh.qhatu.infrasctructure.crosscutting/"]
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